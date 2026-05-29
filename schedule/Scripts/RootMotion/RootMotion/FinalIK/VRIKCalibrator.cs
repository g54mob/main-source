using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	public static class VRIKCalibrator
	{
		[Serializable]
		public class Settings
		{
			[Tooltip("Multiplies character scale")]
			public float scaleMlp;

			[Tooltip("Local axis of the HMD facing forward.")]
			public Vector3 headTrackerForward;

			[Tooltip("Local axis of the HMD facing up.")]
			public Vector3 headTrackerUp;

			[Tooltip("Local axis of the hand trackers pointing from the wrist towards the palm.")]
			public Vector3 handTrackerForward;

			[Tooltip("Local axis of the hand trackers pointing in the direction of the surface normal of the back of the hand.")]
			public Vector3 handTrackerUp;

			[Tooltip("Local axis of the foot trackers towards the player's forward direction.")]
			public Vector3 footTrackerForward;

			[Tooltip("Local axis of the foot tracker towards the up direction.")]
			public Vector3 footTrackerUp;

			[Tooltip("Offset of the head bone from the HMD in (headTrackerForward, headTrackerUp) space relative to the head tracker.")]
			[Space(10f)]
			public Vector3 headOffset;

			[Tooltip("Offset of the hand bones from the hand trackers in (handTrackerForward, handTrackerUp) space relative to the hand trackers.")]
			public Vector3 handOffset;

			[Tooltip("Forward offset of the foot bones from the foot trackers.")]
			public float footForwardOffset;

			[Tooltip("Inward offset of the foot bones from the foot trackers.")]
			public float footInwardOffset;

			[Tooltip("Used for adjusting foot heading relative to the foot trackers.")]
			[Range(-180f, 180f)]
			public float footHeadingOffset;

			[Range(0f, 1f)]
			public float pelvisPositionWeight;

			[Range(0f, 1f)]
			public float pelvisRotationWeight;
		}

		[Serializable]
		public class CalibrationData
		{
			[Serializable]
			public class Target
			{
				public bool used;

				public Vector3 localPosition;

				public Quaternion localRotation;

				public Target(Transform t)
				{
				}

				public void SetTo(Transform t)
				{
				}
			}

			public float scale;

			public Target head;

			public Target leftHand;

			public Target rightHand;

			public Target pelvis;

			public Target leftFoot;

			public Target rightFoot;

			public Target leftLegGoal;

			public Target rightLegGoal;

			public Vector3 pelvisTargetRight;

			public float pelvisPositionWeight;

			public float pelvisRotationWeight;
		}

		public static void RecalibrateScale(VRIK ik, CalibrationData data, Settings settings)
		{
		}

		public static void RecalibrateScale(VRIK ik, CalibrationData data, float scaleMlp)
		{
		}

		private static void CalibrateScale(VRIK ik, Settings settings)
		{
		}

		private static void CalibrateScale(VRIK ik, float scaleMlp = 1f)
		{
		}

		public static CalibrationData Calibrate(VRIK ik, Settings settings, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
		{
			return null;
		}

		private static void CalibrateLeg(Settings settings, Transform tracker, IKSolverVR.Leg leg, Transform lastBone, Vector3 rootForward, bool isLeft)
		{
		}

		public static void Calibrate(VRIK ik, CalibrationData data, Transform headTracker, Transform bodyTracker = null, Transform leftHandTracker = null, Transform rightHandTracker = null, Transform leftFootTracker = null, Transform rightFootTracker = null)
		{
		}

		private static void CalibrateLeg(CalibrationData data, Transform tracker, IKSolverVR.Leg leg, Transform lastBone, Vector3 rootForward, bool isLeft)
		{
		}

		public static CalibrationData Calibrate(VRIK ik, Transform centerEyeAnchor, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 centerEyePositionOffset, Vector3 centerEyeRotationOffset, Vector3 handPositionOffset, Vector3 handRotationOffset, float scaleMlp = 1f)
		{
			return null;
		}

		public static void CalibrateHead(VRIK ik, Transform centerEyeAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
		{
		}

		public static void CalibrateBody(VRIK ik, Transform pelvisTracker, Vector3 trackerPositionOffset, Vector3 trackerRotationOffset)
		{
		}

		public static void CalibrateHands(VRIK ik, Transform leftHandAnchor, Transform rightHandAnchor, Vector3 anchorPositionOffset, Vector3 anchorRotationOffset)
		{
		}

		private static void CalibrateHand(VRIK ik, Transform anchor, Vector3 positionOffset, Vector3 rotationOffset, bool isLeft)
		{
		}

		public static Vector3 GuessWristToPalmAxis(Transform hand, Transform forearm)
		{
			return default(Vector3);
		}

		public static Vector3 GuessPalmToThumbAxis(Transform hand, Transform forearm)
		{
			return default(Vector3);
		}
	}
}
