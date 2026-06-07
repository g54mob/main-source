using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class RotatingMeleeWeaponData : BindableDronePartData
	{
		public ERotatingMeleeWeaponMode RotationMode { get; set; }
	}
}
