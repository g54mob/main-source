using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClosingQuestFlag : MonoBehaviour
{
	[SerializeField]
	private float appearAnimationDuration = 0.5f;

	[SerializeField]
	private AnimationCurve appearCurve;

	[SerializeField]
	private float disappearAnimationDuration = 0.3f;

	[SerializeField]
	private float fulfilledPunchScale = 0.25f;

	[SerializeField]
	private MeshRenderer flag;

	[SerializeField]
	private Transform flagHighlight;

	[SerializeField]
	private InputRouter inputRouter;

	private Sequence flagAnimation;

	private Tween flagHighlightTween;

	[SerializeField]
	private AudioClipOptions appearSound;

	private void OnEnable()
	{
		inputRouter.OnHighlightQuests += Highlight;
	}

	private void Highlight(bool newHighlighted)
	{
		if (newHighlighted)
		{
			flagHighlight.gameObject.SetActive(value: true);
		}
		Tween tween = flagHighlightTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween);
		}
		flagHighlightTween = ShortcutExtensions.DOScale(flagHighlight, newHighlighted ? Vector3.one : new Vector3(1f, 0f, 1f), 0.2f);
		if (!newHighlighted)
		{
			TweenSettingsExtensions.OnComplete(flagHighlightTween, delegate
			{
				flagHighlight.gameObject.SetActive(value: false);
			});
		}
	}

	public void Show(bool newShow, bool animate = true)
	{
		if (newShow)
		{
			Sequence sequence = flagAnimation;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence);
			}
			base.gameObject.SetActive(value: true);
			flagAnimation = DOTween.Sequence();
			TweenSettingsExtensions.Insert(flagAnimation, 0f, TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(base.transform, 1f, animate ? appearAnimationDuration : 0f), 0f), appearCurve));
			if (animate)
			{
				AudioManager.Instance.PlaySoundAtPosition(appearSound, flag.transform.position);
			}
		}
		else
		{
			Sequence sequence2 = flagAnimation;
			if (sequence2 != null)
			{
				TweenExtensions.Kill(sequence2);
			}
			flagAnimation = DOTween.Sequence();
			TweenSettingsExtensions.Insert(flagAnimation, 0f, ShortcutExtensions.DOScale(base.transform, 0f, animate ? disappearAnimationDuration : 0f));
		}
	}

	public void ExecuteQuestStatus(FulfillmentStatus questFulfillmentStatus)
	{
		switch (questFulfillmentStatus)
		{
		case FulfillmentStatus.Changed:
			return;
		case FulfillmentStatus.Unchanged:
			return;
		case FulfillmentStatus.Fulfilled:
		{
			Sequence sequence2 = flagAnimation;
			if (sequence2 != null)
			{
				TweenExtensions.Kill(sequence2, complete: true);
			}
			flagAnimation = DOTween.Sequence();
			TweenSettingsExtensions.Insert(flagAnimation, 0f, ShortcutExtensions.DOPunchScale(base.transform, Vector3.one * fulfilledPunchScale, 0.5f));
			break;
		}
		case FulfillmentStatus.Unfulfillable:
		{
			Sequence sequence = flagAnimation;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			flagAnimation = DOTween.Sequence();
			TweenSettingsExtensions.Insert(flagAnimation, 0f, ShortcutExtensions.DOShakeRotation(base.transform, 0.5f, 30f));
			break;
		}
		}
		TweenSettingsExtensions.Insert(flagAnimation, 0f, TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(base.transform, 0f, 0.5f), Ease.InCubic), 2.5f), delegate
		{
			base.gameObject.SetActive(value: false);
		}));
	}

	public void Setup(List<Quest> questQueue, QuestTile questTile)
	{
		flag.material.SetColor("_BaseColor", questQueue[0].groupType.color);
	}

	private void OnDisable()
	{
		inputRouter.OnHighlightQuests -= Highlight;
	}

	private void _003CHighlight_003Eb__11_0()
	{
		flagHighlight.gameObject.SetActive(value: false);
	}

	private void _003CExecuteQuestStatus_003Eb__13_0()
	{
		base.gameObject.SetActive(value: false);
	}
}
