using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Dtype
	{
		[EnumMember(Value = "null")]
		Null = 0,
		[EnumMember(Value = "float16")]
		Float16 = 1,
		[EnumMember(Value = "float32")]
		Float32 = 2,
		[EnumMember(Value = "float64")]
		Float64 = 3,
		[EnumMember(Value = "int8")]
		Int8 = 4,
		[EnumMember(Value = "int16")]
		Int16 = 5,
		[EnumMember(Value = "int32")]
		Int32 = 6,
		[EnumMember(Value = "int64")]
		Int64 = 7,
		[EnumMember(Value = "uint8")]
		Uint8 = 8,
		[EnumMember(Value = "uint16")]
		Uint16 = 9,
		[EnumMember(Value = "uint32")]
		Uint32 = 10,
		[EnumMember(Value = "uint64")]
		Uint64 = 11,
		[EnumMember(Value = "bool")]
		Bool = 12,
		[EnumMember(Value = "string")]
		String = 13,
		[EnumMember(Value = "list")]
		List = 14,
		[EnumMember(Value = "dict")]
		Dict = 15,
		[EnumMember(Value = "image")]
		Image = 16,
		[EnumMember(Value = "binary")]
		Binary = 17,
		[EnumMember(Value = "bfloat16")]
		BFloat16 = 18,
		[EnumMember(Value = "value_list")]
		ValueList = 19,
		[EnumMember(Value = "value_map")]
		ValueMap = 20
	}
}
