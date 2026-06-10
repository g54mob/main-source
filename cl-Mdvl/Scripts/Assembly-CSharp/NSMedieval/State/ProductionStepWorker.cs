using System;
using System.Collections.Generic;
using Models.Production;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepWorker", "")]
	public class ProductionStepWorker : ProductionStepInstance
	{
		public enum ProcessState
		{
			None = 0,
			InProgress = 1,
			Failed = 3
		}

		[NonSerialized]
		private ProcessState state;

		[NonSerialized]
		private IProductionAgent agent;

		[NonSerialized]
		private float speedModifier;

		[SerializeField]
		private float workDone;

		[NonSerialized]
		private float workerEnterProgressDone;

		[NonSerialized]
		private bool xpRewarded;

		[NonSerialized]
		private IProductionAgent lastAgent;

		public ProcessState State => state;

		public override float Progress => Mathf.Clamp((workDone == 0f) ? 0f : (workDone / base.Blueprint.ProductionTime), 0f, 1f);

		public IProductionAgent Agent => agent;

		public float SpeedModifier => speedModifier;

		public float WorkDone => workDone;

		public IProductionAgent LastAgent => lastAgent;

		public ProductionStepWorker()
			: base(ProductionStepType.WorkerProduce)
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			agent = null;
			lastAgent = null;
		}

		public void DebugAddTime(float time)
		{
			Tick(time);
		}

		public float DebugGetPercentDoneByCurrentAgent()
		{
			return GetPercentDoneByCurrentAgent();
		}

		public void AgentEntered(IProductionAgent agent)
		{
			this.agent = agent;
			xpRewarded = false;
			state = ProcessState.None;
			ProductionComponentInstance ownerProductionComponentInstance = base.OwnerProductionInstance.OwnerProductionComponentInstance;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.StartProductionProgressEffect();
			}
			speedModifier = 1f;
			if (base.Blueprint.ModifyingAttribute > AttributeType.None)
			{
				speedModifier = agent.GetAttributeValue(base.Blueprint.ModifyingAttribute);
				speedModifier = ((speedModifier <= 0f) ? 1f : speedModifier);
			}
			NSMedieval.Model.Production production = base.OwnerProductionInstance.Blueprint;
			float attributeValue = agent.GetAttributeValue(AttributeType.GlobalWorkSpeed);
			speedModifier *= ((attributeValue <= 0f) ? 1f : attributeValue);
			float attributeValue2 = agent.GetAttributeValue(AttributeType.MotorFunction);
			speedModifier *= ((attributeValue2 <= 0f || production.JobType == JobType.Research) ? 1f : attributeValue2);
			speedModifier *= ProductionUtils.CalculateProductionSpeedMultiplier(ownerProductionComponentInstance);
			CustomProduct customProduct = production.GetCustomProduct(base.OwnerProductionInstance);
			if (customProduct != null)
			{
				HumanoidInstance obj = agent as HumanoidInstance;
				obj?.Stats.StartEffector(customProduct.OnStartEffector);
				obj?.Stats.StartEffector(customProduct.WhileProducingEffector);
			}
			workerEnterProgressDone = workDone;
		}

		internal override void OnStart()
		{
			base.OnStart();
			if (base.OwnerProductionInstance?.Storage != null)
			{
				base.OwnerProductionInstance.Storage.ResourceTakenEvent += OnStorageChanged;
				base.OwnerProductionInstance.Storage.ResourceDeletedEvent += ResourceDeletedEvent;
			}
		}

		internal override void OnEnd()
		{
			base.OnEnd();
			if (base.OwnerProductionInstance?.Storage != null)
			{
				base.OwnerProductionInstance.Storage.ResourceTakenEvent -= OnStorageChanged;
				base.OwnerProductionInstance.Storage.ResourceDeletedEvent -= ResourceDeletedEvent;
			}
		}

		private void ResourceDeletedEvent(ResourceInstance instance)
		{
			OnStorageChanged(default(SimpleResourceCount));
		}

		private void OnStorageChanged(SimpleResourceCount count)
		{
			base.OwnerProductionInstance.Storage.ResourceTakenEvent -= OnStorageChanged;
			base.OwnerProductionInstance.Storage.ResourceDeletedEvent -= ResourceDeletedEvent;
			base.OwnerProductionInstance.ResetSteps();
		}

		internal override void Reset()
		{
			base.Reset();
			workDone = 0f;
			agent = null;
			lastAgent = null;
			state = ProcessState.None;
			workerEnterProgressDone = 0f;
		}

		internal override void OnBecomeInactive()
		{
			Cancel();
			base.OnBecomeInactive();
		}

		public void Cancel()
		{
			RewardExperience();
			lastAgent = agent;
			agent = null;
			state = ProcessState.None;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.FinishProductionProgressEffect();
			}
		}

		public void Tick(float delta)
		{
			if (base.IsCompleted)
			{
				return;
			}
			if (agent == null || agent.HasDisposed)
			{
				state = ProcessState.Failed;
				return;
			}
			bool num = state == ProcessState.None;
			state = ProcessState.InProgress;
			workDone += delta * speedModifier * MonoSingleton<ProductionManager>.Instance.GlobalSpeedMultiplier;
			if (workDone >= base.Blueprint.ProductionTime)
			{
				Complete();
			}
			if (num)
			{
				base.OwnerProductionInstance.UpdateState();
			}
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.UpdateProductionCircle();
			}
		}

		protected override void Complete()
		{
			if (workDone >= base.Blueprint.ProductionTime)
			{
				RewardExperience();
				ProductionComponent productionComponent = GetProductionComponent();
				if (productionComponent != null)
				{
					productionComponent.FinishProductionProgressEffect(ActionCompletionStatus.Success);
				}
			}
			workDone = 0f;
			base.Complete();
		}

		private void RewardExperience()
		{
			if (agent == null || xpRewarded || workDone - workerEnterProgressDone <= 0f)
			{
				return;
			}
			float percentDoneByCurrentAgent = GetPercentDoneByCurrentAgent();
			if (percentDoneByCurrentAgent <= 0.01f)
			{
				return;
			}
			List<SkillValuePair> experienceReward = base.Blueprint.ExperienceReward;
			if (experienceReward == null || experienceReward.Count == 0)
			{
				return;
			}
			xpRewarded = true;
			foreach (SkillValuePair item in experienceReward)
			{
				agent.AddExperience(item.Key, percentDoneByCurrentAgent * item.Value);
			}
		}

		private float GetPercentDoneByCurrentAgent()
		{
			float num = workDone - workerEnterProgressDone;
			if (num <= 0f)
			{
				return 0f;
			}
			return num / base.Blueprint.ProductionTime;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("workDone", workDone);
		}

		public ProductionStepWorker(FVDeserializer deserializer)
			: base(deserializer)
		{
			workDone = deserializer.ReadFloat("workDone");
		}
	}
}
