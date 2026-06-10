using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AutoClickVFX : MonoBehaviour
{
	[Header("Sprite References")]
	[Tooltip("The default sprite, e.g., a hand with a finger pointing up.")]
	public Sprite idleSprite;

	[Tooltip("The sprite to show during the 'click' animation, e.g., a hand with a finger pointing down.")]
	public Sprite clickSprite;

	[Header("Animation Settings")]
	public float fadeInDuration = 0.15f;

	public float clickScale = 0.8f;

	public float clickDuration = 0.1f;

	public float fadeOutDelay = 0.2f;

	public float fadeOutDuration = 0.5f;

	[Tooltip("How many pixels the icon moves up as it fades out.")]
	public float fadeOutMoveAmount = 10f;

	private Image vfxImage;

	private CanvasGroup canvasGroup;

	private RectTransform rectTransform;

	private void Start()
	{
		vfxImage = GetComponent<Image>();
		canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;
		rectTransform = GetComponent<RectTransform>();
		vfxImage.sprite = idleSprite;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(canvasGroup.DOFade(1f, fadeInDuration));
		sequence.AppendCallback(delegate
		{
			vfxImage.sprite = clickSprite;
		});
		sequence.Append(base.transform.DOScale(clickScale, clickDuration));
		sequence.AppendCallback(delegate
		{
			vfxImage.sprite = idleSprite;
		});
		sequence.Append(base.transform.DOScale(1f, clickDuration));
		sequence.AppendInterval(fadeOutDelay);
		sequence.Append(canvasGroup.DOFade(0f, fadeOutDuration));
		sequence.Join(rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + fadeOutMoveAmount, fadeOutDuration));
		sequence.OnComplete(delegate
		{
			Object.Destroy(base.gameObject);
		});
	}
}
