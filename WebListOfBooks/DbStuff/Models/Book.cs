namespace WebListOfBooks.DbStuff.Models
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public virtual User User { get; set; }
    }
}
