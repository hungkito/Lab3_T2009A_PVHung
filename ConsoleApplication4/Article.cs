namespace ConsoleApplication4
{
    public class Article
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return $"Url: {Url}, title: {Title}, content: {Content}, image: {Image}";
        }

        public string ToShortString()
        {
            return $"Url: {Url}.\nTitle: {Image}";
        }
    }
}