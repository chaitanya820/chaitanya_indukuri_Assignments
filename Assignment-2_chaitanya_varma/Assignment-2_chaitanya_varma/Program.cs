using System.Diagnostics;

namespace Assignment_2_chaitanya_varma
{
    public class Book
    {                                       
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double price { get; set; }
        public string Author { get; set; }
        public string publisher { get; set; }

        public override string ToString()
        {
            return $"Book ID: {BookId}, Name: {BookName}, Price: {price}, Author: {Author}, Publisher: {publisher}";
        }
    }
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(int id, Book book);
        Book GetByBookId(int id);
        List<Book> GetAllBooks();
    }

    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Update(int id, Book book)
        {
            var index = books.FindIndex(b => b.BookId == id);
            if (index != -1)
            {
                books[index] = book;
            }
        }

        public Book GetByBookId(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepo = new BookRepository();
            bool exitprogram = false;

            while (!exitprogram)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Create Book");
                Console.WriteLine("2. Update Book Details");
                Console.WriteLine("3. Display Book Details");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {


                    case 1:
                        Console.Write("Enter book ID: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter book name: ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter book price: ");
                        double bookPrice = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter author name: ");
                        string authorName = Console.ReadLine();
                        Console.Write("Enter publisher name: ");
                        string publisherName = Console.ReadLine();

                        Book newBook = new Book
                        {
                            BookId = bookId,
                            BookName = bookName,
                            price = bookPrice,
                            Author = authorName,
                            publisher = publisherName
                        };

                        bookRepo.Add(newBook);
                        Console.WriteLine("Book added successfully.");
                        break;

                    case 2:
                        Console.Write("Enter book ID to update: ");
                        int idToUpdate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new book name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new book price: ");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter new author name: ");
                        string newAuthor = Console.ReadLine();
                        Console.Write("Enter new publisher name: ");
                        string newPublisher = Console.ReadLine();

                        Book updatedBook = new Book
                        {
                            BookId = idToUpdate,
                            BookName = newName,
                            price = newPrice,
                            Author = newAuthor,
                            publisher = newPublisher
                        };

                        bookRepo.Update(idToUpdate, updatedBook);
                        Console.WriteLine("Book updated successfully.");
                        break;

                    case 3:
                        break;

                    case 4:
                        exitprogram = true;
                        Console.WriteLine("Exiting the Library Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }

        }
    }
}

