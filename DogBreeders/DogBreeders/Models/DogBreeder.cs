using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeders.Models {

   /// <summary>
   /// represents the owners of dogs
   /// </summary>
   public class DogBreeder {

      public DogBreeder() {
         Dogs = new HashSet<DogBreederDogs>();
      }

      /// <summary>
      /// Primary Key (PK) of table DogBreeds
      /// </summary>
      [Key]
      public int Id { get; set; }

      /// <summary>
      /// name of dog breeder
      /// </summary>
      [Required]
      public string Name { get; set; }

      /// <summary>
      /// Address
      /// </summary>
      public string Address { get; set; }

      /// <summary>
      /// Postal code of dog breeder's address
      /// </summary>
      //  [1-9][0-9]{3}-[0-9]{3}
      /*  2300-313
       *  1000-000
       */
      [RegularExpression("[1-9][0-9]{3}-[0-9]{3}( [a-zA-ZçÇÀÁ]+)+",
         ErrorMessage ="write a valid postal code. Write 4 numbers, a - sign, 3 numbers ande the name of your town.")]
      [StringLength(60)]
      public string PostalCode { get; set; }

      /// <summary>
      /// Email
      /// </summary>
      [Required]
      [EmailAddress]
      [RegularExpression("aluno[0-9]{5}@ipt.pt")] // aluno00300@ipt.pt
      public string Email { get; set; }

      /// <summary>
      /// cell phone
      /// </summary>
      [Required]
      [RegularExpression("[1-9][0-9]{5,8}",ErrorMessage ="you must use only from 6 to 9 numbers")]
      [StringLength(9, MinimumLength =6)]
      public string CellPhone { get; set; }
      // Regular expressions
      // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions
      // https://regexr.com/
      // https://www.regular-expressions.info/




      //**********************************************************
      // List of DogBreedersDogs
      //**********************************************************
      /// <summary>
      /// represents the list of Dogs that the dog breeder has
      /// </summary>
      public ICollection<DogBreederDogs> Dogs { get; set; }
      //**********************************************************


   }
}
