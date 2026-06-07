using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Volumes")]
	public abstract class TVolume : TPolymorphicItem<TVolume>, IVolume
	{
		[SerializeField]
		private Bone m_Bone;

		[SerializeField]
		private float m_Weight = 1f;

		[SerializeReference]
		private IJoint m_Joint = new JointNone();

		public override string Title => $"Bone {m_Bone} with {m_Joint}";

		public float Weight => m_Weight;

		protected TVolume()
		{
		}

		protected TVolume(HumanBodyBones humanBone, float weight, IJoint joint)
			: this()
		{
			m_Bone = new Bone(humanBone);
			m_Weight = weight;
			m_Joint = joint;
		}

		public GameObject UpdatePass1Physics(Animator animator, float mass, Skeleton skeleton)
		{
			Transform transform = m_Bone.GetTransform(animator);
			if (transform == null)
			{
				return null;
			}
			UpdateCollider(transform.gameObject, skeleton);
			UpdateRigidbody(transform.gameObject, mass, skeleton);
			return transform.gameObject;
		}

		public void UpdatePass2Joints(GameObject bone, Animator animator, Skeleton skeleton)
		{
			m_Joint.Setup(bone, skeleton, animator);
		}

		private void UpdateCollider(GameObject bone, Skeleton skeleton)
		{
			Collider collider = SetupCollider(bone, skeleton);
			if (!(collider == null))
			{
				collider.material = skeleton.Material;
			}
		}

		private void UpdateRigidbody(GameObject bone, float mass, Skeleton skeleton)
		{
			Rigidbody rigidbody = bone.Get<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = bone.Add<Rigidbody>();
			}
			if (!(rigidbody == null))
			{
				rigidbody.mass = mass;
				rigidbody.collisionDetectionMode = skeleton.CollisionDetection;
			}
		}

		protected virtual Collider SetupCollider(GameObject bone, Skeleton skeleton)
		{
			return null;
		}

		protected float GetBoneScale(Transform bone)
		{
			Vector3 lossyScale = bone.lossyScale;
			if (lossyScale.x > lossyScale.y && lossyScale.x > lossyScale.z)
			{
				return lossyScale.x;
			}
			if (lossyScale.y > lossyScale.x && lossyScale.y > lossyScale.z)
			{
				return lossyScale.y;
			}
			return lossyScale.z;
		}

		public void DrawGizmos(Animator animator, Volumes.Display display)
		{
			Transform transform = m_Bone.GetTransform(animator);
			if (!(transform == null))
			{
				DrawGizmos(transform, display);
			}
		}

		protected abstract void DrawGizmos(Transform bone, Volumes.Display display);
	}
}
