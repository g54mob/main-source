using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	public class MeshExt
	{
		public static Dictionary<int, MeshOctree> MeshOctrees;

		public static Dictionary<int, float> MeshParseTime;

		public static Transform DebugTransform;

		public static Vector3 ClosestVertex(Vector3 rPoint, Transform rTransform, Mesh rMesh)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPoint(Vector3 rPoint, float rRadius, Transform rTransform, Mesh rMesh)
		{
			return default(Vector3);
		}

		public static void ClosestPointOnTriangle(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 result)
		{
			result = default(Vector3);
		}
	}
}
