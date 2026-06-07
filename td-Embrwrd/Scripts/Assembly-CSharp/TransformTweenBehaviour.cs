using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class TransformTweenBehaviour : PlayableBehaviour
{
	public enum TweenType
	{
		Linear = 0,
		Deceleration = 1,
		Harmonic = 2,
		Custom = 3
	}

	public Transform startLocation;

	public Transform endLocation;

	public bool tweenPosition;

	public bool tweenRotation;

	public TweenType tweenType;

	public AnimationCurve customCurve;

	public Vector3 startingPosition;

	public Quaternion startingRotation;

	private AnimationCurve m_LinearCurve;

	private AnimationCurve m_DecelerationCurve;

	private AnimationCurve m_HarmonicCurve;

	private const float k_RightAngleInRads = (float)Math.PI / 2f;

	public override void PrepareFrame(Playable playable, FrameData info)
	{
	}

	public float EvaluateCurrentCurve(float time)
	{
		return 0f;
	}

	private bool IsCustomCurveNormalised()
	{
		return false;
	}
}
