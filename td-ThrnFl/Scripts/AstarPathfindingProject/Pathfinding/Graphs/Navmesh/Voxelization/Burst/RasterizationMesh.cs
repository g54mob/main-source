using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct RasterizationMesh
	{
		public UnsafeSpan<float3> vertices;

		public UnsafeSpan<int> triangles;

		public int area;

		public Bounds bounds;

		public Matrix4x4 matrix;

		public bool solid;

		public bool doubleSided;

		public bool areaIsTag;

		public bool flatten;
	}
}
