using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class ElementSet : ScriptableObject
	{
		public bool copied;

		[SerializeField]
		private List<Element> elements_ = new List<Element>();

		private AABB aabb_;

		public AABB aabb
		{
			get
			{
				if (aabb_ == null)
				{
					aabb_ = new AABB();
					aabb_.Reset();
					for (int i = 0; i < elements_.Count; i++)
					{
						aabb_.Add(elements_[i].aabb);
					}
				}
				return aabb_;
			}
		}

		public int Count => elements_.Count;

		public int vertexCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < elements_.Count; i++)
				{
					if (elements_[i].type == EElementType.Vertex)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int edgeCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < elements_.Count; i++)
				{
					if (elements_[i].type == EElementType.Edge)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int polygonCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < elements_.Count; i++)
				{
					if (elements_[i].type == EElementType.Polygon)
					{
						num++;
					}
				}
				return num;
			}
		}

		public static ElementSet Create()
		{
			ElementSet elementSet = ScriptableObject.CreateInstance<ElementSet>();
			elementSet.hideFlags |= HideFlags.DontSave | HideFlags.NotEditable;
			return elementSet;
		}

		public void AddVertex(Vertex vertex)
		{
			Element element = new Element();
			element.vertices = new List<Vertex>();
			element.vertices.Add(vertex.Clone());
			element.type = EElementType.Vertex;
			elements_.Add(element);
			copied = false;
			Invalidate();
		}

		public void AddEdge(Edge edge)
		{
			Element element = new Element();
			element.vertices = new List<Vertex>();
			element.vertices.Add(new Vertex(edge.p0));
			element.vertices.Add(new Vertex(edge.p1));
			element.type = EElementType.Edge;
			elements_.Add(element);
			copied = false;
			Invalidate();
		}

		public void AddPolygon(SimplePolygon polygon)
		{
			Element element = new Element();
			element.polygon = polygon;
			elements_.Add(element);
			copied = false;
			InvalidateAABB();
		}

		public void RemoveVertex(Vertex vertex)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == EElementType.Vertex && Comparer.IsEquivalent(elements_[i].vertices[0].pos, vertex.pos))
				{
					elements_.RemoveAt(i);
					break;
				}
			}
			Invalidate();
		}

		public void RemoveEdge(Edge edge)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == EElementType.Edge && Comparer.IsEquivalent(elements_[i].vertices[0].pos, edge.p0) && Comparer.IsEquivalent(elements_[i].vertices[1].pos, edge.p1))
				{
					elements_.RemoveAt(i);
					break;
				}
			}
			Invalidate();
		}

		public void SetPolygon(SimplePolygon polygon)
		{
			Clear();
			if (polygon != null)
			{
				AddPolygon(polygon);
			}
			InvalidateAABB();
		}

		public void SetPolygons(List<SimplePolygon> polygons)
		{
			Clear();
			if (polygons != null)
			{
				for (int i = 0; i < polygons.Count; i++)
				{
					AddPolygon(polygons[i]);
				}
			}
			InvalidateAABB();
		}

		public void SetEdges(List<Edge> edges)
		{
			Clear();
			if (edges != null)
			{
				for (int i = 0; i < edges.Count; i++)
				{
					AddEdge(edges[i]);
				}
			}
			InvalidateAABB();
		}

		public void SetVertices(List<Vertex> vertices)
		{
			Clear();
			if (vertices != null)
			{
				for (int i = 0; i < vertices.Count; i++)
				{
					AddVertex(vertices[i]);
				}
			}
			InvalidateAABB();
		}

		public void TransElement(EElementType transType)
		{
			HashSet<Vertex> vertexElements = new HashSet<Vertex>(new VertexPosComparer());
			HashSet<Vector3> hashSet = new HashSet<Vector3>(new Vector3Comparer());
			for (int i = 0; i < elements_.Count; i++)
			{
				vertexElements.UnionWith(elements_[i].vertices);
			}
			EditableMeshCache editableMeshCache = UMContext.activeModeler.editableMesh.editableMeshCache;
			hashSet.UnionWith(vertexElements.Select((Vertex a) => a.pos));
			HashSet<Vertex> hashSet2 = new HashSet<Vertex>(new VertexPosComparer());
			foreach (Element item in elements_)
			{
				if (item.type != EElementType.Polygon)
				{
					continue;
				}
				SimplePolygon polygon = item.polygon;
				List<SimplePolygon> list = UMContext.activeModeler.editableMesh.FindIntersectedPolygons(item.polygon.aabb);
				_ = UMContext.activeModeler.editableMesh.editableMeshCache;
				for (int num = 0; num < list.Count; num++)
				{
					SimplePolygon simplePolygon = list[num];
					for (int num2 = 0; num2 < polygon.GetEdgeCount(); num2++)
					{
						Edge pureEdge = polygon.GetPureEdge(num2);
						List<Vertex> list2 = simplePolygon.FindVerticesOnEdge(pureEdge);
						if (list2 == null)
						{
							continue;
						}
						foreach (Vertex item2 in list2)
						{
							if (!hashSet.Contains(item2.pos))
							{
								VertexInfo vertexInfo = editableMeshCache.FindVertexByPos(item2.pos);
								if (vertexInfo == null)
								{
									editableMeshCache.Clear();
									vertexInfo = editableMeshCache.FindVertexByPos(item2.pos);
								}
								if (vertexInfo != null)
								{
									hashSet2.Add(vertexInfo.vtx);
									hashSet.Add(item2.pos);
								}
							}
						}
					}
				}
			}
			vertexElements.UnionWith(hashSet2);
			Clear();
			if (transType == EElementType.Vertex)
			{
				foreach (Vertex item3 in vertexElements)
				{
					AddVertex(item3);
				}
				Compile();
			}
			else
			{
				EditableMesh editableMesh = UMContext.activeModeler.editableMesh;
				switch (transType)
				{
				case EElementType.Edge:
				{
					for (int num5 = 0; num5 < editableMesh.GetPolygonCount(); num5++)
					{
						SimplePolygon polygon3 = editableMesh.GetPolygon(num5);
						for (int num6 = 0; num6 < polygon3.GetEdgeCount(); num6++)
						{
							IndexPair edge = polygon3.GetEdge(num6);
							Vertex vertex = polygon3.GetVertex(edge.i0);
							Vertex vertex2 = polygon3.GetVertex(edge.i1);
							if (vertexElements.Contains(vertex) && vertexElements.Contains(vertex2))
							{
								edge.selection = SelectionType.Selected;
								AddEdge(polygon3.GetPureEdge(num6));
							}
							else
							{
								edge.selection = SelectionType.UnSelected;
							}
						}
					}
					break;
				}
				case EElementType.Polygon:
				{
					for (int num3 = 0; num3 < editableMesh.GetPolygonCount(); num3++)
					{
						SimplePolygon polygon2 = editableMesh.GetPolygon(num3);
						List<Vertex> vertexList = polygon2.GetVertexList();
						int num4 = vertexList.Count((Vertex a) => vertexElements.Contains(a));
						if (num4 > 0 && vertexList.Count == num4)
						{
							AddPolygon(polygon2);
						}
					}
					break;
				}
				}
			}
			Invalidate();
			Compile();
		}

		public void Compile()
		{
			Compile(EElementType.None);
		}

		public void Compile(EElementType excludeElementFlags)
		{
			EditableMeshCache editableMeshCache = UMContext.activeModeler.editableMesh.editableMeshCache;
			for (int i = 0; i < elements_.Count; i++)
			{
				if ((excludeElementFlags & EElementType.Vertex) == 0 && elements_[i].type == EElementType.Vertex)
				{
					VertexInfo vertexInfo = editableMeshCache.FindVertexByPos(elements_[i].vertex.pos);
					if (vertexInfo != null)
					{
						vertexInfo.selection = SelectionType.Selected;
					}
				}
				else
				{
					if ((excludeElementFlags & EElementType.Edge) != EElementType.None || elements_[i].type != EElementType.Edge)
					{
						continue;
					}
					Edge[] array = new Edge[2]
					{
						elements_[i].edge,
						elements_[i].edge.Clone().Invert()
					};
					for (int j = 0; j < array.Length; j++)
					{
						List<IndexPair> list = UMContext.activeModeler.editableMesh.FindEdgeIndexPairs(array[j]);
						int num = 0;
						while (list != null && num < list.Count)
						{
							if (list[num].selection != SelectionType.SharedSelected)
							{
								list[num].selection = SelectionType.Selected;
							}
							num++;
						}
					}
				}
			}
		}

		public void AddElement(Element element)
		{
			elements_.Add(element);
			Invalidate();
		}

		public Vertex FindVertex(Vector3 pos)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == EElementType.Vertex && Comparer.IsEquivalent(elements_[i].vertices[0].pos, pos))
				{
					return elements_[i].vertices[0];
				}
			}
			return null;
		}

		public int GetVertexIndex(Vector3 pos)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == EElementType.Vertex && Comparer.IsEquivalent(elements_[i].vertices[0].pos, pos))
				{
					return i;
				}
			}
			return -1;
		}

		public bool HasPos(Vector3 pos)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				for (int j = 0; j < elements_[i].vertices.Count; j++)
				{
					if (Comparer.IsEquivalent(elements_[i].vertices[j].pos, pos))
					{
						return true;
					}
				}
			}
			return false;
		}

		public int GetEdgeIndex(Edge edge)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == EElementType.Edge && Comparer.IsEquivalent(elements_[i].vertices[0].pos, edge.p0) && Comparer.IsEquivalent(elements_[i].vertices[1].pos, edge.p1))
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsEdge(Edge edge)
		{
			return GetEdgeIndex(edge) != -1;
		}

		public int GetPolygonIndex(SimplePolygon polygon)
		{
			if (polygon != null)
			{
				for (int i = 0; i < elements_.Count; i++)
				{
					if (elements_[i].type == EElementType.Polygon && elements_[i].polygonID == polygon.instanceID)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public bool ContainsPolygon(SimplePolygon polygon)
		{
			return GetPolygonIndex(polygon) != -1;
		}

		public void RemovePolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].polygonID == polygon.instanceID)
				{
					elements_.RemoveAt(i);
					break;
				}
			}
			InvalidateAABB();
		}

		public void Refresh()
		{
			ElementSet elementSet = ScriptableObject.CreateInstance<ElementSet>();
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Vertex)
				{
					elementSet.AddVertex(element.vertex);
				}
				else if (element.type == EElementType.Edge)
				{
					elementSet.AddEdge(element.edge);
				}
				else if (element.type == EElementType.Polygon)
				{
					elementSet.AddPolygon(element.polygon);
				}
			}
			ReplaceWith(elementSet);
		}

		public void RemoveDuplicatedEdges(bool includeCheckInvert = false)
		{
			List<Edge> edgeList = GetEdgeList();
			if (edgeList == null)
			{
				return;
			}
			Clear();
			for (int i = 0; i < edgeList.Count; i++)
			{
				if (!ContainsEdge(edgeList[i]) && (!includeCheckInvert || !ContainsEdge(edgeList[i].Clone().Invert())))
				{
					AddEdge(edgeList[i]);
				}
			}
			Invalidate();
		}

		public void RemoveDuplicatedPolygons()
		{
			List<SimplePolygon> polygonList = GetPolygonList();
			if (polygonList == null)
			{
				return;
			}
			Clear();
			for (int i = 0; i < polygonList.Count; i++)
			{
				if (!ContainsPolygon(polygonList[i]))
				{
					AddPolygon(polygonList[i]);
				}
			}
			Invalidate();
		}

		public void RemoveDuplicatedVertices()
		{
			List<Vertex> vertexList = GetVertexList();
			if (vertexList == null)
			{
				return;
			}
			Clear();
			for (int i = 0; i < vertexList.Count; i++)
			{
				if (!HasPos(vertexList[i].pos))
				{
					AddVertex(vertexList[i]);
				}
			}
			Invalidate();
		}

		public void Clear()
		{
			EditableMeshCache editableMeshCache = UMContext.activeModeler.editableMesh.editableMeshCache;
			for (int i = 0; i < editableMeshCache.GetVertexCount(); i++)
			{
				VertexInfo vertexInfo = editableMeshCache.GetVertexInfo(i);
				if (vertexInfo != null)
				{
					vertexInfo.selection = SelectionType.UnSelected;
				}
			}
			elements_.Clear();
			copied = false;
			Compile();
		}

		public List<SimplePolygon> GetPolygonList()
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Polygon)
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					if (element.polygon != null)
					{
						list.Add(element.polygon);
					}
				}
			}
			return list;
		}

		public List<Edge> GetEdgeList()
		{
			List<Edge> list = null;
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Edge)
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(element.edge);
				}
			}
			return list;
		}

		public List<Vertex> GetVertexList()
		{
			List<Vertex> list = null;
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Vertex)
				{
					if (list == null)
					{
						list = new List<Vertex>();
					}
					list.Add(element.vertex);
				}
			}
			return list;
		}

		public List<Vector3> GetPositionList()
		{
			List<Vertex> vertexList = GetVertexList();
			List<Vector3> result = null;
			if (vertexList != null)
			{
				result = vertexList.Select((Vertex a) => a.pos).ToList();
			}
			return result;
		}

		public List<Vector3> GetAllPositions()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				for (int j = 0; j < element.vertices.Count; j++)
				{
					list.Add(element.vertices[j].pos);
				}
			}
			list = list.Distinct(new Vector3Comparer()).ToList();
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		public List<Edge> GetAllEdges(bool excludeDuplication = true)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Vertex)
				{
					list.Add(new Edge(element.vertex.pos, element.vertex.pos));
				}
				else if (element.type == EElementType.Edge)
				{
					if (!excludeDuplication || (!Util.ContainsEdge(element.edge, list) && !Util.ContainsEdge(element.edge.Clone().Invert(), list)))
					{
						list.Add(element.edge.Clone());
					}
				}
				else
				{
					if (element.type != EElementType.Polygon || element.polygon == null || element.polygon.IsOpen())
					{
						continue;
					}
					for (int j = 0; j < element.polygon.segments.GetLoopCount(); j++)
					{
						Segment loop = element.polygon.segments.GetLoop(j);
						for (int k = 0; k < loop.vertices.Count; k++)
						{
							Edge edge = new Edge(loop.vertices[k].pos, loop.vertices[(k + 1) % loop.vertices.Count].pos);
							if (!excludeDuplication || (!Util.ContainsEdge(edge, list) && !Util.ContainsEdge(edge.Clone().Invert(), list)))
							{
								list.Add(edge);
							}
						}
					}
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		public Element GetElement(int idx)
		{
			return elements_[idx];
		}

		public ElementSet Clone()
		{
			ElementSet elementSet = Create();
			for (int i = 0; i < elements_.Count; i++)
			{
				elementSet.AddElement(elements_[i].Clone());
			}
			return elementSet;
		}

		public void ReplaceWith(ElementSet element_set)
		{
			elements_ = element_set.Clone().elements_;
			Invalidate();
		}

		public void Join(ElementSet element_set)
		{
			for (int i = 0; i < element_set.Count; i++)
			{
				elements_.Add(element_set.GetElement(i).Clone());
			}
			Invalidate();
		}

		public Vector3 CalculateAverageNormal()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < elements_.Count; i++)
			{
				zero += elements_[i].normal;
			}
			if (!(zero != Vector3.zero))
			{
				return Vector3.zero;
			}
			return zero.normalized;
		}

		public bool HasElementType(EElementType type)
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				if (elements_[i].type == type)
				{
					return true;
				}
			}
			return false;
		}

		public EElementType HasElementType()
		{
			EElementType eElementType = EElementType.None;
			for (int i = 0; i < elements_.Count; i++)
			{
				eElementType |= elements_[i].type;
			}
			return eElementType;
		}

		public void Invalidate()
		{
			for (int i = 0; i < elements_.Count; i++)
			{
				elements_[i].Invalidate();
			}
			aabb_ = null;
		}

		public void InvalidateAABB()
		{
			aabb_ = null;
		}

		public new void ToString()
		{
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Vertex)
				{
					Debug.Log("Vertex selected");
				}
				else if (element.type == EElementType.Edge)
				{
					Debug.Log("Edge selected");
				}
				else if (element.type == EElementType.Polygon)
				{
					Debug.Log("Polygon selected");
				}
			}
		}

		public void Display()
		{
			for (int i = 0; i < Count; i++)
			{
				Element element = GetElement(i);
				if (element.type == EElementType.Vertex)
				{
					UMContext.engine.DrawDotCap(element.vertices[0].pos, Quaternion.identity, Util.GetAdaptedVertexSize(element.vertices[0].pos));
				}
			}
			for (int j = 0; j < UMContext.engine.selectedElements.Count; j++)
			{
				Element element2 = UMContext.engine.selectedElements.GetElement(j);
				if (element2.type == EElementType.Edge)
				{
					UMContext.engine.DrawAALine(4f, element2.vertices[0].pos, element2.vertices[1].pos);
				}
			}
		}
	}
}
