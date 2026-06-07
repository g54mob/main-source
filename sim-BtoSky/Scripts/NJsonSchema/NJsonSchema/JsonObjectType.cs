using System;
using Newtonsoft.Json;

namespace NJsonSchema
{
	[Flags]
	public enum JsonObjectType
	{
		[JsonProperty("none")]
		None = 0,
		[JsonProperty("array")]
		Array = 1,
		[JsonProperty("boolean")]
		Boolean = 2,
		[JsonProperty("integer")]
		Integer = 4,
		[JsonProperty("null")]
		Null = 8,
		[JsonProperty("number")]
		Number = 0x10,
		[JsonProperty("object")]
		Object = 0x20,
		[JsonProperty("string")]
		String = 0x40,
		[JsonProperty("file")]
		File = 0x80
	}
}
