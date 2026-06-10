using System;
using System.Collections.Generic;
using Controller;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("FishMapResourceInstance", "")]
	public class FishMapResourceInstance : MapResourceInstance
	{
		private FishMapResource blueprint;

		[SerializeField]
		private readonly List<Vec3Int> positions;

		[SerializeField]
		private int fishRemaining;

		[SerializeField]
		private int daysUntilDeath;

		public override bool BlueprintExists => Blueprint != null;

		public int FishRemaining => fishRemaining;

		public FishMapResource Blueprint => blueprint = ((blueprint == null) ? Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(blueprintId) : blueprint);

		public override List<Vec3Int> Positions => positions;

		public FishMapResourceInstance(FishMapResource blueprint, string prefabId, Vector3 worldPosition, int daysUntilDeath)
			: base(blueprint.GetID(), prefabId, worldPosition, GridDataType.FishMapResource)
		{
			this.blueprint = blueprint;
			fishRemaining = this.blueprint.FishingCount;
			SetStats(ResourceStatsProducer.ProduceMapResourceStats(this, 100f));
			base.Stats.Controller.RegisterListener(StatEventType.MinimumValueReached, StatType.Health, HealthDepletedListener);
			if (positions == null)
			{
				positions = new List<Vec3Int>();
			}
			positions.Clear();
			positions.Add(GridUtils.GetGridPosition(worldPosition));
			this.daysUntilDeath = daysUntilDeath;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<FishRegrowController>.Instance.OnFishInstantiated(this);
		}

		public void SetCloneData(FishMapResourceInstance original)
		{
			base.Stats.CopyValues(original.Stats);
			daysUntilDeath = original.daysUntilDeath;
			fishRemaining = original.fishRemaining;
		}

		public override MapResource GetBlueprint()
		{
			return Blueprint;
		}

		public override OrderType GetPossibleOrders()
		{
			return OrderType.Fishing;
		}

		public override bool OnOrderFail(OrderType order)
		{
			return true;
		}

		public override HarvestParametars GetMiningParameters()
		{
			return Blueprint.GetMiningParameters();
		}

		public override List<ResourceInstance> GetAvailableResources(OrderType orders = OrderType.None)
		{
			return Blueprint.StoredResources;
		}

		public override void ReInstantiate()
		{
			blueprint = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(blueprintId);
			SetStats(ResourceStatsProducer.ProduceMapResourceStats(this, 100f));
			base.Stats.Controller.RegisterListener(StatEventType.MinimumValueReached, StatType.Health, HealthDepletedListener);
			base.ReInstantiate();
			SetCurrentOrder(base.CurrentOrder, afterLoading: true);
			if (daysUntilDeath == 0 && !base.HasDisposed)
			{
				daysUntilDeath = Blueprint.Lifespan + new System.Random().Next(Blueprint.LifespanRandomRange.Min, Blueprint.LifespanRandomRange.Max);
			}
			MonoSingleton<FishRegrowController>.Instance.OnFishInstantiated(this);
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
		}

		private void HealthDepletedListener(object stat)
		{
			OnHealthDepleted();
		}

		public void OnFishCatch()
		{
			fishRemaining--;
			if (fishRemaining <= 0)
			{
				Dispose();
			}
		}

		public override bool ShouldFailHarvest(HarvestParametars parameters, IHarvestAgent harvestAgent)
		{
			AttributeType failStat = parameters.FailStat;
			float attributeValue = harvestAgent.GetAttributeValue(AttributeType.Clumsiness);
			float chanceToFail = Blueprint.ChanceToFail;
			float num = UnityEngine.Random.Range(0f, 1f) / attributeValue;
			float num2 = chanceToFail + harvestAgent.GetAttributeValue(failStat);
			return num < num2;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Stats.Controller.RemoveListener(HealthDepletedListener);
				base.Stats?.Dispose();
				if (MonoSingleton<FishResourceController>.IsInstantiated())
				{
					MonoSingleton<FishResourceController>.Instance.DestroyResource(this);
				}
				if (MonoSingleton<FishRegrowController>.IsInstantiated())
				{
					MonoSingleton<FishRegrowController>.Instance.OnFishDestroyed(this);
				}
				if (MonoSingleton<WorldTimeManager>.IsInstantiated())
				{
					MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				}
				base.Dispose();
			}
		}

		public void WaterDepleted()
		{
			(base.Stats?.GetStat(StatType.Health))?.SetCurrent(0f);
		}

		private void OnHealthDepleted()
		{
			foreach (ResourceInstance availableResource in GetAvailableResources())
			{
				int num = (int)Math.Ceiling((float)availableResource.Amount * 0.1f);
				if (num == 0)
				{
					num = 1;
				}
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(availableResource.Blueprint, num), GetPosition(), forbidOnInit: true);
			}
			Dispose();
		}

		private void OnDateUpdate()
		{
			daysUntilDeath--;
			if (daysUntilDeath <= 0)
			{
				Dispose();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("positions", positions);
			serializer.Write("fishRemaining", fishRemaining);
			serializer.Write("daysUntilDeath", daysUntilDeath);
		}

		public FishMapResourceInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			positions = deserializer.ReadObjectList<Vec3Int>("positions");
			fishRemaining = deserializer.ReadInt("fishRemaining");
			daysUntilDeath = deserializer.ReadInt("daysUntilDeath");
		}
	}
}
