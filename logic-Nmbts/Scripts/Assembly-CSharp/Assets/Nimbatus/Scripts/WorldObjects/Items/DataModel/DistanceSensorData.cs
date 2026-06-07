using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class DistanceSensorData : SensorPartData
	{
		public float Range { get; set; }

		public ESensorDetectionType DetectionType { get; set; }

		public bool HideSensor { get; set; }
	}
}
