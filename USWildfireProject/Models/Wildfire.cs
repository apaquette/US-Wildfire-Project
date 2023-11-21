namespace USWildfireProject.Models;

public class Wildfire
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string? DiscoverDate { get; set; }
    public int DiscoveryDayOfYear { get; set; }
    public string? DiscoverTime { get; set; }
    public string? CauseClassification { get; set; }
    public string? GeneralCause { get; set; }
    public string? CauseAgeCategory { get; set; }
    public string? ContainmentDate { get; set; }
    public int? ContainmentDayOfYear { get; set; }
    public string? ContainmentTime { get; set; }
    public double Size { get; set; }
    public char SizeClass { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? State { get; set; }
    public string? County { get; set; }

    public decimal GetContainmentTime()
    {
        string format = "M/d/yyyy HHmm";
        if (string.IsNullOrEmpty(DiscoverTime)) DiscoverTime = "0000";
        DateTime discoverDate = DateTime.ParseExact($"{DiscoverDate} {DiscoverTime}", format , null);
        DateTime containmentDate = DateTime.ParseExact($"{ContainmentDate} {ContainmentTime}", format, null);
        return Convert.ToDecimal((containmentDate - discoverDate).TotalMinutes);
    }
}
