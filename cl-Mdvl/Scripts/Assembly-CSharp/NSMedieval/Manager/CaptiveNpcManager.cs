using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UI.View;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CaptiveNpcManager : MonoSingleton<CaptiveNpcManager>
	{
		[NonSerialized]
		private CaptureHumanoidsView captureHumanoidsView;

		[NonSerialized]
		private InterpolatedValueList maxCaptivesBySettlersAlive;

		[NonSerialized]
		private InterpolatedValueList surrenderChanceBySettlersAlive;

		[NonSerialized]
		private InterpolatedValueList surrenderChanceByCaptivesCount;

		[NonSerialized]
		private InterpolatedValueList releaseFriendlinessBuffByMood;

		[NonSerialized]
		private readonly HashSet<CaptiveNpcBehaviour> captives = new HashSet<CaptiveNpcBehaviour>();

		[NonSerialized]
		private readonly HashSet<CaptiveNpcBehaviour> playersCaptives = new HashSet<CaptiveNpcBehaviour>();

		[NonSerialized]
		private readonly HashSet<HumanoidInstance> captivesHumanoids = new HashSet<HumanoidInstance>();

		[NonSerialized]
		private InterpolatedValueList maxCaptivesToSellByPlayerCaptivesCount;

		[NonSerialized]
		private InterpolatedValueList maxCaptivesToSellByPlayerWorkersCount;

		public CaptureHumanoidsView CaptureHumanoidsView
		{
			get
			{
				if (captureHumanoidsView == null)
				{
					captureHumanoidsView = UnityEngine.Object.FindObjectOfType<CaptureHumanoidsView>(includeInactive: true);
				}
				return captureHumanoidsView;
			}
		}

		public HashSet<HumanoidInstance> CaptivesHumanoids => captivesHumanoids;

		public HashSet<CaptiveNpcBehaviour> Captives => captives;

		public HashSet<CaptiveNpcBehaviour> PlayersCaptives => playersCaptives;

		public int CaptivesCount => captives.Count;

		public InterpolatedValueList MaxCaptivesToSellByPlayerCaptivesCount => maxCaptivesToSellByPlayerCaptivesCount;

		public InterpolatedValueList MaxCaptivesToSellByPlayerWorkersCount => maxCaptivesToSellByPlayerWorkersCount;

		private void Start()
		{
			maxCaptivesBySettlersAlive = Repository<RaidMaxPrisonersBySettlersAliveData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			surrenderChanceBySettlersAlive = Repository<RaidSurrenderChanceBySettlersAliveData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			releaseFriendlinessBuffByMood = Repository<ReleasePrisonersFriendlinessBuffByMoodData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			surrenderChanceByCaptivesCount = Repository<RaidSurrenderChanceByPrisonersCountData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			maxCaptivesToSellByPlayerCaptivesCount = Repository<MerchantLimitPrisonersByPrisonerCountData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			maxCaptivesToSellByPlayerWorkersCount = Repository<MerchantLimitPrisonersByWorkerCountData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			MonoSingleton<HumanoidController>.Instance.OnActivateBehaviourEvent += OnActivateBehaviour;
			MonoSingleton<HumanoidController>.Instance.OnDeactivateBehaviourEvent += OnDeactivateBehaviour;
			MonoSingleton<NPCController>.Instance.OnOwnerSetEvent += OnOwnerSet;
			CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
			caravanController.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(caravanController.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
			CaravanController caravanController2 = MonoSingleton<CaravanController>.Instance;
			caravanController2.CaravanFormingCanceledEvent = (CaravanController.CaravanDelegate)Delegate.Combine(caravanController2.CaravanFormingCanceledEvent, new CaravanController.CaravanDelegate(OnCaravanFormingCanceled));
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<HumanoidController>.IsInstantiated())
			{
				MonoSingleton<HumanoidController>.Instance.OnActivateBehaviourEvent -= OnActivateBehaviour;
				MonoSingleton<HumanoidController>.Instance.OnDeactivateBehaviourEvent -= OnDeactivateBehaviour;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnOwnerSetEvent -= OnOwnerSet;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController caravanController = MonoSingleton<CaravanController>.Instance;
				caravanController.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(caravanController.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
				CaravanController caravanController2 = MonoSingleton<CaravanController>.Instance;
				caravanController2.CaravanFormingCanceledEvent = (CaravanController.CaravanDelegate)Delegate.Remove(caravanController2.CaravanFormingCanceledEvent, new CaravanController.CaravanDelegate(OnCaravanFormingCanceled));
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			}
		}

		public void FireEffectorForAllPrisoners(string effectorId)
		{
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsCaptive()))
			{
				item.Stats.StartEffector(effectorId);
			}
		}

		public void SetAsPrisoners(IReadOnlyCollection<HumanoidInstance> humanoidInstances)
		{
			if (humanoidInstances.Count == 0)
			{
				MonoSingleton<NPCController>.Instance.CapturedPrisoners(humanoidInstances);
				return;
			}
			int num = 0;
			foreach (HumanoidInstance humanoidInstance in humanoidInstances)
			{
				if (!humanoidInstance.HasDied && !humanoidInstance.HasDisposed)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(humanoidInstance);
						messageBuilder.AppendLiteral(" is now a Prisoner.");
					}
					Log.Info(messageBuilder);
					humanoidInstance.SetActiveBehaviour<PrisonerBehaviour>();
					num++;
				}
			}
			MonoSingleton<AchievementManager>.Instance.IncreaseStat("TAKE_PRISONER_CNT", num);
			RefreshMaxPlayerFriendliness();
			MonoSingleton<NPCController>.Instance.CapturedPrisoners(humanoidInstances);
		}

		public bool HasCaptivesWithRecruitOrder()
		{
			return Captives.Any((CaptiveNpcBehaviour cap) => cap.MarkedForRecruiting && !cap.IsCaptiveLabourer && cap.IsInPrisonCell);
		}

		public bool HasCaptivesWithShackleOrder()
		{
			return Captives.Any((CaptiveNpcBehaviour cap) => cap.MarkedForShackling || cap.MarkedForUnShackling);
		}

		private void RefreshMaxPlayerFriendliness()
		{
			using PooledHashSet<FactionInstance> pooledHashSet = HashSetPool<FactionInstance>.GetJanitor();
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (item.IsCaptive())
				{
					pooledHashSet.Add(item.Faction);
				}
			}
			foreach (FactionInstance factionInstance in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances)
			{
				factionInstance.SetHasPrisoners(pooledHashSet.Contains(factionInstance));
			}
		}

		private bool CanSurrender(HumanoidInstance humanoid, IEnumerable<HumanoidInstance> lockedEnemies)
		{
			if (TutorialManager.IsTutorialActive)
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return false;
			}
			if (humanoid.HasDisposed || humanoid.HasFainted)
			{
				return false;
			}
			if (!(humanoid.ActiveBehaviour is EnemyBehaviour))
			{
				return false;
			}
			if (humanoid.Faction != null && humanoid.Faction.Blueprint != null && humanoid.Faction.Blueprint.RaidWillNotSurrender)
			{
				return false;
			}
			if (lockedEnemies.Contains(humanoid))
			{
				return true;
			}
			Vec3Int gridPosition = humanoid.GetGridPosition();
			if (GridDataIndexTools.IsForbiddenEdge(gridPosition.x, gridPosition.z))
			{
				return false;
			}
			if (humanoid.Stats.GetStat(StatType.Health).GetNormalizedPercentage() > 0.8f)
			{
				return false;
			}
			return true;
		}

		public float GetFriendlinessBonusForRelease(CaptiveNpcBehaviour releasedCaptive)
		{
			if (releasedCaptive.Humanoid.Faction == null)
			{
				return 0f;
			}
			int keyValue = Mathf.CeilToInt(releasedCaptive.Humanoid.Stats.GetStat(StatType.Mood).Current);
			float num = 5f * releaseFriendlinessBuffByMood.GetMultiplierInterpolated(keyValue);
			if (releasedCaptive.Humanoid.Faction.IsPermanentlyHostile())
			{
				num = 0f;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Friendliness bonus for releasing prisoner: ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Info(messageBuilder);
			return num;
		}

		public void TryShowSelectPrisonersDialog(ActiveRaidInfo cachedRaidInfo)
		{
			if (!cachedRaidInfo.Won)
			{
				return;
			}
			int workersCount = MonoSingleton<WorkerManager>.Instance.GetWorkersCount();
			int num = MonoSingleton<NPCManager>.Instance.CountNPCs((HumanoidInstance npc) => npc.IsCaptive());
			System.Random random = new System.Random(cachedRaidInfo.RaidId);
			int num2 = Mathf.RoundToInt(maxCaptivesBySettlersAlive.GetMultiplierInterpolated(workersCount));
			float multiplierInterpolated = surrenderChanceBySettlersAlive.GetMultiplierInterpolated(workersCount);
			float multiplierInterpolated2 = surrenderChanceByCaptivesCount.GetMultiplierInterpolated(num);
			float num3 = multiplierInterpolated * multiplierInterpolated2;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Max surrender count by settlers alive (");
				messageBuilder.AppendFormatted(workersCount);
				messageBuilder.AppendLiteral(") = ");
				messageBuilder.AppendFormatted(num2);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Chance of surrendering by settlers alive (");
				messageBuilder.AppendFormatted(workersCount);
				messageBuilder.AppendLiteral(") = ");
				messageBuilder.AppendFormatted(multiplierInterpolated);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(47, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Chance of surrendering by prisoners count (");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(") = ");
				messageBuilder.AppendFormatted(multiplierInterpolated2);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CaptiveNpcManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Chance of surrendering for each enemy is ");
				messageBuilder.AppendFormatted(num3);
			}
			Log.Info(messageBuilder);
			using PooledList<HumanoidInstance> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled((HumanoidInstance npc) => !npc.HasDisposed && !npc.HasFainted && npc.IsRaiderOfRaid(cachedRaidInfo.RaidId) && npc.ActiveBehaviour is EnemyBehaviour);
			pooledList.ShuffleInPlace(random);
			using PooledList<HumanoidInstance> pooledList2 = ListPool<HumanoidInstance>.GetJanitor();
			GetLockedEnemies(pooledList, pooledList2);
			using PooledList<HumanoidInstance> pooledList3 = ListPool<HumanoidInstance>.GetJanitor();
			using PooledList<HumanoidInstance> pooledList4 = ListPool<HumanoidInstance>.GetJanitor();
			foreach (HumanoidInstance item in pooledList)
			{
				bool flag = num3 > 0f && pooledList3.Count < num2 && CanSurrender(item, pooledList2);
				if (flag && random.NextDouble() > (double)num3)
				{
					flag = false;
				}
				if (flag)
				{
					pooledList3.Add(item);
				}
				else
				{
					pooledList4.Add(item);
				}
			}
			if (pooledList3.Any())
			{
				CaptureHumanoidsView.OpenPanel(pooledList3, pooledList4);
			}
			else if (pooledList.Count > 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("bbt_no_one_surrender"));
			}
		}

		private static void GetLockedEnemies(IEnumerable<HumanoidInstance> humanoids, IList<HumanoidInstance> locked)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (HumanoidInstance humanoid in humanoids)
			{
				bool flag = false;
				foreach (Region region in map.RegionManager.Regions)
				{
					if (region.HasMapEdgeNodes && region.Nodes.First() != null && PathfinderUtil.IsPathPossible(humanoid, region.Nodes.First()))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					locked.Add(humanoid);
				}
			}
		}

		private void OnActivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			if (humanoidBehaviour is CaptiveNpcBehaviour captiveNpcBehaviour)
			{
				captives.Add(captiveNpcBehaviour);
				captivesHumanoids.Add(captiveNpcBehaviour.Humanoid);
				if (captiveNpcBehaviour.Owner == null)
				{
					playersCaptives.Add(captiveNpcBehaviour);
				}
				else
				{
					playersCaptives.Remove(captiveNpcBehaviour);
				}
			}
		}

		private void OnDeactivateBehaviour(HumanoidBehaviour humanoidBehaviour)
		{
			if (humanoidBehaviour is CaptiveNpcBehaviour captiveNpcBehaviour)
			{
				captives.Remove(captiveNpcBehaviour);
				captivesHumanoids.Remove(captiveNpcBehaviour.Humanoid);
			}
		}

		private void OnOwnerSet(CaptiveNpcBehaviour captiveNpcBehaviour)
		{
			if (captiveNpcBehaviour.Owner == null)
			{
				playersCaptives.Add(captiveNpcBehaviour);
			}
			else
			{
				playersCaptives.Remove(captiveNpcBehaviour);
			}
		}

		private void OnCaravanFormingCanceled(CaravanInstance caravanInstance)
		{
			UnRopeCaravanPrisoners(caravanInstance);
		}

		private void OnCaravanReturnedHome(CaravanInstance caravanInstance)
		{
			UnRopeCaravanPrisoners(caravanInstance);
		}

		private void UnRopeCaravanPrisoners(CaravanInstance caravanInstance)
		{
			if (caravanInstance?.Creatures == null)
			{
				return;
			}
			foreach (CreatureBase creature in caravanInstance.Creatures)
			{
				if (creature is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive())
				{
					humanoidInstance.RopeTo(null);
				}
			}
		}

		private void OnGameLoaded(bool afterLoading)
		{
			foreach (HumanoidInstance captivesHumanoid in captivesHumanoids)
			{
				if (captivesHumanoid.HasFainted)
				{
					captivesHumanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand, forbidDroppedItem: true);
					captivesHumanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.RightHand, forbidDroppedItem: true);
					captivesHumanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.Head, forbidDroppedItem: true);
					captivesHumanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.BodyArmor, forbidDroppedItem: true);
				}
			}
		}
	}
}
