using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.InteropServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	internal sealed class SuppressGCTransitionAttribute : Attribute
	{
	}
}
