using Data.Variables;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.CameraView
{
	public class FreeCameraView : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Transform _origin;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[Header("Inputs")]
		[SerializeField]
		private InputActionReference panInputAction;

		[SerializeField]
		private InputActionReference rotateInputAction;

		[SerializeField]
		private InputActionReference pointerPositionInputAction;

		[SerializeField]
		private InputActionReference moveUpDownAction;

		[Header("Trailer Inputs")]
		[SerializeField]
		private InputActionReference rotateCameraKeysInputAction;

		[Header("Pan Settings")]
		[SerializeField]
		private FloatVariableSO _cameraSpeedMultiplier;

		[SerializeField]
		private float _cameraMovementSpeed = 10f;

		[Header("Rotate Settings")]
		[SerializeField]
		private FloatVariableSO _cameraRotationMultiplier;

		[SerializeField]
		private float _rotateSpeed = 10f;

		[SerializeField]
		private float _mouseRotationSpeed = 0.5f;

		[SerializeField]
		private float _pitchMultiplier = 2f;

		[Header("Camera Lerp Settings")]
		[SerializeField]
		private float lerpSpeed = 0.05f;

		[SerializeField]
		private BoolVariableSO _operatorUIIsActive;

		private bool _isKeyPanning;

		private bool _isMovingUpDown;

		private Vector2 _prevMousePosition;

		private Vector2 _deltaMousePosition;

		private bool _isKeyRotating;

		private bool _isRotating;

		private Vector3 _originLerpTarget;

		private Vector3 _savedCameraPos;

		private Vector3 _savedCameraOriginPos;

		private Quaternion _savedCameraRot;

		private Quaternion _savedCameraOriginRot;

		private void Awake()
		{
		}

		private void OnEnable()
		{
			_savedCameraOriginPos = _origin.transform.position;
			_savedCameraOriginRot = _origin.transform.rotation;
			_savedCameraPos = _camera.transform.position;
			_savedCameraRot = _camera.transform.rotation;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			_origin.transform.position = _camera.transform.position;
			_originLerpTarget = _origin.transform.position;
			if (panInputAction != null)
			{
				panInputAction.action.performed += HandlePanInputStarted;
			}
			if (panInputAction != null)
			{
				panInputAction.action.canceled += HandlePanInputEnded;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.performed += HandleRotateInputStarted;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.canceled += HandleRotateInputEnded;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.performed += HandleRotateKeysInputStarted;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.canceled += HandleRotateKeysInputEnded;
			}
			if (moveUpDownAction != null)
			{
				moveUpDownAction.action.performed += HandleMoveUpDownInputStarted;
			}
			if (moveUpDownAction != null)
			{
				moveUpDownAction.action.canceled += HandleMoveUpDownInputEnded;
			}
			_camera.transform.LookAt(_origin, Vector3.up);
		}

		private void OnDisable()
		{
			_isKeyPanning = false;
			if (panInputAction != null)
			{
				panInputAction.action.performed -= HandlePanInputStarted;
			}
			if (panInputAction != null)
			{
				panInputAction.action.canceled -= HandlePanInputEnded;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.performed -= HandleRotateInputStarted;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.canceled -= HandleRotateInputEnded;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.performed -= HandleRotateKeysInputStarted;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.canceled -= HandleRotateKeysInputEnded;
			}
			if (moveUpDownAction != null)
			{
				moveUpDownAction.action.performed -= HandleMoveUpDownInputStarted;
			}
			if (moveUpDownAction != null)
			{
				moveUpDownAction.action.canceled -= HandleMoveUpDownInputEnded;
			}
			_origin.transform.position = _savedCameraOriginPos;
			_origin.transform.rotation = _savedCameraOriginRot;
			_camera.transform.position = _savedCameraPos;
			_camera.transform.rotation = _savedCameraRot;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		private void Update()
		{
			UpdateMouseDelta();
			if (_isKeyPanning)
			{
				PanViaKeys();
			}
			if (_isMovingUpDown)
			{
				MoveUpDown();
			}
			Rotate();
			if (_isKeyRotating)
			{
				RotateViaKeys();
			}
			LerpCameraMovements();
		}

		private void LerpCameraMovements()
		{
			_origin.transform.position = Vector3.Lerp(_origin.transform.position, _originLerpTarget, lerpSpeed * Time.deltaTime);
			if (Vector3.Distance(_origin.transform.position, _originLerpTarget) <= 0.01f)
			{
				_origin.transform.position = _originLerpTarget;
			}
			_camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, _camera.transform.localPosition.normalized, lerpSpeed * Time.deltaTime);
		}

		private void HandleRotateInputStarted(InputAction.CallbackContext obj)
		{
			ResetPreviousMousePosition();
			_isRotating = true;
		}

		private void HandleRotateInputEnded(InputAction.CallbackContext obj)
		{
			_isRotating = false;
		}

		private void HandlePanInputEnded(InputAction.CallbackContext obj)
		{
			_isKeyPanning = false;
		}

		private void HandlePanInputStarted(InputAction.CallbackContext obj)
		{
			_isKeyPanning = true;
		}

		private void HandleMoveUpDownInputStarted(InputAction.CallbackContext obj)
		{
			_isMovingUpDown = true;
		}

		private void HandleMoveUpDownInputEnded(InputAction.CallbackContext obj)
		{
			_isMovingUpDown = false;
		}

		private void HandleRotateKeysInputStarted(InputAction.CallbackContext obj)
		{
			_isKeyRotating = true;
		}

		private void HandleRotateKeysInputEnded(InputAction.CallbackContext obj)
		{
			_isKeyRotating = false;
		}

		private void PanViaKeys()
		{
			Vector2 vector = panInputAction.action.ReadValue<Vector2>();
			_originLerpTarget += _camera.transform.forward * (vector.y * _cameraMovementSpeed * _cameraSpeedMultiplier.Value * Time.deltaTime);
			_originLerpTarget += _camera.transform.right * (vector.x * _cameraMovementSpeed * _cameraSpeedMultiplier.Value * Time.deltaTime);
		}

		private void MoveUpDown()
		{
			Vector2 vector = moveUpDownAction.action.ReadValue<Vector2>();
			_originLerpTarget += Vector3.up * (vector.y * _cameraMovementSpeed * _cameraSpeedMultiplier.Value * Time.deltaTime);
		}

		private Vector3 GetOffsetRotatedWithCamera(Vector2 delta, float speed)
		{
			return (_camera.transform.right * delta.x + Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized * delta.y) * speed;
		}

		private void Rotate()
		{
			float x = 0f - Input.GetAxis("Mouse X");
			float y = 0f - Input.GetAxis("Mouse Y");
			Vector2 vector = new Vector2(x, y) * _mouseRotationSpeed;
			_origin.transform.Rotate(Vector3.up, (0f - vector.x) * _rotateSpeed * _cameraRotationMultiplier.Value * Time.deltaTime);
			_camera.transform.RotateAround(_origin.transform.position, _camera.transform.right, vector.y * _rotateSpeed * _cameraRotationMultiplier.Value * Time.deltaTime);
		}

		private void RotateViaKeys()
		{
			Vector2 vector = rotateCameraKeysInputAction.action.ReadValue<Vector2>();
			_origin.transform.Rotate(Vector3.up, vector.x * 3f * (_rotateSpeed / 100f) * _cameraRotationMultiplier.Value);
			float x = _camera.transform.eulerAngles.x;
			float angle = Mathf.Clamp(x + (0f - vector.y) * _rotateSpeed * _pitchMultiplier * Time.deltaTime * _cameraRotationMultiplier.Value * 3f, -89f, 89f) - x;
			_camera.transform.RotateAround(_origin.transform.position, _camera.transform.right, angle);
		}

		private void ResetPreviousMousePosition()
		{
			_prevMousePosition = pointerPositionInputAction.action.ReadValue<Vector2>();
		}

		private void UpdateMouseDelta()
		{
			Vector2 vector = pointerPositionInputAction.action.ReadValue<Vector2>();
			_deltaMousePosition = _prevMousePosition - vector;
			_prevMousePosition = vector;
		}
	}
}
