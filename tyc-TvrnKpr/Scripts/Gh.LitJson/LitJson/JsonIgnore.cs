using System;

namespace LitJson
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class JsonIgnore : Attribute
	{
		public JsonIgnoreWhen Usage { get; private set; }

		public JsonIgnore()
		{
		}

		public JsonIgnore(JsonIgnoreWhen usage)
		{
		}
	}
}
