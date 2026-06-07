using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public interface ITarget
	{
		Vector3 AngularVelocity { get; }

		bool IsDead { get; }

		float MaxVisibleRange { get; }

		Vector3 Position { get; }

		TargetType TargetType { get; }

		Vector3 Velocity { get; }

		void Alert(bool locked, ITargetLockSource source, TrackedTarget trackedTarget);
	}
}
