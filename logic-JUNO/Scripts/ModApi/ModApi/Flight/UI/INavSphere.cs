using System;
using ModApi.Craft;
using UnityEngine;

namespace ModApi.Flight.UI
{
	public interface INavSphere
	{
		float Heading { get; }

		bool HeadingLocked { get; }

		NavSphereIndicatorType? LockedIndicator { get; set; }

		Vector3d? ManeuverNodeDirection { get; set; }

		float Pitch { get; }

		INavSphereTarget Target { get; set; }

		double VelocityMagnitude { get; }

		NavSphereVelocityMode VelocityMode { get; set; }

		Vector3d? GetVector(NavSphereIndicatorType vector);

		Func<NavSphereIndicatorType, Vector3d?> GetVectorFunc();

		void LockCurrentHeading();

		void LockCraftHeading(Vector3d headingDirection, ICraftNode craft);

		void LockHeading(float pitch, float heading, ICraftNode craft = null);

		void LockHeading(Vector3d headingDirection);

		void ToggleLock(NavSphereIndicatorType mode);

		void ToggleProgradeLock();

		void ToggleRetrogradeLock();

		void ToggleTargetLock();

		void UnlockCraftHeading(ICraftNode craft);

		void UnlockHeading();
	}
}
