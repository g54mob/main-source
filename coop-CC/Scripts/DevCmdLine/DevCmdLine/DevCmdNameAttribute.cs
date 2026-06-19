using System;

namespace DevCmdLine
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DevCmdNameAttribute : Attribute
	{
		public readonly string name;

		public DevCmdNameAttribute(string name)
		{
			this.name = name;
		}
	}
}
