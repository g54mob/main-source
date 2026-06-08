using Unity.Entities;

namespace Kitchen
{
	public struct CSplittableItem : IComponentData
	{
		public int SubItem;

		public int RemainingCount;

		public int TotalCount;

		public float SplitSpeed;

		public bool AllowMergeSplit;

		public bool PreventExplicitSplit;

		public bool CopySplit;

		public bool SplitByComponents;

		public int SplitByComponentsHolder;

		public int SplitByComponentsWrapper;

		public int RefuseSplitWith;

		public bool SplitAsSelf;
	}
}
