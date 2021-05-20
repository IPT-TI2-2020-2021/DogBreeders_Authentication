using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeders.Models {
   public class Veterinary {

      public Veterinary() {
         ListOfDogs = new HashSet<Dogs>();
      }

      [Key]
      public int Id { get; set; }

      /// <summary>
      /// Name of Veterinary
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// List of Dogs that each Vet has treated
      /// M-N relationship
      /// </summary>
      public ICollection<Dogs> ListOfDogs { get; set; }



   }
}
