using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna.Beta
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum RemoteAcceleration
	{
		[EnumMember(Value = "remote_auto")]
		Auto = 0,
		[EnumMember(Value = "remote_cpu")]
		CPU = 1,
		[EnumMember(Value = "remote_a40")]
		A40 = 2,
		[EnumMember(Value = "remote_a100")]
		A100 = 3
	}
}
