using System;

namespace DV.Utils
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ExecuteAfter : Attribute
	{
		public Type type;

		public ExecuteAfter(Type type)
		{
			this.type = type;
		}
	}
}
