using System;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonIntegerNode : JsonNode
	{
		public long Value { get; set; }

		public ulong UnsignedValue
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public JsonIntegerNode()
		{
		}

		public JsonIntegerNode(long value)
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
