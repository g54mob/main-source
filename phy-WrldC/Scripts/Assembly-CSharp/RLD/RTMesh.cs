using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTMesh
	{
		private Mesh _unityMesh;

		private Vector3[] _vertices;

		private int[] _vertIndices;

		private int _numTriangles;

		private AABB _aabb;

		private MeshTree _meshTree;

		public int NumTriangles => _numTriangles;

		public Mesh UnityMesh => _unityMesh;

		public AABB AABB => _aabb;

		public bool IsTreeBuilt => _meshTree.IsBuilt;

		public RTMesh(Mesh unityMesh)
		{
			_unityMesh = unityMesh;
			_vertices = _unityMesh.vertices;
			_vertIndices = unityMesh.triangles;
			_numTriangles = _vertIndices.Length / 3;
			_meshTree = new MeshTree(this);
			_aabb = new AABB(unityMesh.bounds);
		}

		public static RTMesh Create(Mesh unityMesh)
		{
			if (unityMesh == null || !unityMesh.isReadable)
			{
				return null;
			}
			return new RTMesh(unityMesh);
		}

		public void BuildTree()
		{
			_meshTree.Build();
		}

		public MeshTriangle GetTriangle(int triangleIndex)
		{
			int num = triangleIndex * 3;
			int num2 = _vertIndices[num];
			int num3 = _vertIndices[num + 1];
			int num4 = _vertIndices[num + 2];
			return new MeshTriangle(new Vector3[3]
			{
				_vertices[num2],
				_vertices[num3],
				_vertices[num4]
			}, triangleIndex, num2, num3, num4);
		}

		public MeshRayHit Raycast(Ray ray, Matrix4x4 meshTransform)
		{
			return _meshTree.RaycastClosest(ray, meshTransform);
		}

		public List<Vector3> OverlapVerts(OBB obb, Transform meshObjectTransform)
		{
			return _meshTree.OverlapVerts(obb, new MeshTransform(meshObjectTransform));
		}

		public List<Vector3> OverlapModelVerts(OBB modelOBB)
		{
			return _meshTree.OverlapModelVerts(modelOBB);
		}

		public List<Vector3> OverlapModelVerts(AABB modelAABB)
		{
			return _meshTree.OverlapModelVerts(new OBB(modelAABB));
		}

		public void DebugDrawTree()
		{
			_meshTree.DebugDraw();
		}
	}
}
