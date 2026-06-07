using TMPro;
using UnityEngine;

public class TextFlashAnimation : CustomAnimation
{
	private readonly TextMeshProUGUI label;

	public TextFlashAnimation(TextMeshProUGUI target)
	{
		label = target;
		speed = 0.75f;
	}

	protected override void UpdateDisplay()
	{
		float t = GameUtility.ClampedCurve(progress * 3f);
		Color color = Color.Lerp(Color.white, Color.red, t);
		label.color = color;
	}
}
