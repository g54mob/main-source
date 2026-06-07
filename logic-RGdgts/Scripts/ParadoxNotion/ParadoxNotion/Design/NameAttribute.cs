using System;

namespace ParadoxNotion.Design
{
	public class NameAttribute : Attribute
	{
		public readonly string name;

		public readonly int priority;

		public NameAttribute(string name, int priority = 0)
		{
		}
	}
}
