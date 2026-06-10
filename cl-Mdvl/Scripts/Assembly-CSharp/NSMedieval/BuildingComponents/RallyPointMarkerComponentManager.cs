using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class RallyPointMarkerComponentManager : ComponentBaseManager<RallyPointMarkerComponent, RallyPointMarkerComponentInstance>
	{
		public RallyPointMarkerComponentManager(VillageMap map)
			: base(map)
		{
		}

		public IEnumerable<RallyPointMarkerComponentInstance> GetWorkerRallyPoints(HumanoidInstance worker)
		{
			foreach (RallyPointMarkerComponentInstance componentInstance in base.ComponentInstances)
			{
				if (componentInstance.IsWorkerSet(worker))
				{
					yield return componentInstance;
				}
			}
		}
	}
}
