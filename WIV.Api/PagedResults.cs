using System.Collections.Generic;

namespace WIV.Api
{
    public class PagedResults<T>
    {
        public int Total { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int Count { get; internal set; }

        public IEnumerable<T> Results { get; set; }
    }
}