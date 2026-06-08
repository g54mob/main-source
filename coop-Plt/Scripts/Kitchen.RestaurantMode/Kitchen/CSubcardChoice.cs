using Unity.Entities;

namespace Kitchen
{
	public struct CSubcardChoice : IComponentData
	{
		public int Choice1;

		public int Choice2;

		public bool FromFranchise;
	}
}
