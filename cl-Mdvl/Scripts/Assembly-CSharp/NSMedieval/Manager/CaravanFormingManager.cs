using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.MovableBuildings;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;

namespace NSMedieval.Manager
{
	public class CaravanFormingManager : MonoSingleton<CaravanFormingManager>
	{
		private const long CaravanFormingTimeout = 18L;

		private Timer caravanFailureCheckTimer;

		public void FormNewCaravan(CaravanInstance instance)
		{
			OrderCaravanForming(instance);
		}

		public void CancelCaravansFormingTo(WorldMapPlace place)
		{
			HashSet<CaravanInstance> caravansInPreparation = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation;
			if (caravansInPreparation.Count == 0)
			{
				return;
			}
			using PooledList<CaravanInstance> pooledList = caravansInPreparation.ToPooledListJanitor();
			foreach (CaravanInstance item in pooledList)
			{
				if (item.DestinationPlace == place)
				{
					CancelCaravanForming(item);
				}
			}
		}

		public void CancelCaravanForming(CaravanInstance caravanInstance)
		{
			if (caravanInstance == null)
			{
				return;
			}
			foreach (CreatureBase creature in caravanInstance.Creatures)
			{
				if (creature is AnimalInstance animalInstance)
				{
					animalInstance.RopeTo(null);
					animalInstance.ClearCaravanFormingData();
				}
				else if (creature is HumanoidInstance humanoidInstance)
				{
					humanoidInstance.ClearCaravanFormingData();
				}
			}
			HumanoidInstance humanoidInstance2 = null;
			if (caravanInstance.Workers != null)
			{
				foreach (HumanoidInstance worker in caravanInstance.Workers)
				{
					if (!worker.HasDisposed)
					{
						if (worker.IsInIncognitoMode())
						{
							worker.IncognitoSpawn(worker.GetPosition());
						}
						WorkerGoapAgent workerGoapAgent = (WorkerGoapAgent)worker.GetGoapAgent();
						if (workerGoapAgent != null && !workerGoapAgent.HasDisposed && !worker.HasDied)
						{
							workerGoapAgent.Abort();
							workerGoapAgent.ClearCaravanFormingData();
							humanoidInstance2 = worker;
						}
					}
				}
			}
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Contains(caravanInstance))
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Remove(caravanInstance);
			}
			if (humanoidInstance2 == null)
			{
				humanoidInstance2 = caravanInstance.Workers.PickRandom() ?? MonoSingleton<WorkerManager>.Instance.AllWorkers.PickRandom().Key;
			}
			if (humanoidInstance2 != null && caravanInstance.TMPResourcesToCarry != null)
			{
				foreach (ResourceInstance item in caravanInstance.TMPResourcesToCarry)
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item, humanoidInstance2.GetPosition());
				}
			}
			else
			{
				Log.Error("This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanFormingManager.cs");
			}
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_canceled"));
			MonoSingleton<CaravanController>.Instance.CaravanFormingCanceled(caravanInstance);
			caravanInstance.ClearTmpResourcesToCarry();
		}

		public void OrderCaravanForming(CaravanInstance caravanInstance, bool isLoad = false)
		{
			if (!caravanInstance.CaravanState.Equals(CaravanState.None))
			{
				return;
			}
			if (!isLoad)
			{
				AssignWorkerPiles(caravanInstance);
				RemoveResourcesFromStoredPiles(caravanInstance);
				caravanInstance.FindMeetingPoints();
				caravanInstance.FindExitPoints();
			}
			if (isLoad)
			{
				caravanInstance.ResetCreaturesOnLoad();
			}
			foreach (HumanoidInstance worker in caravanInstance.Workers)
			{
				if (!worker.HasDied && !worker.HasDisposed && !worker.IsInIncognitoMode())
				{
					worker.StartCaravanFormation(caravanInstance);
				}
			}
			foreach (CreatureBase creature in caravanInstance.Creatures)
			{
				if (creature is AnimalInstance animalInstance)
				{
					animalInstance.StartCaravanFormation(caravanInstance);
				}
				else if (creature is HumanoidInstance humanoidInstance)
				{
					humanoidInstance.StartCaravanFormation(caravanInstance);
				}
			}
			if (caravanInstance.Workers.Count > 0 && !MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Contains(caravanInstance))
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Add(caravanInstance);
			}
			Log.Info("Workers got order to form a caravan!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanFormingManager.cs");
		}

		public void CancelCaravansWithAnimal(AnimalInstance animalInstance)
		{
			List<CaravanInstance> list = new List<CaravanInstance>();
			foreach (CaravanInstance item in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation)
			{
				if (item.Creatures.Contains(animalInstance))
				{
					list.Add(item);
				}
			}
			foreach (CaravanInstance item2 in list)
			{
				CancelCaravanForming(item2);
			}
		}

		private void RemoveResourcesFromStoredPiles(CaravanInstance caravanInstance)
		{
			IEnumerable<ResourcePileInstance> pilesFromStockpilesAndShelves = ResourcePileUtils.GetPilesFromStockpilesAndShelves();
			List<ResourceInstance> list = caravanInstance.TMPResourcesToCarry.Select((ResourceInstance item) => item.Clone()).ToList();
			foreach (ResourceInstance item in list)
			{
				foreach (ResourcePileInstance item2 in pilesFromStockpilesAndShelves)
				{
					if (item2.HasDisposed || item2.Blueprint != item.Blueprint)
					{
						continue;
					}
					if (item2 is MovableBuildingPileInstance movableBuildingPileInstance)
					{
						movableBuildingPileInstance.PileAddedToCaravan();
					}
					ResourceInstance resourceInstance = item2.GetStorage().Take(item);
					MonoSingleton<CaravanController>.Instance.PileAddedToCaravan(item2);
					if (resourceInstance != null && resourceInstance.Amount != 0)
					{
						item.Sub(resourceInstance);
						if (item.Amount <= 0)
						{
							break;
						}
					}
				}
			}
			if (list.Any((ResourceInstance item) => item.Amount > 0))
			{
				Log.Error("Some of the resources could not be properly taken for caravan!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaravanFormingManager.cs");
			}
		}

		private void AssignWorkerPiles(CaravanInstance caravanInstance)
		{
		}

		private void OnCaravanCreated(CaravanInstance caravanInstance)
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Contains(caravanInstance))
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.Remove(caravanInstance);
			}
		}

		private void TimeTick()
		{
			long minutesTotal = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
			long num = (long)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * 18L;
			HashSet<CaravanInstance> hashSet = null;
			foreach (CaravanInstance item in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation)
			{
				if (minutesTotal - item.CreationTime >= num)
				{
					if (hashSet == null)
					{
						hashSet = new HashSet<CaravanInstance>();
					}
					hashSet.Add(item);
				}
			}
			if (hashSet == null)
			{
				return;
			}
			foreach (CaravanInstance item2 in hashSet)
			{
				CancelCaravanForming(item2);
			}
		}

		private void OnAnimalRemoved(AnimalInstance animalInstance)
		{
			if (!animalInstance.IsInIncognitoMode())
			{
				CancelCaravansWithAnimal(animalInstance);
			}
		}

		private void Start()
		{
			CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
			caravanController.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(caravanController.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnAnimalRemoved;
			caravanFailureCheckTimer = new Timer(20f, restartOnEnd: true);
			caravanFailureCheckTimer.AddCallback(TimeTick);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
				caravanController.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(caravanController.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
			}
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnAnimalRemoved;
			}
			base.OnDestroy();
			caravanFailureCheckTimer?.Dispose();
			caravanFailureCheckTimer = null;
		}
	}
}
