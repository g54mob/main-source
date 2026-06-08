using Unity.Entities;

namespace Kitchen
{
	public struct SFranchiseSelector : IComponentData
	{
		public int SelectedIndex;

		public Entity SelectedFranchise;

		public bool RequiresAdditionalBase;
	}
}
