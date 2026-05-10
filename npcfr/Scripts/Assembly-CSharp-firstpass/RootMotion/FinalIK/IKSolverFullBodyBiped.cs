using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverFullBodyBiped : IKSolverFullBody
	{
		public Transform rootNode;

		[Range(0f, 1f)]
		public float spineStiffness;

		[Range(-1f, 1f)]
		public float pullBodyVertical;

		[Range(-1f, 1f)]
		public float pullBodyHorizontal;

		private Vector3 tsh;

		public IKEffector xqk => null;

		public IKEffector xql => null;

		public IKEffector xqm => null;

		public IKEffector xqn => null;

		public IKEffector xqo => null;

		public IKEffector xqp => null;

		public IKEffector xqq => null;

		public IKEffector xqr => null;

		public IKEffector xqs => null;

		public FBIKChain xqt => null;

		public FBIKChain xqu => null;

		public FBIKChain xqv => null;

		public FBIKChain xqw => null;

		public IKMappingLimb xqx => null;

		public IKMappingLimb xqy => null;

		public IKMappingLimb xqz => null;

		public IKMappingLimb xra => null;

		public IKMappingBone xrb => null;

		public Vector3 tsg
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

		public void khk(FullBodyBipedChain a, float b, float c = 0f)
		{
		}

		public void khl(FullBodyBipedEffector a, float b, float c)
		{
		}

		public FBIKChain khm(FullBodyBipedChain a)
		{
			return null;
		}

		public FBIKChain khn(FullBodyBipedEffector a)
		{
			return null;
		}

		public IKEffector kho(FullBodyBipedEffector a)
		{
			return null;
		}

		public IKEffector khp(FullBodyBipedChain a)
		{
			return null;
		}

		public IKMappingLimb khq(FullBodyBipedChain a)
		{
			return null;
		}

		public IKMappingLimb khr(FullBodyBipedEffector a)
		{
			return null;
		}

		public IKMappingSpine khs()
		{
			return null;
		}

		public IKMappingBone kht()
		{
			return null;
		}

		public IKConstraintBend khu(FullBodyBipedChain a)
		{
			return null;
		}

		public override bool keb(ref string a)
		{
			return false;
		}

		public void khv(BipedReferences a, Transform b = null)
		{
		}

		public static Transform khw(BipedReferences a)
		{
			return null;
		}

		public void khx(BipedLimbOrientations a)
		{
		}

		private void kia(FullBodyBipedChain a, BipedLimbOrientations.LimbOrientation b)
		{
		}

		private static Transform kib(BipedReferences a)
		{
			return null;
		}

		private static Transform kic(BipedReferences a)
		{
			return null;
		}

		private static bool kid(Transform[] a, Transform b)
		{
			return false;
		}

		protected override void kgo()
		{
		}

		private void kie()
		{
		}

		private Vector3 kif()
		{
			return default(Vector3);
		}

		private Vector3 kig(IKEffector a, FBIKChain b, Vector3 c)
		{
			return default(Vector3);
		}

		protected override void kgq()
		{
		}

		protected override void kgr()
		{
		}
	}
}
