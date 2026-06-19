using FullInspector;
using UnityEngine.Video;

namespace TH20
{
	public class TutorialBuildModeDefinition : TutorialModeDefinition
	{
		public SharedInstance<RoomDefinition> RoomDefinition;

		public PingInit RoomsPing;

		public PingInit RoomSubMenuPing;

		public PingInit RoomBuildAcceptPing;

		public VideoReference VideoReference;

		public VideoClip VideoBlueprint;

		public bool ShowHubMenuArrow;

		public bool ShowSubMenuArrow;

		public override TutorialMode Create()
		{
			return new TutorialModeBuildRoom(this);
		}
	}
}
