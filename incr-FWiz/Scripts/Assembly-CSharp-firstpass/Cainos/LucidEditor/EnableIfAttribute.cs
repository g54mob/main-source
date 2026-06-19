using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class EnableIfAttribute : Attribute
	{
		public readonly string condition;

		public EnableIfAttribute(string condition)
		{
		}
	}
}
