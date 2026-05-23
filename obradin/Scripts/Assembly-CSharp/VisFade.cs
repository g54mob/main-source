using UnityEngine;

public class VisFade : MonoBehaviour
{
	public LightDimmerKnob lightDimmerKnob;

	private float speed = 2f;

	private float alpha = 1f;

	private float targetAlpha = 1f;

	public bool visible
	{
		set
		{
			targetAlpha = ((!value) ? 0f : 1f);
			if (value && !base.gameObject.activeSelf)
			{
				alpha = 0f;
				base.gameObject.SetActive(true);
			}
		}
	}

	private void Update()
	{
		float num = alpha;
		if (alpha < targetAlpha)
		{
			alpha = Mathf.Min(targetAlpha, alpha + Clock.play.deltaTime * speed);
		}
		else
		{
			alpha = Mathf.Max(targetAlpha, alpha - Clock.play.deltaTime * speed);
		}
		if (num != alpha)
		{
			if (lightDimmerKnob != null)
			{
				lightDimmerKnob.illum = alpha;
			}
			else if (targetAlpha < 0.001f && Mathf.Abs(targetAlpha - alpha) < 0.001f)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
