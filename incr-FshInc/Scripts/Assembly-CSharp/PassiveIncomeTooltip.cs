using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PassiveIncomeTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("References")]
	[Tooltip("The panel that slides out. Should be a child of this object, anchored to the bottom.")]
	[SerializeField]
	private RectTransform tooltipPanel;

	[Tooltip("Text element inside the tooltip panel that displays the passive income value.")]
	[SerializeField]
	private TMP_Text incomeText;

	[Tooltip("Shadow text element that mirrors incomeText for a drop-shadow effect.")]
	[SerializeField]
	private TMP_Text incomeTextShadow;

	[Header("Animation")]
	[SerializeField]
	private float slideDuration = 0.25f;

	[SerializeField]
	private Ease slideEase = Ease.OutBack;

	private float hiddenY;

	private float shownY;

	private bool isShowing;

	private Tween currentTween;

	private void Awake()
	{
		if (!(tooltipPanel == null))
		{
			shownY = tooltipPanel.anchoredPosition.y;
			hiddenY = shownY + tooltipPanel.rect.height;
			Graphic component = tooltipPanel.GetComponent<Graphic>();
			if (component != null)
			{
				component.raycastTarget = false;
			}
			Graphic[] componentsInChildren = tooltipPanel.GetComponentsInChildren<Graphic>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].raycastTarget = false;
			}
			Vector2 anchoredPosition = tooltipPanel.anchoredPosition;
			anchoredPosition.y = hiddenY;
			tooltipPanel.anchoredPosition = anchoredPosition;
			tooltipPanel.gameObject.SetActive(value: false);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(tooltipPanel == null))
		{
			UpdateIncomeText();
			Show();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!(tooltipPanel == null))
		{
			Hide();
		}
	}

	private void Show()
	{
		if (!isShowing)
		{
			isShowing = true;
			tooltipPanel.gameObject.SetActive(value: true);
			currentTween?.Kill();
			currentTween = tooltipPanel.DOAnchorPosY(shownY, slideDuration).SetEase(slideEase).SetUpdate(isIndependentUpdate: true);
		}
	}

	private void Hide()
	{
		if (isShowing)
		{
			isShowing = false;
			currentTween?.Kill();
			currentTween = tooltipPanel.DOAnchorPosY(hiddenY, slideDuration).SetEase(Ease.InBack).SetUpdate(isIndependentUpdate: true)
				.OnComplete(delegate
				{
					tooltipPanel.gameObject.SetActive(value: false);
				});
		}
	}

	private void Update()
	{
		if (isShowing)
		{
			UpdateIncomeText();
		}
	}

	private void UpdateIncomeText()
	{
		if (!(incomeText == null))
		{
			string text = CurrencyFormatter.FormatMoneyPrecise(CalculatePassiveIncomePerSecond());
			incomeText.text = text + " G/s";
			if (incomeTextShadow != null)
			{
				incomeTextShadow.text = incomeText.text;
			}
		}
	}

	private double CalculatePassiveIncomePerSecond()
	{
		if (GameManager.Instance == null)
		{
			return 0.0;
		}
		double num = 0.0;
		foreach (ZoneData allZone in GameManager.Instance.allZones)
		{
			num += (double)allZone.GetCurrentPassiveIncome();
		}
		if (PlayerStats.Instance != null)
		{
			num *= (double)PlayerStats.Instance.PassiveIncomeMultiplier;
			num += (double)PlayerStats.Instance.PassiveIncomeAdditive;
		}
		return num;
	}

	private void OnDisable()
	{
		currentTween?.Kill();
		if (tooltipPanel != null)
		{
			Vector2 anchoredPosition = tooltipPanel.anchoredPosition;
			anchoredPosition.y = hiddenY;
			tooltipPanel.anchoredPosition = anchoredPosition;
			tooltipPanel.gameObject.SetActive(value: false);
		}
		isShowing = false;
	}
}
