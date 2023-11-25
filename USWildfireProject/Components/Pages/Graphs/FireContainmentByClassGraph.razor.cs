using Microsoft.AspNetCore.Components;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages.Graphs;

public partial class FireContainmentByClassGraph : ComponentBase
{
    private List<FireContainmentByClass> averageContainmentByClass = new();
    private bool IsDone = false;
    [Parameter, EditorRequired]
    public List<Wildfire>? Wildfires { get; set; }
    protected override void OnInitialized()
    {
        IsDone = false;
        averageContainmentByClass = Wildfires?.Where(wf => !string.IsNullOrEmpty(wf.ContainmentDate) && !string.IsNullOrEmpty(wf.ContainmentTime)).GroupBy(w => w.SizeClass)
                                    .Select(g => new FireContainmentByClass
                                    {
                                        Class = g.Key,
                                        AverageContainment = g.Average(w => w.GetContainmentTime()),
                                    })
                                    .OrderBy(w => w.Class)
                                    .ToList() ?? new();
        IsDone = true;
    }
    protected class FireContainmentByClass
    {
        public char Class { get; set; }
        public decimal AverageContainment { get; set; }
    }
}