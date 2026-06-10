using System.Collections.Generic;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("ShelfCopySettingsData", "")]
	public class ShelfCopySettingsData : IFVSerializable
	{
		[SerializeField]
		private readonly List<ResourcesFilter> resourceFilters;

		[SerializeField]
		private readonly bool isForbidden;

		[SerializeField]
		private readonly ZonePriority priority;

		[SerializeField]
		private readonly BaseBuildingInstance targetBuilding;

		public List<ResourcesFilter> ResourceFilters => resourceFilters;

		public bool IsForbidden => isForbidden;

		public ZonePriority Priority => priority;

		public BaseBuildingInstance TargetBuilding => targetBuilding;

		public ShelfCopySettingsData(List<ResourcesFilter> resourceFilters, bool isForbidden, ZonePriority priority, BaseBuildingInstance targetBuilding)
		{
			this.resourceFilters = resourceFilters;
			this.isForbidden = isForbidden;
			this.priority = priority;
			this.targetBuilding = targetBuilding;
		}

		public ShelfCopySettingsData DeepCopy()
		{
			List<ResourcesFilter> list = new List<ResourcesFilter>();
			foreach (ResourcesFilter resourceFilter in resourceFilters)
			{
				list.Add(resourceFilter.DeepCopy());
			}
			return new ShelfCopySettingsData(list, isForbidden, priority, targetBuilding);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("resourceFilters", resourceFilters);
			serializer.Write("isForbidden", isForbidden);
			serializer.WriteEnum("priority", priority);
			serializer.Write("targetBuilding", targetBuilding);
		}

		public ShelfCopySettingsData(FVDeserializer deserializer)
		{
			ResourcesFilter resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
			resourceFilters = deserializer.ReadObjectList<ResourcesFilter>("resourceFilters");
			isForbidden = deserializer.ReadBool("isForbidden");
			priority = deserializer.ReadEnum("priority", ZonePriority.None);
			targetBuilding = deserializer.ReadObject<BaseBuildingInstance>("targetBuilding");
			if (resourceFilters == null)
			{
				resourceFilters = new List<ResourcesFilter>();
				if (resourcesFilter != null)
				{
					resourceFilters.Add(resourcesFilter);
				}
			}
			else if (resourceFilters.Count == 0 && resourcesFilter != null)
			{
				resourceFilters.Add(resourcesFilter);
			}
		}
	}
}
