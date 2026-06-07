using UnityEngine;

namespace com.ootii.Geometry
{
	public class BezierSpline : MonoBehaviour
	{
		[SerializeField]
		private Vector3[] mPoints;

		[SerializeField]
		private int[] mControlConstraints;

		[SerializeField]
		private int mSegments;

		[SerializeField]
		private bool mLoop;

		private float mLength;

		private float[] mCurveLengths;

		public Vector3[] Points => null;

		public int Segments
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		public float Length => 0f;

		public int ControlPointCount => 0;

		public int CurveCount => 0;

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void AddControlPoint()
		{
		}

		public void InsertControlPoint(int rIndex)
		{
		}

		public void DeleteControlPoint(int rIndex)
		{
		}

		public Vector3 GetControlPoint(int rIndex)
		{
			return default(Vector3);
		}

		public void SetControlPoint(int rIndex, Vector3 rPoint)
		{
		}

		public int GetControlPointConstraint(int rIndex)
		{
			return 0;
		}

		public void SetControlPointConstraint(int rIndex, int rConstraint)
		{
		}

		public Vector3 GetBackwardTangentPoint(int rIndex)
		{
			return default(Vector3);
		}

		public void SetBackwardTangentPoint(int rIndex, Vector3 rPoint)
		{
		}

		public Vector3 GetForwardTangentPoint(int rIndex)
		{
			return default(Vector3);
		}

		public void SetForwardTangentPoint(int rIndex, Vector3 rPoint)
		{
		}

		public Vector3 GetPoint(float rPercent)
		{
			return default(Vector3);
		}

		public Vector3 GetPoint(int rCurveIndex, float rPercent)
		{
			return default(Vector3);
		}

		public Vector3 GetVelocity(float rPercent)
		{
			return default(Vector3);
		}

		public Vector3 GetVelocity(int rCurveIndex, float rPercent)
		{
			return default(Vector3);
		}

		public Vector3 GetDirection(float rPercent)
		{
			return default(Vector3);
		}

		public Vector3 GetDirection(int rCurveIndex, float rPercent)
		{
			return default(Vector3);
		}

		public void GetCurvePercent(float rPercent, ref int rCurveIndex, ref float rCurvePercent)
		{
		}

		public void ApplyControlPointConstraint(int rIndex, bool rLeadWithBackwardCP)
		{
		}

		public float CalculateCurveLengths()
		{
			return 0f;
		}

		public static Vector3 GetQuadradicPoint(Vector3 rP0, Vector3 rP1, Vector3 rP2, float rTime)
		{
			return default(Vector3);
		}

		public static Vector3 GetFirstQuadradicDerivative(Vector3 rP0, Vector3 rP1, Vector3 rP2, float rTime)
		{
			return default(Vector3);
		}

		public static Vector3 GetCubicPoint(Vector3 rP0, Vector3 rP1, Vector3 rP2, Vector3 rP3, float rTime)
		{
			return default(Vector3);
		}

		public static Vector3 GetFirstCubicDerivative(Vector3 rP0, Vector3 rP1, Vector3 rP2, Vector3 rP3, float rTime)
		{
			return default(Vector3);
		}
	}
}
