using System.Text.Json.Serialization;

namespace dotnet_learning.Models
{


    // when using enums in json you need to use this attribute for documentation purposes
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}