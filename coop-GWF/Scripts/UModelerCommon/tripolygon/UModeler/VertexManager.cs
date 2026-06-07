using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class VertexManager
	{
		[SerializeField]
		private List<VertexInfo> vertices = new List<VertexInfo>();

		private Dictionary<Vertex, VertexInfo> vertexDict = new Dictionary<Vertex, VertexInfo>();

		public void Clear()
		{
			vertices.Clear();
			vertexDict.Clear();
		}

		public void UpdateAll(EditableMesh edMesh)
		{
			Clear();
			if (edMesh == null)
			{
				return;
			}
			using (new ShelfHolder(edMesh))
			{
				edMesh.shelf = 0;
				for (int i = 0; i < edMesh.GetPolygonCount(); i++)
				{
					UpdatePartially(edMesh.GetPolygon(i));
				}
			}
		}

		public bool UpdatePartially(List<SimplePolygon> polygons)
		{
			foreach (SimplePolygon polygon in polygons)
			{
				if (!RemovePolygon(polygon))
				{
					return false;
				}
			}
			foreach (SimplePolygon polygon2 in polygons)
			{
				for (int i = 0; i < polygon2.GetVertexCount(); i++)
				{
					if (!UpdateVertex(polygon2, polygon2.GetVertex(i), i))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool UpdatePartially(SimplePolygon polygon)
		{
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				if (!UpdateVertex(polygon, polygon.GetVertex(i), i))
				{
					return false;
				}
			}
			return true;
		}

		private bool UpdateVertex(SimplePolygon polygon, Vertex vertex, int vertexIndexHint = -1)
		{
			if (vertexIndexHint == -1)
			{
				vertexIndexHint = polygon.FindVertexIndex(vertex);
				if (vertexIndexHint == -1)
				{
					return false;
				}
			}
			if (vertexDict.TryGetValue(vertex, out var value))
			{
				if (!value.IsValid())
				{
					return false;
				}
				if (!Comparer.IsEquivalent(vertex.pos, value.pos))
				{
					RemoveVertex(vertex);
					if (!AddVertex(polygon, vertexIndexHint))
					{
						return false;
					}
				}
				else
				{
					Token token = value.FindToken(vertex);
					if (token == null)
					{
						return false;
					}
					token.Update(polygon, vertexIndexHint);
				}
			}
			else if (!AddVertex(polygon, vertexIndexHint))
			{
				return false;
			}
			return true;
		}

		public bool RemovePolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				if (!RemoveVertex(polygon.GetVertex(i)))
				{
					return false;
				}
			}
			return true;
		}

		private bool RemoveVertex(Vertex vertex)
		{
			if (vertexDict.TryGetValue(vertex, out var value))
			{
				if (!value.RemoveToken(vertex))
				{
					return false;
				}
				vertexDict.Remove(vertex);
				if (value.tokens.Count == 0)
				{
					vertices.Remove(value);
				}
			}
			return true;
		}

		public void RemoveVertexInfo(VertexInfo vi)
		{
			for (int i = 0; i < vi.tokens.Count; i++)
			{
				vertexDict.Remove(vi.tokens[i].vertex);
			}
			vertices.Remove(vi);
		}

		public bool AddVertex(SimplePolygon polygon, int vtxIndex)
		{
			Token token = new Token();
			token.polygon = polygon;
			token.vtxIndex = vtxIndex;
			if (vtxIndex < 0 || vtxIndex >= polygon.GetVertexCount())
			{
				return false;
			}
			Vertex vertex = polygon.GetVertex(vtxIndex);
			VertexInfo vertexInfo = FindVertexByPos(vertex.pos);
			if (vertexInfo == null)
			{
				vertexInfo = new VertexInfo();
				vertices.Add(vertexInfo);
			}
			vertexInfo.tokens.Add(token);
			vertexDict.Add(vertex, vertexInfo);
			return true;
		}

		public VertexInfo FindVertexByPos(Vector3 pos)
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				if (!vertices[i].IsValid())
				{
					return null;
				}
				if (Comparer.IsEquivalent(pos, vertices[i].pos))
				{
					return vertices[i];
				}
			}
			return null;
		}

		public void ResetSelected()
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				vertices[i].selection = SelectionType.UnSelected;
			}
		}

		public void RevertSelected()
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				if (vertices[i].selection == SelectionType.PreSelected)
				{
					vertices[i].RevertSelection();
				}
			}
		}

		public int GetVertexCount()
		{
			return vertices.Count;
		}

		public VertexInfo GetVertexInfo(int idx)
		{
			SimplePolygon polygon = vertices[idx].tokens[0].polygon;
			int vtxIndex = vertices[idx].tokens[0].vtxIndex;
			if (vtxIndex < 0 || vtxIndex >= polygon.GetVertexCount())
			{
				return null;
			}
			return vertices[idx];
		}
	}
}
