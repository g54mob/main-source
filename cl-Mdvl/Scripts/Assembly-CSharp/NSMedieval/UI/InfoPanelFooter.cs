using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class InfoPanelFooter
	{
		public List<InfoPanelAction> InfoPanelActions { get; }

		public HumanoidInstance Humanoid { get; }

		public BaseBuildingInstance BaseBuildingInstance { get; }

		public DoorComponentInstance DoorComponentInstance { get; }

		public WindowComponentInstance WindowComponentInstance { get; }

		public InfoPanelFooter(List<InfoPanelAction> actions, HumanoidInstance humanoid = null)
		{
			Humanoid = humanoid;
			InfoPanelActions = actions;
		}

		public InfoPanelFooter(List<InfoPanelAction> actions, BaseBuildingInstance baseBuildingInstance)
		{
			InfoPanelActions = actions;
			BaseBuildingInstance = baseBuildingInstance;
		}

		public InfoPanelFooter(List<InfoPanelAction> actions, HumanoidInstance humanoid, BaseBuildingInstance baseBuildingInstance, DoorComponentInstance doorComponentInstance)
		{
			Humanoid = humanoid;
			DoorComponentInstance = doorComponentInstance;
			InfoPanelActions = actions;
			BaseBuildingInstance = baseBuildingInstance;
		}

		public InfoPanelFooter(List<InfoPanelAction> actions, HumanoidInstance humanoid, BaseBuildingInstance baseBuildingInstance, WindowComponentInstance windowComponentInstance)
		{
			Humanoid = humanoid;
			WindowComponentInstance = windowComponentInstance;
			InfoPanelActions = actions;
			BaseBuildingInstance = baseBuildingInstance;
		}
	}
}
