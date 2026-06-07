using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class MeshVertexChunk : IEnumerable<Vector3>, IEnumerable
	{
		private List<Vector3> _modelSpaceVerts = new List<Vector3>(100);

		private AABB _modelSpaceAABB;

		private Mesh _mesh;

		public Vector3 this[int vertexIndex] => _modelSpaceVerts[vertexIndex];

		public Mesh Mesh => _mesh;

		public int VertexCount => _modelSpaceVerts.Count;

		public AABB ModelSpaceAABB => _modelSpaceAABB;

		public MeshVertexChunk(List<Vector3> modelSpaceVerts, Mesh mesh)
		{
			_modelSpaceVerts = new List<Vector3>(modelSpaceVerts);
			_mesh = mesh;
			_modelSpaceAABB = new AABB(_modelSpaceVerts);
		}

		public IEnumerator<Vector3> GetEnumerator()
		{
			return _modelSpaceVerts.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Vector3 GetWorldVertClosestToScreenPt(Vector2 screenPoint, Matrix4x4 worldMtx, Camera camera)
		{
			float num = float.MaxValue;
			Vector3 result = Vector3.zero;
			foreach (Vector3 modelSpaceVert in _modelSpaceVerts)
			{
				Vector3 vector = worldMtx.MultiplyPoint(modelSpaceVert);
				float sqrMagnitude = ((Vector2)camera.WorldToScreenPoint(vector) - screenPoint).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = vector;
				}
			}
			return result;
		}
	}
}
