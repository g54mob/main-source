using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UniHumanoid
{
	public class BvhImporterContext
	{
		private string m_path;

		public string Source;

		public Bvh Bvh;

		public GameObject Root;

		public List<Transform> Nodes = new List<Transform>();

		public AnimationClip Animation;

		public AvatarDescription AvatarDescription;

		public Avatar Avatar;

		public Mesh Mesh;

		public Material Material;

		public string Path
		{
			get
			{
				return m_path;
			}
			set
			{
				if (!(m_path == value))
				{
					m_path = value;
				}
			}
		}

		[Obsolete("use Load(path)")]
		public void Parse()
		{
			Parse(Path);
		}

		public void Parse(string path)
		{
			Path = path;
			Source = File.ReadAllText(Path, Encoding.UTF8);
			Bvh = Bvh.Parse(Source);
		}

		public void Load()
		{
			Root = new GameObject(System.IO.Path.GetFileNameWithoutExtension(Path));
			Transform transform = BuildHierarchy(Root.transform, Bvh.Root, 1f);
			Skeleton skeleton = Skeleton.Estimate(transform);
			AvatarDescription avatarDescription = AvatarDescription.Create(transform.Traverse().ToArray(), skeleton);
			float num = 1f;
			Transform transform2 = transform.Traverse().Skip(skeleton.GetBoneIndex(HumanBodyBones.LeftFoot)).First();
			float num2 = transform.position.y - transform2.position.y;
			num = 1f / num2;
			foreach (Transform item in Root.transform.Traverse())
			{
				item.localPosition *= num;
			}
			float y = num2 * num;
			transform.position = new Vector3(0f, y, 0f);
			Avatar = avatarDescription.CreateAvatar(Root.transform);
			Avatar.name = "Avatar";
			AvatarDescription = avatarDescription;
			Animator animator = Root.AddComponent<Animator>();
			animator.avatar = Avatar;
			Animation = BvhAnimation.CreateAnimationClip(Bvh, num);
			Animation.name = Root.name;
			Animation.legacy = true;
			Animation.wrapMode = WrapMode.Loop;
			Animation animation = Root.AddComponent<Animation>();
			animation.AddClip(Animation, Animation.name);
			animation.clip = Animation;
			animation.Play();
			Root.AddComponent<HumanPoseTransfer>().Avatar = Avatar;
			SkinnedMeshRenderer skinnedMeshRenderer = SkeletonMeshUtility.CreateRenderer(animator);
			Material = new Material(Shader.Find("Standard"));
			skinnedMeshRenderer.sharedMaterial = Material;
			Mesh = skinnedMeshRenderer.sharedMesh;
			Mesh.name = "box-man";
		}

		private static Transform BuildHierarchy(Transform parent, BvhNode node, float toMeter)
		{
			GameObject gameObject = new GameObject(node.Name);
			gameObject.transform.localPosition = node.Offset.ToXReversedVector3() * toMeter;
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			foreach (BvhNode child in node.Children)
			{
				BuildHierarchy(gameObject.transform, child, toMeter);
			}
			return gameObject.transform;
		}

		public void Destroy(bool destroySubAssets)
		{
			if (Root != null)
			{
				UnityEngine.Object.DestroyImmediate(Root);
			}
		}
	}
}
