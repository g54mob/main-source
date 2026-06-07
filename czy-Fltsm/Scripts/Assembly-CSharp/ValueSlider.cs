using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : Slider
{
	[SerializeField]
	private TextMeshProUGUI _valueText;

	protected override void OnEnable()
	{
		base.OnEnable();
		base.onValueChanged.AddListener(OnValueChanged);
		OnValueChanged(value);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		base.onValueChanged.RemoveListener(OnValueChanged);
	}

	private void OnValueChanged(float amount)
	{
		_valueText.text = amount.ToString();
	}
}
