namespace Coherence.RSL.ReplicationManager
{
	public struct Version
	{
		public enum Error
		{
			None = 0,
			InvalidFormat = 1,
			FailedToParse = 2
		}

		public static readonly Version Invalid;

		public int Major;

		public int Minor;

		public int Patch;

		public static bool AreVersionsCompatible(Version client, Version server)
		{
			return false;
		}

		public bool IsValid()
		{
			return false;
		}

		public static Error ParseVersion(string versionStr, out Version version)
		{
			version = default(Version);
			return default(Error);
		}

		public new string ToString()
		{
			return null;
		}
	}
}
