using UnityEngine;

public class PugTextEffectMaxFade : PugTextEffect
{
	public AnimationCurve fadeInCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve fadeOutCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	public float fadeInTime = 0.5f;

	public float fadeOutTime = 0.5f;

	private float current;

	private bool fadeOut;

	private bool fadeIn;

	public void FadeIn()
	{
		fadeIn = true;
		fadeOut = false;
	}

	public void FadeOut()
	{
		fadeIn = false;
		fadeOut = true;
	}

	protected override void Awake()
	{
		base.Awake();
		current = 1f;
	}

	public override void ResetEffect(bool rewind)
	{
		if (rewind)
		{
			current = 1f;
		}
		else if (fadeIn)
		{
			current = 0f;
		}
		else if (fadeOut)
		{
			current = 1f;
		}
		fadeIn = (fadeOut = false);
	}

	public override void PugTextEffectLateUpdate()
	{
		float deltaTime = Time.deltaTime;
		Color color = base.text.style.color;
		if (fadeIn)
		{
			current = Mathf.Clamp01(current + deltaTime / fadeInTime);
			color.a *= fadeInCurve.Evaluate(current);
		}
		else if (fadeOut)
		{
			current = Mathf.Clamp01(current - deltaTime / fadeOutTime);
			color.a *= fadeOutCurve.Evaluate(1f - current);
		}
		base.text.SetTempColor(color);
	}
}
