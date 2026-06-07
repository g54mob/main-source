using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class MotorizedHingeData : BindableDronePartData
	{
		public int Speed { get; set; }
	}
}
