using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class RngGateData : SensorPartData
	{
		public int Probability { get; set; }
	}
}
