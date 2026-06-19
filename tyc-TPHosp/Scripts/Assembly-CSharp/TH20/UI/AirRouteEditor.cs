using UnityEngine;

namespace TH20.UI
{
	public class AirRouteEditor : RouteEditor
	{
		private const int MaximumControlPoints = 4;

		public override Vector2[] GetRoute()
		{
			if (!_isLoaded)
			{
				return null;
			}
			Vector2[] array = new Vector2[_controlPoints.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = EmergencyDispatchMap.CalculateRangeFromMapPosition(_mapRectTransform, _controlPoints[i].Transform.localPosition);
			}
			return array;
		}

		public override void LoadRoute(AmbulanceRoute route)
		{
			base.LoadRoute(route);
			if (_currentRoute.Junctions.Count > 4)
			{
				ResizeToMaximumPoints();
			}
			InstantiateControlPoints();
			for (int i = 0; i < _currentRoute.Junctions.Count; i++)
			{
				Vector2 vector = EmergencyDispatchMap.CalculateMapPositionFromRange(_mapRectTransform, _currentRoute.Junctions[i]);
				_controlPoints[i].Transform.localPosition = vector;
				_routeMapPositions.Add(vector);
			}
			_routeRenderer.SetCurvedRoute(_routeMapPositions.ToArray());
			_isLoaded = true;
		}

		public override void AddPoint(Vector2 rectPosition)
		{
			if (_controlPoints.Count != 4)
			{
				_routeMapPositions.Add(rectPosition);
				_routeRenderer.SetCurvedRoute(_routeMapPositions);
				CreateSingleControlPoint().Transform.localPosition = rectPosition;
			}
		}

		public override void RemoveLastPoint()
		{
			if (_routeMapPositions.Count != 0)
			{
				int index = _routeMapPositions.Count - 1;
				_controlPoints[index].Destroy();
				_controlPoints.RemoveAt(index);
				_routeMapPositions.RemoveAt(index);
				_routeRenderer.SetCurvedRoute(_routeMapPositions);
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
				_routeRenderer.SetCurvedRoute(_routeMapPositions);
			}
		}

		private void ResizeToMaximumPoints()
		{
			int count = _currentRoute.Junctions.Count;
			if (count > 4)
			{
				_currentRoute.Junctions.RemoveRange(4, count - 4);
			}
		}
	}
}
