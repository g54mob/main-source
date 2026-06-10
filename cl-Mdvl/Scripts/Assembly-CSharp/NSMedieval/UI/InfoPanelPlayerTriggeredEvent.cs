using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;

namespace NSMedieval.UI
{
	public class InfoPanelPlayerTriggeredEvent : SelectionExtraView
	{
		public BaseBuildingInstance BaseBuildingInstance { get; }

		public PlayerTriggeredEvent PlayerTriggeredEvent { get; }

		public InfoPanelPlayerTriggeredEvent(BaseBuildingInstance baseBuildingInstance)
		{
			PlayerTriggeredEvent = Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetByID(baseBuildingInstance.Blueprint.PlayerTriggeredEvents[0]);
			BaseBuildingInstance = baseBuildingInstance;
		}
	}
}
