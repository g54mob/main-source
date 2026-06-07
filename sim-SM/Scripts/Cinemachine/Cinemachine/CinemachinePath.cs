using System;
using UnityEngine;

namespace Cinemachine
{
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[AddComponentMenu("Cinemachine/CinemachinePath")]
	[SaveDuringPlay]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachinePath.html")]
	public class CinemachinePath : CinemachinePathBase
	{
		[Serializable]
		[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
		public struct Waypoint
		{
			[Tooltip("Position in path-local space")]
			public Vector3 position;

			[Tooltip("Offset from the position, which defines the tangent of the curve at the waypoint.  The length of the tangent encodes the strength of the bezier handle.  The same handle is used symmetrically on both sides of the waypoint, to ensure smoothness.")]
			public Vector3 tangent;

			[Tooltip("Defines the roll of the path at this waypoint.  The other orientation axes are inferred from the tangent and world up.")]
			public float roll;
		}

		[Tooltip("If checked, then the path ends are joined to form a continuous loop.")]
		public bool m_Looped;

		[Tooltip("The waypoints that define the path.  They will be interpolated using a bezier curve.")]
		public Waypoint[] m_Waypoints;

		public override float MinPos => 0f;

		public override float MaxPos => 0f;

		public override bool Looped => false;

		public override int DistanceCacheSampleStepsPerSegment => 0;

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private float GetBoundingIndices(float pos, out int indexA, out int indexB)
		{
			indexA = default(int);
			indexB = default(int);
			return 0f;
		}

		public override Vector3 EvaluateLocalPosition(float pos)
		{
			return default(Vector3);
		}

		public override Vector3 EvaluateLocalTangent(float pos)
		{
			return default(Vector3);
		}

		public override Quaternion EvaluateLocalOrientation(float pos)
		{
			return default(Quaternion);
		}

		internal float GetRoll(int indexA, int indexB, float standardizedPos)
		{
			return 0f;
		}

		private static Quaternion RollAroundForward(float angle)
		{
			return default(Quaternion);
		}
	}
}
