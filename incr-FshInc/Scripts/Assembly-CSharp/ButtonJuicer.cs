using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJuicer : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("Idle Sway & Breath")]
	public float scaleAmount = 1.1f;

	public float swayAngle = 1.5f;

	public float duration = 1.2f;

	public Ease easeType = Ease.InOutSine;

	[Header("Interaction Settings")]
	public float hoverScaleMultiplier = 1.15f;

	public float clickScale = 0.95f;

	public float transitionSpeed = 0.2f;

	private Tween _scaleTween;

	private Tween _rotateTween;

	private bool _isHovered;

	private void Start()
	{
		base.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - swayAngle);
		_rotateTween = base.transform.DORotate(new Vector3(0f, 0f, swayAngle), duration * 1.5f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo)
			.SetUpdate(isIndependentUpdate: true);
		StartIdleScale();
	}

	private void StartIdleScale()
	{
		if (!_isHovered)
		{
			_scaleTween?.Kill();
			_scaleTween = base.transform.DOScale(scaleAmount, duration).SetEase(easeType).SetLoops(-1, LoopType.Yoyo)
				.SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_isHovered = true;
		_scaleTween?.Kill();
		SoundManager.PlaySound("UI_Hover");
		_scaleTween = base.transform.DOScale(hoverScaleMultiplier, transitionSpeed).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isHovered = false;
		_scaleTween?.Kill();
		_scaleTween = base.transform.DOScale(1f, transitionSpeed).SetUpdate(isIndependentUpdate: true).OnComplete(StartIdleScale);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_scaleTween?.Kill();
		_scaleTween = base.transform.DOScale(clickScale, 0.1f).SetUpdate(isIndependentUpdate: true);
		SoundManager.PlaySound("UI_Click");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_scaleTween = base.transform.DOScale(hoverScaleMultiplier, 0.1f).SetUpdate(isIndependentUpdate: true);
	}

	private void OnDestroy()
	{
		_scaleTween?.Kill();
		_rotateTween?.Kill();
	}
}
