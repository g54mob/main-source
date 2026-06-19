using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class RoomRef : ObjectRef<Room>
	{
		public RoomRef()
		{
		}

		public RoomRef(Room room)
			: base(room)
		{
		}
	}
}
