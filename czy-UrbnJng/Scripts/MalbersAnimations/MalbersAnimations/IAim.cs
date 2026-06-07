using UnityEngine;

namespace MalbersAnimations
{
	public interface IAim : IMLayer
	{
		bool Active { get; set; }

		Vector3 AimDirection { get; }

		Transform MainCamera { get; }

		bool AimingSide { get; }

		RaycastHit AimHit { get; }

		Transform AimTarget { get; set; }

		Transform AimOrigin { get; set; }

		Vector3 AimPoint { get; }

		Transform IgnoreTransform { get; set; }

		float HorizontalAngle { get; }

		float VerticalAngle { get; }

		AimSide AimSide { get; set; }

		void SetTarget(Transform value);

		void ExitAim();

		void EnterAim();

		void CalculateAiming();

		void ClearTarget();
	}
}
