using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class BSPTree2DNode
	{
		private PlaneEx plane_;

		private List<Edge> coEdges_ = new List<Edge>();

		public BSPTree2DNode negative;

		public BSPTree2DNode positive;

		public List<Edge> coedges => coEdges_;

		public PlaneEx plane
		{
			get
			{
				return plane_;
			}
			set
			{
				plane_ = value;
			}
		}

		public void AddCoEdge(Edge edge)
		{
			coEdges_.Add(edge);
		}

		private void GetPositivePartitions(Edge edge, Partitions outPartitions)
		{
			if (positive != null)
			{
				positive.GetPartitions(edge, outPartitions);
			}
			else
			{
				outPartitions.positives.Add(edge);
			}
		}

		private void GetNegativePartitions(Edge edge, Partitions outPartitions)
		{
			if (negative != null)
			{
				negative.GetPartitions(edge, outPartitions);
			}
			else
			{
				outPartitions.negatives.Add(edge);
			}
		}

		public void GetPartitions(Edge edge, Partitions outPartitions)
		{
			if (coEdges_.Count != 0)
			{
				Edge outPositive;
				Edge outNegative;
				switch (new PlaneEx(coEdges_[0].p0, coEdges_[0].p1, coEdges_[0].p0 + plane_.normal).SplitEdge(edge, coEdges_, out outPositive, out outNegative))
				{
				case ESplitResult.Cross:
					GetPositivePartitions(outPositive, outPartitions);
					GetNegativePartitions(outNegative, outPartitions);
					break;
				case ESplitResult.Positive:
					GetPositivePartitions(outPositive, outPartitions);
					break;
				case ESplitResult.Negative:
					GetNegativePartitions(outNegative, outPartitions);
					break;
				default:
					HandleCoEdge(edge, outPartitions);
					break;
				}
			}
		}

		public bool IsInside(Vector3 pos)
		{
			float num = new PlaneEx(coEdges_[0].p0, coEdges_[0].p1, coEdges_[0].p0 + plane_.normal).CalcDistanceToPoint(pos);
			if (num > 0.0001f)
			{
				if (positive != null)
				{
					return positive.IsInside(pos);
				}
				return false;
			}
			if (num < -0.0001f)
			{
				if (negative != null)
				{
					return negative.IsInside(pos);
				}
				return true;
			}
			Vector2 pos2 = plane.ToPlaneCoord(pos);
			for (int i = 0; i < coEdges_.Count; i++)
			{
				if (new Edge2D(plane.ToPlaneCoord(coEdges_[i].p0), plane.ToPlaneCoord(coEdges_[i].p1)).IsInside(pos2))
				{
					return false;
				}
			}
			if (positive != null)
			{
				return positive.IsInside(pos);
			}
			if (negative != null)
			{
				return negative.IsInside(pos);
			}
			return false;
		}

		public EIntersection HasIntersection(Edge edge)
		{
			Partitions partitions = new Partitions();
			GetPartitions(edge, partitions);
			if (partitions.negatives.Count > 0)
			{
				return EIntersection.Intersection;
			}
			if (partitions.coPositive.Count > 0 || partitions.coNegative.Count > 0)
			{
				return EIntersection.Adjacency;
			}
			return EIntersection.None;
		}

		private void HandleCoEdge(Edge edge, Partitions outPartitions)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < coEdges_.Count; i++)
			{
				Edge edge2 = coEdges_[i].FindInterectedEdge(edge);
				if (edge2 == null)
				{
					edge2 = coEdges_[i].FindInterectedEdge(edge.Clone().Invert());
					edge2?.Invert();
				}
				if (edge2 != null && !edge2.IsPoint())
				{
					if (coEdges_[i].IsSameDir(edge2))
					{
						outPartitions.coPositive.Add(edge2);
					}
					else
					{
						outPartitions.coNegative.Add(edge2);
					}
					list.Add(edge2);
				}
			}
			int num = 0;
			List<Edge>[] array = new List<Edge>[2]
			{
				new List<Edge>(),
				new List<Edge>()
			};
			array[num].Add(edge);
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < array[num].Count; k++)
				{
					List<Edge> list2 = array[num][k].SubtractEdge(list[j]);
					if (list2 != null)
					{
						for (int l = 0; l < list2.Count; l++)
						{
							array[1 - num].Add(list2[l]);
						}
					}
				}
				array[num].Clear();
				num = 1 - num;
			}
			for (int m = 0; m < array[num].Count; m++)
			{
				Edge edge3 = array[num][m];
				GetPositivePartitions(edge3, outPartitions);
			}
		}
	}
}
