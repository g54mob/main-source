using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class TitleLetterUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	[Header("Hover Settings")]
	public float hoverRiseAmount = 15f;

	public float hoverDuration = 0.2f;

	[Header("Wave Animation Settings")]
	public float waveHeight = 30f;

	public float waveDuration = 0.4f;

	private RectTransform _rectTransform;

	private Vector2 _originalAnchoredPos;

	private TitleGroupUI _group;

	private bool _isAnimatingGroupEffect;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		_originalAnchoredPos = _rectTransform.anchoredPosition;
	}

	public void Initialize(TitleGroupUI group)
	{
		_group = group;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!_isAnimatingGroupEffect)
		{
			_rectTransform.DOAnchorPosY(_originalAnchoredPos.y + hoverRiseAmount, hoverDuration).SetEase(Ease.OutBack);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!_isAnimatingGroupEffect)
		{
			_rectTransform.DOAnchorPosY(_originalAnchoredPos.y, hoverDuration).SetEase(Ease.OutQuad);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_group != null)
		{
			_group.TriggerGroupEffect();
		}
	}

	public void PlayWaveAnimation(float delay)
	{
		_isAnimatingGroupEffect = true;
		base.transform.DOKill();
		_rectTransform.anchoredPosition = _originalAnchoredPos;
		Sequence sequence = DOTween.Sequence();
		sequence.SetDelay(delay);
		sequence.Append(_rectTransform.DOAnchorPosY(_originalAnchoredPos.y + waveHeight, waveDuration / 2f).SetEase(Ease.OutQuad));
		sequence.Append(_rectTransform.DOAnchorPosY(_originalAnchoredPos.y, waveDuration / 2f).SetEase(Ease.OutBounce));
		sequence.OnComplete(delegate
		{
			_isAnimatingGroupEffect = false;
		});
	}
}
