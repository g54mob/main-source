using System;

namespace Shapes
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public class OvldDefault : Attribute
	{
		public string @default;

		public OvldDefault(string @default)
		{
			this.@default = @default;
		}
	}
}
