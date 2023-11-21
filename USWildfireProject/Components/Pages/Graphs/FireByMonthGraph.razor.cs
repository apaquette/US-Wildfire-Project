using Microsoft.AspNetCore.Components;
using System.Globalization;
using USWildfireProject.Models;

namespace USWildfireProject.Components.Pages.Graphs;

public partial class FireByMonthGraph : ComponentBase
{
    private List<FireByMonth> countsByMonth;
    private bool IsDone = false;
    [Parameter, EditorRequired]
    public List<Wildfire> Wildfires { get; set; }
    protected override void OnInitialized()
    {
        IsDone = false;
        countsByMonth = Wildfires.GroupBy(w => int.Parse(w.DiscoverDate.Split("/")[0]))
                                    .Select(g => new FireByMonth
                                    {
                                        Month = g.Key,
                                        FireCount = g.Count()
                                    })
                                    .ToList();
        IsDone = true;
    }
    private string FormatMonth(object value)
    {
        int num = (int)Convert.ToSingle(value);
        return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(num);
    }
    protected class FireByMonth
    {
        public int Month { get; set; }
        public int FireCount { get; set; }
    }
}