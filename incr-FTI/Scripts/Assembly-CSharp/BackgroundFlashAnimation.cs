using UnityEngine;
using UnityEngine.UI;

public class BackgroundFlashAnimation : CustomAnimation
{
	private readonly Image image;

	public Color original;

	public BackgroundFlashAnimation(Image target)
	{
		original = target.color;
		image = target;
		speed = 0.9f;
	}

	protected override void UpdateDisplay()
	{
		image.color = Color.Lerp(Color.yellow, original, progress);
	}
}
