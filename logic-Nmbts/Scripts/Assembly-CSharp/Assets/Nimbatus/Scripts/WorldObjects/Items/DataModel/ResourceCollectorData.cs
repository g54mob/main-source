using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class ResourceCollectorData : BindableDronePartData
	{
		public EWeaponRotation RotationMode { get; set; }
	}
}
