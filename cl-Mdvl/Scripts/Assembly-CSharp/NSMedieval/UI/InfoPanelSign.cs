using System;
using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	[Serializable]
	public class InfoPanelSign : SelectionExtraView
	{
		public Action<string> TooltipCallback { get; }

		public List<BaseBuildingInstance> Selection { get; }

		public InfoPanelSign(Action<string> tooltipCallback, BaseBuildingInstance baseBuildableObject)
		{
			TooltipCallback = tooltipCallback;
			Selection = new List<BaseBuildingInstance> { baseBuildableObject };
		}

		public InfoPanelSign(Action<string> tooltipCallback, List<BaseBuildingInstance> baseBuildableObjects)
		{
			TooltipCallback = tooltipCallback;
			Selection = new List<BaseBuildingInstance>(baseBuildableObjects);
		}
	}
}
