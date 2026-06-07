using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class TemperatureProbeData : SensorPartData
	{
		public ETemperatureProbeDetectionType DetectionType { get; set; }

		public int MinTemp { get; set; }

		public int MaxTemp { get; set; }

		public bool HideSensor { get; set; }
	}
}
