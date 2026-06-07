using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameSettingItem_Slider : AUIGameSettingItem
{
	[SerializeField]
	protected Slider slider;

	[SerializeField]
	protected TMP_Text text_Value;

	[SerializeField]
	[Header("最小值")]
	protected int minValue;

	[SerializeField]
	[Header("最大值")]
	protected int maxValue;

	private float sliderInputCooldown;

	protected override void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnSliderChanged(float value)
	{
	}

	protected override void ApplySetting()
	{
	}

	protected override void ResetToDefault()
	{
	}

	protected override void UpdateDisplay()
	{
	}
}
