using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class DisableIfAttribute : Attribute
	{
		public readonly string condition;

		public DisableIfAttribute(string condition)
		{
		}
	}
}
