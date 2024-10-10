namespace WebListOfBooks.DbStuff.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }   
        public string Email { get; set; }
        public virtual List<Book>? Books { get; set; }
    }
}
