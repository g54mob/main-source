using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView
{
	public class MapViewManagerScript : MonoBehaviour, IMapViewManager, IGameTime
	{
		private MapViewScript _currentMapView;

		private double _gameTime;

		public static IMapViewManager Instance { get; private set; }

		public IIocContainer Ioc { get; private set; }

		public bool IsInForeground
		{
			get
			{
				return _currentMapView.IsInForeground;
			}
			set
			{
				this.ForegroundStateChanging?.Invoke(value);
				_currentMapView.SetForeground(value);
				this.ForegroundStateChanged?.Invoke(value);
			}
		}

		public MapViewScript MapView => _currentMapView;

		IMapView IMapViewManager.MapView => _currentMapView;

		public Camera MapViewCamera => _currentMapView.MapCamera;

		double IGameTime.Time
		{
			get
			{
				return _gameTime;
			}
			set
			{
				if (value != _gameTime)
				{
					double gameTime = _gameTime;
					_gameTime = value;
					OnGameTimeChanged(gameTime, value);
				}
			}
		}

		double IGameTime.WaveTime => 0.0;

		public event MapViewForegroundStateChangedHandler ForegroundStateChanged;

		public event MapViewForegroundStateChangedHandler ForegroundStateChanging;

		public static MapViewManagerScript Create(PlanetNode rootNode, Transform container, double scale, double maxZoomDistance)
		{
			GameObject obj = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/MapView/MapViewManager");
			obj.transform.SetParent(container);
			MapViewManagerScript component = obj.GetComponent<MapViewManagerScript>();
			component.Initialize(rootNode, scale, maxZoomDistance);
			return component;
		}

		public void SetProcessingModes(MapViewScript.RenderingModeType? renderingMode, MapViewScript.NodeProcessingModeType? nodeProcessingMode)
		{
			_currentMapView.SetProcessingModes(renderingMode, nodeProcessingMode);
		}

		protected virtual void Awake()
		{
			Instance = this;
		}

		protected virtual void LateUpdate()
		{
			if (!IsInForeground)
			{
				_currentMapView.PerformMapClosedUpdates();
			}
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
		}

		private void Initialize(PlanetNode rootNode, double scale, double maxZoomDistance)
		{
			if (Game.InFlightScene)
			{
				Ioc = Game.Instance.FlightScene.IocContainer;
			}
			else
			{
				Ioc = new IocContainer();
				Ioc.Register((IGameTime)this);
			}
			Ioc.Register((IMapViewManager)this);
			_currentMapView = MapViewScript.Create(this, Ioc, scale, maxZoomDistance, rootNode);
			if (Game.InPlanetStudioScene)
			{
				IsInForeground = true;
			}
		}

		private void OnGameTimeChanged(double oldTime, double newTime)
		{
			foreach (MapItem item in _currentMapView.Ioc.Resolve<IItemRegistry>(_currentMapView.Context).Items)
			{
				if (item.OrbitInfo.OrbitNode.Orbit != null && item.OrbitInfo.OrbitNode.Orbit.Time != newTime)
				{
					double elapsedTime = newTime - item.OrbitInfo.OrbitNode.Orbit.Time;
					item.OrbitInfo.OrbitNode.Orbit.AdvanceTime(elapsedTime, newTime);
				}
			}
		}
	}
}
