using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public class LaserSeeker : MissileSeeker
	{
		public override SignatureType SignatureType => SignatureType.Laser;

		protected override float SeekerSensitivity => 2500f;

		public LaserSeeker(MissileScript missile)
			: base(missile)
		{
		}

		protected override bool CanAcquireTarget(TrackedTarget trackedTarget)
		{
			if (trackedTarget.Target is LaserTarget laserTarget && trackedTarget.IsFriendly && laserTarget.IsActive)
			{
				if (trackedTarget.Angle <= base.Missile.MaxTargetingAngle && trackedTarget.Distance >= base.Missile.MinRange)
				{
					return trackedTarget.Distance <= base.Missile.MaxRange;
				}
				return false;
			}
			return false;
		}
	}
}
