using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKMappingBone : IKMapping
	{
		public Transform bone;

		[Range(0f, 1f)]
		public float maintainRotationWeight;

		private BoneMap trf;

		public override bool kcq(IKSolver a, ref string b)
		{
			return false;
		}

		public IKMappingBone()
		{
		}

		public IKMappingBone(Transform bone)
		{
		}

		public void kcu()
		{
		}

		public void kcv()
		{
		}

		public override void kcr(IKSolverFullBody a)
		{
		}

		public void kcw()
		{
		}

		public void kcx(float a)
		{
		}
	}
}
