using UnityEngine;

public class ColorAnimation : AsciiAnimation
{
	public Color startColor = Color.black;

	public Color endColor = Color.white;

	public bool endWithSpriteColorInstead;

	public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	private Color spriteInitialColor;

	public override void UpdateWithDeltaTime(float delta)
	{
		base.UpdateWithDeltaTime(delta);
		UpdateColor();
	}

	public override void Play()
	{
		base.Play();
		UpdateColor();
	}

	private void UpdateColor()
	{
		float time = base.ElapsedTime / duration;
		time = curve.Evaluate(time);
		Color b = (endWithSpriteColorInstead ? spriteInitialColor : endColor);
		Color colorOverride = Color.Lerp(startColor, b, time);
		Sprite.colorOverride = colorOverride;
	}

	protected override void Awake()
	{
		base.Awake();
		spriteInitialColor = GetComponent<AsciiSprite>().colorOverride;
	}
}
