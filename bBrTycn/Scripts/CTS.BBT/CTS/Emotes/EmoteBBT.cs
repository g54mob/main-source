using CTS.Core.Utilities;

namespace CTS.Emotes
{
	public class EmoteBBT : Emote
	{
		public RoomBuilding RoomRef { get; private set; }

		public RoomObject ParentRoomData { get; private set; }

		public EmoteBBT SetRoomParent(RoomObject roomParent)
		{
			RoomRef = null;
			ParentRoomData = roomParent;
			if (base.IsPlaying)
			{
				base.CurrentPlayer.Cast<EmotePlayerBBT>().SetRoomParent(roomParent);
			}
			return this;
		}

		public EmoteBBT SetRoom(RoomObject room)
		{
			return SetRoom(room.CurrentRoom);
		}

		public EmoteBBT SetRoom(RoomBuilding room)
		{
			if ((bool)ParentRoomData)
			{
				ParentRoomData = null;
				if (base.IsPlaying)
				{
					base.CurrentPlayer.Cast<EmotePlayerBBT>().SetRoomParent(null);
				}
			}
			RoomRef = room;
			if (base.IsPlaying)
			{
				base.CurrentPlayer.Cast<EmotePlayerBBT>().SetRoom(RoomRef);
			}
			return this;
		}
	}
}
