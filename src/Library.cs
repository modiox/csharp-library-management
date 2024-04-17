namespace LibraryApp;
public class LibraryItem {

    public Guid Id { get; }
    public string Name { get; }
    public DateTime CreatedDate { get; }
    public LibraryItem(Guid id, string name, DateTime? createdDate = null) {
        Id = id;
        Name = name;
        CreatedDate = createdDate ?? DateTime.Now;

    }
}
public class User : LibraryItem {

    public User(string name, DateTime? createdDate = null) : base(Guid.NewGuid(),name, createdDate) { }

}

public class Book : LibraryItem {
    public Book(string title, DateTime? dateAdded = null) : base(Guid.NewGuid(), title, dateAdded){}


}

public class Library {

    //List the books
    //List the users
    //create the objects for book and user
    private List<Book> books; 
    private List<User> users; 
    private INotificationService notificationService;
    public Library(INotificationService notificationService)
    { 
        books = new List<Book>();
        users = new List<User>();
        this.notificationService = notificationService;
    }

    //Methods to add the books and users
    public void AddBook(Book book)
    {
        books.Add(book);
        notificationService.SendNotificationOnSuccess($"Book {book.Name} was added"); //inject the msg 
    }
    public void AddUser(User user)
    {
        users.Add(user);
        notificationService.SendNotificationOnSuccess($"User '{user.Name}' was added");
    }

    public IEnumerable<Book> GetAllBooks(int page, int limit)
    {
        return books.OrderByDescending(b => b.CreatedDate)
                    .Skip((page - 1) * limit)
                    .Take(limit);
    }

    public IEnumerable<User> GetAllUsers(int page, int limit)
    {
        return users.OrderByDescending(u => u.CreatedDate)
                    .Skip((page - 1) * limit)
                    .Take(limit);
    }

    public IEnumerable<Book> FindBooksByTitle(string title)
    {
        return books.Where(b => b.Name.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<User> FindUsersByName(string name)
    {
        return users.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public void DeleteBook(Guid id)
    {
        books.RemoveAll(b => b.Id == id);
    }

    public void DeleteUser(Guid id)
    {
        users.RemoveAll(u => u.Id == id);
    }

}

