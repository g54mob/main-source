using System;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

public class bns : bnx
{
	[Serializable]
	public abstract class HitPoint
	{
		public string name;

		public Collider collider;

		[SerializeField]
		private float crossFadeTime;

		private float ueh;

		private float uei;

		private float uej;

		public bool xtc => false;

		protected float uee
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		protected float uef
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		protected Vector3 ueg
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public virtual void lae(Vector3 a, Vector3 b)
		{
		}

		public void laf(IKSolverFullBodyBiped a, float b)
		{
		}

		protected abstract float lag();

		protected abstract void lah();

		protected abstract void lai(IKSolverFullBodyBiped a, float b);
	}

	[Serializable]
	public class HitPointEffector : HitPoint
	{
		[Serializable]
		public class EffectorLink
		{
			public FullBodyBipedEffector effector;

			public float weight;

			private Vector3 uek;

			private Vector3 current;

			public void laj(IKSolverFullBodyBiped a, Vector3 b, float c)
			{
			}

			public void lak()
			{
			}
		}

		public AnimationCurve offsetInForceDirection;

		public AnimationCurve offsetInUpDirection;

		public EffectorLink[] effectorLinks;

		protected override float lag()
		{
			return 0f;
		}

		protected override void lah()
		{
		}

		protected override void lai(IKSolverFullBodyBiped a, float b)
		{
		}
	}

	[Serializable]
	public class HitPointBone : HitPoint
	{
		[Serializable]
		public class BoneLink
		{
			public Transform bone;

			[Range(0f, 1f)]
			public float weight;

			private Quaternion uel;

			private Quaternion current;

			public void lal(IKSolverFullBodyBiped a, Quaternion b, float c)
			{
			}

			public void lam()
			{
			}
		}

		public AnimationCurve aroundCenterOfMass;

		public BoneLink[] boneLinks;

		private Rigidbody uem;

		private Vector3 uen;

		public override void lae(Vector3 a, Vector3 b)
		{
		}

		protected override float lag()
		{
			return 0f;
		}

		protected override void lah()
		{
		}

		protected override void lai(IKSolverFullBodyBiped a, float b)
		{
		}
	}

	public HitPointEffector[] effectorHitPoints;

	public HitPointBone[] boneHitPoints;

	public bool xtd => false;

	public void lao(Collider a, Vector3 b, Vector3 c)
	{
	}

	protected override void kzn()
	{
	}
}
