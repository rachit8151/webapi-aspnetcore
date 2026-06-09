using System.ComponentModel.DataAnnotations;

namespace PharmacyAPI.Models
{
	public class Medicine
	{
		public int MedicineId { get; set; }

		[Required]
		public string MedicineName { get; set; }
		[Required]
		public decimal Price { get; set; }
		
		public int Stock { get; set; }
		[Required]
		public DateTime ExpiryDate { get; set; }
	}
}
