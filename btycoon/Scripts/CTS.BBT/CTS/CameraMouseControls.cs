using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CTS
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(-30)]
	public class CameraMouseControls : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 0.4f)]
		private float _mousePadding = 0.1f;

		[SerializeField]
		private bool _onlyMoveIfInsideScreen;

		[SerializeField]
		private bool _screenBorderMove = true;

		[SerializeField]
		private float _deltaPanningModifier = 0.1f;

		[SerializeField]
		private float _deltaRotationModifier = 0.25f;

		[SerializeField]
		private float _deltaZoomModifier = 0.25f;

		[SerializeField]
		private float _rotationBuffer = 0.1f;

		[SerializeField]
		private bool _debug;

		private CameraRotation _cameraRotationRef;

		private CameraMovements _cameraPanningRef;

		private CameraZoom _cameraZoomRef;

		private bool _inputMousePan;

		private bool _inputMouseRotate;

		private float _mouseRotateTimeBuffer;

		private float _mouseDelta;

		private Vector2 _mouseDirection;

		private LockToggle _selectionToggle;

		private LockToggle _cursorToggle;

		private void Awake()
		{
			_cameraRotationRef = GetComponent<CameraRotation>();
			_cameraPanningRef = GetComponent<CameraMovements>();
			_cameraZoomRef = GetComponent<CameraZoom>();
			_selectionToggle = new LockToggle(CTSSingleton<WorldSelector>.Instance);
			_cursorToggle = new LockToggle(MonoSingleton<CursorManager>.Instance);
		}

		private void Update()
		{
			if (!_inputMouseRotate && !(MonoSingleton<CursorManager>.Instance.LastTimeSinceEnabled >= Time.unscaledTime))
			{
				CalculateMouseDirection();
				if (_mouseDirection.sqrMagnitude > 0.0001f)
				{
					_cameraPanningRef.MoveCameraInDirection(_mouseDirection);
				}
			}
		}

		private void OnEnable()
		{
			SubscribeInputs();
		}

		private void OnDisable()
		{
			UnsubscribeInputs();
			_selectionToggle.Unlock();
		}

		private void SubscribeInputs()
		{
			InputManager.game.cameraMousePan.onDown += OnInputMousePan;
			InputManager.game.cameraMousePan.onUp += OnInputMousePan;
			InputManager.game.cameraMouseRotation.onDown += OnInputMouseRotate;
			InputManager.game.cameraMouseRotation.onUp += OnInputMouseRotate;
			InputManager.game.cameraMouseZoom.onComplete += OnCameraZoom;
			InputManager.general.mouseDelta.onComplete += OnMouseDelta;
		}

		private void UnsubscribeInputs()
		{
			InputManager.game.cameraMousePan.onDown -= OnInputMousePan;
			InputManager.game.cameraMousePan.onUp -= OnInputMousePan;
			InputManager.game.cameraMouseRotation.onDown -= OnInputMouseRotate;
			InputManager.game.cameraMouseRotation.onUp -= OnInputMouseRotate;
			InputManager.game.cameraMouseZoom.onComplete -= OnCameraZoom;
			InputManager.general.mouseDelta.onComplete -= OnMouseDelta;
		}

		private void OnInputMousePan(InputAction.CallbackContext p_ctx)
		{
			_inputMousePan = p_ctx.ReadValue<float>() > 0.1f;
			RestoreSelection();
		}

		public void ParamsForThisScene(CameraMouseControlsStruct cameramousestruct)
		{
			if (cameramousestruct.IsNeedMouseClick)
			{
				base.enabled = true;
				_mousePadding = cameramousestruct._mousePadding;
				_onlyMoveIfInsideScreen = cameramousestruct._onlyMoveIfInsideScreen;
				_screenBorderMove = cameramousestruct._screenBorderMove;
				_deltaPanningModifier = cameramousestruct._deltaPanningModifier;
				_deltaRotationModifier = cameramousestruct._deltaRotationModifier;
				_deltaZoomModifier = cameramousestruct._deltaZoomModifier;
				_rotationBuffer = cameramousestruct._rotationBuffer;
			}
			else
			{
				base.enabled = false;
			}
		}

		public CameraMouseControlsStruct GetCameraMouseControlsStruct()
		{
			return new CameraMouseControlsStruct
			{
				IsNeedMouseClick = base.enabled,
				_deltaPanningModifier = _deltaPanningModifier,
				_deltaRotationModifier = _deltaRotationModifier,
				_deltaZoomModifier = _deltaZoomModifier,
				_mousePadding = _mousePadding,
				_screenBorderMove = _screenBorderMove,
				_onlyMoveIfInsideScreen = _onlyMoveIfInsideScreen,
				_rotationBuffer = _rotationBuffer
			};
		}

		private void OnInputMouseRotate(InputAction.CallbackContext p_ctx)
		{
			_inputMouseRotate = p_ctx.ReadValue<float>() > 0.1f;
			if (_inputMouseRotate)
			{
				MonoSingleton<CursorManager>.Instance.RegisterPosition();
			}
			else
			{
				MonoSingleton<CursorManager>.Instance.ResetOldPos();
			}
			_mouseRotateTimeBuffer = Time.unscaledTime + _rotationBuffer;
			RestoreSelection();
		}

		private void RestoreSelection()
		{
			if (!_inputMouseRotate && !_inputMousePan)
			{
				_selectionToggle.Unlock();
				_cursorToggle.Unlock();
			}
		}

		private void OnMouseDelta(InputAction.CallbackContext ctx)
		{
			Vector2 vector = ctx.ReadValue<Vector2>();
			if (_inputMousePan)
			{
				TryDisablingSelection();
				Vector3 p_worldDirection = Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f) * (vector * (0f - _deltaPanningModifier)).ToHorizontal3D();
				if (_cameraPanningRef.enabled)
				{
					_cameraPanningRef.Move(p_worldDirection);
				}
			}
			if (_inputMouseRotate)
			{
				if (Time.unscaledTime >= _mouseRotateTimeBuffer)
				{
					TryDisablingSelection();
				}
				if (_cameraRotationRef.enabled)
				{
					_cameraRotationRef.RotateByStrength(vector.x * _deltaRotationModifier);
				}
			}
			void TryDisablingSelection()
			{
				if (!InputManager.game.select.InProgress() && !InputManager.game.unselect.InProgress())
				{
					_selectionToggle.Lock();
					_cursorToggle.Lock();
				}
			}
		}

		private void OnCameraZoom(InputAction.CallbackContext ctx)
		{
			float num = ctx.ReadValue<float>() * 0.001f;
			_cameraZoomRef.AddTargetZoom(num * _deltaZoomModifier);
		}

		private void CalculateMouseDirection()
		{
			float num = (float)Screen.height * _mousePadding;
			Vector3 mousePosition = Input.mousePosition;
			if (!IsMouseInsideScreen(mousePosition) || EventSystem.current.IsPointerOverGameObject() || _inputMousePan || !Application.isFocused || !_screenBorderMove)
			{
				_mouseDirection = Vector2.zero;
				return;
			}
			if (mousePosition.x < num)
			{
				_mouseDirection.x = -1f;
			}
			else if (mousePosition.x > (float)Screen.width - num)
			{
				_mouseDirection.x = 1f;
			}
			else
			{
				_mouseDirection.x = 0f;
			}
			if (mousePosition.y < num)
			{
				_mouseDirection.y = -1f;
			}
			else if (mousePosition.y > (float)Screen.height - num)
			{
				_mouseDirection.y = 1f;
			}
			else
			{
				_mouseDirection.y = 0f;
			}
		}

		private bool IsMouseInsideScreen(Vector2 p_mousePos)
		{
			if (_onlyMoveIfInsideScreen)
			{
				if (p_mousePos.x >= 0f && p_mousePos.x <= (float)Screen.width && p_mousePos.y >= 0f)
				{
					return p_mousePos.y <= (float)Screen.height;
				}
				return false;
			}
			return true;
		}
	}
}
