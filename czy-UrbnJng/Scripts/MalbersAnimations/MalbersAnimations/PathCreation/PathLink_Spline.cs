using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Link (Unity Spline)")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/path-constraint/path-link-spline")]
	public class PathLink_Spline : MonoBehaviour, IPath
	{
		public SplineContainer spline;

		[Tooltip("Resolution to find the closest point on the path")]
		[Min(1f)]
		public int m_SearchResolution = 50;

		public Vector3 StartPath => spline.EvaluatePosition(0f);

		public Vector3 EndPath => spline.EvaluatePosition(1f);

		public bool IsClosed => spline.Spline.Closed;

		public Bounds bounds => spline.Spline.GetBounds();

		public float GetClosestTimeOnPath(Vector3 position)
		{
			return FindClosestPoint(position, m_SearchResolution);
		}

		public Quaternion GetPathRotation(float NormalizedTime)
		{
			Vector3 forward = Vector3.Normalize(spline.EvaluateTangent(NormalizedTime));
			float3 float5 = spline.EvaluateUpVector(NormalizedTime);
			return Quaternion.LookRotation(forward, float5);
		}

		public Vector3 GetPointAtTime(float NormalizedTime)
		{
			return spline.EvaluatePosition(NormalizedTime);
		}

		private float FindClosestPoint(Vector3 p, int stepsPerSegment)
		{
			stepsPerSegment = Mathf.RoundToInt(Mathf.Clamp(stepsPerSegment, 1f, 100f));
			float num = 1f / (float)stepsPerSegment;
			float num2 = 1f;
			float result = 0f;
			float num3 = float.MaxValue;
			Vector3 vector = spline.EvaluatePosition(0f);
			for (float num4 = 0f; num4 <= num2; num4 += num)
			{
				Vector3 vector2 = spline.EvaluatePosition(num4);
				float num5 = p.ClosestTimeOnSegment(vector, vector2);
				float num6 = Vector3.SqrMagnitude(p - Vector3.Lerp(vector, vector2, num5));
				if (num6 < num3)
				{
					num3 = num6;
					result = num4 - (1f - num5) * num;
				}
				vector = vector2;
			}
			return result;
		}

		private void Reset()
		{
			spline = GetComponent<SplineContainer>();
		}

		private void OnDrawGizmos()
		{
			if (!(spline == null) && !spline.Spline.Closed)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(StartPath, 0.02f * base.transform.localScale.y);
				Gizmos.DrawSphere(EndPath, 0.02f * base.transform.localScale.y);
			}
		}
	}
}
