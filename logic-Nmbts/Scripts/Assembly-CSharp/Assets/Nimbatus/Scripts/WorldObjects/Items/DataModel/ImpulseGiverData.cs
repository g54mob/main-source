using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class ImpulseGiverData : SensorPartData
	{
		public float ActiveTime { get; set; }

		public float PauseTime { get; set; }
	}
}
