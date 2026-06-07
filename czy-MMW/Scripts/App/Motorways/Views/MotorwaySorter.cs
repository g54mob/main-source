using System;
using System.Collections.Generic;
using Motorways.Utility;
using UnityEngine;
using Utils.Geometry;

namespace Motorways.Views
{
	public class MotorwaySorter
	{
		public readonly struct MotorwayLowerThanConstraint
		{
			public readonly MotorwayGeometryInfo.MotorwayEndEdge endEdge;

			public readonly int lowerMotorwayId;

			public readonly int higherMotorwayId;

			public MotorwayLowerThanConstraint(MotorwayGeometryInfo.MotorwayEndEdge endEdge, int lowerMotorwayId, int higherMotorwayId)
			{
				this.endEdge = endEdge;
				this.lowerMotorwayId = lowerMotorwayId;
				this.higherMotorwayId = higherMotorwayId;
			}
		}

		public class MotorwayDepthSegment
		{
			public readonly int motorwayId;

			public float startDistance;

			public Vector2 startPosition;

			public float endDistance;

			public Vector2 endPosition;

			public readonly List<MotorwayLowerThanConstraint> constraints = new List<MotorwayLowerThanConstraint>();

			public float depth;

			public MotorwayDepthSegment(int motorwayId, float startDistance, Vector2 startPosition, float endDistance, Vector2 endPosition)
			{
				this.motorwayId = motorwayId;
				if (startDistance <= endDistance)
				{
					this.startDistance = startDistance;
					this.startPosition = startPosition;
					this.endDistance = endDistance;
					this.endPosition = endPosition;
				}
				else
				{
					this.startDistance = endDistance;
					this.startPosition = endPosition;
					this.endDistance = startDistance;
					this.endPosition = startPosition;
				}
			}
		}

		public class MotorwayDepth
		{
			public readonly int motorwayId;

			private readonly List<MotorwayDepthSegment> _depthSegments = new List<MotorwayDepthSegment>();

			public IReadOnlyList<MotorwayDepthSegment> DepthSegments => _depthSegments.AsReadOnly();

			public MotorwayDepth(int motorwayId)
			{
				this.motorwayId = motorwayId;
			}

			public void Add(MotorwayDepthSegment newDepthSegment)
			{
				if (_depthSegments.Count == 0)
				{
					_depthSegments.Add(newDepthSegment);
					return;
				}
				for (int i = 0; i < _depthSegments.Count; i++)
				{
					MotorwayDepthSegment motorwayDepthSegment = _depthSegments[i];
					if (newDepthSegment.startDistance > motorwayDepthSegment.endDistance)
					{
						if (i == _depthSegments.Count - 1)
						{
							_depthSegments.Add(newDepthSegment);
							break;
						}
						continue;
					}
					if (motorwayDepthSegment.startDistance > newDepthSegment.endDistance)
					{
						_depthSegments.Insert(i, newDepthSegment);
						break;
					}
					float startDistance;
					Vector2 startPosition;
					if (motorwayDepthSegment.startDistance < newDepthSegment.startDistance)
					{
						startDistance = motorwayDepthSegment.startDistance;
						startPosition = motorwayDepthSegment.startPosition;
					}
					else
					{
						startDistance = newDepthSegment.startDistance;
						startPosition = newDepthSegment.startPosition;
					}
					float endDistance;
					Vector2 endPosition;
					if (motorwayDepthSegment.endDistance > newDepthSegment.endDistance)
					{
						endDistance = motorwayDepthSegment.endDistance;
						endPosition = motorwayDepthSegment.endPosition;
					}
					else
					{
						endDistance = newDepthSegment.endDistance;
						endPosition = newDepthSegment.endPosition;
					}
					motorwayDepthSegment.startDistance = startDistance;
					motorwayDepthSegment.startPosition = startPosition;
					motorwayDepthSegment.endDistance = endDistance;
					motorwayDepthSegment.endPosition = endPosition;
					motorwayDepthSegment.constraints.AddRange(newDepthSegment.constraints);
					break;
				}
			}
		}

		public const float MaxMotorwayWorldHeight = -6f;

		public const float MinMotorwayWorldHeight = -3f;

		private const float MotorwayWorldHeightRange = -3f;

		private const float GapBetweenSortedAndDefault = -0.3f;

		public const float SortedMinMotorwayWorldHeight = -4.5f;

		public const float SortedMaxMotorwayWorldHeight = -6f;

		public const float SortedMotorwayWorldHeightRange = -1.5f;

		public const float DefaultMinMotorwayWorldHeight = -3f;

		public const float DefaultMaxMotorwayWorldHeight = -4.2f;

		public const float DefaultMotorwayWorldHeightRange = -1.1999998f;

		public void CalculateDepthSegments(Dictionary<int, MotorwayView> motorwayViews, MotorwayGeometryInfo motorwayGeometryInfo)
		{
			ComputeMotorwayEdgeOverlaps(motorwayGeometryInfo, motorwayViews);
			Dictionary<int, MotorwayDepth> dictionary = new Dictionary<int, MotorwayDepth>();
			foreach (KeyValuePair<int, MotorwayView> motorwayView in motorwayViews)
			{
				dictionary.Add(motorwayView.Key, new MotorwayDepth(motorwayView.Key));
			}
			foreach (KeyValuePair<int, MotorwayGeometryInfo.MotorwayEndEdges> endEdge in motorwayGeometryInfo.EndEdges)
			{
				FindDepthSegments(endEdge.Key, endEdge.Value.start, isStartEdge: true, motorwayViews, motorwayGeometryInfo.Polygons, dictionary);
				FindDepthSegments(endEdge.Key, endEdge.Value.end, isStartEdge: false, motorwayViews, motorwayGeometryInfo.Polygons, dictionary);
			}
			List<(List<MotorwayGeometryInfo.MotorwayEndEdge> endEdges, List<MotorwayDepthSegment> depthSegments)> depthSegmentGroups = GroupDepthSegments(dictionary);
			SortDepthSegmentGroups(depthSegmentGroups);
			AssignWorldspaceDepths(depthSegmentGroups);
			foreach (KeyValuePair<int, MotorwayView> motorwayView2 in motorwayViews)
			{
				motorwayView2.Value.SetMotorwayDepth(dictionary[motorwayView2.Key]);
			}
		}

		private static void AssignWorldspaceDepths(List<(List<MotorwayGeometryInfo.MotorwayEndEdge> endEdges, List<MotorwayDepthSegment> depthSegments)> depthSegmentGroups)
		{
			foreach (var depthSegmentGroup in depthSegmentGroups)
			{
				for (int i = 0; i < depthSegmentGroup.depthSegments.Count; i++)
				{
					depthSegmentGroup.depthSegments[i].depth = -4.5f + -1.5f * (float)(i + 1) / (float)depthSegmentGroup.depthSegments.Count;
				}
			}
		}

		private static void SortDepthSegmentGroups(List<(List<MotorwayGeometryInfo.MotorwayEndEdge> endEdges, List<MotorwayDepthSegment> depthSegments)> depthSegmentGroups)
		{
			foreach (var depthSegmentGroup in depthSegmentGroups)
			{
				depthSegmentGroup.depthSegments.Sort(delegate(MotorwayDepthSegment depthSegmentA, MotorwayDepthSegment depthSegmentB)
				{
					bool flag = false;
					bool flag2 = false;
					foreach (MotorwayDepthSegment item in depthSegmentGroup.depthSegments)
					{
						foreach (MotorwayLowerThanConstraint constraint in item.constraints)
						{
							flag = flag || (constraint.lowerMotorwayId == depthSegmentA.motorwayId && constraint.higherMotorwayId == depthSegmentB.motorwayId);
							flag2 = flag2 || (constraint.lowerMotorwayId == depthSegmentB.motorwayId && constraint.higherMotorwayId == depthSegmentA.motorwayId);
						}
						if (flag && flag2)
						{
							break;
						}
					}
					if ((flag && flag2) || (!flag && !flag2))
					{
						if (depthSegmentA.motorwayId >= depthSegmentB.motorwayId)
						{
							return 1;
						}
						return -1;
					}
					return (!flag) ? 1 : (-1);
				});
			}
		}

		private static List<(List<MotorwayGeometryInfo.MotorwayEndEdge> endEdges, List<MotorwayDepthSegment> depthSegments)> GroupDepthSegments(Dictionary<int, MotorwayDepth> motorwayDepths)
		{
			List<(List<MotorwayGeometryInfo.MotorwayEndEdge>, List<MotorwayDepthSegment>)> list = new List<(List<MotorwayGeometryInfo.MotorwayEndEdge>, List<MotorwayDepthSegment>)>();
			foreach (KeyValuePair<int, MotorwayDepth> motorwayDepth in motorwayDepths)
			{
				foreach (MotorwayDepthSegment depthSegment in motorwayDepth.Value.DepthSegments)
				{
					(List<MotorwayGeometryInfo.MotorwayEndEdge>, List<MotorwayDepthSegment>)? tuple = null;
					foreach (var item in list)
					{
						foreach (MotorwayLowerThanConstraint constraint in depthSegment.constraints)
						{
							if (item.Item1.Contains(constraint.endEdge))
							{
								tuple = item;
								break;
							}
						}
					}
					if (!tuple.HasValue)
					{
						tuple = (new List<MotorwayGeometryInfo.MotorwayEndEdge>(), new List<MotorwayDepthSegment>());
						list.Add(tuple.Value);
					}
					foreach (MotorwayLowerThanConstraint constraint2 in depthSegment.constraints)
					{
						if (!tuple.Value.Item1.Contains(constraint2.endEdge))
						{
							tuple.Value.Item1.Add(constraint2.endEdge);
						}
					}
					tuple.Value.Item2.Add(depthSegment);
				}
			}
			return list;
		}

		public bool CanCalculateDepthSegments(Dictionary<int, MotorwayView> motorwayViews)
		{
			if (motorwayViews.Count <= 0)
			{
				return false;
			}
			foreach (MotorwayView value in motorwayViews.Values)
			{
				if (value.Spline.spline == null)
				{
					return false;
				}
			}
			return true;
		}

		private (int, int) MotorwayIntersectionCacheKey(int motorwayIdA, int motorwayIdB)
		{
			return (Math.Min(motorwayIdA, motorwayIdB), Math.Max(motorwayIdA, motorwayIdB));
		}

		private Dictionary<(int, int), List<MotorwayIntersectionUtil.MotorwayIntersection>> ComputeIntersectionPoints(Dictionary<int, MotorwayGeometryInfo.MotorwayEndEdges> endEdges, Dictionary<int, MotorwayPolygon> motorwayPolygons)
		{
			Dictionary<(int, int), List<MotorwayIntersectionUtil.MotorwayIntersection>> dictionary = new Dictionary<(int, int), List<MotorwayIntersectionUtil.MotorwayIntersection>>();
			foreach (KeyValuePair<int, MotorwayGeometryInfo.MotorwayEndEdges> endEdge in endEdges)
			{
				int key = endEdge.Key;
				MotorwayPolygon polygonA = motorwayPolygons[key];
				List<int> list = new List<int>(endEdge.Value.start.overlappingMotorwayIds);
				list.AddRange(endEdge.Value.end.overlappingMotorwayIds);
				foreach (int item in list)
				{
					(int, int) key2 = MotorwayIntersectionCacheKey(key, item);
					if (!dictionary.ContainsKey(key2))
					{
						MotorwayPolygon polygonB = motorwayPolygons[item];
						MotorwayIntersectionUtil.PolygonIntersectsPolygon(polygonA, polygonB, out var intersections);
						dictionary.Add(key2, intersections);
					}
				}
			}
			return dictionary;
		}

		private void FindDepthSegments(int endEdgeMotorwayId, MotorwayGeometryInfo.MotorwayEndEdge motorwayEndEdge, bool isStartEdge, Dictionary<int, MotorwayView> motorwayViews, Dictionary<int, MotorwayPolygon> motorwayPolygons, Dictionary<int, MotorwayDepth> motorwayDepth)
		{
			MotorwayPolygon polygonA = motorwayPolygons[endEdgeMotorwayId];
			Spline.RasterizedSpline rasterizedSpline = motorwayViews[endEdgeMotorwayId].Spline.spline.Rasterize(10);
			foreach (int overlappingMotorwayId in motorwayEndEdge.overlappingMotorwayIds)
			{
				Spline.RasterizedSpline motorwaySpline = motorwayViews[overlappingMotorwayId].Spline.spline.Rasterize(10);
				MotorwayPolygon polygonB = motorwayPolygons[overlappingMotorwayId];
				MotorwayIntersectionUtil.PolygonIntersectsPolygon(polygonA, polygonB, out var intersections);
				if (intersections.Count == 0)
				{
					Diagnostics.FailAssert("There should be intersections as the motorways end-edges were flagged as 'overlapping'");
				}
				else
				{
					if (intersections.Count == 1)
					{
						continue;
					}
					List<(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2)> list = SortIntersectionsAlongSpline(rasterizedSpline, intersections, isStartEdge);
					(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2) tuple = list[list.Count - 1];
					foreach (var item6 in list)
					{
						if (item6.Item1.isSeparatingOrJoining)
						{
							tuple = item6;
							break;
						}
					}
					MotorwayLowerThanConstraint item = new MotorwayLowerThanConstraint(motorwayEndEdge, endEdgeMotorwayId, overlappingMotorwayId);
					float startDistance = (isStartEdge ? 0f : rasterizedSpline.Length);
					Vector2 startPosition = (isStartEdge ? rasterizedSpline.Positions[0] : rasterizedSpline.Positions[rasterizedSpline.Positions.Count - 1]);
					MotorwayDepthSegment motorwayDepthSegment = new MotorwayDepthSegment(endEdgeMotorwayId, startDistance, startPosition, tuple.Item2, tuple.Item3);
					motorwayDepthSegment.constraints.Add(item);
					motorwayDepth[endEdgeMotorwayId].Add(motorwayDepthSegment);
					List<(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2)> list2 = SortIntersectionsAlongSpline(motorwaySpline, intersections, fromStart: true);
					int num = 0;
					for (int i = 0; i < list2.Count; i++)
					{
						if (list2[i].Item1.Equals(tuple.Item1))
						{
							num = i;
							break;
						}
					}
					int num2 = num - 1;
					int num3 = num + 1;
					bool flag = (num2 >= 0 && num3 >= list2.Count) || ((num2 >= 0 || num3 >= list.Count) && (num2 < 0 || num3 >= list2.Count || list2[num3].Item1.isSeparatingOrJoining));
					(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2) tuple2 = list2[num];
					MotorwayDepthSegment motorwayDepthSegment2;
					if (flag)
					{
						float item2 = list2[0].Item2;
						Vector2 item3 = list2[0].Item3;
						motorwayDepthSegment2 = new MotorwayDepthSegment(overlappingMotorwayId, item2, item3, tuple2.Item2, tuple2.Item3);
					}
					else
					{
						float item4 = list2[list2.Count - 1].Item2;
						Vector2 item5 = list2[list2.Count - 1].Item3;
						motorwayDepthSegment2 = new MotorwayDepthSegment(overlappingMotorwayId, tuple2.Item2, tuple2.Item3, item4, item5);
					}
					motorwayDepthSegment2.constraints.Add(item);
					motorwayDepth[overlappingMotorwayId].Add(motorwayDepthSegment2);
				}
			}
		}

		private static List<(MotorwayIntersectionUtil.MotorwayIntersection point, float distance, Vector2 pointOnSpline)> SortIntersectionsAlongSpline(Spline.RasterizedSpline motorwaySpline, List<MotorwayIntersectionUtil.MotorwayIntersection> intersections, bool fromStart)
		{
			List<(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2)> list = new List<(MotorwayIntersectionUtil.MotorwayIntersection, float, Vector2)>(intersections.Count);
			foreach (MotorwayIntersectionUtil.MotorwayIntersection intersection in intersections)
			{
				(int closestStartIndex, int closestEndIndex) tuple = MotorwaySpline.ClosestEdgeOnSplineToPoint(motorwaySpline, intersection.point);
				int item = tuple.closestStartIndex;
				int item2 = tuple.closestEndIndex;
				Vector2 vector = motorwaySpline.Positions[item];
				Vector2 lhs = motorwaySpline.Positions[item2] - vector;
				float num = Vector2.Dot(lhs, intersection.point - vector) / lhs.magnitude;
				Vector2 vector2 = vector + lhs.normalized * num;
				float num2 = Vector2.Distance(vector, vector2);
				Vector2 b = vector;
				for (int num3 = item - 1; num3 >= 0; num3--)
				{
					Vector2 vector3 = motorwaySpline.Positions[num3];
					num2 += Vector2.Distance(vector3, b);
					b = vector3;
				}
				list.Add((intersection, num2, vector2));
			}
			list.Sort(delegate((MotorwayIntersectionUtil.MotorwayIntersection point, float distance, Vector2 pointOnSpline) intersectionA, (MotorwayIntersectionUtil.MotorwayIntersection point, float distance, Vector2 pointOnSpline) intersectionB)
			{
				if (intersectionA.distance < intersectionB.distance)
				{
					if (!fromStart)
					{
						return 1;
					}
					return -1;
				}
				if (!(intersectionA.distance > intersectionB.distance))
				{
					return 0;
				}
				return fromStart ? 1 : (-1);
			});
			return list;
		}

		private void ComputeMotorwayEdgeOverlaps(MotorwayGeometryInfo motorwayGeometryInfo, Dictionary<int, MotorwayView> motorwayViews)
		{
			foreach (KeyValuePair<int, AxisAlignedBoundingBox> bound in motorwayGeometryInfo.Bounds)
			{
				if ((motorwayViews[bound.Key].Motorway.State & RoadState.VisiblyActive) == 0)
				{
					continue;
				}
				MotorwayPolygon motorwayPolygon = motorwayGeometryInfo.Polygons[bound.Key];
				foreach (KeyValuePair<int, MotorwayGeometryInfo.MotorwayEndEdges> endEdge in motorwayGeometryInfo.EndEdges)
				{
					if (bound.Key != endEdge.Key && (motorwayViews[endEdge.Key].Motorway.State & RoadState.VisiblyActive) != RoadState.None)
					{
						MotorwayGeometryInfo.MotorwayEndEdges value = endEdge.Value;
						if (MotorwayIntersectionUtil.EndEdgeIntersectsPolygon(motorwayPolygon, value.start, bound.Value))
						{
							value.start.overlappingMotorwayIds.Add(motorwayPolygon.motorwayId);
						}
						if (MotorwayIntersectionUtil.EndEdgeIntersectsPolygon(motorwayPolygon, value.end, bound.Value))
						{
							value.end.overlappingMotorwayIds.Add(motorwayPolygon.motorwayId);
						}
					}
				}
			}
		}

		public void Reset()
		{
		}
	}
}
