using System;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public abstract class RagdollAnimatorFeatureBase : ScriptableObject
	{
		protected Transform Transform => Owner.BaseTransform;

		public RagdollHandler ParentRagdollHandler => Owner;

		public RagdollAnimatorFeatureHelper Helper => InitializedWith;

		[field: NonSerialized]
		protected RagdollHandler Owner { get; private set; }

		[field: NonSerialized]
		protected RagdollAnimatorFeatureHelper InitializedWith { get; private set; }

		public bool Initialized { get; private set; }

		public float FeatureBlend { get; set; }

		public void Base_Init(RagdollHandler ragdollHandler, RagdollAnimatorFeatureHelper helper)
		{
			FeatureBlend = 1f;
			InitializedWith = helper;
			Owner = ragdollHandler;
			if (OnInit())
			{
				Initialized = true;
			}
		}

		public virtual bool OnInit()
		{
			return true;
		}

		public virtual void OnDisableRagdoll()
		{
		}

		public virtual void OnEnableRagdoll()
		{
		}

		public virtual void OnDestroyFeature()
		{
		}

		public virtual void OnEnabledSwitch()
		{
		}
	}
}
