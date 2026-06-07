using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiseasePanel : TooltipTriggerBase, ITooltipProvider
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private Slider _timerSlider;

	private Disease _disease;

	public void Initialize(Disease disease)
	{
		_disease = disease;
		_icon.sprite = disease.Icon.Sprite;
		_name.text = disease.Name;
	}

	protected override void Update()
	{
		base.Update();
		if ((bool)_disease)
		{
			_timerSlider.value = 1f - _disease.NormalizedProgress;
		}
	}

	protected override void OnPointerEnter()
	{
		if ((bool)_disease)
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	protected override void OnPointerExit()
	{
		TooltipPanel.HideTooltip(this);
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		if (!_disease)
		{
			return string.Empty;
		}
		return _disease.GetTooltip(tooltipBuilder);
	}
}
