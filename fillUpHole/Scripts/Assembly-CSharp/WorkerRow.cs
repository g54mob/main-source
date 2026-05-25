using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkerRow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject Parent;

	private TMP_Text _rowLabel;

	private TMP_Text _rowValueLabel;

	private Button _minusButton;

	private TMP_Text _minusButtonText;

	private Button _plusButton;

	private TMP_Text _plusButtonText;

	private string _tooltipTitle = "";

	private string _tooltipText = "";

	private Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> _dynamicTooltip;

	public event EventHandler MinusPressEvent;

	public event EventHandler PlusPressEvent;

	private void Awake()
	{
		_rowLabel = base.transform.Find("RowLabel").GetComponent<TMP_Text>();
		_rowValueLabel = base.transform.Find("RowValueLabel").GetComponent<TMP_Text>();
		_minusButton = base.transform.Find("MinusButton").GetComponent<Button>();
		_minusButtonText = _minusButton.transform.Find("ButtonText").GetComponent<TMP_Text>();
		_plusButton = base.transform.Find("PlusButton").GetComponent<Button>();
		_plusButtonText = _plusButton.transform.Find("ButtonText").GetComponent<TMP_Text>();
		_minusButton.onClick.AddListener(MinusButtonClick);
		_plusButton.onClick.AddListener(PlusButtonClick);
	}

	private void Start()
	{
	}

	public void Initialize(GameObject parent, string label, string tooltip = "")
	{
		Parent = parent;
		SetLabel(label);
		SetTooltip(tooltip);
	}

	public void SetLabel(string label)
	{
		_rowLabel.text = label;
	}

	public void SetValue(string value)
	{
		_rowValueLabel.text = value;
	}

	public void SetTooltip(string text)
	{
		_tooltipText = text;
		_dynamicTooltip = null;
	}

	public void SetTooltip(string title, string text)
	{
		_tooltipTitle = title;
		_tooltipText = text;
		_dynamicTooltip = null;
	}

	public void SetDynamicTooltip(Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> tooltipInfo)
	{
		_tooltipTitle = "";
		_tooltipText = "";
		_dynamicTooltip = tooltipInfo;
	}

	public void HideButton()
	{
		_minusButton.gameObject.SetActive(value: false);
		_plusButton.gameObject.SetActive(value: false);
	}

	public void ShowButton()
	{
		_minusButton.gameObject.SetActive(value: true);
		_plusButton.gameObject.SetActive(value: true);
	}

	private void MinusButtonClick()
	{
		this.MinusPressEvent?.Invoke(this, EventArgs.Empty);
	}

	private void PlusButtonClick()
	{
		this.PlusPressEvent?.Invoke(this, EventArgs.Empty);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(_tooltipText) || _dynamicTooltip != null)
		{
			if (_dynamicTooltip == null)
			{
				TooltipPanel.Instance.ShowTooltip(Parent, base.gameObject, _tooltipTitle, _tooltipText);
			}
			else
			{
				TooltipPanel.Instance.ShowDynamicTooltip(Parent, base.gameObject, _dynamicTooltip);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipPanel.Instance.HideTooltip();
	}
}
