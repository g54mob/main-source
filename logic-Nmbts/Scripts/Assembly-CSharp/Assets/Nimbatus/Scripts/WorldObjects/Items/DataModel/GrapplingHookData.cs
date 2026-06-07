using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	public class GrapplingHookData : SensorPartData
	{
		public int Strength { get; set; }

		public EWeaponRotation Rotation { get; set; }

		public EGrapplingHookTarget Target { get; set; }
	}
}
