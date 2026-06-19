using UnityEngine;

public class PugTextEffectBlink : PugTextEffect
{
	public bool unscaledTime;

	public int rate = 1;

	private float time
	{
		get
		{
			if (!unscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}
	}

	public override void PugTextEffectLateUpdate()
	{
		bool flag = Mathf.FloorToInt(time * 60f) % (2 * rate) < rate;
		foreach (SpriteRenderer glyph in base.text.glyphs)
		{
			glyph.enabled = flag;
		}
	}

	private void OnDisable()
	{
		foreach (SpriteRenderer glyph in base.text.glyphs)
		{
			glyph.enabled = true;
		}
	}
}
