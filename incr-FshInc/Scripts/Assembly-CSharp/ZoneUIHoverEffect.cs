using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneUIHoverEffect : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("UI Element References")]
	public Transform zoneCardTransform;

	public GameObject secondaryInfoBox;

	[Header("Hover Animation Settings - Zone Card")]
	public float hoverMoveUpAmount = 20f;

	public float hoverMoveDuration = 0.15f;

	public Ease hoverEaseType = Ease.OutQuad;

	[Header("Hover Animation Settings - Secondary Info Box")]
	public float secondaryBoxAppearDuration = 0.2f;

	public Ease secondaryBoxEaseType = Ease.OutBack;

	public Vector3 secondaryBoxStartScale = new Vector3(0.1f, 0.1f, 1f);

	public Vector3 secondaryBoxTargetScale = Vector3.one;

	public Vector3 secondaryBoxOffset = new Vector3(50f, 0f, 0f);

	private Vector3 originalZoneCardPosition;

	private Vector3 originalSecondaryInfoBoxLocalPosition;

	private Vector3 originalSecondaryInfoBoxLocalScale;

	private Tween zoneCardTween;

	private Tween secondaryBoxTween;

	private void Awake()
	{
		if (zoneCardTransform == null)
		{
			zoneCardTransform = base.transform;
		}
		if (secondaryInfoBox == null)
		{
			Debug.LogError("Secondary Info Box GameObject not assigned! Please assign it in the Inspector.", this);
		}
		originalZoneCardPosition = zoneCardTransform.position;
		if (secondaryInfoBox != null)
		{
			originalSecondaryInfoBoxLocalPosition = secondaryInfoBox.transform.localPosition;
			originalSecondaryInfoBoxLocalScale = secondaryInfoBox.transform.localScale;
			secondaryInfoBox.transform.localScale = secondaryBoxStartScale;
			secondaryInfoBox.SetActive(value: false);
		}
	}

	private void Start()
	{
		UpdateOriginalPosition();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		UpdateOriginalPosition();
		zoneCardTween?.Kill();
		secondaryBoxTween?.Kill();
		zoneCardTween = zoneCardTransform.DOMoveY(originalZoneCardPosition.y + hoverMoveUpAmount, hoverMoveDuration).SetEase(hoverEaseType);
		if (secondaryInfoBox != null)
		{
			if (!secondaryInfoBox.activeSelf)
			{
				secondaryInfoBox.SetActive(value: true);
				secondaryInfoBox.transform.localScale = secondaryBoxStartScale;
				Vector3 vector = originalSecondaryInfoBoxLocalPosition + secondaryBoxOffset;
				secondaryInfoBox.transform.localPosition = vector - secondaryBoxOffset * 0.5f;
			}
			secondaryBoxTween = secondaryInfoBox.transform.DOScale(secondaryBoxTargetScale, secondaryBoxAppearDuration).SetEase(secondaryBoxEaseType);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		zoneCardTween?.Kill();
		secondaryBoxTween?.Kill();
		zoneCardTween = zoneCardTransform.DOMoveY(originalZoneCardPosition.y, hoverMoveDuration).SetEase(hoverEaseType);
		if (secondaryInfoBox != null)
		{
			secondaryBoxTween = secondaryInfoBox.transform.DOScale(secondaryBoxStartScale, secondaryBoxAppearDuration).SetEase(secondaryBoxEaseType).OnComplete(delegate
			{
				secondaryInfoBox.SetActive(value: false);
			});
		}
	}

	public void UpdateOriginalPosition()
	{
		if (zoneCardTransform != null)
		{
			originalZoneCardPosition = zoneCardTransform.position;
		}
	}

	private void OnDisable()
	{
		zoneCardTween?.Kill();
		secondaryBoxTween?.Kill();
		if (zoneCardTransform != null)
		{
			zoneCardTransform.position = originalZoneCardPosition;
		}
		if (secondaryInfoBox != null)
		{
			secondaryInfoBox.SetActive(value: false);
			secondaryInfoBox.transform.localScale = originalSecondaryInfoBoxLocalScale;
			secondaryInfoBox.transform.localPosition = originalSecondaryInfoBoxLocalPosition;
		}
	}
}
