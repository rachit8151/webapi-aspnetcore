using System.ComponentModel.DataAnnotations;

namespace PharmacyAPI.Models
{
	public class Medicine
	{
		public int MedicineId { get; set; }

		[Required(ErrorMessage = "Medicine Name Required")]
		public string MedicineName { get; set; }
		[Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
		public decimal Price { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Stock must be a positive integer")]
		public int Stock { get; set; }
		[Required(ErrorMessage = "Expiry Date Required")]
		public DateTime ExpiryDate { get; set; }
	}
}
