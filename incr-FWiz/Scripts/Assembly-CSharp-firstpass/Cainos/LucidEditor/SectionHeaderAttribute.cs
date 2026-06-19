using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class SectionHeaderAttribute : Attribute
	{
		public readonly string title;

		public SectionHeaderAttribute(string title)
		{
		}
	}
}
