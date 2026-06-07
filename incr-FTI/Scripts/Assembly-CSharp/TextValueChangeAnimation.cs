using System;
using DG.Tweening;
using TMPro;

public class TextValueChangeAnimation : CustomAnimation
{
	private readonly TextMeshProUGUI label;

	private double displayedValue;

	private double startValue;

	private double endValue;

	public bool useRounded;

	public TextValueChangeAnimation(TextMeshProUGUI target)
	{
		label = target;
		speed = 3f;
	}

	public void DisplayValue(double v)
	{
		displayedValue = v;
		if (useRounded)
		{
			TextDisplay.SetNumber(label, Math.Floor(displayedValue));
		}
		else
		{
			TextDisplay.SetNumber(label, displayedValue);
		}
	}

	public void AnimateToValue(double next)
	{
		startValue = displayedValue;
		endValue = next;
		Run();
	}

	protected override void UpdateDisplay()
	{
		float t = DOVirtual.EasedValue(0f, 1f, progress, Ease.OutQuad);
		DisplayValue(GameUtility.Lerp(startValue, endValue, t));
	}
}
