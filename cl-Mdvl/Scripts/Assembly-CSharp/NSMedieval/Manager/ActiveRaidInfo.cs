using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Controllers;
using NSMedieval.Dictionary;
using NSMedieval.Manager.RaidEndConditions;
using NSMedieval.Manager.RaidPointsFactors;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	[Serializable]
	[FVSerializableKey("ActiveRaidInfo", "")]
	public class ActiveRaidInfo : IFVSerializable, IDisposable
	{
		public delegate List<RaidEndCondition> CreateRaidEndConditionsDelegate(ActiveRaidInfo info, IEnumerable<HumanoidInstance> units);

		private List<string> battleScalesTooltipLines;

		[SerializeField]
		private NSMedieval.Model.Raid blueprint;

		[SerializeField]
		private int raidId;

		[SerializeField]
		private int spawnCount;

		[SerializeField]
		private long startTime;

		[SerializeField]
		private int trebuchetsCount;

		[SerializeField]
		private bool isSiege;

		[SerializeField]
		private bool hasEngaged;

		[SerializeField]
		private bool hasCharged;

		[SerializeField]
		private List<string> workersDied = new List<string>();

		[SerializeField]
		private List<string> enemiesDied = new List<string>();

		[SerializeField]
		private List<string> enemiesSurvived = new List<string>();

		[SerializeField]
		private List<string> buildingsDestroyed = new List<string>();

		[SerializeField]
		private int productionBuildingsDestroyed;

		[SerializeField]
		private StringKeyPair workersAttacked = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private StringKeyPair damageTaken = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private StringKeyPair hitsBlocked = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private uint commanderAgentId;

		[SerializeField]
		private string parentEventId;

		private List<RaidPointsFactor> playerPointsFactors;

		private List<RaidPointsFactor> enemyPointsFactors;

		private List<RaidEndCondition> playerEndConditions;

		private List<RaidEndCondition> enemyEndConditions;

		private Cooldown raidEngageDelay = new Cooldown(TutorialManager.IsTutorialActive);

		public VillageMap Map { get; private set; }

		public float BattleScalesBalance { get; private set; }

		public RaidStatus RaidStatus { get; private set; }

		public IReadOnlyList<string> BattleScalesTooltipLines => battleScalesTooltipLines;

		public Cooldown RaidEngageDelay
		{
			get
			{
				return raidEngageDelay;
			}
			set
			{
				raidEngageDelay = value;
			}
		}

		public bool Won => RaidStatus == RaidStatus.PlayerVictory;

		public bool HasEnded => RaidStatus != RaidStatus.InProgress;

		public bool HasCharged
		{
			get
			{
				return hasCharged;
			}
			set
			{
				hasCharged = value;
			}
		}

		public bool HasEngaged
		{
			get
			{
				return hasEngaged;
			}
			set
			{
				hasEngaged = value;
			}
		}

		public NSMedieval.Model.Raid Blueprint => blueprint;

		public int RaidId => raidId;

		public int SpawnCount => spawnCount;

		public bool IsSiege => isSiege;

		public List<string> WorkersDied => workersDied;

		public List<string> EnemiesDied => enemiesDied;

		public List<string> EnemiesSurvived => enemiesSurvived;

		public List<string> BuildingsDestroyed => buildingsDestroyed;

		public Dictionary<string, float> WorkersAttacked => workersAttacked.Dictionary;

		public Dictionary<string, float> DamageTaken => damageTaken.Dictionary;

		public Dictionary<string, float> HitsBlocked => hitsBlocked.Dictionary;

		public int TrebuchetsCount
		{
			get
			{
				return trebuchetsCount;
			}
			set
			{
				trebuchetsCount = value;
			}
		}

		public long StartTime => startTime;

		public uint CommanderAgentId
		{
			get
			{
				return commanderAgentId;
			}
			set
			{
				commanderAgentId = value;
			}
		}

		public string ParentEventId => parentEventId;

		public event Action OnBattleScalesChanged;

		public ActiveRaidInfo(VillageMap villageMap, NSMedieval.Model.Raid blueprint, string parentEventId, int raidId, List<HumanoidInstance> enemyUnits, List<HumanoidInstance> playerUnits, long startTime, bool isSiege, uint commanderAgentId, CreateRaidEndConditionsDelegate createPlayerEndConditions = null, CreateRaidEndConditionsDelegate createEnemyEndConditions = null)
			: this()
		{
			Map = villageMap;
			this.blueprint = blueprint;
			this.raidId = raidId;
			spawnCount = enemyUnits.Count;
			this.startTime = startTime;
			this.isSiege = isSiege;
			hasEngaged = false;
			hasCharged = false;
			this.commanderAgentId = commanderAgentId;
			this.parentEventId = parentEventId;
			bool isSecondMap = GlobalSaveController.CurrentVillageData.IsSecondMap;
			playerPointsFactors = RaidUtil.CreateFactors(this, playerUnits, isSecondMap, buildingsOwnedByThisSide: true);
			enemyPointsFactors = RaidUtil.CreateFactors(this, enemyUnits, isSecondMap);
			foreach (RaidPointsFactor playerPointsFactor in playerPointsFactors)
			{
				playerPointsFactor.OnPointsChanged += OnPointsFactorChanged;
			}
			foreach (RaidPointsFactor enemyPointsFactor in enemyPointsFactors)
			{
				enemyPointsFactor.OnPointsChanged += OnPointsFactorChanged;
			}
			List<RaidEndCondition> list = createPlayerEndConditions?.Invoke(this, playerUnits);
			List<RaidEndCondition> list2 = createEnemyEndConditions?.Invoke(this, enemyUnits);
			if (list == null)
			{
				playerEndConditions = RaidUtil.CreateEndConditions(this, playerUnits);
			}
			else
			{
				playerEndConditions = new List<RaidEndCondition>(list);
			}
			if (list2 == null)
			{
				enemyEndConditions = RaidUtil.CreateEndConditions(this, enemyUnits);
			}
			else
			{
				enemyEndConditions = new List<RaidEndCondition>(list2);
			}
			OnPointsFactorChanged();
			Map.CommanderAIManager.LinkWithRaid(this.commanderAgentId, this);
		}

		private ActiveRaidInfo()
		{
		}

		public void InitAfterLoad()
		{
			if (Map == null)
			{
				VillageMap villageMap = (Map = VillageManager.ActiveVillage.Map);
			}
			if (playerPointsFactors == null || enemyPointsFactors == null || playerEndConditions == null || enemyEndConditions == null || Map.CommanderAIManager.GetCommander(commanderAgentId) == null)
			{
				Log.Info("Fixing old save raid instance (pre battle scales)", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
				List<HumanoidInstance> workers = GlobalSaveController.CurrentVillageData.Workers;
				using PooledList<HumanoidInstance> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled((HumanoidInstance humanoid) => humanoid.IsEnemy());
				bool isSecondMap = GlobalSaveController.CurrentVillageData.IsSecondMap;
				if (playerPointsFactors == null)
				{
					playerPointsFactors = RaidUtil.CreateFactors(this, workers, isSecondMap, buildingsOwnedByThisSide: true);
				}
				if (enemyPointsFactors == null)
				{
					enemyPointsFactors = RaidUtil.CreateFactors(this, pooledList, isSecondMap);
				}
				if (playerEndConditions == null)
				{
					playerEndConditions = RaidUtil.CreateEndConditions(this, workers);
				}
				if (enemyEndConditions == null)
				{
					enemyEndConditions = RaidUtil.CreateEndConditions(this, pooledList);
				}
				foreach (RaidPointsFactor playerPointsFactor in playerPointsFactors)
				{
					playerPointsFactor.OnPointsChanged += OnPointsFactorChanged;
				}
				foreach (RaidPointsFactor enemyPointsFactor in enemyPointsFactors)
				{
					enemyPointsFactor.OnPointsChanged += OnPointsFactorChanged;
				}
				if (Map.CommanderAIManager.GetCommander(commanderAgentId) == null)
				{
					Log.Info("Fixing old save raid instance, assigning new Commander AI agent", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
					commanderAgentId = Map.CommanderAIManager.CreateCommander(pooledList);
					Map.CommanderAIManager.LinkWithRaid(commanderAgentId, this);
				}
				OnPointsFactorChanged();
				return;
			}
			foreach (RaidPointsFactor playerPointsFactor2 in playerPointsFactors)
			{
				playerPointsFactor2.InitAfterLoad();
				playerPointsFactor2.OnPointsChanged += OnPointsFactorChanged;
			}
			foreach (RaidPointsFactor enemyPointsFactor2 in enemyPointsFactors)
			{
				enemyPointsFactor2.InitAfterLoad();
				enemyPointsFactor2.OnPointsChanged += OnPointsFactorChanged;
			}
			foreach (RaidEndCondition playerEndCondition in playerEndConditions)
			{
				playerEndCondition.InitAfterLoad();
			}
			foreach (RaidEndCondition enemyEndCondition in enemyEndConditions)
			{
				enemyEndCondition.InitAfterLoad();
			}
			OnPointsFactorChanged();
		}

		public void AddToWorkersAttacked(HumanoidInstance humanoidInstance, float damage)
		{
			if (humanoidInstance?.Info != null)
			{
				string fullName = humanoidInstance.Info.GetFullName();
				if (!workersAttacked.Dictionary.TryAdd(fullName, damage))
				{
					workersAttacked.Dictionary[fullName] += damage;
				}
			}
		}

		public void AddHitBlocked(HumanoidInstance humanoidInstance, float damageBlocked)
		{
			if (humanoidInstance?.Info != null)
			{
				string fullName = humanoidInstance.Info.GetFullName();
				if (!hitsBlocked.Dictionary.TryAdd(fullName, damageBlocked))
				{
					hitsBlocked.Dictionary[fullName] += damageBlocked;
				}
			}
		}

		public void AddDamageTaken(HumanoidInstance humanoidInstance, float damageTaken)
		{
			if (humanoidInstance?.Info != null)
			{
				string fullName = humanoidInstance.Info.GetFullName();
				if (!this.damageTaken.Dictionary.TryAdd(fullName, damageTaken))
				{
					this.damageTaken.Dictionary[fullName] += damageTaken;
				}
			}
		}

		public void GenerateEnemiesSurvivedList()
		{
			EnemiesSurvived.Clear();
			foreach (EnemyBehaviour item in MonoSingleton<NPCManager>.Instance.IterateNPCs<EnemyBehaviour>())
			{
				if (item.RaidId == RaidId)
				{
					EnemiesSurvived.Add(item.Humanoid.Info.GetFullName());
				}
			}
		}

		public static ActiveRaidInfo GetById(int raidId)
		{
			return GlobalSaveController.CurrentVillageData.Raids.FirstOrDefault((ActiveRaidInfo item) => item.RaidId == raidId);
		}

		public void TickEndConditions()
		{
			if (HasEnded)
			{
				Log.Warning("Tried to tick raid end conditions for a raid that has ended", "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
				return;
			}
			bool isEnabled;
			foreach (RaidEndCondition playerEndCondition in playerEndConditions)
			{
				if (playerEndCondition.ShouldEnd)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Ending raid because of player end condition '");
						messageBuilder.AppendFormatted(playerEndCondition.GetType().Name);
						messageBuilder.AppendLiteral("'");
					}
					Log.Info(messageBuilder);
					EndRaid();
					return;
				}
			}
			foreach (RaidEndCondition enemyEndCondition in enemyEndConditions)
			{
				if (enemyEndCondition.ShouldEnd)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Ending raid because of enemy end condition '");
						messageBuilder.AppendFormatted(enemyEndCondition.GetType().Name);
						messageBuilder.AppendLiteral("'");
					}
					Log.Info(messageBuilder);
					EndRaid();
					return;
				}
			}
			if (BattleScalesBalance < -0.99f || BattleScalesBalance > 0.99f)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ending raid because the battle scale balance was: ");
					messageBuilder.AppendFormatted(BattleScalesBalance);
				}
				Log.Info(messageBuilder);
				EndRaid();
			}
		}

		private void EndRaid()
		{
			if (HasEnded)
			{
				return;
			}
			FloatRange neutralOutcomePointsRange = SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.NeutralOutcomePointsRange;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (BattleScalesBalance < neutralOutcomePointsRange.Min)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ending raid with enemy victory, balance ");
					messageBuilder.AppendFormatted(BattleScalesBalance);
					messageBuilder.AppendLiteral(", min neutral outcome ");
					messageBuilder.AppendFormatted(neutralOutcomePointsRange.Min);
				}
				Log.Info(messageBuilder);
				RaidStatus = RaidStatus.EnemyVictory;
				return;
			}
			if (BattleScalesBalance > neutralOutcomePointsRange.Max)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ending raid with player victory, balance ");
					messageBuilder.AppendFormatted(BattleScalesBalance);
					messageBuilder.AppendLiteral(", max neutral outcome ");
					messageBuilder.AppendFormatted(neutralOutcomePointsRange.Max);
				}
				Log.Info(messageBuilder);
				RaidStatus = RaidStatus.PlayerVictory;
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(74, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Ending raid with tie, balance ");
				messageBuilder.AppendFormatted(BattleScalesBalance);
				messageBuilder.AppendLiteral(", min neutral outcome ");
				messageBuilder.AppendFormatted(neutralOutcomePointsRange.Min);
				messageBuilder.AppendLiteral(", max neutral outcome ");
				messageBuilder.AppendFormatted(neutralOutcomePointsRange.Max);
			}
			Log.Info(messageBuilder);
			RaidStatus = RaidStatus.Tie;
		}

		public void Dispose()
		{
			foreach (RaidPointsFactor playerPointsFactor in playerPointsFactors)
			{
				playerPointsFactor.Dispose();
			}
			foreach (RaidPointsFactor enemyPointsFactor in enemyPointsFactors)
			{
				enemyPointsFactor.Dispose();
			}
			foreach (RaidEndCondition playerEndCondition in playerEndConditions)
			{
				playerEndCondition.Dispose();
			}
			foreach (RaidEndCondition enemyEndCondition in enemyEndConditions)
			{
				enemyEndCondition.Dispose();
			}
			Map = null;
			this.OnBattleScalesChanged = null;
		}

		private void OnPointsFactorChanged()
		{
			(float normalizedPoints, float maxPointsRaw) tuple = RaidUtil.CalculateNormalizedPoints(playerPointsFactors);
			float item = tuple.normalizedPoints;
			float item2 = tuple.maxPointsRaw;
			(float normalizedPoints, float maxPointsRaw) tuple2 = RaidUtil.CalculateNormalizedPoints(enemyPointsFactors);
			float item3 = tuple2.normalizedPoints;
			float item4 = tuple2.maxPointsRaw;
			BattleScalesBalance = item - item3;
			if (battleScalesTooltipLines == null)
			{
				battleScalesTooltipLines = new List<string>();
			}
			battleScalesTooltipLines.Clear();
			int num = Mathf.RoundToInt(BattleScalesBalance * 100f);
			string text = ((num < 0) ? "DefaultRed" : "DefaultGreen");
			if (num == 0)
			{
				text = "DefaultYellow";
			}
			string text2 = ((num > 0) ? "+" : "");
			battleScalesTooltipLines.Add(string.Format("{0}: <style={1}>{2}{3}</style>\n", MonoSingleton<LocalizationController>.Instance.GetText("battle_balance"), text, text2, num));
			RaidUtil.FillTooltipLines(enemyPointsFactors, item4, battleScalesTooltipLines, isPlayer: false);
			RaidUtil.FillTooltipLines(playerPointsFactors, item2, battleScalesTooltipLines, isPlayer: true);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\ActiveRaidInfo.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnPointsFactorChanged, battle scales balance: ");
				messageBuilder.AppendFormatted(BattleScalesBalance);
			}
			Log.Debug(messageBuilder);
			this.OnBattleScalesChanged?.Invoke();
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprint", blueprint);
			serializer.Write("raidId", raidId);
			serializer.Write("spawnCount", spawnCount);
			serializer.Write("startTime", startTime);
			serializer.Write("trebuchetsCount", trebuchetsCount);
			serializer.Write("isSiege", isSiege);
			serializer.Write("hasEngaged", hasEngaged);
			serializer.Write("hasCharged", hasCharged);
			serializer.WriteEnum("raidStatus", RaidStatus);
			serializer.Write("workersDied", workersDied);
			serializer.Write("enemiesDied", enemiesDied);
			serializer.Write("enemiesSurvived", enemiesSurvived);
			serializer.Write("buildingsDestroyed", buildingsDestroyed);
			serializer.Write("productionBuildingsDestroyed", productionBuildingsDestroyed);
			serializer.Write("workersAttacked", workersAttacked);
			serializer.Write("damageTaken", damageTaken);
			serializer.Write("hitsBlocked", hitsBlocked);
			serializer.Write("commanderAgentId", commanderAgentId);
			serializer.Write("map", Map);
			serializer.Write("playerPointsFactors", playerPointsFactors);
			serializer.Write("enemyPointsFactors", enemyPointsFactors);
			serializer.Write("playerEndConditions", playerEndConditions);
			serializer.Write("enemyEndConditions", enemyEndConditions);
			serializer.Write("raidEngageDelay", raidEngageDelay);
			serializer.Write("parentEventId", parentEventId);
		}

		public ActiveRaidInfo(FVDeserializer deserializer)
			: this()
		{
			blueprint = deserializer.ReadObject<NSMedieval.Model.Raid>("blueprint");
			raidId = deserializer.ReadInt("raidId");
			spawnCount = deserializer.ReadInt("spawnCount");
			startTime = deserializer.ReadLong("startTime", 0L);
			trebuchetsCount = deserializer.ReadInt("trebuchetsCount");
			isSiege = deserializer.ReadBool("isSiege");
			hasEngaged = deserializer.ReadBool("hasEngaged");
			hasCharged = deserializer.ReadBool("hasCharged");
			RaidStatus = deserializer.ReadEnum("raidStatus", RaidStatus.InProgress);
			workersDied = deserializer.ReadStringList("workersDied");
			enemiesDied = deserializer.ReadStringList("enemiesDied");
			enemiesSurvived = deserializer.ReadStringList("enemiesSurvived");
			buildingsDestroyed = deserializer.ReadStringList("buildingsDestroyed");
			productionBuildingsDestroyed = deserializer.ReadInt("productionBuildingsDestroyed");
			workersAttacked = deserializer.ReadObject<StringKeyPair>("workersAttacked");
			damageTaken = deserializer.ReadObject<StringKeyPair>("damageTaken");
			hitsBlocked = deserializer.ReadObject<StringKeyPair>("hitsBlocked");
			commanderAgentId = deserializer.ReadUInt("commanderAgentId");
			Map = deserializer.ReadObject<VillageMap>("map");
			playerPointsFactors = deserializer.ReadObjectList<RaidPointsFactor>("playerPointsFactors");
			enemyPointsFactors = deserializer.ReadObjectList<RaidPointsFactor>("enemyPointsFactors");
			playerEndConditions = deserializer.ReadObjectList<RaidEndCondition>("playerEndConditions");
			enemyEndConditions = deserializer.ReadObjectList<RaidEndCondition>("enemyEndConditions");
			raidEngageDelay = deserializer.ReadObject<Cooldown>("raidEngageDelay");
			parentEventId = deserializer.ReadString("parentEventId");
		}
	}
}
