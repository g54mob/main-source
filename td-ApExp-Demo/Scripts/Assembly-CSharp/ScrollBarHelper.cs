using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScrollBarHelper : MonoBehaviour
{
	[Header("Targets (either is optional)")]
	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Scrollbar scrollbar;

	[SerializeField]
	[Tooltip("Any other UI element that you would like to use as a hover target.")]
	private List<RectTransform> additionalHovers;

	[Range(0.01f, 0.5f)]
	private float sensitivity = 0.1f;

	[Header("Behavior")]
	[Tooltip("Only respond when cursor is over the ScrollRect viewport or the Scrollbar.")]
	public bool requireHover = true;

	[Tooltip("Flip the direction if needed.")]
	public bool invert;

	private const float WheelPerNotch = 120f;

	private RectTransform _barRect;

	private RectTransform _viewportRect;

	private Camera _uiCam;

	private void Reset()
	{
		scrollRect = GetComponentInParent<ScrollRect>();
		scrollbar = GetComponent<Scrollbar>() ?? GetComponentInChildren<Scrollbar>();
	}

	private void Awake()
	{
		if (scrollRect == null)
		{
			scrollRect = GetComponentInParent<ScrollRect>();
		}
		if (scrollbar == null)
		{
			scrollbar = GetComponent<Scrollbar>();
		}
		_barRect = (scrollbar ? scrollbar.GetComponent<RectTransform>() : null);
		if (scrollRect != null)
		{
			_viewportRect = ((scrollRect.viewport != null) ? scrollRect.viewport : scrollRect.GetComponent<RectTransform>());
		}
		Canvas componentInParent = GetComponentInParent<Canvas>();
		if (componentInParent != null && componentInParent.renderMode != RenderMode.ScreenSpaceOverlay)
		{
			_uiCam = componentInParent.worldCamera;
		}
	}

	private void Update()
	{
		if (Mouse.current == null)
		{
			return;
		}
		float y = Mouse.current.scroll.ReadValue().y;
		if (Mathf.Approximately(y, 0f) || (requireHover && !IsPointerOverTargets()))
		{
			return;
		}
		float num = y / 120f * sensitivity * (invert ? (-1f) : 1f);
		bool flag = false;
		if (scrollRect != null)
		{
			if (scrollRect.vertical)
			{
				scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + num);
				flag = true;
			}
			else if (scrollRect.horizontal)
			{
				scrollRect.horizontalNormalizedPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition - num);
				flag = true;
			}
		}
		if (!flag && scrollbar != null)
		{
			scrollbar.value = Mathf.Clamp01(scrollbar.value - num);
		}
	}

	private bool IsPointerOverTargets()
	{
		Vector2 screenPoint = Mouse.current.position.ReadValue();
		bool flag = (bool)_barRect && RectTransformUtility.RectangleContainsScreenPoint(_barRect, screenPoint, _uiCam);
		bool flag2 = (bool)_viewportRect && RectTransformUtility.RectangleContainsScreenPoint(_viewportRect, screenPoint, _uiCam);
		bool flag3;
		if (additionalHovers == null)
		{
			flag3 = true;
		}
		else
		{
			foreach (RectTransform additionalHover in additionalHovers)
			{
				flag3 = (bool)additionalHover && RectTransformUtility.RectangleContainsScreenPoint(additionalHover, screenPoint, _uiCam);
				if (flag3)
				{
					return flag || flag2 || flag3;
				}
			}
			flag3 = false;
		}
		return flag || flag2 || flag3;
	}
}
