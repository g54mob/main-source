using System;
using System.Collections.Generic;
using System.Linq;
using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class ResourceContainerController
	{
		private const float RESOURCE_MASS_UPDATE_PERIOD = 120f;

		public readonly List<ResourceContainer> resourceContainers;

		public readonly ResourceMassPortReader[] additionalResourceMassFromComponents;

		private float resourceMassUpdateTimer = 120f;

		private bool hasResourceContainers;

		public bool AreResourcesFull
		{
			get
			{
				if (hasResourceContainers)
				{
					return resourceContainers.All((ResourceContainer rc) => rc.normalizedReadOutPort.Value == 1f);
				}
				return true;
			}
		}

		public event Action UpdateResourcesMass;

		public bool AreResourcesAbovePercentage(float percentage)
		{
			if (hasResourceContainers)
			{
				return resourceContainers.All((ResourceContainer rc) => rc.normalizedReadOutPort.Value > percentage);
			}
			return true;
		}

		public bool IsAbovePercentage(ResourceContainerType resourceType, float percentage)
		{
			ResourceContainer resourceContainer = GetResourceContainer(resourceType);
			if (resourceContainer == null)
			{
				return true;
			}
			return resourceContainer.normalizedReadOutPort.Value > percentage;
		}

		public ResourceContainerController(SimulationFlow simFlow, ResourceMassPortReader[] additionalResourceMassFromComponents)
		{
			resourceContainers = new List<ResourceContainer>();
			for (int i = 0; i < simFlow.OrderedSimComps.Count; i++)
			{
				if (simFlow.OrderedSimComps[i] is ResourceContainer item)
				{
					resourceContainers.Add(item);
				}
			}
			hasResourceContainers = resourceContainers.Count > 0;
			this.additionalResourceMassFromComponents = additionalResourceMassFromComponents;
		}

		public ResourceContainer GetResourceContainer(ResourceContainerType resourceType)
		{
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				if (resourceContainer.resourceType == resourceType)
				{
					return resourceContainer;
				}
			}
			return null;
		}

		public float GetResourcesMass()
		{
			float num = 0f;
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				num += resourceContainer.amountReadOut.Value * resourceContainer.resourceType.GetResourceMassMultiplier();
			}
			if (additionalResourceMassFromComponents != null)
			{
				ResourceMassPortReader[] array = additionalResourceMassFromComponents;
				foreach (ResourceMassPortReader resourceMassPortReader in array)
				{
					num += resourceMassPortReader.Mass;
				}
			}
			return num;
		}

		public void UpdateTimer()
		{
			if (hasResourceContainers)
			{
				resourceMassUpdateTimer -= Time.deltaTime;
				if (resourceMassUpdateTimer < 0f)
				{
					this.UpdateResourcesMass?.Invoke();
					resourceMassUpdateTimer = 120f;
				}
			}
		}

		public void DepleteResourceContainer(ResourceContainerType containerType)
		{
			ResourceContainer resourceContainer = GetResourceContainer(containerType);
			DepleteResourceContainer(resourceContainer);
		}

		public void ClampResourceContainer(ResourceContainerType containerType, float maxFactor)
		{
			ResourceContainer resourceContainer = GetResourceContainer(containerType);
			ClampResourceContainer(resourceContainer, maxFactor);
		}

		public void DepleteAllResourceContainers()
		{
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				DepleteResourceContainer(resourceContainer);
			}
		}

		private void DepleteResourceContainer(ResourceContainer resourceContainer)
		{
			if (resourceContainer == null)
			{
				Debug.LogError("DepleteResourceContainer requires a valid ResourceContainer reference. Skipping...");
				return;
			}
			float value = resourceContainer.amountReadOut.Value;
			resourceContainer.consumeExtIn.ExternalValueUpdate(value);
		}

		private void ClampResourceContainer(ResourceContainer resourceContainer, float maxFactor)
		{
			if (resourceContainer == null)
			{
				Debug.LogError("ClampResourceContainer requires a valid ResourceContainer reference. Skipping...");
				return;
			}
			float value = resourceContainer.amountReadOut.Value;
			float capacity = resourceContainer.capacity;
			float newValue = Mathf.Min(0f, capacity * maxFactor - value);
			resourceContainer.refillExtIn.ExternalValueUpdate(newValue);
		}

		public void RefillResourceContainer(ResourceContainerType containerType)
		{
			ResourceContainer resourceContainer = GetResourceContainer(containerType);
			RefillResourceContainer(resourceContainer);
		}

		public void RefillAllResourceContainers()
		{
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				RefillResourceContainer(resourceContainer);
			}
		}

		private void RefillResourceContainer(ResourceContainer resourceContainer)
		{
			if (resourceContainer == null)
			{
				Debug.LogError("RefillResourceContainer requires a valid ResourceContainer reference. Skipping...");
				return;
			}
			float value = resourceContainer.amountReadOut.Value;
			resourceContainer.refillExtIn.ExternalValueUpdate(resourceContainer.capacity - value);
		}
	}
}
