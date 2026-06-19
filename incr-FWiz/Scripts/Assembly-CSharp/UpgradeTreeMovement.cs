using System.Collections.Generic;
using OUSystems.Basics.UI;
using UnityEngine;

public class UpgradeTreeMovement : MonoBehaviour
{
	[SerializeField]
	private RectTransform _movementTransform;

	[SerializeField]
	private float _catchupSpeed;

	private Vector2 _truePosition;

	private Vector2 _moveDirection;

	private float _speedModifier;

	[Header("Move Settings")]
	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _dragSpeed;

	[SerializeField]
	private Rect _bounds;

	[SerializeField]
	public UpgradeTreeUI _treeUI;

	private Vector2 _lastDragPos;

	private bool _isDragging;

	private bool _isPressing;

	private Canvas _rootCanvas;

	private RectTransform _canvasRect;

	[SerializeField]
	private GameObject _raycastBlockPanel;

	[SerializeField]
	private HoverListener _treeHoverListener;

	[SerializeField]
	private float _dragTriggerDist;

	[Header("Zoom Settings")]
	[SerializeField]
	private float _zoomSpeed;

	[SerializeField]
	private float _minZoom;

	[SerializeField]
	private float _maxZoom;

	[SerializeField]
	private float _zoomSmoothSpeed;

	private float _targetZoom;

	private float _currentZoom;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateMoveDirection(Vector2 moveDirection, float speedModifier)
	{
	}

	private void OnScroll(int scrollDelta)
	{
	}

	public void Recenter()
	{
	}

	private void Update()
	{
	}

	private void HandleDragging()
	{
	}

	private void OnStartDrag()
	{
	}

	private void OnEndDrag()
	{
	}

	private void ClampPositionToBounds()
	{
	}

	private Rect GetMovementBounds(List<UpgradeTreeUIUpgrade> objects)
	{
		return default(Rect);
	}
}
