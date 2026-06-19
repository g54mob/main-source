using UnityEngine;

public class PugTextEffectJump : PugTextEffect
{
	public float intensity = 1f;

	public float speed = 10f;

	public float phase = 0.5f;

	public float globalPhase;

	public bool unscaledTime = true;

	public bool applyRotation;

	public bool applyBounceColor;

	public Color bounceColor = Color.white;

	public float time
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
		for (int i = 0; i < base.text.glyphs.Count; i++)
		{
			SpriteRenderer spriteRenderer = base.text.glyphs[i];
			Transform transform = spriteRenderer.transform;
			float f = speed * time + phase * (float)i + globalPhase;
			if (applyRotation)
			{
				transform.Rotate(0f, 0f, 10f * Mathf.Sin(f));
			}
			transform.Translate(0f, intensity * Mathf.Abs(Mathf.Sin(f)) / 16f, 0f);
			if (applyBounceColor)
			{
				float t = 1f - Mathf.Abs(Mathf.Sin(f));
				spriteRenderer.color = Color.Lerp(base.text.style.color, bounceColor, t);
			}
		}
	}
}
