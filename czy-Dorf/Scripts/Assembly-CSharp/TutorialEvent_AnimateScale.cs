using DG.Tweening;
using UnityEngine;

public class TutorialEvent_AnimateScale : TutorialEvent
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private float scaleDuration = 1f;

	[SerializeField]
	private AnimationCurve scaleCurve;

	[SerializeField]
	private Vector3 targetScale;

	[SerializeField]
	private Vector3 fromScale;

	[SerializeField]
	private bool setActive;

	public override void Begin()
	{
		if (setActive)
		{
			target.gameObject.SetActive(value: true);
		}
		TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(target, targetScale, scaleDuration), fromScale), scaleCurve);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
		if (setActive)
		{
			target.gameObject.SetActive(value: true);
		}
		ShortcutExtensions.DOScale(target, targetScale, 0f);
	}
}
