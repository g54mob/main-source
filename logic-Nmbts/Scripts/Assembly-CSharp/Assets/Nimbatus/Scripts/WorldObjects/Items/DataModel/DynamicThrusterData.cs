using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class DynamicThrusterData : BindableDronePartData
	{
		public float StartForce { get; set; }

		public float ForceChange { get; set; }
	}
}
