using System.Collections.Generic;
using System.Linq;
using FullInspector;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class EmergencyDispatchMap : MonoBehaviour
	{
		[SerializeField]
		private MapLayerParent[] _mapObjectHolders;

		[InspectorDivider]
		[InspectorMargin(8)]
		[SerializeField]
		private Image _mapImage;

		[SerializeField]
		private RectTransform _mapMask;

		private EmergencyDispatchMenu _emergencyDispatchMenu;

		private EmergencyDispatchMenu.Config _config;

		private RectTransform _mapRectTransform;

		private Bounds _mapScrollMargin;

		private Bounds _mapScrollBounds;

		private float _mapScrollRate;

		private bool _hasScrollTarget;

		private Vector2 _originalMapPosition;

		private Vector2 _currentMapPosition;

		private Vector2 _targetMapPosition;

		private UIMapPin _selectedMapPin;

		private readonly List<UIMapPin> _mapPins = new List<UIMapPin>();

		private readonly Dictionary<Ambulance, AmbulanceRouteRenderer> _routeRenderers = new Dictionary<Ambulance, AmbulanceRouteRenderer>();

		public UIMapPin SelectedPin => _selectedMapPin;

		public RectTransform MapMask => _mapMask;

		public void Setup(EmergencyDispatchMenu emergencyDispatchMenu)
		{
			_emergencyDispatchMenu = emergencyDispatchMenu;
			_config = _emergencyDispatchMenu.Definition;
			_mapRectTransform = (RectTransform)_mapImage.transform;
			_originalMapPosition = _mapRectTransform.anchoredPosition;
			_currentMapPosition = _originalMapPosition;
			_targetMapPosition = _originalMapPosition;
			if (_config.LevelIdsAndMaps.TryGetValue(emergencyDispatchMenu.Level.Config.UniqueId, out var value))
			{
				_mapImage.sprite = value;
			}
			_mapScrollMargin = _config.MapScrollMargin;
			_mapScrollRate = _config.MapScrollRate;
			_mapScrollBounds = new Bounds(size: new Vector2
			{
				x = _mapImage.rectTransform.rect.width - _mapMask.rect.width,
				y = _mapImage.rectTransform.rect.height - _mapMask.rect.height
			}, center: Vector3.zero);
		}

		public void SetSelectedMapPin(UIMapPin pin)
		{
			if (!(_selectedMapPin == pin))
			{
				CloseAllSelectionsOnMap();
				_selectedMapPin = pin;
				if (_selectedMapPin as EmergencyPin != null || _selectedMapPin == null)
				{
					RefreshAllAmbulancePinStates();
				}
				RefreshAllRouteStates();
				ScrollPinToMapCenterIfRequired(pin);
			}
		}

		public void CloseAllSelectionsOnMap()
		{
			if (!(_selectedMapPin == null))
			{
				_selectedMapPin.Deselect();
				if (_selectedMapPin is EmergencyPin emergencyPin)
				{
					emergencyPin.SelectMenu.CloseMenu();
					_emergencyDispatchMenu.HideAmbulanceSelectionMenu();
				}
			}
		}

		private void PlaceRectTransformOnMap(Transform transformToPlace, Vector2 location, MapLayerParent.EMapLayer layer)
		{
			Transform parentTransformFromLayer = GetParentTransformFromLayer(layer);
			if (transformToPlace.parent != parentTransformFromLayer)
			{
				transformToPlace.SetParent(parentTransformFromLayer, worldPositionStays: true);
				transformToPlace.SetAsLastSibling();
				transformToPlace.localScale = Vector3.one;
			}
			transformToPlace.localPosition = CalculateMapPositionFromRange(_mapRectTransform, location);
		}

		public Transform GetParentTransformFromLayer(MapLayerParent.EMapLayer layer)
		{
			MapLayerParent[] mapObjectHolders = _mapObjectHolders;
			for (int i = 0; i < mapObjectHolders.Length; i++)
			{
				MapLayerParent mapLayerParent = mapObjectHolders[i];
				if (layer == mapLayerParent.MapLayer)
				{
					return mapLayerParent.ParentTransform;
				}
			}
			return null;
		}

		public void ScrollPinToMapCenterIfRequired(UIMapPin mapPin)
		{
			Vector3 vector = Vector3.zero;
			if (mapPin != null && mapPin is EmergencyPin)
			{
				vector = mapPin.transform.localPosition;
				vector.y += _emergencyDispatchMenu.EmergencyPinMenuRect.rect.height / 2f;
			}
			if (vector != Vector3.zero && !_mapScrollMargin.Contains(vector))
			{
				_hasScrollTarget = true;
				_targetMapPosition = mapPin.transform.localPosition;
			}
			else
			{
				_hasScrollTarget = false;
			}
		}

		public HospitalPin InstantiateHospitalPin(AmbulanceDepartment ambulanceDepartment)
		{
			if (_config == null)
			{
				return null;
			}
			HospitalPin hospitalPin = InstantiateMapPinInternal<HospitalPin>(_config.HospitalPinPrefab);
			if (hospitalPin != null)
			{
				hospitalPin.Setup(_emergencyDispatchMenu, this, ambulanceDepartment);
				PlaceRectTransformOnMap(hospitalPin.transform, hospitalPin.MapPosition, hospitalPin.MapLayer);
				_mapPins.Add(hospitalPin);
			}
			return hospitalPin;
		}

		public EmergencyPin InstantiateEmergencyPin(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			if (_config == null)
			{
				return null;
			}
			EmergencyPin emergencyPin = InstantiateMapPinInternal<EmergencyPin>(_config.EmergencyPinPrefab);
			if (emergencyPin != null)
			{
				emergencyPin.Setup(this, ambulanceEmergency, _emergencyDispatchMenu);
				PlaceRectTransformOnMap(emergencyPin.transform, emergencyPin.MapPosition, emergencyPin.MapLayer);
				_mapPins.Add(emergencyPin);
				if (ambulanceEmergency != null)
				{
					bool active = ambulanceEmergency.PatientsRemaining > 0;
					emergencyPin.SetActive(active);
				}
			}
			return emergencyPin;
		}

		public AmbulancePin InstantiateAmbulancePin(Ambulance ambulance)
		{
			if (_config == null)
			{
				return null;
			}
			AmbulancePin ambulancePin = InstantiateMapPinInternal<AmbulancePin>(_config.AmbulancePinPrefab);
			if (ambulancePin != null)
			{
				AmbulanceRouteRenderer routeRenderer = PlaceAmbulanceRouteOnMap(ambulance);
				ambulancePin.Setup(this, ambulance, routeRenderer);
				PlaceRectTransformOnMap(ambulancePin.transform, ambulancePin.MapPosition, ambulancePin.MapLayer);
				_mapPins.Add(ambulancePin);
				RefreshRenderStateChangeable(ambulancePin.Ambulance, ambulancePin);
			}
			return ambulancePin;
		}

		public void SetEmergencyPinActive(ChallengeAmbulanceEmergency emergency, bool active)
		{
			EmergencyPin emergencyPin = _mapPins.Find((UIMapPin x) => x is EmergencyPin emergencyPin2 && emergencyPin2.AmbulanceEmergency.EmergencyID == emergency.EmergencyID) as EmergencyPin;
			if (emergencyPin != null)
			{
				emergencyPin.SetActive(active);
			}
		}

		public void RemoveEmergencyPin(ChallengeAmbulanceEmergency emergency)
		{
			EmergencyPin emergencyPin = _mapPins.Find((UIMapPin x) => x is EmergencyPin emergencyPin2 && emergencyPin2.AmbulanceEmergency.EmergencyID == emergency.EmergencyID) as EmergencyPin;
			if (emergencyPin == null)
			{
				return;
			}
			if (_selectedMapPin == emergencyPin)
			{
				SetSelectedMapPin(null);
			}
			foreach (Ambulance item in emergencyPin.AmbulanceEmergency.AmbulancesInUse)
			{
				RemoveAmbulancePin(item);
			}
			_mapPins.Remove(emergencyPin);
			Object.Destroy(emergencyPin.gameObject);
		}

		public void RemoveAmbulancePin(Ambulance ambulance)
		{
			AmbulancePin ambulancePin = _mapPins.Find((UIMapPin x) => x is AmbulancePin ambulancePin2 && ambulancePin2.Ambulance == ambulance) as AmbulancePin;
			if (!(ambulancePin == null))
			{
				_mapPins.Remove(ambulancePin);
				Object.Destroy(ambulancePin.gameObject);
			}
		}

		public void RemoveAllMapPins()
		{
			for (int num = _mapPins.Count - 1; num >= 0; num--)
			{
				Object.Destroy(_mapPins[num].gameObject);
			}
			_mapPins.Clear();
		}

		public AmbulanceRouteRenderer PlaceAmbulanceRouteOnMap(Ambulance ambulance)
		{
			if (ambulance?.Owner == null || ambulance?.CurrentRoute == null)
			{
				return null;
			}
			AmbulanceRoute currentRoute = ambulance.CurrentRoute;
			if (_routeRenderers.TryGetValue(ambulance, out var value))
			{
				RefreshAllRouteStates();
				return value;
			}
			AmbulanceRouteRenderer ambulanceRouteRenderer = InstantiateRouteRenderer();
			if (ambulanceRouteRenderer == null)
			{
				return null;
			}
			ambulanceRouteRenderer.Setup(ambulance.Owner);
			Vector2[] array = ConvertRangePointsToMapPositions(currentRoute.Junctions);
			if (array != null)
			{
				if (currentRoute.RouteType == AmbulanceConfig.Type.Air)
				{
					ambulanceRouteRenderer.SetCurvedRoute(array);
				}
				else
				{
					ambulanceRouteRenderer.SetPositions(array);
				}
				_routeRenderers.Add(ambulance, ambulanceRouteRenderer);
				RefreshAllRouteStates();
			}
			return ambulanceRouteRenderer;
		}

		public static Vector2 CalculateMapPositionFromRange(RectTransform rectTransform, Vector2 location)
		{
			float num = location.x / 100f;
			float num2 = location.y / 100f;
			Rect rect = rectTransform.rect;
			return new Vector2(num * rect.width / 2f, num2 * rect.height / 2f);
		}

		public static Vector2 CalculateRangeFromMapPosition(RectTransform rectTransform, Vector2 mapPosition)
		{
			Rect rect = rectTransform.rect;
			return new Vector2
			{
				x = mapPosition.x / rect.width * 2f,
				y = mapPosition.y / rect.height * 2f
			} * 100f;
		}

		public ERenderState RefreshRenderStateChangeable(Ambulance ambulance, iRenderStateChangeable renderStateChangeable)
		{
			if (ambulance == null || renderStateChangeable == null)
			{
				return ERenderState.Neutral;
			}
			if (_selectedMapPin != null && _selectedMapPin is EmergencyPin emergencyPin && emergencyPin.AmbulanceEmergency.EmergencyID == ambulance.AmbulanceEmergency.EmergencyID)
			{
				renderStateChangeable.SetRenderState(ERenderState.Emphasised);
				return ERenderState.Emphasised;
			}
			renderStateChangeable.SetRenderState(ERenderState.Neutral);
			return ERenderState.Neutral;
		}

		private void RefreshAllAmbulancePinStates()
		{
			foreach (AmbulancePin item in _mapPins.Where((UIMapPin x) => x is AmbulancePin)?.Cast<AmbulancePin>())
			{
				RefreshRenderStateChangeable(item.Ambulance, item);
			}
		}

		private void RefreshAllRouteStates()
		{
			List<Ambulance> list = new List<Ambulance>();
			foreach (KeyValuePair<Ambulance, AmbulanceRouteRenderer> routeRenderer in _routeRenderers)
			{
				ERenderState eRenderState = RefreshRenderStateChangeable(routeRenderer.Key, routeRenderer.Value);
				MapLayerParent.EMapLayer eMapLayer = routeRenderer.Key.CurrentRoute.RouteType switch
				{
					AmbulanceConfig.Type.Road => (eRenderState != ERenderState.Emphasised) ? MapLayerParent.EMapLayer.DeselectedRoadRoutes : MapLayerParent.EMapLayer.SelectedRoadRoutes, 
					AmbulanceConfig.Type.Air => (eRenderState == ERenderState.Emphasised) ? MapLayerParent.EMapLayer.SelectedAirRoutes : MapLayerParent.EMapLayer.DeselectedAirRoutes, 
					_ => (eRenderState != ERenderState.Emphasised) ? MapLayerParent.EMapLayer.DeselectedRoadRoutes : MapLayerParent.EMapLayer.SelectedRoadRoutes, 
				};
				Transform parentTransformFromLayer = GetParentTransformFromLayer(eMapLayer);
				Transform transform = routeRenderer.Value.transform;
				if (parentTransformFromLayer != null && parentTransformFromLayer != transform.parent)
				{
					transform.SetParent(parentTransformFromLayer, worldPositionStays: true);
					if (routeRenderer.Key is PlayerAmbulance)
					{
						transform.SetAsLastSibling();
					}
					else
					{
						transform.SetAsFirstSibling();
					}
				}
				if (eMapLayer == MapLayerParent.EMapLayer.DeselectedAirRoutes)
				{
					list.Add(routeRenderer.Key);
				}
			}
			list = list.OrderByDescending((Ambulance a) => a.AmbulanceEmergency.Definition.Location.Instance.EmergencyLocation.y).ToList();
			for (int num = 0; num < list.Count; num++)
			{
				_routeRenderers[list[num]].transform.SetSiblingIndex(num);
			}
		}

		public void RemoveRouteIfNoLongerInUse(Ambulance key, bool force = false)
		{
			if (!_routeRenderers.TryGetValue(key, out var value))
			{
				return;
			}
			_routeRenderers.Remove(key);
			if (!force)
			{
				foreach (KeyValuePair<Ambulance, AmbulanceRouteRenderer> routeRenderer in _routeRenderers)
				{
					if (routeRenderer.Value == value)
					{
						return;
					}
				}
			}
			Object.Destroy(value.gameObject);
		}

		private void Update()
		{
			UpdateMapScroll();
			UpdateMapPins();
		}

		private void UpdateMapScroll()
		{
			Vector2 vector = (_hasScrollTarget ? (_originalMapPosition - _targetMapPosition) : _originalMapPosition);
			if (_hasScrollTarget)
			{
				vector = _mapScrollBounds.ClosestPoint(vector);
			}
			_currentMapPosition = _mapRectTransform.localPosition;
			if ((_currentMapPosition - vector).sqrMagnitude < 0.1f)
			{
				_mapRectTransform.localPosition = vector;
				return;
			}
			_currentMapPosition.x = MathUtils.InterpolateTo(_currentMapPosition.x, vector.x, _mapScrollRate, Time.unscaledDeltaTime);
			_currentMapPosition.y = MathUtils.InterpolateTo(_currentMapPosition.y, vector.y, _mapScrollRate, Time.unscaledDeltaTime);
			_mapRectTransform.localPosition = _currentMapPosition;
		}

		private void UpdateMapPins()
		{
			foreach (UIMapPin mapPin in _mapPins)
			{
				mapPin.UpdatePin(this);
			}
		}

		private T InstantiateMapPinInternal<T>(GameObject prefab) where T : UIMapPin
		{
			return Object.Instantiate(prefab).GetComponent<T>();
		}

		private AmbulanceRouteRenderer InstantiateRouteRenderer()
		{
			if (_config == null)
			{
				return null;
			}
			AmbulanceRouteRenderer component = Object.Instantiate(_config.RouteRendererPrefab).GetComponent<AmbulanceRouteRenderer>();
			if (component != null)
			{
				RectTransform rectTransform = (RectTransform)component.transform;
				if (rectTransform != null)
				{
					Transform parentTransformFromLayer = GetParentTransformFromLayer(MapLayerParent.EMapLayer.SelectedRoadRoutes);
					rectTransform.SetParent(parentTransformFromLayer, worldPositionStays: false);
					rectTransform.localScale = Vector3.one;
				}
			}
			return component;
		}

		private Vector2[] ConvertRangePointsToMapPositions(List<Vector2> points)
		{
			if (points == null || points.Count == 0)
			{
				return null;
			}
			Vector2[] array = new Vector2[points.Count];
			for (int i = 0; i < points.Count; i++)
			{
				array[i] = CalculateMapPositionFromRange(_mapRectTransform, points[i]);
			}
			return array;
		}

		public EmergencyPin CircleTutorialPin(bool active)
		{
			foreach (UIMapPin mapPin in _mapPins)
			{
				if (mapPin is EmergencyPin emergencyPin && emergencyPin.AmbulanceEmergency.IsTutorial)
				{
					emergencyPin.CircleTutorialPin(active);
					return emergencyPin;
				}
			}
			return null;
		}
	}
}
