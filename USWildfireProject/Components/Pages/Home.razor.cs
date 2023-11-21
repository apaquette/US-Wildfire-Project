using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using USWildfireProject.Data;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages;

public partial class Home : ComponentBase
{
    private bool IsLoading = false;
    public List<Wildfire>? Wildfires { get; set; }
    private WildfireContext? _context;
    public async Task ShowWildfires()
    {
        IsLoading = true;
        await Task.Delay(10);
        _context ??= await WildfireDataContextFactory.CreateDbContextAsync();

        if (_context is not null)
        {
            try
            {
                Wildfires = await _context.Wildfires.ToListAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        if (_context is not null) await _context.DisposeAsync();
        IsLoading = false;
    }
}
