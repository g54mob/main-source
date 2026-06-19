using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Parameter)]
	internal sealed class CallerArgumentExpressionAttribute : Attribute
	{
		public string ParameterName { get; }

		public CallerArgumentExpressionAttribute(string parameterName)
		{
			ParameterName = parameterName;
		}
	}
}
