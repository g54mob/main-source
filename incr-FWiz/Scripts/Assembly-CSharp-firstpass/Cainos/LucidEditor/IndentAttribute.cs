using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class IndentAttribute : Attribute
	{
		public readonly int indent;

		public IndentAttribute()
		{
		}

		public IndentAttribute(int indent)
		{
		}
	}
}
