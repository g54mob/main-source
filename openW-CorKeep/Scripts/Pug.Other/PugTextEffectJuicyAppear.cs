using System;
using Pug.UnityExtensions;
using UnityEngine;

public class PugTextEffectJuicyAppear : PugTextEffect
{
	public Transform centerPoint;

	public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

	public float eloignement = 10f;

	public float maxScale = 2f;

	public float glyphDuration = 1f;

	private TimerSimple[] glyphTimers;

	public override void ResetEffect(bool rewind)
	{
		if (base.text == null)
		{
			return;
		}
		if (glyphTimers == null || glyphTimers.Length < base.text.glyphs.Count)
		{
			glyphTimers = new TimerSimple[Math.Max(32, 2 * base.text.glyphs.Count)];
		}
		for (int i = 0; i < base.text.glyphs.Count; i++)
		{
			TimerSimple timerSimple = new TimerSimple(glyphDuration, unscaled: true);
			if (rewind)
			{
				timerSimple.DelayedStart(UnityEngine.Random.Range(0f, 0.3f));
			}
			glyphTimers[i] = timerSimple;
		}
	}

	public override void PugTextEffectLateUpdate()
	{
		for (int i = 0; i < base.text.glyphs.Count; i++)
		{
			TimerSimple timerSimple = glyphTimers[i];
			if (!timerSimple.isRunning)
			{
				base.text.glyphs[i].enabled = true;
				continue;
			}
			float num;
			if (!timerSimple.isTimerElapsed && timerSimple.elapsedRatio < 0f)
			{
				base.text.glyphs[i].enabled = false;
				num = curve.Evaluate(0f);
			}
			else
			{
				base.text.glyphs[i].enabled = true;
				if (!timerSimple.isTimerElapsed)
				{
					num = curve.Evaluate(timerSimple.elapsedRatio);
				}
				else
				{
					num = 0f;
					if (timerSimple.isTimerElapsed)
					{
						glyphTimers[i].Stop();
					}
				}
			}
			SpriteRenderer spriteRenderer = base.text.glyphs[i];
			Vector2 vector = spriteRenderer.transform.Position2D() - centerPoint.transform.Position2D();
			spriteRenderer.transform.Translate(vector * num * eloignement);
			spriteRenderer.transform.localScale *= 1f + num * (maxScale - 1f);
		}
	}
}
