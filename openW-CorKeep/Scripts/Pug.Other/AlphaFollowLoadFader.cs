using UnityEngine;

public class AlphaFollowLoadFader : MonoBehaviour
{
	public float loadFaderOffset;

	private float defaultAlpha;

	private SpriteRenderer spriteRenderer;

	private float prevFadeValue = -1f;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultAlpha = spriteRenderer.color.a;
	}

	private void Update()
	{
		float fadeValue = Manager.load.GetFadeValue();
		if (fadeValue != prevFadeValue)
		{
			prevFadeValue = fadeValue;
			float a = Mathf.Clamp01(fadeValue + loadFaderOffset) * defaultAlpha;
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
		}
	}
}
