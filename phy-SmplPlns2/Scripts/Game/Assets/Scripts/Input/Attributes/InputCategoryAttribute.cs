using System;

namespace Assets.Scripts.Input.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class InputCategoryAttribute : Attribute
	{
		public string Category { get; }

		public InputCategoryAttribute(string category)
		{
			Category = category;
		}
	}
}
