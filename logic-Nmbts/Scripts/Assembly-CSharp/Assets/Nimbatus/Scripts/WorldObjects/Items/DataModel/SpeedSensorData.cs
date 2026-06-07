using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class SpeedSensorData : SensorPartData
	{
		public int Tolerance { get; set; }
	}
}
