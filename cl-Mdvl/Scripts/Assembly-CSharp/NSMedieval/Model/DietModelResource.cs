using System;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DietModelResource
	{
		public enum DietResourceType
		{
			Resource = 0,
			Group = 1,
			Plant = 2
		}

		[SerializeField]
		private string type;

		[SerializeField]
		private string value;

		[SerializeField]
		private float priority;

		[SerializeField]
		private int[] phases;

		[NonSerialized]
		private DietResourceType typeCache;

		[NonSerialized]
		private bool typeCacheInitialized;

		public DietResourceType Type
		{
			get
			{
				if (!typeCacheInitialized)
				{
					typeCacheInitialized = true;
					typeCache = (DietResourceType)Enum.Parse(typeof(DietResourceType), type, ignoreCase: true);
				}
				return typeCache;
			}
		}

		public float Priority => priority;

		public string Value => value;

		public bool CanConsume(ResourcePileInstance resourcePile)
		{
			if (Type == DietResourceType.Resource)
			{
				return Value.Equals(resourcePile.BlueprintId);
			}
			if (Type == DietResourceType.Group && Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(Value).Contains(resourcePile.Blueprint))
			{
				return true;
			}
			return false;
		}

		public bool CanConsume(ResourceInstance resourceInstance)
		{
			if (Type == DietResourceType.Resource)
			{
				return Value.Equals(resourceInstance.BlueprintId);
			}
			if (Type == DietResourceType.Group && Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(Value).Contains(resourceInstance.Blueprint))
			{
				return true;
			}
			return false;
		}

		public bool CanConsume(Resource resourceBlueprint)
		{
			if (Type == DietResourceType.Resource)
			{
				return Value.Equals(resourceBlueprint.GetID());
			}
			if (Type == DietResourceType.Group && Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(Value).Contains(resourceBlueprint))
			{
				return true;
			}
			return false;
		}

		public bool CanConsume(PlantMapResourceInstance plantMapResource)
		{
			if (Type == DietResourceType.Plant)
			{
				bool flag = Value.Equals(plantMapResource.BlueprintId);
				if (phases != null)
				{
					if (flag)
					{
						return phases.Contains(plantMapResource.CurrentPhase);
					}
					return false;
				}
				return flag;
			}
			return false;
		}

		public override string ToString()
		{
			return $"{Type}: {Value}";
		}
	}
}
