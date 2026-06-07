using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public readonly struct BriskHeader
	{
		public Mode Mode { get; }

		public BriskHeader(Mode mode)
		{
			Mode = default(Mode);
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream outStream)
		{
		}

		public static BriskHeader Deserialize(IInOctetStream stream)
		{
			return default(BriskHeader);
		}
	}
}
