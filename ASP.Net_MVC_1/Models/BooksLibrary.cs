namespace ASP.Net_MVC_1.Models
{
    public class BooksLibrary : ILibrary<Book>
    {
        List<Book> books;
        public BooksLibrary()
        {
            books = new List<Book>()
            {
                new Book()
                {
                    Id= 1,
                    Title="The Witcher Sword of Destiny",
                    Author="Andrzej Sapkowski",
                    Genre ="fantasy",
                    Publisher ="superNOWA",
                    YearOfPublish = 1992,
                    FilePath = "/images/pl_sword_of_destiny_new.jpg",
                    More = "In this story, Geralt meets a man named Borch Three " +
                    "Jackdaws and two of his bodyguards from distant Zerrikania. " +
                    "They set off along the road, but run into a cordon. Dandelion, " +
                    "who is also here, gives explanations. A green dragon got into the " +
                    "habit of flying in Holopolye, and the local shoemaker Kozoed figured " +
                    "out how to poison him. However, the dragon did not die, but with difficulty" +
                    " crawled into the mountains. The King of Caingorn, Nedamir, wanted to woo " +
                    "Princess Malleora, but her entourage said that, according to the prediction," +
                    " the princess' fiancé should kill the dragon. Therefore, Nedamir set up a cordon, " +
                    "and he himself went to the dragon with the hunters."
                },
                new Book()
                {
                    Id= 2,
                    Title="Harry Potter and the Chamber of Secrets",
                    Author="Joanne Rowling",
                    Genre ="fantasy, adventure",
                    Publisher ="Bloomsbury",
                    YearOfPublish = 1998,
                    FilePath = "/images/Harry_Potter_and_the_Chamber_of_Secrets_—_book.jpg",
                    More = "The second novel in the series of books about the young wizard Harry Potter, written by JK Rowling." +
                    " The book tells about the second academic year at Hogwarts School of Witchcraft and Wizardry," +
                    " about Harry and his friends - Ron Weasley and Hermione Granger - about the unusually mysterious" +
                    " consequences at the school, a certain \"Heir of Slytherin\". The targets of the attacks are muggle-born students." +
                    " All aggressors are in a daze and do not react to anything. The main character will have to face the innocence " +
                    "of mysterious events and join the battle with his powerful dark load."
                }
            };


        }
        public Book Add(Book item)
        {
            books.Add(item);
            return item;
        }

        public bool Delete(int id)
        {
            Book? book = Get(id);
            return books.Remove(book!);
        }

        public Book Edit(Book item)
        {
            Book? book = Get(item.Id);
            book!.Title = item.Title;
            book!.Author = item.Author;
            book!.Genre = item.Genre;
            book!.Publisher = item.Publisher;
            book!.YearOfPublish = item.YearOfPublish;
            book!.FilePath = item.FilePath;
            book!.More = item.More;
            return book;
        }

        public Book? Get(int id)
        {
           return books.FirstOrDefault(t=>t.Id== id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }
    }
}
