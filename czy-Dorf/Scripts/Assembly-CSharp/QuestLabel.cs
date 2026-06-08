using System.Collections.Generic;
using DG.Tweening;
using Dorfromantik.UI;
using UnityEngine;

public class QuestLabel : MonoBehaviour, ITileStateReceiver
{
	[SerializeField]
	private QuestUiComponentLibrary questComponentLibrary;

	[SerializeField]
	private QuestBubble questBubble;

	[SerializeField]
	private GameObject questBubbleTrigger;

	[SerializeField]
	private float fulfilledPunchScale = 0.25f;

	[SerializeField]
	private UiScalingManager uiScalingManager;

	private QuestTile questTile;

	private Quest quest;

	private Quest followQuest;

	private bool active = true;

	private Sequence feedbackAnimation;

	public void Setup(List<Quest> questQueue, QuestTile questTile)
	{
		this.questTile = questTile;
		quest = questQueue[0];
		followQuest = ((questQueue.Count > 1) ? questQueue[1] : null);
		questBubble = GetComponentInChildren<QuestBubble>();
		questBubble.Setup(quest, followQuest);
	}

	public void UpdateConditionStatus(int conditionIndex, FulfillmentStatus conditionFulfilled, int currentCount, int targetCount)
	{
		questBubble.UpdateConditionStatus(conditionIndex, conditionFulfilled, currentCount, targetCount);
	}

	public void UpdateQuestStatus(FulfillmentStatus questStatus)
	{
		questBubble.UpdateBubbleColor(questStatus);
	}

	public void ExecuteQuestStatus(FulfillmentStatus questStatus)
	{
		Sequence sequence = feedbackAnimation;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence, complete: true);
		}
		feedbackAnimation = DOTween.Sequence();
		switch (questStatus)
		{
		case FulfillmentStatus.Changed:
			return;
		case FulfillmentStatus.Unchanged:
			return;
		case FulfillmentStatus.Fulfilled:
			TweenSettingsExtensions.Insert(feedbackAnimation, 0f, ShortcutExtensions.DOPunchScale(questBubble.transform, Vector3.one * fulfilledPunchScale, 0.5f));
			break;
		case FulfillmentStatus.Unfulfillable:
			TweenSettingsExtensions.Insert(feedbackAnimation, 0f, ShortcutExtensions.DOShakeRotation(questBubble.transform, 0.5f, 30f));
			break;
		}
		if (!followQuest || followQuest.displayType != QuestDisplayType.Bubble || questStatus == FulfillmentStatus.Unfulfillable)
		{
			Activate(shouldActivate: false, animate: true);
		}
	}

	public void Flip(bool animate = true)
	{
		quest = followQuest;
		followQuest = null;
		questBubble.Flip(animate);
	}

	public void SetSessionQuest(SessionQuest sessionQuest)
	{
		questBubble.SetSessionQuest(sessionQuest);
	}

	public void ChangeTileState(TileState targetState)
	{
		if (!active)
		{
			base.gameObject.SetActive(value: false);
		}
		switch (targetState)
		{
		case TileState.stacked:
			base.gameObject.SetActive(value: false);
			break;
		case TileState.stackPreview:
			base.gameObject.SetActive(value: false);
			break;
		case TileState.topStackPreview:
		case TileState.placementPreview:
			if (OverwritingSingleton<GameSession>.Instance.GameMode.spawnsQuests)
			{
				questBubbleTrigger.gameObject.SetActive(value: false);
				Activate(shouldActivate: true, animate: true);
			}
			break;
		case TileState.placed:
			questBubbleTrigger.gameObject.SetActive(value: true);
			break;
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
		if (targetLayer == 10)
		{
			targetLayer = 11;
		}
		base.gameObject.layer = targetLayer;
		if ((bool)questBubble)
		{
			questBubble.SetRendererLayer(targetLayer);
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
	}

	public void SetTileReference(Tile tile)
	{
	}

	public void Expand(bool newExpand)
	{
	}

	public void Activate(bool shouldActivate, bool animate)
	{
		if (shouldActivate)
		{
			if (!animate)
			{
				goto IL_00d7;
			}
			Sequence sequence = feedbackAnimation;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			feedbackAnimation = DOTween.Sequence();
			base.gameObject.SetActive(value: true);
			TweenSettingsExtensions.Insert(feedbackAnimation, 0f, ShortcutExtensions.DOScale(base.transform, ((bool)questTile && questTile.State == TileState.topStackPreview) ? uiScalingManager.DefaultQuestBubbleScale : uiScalingManager.CurrentQuestBubbleScale, 0.3f));
		}
		else
		{
			if (!animate)
			{
				goto IL_00d7;
			}
			TweenSettingsExtensions.Insert(feedbackAnimation, 0f, TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(base.transform, 0f, 0.5f), Ease.InCubic), 2.5f), delegate
			{
				Activate(shouldActivate: false, animate: false);
			}));
		}
		goto IL_00f5;
		IL_00d7:
		Sequence sequence2 = feedbackAnimation;
		if (sequence2 != null)
		{
			TweenExtensions.Kill(sequence2, complete: true);
		}
		base.gameObject.SetActive(shouldActivate);
		goto IL_00f5;
		IL_00f5:
		active = shouldActivate;
	}

	public void ChangeScale(float newScale)
	{
		if (questTile.State != TileState.topStackPreview && active)
		{
			if (feedbackAnimation != null && feedbackAnimation.active && !TweenExtensions.IsComplete(feedbackAnimation))
			{
				TweenSettingsExtensions.Append(feedbackAnimation, ShortcutExtensions.DOScale(base.transform, newScale, 0.1f));
			}
			else
			{
				base.transform.localScale = new Vector3(newScale, newScale, newScale);
			}
		}
	}

	private void _003CActivate_003Eb__21_0()
	{
		Activate(shouldActivate: false, animate: false);
	}
}
