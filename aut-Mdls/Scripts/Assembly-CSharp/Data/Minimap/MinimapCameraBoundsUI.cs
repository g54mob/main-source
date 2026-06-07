using System.Collections.Generic;
using Events.Minimap;
using Presentation.Locators;
using Presentation.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Data.Minimap
{
	public class MinimapCameraBoundsUI : MonoBehaviour
	{
		[SerializeField]
		private MinimapDataCreatedEvent _minimapDataCreatedEvent;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private UILineRenderer _uiLineRenderer;

		[SerializeField]
		private MinimapUI _minimapUI;

		[SerializeField]
		private ScrollRectWithMMB _scrollRect;

		[SerializeField]
		private MinimapScrollViewControls _minimapScrollViewControls;

		[SerializeField]
		private InputActionReference _rightClickAction;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private CanvasScaler _canvasScaler;

		[Space]
		[SerializeField]
		private Color _fillColor;

		[SerializeField]
		private Color _boundsColor;

		[SerializeField]
		private float _boundsThickness = 2f;

		private bool _hasMinimapData;

		private MinimapData _minimapData;

		private Vector3[] _frustumCorners;

		private Vector3[] _localFrustumCorners;

		private Vector3 _lastCamPos;

		private readonly List<UILine> _lines = new List<UILine>();

		private readonly Rect _viewportRect = new Rect(0f, 0f, 1f, 1f);

		private void Awake()
		{
			_frustumCorners = new Vector3[4];
			_localFrustumCorners = new Vector3[4];
			_minimapDataCreatedEvent.Register(OnMinimapDataCreated);
			_rightClickAction.action.performed += OnMoveCameraToPosition;
		}

		private void Start()
		{
			_lastCamPos = _cameraLocator.Camera.transform.position;
		}

		private void OnDestroy()
		{
			_minimapDataCreatedEvent.UnRegister(OnMinimapDataCreated);
			_rightClickAction.action.performed -= OnMoveCameraToPosition;
		}

		private void OnMinimapDataCreated(MinimapData minimapData)
		{
			_minimapData = minimapData;
			_hasMinimapData = true;
		}

		private void Update()
		{
			if (_hasMinimapData)
			{
				float thickness = _boundsThickness / _minimapScrollViewControls.CurrentScale;
				UpdateCameraFrustumCorners();
				Vector3 vector = (_localFrustumCorners[0] + _localFrustumCorners[1] + _localFrustumCorners[2] + _localFrustumCorners[3]) / 4f;
				_uiLineRenderer.transform.localPosition = vector;
				_localFrustumCorners[0] -= vector;
				_localFrustumCorners[1] -= vector;
				_localFrustumCorners[2] -= vector;
				_localFrustumCorners[3] -= vector;
				_lines.Clear();
				_lines.Add(new UILine(_localFrustumCorners[0], _localFrustumCorners[1], _boundsColor, thickness));
				_lines.Add(new UILine(_localFrustumCorners[1], _localFrustumCorners[2], _boundsColor, thickness));
				_lines.Add(new UILine(_localFrustumCorners[2], _localFrustumCorners[3], _boundsColor, thickness));
				_lines.Add(new UILine(_localFrustumCorners[3], _localFrustumCorners[0], _boundsColor, thickness));
				_uiLineRenderer.SetLineSegments(_lines);
				_uiLineRenderer.ClearTriangles();
				_uiLineRenderer.AddTriangle(_localFrustumCorners[2], _localFrustumCorners[1], _localFrustumCorners[0], _fillColor);
				_uiLineRenderer.AddTriangle(_localFrustumCorners[2], _localFrustumCorners[3], _localFrustumCorners[0], _fillColor);
				MoveMinimapToCameraFrustum();
			}
		}

		private void MoveMinimapToCameraFrustum()
		{
			if (_scrollRect.IsDragging || _cameraViewLocator.CameraView.IsLerpingToTarget)
			{
				_lastCamPos = _cameraLocator.Camera.transform.position;
			}
			else if (Vector3.Distance(_lastCamPos, _cameraLocator.Camera.transform.position) > 0.1f)
			{
				Vector3 worldPosition = CalculateMiddleOfFrustum();
				_minimapUI.FocusMinimapOnWorldPosition(worldPosition);
				_lastCamPos = _cameraLocator.Camera.transform.position;
			}
		}

		private void UpdateCameraFrustumCorners()
		{
			_cameraLocator.Camera.CalculateFrustumCorners(_viewportRect, _cameraLocator.Camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, _frustumCorners);
			for (int i = 0; i < 4; i++)
			{
				_frustumCorners[i] = _cameraLocator.Camera.transform.TransformVector(_frustumCorners[i]);
				Vector3 normalized = _frustumCorners[i].normalized;
				float num = Mathf.Abs(_cameraLocator.Camera.transform.position.y / normalized.y);
				_frustumCorners[i] = _cameraLocator.Camera.transform.position + normalized * num;
				_localFrustumCorners[i] = _minimapData.WorldPosToLocalPos(_frustumCorners[i]);
			}
		}

		private Vector3 CalculateMiddleOfFrustum()
		{
			return (_frustumCorners[0] + _frustumCorners[1] + _frustumCorners[2] + _frustumCorners[3]) / 4f;
		}

		private void OnMoveCameraToPosition(InputAction.CallbackContext action)
		{
			if (_minimapScrollViewControls.IsHoveringMinimap && Mathf.Approximately(action.ReadValue<float>(), 1f))
			{
				Vector2 localMousePosition = _minimapScrollViewControls.GetLocalMousePosition();
				_cameraViewLocator.CameraView.LerpToTarget(_minimapData.LocalPosToWorldPos(localMousePosition), blockInput: true);
			}
		}
	}
}
