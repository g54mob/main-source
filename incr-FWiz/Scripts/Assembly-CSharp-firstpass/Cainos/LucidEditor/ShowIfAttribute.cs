using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class ShowIfAttribute : Attribute
	{
		public readonly string condition;

		public ShowIfAttribute(string condition)
		{
		}
	}
}
