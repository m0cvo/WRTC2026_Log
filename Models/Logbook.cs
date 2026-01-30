using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WRTC2026_Log.Models
{
    public class Logbook
    {
        [Required]
        public int Id { get; set; } // Primary key
        [DataType (DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [DataType (DataType.DateTime)]
        public DateTime Time { get; set; }
        public float Frequency { get; set; }
        public string Mode { get; set; }
        [Display(Name = "Power (W)")]
        public int Power { get; set; }
        [Required]
        public string Callsign { get; set; }
        [Display(Name = "Report Sent")]
        public int ReportSent { get; set; }
        [Display(Name = "Report Received")]
        public int ReportReceived { get; set; }
    }
}
