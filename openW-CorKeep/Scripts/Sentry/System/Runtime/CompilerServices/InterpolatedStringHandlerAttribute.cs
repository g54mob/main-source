using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	internal sealed class InterpolatedStringHandlerAttribute : Attribute
	{
	}
}
