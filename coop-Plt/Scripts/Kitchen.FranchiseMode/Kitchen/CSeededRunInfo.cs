using Unity.Entities;

namespace Kitchen
{
	public struct CSeededRunInfo : IComponentData
	{
		public Seed FixedSeed;

		public bool IsSeedOverride;
	}
}
