using System.Collections;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.OcclusionCulling;
using NSMedieval.Testing.Autoplay;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Map
{
	public static class WorldLoadHandler
	{
		internal static IEnumerator LoadingSequence()
		{
			DebugEventLog.Initialize();
			_ = GlobalSaveController.CurrentVillageData.GameParametersCurrent;
			yield return new WaitForEndOfFrame();
			VillageMap map = VillageManager.ActiveVillage.Map;
			MonoSingleton<CropsManager>.Instance.Initialize(map);
			if (!GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				GlobalSaveController.CurrentVillageData.CheckDataIntegrity();
				MonoSingleton<LoadingController>.Instance.InvokeLoadingPhaseChanged("load_spawning_objects");
				yield return GlobalSaveController.CurrentVillageData.PlayerVillage.SpawnObjects();
				MonoSingleton<ResourcePileManager>.Instance.SpawnResourcesFromVillageMap();
				if (GlobalSaveController.CurrentVillageData.IsSecondMapFirstTime)
				{
					MonoSingleton<Heightmap>.Instance.RefreshWholeHeightmap();
					MonoSingleton<World>.Instance.RecalculateLargestArea();
					MonoSingleton<StartPositionManager>.Instance.CalculateDistanceMap();
					MonoSingleton<ResourcePileManager>.Instance.SpawnResourcesForSecondMap();
				}
				GlobalSaveController.CurrentVillageData.WorldMapData.InitAfterLoad();
			}
			else
			{
				MonoSingleton<LoadingController>.Instance.InvokeLoadingPhaseChanged("loading_spawning_slopes");
				MonoSingleton<SlopeManager>.Instance.CreateViews(GlobalSaveController.CurrentVillageData.PlayerVillage.Map);
				MonoSingleton<Heightmap>.Instance.RefreshWholeHeightmap();
				MonoSingleton<World>.Instance.RecalculateLargestArea();
				MonoSingleton<StartPositionManager>.Instance.CalculateDistanceMap();
				if (TestManager.SpawnResources && !GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					MonoSingleton<ResourcePileManager>.Instance.InstantiateStartingResourcePiles();
				}
			}
			yield return new WaitForSeconds(0.1f);
			if (GlobalSaveController.CurrentVillageData.IsSecondMapFirstTime)
			{
				MonoSingleton<TravelManager>.Instance.SpawnLoot();
				MonoSingleton<TravelManager>.Instance.SetSecondMapStartingPositions();
			}
			MonoSingleton<WorkerManager>.Instance.SetWorkerStartPositions();
			yield return new WaitForSeconds(0.1f);
			MonoSingleton<HeraldryManager>.Instance.UpdateHeraldry();
			yield return new WaitForSeconds(0.1f);
			MonoSingleton<OcclusionCullingManager>.Instance.InitAfterLoad(GlobalSaveController.CurrentVillageData.PlayerVillage.Map);
			MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(delegate
			{
				PathfinderUtil.ClearIsPathPossibleCache();
				PathfinderUtil.EnableCaching = true;
			});
		}
	}
}
