using Unity.Entities;

namespace Kitchen
{
	public struct CLayoutInfo : IComponentData
	{
		public Entity Layout;

		public int Setting;

		public Seed Seed;
	}
}
