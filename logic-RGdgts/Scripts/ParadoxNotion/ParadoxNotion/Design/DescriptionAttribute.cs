using System;

namespace ParadoxNotion.Design
{
	public class DescriptionAttribute : Attribute
	{
		public readonly string description;

		public DescriptionAttribute(string description)
		{
		}
	}
}
