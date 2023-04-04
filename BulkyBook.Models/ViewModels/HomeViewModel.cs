namespace BulkyBook.Models.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Product> Products { get; set; } = null!;

        public string? SearchString { get; set; }
    }
}
