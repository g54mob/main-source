using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class PistonData : SensorPartData
	{
		public float Distance { get; set; }

		public float Speed { get; set; }
	}
}
