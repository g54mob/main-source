using System;
using RootMotion.FinalIK;
using UnityEngine;

public class boc : bnx
{
	[Serializable]
	public class RecoilOffset
	{
		[Serializable]
		public class EffectorLink
		{
			public FullBodyBipedEffector effector;

			public float weight;
		}

		public Vector3 offset;

		[Range(0f, 1f)]
		public float additivity;

		public float maxAdditiveOffsetMag;

		public EffectorLink[] effectorLinks;

		private Vector3 ufv;

		private Vector3 ufw;

		public void lck()
		{
		}

		public void lcl(IKSolverFullBodyBiped a, Quaternion b, float c, float d, float e)
		{
		}
	}

	[Serializable]
	public enum Handedness
	{
		Right = 0,
		Left = 1
	}

	public bmd aimIK;

	public bmd headIK;

	public bool aimIKSolvedLast;

	public Handedness handedness;

	public bool twoHanded;

	public AnimationCurve recoilWeight;

	public float magnitudeRandom;

	public Vector3 rotationRandom;

	public Vector3 handRotationOffset;

	public float blendTime;

	[Space(10f)]
	public RecoilOffset[] offsets;

	[HideInInspector]
	public Quaternion rotationOffset;

	private float ufx;

	private float ufy;

	private Quaternion ufz;

	private Quaternion uga;

	private Quaternion ugb;

	private float ugc;

	private bool ugd;

	private float uge;

	private float ugf;

	private Quaternion ugg;

	private bool ugh;

	private Vector3 ugi;

	public bool xtl => false;

	private IKEffector xtm => null;

	private IKEffector xtn => null;

	private Transform xto => null;

	private Transform xtp => null;

	public void lal(float a)
	{
	}

	private void blq()
	{
	}

	public void eyf(float a)
	{
	}

	public void lco(float a)
	{
	}

	public void oes(Quaternion a, Quaternion b)
	{
	}

	private void ewj()
	{
	}

	private void jkq()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void hic(Quaternion a, Quaternion b)
	{
	}

	private void izk()
	{
	}

	private void lcp()
	{
	}

	public void lcn(Quaternion a, Quaternion b)
	{
	}

	protected override void kzn()
	{
	}

	public void lae(Quaternion a, Quaternion b)
	{
	}

	public void itw(Quaternion a, Quaternion b)
	{
	}

	private void lcq()
	{
	}

	private void fgo()
	{
	}

	private void jsb()
	{
	}
}
