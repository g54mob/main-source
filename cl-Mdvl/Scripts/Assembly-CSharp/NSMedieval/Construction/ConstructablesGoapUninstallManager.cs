using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.Construction
{
	public class ConstructablesGoapUninstallManager : MonoSingleton<ConstructablesGoapUninstallManager>
	{
		private readonly HashSet<BaseBuildingInstance> objectsToUninstall = new HashSet<BaseBuildingInstance>();

		public HashSet<BaseBuildingInstance> ObjectsToUninstall => objectsToUninstall;

		public event Action<BaseBuildingInstance> OnMarkedForUninstallEvent;

		public event Action<BaseBuildingInstance> OnUnMarkedForUninstallEvent;

		public void AddToUninstallList(BaseBuildingInstance target)
		{
			if (objectsToUninstall.Add(target))
			{
				this.OnMarkedForUninstallEvent?.Invoke(target);
			}
		}

		public void RemoveFromUninstallList(BaseBuildingInstance target)
		{
			if (objectsToUninstall.Remove(target))
			{
				this.OnUnMarkedForUninstallEvent?.Invoke(target);
			}
		}
	}
}
