using System;

namespace ParadoxNotion.Design
{
	public class CategoryAttribute : Attribute
	{
		public readonly string category;

		public CategoryAttribute(string category)
		{
		}
	}
}
