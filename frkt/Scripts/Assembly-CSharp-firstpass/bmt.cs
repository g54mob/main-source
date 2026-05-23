using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bmt : MonoBehaviour
{
	[Serializable]
	public enum RotationMode
	{
		TwoDOF = 0,
		ThreeDOF = 1
	}

	[Serializable]
	public class Multiplier
	{
		public bms.WeightCurve.Type curve;

		public float multiplier;
	}

	public FullBodyBipedEffector effectorType;

	public Multiplier[] multipliers;

	public float interactionSpeedMlp;

	public Transform pivot;

	public RotationMode rotationMode;

	public Vector3 twistAxis;

	public float twistWeight;

	public float swingWeight;

	[Range(0f, 1f)]
	public float threeDOFWeight;

	public bool rotateOnce;

	public bool usePoser;

	public Transform[] bones;

	private Quaternion uaz;

	private Transform uba;

	public void blm(Transform a)
	{
	}

	private void kun()
	{
	}

	private void kuo()
	{
	}

	private void kuq()
	{
	}

	public float kut(bms.WeightCurve.Type a)
	{
		return 0f;
	}

	public void kcl(Transform a)
	{
	}

	private void kup()
	{
	}

	private void kul()
	{
	}

	public void hvs()
	{
	}

	public void kuv(Transform a)
	{
	}

	public void cqw(Transform a)
	{
	}

	public float lsl(bms.WeightCurve.Type a)
	{
		return 0f;
	}

	private void kur()
	{
	}

	public void gzj()
	{
	}

	private void kum()
	{
	}

	private void kus()
	{
	}

	public void blg(Transform a)
	{
	}

	public void kuu()
	{
	}
}
