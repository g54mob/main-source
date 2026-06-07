using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public interface IMissileSeeker
	{
		string FireMessage { get; }

		void AcquireTarget(TargetingSystem targetingSystem, TrackedTarget trackedTarget, float deltaTime);

		bool CanFire(TargetingSystem targetingSystem, TrackedTarget trackedTarget);

		bool GetSuitabilityForTarget(TrackedTarget trackedTarget);

		bool MaintainLock();
	}
}
