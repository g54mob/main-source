using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class SuperBugRewardRoomItem : SuperBugReward
	{
		[Key(0)]
		public int RoomItemID;
	}
}
