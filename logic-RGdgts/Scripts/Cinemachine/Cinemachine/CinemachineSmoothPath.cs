using System;
using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[DisallowMultipleComponent]
	public class CinemachineSmoothPath : CinemachinePathBase
	{
		[Serializable]
		public struct Waypoint
		{
			public Vector3 position;

			public float roll;

			internal Vector4 AsVector4 => default(Vector4);

			internal static Waypoint FromVector4(Vector4 v)
			{
				return default(Waypoint);
			}
		}

		public bool m_Looped;

		public Waypoint[] m_Waypoints;

		private Waypoint[] m_ControlPoints1;

		private Waypoint[] m_ControlPoints2;

		private bool m_IsLoopedCache;

		public override float MinPos => 0f;

		public override float MaxPos => 0f;

		public override bool Looped => false;

		public override int DistanceCacheSampleStepsPerSegment => 0;

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}

		public override void InvalidateDistanceCache()
		{
		}

		private void UpdateControlPoints()
		{
		}

		private float GetBoundingIndices(float pos, out int indexA, out int indexB)
		{
			indexA = default(int);
			indexB = default(int);
			return 0f;
		}

		public override Vector3 EvaluatePosition(float pos)
		{
			return default(Vector3);
		}

		public override Vector3 EvaluateTangent(float pos)
		{
			return default(Vector3);
		}

		public override Quaternion EvaluateOrientation(float pos)
		{
			return default(Quaternion);
		}

		private Quaternion RollAroundForward(float angle)
		{
			return default(Quaternion);
		}
	}
}
