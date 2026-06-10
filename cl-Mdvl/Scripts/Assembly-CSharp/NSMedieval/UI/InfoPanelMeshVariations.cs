using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelMeshVariations : SelectionExtraView
	{
		public List<BaseBuildingInstance> Selection { get; }

		public InfoPanelMeshVariations(IEnumerable<BaseBuildingInstance> selectionWithMeshVariations)
		{
			Selection = new List<BaseBuildingInstance>(selectionWithMeshVariations);
		}

		public InfoPanelMeshVariations(BaseBuildingInstance baseBuildableObject)
		{
			Selection = new List<BaseBuildingInstance> { baseBuildableObject };
		}
	}
}
