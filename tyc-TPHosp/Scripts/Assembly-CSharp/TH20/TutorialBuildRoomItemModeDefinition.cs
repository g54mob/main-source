using FullInspector;
using UnityEngine.Video;

namespace TH20
{
	public class TutorialBuildRoomItemModeDefinition : TutorialModeDefinition
	{
		public SharedInstance<RoomItemDefinition> RoomItemDefinition;

		public PingInit ItemsPing;

		public PingInit RoomItemPing;

		public VideoClip VideoClip;

		public VideoReference VideoReference;

		public bool ShowHubMenuArrow;

		public bool ShowSubMenuArrow;

		public override TutorialMode Create()
		{
			return new TutorialModeBuildRoomItem(this);
		}
	}
}
