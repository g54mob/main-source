using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class EditableMeshCache
	{
		private EditableMesh editableMesh;

		private Dictionary<ulong, SimplePolygon>[] polygonDict = new Dictionary<ulong, SimplePolygon>[2]
		{
			new Dictionary<ulong, SimplePolygon>(),
			new Dictionary<ulong, SimplePolygon>()
		};

		private List<VertexInfo> vertices = new List<VertexInfo>();

		private Dictionary<Vertex, VertexInfo> vertexDict = new Dictionary<Vertex, VertexInfo>();

		private Dictionary<VertexKey, List<VertexInfo>> vertexByPos = new Dictionary<VertexKey, List<VertexInfo>>();

		private bool dirty = true;

		public void Clear()
		{
			dirty = true;
			polygonDict[0].Clear();
			polygonDict[1].Clear();
			vertices.Clear();
			vertexDict.Clear();
			vertexByPos.Clear();
		}

		public void ClearShelf(int inShelf)
		{
			if (editableMesh != null)
			{
				foreach (SimplePolygon item in polygonDict[inShelf].Select((KeyValuePair<ulong, SimplePolygon> a) => a.Value).ToList())
				{
					RemovePolygon(item, inShelf);
				}
			}
			polygonDict[inShelf].Clear();
		}

		public void SetEditableMesh(EditableMesh edMesh)
		{
			editableMesh = edMesh;
		}

		private void CheckUpdate()
		{
			if (!dirty)
			{
				return;
			}
			dirty = false;
			if (editableMesh == null)
			{
				return;
			}
			using (new ShelfHolder(editableMesh))
			{
				List<List<int>> list = new List<List<int>>();
				list.Add(new List<int>());
				list.Add(new List<int>());
				for (int i = 0; i < 2; i++)
				{
					editableMesh.shelf = i;
					for (int j = 0; j < editableMesh.GetPolygonCount(); j++)
					{
						if (!polygonDict[i].ContainsKey(editableMesh.GetPolygon(j).instanceID))
						{
							polygonDict[i].Add(editableMesh.GetPolygon(j).instanceID, editableMesh.GetPolygon(j));
							UpdatePartially(editableMesh.GetPolygon(j));
						}
						else
						{
							list[i].Add(j);
						}
					}
				}
				bool flag = false;
				for (int k = 0; k < 2; k++)
				{
					if (list[k].Count > 0)
					{
						editableMesh.shelf = k;
						for (int l = 0; l < list[k].Count; l++)
						{
							editableMesh.GetPolygon(l).RegenarateInstanceID();
							polygonDict[k].Add(editableMesh.GetPolygon(l).instanceID, editableMesh.GetPolygon(l));
							UpdatePartially(editableMesh.GetPolygon(l));
							flag = true;
						}
					}
				}
				if (flag)
				{
					Debug.LogWarning("There could be some invalid polygons. We recommend that you should try [Tools] > [UModeler] > [Diagnosis All UModeler Objects]. And then please try Diagnosis tool in Misc group to each invalid UModeler object.");
				}
			}
		}

		private int GetShelf(int shelf)
		{
			if (shelf == -1)
			{
				return editableMesh.shelf;
			}
			return shelf;
		}

		public SimplePolygon FindPolygon(ulong id, int shelf = -1)
		{
			CheckUpdate();
			shelf = GetShelf(shelf);
			if (polygonDict[shelf].TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		public void AddPolygon(SimplePolygon polygon, int shelf = -1)
		{
			CheckUpdate();
			shelf = GetShelf(shelf);
			if (!polygonDict[shelf].ContainsKey(polygon.instanceID))
			{
				polygonDict[shelf].Add(polygon.instanceID, polygon);
			}
			else if (polygonDict[shelf][polygon.instanceID] != polygon)
			{
				polygonDict[shelf][polygon.instanceID] = polygon;
			}
		}

		public void MovePolygonShelf(SimplePolygon polygon, int srcShelf, int destShelf)
		{
			CheckUpdate();
			if (polygonDict[srcShelf].ContainsKey(polygon.instanceID))
			{
				polygonDict[srcShelf].Remove(polygon.instanceID);
			}
			if (!polygonDict[destShelf].ContainsKey(polygon.instanceID))
			{
				polygonDict[destShelf].Add(polygon.instanceID, polygon);
			}
		}

		public void RemovePolygon(SimplePolygon polygon, int shelf = -1)
		{
			CheckUpdate();
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				if (!RemoveVertex(polygon.GetVertex(i)))
				{
					Clear();
				}
			}
			shelf = GetShelf(shelf);
			if (polygonDict[shelf].ContainsKey(polygon.instanceID))
			{
				polygonDict[shelf].Remove(polygon.instanceID);
			}
			else
			{
				Clear();
			}
		}

		public bool UpdatePartially(SimplePolygon polygon)
		{
			CheckUpdate();
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
			CheckUpdate();
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

		private bool RemoveVertex(Vertex vertex)
		{
			CheckUpdate();
			if (vertexDict.TryGetValue(vertex, out var value))
			{
				if (!value.RemoveToken(vertex))
				{
					return false;
				}
				vertexDict.Remove(vertex);
				if (value.tokens.Count == 0)
				{
					VertexKey key = new VertexKey(vertex.pos);
					if (vertexByPos.TryGetValue(key, out var value2))
					{
						value2.Remove(value);
					}
					vertices.Remove(value);
				}
			}
			return true;
		}

		public bool AddVertex(SimplePolygon polygon, int vtxIndex)
		{
			CheckUpdate();
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
				VertexKey key = new VertexKey(vertex.pos);
				if (!vertexByPos.TryGetValue(key, out var value))
				{
					value = new List<VertexInfo>();
					vertexByPos.Add(key, value);
				}
				value.Add(vertexInfo);
			}
			vertexInfo.tokens.Add(token);
			vertexDict.Add(vertex, vertexInfo);
			return true;
		}

		public VertexInfo FindVertexByPos(Vector3 pos)
		{
			CheckUpdate();
			VertexKey key = new VertexKey(pos);
			vertexByPos.TryGetValue(key, out var value);
			if (value != null)
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].IsValid() && Comparer.IsEquivalent(pos, value[i].pos))
					{
						return value[i];
					}
				}
			}
			List<VertexKey> aroundKeys = key.GetAroundKeys(null);
			for (int j = 0; j < aroundKeys.Count; j++)
			{
				vertexByPos.TryGetValue(aroundKeys[j], out var value2);
				if (value2 == null)
				{
					continue;
				}
				for (int k = 0; k < value2.Count; k++)
				{
					if (Comparer.IsEquivalent(pos, value2[k].pos))
					{
						return value2[k];
					}
				}
			}
			return null;
		}

		public VertexInfo FindVertexByComparer(Vertex findVertex)
		{
			CheckUpdate();
			for (int i = 0; i < vertices.Count; i++)
			{
				if (vertices[i].IsValid() && VertexEqualityComparer.Equivalent(findVertex, vertices[i].vtx))
				{
					return vertices[i];
				}
			}
			foreach (KeyValuePair<Vertex, VertexInfo> item in vertexDict)
			{
				if (VertexEqualityComparer.Equivalent(findVertex, item.Key))
				{
					return item.Value;
				}
			}
			return null;
		}

		public void ResetSelected()
		{
			CheckUpdate();
			for (int i = 0; i < vertices.Count; i++)
			{
				vertices[i].selection = SelectionType.UnSelected;
			}
		}

		public void RevertSelected()
		{
			CheckUpdate();
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
			CheckUpdate();
			return vertices.Count;
		}

		public VertexInfo GetVertexInfo(int idx)
		{
			CheckUpdate();
			SimplePolygon polygon = vertices[idx].tokens[0].polygon;
			int vtxIndex = vertices[idx].tokens[0].vtxIndex;
			if (vtxIndex < 0 || vtxIndex >= polygon.GetVertexCount())
			{
				return null;
			}
			return vertices[idx];
		}

		public VertexInfo GetVertexInfo(Vertex vertex)
		{
			CheckUpdate();
			if (vertexDict.TryGetValue(vertex, out var value))
			{
				return value;
			}
			return null;
		}

		public int GetVertexIndexOf(Vertex vertex)
		{
			CheckUpdate();
			if (vertexDict.TryGetValue(vertex, out var value))
			{
				return vertices.IndexOf(value);
			}
			return -1;
		}
	}
}
