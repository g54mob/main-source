using DG.Tweening;
using UnityEngine;

public class Wiggler : MonoBehaviour
{
	[SerializeField]
	private float defaultWiggleStrength = 30f;

	[SerializeField]
	private float defaultWiggleDuration = 0.3f;

	[SerializeField]
	private Vector3 rotationWiggleAxis = Vector3.up;

	private Sequence wiggleAnimation;

	private bool canBeKilled = true;

	public void Wiggle(float strengthMultiplier = 1f, float durationMultiplier = 1f, bool killWiggle = true)
	{
		if (canBeKilled || killWiggle)
		{
			Sequence sequence = wiggleAnimation;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			wiggleAnimation = DOTween.Sequence();
			TweenSettingsExtensions.Append(wiggleAnimation, ShortcutExtensions.DOPunchRotation(base.transform, rotationWiggleAxis * defaultWiggleStrength * strengthMultiplier, defaultWiggleDuration * durationMultiplier));
			canBeKilled = false;
			TweenSettingsExtensions.InsertCallback(wiggleAnimation, defaultWiggleDuration * durationMultiplier * 0.5f, delegate
			{
				canBeKilled = true;
			});
		}
	}

	private void _003CWiggle_003Eb__5_0()
	{
		canBeKilled = true;
	}
}
