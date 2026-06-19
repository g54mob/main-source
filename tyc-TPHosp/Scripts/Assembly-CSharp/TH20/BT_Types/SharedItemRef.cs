using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedItemRef : SharedObjectRef<ItemRef, RoomItem>
	{
		public static implicit operator SharedItemRef(ItemRef value)
		{
			return new SharedItemRef
			{
				Value = value
			};
		}
	}
}
