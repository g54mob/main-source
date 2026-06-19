using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.Versioning
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[AttributeUsage(AttributeTargets.Assembly)]
	internal sealed class TargetPlatformAttribute : OSPlatformAttribute
	{
		public TargetPlatformAttribute(string platformName)
			: base(platformName)
		{
		}
	}
}
