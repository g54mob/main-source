using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Interface, Inherited = false)]
	internal sealed class SkipLocalsInitAttribute : Attribute
	{
	}
}
