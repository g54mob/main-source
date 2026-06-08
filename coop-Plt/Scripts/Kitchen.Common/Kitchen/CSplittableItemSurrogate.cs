using Unity.Entities;

namespace Kitchen
{
	public struct CSplittableItemSurrogate : IComponentData, TypeHash.ISurrogate<CSplittableItem>, TypeHash.ISurrogate
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

		public int RefuseSplitWith;

		public bool SplitAsSelf;

		public IComponentData Convert()
		{
			return new CSplittableItem
			{
				SubItem = SubItem,
				RemainingCount = RemainingCount,
				TotalCount = TotalCount,
				SplitSpeed = SplitSpeed,
				AllowMergeSplit = AllowMergeSplit,
				PreventExplicitSplit = PreventExplicitSplit,
				CopySplit = CopySplit,
				SplitByComponents = SplitByComponents,
				SplitByComponentsHolder = SplitByComponentsHolder,
				RefuseSplitWith = RefuseSplitWith,
				SplitAsSelf = SplitAsSelf,
				SplitByComponentsWrapper = 0
			};
		}
	}
}
