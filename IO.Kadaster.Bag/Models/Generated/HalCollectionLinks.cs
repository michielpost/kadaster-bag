using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace IO.Kadaster.Bag.Models.Generated;

/// <summary>
/// </summary>
[DataContract]
public class HalCollectionLinks
{
    /// <summary>
    ///     Gets or Sets Self
    /// </summary>
    [DataMember(Name = "self", EmitDefaultValue = false)]
    [JsonPropertyName("self")]
    public HalLink Self { get; set; }


    /// <summary>
    ///     Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class HalCollectionLinks {\n");
        sb.Append("  Self: ").Append(Self).Append("\n");
        sb.Append("}\n");
        return sb.ToString();
    }
}