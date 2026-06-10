using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(UIHoverCursor))]
public class UIReactiveProp : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("Hover Settings")]
	[Tooltip("Scale multiplier when hovered (e.g., 1.1 for 10% larger)")]
	public float hoverScale = 1.1f;

	[Tooltip("Rotation wiggle strength on hover")]
	public float wiggleStrength = 5f;

	[Tooltip("Duration of the hover animation")]
	public float animDuration = 0.2f;

	[Header("Click Settings")]
	[Tooltip("Toggle to enable/disable the squash animation on click")]
	public bool enableClickAnimation = true;

	[Tooltip("Scale multiplier when held down (e.g., 0.95 for 5% squash). Set closer to 1 for less intensity.")]
	public float clickSquash = 0.95f;

	[Header("Entrance")]
	public bool playEntranceOnStart;

	public float entranceDelay;

	[Header("Pivot Override")]
	[Tooltip("Enable this to force the pivot to a specific spot for animation (e.g., Bottom for plants).")]
	public bool overridePivot;

	[Tooltip("X: 0=Left, 0.5=Center, 1=Right\nY: 0=Bottom, 0.5=Center, 1=Top")]
	public Vector2 targetPivot = new Vector2(0.5f, 0.5f);

	private RectTransform _rectTransform;

	private Vector3 _originalScale;

	private Quaternion _originalRotation;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	private void Start()
	{
		if (overridePivot)
		{
			SetPivotSmart(targetPivot);
		}
		_originalScale = _rectTransform.localScale;
		_originalRotation = _rectTransform.localRotation;
		if (playEntranceOnStart)
		{
			AnimateEntrance(entranceDelay);
		}
	}

	private void SetPivotSmart(Vector2 newPivot)
	{
		Vector3 position = _rectTransform.position;
		_rectTransform.pivot = newPivot;
		_rectTransform.position = position;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_rectTransform.DOKill();
		SoundManager.PlaySound("UI_Hover", 0.1f);
		_rectTransform.DOScale(_originalScale * hoverScale, animDuration).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
		if (wiggleStrength > 0f)
		{
			_rectTransform.DOShakeRotation(animDuration, new Vector3(0f, 0f, wiggleStrength), 10, 90f, fadeOut: false).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_rectTransform.DOKill();
		_rectTransform.DOScale(_originalScale, animDuration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
		_rectTransform.DOLocalRotateQuaternion(_originalRotation, animDuration).SetUpdate(isIndependentUpdate: true);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (enableClickAnimation)
		{
			SoundManager.PlaySound("UI_Click", 0.2f);
			_rectTransform.DOKill();
			_rectTransform.DOScale(_originalScale * clickSquash, 0.1f).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (enableClickAnimation)
		{
			_rectTransform.DOScale(_originalScale * hoverScale, 0.2f).SetEase(Ease.OutElastic).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void AnimateEntrance(float delay = 0f)
	{
		_rectTransform.localScale = Vector3.zero;
		_rectTransform.DOScale(_originalScale, 0.5f).SetEase(Ease.OutBack).SetDelay(delay)
			.SetUpdate(isIndependentUpdate: true);
	}
}
