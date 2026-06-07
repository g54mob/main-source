using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui;
using DG.Tweening;
using ModApi.Flight.UI;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class ViewPanelController : FlightPanelController
	{
		private Dictionary<XmlElement, CameraMode> _buttomMap = new Dictionary<XmlElement, CameraMode>();

		private XmlElement _cameraPanel;

		private XmlElement _cameraPartsPanel;

		private XmlElement _contractsButton;

		private ContractsPanel _contractsPanel;

		private IFlightSceneUI _flightSceneUi;

		private GameViewScript _gameView;

		private MapViewScript _mapView;

		private XmlElement _mapViewButton;

		private GameObject _recenterButton;

		private XmlElement _recenterHint;

		private XmlElement _toggleCameraPanelButton;

		private XmlElement _toggleCameraPartsPanelButton;

		public bool HasSeenRecenterTooltip
		{
			get
			{
				return Game.Instance.Settings.SeenNotifications.Contains("Flight-RecenterCamera");
			}
			private set
			{
				if (value)
				{
					Game.Instance.Settings.AddNotification("Flight-RecenterCamera");
				}
			}
		}

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
			_flightSceneUi = FlightSceneScript.Instance.FlightSceneUI;
		}

		public override void LateUpdatePanel(CraftNode craftNode)
		{
			base.LateUpdatePanel(craftNode);
			_contractsPanel?.Update();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_recenterButton = base.xmlLayout.GetElementById("recenter-button").gameObject;
			_mapViewButton = base.xmlLayout.GetElementById("toggle-map-view-button");
			_cameraPanel = base.xmlLayout.GetElementById("camera-panel");
			_cameraPartsPanel = base.xmlLayout.GetElementById("camera-parts-panel");
			_toggleCameraPanelButton = base.xmlLayout.GetElementById("toggle-camera-panel-button");
			_toggleCameraPartsPanelButton = base.xmlLayout.GetElementById("camera-parts");
			_contractsButton = base.xmlLayout.GetElementById("contracts-button");
			_recenterHint = base.xmlLayout.GetElementById("recenter-hint");
			if (Game.IsCareer)
			{
				XmlElement elementById = base.xmlLayout.GetElementById("contracts-panel");
				_contractsPanel = new ContractsPanel(elementById);
			}
			else
			{
				UnityEngine.Object.Destroy(_contractsButton.gameObject);
				_contractsButton = null;
			}
		}

		public void OnCameraModeClicked(XmlElement element)
		{
			CameraMode cameraMode = _buttomMap[element];
			_gameView.CameraControllerManager.SelectCameraMode(cameraMode, saveAsDefault: true, displayMessage: true);
		}

		public XmlElement RegisterCameraButton(string elementId, CameraMode cameraMode)
		{
			XmlElement elementById = base.xmlLayout.GetElementById(elementId);
			if (elementById != null)
			{
				_buttomMap[elementById] = cameraMode;
			}
			else
			{
				Debug.LogError("Could not find camera button with ID: " + elementId);
			}
			return elementById;
		}

		public void SetButtonsEnabledExcluding(bool enabled, params CameraController[] controllersToEnable)
		{
			foreach (KeyValuePair<XmlElement, CameraMode> item in _buttomMap)
			{
				XmlElement key = item.Key;
				CameraController cameraController = item.Value.CameraController;
				bool active = (controllersToEnable.Contains(cameraController) ? enabled : (!enabled));
				cameraController.SetEnabled(active, notifyCameraManager: false);
				key.gameObject.SetActive(active);
			}
		}

		public void ShowCustomCameraPartsPanel(bool show)
		{
			_toggleCameraPartsPanelButton.gameObject.SetActive(show);
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			bool flag = false;
			flag = (_gameView.RenderView && (_gameView.GameCamera.IsOffCenter || _gameView.CameraControllerManager.CurrentCameraController.IsOffCenter)) || _mapView.MapCameraScript.IsOffCenter;
			if (_recenterButton.activeSelf != flag)
			{
				if (flag && !HasSeenRecenterTooltip && _gameView.RenderView)
				{
					_recenterHint.SetActive(active: true);
					_recenterHint.transform.DOScale(1.1f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
				}
				_recenterButton.SetActive(flag);
			}
			if (_cameraPanel.Visible)
			{
				if (_gameView.CameraControllerManager.CurrentCameraController.IsCustom)
				{
					_toggleCameraPartsPanelButton.AddClass("selected");
				}
				else if (_toggleCameraPartsPanelButton.HasClass("selected"))
				{
					_toggleCameraPartsPanelButton.RemoveClass("selected");
				}
				foreach (KeyValuePair<XmlElement, CameraMode> item in _buttomMap)
				{
					if (item.Value != null)
					{
						if (item.Value.IsSelected)
						{
							item.Key.AddClass("selected");
						}
						else if (item.Key.HasClass("selected"))
						{
							item.Key.RemoveClass("selected");
						}
					}
				}
			}
			SelectButton(_mapViewButton, _mapView.Visible);
			SelectButton(_toggleCameraPanelButton, _cameraPanel.Visible);
			if (_contractsPanel != null)
			{
				SelectButton(_contractsButton, _contractsPanel.Visible);
			}
		}

		protected virtual void Start()
		{
			ViewManagerScript viewManager = FlightSceneScript.Instance.ViewManager;
			_mapView = viewManager.MapViewManager.MapView;
			_gameView = viewManager.GameView;
			CameraManagerScript.DefaultCameraModes defaultModes = _gameView.CameraControllerManager.DefaultModes;
			RegisterCameraButton("camera-planet-aligned", defaultModes.ModeOrbitPlanetAligned);
			RegisterCameraButton("camera-space-aligned", defaultModes.ModeOrbitSpaceAligned);
			RegisterCameraButton("camera-orbit-chase", defaultModes.ModeOrbitChaseView);
			RegisterCameraButton("camera-orbit-sr1", defaultModes.ModeOrbitSR1View);
			RegisterCameraButton("camera-fly-by-cinematic", defaultModes.ModeFlyByCinematic);
			RegisterCameraButton("camera-fly-by-stationary", defaultModes.ModeFlyByStationary);
			_gameView.CameraControllerManager.CustomCameraModeAdded += OnCustomCameraModeAdded;
			_gameView.CameraControllerManager.CustomCameraModeRemoved += OnCustomCameraModeRemoved;
			_gameView.CameraControllerManager.CameraEnabledStateChanged += OnCameraEnabledStateChanged;
			viewManager.ViewChanged += OnViewManagerViewChanged;
			ToggleViewSpecificElements();
			if (Game.IsCareer && Game.Instance.GameState.Career.Contracts.Active.Count > 0)
			{
				_contractsPanel.ShowFirstContract();
			}
		}

		private XmlElement GetCameraElement(CameraMode cameraMode)
		{
			return GetCameraEntry(cameraMode)?.Key;
		}

		private KeyValuePair<XmlElement, CameraMode>? GetCameraEntry(CameraMode cameraMode)
		{
			KeyValuePair<XmlElement, CameraMode>? result = null;
			foreach (KeyValuePair<XmlElement, CameraMode> item in _buttomMap)
			{
				if (item.Value == cameraMode)
				{
					result = item;
					return result;
				}
			}
			return result;
		}

		private void OnCameraEnabledStateChanged(CameraMode cameraMode)
		{
			XmlElement cameraElement = GetCameraElement(cameraMode);
			if (cameraElement != null)
			{
				cameraElement.gameObject.SetActive(cameraMode.CameraController.Enabled);
			}
			UpdateCustomCameraDropdownVisibility();
		}

		private void OnContractClicked(XmlElement contractElement)
		{
			_contractsPanel.OnContractClicked(contractElement);
		}

		private void OnContractsButtonClicked(XmlElement element)
		{
			_contractsPanel.Visible = !_contractsPanel.Visible;
			if (_contractsPanel.Visible)
			{
				_cameraPanel.Hide();
			}
		}

		private void OnCustomCameraModeAdded(CameraMode cameraMode)
		{
			if (!cameraMode.IsHidden)
			{
				XmlElement xmlElement = UiUtilities.CloneTemplate(base.xmlLayout.GetElementById("camera-part-template"), _cameraPartsPanel);
				xmlElement.gameObject.SetActive(cameraMode.CameraController.Enabled);
				xmlElement.GetElementByInternalId("text").SetText(cameraMode.Name);
				_buttomMap[xmlElement] = cameraMode;
				UpdateCustomCameraDropdownVisibility();
			}
		}

		private void OnCustomCameraModeRemoved(CameraMode cameraMode)
		{
			if (_buttomMap.Count > 0)
			{
				KeyValuePair<XmlElement, CameraMode>? cameraEntry = GetCameraEntry(cameraMode);
				if (cameraEntry.HasValue)
				{
					UnityEngine.Object.Destroy(cameraEntry.Value.Key.gameObject);
					_buttomMap.Remove(cameraEntry.Value.Key);
				}
				UpdateCustomCameraDropdownVisibility();
			}
		}

		private void OnDestroy()
		{
			_buttomMap.Clear();
		}

		private void OnEndFlightButtonClicked()
		{
			_flightSceneUi.FlightScene.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			base.FlightSceneUiController.OnExitButtonClicked();
		}

		private void OnHideCompletedContractsButtonClicked()
		{
			_contractsPanel.HideCompleteContracts();
		}

		private void OnMapViewButtonClicked()
		{
			Game.Instance.FlightScene.ViewManager.ToggleMapView();
		}

		private void OnRecenterButtonClicked()
		{
			HasSeenRecenterTooltip = true;
			_recenterHint.SetActive(active: false);
			if (_gameView.RenderView)
			{
				_gameView.GameCamera.Recenter();
				_gameView.CameraControllerManager.CurrentCameraController.Recenter();
			}
			else
			{
				_mapView.MapCameraScript.RecenterOnTarget();
			}
		}

		private void OnRequirementClicked(XmlElement element)
		{
			_contractsPanel.OnRequirementClicked(element);
		}

		private void OnSearchButtonClicked(XmlElement button)
		{
			_mapView.MapViewUi.SearchPanel.OnSearchButtonClicked(button);
		}

		private void OnToggleCameraPanelButtonClicked(XmlElement element)
		{
			if (_cameraPanel.Visible)
			{
				_cameraPanel.Hide();
				_cameraPartsPanel.Hide();
				return;
			}
			_cameraPanel.Show();
			if (_contractsPanel != null)
			{
				_contractsPanel.Visible = false;
			}
		}

		private void OnToggleCameraPartsPanelButtonClicked(XmlElement element)
		{
			if (_cameraPartsPanel.Visible)
			{
				_cameraPartsPanel.Hide();
			}
			else
			{
				_cameraPartsPanel.Show();
			}
		}

		private void OnToggleMenuButtonClicked()
		{
			base.FlightSceneUiController.ToggleMenu();
		}

		private void OnViewManagerViewChanged(object sender, EventArgs e)
		{
			ToggleViewSpecificElements();
		}

		private void SelectButton(XmlElement button, bool select)
		{
			if (select)
			{
				if (!button.HasClass("selected"))
				{
					button.AddClass("selected");
				}
			}
			else if (button.HasClass("selected"))
			{
				button.RemoveClass("selected");
			}
		}

		private void ToggleViewSpecificElements()
		{
			bool flag = !_gameView.RenderView;
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("map-view-only"))
			{
				item.SetActive(flag);
			}
			foreach (XmlElement item2 in base.xmlLayout.GetElementsByClass("game-view-only"))
			{
				item2.SetActive(!flag);
			}
			_recenterHint.SetActive(active: false);
			if (flag)
			{
				_cameraPartsPanel.Hide();
				_cameraPanel.Hide();
			}
			else
			{
				_gameView.CameraControllerManager.SelectCameraMode(null);
			}
		}

		private void UpdateCustomCameraDropdownVisibility()
		{
			bool flag = false;
			foreach (KeyValuePair<XmlElement, CameraMode> item in _buttomMap)
			{
				if (item.Value != null)
				{
					CameraController cameraController = item.Value.CameraController;
					if (cameraController.IsCustom && cameraController.Enabled)
					{
						flag = true;
					}
				}
			}
			base.xmlLayout.GetElementById("no-camera-parts-text").SetActive(!flag);
		}
	}
}
