using System;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

public class bnt : bnz
{
	[Serializable]
	public abstract class Offset
	{
		public string name;

		public Collider collider;

		[SerializeField]
		private float crossFadeTime;

		private float uer;

		private float ues;

		private float uet;

		protected float ueo
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

		protected float uep
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

		protected Vector3 ueq
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

		public virtual void lav(Vector3 a, AnimationCurve[] b, Vector3 c)
		{
		}

		public void law(bmo a, AnimationCurve[] b, float c)
		{
		}

		protected abstract float lax(AnimationCurve[] a);

		protected abstract void lay();

		protected abstract void laz(bmo a, AnimationCurve[] b, float c);
	}

	[Serializable]
	public class PositionOffset : Offset
	{
		[Serializable]
		public class PositionOffsetLink
		{
			public IKSolverVR.PositionOffset positionOffset;

			public float weight;

			private Vector3 ueu;

			private Vector3 current;

			public void lba(bmo a, Vector3 b, float c)
			{
			}

			public void lbb()
			{
			}
		}

		public int forceDirCurveIndex;

		public int upDirCurveIndex;

		public PositionOffsetLink[] offsetLinks;

		protected override float lax(AnimationCurve[] a)
		{
			return 0f;
		}

		protected override void lay()
		{
		}

		protected override void laz(bmo a, AnimationCurve[] b, float c)
		{
		}
	}

	[Serializable]
	public class RotationOffset : Offset
	{
		[Serializable]
		public class RotationOffsetLink
		{
			public IKSolverVR.RotationOffset rotationOffset;

			[Range(0f, 1f)]
			public float weight;

			private Quaternion uev;

			private Quaternion current;

			public void lbc(bmo a, Quaternion b, float c)
			{
			}

			public void lbd()
			{
			}
		}

		public int curveIndex;

		public RotationOffsetLink[] offsetLinks;

		private Rigidbody uew;

		private Vector3 uex;

		public override void lav(Vector3 a, AnimationCurve[] b, Vector3 c)
		{
		}

		protected override float lax(AnimationCurve[] a)
		{
			return 0f;
		}

		protected override void lay()
		{
		}

		protected override void laz(bmo a, AnimationCurve[] b, float c)
		{
		}
	}

	public AnimationCurve[] offsetCurves;

	public PositionOffset[] positionOffsets;

	public RotationOffset[] rotationOffsets;

	protected override void lbe()
	{
	}

	public void bjf(Collider a, Vector3 b, Vector3 c)
	{
	}

	public void dvy(Collider a, Vector3 b, Vector3 c)
	{
	}

	public void kqx(Collider a, Vector3 b, Vector3 c)
	{
	}

	public void lbf(Collider a, Vector3 b, Vector3 c)
	{
	}
}
