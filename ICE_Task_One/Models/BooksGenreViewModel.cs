using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ICE_Task_One.Models;

public class BookGenreViewModel
{
    public List<Books>? Bookss { get; set; }
    public SelectList? Genres { get; set; }
    public string? BookGenre { get; set; }
    public string? SearchString { get; set; }
}