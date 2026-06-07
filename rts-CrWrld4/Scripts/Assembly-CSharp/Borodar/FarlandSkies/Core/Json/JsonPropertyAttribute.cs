using System;

namespace Borodar.FarlandSkies.Core.Json
{
	public class JsonPropertyAttribute : Attribute
	{
		public string Name { get; private set; }

		public JsonPropertyAttribute()
		{
		}

		public JsonPropertyAttribute(string propertyName)
		{
		}
	}
}
