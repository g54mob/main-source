using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval
{
	public sealed class RtsCameraInputListener : InputListener
	{
		private const float MousePanningDistanceThreshold = 0.02f;

		private const float MousePanningDistanceDraftedThreshold = 0.06f;

		private string mouseXAxis;

		private string mouseYAxis;

		private string mouseZoomAxis;

		private KeyCode panKey;

		private KeyCode mouseOrbitKey;

		private KeyCode mouseAltOrbitKey;

		private bool mouseOrbiting;

		private bool mousePanning;

		private Vector3 panningStartPos = Vector3.zero;

		public bool StopEventPropagation { get; set; }

		public RtsCameraInputListener()
			: base(InputListenerType.Camera)
		{
			UpdateKeys();
			DefaultPlayerControls data = Repository<DefaultPlayerControlsData, DefaultPlayerControls>.Instance.GetData<DefaultPlayerControls>();
			mouseXAxis = data.MouseXAxis;
			mouseYAxis = data.MouseYAxis;
			mouseZoomAxis = data.MouseZoomAxis;
			panKey = data.CameraPanKey;
			MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(panKey);
			MonoSingleton<SceneController>.Instance.UnscaledTick += UpdateCameraTick;
			MonoSingleton<SettingsController>.Instance.KeybindingsSavedEvent += UpdateKeys;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.UnscaledTick -= UpdateCameraTick;
			}
			if (MonoSingleton<SettingsController>.IsInstantiated())
			{
				MonoSingleton<SettingsController>.Instance.KeybindingsSavedEvent -= UpdateKeys;
			}
		}

		public override bool IsStopEventPropagation()
		{
			if (MonoSingleton<CameraManager>.IsInstantiated())
			{
				return false;
			}
			CameraType selectedCameraType = MonoSingleton<CameraManager>.Instance.SelectedCameraType;
			if (selectedCameraType != CameraType.Gameplay)
			{
				return selectedCameraType != CameraType.WorldMapMode;
			}
			return false;
		}

		public override void KeyDown(KeyCode key)
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				UpdateMovementVector();
				MonoSingleton<RtsCamera>.Instance.FastCameraMove = MonoSingleton<RtsCamera>.Instance.FastCameraMove || MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.RtsFastMove, key);
				if (key == panKey)
				{
					SetMousePanning(value: true);
				}
				else if (key == mouseOrbitKey || key == mouseAltOrbitKey)
				{
					mouseOrbiting = true;
				}
				else if (key == MonoSingleton<KeybindingManager>.Instance.Keybindings[KeyInputEvent.CameraReset].PrimaryKey || key == MonoSingleton<KeybindingManager>.Instance.Keybindings[KeyInputEvent.CameraReset].AlternativeKey)
				{
					MonoSingleton<RtsCamera>.Instance.OnCameraReset();
				}
			}
		}

		public override void KeyDownTick(KeyCode key)
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.ZoomIn, key))
				{
					num3 = 0.01f;
				}
				else if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.ZoomOut, key))
				{
					num3 = -0.01f;
				}
				if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MapRotateLeft, key))
				{
					num = -1f;
				}
				else if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MapRotateRight, key))
				{
					num = 1f;
				}
				if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.TiltDown, key))
				{
					num2 = -1f;
				}
				else if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.TiltUp, key))
				{
					num2 = 1f;
				}
				MonoSingleton<RtsCamera>.Instance.SetDesiredRotation(MonoSingleton<RtsCamera>.Instance.DesiredRotation + num / (float)Screen.width * MonoSingleton<RtsCamera>.Instance.Settings.MouseRotateSpeed);
				MonoSingleton<RtsCamera>.Instance.SetDesiredHeight(MonoSingleton<RtsCamera>.Instance.DesiredHeight - num3 * MonoSingleton<RtsCamera>.Instance.Settings.MouseZoomSpeed * MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraSensitivity);
				MonoSingleton<RtsCamera>.Instance.UpdateTilt((0f - num2 / (float)Screen.width) * MonoSingleton<RtsCamera>.Instance.Settings.MouseTiltSpeed);
			}
		}

		public override void KeyUp(KeyCode key)
		{
			if (!MonoSingleton<RtsCamera>.IsInstantiated() || !MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				return;
			}
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				MonoSingleton<RtsCamera>.Instance.SetMovementAxis(Vector2.zero);
				return;
			}
			UpdateMovementVector();
			MonoSingleton<RtsCamera>.Instance.FastCameraMove &= !MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.RtsFastMove, key);
			if (key == panKey)
			{
				SetMousePanning(value: false);
			}
			else if (key == mouseOrbitKey || key == mouseAltOrbitKey)
			{
				mouseOrbiting = false;
			}
		}

		public override void Disable()
		{
			mouseOrbiting = (mousePanning = false);
			MonoSingleton<RtsCamera>.Instance.SetDesiredRotation(MonoSingleton<RtsCamera>.Instance.CurrentRotation);
			MonoSingleton<RtsCamera>.Instance.UpdateTilt(0f);
			MonoSingleton<RtsCamera>.Instance.AddToPosition(0f, 0f, 0f);
			base.Disable();
		}

		public void UpdateCameraTick(float delta)
		{
			if (!MonoSingleton<UIController>.Instance.GameStarted || MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible || !base.IsEnabled || !MonoSingleton<RtsCamera>.IsInstantiated() || MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				return;
			}
			if (MonoSingleton<InputManager>.IsInstantiated() && MonoSingleton<InputManager>.Instance.isActiveAndEnabled && !Input.GetKey(KeyCode.LeftShift))
			{
				float axisRaw = Input.GetAxisRaw(mouseZoomAxis);
				if (!Mathf.Approximately(axisRaw, 0f) && !GuiInputListener.IsMouseOverGui())
				{
					MonoSingleton<RtsCamera>.Instance.SetDesiredHeight(MonoSingleton<RtsCamera>.Instance.DesiredHeight - axisRaw * MonoSingleton<RtsCamera>.Instance.Settings.MouseZoomSpeed * MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraSensitivity);
				}
			}
			if (mouseOrbiting)
			{
				MonoSingleton<RtsCamera>.Instance.SetDesiredRotation(MonoSingleton<RtsCamera>.Instance.DesiredRotation + Input.GetAxisRaw(mouseXAxis) / (float)Screen.width * MonoSingleton<RtsCamera>.Instance.Settings.MouseRotateSpeed);
				MonoSingleton<RtsCamera>.Instance.UpdateTilt((0f - Input.GetAxisRaw(mouseYAxis) / (float)Screen.width) * MonoSingleton<RtsCamera>.Instance.Settings.MouseTiltSpeed);
				return;
			}
			if (mousePanning)
			{
				float dx = Input.GetAxisRaw(mouseXAxis) / (float)Screen.width * MonoSingleton<RtsCamera>.Instance.Settings.MousePanSpeed * MonoSingleton<RtsCamera>.Instance.MovementCorrection;
				float dz = Input.GetAxisRaw(mouseYAxis) / (float)Screen.width * MonoSingleton<RtsCamera>.Instance.Settings.MousePanSpeed * MonoSingleton<RtsCamera>.Instance.MovementCorrection;
				if (panningStartPos != Vector3.positiveInfinity)
				{
					if (Vector3.Distance(InputUtils.GetPosScaled(Input.mousePosition), panningStartPos) > GetMousePanningThreshold())
					{
						panningStartPos = Vector3.positiveInfinity;
						MonoSingleton<RtsCamera>.Instance.AddToPosition(dx, 0f, dz);
					}
				}
				else
				{
					MonoSingleton<RtsCamera>.Instance.AddToPosition(dx, 0f, dz);
				}
			}
			if (MonoSingleton<RtsCamera>.Instance.LockedToLayer)
			{
				if ((Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Mouse ScrollWheel") < 0f) || MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyPressed(KeyInputEvent.LockCameraToLayerUp))
				{
					MonoSingleton<RtsCamera>.Instance.OnLockedLayerUpEvent();
				}
				else if ((Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Mouse ScrollWheel") > 0f) || MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyPressed(KeyInputEvent.LockCameraToLayerDown))
				{
					MonoSingleton<RtsCamera>.Instance.OnLockedLayerDownEvent();
				}
			}
		}

		private void UpdateKeys()
		{
			KeyCode keyCode = MonoSingleton<GlobalSaveController>.Instance.GetKeyCode(KeyInputEvent.MouseOrbit);
			if (mouseOrbitKey != keyCode)
			{
				MonoSingleton<InputManager>.Instance.UnregisterKeycodeFromListening(mouseOrbitKey);
				mouseOrbitKey = keyCode;
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(mouseOrbitKey);
			}
			KeyCode alternativeKey = MonoSingleton<KeybindingManager>.Instance.Keybindings[KeyInputEvent.MouseOrbit].AlternativeKey;
			if (mouseAltOrbitKey != alternativeKey)
			{
				MonoSingleton<InputManager>.Instance.UnregisterKeycodeFromListening(mouseAltOrbitKey);
				mouseAltOrbitKey = alternativeKey;
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(mouseAltOrbitKey);
			}
		}

		private static float GetMousePanningThreshold()
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject item) => item is WorkerView { HumanoidInstance: not null } workerView && workerView.HumanoidInstance.WorkerBehaviour.IsDrafting))
			{
				return 0.06f;
			}
			return 0.02f;
		}

		private void UpdateMovementVector()
		{
			RtsCamera instance = MonoSingleton<RtsCamera>.Instance;
			Vector3 movementAxis = instance.MovementAxis;
			movementAxis.z = 0f;
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MoveUp))
			{
				movementAxis.z += 1f;
			}
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MoveDown))
			{
				movementAxis.z -= 1f;
			}
			movementAxis.x = 0f;
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MoveLeft))
			{
				movementAxis.x -= 1f;
			}
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.MoveRight))
			{
				movementAxis.x += 1f;
			}
			if (movementAxis != Vector3.zero)
			{
				MonoSingleton<RtsCamera>.Instance.CancelFollow();
			}
			instance.SetMovementAxis(movementAxis);
		}

		private void SetMousePanning(bool value)
		{
			bool flag = mousePanning;
			mousePanning = value;
			if (value != flag)
			{
				panningStartPos = InputUtils.GetPosScaled(Input.mousePosition);
			}
		}
	}
}
