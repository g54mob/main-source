using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	[RequireComponent(typeof(Animator))]
	public class HumanBuilderTest : MonoBehaviour
	{
		private class SkeletonBuilder
		{
			private Dictionary<HumanBodyBones, Transform> m_skeleton = new Dictionary<HumanBodyBones, Transform>();

			private Dictionary<HumanBodyBones, Vector3> m_boneTail = new Dictionary<HumanBodyBones, Vector3>();

			private Transform m_root;

			public IDictionary<HumanBodyBones, Transform> Skeleton => m_skeleton;

			public SkeletonBuilder(Transform root)
			{
				m_root = root;
			}

			private void Add(HumanBodyBones key, Transform parent, Vector3 headPosition, Vector3 tailPosition)
			{
				Transform transform = new GameObject(key.ToString()).transform;
				transform.SetParent(parent, worldPositionStays: false);
				transform.localPosition = headPosition;
				m_skeleton[key] = transform;
				m_boneTail[key] = tailPosition;
			}

			private void Add(HumanBodyBones key, HumanBodyBones parentKey, Vector3 tailPosition)
			{
				Add(key, m_skeleton[parentKey], m_boneTail[parentKey], tailPosition);
			}

			public void AddHips(float height, float len)
			{
				Add(HumanBodyBones.Hips, m_root, new Vector3(0f, height, 0f), new Vector3(0f, len, 0f));
			}

			public void AddSpine(float len)
			{
				Add(HumanBodyBones.Spine, HumanBodyBones.Hips, new Vector3(0f, len, 0f));
			}

			public void AddChest(float len)
			{
				Add(HumanBodyBones.Chest, HumanBodyBones.Spine, new Vector3(0f, len, 0f));
			}

			public void AddNeck(float len)
			{
				Add(HumanBodyBones.Neck, HumanBodyBones.Chest, new Vector3(0f, len, 0f));
			}

			public void AddHead(float len)
			{
				Add(HumanBodyBones.Head, HumanBodyBones.Neck, new Vector3(0f, len, 0f));
			}

			public void AddArm(float shoulder, float upper, float lower, float hand)
			{
				Add(HumanBodyBones.LeftShoulder, HumanBodyBones.Chest, new Vector3(0f - shoulder, 0f, 0f));
				Add(HumanBodyBones.LeftUpperArm, HumanBodyBones.LeftShoulder, new Vector3(0f - upper, 0f, 0f));
				Add(HumanBodyBones.LeftLowerArm, HumanBodyBones.LeftUpperArm, new Vector3(0f - lower, 0f, 0f));
				Add(HumanBodyBones.LeftHand, HumanBodyBones.LeftLowerArm, new Vector3(0f - hand, 0f, 0f));
				Add(HumanBodyBones.RightShoulder, HumanBodyBones.Chest, new Vector3(shoulder, 0f, 0f));
				Add(HumanBodyBones.RightUpperArm, HumanBodyBones.RightShoulder, new Vector3(upper, 0f, 0f));
				Add(HumanBodyBones.RightLowerArm, HumanBodyBones.RightUpperArm, new Vector3(lower, 0f, 0f));
				Add(HumanBodyBones.RightHand, HumanBodyBones.RightLowerArm, new Vector3(hand, 0f, 0f));
			}

			public void AddLeg(float distance, float upper, float lower, float foot, float toe)
			{
				Add(HumanBodyBones.LeftUpperLeg, m_skeleton[HumanBodyBones.Hips], new Vector3(0f - distance, 0f, 0f), new Vector3(0f, 0f - upper, 0f));
				Add(HumanBodyBones.LeftLowerLeg, HumanBodyBones.LeftUpperLeg, new Vector3(0f, 0f - lower, 0f));
				Add(HumanBodyBones.LeftFoot, HumanBodyBones.LeftLowerLeg, new Vector3(0f, 0f - foot, foot));
				Add(HumanBodyBones.LeftToes, HumanBodyBones.LeftFoot, new Vector3(0f, 0f, toe));
				Add(HumanBodyBones.RightUpperLeg, m_skeleton[HumanBodyBones.Hips], new Vector3(distance, 0f, 0f), new Vector3(0f, 0f - upper, 0f));
				Add(HumanBodyBones.RightLowerLeg, HumanBodyBones.RightUpperLeg, new Vector3(0f, 0f - lower, 0f));
				Add(HumanBodyBones.RightFoot, HumanBodyBones.RightLowerLeg, new Vector3(0f, 0f - foot, foot));
				Add(HumanBodyBones.RightToes, HumanBodyBones.RightFoot, new Vector3(0f, 0f, toe));
			}
		}

		[SerializeField]
		private Material m_material;

		private void OnEnable()
		{
			BuildSkeleton(base.transform);
		}

		private void BuildSkeleton(Transform root)
		{
			Vector3 position = root.position;
			root.position = Vector3.zero;
			try
			{
				SkeletonBuilder skeletonBuilder = new SkeletonBuilder(root);
				skeletonBuilder.AddHips(0.8f, 0.2f);
				skeletonBuilder.AddSpine(0.1f);
				skeletonBuilder.AddChest(0.2f);
				skeletonBuilder.AddNeck(0.1f);
				skeletonBuilder.AddHead(0.2f);
				skeletonBuilder.AddArm(0.1f, 0.3f, 0.3f, 0.1f);
				skeletonBuilder.AddLeg(0.1f, 0.3f, 0.4f, 0.1f, 0.1f);
				AvatarDescription avatarDescription = AvatarDescription.Create(skeletonBuilder.Skeleton);
				Animator component = GetComponent<Animator>();
				component.avatar = avatarDescription.CreateAvatar(root);
				SkinnedMeshRenderer skinnedMeshRenderer = SkeletonMeshUtility.CreateRenderer(component);
				if (m_material == null)
				{
					m_material = new Material(Shader.Find("Standard"));
				}
				skinnedMeshRenderer.sharedMaterial = m_material;
				HumanPoseTransfer component2 = GetComponent<HumanPoseTransfer>();
				if (component2 != null)
				{
					component2.Avatar = component.avatar;
					component2.Setup();
				}
			}
			finally
			{
				root.position = position;
			}
		}
	}
}
