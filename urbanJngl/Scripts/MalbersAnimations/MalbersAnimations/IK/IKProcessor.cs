using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	public abstract class IKProcessor
	{
		[HideInInspector]
		public string name;

		[HideInInspector]
		public bool Active = true;

		[Tooltip("Weight Applied for the Processor")]
		[HideInInspector]
		[Range(0f, 1f)]
		public float Weight = 1f;

		[Tooltip("Target transform reference from the IK Set [Targets Array]. Index Value. Target applied to the Avatar IK Goal")]
		[HideInInspector]
		[Min(-1f)]
		public int TargetIndex;

		[HideInInspector]
		public string AnimParameter;

		[HideInInspector]
		public int AnimParameterHash;

		public abstract bool RequireTargets { get; }

		public virtual void Start(IKSet IKSet, Animator anim, int index)
		{
		}

		public virtual void OnEnable(IKSet IKSet, Animator anim, int index)
		{
		}

		public virtual void OnDisable(IKSet IKSet, Animator anim, int index)
		{
		}

		public virtual void OnAnimatorIK(IKSet IKSet, Animator anim, int index, float weight)
		{
		}

		public virtual void LateUpdate(IKSet IKSet, Animator anim, int index, float weight)
		{
		}

		public virtual void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
		}

		public abstract void Validate(IKSet set, Animator animator, int index);

		public float GetProcessorAnimWeight(Animator animator)
		{
			if (AnimParameterHash == 0)
			{
				return 1f;
			}
			return animator.GetFloat(AnimParameterHash);
		}

		internal virtual void OnSceneGUI(IKSet set, Animator animator, UnityEngine.Object target, int index)
		{
		}
	}
}
