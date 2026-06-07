using System;
using System.Xml.Serialization;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	[XmlInclude(typeof(DronePartData))]
	[XmlInclude(typeof(ResourceCollectorData))]
	[XmlInclude(typeof(BindableDronePartData))]
	[XmlInclude(typeof(DroneComponentData))]
	[XmlInclude(typeof(TemperatureRegulatorData))]
	[XmlInclude(typeof(AltimeterData))]
	[XmlInclude(typeof(BufferPartData))]
	[XmlInclude(typeof(DistanceSensorData))]
	[XmlInclude(typeof(GravitySensorData))]
	[XmlInclude(typeof(ImpulseGiverData))]
	[XmlInclude(typeof(LEDPartData))]
	[XmlInclude(typeof(MagnetData))]
	[XmlInclude(typeof(SensorPartData))]
	[XmlInclude(typeof(SpringData))]
	[XmlInclude(typeof(SpeedSensorData))]
	[XmlInclude(typeof(TemperatureSensorData))]
	[XmlInclude(typeof(DynamicThrusterData))]
	[XmlInclude(typeof(WeaponData))]
	[XmlInclude(typeof(TriggerImpulsePartData))]
	[XmlInclude(typeof(FactoryPartData))]
	[XmlInclude(typeof(MotorizedHingeData))]
	[XmlInclude(typeof(DelayPartData))]
	[XmlInclude(typeof(ProximitySensorData))]
	[XmlInclude(typeof(RngGateData))]
	[XmlInclude(typeof(VtolThrusterData))]
	[XmlInclude(typeof(ExplosiveData))]
	[XmlInclude(typeof(PistonData))]
	[XmlInclude(typeof(RotatingMeleeWeaponData))]
	[XmlInclude(typeof(ActiveHingeData))]
	[XmlInclude(typeof(TemperatureProbeData))]
	[XmlInclude(typeof(AudioPartData))]
	[XmlInclude(typeof(WheelPartData))]
	[XmlInclude(typeof(LinearSpringData))]
	[XmlInclude(typeof(GrapplingHookData))]
	[XmlInclude(typeof(BallastTankData))]
	public class NimbatusItemData
	{
		public string PrefabId { get; set; }

		public string PersistentId { get; set; }
	}
}
