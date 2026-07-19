using System;
using UnityEngine;

namespace UniHumanoid
{
	public static class EnumExtensions
	{
		public static string ToStringFromEnum(this HumanBodyBones val, bool compareBoneTrait = false)
		{
			switch (val)
			{
			case HumanBodyBones.Hips:
				return "Hips";
			case HumanBodyBones.LeftUpperLeg:
				return "LeftUpperLeg";
			case HumanBodyBones.RightUpperLeg:
				return "RightUpperLeg";
			case HumanBodyBones.LeftLowerLeg:
				return "LeftLowerLeg";
			case HumanBodyBones.RightLowerLeg:
				return "RightLowerLeg";
			case HumanBodyBones.LeftFoot:
				return "LeftFoot";
			case HumanBodyBones.RightFoot:
				return "RightFoot";
			case HumanBodyBones.Spine:
				return "Spine";
			case HumanBodyBones.Chest:
				return "Chest";
			case HumanBodyBones.Neck:
				return "Neck";
			case HumanBodyBones.Head:
				return "Head";
			case HumanBodyBones.LeftShoulder:
				return "LeftShoulder";
			case HumanBodyBones.RightShoulder:
				return "RightShoulder";
			case HumanBodyBones.LeftUpperArm:
				return "LeftUpperArm";
			case HumanBodyBones.RightUpperArm:
				return "RightUpperArm";
			case HumanBodyBones.LeftLowerArm:
				return "LeftLowerArm";
			case HumanBodyBones.RightLowerArm:
				return "RightLowerArm";
			case HumanBodyBones.LeftHand:
				return "LeftHand";
			case HumanBodyBones.RightHand:
				return "RightHand";
			case HumanBodyBones.LeftToes:
				return "LeftToes";
			case HumanBodyBones.RightToes:
				return "RightToes";
			case HumanBodyBones.LeftEye:
				return "LeftEye";
			case HumanBodyBones.RightEye:
				return "RightEye";
			case HumanBodyBones.Jaw:
				return "Jaw";
			case HumanBodyBones.LeftThumbProximal:
				if (!compareBoneTrait)
				{
					return "LeftThumbProximal";
				}
				return "Left Thumb Proximal";
			case HumanBodyBones.LeftThumbIntermediate:
				if (!compareBoneTrait)
				{
					return "LeftThumbIntermediate";
				}
				return "Left Thumb Intermediate";
			case HumanBodyBones.LeftThumbDistal:
				if (!compareBoneTrait)
				{
					return "LeftThumbDistal";
				}
				return "Left Thumb Distal";
			case HumanBodyBones.LeftIndexProximal:
				if (!compareBoneTrait)
				{
					return "LeftIndexProximal";
				}
				return "Left Index Proximal";
			case HumanBodyBones.LeftIndexIntermediate:
				if (!compareBoneTrait)
				{
					return "LeftIndexIntermediate";
				}
				return "Left Index Intermediate";
			case HumanBodyBones.LeftIndexDistal:
				if (!compareBoneTrait)
				{
					return "LeftIndexDistal";
				}
				return "Left Index Distal";
			case HumanBodyBones.LeftMiddleProximal:
				if (!compareBoneTrait)
				{
					return "LeftMiddleProximal";
				}
				return "Left Middle Proximal";
			case HumanBodyBones.LeftMiddleIntermediate:
				if (!compareBoneTrait)
				{
					return "LeftMiddleIntermediate";
				}
				return "Left Middle Intermediate";
			case HumanBodyBones.LeftMiddleDistal:
				if (!compareBoneTrait)
				{
					return "LeftMiddleDistal";
				}
				return "Left Middle Distal";
			case HumanBodyBones.LeftRingProximal:
				if (!compareBoneTrait)
				{
					return "LeftRingProximal";
				}
				return "Left Ring Proximal";
			case HumanBodyBones.LeftRingIntermediate:
				if (!compareBoneTrait)
				{
					return "LeftRingIntermediate";
				}
				return "Left Ring Intermediate";
			case HumanBodyBones.LeftRingDistal:
				if (!compareBoneTrait)
				{
					return "LeftRingDistal";
				}
				return "Left Ring Distal";
			case HumanBodyBones.LeftLittleProximal:
				if (!compareBoneTrait)
				{
					return "LeftLittleProximal";
				}
				return "Left Little Proximal";
			case HumanBodyBones.LeftLittleIntermediate:
				if (!compareBoneTrait)
				{
					return "LeftLittleIntermediate";
				}
				return "Left Little Intermediate";
			case HumanBodyBones.LeftLittleDistal:
				if (!compareBoneTrait)
				{
					return "LeftLittleDistal";
				}
				return "Left Little Distal";
			case HumanBodyBones.RightThumbProximal:
				if (!compareBoneTrait)
				{
					return "RightThumbProximal";
				}
				return "Right Thumb Proximal";
			case HumanBodyBones.RightThumbIntermediate:
				if (!compareBoneTrait)
				{
					return "RightThumbIntermediate";
				}
				return "Right Thumb Intermediate";
			case HumanBodyBones.RightThumbDistal:
				if (!compareBoneTrait)
				{
					return "RightThumbDistal";
				}
				return "Right Thumb Distal";
			case HumanBodyBones.RightIndexProximal:
				if (!compareBoneTrait)
				{
					return "RightIndexProximal";
				}
				return "Right Index Proximal";
			case HumanBodyBones.RightIndexIntermediate:
				if (!compareBoneTrait)
				{
					return "RightIndexIntermediate";
				}
				return "Right Index Intermediate";
			case HumanBodyBones.RightIndexDistal:
				if (!compareBoneTrait)
				{
					return "RightIndexDistal";
				}
				return "Right Index Distal";
			case HumanBodyBones.RightMiddleProximal:
				if (!compareBoneTrait)
				{
					return "RightMiddleProximal";
				}
				return "Right Middle Proximal";
			case HumanBodyBones.RightMiddleIntermediate:
				if (!compareBoneTrait)
				{
					return "RightMiddleIntermediate";
				}
				return "Right Middle Intermediate";
			case HumanBodyBones.RightMiddleDistal:
				if (!compareBoneTrait)
				{
					return "RightMiddleDistal";
				}
				return "Right Middle Distal";
			case HumanBodyBones.RightRingProximal:
				if (!compareBoneTrait)
				{
					return "RightRingProximal";
				}
				return "Right Ring Proximal";
			case HumanBodyBones.RightRingIntermediate:
				if (!compareBoneTrait)
				{
					return "RightRingIntermediate";
				}
				return "Right Ring Intermediate";
			case HumanBodyBones.RightRingDistal:
				if (!compareBoneTrait)
				{
					return "RightRingDistal";
				}
				return "Right Ring Distal";
			case HumanBodyBones.RightLittleProximal:
				if (!compareBoneTrait)
				{
					return "RightLittleProximal";
				}
				return "Right Little Proximal";
			case HumanBodyBones.RightLittleIntermediate:
				if (!compareBoneTrait)
				{
					return "RightLittleIntermediate";
				}
				return "Right Little Intermediate";
			case HumanBodyBones.RightLittleDistal:
				if (!compareBoneTrait)
				{
					return "RightLittleDistal";
				}
				return "Right Little Distal";
			case HumanBodyBones.UpperChest:
				return "UpperChest";
			case HumanBodyBones.LastBone:
				return "LastBone";
			default:
				throw new InvalidOperationException();
			}
		}
	}
}
