using Assets.Scripts.Input.XR;
using UnityEngine;

namespace Assets.Scripts.XR.HandPoses
{
	public interface IGripTarget
	{
		XRControlGripType GripType { get; }

		GripPose Pose { get; }

		bool SnapHandPositionToTarget { get; }

		bool SnapHandRotationToTarget { get; }

		Transform TargetTransform { get; }

		string GetOverrideControlBinding(string controlId);

		void OnGripAttached(FlightHand hand);

		void OnGripDetached(FlightHand hand);

		void OnGripUpdate(FlightHand hand);
	}
}
