using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MongoDB.Driver;
using Shopping.API.Model;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedDataAsync(Products).GetAwaiter().GetResult();
        }

        public IMongoCollection<Product> Products { get; }

        public static async Task SeedDataAsync(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                await productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    
                    Name = "IPhone 13",
                    Category = "Smart Phone",
                    Description = "IPhone 13 with A15 Bionic chip, 6.1-inch Super Retina XDR display, and advanced dual-camera system.",
                    ImageFile = "iphone13.jpg",
                    Price = 799.00M
                },

                new Product
                {
                    //Id = "2",
                    Name = "Samsung Galaxy S21",
                    Category = "Smart Phone",
                    Description = "Samsung Galaxy S21 with Exynos 2100, 6.2-inch Dynamic AMOLED display, and pro-grade camera system.",
                    ImageFile = "galaxys21.jpg",
                    Price = 699.00M
                },
                new Product
                {
                    //Id = "3",
                    Name = "Google Pixel 6",
                    Category = "Smart Phone",
                    Description = "Google Pixel 6 with Google Tensor chip, 6.4-inch AMOLED display, and advanced camera features.",
                    ImageFile = "pixel6.jpg",
                    Price = 599.00M
                },
                new Product
                {
                    //Id = "4",
                    Name = "OnePlus 9",
                    Category = "Smart Phone",
                    Description = "OnePlus 9 with Snapdragon 888, 6.55-inch Fluid AMOLED display, and Hasselblad Camera for Mobile.",
                    ImageFile = "oneplus9.jpg",
                    Price = 729.00M
                },
                new Product
                {
                    //Id = "5",
                    Name = "Sony WH-1000XM4",
                    Category = "Headphones",
                    Description = "Sony WH-1000XM4 wireless noise-canceling headphones with superior sound quality and comfort.",
                    ImageFile = "sonywh1000xm4.jpg",
                    Price = 349.99M
                },
                new Product
                {
                   // Id = "6",
                    Name = "Bose QuietComfort 35 II",
                    Category = "Headphones",
                    Description = "Bose QuietComfort 35 II wireless headphones with world-class noise cancellation and Alexa voice control.",
                    ImageFile = "boseqc35ii.jpg",
                    Price = 299.99M
                }

            };
        }

    }
}
