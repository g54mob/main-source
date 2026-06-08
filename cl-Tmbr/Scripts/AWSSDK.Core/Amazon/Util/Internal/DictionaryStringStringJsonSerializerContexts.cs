using System.Collections.Generic;

namespace Amazon.Util.Internal
{
	[JsonSerializable(typeof(Dictionary<string, string>))]
	public class DictionaryStringStringJsonSerializerContexts : JsonSerializerContext
	{
		public DictionaryStringStringJsonSerializerContexts(JsonSerializerOptions defaultOptions)
			: base(defaultOptions)
		{
		}
	}
}
