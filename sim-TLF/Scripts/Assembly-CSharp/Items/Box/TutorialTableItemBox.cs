using Services.Missions;
using Zenject;

namespace Items.Box
{
	public class TutorialTableItemBox : ItemBoxView
	{
		[Inject]
		private MissionEventBus _missionEventBus;

		private void OnEnable()
		{
			base.OnBoxOpened += OpenTableBox;
		}

		private void OpenTableBox()
		{
			_missionEventBus.Emit("interact", "openTableBox");
		}
	}
}
