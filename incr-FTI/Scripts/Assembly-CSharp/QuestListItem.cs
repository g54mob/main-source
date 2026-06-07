using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestListItem : MenuButton, IPooledListItem
{
	public Quest quest;

	public ImageButton claimOverlayImageButton;

	public Image backgroundImage;

	public MenuButton claimRewardButton;

	public LayoutGroup progressBarLayoutGroup;

	public GameObject questProgressRowPrefab;

	public CostGrid rewardGrid;

	private readonly List<QuestProgressBar> progressBars = new List<QuestProgressBar>();

	private BackgroundFlashAnimation focusHighlight;

	public CanvasGroup canvas;

	private Flag questReadyFlag;

	public void Initialize()
	{
		claimOverlayImageButton.AddPointerClickTrigger(OnClaimButtonPressed);
		claimRewardButton.AddPointerClickTrigger(OnClaimButtonPressed);
		focusHighlight = new BackgroundFlashAnimation(backgroundImage);
		canvas = base.gameObject.AddComponent<CanvasGroup>();
	}

	public void LoadQuest(Quest q)
	{
		quest = q;
		questReadyFlag = Flag.Unknown;
		int num = 0;
		foreach (Requirement requirement in quest.completionRequirement.requirements)
		{
			QuestProgressBar questProgressBar = null;
			if (num >= progressBars.Count)
			{
				questProgressBar = MenuManager.GetMenuObject(questProgressRowPrefab, progressBarLayoutGroup.transform).GetComponent<QuestProgressBar>();
				questProgressBar.Initialize();
				progressBars.Add(questProgressBar);
			}
			else
			{
				questProgressBar = progressBars[num];
				questProgressBar.gameObject.SetActive(value: true);
			}
			questProgressBar.LoadRequirement(requirement);
			questProgressBar.UpdateStaticDisplay();
			num++;
		}
		int num2 = progressBars.Count - quest.completionRequirement.requirements.Count;
		if (num2 > 0)
		{
			int count = quest.completionRequirement.requirements.Count;
			for (int i = 0; i < num2; i++)
			{
				progressBars[count + i].gameObject.SetActive(value: false);
			}
		}
		rewardGrid.Clear();
		EntityLevel entityLevel = GameUtility.PrimaryReward(quest.def.derivedRewards);
		_ = entityLevel.entityId.type;
		if (quest.def.isPermanentResearchUnlock)
		{
			rewardGrid.AddReward(entityLevel.entityId, entityLevel.level, 0.0);
		}
		else if ((quest.questGroup != QuestGroup.Primary || entityLevel.entityId.type != EntityType.Quest) && entityLevel.entityId.type != EntityType.None)
		{
			rewardGrid.AddReward(entityLevel.entityId, entityLevel.level, 0.0);
		}
		if (quest.rewardItems != null)
		{
			foreach (KeyValuePair<ItemType, double> item in quest.rewardItems.items)
			{
				rewardGrid.AddReward(EntityId.FromItem(item.Key), 0, item.Value);
			}
		}
		rewardGrid.PerformLayout();
		((RectTransform)base.transform).SetHeight(q.layoutHeight);
	}

	public void ReloadLabel()
	{
		foreach (QuestProgressBar progressBar in progressBars)
		{
			if (progressBar.gameObject.activeInHierarchy)
			{
				progressBar.ReloadLabels();
			}
		}
	}

	public override void ResetPointerAndHighlightState()
	{
		base.ResetPointerAndHighlightState();
		claimOverlayImageButton.ResetPointerAndHighlightState();
	}

	public void OnStateAssignmentChanged()
	{
		_ = base.buttonState;
		UpdateStaticDisplay();
		UpdateSimulationDisplay();
		UpdateDynamicDisplay();
		ResetPointerAndHighlightState();
		AnimateInstant();
		claimOverlayImageButton.AnimateInstant();
	}

	public void UpdateSimulationDisplay()
	{
		foreach (QuestProgressBar progressBar in progressBars)
		{
			progressBar.UpdateSimulationDisplay();
		}
		UpdateButtonState();
	}

	public void UpdateDynamicDisplay()
	{
		foreach (QuestProgressBar progressBar in progressBars)
		{
			progressBar.UpdateDynamicDisplay();
		}
		focusHighlight?.UpdateAnimation();
	}

	public void UpdateStaticDisplay()
	{
		foreach (QuestProgressBar progressBar in progressBars)
		{
			if (progressBar.gameObject.activeInHierarchy)
			{
				progressBar.UpdateStaticDisplay();
			}
		}
		_ = quest.def.derivedRewards.Count;
		UpdateButtonState();
	}

	public void UpdateButtonState()
	{
		if (questReadyFlag == Flag.True)
		{
			return;
		}
		if (quest == null)
		{
			claimRewardButton.invalidReason = InvalidReason.QuestNotComplete;
			claimRewardButton.buttonState = CustomButtonState.Disabled;
		}
		else if (quest.IsReadyToClaim())
		{
			claimRewardButton.invalidReason = InvalidReason.None;
			if (GameManager.Instance.tutorialQuestType != QuestType.None)
			{
				claimRewardButton.buttonState = CustomButtonState.HighlightFlashing;
			}
			else
			{
				claimRewardButton.buttonState = CustomButtonState.BlueFlashing;
			}
			SetProgressBarsClickable(nextState: false);
			questReadyFlag = Flag.True;
		}
		else if (questReadyFlag != Flag.False)
		{
			claimRewardButton.invalidReason = InvalidReason.QuestNotComplete;
			claimRewardButton.buttonState = CustomButtonState.Disabled;
			SetProgressBarsClickable(nextState: true);
			questReadyFlag = Flag.False;
		}
	}

	private void SetProgressBarsClickable(bool nextState)
	{
		claimOverlayImageButton.iconImage.enabled = !nextState;
		foreach (QuestProgressBar progressBar in progressBars)
		{
			if (progressBar.TryGetComponent<Image>(out var component))
			{
				component.raycastTarget = nextState;
			}
		}
	}

	public void OnClaimButtonPressed()
	{
		if (claimRewardButton.invalidReason != InvalidReason.None)
		{
			foreach (QuestProgressBar progressBar in progressBars)
			{
				progressBar.FlashIfIncomplete();
			}
			MenuManager.Instance.ShowMessage(claimRewardButton.invalidReason);
		}
		else
		{
			ResetPointerAndHighlightState();
			GameManager.Instance.ClaimQuestIndividually(quest);
			UpdateButtonState();
		}
	}

	public new void AnimateFocusHighlight()
	{
		focusHighlight.Run();
	}

	public void SetVisible(bool visible)
	{
		canvas.alpha = (visible ? 1f : 0f);
		canvas.interactable = visible;
		canvas.blocksRaycasts = visible;
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
	}
}
