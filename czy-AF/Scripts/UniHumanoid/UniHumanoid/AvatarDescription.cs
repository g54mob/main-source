using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	[Serializable]
	public class AvatarDescription : ScriptableObject
	{
		public float armStretch = 0.05f;

		public float legStretch = 0.05f;

		public float upperArmTwist = 0.5f;

		public float lowerArmTwist = 0.5f;

		public float upperLegTwist = 0.5f;

		public float lowerLegTwist = 0.5f;

		public float feetSpacing;

		public bool hasTranslationDoF;

		public BoneLimit[] human;

		public HumanDescription ToHumanDescription(Transform root)
		{
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			SkeletonBone[] array = new SkeletonBone[componentsInChildren.Length];
			int num = 0;
			Transform[] array2 = componentsInChildren;
			foreach (Transform t in array2)
			{
				array[num] = t.ToSkeletonBone();
				num++;
			}
			HumanBone[] array3 = new HumanBone[human.Length];
			num = 0;
			BoneLimit[] array4 = human;
			foreach (BoneLimit boneLimit in array4)
			{
				array3[num] = boneLimit.ToHumanBone();
				num++;
			}
			return new HumanDescription
			{
				skeleton = array,
				human = array3,
				armStretch = armStretch,
				legStretch = legStretch,
				upperArmTwist = upperArmTwist,
				lowerArmTwist = lowerArmTwist,
				upperLegTwist = upperLegTwist,
				lowerLegTwist = lowerLegTwist,
				feetSpacing = feetSpacing,
				hasTranslationDoF = hasTranslationDoF
			};
		}

		public Avatar CreateAvatar(Transform root)
		{
			return AvatarBuilder.BuildHumanAvatar(root.gameObject, ToHumanDescription(root));
		}

		public Avatar CreateAvatarAndSetup(Transform root)
		{
			Avatar avatar = CreateAvatar(root);
			avatar.name = base.name;
			Animator component = root.GetComponent<Animator>();
			if (component != null)
			{
				Dictionary<Transform, Vector3> dictionary = root.Traverse().ToDictionary((Transform x) => x, (Transform x) => x.position);
				component.avatar = avatar;
				foreach (Transform item in root.Traverse())
				{
					item.position = dictionary[item];
				}
			}
			HumanPoseTransfer component2 = root.GetComponent<HumanPoseTransfer>();
			if (component2 != null)
			{
				component2.Avatar = avatar;
			}
			return avatar;
		}

		public static AvatarDescription CreateFrom(HumanDescription description)
		{
			AvatarDescription avatarDescription = ScriptableObject.CreateInstance<AvatarDescription>();
			avatarDescription.name = "AvatarDescription";
			avatarDescription.armStretch = description.armStretch;
			avatarDescription.legStretch = description.legStretch;
			avatarDescription.feetSpacing = description.feetSpacing;
			avatarDescription.hasTranslationDoF = description.hasTranslationDoF;
			avatarDescription.lowerArmTwist = description.lowerArmTwist;
			avatarDescription.lowerLegTwist = description.lowerLegTwist;
			avatarDescription.upperArmTwist = description.upperArmTwist;
			avatarDescription.upperLegTwist = description.upperLegTwist;
			avatarDescription.human = description.human.Select(BoneLimit.From).ToArray();
			return avatarDescription;
		}

		public static AvatarDescription Create(AvatarDescription src = null)
		{
			AvatarDescription avatarDescription = ScriptableObject.CreateInstance<AvatarDescription>();
			avatarDescription.name = "AvatarDescription";
			if (src != null)
			{
				avatarDescription.armStretch = src.armStretch;
				avatarDescription.legStretch = src.legStretch;
				avatarDescription.feetSpacing = src.feetSpacing;
				avatarDescription.upperArmTwist = src.upperArmTwist;
				avatarDescription.lowerArmTwist = src.lowerArmTwist;
				avatarDescription.upperLegTwist = src.upperLegTwist;
				avatarDescription.lowerLegTwist = src.lowerLegTwist;
			}
			else
			{
				avatarDescription.armStretch = 0.05f;
				avatarDescription.legStretch = 0.05f;
				avatarDescription.feetSpacing = 0f;
				avatarDescription.lowerArmTwist = 0.5f;
				avatarDescription.upperArmTwist = 0.5f;
				avatarDescription.upperLegTwist = 0.5f;
				avatarDescription.lowerLegTwist = 0.5f;
			}
			return avatarDescription;
		}

		public static AvatarDescription Create(Transform[] boneTransforms, Skeleton skeleton)
		{
			return Create(skeleton.Bones.Select((KeyValuePair<HumanBodyBones, int> x) => new KeyValuePair<HumanBodyBones, Transform>(x.Key, boneTransforms[x.Value])));
		}

		public static AvatarDescription Create(IEnumerable<KeyValuePair<HumanBodyBones, Transform>> skeleton)
		{
			AvatarDescription avatarDescription = Create();
			avatarDescription.SetHumanBones(skeleton);
			return avatarDescription;
		}

		public void SetHumanBones(IEnumerable<KeyValuePair<HumanBodyBones, Transform>> skeleton)
		{
			human = skeleton.Select((KeyValuePair<HumanBodyBones, Transform> x) => new BoneLimit
			{
				humanBone = x.Key,
				boneName = x.Value.name,
				useDefaultValues = true
			}).ToArray();
		}
	}
}
