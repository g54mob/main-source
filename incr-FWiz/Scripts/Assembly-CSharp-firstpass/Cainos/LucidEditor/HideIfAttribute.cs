using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class HideIfAttribute : Attribute
	{
		public readonly string condition;

		public HideIfAttribute(string condition)
		{
		}
	}
}
