using UnityEngine;

namespace Photon.Pun.Demo.SlotRacer.Utils
{
	public class BezierSpline : MonoBehaviour
	{
		[SerializeField]
		private Vector3[] points;

		[SerializeField]
		private float[] lengths;

		[SerializeField]
		private float[] lengthsTime;

		public float TotalLength;

		[SerializeField]
		private BezierControlPointMode[] modes;

		[SerializeField]
		private bool loop;

		public bool Loop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int ControlPointCount => 0;

		public int CurveCount => 0;

		private void Awake()
		{
		}

		public Vector3 GetControlPoint(int index)
		{
			return default(Vector3);
		}

		public void SetControlPoint(int index, Vector3 point)
		{
		}

		public BezierControlPointMode GetControlPointMode(int index)
		{
			return default(BezierControlPointMode);
		}

		public void SetControlPointMode(int index, BezierControlPointMode mode)
		{
		}

		private void EnforceMode(int index)
		{
		}

		public Vector3 GetPoint(float t)
		{
			return default(Vector3);
		}

		public Vector3 GetVelocity(float t)
		{
			return default(Vector3);
		}

		public Vector3 GetDirection(float t)
		{
			return default(Vector3);
		}

		public void AddCurve()
		{
		}

		public void Reset()
		{
		}

		public void ComputeLengths()
		{
		}

		public Vector3 GetPositionAtDistance(float distance, bool reverse = false)
		{
			return default(Vector3);
		}
	}
}
