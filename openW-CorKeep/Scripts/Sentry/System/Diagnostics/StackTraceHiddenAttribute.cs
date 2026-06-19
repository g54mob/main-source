using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	internal sealed class StackTraceHiddenAttribute : Attribute
	{
	}
}
