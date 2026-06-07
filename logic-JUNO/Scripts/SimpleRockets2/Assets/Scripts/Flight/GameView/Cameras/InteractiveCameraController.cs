using Assets.Scripts.Flight.GameView.UI;
using Assets.Scripts.Input;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight;
using ModApi.Flight.UI;
using ModApi.Input;
using ModApi.Math;
using ModApi.Settings;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public abstract class InteractiveCameraController : CameraController
	{
		public const float MaxZoomDistance = 2250000f;

		public const float MinZoomDistance = 1.5f;

		private Vector2 _deltaRotation;

		private FlightSettings _flightSettings;

		private GameViewInterfaceScript _gameViewInterface;

		private Mouse _mouse;

		private MouseInputSettingsFlight _mouseInputSettings;

		private bool _mouseLook;

		private ITimeManager _timeManager;

		public Vector2? ClampDeltaRotationRange { get; set; }

		public Vector2 DeltaRotation
		{
			get
			{
				return _deltaRotation;
			}
			set
			{
				if (ClampDeltaRotationRange.HasValue)
				{
					Vector2 value2 = ClampDeltaRotationRange.Value;
					_deltaRotation = new Vector2(Mathf.Clamp(value.x, 0f - value2.x, value2.x), Mathf.Clamp(value.y, 0f - value2.y, value2.y));
				}
				else
				{
					_deltaRotation = value;
				}
			}
		}

		public bool MouseLook
		{
			get
			{
				return _mouseLook;
			}
			set
			{
				_mouseLook = value;
				UpdateCursor();
			}
		}

		public float PanSensitivity { get; set; } = 1f;

		public bool ViewIsFocused
		{
			get
			{
				if (!Game.Instance.UserInterface.AnyDialogsOpen && Game.Instance.FlightScene.ViewManager.MapViewManager != null && !Game.Instance.FlightScene.ViewManager.MapViewManager.IsInForeground)
				{
					return !_timeManager.Paused;
				}
				return false;
			}
		}

		protected float CameraLookLeftRightAxis { get; set; }

		protected float CameraLookUpDownAxis { get; set; }

		protected float CameraLookZoomAxis { get; set; }

		protected float CameraRotationOffset { get; private set; }

		protected bool CameraUpDownZoomSwapped { get; private set; }

		protected bool Pinching { get; private set; }

		protected float TargetDistance { get; set; } = -20f;

		protected Vector3 TargetPositionOffset { get; set; }

		protected bool Touching { get; private set; }

		public InteractiveCameraController(CameraManagerScript cameraManager)
			: base(cameraManager)
		{
			_mouse = InputWrapper.Player.controllers.Mouse;
			_timeManager = Game.Instance.FlightScene.TimeManager;
			Game.Instance.FlightScene.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
			Game.Instance.UserInterface.AnyDialogsOpenChanged += OnAnyDialogsOpenChanged;
			Game.Instance.FlightScene.Initialized += delegate
			{
				Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged += OnMapViewForegroundStateChanged;
				_gameViewInterface = (Game.Instance.FlightScene.ViewManager.GameView as GameViewScript).GameViewInterface;
			};
			_flightSettings = Game.Instance.Settings.Game.Flight;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
		}

		public void Move(Vector2 direction)
		{
			float num = 0.05f;
			Vector3 vector = base.CameraTransform.right * direction.x * num + base.CameraTransform.up * direction.y * num;
			TargetPositionOffset += vector;
		}

		public override void OnApplicaitionFocus(bool focus)
		{
			base.OnApplicaitionFocus(focus);
			UpdateCursor();
		}

		public override bool OnBeginPinch(PinchEventData eventData)
		{
			Pinching = true;
			return true;
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
			CameraUpDownZoomSwapped = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (Game.Instance?.UserInterface != null)
			{
				Game.Instance.UserInterface.AnyDialogsOpenChanged -= OnAnyDialogsOpenChanged;
			}
			if (Game.Instance?.FlightScene?.TimeManager != null)
			{
				Game.Instance.FlightScene.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
			}
			if (Game.Instance?.FlightScene?.ViewManager?.MapViewManager != null)
			{
				Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged -= OnMapViewForegroundStateChanged;
			}
		}

		public override bool OnDrag(PointerEventData eventData)
		{
			if (!MouseLook)
			{
				bool inverted = false;
				if (eventData.IsTouchPrimary() || _mouseInputSettings.CanRotateCamera(eventData.InputButton(), out inverted))
				{
					Vector2 vector = eventData.delta / Game.Instance.Device.Dpi;
					if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
					{
						vector *= 160f;
					}
					else
					{
						vector *= 80f;
					}
					Rotate(new Vector2(0f - vector.y, vector.x) * ((!inverted) ? 1 : (-1)), additiveRotation: true);
				}
				else if (_mouseInputSettings.CanPanCamera(eventData.InputButton(), out inverted) && Game.Instance.FlightScene.TimeManager.Paused)
				{
					if (UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift))
					{
						CameraRotationOffset += eventData.delta.x;
					}
					else
					{
						Move(new Vector2(0f - eventData.delta.x, 0f - eventData.delta.y) * ((!inverted) ? 1 : (-1)));
					}
				}
			}
			return true;
		}

		public override bool OnEndPinch(PinchEventData eventData)
		{
			Pinching = false;
			return false;
		}

		public override bool OnPinch(PinchEventData eventData)
		{
			float num = eventData.DistanceDelta / Game.Instance.Device.Dpi;
			Zoom(num * 12f);
			return true;
		}

		public override bool OnPointerDown(PointerEventData eventData)
		{
			Touching = true;
			return false;
		}

		public override bool OnPointerUp(PointerEventData eventData)
		{
			Touching = false;
			return false;
		}

		public override void OnSelected(int subMode)
		{
			base.OnSelected(subMode);
			UpdateCursor();
		}

		public virtual void Rotate(Vector2 rotation, bool additiveRotation)
		{
			if (additiveRotation)
			{
				DeltaRotation += rotation * 0.4f * PanSensitivity;
				DeltaRotation = new Vector2(Mathf.Clamp(DeltaRotation.x, -89f, 89f), DeltaRotation.y);
			}
			else
			{
				DeltaRotation = rotation;
			}
		}

		public void SetZoom(float zoom)
		{
			TargetDistance = zoom;
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			if (!Game.Instance.FlightScene.TimeManager.Paused && MouseLook && _gameViewInterface.EnablePseudoDragging)
			{
				DeltaRotation += GetMouseLookDelta(1f) * PanSensitivity;
			}
			if (frameCount == 1 && !Game.Instance.UserInterface.AnyDialogsOpen)
			{
				UpdateInputs();
				Vector2 vector = InputRotationMultiplier();
				Vector2 rotation = new Vector2(CameraLookUpDownAxis * vector.x, CameraLookLeftRightAxis * vector.y);
				if (rotation.x != 0f || rotation.y != 0f)
				{
					Rotate(rotation, InputRotationIsAdditives());
				}
				if (CameraLookZoomAxis != 0f)
				{
					float zoomPercentage = 1f - CameraLookZoomAxis * 0.05f;
					Zoom(zoomPercentage);
				}
			}
			if (TargetDistance < 1.5f)
			{
				TargetDistance = 1.5f;
			}
			else if (TargetDistance > 2250000f)
			{
				TargetDistance = 2250000f;
			}
			if (base.CameraManager.SharedCameraDistance < 1.5f)
			{
				base.CameraManager.SharedCameraDistance = 1.5f;
			}
		}

		public override void Zoom(float zoomPercentage)
		{
			TargetDistance *= zoomPercentage;
			TargetDistance = Mathf.Clamp(TargetDistance, 1.5f, 2250000f);
		}

		protected virtual float GetCameraLookLeftRightAxis(float lookLeftRightAxis, float lookBackAxis)
		{
			if (lookLeftRightAxis == 0f)
			{
				return lookBackAxis;
			}
			return lookLeftRightAxis;
		}

		protected virtual bool InputRotationIsAdditives()
		{
			return true;
		}

		protected virtual Vector2 InputRotationMultiplier()
		{
			return new Vector2(360f, -360f) * Time.unscaledDeltaTime;
		}

		protected virtual void UpdateInputs()
		{
			IGameInputs inputs = Game.Instance.Inputs;
			if (inputs.CameraSwapUpDownZoom.GetButtonDownIfEnabled())
			{
				CameraUpDownZoomSwapped = !CameraUpDownZoomSwapped;
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Camera look up/down and zoom swapped.");
				}
			}
			float axisIfEnabled = inputs.CameraLookLeftRight.GetAxisIfEnabled();
			float cameraLookUpDownAxis = (CameraUpDownZoomSwapped ? inputs.CameraLookZoom.GetAxisIfEnabled() : inputs.CameraLookUpDown.GetAxisIfEnabled());
			float num = (CameraUpDownZoomSwapped ? inputs.CameraLookUpDown.GetAxisIfEnabled() : inputs.CameraLookZoom.GetAxisIfEnabled());
			int num2 = 0;
			CameraLookUpDownAxis = cameraLookUpDownAxis;
			CameraLookLeftRightAxis = GetCameraLookLeftRightAxis(axisIfEnabled, num2);
			if (num != 0f && (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom) && Device.IsOsxRuntime)
			{
				num = Mathf.Clamp(num / 2f, -8f, 8f);
			}
			CameraLookZoomAxis = num * 0.5f;
		}

		private Vector2 GetMouseLookDelta(float smoothingAmount)
		{
			Vector2 vector = new Vector2(0f - _mouse.GetAxis(1), _mouse.GetAxis(0)) * _flightSettings.CameraSensitivityFps;
			smoothingAmount *= (float)_flightSettings.CameraSmoothingFps;
			if (smoothingAmount > 0.0022727272f)
			{
				float val = Utilities.Max(Utilities.Abs(vector));
				float num = Mathf.Lerp(0.1f, 1f, MathUtils.PercentBetween(val, 0.05f, 22f * smoothingAmount));
				vector *= num;
			}
			return vector;
		}

		private void OnAnyDialogsOpenChanged(bool anyDialogsOpen)
		{
			UpdateCursor();
		}

		private void OnMapViewForegroundStateChanged(bool foreground)
		{
			UpdateCursor();
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			UpdateCursor();
		}

		private void UpdateCursor()
		{
			if (base.IsSelected)
			{
				if (MouseLook && ViewIsFocused)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			}
		}
	}
}
