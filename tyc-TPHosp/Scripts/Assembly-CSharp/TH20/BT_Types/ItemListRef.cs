using System;
using System.Collections.Generic;

namespace TH20.BT_Types
{
	[Serializable]
	public class ItemListRef : ObjectRef<List<RoomItem>>
	{
		public ItemListRef()
		{
		}

		public ItemListRef(List<RoomItem> items)
			: base(items)
		{
		}
	}
}
