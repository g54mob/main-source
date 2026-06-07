using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class SpringData : DronePartData
	{
		public int Strength { get; set; }

		public bool Linear { get; set; }
	}
}
