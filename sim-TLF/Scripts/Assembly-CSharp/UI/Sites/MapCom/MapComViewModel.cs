using Loxodon.Framework.ViewModels;
using Services.Missions;
using Zenject;

namespace UI.Sites.MapCom
{
	internal class MapComViewModel : ViewModelBase
	{
		[Inject]
		private MissionEventBus _missionEventBus;

		internal void SetDestinationCommand()
		{
		}

		internal void ShowItemsCommand()
		{
		}

		internal void IslandCommand()
		{
		}
	}
}
