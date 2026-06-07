using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bpl : bnx
{
	[Serializable]
	public enum Mode
	{
		Position = 0,
		PositionOffset = 1
	}

	[Serializable]
	public class Absorber
	{
		public FullBodyBipedEffector effector;

		public float weight;

		private Vector3 uiz;

		private Quaternion uja;

		private IKEffector ujb;

		public void lfl(IKSolverFullBodyBiped a, Mode b)
		{
		}

		public void lfm(float a)
		{
		}

		public void lfn(float a)
		{
		}

		public void lfo(float a)
		{
		}
	}

	public Mode mode;

	public Absorber[] absorbers;

	public AnimationCurve falloff;

	public float falloffSpeed;

	private float ujc;

	private float ujd;

	private Mode uje;

	private void bti(Collision c)
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void kzn()
	{
	}

	private void lfp()
	{
	}

	protected override void Start()
	{
	}

	private void OnCollisionEnter(Collision c)
	{
	}

	private void oon()
	{
	}
}
