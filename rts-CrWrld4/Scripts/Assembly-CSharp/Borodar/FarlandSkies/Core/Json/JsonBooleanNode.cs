using System;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonBooleanNode : JsonNode
	{
		public bool Value { get; set; }

		public JsonBooleanNode()
		{
		}

		public JsonBooleanNode(bool value)
		{
		}

		public override JsonNode Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override object ConvertTo(Type type)
		{
			return null;
		}

		public override void Write(IJsonWriter writer)
		{
		}
	}
}
