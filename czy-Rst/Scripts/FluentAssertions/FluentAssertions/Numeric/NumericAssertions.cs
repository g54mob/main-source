using System;
using System.Diagnostics;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	public class NumericAssertions<T> : NumericAssertions<T, NumericAssertions<T>> where T : struct, IComparable<T>
	{
		public NumericAssertions(T value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class NumericAssertions<T, TAssertions> : NumericAssertionsBase<T, T, TAssertions> where T : struct, IComparable<T> where TAssertions : NumericAssertions<T, TAssertions>
	{
		public override T Subject { get; }

		public NumericAssertions(T value, AssertionChain assertionChain)
			: base(assertionChain)
		{
			Subject = value;
		}
	}
}
