using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatsRow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Parent;

	private TMP_Text _rowLabel;

	private TMP_Text _rowValueLabel;

	private string _tooltipText = "";

	private void Awake()
	{
		_rowLabel = base.transform.Find("RowLabel").GetComponent<TMP_Text>();
		_rowValueLabel = base.transform.Find("RowValueLabel").GetComponent<TMP_Text>();
	}

	public void ChangeLabel(string label)
	{
		_rowLabel.text = label;
	}

	public void ChangeValue(string value)
	{
		_rowValueLabel.text = value;
	}

	public void ChangeTooltip(string text)
	{
		_tooltipText = text;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(_tooltipText))
		{
			TooltipPanel.Instance.ShowTooltip(Parent, base.gameObject, _tooltipText);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipPanel.Instance.HideTooltip();
	}
}
