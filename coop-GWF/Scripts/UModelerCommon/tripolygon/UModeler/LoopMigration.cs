using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class LoopMigration
	{
		public int[] vertexIndices;

		public int[] UVIndices;

		private VertexInfo GetVertexInfo(EditableMeshCache editableMeshCache, Vertex vertex)
		{
			VertexInfo vertexInfo = editableMeshCache.GetVertexInfo(vertex);
			if (vertexInfo == null)
			{
				vertexInfo = editableMeshCache.FindVertexByComparer(vertex);
			}
			if (vertexInfo == null)
			{
				Debug.Log($"ConnotFound {vertex}");
			}
			return vertexInfo;
		}

		internal void SetLoopVertices(EditableMeshCache editableMeshCache, List<Vertex> vertices, Dictionary<VertexInfo, int> sortingVertices)
		{
			vertexIndices = new int[vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				if (sortingVertices.TryGetValue(GetVertexInfo(editableMeshCache, vertices[i]), out var value))
				{
					vertexIndices[i] = value;
				}
			}
		}

		internal void SetLoopUVs(EditableMeshCache editableMeshCache, List<Vertex> vertices, Dictionary<VertexInfo, int> sortingUVs)
		{
			UVIndices = new int[vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				if (sortingUVs.TryGetValue(GetVertexInfo(editableMeshCache, vertices[i]), out var value))
				{
					UVIndices[i] = value;
					continue;
				}
				foreach (KeyValuePair<VertexInfo, int> sortingUV in sortingUVs)
				{
					if (sortingUV.Key.FindToken(vertices[i]) != null)
					{
						UVIndices[i] = sortingUV.Value;
						break;
					}
				}
			}
		}
	}
}
