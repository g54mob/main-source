using UnityEngine;

namespace FractureField.DrillSite
{
	public class DrillSiteCameraController : MonoBehaviour
	{
		[Header("Input Area")]
		[SerializeField]
		private RectTransform _inputArea;

		[SerializeField]
		private bool _requireInputArea;

		[SerializeField]
		private bool _mapInputAreaToFullCamera;

		[Header("Zoom Settings")]
		[SerializeField]
		private float _minZoom;

		[SerializeField]
		private float _maxZoom;

		[SerializeField]
		private float _zoomSpeed;

		[SerializeField]
		private float _zoomSmoothing;

		[Header("Pan Settings")]
		[SerializeField]
		private float _panSpeed;

		[SerializeField]
		private float _panSmoothing;

		[Header("Bounds")]
		[SerializeField]
		private Vector2 _minBounds;

		[SerializeField]
		private Vector2 _maxBounds;

		[SerializeField]
		private bool _boundsRelativeToInitialPosition;

		[SerializeField]
		private bool _enforceBounds;

		private Camera _camera;

		private Vector3 _dragOrigin;

		private Vector3 _targetPosition;

		private float _targetZoom;

		private bool _isDragging;

		private Vector3 _initialPosition;

		private float _initialZoom;

		private bool _boundsDirty;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private bool IsMouseInInputArea()
		{
			return false;
		}

		private void HandlePanning()
		{
		}

		private void HandleZooming()
		{
		}

		private void ApplyMovement()
		{
		}

		private void CheckAndApplyBounds()
		{
		}

		private Vector3 GetWorldMousePosition()
		{
			return default(Vector3);
		}

		public void SetPosition(Vector3 position)
		{
		}

		public void SetZoom(float zoom)
		{
		}

		public void ResetCamera()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
