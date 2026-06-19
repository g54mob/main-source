using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	public abstract class RouteEditor : MonoBehaviour
	{
		protected class ControlPoint
		{
			public Action<int, Vector2> OnPositionChanged;

			public RectTransform Transform;

			public readonly int Index;

			private const float _distanceClassedAsMove = 1f;

			private Vector2 _currentPosition;

			private Vector2 _previousPosition;

			public bool IsInitialised { get; private set; }

			public ControlPoint(int index, RectTransform transform)
			{
				Index = index;
				Transform = transform;
				Vector3 localPosition = Transform.localPosition;
				_currentPosition = localPosition;
				_previousPosition = localPosition;
				if (Transform != null)
				{
					TMP_Text componentInChildren = Transform.GetComponentInChildren<TMP_Text>();
					if (componentInChildren != null)
					{
						componentInChildren.text = (Index + 1).ToString();
					}
				}
				IsInitialised = true;
			}

			public void Update()
			{
				if (IsInitialised)
				{
					_previousPosition = _currentPosition;
					_currentPosition = Transform.localPosition;
					if (_currentPosition != _previousPosition && Vector2.Distance(_currentPosition, _previousPosition) >= 1f)
					{
						OnPositionChanged.InvokeSafe(Index, _currentPosition);
					}
				}
			}

			public void Destroy()
			{
				UnityEngine.Object.Destroy(Transform.gameObject);
			}
		}

		protected UIMapCoordinateRetrieverTool _coordinateRetrieverTool;

		protected List<ControlPoint> _controlPoints;

		protected RectTransform _mapRectTransform;

		protected AmbulanceRouteRenderer _routeRenderer;

		protected AmbulanceRoute _currentRoute;

		protected List<Vector2> _routeMapPositions;

		protected bool _isLoaded;

		public virtual void Setup(UIMapCoordinateRetrieverTool coordinateRetrieverTool, RectTransform mapTransform)
		{
			_coordinateRetrieverTool = coordinateRetrieverTool;
			_mapRectTransform = mapTransform;
			_routeRenderer = GetComponent<AmbulanceRouteRenderer>();
			_controlPoints = new List<ControlPoint>();
			_routeMapPositions = new List<Vector2>();
		}

		public virtual Vector2[] GetRoute()
		{
			if (!_isLoaded)
			{
				return null;
			}
			Vector2[] array = new Vector2[_routeRenderer.Points.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = EmergencyDispatchMap.CalculateRangeFromMapPosition(_mapRectTransform, _routeRenderer.Points[i]);
			}
			return array;
		}

		public virtual void LoadRoute(AmbulanceRoute route)
		{
			if (route != null && !(_routeRenderer == null))
			{
				_currentRoute = route;
				_routeMapPositions.Clear();
			}
		}

		public void UpdateControlPoints()
		{
			for (int i = 0; i < _controlPoints.Count; i++)
			{
				_controlPoints[i]?.Update();
			}
		}

		public virtual void OnDestroy()
		{
			ClearControlPoints();
		}

		public abstract void AddPoint(Vector2 rectPosition);

		public abstract void RemoveLastPoint();

		public abstract void ClearRoute();

		protected abstract void OnControlPointPositionChanged(int index, Vector2 position);

		protected void InstantiateControlPoints()
		{
			ClearControlPoints();
			for (int i = 0; i < _currentRoute.Junctions.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_coordinateRetrieverTool.Config.ControlPointPrefab, _mapRectTransform.position, Quaternion.identity);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(base.transform);
					DraggablePanel component = gameObject.GetComponent<DraggablePanel>();
					if (component != null)
					{
						component.SetCanvas(_coordinateRetrieverTool.Canvas);
					}
					ControlPoint controlPoint = new ControlPoint(i, (RectTransform)gameObject.transform);
					controlPoint.OnPositionChanged = (Action<int, Vector2>)Delegate.Combine(controlPoint.OnPositionChanged, new Action<int, Vector2>(OnControlPointPositionChanged));
					_controlPoints.Add(controlPoint);
				}
			}
		}

		protected ControlPoint CreateSingleControlPoint()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_coordinateRetrieverTool.Config.ControlPointPrefab, _mapRectTransform.position, Quaternion.identity);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(base.transform);
				DraggablePanel component = gameObject.GetComponent<DraggablePanel>();
				if (component != null)
				{
					component.SetCanvas(_coordinateRetrieverTool.Canvas);
				}
				ControlPoint controlPoint = new ControlPoint(_controlPoints.Count, (RectTransform)gameObject.transform);
				controlPoint.OnPositionChanged = (Action<int, Vector2>)Delegate.Combine(controlPoint.OnPositionChanged, new Action<int, Vector2>(OnControlPointPositionChanged));
				_controlPoints.Add(controlPoint);
				return controlPoint;
			}
			return null;
		}

		protected void ClearControlPoints()
		{
			if (_controlPoints != null && _controlPoints.Count != 0)
			{
				int count = _controlPoints.Count;
				while (count-- > 0)
				{
					ControlPoint controlPoint = _controlPoints[count];
					controlPoint.OnPositionChanged = (Action<int, Vector2>)Delegate.Remove(controlPoint.OnPositionChanged, new Action<int, Vector2>(OnControlPointPositionChanged));
					_controlPoints[count].Destroy();
				}
				_controlPoints.Clear();
			}
		}
	}
}
