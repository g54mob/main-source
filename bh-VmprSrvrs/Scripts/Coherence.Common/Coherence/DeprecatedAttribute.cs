using System;

namespace Coherence
{
	internal class DeprecatedAttribute : Attribute
	{
		public int VersionMajor { get; }

		public int VersionMinor { get; }

		public int VersionPatch { get; }

		public string AsOf { get; }

		public string Reason { get; set; }

		public DeprecatedAttribute(string asOf, int versionMajor, int versionMinor, int versionPatch)
		{
		}
	}
}
