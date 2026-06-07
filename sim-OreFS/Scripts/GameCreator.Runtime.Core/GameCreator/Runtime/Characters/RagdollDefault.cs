using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Default Ragdoll")]
	[Category("Default Ragdoll")]
	[Image(typeof(IconSkeleton), ColorTheme.Type.Yellow)]
	[Description("Default Ragdoll System")]
	public class RagdollDefault : TRagdollSystem
	{
		[SerializeField]
		private BoneRack m_BoneRack = new BoneRack();

		[SerializeField]
		private float m_TransitionDuration = 0.2f;

		[SerializeField]
		private AnimationClip m_RecoverFaceDown;

		[SerializeField]
		private AnimationClip m_RecoverFaceUp;

		[NonSerialized]
		private int m_CurrentModelID = -1;

		[NonSerialized]
		private GameObject[] m_Bones = Array.Empty<GameObject>();

		[NonSerialized]
		private BoneSnapshot m_RootSnapshot;

		[NonSerialized]
		private BoneSnapshot[] m_BonesSnapshots;

		[NonSerialized]
		private bool m_IsRecovering;

		[NonSerialized]
		private float m_RecoverStartTime;

		protected internal override void OnStartup(Character character)
		{
			if (m_BoneRack != null)
			{
				m_BoneRack.EventChangeSkeleton += OnChangeSkeleton;
			}
		}

		protected internal override void OnDispose(Character character)
		{
			if (m_BoneRack != null)
			{
				m_BoneRack.EventChangeSkeleton -= OnChangeSkeleton;
			}
		}

		protected internal override void OnEnable(Character character)
		{
		}

		protected internal override void OnDisable(Character character)
		{
		}

		protected internal override void OnUpdate(Character character)
		{
		}

		protected internal override void OnLateUpdate(Character character)
		{
			if (character.Ragdoll.IsRagdoll)
			{
				Animator animator = character.Animim.Animator;
				if (!(animator == null) && m_IsRecovering)
				{
					UpdateRagdollRecover(character, animator.transform);
				}
			}
		}

		protected internal override Task StartRagdoll(Character character)
		{
			m_IsRecovering = false;
			RequireInitialize(character, force: false);
			Vector3 worldMoveDirection = character.Driver.WorldMoveDirection;
			character.Gestures.Stop(0f, 0.1f);
			Animator animator = character.Animim.Animator;
			animator.transform.SetParent(null);
			GameObject[] bones = m_Bones;
			foreach (GameObject gameObject in bones)
			{
				gameObject.Get<Collider>().enabled = true;
				gameObject.Get<Rigidbody>().isKinematic = false;
				gameObject.Get<Rigidbody>().linearVelocity = worldMoveDirection;
			}
			animator.enabled = false;
			return Task.CompletedTask;
		}

		protected internal override Task StopRagdoll(Character character)
		{
			Animator animator = character.Animim.Animator;
			RequireInitialize(character, force: false);
			GameObject[] bones = m_Bones;
			foreach (GameObject gameObject in bones)
			{
				gameObject.Get<Collider>().enabled = false;
				gameObject.Get<Rigidbody>().linearVelocity = Vector3.zero;
				gameObject.Get<Rigidbody>().isKinematic = true;
			}
			Transform transform = animator.transform;
			if (animator.isHuman)
			{
				Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Hips);
				Transform boneTransform2 = animator.GetBoneTransform(HumanBodyBones.Head);
				if (Physics.Raycast(new Ray(boneTransform.position, Vector3.down * (character.Motion.Height * 0.5f)), out var hitInfo))
				{
					Vector3 vector = transform.position - hitInfo.point;
					transform.position -= vector;
					boneTransform.position += vector;
				}
				else
				{
					Vector3 vector2 = transform.position - boneTransform.position;
					transform.position -= vector2;
					boneTransform.position += vector2;
				}
				Vector3 forward = Vector3.ProjectOnPlane(boneTransform2.position - boneTransform.position, Vector3.up);
				Quaternion rotation = boneTransform.rotation;
				Vector3 vector3 = boneTransform.TransformDirection(Vector3.forward);
				transform.rotation = Quaternion.LookRotation(forward, Vector3.up) * Quaternion.Euler(0f, (vector3.y > 0f) ? 180f : 0f, 0f);
				boneTransform.rotation = rotation;
			}
			character.Driver.SetPosition(transform.position);
			character.Driver.SetRotation(transform.rotation);
			Transform parent = ((character.Animim.Mannequin != null && character.Animim.Mannequin != transform) ? character.Animim.Mannequin : character.transform);
			transform.SetParent(parent, worldPositionStays: true);
			animator.enabled = true;
			return Task.CompletedTask;
		}

		protected internal override async Task RecoverRagdoll(Character character)
		{
			Animator animator = character.Animim.Animator;
			AnimationClip animationClip = ((!animator.isHuman) ? ((animator.transform.TransformDirection(Vector3.forward).y > 0f) ? m_RecoverFaceUp : m_RecoverFaceDown) : ((animator.GetBoneTransform(HumanBodyBones.Hips).TransformDirection(Vector3.forward).y > 0f) ? m_RecoverFaceUp : m_RecoverFaceDown));
			if (animationClip != null)
			{
				ConfigGesture config = new ConfigGesture(0f, animationClip.length, 1f, rootMotion: true, 0f, character.Animim.SmoothTime);
				m_IsRecovering = true;
				m_RecoverStartTime = character.Time.Time;
				RefreshSnapshots(character);
				await character.Gestures.CrossFade(animationClip, null, BlendMode.Blend, config, stopPreviousGestures: true);
			}
		}

		private void RequireInitialize(Character character, bool force)
		{
			if (character == null || character.Animim.Animator == null)
			{
				return;
			}
			Skeleton skeleton = m_BoneRack.Skeleton;
			if (!(skeleton == null))
			{
				int instanceID = character.Animim.Animator.gameObject.GetInstanceID();
				if (instanceID != m_CurrentModelID || force)
				{
					m_Bones = skeleton.Refresh(character);
					m_CurrentModelID = instanceID;
				}
			}
		}

		private void RefreshSnapshots(Character character)
		{
			Animator animator = character.Animim.Animator;
			if (animator == null)
			{
				return;
			}
			Transform[] componentsInChildren = animator.GetComponentsInChildren<Transform>();
			m_RootSnapshot = new BoneSnapshot(animator.transform);
			List<BoneSnapshot> list = new List<BoneSnapshot>();
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				if (!(transform == animator.transform))
				{
					list.Add(new BoneSnapshot(transform));
				}
			}
			m_BonesSnapshots = list.ToArray();
		}

		private void UpdateRagdollRecover(Character character, Transform mannequin)
		{
			float num = character.Time.Time - m_RecoverStartTime;
			float t = Easing.QuadInOut(0f, 1f, num / m_TransitionDuration);
			m_RootSnapshot.Value.localPosition = Vector3.Lerp(m_RootSnapshot.LocalPosition, m_RootSnapshot.Value.localPosition, t);
			m_RootSnapshot.Value.localRotation = Quaternion.Lerp(m_RootSnapshot.LocalRotation, m_RootSnapshot.Value.localRotation, t);
			BoneSnapshot[] bonesSnapshots = m_BonesSnapshots;
			foreach (BoneSnapshot boneSnapshot in bonesSnapshots)
			{
				if (!(boneSnapshot.Value == null))
				{
					if (boneSnapshot.Value.parent == mannequin)
					{
						boneSnapshot.Value.position = Vector3.Lerp(boneSnapshot.WorldPosition, boneSnapshot.Value.position, t);
					}
					if (boneSnapshot.LocalRotation != boneSnapshot.Value.localRotation)
					{
						boneSnapshot.Value.rotation = Quaternion.Lerp(boneSnapshot.WorldRotation, boneSnapshot.Value.rotation, t);
					}
				}
			}
		}

		private void OnChangeSkeleton()
		{
			m_CurrentModelID = -1;
		}

		protected internal override void OnDrawGizmos(Character character)
		{
			if (!(character.Animim.Animator == null))
			{
				m_BoneRack.DrawGizmos(character.Animim.Animator);
			}
		}
	}
}
