using System.Collections.Generic;

namespace NJsonSchema
{
	public interface IJsonExtensionObject
	{
		IDictionary<string, object> ExtensionData { get; set; }
	}
}
