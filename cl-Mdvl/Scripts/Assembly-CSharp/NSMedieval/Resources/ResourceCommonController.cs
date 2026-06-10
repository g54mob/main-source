using System;
using System.Collections.Generic;
using NSMedieval.Components;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Resources
{
	public class ResourceCommonController : MapResourceController<ResourceCommonController, DigMarkerResourceInstance>
	{
		public event Action<MapResourceInstance> OnOrderChangedEvent;

		public event Action OnGroupUpdatedEvent;

		public event Action OnResourceGroupItemUpdate;

		public event Action<ResourceInstance, Storage> ResourceAddedToStorageEvent;

		public event Action<ResourceInstance, Storage> ResourceRemovedFromStorageEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnOrderChangedEvent = null;
			this.OnGroupUpdatedEvent = null;
			this.OnResourceGroupItemUpdate = null;
			this.ResourceRemovedFromStorageEvent = null;
			this.ResourceAddedToStorageEvent = null;
		}

		public void OnOrderChanged(MapResourceInstance resource)
		{
			this.OnOrderChangedEvent?.Invoke(resource);
		}

		public void OnGroupUpdated()
		{
			this.OnGroupUpdatedEvent?.Invoke();
		}

		public void OnDrankResource(ResourceInstance resourceInstance, Agent agent)
		{
			if (resourceInstance != null && !resourceInstance.HasDisposed)
			{
				OnAteResource(resourceInstance.Blueprint, agent);
				if (agent.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.WorkerInteraction.HandleConsumedDrinkEvent(resourceInstance);
				}
			}
		}

		public void OnAteResource(ResourceInstance resourceInstance, Agent agent)
		{
			if (resourceInstance != null && !resourceInstance.HasDisposed)
			{
				OnAteResource(resourceInstance.Blueprint, agent);
				if (agent.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.WorkerInteraction.HandleConsumedFoodEvent(resourceInstance);
				}
			}
		}

		public void OnAteResource(Resource resourceBlueprint, Agent agent)
		{
			if (!(resourceBlueprint == null) && agent != null && agent.AgentOwner is IStatsOwner)
			{
				FireOnUsedEffects(resourceBlueprint.OnUseEffects, agent);
			}
		}

		public void OnAtePlantMapResource(PlantMapResourceInstance plant, Agent agent)
		{
			if (plant != null && !(plant.Blueprint == null) && agent.AgentOwner is IStatsOwner)
			{
				FireOnUsedEffects(plant.Blueprint.OnEatEffectors, agent);
			}
		}

		private static void FireOnUsedEffects(IReadOnlyCollection<string> effectors, Agent agent)
		{
			if (effectors == null || effectors.Count == 0)
			{
				return;
			}
			foreach (string effector in effectors)
			{
				((IStatsOwner)agent.AgentOwner).Stats.StartEffector(effector);
			}
		}

		public void ResourceGroupItemUpdate()
		{
			this.OnResourceGroupItemUpdate?.Invoke();
		}

		public void ResourceAddedToStorage(ResourceInstance resource, Storage storage)
		{
			this.ResourceAddedToStorageEvent?.Invoke(resource, storage);
		}

		public void ResourceRemovedFromStorage(ResourceInstance resource, Storage storage)
		{
			this.ResourceRemovedFromStorageEvent?.Invoke(resource, storage);
		}
	}
}
