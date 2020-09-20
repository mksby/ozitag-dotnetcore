public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? Rooms { get; set; }
    public int? PriceMin { get; set; }
    public int? PriceMax { get; set; }
    public PaginationFilter()
    {
        this.PageNumber = 1;
        this.PageSize = 10;
    }
    public PaginationFilter(int pageNumber, int? pageSize, int? rooms, int? priceMin, int? priceMax)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize ?? 10;
        this.Rooms = rooms;
        this.PriceMin = priceMin;
        this.PriceMax = priceMax;
    }
}