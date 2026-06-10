using System.Collections.Generic;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class WindowComponentManager : ComponentBaseManager<WindowComponent, WindowComponentInstance>
	{
		private HashSet<WindowComponentInstance> hasWindowsWithOrder = new HashSet<WindowComponentInstance>();

		public HashSet<WindowComponentInstance> HasWindowsWithOrder => hasWindowsWithOrder;

		public WindowComponentManager(VillageMap map)
			: base(map)
		{
		}

		public override void Dispose()
		{
			hasWindowsWithOrder.Clear();
			hasWindowsWithOrder = null;
			base.Dispose();
		}
	}
}
