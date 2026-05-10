using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bot : bnx
{
	[Serializable]
	public struct Warp
	{
		public int animationLayer;

		public string animationState;

		public AnimationCurve weightCurve;

		public Transform warpFrom;

		public Transform warpTo;

		public FullBodyBipedEffector effector;
	}

	[Serializable]
	public enum EffectorMode
	{
		PositionOffset = 0,
		Position = 1
	}

	public Animator animator;

	public EffectorMode effectorMode;

	[Space(10f)]
	public Warp[] warps;

	private EffectorMode uhs;

	private void lop()
	{
	}

	public float leq(int a)
	{
		return 0f;
	}

	public float mxi(int a)
	{
		return 0f;
	}

	private void hln()
	{
	}

	private void OnDisable()
	{
	}

	protected override void kzn()
	{
	}

	protected override void Start()
	{
	}
}
