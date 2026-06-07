using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class SegmentPolygons
	{
		private List<Segment> loops_;

		private PlaneEx plane_;

		private EPolygonFlag flag_;

		private Queue<Segment> sementQueue = new Queue<Segment>();

		public bool open
		{
			get
			{
				for (int i = 0; i < loops_.Count; i++)
				{
					if (loops_[i].open)
					{
						return true;
					}
				}
				return false;
			}
		}

		public SegmentPolygons()
		{
			loops_ = new List<Segment>();
		}

		private Segment GetNewSegment()
		{
			return new Segment();
		}

		public void SetSegmentPolygons(SimplePolygon polygon)
		{
			loops_.Clear();
			flag_ = polygon.flags;
			if (polygon.IsValid())
			{
				plane_ = polygon.plane;
				if (Util.IsOpenPolygon(polygon))
				{
					FindSegments(polygon, loops_);
				}
				else
				{
					FindLoops(polygon, loops_);
				}
			}
		}

		private void FindSegments(SimplePolygon polygon, List<Segment> out_segments)
		{
			HashSet<IndexPair> hashSet = new HashSet<IndexPair>();
			while (hashSet.Count < polygon.GetEdgeCount())
			{
				IndexPair indexPair = null;
				for (int i = 0; i < polygon.GetEdgeCount(); i++)
				{
					IndexPair edge = polygon.GetEdge(i);
					if (!hashSet.Contains(edge) && polygon.FindPrevEdges(edge) == null)
					{
						indexPair = edge;
						break;
					}
				}
				if (indexPair == null)
				{
					break;
				}
				Segment newSegment = GetNewSegment();
				IndexPair indexPair2 = indexPair;
				while (!hashSet.Contains(indexPair2))
				{
					hashSet.Add(indexPair2);
					newSegment.vertices.Add(polygon.GetVertex(indexPair2.i0).Clone());
					newSegment.indices.Add(indexPair2.i0);
					polygon.FindNeighborEdges(indexPair2, out var _, out var outNextEdge);
					if (outNextEdge == null)
					{
						break;
					}
					indexPair2 = outNextEdge;
				}
				newSegment.open = true;
				newSegment.vertices.Add(polygon.GetVertex(indexPair2.i1).Clone());
				newSegment.indices.Add(indexPair2.i1);
				out_segments.Add(newSegment);
			}
		}

		private void FindLoops(SimplePolygon polygon, List<Segment> out_loops)
		{
			HashSet<IndexPair> hashSet = new HashSet<IndexPair>();
			HashSet<IndexPair> hashSet2 = new HashSet<IndexPair>();
			Dictionary<int, List<IndexPair>> dictionary = new Dictionary<int, List<IndexPair>>();
			Dictionary<int, List<IndexPair>> dictionary2 = new Dictionary<int, List<IndexPair>>();
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				IndexPair edge = polygon.GetEdge(i);
				hashSet2.Add(edge);
				if (!dictionary.TryGetValue(edge.i0, out var value))
				{
					dictionary.Add(edge.i0, value = new List<IndexPair>());
				}
				value.Add(edge);
				if (!dictionary2.TryGetValue(edge.i1, out value))
				{
					dictionary2.Add(edge.i1, value = new List<IndexPair>());
				}
				value.Add(edge);
			}
			foreach (IndexPair item in hashSet2)
			{
				if (dictionary[item.i0].Count > 1 || dictionary2[item.i1].Count > 1 || hashSet.Contains(item))
				{
					continue;
				}
				Segment segment = GetNewSegment();
				segment.open = false;
				hashSet.Add(item);
				IndexPair outNextEdge = item;
				int num = 0;
				do
				{
					if (dictionary.TryGetValue(outNextEdge.i1, out var value2))
					{
						segment.vertices.Add(polygon.GetVertex(outNextEdge.i0).Clone());
						segment.indices.Add(outNextEdge.i0);
						if (value2.Count == 1)
						{
							outNextEdge = value2[0];
						}
						else if (value2.Count > 1)
						{
							polygon.ChooseNextEdge(outNextEdge, value2, out outNextEdge);
						}
						hashSet.Add(outNextEdge);
						if (++num > polygon.GetEdgeCount() + 1)
						{
							segment = null;
							break;
						}
						continue;
					}
					segment = null;
					break;
				}
				while (item.i0 != outNextEdge.i1);
				if (segment != null && segment.vertices.Count > 0)
				{
					segment.vertices.Add(polygon.GetVertex(outNextEdge.i0).Clone());
					segment.indices.Add(outNextEdge.i0);
					if (MathUtil.IsCCW(segment.vertices, polygon.plane))
					{
						out_loops.Insert(0, segment);
					}
					else
					{
						out_loops.Add(segment);
					}
				}
			}
		}

		public int GetLoopCount()
		{
			return loops_.Count;
		}

		public int GetHoleCount()
		{
			return loops_.Count - 1;
		}

		public Segment GetLoop(int index)
		{
			return loops_[index];
		}

		public Segment GetOutsideLoop()
		{
			if (loops_.Count == 0)
			{
				return null;
			}
			return loops_[0];
		}

		public SimplePolygon GetOutsideLoopPolygon()
		{
			if (GetOutsideLoop() != null)
			{
				return new SimplePolygon(GetOutsideLoop().vertices, plane_, open: false, flag_);
			}
			return null;
		}

		public Segment GetHole(int index)
		{
			return loops_[index + 1];
		}

		public SimplePolygon GetHolePolygon(int index)
		{
			List<Vertex> list = new List<Vertex>();
			List<Vertex> vertices = GetHole(index).vertices;
			for (int i = 0; i < vertices.Count; i++)
			{
				list.Add(vertices[vertices.Count - i - 1]);
			}
			return new SimplePolygon(list, null, open: false, flag_)
			{
				plane = plane_
			};
		}

		public List<SimplePolygon> GetHolePolygons()
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < GetHoleCount(); i++)
			{
				list.Add(GetHolePolygon(i));
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list;
		}
	}
}
