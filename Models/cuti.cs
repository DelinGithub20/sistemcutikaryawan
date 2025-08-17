using System;
using System.ComponentModel.DataAnnotations;

namespace sistemcutikaryawan.Models
{
    public class Cuti
    {
        public int Id { get; set; }

        [Required]
        public String NamaKaryawan { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TanggalMulai { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TanggalSelesai { get; set; }

        public string Alasan { get; set; }

        public string Status { get; set; } = "Pending";
    }
}