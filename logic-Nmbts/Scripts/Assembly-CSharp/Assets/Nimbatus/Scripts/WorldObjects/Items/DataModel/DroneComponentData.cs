using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class DroneComponentData : DronePartData
	{
		public ECoating Coating { get; set; }
	}
}
