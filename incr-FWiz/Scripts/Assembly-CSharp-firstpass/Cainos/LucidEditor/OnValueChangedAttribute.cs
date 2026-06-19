using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class OnValueChangedAttribute : Attribute
	{
		public readonly string methodName;

		public OnValueChangedAttribute(string methodName)
		{
		}
	}
}
