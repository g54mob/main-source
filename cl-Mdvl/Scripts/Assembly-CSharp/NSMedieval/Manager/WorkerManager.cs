using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class WorkerManager : MonoSingleton<WorkerManager>, IObserver, IWorkersCountProvider
	{
		private readonly Dictionary<HumanoidInstance, WorkerView> instanceViewDictionary = new Dictionary<HumanoidInstance, WorkerView>();

		private readonly HashSet<HumanoidInstance> faintedWorkers = new HashSet<HumanoidInstance>();

		private Cooldown debugEventCooldown;

		public ReadOnlyDictionary<HumanoidInstance, WorkerView> AllWorkers => new ReadOnlyDictionary<HumanoidInstance, WorkerView>(instanceViewDictionary);

		public HashSet<HumanoidInstance> FaintedWorkers => faintedWorkers;

		public static ReadOnlyDictionary<HumanoidInstance, WorkerView>.KeyCollection WorkersHere => MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys;

		public static IEnumerable<HumanoidInstance> WorkersEverywhere
		{
			get
			{
				foreach (HumanoidInstance item in WorkersHere)
				{
					yield return item;
				}
				foreach (HumanoidInstance caravanWorker in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravanWorkers)
				{
					yield return caravanWorker;
				}
			}
		}

		public static int GetMaxSkillLevel(SkillType type, JobType requiredJob = JobType.None)
		{
			int num = 0;
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (!worker.HasDisposed && (requiredJob == JobType.None || worker.WorkerBehaviour.IsJobActive(requiredJob)) && worker.GetSkillLevel(type) > num)
				{
					num = worker.GetSkillLevel(type);
				}
			}
			return num;
		}

		public static bool WorkerExistsCheckJobAndSkill(SkillType skillType, JobType jobType, int minSkill)
		{
			int num = MonoSingleton<WorkerManager>.Instance.AllWorkers.Count;
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (worker.Skills.GetSkill(skillType).Level < minSkill)
				{
					num--;
				}
				else if (!worker.WorkerBehaviour.ActiveJobCombination.HasFlag(jobType))
				{
					num--;
				}
			}
			return num > 0;
		}

		public void AnimateAllWorkers(string triggerName, float time, Func<HumanoidInstance, bool> condition = null)
		{
			float num = 0.2f;
			HumanoidInstance[] array = instanceViewDictionary.Keys.ToArray();
			foreach (HumanoidInstance humanoidInstance in array)
			{
				if (humanoidInstance != null && !humanoidInstance.HasDisposed && (condition == null || condition(humanoidInstance)))
				{
					humanoidInstance.GetGoapAgent()?.Abort();
					humanoidInstance.GetGoapAgent()?.DelayNextTick(time + num);
				}
			}
			MonoSingleton<TaskController>.Instance.WaitFor(num).Then(delegate
			{
				foreach (HumanoidInstance key in instanceViewDictionary.Keys)
				{
					if (key != null && !key.HasDisposed && (condition == null || condition(key)))
					{
						MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(key);
						MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(key, triggerName);
					}
				}
			});
		}

		public bool AnyWorker(Func<HumanoidInstance, bool> func)
		{
			return instanceViewDictionary.Keys.Any(func);
		}

		public bool IsRoleTaken(Role role, out HumanoidInstance humanoidInstance)
		{
			humanoidInstance = null;
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			pooledList.AddRange(instanceViewDictionary.Keys);
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				if (caravan?.Workers != null)
				{
					pooledList.AddRange(caravan.Workers);
				}
			}
			foreach (HumanoidInstance item in pooledList)
			{
				if (!item.HasDisposed && item.WorkerBehaviour.HumanoidRoleOwner.HasRole(role))
				{
					humanoidInstance = item;
					return true;
				}
			}
			return false;
		}

		public int GetWorkersCount()
		{
			return AllWorkers.Count;
		}

		public WorkerView GetView(HumanoidInstance humanoid)
		{
			return instanceViewDictionary.GetValueOrDefault(humanoid);
		}

		public void SetWorkerStartPositions()
		{
			int num = GlobalSaveController.CurrentVillageData.Workers.RemoveAll((HumanoidInstance worker) => worker.HasDisposed || worker.HasDied);
			bool isEnabled;
			if (num > 0)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removed ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" disposed / dead workers.");
				}
				Log.Info(messageBuilder);
			}
			List<HumanoidInstance> list = new List<HumanoidInstance>(GlobalSaveController.CurrentVillageData.Workers);
			foreach (HumanoidInstance item in list)
			{
				MonoSingleton<HumanoidIconManager>.Instance.GenerateAndCacheIcon(item);
			}
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				SetWorkerStartingPositions(list);
			}
			foreach (HumanoidInstance item2 in list)
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorker(item2);
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				pooledList.Clear();
				foreach (HumanoidInstance caravanWorker in caravan.Workers)
				{
					if (caravanWorker.HasDied || caravanWorker.HasDisposed)
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(94, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("[Autofix] Something went wrong and a worker instance has ");
							messageBuilder2.AppendFormatted(caravanWorker.HasDied ? "Dead" : "Disposed");
							messageBuilder2.AppendLiteral(". Removing from caravan. (worker: '");
							messageBuilder2.AppendFormatted(caravanWorker);
							messageBuilder2.AppendLiteral("')");
						}
						Log.Error(messageBuilder2);
						pooledList.Add(caravanWorker);
					}
					else if (list.Any((HumanoidInstance workerOnMap) => caravanWorker.UniqueId == workerOnMap.UniqueId))
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(147, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("[Autofix] Something went wrong and a worker instance is both in the caravan and on the current map, removing the one from the caravan. (worker: '");
							messageBuilder2.AppendFormatted(caravanWorker);
							messageBuilder2.AppendLiteral("')");
						}
						Log.Error(messageBuilder2);
						pooledList.Add(caravanWorker);
					}
					else
					{
						MonoSingleton<WorkerController>.Instance.InitIncognitoWorker(caravanWorker);
					}
				}
				foreach (HumanoidInstance item3 in pooledList)
				{
					caravan.Workers.Remove(item3);
				}
			}
			LogDebugEvents();
		}

		public void RunEffectorOnAllWorkersOneTime(string effectorName)
		{
			HumanoidInstance[] array = AllWorkers.Keys.ToArray();
			foreach (HumanoidInstance humanoidInstance in array)
			{
				if (!humanoidInstance.HasDisposed && !humanoidInstance.WorkerBehaviour.IsBanished)
				{
					humanoidInstance.Stats.StartEffector(effectorName);
				}
			}
		}

		public bool IsEveryoneSleeping()
		{
			return AllWorkers.Keys.Count((HumanoidInstance item) => item.IsSleeping && !item.WorkerBehaviour.IsDrafting) == GetWorkersCount();
		}

		public int GetResourceCountFromWorkerStorage(Resource blueprint)
		{
			if (blueprint == null)
			{
				return 0;
			}
			int num = 0;
			foreach (HumanoidInstance key in instanceViewDictionary.Keys)
			{
				foreach (ResourceInstance resource in key.GetStorage().Resources)
				{
					if (resource.Blueprint.Equals(blueprint))
					{
						num += resource.Amount;
					}
				}
			}
			return num;
		}

		public int GetResourceCountFromWorkerStorage(Resource blueprint, List<Resource> allowedBlueprints)
		{
			if (blueprint == null)
			{
				return 0;
			}
			int num = 0;
			foreach (HumanoidInstance key in instanceViewDictionary.Keys)
			{
				foreach (ResourceInstance resource in key.GetStorage().Resources)
				{
					if (resource.Blueprint.Equals(blueprint) && allowedBlueprints.Contains(blueprint))
					{
						num += resource.Amount;
					}
				}
			}
			return num;
		}

		public int GetResourceCategoryCountFromWorkerStorage(ResourceCategory resourceCategory)
		{
			if (resourceCategory.Equals(ResourceCategory.None))
			{
				return 0;
			}
			int num = 0;
			foreach (HumanoidInstance key in instanceViewDictionary.Keys)
			{
				foreach (ResourceInstance resource in key.GetStorage().Resources)
				{
					if (resource.Blueprint.Category.HasFlag(resourceCategory))
					{
						num += resource.Amount;
					}
				}
			}
			return num;
		}

		public int GetResourceCategoryCountFromWorkerStorage(ResourceCategory resourceCategory, List<Resource> allowedBlueprints)
		{
			if (resourceCategory.Equals(ResourceCategory.None))
			{
				return 0;
			}
			int num = 0;
			foreach (HumanoidInstance key in instanceViewDictionary.Keys)
			{
				foreach (ResourceInstance resource in key.GetStorage().Resources)
				{
					if (resource.Blueprint.Category.HasFlag(resourceCategory) && allowedBlueprints.Contains(resource.Blueprint))
					{
						num += resource.Amount;
					}
				}
			}
			return num;
		}

		public int GetResourceGroupCountFromWorkerStorage(string groupID)
		{
			int num = 0;
			foreach (HumanoidInstance key in instanceViewDictionary.Keys)
			{
				if (key.GetGoapAgent().CurrentGoalName.Equals("HungerGoal"))
				{
					continue;
				}
				foreach (ResourceInstance resource in key.GetStorage().Resources)
				{
					if (resource.Blueprint.GroupIdentifier == groupID)
					{
						num += resource.Amount;
					}
				}
			}
			return num;
		}

		public void InstantiateWorker(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance.ContainsBehaviourType(BehaviourType.NotWorker))
			{
				foreach (EquipmentInstance equipment in humanoidInstance.Inventory.GetEquipments())
				{
					equipment.SetIsManuallyEquipped(value: true);
				}
			}
			WorkerView component = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(humanoidInstance.Info.GetPhysicalLookKey()), humanoidInstance.GetPosition(), Quaternion.Euler(new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f)), base.transform).GetComponent<WorkerView>();
			GameObject gameObject = component.gameObject;
			gameObject.name = gameObject.name + "_" + humanoidInstance.Info.FirstName + "_" + humanoidInstance.Info.LastName;
			instanceViewDictionary.TryAdd(humanoidInstance, component);
			humanoidInstance.SetActiveBehaviour<WorkerBehaviour>(activate: false);
			humanoidInstance.InitStorages();
			component.Setup(humanoidInstance);
			humanoidInstance.Spawn();
			humanoidInstance.WorkerBehaviour.Setup();
			MonoSingleton<WorkerController>.Instance.WorkerCountChanged();
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "animal_update", UpdatePetOwners);
		}

		private void UpdatePetOwners()
		{
			List<HumanoidInstance> list = AllWorkers.Keys.ToList();
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				if (caravan?.Workers != null)
				{
					list.AddRange(caravan.Workers);
				}
			}
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (key.AnimalType == AnimalType.Pet || key.AnimalType == AnimalType.DomesticNpc)
				{
					int id = key.UniqueId;
					HumanoidInstance humanoidInstance = list.FirstOrDefault((HumanoidInstance item) => item.PetsIDs?.Contains(id) ?? false);
					if (humanoidInstance != null)
					{
						key.AssignPetOwner(humanoidInstance);
					}
				}
			}
		}

		private void OnPullOutTool(HumanoidInstance humanoid, string toolID, Transform socket)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].OnPullOutTool(toolID, socket);
			}
		}

		private void OnHideTool(HumanoidInstance humanoid)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].OnHideTool();
			}
		}

		private void OnFoodStorageChange(HumanoidInstance humanoid)
		{
			if (humanoid != null && instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].OnFoodStorageChange();
			}
		}

		private void OnMedicineStorageChange(HumanoidInstance humanoid)
		{
			if (humanoid != null && instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].OnMedicineStorageChange();
			}
		}

		private void OnTriggersReset(IGoapAgentOwner agentOwner)
		{
			if (agentOwner is HumanoidInstance key && instanceViewDictionary.ContainsKey(key))
			{
				instanceViewDictionary[key].ResetTriggers();
			}
		}

		private void OnTriggerAnimation(IGoapAgentOwner agentOwner, string trigger)
		{
			if (agentOwner is HumanoidInstance key && instanceViewDictionary.ContainsKey(key))
			{
				instanceViewDictionary[key].OnTriggerAnimation(trigger);
			}
		}

		private void OnFaceObject(HumanoidInstance humanoid, Vector3 objectPosition)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].FaceObject(objectPosition);
			}
		}

		private void OnFaceTransform(HumanoidInstance humanoid, Transform targetTransform)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].FaceObject(targetTransform);
			}
		}

		private void OnLookAt(HumanoidInstance humanoid, Transform targetTransform)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].LookAt(targetTransform);
			}
		}

		private void OnSetEulerAngle(HumanoidInstance humanoid, Vector3 newEulerAngles)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				instanceViewDictionary[humanoid].SetEulerAngle(newEulerAngles);
			}
		}

		private void SetWorkerStartingPositions(List<HumanoidInstance> workers)
		{
			int num = 0;
			while (num < workers.Count)
			{
				Vector3 position = MonoSingleton<StartPositionManager>.Instance.GetNextPositionWorldSpace();
				MonoSingleton<World>.Instance.LimitPositionToRange(ref position);
				if (!MonoSingleton<SlopeManager>.Instance.IsSlopeAt((int)position.x, (int)position.z) && !(MonoSingleton<FloraRegrowController>.Instance.GetPositionUsedBy((int)position.x, (int)position.z) != null))
				{
					position.y = MonoSingleton<Heightmap>.Instance.GetHeightAt((int)position.x, (int)position.z) * World.MapBlockHeight;
					workers[num].UpdatePosition(position);
					workers[num].SpawnPosition = position;
					num++;
				}
			}
		}

		private void OnCreateWorker(HumanoidInstance humanoid)
		{
			GlobalSaveController.CurrentVillageData.AddWorker(humanoid);
			Vector3 position = ((humanoid.GetPosition() == Vector3.zero) ? humanoid.WorkerBehaviour.WorkerBlueprint.SpawnPosition : humanoid.GetPosition());
			int index = GlobalSaveController.CurrentVillageData.Workers.IndexOf(humanoid);
			GlobalSaveController.CurrentVillageData.Workers[index].UpdatePosition(position);
		}

		public void RemoveWorker(HumanoidInstance humanoid)
		{
			if (instanceViewDictionary.ContainsKey(humanoid))
			{
				bool flag = false;
				StatInstance statInstance = humanoid.Stats?.GetStat(StatType.Health);
				if (!humanoid.WorkerBehaviour.IsBanished && !humanoid.HasDisposed && (statInstance == null || statInstance.Current <= 0.9f))
				{
					flag = true;
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("has_died", humanoid) ?? "", humanoid.GetPosition());
				}
				instanceViewDictionary[humanoid].Dispose();
				instanceViewDictionary.Remove(humanoid);
				faintedWorkers.Remove(humanoid);
				GlobalSaveController.CurrentVillageData.RemoveWorker(humanoid);
				MonoSingleton<HumanoidIconManager>.Instance.OnHumanoidRemoved(humanoid);
				MonoSingleton<WorkerController>.Instance.WorkerCountChanged();
				if (flag)
				{
					MonoSingleton<WorkerController>.Instance.WorkerDied(AllWorkers.Count);
				}
			}
		}

		private void OnFaintEvent(StatsInstance instance)
		{
			if (instance.Owner is HumanoidInstance item)
			{
				faintedWorkers.Add(item);
				MonoSingleton<WorkerController>.Instance.WorkerFainted(faintedWorkers.Count, AllWorkers.Count);
			}
		}

		private void OnWakeUpEvent(StatsInstance instance)
		{
			if (!(instance.Owner is HumanoidInstance humanoidInstance))
			{
				return;
			}
			if (humanoidInstance.HasFainted)
			{
				Log.Warning("WorkerManager.OnWakeUpEvent event fired, but humanoid is still fainted. Ignoring event. This is a failsafe.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
				return;
			}
			faintedWorkers.Remove(humanoidInstance);
			if (!IsEveryoneSleeping())
			{
				Log.Info("Worker woke up! Disable sleep speed in the next frame.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(MonoSingleton<GameSpeedManager>.Instance.DisableSpeedSleep);
			}
		}

		private void OnFallASleepEvent(StatsInstance instance)
		{
			if (instance.Owner is HumanoidInstance { WorkerBehaviour: not null, HasDisposed: false } humanoidInstance)
			{
				if (IsEveryoneSleeping())
				{
					Log.Info("All workers are a sleep (or fainted). Increasing maximum game speed", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WorkerManager.cs");
					MonoSingleton<GameSpeedManager>.Instance.EnableSleepSpeed();
				}
				humanoidInstance.LadderFallDown();
			}
		}

		protected override void Awake()
		{
			base.Awake();
			debugEventCooldown = new Cooldown(TutorialManager.IsTutorialActive);
			MonoSingleton<EventScheduler>.Instance.WorkersCountProvider = this;
		}

		private void Start()
		{
			MonoSingleton<WorkerController>.Instance.CreateWorkerEvent += OnCreateWorker;
			MonoSingleton<WorkerController>.Instance.PullOutToolEvent += OnPullOutTool;
			MonoSingleton<WorkerController>.Instance.HideToolEvent += OnHideTool;
			MonoSingleton<WorkerController>.Instance.FoodStorageChangedEvent += OnFoodStorageChange;
			MonoSingleton<WorkerController>.Instance.MedicineStorageChangedEvent += OnMedicineStorageChange;
			MonoSingleton<WorkerController>.Instance.FaceObjectEvent += OnFaceObject;
			MonoSingleton<WorkerController>.Instance.FaceObjectTransformEvent += OnFaceTransform;
			MonoSingleton<WorkerController>.Instance.LookAtTransformEvent += OnLookAt;
			MonoSingleton<WorkerController>.Instance.SetEulerAngleEvent += OnSetEulerAngle;
			MonoSingleton<AnimationController>.Instance.TriggerAnimationEvent += OnTriggerAnimation;
			MonoSingleton<AnimationController>.Instance.ResetTriggersAnimationEvent += OnTriggersReset;
			MonoSingleton<AnimationController>.Instance.ForeQuitAnimationEvent += OnTriggerAnimation;
			MonoSingleton<LifeController>.Instance.OnFaintEvent += OnFaintEvent;
			MonoSingleton<LifeController>.Instance.WakeUpEvent += OnWakeUpEvent;
			MonoSingleton<LifeController>.Instance.FallAsleepEvent += OnFallASleepEvent;
			MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent += OnRaidWon;
			MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent += OnRaidLost;
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
			MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChangedEvent += OnSingleOwnerRoomsChanged;
			MonoSingleton<RoomDetectionController>.Instance.RoomImpressivenessChangedEvent += OnRoomImpressivenessChanged;
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeRecalculatedEvent += OnRoomTypeRecalculated;
			MonoSingleton<BaseWealth>.Instance.WealthChangedEvent += OnWealthChanged;
			MonoSingleton<CombatController>.Instance.DealGateDamageEvent += OnDealGateDamage;
			MonoSingleton<CombatController>.Instance.DealDrawbridgeDamageEvent += OnDealDrawbridgeDamage;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
			MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
		}

		private void OnLoadingComplete()
		{
			RefreshWorkerRoomJealousEffectors();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
		}

		private void OnRoomRemoved(Room room)
		{
			CheckWorkersRoomChange(room);
			RefreshWorkerRoomJealousEffectors();
		}

		private void OnRoomAdded(Room room, RoomType previousType)
		{
			CheckWorkersRoomChange(room);
			RefreshWorkerRoomJealousEffectors();
		}

		private void CheckWorkersRoomChange(Room room)
		{
			foreach (HumanoidInstance key in AllWorkers.Keys)
			{
				if (!CombatUtils.IsNullOrDisposed(key))
				{
					Region region = key.GetNode().Region;
					if (room.Regions.Contains(region))
					{
						key.ForceCheckRoomChange();
					}
				}
			}
		}

		private void OnRaidWon()
		{
			AnimateAllWorkers("IdleHappy", 3f, (HumanoidInstance item) => !item.HasFainted);
			Worker baseWorker = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker;
			if (!string.IsNullOrEmpty(baseWorker.DefaultHumanType.RaidWonEffector))
			{
				RunEffectorOnAllWorkersOneTime(baseWorker.DefaultHumanType.RaidWonEffector);
			}
		}

		private void OnRaidLost()
		{
			Worker baseWorker = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker;
			if (!string.IsNullOrEmpty(baseWorker.DefaultHumanType.RaidLostEffector))
			{
				RunEffectorOnAllWorkersOneTime(baseWorker.DefaultHumanType.RaidLostEffector);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.CreateWorkerEvent -= OnCreateWorker;
				MonoSingleton<WorkerController>.Instance.PullOutToolEvent -= OnPullOutTool;
				MonoSingleton<WorkerController>.Instance.HideToolEvent -= OnHideTool;
				MonoSingleton<WorkerController>.Instance.FoodStorageChangedEvent -= OnFoodStorageChange;
				MonoSingleton<WorkerController>.Instance.MedicineStorageChangedEvent -= OnMedicineStorageChange;
				MonoSingleton<WorkerController>.Instance.FaceObjectEvent -= OnFaceObject;
				MonoSingleton<WorkerController>.Instance.FaceObjectTransformEvent -= OnFaceTransform;
				MonoSingleton<WorkerController>.Instance.LookAtTransformEvent -= OnLookAt;
				MonoSingleton<WorkerController>.Instance.SetEulerAngleEvent -= OnSetEulerAngle;
			}
			if (MonoSingleton<AnimationController>.IsInstantiated())
			{
				MonoSingleton<AnimationController>.Instance.TriggerAnimationEvent -= OnTriggerAnimation;
				MonoSingleton<AnimationController>.Instance.ResetTriggersAnimationEvent -= OnTriggersReset;
				MonoSingleton<AnimationController>.Instance.ForeQuitAnimationEvent -= OnTriggerAnimation;
			}
			if (MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.OnFaintEvent -= OnFaintEvent;
				MonoSingleton<LifeController>.Instance.WakeUpEvent -= OnWakeUpEvent;
				MonoSingleton<LifeController>.Instance.FallAsleepEvent -= OnFallASleepEvent;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent -= OnRaidWon;
				MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent -= OnRaidLost;
			}
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
				MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChangedEvent -= OnSingleOwnerRoomsChanged;
				MonoSingleton<RoomDetectionController>.Instance.RoomImpressivenessChangedEvent -= OnRoomImpressivenessChanged;
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeRecalculatedEvent -= OnRoomTypeRecalculated;
			}
			if (MonoSingleton<BaseWealth>.IsInstantiated())
			{
				MonoSingleton<BaseWealth>.Instance.WealthChangedEvent -= OnWealthChanged;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DealGateDamageEvent += OnDealGateDamage;
				MonoSingleton<CombatController>.Instance.DealDrawbridgeDamageEvent += OnDealDrawbridgeDamage;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			foreach (WorkerView value in AllWorkers.Values)
			{
				value.Dispose(disposeInstance: false);
			}
			instanceViewDictionary.Clear();
			faintedWorkers.Clear();
			base.OnDestroy();
		}

		private void OnLateTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("WorkerManager.LateTick"))
			{
				if (debugEventCooldown.HasEnded && DebugEventLog.IsInitialized)
				{
					debugEventCooldown = Cooldown.FromNowMinutes(1, TutorialManager.IsTutorialActive);
					LogDebugEvents();
				}
			}
		}

		private void LogDebugEvents()
		{
			if (!DebugEventLog.IsInitialized)
			{
				return;
			}
			foreach (HumanoidInstance key in AllWorkers.Keys)
			{
				DebugEventLog.SampleCreatureState(key);
			}
		}

		public void DestroyView(HumanoidInstance humanoidInstance)
		{
			GetView(humanoidInstance).Dispose(disposeInstance: false);
			instanceViewDictionary.Remove(humanoidInstance);
		}

		private void OnSingleOwnerRoomsChanged()
		{
			RefreshWorkerRoomJealousEffectors();
		}

		private void OnRoomImpressivenessChanged(Room room, RoomImpressivenessSettings.Setting prevImpressiveness)
		{
			RefreshWorkerRoomJealousEffectors();
		}

		private void OnRoomTypeRecalculated(Room room, bool wasTypeChanged)
		{
			foreach (HumanoidInstance key in AllWorkers.Keys)
			{
				if (key.Room == room)
				{
					if (wasTypeChanged)
					{
						key.WorkerBehaviour.OnRoomTypeChanged();
					}
					else
					{
						key.WorkerBehaviour.OnRoomTypeRefreshed();
					}
				}
			}
		}

		private void OnWealthChanged(float wealth)
		{
			if (!MonoSingleton<BaseWealth>.IsInstantiated())
			{
				return;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			float wealth2 = wealth / Mathf.Max(1f, AllWorkers.Keys.Count);
			BaseWealthEffectors.Setting workerWealthEffectors = MonoSingleton<BaseWealth>.Instance.GetWorkerWealthEffectors(wealth2);
			foreach (BaseWealthEffectors.Setting setting in MonoSingleton<BaseWealth>.Instance.BaseWealthEffectors.Settings)
			{
				bool flag = setting == workerWealthEffectors;
				foreach (string effector in setting.Effectors)
				{
					if ((!flag || !map.GlobalEffectorsManager.IsGlobalEffectorRunning(effector, GlobalEffectorDomain.Worker)) && (flag || map.GlobalEffectorsManager.IsGlobalEffectorRunning(effector, GlobalEffectorDomain.Worker)))
					{
						map.GlobalEffectorsManager.RunEffectorOnDomain(effector, flag, GlobalEffectorDomain.Worker);
					}
				}
			}
		}

		private void RefreshWorkerRoomJealousEffectors()
		{
			if (VillageManager.ActiveVillage?.Map?.RoomDetection == null || !LoadingController.IsLoadingComplete)
			{
				return;
			}
			NSMedieval.RoomDetection.RoomDetection roomDetection = VillageManager.ActiveVillage.Map.RoomDetection;
			Room mostImpressiveSingleOwnerRoom = roomDetection.GetMostImpressiveSingleOwnerRoom(Repository<RoomTypeRepository, RoomType>.Instance.SingleBedroomType);
			RoomType singleBedroomType = Repository<RoomTypeRepository, RoomType>.Instance.SingleBedroomType;
			RoomType sharedBedroomType = Repository<RoomTypeRepository, RoomType>.Instance.SharedBedroomType;
			Room room = null;
			Room room2 = null;
			foreach (Room item in roomDetection.IterateRoomsSafe())
			{
				if (room == null && item.RoomType == singleBedroomType)
				{
					room = item;
				}
				if (room2 == null && item.RoomType == sharedBedroomType)
				{
					room2 = item;
				}
			}
			foreach (HumanoidInstance key in AllWorkers.Keys)
			{
				if (key.IsInIncognitoMode() || key.HasDied || key.HasDisposed)
				{
					continue;
				}
				Room singleOwnerRoom = roomDetection.GetSingleOwnerRoom(key, singleBedroomType);
				if (singleOwnerRoom != null && singleOwnerRoom.ImpressivenessScore >= roomDetection.RoomImpressivenessSettings.ImpressiveSetting.MinValue)
				{
					if (!key.Stats.IsEffectorActive("RoomTooImpressive"))
					{
						key.Stats.StartEffector("RoomTooImpressive");
					}
				}
				else if (key.Stats.IsEffectorActive("RoomTooImpressive"))
				{
					key.Stats.EndEffector("RoomTooImpressive");
				}
				if (mostImpressiveSingleOwnerRoom != null && (singleOwnerRoom == null || singleOwnerRoom.Impressiveness != mostImpressiveSingleOwnerRoom.Impressiveness))
				{
					if (!key.Stats.IsEffectorActive("JealousBedroom"))
					{
						key.Stats.StartEffector("JealousBedroom");
						HumanoidInstance singleOwner = mostImpressiveSingleOwnerRoom.GetSingleOwner();
						if (singleOwner != null)
						{
							key.WorkerBehaviour.JealousOfWorkersBedroom = singleOwner.Info?.GetFullName();
						}
					}
				}
				else if (key.Stats.IsEffectorActive("JealousBedroom"))
				{
					key.Stats.EndEffector("JealousBedroom");
					key.WorkerBehaviour.JealousOfWorkersBedroom = null;
				}
				if (singleOwnerRoom == null && room != null && room2 != null)
				{
					if (!key.Stats.IsEffectorActive("WantsOwnRoom"))
					{
						key.Stats.StartEffector("WantsOwnRoom");
					}
				}
				else if (key.Stats.IsEffectorActive("WantsOwnRoom"))
				{
					key.Stats.EndEffector("WantsOwnRoom");
				}
			}
		}

		private void OnDealGateDamage(DoorComponentInstance doorComponentInstance)
		{
			if (doorComponentInstance == null || doorComponentInstance.HasDisposed || doorComponentInstance.OwnerBuilding == null || doorComponentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			int y = doorComponentInstance.OwnerBuilding.GridDataPosition.y;
			using PooledHashSet<Vec3Int> pooledHashSet = HashSetPool<Vec3Int>.GetJanitor();
			foreach (Vec3Int position in doorComponentInstance.OwnerBuilding.Positions)
			{
				if (position.y == y)
				{
					pooledHashSet.Add(position);
				}
			}
			using PooledList<HumanoidInstance> pooledList = AllWorkers.Keys.ToPooledListJanitor();
			foreach (HumanoidInstance item in pooledList)
			{
				Vec3Int gridPosition = item.GetGridPosition();
				if (pooledHashSet.Contains(gridPosition))
				{
					CombatHitManager.DealGateDamage(item, doorComponentInstance);
				}
			}
		}

		private void OnDealDrawbridgeDamage(DrawbridgeComponent drawbridgeComponent)
		{
			if (drawbridgeComponent == null)
			{
				return;
			}
			DoorComponentInstance componentInstance = drawbridgeComponent.DoorComponent.ComponentInstance;
			if (componentInstance == null || componentInstance.HasDisposed || componentInstance.OwnerBuilding == null || componentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor(AllWorkers.Keys);
			for (int num = pooledList.Count - 1; num >= 0; num--)
			{
				Vec3Int gridPosition = pooledList[num].GetGridPosition();
				if (drawbridgeComponent.DrawbridgePositions.Contains(gridPosition))
				{
					CombatHitManager.DealGateDamage(pooledList[num], componentInstance);
				}
			}
		}
	}
}
