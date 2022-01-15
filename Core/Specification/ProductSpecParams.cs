namespace Core.Specification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pagesize = 6;

        private int myVar;
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value > MaxPageSize ? MaxPageSize : value; }
        }
        
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

       
        private string _search;
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
        
    }
}