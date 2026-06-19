using UnityEngine;

namespace TH20.UI
{
	public class RoadRouteEditor : RouteEditor
	{
		public override void LoadRoute(AmbulanceRoute route)
		{
			base.LoadRoute(route);
			InstantiateControlPoints();
			for (int i = 0; i < _currentRoute.Junctions.Count; i++)
			{
				Vector2 vector = EmergencyDispatchMap.CalculateMapPositionFromRange(_mapRectTransform, _currentRoute.Junctions[i]);
				_controlPoints[i].Transform.localPosition = vector;
				_routeMapPositions.Add(vector);
			}
			_routeRenderer.SetPositions(_routeMapPositions);
			_isLoaded = true;
		}

		public override void AddPoint(Vector2 rectPosition)
		{
			_routeRenderer.SetPosition(_routeRenderer.Points.Length, rectPosition);
			_routeMapPositions.Add(rectPosition);
			CreateSingleControlPoint().Transform.localPosition = rectPosition;
		}

		public override void RemoveLastPoint()
		{
			if (_routeMapPositions.Count != 0)
			{
				int index = _routeMapPositions.Count - 1;
				_controlPoints[index].Destroy();
				_controlPoints.RemoveAt(index);
				_routeMapPositions.RemoveAt(index);
				_routeRenderer.SetPositions(_routeMapPositions);
			}
		}

		public override void ClearRoute()
		{
			if (_routeMapPositions.Count != 0)
			{
				ClearControlPoints();
				_routeMapPositions.Clear();
				_routeRenderer.ClearPositions();
			}
		}

		protected override void OnControlPointPositionChanged(int index, Vector2 position)
		{
			if (index < _routeMapPositions.Count)
			{
				_routeMapPositions[index] = position;
				_routeRenderer.SetPosition(index, _routeMapPositions[index]);
			}
		}
	}
}
