using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class TitleHeaderAttribute : Attribute
	{
		public readonly string title;

		public TitleHeaderAttribute(string title)
		{
		}
	}
}
