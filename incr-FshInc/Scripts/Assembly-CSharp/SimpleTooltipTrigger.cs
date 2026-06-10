using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Tooltip("The text to display in the tooltip.")]
	[SerializeField]
	public string tooltipText;

	[SerializeField]
	public string headerText;

	public bool showHeaderText;

	[Tooltip("The offset from this element's pivot where the tooltip should appear.")]
	[SerializeField]
	private Vector2 positionOffset;

	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (rectTransform == null)
		{
			rectTransform = GetComponent<RectTransform>();
		}
		if (SimpleTooltip.Instance != null)
		{
			SimpleTooltip.Instance.ShowTooltip(tooltipText, rectTransform, positionOffset, headerText, showHeaderText);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (SimpleTooltip.Instance != null)
		{
			SimpleTooltip.Instance.HideTooltip();
		}
	}

	private void OnDisable()
	{
		if (SimpleTooltip.Instance != null)
		{
			SimpleTooltip.Instance.HideTooltip();
		}
	}
}
