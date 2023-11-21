using Microsoft.AspNetCore.Components;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages.Graphs;

public partial class FireByCauseGraph : ComponentBase
{
    private List<FireByCause> countsByCause;
    private bool IsDone = false;
    [Parameter, EditorRequired]
    public List<Wildfire> Wildfires { get; set; }
    protected override void OnInitialized()
    {
        IsDone = false;
        countsByCause = Wildfires.GroupBy(w => w.GeneralCause)
                                    .Select(g => new FireByCause
                                    {
                                        Cause = g.Key,
                                        FireCount = g.Count()
                                    })
                                    .ToList();
        countsByCause.OrderByDescending(x => x.FireCount);
        IsDone = true;
    }
    protected class FireByCause
    {
        public string? Cause { get; set; }
        public int FireCount { get; set; }
    }
}