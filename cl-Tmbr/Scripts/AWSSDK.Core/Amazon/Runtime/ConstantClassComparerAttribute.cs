using System;

namespace Amazon.Runtime
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ConstantClassComparerAttribute : Attribute
	{
		public ConstantClassComparerKind ComparerKind { get; }

		public ConstantClassComparerAttribute(ConstantClassComparerKind comparerKind)
		{
			ComparerKind = comparerKind;
		}
	}
}
