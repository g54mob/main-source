using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductionGraphDotTooltipEnabler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	[SerializeField]
	private GameObject _tooltip;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private TextMeshProUGUI _textText;

	public void SetText(string title, string amount)
	{
		_nameText.SetText(title);
		_textText.SetText(amount);
	}

	public void SetAmountText(string amount)
	{
		_textText.SetText(amount);
	}

	private void OnEnable()
	{
		if (_tooltip != null)
		{
			_tooltip.SetActive(value: false);
		}
	}

	private void OnDisable()
	{
		if (_tooltip != null)
		{
			_tooltip.SetActive(value: false);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (_tooltip != null)
		{
			_tooltip.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (_tooltip != null)
		{
			_tooltip.SetActive(value: false);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_tooltip != null)
		{
			_tooltip.SetActive(value: false);
		}
	}
}
