using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelGraves : SelectionExtraView
	{
		public readonly List<GraveComponentInstance> GraveComponentInstances;

		public InfoPanelGraves(GraveComponentInstance graveComponentInstance)
		{
			GraveComponentInstances = new List<GraveComponentInstance> { graveComponentInstance };
		}

		public InfoPanelGraves(List<GraveComponentInstance> graveComponentInstances)
		{
			GraveComponentInstances = graveComponentInstances;
		}
	}
}
