using System;
using Pug.UnityExtensions;
using UnityEngine;

public class PugTextEffectScroller : PugTextEffect
{
	public float speed = 5f;

	private TimerSimple timer = new TimerSimple(1f, unscaled: true);

	private float width;

	public override void ResetEffect(bool rewind)
	{
		if (!(base.text == null))
		{
			if (rewind)
			{
				timer.Start();
			}
			if (base.text.localPositionBackups.Count > 0)
			{
				width = base.text.localPositionBackups[base.text.localPositionBackups.Count - 1].x - base.text.localPositionBackups[0].x;
				width += 1f;
				width = Math.Max(35f, width);
			}
			else
			{
				width = 0f;
			}
		}
	}

	public override void PugTextEffectLateUpdate()
	{
		float x = base.transform.position.x;
		float num = Mathf.Repeat(timer.elapsedTime * speed, width);
		foreach (SpriteRenderer glyph in base.text.glyphs)
		{
			Transform obj = glyph.transform;
			float num2 = 0f - num;
			if (obj.position.x + num2 < x)
			{
				num2 += width;
			}
			obj.Translate(num2, 0f, 0f);
		}
	}
}
