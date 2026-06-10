using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SocialsButtonEffect : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Settings")]
	[Tooltip("How much bigger? 1.1 is 10% bigger. 1.05 is 5% (very subtle).")]
	[SerializeField]
	private float hoverScale = 1.1f;

	[Tooltip("How fast the animation plays in seconds.")]
	[SerializeField]
	private float duration = 0.15f;

	private Vector3 _originalScale;

	private RectTransform _rectTransform;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	private void Start()
	{
		_originalScale = _rectTransform.localScale;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		base.transform.DOKill();
		base.transform.DOScale(_originalScale * hoverScale, duration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		base.transform.DOKill();
		base.transform.DOScale(_originalScale, duration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
	}
}
