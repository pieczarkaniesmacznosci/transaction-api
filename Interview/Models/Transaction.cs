using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Interview.Models
{
    [JsonObject]
    public class Transaction
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Debit { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime PostingDate { get; set; }
        [Required]
        public bool IsCleared { get; set; }
        [Required]
        public DateTime? ClearedDate { get; set; }
    }
}