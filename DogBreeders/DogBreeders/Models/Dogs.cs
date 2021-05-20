using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeders.Models {

   /// <summary>
   /// represents the Dogs that some dog breeder has
   /// </summary>
   public class Dogs {

      /// <summary>
      /// constructor
      /// </summary>
      public Dogs() {
         // access to DB, and read all Photos that the Dog has
         Photos = new HashSet<Photos>();
         // access to DB, and read all Dog Breeders that are connected with the dog
         DogBreeders = new HashSet<DogBreederDogs>();
         
         // List of Vets that treated the dog
         Vets = new HashSet<Veterinary>();
      }

      /// <summary>
      /// Primary Key (PK) of table Dogs
      /// </summary>
      [Key]
      public int Id { get; set; }

      /// <summary>
      /// Name of dog
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Sex of dog
      /// </summary>
      public string Sex { get; set; }

      /// <summary>
      /// Birth date of dog
      /// </summary>
      public DateTime DateOfBirth { get; set; }

      //******************************************************************
      /// <summary>
      ///  Dog has a list of Photos
      /// </summary>
      public ICollection<Photos> Photos { get; set; }
      //******************************************************************


      //******************************************************************
      // FK from Dog to Breed
      //******************************************************************
      [ForeignKey("Breed")]
      public int BreedFK { get; set; }  // FK to Breed, in DB
      public Breeds Breed { get; set; } // FK to Breed, in C#

      //******************************************************************

      //**********************************************************
      // List of DogBreedersDogs
      //**********************************************************
      /// <summary>
      /// represents the list of DogBreeders that the dog is connected to
      /// </summary>
      public ICollection<DogBreederDogs> DogBreeders { get; set; }
      //**********************************************************


      //*******************************************************
      /// <summary>
      /// List of Vets that treated the dog
      /// M-N relationship
      /// </summary>
      public ICollection<Veterinary> Vets { get; set; }


   }
}
