using Pug.UnityExtensions;
using UnityEngine;

public class PugTextEffectFade : PugTextEffect
{
	public AnimationCurve fadeInCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve fadeOutCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	public float fadeInTime = 0.5f;

	public float fadeOutTime = 0.5f;

	public bool fadeInOnReset;

	private AnimationCurve currentCurve;

	private TimerSimple timer;

	public bool isFading
	{
		get
		{
			if (timer.isRunning)
			{
				return !timer.isTimerElapsed;
			}
			return false;
		}
	}

	public void OnEnable()
	{
		ResetEffect(rewind: true);
	}

	public override void ResetEffect(bool rewind)
	{
		if (base.text == null)
		{
			return;
		}
		if (!rewind)
		{
			timer.Stop();
			base.text.SetTempColor(base.text.style.color);
			return;
		}
		Color glyphsColor = base.text.GetGlyphsColor();
		base.text.SetTempColor(glyphsColor);
		timer.Stop();
		if (fadeInOnReset)
		{
			FadeIn();
		}
	}

	private void StartFade(AnimationCurve curve, float lifespan)
	{
		currentCurve = curve;
		Color glyphsColor = base.text.GetGlyphsColor();
		glyphsColor.a *= curve.Evaluate(0f);
		base.text.SetTempColor(glyphsColor);
		timer.Start(lifespan);
	}

	public void FadeIn()
	{
		StartFade(fadeInCurve, fadeInTime);
	}

	public void FadeOut()
	{
		StartFade(fadeOutCurve, fadeOutTime);
	}

	public override void PugTextEffectLateUpdate()
	{
		if (timer.isRunning)
		{
			Color glyphsColor = base.text.GetGlyphsColor();
			if (timer.isTimerElapsed)
			{
				timer.Stop();
				glyphsColor.a = currentCurve.Evaluate(1f);
			}
			else
			{
				glyphsColor.a = currentCurve.Evaluate(timer.elapsedRatio);
			}
			base.text.SetTempColor(glyphsColor);
		}
	}

	public float GetCurrentCurveValue()
	{
		if (currentCurve == null)
		{
			return 0f;
		}
		return currentCurve.Evaluate(timer.elapsedRatio);
	}
}
