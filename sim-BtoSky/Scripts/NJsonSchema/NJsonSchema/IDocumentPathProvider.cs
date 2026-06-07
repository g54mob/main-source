using Newtonsoft.Json;

namespace NJsonSchema
{
	public interface IDocumentPathProvider
	{
		[JsonIgnore]
		string DocumentPath { get; set; }
	}
}
