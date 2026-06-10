using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace Constructables.Managers
{
	public class BuildingsManagerCommon : MonoSingleton<BuildingsManagerCommon>, IObserver
	{
		private readonly WaitForSecondsRealtime shortWait = new WaitForSecondsRealtime(0.05f);

		private ThreadingJobSystem.ThreadedTaskData refreshBlueprintsWorldStateChanged;

		private ThreadingJobSystem.ThreadedTaskData refreshBlueprintsResourceChanged;

		private ThreadingJobSystem.ThreadedTaskData refreshBlueprintsBuildingPlaced;

		private bool coroutineRunning;

		[NonSerialized]
		private VillageMap villageMap;

		public bool CoroutineRunning => coroutineRunning;

		protected override void OnDestroy()
		{
			villageMap = null;
			base.OnDestroy();
		}

		public void StartResourceChangedRefreshBlueprintsCoroutine(IList<BaseBuildingInstance> buildingBlueprints, IEnumerable<HumanoidInstance> workers, int pause = 40)
		{
			StartCoroutine(this?.ResourceChangedRefreshBlueprintsCoroutine(buildingBlueprints, workers));
		}

		private void Start()
		{
			villageMap = VillageManager.ActiveVillage.Map;
		}

		private IEnumerator ResourceChangedRefreshBlueprintsCoroutine(IList<BaseBuildingInstance> buildingBlueprints, IEnumerable<HumanoidInstance> workers, int pause = 40)
		{
			coroutineRunning = true;
			int counter = 0;
			IOrderedEnumerable<BaseBuildingInstance> orderedEnumerable = buildingBlueprints.OrderByDescending((BaseBuildingInstance x) => x.Stability - ((x.Reachable && x.ResourcesAvailable) ? 1 : 4) > 0);
			foreach (BaseBuildingInstance blueprintBuilding in orderedEnumerable)
			{
				counter++;
				if (counter == pause)
				{
					counter = 0;
					yield return shortWait;
				}
				villageMap.BuildingsManagerMain.CheckBlueprintStatus(blueprintBuilding, workers);
			}
			coroutineRunning = false;
		}
	}
}
