using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Utility;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.Trains;
using UnityEngine;

namespace Motorways
{
	public class LaneCursor : LaneModel.IObserver, IReusable, IReleasedFromScopeHandler
	{
		private struct Lane
		{
			private LaneModel _laneModel;

			private MotorwayView _motorwayView;

			private RailView _railView;

			private BoatPathView _boatPathView;

			private List<LineSegment> _lineSegments;

			private float _length;

			public bool IsStraight
			{
				get
				{
					if (_railView != null)
					{
						return _railView.LineSegmentCount == 1;
					}
					if (_boatPathView != null)
					{
						return _boatPathView.LineSegmentCount == 1;
					}
					if (_motorwayView == null)
					{
						return LineSegmentCount == 1;
					}
					return false;
				}
			}

			public float Length
			{
				get
				{
					if (_motorwayView != null)
					{
						return _motorwayView.GetLaneLength(_laneModel);
					}
					return _length;
				}
			}

			public float LengthRatio
			{
				get
				{
					if (_laneModel != null)
					{
						return Length / (float)_laneModel.Length;
					}
					return 1f;
				}
			}

			public int LineSegmentCount
			{
				get
				{
					if (_motorwayView != null)
					{
						return _motorwayView.GetLanePoints(_laneModel).Count - 1;
					}
					if (_lineSegments != null)
					{
						return _lineSegments.Count;
					}
					if (_railView != null)
					{
						return _railView.LineSegmentCount;
					}
					if (_boatPathView != null)
					{
						return _boatPathView.LineSegmentCount;
					}
					return 0;
				}
			}

			public LaneModel LaneModel => _laneModel;

			public LaneModel UnambiguousPreviousLane
			{
				get
				{
					if (_laneModel != null && _laneModel.InboundLanes.Count == 1)
					{
						return _laneModel.InboundLanes[0];
					}
					return null;
				}
			}

			public Lane(LaneModel laneModel, TilemapView tilemapView)
			{
				_laneModel = laneModel;
				_motorwayView = tilemapView.TryGetMotorwayViewForLane(laneModel);
				_railView = null;
				_boatPathView = null;
				_lineSegments = null;
				_length = 0f;
				if (_motorwayView == null)
				{
					_lineSegments = _laneModel.GetLineSegments();
					_length = (float)_laneModel.Length;
				}
			}

			public Lane(RailView railView)
			{
				_laneModel = null;
				_motorwayView = null;
				_railView = railView;
				_boatPathView = null;
				_lineSegments = _railView.LineSegments;
				_length = (float)_railView.Model.Length;
			}

			public Lane(BoatPathView boatPathView, BoatModel.BoatDirection direction)
			{
				_laneModel = null;
				_motorwayView = null;
				_railView = null;
				_boatPathView = boatPathView;
				if (direction == BoatModel.BoatDirection.Backwards)
				{
					_lineSegments = new List<LineSegment>();
					foreach (LineSegment lineSegment in boatPathView.LineSegments)
					{
						_lineSegments.Insert(0, new LineSegment(lineSegment.End, lineSegment.Start));
					}
				}
				else
				{
					_lineSegments = boatPathView.LineSegments;
				}
				_length = (float)boatPathView.Model.Length;
			}

			public Lane(List<LineSegment> lineSegments)
			{
				_laneModel = null;
				_motorwayView = null;
				_railView = null;
				_boatPathView = null;
				_lineSegments = lineSegments;
				_length = 0f;
				foreach (LineSegment lineSegment in _lineSegments)
				{
					_length += lineSegment.Length;
				}
			}

			public LineSegment GetLineSegment(int lineSegmentIndex)
			{
				if (_lineSegments != null)
				{
					if (!Diagnostics.Verify(lineSegmentIndex < _lineSegments.Count, "Invalid index for GetLineSegment."))
					{
						lineSegmentIndex = _lineSegments.Count - 1;
					}
					return _lineSegments[lineSegmentIndex];
				}
				if (_motorwayView != null)
				{
					List<Vector2> lanePoints = _motorwayView.GetLanePoints(_laneModel);
					if (!Diagnostics.Verify(lineSegmentIndex < lanePoints.Count - 1, "Invalid index for GetLineSegment."))
					{
						lineSegmentIndex = lanePoints.Count - 2;
					}
					return new LineSegment(lanePoints[lineSegmentIndex], lanePoints[lineSegmentIndex + 1]);
				}
				return LineSegment.Null;
			}

			public bool RepresentsLaneModel(LaneModel laneModel)
			{
				return _laneModel == laneModel;
			}

			public bool RepresentsRailView(RailView railView)
			{
				return _railView == railView;
			}

			public bool RepresentsBoatPathView(BoatPathView boatPathView)
			{
				return _boatPathView == boatPathView;
			}
		}

		private List<Lane> _path = new List<Lane>(4);

		private int _currentLaneIndex;

		private float _distanceAlongCurrentLane;

		private LaneModel _previousOriginLaneModelForPath;

		private RailTileModel _previousOriginRailTileModelForPath;

		private BoatPathTileModel _previousOriginBoatPathTileModelForPath;

		private LineSegment _currentLineSegment;

		private float _distanceAlongCurrentLineSegment;

		private int _currentLineSegmentIndex = -1;

		public Circle debugLastRadiusMovementCircle;

		public LineSegment debugLastRadiusMovementLineSegment;

		public List<LineSegment> debugBoatPath = new List<LineSegment>();

		[Dependency]
		private TilemapView _tilemapView;

		public Vector3 Position
		{
			get
			{
				if (_currentLineSegmentIndex == -1)
				{
					FindCurrentLineSegment();
				}
				return _currentLineSegment.GetPosition(_distanceAlongCurrentLineSegment);
			}
		}

		public void MoveToTrain(TrainView train, float stepAlpha, ViewIndex viewIndex, float additionalPrefixLength)
		{
			TrainModel model = train.Model;
			RailTileModel tile = model.CurrentFrame.tile;
			RailTileModel tile2 = model.NextFrame.tile;
			RailTileModel nextRailModel = model.NextFrame.tile.NextRailModel;
			_currentLineSegment = LineSegment.Null;
			_distanceAlongCurrentLineSegment = 0f;
			_currentLineSegmentIndex = -1;
			if (_previousOriginRailTileModelForPath == tile && tile == tile2)
			{
				RailView railView = viewIndex.GetRailView(_previousOriginRailTileModelForPath);
				_currentLaneIndex = -1;
				for (int i = 0; i < _path.Count; i++)
				{
					if (_path[i].RepresentsRailView(railView))
					{
						_currentLaneIndex = i;
						break;
					}
				}
				if (_currentLaneIndex != -1)
				{
					_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.distanceAlongTrack, (float)model.NextFrame.distanceAlongTrack, stepAlpha);
					_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
					return;
				}
			}
			if (_path.Count > 0)
			{
				ClearPath();
			}
			RailTileModel railTileModel = tile;
			while (additionalPrefixLength > 0f && railTileModel.PreviousRailModel != null)
			{
				railTileModel = railTileModel.PreviousRailModel;
				additionalPrefixLength -= (float)railTileModel.Length;
				_path.Insert(0, new Lane(viewIndex.GetRailView(railTileModel)));
			}
			_distanceAlongCurrentLane = 0f;
			if (tile == tile2)
			{
				_currentLaneIndex = _path.Count;
				_path.Add(new Lane(viewIndex.GetRailView(tile)));
				_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.distanceAlongTrack, (float)model.NextFrame.distanceAlongTrack, stepAlpha);
				_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
			}
			else
			{
				Lane item = new Lane(viewIndex.GetRailView(tile));
				float lengthRatio = item.LengthRatio;
				float num = (float)model.CurrentFrame.distanceAlongTrack * lengthRatio;
				float num2 = (float)tile.Length * lengthRatio;
				Lane item2 = new Lane(viewIndex.GetRailView(tile2));
				float lengthRatio2 = item2.LengthRatio;
				float num3 = (float)model.NextFrame.distanceAlongTrack * lengthRatio2;
				float num4 = (float)tile2.Length * lengthRatio2;
				if (tile.NextRailModel == tile2)
				{
					float num5 = num3 + (num2 - num);
					_distanceAlongCurrentLane = num + num5 * stepAlpha;
				}
				else
				{
					float num6 = num + (num4 - num3);
					_distanceAlongCurrentLane = num - num6 * stepAlpha;
				}
				if (_distanceAlongCurrentLane > num2)
				{
					_path.Add(item);
					_currentLaneIndex = _path.Count;
					_path.Add(item2);
					_distanceAlongCurrentLane -= num2;
				}
				else if (num < 0f)
				{
					_path.Add(item);
					_currentLaneIndex = _path.Count;
					_path.Add(item2);
					_distanceAlongCurrentLane += num4;
				}
				else
				{
					_currentLaneIndex = _path.Count;
					_path.Add(item);
					_path.Add(item2);
				}
			}
			if (nextRailModel != null)
			{
				_path.Add(new Lane(viewIndex.GetRailView(nextRailModel)));
			}
			_previousOriginRailTileModelForPath = tile;
		}

		public void MoveToBoat(BoatView boat, ViewIndex viewIndex, float stepAlpha)
		{
			BoatModel model = boat.Model;
			BoatPathTileModel tile = model.CurrentFrame.tile;
			BoatPathTileModel tile2 = model.NextFrame.tile;
			BoatPathTileModel nextBoatPathModelInDirection = model.NextFrame.tile.GetNextBoatPathModelInDirection(model.CurrentFrame.direction);
			_currentLineSegment = LineSegment.Null;
			_distanceAlongCurrentLineSegment = 0f;
			_currentLineSegmentIndex = -1;
			if (_previousOriginBoatPathTileModelForPath == tile && tile == tile2)
			{
				_currentLaneIndex = -1;
				BoatPathView boatPathView = viewIndex.GetBoatPathView(_previousOriginBoatPathTileModelForPath);
				for (int i = 0; i < _path.Count; i++)
				{
					if (_path[i].RepresentsBoatPathView(boatPathView))
					{
						_currentLaneIndex = i;
						break;
					}
				}
				if (_currentLaneIndex != -1)
				{
					_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.DistanceAlongPathSegment, (float)model.NextFrame.DistanceAlongPathSegment, stepAlpha);
					_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
					return;
				}
			}
			if (_path.Count > 0)
			{
				ClearPath();
			}
			_distanceAlongCurrentLane = 0f;
			if (tile == tile2)
			{
				_currentLaneIndex = _path.Count;
				_path.Add(new Lane(viewIndex.GetBoatPathView(tile), model.CurrentFrame.direction));
				_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.DistanceAlongPathSegment, (float)model.NextFrame.DistanceAlongPathSegment, stepAlpha);
				_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
			}
			else
			{
				Lane item = new Lane(viewIndex.GetBoatPathView(tile), model.CurrentFrame.direction);
				float lengthRatio = item.LengthRatio;
				float num = (float)model.CurrentFrame.DistanceAlongPathSegment * lengthRatio;
				float num2 = (float)tile.Length * lengthRatio;
				Lane item2 = new Lane(viewIndex.GetBoatPathView(tile2), model.CurrentFrame.direction);
				float lengthRatio2 = item2.LengthRatio;
				float num3 = (float)model.NextFrame.DistanceAlongPathSegment * lengthRatio2;
				float num4 = (float)tile2.Length * lengthRatio2;
				if (tile.GetNextBoatPathModelInDirection(model.CurrentFrame.direction) == tile2)
				{
					float num5 = num3 + (num2 - num);
					_distanceAlongCurrentLane = num + num5 * stepAlpha;
				}
				else
				{
					float num6 = num + (num4 - num3);
					_distanceAlongCurrentLane = num - num6 * stepAlpha;
				}
				if (_distanceAlongCurrentLane > num2)
				{
					_path.Add(item);
					_currentLaneIndex = _path.Count;
					_path.Add(item2);
					_distanceAlongCurrentLane -= num2;
				}
				else if (num < 0f)
				{
					_path.Add(item);
					_currentLaneIndex = _path.Count;
					_path.Add(item2);
					_distanceAlongCurrentLane += num4;
				}
				else
				{
					_currentLaneIndex = _path.Count;
					_path.Add(item);
					_path.Add(item2);
				}
			}
			if (nextBoatPathModelInDirection != null)
			{
				_path.Add(new Lane(viewIndex.GetBoatPathView(nextBoatPathModelInDirection), model.CurrentFrame.direction));
			}
			_previousOriginBoatPathTileModelForPath = tile;
		}

		public void MoveToVehicle(VehicleView vehicle, float stepAlpha)
		{
			VehicleModel model = vehicle.Model;
			LaneModel lane = model.CurrentFrame.lane;
			LaneModel lane2 = model.NextFrame.lane;
			LaneModel laneModel = ((model.path.Count > 0) ? model.path[0] : null);
			_currentLineSegment = LineSegment.Null;
			_distanceAlongCurrentLineSegment = 0f;
			_currentLineSegmentIndex = -1;
			if (_previousOriginLaneModelForPath == lane && lane == lane2)
			{
				_currentLaneIndex = -1;
				for (int i = 0; i < _path.Count; i++)
				{
					if (_path[i].RepresentsLaneModel(_previousOriginLaneModelForPath))
					{
						_currentLaneIndex = i;
						break;
					}
				}
				if (_currentLaneIndex != -1)
				{
					_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.distanceAlongLane, (float)model.NextFrame.distanceAlongLane, stepAlpha);
					_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
					if (_currentLaneIndex == _path.Count - 1 && laneModel != null)
					{
						_path.Add(new Lane(laneModel, _tilemapView));
					}
					return;
				}
			}
			if (_path.Count > 0)
			{
				ClearPath();
			}
			if (vehicle.PreviousLaneSegments.Count > 0)
			{
				_path.Add(new Lane(vehicle.PreviousLaneSegments));
			}
			_distanceAlongCurrentLane = 0f;
			if (lane == lane2)
			{
				_currentLaneIndex = _path.Count;
				_path.Add(new Lane(lane, _tilemapView));
				_distanceAlongCurrentLane = Mathf.Lerp((float)model.CurrentFrame.distanceAlongLane, (float)model.NextFrame.distanceAlongLane, stepAlpha);
				_distanceAlongCurrentLane *= _path[_currentLaneIndex].LengthRatio;
			}
			else
			{
				Lane item = new Lane(lane, _tilemapView);
				float lengthRatio = item.LengthRatio;
				float num = (float)model.CurrentFrame.distanceAlongLane * lengthRatio;
				float num2 = (float)lane.Length * lengthRatio;
				Lane item2 = new Lane(lane2, _tilemapView);
				float lengthRatio2 = item2.LengthRatio;
				float num3 = (float)model.NextFrame.distanceAlongLane * lengthRatio2 + (num2 - num);
				_distanceAlongCurrentLane = num + num3 * stepAlpha;
				if (_distanceAlongCurrentLane > num2)
				{
					_path.Add(item);
					_currentLaneIndex = _path.Count;
					_path.Add(item2);
					_distanceAlongCurrentLane -= num2;
				}
				else
				{
					_currentLaneIndex = _path.Count;
					_path.Add(item);
					_path.Add(item2);
				}
			}
			if (laneModel != null)
			{
				_path.Add(new Lane(laneModel, _tilemapView));
			}
			_previousOriginLaneModelForPath = lane;
			foreach (Lane item3 in _path)
			{
				item3.LaneModel?.Subscribe(this);
			}
		}

		public void Move(float distance)
		{
			_distanceAlongCurrentLane += distance;
			float length = _path[_currentLaneIndex].Length;
			while (_distanceAlongCurrentLane > length)
			{
				if (_currentLaneIndex + 1 >= _path.Count)
				{
					_distanceAlongCurrentLane = length;
					break;
				}
				_currentLaneIndex++;
				_distanceAlongCurrentLane -= length;
			}
			while (_distanceAlongCurrentLane < 0f)
			{
				if (_currentLaneIndex <= 0)
				{
					_distanceAlongCurrentLane = 0f;
					break;
				}
				_currentLaneIndex--;
				float length2 = _path[_currentLaneIndex].Length;
				_distanceAlongCurrentLane += length2;
			}
			_currentLineSegmentIndex = -1;
		}

		public bool MoveAlongRadius(float distance, out Vector3 position)
		{
			if (!Diagnostics.Verify(distance < 0f, "MoveAlongRadius does not support positive movement yet."))
			{
				position = Position;
				return false;
			}
			if (_currentLaneIndex != -1 && _path[_currentLaneIndex].IsStraight)
			{
				float num = 0f - distance;
				if (_distanceAlongCurrentLane >= num)
				{
					_distanceAlongCurrentLane -= num;
					_currentLineSegmentIndex = -1;
					position = Position;
					return true;
				}
				if (_currentLaneIndex >= 1)
				{
					Lane lane = _path[_currentLaneIndex - 1];
					if (lane.IsStraight && lane.Length + _distanceAlongCurrentLane >= num)
					{
						_currentLaneIndex--;
						_distanceAlongCurrentLane = lane.Length - (num - _distanceAlongCurrentLane);
						_currentLineSegmentIndex = -1;
						position = Position;
						return true;
					}
				}
			}
			if (_currentLineSegmentIndex == -1)
			{
				FindCurrentLineSegment();
			}
			Circle circle = (debugLastRadiusMovementCircle = new Circle(Position, Mathf.Abs(distance)));
			bool flag = true;
			while (!_currentLineSegment.IsNull)
			{
				debugLastRadiusMovementLineSegment = _currentLineSegment;
				float lastIntersectionCoordinate = GetLastIntersectionCoordinate(circle, _currentLineSegment, flag ? _distanceAlongCurrentLineSegment : (-1f));
				if (lastIntersectionCoordinate >= 0f)
				{
					float num2 = lastIntersectionCoordinate * _currentLineSegment.Length;
					_distanceAlongCurrentLane += num2 - _distanceAlongCurrentLineSegment;
					_distanceAlongCurrentLineSegment = num2;
					position = Position;
					return true;
				}
				flag = false;
				if (!MoveToPreviousLineSegment())
				{
					LineSegment lineSegment = (debugLastRadiusMovementLineSegment = new LineSegment(_currentLineSegment.Start - _currentLineSegment.Direction * circle.Radius * 3f, _currentLineSegment.Start));
					float lastIntersectionCoordinate2 = GetLastIntersectionCoordinate(circle, lineSegment);
					if (!(lastIntersectionCoordinate2 >= 0f))
					{
						break;
					}
					position = lineSegment.GetPosition(lastIntersectionCoordinate2 * lineSegment.Length);
					return true;
				}
			}
			position = Vector3.zero;
			return false;
		}

		public void OnLaneModelReleased(LaneModel laneModel)
		{
			ClearPath();
			_previousOriginLaneModelForPath = null;
		}

		private void ClearPath()
		{
			foreach (Lane item in _path)
			{
				item.LaneModel?.Unsubscribe(this);
			}
			_path.Clear();
		}

		private void FindCurrentLineSegment()
		{
			int lineSegmentCount = _path[_currentLaneIndex].LineSegmentCount;
			float num = 0f;
			for (_currentLineSegmentIndex = 0; _currentLineSegmentIndex < lineSegmentCount; _currentLineSegmentIndex++)
			{
				_currentLineSegment = _path[_currentLaneIndex].GetLineSegment(_currentLineSegmentIndex);
				if (num + _currentLineSegment.Length > _distanceAlongCurrentLane)
				{
					_distanceAlongCurrentLineSegment = _distanceAlongCurrentLane - num;
					break;
				}
				num += _currentLineSegment.Length;
			}
			if (_currentLineSegmentIndex >= lineSegmentCount)
			{
				_currentLineSegmentIndex = lineSegmentCount - 1;
				_distanceAlongCurrentLineSegment = _currentLineSegment.Length;
			}
		}

		private bool MoveToPreviousLineSegment()
		{
			if (_currentLineSegmentIndex == -1)
			{
				FindCurrentLineSegment();
			}
			if (_currentLineSegmentIndex == 0)
			{
				if (_currentLaneIndex == 0)
				{
					LaneModel unambiguousPreviousLane = _path[0].UnambiguousPreviousLane;
					if (unambiguousPreviousLane != null)
					{
						bool flag = false;
						foreach (Lane item in _path)
						{
							if (item.RepresentsLaneModel(unambiguousPreviousLane))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							unambiguousPreviousLane.Subscribe(this);
							_path.Insert(0, new Lane(unambiguousPreviousLane, _tilemapView));
							_currentLaneIndex = 1;
						}
					}
				}
				if (_currentLaneIndex == 0)
				{
					_distanceAlongCurrentLane = 0f;
					_distanceAlongCurrentLineSegment = 0f;
					return false;
				}
				_currentLaneIndex--;
				Lane lane = _path[_currentLaneIndex];
				_currentLineSegmentIndex = lane.LineSegmentCount - 1;
				_currentLineSegment = lane.GetLineSegment(_currentLineSegmentIndex);
				_distanceAlongCurrentLineSegment = _currentLineSegment.Length;
				_distanceAlongCurrentLane = lane.Length;
				return true;
			}
			_distanceAlongCurrentLane -= _distanceAlongCurrentLineSegment;
			_currentLineSegmentIndex--;
			_currentLineSegment = _path[_currentLaneIndex].GetLineSegment(_currentLineSegmentIndex);
			_distanceAlongCurrentLineSegment = _currentLineSegment.Length;
			return true;
		}

		private float GetLastIntersectionCoordinate(Circle circle, LineSegment lineSegment, float minimumDistanceAlongLineSegment = -1f)
		{
			Geometry.CircleLineIntersection circleLineIntersection = Geometry.TryCircleLineSegmentIntersection(circle, lineSegment);
			if (circleLineIntersection.count > 0)
			{
				float num = -1f;
				for (int i = 0; i < circleLineIntersection.count; i++)
				{
					float parametricCoordinate = lineSegment.GetParametricCoordinate(circleLineIntersection.GetIntersection(i));
					if (!(minimumDistanceAlongLineSegment >= 0f) || !(parametricCoordinate * lineSegment.Length > minimumDistanceAlongLineSegment))
					{
						num = Mathf.Max(num, parametricCoordinate);
					}
				}
				return num;
			}
			return -1f;
		}

		public void Reset()
		{
			_currentLaneIndex = 0;
			_distanceAlongCurrentLane = 0f;
			_currentLineSegment = LineSegment.Null;
			_distanceAlongCurrentLineSegment = 0f;
			_currentLineSegmentIndex = -1;
			debugLastRadiusMovementCircle = default(Circle);
			debugLastRadiusMovementLineSegment = default(LineSegment);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			ClearPath();
		}
	}
}
