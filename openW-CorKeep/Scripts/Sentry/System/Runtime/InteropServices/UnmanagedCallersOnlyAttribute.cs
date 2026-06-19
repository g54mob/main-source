using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.InteropServices
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	internal sealed class UnmanagedCallersOnlyAttribute : Attribute
	{
		public Type[]? CallConvs;

		public string? EntryPoint;
	}
}
