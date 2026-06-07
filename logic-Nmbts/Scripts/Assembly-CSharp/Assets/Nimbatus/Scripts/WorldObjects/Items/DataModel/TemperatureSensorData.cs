using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class TemperatureSensorData : SensorPartData
	{
		public int Tolerance { get; set; }
	}
}
