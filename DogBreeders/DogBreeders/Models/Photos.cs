using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeders.Models {

   /// <summary>
   /// Photos of the dogs
   /// </summary>
   public class Photos {


      /// <summary>
      /// Primary Key (PK) of table Photos
      /// </summary>
      [Key]
      public int Id { get; set; }


      /// <summary>
      /// name of file that has the photo of dog 
      /// </summary>
      public string NameOfPhoto { get; set; }

      /// <summary>
      /// date of photo
      /// </summary>
      public DateTime Date { get; set; }

      /// <summary>
      /// place where the photo was taken
      /// </summary>
      [Display(Name ="Local where the Photo was taken")]
      public string Local { get; set; }

      //*********************************************************
      // making the FK from the Photo to the Dog
      //*********************************************************
      [ForeignKey("Dog")] // with this annotation we are connecting
                          // attribute 'DogFK' with attribute 'Dog'
      public int DogFK { get; set; } // mark 'Dog' as FK in DB

      public Dogs Dog { get; set; } // Photo has only one Dog
                                    // mark 'Dog' as FK in C#
                                    // This is the only attribute that we realy nead
                                    // the other attributs are for programmers confort

      //*********************************************************



   }
}
