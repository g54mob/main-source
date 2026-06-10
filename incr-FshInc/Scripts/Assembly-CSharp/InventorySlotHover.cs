using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Animation Settings")]
	public float hoverOffsetY = 15f;

	public float animationDuration = 0.2f;

	public Ease hoverEase = Ease.OutQuad;

	private RectTransform _rectTransform;

	private Vector2 _originalPosition;

	private Tween _currentTween;

	private bool _isInitialized;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	public void Initialize(Vector2 homePosition)
	{
		_originalPosition = homePosition;
		_isInitialized = true;
	}

	private void OnDisable()
	{
		_currentTween?.Kill();
		if (_isInitialized)
		{
			_rectTransform.anchoredPosition = _originalPosition;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (_isInitialized && base.enabled)
		{
			_currentTween?.Kill();
			_currentTween = _rectTransform.DOAnchorPosY(_originalPosition.y + hoverOffsetY, animationDuration).SetEase(hoverEase);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (_isInitialized && base.enabled)
		{
			_currentTween?.Kill();
			_currentTween = _rectTransform.DOAnchorPosY(_originalPosition.y, animationDuration).SetEase(hoverEase);
		}
	}
}
