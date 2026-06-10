using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelRallyPoint : SelectionExtraView
	{
		private BaseBuildingInstance baseBuildingInstance;

		public BaseBuildingInstance BaseBuildingInstance => baseBuildingInstance;

		public InfoPanelRallyPoint(BaseBuildingInstance baseBuildingInstance)
		{
			this.baseBuildingInstance = baseBuildingInstance;
		}
	}
}
