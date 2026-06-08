using Unity.Entities;

namespace Kitchen
{
	public struct SCreateFranchiseSelector : IComponentData
	{
		public int CardCount;

		public Entity Selector;
	}
}
