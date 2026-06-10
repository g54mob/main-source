using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelBuildingOwnership : SelectionExtraView
	{
		private BaseBuildingInstance baseBuildingInstance;

		public BaseBuildingInstance BaseBuildingInstance => baseBuildingInstance;

		public InfoPanelBuildingOwnership(BaseBuildingInstance baseBuildingInstance)
		{
			this.baseBuildingInstance = baseBuildingInstance;
		}
	}
}
