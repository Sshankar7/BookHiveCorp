using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHiveCorp.Models
{
    public class SampleData
    {
        public void Seed(BookHiveCorpEntities context)
        {
            const string imgUrl = "~/Images/placeholder.gif";

            AddBooks(context, imgUrl, AddCategories(context), AddAuthors(context));

            context.SaveChanges();
        }
        private static void AddBooks(
            BookHiveCorpEntities context,
            string imgUrl,
            List<Category> categories,
            List<Author> authors)
        {
            var books = new[]
            {
                new Book
                {
                    Title = "Indian Philosophy Vol 1 ",
                    Category = categories.Single(c => c.Name == "Philosophy"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "S Radhakrishnan"),
                    BookArtUrl = "~/Images/Philosophy/p1.jpg"
                },
                new Book
                {
                    Title = "Mahabharata Secret",
                    Category = categories.Single(c => c.Name == "Philosophy"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Christopher C Doyle"),
                    BookArtUrl = "~/Images/Philosophy/p2.jpg"
                },
                new Book
                {
                    Title = "Code Name God",
                    Category = categories.Single(c => c.Name == "Philosophy"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Mani Bhaumik"),
                    BookArtUrl = "~/Images/Philosophy/p3.jpg"
                },
                new Book
                {
                    Title = "Think On These Things W/cd ",
                    Category = categories.Single(c => c.Name == "Philosophy"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "J Krishnamurti"),
                    BookArtUrl = "~/Images/Philosophy/p4.jpg"
                },
                new Book
                {
                    Title = "Power Of Your Subconscious Mind ",
                    Category = categories.Single(c => c.Name == "Philosophy"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Joseph Murphy"),
                    BookArtUrl ="~/Images/Philosophy/p5.jpg"
                },
                new Book
                {
                    Title = "Chained: Can you escape fate?",
                    Category = categories.Single(c => c.Name == "Indian Writing"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Mehek Bassi"),
                    BookArtUrl = "~/Images/Indian writing/i2.jpeg"
                },
                new Book
                {
                    Title = "Digital Fortress",
                    Category = categories.Single(c => c.Name == "Non Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Dan Brown"),
                    BookArtUrl ="~/Images/Non Fiction/n2.jpg"
                },
                new Book
                {
                    Title = "Wings Of Fire An Autobiography",
                    Category = categories.Single(c => c.Name == "Indian Writing"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "APJ Abdul Kalam"),
                    BookArtUrl = "~/Images/Indian writing/i1.jpg"
                },
                new Book
                {
                    Title = "Secret Wish List",
                    Category = categories.Single(c => c.Name == "Indian Writing"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Preeti Shenoy"),
                    BookArtUrl ="~/Images/Indian writing/i3.jpg"
                },
                new Book
                {
                    Title = "Sita : An Illustrated Retelling Of Ramayana",
                    Category = categories.Single(c => c.Name == "Indian Writing"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Devdutt Pattanaik"),
                    BookArtUrl ="~/Images/Indian writing/i4.jpg"
                },
                new Book
                {
                    Title = "Kite Runner",
                    Category = categories.Single(c => c.Name == "Indian Writing"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Khaled Hosseini"),
                    BookArtUrl = "~/Images/Indian writing/i5.jpg"
                },
                new Book
                {
                    Title = "Sycamore Row",
                    Category = categories.Single(c => c.Name == "Non Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "John Grisham"),
                    BookArtUrl = "~/Images/Non Fiction/n1.jpg"
                },
                 new Book
                {
                    Title = "Inferno",
                    Category = categories.Single(c => c.Name == "Non Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Dan Brown"),
                    BookArtUrl = "~/Images/Non Fiction/n3.jpg"
                },
                new Book
                {
                    Title = "Narendra Modi : The Man The Times",
                    Category = categories.Single(c => c.Name == "Non Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Nilanjan Mukhopadhyay"),
                    BookArtUrl = "~/Images/Non Fiction/n4.jpg"
                },
                new Book
                {
                    Title = "Angels & Demons",
                    Category = categories.Single(c => c.Name == "Non Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Dan Brown"),
                    BookArtUrl = "~/Images/Non Fiction/n5.jpg"
                },
                 new Book
                {
                    Title = "Concise Inorganic Chemistry ",
                    Category = categories.Single(c => c.Name == "Academics"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "JD Lee"),
                    BookArtUrl = "~/Images/Academic/a1.jpg"
                },
                 new Book
                {
                    Title = "Modern Indian Literature",
                    Category = categories.Single(c => c.Name == "Academics"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Na"),
                    BookArtUrl = "~/Images/Academic/a2.jpg"
                },
                new Book
                {
                    Title = "Data Communications & Networking",
                    Category = categories.Single(c => c.Name == "Academics"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Behrouz A Forouzan"),
                    BookArtUrl = "~/Images/Academic/a3.jpg"
                },
                new Book
                {
                    Title = "Unix Concepts & Applications",
                    Category = categories.Single(c => c.Name == "Academics"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Sumitabha Das"),
                    BookArtUrl = "~/Images/Academic/a4.jpg"
                },
                 new Book
                {
                    Title = "Environmental Studies From Crisis To Cure",
                    Category = categories.Single(c => c.Name == "Academics"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "R Rajagopalan"),
                    BookArtUrl = "~/Images/Academic/a5.jpg"
                },
                 new Book
                {
                    Title = "My First Book - Animals",
                    Category = categories.Single(c => c.Name == "Children"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Na"),
                    BookArtUrl = "~/Images/Children/c1.jpg"
                },
                new Book
                {
                    Title = "My First Book Of Food : Young Learners",
                    Category = categories.Single(c => c.Name == "Children"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Na"),
                    BookArtUrl = "~/Images/Children/c2.jpg"
                },
                new Book
                {
                    Title = "Popular Moral Stories : Young Learners ",
                    Category = categories.Single(c => c.Name == "Children"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Na"),
                    BookArtUrl = "~/Images/Children/c3.jpg"
                },
                new Book
                {
                    Title = "The Haunted Castle : 46 ",
                    Category = categories.Single(c => c.Name == "Children"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Geronimo Stilton"),
                    BookArtUrl = "~/Images/Children/c4.jpg"
                },
                new Book
                {
                    Title = "Krishna Key",
                    Category = categories.Single(c => c.Name == "Children"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Ashwin Sanghi"),
                    BookArtUrl = "~/Images/Children/c5.jpg"
                },
                new Book
                {
                    Title = "Thousand Splendid Suns ",
                    Category = categories.Single(c => c.Name == "Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Khaled Hosseini"),
                    BookArtUrl = "~/Images/Fiction/f1.jpg"
                },
                new Book
                {
                    Title = "Mute Anklet ",
                    Category = categories.Single(c => c.Name == "Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Radhika Nathan"),
                    BookArtUrl = "~/Images/Fiction/f2.jpg"
                },
                new Book
                {
                    Title = "World Famous Ghosts  ",
                    Category = categories.Single(c => c.Name == "Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Ashok Kumar Sharma"),
                    BookArtUrl = "~/Images/Fiction/f3.jpg"
                },
                new Book
                {
                    Title = "Curse Of The Mummy's Tomb Goosebumps 5 ",
                    Category = categories.Single(c => c.Name == "Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Rl Stine"),
                    BookArtUrl = "~/Images/Fiction/f4.jpg"
                },
                new Book
                {
                    Title = "Godfather",
                    Category = categories.Single(c => c.Name == "Fiction"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Mario Puzo"),
                    BookArtUrl = "~/Images/Fiction/f5.jpg"
                },
                new Book
                {
                    Title = "Yuvraj Singh : Powerful Elegance ",
                    Category = categories.Single(c => c.Name == "Sports"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Ayaz Memon"),
                    BookArtUrl = "~/Images/Sports/s1.jpg"
                },
                new Book
                {
                    Title = "Saina Nehwal : An Insiprational Biography ",
                    Category = categories.Single(c => c.Name == "Sports"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "TS Sudhir"),
                    BookArtUrl = "~/Images/Sports/s2.jpg"
                },
                 new Book
                {
                    Title = "Race Of My Life ",
                    Category = categories.Single(c => c.Name == "Sports"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Milkha Singh"),
                    BookArtUrl = "~/Images/Sports/s3.jpg"
                },
                 new Book
                {
                    Title = "Sachin Tendulkar : Master Blaster ",
                    Category = categories.Single(c => c.Name == "Sports"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Ayaz Memon"),
                    BookArtUrl = "~/Images/Sports/s4.jpg"
                },
                new Book
                {
                    Title = "Rafa My Story",
                    Category = categories.Single(c => c.Name == "Sports"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "John Carlin"),
                    BookArtUrl = "~/Images/Sports/s5.jpg"
                },
                new Book
                {
                    Title = "Knowing Sant Kabir - Life & Teachings",
                    Category = categories.Single(c => c.Name == "Religion & Sprituality"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Shrikant Prasoon"),
                    BookArtUrl = "~/Images/Religion/sp1.jpg"
                },
                new Book
                {
                    Title = "Lords Song Gita",
                    Category = categories.Single(c => c.Name == "Religion & Sprituality"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Sant K Bhatnagar"),
                    BookArtUrl = "~/Images/Religion/sp2.jpg"
                },
                new Book
                {
                    Title = "Symbiosis Of Science & Spirituality",
                    Category = categories.Single(c => c.Name == "Religion & Sprituality"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Sampooran Singh"),
                    BookArtUrl = "~/Images/Religion/sp3.jpg"
                },
                new Book
                {
                    Title = "Bad Boys Of Bokaro Jail",
                    Category = categories.Single(c => c.Name == "Religion & Sprituality"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Chetan Mahajan"),
                    BookArtUrl = "~/Images/Religion/sp4.jpg"
                },
                new Book
                {
                    Title = "Chanakya Neeti : Sutras Of Chanakya Included",
                    Category = categories.Single(c => c.Name == "Religion & Sprituality"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "BK Chaturvedi"),
                    BookArtUrl = "~/Images/Religion/sp5.jpg"
                },
                new Book
                {
                    Title = "Man Eaters Of Kumaon ",
                    Category = categories.Single(c => c.Name == "Travel"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Jim Corbett"),
                    BookArtUrl = "~/Images/Travel/t1.jpg"
                },
                 new Book
                {
                    Title = "Meet Me At The Border",
                    Category = categories.Single(c => c.Name == "Travel"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Inder Raj Ahluwala"),
                    BookArtUrl = "~/Images/Travel/t2.jpg"
                },
                new Book
                {
                    Title = "Riding The Himalayas",
                    Category = categories.Single(c => c.Name == "Travel"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Keki N Daruwalla"),
                    BookArtUrl = "~/Images/Travel/t3.jpg"
                },
                new Book
                {
                    Title = "Motorcycle Diaries",
                    Category = categories.Single(c => c.Name == "Travel"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Ernesto Che Guevara"),
                    BookArtUrl = "~/Images/Travel/t4.jpg"
                },
                new Book
                {
                    Title = "Is God Dead?: The Truth about Jammu & Kashmir",
                    Category = categories.Single(c => c.Name == "Travel"),
                    Price = 8.99M,
                    Author = authors.Single(a => a.Name == "Raghubir Lal Anand"),
                    BookArtUrl = "~/Images/Travel/t5.jpg"
                },

            };

            context.Books.AddRange(books);
        }

        private static List<Author> AddAuthors(BookHiveCorpEntities context)
        {
            var authors = new List<Author>
            {
                new Author { Name = "Amish" },
                new Author { Name = "Andrea Pirlo" },
                new Author { Name = "Ajay" },
                new Author { Name = "APJ Abdul Kalam" },
                new Author { Name = "Ashok Kumar Sharma" },
                new Author { Name = "Ashwin Sanghi" },
                new Author { Name = "Ayaz Memon" },
                new Author { Name = "Behrouz A Forouzan" },
                new Author { Name = "BK Chaturvedi" },
                new Author { Name = "Bornious plantinga Jr." },
                new Author { Name = "Brandon Statanton" },
                new Author { Name = "British Horse Society" },
                new Author { Name = "Cheryl Strayed" },
                new Author { Name = "Chetan Mahajan" },
                new Author { Name = "Chic" },
                new Author { Name = "Christopher C Doyle" },
                new Author { Name = "Dan Brown" },
                new Author { Name = "Devdutt Pattanaik" },
                new Author { Name = "Eckhart Tolle" },
                new Author { Name = "Ernesto Che Guevara" },
                new Author { Name = "Gary D Chapman" },
                new Author { Name = "Geronimo Stilton" },
                new Author { Name = "Gita Arjun" },
                new Author { Name = "Herbert Schildt" },
                new Author { Name = "Inder Raj Ahluwala" },
                new Author { Name = "J Krishnamurti" },
                new Author { Name = "Jayme Adelson" },
                new Author { Name = "JD Lee" },
                new Author { Name = "Jim Corbett" },
                new Author { Name = "Joseph Murphy" },
                new Author { Name = "John Carlin" },
                new Author { Name = "John Grisham" },
                new Author { Name = "Js Mathur" },
                new Author { Name = "Katherine Grainger" },
                new Author { Name = "Keki N Daruwalla" },
                new Author { Name = "Khaled Hosseini" },
                new Author { Name = "Mani Bhaumik" }, 
                new Author { Name = "Mehek Bassi" },
                new Author { Name = "Mario Puzo" },
                new Author { Name = "Milkha Singh" },
                new Author { Name = "Na" },
                new Author { Name = "Nassim Nicholas Taleb" },
                new Author { Name = "Nilanjan Mukhopadhyay" },               
                new Author { Name = "Osho" },
                new Author { Name = "Paul Banish" },
                new Author { Name = "Pony Club" },
                new Author { Name = "Preeti Shenoy" },
                new Author { Name = "Priya Narendra" },
                new Author { Name = "R Rajagopalan" },
                new Author { Name = "Radhika Nathan" },
                new Author { Name = "Raghubir Lal Anand" },
                new Author { Name = "Rl Stine" },
                new Author { Name = "Rick Hanson" },
                new Author { Name = "Rick Stein" },
                new Author { Name = "Rita Shrma" },
                new Author { Name = "Rukmini Bhattacharjee" },
                new Author { Name = "S Radhakrishnan" },
                new Author { Name = "Sampooran Singh" },
                new Author { Name = "Sant K Bhatnagar" },
                new Author { Name = "Shiv Khera" },               
                new Author { Name = "Shrikant Prasoon" },
                new Author { Name = "Shyam Shelevadurai" },
                new Author { Name = "SK Verma" },
                new Author { Name = "Sumitabha Das" },
                new Author { Name = "Sylvia Loch" }, 
                new Author { Name = "Swami Chinmayananda" },
                new Author { Name = "TS Sudhir" },
                new Author { Name = "Viktor E. Frankl" }
          };
            context.Authors.AddRange(authors);

            return authors;
        }

        private static List<Category> AddCategories(BookHiveCorpEntities context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Academics" },
                new Category { Name = "Children" },
                new Category { Name = "Fiction" },
                new Category { Name = "Non Fiction" },
                new Category { Name = "Indian Writing" },
                new Category { Name = "Philosophy" },
                new Category { Name = "Religion & Sprituality" },
                new Category { Name = "Sports" },
                new Category { Name = "Travel" }
            };

            context.Categories.AddRange(categories);

            return categories;
        }
    }
}