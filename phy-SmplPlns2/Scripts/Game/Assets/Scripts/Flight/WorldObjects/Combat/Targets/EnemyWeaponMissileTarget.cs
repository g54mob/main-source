using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public class EnemyWeaponMissileTarget : EnemyLaserWeaponTarget
	{
		public override bool IsDead
		{
			get
			{
				if (!base.IsDead)
				{
					return Missile.IsDestroyed;
				}
				return true;
			}
		}

		public MissileScript Missile { get; private set; }

		public EnemyWeaponMissileTarget(MissileScript missile, ExclusiveLock exclusiveLock = null)
			: base(missile.PartScript.Body.RigidBody, exclusiveLock)
		{
			Missile = missile;
		}

		public override void Explode()
		{
			Missile.Detonate(Vector3.up);
		}
	}
}
