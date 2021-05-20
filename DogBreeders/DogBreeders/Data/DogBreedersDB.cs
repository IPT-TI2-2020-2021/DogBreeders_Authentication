using DogBreeders.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace DogBreeders.Data {
   public class DogBreedersDB : IdentityDbContext {
      public DogBreedersDB(DbContextOptions<DogBreedersDB> options)
          : base(options) {
      }



      //public void OnModelCreating() { }
      protected override void OnModelCreating(ModelBuilder modelBuilder) {

         base.OnModelCreating(modelBuilder);

         // insert DB seed

         modelBuilder.Entity<Breeds>().HasData(
            new Breeds { Id = 1, Name = "Retriever do Labrador" },
            new Breeds { Id = 2, Name = "Serra da Estrela" },
            new Breeds { Id = 3, Name = "Pastor Alemão" },
            new Breeds { Id = 4, Name = "Dogue Alemão" },
            new Breeds { Id = 5, Name = "S. Bernardo" },
            new Breeds { Id = 6, Name = "Rafeiro do Alentejo" },
            new Breeds { Id = 7, Name = "Golden Retriever" },
            new Breeds { Id = 8, Name = "Border Collie" }
         );

         modelBuilder.Entity<DogBreeder>().HasData(
            new DogBreeder { Id = 1, Name = "Marisa Vieira", Address = "Largo do Pelourinho", PostalCode = "2305 - 515 PAIALVO", Email = "Marisa.Freitas@iol.pt", CellPhone = "967197885" },
            new DogBreeder { Id = 2, Name = "Fátima Ribeiro", Address = "Praça Infante Dom Henrique", PostalCode = "2300 - 551 TOMAR", Email = "Fátima.Machado@gmail.com", CellPhone = "963737476" },
            new DogBreeder { Id = 4, Name = "Paula Silva", Address = "Bairro Pimenta", PostalCode = "2300 - 324 TOMAR", Email = "Paula.Lopes@iol.pt", CellPhone = "967517256" },
            new DogBreeder { Id = 5, Name = "Mariline Marques", Address = "Zona Industrial", PostalCode = "2305 - 127 ASSEICEIRA TMR", Email = "Mariline.Martins@sapo.pt", CellPhone = "967212144" },
            new DogBreeder { Id = 6, Name = "Marcos Rocha", Address = "Rua de Bacelos", PostalCode = "2475 - 013 BENEDITA", Email = "Marcos.Rocha@sapo.pt", CellPhone = "962125638" },
            new DogBreeder { Id = 7, Name = "Alexandre Vieira", Address = "Rua João Pedro Costa", PostalCode = "7630 - 782 ZAMBUJEIRA DO MAR", Email = "Alexandre.Dias@hotmail.com", CellPhone = "961493756" },
            new DogBreeder { Id = 8, Name = "Paula Soares", Address = "Praça Infante Dom Henrique", PostalCode = "2300 - 551 TOMAR", Email = "Paula.Vieira@clix.pt", CellPhone = "961937768" },
            new DogBreeder { Id = 9, Name = "Mariline Santos", Address = "Rua Corredora do Mestre (Palhavã de Cima)", PostalCode = "2300 - 390 TOMAR", Email = "Mariline.Ribeiro@iol.pt", CellPhone = "964106478" },
            new DogBreeder { Id = 10, Name = "Roberto Pinto", Address = "Largo do Flecheiro", PostalCode = "2300 - 635 TOMAR", Email = "Roberto.Vieira@sapo.pt", CellPhone = "964685937" }
         );

         modelBuilder.Entity<Dogs>().HasData(
            new Dogs { Id = 1, Name = "Aguia da Quinta do Conde", Sex = "F", DateOfBirth = new DateTime(2019, 4, 16), BreedFK = 1 },
            new Dogs { Id = 2, Name = "Aileen da Quinta do Lordy", Sex = "F", DateOfBirth = new DateTime(2019, 10, 10), BreedFK = 1 },
            new Dogs { Id = 3, Name = "Aladim do Canto do Bairro Pimenta", Sex = "F", DateOfBirth = new DateTime(2011, 3, 22), BreedFK = 5 },
            new Dogs { Id = 4, Name = "Albert do Canto do Bairro Pimenta", Sex = "F", DateOfBirth = new DateTime(2008, 6, 8), BreedFK = 5 },
            new Dogs { Id = 5, Name = "Alabaster da Casa do Sobreiral", Sex = "F", DateOfBirth = new DateTime(2012, 8, 21), BreedFK = 2 },
            new Dogs { Id = 6, Name = "Gannett do Quintal de Cima", Sex = "F", DateOfBirth = new DateTime(2010, 10, 1), BreedFK = 6 },
            new Dogs { Id = 7, Name = "Gardenia da Tapada de Cima", Sex = "F", DateOfBirth = new DateTime(2010, 12, 11), BreedFK = 3 },
            new Dogs { Id = 8, Name = "Forte da Flecha do Indio", Sex = "F", DateOfBirth = new DateTime(2013, 4, 22), BreedFK = 7 },
            new Dogs { Id = 9, Name = "Garbo da Flecha do Indio", Sex = "M", DateOfBirth = new DateTime(2011, 5, 10), BreedFK = 7 },
            new Dogs { Id = 10, Name = "Garfunkle da Quinta do Lordy", Sex = "F", DateOfBirth = new DateTime(2017, 3, 21), BreedFK = 4 },
            new Dogs { Id = 11, Name = "Garnet do Quintal de Cima", Sex = "M", DateOfBirth = new DateTime(2018, 1, 4), BreedFK = 8 }
         );

         modelBuilder.Entity<Photos>().HasData(
            new Photos { Id = 1, NameOfPhoto = "Retriever_do_labrador.jpg", Local = "", Date = new DateTime(2019, 5, 20), DogFK = 1 },
            new Photos { Id = 2, NameOfPhoto = "Retriever_do_labrador_2.jpg", Local = "", Date = new DateTime(2019, 5, 20), DogFK = 1 },
            new Photos { Id = 3, NameOfPhoto = "Retriever_do_labrador_3.jpg", Local = "", Date = new DateTime(2019, 11, 18), DogFK = 2 },
            new Photos { Id = 4, NameOfPhoto = "s.bernardo.jpg", Local = "", Date = new DateTime(2021, 1, 17), DogFK = 3 },
            new Photos { Id = 5, NameOfPhoto = "s.bernardo_2.jpg", Local = "casa", Date = new DateTime(2019, 3, 7), DogFK = 4 },
            new Photos { Id = 6, NameOfPhoto = "serra_da_estrela.jpg", Local = "", Date = new DateTime(2013, 10, 21), DogFK = 5 },
            new Photos { Id = 7, NameOfPhoto = "serra_da_estrela_2.jpg", Local = "", Date = new DateTime(2012, 10, 1), DogFK = 5 },
            new Photos { Id = 8, NameOfPhoto = "Rafeiro_do_Alentejo.jpg", Local = "Quinta", Date = new DateTime(2020, 10, 1), DogFK = 6 },
            new Photos { Id = 9, NameOfPhoto = "pastor_alemao_2.jpg", Local = "", Date = new DateTime(2011, 1, 4), DogFK = 7 },
            new Photos { Id = 10, NameOfPhoto = "pastor_alemao.jpg", Local = "", Date = new DateTime(2020, 12, 6), DogFK = 7 },
            new Photos { Id = 11, NameOfPhoto = "golden-retriever_2.jpg", Local = "", Date = new DateTime(2018, 12, 23), DogFK = 8 },
            new Photos { Id = 12, NameOfPhoto = "golden-retriever.jpg", Local = "ninhada", Date = new DateTime(2017, 1, 5), DogFK = 8 },
            new Photos { Id = 13, NameOfPhoto = "Golden-Retriever-1.jpg", Local = "", Date = new DateTime(2020, 2, 2), DogFK = 9 },
            new Photos { Id = 14, NameOfPhoto = "Dogue_Alemao.jpg", Local = "Casa da tia Ana", Date = new DateTime(2021, 4, 13), DogFK = 10 },
            new Photos { Id = 15, NameOfPhoto = "border_collie.jpg", Local = "quintal", Date = new DateTime(2021, 2, 4), DogFK = 11 }
         );

         modelBuilder.Entity<DogBreederDogs>().HasData(
            new DogBreederDogs { Id = 1, DogFK = 1, DogBreederFK = 1 },
            new DogBreederDogs { Id = 2, DogFK = 2, DogBreederFK = 2 },
            new DogBreederDogs { Id = 3, DogFK = 3, DogBreederFK = 4 },
            new DogBreederDogs { Id = 4, DogFK = 4, DogBreederFK = 5 },
            new DogBreederDogs { Id = 5, DogFK = 5, DogBreederFK = 6 },
            new DogBreederDogs { Id = 6, DogFK = 6, DogBreederFK = 7 },
            new DogBreederDogs { Id = 7, DogFK = 7, DogBreederFK = 8 },
            new DogBreederDogs { Id = 8, DogFK = 8, DogBreederFK = 9 },
            new DogBreederDogs { Id = 9, DogFK = 9, DogBreederFK = 10 },
            new DogBreederDogs { Id = 10, DogFK = 10, DogBreederFK = 5 },
            new DogBreederDogs { Id = 11, DogFK = 11, DogBreederFK = 8 }
         );

      }


      // connect our classes with the DataBase
      // these attributes represents the tables in the database
      public DbSet<Dogs> Dogs { get; set; }
      public DbSet<DogBreeder> DogBreeders { get; set; }
      public DbSet<DogBreederDogs> DogBreedersDogs { get; set; }
      public DbSet<Photos> Photos { get; set; }
      public DbSet<Breeds> Breeds { get; set; }

      public DbSet<Veterinary> Vets { get; set; }




   }
}
