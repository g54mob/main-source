using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.UI;
using ModApi.Common.Events;
using ModApi.Flight;
using ModApi.Flight.MapView;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class EvaSharedCamerasScript : MonoBehaviour
	{
		private static EvaSharedCamerasScript _instance;

		private IFlightScene _flightScene;

		private GameViewScript _gameView;

		private ViewPanelController _viewPanelController;

		public static EvaSharedCamerasScript Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Transform.gameObject.AddComponent<EvaSharedCamerasScript>();
					_instance.Initialize();
				}
				return _instance;
			}
		}

		public FirstPersonCameraController FpsController { get; private set; }

		internal OrbitCameraController ThirdPersonConroller { get; private set; }

		public void SetEvaCamerasEnabled(bool evaCamerasEnabled)
		{
			_viewPanelController.SetButtonsEnabledExcluding(evaCamerasEnabled, ThirdPersonConroller, FpsController);
			_gameView.CameraControllerManager.SelectCameraMode(evaCamerasEnabled ? ThirdPersonConroller.CameraModes[0] : _gameView.CameraControllerManager.DefaultModes.ModeOrbitPlanetAligned, saveAsDefault: false);
			_viewPanelController.ShowCustomCameraPartsPanel(!evaCamerasEnabled);
		}

		private void Initialize()
		{
			_flightScene = Game.Instance.FlightScene;
			_gameView = _flightScene.ViewManager.GameView as GameViewScript;
			_viewPanelController = _flightScene.FlightSceneUI.Transform.GetComponentInChildren<ViewPanelController>();
			ThirdPersonConroller = new OrbitCameraController(_gameView.CameraControllerManager);
			ThirdPersonConroller.SetZoom(15f);
			ThirdPersonConroller.InvertLeftRightAxisInput = true;
			FpsController = new FirstPersonCameraController(_gameView.CameraControllerManager);
			FpsController.EyeballOffset = 0.25f;
			FpsController.ClampDeltaRotationRange = new Vector2(70f, 180f);
			CameraMode cameraMode = new CameraMode("Third Person", ThirdPersonConroller, 0);
			CameraMode cameraMode2 = new CameraMode("First Person", FpsController, 0);
			_gameView.CameraControllerManager.AddCameraMode(cameraMode);
			_gameView.CameraControllerManager.AddCameraMode(cameraMode2);
			XmlElement xmlElement = _viewPanelController.RegisterCameraButton("camera-third-person", cameraMode);
			_viewPanelController.RegisterCameraButton("camera-first-person", cameraMode2).gameObject.SetActive(value: false);
			xmlElement.gameObject.SetActive(value: false);
			cameraMode.CameraController.SetEnabled(enabled: false, notifyCameraManager: true);
			cameraMode2.CameraController.SetEnabled(enabled: false, notifyCameraManager: true);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged += OnMapViewForegroundStateChanged;
			});
		}

		private void OnDestroy()
		{
			_instance = null;
			IMapViewManager mapViewManager = Game.Instance?.FlightScene?.ViewManager?.MapViewManager;
			if (mapViewManager != null)
			{
				mapViewManager.ForegroundStateChanged -= OnMapViewForegroundStateChanged;
			}
		}

		private void OnMapViewForegroundStateChanged(bool foreground)
		{
			EvaScript.UpdateCrosshairsVisibility();
		}
	}
}
