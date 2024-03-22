using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICE_Task_One.Models;

public class Books
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author {get; set; }
    public string? Genre { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public string? Rating { get; set; }
}