using System.Text.Json;

public class FeatureCollection
{
    // Collection of earthquake features
    public List<Feature> features { get; set; }
}

// Represents a single earthquake feature in the JSON data
public class Feature
{
    // Earthquake-specific properties
    public Properties properties { get; set; }
}

// Represents the properties of an earthquake (magnitude and location)
public class Properties
{
    // Magnitude of the earthquake (nullable)
    public double? mag { get; set; }

    // Location description of the earthquake
    public string place { get; set; }
}
