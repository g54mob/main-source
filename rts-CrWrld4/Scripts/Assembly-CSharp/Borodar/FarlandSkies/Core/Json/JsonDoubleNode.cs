using System;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonDoubleNode : JsonNode
	{
		public double Value { get; set; }

		public JsonDoubleNode()
		{
		}

		public JsonDoubleNode(double value)
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
