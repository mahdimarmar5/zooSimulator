

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter<MovementType>))]
public enum MovementType
{
    Walking,
    Flying,
}