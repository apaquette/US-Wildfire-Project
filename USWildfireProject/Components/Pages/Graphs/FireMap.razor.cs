using Microsoft.AspNetCore.Components;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages.Graphs;

public partial class FireMap : ComponentBase
{
    private List<FirePin> FirePins = new();
    private bool IsDone = false;
    private int selectedYear;
    private List<int> years = new();
    [Parameter, EditorRequired]
    public List<Wildfire>? Wildfires { get; set; }

    protected override void OnInitialized()
    {
        IsDone = false;
        years = Wildfires?.GroupBy(x => x.Year).Select(x => x.Key).ToList() ?? new();
        years.Sort();
        selectedYear = years.FirstOrDefault();
        ShowWildfires();
        IsDone = true;
    }

    public void ShowWildfires()
    {
        FirePins = Wildfires?.Where(w => w.Year == selectedYear && (w.SizeClass == "G".ToCharArray()[0] || w.SizeClass == "F".ToCharArray()[0]))
                            .Select(f => new FirePin
                            {
                                Latitude = f.Latitude,
                                Longitude = f.Longitude
                            })
                            .ToList() ?? new();
    }

    protected class FirePin
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
