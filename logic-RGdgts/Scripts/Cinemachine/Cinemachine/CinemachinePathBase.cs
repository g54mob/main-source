using System;
using UnityEngine;

namespace Cinemachine
{
	public abstract class CinemachinePathBase : MonoBehaviour
	{
		[Serializable]
		public class Appearance
		{
			public Color pathColor;

			public Color inactivePathColor;

			public float width;
		}

		public enum PositionUnits
		{
			PathUnits = 0,
			Distance = 1,
			Normalized = 2
		}

		public int m_Resolution;

		public Appearance m_Appearance;

		private float[] m_DistanceToPos;

		private float[] m_PosToDistance;

		private int m_CachedSampleSteps;

		private float m_PathLength;

		private float m_cachedPosStepSize;

		private float m_cachedDistanceStepSize;

		public abstract float MinPos { get; }

		public abstract float MaxPos { get; }

		public abstract bool Looped { get; }

		public abstract int DistanceCacheSampleStepsPerSegment { get; }

		public float PathLength => 0f;

		public virtual float StandardizePos(float pos)
		{
			return 0f;
		}

		public abstract Vector3 EvaluatePosition(float pos);

		public abstract Vector3 EvaluateTangent(float pos);

		public abstract Quaternion EvaluateOrientation(float pos);

		public virtual float FindClosestPoint(Vector3 p, int startSegment, int searchRadius, int stepsPerSegment)
		{
			return 0f;
		}

		public float MinUnit(PositionUnits units)
		{
			return 0f;
		}

		public float MaxUnit(PositionUnits units)
		{
			return 0f;
		}

		public virtual float StandardizeUnit(float pos, PositionUnits units)
		{
			return 0f;
		}

		public Vector3 EvaluatePositionAtUnit(float pos, PositionUnits units)
		{
			return default(Vector3);
		}

		public Vector3 EvaluateTangentAtUnit(float pos, PositionUnits units)
		{
			return default(Vector3);
		}

		public Quaternion EvaluateOrientationAtUnit(float pos, PositionUnits units)
		{
			return default(Quaternion);
		}

		public virtual void InvalidateDistanceCache()
		{
		}

		public bool DistanceCacheIsValid()
		{
			return false;
		}

		public float StandardizePathDistance(float distance)
		{
			return 0f;
		}

		public float ToNativePathUnits(float pos, PositionUnits units)
		{
			return 0f;
		}

		public float FromPathNativeUnits(float pos, PositionUnits units)
		{
			return 0f;
		}

		private void ResamplePath(int stepsPerSegment)
		{
		}
	}
}
