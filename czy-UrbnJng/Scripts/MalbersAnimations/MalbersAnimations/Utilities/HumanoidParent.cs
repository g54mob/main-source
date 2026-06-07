using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Transform/Humanoid Parent")]
	[DefaultExecutionOrder(1501)]
	public class HumanoidParent : MonoBehaviour
	{
		public Animator animator;

		[SearcheableEnum]
		[Tooltip("Which bone will be the parent of this gameobject")]
		public HumanBodyBones parent = HumanBodyBones.Spine;

		[Tooltip("Reset the Local Position of this gameobject when parented")]
		public BoolReference LocalPos;

		[Tooltip("Reset the Local Rotation of this gameobject when parented")]
		public BoolReference LocalRot;

		[Tooltip("Additional Local Position Offset to add after the gameobject is parented")]
		public Vector3Reference PosOffset;

		[Tooltip("Additional Local Rotation Offset to add after the gameobject is parented")]
		public Vector3Reference RotOffset;

		private void OnEnable()
		{
			if (animator == null)
			{
				animator = this.FindComponent<Animator>();
			}
			if (animator != null)
			{
				Align();
			}
		}

		private void Align()
		{
			if (animator.avatar != null)
			{
				Transform boneTransform = animator.GetBoneTransform(parent);
				if (boneTransform != null && base.transform.parent != boneTransform)
				{
					base.transform.parent = boneTransform;
					if (LocalPos.Value)
					{
						base.transform.localPosition = Vector3.zero;
					}
					if (LocalRot.Value)
					{
						base.transform.localRotation = Quaternion.identity;
					}
					base.transform.localPosition += (Vector3)PosOffset;
					base.transform.localRotation *= Quaternion.Euler(RotOffset);
				}
			}
			else
			{
				Debug.LogWarning("Avatar is missing in the animator. [" + base.name + "]", this);
				base.enabled = false;
			}
		}

		[ContextMenu("Try Align")]
		private void TryAlign()
		{
			if (animator != null && animator.avatar != null)
			{
				Transform boneTransform = animator.GetBoneTransform(parent);
				if (boneTransform != null && base.transform.parent != boneTransform)
				{
					if (LocalPos.Value)
					{
						base.transform.position = boneTransform.position;
					}
					if (LocalRot.Value)
					{
						base.transform.localRotation = boneTransform.rotation;
					}
					base.transform.localPosition += (Vector3)PosOffset;
					base.transform.localRotation *= Quaternion.Euler(RotOffset);
				}
			}
			if (!Application.isPlaying)
			{
				MTools.SetDirty(this);
			}
		}

		private void OnValidate()
		{
			if (animator == null)
			{
				animator = base.gameObject.FindComponent<Animator>();
			}
		}
	}
}
