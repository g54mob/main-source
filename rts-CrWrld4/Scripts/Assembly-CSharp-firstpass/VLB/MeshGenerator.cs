using UnityEngine;

namespace VLB
{
	public static class MeshGenerator
	{
		private const float kMinTruncatedRadius = 0.001f;

		public static Mesh GenerateConeZ_RadiusAndAngle(float lengthZ, float radiusStart, float coneAngle, int numSides, int numSegments, bool cap, bool doubleSided)
		{
			return null;
		}

		public static Mesh GenerateConeZ_Angle(float lengthZ, float coneAngle, int numSides, int numSegments, bool cap, bool doubleSided)
		{
			return null;
		}

		public static Mesh GenerateConeZ_Radius(float lengthZ, float radiusStart, float radiusEnd, int numSides, int numSegments, bool cap, bool doubleSided)
		{
			return null;
		}

		public static int GetVertexCount(int numSides, int numSegments, bool geomCap, bool doubleSided)
		{
			return 0;
		}

		public static int GetIndicesCount(int numSides, int numSegments, bool geomCap, bool doubleSided)
		{
			return 0;
		}

		public static int GetSharedMeshVertexCount()
		{
			return 0;
		}

		public static int GetSharedMeshIndicesCount()
		{
			return 0;
		}
	}
}
