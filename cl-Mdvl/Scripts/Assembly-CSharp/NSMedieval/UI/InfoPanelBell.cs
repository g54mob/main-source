using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelBell : SelectionExtraView
	{
		private BaseBuildingInstance baseBuildingInstance;

		public BaseBuildingInstance BaseBuildingInstance => baseBuildingInstance;

		public InfoPanelBell(BaseBuildingInstance baseBuildingInstance)
		{
			this.baseBuildingInstance = baseBuildingInstance;
		}
	}
}
