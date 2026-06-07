using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public class EnemyWeaponBombTarget : EnemyLaserWeaponTarget
	{
		public BombScript Bomb { get; private set; }

		public override bool IsDead
		{
			get
			{
				if (!base.IsDead)
				{
					return Bomb.IsDestroyed;
				}
				return true;
			}
		}

		public EnemyWeaponBombTarget(BombScript bomb, ExclusiveLock exclusiveLock = null)
			: base(bomb.PartScript.Body.RigidBody, exclusiveLock)
		{
			Bomb = bomb;
		}

		public override void Explode()
		{
			Bomb.Detonate(Vector3.up);
		}
	}
}
