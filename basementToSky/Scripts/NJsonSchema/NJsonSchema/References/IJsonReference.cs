using Newtonsoft.Json;

namespace NJsonSchema.References
{
	public interface IJsonReference : IJsonReferenceBase, IDocumentPathProvider
	{
		[JsonIgnore]
		IJsonReference ActualObject { get; }

		[JsonIgnore]
		object PossibleRoot { get; }
	}
}
