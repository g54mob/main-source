using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public struct Version
	{
		public ushort Major;

		public ushort Minor;

		public ushort Patch;

		public string Prerelease;

		public Version(ushort major, ushort minor, ushort patch, string prerelease)
		{
			Major = 0;
			Minor = 0;
			Patch = 0;
			Prerelease = null;
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream)
		{
		}

		public static Version Deserialize(IInOctetStream stream)
		{
			return default(Version);
		}
	}
}
