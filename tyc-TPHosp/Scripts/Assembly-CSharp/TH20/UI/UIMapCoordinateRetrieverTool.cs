#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using System.Linq;
using FullInspector.Generated.SharedInstance;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	[RequireComponent(typeof(GraphicRaycaster))]
	public class UIMapCoordinateRetrieverTool : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private SharedInstance_TH20UITH20_UI_CoordinateRetrieverConfig _config;

		[SerializeField]
		private RouteEditor _roadRouteEditor;

		[SerializeField]
		private RouteEditor _airRouteEditor;

		[SerializeField]
		private Image _mapImage;

		[SerializeField]
		private Canvas _canvas;

		private CoordinateRetrieverConfig _configInstance;

		private GraphicRaycaster _raycaster;

		private RouteEditor _routeEditor;

		public CoordinateRetrieverConfig Config => _config.Instance;

		public Canvas Canvas => _canvas;

		public void Awake()
		{
			_raycaster = GetComponent<GraphicRaycaster>();
			_configInstance = _config.Instance;
			switch (_configInstance.Route.Instance.RouteType)
			{
			case AmbulanceConfig.Type.All:
			case AmbulanceConfig.Type.Road:
				_routeEditor = _roadRouteEditor;
				_airRouteEditor.enabled = false;
				break;
			case AmbulanceConfig.Type.Air:
				_routeEditor = _airRouteEditor;
				_roadRouteEditor.enabled = false;
				break;
			}
			if (_configInstance.Map != null)
			{
				_mapImage.sprite = _configInstance.Map;
			}
		}

		public void Start()
		{
			_routeEditor.Setup(this, _mapImage.rectTransform);
			if (_configInstance?.Route?.Instance != null)
			{
				_routeEditor.LoadRoute(_config.Instance.Route.Instance);
			}
		}

		public void Update()
		{
			if (_routeEditor != null)
			{
				_routeEditor.UpdateControlPoints();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			RectTransform clickedTransform = GetClickedTransform(eventData);
			if (!(clickedTransform == null) && (bool)clickedTransform.GetComponent<CoordinateTarget>())
			{
				SetPointOnRoute(eventData);
			}
		}

		public void SaveRoute()
		{
			if (_config != null && _routeEditor != null)
			{
				Vector2[] route = _routeEditor.GetRoute();
				if (route != null && route.Length != 0)
				{
					_config.Instance.Route.Instance.Junctions = route.ToList();
				}
			}
		}

		public void Undo()
		{
			if (_routeEditor != null)
			{
				_routeEditor.RemoveLastPoint();
			}
		}

		public void Clear()
		{
			if (_routeEditor != null)
			{
				_routeEditor.ClearRoute();
			}
		}

		private void SetPointOnRoute(PointerEventData eventData)
		{
			RectTransform clickedTransform = GetClickedTransform(eventData);
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(clickedTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				Vector2 vector = EmergencyDispatchMap.CalculateRangeFromMapPosition(clickedTransform, localPoint);
				Vector2 vector2 = vector;
				Logging.Info("Local Cursor: " + vector2.ToString());
				_routeEditor.AddPoint(localPoint);
			}
		}

		private RectTransform GetClickedTransform(PointerEventData eventData)
		{
			List<RaycastResult> list = new List<RaycastResult>();
			_raycaster.Raycast(eventData, list);
			if (list.Count > 0)
			{
				return list[0].gameObject.transform as RectTransform;
			}
			return null;
		}
	}
}
