using Cinemachine;
using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Link (Cinemachine Path)")]
	public class PathLink_Cinemachine : MonoBehaviour, IPath
	{
		[RequiredField]
		public CinemachinePathBase m_Path;

		[Tooltip("Resolution to find the closest point on the path")]
		[Min(1f)]
		public int m_SearchResolution = 50;

		private static readonly CinemachinePathBase.PositionUnits Normalized = CinemachinePathBase.PositionUnits.Normalized;

		public Vector3 StartPath => GetPointAtTime(0f);

		public Vector3 EndPath => GetPointAtTime(1f);

		public bool IsClosed => m_Path.Looped;

		public Bounds bounds => CalculateBounds();

		public float GetClosestTimeOnPath(Vector3 position)
		{
			return FindClosestPoint(position, m_SearchResolution);
		}

		public Quaternion GetPathRotation(float NormalizedTime)
		{
			return m_Path.EvaluateOrientationAtUnit(NormalizedTime, Normalized);
		}

		public Vector3 GetPointAtTime(float NormalizedTime)
		{
			return m_Path.EvaluatePositionAtUnit(NormalizedTime, Normalized);
		}

		private float FindClosestPoint(Vector3 p, int stepsPerSegment)
		{
			stepsPerSegment = Mathf.RoundToInt(Mathf.Clamp(stepsPerSegment, 1f, 100f));
			float num = 1f / (float)stepsPerSegment;
			float num2 = 1f;
			float result = 0f;
			float num3 = float.MaxValue;
			int distanceCacheSampleStepsPerSegment = m_Path.DistanceCacheSampleStepsPerSegment;
			num /= (float)distanceCacheSampleStepsPerSegment;
			Vector3 vector = m_Path.EvaluatePosition(0f);
			for (float num4 = 0f; num4 <= num2; num4 += num)
			{
				float pos = m_Path.StandardizeUnit(num4, Normalized);
				Vector3 vector2 = m_Path.EvaluatePositionAtUnit(pos, Normalized);
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

		internal Bounds CalculateBounds()
		{
			Bounds result = default(Bounds);
			for (int i = 0; i <= 50; i++)
			{
				Vector3 position = m_Path.EvaluatePositionAtUnit((float)i / 10f, Normalized);
				result.Encapsulate(base.transform.InverseTransformPoint(position));
			}
			return result;
		}

		private void Reset()
		{
			CinemachineSmoothPath component = GetComponent<CinemachineSmoothPath>();
			if (component == null)
			{
				m_Path = base.gameObject.AddComponent<CinemachineSmoothPath>();
			}
			else
			{
				m_Path = component;
			}
		}
	}
}
