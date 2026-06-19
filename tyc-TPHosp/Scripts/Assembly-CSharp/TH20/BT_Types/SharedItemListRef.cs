using System;
using System.Collections.Generic;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedItemListRef : SharedObjectRef<ItemListRef, List<RoomItem>>
	{
		public static implicit operator SharedItemListRef(ItemListRef value)
		{
			return new SharedItemListRef
			{
				Value = value
			};
		}
	}
}
