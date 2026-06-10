using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Manager.RaidEndConditions;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("RaidPhase", "")]
	public class RaidPhase : GameEventBranchingPhaseBase
	{
		private const int VICTORY_PHASE_INDEX = 0;

		private const int DEFEAT_PHASE_INDEX = 1;

		private const int TIE_PHASE_INDEX = 2;

		[SerializeField]
		private RaidPhaseStatus raidStatus;

		[SerializeField]
		private int raidId;

		[SerializeField]
		private bool skipManyUnitsDeadCondition;

		[SerializeField]
		private bool skipNoDamageTimeoutCondition;

		private int? raidEngageDelayMinutes;

		private IRaidPhaseDataHolder ExternalDataHolder => base.EventInstance as IRaidPhaseDataHolder;

		public RaiderBlueprintId[] EnemyBlueprintIds => ExternalDataHolder.EnemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => ExternalDataHolder.SiegeWeaponBlueprints;

		public bool IsSiege => ExternalDataHolder.IsSiege;

		public ActiveRaidInfo CachedRaidInfo
		{
			get
			{
				return ExternalDataHolder.CachedRaidInfo;
			}
			set
			{
				ExternalDataHolder.CachedRaidInfo = value;
			}
		}

		public VillagePlace RaiderOriginPlace => ExternalDataHolder.RaiderOriginVillage;

		public FactionInstance RaiderFactionInstance => ExternalDataHolder.RaiderFactionInstance;

		public RaidPhase(int? raidEngageDelayMinutes = null, bool skipManyUnitsDeadCondition = false, bool skipNoDamageTimeoutCondition = false)
		{
			this.raidEngageDelayMinutes = raidEngageDelayMinutes;
			this.skipManyUnitsDeadCondition = skipManyUnitsDeadCondition;
			this.skipNoDamageTimeoutCondition = skipNoDamageTimeoutCondition;
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override bool OnStart()
		{
			VerifyEventImplements<IRaidPhaseDataHolder>();
			Subscribe();
			if (GlobalSaveController.CurrentVillageData.LastRaidInfo.ShouldForceSiegeWeaponRaid)
			{
				GlobalSaveController.CurrentVillageData.LastRaidInfo.NoMeleeDamageInRow = 0;
			}
			raidId = GetNewRaidId();
			raidStatus = RaidPhaseStatus.InProgress;
			StartRaid();
			return true;
		}

		private void Subscribe()
		{
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidStarted;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStarted;
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
			}
		}

		protected override int TickNextPhaseIndex()
		{
			return raidStatus switch
			{
				RaidPhaseStatus.Victory => 0, 
				RaidPhaseStatus.Defeat => 1, 
				RaidPhaseStatus.Tie => 2, 
				_ => -1, 
			};
		}

		private static int GetNewRaidId()
		{
			int num = UnityEngine.Random.Range(1, int.MaxValue);
			while (GlobalSaveController.CurrentVillageData.HasRaidWithId(num))
			{
				num = UnityEngine.Random.Range(1, int.MaxValue);
			}
			return num;
		}

		private void StartRaid()
		{
			List<IEnemyPurchaseUnit> list = new List<IEnemyPurchaseUnit>();
			List<int?> list2 = new List<int?>();
			RaiderBlueprintId[] enemyBlueprintIds = EnemyBlueprintIds;
			foreach (RaiderBlueprintId raiderBlueprintId in enemyBlueprintIds)
			{
				list.Add(raiderBlueprintId.FindBlueprint());
				list2.Add(raiderBlueprintId.RandomSeed);
			}
			bool isSiege = IsSiege;
			MonoSingleton<GameEventSystemController>.Instance.RaidStarted(isSiege, list, base.Blueprint.Category, raidId);
			long delayBeforeAttack = GlobalSaveController.CurrentVillageData.MapSizeInstance.RaidDelayBeforeAttack;
			int raidDontEngageCombatDuration = GlobalSaveController.CurrentVillageData.MapSizeInstance.RaidDontEngageCombatDuration;
			NSMedieval.Model.Raid raid = new NSMedieval.Model.Raid(raidId, isSiege, delayBeforeAttack, raidDontEngageCombatDuration);
			List<NSMedieval.Model.Raid.RaidEnemyInfo> list3 = new List<NSMedieval.Model.Raid.RaidEnemyInfo>();
			foreach (IEnemyPurchaseUnit item2 in list)
			{
				if (item2 != null)
				{
					NSMedieval.Model.Raid.RaidEnemyInfo item = new NSMedieval.Model.Raid.RaidEnemyInfo(item2);
					list3.Add(item);
				}
			}
			raid.Enemies = list3.ToArray();
			raid.SiegeWeapons = SiegeWeaponBlueprints?.ToArray();
			raid.EquipmentGroup = null;
			if (RaiderFactionInstance != null && base.EventInstance.Blueprint.ResetFactionFriendliness)
			{
				RaiderFactionInstance.SetPlayerFriendliness(RaiderFactionInstance.Blueprint.FriendlinessRange.Random(), showNotification: false, processRelatedFactions: false);
			}
			if (TutorialManager.IsTutorialActive)
			{
				raid.DelayBeforeAttack = 0L;
				ExternalDataHolder.OverrideRaidSpawnPositions = new List<MapNode>
				{
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 135)),
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 134)),
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 133)),
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 132)),
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 131)),
					VillageManager.ActiveVillage.Map.GetNode(new Vec3Int(200, 5, 130))
				};
			}
			ActiveRaidInfo activeRaidInfo = VillageManager.ActiveVillage.Map.RaidManager.StartRaid(raid, RaiderOriginPlace, RaiderFactionInstance, base.EventInstance.Blueprint.GetID(), list2, ExternalDataHolder.OverrideRaidSpawnPositions, base.EventInstance, GetPlayerEndConditions, GetPlayerEndConditions);
			if (raidEngageDelayMinutes.HasValue)
			{
				activeRaidInfo.RaidEngageDelay = Cooldown.FromNowMinutes(raidEngageDelayMinutes.Value, TutorialManager.IsTutorialActive);
			}
		}

		private List<RaidEndCondition> GetPlayerEndConditions(ActiveRaidInfo info, IEnumerable<HumanoidInstance> units)
		{
			List<RaidEndCondition> list = new List<RaidEndCondition>();
			if (!skipManyUnitsDeadCondition)
			{
				list.Add(new ManyUnitsDeadEndCondition(info, units));
			}
			if (!skipNoDamageTimeoutCondition)
			{
				list.Add(new NoDamageTimeoutEndCondition(info));
			}
			return list;
		}

		private void OnRaidStarted(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			if (!raidId.Equals(info.RaidId))
			{
				return;
			}
			CachedRaidInfo = info;
			Vector3 zero = Vector3.zero;
			foreach (HumanoidInstance enemy in enemies)
			{
				zero += enemy.GetPosition();
			}
			zero /= (float)enemies.Count;
			if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(zero);
			}
		}

		private void OnRaidEnded(ActiveRaidInfo info)
		{
			FVLogInfoInterpolationHandler messageBuilder;
			bool isEnabled;
			if (!raidId.Equals(info.RaidId))
			{
				FVLogger logger = GameEventPhaseBase.Logger;
				messageBuilder = new FVLogInfoInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Raid\\RaidPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Not removing raid event, not the same id (");
					messageBuilder.AppendFormatted(info.RaidId);
					messageBuilder.AppendLiteral(" and ");
					messageBuilder.AppendFormatted(raidId);
					messageBuilder.AppendLiteral(")");
				}
				logger.Info(in messageBuilder);
				return;
			}
			Unsubscribe();
			if (CachedRaidInfo == null)
			{
				ActiveRaidInfo activeRaidInfo = (CachedRaidInfo = info);
			}
			CachedRaidInfo.GenerateEnemiesSurvivedList();
			raidStatus = CachedRaidInfo.RaidStatus switch
			{
				RaidStatus.PlayerVictory => RaidPhaseStatus.Victory, 
				RaidStatus.EnemyVictory => RaidPhaseStatus.Defeat, 
				RaidStatus.Tie => RaidPhaseStatus.Tie, 
				_ => RaidPhaseStatus.Tie, 
			};
			FVLogger logger2 = GameEventPhaseBase.Logger;
			messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Raid\\RaidPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Raid has ended in ");
				messageBuilder.AppendFormatted(raidStatus);
			}
			logger2.Info(in messageBuilder);
		}

		public override void OnLoaded(bool fromSave)
		{
			if (fromSave && GlobalSaveController.CurrentVillageData.NPCs.All((HumanoidInstance npc) => !npc.IsRaiderOfRaid(raidId)))
			{
				GameEventPhaseBase.Logger.Info("Removing raid on load (no enemies present).");
				raidStatus = RaidPhaseStatus.Victory;
			}
			else
			{
				Subscribe();
			}
		}

		public override void OnEnd()
		{
			Unsubscribe();
			if (!CachedRaidInfo.HasEnded)
			{
				CleanUpAfterForceEnd();
			}
			MonoSingleton<CaptiveNpcManager>.Instance.TryShowSelectPrisonersDialog(CachedRaidInfo);
		}

		private void CleanUpAfterForceEnd()
		{
			foreach (EnemyBehaviour item in MonoSingleton<NPCManager>.Instance.IterateNPCs<EnemyBehaviour>())
			{
				if (item.RaidId == raidId)
				{
					item.Humanoid.Stats.GetStat(StatType.Health).SetCurrent(0f);
				}
			}
		}

		public RaidPhase NextPhaseOnVictory(GameEventPhaseBase phase)
		{
			SetNextPhase(phase, 0);
			return this;
		}

		public RaidPhase NextPhaseOnDefeat(GameEventPhaseBase phase)
		{
			SetNextPhase(phase, 1);
			return this;
		}

		public RaidPhase NextPhaseOnTie(GameEventPhaseBase phase)
		{
			SetNextPhase(phase, 2);
			return this;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.WriteEnum("raidStatus", raidStatus);
			serializer.Write("raidId", raidId);
			serializer.Write("raidEngageDelayMinutes", raidEngageDelayMinutes);
			serializer.Write("skipNoDamageTimeoutCondition", skipNoDamageTimeoutCondition);
			serializer.Write("skipManyUnitsDeadCondition", skipManyUnitsDeadCondition);
		}

		public RaidPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			raidStatus = deserializer.ReadEnum("raidStatus", RaidPhaseStatus.None);
			raidId = deserializer.ReadInt("raidId");
			raidEngageDelayMinutes = deserializer.ReadNullableInt("raidEngageDelayMinutes");
			skipNoDamageTimeoutCondition = deserializer.ReadBool("skipNoDamageTimeoutCondition");
			skipManyUnitsDeadCondition = deserializer.ReadBool("skipManyUnitsDeadCondition");
		}
	}
}
