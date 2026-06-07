using System;

namespace ParadoxNotion.Design
{
	public class ColorAttribute : Attribute
	{
		public readonly string hexColor;

		public ColorAttribute(string hexColor)
		{
		}
	}
}
