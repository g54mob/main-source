using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class LinearSpringData : DronePartData
	{
		public int Strength { get; set; }

		public int Delta { get; set; }
	}
}
