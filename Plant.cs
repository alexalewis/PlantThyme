using System;

namespace PlantThyme
{
  public class Plant
  {
    public int Id { get; set; }
    public string Species { get; set; }
    public string LocatedPlant { get; set; }
    public DateTime PlantDate { get; set; }
    public DateTime LastWatered { get; set; }
    public string LightNeeded { get; set; }
    public string WaterNeeded { get; set; }
  }
}