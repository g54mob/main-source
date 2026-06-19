using System;

namespace SickDev.CommandSystem
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ParserAttribute : Attribute
	{
		public readonly Type type;

		public ParserAttribute(Type type)
		{
			this.type = type;
		}
	}
}
