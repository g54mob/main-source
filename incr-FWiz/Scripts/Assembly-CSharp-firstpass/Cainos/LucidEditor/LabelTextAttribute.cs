using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class LabelTextAttribute : Attribute
	{
		public readonly string label;

		public LabelTextAttribute(string label)
		{
		}
	}
}
