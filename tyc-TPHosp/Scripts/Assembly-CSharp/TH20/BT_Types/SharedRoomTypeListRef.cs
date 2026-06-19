using System;
using System.Collections.Generic;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedRoomTypeListRef : SharedObjectRef<RoomTypeListRef, List<RoomDefinition.Type>>
	{
		public static implicit operator SharedRoomTypeListRef(RoomTypeListRef value)
		{
			return new SharedRoomTypeListRef
			{
				Value = value
			};
		}
	}
}
