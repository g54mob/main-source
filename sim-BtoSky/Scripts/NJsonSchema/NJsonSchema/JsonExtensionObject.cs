using System.Collections.Generic;
using Newtonsoft.Json;

namespace NJsonSchema
{
	[JsonConverter(typeof(ExtensionDataDeserializationConverter))]
	public class JsonExtensionObject : IJsonExtensionObject
	{
		[JsonExtensionData]
		public IDictionary<string, object> ExtensionData { get; set; }
	}
}
