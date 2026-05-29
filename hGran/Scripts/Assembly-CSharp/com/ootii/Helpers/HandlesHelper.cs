using UnityEngine;
using com.ootii.Actors.BoneControllers;

namespace com.ootii.Helpers
{
	public class HandlesHelper
	{
		public static float HandleScale;

		public static float Scale;

		public static Color InactiveColor;

		public static float LastFloat;

		public static Vector3[] Vectors;

		public static Quaternion StartRotation;

		public static bool JointSwingHandle(BoneControllerBone rBone, IKBoneModifier rModifier)
		{
			return false;
		}

		public static bool JointSwingHandle(BoneControllerBone rBone, ref Quaternion rSwing)
		{
			return false;
		}

		public static bool JointTwistHandle(BoneControllerBone rBone, IKBoneModifier rModifier)
		{
			return false;
		}

		public static bool JointTwistHandle(BoneControllerBone rBone, ref Quaternion rTwist)
		{
			return false;
		}

		public static bool JointSwingAxisHandle(BoneControllerBone rBone, Vector3 rAxis, ref Quaternion rSwing)
		{
			return false;
		}

		public static bool JointSwingAxisHandle(BoneControllerBone rBone, Vector3 rAxis, IKBoneModifier rModifier)
		{
			return false;
		}

		public static bool JointSwingAxisLimitsHandle(BoneControllerBone rBone, Vector3 rAxis, float rMinAngle, float rMaxAngle)
		{
			return false;
		}

		public static bool JointTwistLimitsHandle(BoneControllerBone rBone, ref float rMinAngle, ref float rMaxAngle)
		{
			return false;
		}

		public static void DrawTransform(Transform rTransform, bool rAutoScale)
		{
		}

		public static void DrawTransform(Vector3 rPosition, Quaternion rRotation, float rAlpha, bool rAutoScale, float rScale = 1f)
		{
		}

		public static void DrawTransform(Vector3 rPosition, Quaternion rRotation, Vector3 rForward, Vector3 rUp, Vector3 rRight, float rAlpha, bool rAutoScale, float rScale = 1f)
		{
		}

		public static void DrawBone(BoneControllerBone rBone, Color rColor)
		{
		}

		public static void DrawBoneCollider(BoneControllerBone rBone, Color rColor)
		{
		}

		public static void DrawSkeleton(BoneController rSkeleton, Color rBoneColor, Color rColliderColor)
		{
		}

		public static void DrawBox(Vector3 rMin, Vector3 rMax, Color rColor)
		{
		}
	}
}
