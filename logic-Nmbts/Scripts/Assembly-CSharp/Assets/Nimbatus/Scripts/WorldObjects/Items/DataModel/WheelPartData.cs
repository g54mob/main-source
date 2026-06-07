using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class WheelPartData : BindableDronePartData
	{
		public int Speed { get; set; }

		public float Radius { get; set; }

		public ETyre Tyre { get; set; }
	}
}
