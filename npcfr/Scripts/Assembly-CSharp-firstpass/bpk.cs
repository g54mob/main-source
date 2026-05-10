using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bpk : MonoBehaviour
{
	[Serializable]
	public class Partner
	{
		public bmi ik;

		public Transform mouth;

		public Transform mouthTarget;

		public Transform touchTargetLeftHand;

		public Transform touchTargetRightHand;

		public float bodyWeightHorizontal;

		public float bodyWeightVertical;

		public float neckRotationWeight;

		public float headTiltAngle;

		public Vector3 headTiltAxis;

		private Quaternion uiy;

		private Transform xtx => null;

		public void lfh()
		{
		}

		public void lfi(float a)
		{
		}

		private void lfk(FullBodyBipedEffector a, Transform b, Vector3 c, float d)
		{
		}
	}

	public Partner partner1;

	public Partner partner2;

	[Range(0f, 1f)]
	public float weight;

	[Range(1f, 4f)]
	public int iterations;

	private void Start()
	{
	}

	private void gtf()
	{
	}

	private void fdv()
	{
	}

	private void LateUpdate()
	{
	}

	private void ird()
	{
	}
}
