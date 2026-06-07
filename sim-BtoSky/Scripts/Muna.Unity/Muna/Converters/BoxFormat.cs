using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna.Converters
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum BoxFormat
	{
		[EnumMember(Value = "xyxy")]
		XYXY = 1,
		[EnumMember(Value = "xywh")]
		XYWH = 2,
		[EnumMember(Value = "cxcywh")]
		CxCyWH = 3,
		[EnumMember(Value = "xyxyxyxy")]
		XYXYXYXY = 4
	}
}
