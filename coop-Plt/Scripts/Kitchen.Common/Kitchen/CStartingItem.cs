using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(16)]
	public struct CStartingItem : IBufferElementData
	{
		public int ID;

		public bool SkipFirstTimeInfo;

		public static implicit operator int(CStartingItem item)
		{
			return item.ID;
		}

		public static implicit operator CStartingItem(int item)
		{
			return new CStartingItem
			{
				ID = item
			};
		}
	}
}
