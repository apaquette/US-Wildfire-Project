using Microsoft.AspNetCore.Components;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages.Graphs;

public partial class FireByYearGraph : ComponentBase
{
    private List<FireByYear> countsByYear;
    private bool IsDone = false;
    [Parameter, EditorRequired]
    public List<Wildfire> Wildfires { get; set; }
    protected override void OnInitialized()
    {
        IsDone = false;
        countsByYear = Wildfires.GroupBy(w => w.Year)
                                    .Select(g => new FireByYear
                                    {
                                        Year = g.Key,
                                        FireCount = g.Count()
                                    })
                                    .ToList();
        IsDone = true;
    }
    protected class FireByYear
    {
        public int Year { get; set; }
        public int FireCount { get; set; }
    }
}