using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UIHoverCursor))]
public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("Animation Settings")]
	[Tooltip("How much the button scales on the X-axis when hovered.")]
	public float hoverScaleX = 1.05f;

	[Tooltip("How much the button scales on the Y-axis when hovered.")]
	public float hoverScaleY = 1.1f;

	[Tooltip("How much the button shrinks when pressed down.")]
	public float pressScale = 0.9f;

	[Tooltip("How long the animations take.")]
	public float animationDuration = 0.2f;

	[Tooltip("The easing function for the animation. 'OutBack' gives a nice overshoot effect.")]
	public Ease easeType = Ease.OutBack;

	[Header("Shadow Settings")]
	[Tooltip("The shadow component on this button.")]
	public bool shadowEnabled;

	public Shadow buttonShadow;

	[Tooltip("The shadow's offset when the button is hovered.")]
	public Vector2 shadowHoverOffset = new Vector2(8f, -8f);

	private Vector3 _originalScale;

	private Vector2 _originalShadowOffset;

	private void Awake()
	{
		_originalScale = base.transform.localScale;
		if (shadowEnabled)
		{
			if (buttonShadow == null)
			{
				buttonShadow = GetComponent<Shadow>();
			}
			if (buttonShadow != null)
			{
				_originalShadowOffset = buttonShadow.effectDistance;
			}
			else
			{
				shadowEnabled = false;
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		base.transform.DOScale(new Vector3(_originalScale.x * hoverScaleX, _originalScale.y * hoverScaleY, _originalScale.z), animationDuration).SetEase(easeType).SetUpdate(isIndependentUpdate: true);
		SoundManager.PlaySound("UI_Hover");
		if (shadowEnabled)
		{
			DOTween.To(() => buttonShadow.effectDistance, delegate(Vector2 x)
			{
				buttonShadow.effectDistance = x;
			}, shadowHoverOffset, animationDuration).SetEase(easeType).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		base.transform.DOScale(_originalScale, animationDuration).SetEase(easeType).SetUpdate(isIndependentUpdate: true);
		if (shadowEnabled)
		{
			DOTween.To(() => buttonShadow.effectDistance, delegate(Vector2 x)
			{
				buttonShadow.effectDistance = x;
			}, _originalShadowOffset, animationDuration).SetEase(easeType).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		base.transform.DOScale(_originalScale * pressScale, animationDuration / 2f).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
		SoundManager.PlaySound("UI_Click");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		base.transform.DOScale(new Vector3(_originalScale.x * hoverScaleX, _originalScale.y * hoverScaleY, _originalScale.z), animationDuration).SetEase(easeType).SetUpdate(isIndependentUpdate: true);
	}

	private void OnDisable()
	{
		DOTween.Kill(base.transform);
		if (shadowEnabled && buttonShadow != null)
		{
			buttonShadow.DOKill();
		}
	}
}
