using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelPenMarker : InfoPanelMeshVariations
	{
		public InfoPanelPenMarker(IEnumerable<BaseBuildingInstance> selectionWithMeshVariations)
			: base(selectionWithMeshVariations)
		{
		}

		public InfoPanelPenMarker(BaseBuildingInstance baseBuildableObject)
			: base(baseBuildableObject)
		{
		}
	}
}
