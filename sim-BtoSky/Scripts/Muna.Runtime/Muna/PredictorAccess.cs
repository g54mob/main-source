using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PredictorAccess
	{
		[EnumMember(Value = "public")]
		Public = 0,
		[EnumMember(Value = "private")]
		Private = 1,
		[EnumMember(Value = "unlisted")]
		Unlisted = 2
	}
}
