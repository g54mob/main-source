using System;

namespace DV.Utils
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ExecuteBefore : Attribute
	{
		public Type type;

		public ExecuteBefore(Type type)
		{
			this.type = type;
		}
	}
}
