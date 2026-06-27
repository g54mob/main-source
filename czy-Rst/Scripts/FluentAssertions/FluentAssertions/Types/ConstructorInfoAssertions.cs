using System.Diagnostics;
using System.Reflection;
using FluentAssertions.Execution;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class ConstructorInfoAssertions : MethodBaseAssertions<ConstructorInfo, ConstructorInfoAssertions>
	{
		private protected override string SubjectDescription => GetDescriptionFor(base.Subject);

		protected override string Identifier => "constructor";

		public ConstructorInfoAssertions(ConstructorInfo constructorInfo, AssertionChain assertionChain)
			: base(constructorInfo, assertionChain)
		{
		}

		private static string GetDescriptionFor(ConstructorInfo constructorInfo)
		{
			return $"{constructorInfo.DeclaringType}({MethodBaseAssertions<ConstructorInfo, ConstructorInfoAssertions>.GetParameterString(constructorInfo)})";
		}
	}
}
