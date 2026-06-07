using Newtonsoft.Json;

namespace NJsonSchema
{
	public class JsonXmlObject
	{
		[JsonIgnore]
		public JsonSchema ParentSchema { get; internal set; }

		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string Name { get; internal set; }

		[JsonProperty("wrapped", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool Wrapped { get; internal set; }

		[JsonProperty("namespace", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string Namespace { get; internal set; }

		[JsonProperty("prefix", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string Prefix { get; internal set; }

		[JsonProperty("attribute", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public bool Attribute { get; internal set; }
	}
}
