using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Simple Smooth")]
	[RequireComponent(typeof(Seeker))]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_simple_smooth_modifier.php")]
	public class SimpleSmoothModifier : MonoModifier
	{
		public enum SmoothType
		{
			Simple = 0,
			Bezier = 1,
			OffsetSimple = 2,
			CurvedNonuniform = 3
		}

		public SmoothType smoothType;

		[Tooltip("The number of times to subdivide (divide in half) the path segments. [0...inf] (recommended [1...10])")]
		public int subdivisions;

		[Tooltip("Number of times to apply smoothing")]
		public int iterations;

		[Tooltip("Determines how much smoothing to apply in each smooth iteration. 0.5 usually produces the nicest looking curves")]
		[Range(0f, 1f)]
		public float strength;

		[Tooltip("Toggle to divide all lines in equal length segments")]
		public bool uniformLength;

		[Tooltip("The length of each segment in the smoothed path. A high value yields rough paths and low value yields very smooth paths, but is slower")]
		public float maxSegmentLength;

		[Tooltip("Length factor of the bezier curves' tangents")]
		public float bezierTangentLength;

		[Tooltip("Offset to apply in each smoothing iteration when using Offset Simple")]
		public float offset;

		[Tooltip("How much to smooth the path. A higher value will give a smoother path, but might take the character far off the optimal path.")]
		public float factor;

		private MiniMap m_MiniMap;

		public override int Order => 0;

		private void Start()
		{
		}

		public override void Apply(Path p)
		{
		}

		public List<Vector3> CurvedNonuniform(List<Vector3> path)
		{
			return null;
		}

		public static Vector3 GetPointOnCubic(Vector3 a, Vector3 b, Vector3 tan1, Vector3 tan2, float t)
		{
			return default(Vector3);
		}

		public List<Vector3> SmoothOffsetSimple(List<Vector3> path)
		{
			return null;
		}

		public List<Vector3> SmoothSimple(List<Vector3> path)
		{
			return null;
		}

		public List<Vector3> SmoothBezier(List<Vector3> path)
		{
			return null;
		}
	}
}
