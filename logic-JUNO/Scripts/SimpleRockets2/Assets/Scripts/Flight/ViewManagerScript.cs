using System;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class ViewManagerScript : MonoBehaviour, IViewManager
	{
		private FlightSceneScript _flightSceneScript;

		[SerializeField]
		private GameViewScript _gameView;

		private MapViewManagerScript _mapViewManager;

		public GameViewScript GameView => _gameView;

		IGameView IViewManager.GameView => _gameView;

		public MapViewManagerScript MapViewManager => _mapViewManager;

		IMapViewManager IViewManager.MapViewManager => _mapViewManager;

		public event EventHandler<EventArgs> ViewChanged;

		public void Awake()
		{
			base.gameObject.AddComponent<TerrainRendererManagerScript>();
		}

		public void Initialize()
		{
			_flightSceneScript = FlightSceneScript.Instance;
			_gameView.Initialize((CraftNode)_flightSceneScript.CraftNode);
			_mapViewManager = MapViewManagerScript.Create(_flightSceneScript.FlightState.RootNode as PlanetNode, base.transform, _flightSceneScript.FlightState.SolarSystemData.MapViewScale, _flightSceneScript.FlightState.SolarSystemData.MaximumMapViewZoom);
			_gameView.RenderView = true;
			_mapViewManager.IsInForeground = false;
		}

		public void ToggleMapView()
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (!Game.IsCareer || CareerState.IsDebugMode || _mapViewManager.IsInForeground || validator.IsItemAvailable("Map.Enable"))
			{
				_gameView.RenderView = !_gameView.RenderView;
				_mapViewManager.IsInForeground = !_mapViewManager.IsInForeground;
				_flightSceneScript.FlightSceneUI.RestoreNavSphereVisibility();
				this.ViewChanged?.Invoke(this, new EventArgs());
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the map view yet. You can unlock it in the Tech Tree.";
			}
		}
	}
}
