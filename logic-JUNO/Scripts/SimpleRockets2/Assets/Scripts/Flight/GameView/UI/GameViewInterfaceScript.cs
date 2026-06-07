using System.Collections.Generic;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.GameView.UI.Inspector;
using Assets.Scripts.Flight.UI;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using ModApi.Input.Events;
using ModApi.Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.GameView.UI
{
	public class GameViewInterfaceScript : MonoBehaviour, IGameViewPointerEventHandler
	{
		private IGameViewPointerEventHandler _capturedHandler;

		private IPartScript _capturedPart;

		private IGameViewPointerEventHandler _capturedPartHandler;

		private Vector2 _drag;

		private float _dragStartTime;

		private List<GameViewPointerEvent> _frameEvents = new List<GameViewPointerEvent>();

		private GameViewScript _gameView;

		private InputResponder _inputResponder = new InputResponder("GameViewInterfaceScript");

		private MouseInputSettingsFlight _mouseInputSettings;

		private bool _pointerDown;

		public bool EnablePseudoDragging { get; set; }

		public GameViewInspectorScript GameViewInspector { get; private set; }

		public InputResponder InputResponder => _inputResponder;

		public IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent)
		{
			if (pointerEvent.EventType == GameViewPointerEventType.PointerDown)
			{
				_pointerDown = true;
			}
			else if (pointerEvent.EventType == GameViewPointerEventType.PointerUp || pointerEvent.EventType == GameViewPointerEventType.PointerClick)
			{
				_pointerDown = false;
			}
			if (_capturedPart == null)
			{
				_capturedPart = _gameView.FindPartAtScreenPosition(pointerEvent.EventData.position);
			}
			_capturedPartHandler = _capturedPart?.HandleGameViewPointerEvent(pointerEvent);
			IGameViewPointerEventHandler result = null;
			if (_capturedPartHandler == null)
			{
				if (_capturedPart != null)
				{
					_capturedPart = null;
				}
				if (!pointerEvent.Handled)
				{
					if (pointerEvent.EventType == GameViewPointerEventType.PointerClick)
					{
						IPartScript partScript = _gameView.FindPartAtScreenPosition(pointerEvent.EventData.position);
						if (pointerEvent.IsTouchPrimary || _mouseInputSettings.CanSelectPart(pointerEvent.InputButton))
						{
							if (_gameView.CameraControllerManager.CurrentCameraController.AllowPartSelection)
							{
								_gameView.SelectedPart = ((_gameView.SelectedPart == partScript) ? null : partScript);
							}
							else if (Device.IsMobileBuild)
							{
								partScript?.ToggleActivationState();
							}
						}
						else if (_mouseInputSettings.CanActivatePart(pointerEvent.InputButton))
						{
							partScript?.ToggleActivationState();
						}
						else if (_mouseInputSettings.CanFocusCameraOnPart(pointerEvent.InputButton) && partScript != null)
						{
							_gameView.GameCamera.Recenter();
							Transform transform = partScript.Transform;
							partScript.CraftScript.CameraFocus = ((transform == partScript.CraftScript.CameraFocus) ? null : transform);
						}
					}
					else if (pointerEvent.EventType == GameViewPointerEventType.PointerDown)
					{
						_drag = Vector2.zero;
						_dragStartTime = Time.unscaledTime;
						if (EnablePseudoDragging)
						{
							result = this;
						}
					}
					else if (pointerEvent.EventType == GameViewPointerEventType.Drag)
					{
						_drag += pointerEvent.EventData.delta;
						_gameView.DragCamera(pointerEvent.InputButton, pointerEvent.IsTouchPrimary, pointerEvent.EventData.delta);
						if (EnablePseudoDragging)
						{
							result = this;
						}
					}
					else if (pointerEvent.EventType == GameViewPointerEventType.PointerUp)
					{
						_drag = Vector2.zero;
						_dragStartTime = Time.unscaledTime;
						result = null;
					}
				}
			}
			else
			{
				result = this;
			}
			return result;
		}

		protected virtual void Awake()
		{
			_inputResponder.IsResponding = () => base.gameObject.activeInHierarchy;
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnPointerClick = OnPointerClick;
			_inputResponder.OnPointerDown = OnPointerDown;
			_inputResponder.OnPointerUp = OnPointerUp;
			_inputResponder.OnPinch = OnPinch;
			_inputResponder.OnScroll = OnScroll;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
			Game.Instance.FlightScene.Initialized += OnFlightSceneInitialized;
		}

		protected virtual void LateUpdate()
		{
			if (_frameEvents.Count > 0)
			{
				foreach (GameViewPointerEvent frameEvent in _frameEvents)
				{
					if (_capturedHandler != null)
					{
						_capturedHandler = _capturedHandler.HandleGameViewPointerEvent(frameEvent);
					}
					else
					{
						_capturedHandler = HandleGameViewPointerEvent(frameEvent);
					}
					if (_capturedHandler != null && _capturedPartHandler != null)
					{
						Game.Instance.FlightScene.FlightSceneUI.OverrideInputResponderCapture(_inputResponder);
						break;
					}
				}
				_frameEvents.Clear();
			}
			else if (EnablePseudoDragging && _pointerDown)
			{
				PointerEventData eventData = new PointerEventData(EventSystem.current);
				GameViewPointerEvent gameViewPointerEvent = new GameViewPointerEvent(GameViewPointerEventType.Drag, eventData);
				gameViewPointerEvent.EventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
				_capturedHandler = HandleGameViewPointerEvent(gameViewPointerEvent);
			}
		}

		protected virtual void Start()
		{
			_gameView = FlightSceneScript.Instance.ViewManager.GameView;
			GameViewInspector = GameViewInspectorScript.Create();
			GameViewInspector.Visible = Game.Instance.Settings.Game.Flight.ShowFlightViewInspector.Value;
		}

		private void OnCameraModeChanged(CameraMode newMode, CameraMode oldMode)
		{
			if (!Device.IsMobileBuild && newMode.CameraController is FirstPersonCameraController firstPersonCameraController)
			{
				EnablePseudoDragging = firstPersonCameraController.MouseLook;
			}
			Game.Instance.FlightScene.FlightSceneUI.NavSphereHeadingVisible = newMode.Name != "2D View";
		}

		private bool OnDrag(PointerEventData eventData)
		{
			_frameEvents.Add(new GameViewPointerEvent(GameViewPointerEventType.Drag, eventData));
			return true;
		}

		private void OnFlightSceneInitialized(IFlightScene initializedObject)
		{
			_gameView.CameraControllerManager.CameraModeChanged += OnCameraModeChanged;
		}

		private bool OnPinch(PinchEventData eventData)
		{
			if (eventData.Distance > 0f)
			{
				float zoomPercentage = (eventData.Distance - eventData.DistanceDelta) / eventData.Distance;
				_gameView.GameCamera.Zoom(zoomPercentage);
			}
			return true;
		}

		private bool OnPointerClick(PointerEventData eventData)
		{
			if (Time.unscaledTime - _dragStartTime < 0.5f && _drag.magnitude < 20f)
			{
				_frameEvents.Add(new GameViewPointerEvent(GameViewPointerEventType.PointerClick, eventData));
			}
			return true;
		}

		private bool OnPointerDown(PointerEventData eventData)
		{
			_frameEvents.Add(new GameViewPointerEvent(GameViewPointerEventType.PointerDown, eventData));
			if (!Device.IsMobileBuild)
			{
				return !EnablePseudoDragging;
			}
			return EnablePseudoDragging;
		}

		private bool OnPointerUp(PointerEventData eventData)
		{
			_frameEvents.Add(new GameViewPointerEvent(GameViewPointerEventType.PointerUp, eventData));
			return true;
		}

		private bool OnScroll(PointerEventData eventData)
		{
			if (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom)
			{
				Vector2 vector = eventData.scrollDelta;
				if (Device.IsOsxRuntime)
				{
					vector = new Vector2(Mathf.Clamp(vector.x / 2f, -8f, 8f), Mathf.Clamp(vector.y / 2f, -8f, 8f));
				}
				if (vector.x != 0f)
				{
					bool inverted = false;
					CameraController currentCameraController = _gameView.CameraControllerManager.CurrentCameraController;
					if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float zoomPercentage = 1f - vector.x * 0.1f;
						_gameView.GameCamera.Zoom(zoomPercentage);
					}
					else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float num = 30f * (float)((!inverted) ? 1 : (-1));
						currentCameraController.Rotate(new Vector2(vector.x * num, 0f));
					}
					else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float num2 = 20f * (float)(inverted ? 1 : (-1));
						currentCameraController.Pan(new Vector2((0f - vector.x) * num2, 0f));
					}
					else if (_mouseInputSettings.CanSpinForwardAxis(InputAxis.ScrollHorizontal, out inverted))
					{
						float num3 = 15f * (float)((!inverted) ? 1 : (-1));
						currentCameraController.Tilt(vector.x * num3);
					}
				}
				if (vector.y != 0f)
				{
					bool inverted2 = false;
					CameraController currentCameraController2 = _gameView.CameraControllerManager.CurrentCameraController;
					if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollVertical, out inverted2))
					{
						float zoomPercentage2 = 1f - vector.y * 0.05f;
						_gameView.GameCamera.Zoom(zoomPercentage2);
					}
					else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollVertical, out inverted2))
					{
						float num4 = 15f * (float)((!inverted2) ? 1 : (-1));
						currentCameraController2.Rotate(new Vector2(0f, vector.y * num4));
					}
					else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollVertical, out inverted2))
					{
						float num5 = 20f * (float)(inverted2 ? 1 : (-1));
						currentCameraController2.Pan(new Vector2(0f, (0f - vector.y) * num5));
					}
					else if (_mouseInputSettings.CanSpinForwardAxis(InputAxis.ScrollVertical, out inverted2))
					{
						float num6 = 15f * (float)((!inverted2) ? 1 : (-1));
						currentCameraController2.Tilt(vector.y * num6);
					}
				}
			}
			return false;
		}
	}
}
