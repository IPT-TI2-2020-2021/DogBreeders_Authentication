using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogBreeders.Data;
using DogBreeders.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DogBreeders.Controllers {
   /// <summary>
   /// Controller to work with the Photos of dogs
   /// </summary>
   public class PhotosController : Controller {

      /// <summary>
      /// reference to our project Database
      /// </summary>
      private readonly DogBreedersDB _db;

      /// <summary>
      /// variable that stores all data related with server
      /// </summary>
      private readonly IWebHostEnvironment _path;

      public PhotosController(DogBreedersDB context, IWebHostEnvironment path) {
         _db = context;
         _path = path;
      }




      // GET: Photos
      /// <summary>
      /// Method to process the Index requests
      /// </summary>
      /// <returns></returns>
      public async Task<IActionResult> Index() {

         /* 
          * SELECT *
          * FROM Photos INNER JOIN Dogs ON Photos.DogFK = Dogs.Id
          *             INNER JOIN Breeds ON Dogs.BreedsFK = Breeds.Id
          */
         var ListOfPhotos = _db.Photos.Include(p => p.Dog)
                                      .ThenInclude(d => d.Breed);  // LINQ

         // send the control to View, and from there to the browser
         return View(await ListOfPhotos.ToListAsync());
      }







      // GET: Photos/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var photos = await _db.Photos
             .Include(p => p.Dog)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (photos == null) {
            return NotFound();
         }

         return View(photos);
      }




      // GET: Photos/Create
      /// <summary>
      /// This method shows to users the form to add a new photo, 
      /// at the first time that a user wants to add a photo
      /// </summary>
      /// <returns></returns>
      public IActionResult Create() {

         ViewData["Dogs"] = new SelectList(_db.Dogs.OrderBy(d => d.Name), "Id", "Name");

         return View();
      }



      // POST: Photos/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,NameOfPhoto,Date,Local,DogFK")] Photos photos, IFormFile photoOfDog) {

         /*
          * Algorithm to deal with file of photos of dogs
          * - if there is no file,
          *     - do not accept the record
          *     - write it to user, at browser
          * - if the file was not good (.png ,.jpg are good files)
          *     - do not accept the record
          *     - write it to user, at browser
          * - if you came to here, is because the file is good
          *    - decide the name of file
          *    - assign the file name to data colected by the form
          *    - write the file on the disc drive
          */

         if (photoOfDog == null) {
            // if you came to here, there is no file
            // write a error message
            ModelState.AddModelError("", "you haven't choose a file. Please, pick one...");
            // send the control to Browser
            ViewData["Dogs"] = new SelectList(_db.Dogs.OrderBy(d => d.Name), "Id", "Name");
            return View();
         }

         if (photoOfDog.ContentType != "image/jpeg" && photoOfDog.ContentType != "image/png") {
            // if you came to here, there is a file
            // but, the file is not good
            // write a error message
            ModelState.AddModelError("", "Your file is not of correct type. Please, choose PNG or JPG image...");
            // send the control to Browser
            ViewData["Dogs"] = new SelectList(_db.Dogs.OrderBy(d => d.Name), "Id", "Name");
            return View();
         }

         // if you came to here, you have a good file...
         //Decide the name of your file
         Guid g;
         g = Guid.NewGuid();
         // determining the extension of file
         string extension = Path.GetExtension(photoOfDog.FileName).ToLower();
         // new name of file
         string nameOfFile = photos.DogFK + "_" + g.ToString() + extension;
         // assign new file name to 'photos'
         photos.NameOfPhoto = nameOfFile;

         if (ModelState.IsValid) {
            _db.Add(photos);
            await _db.SaveChangesAsync();
            // because all data was stored on DB,
            // we are going to store de file on the disc drive of server
            // Where you want the file to be stored?
            string whereToStoreTheFile = _path.WebRootPath;
            nameOfFile = Path.Combine(whereToStoreTheFile, "fotos", nameOfFile);
            // write the file
            using var stream = new FileStream(nameOfFile, FileMode.Create);
            await photoOfDog.CopyToAsync(stream);

            return RedirectToAction(nameof(Index));
         }
         ViewData["DogFK"] = new SelectList(_db.Dogs, "Id", "Id", photos.DogFK);
         return View(photos);
      }

      // GET: Photos/Edit/5
      public async Task<IActionResult> Edit(int? id) {
        // evaluate if the user specifies the ID of the photo that shoud be edited
         if (id == null) {
            return NotFound();
         }

         // trying to find the photo
         var photo = await _db.Photos.FindAsync(id);

         // if the photo was not found, nothing can be done
         if (photo == null) {
            return NotFound();
         }

         // selecting the name of dogs that could be related with photos
         // this data is to be used on dropdown
         ViewData["DogFK"] = new SelectList(_db.Dogs, "Id", "Name", photo.DogFK);

         //**************************************************************************
         // write in a session variable the value that is going to be send to Browser
         // I write it here because the users can't change values here
         HttpContext.Session.SetInt32("PhotoId", photo.Id);

         // sending data to View
         return View(photo);
      }

      // POST: Photos/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfPhoto,Date,Local,DogFK")] Photos photo) {
         if (id != photo.Id) {
            return NotFound();
         }

         // recall the value that was stored when the user starts the photo edition
         var numPhotoId = HttpContext.Session.GetInt32("PhotoId");

         // if the ID of photo that we sent to browser is different from the the ID that we receive on Controller
         // I do not do nothing
         if (numPhotoId != photo.Id) {
            // my user is trying to damage my data
            // I'm going to sent it to Index page
            return RedirectToAction("Index");
         }



         if (ModelState.IsValid) {
            try {
               _db.Update(photo);
               await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!PhotosExists(photo.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         ViewData["DogFK"] = new SelectList(_db.Dogs, "Id", "Name", photo.DogFK);
         return View(photo);
      }

      // GET: Photos/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var photos = await _db.Photos
             .Include(p => p.Dog)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (photos == null) {
            return NotFound();
         }

         return View(photos);
      }

      // POST: Photos/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {
         var photos = await _db.Photos.FindAsync(id);
         _db.Photos.Remove(photos);
         await _db.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool PhotosExists(int id) {
         return _db.Photos.Any(e => e.Id == id);
      }
   }
}
