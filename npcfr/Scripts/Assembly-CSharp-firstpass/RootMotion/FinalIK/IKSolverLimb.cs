using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverLimb : IKSolverTrigonometric
	{
		[Serializable]
		public enum BendModifier
		{
			Animation = 0,
			Target = 1,
			Parent = 2,
			Arm = 3,
			Goal = 4
		}

		[Serializable]
		public struct AxisDirection
		{
			public Vector3 direction;

			public Vector3 axis;

			public float dot;

			public AxisDirection(Vector3 direction, Vector3 axis)
			{
				this.direction = default(Vector3);
				this.axis = default(Vector3);
				dot = 0f;
			}
		}

		public AvatarIKGoal goal;

		public BendModifier bendModifier;

		[Range(0f, 1f)]
		public float maintainRotationWeight;

		[Range(0f, 1f)]
		public float bendModifierWeight;

		public Transform bendGoal;

		private bool tsm;

		private bool tsn;

		private Quaternion tso;

		private Quaternion tsp;

		private Quaternion tsq;

		private Quaternion tsr;

		private Quaternion tss;

		private Vector3 tst;

		private Vector3 tsu;

		private AxisDirection[] tsv;

		private AxisDirection[] tsw;

		private AxisDirection[] xre => null;

		public void kit()
		{
		}

		public void kiu()
		{
		}

		protected override void kiv()
		{
		}

		protected override void kiw()
		{
		}

		protected override void kix()
		{
		}

		public IKSolverLimb()
		{
		}

		public IKSolverLimb(AvatarIKGoal goal)
		{
		}

		private void kiz(ref AxisDirection[] a)
		{
		}

		private Vector3 kja()
		{
			return default(Vector3);
		}
	}
}
