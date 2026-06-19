using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.Versioning
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal abstract class OSPlatformAttribute : Attribute
	{
		public string PlatformName { get; }

		protected OSPlatformAttribute(string platformName)
		{
			PlatformName = platformName;
		}
	}
}
