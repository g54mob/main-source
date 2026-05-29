using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Modifiers/Radius Offset")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_radius_modifier.php")]
	public class RadiusModifier : MonoModifier
	{
		[Flags]
		private enum TangentType
		{
			OuterRight = 1,
			InnerRightLeft = 2,
			InnerLeftRight = 4,
			OuterLeft = 8,
			Outer = 9,
			Inner = 6
		}

		public float radius;

		public float detail;

		private float[] radi;

		private float[] a1;

		private float[] a2;

		private bool[] dir;

		public override int Order => 0;

		private bool CalculateCircleInner(Vector3 p1, Vector3 p2, float r1, float r2, out float a, out float sigma)
		{
			a = default(float);
			sigma = default(float);
			return false;
		}

		private bool CalculateCircleOuter(Vector3 p1, Vector3 p2, float r1, float r2, out float a, out float sigma)
		{
			a = default(float);
			sigma = default(float);
			return false;
		}

		private TangentType CalculateTangentType(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
		{
			return default(TangentType);
		}

		private TangentType CalculateTangentTypeSimple(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			return default(TangentType);
		}

		public override void Apply(Path p)
		{
		}

		public List<Vector3> Apply(List<Vector3> vs)
		{
			return null;
		}
	}
}
