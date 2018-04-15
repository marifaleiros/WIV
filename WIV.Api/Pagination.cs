namespace WIV.Api
{
    public class Pagination
    {
        public Pagination()
        {
            Limit = 10;
        }

        public int Limit { get; set; }

        public int? Offset { get; set; }

        public bool HasOffset { get { return Offset.HasValue; } }
    }
}