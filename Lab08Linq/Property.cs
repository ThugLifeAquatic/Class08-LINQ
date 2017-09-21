namespace QuickType
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class GettingStarted
    {
        [JsonProperty("features")]
        public Feature[] Features { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("borough")]
        public string Borough { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }


    public partial class GettingStarted
    {
        public static GettingStarted FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this GettingStarted self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}

