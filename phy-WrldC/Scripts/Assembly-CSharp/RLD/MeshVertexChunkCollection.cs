using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class MeshVertexChunkCollection : IEnumerable<MeshVertexChunk>, IEnumerable
	{
		private struct VertexChunkIndices
		{
			private int _XIndex;

			private int _YIndex;

			private int _ZIndex;

			public int XIndex => _XIndex;

			public int YIndex => _YIndex;

			public int ZIndex => _ZIndex;

			public VertexChunkIndices(int xIndex, int yIndex, int zIndex)
			{
				_XIndex = xIndex;
				_YIndex = yIndex;
				_ZIndex = zIndex;
			}
		}

		private Mesh _mesh;

		private List<MeshVertexChunk> _vertexChunks = new List<MeshVertexChunk>(50);

		public MeshVertexChunk this[int chunkIndex] => _vertexChunks[chunkIndex];

		public int Count => _vertexChunks.Count;

		public IEnumerator<MeshVertexChunk> GetEnumerator()
		{
			return _vertexChunks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public List<MeshVertexChunk> GetWorldChunksHoveredByPoint(Vector3 hoverPoint, Matrix4x4 worldMtx, Camera camera)
		{
			List<MeshVertexChunk> list = new List<MeshVertexChunk>();
			foreach (MeshVertexChunk vertexChunk in _vertexChunks)
			{
				AABB modelSpaceAABB = vertexChunk.ModelSpaceAABB;
				modelSpaceAABB.Transform(worldMtx);
				if (modelSpaceAABB.GetScreenRectangle(camera).Contains(hoverPoint, allowInverse: true))
				{
					list.Add(vertexChunk);
				}
			}
			return list;
		}

		public MeshVertexChunk GetWorldVertChunkClosestToScreenPt(Vector2 screenPoint, Matrix4x4 worldMtx, Camera camera)
		{
			float num = float.MaxValue;
			MeshVertexChunk result = null;
			foreach (MeshVertexChunk vertexChunk in _vertexChunks)
			{
				AABB modelSpaceAABB = vertexChunk.ModelSpaceAABB;
				modelSpaceAABB.Transform(worldMtx);
				foreach (Vector2 screenCenterAndCornerPoint in modelSpaceAABB.GetScreenCenterAndCornerPoints(camera))
				{
					float sqrMagnitude = (screenCenterAndCornerPoint - screenPoint).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = vertexChunk;
					}
				}
			}
			return result;
		}

		public bool FromMesh(Mesh mesh)
		{
			if (mesh == null || !mesh.isReadable)
			{
				return false;
			}
			Bounds bounds = mesh.bounds;
			Vector3[] vertices = mesh.vertices;
			float num = bounds.size.x / 2f;
			float num2 = bounds.size.y / 2f;
			float num3 = bounds.size.z / 2f;
			Dictionary<VertexChunkIndices, List<Vector3>> dictionary = new Dictionary<VertexChunkIndices, List<Vector3>>();
			Vector3[] array = vertices;
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 item = array[i];
				int xIndex = Mathf.FloorToInt(item.x / num);
				int yIndex = Mathf.FloorToInt(item.y / num2);
				int zIndex = Mathf.FloorToInt(item.z / num3);
				VertexChunkIndices key = new VertexChunkIndices(xIndex, yIndex, zIndex);
				if (dictionary.ContainsKey(key))
				{
					dictionary[key].Add(item);
					continue;
				}
				dictionary.Add(key, new List<Vector3>(50));
				dictionary[key].Add(item);
			}
			if (dictionary.Count == 0)
			{
				return false;
			}
			_mesh = mesh;
			_vertexChunks.Clear();
			foreach (KeyValuePair<VertexChunkIndices, List<Vector3>> item2 in dictionary)
			{
				if (item2.Value.Count != 0)
				{
					_vertexChunks.Add(new MeshVertexChunk(item2.Value, _mesh));
				}
			}
			return true;
		}
	}
}
