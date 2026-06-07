using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class IndentAttribute : Attribute
	{
		public int IndentLevel;

		public IndentAttribute(int indentLevel = 1)
		{
			IndentLevel = indentLevel;
		}
	}
}
