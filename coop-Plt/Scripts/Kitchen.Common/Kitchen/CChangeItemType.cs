using Unity.Entities;

namespace Kitchen
{
	public struct CChangeItemType : IComponentData
	{
		public int NewID;

		public bool CollapseComponents;

		public int ApplyProcessToComponents;

		public bool MakeSelfSplittable;

		public static implicit operator CChangeItemType(int t)
		{
			return new CChangeItemType
			{
				NewID = t
			};
		}

		public static implicit operator int(CChangeItemType h)
		{
			return h.NewID;
		}
	}
}
