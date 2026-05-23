using System;
using System.Collections.Generic;
using Presentation.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class TechTreeUIZoom : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	private Vector3 _initialScale;

	[SerializeField]
	private float _zoomSpeed = 0.1f;

	[SerializeField]
	private float _minZoom = 0.5f;

	[SerializeField]
	private float _maxZoom = 10f;

	[SerializeField]
	private TechTreeUI _techTreeUI;

	[SerializeField]
	private ScrollRectWithMMB _scrollRectWithMMB;

	[SerializeField]
	private List<float> _zoomTiers;

	private RectTransform _rectTransform;

	private Vector3 _zoomLevel;

	private bool _zoomLocked;

	public Vector3 ZoomLevel => _zoomLevel;

	public event Action OnZoom = delegate
	{
	};

	private void Awake()
	{
		_initialScale = base.transform.localScale;
		_rectTransform = GetComponent<RectTransform>();
	}

	public void SetZoomLevel(Vector3 zoomLevel)
	{
		_zoomLevel = zoomLevel;
		base.transform.localScale = _zoomLevel;
		_techTreeUI.ScrollZoom(_maxZoom, GetZoomTier(_zoomLevel));
	}

	public void SetMinZoom()
	{
		SetZoomLevel(Vector3.one * _minZoom);
	}

	public void ResetZoomLevel()
	{
		SetZoomLevel(Vector3.one * _maxZoom);
	}

	public void LockZoom(bool toggle)
	{
		_zoomLocked = toggle;
	}

	public void OnScroll(PointerEventData eventData)
	{
		if (!_zoomLocked)
		{
			bool isDragging = _scrollRectWithMMB.IsDragging;
			if (isDragging)
			{
				_scrollRectWithMMB.OnEndDrag(eventData);
			}
			Vector2 position = eventData.position;
			this.OnZoom();
			float num = Mathf.Sign(eventData.scrollDelta.y);
			Vector3 vector = Vector3.one * (num * _zoomSpeed);
			_zoomLevel = base.transform.localScale + vector;
			_zoomLevel = ClampDesiredScale(_zoomLevel);
			Vector3 vector2 = _zoomLevel - base.transform.localScale;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, position, null, out var localPoint);
			Vector3 vector3 = new Vector3(localPoint.x * vector2.x, localPoint.y * vector2.y, 0f);
			_rectTransform.localPosition -= vector3;
			base.transform.localScale = _zoomLevel;
			int zoomTier = GetZoomTier(_zoomLevel);
			_techTreeUI.ScrollZoom(_zoomLevel.x, zoomTier);
			if (isDragging)
			{
				_scrollRectWithMMB.OnBeginDrag(eventData);
			}
		}
	}

	private int GetZoomTier(Vector3 zoomLevel)
	{
		for (int num = _zoomTiers.Count - 1; num >= 0; num--)
		{
			if (zoomLevel.x > _zoomTiers[num])
			{
				return num;
			}
		}
		return 0;
	}

	private Vector3 ClampDesiredScale(Vector3 desiredScale)
	{
		Vector3 lhs = _initialScale * _minZoom;
		Vector3 lhs2 = _initialScale * _maxZoom;
		desiredScale = Vector3.Max(lhs, desiredScale);
		desiredScale = Vector3.Min(lhs2, desiredScale);
		return desiredScale;
	}
}
