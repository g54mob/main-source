using NSMedieval.Construction;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("FuelConsumerCopySettingsData", "")]
	public class FuelConsumerCopySettingsData : IFVSerializable
	{
		[SerializeField]
		private readonly ResourcesFilter resourcesFilter;

		[SerializeField]
		private readonly ZonePriority refuelPriority;

		[SerializeField]
		private readonly TorchState torchState;

		[SerializeField]
		private readonly bool turnedOff;

		[SerializeField]
		private ThermalModelIntensity thermalModelIntensity;

		[SerializeField]
		private readonly BaseBuildingInstance targetBuilding;

		public ResourcesFilter ResourcesFilter => resourcesFilter;

		public ZonePriority RefuelPriority => refuelPriority;

		public TorchState TorchState => torchState;

		public bool TurnedOff => turnedOff;

		public ThermalModelIntensity ThermalModelIntensity => thermalModelIntensity;

		public BaseBuildingInstance TargetBuilding => targetBuilding;

		public FuelConsumerCopySettingsData(FuelConsumerComponentInstance fcci)
		{
			resourcesFilter = fcci.ResourcesFilter.DeepCopy();
			refuelPriority = fcci.RefuelPriority;
			torchState = fcci.TorchState;
			turnedOff = fcci.TurnedOff;
			thermalModelIntensity = fcci.ThermalModelIntensity;
			targetBuilding = null;
		}

		public FuelConsumerCopySettingsData(ResourcesFilter resourcesFilter, ZonePriority refuelPriority, TorchState torchState, bool turnedOff, ThermalModelIntensity thermalModelIntensity, BaseBuildingInstance targetBuilding)
		{
			this.resourcesFilter = resourcesFilter;
			this.refuelPriority = refuelPriority;
			this.torchState = torchState;
			this.turnedOff = turnedOff;
			this.thermalModelIntensity = thermalModelIntensity;
			this.targetBuilding = targetBuilding;
		}

		public FuelConsumerCopySettingsData DeepCopy()
		{
			return new FuelConsumerCopySettingsData(resourcesFilter.DeepCopy(), refuelPriority, torchState, turnedOff, thermalModelIntensity, targetBuilding);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("resourcesFilter", resourcesFilter);
			serializer.WriteEnum("refuelPriority", refuelPriority);
			serializer.WriteEnum("torchState", torchState);
			serializer.WriteEnum("thermalModelIntensity", thermalModelIntensity);
			serializer.Write("turnedOff", turnedOff);
			serializer.Write("targetBuilding", targetBuilding);
		}

		public FuelConsumerCopySettingsData(FVDeserializer deserializer)
		{
			resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
			refuelPriority = deserializer.ReadEnum("refuelPriority", ZonePriority.None);
			torchState = deserializer.ReadEnum("torchState", TorchState.Off);
			turnedOff = deserializer.ReadBool("turnedOff");
			thermalModelIntensity = deserializer.ReadEnum("thermalModelIntensity", ThermalModelIntensity.Off);
			targetBuilding = deserializer.ReadObject<BaseBuildingInstance>("targetBuilding");
		}
	}
}
