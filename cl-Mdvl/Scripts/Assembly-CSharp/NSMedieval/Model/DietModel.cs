using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DietModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float multiplierInsideHomeArea = 1f;

		[SerializeField]
		private float multiplierOutsideHomeArea = 1f;

		[SerializeField]
		private float multiplierWildInsideHomeArea = 1f;

		[SerializeField]
		private float multiplierWildOutsideHomeArea = 1f;

		[SerializeField]
		private List<DietModelResource> dietResources;

		private object canConsumeThreadLock = new object();

		private float maxPriority = -1f;

		private bool hasPlantsInit;

		private bool hasPlants;

		private Dictionary<Resource, bool> canConsumeResourcePileCache = new Dictionary<Resource, bool>();

		private Dictionary<PlantMapResource, bool> canConsumeResourcePlantCache = new Dictionary<PlantMapResource, bool>();

		public List<DietModelResource> DietResources => dietResources;

		public float MaxPriority
		{
			get
			{
				if (maxPriority < 0f)
				{
					foreach (DietModelResource dietResource in dietResources)
					{
						if (dietResource.Priority > maxPriority)
						{
							maxPriority = dietResource.Priority;
						}
					}
				}
				return maxPriority;
			}
		}

		public bool HasPlants
		{
			get
			{
				if (!hasPlantsInit)
				{
					hasPlantsInit = true;
					hasPlants = dietResources.Any((DietModelResource res) => res.Type == DietModelResource.DietResourceType.Plant);
				}
				return hasPlants;
			}
		}

		public override string GetID()
		{
			return id;
		}

		public bool CanConsume(ResourceInstance resourceInstance)
		{
			return CanConsume(resourceInstance.Blueprint);
		}

		public bool CanConsume(ResourcePileInstance resourcePile)
		{
			return CanConsume(resourcePile.Blueprint);
		}

		public bool CanConsume(PlantMapResourceInstance plantMapResource)
		{
			if (canConsumeResourcePlantCache.ContainsKey(plantMapResource.Blueprint))
			{
				return canConsumeResourcePlantCache[plantMapResource.Blueprint];
			}
			bool result;
			foreach (DietModelResource dietResource in dietResources)
			{
				if (!dietResource.CanConsume(plantMapResource))
				{
					continue;
				}
				lock (canConsumeThreadLock)
				{
					if (!canConsumeResourcePlantCache.ContainsKey(plantMapResource.Blueprint))
					{
						canConsumeResourcePlantCache.Add(plantMapResource.Blueprint, value: true);
					}
				}
				result = true;
				goto IL_00fb;
			}
			lock (canConsumeThreadLock)
			{
				if (canConsumeResourcePlantCache.ContainsKey(plantMapResource.Blueprint))
				{
					canConsumeResourcePlantCache[plantMapResource.Blueprint] = false;
					result = false;
					goto IL_00fb;
				}
				canConsumeResourcePlantCache.Add(plantMapResource.Blueprint, value: false);
			}
			return false;
			IL_00fb:
			return result;
		}

		public float GetPriority(ResourcePileInstance resourcePile, bool isInHomeArea, bool isWildAnimal)
		{
			foreach (DietModelResource dietResource in dietResources)
			{
				if (dietResource.CanConsume(resourcePile))
				{
					if (isInHomeArea)
					{
						return dietResource.Priority * (isWildAnimal ? multiplierWildInsideHomeArea : multiplierInsideHomeArea);
					}
					return dietResource.Priority * (isWildAnimal ? multiplierWildOutsideHomeArea : multiplierOutsideHomeArea);
				}
			}
			return 0f;
		}

		public float GetPriority(ResourceInstance resourceInstance, bool isInHomeArea)
		{
			foreach (DietModelResource dietResource in dietResources)
			{
				if (dietResource.CanConsume(resourceInstance))
				{
					if (isInHomeArea)
					{
						return dietResource.Priority * multiplierInsideHomeArea;
					}
					return dietResource.Priority * multiplierOutsideHomeArea;
				}
			}
			return 0f;
		}

		public float GetPriority(PlantMapResourceInstance plantMapResource, bool isInHomeArea, bool isWildAnimal)
		{
			foreach (DietModelResource dietResource in dietResources)
			{
				if (dietResource.CanConsume(plantMapResource))
				{
					if (isInHomeArea)
					{
						return dietResource.Priority * (isWildAnimal ? multiplierWildInsideHomeArea : multiplierInsideHomeArea);
					}
					return dietResource.Priority * (isWildAnimal ? multiplierWildOutsideHomeArea : multiplierOutsideHomeArea);
				}
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanConsume(Resource resourceBlueprint)
		{
			lock (canConsumeThreadLock)
			{
				if (canConsumeResourcePileCache.ContainsKey(resourceBlueprint))
				{
					return canConsumeResourcePileCache[resourceBlueprint];
				}
				foreach (DietModelResource dietResource in dietResources)
				{
					if (dietResource.CanConsume(resourceBlueprint))
					{
						canConsumeResourcePileCache.Add(resourceBlueprint, value: true);
						return true;
					}
				}
				if (canConsumeResourcePileCache.ContainsKey(resourceBlueprint))
				{
					canConsumeResourcePileCache[resourceBlueprint] = false;
					return false;
				}
				canConsumeResourcePileCache.Add(resourceBlueprint, value: false);
				return false;
			}
		}
	}
}
