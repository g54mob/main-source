using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class UVIsland : PolygonResources
	{
		[SerializeField]
		public bool selected;

		private AABB aabb_;

		public AABB aabb
		{
			get
			{
				if (aabb_ == null)
				{
					aabb_ = new AABB();
					aabb_.Reset();
					for (int i = 0; i < GetPolygonCount(); i++)
					{
						aabb_.Add(GetPolygon(i).uvAABB);
					}
				}
				return aabb_;
			}
		}

		public override void Invalidate()
		{
			aabb_ = null;
		}

		protected override PolygonResources CreateResources()
		{
			return new UVIsland();
		}

		public SimplePolygon FindPolygonHavingUVEdge(Vector2 uv0, Vector2 uv1, int matID)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (matID != -1 && matID != polygon.matID)
				{
					continue;
				}
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					IndexPair edge = polygon.GetEdge(j);
					Vertex vertex = polygon.GetVertex(edge.i0);
					Vertex vertex2 = polygon.GetVertex(edge.i1);
					if (Comparer.IsEquivalent(vertex.uv, uv0) && Comparer.IsEquivalent(vertex2.uv, uv1))
					{
						return polygon;
					}
				}
			}
			return null;
		}

		public override void Refresh()
		{
			base.Refresh();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				GetPolygon(i).EnableUnwrapped(unwrapped: true);
			}
		}

		private bool IsPointInAABB(Vector2 uv)
		{
			return aabb.Contains(uv);
		}

		public SimplePolygon PickPolygon(Vector2 uv, int matID = -1)
		{
			if (!IsPointInAABB(uv))
			{
				return null;
			}
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if ((matID == -1 || polygon.matID == matID) && polygon.IsUVPassed(uv))
				{
					return polygon;
				}
			}
			return null;
		}

		public SimplePolygon PickClosestEdge(Vector2 uv, int matID, out IndexPair out_closest_edge_pair, out Vector2 out_uv_on_edge)
		{
			AABB aABB = aabb.Clone();
			aABB.Expand(Vector3.one * 0.01f);
			out_closest_edge_pair = IndexPair.invalide_pair;
			out_uv_on_edge = Vector2.zero;
			if (!aABB.Contains(uv))
			{
				return null;
			}
			float num = 3E+10f;
			SimplePolygon result = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if ((matID == -1 || matID == polygon.matID) && polygon.FindClosestUVEdge(uv, out var outClosestEdgeIndexPair, out var outUVOnClosestEdge))
				{
					float num2 = Vector2.Distance(outUVOnClosestEdge, uv);
					if (num2 < num)
					{
						num = num2;
						out_closest_edge_pair = outClosestEdgeIndexPair;
						out_uv_on_edge = outUVOnClosestEdge;
						result = polygon;
					}
				}
			}
			return result;
		}

		public SimplePolygon PickClosestUV(Vector2 uv, int matID, out int outUVVtxIdx)
		{
			AABB aABB = aabb.Clone();
			aABB.Expand(Vector3.one * 0.01f);
			outUVVtxIdx = -1;
			if (!aABB.Contains(uv))
			{
				return null;
			}
			float num = 3E+10f;
			SimplePolygon result = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (matID != -1 && matID != polygon.matID)
				{
					continue;
				}
				int out_uv_idx = 0;
				if (polygon.FindClosestUV(uv, out out_uv_idx))
				{
					float num2 = Vector2.Distance(polygon.GetVertex(out_uv_idx).uv, uv);
					if (num2 < num)
					{
						num = num2;
						outUVVtxIdx = out_uv_idx;
						result = polygon;
					}
				}
			}
			return result;
		}

		public List<Token> FindTokens(Vector2 uv)
		{
			List<Token> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				for (int j = 0; j < polygon.GetVertexCount(); j++)
				{
					if (Comparer.IsEquivalent(polygon.GetVertex(j).uv, uv))
					{
						if (list == null)
						{
							list = new List<Token>();
						}
						list.Add(new Token(polygon, j));
						break;
					}
				}
			}
			return list;
		}

		public void Add(UVIsland island)
		{
			for (int i = 0; i < island.GetPolygonCount(); i++)
			{
				AddPolygon(island.GetPolygon(i));
			}
		}

		public override PolygonResources Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			PolygonResources polygonResources = base.Clone(originalToClone);
			((UVIsland)polygonResources).aabb_ = aabb_;
			return polygonResources;
		}

		public override void AddPolygon(SimplePolygon polygon)
		{
			if (!polygon.IsMirrored())
			{
				base.AddPolygon(polygon);
				if (aabb_ != null)
				{
					aabb_.Add(polygon.uvAABB);
				}
			}
		}

		public AABB ComputeUVBoundary()
		{
			AABB aABB = new AABB();
			aABB.Reset();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				for (int j = 0; j < polygon.GetVertexCount(); j++)
				{
					Vertex vertex = polygon.GetVertex(j);
					aABB.Add(vertex.uv);
				}
			}
			return aABB;
		}

		public IndexPair FindUVEdge(Vector2 uv0, Vector2 uv1, int matID, out SimplePolygon out_polygon)
		{
			out_polygon = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (matID != -1 && matID != polygon.matID)
				{
					continue;
				}
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					IndexPair edge = polygon.GetEdge(j);
					Vertex vertex = polygon.GetVertex(edge.i0);
					Vertex vertex2 = polygon.GetVertex(edge.i1);
					if (Comparer.IsEquivalent(vertex.uv, uv0) && Comparer.IsEquivalent(vertex2.uv, uv1))
					{
						out_polygon = polygon;
						return edge;
					}
				}
			}
			return null;
		}

		public SimplePolygon FindPolygon(Edge edge)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsEdge(edge))
				{
					return polygon;
				}
			}
			return null;
		}

		public bool IsUVAdjacent(SimplePolygon polygon)
		{
			if (!aabb.IsIntersectBox2D(polygon.uvAABB))
			{
				return false;
			}
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				if (GetPolygon(i).IsUVAdjacent(polygon))
				{
					return true;
				}
			}
			return false;
		}

		public override void Read(BinaryReader binaryReader)
		{
			selected = binaryReader.ReadBoolean();
			base.Read(binaryReader);
		}

		public override void Write(BinaryWriter binWriter)
		{
			binWriter.Write(selected);
			base.Write(binWriter);
		}
	}
}
