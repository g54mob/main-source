using DG.Tweening;
using TMPro;
using UnityEngine;

public class SimpleTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI tooltipText;

	private CanvasGroup canvasGroup;

	[SerializeField]
	private TextMeshProUGUI headerText;

	[Header("Coordinate Conversion Settings")]
	[Tooltip("The RectTransform of the parent Canvas.")]
	[SerializeField]
	private RectTransform canvasRectTransform;

	[Tooltip("The Camera used to render this canvas. Required for 'Screen Space - Camera' mode.")]
	[SerializeField]
	private Camera uiCamera;

	private RectTransform tooltipRectTransform;

	[Header("Animation Settings")]
	public float showDuration = 0.3f;

	public float hideDuration = 0.2f;

	public float rotationAmount = -10f;

	public static SimpleTooltip Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.blocksRaycasts = false;
		tooltipRectTransform = GetComponent<RectTransform>();
		if (uiCamera == null)
		{
			Debug.LogError("SimpleTooltip Error: UI Camera has not been assigned in the Inspector!", base.gameObject);
		}
		HideTooltip();
	}

	private void Update()
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, uiCamera, out var _);
	}

	public void ShowTooltip(string text, RectTransform anchor, Vector2 offset, string headerTextString, bool showHeaderText)
	{
		base.transform.DOKill();
		if (canvasGroup != null)
		{
			canvasGroup.DOKill();
		}
		if (tooltipText != null)
		{
			tooltipText.text = text;
		}
		if (headerText != null)
		{
			if (showHeaderText)
			{
				headerText.enabled = true;
				headerText.text = headerTextString;
			}
			else
			{
				headerText.enabled = false;
			}
		}
		if (anchor != null && uiCamera != null)
		{
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(uiCamera, anchor.position);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, uiCamera, out var localPoint);
			localPoint += offset;
			if (tooltipRectTransform != null)
			{
				tooltipRectTransform.anchoredPosition = localPoint;
			}
		}
		base.gameObject.SetActive(value: true);
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
		base.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
		if (canvasGroup != null)
		{
			canvasGroup.DOFade(1f, showDuration).SetEase(Ease.OutQuad);
		}
		base.transform.DORotate(Vector3.zero, showDuration).SetEase(Ease.OutBack);
	}

	public void HideTooltip()
	{
		base.transform.DOKill();
		canvasGroup.DOKill();
		canvasGroup.DOFade(0f, hideDuration).SetEase(Ease.InQuad).OnComplete(delegate
		{
			base.gameObject.SetActive(value: false);
		});
	}
}
