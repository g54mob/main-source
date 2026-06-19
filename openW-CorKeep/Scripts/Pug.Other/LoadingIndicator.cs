using Pug.UnityExtensions;
using UnityEngine;

public class LoadingIndicator : MonoBehaviour
{
	public SimpleSpriteAnimationLoop visuals;

	public AnimationCurve fadeCurve;

	private void Awake()
	{
		visuals.gameObject.SetActive(value: false);
	}

	private void LateUpdate()
	{
		bool flag = Manager.load.IsScreenFadingIn();
		float fadeValue = Manager.load.GetFadeValue();
		bool flag2 = (flag ? (fadeValue < 0.5f) : (fadeValue < 0.9f));
		if (visuals.gameObject.activeSelf != flag2)
		{
			visuals.gameObject.SetActive(flag2);
			if (flag2)
			{
				visuals.ResetTimer();
			}
		}
		if (flag2)
		{
			if (flag)
			{
				visuals.SetAlpha(fadeCurve.Evaluate((0.5f - fadeValue) * 2f));
			}
			else
			{
				visuals.SetAlpha(fadeCurve.Evaluate(1f - fadeValue));
			}
		}
	}
}
