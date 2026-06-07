using System;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonStringNode : JsonNode
	{
		private string value;

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JsonStringNode()
		{
		}

		public JsonStringNode(string value)
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
