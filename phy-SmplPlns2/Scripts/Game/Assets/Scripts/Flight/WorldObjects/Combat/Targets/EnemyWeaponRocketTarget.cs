using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.WorldObjects.Combat.Targets
{
	public class EnemyWeaponRocketTarget : EnemyLaserWeaponTarget
	{
		public override bool IsDead
		{
			get
			{
				if (!base.IsDead)
				{
					return Rocket.HasExploded;
				}
				return true;
			}
		}

		public RocketScript Rocket { get; private set; }

		public EnemyWeaponRocketTarget(RocketScript rocket, ExclusiveLock exclusiveLock = null)
			: base(new RigidBodyPhysx(rocket.Rigidbody), exclusiveLock)
		{
			Rocket = rocket;
		}

		public override void Explode()
		{
			Rocket.Explode();
		}
	}
}
