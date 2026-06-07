using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class ProximitySensorData : SensorPartData
	{
		public ESensorDetectionType DetectionType { get; set; }

		public float Range { get; set; }

		public float Angle { get; set; }

		public bool HideSensor { get; set; }
	}
}
