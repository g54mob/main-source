using System.Linq;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class TrapComponentsManager : ComponentBaseManager<TrapComponent, TrapComponentInstance>
	{
		public TrapComponentsManager(VillageMap map)
			: base(map)
		{
		}

		public bool NonOperationalTrapsExist()
		{
			return base.ComponentInstances.Any((TrapComponentInstance trap) => !trap.Operational && !trap.IsOnFire);
		}
	}
}
