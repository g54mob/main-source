using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SinglePurchaseRow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Parent;

	private TMP_Text _rowLabel;

	private Button _rowButton;

	private TMP_Text _rowButtonText;

	private string _tooltipText = "";

	public event EventHandler ButtonPressEvent;

	private void Awake()
	{
		_rowLabel = base.transform.Find("RowLabel").GetComponent<TMP_Text>();
		_rowButton = base.transform.Find("RowButton").GetComponent<Button>();
		_rowButtonText = _rowButton.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
		_rowButton.onClick.AddListener(RowButtonClick);
	}

	public void ChangeLabel(string label)
	{
		_rowLabel.text = label;
	}

	public void ChangeCost(string cost)
	{
		_rowButtonText.text = cost;
	}

	public void ChangeTooltip(string text)
	{
		_tooltipText = text;
	}

	public void ShowButton(bool isVisible)
	{
		_rowButton.gameObject.SetActive(isVisible);
	}

	private void RowButtonClick()
	{
		this.ButtonPressEvent?.Invoke(this, EventArgs.Empty);
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
