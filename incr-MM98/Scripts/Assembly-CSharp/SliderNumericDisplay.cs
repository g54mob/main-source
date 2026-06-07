using UnityEngine;
using UnityEngine.UI;

public class SliderNumericDisplay : ValueNumericDisplay
{
	[SerializeField]
	private Slider slider;

	[SerializeField]
	private double maxValue = 100.0;

	public override void Animate(double number, string format, float duration)
	{
		base.Animate(number, format, duration);
		UpdateSlider();
	}

	private void UpdateSlider()
	{
		slider.normalizedValue = Mathf.Clamp01((float)(Number.GetValueOrDefault() / maxValue));
	}
}
