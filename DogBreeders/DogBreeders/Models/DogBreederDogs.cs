using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeders.Models {

   /// <summary>
   /// this class represents the 
   /// relationship bettween Dogs and Dog Breeders   
   /// </summary>
   public class DogBreederDogs {

      /// <summary>
      /// Primary Key (PK) of table DogBreedDogs
      /// </summary>
      [Key]
      public int Id { get; set; }



      //**********************************************************
      // FK to DogBreeders
      //**********************************************************
      [ForeignKey("DogBreeder")]
      public int DogBreederFK { get; set; }
      public DogBreeder DogBreeder { get; set; }
      //**********************************************************

      //**********************************************************
      // FK to Dogs
      //**********************************************************
      [ForeignKey("Dog")]
      public int DogFK { get; set; }
      public Dogs Dog { get; set; }
      //**********************************************************

   }
}
