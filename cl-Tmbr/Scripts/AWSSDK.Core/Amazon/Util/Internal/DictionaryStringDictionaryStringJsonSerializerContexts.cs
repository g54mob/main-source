using System.Collections.Generic;

namespace Amazon.Util.Internal
{
	[JsonSerializable(typeof(Dictionary<string, Dictionary<string, string>>))]
	public class DictionaryStringDictionaryStringJsonSerializerContexts : JsonSerializerContext
	{
		public DictionaryStringDictionaryStringJsonSerializerContexts(JsonSerializerOptions defaultOptions)
			: base(defaultOptions)
		{
		}
	}
}
