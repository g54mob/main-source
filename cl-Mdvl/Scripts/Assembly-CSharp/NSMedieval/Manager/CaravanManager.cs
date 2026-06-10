using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using NSMedieval.WorldMap.Caravan;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CaravanManager : MonoSingleton<CaravanManager>
	{
		[SerializeField]
		private CaravanView caravanPrefab;

		[SerializeField]
		private CaravanFormPanelView caravanFormPanelView;

		[SerializeField]
		private LeaveMapCaravanPanelView leaveMapCaravanPanelView;

		[SerializeField]
		private LootPlaceCaravanPanelView lootPlaceCaravanPanelView;

		[NonSerialized]
		private readonly Dictionary<CaravanInstance, CaravanView> caravanViews = new Dictionary<CaravanInstance, CaravanView>();

		[NonSerialized]
		private readonly List<CaravanInstance> toRemove = new List<CaravanInstance>();

		private static List<CaravanInstance> Caravans
		{
			get
			{
				if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
				{
					return MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Caravans;
				}
				return null;
			}
		}

		public static float CalculateAmbushChance(float chanceMultiplier, float tripDurationHours, IReadOnlyCollection<HumanoidInstance> caravanWorkers, int prisonersCount, float caravanWealth)
		{
			if (caravanWorkers == null || caravanWorkers.Count == 0)
			{
				return 0f;
			}
			float multiplierInterpolated = CaravanAmbushSettings.I.ChanceByTripLength.GetMultiplierInterpolated(Mathf.RoundToInt(tripDurationHours));
			float multiplierInterpolated2 = CaravanAmbushSettings.I.ChanceBySettlersCount.GetMultiplierInterpolated(Mathf.RoundToInt(caravanWorkers.Count));
			float multiplierInterpolated3 = CaravanAmbushSettings.I.ChanceByPrisonersCount.GetMultiplierInterpolated(Mathf.RoundToInt(prisonersCount));
			float f = caravanWealth / (float)caravanWorkers.Count;
			float multiplierInterpolated4 = CaravanAmbushSettings.I.ChanceByWealthPerSettler.GetMultiplierInterpolated(Mathf.RoundToInt(f));
			int num = 0;
			foreach (HumanoidInstance caravanWorker in caravanWorkers)
			{
				if (caravanWorker.HasWeapon())
				{
					num++;
				}
			}
			float f2 = 100f * (float)num / (float)caravanWorkers.Count;
			float multiplierInterpolated5 = CaravanAmbushSettings.I.ChanceByArmedSettlersPercentage.GetMultiplierInterpolated(Mathf.RoundToInt(f2));
			float value = chanceMultiplier * multiplierInterpolated5 * multiplierInterpolated4 * multiplierInterpolated3 * multiplierInterpolated2 * multiplierInterpolated;
			value = Mathf.Clamp01(value);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(116, 7, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Calculated ambush chance for caravan (base: ");
				messageBuilder.AppendFormatted(chanceMultiplier);
				messageBuilder.AppendLiteral(", armed sett.: ");
				messageBuilder.AppendFormatted(multiplierInterpolated5);
				messageBuilder.AppendLiteral(", wealth: ");
				messageBuilder.AppendFormatted(multiplierInterpolated4);
				messageBuilder.AppendLiteral(", prisoners.cnt: ");
				messageBuilder.AppendFormatted(multiplierInterpolated3);
				messageBuilder.AppendLiteral(", settlers.cnt: ");
				messageBuilder.AppendFormatted(multiplierInterpolated2);
				messageBuilder.AppendLiteral(", length: ");
				messageBuilder.AppendFormatted(multiplierInterpolated);
				messageBuilder.AppendLiteral(") = ");
				messageBuilder.AppendFormatted(value);
			}
			Log.Debug(messageBuilder);
			return value;
		}

		public static float CalculateAmbushPosition(CaravanInstance caravan)
		{
			float num = CalculateAmbushChance(GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("caravanAmbushChanceMultiplier"), caravan.GetTripDurationHours(), caravan.Workers, caravan.PrisonersCount, caravan.GetWealth());
			if (UnityEngine.Random.value < num)
			{
				return Repository<CaravanAmbushSettingsData, CaravanAmbushSettings>.Instance.GetData<CaravanAmbushSettings>().TripPositionPercentRange.Random();
			}
			return -1f;
		}

		public static float CalculateAmbushChance(CaravanInstance caravan)
		{
			return CalculateAmbushChance(GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("caravanAmbushChanceMultiplier"), caravan.GetTripDurationHours(), caravan.Workers, caravan.PrisonersCount, caravan.GetWealth());
		}

		public static CaravanInstance GetCaravan(CreatureBase creature)
		{
			return Caravans.FirstOrDefault((CaravanInstance caravan) => caravan != null && ((caravan.Creatures != null && caravan.Creatures.Contains(creature)) || (caravan.Workers != null && caravan.Workers.Contains(creature))));
		}

		public static CaravanInstance GetCaravanAtOrTravellingTo(WorldMapMarkerPlace marker)
		{
			return Caravans.FirstOrDefault((CaravanInstance caravan) => caravan?.DestinationPlace == marker);
		}

		public static void SendAllHome(WorldMapPlace place)
		{
			foreach (CaravanInstance caravan in Caravans)
			{
				if (caravan != null && caravan.DestinationPlace == place && caravan.CaravanState != CaravanState.Returning)
				{
					caravan.StartTripHome();
				}
			}
		}

		public static CaravanInstance GetCaravan(int id)
		{
			return Caravans.FirstOrDefault((CaravanInstance caravan) => caravan.UniqueId == id);
		}

		public static CaravanInstance GetCaravan(CreatureBase creature, bool searchActiveCaravans, bool searchCaravansInPreparation)
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() || LoadingController.IsSceneTransition)
			{
				return null;
			}
			CaravanInstance caravanInstance = null;
			if (searchActiveCaravans)
			{
				caravanInstance = Caravans.FirstOrDefault((CaravanInstance caravan) => caravan != null && ((caravan.Creatures != null && caravan.Creatures.Contains(creature)) || (caravan.Workers != null && caravan.Workers.Contains(creature))));
			}
			if (caravanInstance == null && searchCaravansInPreparation)
			{
				caravanInstance = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.FirstOrDefault((CaravanInstance caravan) => caravan != null && ((caravan.Creatures != null && caravan.Creatures.Contains(creature)) || (caravan.Workers != null && caravan.Workers.Contains(creature))));
			}
			return caravanInstance;
		}

		public static CaravanInstance GetAnyActiveCaravan()
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() || LoadingController.IsSceneTransition)
			{
				return null;
			}
			if (Caravans.Count <= 0)
			{
				return null;
			}
			return Caravans[0];
		}

		public static CaravanPostComponentInstance GetNearestCaravanPost(CreatureBase worker)
		{
			Vec3Int b = worker.GetGridPosition();
			List<CaravanPostComponentInstance> list = new List<CaravanPostComponentInstance>();
			foreach (CaravanPostComponentInstance componentInstance in VillageManager.ActiveVillage.Map.CaravanPostComponentManager.ComponentInstances)
			{
				if (componentInstance != null && componentInstance.OwnerBuilding.ReachablePositions.Any() && PathfinderUtil.IsPathPossible(worker, componentInstance.GridDataPosition, b))
				{
					list.Add(componentInstance);
				}
			}
			CaravanPostComponentInstance caravanPostComponentInstance = null;
			float num = 0f;
			foreach (CaravanPostComponentInstance item in list)
			{
				if (caravanPostComponentInstance == null || (float)(item.GridDataPosition - b).sqrMagnitude < num)
				{
					num = (item.GridDataPosition - b).sqrMagnitude;
					caravanPostComponentInstance = item;
				}
			}
			return caravanPostComponentInstance;
		}

		public CaravanView GetView(CaravanInstance caravanInstance)
		{
			return caravanViews.GetValueOrDefault(caravanInstance);
		}

		public void OpenFormCaravanPanel(WorldMapPlace destinationPlace)
		{
			caravanFormPanelView.OpenPanel(VillageManager.ActiveVillage.Map, destinationPlace);
		}

		public void OpenLootPlacePanel(CaravanInstance caravan)
		{
			lootPlaceCaravanPanelView.OpenPanel(caravan, caravan.DestinationPlace);
		}

		public void OpenLeaveMapCaravanPanel()
		{
			WorldMapPlace worldMapPlace = GlobalSaveController.CurrentVillageData.WorldMapPlace;
			if (worldMapPlace.CaravanId == int.MaxValue)
			{
				Log.Info("Tried to open the leave map screen, but there is no caravan stationed at this place. This should not happen, but creating a new one to try and salvage the situation", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
				CaravanInstance caravanInstance = new CaravanInstance(worldMapPlace, snapToDestination: true);
				Caravans.Add(caravanInstance);
				worldMapPlace.CaravanId = caravanInstance.UniqueId;
			}
			CaravanInstance caravan = null;
			foreach (CaravanInstance caravan2 in Caravans)
			{
				if (caravan2.UniqueId == worldMapPlace.CaravanId)
				{
					caravan = caravan2;
					break;
				}
			}
			leaveMapCaravanPanelView.OpenPanel(VillageManager.ActiveVillage.Map, caravan);
		}

		public void StartCaravan(CaravanInstance caravanInstance)
		{
			caravanInstance.InitCaravanStorage();
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("StartCaravan: adding ");
				messageBuilder.AppendFormatted(caravanInstance.Name);
				messageBuilder.AppendLiteral(" to caravans.");
			}
			Log.Info(messageBuilder);
			Caravans.Add(caravanInstance);
			RemoveWorkersBeforeStart(caravanInstance.Workers);
			Vector2Int villagePosition = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePosition;
			caravanInstance.StartTrip(villagePosition, caravanInstance.DestinationPlace.Position);
			caravanInstance.AmbushTripPositionNormalized = CalculateAmbushPosition(caravanInstance);
			messageBuilder = new FVLogInfoInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Caravan ambush trip position: ");
				messageBuilder.AppendFormatted(caravanInstance.AmbushTripPositionNormalized);
				messageBuilder.AppendLiteral(", caravan: ");
				messageBuilder.AppendFormatted(this);
			}
			Log.Info(messageBuilder);
			CreateViewForCaravan(caravanInstance);
			MonoSingleton<CaravanController>.Instance.CaravanCreated(caravanInstance);
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_left"));
			MonoSingleton<AchievementManager>.Instance.IncreaseStat("SEND_CARAVAN_CNT");
		}

		public bool IsAnyCaravanGoingTo(WorldMapPlace mapPlace)
		{
			for (int i = 0; i < Caravans.Count; i++)
			{
				CaravanInstance caravanInstance = Caravans[i];
				if (caravanInstance.DestinationPlace == mapPlace && caravanInstance.CaravanState != CaravanState.Returning && caravanInstance.CaravanState != CaravanState.Finished)
				{
					return true;
				}
			}
			return false;
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			base.OnDestroy();
		}

		private void Update()
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() || !MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible || caravanViews.Count == 0)
			{
				return;
			}
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			long minutesTotal = dateAndTime.MinutesTotal;
			float minuteFract = dateAndTime.MinuteFract;
			foreach (CaravanInstance caravan in Caravans)
			{
				caravanViews[caravan].TickTime(minutesTotal, minuteFract);
			}
		}

		private void OnTimeUpdate()
		{
			if (Caravans == null || LoadingController.IsSceneTransition || LoadingController.IsLeavingMainScene || GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return;
			}
			foreach (CaravanInstance caravan in Caravans)
			{
				WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
				if (caravan.TickTime(dateAndTime.MinutesTotal, dateAndTime.MinuteFract))
				{
					toRemove.Add(caravan);
					caravan.OnReturnedHome();
					CaravanReturnedHome(caravan);
					MonoSingleton<CaravanController>.Instance.CaravanReturnedHome(caravan);
				}
			}
			if (toRemove.Count <= 0)
			{
				return;
			}
			foreach (CaravanInstance item in toRemove)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Caravan arrived home from village: ");
					messageBuilder.AppendFormatted(item.DestinationPlace?.Name);
				}
				Log.Info(messageBuilder);
				Caravans.Remove(item);
				CaravanView caravanView = caravanViews[item];
				caravanViews.Remove(item);
				caravanView.OnEnd();
				UnityEngine.Object.Destroy(caravanView.gameObject);
			}
			toRemove.Clear();
		}

		private void OnMapLoaded(bool fromSave)
		{
			if (!fromSave || GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return;
			}
			foreach (CaravanInstance caravan in Caravans)
			{
				caravan.OnLoadedFromSave();
				CreateViewForCaravan(caravan);
			}
			List<HumanoidInstance> list = ListPool<HumanoidInstance>.Get();
			foreach (CaravanInstance item in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation)
			{
				if (item.CaravanState != CaravanState.None || item.Workers == null)
				{
					continue;
				}
				foreach (ResourceInstance item2 in item.TMPResourcesToCarry)
				{
					if (item2 != null && item2.Stats != null && item2.Stats.Owner == null)
					{
						item2.InitAfterLoadPile();
					}
				}
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loading caravan ");
					messageBuilder.AppendFormatted(item.Name);
					messageBuilder.AppendLiteral(". Clearing workers.");
				}
				Log.Info(messageBuilder);
				list.Clear();
				list.AddRange(item.Workers);
				item.Workers.Clear();
				foreach (int workerId in item.WorkerGlobalIndexes)
				{
					HumanoidInstance humanoidInstance = GlobalSaveController.CurrentVillageData.Workers.FirstOrDefault((HumanoidInstance w) => w.UniqueId == workerId);
					if (humanoidInstance == null)
					{
						humanoidInstance = list.FirstOrDefault((HumanoidInstance w) => w.UniqueId == workerId);
						if (humanoidInstance == null)
						{
							messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Cannot find humanoid with id: ");
								messageBuilder.AppendFormatted(workerId);
							}
							Log.Info(messageBuilder);
							continue;
						}
					}
					item.Workers.Add(humanoidInstance);
					messageBuilder = new FVLogInfoInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Caravan '");
						messageBuilder.AppendFormatted(item.Name);
						messageBuilder.AppendLiteral("': added ");
						messageBuilder.AppendFormatted(humanoidInstance.Info.GetFullName());
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
				}
				if (item.Workers.Count != 0)
				{
					MonoSingleton<CaravanFormingManager>.Instance.OrderCaravanForming(item, isLoad: true);
				}
			}
			ListPool<HumanoidInstance>.Return(list);
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.RemoveWhere((CaravanInstance caravan) => caravan.CaravanState != CaravanState.None || caravan.Workers.Count == 0);
		}

		private CaravanView CreateViewForCaravan(CaravanInstance caravanInstance)
		{
			CaravanView caravanView = UnityEngine.Object.Instantiate(caravanPrefab, MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.HeightmapContent.transform, worldPositionStays: true);
			caravanView.Setup(caravanInstance);
			if (caravanViews.ContainsKey(caravanInstance))
			{
				Log.Info("Caravan: This should not happen", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
				caravanViews.Remove(caravanInstance);
			}
			caravanViews.Add(caravanInstance, caravanView);
			return caravanView;
		}

		private void RemoveWorkersBeforeStart(HashSet<HumanoidInstance> workers)
		{
			foreach (HumanoidInstance worker in workers)
			{
				worker.IncognitoDispose();
			}
		}

		private static void RandomizeStat(StatInstance stat, float min, float max)
		{
			if (stat != null)
			{
				float current = Mathf.Lerp(stat.Min, stat.Max, Mathf.Clamp01(UnityEngine.Random.Range(min, max)));
				stat.SetCurrent(current);
			}
		}

		private void CaravanReturnedHome(CaravanInstance caravanInstance)
		{
			HumanoidInstance humanoidInstance = caravanInstance.Workers.PickRandom();
			WalkableModel walkableModel = humanoidInstance?.CurrentHumanType.WalkableModelFriendly;
			foreach (HumanoidInstance worker in caravanInstance.Workers)
			{
				worker.Stats.StartEffector("CaravanReturnedHomeWorker");
			}
			List<CreatureBase> list = new List<CreatureBase>(caravanInstance.Workers);
			list.AddRange(caravanInstance.Creatures);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (num < list.Count)
				{
					CreatureBase creatureBase = list[num];
					if (creatureBase.HasDied || creatureBase.HasDisposed)
					{
						if (!creatureBase.HasDisposed)
						{
							creatureBase.Dispose();
						}
						list.RemoveAt(num);
					}
				}
			}
			foreach (CreatureBase item in list)
			{
				if (item is AnimalInstance animalInstance)
				{
					animalInstance.RopeTo(null);
					animalInstance.ReturnedHomeFromCaravan();
				}
			}
			if (list.Count > 0)
			{
				NPCStartPositionManager.SetStartPositionsForAgents(walkableModel, list, delegate(MapNode node, IPathfindingAgent agent)
				{
					if (agent is AnimalInstance animalInstance2)
					{
						animalInstance2.IncognitoSpawn(node.WorldPosition);
						animalInstance2.SetPredatorsCannotTargetForHours(3f);
						RandomizeStat(animalInstance2.Stats.GetStat(StatType.Hunger), 0.6f, 1f);
					}
					else
					{
						HumanoidInstance humanoidInstance3 = (HumanoidInstance)agent;
						if (humanoidInstance3.WorkerBehaviour != null)
						{
							humanoidInstance3.WorkerBehaviour.SetCombatMode(UnitCombatModeType.Neutral);
						}
						humanoidInstance3.IncognitoSpawn(node.WorldPosition, randomizeAppearance: false);
						RandomizeStat(humanoidInstance3.Stats.GetStat(StatType.Hunger), 0.6f, 0.9f);
						RandomizeStat(humanoidInstance3.Stats.GetStat(StatType.Sleep), 0.4f, 0.8f);
						RandomizeStat(humanoidInstance3.Stats.GetStat(StatType.Entertaiment), 0.4f, 0.7f);
						RandomizeStat(humanoidInstance3.Stats.GetStat(StatType.Mood), 0.45f, 0.65f);
					}
				});
			}
			long num2 = (caravanInstance.GetTripDurationMinutes() * 2 + caravanInstance.GetWaitDurationBeforeGoHome()) / GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			MonoSingleton<ProximityInteractionManager>.Instance.SimulateInteractions(list, num2);
			Vector3 worldPosition = Vector3.zero;
			if (caravanInstance.Workers.Count > 0)
			{
				HumanoidInstance humanoidInstance2 = caravanInstance.Workers.First();
				MonoSingleton<RtsCamera>.Instance.JumpTo(humanoidInstance2.GetPosition());
				worldPosition = GetNearestCaravanPost(humanoidInstance2)?.GetPosition() ?? humanoidInstance2.GetPosition();
			}
			foreach (ResourceInstance resource3 in caravanInstance.Storage.Resources)
			{
				if (resource3.Amount == 0)
				{
					continue;
				}
				if (caravanInstance.Workers.Count > 0)
				{
					Log.Info("Caravan returned home. Spawn instance: " + resource3.Blueprint?.ToString() + " - " + resource3.Amount, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
					if (resource3 is CarcassResourceInstance carcassResourceInstance)
					{
						CarcassResourceInstance resource = (CarcassResourceInstance)carcassResourceInstance.Clone();
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource, worldPosition);
					}
					else
					{
						ResourceInstance resource2 = resource3.Clone();
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource2, worldPosition);
					}
				}
				resource3.Dispose();
			}
			caravanInstance.Storage.Dispose();
			WorkerView selectable = humanoidInstance?.GetAgentView<WorkerView>();
			MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_mesage_back"), selectable);
		}

		public bool IsWorkerInCaravan(HumanoidInstance humanoidInstance)
		{
			if (Caravans == null)
			{
				return false;
			}
			foreach (CaravanInstance caravan in Caravans)
			{
				if (caravan.CaravanState != CaravanState.Finished && caravan.Workers.Contains(humanoidInstance))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnyCaravanAmbushed()
		{
			return Caravans.Any((CaravanInstance caravan) => caravan.EventContext is AmbushContext);
		}

		public bool CanAmbushHappen()
		{
			return !IsAnyCaravanAmbushed();
		}

		public void DisposeCurrentWorldMapPlaceCaravan()
		{
			CaravanInstance currentCaravanInstance = GetCurrentCaravanInstance();
			if (currentCaravanInstance != null)
			{
				Caravans.Remove(currentCaravanInstance);
				if (caravanViews.Remove(currentCaravanInstance, out var value))
				{
					UnityEngine.Object.Destroy(value.gameObject);
					value.OnEnd();
				}
			}
		}

		private CaravanInstance GetCurrentCaravanInstance()
		{
			WorldMapPlace worldMapPlace = GlobalSaveController.CurrentVillageData.WorldMapPlace;
			if (worldMapPlace.CaravanId == int.MaxValue)
			{
				Log.Info("Tried to open the leave map screen, but there is no caravan stationed at this place. Creating a new one.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanManager.cs");
				CaravanInstance caravanInstance = new CaravanInstance(worldMapPlace, snapToDestination: true);
				Caravans.Add(caravanInstance);
				worldMapPlace.CaravanId = caravanInstance.UniqueId;
			}
			foreach (CaravanInstance caravan in Caravans)
			{
				if (caravan.UniqueId == worldMapPlace.CaravanId)
				{
					return caravan;
				}
			}
			return null;
		}
	}
}
