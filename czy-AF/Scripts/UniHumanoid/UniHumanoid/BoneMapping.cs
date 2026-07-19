using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	public class BoneMapping : MonoBehaviour
	{
		[SerializeField]
		public GameObject[] Bones = new GameObject[55];

		[SerializeField]
		public AvatarDescription Description;

		private void Reset()
		{
			GetBones();
		}

		private void GetBones()
		{
			Bones = new GameObject[55];
			Animator component = GetComponent<Animator>();
			if (!(component != null) || !(component.avatar != null))
			{
				return;
			}
			foreach (HumanBodyBones value in Enum.GetValues(typeof(HumanBodyBones)))
			{
				if (value == HumanBodyBones.LastBone)
				{
					break;
				}
				Transform boneTransform = component.GetBoneTransform(value);
				if (boneTransform != null)
				{
					Bones[(int)value] = boneTransform.gameObject;
				}
			}
		}

		public void GuessBoneMapping()
		{
			GameObject gameObject = Bones[0];
			if (gameObject == null)
			{
				Debug.LogWarning("require hips");
				return;
			}
			Skeleton skeleton = new BvhSkeletonEstimator().Detect(gameObject.transform);
			Transform[] array = gameObject.transform.Traverse().ToArray();
			for (int i = 0; i < 55; i++)
			{
				int boneIndex = skeleton.GetBoneIndex((HumanBodyBones)i);
				if (boneIndex >= 0)
				{
					Bones[i] = array[boneIndex].gameObject;
				}
			}
		}

		public void EnsureTPose()
		{
			Dictionary<HumanBodyBones, Transform> dictionary = (from x in Bones.Select((GameObject x, int i) => new { i, x })
				where x.x != null
				select x).ToDictionary(x => (HumanBodyBones)x.i, x => x.x.transform);
			Vector3 normalized = (dictionary[HumanBodyBones.LeftLowerArm].position - dictionary[HumanBodyBones.LeftUpperArm].position).normalized;
			dictionary[HumanBodyBones.LeftUpperArm].rotation = Quaternion.FromToRotation(normalized, Vector3.left) * dictionary[HumanBodyBones.LeftUpperArm].rotation;
			Vector3 normalized2 = (dictionary[HumanBodyBones.RightLowerArm].position - dictionary[HumanBodyBones.RightUpperArm].position).normalized;
			dictionary[HumanBodyBones.RightUpperArm].rotation = Quaternion.FromToRotation(normalized2, Vector3.right) * dictionary[HumanBodyBones.RightUpperArm].rotation;
		}

		public static void SetBonesToDescription(BoneMapping mapping, AvatarDescription description)
		{
			Dictionary<HumanBodyBones, Transform> humanBones = (from x in mapping.Bones.Select((GameObject x, int i) => new { i, x })
				where x.x != null
				select x).ToDictionary(x => (HumanBodyBones)x.i, x => x.x.transform);
			description.SetHumanBones(humanBones);
		}

		private void Awake()
		{
			if (Bones == null || Bones.All((GameObject x) => x == null))
			{
				GetBones();
			}
		}
	}
}
