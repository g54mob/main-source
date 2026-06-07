using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PredictorStatus
	{
		[EnumMember(Value = "compiling")]
		Compiling = 0,
		[EnumMember(Value = "active")]
		Active = 1,
		[EnumMember(Value = "archived")]
		Archived = 3
	}
}
