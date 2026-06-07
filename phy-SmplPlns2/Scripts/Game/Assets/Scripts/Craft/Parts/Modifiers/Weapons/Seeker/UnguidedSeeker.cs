using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public class UnguidedSeeker : IMissileSeeker
	{
		public string FireMessage => null;

		public SignatureType SignatureType => SignatureType.None;

		public UnguidedSeeker(MissileScript missile)
		{
		}

		public void AcquireTarget(TargetingSystem targetingSystem, TrackedTarget trackedTarget, float deltaTime)
		{
		}

		public bool CanFire(TargetingSystem targetingSystem, TrackedTarget trackedTarget)
		{
			return true;
		}

		public bool GetSuitabilityForTarget(TrackedTarget trackedTarget)
		{
			return true;
		}

		public bool MaintainLock()
		{
			return false;
		}
	}
}
