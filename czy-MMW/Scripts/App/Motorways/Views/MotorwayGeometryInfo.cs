using System.Collections.Generic;
using Motorways.Utility;
using UnityEngine;
using Utils.Geometry;

namespace Motorways.Views
{
	public class MotorwayGeometryInfo
	{
		public class MotorwayEndEdge
		{
			public enum Type
			{
				Start = 0,
				End = 1
			}

			public int motorwayId;

			public Type type;

			public Vector2 from;

			public Vector2 to;

			public readonly List<int> overlappingMotorwayIds = new List<int>();

			public MotorwayEndEdge(int motorwayId, Type type, Vector2 from, Vector2 to)
			{
				this.motorwayId = motorwayId;
				this.type = type;
				this.from = from;
				this.to = to;
			}
		}

		public readonly struct MotorwayEndEdges
		{
			public readonly int motorwayId;

			public readonly MotorwayEndEdge start;

			public readonly MotorwayEndEdge end;

			public MotorwayEndEdges(int motorwayId, MotorwayEndEdge startEdge, MotorwayEndEdge endEdge)
			{
				this.motorwayId = motorwayId;
				start = startEdge;
				end = endEdge;
			}
		}

		public const int RasterizedResolution = 10;

		private Dictionary<int, MotorwayEndEdges> _motorwayEndEdges;

		private Dictionary<int, MotorwayPolygon> _motorwayPolygons;

		private Dictionary<int, AxisAlignedBoundingBox> _motorwayBounds;

		private readonly MotorwayVisualParameters _visualParameters;

		public Dictionary<int, MotorwayEndEdges> EndEdges => _motorwayEndEdges;

		public Dictionary<int, MotorwayPolygon> Polygons => _motorwayPolygons;

		public Dictionary<int, AxisAlignedBoundingBox> Bounds => _motorwayBounds;

		public MotorwayGeometryInfo(MotorwayVisualParameters visualParameters)
		{
			_visualParameters = visualParameters;
		}

		public void ComputeGeometryInfo(Dictionary<int, MotorwayView> motorwayViews)
		{
			if (motorwayViews.Count > 0)
			{
				float halfRoadWidth = 0.5f * _visualParameters.roadWidth + _visualParameters.roadOutlineWidth;
				_motorwayEndEdges = ComputeMotorwayEdges(motorwayViews, halfRoadWidth);
				_motorwayPolygons = ComputeMotorwayPolygons(motorwayViews, halfRoadWidth);
				_motorwayBounds = ComputeBounds(_motorwayPolygons);
			}
		}

		private Dictionary<int, MotorwayEndEdges> ComputeMotorwayEdges(Dictionary<int, MotorwayView> motorwayViews, float halfRoadWidth)
		{
			Dictionary<int, MotorwayEndEdges> dictionary = new Dictionary<int, MotorwayEndEdges>();
			foreach (KeyValuePair<int, MotorwayView> motorwayView in motorwayViews)
			{
				Vector2 vector = motorwayView.Value.Spline.spline.Evaluate(0f);
				Vector2 normalized = motorwayView.Value.Spline.spline.EvaluateTangent(0f).GetNormal().normalized;
				Vector2 vector2 = vector + halfRoadWidth * normalized;
				Vector2 to = vector + halfRoadWidth * -normalized;
				MotorwayEndEdge startEdge = new MotorwayEndEdge(motorwayView.Key, MotorwayEndEdge.Type.Start, vector2, to);
				Vector2 vector3 = motorwayView.Value.Spline.spline.Evaluate(1f);
				Vector2 normalized2 = motorwayView.Value.Spline.spline.EvaluateTangent(1f).GetNormal().normalized;
				Vector2 vector4 = vector3 + halfRoadWidth * normalized2;
				Vector2 to2 = vector3 + halfRoadWidth * -normalized2;
				MotorwayEndEdge endEdge = new MotorwayEndEdge(motorwayView.Key, MotorwayEndEdge.Type.End, vector4, to2);
				dictionary.Add(motorwayView.Key, new MotorwayEndEdges(motorwayView.Key, startEdge, endEdge));
			}
			return dictionary;
		}

		private Dictionary<int, MotorwayPolygon> ComputeMotorwayPolygons(Dictionary<int, MotorwayView> motorwayViews, float halfRoadWidth)
		{
			Dictionary<int, MotorwayPolygon> dictionary = new Dictionary<int, MotorwayPolygon>();
			foreach (KeyValuePair<int, MotorwayView> motorwayView in motorwayViews)
			{
				Spline.RasterizedSpline rasterizedSpline = motorwayView.Value.Spline.spline.Offset(halfRoadWidth, 10);
				Spline.RasterizedSpline rasterizedSpline2 = motorwayView.Value.Spline.spline.Offset(0f - halfRoadWidth, 10);
				Vector2Int startCoordinates = motorwayView.Value.Motorway.StartCoordinates;
				Vector2Int endCoordinates = motorwayView.Value.Motorway.EndCoordinates;
				if (startCoordinates.x > endCoordinates.x || (startCoordinates.x == endCoordinates.x && startCoordinates.y > endCoordinates.y))
				{
					Spline.RasterizedSpline rasterizedSpline3 = rasterizedSpline2;
					Spline.RasterizedSpline rasterizedSpline4 = rasterizedSpline;
					rasterizedSpline = rasterizedSpline3;
					rasterizedSpline2 = rasterizedSpline4;
				}
				List<MotorwayPoint> list = new List<MotorwayPoint>();
				if (rasterizedSpline2.Positions.Count > 0)
				{
					list.Add(new MotorwayPoint(rasterizedSpline2.Positions[0], MotorwayPointType.LeftEnd));
					for (int i = 1; i < rasterizedSpline2.Positions.Count - 1; i++)
					{
						new MotorwayPoint(rasterizedSpline2.Positions[i], MotorwayPointType.Left);
						list.Add(new MotorwayPoint(rasterizedSpline2.Positions[i], MotorwayPointType.Left));
					}
					list.Add(new MotorwayPoint(rasterizedSpline2.Positions[rasterizedSpline2.Positions.Count - 1], MotorwayPointType.LeftEnd));
				}
				list.Reverse();
				if (rasterizedSpline.Positions.Count > 0)
				{
					list.Add(new MotorwayPoint(rasterizedSpline.Positions[0], MotorwayPointType.RightEnd));
					for (int j = 1; j < rasterizedSpline.Positions.Count - 1; j++)
					{
						new MotorwayPoint(rasterizedSpline.Positions[j], MotorwayPointType.Right);
						list.Add(new MotorwayPoint(rasterizedSpline.Positions[j], MotorwayPointType.Right));
					}
					list.Add(new MotorwayPoint(rasterizedSpline.Positions[rasterizedSpline.Positions.Count - 1], MotorwayPointType.RightEnd));
				}
				dictionary.Add(motorwayView.Key, new MotorwayPolygon(motorwayView.Key, list));
			}
			return dictionary;
		}

		private Dictionary<int, AxisAlignedBoundingBox> ComputeBounds(Dictionary<int, MotorwayPolygon> motorwayPolygons)
		{
			Dictionary<int, AxisAlignedBoundingBox> dictionary = new Dictionary<int, AxisAlignedBoundingBox>();
			foreach (KeyValuePair<int, MotorwayPolygon> motorwayPolygon in motorwayPolygons)
			{
				Vector2 positiveInfinity = Vector2.positiveInfinity;
				Vector2 negativeInfinity = Vector2.negativeInfinity;
				foreach (MotorwayPoint point in motorwayPolygon.Value.points)
				{
					Vector2 position = point.position;
					positiveInfinity.x = ((position.x < positiveInfinity.x) ? position.x : positiveInfinity.x);
					positiveInfinity.y = ((position.y < positiveInfinity.y) ? position.y : positiveInfinity.y);
					negativeInfinity.x = ((position.x > negativeInfinity.x) ? position.x : negativeInfinity.x);
					negativeInfinity.y = ((position.y > negativeInfinity.y) ? position.y : negativeInfinity.y);
				}
				AxisAlignedBoundingBox value = new AxisAlignedBoundingBox(positiveInfinity, negativeInfinity);
				dictionary.Add(motorwayPolygon.Key, value);
			}
			return dictionary;
		}
	}
}
