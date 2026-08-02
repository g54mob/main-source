using UnityEngine;

namespace JUTPS.ExtendedInverseKinematics
{
	public static class JUInverseKinematicExtension
	{
		public static void SetLeftHandOn(this Animator anim, Transform IKPositionLeftHand, float IKWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, IKPositionLeftHand.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, IKPositionLeftHand.rotation);
		}

		public static void SetRightHandOn(this Animator anim, Transform IKPositionRightHand, float IKWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightHand, IKPositionRightHand.position);
			anim.SetIKRotation(AvatarIKGoal.RightHand, IKPositionRightHand.rotation);
		}

		public static void SetLeftHandOn(this Animator anim, Transform IKPositionLeftHand, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, IKPositionLeftHand.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, IKPositionLeftHand.rotation);
			anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightElbow, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SetRightHandOn(this Animator anim, Transform IKPositionRightHand, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightHand, IKPositionRightHand.position);
			anim.SetIKRotation(AvatarIKGoal.RightHand, IKPositionRightHand.rotation);
			anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightElbow, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SetLeftFootOn(this Animator anim, Transform IKPositionLeftFoot, float IKWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftFoot, IKPositionLeftFoot.position);
			anim.SetIKRotation(AvatarIKGoal.LeftFoot, IKPositionLeftFoot.rotation);
		}

		public static void SetRightFootOn(this Animator anim, Transform IKPositionRightFoot, float IKWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightFoot, IKPositionRightFoot.position);
			anim.SetIKRotation(AvatarIKGoal.RightFoot, IKPositionRightFoot.rotation);
		}

		public static void SetLeftFootOn(this Animator anim, Transform IKPositionLeftFoot, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftFoot, IKPositionLeftFoot.position);
			anim.SetIKRotation(AvatarIKGoal.LeftFoot, IKPositionLeftFoot.rotation);
			anim.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.LeftKnee, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SetRightFootOn(this Animator anim, Transform IKPositionRightFoot, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightFoot, IKPositionRightFoot.position);
			anim.SetIKRotation(AvatarIKGoal.RightFoot, IKPositionRightFoot.rotation);
			anim.SetIKHintPositionWeight(AvatarIKHint.RightKnee, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightKnee, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SetLeftFootOn(this Animator anim, Vector3 IKPositionLeftFoot, Quaternion IKRotationLeftFoot, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftFoot, IKPositionLeftFoot);
			anim.SetIKRotation(AvatarIKGoal.LeftFoot, IKRotationLeftFoot);
			anim.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.LeftKnee, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SetRightFootOn(this Animator anim, Vector3 IKPositionRightFoot, Quaternion IKRotationRightFoot, float IKWeight, Vector3 HintAjust, float HintWeight)
		{
			anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightFoot, IKPositionRightFoot);
			anim.SetIKRotation(AvatarIKGoal.RightFoot, IKRotationRightFoot);
			anim.SetIKHintPositionWeight(AvatarIKHint.RightKnee, HintWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightKnee, anim.transform.position + anim.transform.right * HintAjust.x + anim.transform.up * HintAjust.y + anim.transform.forward * HintAjust.z);
		}

		public static void SpineInclination(this Animator anim, Vector3 LeanVector, float Weight = 0f)
		{
			LeanVector = Vector3.Lerp(Vector3.zero, LeanVector, Weight);
			Vector3 localEulerAngles = anim.GetBoneTransform(HumanBodyBones.Spine).localEulerAngles;
			Vector3 euler = localEulerAngles;
			euler.x = localEulerAngles.x + LeanVector.x;
			euler.y = localEulerAngles.y + LeanVector.y;
			euler.z = localEulerAngles.z + LeanVector.z;
			Quaternion rotation = Quaternion.Euler(euler);
			anim.SetBoneLocalRotation(HumanBodyBones.Spine, rotation);
		}

		public static void SpineInclination(this Animator anim, Vector3 Direction, float LeanIntensity, float Weight = 1f)
		{
			Direction = Vector3.Lerp(Vector3.zero, Direction, Weight);
			Transform boneTransform = anim.GetBoneTransform(HumanBodyBones.Spine);
			Quaternion rotation = Quaternion.Euler(boneTransform.eulerAngles + Direction * LeanIntensity);
			boneTransform.rotation = rotation;
			anim.SetBoneLocalRotation(HumanBodyBones.Spine, boneTransform.localRotation);
		}

		public static void SpineLookAtUnclamped(this Animator anim, Vector3 position = default(Vector3), float Weight = 1f)
		{
			Transform boneTransform = anim.GetBoneTransform(HumanBodyBones.Spine);
			boneTransform.rotation = Quaternion.LookRotation(position - boneTransform.position);
			boneTransform.parent.rotation = Quaternion.Lerp(boneTransform.parent.rotation, boneTransform.rotation, 0.5f * Weight);
			anim.SetBoneLocalRotation(HumanBodyBones.Spine, boneTransform.localRotation);
		}

		public static void HeadLookAtUnclamped(this Animator anim, Vector3 position = default(Vector3), float Weight = 1f)
		{
			Transform boneTransform = anim.GetBoneTransform(HumanBodyBones.Head);
			boneTransform.rotation = Quaternion.LookRotation(position - boneTransform.position);
			boneTransform.parent.rotation = Quaternion.Lerp(boneTransform.parent.rotation, boneTransform.rotation, 0.5f * Weight);
			anim.SetBoneLocalRotation(HumanBodyBones.Head, boneTransform.localRotation);
		}

		public static void NormalLookAt(this Animator anim, Vector3 position = default(Vector3), float Weight = 1f, float BodyWeight = 0f, float GlobalWeight = 1f)
		{
			anim.SetLookAtWeight(GlobalWeight, BodyWeight, Weight);
			anim.SetLookAtPosition(position);
		}

		public static Transform GetLastSpineBone(this Animator anim)
		{
			return anim.GetBoneTransform(HumanBodyBones.Head).parent.parent;
		}
	}
}
