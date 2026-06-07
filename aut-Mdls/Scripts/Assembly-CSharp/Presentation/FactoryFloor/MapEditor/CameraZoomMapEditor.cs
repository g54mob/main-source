using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.FactoryFloor.MapEditor
{
	public class CameraZoomMapEditor : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _cameraScroll;

		[SerializeField]
		private Camera _cam;

		[SerializeField]
		private float _zoomSpeed = 5f;

		[SerializeField]
		private float _minZoom = 5f;

		[SerializeField]
		private float _maxZoom = 20f;

		[SerializeField]
		private float _zoomSeconds = 5f;

		private float _targetZoom;

		private float _velocity;

		public float TargetZoom => _targetZoom;

		private void Start()
		{
			_targetZoom = _cam.orthographicSize;
			_cameraScroll.action.performed += HandleScrollInput;
		}

		private void OnDestroy()
		{
			_cameraScroll.action.performed -= HandleScrollInput;
		}

		private void HandleScrollInput(InputAction.CallbackContext obj)
		{
			float num = (0f - _cameraScroll.action.ReadValue<Vector2>().y) * _zoomSpeed * Time.deltaTime;
			float targetZoom = Mathf.Clamp(_targetZoom + num, _minZoom, _maxZoom);
			_targetZoom = targetZoom;
		}

		private void Update()
		{
			_cam.orthographicSize = Mathf.SmoothDamp(_cam.orthographicSize, _targetZoom, ref _velocity, _zoomSeconds);
		}
	}
}
