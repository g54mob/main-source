using Unity.Entities;

namespace Kitchen
{
	public struct CCreateItem : IComponentData
	{
		public int ID;

		public Entity Holder;

		public static implicit operator CCreateItem(int t)
		{
			return new CCreateItem
			{
				ID = t
			};
		}

		public static implicit operator int(CCreateItem h)
		{
			return h.ID;
		}
	}
}
