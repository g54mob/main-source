using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class AltimeterData : SensorPartData
	{
		public int Altitude { get; set; }

		public int Tolerance { get; set; }
	}
}
