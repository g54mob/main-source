using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class TriggerImpulsePartData : SensorPartData
	{
		public float Delay { get; set; }

		public float ActiveTime { get; set; }
	}
}
