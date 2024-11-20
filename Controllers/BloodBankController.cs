using BloodBankManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBankManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : ControllerBase
    {
        // Static list of blood bank entries with pre-filled data
        private static List<BloodBankEntry> _entries = new List<BloodBankEntry>
        {
            new BloodBankEntry
            {
                Id = 1,
                DonorName = "Shrishti Singh",
                Age = 30,
                BloodType = "A+",
                ContactInfo = "1234567890",
                Quantity = 2,
                CollectionDate = DateTime.Now.AddDays(-5),
                ExpirationDate = DateTime.Now.AddDays(25),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 2,
                DonorName = "Ashish Singh",
                Age = 27,
                BloodType = "O-",
                ContactInfo = "0987654321",
                Quantity = 3,
                CollectionDate = DateTime.Now.AddDays(-10),
                ExpirationDate = DateTime.Now.AddDays(20),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 3,
                DonorName = "Amrita Singh",
                Age = 35,
                BloodType = "B+",
                ContactInfo = "5678901234",
                Quantity = 1,
                CollectionDate = DateTime.Now.AddDays(-2),
                ExpirationDate = DateTime.Now.AddDays(28),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 4,
                DonorName = "Shreya Singh",
                Age = 40,
                BloodType = "AB-",
                ContactInfo = "6789012345",
                Quantity = 5,
                CollectionDate = DateTime.Now.AddDays(-8),
                ExpirationDate = DateTime.Now.AddDays(22),
                Status = "Unavailable"
            },
            new BloodBankEntry
            {
                Id = 5,
                DonorName = "Shreya Rawat",
                Age = 22,
                BloodType = "O+",
                ContactInfo = "2345678901",
                Quantity = 4,
                CollectionDate = DateTime.Now.AddDays(-6),
                ExpirationDate = DateTime.Now.AddDays(24),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 6,
                DonorName = "Rohan Mehta",
                Age = 30,
                BloodType = "A+",
                ContactInfo = "3456789012",
                Quantity = 3,
                CollectionDate = DateTime.Now.AddDays(-10),
                ExpirationDate = DateTime.Now.AddDays(20),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 7,
                DonorName = "Ananya Gupta",
                Age = 27,
                BloodType = "B-",
                ContactInfo = "4567890123",
                Quantity = 2,
                CollectionDate = DateTime.Now.AddDays(-4),
                ExpirationDate = DateTime.Now.AddDays(26),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 8,
                DonorName = "Karan Sharma",
                Age = 35,
                BloodType = "AB+",
                ContactInfo = "5678901234",
                Quantity = 5,
                CollectionDate = DateTime.Now.AddDays(-12),
                ExpirationDate = DateTime.Now.AddDays(18),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 9,
                DonorName = "Megha Verma",
                Age = 21,
                BloodType = "O-",
                ContactInfo = "6789012345",
                Quantity = 4,
                CollectionDate = DateTime.Now.AddDays(-2),
                ExpirationDate = DateTime.Now.AddDays(28),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 10,
                DonorName = "Rahul Desai",
                Age = 28,
                BloodType = "B+",
                ContactInfo = "7890123456",
                Quantity = 1,
                CollectionDate = DateTime.Now.AddDays(-8),
                ExpirationDate = DateTime.Now.AddDays(22),
                Status = "Unavailable"
            },
            new BloodBankEntry
            {
                Id = 11,
                DonorName = "Priya Singh",
                Age = 24,
                BloodType = "A-",
                ContactInfo = "8901234567",
                Quantity = 3,
                CollectionDate = DateTime.Now.AddDays(-5),
                ExpirationDate = DateTime.Now.AddDays(25),
                Status = "Available"
            }
        };

       


     private static int _idCounter = _entries.Max(e => e.Id) + 1;

        // Create Entry
        [HttpPost]
        public IActionResult Create(BloodBankEntry entry)
        {
            entry.Id = _idCounter++;
            _entries.Add(entry);
            return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
        }

        // Get All Entries
        [HttpGet]
        public IActionResult GetAll(int? page = null, int? size = null)
        {
            var result = _entries.AsQueryable();

            if (page.HasValue && size.HasValue)
            {
                result = result.Skip((page.Value - 1) * size.Value).Take(size.Value);
            }

            return Ok(result);
        }

        // Get Entry by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                return NotFound();

            return Ok(entry);
        }

        // Update Entry
        [HttpPut("{id}")]
        public IActionResult Update(int id, BloodBankEntry updatedEntry)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                return NotFound();

            entry.DonorName = updatedEntry.DonorName;
            entry.Age = updatedEntry.Age;
            entry.BloodType = updatedEntry.BloodType;
            entry.ContactInfo = updatedEntry.ContactInfo;
            entry.Quantity = updatedEntry.Quantity;
            entry.CollectionDate = updatedEntry.CollectionDate;
            entry.ExpirationDate = updatedEntry.ExpirationDate;
            entry.Status = updatedEntry.Status;

            return NoContent();
        }

        // Delete Entry
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                return NotFound();

            _entries.Remove(entry);
            return NoContent();
        }

        // Search by BloodType, Status, or DonorName
        [HttpGet("search")]
        public IActionResult Search(string? bloodType = null, string? status = null, string? donorName = null)
        {
            var result = _entries.AsQueryable();

            if (!string.IsNullOrEmpty(bloodType))
                result = result.Where(e => e.BloodType == bloodType);

            if (!string.IsNullOrEmpty(status))
                result = result.Where(e => e.Status == status);

            if (!string.IsNullOrEmpty(donorName))
                result = result.Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase));

            return Ok(result);
        }
    }
}
