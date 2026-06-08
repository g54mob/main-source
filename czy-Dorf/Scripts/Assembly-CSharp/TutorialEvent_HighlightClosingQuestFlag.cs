using DG.Tweening;
using UnityEngine;

public class TutorialEvent_HighlightClosingQuestFlag : TutorialEvent
{
	[SerializeField]
	private QuestManager questManager;

	private QuestWatcher targetQuestWatcher;

	private Sequence highlightingTween;

	public override void Begin()
	{
		questManager.OnQuestAdded += StartAnimation;
	}

	private void StartAnimation(QuestWatcher targetQuestWatcher)
	{
		ClosingQuestFlag closingQuestFlag = targetQuestWatcher.ClosingQuestFlag;
		highlightingTween = DOTween.Sequence();
		TweenSettingsExtensions.Append(highlightingTween, TweenSettingsExtensions.From(ShortcutExtensions.DOScale(closingQuestFlag.transform, 1.5f, 2f), 1f));
		TweenSettingsExtensions.SetLoops(highlightingTween, -1, LoopType.Yoyo);
	}

	public override void Finish()
	{
		questManager.OnQuestAdded -= StartAnimation;
		Sequence sequence = highlightingTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence, complete: true);
		}
	}

	public override void Skip()
	{
	}
}
