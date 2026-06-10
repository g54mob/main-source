using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Dialogs;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Raid.Config;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class RaidManager : IDisposable
	{
		public readonly RaidPointOfInterestManager PointOfInterestManager;

		private readonly Timer raidCheckTickTimer;

		private readonly VillageMap Map;

		public bool IsMeleeDamageTaken { get; set; }

		public RaidManager(VillageMap map)
		{
			Map = map;
			PointOfInterestManager = new RaidPointOfInterestManager();
			raidCheckTickTimer = new Timer(1f, restartOnEnd: true);
			raidCheckTickTimer.AddCallback(RaidCheckTick);
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidStarted;
			MonoSingleton<RaidController>.Instance.RaidAttackEngageEvent += OnRaidAttackEngageEvent;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnNpcRemoved;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<CombatController>.Instance.HitBlockedEvent += OnHitBlocked;
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += OnAgentDied;
			MonoSingleton<CombatController>.Instance.DealDamageEvent += OnDealDamageEvent;
			MonoSingleton<ConstructionController>.Instance.DoorLockOrderChangedEvent += OnDoorLockStateChanged;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerDied;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFriendlinessChanged;
			UpdateBattleScalesUI();
		}

		public void InitAfterLoad()
		{
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.InitAfterLoad();
				raid.OnBattleScalesChanged += UpdateBattleScalesUI;
			}
			UpdateBattleScalesUI();
		}

		public void Dispose()
		{
			raidCheckTickTimer.Dispose();
			PointOfInterestManager.Dispose();
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.Dispose();
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStarted;
				MonoSingleton<RaidController>.Instance.RaidAttackEngageEvent -= OnRaidAttackEngageEvent;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnNpcRemoved;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
				MonoSingleton<CombatController>.Instance.AgentDiedEvent -= OnAgentDied;
				MonoSingleton<CombatController>.Instance.HitBlockedEvent -= OnHitBlocked;
				MonoSingleton<CombatController>.Instance.DealDamageEvent -= OnDealDamageEvent;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChangedEvent -= OnDoorLockStateChanged;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnWorkerDied;
			}
		}

		public ActiveRaidInfo StartRaid(NSMedieval.Model.Raid raid, VillagePlace originVillage, FactionInstance factionInstance, string parentEventId, List<int?> enemyRandomSeeds = null, List<MapNode> overrideSpawnPositions = null, GameEventInstance fromEvent = null, ActiveRaidInfo.CreateRaidEndConditionsDelegate createPlayerEndConditions = null, ActiveRaidInfo.CreateRaidEndConditionsDelegate createEnemyEndConditions = null)
		{
			if (raid == null)
			{
				Log.Error("StartRaid: raid is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			}
			if (raid?.Enemies == null)
			{
				Log.Error("StartRaid: raid?.Enemies is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			}
			if (GlobalSaveController.CurrentVillageData?.LastRaidInfo == null)
			{
				Log.Error("StartRaid: CurrentVillageData?.LastRaidInfo is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			}
			if (raid != null && raid.Enemies.Any((NSMedieval.Model.Raid.RaidEnemyInfo enemy) => enemy == null))
			{
				Log.Error("StartRaid: some of raid.Enemies is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			}
			if (raid != null && enemyRandomSeeds != null && enemyRandomSeeds.Count != raid.Enemies.Length)
			{
				throw new Exception($"Enemy random seeds provided, but length does not match length of enemies (enemies.length={raid.Enemies.Length}, seeds.length={enemyRandomSeeds.Count}");
			}
			GlobalSaveController.CurrentVillageData.LastRaidInfo.Reset();
			GlobalSaveController.CurrentVillageData.LastRaidInfo.NoMeleeDamageInRow++;
			GlobalSaveController.CurrentVillageData.LastRaidInfo.HasDoor = CheckHasDoor();
			long currentTimeTutorialAware = GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware;
			List<HumanoidInstance> list = new List<HumanoidInstance>();
			for (int num = 0; num < raid.Enemies.Length; num++)
			{
				NSMedieval.Model.Raid.RaidEnemyInfo raidEnemyInfo = raid.Enemies[num];
				BodyType bodyType = factionInstance?.GetRandomBodyType() ?? BodyType.Male;
				int? randomSeed = enemyRandomSeeds?[num];
				HumanoidInstance instance = MonoSingleton<NPCManager>.Instance.SpawnEnemy(raidEnemyInfo.Name, bodyType, Vector3.zero, originVillage, factionInstance, raid.RaidID, randomSeed, fromEvent);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					instance.GetGoapAgent()?.StartTicker();
				});
				list.Add(instance);
			}
			if (list.Any((HumanoidInstance enemy) => enemy == null))
			{
				Log.Error("StartRaid: some of enemies is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			}
			WalkableModel testAgentWalkableDoorsNoWater = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoorsNoWater();
			int num2 = list.Count((HumanoidInstance enemy) => CombatUtils.GetAttackType(enemy) != AttackType.Melee);
			int num3 = list.Count - num2;
			int num4 = Math.Min(num3, 30);
			int num5 = Math.Min(num2, 30);
			int count = list.Count;
			int positionsToGet = list.Count + num4 + num5 + count;
			bool flag = false;
			List<MapNode> outStartingNodes;
			if (overrideSpawnPositions != null)
			{
				outStartingNodes = overrideSpawnPositions;
				flag = true;
			}
			else
			{
				Log.Info("Getting spawn points for plain raid", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
				if (!MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(testAgentWalkableDoorsNoWater, out var outTargetNode, out outStartingNodes, positionsToGet))
				{
					Log.Info("Failed to find spawn points reachable from targets, getting spawn points for siege", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
					MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(testAgentWalkableDoorsNoWater, out outTargetNode, out outStartingNodes, positionsToGet, int.MaxValue, onlyTargetReachable: false);
				}
			}
			if (!flag)
			{
				if (outStartingNodes != null && outStartingNodes.Count > 0)
				{
					bool flag2;
					int frontLineCount;
					int frontEmptySpaceCount;
					int backLineCount;
					int backEmptySpaceCount;
					if (UnityEngine.Random.value > 0.5f)
					{
						flag2 = false;
						frontLineCount = num2;
						frontEmptySpaceCount = num5;
						backLineCount = num3;
						backEmptySpaceCount = num4;
					}
					else
					{
						flag2 = true;
						frontLineCount = num3;
						frontEmptySpaceCount = num4;
						backLineCount = num2;
						backEmptySpaceCount = num5;
					}
					using PooledList<MapNode> pooledList = ListPool<MapNode>.GetJanitor();
					using PooledList<MapNode> pooledList2 = ListPool<MapNode>.GetJanitor();
					DistributeSpawnPoints(outStartingNodes, frontLineCount, backLineCount, frontEmptySpaceCount, backEmptySpaceCount, pooledList, pooledList2, out var armyFaceDirection);
					Quaternion quaternion = Quaternion.LookRotation(armyFaceDirection);
					foreach (HumanoidInstance item in list)
					{
						MapNode mapNode = ((CombatUtils.GetAttackType(item) != AttackType.Melee) ? (flag2 ? pooledList2.TakeFirst() : pooledList.TakeFirst()) : (flag2 ? pooledList.TakeFirst() : pooledList2.TakeFirst()));
						if (mapNode == null)
						{
							Log.Error("StartRaid: MapNode node is NULL (enemy), seems we ran out of spawn points for this attack type? Will assign the first enemy's spawn point to this guy as well", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
							mapNode = list[0].GetNode();
						}
						item.UpdatePosition(mapNode.WorldPosition);
						Quaternion rotation = quaternion * Quaternion.Euler(0f, UnityEngine.Random.Range(-15f, 15f), 0f);
						item.UpdateRotation(rotation);
					}
				}
			}
			else
			{
				foreach (HumanoidInstance item2 in list)
				{
					MapNode mapNode2 = outStartingNodes.TakeFirst();
					if (mapNode2 == null)
					{
						Log.Error("StartRaid: MapNode node is NULL (enemy), seems we ran out of spawn points for this attack type? Will assign the first enemy's spawn point to this guy as well", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
						mapNode2 = list[0].GetNode();
					}
					item2.UpdatePosition(mapNode2.WorldPosition);
				}
			}
			List<HumanoidInstance> playerUnits = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Where((HumanoidInstance item) => item != null && !item.HasFainted).ToList();
			int victoriesInRow = GlobalSaveController.CurrentVillageData.LastRaidInfo.VictoriesInRow;
			int everyVictoriesInRowCount = SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.HarderSiegePathfinderSettings.EveryVictoriesInRowCount;
			SiegePathfinderPenaltyModifiers siegePathfinderModifiers = ((victoriesInRow <= 0 || victoriesInRow % everyVictoriesInRowCount != 0) ? SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.StandardSiegePathfinderSettings : SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.HarderSiegePathfinderSettings);
			uint commanderAgentId = Map.CommanderAIManager.CreateCommander(list, raid.SiegeWeapons, siegePathfinderModifiers);
			ActiveRaidInfo activeRaidInfo = new ActiveRaidInfo(Map, raid, parentEventId, raid.RaidID, list, playerUnits, currentTimeTutorialAware, raid.IsSiege, commanderAgentId, createPlayerEndConditions, createEnemyEndConditions);
			activeRaidInfo.RaidEngageDelay = Cooldown.FromNowMinutes((int)activeRaidInfo.Blueprint.DelayBeforeAttack, TutorialManager.IsTutorialActive);
			GlobalSaveController.CurrentVillageData.Raids.Add(activeRaidInfo);
			GlobalSaveController.CurrentVillageData.LastRaidInfo.FirstRaid = false;
			GlobalSaveController.CurrentVillageData.LastRaidInfo.HasHeavyUnit = HasHeavyUnit();
			MonoSingleton<RaidController>.Instance.OnRaidSpawned(activeRaidInfo, list);
			activeRaidInfo.OnBattleScalesChanged += UpdateBattleScalesUI;
			UpdateBattleScalesUI();
			return activeRaidInfo;
		}

		public bool RaidInProgress()
		{
			return GlobalSaveController.CurrentVillageData.Raids.Count > 0;
		}

		public static void DistributeSpawnPoints(List<MapNode> allNodes, int frontLineCount, int backLineCount, int frontEmptySpaceCount, int backEmptySpaceCount, PooledList<MapNode> outFrontLineSpawnPoints, PooledList<MapNode> outBackLineSpawnPoints, out Vector3 armyFaceDirection)
		{
			if (allNodes.Count == 0)
			{
				Log.Error("AllNodes.Count == 0, failed to distribute spawn points", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
				armyFaceDirection = default(Vector3);
				return;
			}
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(64, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Distributing spawn points (allNodes.Count = ");
				messageBuilder.AppendFormatted(allNodes.Count);
				messageBuilder.AppendLiteral(", first node is at ");
				messageBuilder.AppendFormatted(allNodes[0].Position);
				messageBuilder.AppendLiteral(")");
			}
			Log.Info(messageBuilder);
			Vector3 vector = MonoSingleton<World>.Instance.Center.ToVector3World();
			Vector3 vector2 = allNodes.Average((MapNode node) => node.WorldPosition);
			Vector3 vector3 = vector - vector2;
			if (Math.Abs(vector3.x) > Math.Abs(vector3.z))
			{
				armyFaceDirection = new Vector3(vector3.x, 0f, 0f);
			}
			else
			{
				armyFaceDirection = new Vector3(0f, 0f, vector3.z);
			}
			int num = frontLineCount + backLineCount + frontEmptySpaceCount + backEmptySpaceCount;
			bool flag = allNodes.Count >= num;
			if (!flag)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(132, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("There aren't enough spawn points for everyone, some enemies will share a single spawn point (allNodes.Count = ");
					messageBuilder.AppendFormatted(allNodes.Count);
					messageBuilder.AppendLiteral(", neededPointCount = ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(")");
				}
				Log.Info(messageBuilder);
			}
			Vector3 armySortReferencePoint = vector2 + armyFaceDirection * 100f;
			allNodes.Sort(delegate(MapNode node1, MapNode node2)
			{
				float num5 = node1.WorldPosition.DistanceSquared(in armySortReferencePoint);
				float value = node2.WorldPosition.DistanceSquared(in armySortReferencePoint);
				return num5.CompareTo(value);
			});
			int num2 = Math.Min(frontLineCount + frontEmptySpaceCount, allNodes.Count);
			for (int num3 = 0; num3 < frontLineCount; num3++)
			{
				MapNode item = (flag ? allNodes.TakeRandom(0, num2) : allNodes.GetRandom(0, num2));
				outFrontLineSpawnPoints.Add(item);
				num2--;
			}
			int startIndexInclusive = Math.Max(allNodes.Count - backLineCount - backEmptySpaceCount, 0);
			for (int num4 = 0; num4 < backLineCount; num4++)
			{
				MapNode item2 = (flag ? allNodes.TakeRandom(startIndexInclusive, allNodes.Count) : allNodes.GetRandom(startIndexInclusive, allNodes.Count));
				outBackLineSpawnPoints.Add(item2);
			}
		}

		private bool CheckHasDoor()
		{
			foreach (DoorComponentInstance componentInstance in VillageManager.ActiveVillage.Map.DoorComponentManager.ComponentInstances)
			{
				if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.OwnerBuilding != null && componentInstance.Blueprint.CountsAsDoorInRaid)
				{
					return true;
				}
			}
			return false;
		}

		private void UpdateBattleScalesUI()
		{
			List<ActiveRaidInfo> raids = GlobalSaveController.CurrentVillageData.Raids;
			if (raids.Count == 0)
			{
				MonoSingleton<BattleScaleView>.Instance.IsVisible = false;
				return;
			}
			ActiveRaidInfo activeRaidInfo = raids[0];
			if (activeRaidInfo.HasEnded)
			{
				MonoSingleton<BattleScaleView>.Instance.IsVisible = false;
				return;
			}
			MonoSingleton<BattleScaleView>.Instance.IsVisible = true;
			MonoSingleton<BattleScaleView>.Instance.MarkerPosition = activeRaidInfo.BattleScalesBalance;
			MonoSingleton<BattleScaleView>.Instance.SetTooltipLines(activeRaidInfo.BattleScalesTooltipLines);
		}

		private bool HasHeavyUnit()
		{
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC.ActiveBehaviour.NpcBlueprint.Type == NPCType.Heavy)
				{
					return true;
				}
			}
			return false;
		}

		private void OnRaidStarted(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			MonoSingleton<GameSpeedManager>.Instance.SetSpeedNormal();
		}

		private void OnRaidAttackEngageEvent(ActiveRaidInfo info)
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("enemies_have_started_attacking"));
		}

		private void RaidCheckTick()
		{
			if (!MonoSingleton<World>.IsInstantiated() || !MonoSingleton<World>.Instance.IsLoaded)
			{
				return;
			}
			List<ActiveRaidInfo> raids = GlobalSaveController.CurrentVillageData.Raids;
			foreach (ActiveRaidInfo item in raids.IterateInReverseDynamic())
			{
				item.TickEndConditions();
				if (item.HasEnded)
				{
					MonoSingleton<RaidController>.Instance.OnRaidEnded(item);
					switch (item.RaidStatus)
					{
					case RaidStatus.PlayerVictory:
						GlobalSaveController.CurrentVillageData.LastRaidInfo.VictoriesInRow++;
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("raiders_defeated"));
						MonoSingleton<RaidController>.Instance.OnWorkersWonRaid();
						break;
					case RaidStatus.EnemyVictory:
						GlobalSaveController.CurrentVillageData.LastRaidInfo.VictoriesInRow = 0;
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("raiders_won"));
						MonoSingleton<RaidController>.Instance.OnWorkersLostRaid();
						break;
					case RaidStatus.Tie:
						GlobalSaveController.CurrentVillageData.LastRaidInfo.VictoriesInRow = 0;
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("raiders_tied"));
						MonoSingleton<RaidController>.Instance.OnRaidTie();
						break;
					}
					Map.CommanderAIManager.DestroyCommander(item.CommanderAgentId);
					raids.Remove(item);
					bool isVisible = MonoSingleton<BattleScaleView>.Instance.IsVisible;
					UpdateBattleScalesUI();
					if (isVisible)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(MonoSingleton<BattleScaleView>.Instance.gameObject);
						gameObject.gameObject.SetActive(value: true);
						MonoSingleton<DialogViewManager>.Instance.AddTempAdditionalView(gameObject.GetComponent<Canvas>());
					}
				}
			}
		}

		private static void OnDoorLockStateChanged(DoorComponentInstance doorComponentInstance)
		{
			if (doorComponentInstance.HasDisposed || doorComponentInstance.OwnerBuilding == null || doorComponentInstance.LockState != LockState.ForcedOpen || GlobalSaveController.CurrentVillageData?.Raids == null || GlobalSaveController.CurrentVillageData.Raids.Count == 0)
			{
				return;
			}
			if (!GlobalSaveController.CurrentVillageData.LastRaidInfo.IsDoorDestroyed)
			{
				GlobalSaveController.CurrentVillageData.LastRaidInfo.IsDoorDestroyed = true;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Destroyed building ");
				messageBuilder.AppendFormatted(doorComponentInstance.OwnerBuilding.Blueprint.GetID());
			}
			Log.Info(messageBuilder);
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.BuildingsDestroyed.Add(doorComponentInstance.OwnerBuilding.Blueprint.GetID());
			}
		}

		private void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (!(take is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return;
			}
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.AddHitBlocked(humanoidInstance, hitInfo.Damage);
			}
		}

		private void OnWorkerDied(HumanoidInstance humanoid)
		{
			if (humanoid == null || humanoid.IsInIncognitoMode())
			{
				return;
			}
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.WorkersDied.Add(humanoid.Info.GetFullName());
			}
		}

		private void OnNpcRemoved(HumanoidInstance humanoid)
		{
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				if (humanoid.IsRaiderOfRaid(raid.RaidId))
				{
					raid.EnemiesDied.Add(humanoid.Info.GetFullName());
				}
			}
		}

		private void OnAgentDied(IDamageCommonAgent agent)
		{
			if (!(agent is BaseBuildingInstance baseBuildingInstance))
			{
				return;
			}
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Destroyed building ");
				messageBuilder.AppendFormatted(baseBuildingInstance.Blueprint.GetID());
			}
			Log.Info(messageBuilder);
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.BuildingsDestroyed.Add(baseBuildingInstance.Blueprint.GetID());
			}
			if (baseBuildingInstance.BuildingType != BuildingType.ProductionBuilding)
			{
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Destroyed prod building ");
				messageBuilder.AppendFormatted(baseBuildingInstance.Blueprint.GetID());
			}
			Log.Info(messageBuilder);
			foreach (ActiveRaidInfo raid2 in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid2.BuildingsDestroyed.Add(baseBuildingInstance.Blueprint.GetID());
			}
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			LastRaidInfo lastRaidInfo = GlobalSaveController.CurrentVillageData.LastRaidInfo;
			if (deal is HumanoidInstance humanoidInstance)
			{
				if (!lastRaidInfo.IsDoorDamageTaken && take is BaseBuildingInstance baseBuildingInstance && (baseBuildingInstance.BuildingType & BuildingType.AnyDoor) != 0)
				{
					DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
					if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.Blueprint.CountsAsDoorInRaid)
					{
						lastRaidInfo.IsDoorDamageTaken = true;
						Log.Info("Door damage taken", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidManager.cs");
					}
				}
				if (!lastRaidInfo.IsMeleeDamageTaken && take is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsWorker() && humanoidInstance.GetEquipment() != null)
				{
					foreach (EquipmentInstance item in humanoidInstance.GetEquipment())
					{
						if (item.WeaponTypeSettings.AttackType.Equals(AttackType.Melee))
						{
							lastRaidInfo.IsMeleeDamageTaken = true;
							lastRaidInfo.NoMeleeDamageInRow = 0;
						}
					}
				}
			}
			if (deal is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance3)
			{
				foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
				{
					raid.AddToWorkersAttacked(humanoidInstance3, hitInfo.Damage);
				}
			}
			OnDamageTaken(take, hitInfo.Damage);
		}

		private void OnDealDamageEvent(IDamageTakingAgent damageTakingAgent, float damage)
		{
			OnDamageTaken(damageTakingAgent, damage);
		}

		private void OnDamageTaken(IDamageTakingAgent take, float damage)
		{
			if (!(take is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return;
			}
			foreach (ActiveRaidInfo raid in GlobalSaveController.CurrentVillageData.Raids)
			{
				raid.AddDamageTaken(humanoidInstance, damage);
			}
		}

		private void OnFriendlinessChanged(FactionFriendliness friendliness, FactionInstance faction)
		{
			if (friendliness == FactionFriendliness.Hostile && GlobalSaveController.CurrentVillageData.NPCs.Any((HumanoidInstance enemyInstance) => enemyInstance.Faction.Equals(faction)))
			{
				MonoSingleton<GameSpeedManager>.Instance.SetSpeedNormal();
			}
		}
	}
}
