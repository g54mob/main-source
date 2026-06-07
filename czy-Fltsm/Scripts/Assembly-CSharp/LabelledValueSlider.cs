using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LabelledValueSlider : Slider, ITooltipProvider
{
	[SerializeField]
	private TextMeshProUGUI _mininumValueText;

	[SerializeField]
	private TextMeshProUGUI _maximumValueText;

	[SerializeField]
	private TextMeshProUGUI _valueText;

	[SerializeField]
	private string _format = "F0";

	[SerializeField]
	private LocalizedString _tooltip = null;

	protected override void Awake()
	{
		base.Awake();
		SetMinMaxValues(base.minValue, base.maxValue);
		_valueText.text = value.ToString(_format);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (Application.isPlaying)
		{
			TooltipPanel.HideTooltip(this);
		}
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		_valueText.text = value.ToString(_format);
	}

	public override void SetValueWithoutNotify(float input)
	{
		base.SetValueWithoutNotify(input);
		_valueText.text = value.ToString(_format);
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (!string.IsNullOrWhiteSpace(_tooltip))
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		TooltipPanel.HideTooltip(this);
	}

	public void SetMinMaxValues(float minimum, float maximum)
	{
		base.minValue = minimum;
		base.maxValue = maximum;
		_mininumValueText.text = minimum.ToString(_format);
		_maximumValueText.text = maximum.ToString(_format);
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _tooltip;
	}
}
