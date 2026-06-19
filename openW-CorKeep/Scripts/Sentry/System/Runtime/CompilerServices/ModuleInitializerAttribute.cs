using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	internal sealed class ModuleInitializerAttribute : Attribute
	{
	}
}
