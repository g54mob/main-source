using Newtonsoft.Json;

namespace NJsonSchema.References
{
	public interface IJsonReferenceBase : IDocumentPathProvider
	{
		[JsonProperty("$ref", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		string ReferencePath { get; set; }

		[JsonIgnore]
		IJsonReference Reference { get; set; }
	}
}
