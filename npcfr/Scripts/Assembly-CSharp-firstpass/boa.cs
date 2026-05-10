using System;
using RootMotion.FinalIK;
using UnityEngine;

public class boa : MonoBehaviour
{
	[Serializable]
	public class EffectorLink
	{
		public FullBodyBipedEffector effector;

		public Vector3 offset;

		public Vector3 pin;

		public Vector3 pinWeight;

		public Vector3 rotationOffset;

		public void lce(IKSolverFullBodyBiped a, float b, Quaternion c)
		{
		}
	}

	public EffectorLink[] effectorLinks;

	public void bzj(IKSolverFullBodyBiped a, float b, Quaternion c)
	{
	}

	public void lcg(IKSolverFullBodyBiped a, float b, Quaternion c)
	{
	}

	public void cmr(IKSolverFullBodyBiped a, float b)
	{
	}

	public void inb(IKSolverFullBodyBiped a, float b, Quaternion c)
	{
	}

	public void mzk(IKSolverFullBodyBiped a, float b)
	{
	}

	public void lcf(IKSolverFullBodyBiped a, float b)
	{
	}

	public void jip(IKSolverFullBodyBiped a, float b)
	{
	}
}
