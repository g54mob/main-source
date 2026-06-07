using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.UI;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using UI.Xml;

namespace Assets.Scripts.Flight.UI
{
	public class NavPanelController : FlightPanelController
	{
		private const string SelectedClass = "panel-button-icon-toggled";

		private XmlElement _analogSticksButton;

		private XmlElement _flightInspectorButton;

		private XmlElement _flightLogButton;

		private IFlightSceneUI _flightSceneUi;

		private IGameView _gameView;

		private GameViewInterfaceScript _gameViewInterface;

		private XmlElement _lockHeadingButton;

		private Dictionary<NavSphereIndicatorType, XmlElement> _lockVectorButtons = new Dictionary<NavSphereIndicatorType, XmlElement>();

		private INavSphere _navSphere;

		private XmlElement _translationButton;

		private XmlElement _visibleButton;

		public override void CraftNodeChanged(CraftNode craftNode)
		{
		}

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
			_flightSceneUi = FlightSceneScript.Instance.FlightSceneUI;
			_gameView = Game.Instance.FlightScene.ViewManager.GameView;
			_navSphere = _flightSceneUi.NavSphere;
		}

		public bool IsFlightInspectorVisible()
		{
			if (_gameView.RenderView)
			{
				return _gameViewInterface.GameViewInspector.Visible;
			}
			return (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).MapViewUi.MapViewInspector.Visible;
		}

		public bool IsFlightLogVisible()
		{
			return _flightSceneUi.FlightLogUI.Visible;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_lockHeadingButton = base.xmlLayout.GetElementById("nav-sphere-lock");
			_visibleButton = base.xmlLayout.GetElementById("nav-sphere-visible");
			_translationButton = base.xmlLayout.GetElementById("nav-sphere-translation");
			_flightInspectorButton = base.xmlLayout.GetElementById("toggle-flight-inspector");
			_flightLogButton = base.xmlLayout.GetElementById("toggle-flight-log");
			_analogSticksButton = base.xmlLayout.GetElementById("toggle-analog-sticks");
			_lockVectorButtons.Clear();
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("panel-button"))
			{
				if (!item.name.StartsWith("NavSpherePanel.Lock"))
				{
					continue;
				}
				if (Enum.TryParse<NavSphereIndicatorType>(item.name.Substring(19), out var type))
				{
					_lockVectorButtons.Add(type, item);
					item.AddOnClickEvent(delegate
					{
						_navSphere.ToggleLock(type);
					}, clearExisting: true);
				}
			}
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			if (craftNode == null)
			{
				return;
			}
			foreach (KeyValuePair<NavSphereIndicatorType, XmlElement> lockVectorButton in _lockVectorButtons)
			{
				if (_navSphere.GetVector(lockVectorButton.Key).HasValue)
				{
					UpdateButton(lockVectorButton.Value, lockVectorButton.Key == _navSphere.LockedIndicator);
					if (!lockVectorButton.Value.Visible)
					{
						lockVectorButton.Value.Show();
					}
				}
				else if (lockVectorButton.Value.Visible)
				{
					lockVectorButton.Value.Hide();
				}
			}
			UpdateButton(_lockHeadingButton, _navSphere.HeadingLocked && !_navSphere.LockedIndicator.HasValue);
			UpdateButton(_flightInspectorButton, IsFlightInspectorVisible());
			UpdateButton(_flightLogButton, IsFlightLogVisible());
			UpdateButton(_translationButton, craftNode.Controls.TranslationModeEnabled);
			UpdateButton(_visibleButton, FlightSceneScript.Instance.FlightSceneUI.NavSphereVisible);
			if (_analogSticksButton != null)
			{
				bool flag = base.FlightSceneUiController.AnalogControlsVisible;
				if (!_gameView.RenderView && flag)
				{
					flag = false;
					base.FlightSceneUiController.AnalogControlsVisible = false;
				}
				UpdateButton(_analogSticksButton, flag);
			}
		}

		private void OnLockHeadingClicked()
		{
			if (_navSphere.HeadingLocked && !_navSphere.LockedIndicator.HasValue)
			{
				_navSphere.UnlockHeading();
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unlocked Current Heading");
			}
			else
			{
				_navSphere.LockCurrentHeading();
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Locked Current Heading");
			}
		}

		private void OnTargetClicked()
		{
			_navSphere.ToggleTargetLock();
		}

		private void OnToggleActivationPanelClicked(XmlElement toggle)
		{
			XmlElement elementById = base.FlightSceneUiController.xmlLayout.GetElementById("activation-panel");
			if (!toggle.HasClass("panel-button-icon-toggled"))
			{
				toggle.AddClass("panel-button-icon-toggled");
				elementById.Show();
			}
			else
			{
				toggle.RemoveClass("panel-button-icon-toggled");
				elementById.Hide();
			}
		}

		private void OnToggleAnalogSticks(XmlElement toggle)
		{
			base.FlightSceneUiController.AnalogControlsVisible = !base.FlightSceneUiController.AnalogControlsVisible;
		}

		private void OnToggleFlightInspectorClicked(XmlElement toggle)
		{
			if (_gameView.RenderView)
			{
				_gameViewInterface.GameViewInspector.Visible = !_gameViewInterface.GameViewInspector.Visible;
				return;
			}
			MapViewScript mapViewScript = Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript;
			mapViewScript.MapViewUi.MapViewInspector.Visible = !mapViewScript.MapViewUi.MapViewInspector.Visible;
		}

		private void OnToggleFlightLogClicked(XmlElement toggle)
		{
			_flightSceneUi.FlightLogUI.Visible = !_flightSceneUi.FlightLogUI.Visible;
		}

		private void OnToggleNavPanelClicked(XmlElement toggle)
		{
			XmlElement elementById = base.xmlLayout.GetElementById("nav-sphere-panel");
			if (!toggle.HasClass("panel-button-icon-toggled"))
			{
				toggle.AddClass("panel-button-icon-toggled");
				elementById.Show();
			}
			else
			{
				toggle.RemoveClass("panel-button-icon-toggled");
				elementById.Hide();
			}
		}

		private void OnTranslationClicked()
		{
			if (base.CraftNode != null)
			{
				base.CraftNode.Controls.ToggleTranslationMode();
			}
		}

		private void OnVisibleClicked()
		{
			_flightSceneUi.SetNavSphereVisibility(!_flightSceneUi.NavSphereVisible, updateSettings: true);
		}

		private void Start()
		{
			base.xmlLayout.GetElementById("nav-sphere-panel").SetActive(active: false);
			GameViewScript gameViewScript = _flightSceneUi.FlightScene.ViewManager.GameView as GameViewScript;
			_gameViewInterface = gameViewScript.GameViewInterface;
		}

		private void UpdateButton(XmlElement button, bool selected)
		{
			if (selected)
			{
				if (!button.HasClass("panel-button-icon-toggled"))
				{
					button.AddClass("panel-button-icon-toggled");
				}
			}
			else if (button.HasClass("panel-button-icon-toggled"))
			{
				button.RemoveClass("panel-button-icon-toggled");
			}
		}
	}
}
