using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Tools.Math;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ResourceInstance", "")]
	public class ResourceInstance : IGameDisposable, IDisposable, IStatsOwner, ILifeLogOwner, IFVSerializable
	{
		[SerializeField]
		protected FactionOwnership factionOwnership;

		[SerializeField]
		private string blueprintId;

		[SerializeField]
		private int amount;

		[SerializeField]
		private string localizedInheritedName = string.Empty;

		[SerializeField]
		private LinkedList<LifeEventLogStruct> lifeEventLogs;

		[SerializeField]
		private readonly int ownerCreationID;

		[SerializeField]
		private int producerUniqueId;

		[NonSerialized]
		private bool forbidOnInit;

		[NonSerialized]
		private StatsInstance stats;

		[NonSerialized]
		private Resource blueprint;

		[NonSerialized]
		private ILifeLogOwner creatureLogOwnerCache;

		[NonSerialized]
		private int stackingLimit;

		[NonSerialized]
		private ResourcePileInstance resourcePileInstance;

		private bool statsInitialzied;

		private string localizedNameCache;

		public ResourcePileInstance ResourcePileInstance
		{
			get
			{
				return resourcePileInstance;
			}
			set
			{
				resourcePileInstance = value;
			}
		}

		public bool HasDisposed { get; protected set; }

		public string BlueprintId => blueprintId;

		public int Amount => amount;

		public SimpleResourceCount Count => new SimpleResourceCount(Blueprint, Amount);

		public string LocalizedInheritedName => localizedInheritedName;

		public bool ForbidOnInit
		{
			get
			{
				return forbidOnInit;
			}
			set
			{
				forbidOnInit = value;
			}
		}

		public bool DroppedByEnemy => CreatureLogOwner is HumanoidInstance;

		public string Info => $"type = {blueprintId}, amount = {amount}";

		public float Weight => Blueprint.Weight * (float)amount;

		public LinkedList<LifeEventLogStruct> LifeEventLogs => lifeEventLogs ?? (lifeEventLogs = new LinkedList<LifeEventLogStruct>());

		public Resource Blueprint
		{
			get
			{
				Resource resource = blueprint ?? (blueprint = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId));
				if (resource == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(86, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\Components\\ResourceInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("[Autofix] resource with id '");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral("' not found, probably a modded save, defaulting to cabbage");
					}
					Log.Error(messageBuilder);
					blueprintId = "cabbage";
					resource = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId);
				}
				return resource;
			}
		}

		public StatsInstance Stats => stats;

		public int OwnerCreationID => ownerCreationID;

		public int ProducerUniqueId => producerUniqueId;

		public int StackingLimit => stackingLimit;

		public FactionOwnership FactionOwnership => factionOwnership;

		public ILifeLogOwner CreatureLogOwner
		{
			get
			{
				if (creatureLogOwnerCache != null)
				{
					return creatureLogOwnerCache;
				}
				if (ownerCreationID == 0)
				{
					return null;
				}
				creatureLogOwnerCache = MonoSingleton<CreatureManager>.Instance.GetByCreationId(ownerCreationID);
				if (creatureLogOwnerCache == null)
				{
					creatureLogOwnerCache = MonoSingleton<ResourcePileTracker>.Instance.GetCarcassOwnerByOwnerCreationId(ownerCreationID);
				}
				return creatureLogOwnerCache;
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public ResourceInstance(Resource blueprint, int amount, ILifeLogOwner logOwner)
		{
			if (logOwner != null && logOwner.LifeEventLogs.Count > 0)
			{
				foreach (LifeEventLogStruct lifeEventLog in logOwner.LifeEventLogs)
				{
					LifeEventLogs.AddLast(lifeEventLog);
				}
			}
			ownerCreationID = ((logOwner is ResourceInstance resourceInstance) ? resourceInstance.OwnerCreationID : ((!(logOwner is CreatureBase creatureBase)) ? ownerCreationID : creatureBase.UniqueId));
			SetupInstance(blueprint, amount);
		}

		public ResourceInstance(Resource blueprint, int amount)
		{
			SetupInstance(blueprint, amount);
		}

		public void SetProducerUniqueId(int producerUniqueId)
		{
			if (this.producerUniqueId == 0)
			{
				this.producerUniqueId = producerUniqueId;
			}
		}

		public override string ToString()
		{
			return $"'Resource:{blueprintId} Count: {Amount}, Weight: {Weight}, Value: {GetWealth()}, Disposed:{HasDisposed}'";
		}

		public virtual ResourceInstance Clone(int overrideAmount = -1)
		{
			ResourceInstance resourceInstance = new ResourceInstance(Blueprint, (overrideAmount >= 0) ? overrideAmount : Amount, this);
			resourceInstance.SetProducerUniqueId(producerUniqueId);
			resourceInstance.CloneStatsCurrent(Stats);
			resourceInstance.SetLocalizedInheritedName(localizedInheritedName);
			resourceInstance.factionOwnership = factionOwnership;
			return resourceInstance;
		}

		public void SetFaction(FactionOwnership factionOwnership)
		{
			this.factionOwnership = factionOwnership;
		}

		public bool OwnedByPlayer()
		{
			return factionOwnership == FactionOwnership.Player;
		}

		public void OverrideStackingLimit(int newStackingLimit)
		{
			stackingLimit = newStackingLimit;
		}

		public void ResetStackingLimit()
		{
			if (!(blueprint == null))
			{
				stackingLimit = blueprint.StackingLimit;
			}
		}

		public int TransferTo(Storage target, int amount = -1)
		{
			return target.Transfer(this, amount);
		}

		public int TransferTo(ResourceInstance target, int amount = -1)
		{
			if (target == null || Amount <= 0)
			{
				return 0;
			}
			if (amount <= 0)
			{
				amount = Amount;
			}
			int num = target.Amount;
			target.Add(this, amount);
			int num2 = target.Amount - num;
			if (num2 > 0)
			{
				Sub(num2);
				return num2;
			}
			return 0;
		}

		public NSMedieval.StatsSystem.Attribute GetAttributeOverride(AttributeType type)
		{
			return null;
		}

		public bool StatsInitialized()
		{
			return stats != null;
		}

		public StatInstance GetStat(StatType type)
		{
			return Stats.GetStat(type);
		}

		public float GetHealthInPercentage()
		{
			float current = GetStat(StatType.Health).Current;
			return Mathf.Round(PercentageTools.GetPercentOfYFromX(GetStat(StatType.Health).Max, current));
		}

		public float GetFreshnessInPercentage()
		{
			float current = GetStat(StatType.Freshness).Current;
			return Mathf.Round(PercentageTools.GetPercentOfYFromX(GetStat(StatType.Freshness).Max, current));
		}

		public float GetWealth()
		{
			if (HasDisposed)
			{
				return 0f;
			}
			StatInstance stat = Stats.GetStat(StatType.Health);
			float num = (stat.Current - stat.Min) / (stat.Max - stat.Min);
			return (float)Amount * Blueprint.WealthPoints * num;
		}

		public float GetUnitWealth()
		{
			if (HasDisposed)
			{
				return 0f;
			}
			StatInstance stat = Stats.GetStat(StatType.Health);
			return Blueprint.WealthPoints * stat.GetNormalizedPercentage();
		}

		public void CloneStatsCurrent(StatsInstance stats)
		{
			if (stats?.Stats == null)
			{
				Log.Warning("Cannot clone null stats. This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\Components\\ResourceInstance.cs");
				return;
			}
			foreach (KeyValuePair<StatType, StatInstance> stat in stats.Stats)
			{
				GetStat(stat.Key)?.SetCurrent(stat.Value.Current);
			}
		}

		public float GetStatValue(StatType type)
		{
			return (Stats?.GetStat(type))?.Current ?? 0f;
		}

		public float GetMaxStatValue(StatType type)
		{
			return Stats.GetStat(type)?.Max ?? 0f;
		}

		public float GetNutrition()
		{
			if (Blueprint.NutritionPerHp > 0f)
			{
				return Blueprint.NutritionPerHp * GetStatValue(StatType.Health);
			}
			return Blueprint.Nutrition;
		}

		public virtual void Dispose()
		{
			if (statsInitialzied)
			{
				stats?.Dispose();
			}
			HasDisposed = true;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			stats = null;
			creatureLogOwnerCache = null;
		}

		public void SetLocalizedInheritedName(string localizedInheritedName)
		{
			this.localizedInheritedName = localizedInheritedName;
		}

		internal int Add(ResourceInstance toAdd, int amount = -1)
		{
			int num = this.amount;
			int num2 = num + ((amount > 0) ? amount : toAdd.amount);
			if (num2 < 0)
			{
				num2 = 0;
			}
			MergeStats(toAdd);
			this.amount = num2;
			return Mathf.Max(0, this.amount - num);
		}

		internal int Sub(ResourceInstance toSubtract)
		{
			int num = amount;
			int num2 = num - toSubtract.amount;
			if (num2 < 0)
			{
				num2 = 0;
			}
			MergeStats(toSubtract);
			amount = num2;
			return num - amount;
		}

		internal int Sub(int amount)
		{
			int num = this.amount;
			this.amount -= amount;
			if (this.amount < 0)
			{
				this.amount = 0;
			}
			return num - this.amount;
		}

		private void MergeStats(ResourceInstance toMergeWith)
		{
			if (toMergeWith == this)
			{
				return;
			}
			foreach (KeyValuePair<StatType, StatInstance> stat in Stats.Stats)
			{
				float mergedValue = GetMergedValue(this, toMergeWith, stat.Value.Current, toMergeWith.GetStatValue(stat.Key));
				stat.Value.SetCurrent(mergedValue);
			}
		}

		private static float GetMergedValue(ResourceInstance first, ResourceInstance second, float firstValue, float secondValue)
		{
			if (first.BlueprintId != second.BlueprintId)
			{
				return firstValue;
			}
			return firstValue * ((float)first.Amount / (float)(first.Amount + second.Amount)) + secondValue * ((float)second.Amount / (float)(first.Amount + second.Amount));
		}

		private void SetupInstance(Resource blueprint, int amount)
		{
			if (blueprint == null)
			{
				throw new Exception("ERROR: Blueprint for this resource not found: '" + blueprintId);
			}
			blueprintId = blueprint.GetID();
			this.amount = amount;
			this.blueprint = blueprint;
			stackingLimit = this.blueprint.StackingLimit;
			InitStats();
			if (stats.Owner == null)
			{
				stats.SetOwner(this);
			}
		}

		private void InitStats()
		{
			if (statsInitialzied)
			{
				return;
			}
			if (Blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(91, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\Components\\ResourceInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ignored invalid Resources during loading because they didn't have an existing blueprint. : ");
					messageBuilder.AppendFormatted(blueprintId);
				}
				Log.Error(messageBuilder);
			}
			else if (stats != null)
			{
				if (stats.Owner == null)
				{
					stats.SetOwner(this);
				}
				ResourceStatsProducer.ProduceResourceStats(this, Blueprint, stats);
				stats.Initialize();
				statsInitialzied = true;
			}
			else
			{
				stats = ResourceStatsProducer.ProduceResourceStats(this, Blueprint);
				statsInitialzied = true;
			}
		}

		public void LogLifeEvent(LifeEventLogStruct lifeEvent)
		{
			LifeEventLogs.AddFirst(lifeEvent);
			int lifeLogLimit = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.LifeLogLimit;
			for (int num = LifeEventLogs.Count - lifeLogLimit; num > 0; num--)
			{
				LifeEventLogs.RemoveLast();
			}
		}

		public void InitAfterLoadPile()
		{
			InitStats();
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprintId);
			serializer.Write("amount", amount);
			serializer.Write("localizedInheritedName", localizedInheritedName);
			serializer.Write("lifeEventLogs", lifeEventLogs);
			serializer.Write("ownerCreationID", ownerCreationID);
			serializer.Write("producerUniqueId", producerUniqueId);
			serializer.Write("stats", stats);
		}

		public ResourceInstance(FVDeserializer deserializer)
		{
			blueprintId = deserializer.ReadString("blueprintId");
			amount = deserializer.ReadInt("amount");
			localizedInheritedName = deserializer.ReadString("localizedInheritedName");
			lifeEventLogs = deserializer.ReadObjectLinkedList<LifeEventLogStruct>("lifeEventLogs");
			ownerCreationID = deserializer.ReadInt("ownerCreationID");
			producerUniqueId = deserializer.ReadInt("producerUniqueId");
			stats = deserializer.ReadObject<StatsInstance>("stats");
		}
	}
}
