using System;
using System.Linq;
using Models.Production;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepPassive", "")]
	public class ProductionStepPassive : ProductionStepInstance
	{
		[SerializeField]
		private float timePassed;

		[SerializeField]
		private SerializableAttributeDictionary lastAgentAttributes;

		public override float Progress
		{
			get
			{
				if (!(timePassed <= 0f))
				{
					return timePassed / base.Blueprint.ProductionTime;
				}
				return 0f;
			}
		}

		public float TimePassed => timePassed;

		public SerializableAttributeDictionary LastAgentAttributes => lastAgentAttributes;

		public ProductionStepPassive()
			: base(ProductionStepType.PassiveProduce)
		{
		}

		public void DebugAddTime(float time)
		{
			OnTick(time);
		}

		internal override void OnBecomeActive()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.StartProductionProgressEffect();
			}
			if ((base.OwnerProductionInstance.Steps.FirstOrDefault((ProductionStepInstance item) => item.Type == ProductionStepType.WorkerProduce && item.IsCompleted) as ProductionStepWorker)?.LastAgent is IStatsOwner statsOwner)
			{
				lastAgentAttributes = statsOwner.Stats.AttributesSerDict;
			}
			base.OnBecomeActive();
		}

		internal override void OnBecomeInactive()
		{
			MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.FinishProductionProgressEffect();
			}
			base.OnBecomeInactive();
		}

		internal override void Reset()
		{
			timePassed = 0f;
			lastAgentAttributes = null;
			base.Reset();
		}

		private void OnTick(float delta)
		{
			if (delta <= 0f || base.HasDisposed)
			{
				return;
			}
			timePassed += delta * ProductionUtils.CalculateProductionSpeedMultiplier(base.OwnerProductionInstance.OwnerProductionComponentInstance) * MonoSingleton<ProductionManager>.Instance.GlobalSpeedMultiplier;
			if (timePassed < base.Blueprint.ProductionTime)
			{
				ProductionComponent productionComponent = GetProductionComponent();
				if (productionComponent != null)
				{
					productionComponent.UpdateProductionCircle();
				}
			}
			else
			{
				timePassed = base.Blueprint.ProductionTime;
				Complete();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("timePassed", timePassed);
			serializer.Write("lastAgentAttributes", lastAgentAttributes);
		}

		public ProductionStepPassive(FVDeserializer deserializer)
			: base(deserializer)
		{
			timePassed = deserializer.ReadFloat("timePassed");
			lastAgentAttributes = deserializer.ReadObject<SerializableAttributeDictionary>("lastAgentAttributes");
		}
	}
}
