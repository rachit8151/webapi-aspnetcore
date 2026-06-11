using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Data;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MedicineController : ControllerBase
	{
		private readonly PharmacyDbContext pharm;

		public MedicineController(PharmacyDbContext pharm)
		{
			this.pharm = pharm;
		}

		//GET API
		[HttpGet]
		public IActionResult GetMedicines()
		{
			var medicineData = pharm.Medicines.ToList();
			return Ok(medicineData);
		}

		[HttpGet("{id}")]
		public IActionResult GetMedicineById(int id)
		{
			var medicineData = pharm.Medicines.FirstOrDefault(m => m.MedicineId == id);
			if (medicineData == null)
			{
				return NotFound("Medicine Not Found");
			}
			return Ok(medicineData);
		}

		[HttpGet("DTO")]
		public IActionResult GetMedicine()
		{
			var mecidineData = pharm.Medicines
				.Select(m => new MedicineDTO
				{
					MedicineId = m.MedicineId,
					MedicineName = m.MedicineName,
					ExpiryDate = m.ExpiryDate
				})
				.ToList();
			return Ok(mecidineData);
		}

		[HttpGet("Search")]
		public IActionResult SearchMedicine(string medicineName)
		{
			var medicineData = pharm.Medicines
				.Where(m => m.MedicineName.Contains(medicineName)
				|| m.Price.ToString().Contains(medicineName))
				.ToList();
			return Ok(medicineData);
		}

		//POST API
		[HttpPost]
		public IActionResult AddMedicine(Medicine medicine)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			pharm.Medicines.Add(medicine);
			pharm.SaveChanges();
			return Ok("Medicine Added Successfully");
		}

		[HttpPost("AddMultiple")]
		public IActionResult AddMultipleMedicines(List<Medicine> medicines)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			pharm.Medicines.AddRange(medicines);
			pharm.SaveChanges();
			return Ok("Multiple Medicines Added");
		}

		//PUT API
		[HttpPut("{id}")]
		public IActionResult UpdateMedicine(int id, Medicine medicine)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var medicineData = pharm.Medicines.FirstOrDefault(m => m.MedicineId == id);
			if(medicineData == null)
			{
				return NotFound("Medicine Not Found");
			}
			medicineData.MedicineName = medicine.MedicineName;
			medicineData.Price = medicine.Price;
			medicineData.Stock = medicine.Stock;
			medicineData.ExpiryDate = medicine.ExpiryDate;
			pharm.SaveChanges();
			return Ok("Medicine Updated Successfully");
		}

		//DELETE API
		[HttpDelete("{id}")]
		public IActionResult DeleteMedicine(int id)
		{
			var medicineData = pharm.Medicines.FirstOrDefault(m => m.MedicineId == id);
			if (medicineData == null)
			{
				return NotFound("Medicine Not Found");
			}
			pharm.Medicines.Remove(medicineData);
			pharm.SaveChanges();
			return Ok("Medicine Deleted Successfully");
		}

	}
}
