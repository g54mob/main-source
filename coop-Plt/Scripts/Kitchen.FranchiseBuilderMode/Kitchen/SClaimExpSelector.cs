using Unity.Entities;

namespace Kitchen
{
	public struct SClaimExpSelector : IComponentData
	{
		public int ExpValue;

		public Entity Selector;
	}
}
