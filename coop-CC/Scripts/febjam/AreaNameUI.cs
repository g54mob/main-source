using Aggro.Core;

public class AreaNameUI : EntityBehaviourBase
{
	public EaseUI parkingLot;

	public EaseUI breakroom;

	protected override void OnUpdatePresentation()
	{
		bool show = GameUtil.GetCurrentRoomType() == RoomType.Lobby;
		bool show2 = GameUtil.GetCurrentRoomType() == RoomType.BreakRoom;
		parkingLot.show = show;
		breakroom.show = show2;
	}
}
