using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class TemperatureRegulatorData : BindableDronePartData
	{
		public int Strength { get; set; }

		public float Radius { get; set; }
	}
}
