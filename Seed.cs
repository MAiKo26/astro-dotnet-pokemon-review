using PokemonReviewAPI.Data;
using PokemonReviewAPI.Models;


namespace PokemonReviewApp
{

    // Go through the models and modify them correctly !
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Description = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", Country=new Country(){Name= "Safari City" } } },
                                new Review { Title="Pikachu", Description = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", Country=new Country(){Name= "Safari City" }  } },
                                new Review { Title="Pikachu",Description = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", Country=new Country(){Name= "Safari City" } } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            City = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Description = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", Country=new Country(){Name= "Safari City" }  } },
                                new Review { Title= "Squirtle",Description = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", Country=new Country(){Name= "Safari City" } } },
                                new Review { Title= "Squirtle", Description = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", Country=new Country(){Name= "Safari City" } } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            City = "Mistys Gym",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Description = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", Country=new Country(){Name= "Safari City" } } },
                                new Review { Title="Veasaur",Description = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", Country=new Country(){Name= "Safari City" } } },
                                new Review { Title="Veasaur",Description = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", Country=new Country(){Name= "Safari City" } } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash",
                            City = "Mourouj",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}