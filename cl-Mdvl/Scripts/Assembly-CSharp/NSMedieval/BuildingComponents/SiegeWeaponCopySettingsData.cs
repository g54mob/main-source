using NSMedieval.Serialization;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("SiegeWeaponCopySettingsData", "")]
	public class SiegeWeaponCopySettingsData : IFVSerializable
	{
		[SerializeField]
		private readonly ResourcesFilter resourcesFilter;

		[SerializeField]
		private readonly BaseBuildingInstance targetBuilding;

		public ResourcesFilter ResourcesFilter => resourcesFilter;

		public BaseBuildingInstance TargetBuilding => targetBuilding;

		public SiegeWeaponCopySettingsData(SiegeWeaponComponentInstance siegeWeaponComponentInstance)
		{
			resourcesFilter = siegeWeaponComponentInstance.ResourcesFilter.DeepCopy();
			targetBuilding = null;
		}

		public SiegeWeaponCopySettingsData(ResourcesFilter resourcesFilter, BaseBuildingInstance targetBuilding)
		{
			this.resourcesFilter = resourcesFilter;
			this.targetBuilding = targetBuilding;
		}

		public SiegeWeaponCopySettingsData DeepCopy()
		{
			return new SiegeWeaponCopySettingsData(resourcesFilter.DeepCopy(), targetBuilding);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("resourcesFilter", resourcesFilter);
			serializer.Write("targetBuilding", targetBuilding);
		}

		public SiegeWeaponCopySettingsData(FVDeserializer deserializer)
		{
			resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
			targetBuilding = deserializer.ReadObject<BaseBuildingInstance>("targetBuilding");
		}
	}
}
