using Pathfinding.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct RasterizationMesh
	{
		public UnsafeSpan<float3> vertices;

		public UnsafeSpan<int> triangles;

		public UnsafeSpan<int> areas;

		public int area;

		public Bounds bounds;

		public Matrix4x4 matrix;

		public bool solid;

		public bool doubleSided;

		public bool flatten;
	}
}
