using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.Versioning
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	internal sealed class UnsupportedOSPlatformGuardAttribute : OSPlatformAttribute
	{
		public UnsupportedOSPlatformGuardAttribute(string platformName)
			: base(platformName)
		{
		}
	}
}
