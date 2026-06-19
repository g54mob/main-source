using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class ItemRef : ObjectRef<RoomItem>
	{
		public ItemRef()
		{
		}

		public ItemRef(RoomItem item)
			: base(item)
		{
		}
	}
}
