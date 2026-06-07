using Assets.Scripts.Craft;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public abstract class EnemyLaserWeaponTarget : EnemyWeaponTarget
	{
		public EnemyLaserWeaponTarget(IRigidBody rigidbody, ExclusiveLock exclusiveLock)
			: base(rigidbody, exclusiveLock)
		{
		}

		public abstract void Explode();
	}
}
