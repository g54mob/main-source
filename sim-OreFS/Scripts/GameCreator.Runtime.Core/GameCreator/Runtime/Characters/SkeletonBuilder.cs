using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public static class SkeletonBuilder
	{
		public static Volumes Make(Animator animator)
		{
			if (animator == null)
			{
				return null;
			}
			if (!animator.isHuman)
			{
				return null;
			}
			List<IVolume> list = new List<IVolume>
			{
				MakeHips(animator, 1f),
				MakeSpine(animator, 0.9f),
				MakeHead(animator, 0.45f),
				MakeUpperLegL(animator, 0.85f),
				MakeLowerLegL(animator, 0.6f),
				MakeFootL(animator, 0.4f),
				MakeUpperLegR(animator, 0.85f),
				MakeLowerLegR(animator, 0.6f),
				MakeFootR(animator, 0.4f),
				MakeUpperArmL(animator, 0.6f),
				MakeLowerArmL(animator, 0.35f),
				MakeHandL(animator, 0.25f),
				MakeUpperArmR(animator, 0.6f),
				MakeLowerArmR(animator, 0.35f),
				MakeHandR(animator, 0.25f)
			};
			if (animator.GetBoneTransform(HumanBodyBones.Chest) != null && animator.GetBoneTransform(HumanBodyBones.UpperChest) != null)
			{
				list.Add(MakeChest(animator, 0.75f));
				list.Add(MakeUpperChest(animator, 0.65f));
			}
			if (animator.GetBoneTransform(HumanBodyBones.RightShoulder) != null && animator.GetBoneTransform(HumanBodyBones.LeftShoulder) != null)
			{
				list.Add(MakeShoulderL(animator, 0.35f));
				list.Add(MakeShoulderR(animator, 0.35f));
			}
			if (animator.GetBoneTransform(HumanBodyBones.Neck) != null)
			{
				list.Add(MakeNeck(animator, 0.6f));
			}
			return new Volumes(list.ToArray());
		}

		private static IVolume MakeChest(Animator animator, float weight)
		{
			Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Hips);
			Transform boneTransform2 = animator.GetBoneTransform(HumanBodyBones.Head);
			Transform boneTransform3 = animator.GetBoneTransform(HumanBodyBones.UpperChest);
			Transform boneTransform4 = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
			Transform boneTransform5 = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
			float a = Math.Max(Vector3.Distance(boneTransform.position, boneTransform4.position), Vector3.Distance(boneTransform.position, boneTransform5.position));
			float b = Vector3.Distance(boneTransform2.position, boneTransform3.position);
			return new VolumeCapsule(HumanBodyBones.Chest, weight, new JointConfigurable(new Bone(HumanBodyBones.Spine), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(470f, 30f), new SpringLimit(470f, 30f), new TetherLimit(-5f, 0.3f, 5f), new TetherLimit(20f, 0.3f, 5f), new TetherLimit(5f, 0.3f, 1f), new TetherLimit(10f, 0.3f, 2f)), Vector3.zero, Mathf.Lerp(a, b, 0.5f), Mathf.Lerp(a, b, 0.5f), VolumeCapsule.Direction.AxisX);
		}

		private static IVolume MakeFootL(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.LeftLowerLeg), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new SpringLimit(260f, 16f), new SpringLimit(260f, 16f), new TetherLimit(-25f, 0.3f, 10f), new TetherLimit(25f, 0.3f, 10f), new TetherLimit(20f, 0.3f, 4f), new TetherLimit(20f, 0.3f, 4f));
			return MakeFootLimb(animator, weight, HumanBodyBones.LeftLowerLeg, HumanBodyBones.LeftFoot, joint);
		}

		private static IVolume MakeFootR(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.RightLowerLeg), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new SpringLimit(260f, 16f), new SpringLimit(260f, 16f), new TetherLimit(-25f, 0.3f, 10f), new TetherLimit(25f, 0.3f, 10f), new TetherLimit(20f, 0.3f, 4f), new TetherLimit(20f, 0.3f, 4f));
			return MakeFootLimb(animator, weight, HumanBodyBones.RightLowerLeg, HumanBodyBones.RightFoot, joint);
		}

		private static IVolume MakeFootLimb(Animator animator, float weight, HumanBodyBones parentBone, HumanBodyBones bone, IJoint joint)
		{
			Transform boneTransform = animator.GetBoneTransform(parentBone);
			Transform boneTransform2 = animator.GetBoneTransform(bone);
			float num = Vector3.Distance(boneTransform2.position, boneTransform.position);
			float num2 = num * 0.5f;
			float num3 = num * 0.15f;
			CalculateDirection(boneTransform2.TransformPoint(Vector3.forward), out var direction, out var _);
			Vector3 position = new Vector3(0f, 0f - num3, num2 * 0.5f - num3);
			position += boneTransform2.position;
			return new VolumeCapsule(bone, weight, joint, boneTransform2.InverseTransformPoint(position), num2, num3, (VolumeCapsule.Direction)direction);
		}

		private static IVolume MakeHandL(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.LeftLowerArm), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f), new SpringLimit(160f, 10f), new SpringLimit(230f, 15f), new TetherLimit(-2f, 0.3f, 20f), new TetherLimit(95f, 0.3f, 20f), new TetherLimit(20f, 0.3f, 4f), new TetherLimit(15f, 0.3f, 3f));
			return MakeHandLimb(animator, weight, HumanBodyBones.LeftHand, HumanBodyBones.LeftLowerArm, joint);
		}

		private static IVolume MakeHandR(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.RightLowerArm), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 0f, 1f), new Vector3(0f, -1f, 0f), new SpringLimit(160f, 10f), new SpringLimit(230f, 15f), new TetherLimit(-2f, 0.3f, 20f), new TetherLimit(95f, 0.3f, 20f), new TetherLimit(20f, 0.3f, 4f), new TetherLimit(15f, 0.3f, 3f));
			return MakeHandLimb(animator, weight, HumanBodyBones.RightHand, HumanBodyBones.RightLowerArm, joint);
		}

		private static IVolume MakeHandLimb(Animator animator, float weight, HumanBodyBones bone, HumanBodyBones parentBone, IJoint joint)
		{
			Transform boneTransform = animator.GetBoneTransform(bone);
			Transform boneTransform2 = animator.GetBoneTransform(parentBone);
			Vector3 vector = boneTransform.position - boneTransform2.position;
			float num = Mathf.Abs(vector.x * 0.75f);
			float radius = Mathf.Abs(vector.x * 0.15f);
			CalculateDirection(boneTransform.TransformPoint(Vector3.right), out var direction, out var _);
			Vector3 position = new Vector3(Mathf.Sign(vector.x) * num * 0.5f, 0f, 0f);
			position += boneTransform.position;
			return new VolumeCapsule(bone, weight, joint, boneTransform.InverseTransformPoint(position), num, radius, (VolumeCapsule.Direction)direction);
		}

		private static IVolume MakeHead(Animator animator, float weight)
		{
			float num = Vector3.Distance(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm).position, animator.GetBoneTransform(HumanBodyBones.RightUpperArm).position) * 0.25f;
			HumanBodyBones humanBodyBones = HumanBodyBones.Neck;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.UpperChest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
			Transform boneTransform2 = animator.GetBoneTransform(humanBodyBones);
			Vector3 normalized = (boneTransform.position - boneTransform2.position).normalized;
			return new VolumeSphere(HumanBodyBones.Head, weight, new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(280f, 17f), new SpringLimit(280f, 17f), new TetherLimit(-30f, 0.3f, 11f), new TetherLimit(25f, 0.3f, 11f), new TetherLimit(15f, 0.3f, 3f), new TetherLimit(20f, 0.3f, 4f)), normalized * num, num);
		}

		private static IVolume MakeHips(Animator animator, float weight)
		{
			Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Hips);
			float num = Vector3.Distance(b: animator.GetBoneTransform(HumanBodyBones.RightUpperLeg).position, a: boneTransform.position);
			return new VolumeCapsule(HumanBodyBones.Hips, weight, new JointConfigurable(Bone.CreateNone(), ConfigurableJointMotion.Free, ConfigurableJointMotion.Free, new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new SpringLimit(620f, 35f), new SpringLimit(620f, 35f), new TetherLimit(0f, 0.3f, 0f), new TetherLimit(0f, 0.3f, 0f), new TetherLimit(0f, 0.3f, 0f), new TetherLimit(0f, 0.3f, 0f)), Vector3.zero, num * 2f, num, VolumeCapsule.Direction.AxisX);
		}

		private static IVolume MakeLowerArmL(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.LeftUpperArm), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(230f, 15f), new SpringLimit(230f, 15f), new TetherLimit(0f, 0.3f, 25f), new TetherLimit(120f, 0.3f, 25f), new TetherLimit(30f, 0.3f, 6f), new TetherLimit(0f, 0.3f, 0f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.LeftLowerArm, HumanBodyBones.LeftHand, joint);
		}

		private static IVolume MakeLowerArmR(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.RightUpperArm), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(230f, 15f), new SpringLimit(230f, 15f), new TetherLimit(0f, 0.3f, 25f), new TetherLimit(120f, 0.3f, 25f), new TetherLimit(30f, 0.3f, 6f), new TetherLimit(0f, 0.3f, 0f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.RightLowerArm, HumanBodyBones.RightHand, joint);
		}

		private static IVolume MakeLowerLegL(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.LeftUpperLeg), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(350f, 22f), new SpringLimit(350f, 22f), new TetherLimit(-90f, 0.3f, 18f), new TetherLimit(0f, 0.3f, 18f), new TetherLimit(10f, 0.3f, 2f), new TetherLimit(1f, 0.3f, 2f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.LeftLowerLeg, HumanBodyBones.LeftFoot, joint);
		}

		private static IVolume MakeLowerLegR(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.RightUpperLeg), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(350f, 22f), new SpringLimit(350f, 22f), new TetherLimit(-90f, 0.3f, 18f), new TetherLimit(0f, 0.3f, 18f), new TetherLimit(10f, 0.3f, 2f), new TetherLimit(1f, 0.3f, 2f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.RightLowerLeg, HumanBodyBones.RightFoot, joint);
		}

		private static IVolume MakeLowerLimb(Animator animator, float weight, HumanBodyBones lowerBone, HumanBodyBones parentBone, IJoint joint)
		{
			Transform boneTransform = animator.GetBoneTransform(lowerBone);
			Transform boneTransform2 = animator.GetBoneTransform(parentBone);
			Vector3 position = boneTransform.position - boneTransform2.position + boneTransform.position;
			CalculateDirection(boneTransform.InverseTransformPoint(position), out var direction, out var distance);
			Vector3 zero = Vector3.zero;
			zero[direction] = distance * 0.5f;
			float num = Mathf.Abs(distance);
			float radius = num * 0.25f;
			return new VolumeCapsule(parentBone, weight, joint, zero, num, radius, (VolumeCapsule.Direction)direction);
		}

		private static IVolume MakeMiddleLimb(Animator animator, float weight, HumanBodyBones upperBone, HumanBodyBones lowerBone, IJoint joint)
		{
			Transform boneTransform = animator.GetBoneTransform(upperBone);
			Vector3 position = animator.GetBoneTransform(lowerBone).position;
			CalculateDirection(boneTransform.InverseTransformPoint(position), out var direction, out var distance);
			Vector3 zero = Vector3.zero;
			zero[direction] = distance * 0.5f;
			float num = Mathf.Abs(distance);
			float radius = num * 0.15f;
			return new VolumeCapsule(upperBone, weight, joint, zero, num, radius, (VolumeCapsule.Direction)direction);
		}

		private static IVolume MakeNeck(Animator animator, float weight)
		{
			HumanBodyBones humanBodyBones = HumanBodyBones.UpperChest;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			JointConfigurable joint = new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(350f, 20f), new SpringLimit(350f, 20f), new TetherLimit(-30f, 0.3f, 15f), new TetherLimit(10f, 0.3f, 15f), new TetherLimit(10f, 0.3f, 5f), new TetherLimit(10f, 0.3f, 5f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.Neck, HumanBodyBones.Head, joint);
		}

		private static IVolume MakeShoulderL(Animator animator, float weight)
		{
			HumanBodyBones humanBodyBones = HumanBodyBones.UpperChest;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			JointConfigurable joint = new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f), new SpringLimit(250f, 15f), new SpringLimit(250f, 15f), new TetherLimit(-15f, 0.3f, 6f), new TetherLimit(15f, 0.3f, 6f), new TetherLimit(15f, 0.3f, 3f), new TetherLimit(15f, 0.3f, 3f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.LeftShoulder, HumanBodyBones.LeftUpperArm, joint);
		}

		private static IVolume MakeShoulderR(Animator animator, float weight)
		{
			HumanBodyBones humanBodyBones = HumanBodyBones.UpperChest;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			JointConfigurable joint = new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 0f, 1f), new Vector3(0f, -1f, 0f), new SpringLimit(250f, 15f), new SpringLimit(250f, 15f), new TetherLimit(-15f, 0.3f, 6f), new TetherLimit(15f, 0.3f, 6f), new TetherLimit(15f, 0.3f, 3f), new TetherLimit(15f, 0.3f, 3f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.RightShoulder, HumanBodyBones.RightUpperArm, joint);
		}

		private static IVolume MakeSpine(Animator animator, float weight)
		{
			Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
			Transform boneTransform2 = animator.GetBoneTransform(HumanBodyBones.Hips);
			Transform boneTransform3 = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
			Transform boneTransform4 = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
			float num = Math.Max(Vector3.Distance(boneTransform2.position, boneTransform3.position), Vector3.Distance(boneTransform2.position, boneTransform4.position));
			Transform boneTransform5 = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			Transform boneTransform6 = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
			float num2 = Math.Max(Vector3.Distance(boneTransform2.position, boneTransform5.position) * 0.5f, Vector3.Distance(boneTransform2.position, boneTransform6.position) * 0.5f);
			Transform boneTransform7 = animator.GetBoneTransform(HumanBodyBones.Spine);
			Bounds bounds = new Bounds(boneTransform7.position, Vector3.one * num);
			float radius = num;
			Transform boneTransform8 = animator.GetBoneTransform(HumanBodyBones.Chest);
			Transform boneTransform9 = animator.GetBoneTransform(HumanBodyBones.UpperChest);
			if (boneTransform8 == null || boneTransform9 == null)
			{
				Vector3 point = Vector3.Lerp(boneTransform2.position, boneTransform.position, 0.6f);
				bounds.Encapsulate(point);
				bounds.Encapsulate(boneTransform5.position);
				bounds.Encapsulate(boneTransform6.position);
				radius = num2;
			}
			return new VolumeCapsule(HumanBodyBones.Spine, weight, new JointConfigurable(new Bone(HumanBodyBones.Hips), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(550f, 30f), new SpringLimit(550f, 30f), new TetherLimit(0f, 0.3f, 20f), new TetherLimit(95f, 0.3f, 20f), new TetherLimit(5f, 0.3f, 1f), new TetherLimit(10f, 0.3f, 2f)), boneTransform7.InverseTransformPoint(bounds.center), bounds.size.x, radius, VolumeCapsule.Direction.AxisX);
		}

		private static IVolume MakeUpperArmL(Animator animator, float weight)
		{
			HumanBodyBones humanBodyBones = HumanBodyBones.LeftShoulder;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.UpperChest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			JointConfigurable joint = new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, -1f), new SpringLimit(380f, 22f), new SpringLimit(380f, 22f), new TetherLimit(-90f, 0.3f, 20f), new TetherLimit(10f, 0.3f, 20f), new TetherLimit(60f, 0.3f, 12f), new TetherLimit(30f, 0.3f, 6f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.LeftUpperArm, HumanBodyBones.LeftLowerArm, joint);
		}

		private static IVolume MakeUpperArmR(Animator animator, float weight)
		{
			HumanBodyBones humanBodyBones = HumanBodyBones.RightShoulder;
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.UpperChest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Chest;
			}
			if (animator.GetBoneTransform(humanBodyBones) == null)
			{
				humanBodyBones = HumanBodyBones.Spine;
			}
			JointConfigurable joint = new JointConfigurable(new Bone(humanBodyBones), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, -1f), new SpringLimit(380f, 22f), new SpringLimit(380f, 22f), new TetherLimit(-90f, 0.3f, 20f), new TetherLimit(10f, 0.3f, 20f), new TetherLimit(60f, 0.3f, 12f), new TetherLimit(30f, 0.3f, 6f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.RightUpperArm, HumanBodyBones.RightLowerArm, joint);
		}

		private static IVolume MakeUpperChest(Animator animator, float weight)
		{
			Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
			Transform boneTransform2 = animator.GetBoneTransform(HumanBodyBones.UpperChest);
			Transform boneTransform3 = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			Transform boneTransform4 = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
			float radius = Vector3.Distance(boneTransform.position, boneTransform2.position);
			float height = Vector3.Distance(boneTransform3.position, boneTransform4.position);
			return new VolumeCapsule(HumanBodyBones.UpperChest, weight, new JointConfigurable(new Bone(HumanBodyBones.Chest), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(400f, 25f), new SpringLimit(400f, 25f), new TetherLimit(-5f, 0.3f, 5f), new TetherLimit(15f, 0.3f, 5f), new TetherLimit(5f, 0.3f, 1f), new TetherLimit(10f, 0.3f, 2f)), Vector3.zero, height, radius, VolumeCapsule.Direction.AxisX);
		}

		private static IVolume MakeUpperLegL(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.Hips), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(520f, 30f), new SpringLimit(520f, 30f), new TetherLimit(-20f, 0.3f, 18f), new TetherLimit(70f, 0.3f, 18f), new TetherLimit(30f, 0.3f, 6f), new TetherLimit(8f, 0.3f, 1.5f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.LeftUpperLeg, HumanBodyBones.LeftLowerLeg, joint);
		}

		private static IVolume MakeUpperLegR(Animator animator, float weight)
		{
			JointConfigurable joint = new JointConfigurable(new Bone(HumanBodyBones.Hips), ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited, new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new SpringLimit(520f, 30f), new SpringLimit(520f, 30f), new TetherLimit(-20f, 0.3f, 18f), new TetherLimit(70f, 0.3f, 18f), new TetherLimit(30f, 0.3f, 6f), new TetherLimit(8f, 0.3f, 1.5f));
			return MakeMiddleLimb(animator, weight, HumanBodyBones.RightUpperLeg, HumanBodyBones.RightLowerLeg, joint);
		}

		private static void CalculateDirection(Vector3 point, out int direction, out float distance)
		{
			direction = 0;
			if (Mathf.Abs(point[1]) > Mathf.Abs(point[0]))
			{
				direction = 1;
			}
			if (Mathf.Abs(point[2]) > Mathf.Abs(point[direction]))
			{
				direction = 2;
			}
			distance = point[direction];
		}
	}
}
