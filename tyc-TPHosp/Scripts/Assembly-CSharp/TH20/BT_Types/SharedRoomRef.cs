using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedRoomRef : SharedObjectRef<RoomRef, Room>
	{
		public static implicit operator SharedRoomRef(RoomRef value)
		{
			return new SharedRoomRef
			{
				Value = value
			};
		}
	}
}
