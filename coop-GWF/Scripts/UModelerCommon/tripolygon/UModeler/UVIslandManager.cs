using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class UVIslandManager
	{
		[SerializeField]
		private List<UVIsland> uvislands_ = new List<UVIsland>();

		[SerializeField]
		private byte[] uvislandsStream_;

		private List<UVIsland> uvislandsList_ = new List<UVIsland>();

		public void Invalidate()
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				GetUVIsland(i).Invalidate();
			}
		}

		public void Refresh()
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				UVIsland uVIsland = GetUVIsland(i);
				if (!uVIsland.RemoveUnused())
				{
					uVIsland.Refresh();
				}
			}
			RemoveAllEmpty();
		}

		public void Clear()
		{
			uvislandsList_.Clear();
		}

		public void BeforeSerialize(int editMeshVersion)
		{
		}

		public void AfterDeserialize(int editMeshVersion)
		{
			if (uvislandsStream_ != null && uvislandsStream_.Length != 0)
			{
				MemoryStream memoryStream = new MemoryStream(uvislandsStream_);
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				binaryReader.ReadInt32();
				int num = binaryReader.ReadInt32();
				uvislands_.Clear();
				uvislands_.Capacity = num;
				for (int i = 0; i < num; i++)
				{
					UVIsland uVIsland = new UVIsland();
					uVIsland.Read(binaryReader);
					uvislands_.Add(uVIsland);
				}
				binaryReader.Close();
				memoryStream.Close();
				uvislandsStream_ = null;
			}
			uvislandsList_ = uvislands_;
			for (int j = 0; j < uvislandsList_.Count; j++)
			{
				uvislandsList_[j].SetDirtyCache();
			}
		}

		public void InitCommon(int editMeshVersion)
		{
			uvislandsList_ = uvislands_;
		}

		public void ConvertStream(int editMeshVersion)
		{
		}

		public UVIsland GetUVIsland(int index)
		{
			return uvislandsList_[index];
		}

		public int GetUVIslandCount()
		{
			return uvislandsList_.Count;
		}

		public void AddUVIsland(UVIsland uvisland)
		{
			for (int i = 0; i < uvisland.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = uvisland.GetPolygon(i);
				SimplePolygon polygon2 = polygon.Clone();
				RemovePolygon(polygon);
				polygon.ReplaceWith(polygon2);
			}
			uvislandsList_.Add(uvisland);
		}

		public void AddPolygonToNewIsland(SimplePolygon polygon)
		{
			UVIsland uVIsland = new UVIsland();
			uVIsland.AddPolygon(polygon);
			AddUVIsland(uVIsland);
		}

		public void AddPolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				UVIsland uVIsland = GetUVIsland(i);
				if (uVIsland.IsUVAdjacent(polygon))
				{
					uVIsland.AddPolygon(polygon);
					return;
				}
			}
			AddPolygonToNewIsland(polygon);
		}

		public List<Token> FindTokens(Vector2 uv)
		{
			List<Token> list = null;
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				List<Token> list2 = GetUVIsland(i).FindTokens(uv);
				if (list2 != null)
				{
					if (list == null)
					{
						list = new List<Token>();
					}
					list.AddRange(list2);
				}
			}
			return list;
		}

		public void RemovePolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < GetUVIslandCount() && !GetUVIsland(i).RemovePolygon(polygon); i++)
			{
			}
		}

		public UVIsland FindUVIsland(SimplePolygon polygon)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).Contains(polygon))
				{
					return GetUVIsland(i);
				}
			}
			return null;
		}

		public UVIsland FindUVIsland(ulong id)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).instanceID == id)
				{
					return GetUVIsland(i);
				}
			}
			return null;
		}

		public UVIsland FindUVIsland(Vector2 uv0, Vector2 uv1, int matID)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).FindPolygonHavingUVEdge(uv0, uv1, matID) != null)
				{
					return GetUVIsland(i);
				}
			}
			return null;
		}

		public SimplePolygon FindPolygon(Edge edge, out UVIsland outIsland)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				SimplePolygon simplePolygon = GetUVIsland(i).FindPolygon(edge);
				if (simplePolygon != null)
				{
					outIsland = GetUVIsland(i);
					return simplePolygon;
				}
			}
			outIsland = null;
			return null;
		}

		public void RemoveAllEmpty()
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				GetUVIsland(i).RemoveUnused();
			}
			uvislandsList_.RemoveAll(IsUVIslandEmpty);
		}

		private bool IsUVIslandEmpty(UVIsland island)
		{
			return island.GetPolygonCount() == 0;
		}

		public void RemoveUVIsland(UVIsland uvisland)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).IsEquivalent(uvisland))
				{
					for (int j = 0; j < uvisland.GetPolygonCount(); j++)
					{
						uvisland.GetPolygon(j).EnableUnwrapped(unwrapped: false);
					}
					uvislandsList_.RemoveAt(i);
					break;
				}
			}
		}

		public IndexPair FindUVEdge(Vector2 uv0, Vector2 uv1, int matID)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				SimplePolygon out_polygon;
				IndexPair indexPair = GetUVIsland(i).FindUVEdge(uv0, uv1, matID, out out_polygon);
				if (indexPair != null)
				{
					return indexPair;
				}
			}
			return null;
		}

		public SimplePolygon FindPolygon(Vector2 uv0, Vector2 uv1, int matID)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).FindUVEdge(uv0, uv1, matID, out var out_polygon) != null)
				{
					return out_polygon;
				}
			}
			return null;
		}

		public UVIslandManager Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			UVIslandManager uVIslandManager = new UVIslandManager();
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				uVIslandManager.uvislandsList_.Add(GetUVIsland(i).Clone(originalToClone) as UVIsland);
			}
			return uVIslandManager;
		}

		public UVIsland FindEquivalentIsland(UVIsland island)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).IsEquivalent(island))
				{
					return GetUVIsland(i);
				}
			}
			return null;
		}

		public UVIsland FindUVIslandHavingUVEdge(Vector2 uv0, Vector2 uv1, int matID)
		{
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				if (GetUVIsland(i).FindPolygonHavingUVEdge(uv0, uv1, matID) != null)
				{
					return GetUVIsland(i);
				}
			}
			return null;
		}

		public void FindConnectedUVEdges(Vector2 uv, out List<VertexEdge> edgesConnectedToStarting, out List<VertexEdge> edgesConnectedToEnding)
		{
			edgesConnectedToStarting = null;
			edgesConnectedToEnding = null;
			for (int i = 0; i < GetUVIslandCount(); i++)
			{
				UVIsland uVIsland = GetUVIsland(i);
				for (int j = 0; j < uVIsland.GetPolygonCount(); j++)
				{
					SimplePolygon polygon = uvislandsList_[i].GetPolygon(j);
					for (int k = 0; k < polygon.GetEdgeCount(); k++)
					{
						IndexPair edge = polygon.GetEdge(k);
						Vertex vertex = polygon.GetVertex(edge.i0);
						Vertex vertex2 = polygon.GetVertex(edge.i1);
						if (Comparer.IsEquivalent(uv, vertex.uv))
						{
							if (edgesConnectedToStarting == null)
							{
								edgesConnectedToStarting = new List<VertexEdge>();
							}
							edgesConnectedToStarting.Add(new VertexEdge(vertex, vertex2));
						}
						if (Comparer.IsEquivalent(uv, vertex2.uv))
						{
							if (edgesConnectedToEnding == null)
							{
								edgesConnectedToEnding = new List<VertexEdge>();
							}
							edgesConnectedToEnding.Add(new VertexEdge(vertex, vertex2));
						}
					}
				}
			}
		}

		public void ArrangeUVIslandsFast(EditableMesh edMesh)
		{
			uvislandsList_.Clear();
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < edMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = edMesh.GetPolygon(i);
				if (polygon.IsUnwrapped())
				{
					list.Add(polygon);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				UVIsland uVIsland = new UVIsland();
				uVIsland.AddPolygon(list[j]);
				uvislandsList_.Add(uVIsland);
			}
		}

		public void ArrangeUVIslands(EditableMesh edMesh)
		{
			uvislandsList_.Clear();
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < edMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = edMesh.GetPolygon(i);
				if (polygon.IsUnwrapped())
				{
					list.Add(polygon);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			while (0 < list.Count)
			{
				UVIsland uVIsland = new UVIsland();
				uVIsland.AddPolygon(list[0]);
				list.RemoveAt(0);
				bool flag = true;
				while (flag)
				{
					flag = false;
					for (int j = 0; j < list.Count; j++)
					{
						SimplePolygon polygon2 = list[j];
						if (uVIsland.IsUVAdjacent(polygon2))
						{
							uVIsland.AddPolygon(polygon2);
							list.RemoveAt(j);
							j--;
							flag = true;
						}
					}
				}
				uvislandsList_.Add(uVIsland);
			}
		}

		public ulong CollectLatestID()
		{
			ulong num = 0uL;
			for (int i = 0; i < uvislandsList_.Count; i++)
			{
				if (uvislandsList_[i].instanceID > num)
				{
					num = uvislandsList_[i].instanceID;
				}
			}
			return num;
		}

		public void CheckInstanceID(List<ulong> instanceIDs)
		{
			for (int i = 0; i < uvislandsList_.Count; i++)
			{
				if (instanceIDs.IndexOf(uvislandsList_[i].instanceID) != -1)
				{
					uvislandsList_[i].RegenerateInstanceID();
				}
				instanceIDs.Add(uvislandsList_[i].instanceID);
			}
		}
	}
}
