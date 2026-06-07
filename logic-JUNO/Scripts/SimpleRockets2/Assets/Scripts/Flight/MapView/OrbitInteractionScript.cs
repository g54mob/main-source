using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView
{
	public class OrbitInteractionScript : MonoBehaviour
	{
		public delegate void OrbitInteractionDelegate(OrbitInteractionScript source, OrbitCursorInfo pointInfo);

		public class OrbitCursorInfo
		{
			public IOrbitPoint ClosestPoint { get; private set; } = new OrbitPoint();

			public Vector3d ClosestPositionMapViewCoords { get; set; }

			public Vector3 ClosestPositionOnOrbitScreen { get; set; }

			public Vector3 CursorPosition { get; set; }

			public float HoverStartTime { get; private set; }

			public float HoverTime { get; private set; }

			public MapOrbitInfo OrbitInfo { get; set; }

			public void SetTimes(float startTime, float currentTime)
			{
				HoverStartTime = startTime;
				HoverTime = currentTime - HoverStartTime;
			}
		}

		public const string PointerDebugToggleButton = "pointer debug";

		private OrbitCursorInfo _activeCursorInfo;

		private IChainNodeList _chainNodeList;

		private IMapViewCoordinateConverter _coordinateConverter;

		private ICraftInfo _craftinfo;

		private OrbitCursorInfo[] _hoveredOrbitCachedInstances = new OrbitCursorInfo[2]
		{
			new OrbitCursorInfo(),
			new OrbitCursorInfo()
		};

		private OrbitCursorInfo _hoveredOrbitLastUsedCachedInstance;

		private float _hoverStartTime;

		private IMapView _mapView;

		private bool _pointerDebug;

		public OrbitCursorInfo CursorInfo => _activeCursorInfo;

		public event OrbitInteractionDelegate HoverEnter;

		public event OrbitInteractionDelegate HoverExit;

		public event OrbitInteractionDelegate HoverStay;

		public static OrbitInteractionScript Create(IIocContainer ioc, ICraftContext craftContext)
		{
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(context);
			ICraftInfo craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			GameObject obj = new GameObject($"OrbitInteraction({craftInfo.ItemName})");
			obj.transform.parent = objectContainerProvider.FloatingOriginIgnoreContainer;
			obj.layer = objectContainerProvider.FloatingOriginIgnoreContainer.gameObject.layer;
			OrbitInteractionScript orbitInteractionScript = obj.AddComponent<OrbitInteractionScript>();
			orbitInteractionScript.Initialize(ioc, craftContext);
			return orbitInteractionScript;
		}

		public static IOrbitPoint GetOrbitPointFromScreenPosition(IMapViewCoordinateConverter coordinateConverter, Camera camera, MapOrbitInfo orbitInfo, Vector3 screenPos)
		{
			Vector3? pointerPositionOnOrbitalPlane = GetPointerPositionOnOrbitalPlane(screenPos, orbitInfo, coordinateConverter, camera);
			IOrbitPoint result = null;
			if (pointerPositionOnOrbitalPlane.HasValue)
			{
				result = GetClosestPointOnOrbit(orbitInfo, pointerPositionOnOrbitalPlane.Value, coordinateConverter, screenPos, camera, showDebugLine: false, out var _);
			}
			return result;
		}

		public void OnBeforeCameraPositioned()
		{
			UpdatePointerHoverEvents();
		}

		private static IOrbitPoint GetClosestPointOnOrbit(MapOrbitInfo orbitInfo, Vector3d mapViewOrbitalPlanePosition, IMapViewCoordinateConverter coordinateConverter, bool showDebugLine, out Vector3d? closestPointMapCoords)
		{
			return GetClosestPointOnOrbit(orbitInfo, mapViewOrbitalPlanePosition, coordinateConverter, null, null, showDebugLine, out closestPointMapCoords);
		}

		private static IOrbitPoint GetClosestPointOnOrbit(MapOrbitInfo orbitInfo, Vector3d mapViewOrbitalPlanePosition, IMapViewCoordinateConverter coordinateConverter, Vector3? screenPos, Camera mapCamera, bool showDebugLine, out Vector3d? closestPointMapCoords)
		{
			IOrbitNode orbitNode = orbitInfo.OrbitNode;
			Vector3d referenceSolarPosition = orbitInfo.DrawModeProvider.DrawMode.GetReferenceSolarPosition(orbitInfo);
			Vector3d position = coordinateConverter.ConvertMapViewToSolar(mapViewOrbitalPlanePosition) - referenceSolarPosition;
			IOrbitPoint orbitPoint = OrbitMath.GetClosestPointOnOrbit(orbitNode.Orbit, position);
			closestPointMapCoords = null;
			if (orbitPoint != null)
			{
				Vector3d solarPosition = orbitPoint.Position + referenceSolarPosition;
				closestPointMapCoords = coordinateConverter.ConvertSolarToMapView(solarPosition);
				if (showDebugLine)
				{
					DebugGizmos.DrawLine(orbitInfo.Id.ToString(), (Vector3)mapViewOrbitalPlanePosition, (Vector3)coordinateConverter.ConvertSolarToMapView(referenceSolarPosition), orbitInfo.OrbitColor, LayerMask.NameToLayer("MapView"));
				}
			}
			if (screenPos.HasValue && mapCamera != null)
			{
				IOrbitPoint closestPointOnOrbit = OrbitMath.GetClosestPointOnOrbit(orbitNode.Orbit, position, useAlternateMethod: true);
				if (closestPointOnOrbit != null)
				{
					Vector3d solarPosition2 = closestPointOnOrbit.Position + referenceSolarPosition;
					Vector3d value = coordinateConverter.ConvertSolarToMapView(solarPosition2);
					if (orbitPoint != null && closestPointMapCoords.HasValue)
					{
						Vector2 a = mapCamera.WorldToScreenPoint(closestPointMapCoords.Value.ToVector3());
						Vector2 vector = mapCamera.WorldToScreenPoint(value.ToVector3());
						Vector2 vector2 = screenPos.Value;
						if (Vector2.Distance(a, vector2) > Vector3.Distance(vector, vector2))
						{
							orbitPoint = closestPointOnOrbit;
							closestPointMapCoords = value;
						}
					}
					else
					{
						orbitPoint = closestPointOnOrbit;
						closestPointMapCoords = value;
					}
				}
			}
			return orbitPoint;
		}

		private static Vector3? GetPointerPositionOnOrbitalPlane(Vector3 cursorPosition, MapOrbitInfo orbitInfo, IMapViewCoordinateConverter coordinateConverter, Camera camera)
		{
			Vector3d referenceSolarPosition = orbitInfo.DrawModeProvider.DrawMode.GetReferenceSolarPosition(orbitInfo);
			Ray ray = Utilities.ScreenPointToRay(camera, cursorPosition);
			if (Math3d.RayPlaneIntersection(out var intersection, ray.origin, ray.direction, orbitInfo.OrbitNode.Orbit.OrbitalPlaneNormal, coordinateConverter.ConvertSolarToMapView(referenceSolarPosition)))
			{
				return (Vector3)intersection;
			}
			return null;
		}

		private void Initialize(IIocContainer ioc, ICraftContext craftContext)
		{
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			_chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			_craftinfo = ioc.Resolve<ICraftInfo>(craftContext);
			_coordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(context);
			_mapView = ioc.Resolve<IMapView>(context);
			DebugPanel.Instance.AddToggleButton("pointer debug", initialValue: false, delegate(bool x)
			{
				_pointerDebug = x;
			}, rebuildUi: false);
			HoverEnter += OnHoverEnter;
			HoverExit += OnHoverExit;
			HoverStay += OnHoverStay;
		}

		private void OnHoverEnter(OrbitInteractionScript source, OrbitCursorInfo pointInfo)
		{
			pointInfo.OrbitInfo.OrbitInteractionEventRecipient.OnHoverEnter(source, pointInfo);
		}

		private void OnHoverExit(OrbitInteractionScript source, OrbitCursorInfo pointInfo)
		{
			pointInfo.OrbitInfo.OrbitInteractionEventRecipient.OnHoverExit(source, pointInfo);
		}

		private void OnHoverStay(OrbitInteractionScript source, OrbitCursorInfo pointInfo)
		{
			pointInfo.OrbitInfo.OrbitInteractionEventRecipient.OnHoverStay(source, pointInfo);
		}

		private double UpdateIfCloser(MapOrbitInfo orbitInfo, Vector3 screenPos, ref OrbitCursorInfo currentClosestOrbitInfo, double prevClosestSqrDistance)
		{
			Vector3? pointerPositionOnOrbitalPlane = GetPointerPositionOnOrbitalPlane(screenPos, orbitInfo, _coordinateConverter, _mapView.MapCamera);
			if (pointerPositionOnOrbitalPlane.HasValue)
			{
				Vector3d? closestPointMapCoords;
				IOrbitPoint closestPointOnOrbit = GetClosestPointOnOrbit(orbitInfo, pointerPositionOnOrbitalPlane.Value, _coordinateConverter, screenPos, _mapView.MapCamera, _pointerDebug, out closestPointMapCoords);
				if (closestPointOnOrbit != null)
				{
					double validTrueAnomalyStart = orbitInfo.ValidTrueAnomalyStart;
					double validTrueAnomalyEnd = orbitInfo.ValidTrueAnomalyEnd;
					if (OrbitMath.TrueAnomalyBetween(closestPointOnOrbit.TrueAnomaly, validTrueAnomalyStart, validTrueAnomalyEnd, inclusive: true))
					{
						float sqrMagnitude = (pointerPositionOnOrbitalPlane.Value - (Vector3)closestPointMapCoords.Value).sqrMagnitude;
						if (currentClosestOrbitInfo == null)
						{
							if (_hoveredOrbitLastUsedCachedInstance == null || _hoveredOrbitLastUsedCachedInstance == _hoveredOrbitCachedInstances[1])
							{
								currentClosestOrbitInfo = _hoveredOrbitCachedInstances[0];
							}
							else
							{
								currentClosestOrbitInfo = _hoveredOrbitCachedInstances[1];
							}
							_hoveredOrbitLastUsedCachedInstance = currentClosestOrbitInfo;
						}
						if ((double)sqrMagnitude < prevClosestSqrDistance)
						{
							prevClosestSqrDistance = sqrMagnitude;
							currentClosestOrbitInfo.OrbitInfo = orbitInfo;
							currentClosestOrbitInfo.ClosestPositionMapViewCoords = closestPointMapCoords.Value;
							currentClosestOrbitInfo.CursorPosition = pointerPositionOnOrbitalPlane.Value;
							currentClosestOrbitInfo.ClosestPoint.Set(closestPointOnOrbit);
						}
					}
				}
			}
			return prevClosestSqrDistance;
		}

		private void UpdatePointerDebugInfo(Vector3d closestPoint, Vector3 worldPointerPosition)
		{
		}

		private void UpdatePointerHoverEvents()
		{
			OrbitCursorInfo activeCursorInfo = _activeCursorInfo;
			_activeCursorInfo = null;
			if (_craftinfo.Data.ShowOrbitLine && !_craftinfo.OrbitInfo.InContactWithPlanet)
			{
				OrbitCursorInfo currentClosestOrbitInfo = null;
				double prevClosestSqrDistance = double.MaxValue;
				Vector3 mousePosition = UnityEngine.Input.mousePosition;
				foreach (IChainableOrbit chainNode in _chainNodeList.ChainNodes)
				{
					prevClosestSqrDistance = UpdateIfCloser(chainNode.OrbitInfo, mousePosition, ref currentClosestOrbitInfo, prevClosestSqrDistance);
				}
				if (currentClosestOrbitInfo != null)
				{
					currentClosestOrbitInfo.ClosestPositionOnOrbitScreen = Utilities.GameWorldToScreenPoint(_mapView.MapCamera, (Vector3)currentClosestOrbitInfo.ClosestPositionMapViewCoords);
					if (((Vector2)(currentClosestOrbitInfo.ClosestPositionOnOrbitScreen - mousePosition)).sqrMagnitude < 400f || _pointerDebug)
					{
						_activeCursorInfo = currentClosestOrbitInfo;
					}
				}
			}
			if (_activeCursorInfo != null)
			{
				if (activeCursorInfo == null || activeCursorInfo.OrbitInfo.Id != _activeCursorInfo.OrbitInfo.Id)
				{
					if (activeCursorInfo != null)
					{
						activeCursorInfo.SetTimes(_hoverStartTime, Time.unscaledTime);
						this.HoverExit(this, activeCursorInfo);
					}
					_hoverStartTime = Time.unscaledTime;
					_activeCursorInfo.SetTimes(_hoverStartTime, Time.unscaledTime);
					this.HoverEnter(this, _activeCursorInfo);
				}
				else
				{
					_activeCursorInfo.SetTimes(_hoverStartTime, Time.unscaledTime);
					this.HoverStay(this, _activeCursorInfo);
				}
			}
			else if (activeCursorInfo != null)
			{
				activeCursorInfo.SetTimes(_hoverStartTime, Time.unscaledTime);
				this.HoverExit(this, activeCursorInfo);
			}
		}
	}
}
