using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	public abstract class WeightProcessor
	{
		[HideInInspector]
		public bool Active = true;

		public abstract float Process(IKSet set, float weight);

		public virtual void OnEnable(IKSet set, Animator anim)
		{
		}

		public virtual void OnDisable(IKSet set, Animator anim)
		{
		}

		public virtual void OnDrawGizmos(IKSet set, Animator anim)
		{
		}

		public virtual void OnHandlesGizmos(IKSet set, Animator anim)
		{
		}
	}
}
