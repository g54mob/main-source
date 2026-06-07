using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public struct NameVersion
	{
		public Version Version;

		public string Name;

		public NameVersion(string name, Version version)
		{
			Version = default(Version);
			Name = null;
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream)
		{
		}

		public static NameVersion Deserialize(IInOctetStream stream)
		{
			return default(NameVersion);
		}
	}
}
