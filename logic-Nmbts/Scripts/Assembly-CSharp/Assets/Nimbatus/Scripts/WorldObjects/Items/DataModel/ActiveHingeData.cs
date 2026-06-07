using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class ActiveHingeData : BindableDronePartData
	{
		public float Angle { get; set; }

		public float Speed { get; set; }
	}
}
