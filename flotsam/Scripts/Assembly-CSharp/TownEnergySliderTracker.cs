using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownEnergySliderTracker : TownEnergyTracker
{
	[SerializeField]
	private Slider _energySlider;

	[SerializeField]
	private TextMeshProUGUI _energyAmountText;

	[SerializeField]
	private bool _showEnergyAsPercentage = true;

	[SerializeField]
	private Image _border;

	[SerializeField]
	private Color _borderColorCooldown;

	[SerializeField]
	[Range(1f, 100f)]
	private float _borderColorLerpSpeed = 5f;

	[SerializeField]
	private Image _bar;

	[SerializeField]
	private Color _barColorCooldown;

	private Color _borderColorDefault;

	private Color _barColorDefault;

	private float _currentValue;

	private float _currentValueMax;

	protected override void Awake()
	{
		base.Awake();
		_borderColorDefault = _border.color;
		_barColorDefault = _bar.color;
	}

	protected override void Update()
	{
		base.Update();
		if (Engine.IsCoolingDown)
		{
			float num = Engine.CooldownStartTime - Time.realtimeSinceStartup;
			_border.color = Color.Lerp(_borderColorDefault, _borderColorCooldown, (Mathf.Cos(num * _borderColorLerpSpeed) + 1f) / 2f);
		}
		else
		{
			_border.color = _borderColorDefault;
		}
	}

	public override void SetValue(float value, float valueMax)
	{
		if (_currentValue != value || _currentValueMax != valueMax)
		{
			_currentValue = value;
			_currentValueMax = valueMax;
			float num = ((valueMax > 0f) ? (value / valueMax) : 0f);
			_energySlider.value = num;
			_energyAmountText.text = (_showEnergyAsPercentage ? $"{num:0%}" : $"{value:F0}/{valueMax:F0}");
		}
	}
}
