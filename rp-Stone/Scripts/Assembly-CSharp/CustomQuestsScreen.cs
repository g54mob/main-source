using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomQuestsScreen : ScrollContainerScreen, IActivatable
{
	public enum State
	{
		Normal = 0,
		QuestStoneActivation1 = 1,
		QuestStoneActivation2 = 2,
		QuestStoneActivation3 = 3,
		EventRewardsScreen = 4,
		EventLeaderboardScreen = 5,
		EventLastChancePremium = 6,
		GenericInfoDialog = 7,
		RewardDialog = 8,
		AbandonQuestConfirmation = 9,
		ChangeActiveQuestConfirmation = 10,
		OpeningTreasure = 11
	}

	public CustomQuestsRowBasic rowBasicPrefab;

	public CustomQuestsRowAdvanced rowAdvancedPrefab;

	public WeeklyQuestsRow rowWeekly;

	public ReferralQuestRow rowReferral;

	public DialogButton unlockBasicsRow;

	public CustomQuestsRowNextTime nextTimeRow;

	public CustomQuestsRowTotalCount totalCountRow;

	public AsciiAnimation questStoneActivationAnim;

	public CustomQuestsConfirmationAbandon abandonQuestConfirmation;

	public CustomQuestsConfirmationChange changeActiveQuestConfirmation;

	public EventQuestRow eventRow;

	public EventRewardsScreen eventRewardsScreen;

	public EventLeaderboardScreen eventLeaderboardScreen;

	public EventLastChanceDialog eventLastChanceDialog;

	public EventCompletedDialog rewardDialog;

	public OneChoiceIconDialog genericInfoDialog;

	private int stateElapsedTime;

	private ModalFade fade;

	private DialogButton lastPressedAdvancedRow;

	private bool isDirty = true;

	private bool forceFocusOnActiveEpic = true;

	private int lastGridWidth;

	private int lastGridHeight;

	private bool scheduledUpdateContainerPosition;

	private Data.CustomQuestInstance abandonQuest;

	private Data.CustomQuest replayQuestDef;

	private DateTime lastDateTime;

	public State currentState { get; private set; }

	public DialogButton focusedRow { get; set; }

	public bool hasInteractedWithEpic { get; set; }

	public static string[] deepLinkParams { get; set; }

	public override void Activate()
	{
		CheckDailyRefresh();
		if (isDirty)
		{
			forceFocusOnActiveEpic = true;
			UpdateContents();
		}
		if (ReferralController.singleton.data == null && WeeklyQuestsController.singleton.questCount >= 2)
		{
			ReferralController.singleton.UnlockReferralQuest();
		}
		else if (!SaveFiles.singleton.isLoading)
		{
			ReferralController.singleton.UpdateReferralQuestData();
		}
	}

	private void OnApplicationFocus(bool value)
	{
		if (value && GameStates.Singleton.CurrentState == GameStates.State.CustomQuests)
		{
			ReferralController.singleton.UpdateReferralQuestData();
		}
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Normal:
			GameStates.Singleton.ShowMouse();
			break;
		case State.QuestStoneActivation1:
			GameStates.Singleton.HideMouse();
			fade.active = true;
			questStoneActivationAnim.Stop();
			questStoneActivationAnim.Sprite.SetFrameIndex(0);
			break;
		case State.QuestStoneActivation2:
			questStoneActivationAnim.Play();
			SfxController.singleton.Play("quest_stone_unlock");
			break;
		case State.QuestStoneActivation3:
		{
			fade.active = false;
			GameStates.Singleton.navBar.questStoneButton.SetState(QuestStoneNavButton.State.Idle);
			bool flag = false;
			if (CustomQuestsController.Singleton.ftueStep == CustomQuestsController.FTUEStep.UnlockBasicQuests)
			{
				CustomQuestsController.Singleton.ftueStep = CustomQuestsController.FTUEStep.CompleteFirstBasicQuest;
				flag = true;
			}
			UpdateContents();
			if (flag)
			{
				FadeRowsFromWhite();
				MarkAllAsSeen();
			}
			else
			{
				FadeLastPressedRowFromWhite();
			}
			break;
		}
		case State.GenericInfoDialog:
			genericInfoDialog.Show();
			break;
		case State.AbandonQuestConfirmation:
			abandonQuestConfirmation.Show();
			break;
		case State.ChangeActiveQuestConfirmation:
			changeActiveQuestConfirmation.Show();
			break;
		}
		currentState = newState;
		stateElapsedTime = 0;
	}

	public override void UpdateTic()
	{
		if (currentState == State.Normal)
		{
			base.UpdateTic();
		}
		stateElapsedTime++;
		if (isDirty && currentState != State.OpeningTreasure)
		{
			UpdateContents();
		}
		else if (scheduledUpdateContainerPosition)
		{
			UpdateContainerPosition();
		}
		UpdateFocusedRow();
		if (currentState == State.Normal)
		{
			if (deepLinkParams != null)
			{
				if (deepLinkParams.Length >= 2 && deepLinkParams[1] == "rewards" && rows.Contains(eventRow))
				{
					eventRewardsScreen.deepLinkParams = deepLinkParams;
					eventRow.FireShowRewards();
				}
				deepLinkParams = null;
			}
			else
			{
				for (int i = 0; i < rows.Count; i++)
				{
					rows[i].UpdateTic();
				}
			}
		}
		else if (currentState == State.QuestStoneActivation1 && stateElapsedTime >= 15)
		{
			SetState(State.QuestStoneActivation2);
		}
		else if (currentState == State.QuestStoneActivation2 && stateElapsedTime >= 63)
		{
			SetState(State.QuestStoneActivation3);
		}
		else if (currentState == State.QuestStoneActivation3 && stateElapsedTime >= 12)
		{
			SetState(State.Normal);
		}
		else if (currentState == State.EventRewardsScreen)
		{
			eventRewardsScreen.UpdateTic();
			if (eventRewardsScreen.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.EventLeaderboardScreen)
		{
			eventLeaderboardScreen.UpdateTic();
			if (eventLeaderboardScreen.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.EventLastChancePremium)
		{
			eventLastChanceDialog.UpdateTic();
			if (eventLastChanceDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
				if (eventLastChanceDialog.debugRewardPoints < 0 && eventLastChanceDialog.skipRewards)
				{
					eventRow.eventController.CollectRewardsAndEnd();
				}
			}
		}
		else if (currentState == State.GenericInfoDialog)
		{
			genericInfoDialog.UpdateTic();
			if (genericInfoDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.RewardDialog)
		{
			rewardDialog.UpdateTic();
			if (rewardDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.AbandonQuestConfirmation)
		{
			abandonQuestConfirmation.UpdateTic();
			if (abandonQuestConfirmation.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.ChangeActiveQuestConfirmation)
		{
			changeActiveQuestConfirmation.UpdateTic();
			if (changeActiveQuestConfirmation.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.OpeningTreasure)
		{
			GameStates.Singleton.gateShopScreen.openTreasureDialog.UpdateTic();
			if (GameStates.Singleton.gateShopScreen.openTreasureDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateGridSizeChanged(r.width, r.height);
		base.Draw(r, offsetX, offsetY);
		if (currentState == State.QuestStoneActivation1 || currentState == State.QuestStoneActivation2)
		{
			fade.Draw(r);
			DrawUnlockRow(r);
			DrawQuestStoneAnim(r);
		}
		else if (currentState == State.QuestStoneActivation3)
		{
			fade.Draw(r);
			DrawQuestStoneAnim(r);
		}
		else if (currentState == State.EventRewardsScreen)
		{
			eventRewardsScreen.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.EventLastChancePremium)
		{
			eventLastChanceDialog.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.EventLeaderboardScreen)
		{
			eventLeaderboardScreen.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.GenericInfoDialog)
		{
			genericInfoDialog.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.RewardDialog)
		{
			rewardDialog.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.AbandonQuestConfirmation)
		{
			abandonQuestConfirmation.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.ChangeActiveQuestConfirmation)
		{
			changeActiveQuestConfirmation.Draw(r, r.width / 2, r.height / 2);
		}
		else if (currentState == State.OpeningTreasure)
		{
			GameStates.Singleton.gateShopScreen.openTreasureDialog.Draw(r, r.width / 2, r.height / 2);
		}
	}

	private void DrawUnlockRow(AsciiRenderProcedural r)
	{
		foreach (DialogButton row in rows)
		{
			if (row == unlockBasicsRow || row == lastPressedAdvancedRow)
			{
				row.Draw(r, row.lastDrawnX, row.lastDrawnY);
				if (stateElapsedTime >= 59)
				{
					row.DrawHighlight(r, row.lastDrawnX, row.lastDrawnY);
				}
				break;
			}
		}
	}

	private void DrawQuestStoneAnim(AsciiRenderProcedural r)
	{
		int lastDrawnX = GameStates.Singleton.navBar.questStoneButton.lastDrawnX;
		int lastDrawnY = GameStates.Singleton.navBar.questStoneButton.lastDrawnY;
		questStoneActivationAnim.Sprite.Draw(r, lastDrawnX, lastDrawnY);
	}

	private void UpdateGridSizeChanged(int gridWidth, int gridHeight)
	{
		if (lastGridWidth != gridWidth || lastGridHeight != gridHeight)
		{
			lastGridWidth = gridWidth;
			lastGridHeight = gridHeight;
			UpdateContents();
		}
	}

	public override void UpdateContents()
	{
		if ((currentState == State.EventLeaderboardScreen && eventLeaderboardScreen.CurrentState > DialogNineSlice.State.In) || (currentState == State.EventRewardsScreen && eventRewardsScreen.CurrentState > DialogNineSlice.State.In) || currentState == State.EventLastChancePremium || (currentState == State.GenericInfoDialog && genericInfoDialog.CurrentState > DialogNineSlice.State.In) || (currentState == State.RewardDialog && rewardDialog.CurrentState > DialogNineSlice.State.In) || (GameStates.Singleton.isTransitioning && GameStates.Singleton.CurrentState == GameStates.State.CustomQuests))
		{
			return;
		}
		CustomQuestsController.Singleton.HandleScreenUpdateContents();
		HashSet<string> hashSet = new HashSet<string>();
		if (!forceFocusOnActiveEpic)
		{
			foreach (AsciiObject row in rows)
			{
				if (row is CustomQuestsRowAdvanced)
				{
					CustomQuestsRowAdvanced customQuestsRowAdvanced = row as CustomQuestsRowAdvanced;
					if (customQuestsRowAdvanced.currentRowState == CustomQuestsRowAdvanced.RowState.Open)
					{
						hashSet.Add(customQuestsRowAdvanced.QuestDef.id);
					}
				}
			}
		}
		isDirty = false;
		RemoveRow(unlockBasicsRow);
		RemoveRow(rowWeekly);
		RemoveRow(rowReferral);
		RemoveRow(eventRow);
		RemoveRow(nextTimeRow);
		RemoveRow(totalCountRow);
		RemoveAllCallbacks();
		RecycleAllRows();
		if (CustomQuestsController.Singleton.ftueStep == CustomQuestsController.FTUEStep.UnlockBasicQuests)
		{
			AddRowInstance(unlockBasicsRow);
			UpdateContainerPosition();
			return;
		}
		List<Data.CustomQuestInstance> activeQuests = CustomQuestsController.Singleton.ActiveQuests;
		for (int i = 0; i < activeQuests.Count; i++)
		{
			Data.CustomQuestInstance quest = activeQuests[i];
			if (quest.IsBasic)
			{
				CustomQuestsRowBasic obj = AddRowFromPrefab(rowBasicPrefab) as CustomQuestsRowBasic;
				obj.claimRewardButton.ClearOnPressed();
				obj.claimRewardButton.OnPressed += delegate
				{
					TreasureItem reward = CustomQuestsController.Singleton.ClaimReward(quest);
					ShowReward(quest, reward);
					AnalyticsMacros.DailyQuestRewardCollected();
				};
				obj.OnPressed += CustomQuestsController.Singleton.HandleQuestButtonPressed;
				obj.Setup(quest);
			}
		}
		if (WeeklyQuestsController.singleton.activeQuest != null)
		{
			try
			{
				rowWeekly.Setup(WeeklyQuestsController.singleton.activeQuest);
				rowWeekly.claimRewardButton.isDisabledState = false;
				AddRowInstance(rowWeekly);
			}
			catch (Exception)
			{
			}
		}
		if (rowReferral.data != null && (!rowReferral.data.HasExpired() || rowReferral.data.HasTreasureToCollect()))
		{
			AddRowInstance(rowReferral);
		}
		BaseEventController2 baseEventController = EventController.singleton.GetPendingRewardsEventController();
		if (baseEventController == null)
		{
			baseEventController = EventController.singleton.GetActiveEventController();
		}
		if (baseEventController != null && baseEventController.IsVisibleInQuestScreen())
		{
			if (!hasInteractedWithEpic)
			{
				focusedRow = eventRow;
			}
			eventRow.Setup(baseEventController);
			eventLeaderboardScreen.Setup(baseEventController);
			AddRowInstance(eventRow);
		}
		if (CustomQuestsController.Singleton.ftueStep > CustomQuestsController.FTUEStep.CompleteFirstEpicQuest && CustomQuestsController.Singleton.nextSpawnDate > DateTime.Now && CustomQuestsController.Singleton.GetNextEpicToUnlock() != null)
		{
			nextTimeRow.Setup();
			AddRowInstance(nextTimeRow);
		}
		List<Data.CustomQuest> epicQuestsUnlocked = CustomQuestsController.Singleton.EpicQuestsUnlocked;
		for (int num = epicQuestsUnlocked.Count - 1; num >= 0; num--)
		{
			Data.CustomQuest questDef = epicQuestsUnlocked[num];
			Data.CustomQuestInstance customQuestInstance = activeQuests.Find((Data.CustomQuestInstance q) => q.def.id == questDef.id);
			if (customQuestInstance != null)
			{
				if (!customQuestInstance.IsBasic)
				{
					bool open = hashSet.Contains(customQuestInstance.def.id);
					CustomQuestsRowAdvanced customQuestsRowAdvanced2 = AddRowFromPrefab(rowAdvancedPrefab) as CustomQuestsRowAdvanced;
					customQuestsRowAdvanced2.scrollContainer = scrollContainer;
					customQuestsRowAdvanced2.OnPressed += CustomQuestsController.Singleton.HandleQuestButtonPressed;
					customQuestsRowAdvanced2.OnPressed += HandleAdvancedRowPressed;
					if (forceFocusOnActiveEpic && (focusedRow == null || hasInteractedWithEpic))
					{
						open = true;
						focusedRow = customQuestsRowAdvanced2;
					}
					customQuestsRowAdvanced2.Setup(customQuestInstance, open);
				}
			}
			else
			{
				bool open2 = hashSet.Contains(questDef.id);
				CustomQuestsRowAdvanced customQuestsRowAdvanced3 = AddRowFromPrefab(rowAdvancedPrefab) as CustomQuestsRowAdvanced;
				customQuestsRowAdvanced3.scrollContainer = scrollContainer;
				customQuestsRowAdvanced3.OnPressed += CustomQuestsController.Singleton.HandleQuestButtonPressed;
				customQuestsRowAdvanced3.OnPressed += HandleAdvancedRowPressed;
				if (focusedRow == null && !CustomQuestsController.Singleton.IsEpicRevealed(questDef.id))
				{
					focusedRow = customQuestsRowAdvanced3;
				}
				customQuestsRowAdvanced3.Setup(questDef, open2);
			}
		}
		CustomQuestsController.Singleton.UpdateBadge();
		CustomQuestsController singleton = CustomQuestsController.Singleton;
		int epicQuestsCompletedCount = singleton.EpicQuestsCompletedCount;
		if (epicQuestsCompletedCount > 0)
		{
			totalCountRow.Setup(epicQuestsCompletedCount, singleton.EpicQuestsTotal);
			AddRowInstance(totalCountRow);
		}
		UpdateContainerPosition();
		forceFocusOnActiveEpic = false;
	}

	public void ScheduleUpdateContainerPosition()
	{
		scheduledUpdateContainerPosition = true;
	}

	public void UpdateContainerPosition()
	{
		scheduledUpdateContainerPosition = false;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		int num = 0;
		foreach (AsciiObject row in rows)
		{
			num += row.Height;
		}
		int num2 = asciiRenderer.height - 1;
		int num3 = 1;
		scrollContainer.Height = Mathf.Min(num2, num);
		scrollContainer.scrollBar.Height = scrollContainer.Height;
		int a = (num2 - scrollContainer.Height) / 2 + 1;
		a = Mathf.Max(a, num3);
		scrollContainer.PositionY = a;
		if (scrollContainer.Height < num2)
		{
			scrollContainer.Height = num2 - (num3 - a);
		}
		scrollContainer.scrollBar.PositionY = scrollContainer.PositionY;
		scrollContainer.ConstrainScrollY();
	}

	private void UpdateFocusedRow()
	{
		if (!(focusedRow == null))
		{
			int rowPositionY = scrollContainer.GetRowPositionY(focusedRow);
			if (focusedRow.Height >= scrollContainer.Height)
			{
				scrollContainer.SetScrollY(rowPositionY, jumpToPosition: false);
				return;
			}
			int num = scrollContainer.Height - focusedRow.Height;
			scrollContainer.SetScrollY(rowPositionY - num / 2, jumpToPosition: false);
		}
	}

	public void TryReplay(Data.CustomQuest questDef)
	{
		List<Data.CustomQuestInstance> epicQuestsActive = CustomQuestsController.Singleton.EpicQuestsActive;
		if (epicQuestsActive.Count > 0)
		{
			replayQuestDef = questDef;
			changeActiveQuestConfirmation.Setup(Te.xt(epicQuestsActive[0].Title), Te.xt(questDef.title));
			SetState(State.ChangeActiveQuestConfirmation);
		}
		else
		{
			CustomQuestsController.Singleton.ReplayQuest(questDef);
			MarkDirty();
		}
		focusedRow = GetRowForQuest(questDef);
		hasInteractedWithEpic = true;
	}

	public void TryAbandon(Data.CustomQuestInstance quest)
	{
		abandonQuest = quest;
		abandonQuestConfirmation.Setup(Te.xt(quest.Title));
		SetState(State.AbandonQuestConfirmation);
	}

	public bool IsShowingSubScreen()
	{
		return currentState > State.QuestStoneActivation3;
	}

	public bool ShouldCheckSequentialPopupManager()
	{
		if (currentState != State.Normal && currentState != State.EventRewardsScreen)
		{
			return currentState == State.EventLeaderboardScreen;
		}
		return true;
	}

	public bool ShouldDrawMoneyHud()
	{
		if (currentState != State.EventRewardsScreen && currentState != State.EventLeaderboardScreen)
		{
			return currentState != State.EventLastChancePremium;
		}
		return false;
	}

	private void HandleAbandonQuestConfirmed(DialogButton btn)
	{
		abandonQuestConfirmation.Hide();
		CustomQuestsController.Singleton.AbandonQuest(abandonQuest);
		CustomQuestsRowAdvanced rowForQuest = GetRowForQuest(abandonQuest);
		rowForQuest.Close();
		abandonQuest = null;
		MarkDirty();
		focusedRow = rowForQuest;
		hasInteractedWithEpic = false;
	}

	private void HandleChangeActiveQuestConfirmed(DialogButton btn)
	{
		changeActiveQuestConfirmation.Hide();
		CustomQuestsController.Singleton.ReplayQuest(replayQuestDef);
		replayQuestDef = null;
		MarkDirty();
	}

	private void HandleUnlockBasicsPressed(DialogButton btn)
	{
		SetState(State.QuestStoneActivation1);
		AnalyticsMacros.DailyQuestsUnlocked();
	}

	private void HandleUserScrolledManually(ScrollContainer sc)
	{
		focusedRow = null;
	}

	private void HandleClaimWeeklyReward(DialogButton btn)
	{
		btn.isDisabledState = true;
		WeeklyQuestsController.singleton.activeQuest = null;
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		TreasureItem treasure = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "ki_treasure", possibleElements);
		GameStates.Singleton.gateShopScreen.openTreasureDialog.Setup(treasure);
		GameStates.Singleton.gateShopScreen.openTreasureDialog.Show();
		SetState(State.OpeningTreasure);
		MarkDirty();
		AnalyticsMacros.WeeklyQuestRewardCollected();
		ReferralController.singleton.UnlockReferralQuest();
	}

	private void HandleReferralDataChanged(ReferralDataModel data)
	{
		rowReferral.Setup(data);
		MarkDirty();
		if (GameStates.Singleton.CurrentState != GameStates.State.CustomQuests && data != null && data.HasTreasureToCollect())
		{
			CustomQuestsController.Singleton.UpdateBadge();
		}
	}

	private void HandleClaimReferralReward()
	{
		TreasureItem treasure = ReferralController.singleton.CollectOneTreasureReward();
		GameStates.Singleton.gateShopScreen.openTreasureDialog.Setup(treasure);
		GameStates.Singleton.gateShopScreen.openTreasureDialog.Show();
		SetState(State.OpeningTreasure);
		MarkDirty();
	}

	private void HandleReferralRowPressed(DialogButton btn)
	{
		focusedRow = rowReferral;
	}

	private void HandleEventRowPressed(DialogButton btn)
	{
		focusedRow = eventRow;
	}

	private void HandleEventStartPressed(BaseEventController2 eventController)
	{
		eventLeaderboardScreen.ResetCachedData();
	}

	private void HandleShowEventRewards(Data.EventRewardCollection rewardCollection, DateTime eventEndDate)
	{
		eventRewardsScreen.SetEventEndDate(eventEndDate);
		eventRewardsScreen.Show(rewardCollection, eventRow.eventController);
		SetState(State.EventRewardsScreen);
	}

	private void HandleShowEventLeaderboard()
	{
		EventController.EventData data = eventRow.eventController.data;
		eventLeaderboardScreen.Show(data.id, data.name);
		SetState(State.EventLeaderboardScreen);
	}

	private void HandleShowObjectiveExtraInfo(string infoText, string titleText)
	{
		genericInfoDialog.SetMessage(infoText);
		if (titleText != null)
		{
			genericInfoDialog.title.SetValue(titleText);
		}
		SetState(State.GenericInfoDialog);
	}

	private void HandleLastChanceToPremium(Data.EventRewardCollection rewardCollection)
	{
		eventLastChanceDialog.Show(eventRow.eventController);
		SetState(State.EventLastChancePremium);
	}

	private void FadeFromWhite(AsciiObject obj)
	{
		FadeFromColorNineSlice component = obj.GetComponent<FadeFromColorNineSlice>();
		if ((bool)component)
		{
			component.SetToOpaque();
			component.FadeToNormal();
		}
	}

	private void FadeRowsFromWhite()
	{
		foreach (AsciiObject row in rows)
		{
			FadeFromWhite(row);
		}
	}

	private void FadeLastPressedRowFromWhite()
	{
		foreach (AsciiObject row in rows)
		{
			if (row == lastPressedAdvancedRow)
			{
				FadeFromWhite(row);
				CustomQuestsRowAdvanced customQuestsRowAdvanced = row as CustomQuestsRowAdvanced;
				if (customQuestsRowAdvanced != null)
				{
					customQuestsRowAdvanced.SetRowState(CustomQuestsRowAdvanced.RowState.Closed);
				}
			}
		}
	}

	private void MarkAllAsSeen()
	{
		foreach (AsciiObject row in rows)
		{
			FadeFromWhite(row);
			CustomQuestsRow customQuestsRow = row as CustomQuestsRow;
			if (customQuestsRow != null && customQuestsRow.quest != null)
			{
				CustomQuestsController.Singleton.SetSeen(customQuestsRow.quest);
			}
		}
	}

	private void ShowReward(Data.CustomQuestInstance quest, Item reward)
	{
		string text = Te.xt(quest.Title);
		if (text == null)
		{
			text = quest.status;
		}
		ShowReward(text, reward);
	}

	private void ShowReward(string title, Item reward)
	{
		if (!(reward == null))
		{
			AsciiSprite icon = reward.GetIcon();
			rewardDialog.Setup(title, icon);
			rewardDialog.Show();
			SetState(State.RewardDialog);
		}
	}

	private void HandleUserScrolledContainer(ScrollContainer _container)
	{
		focusedRow = null;
		forceFocusOnActiveEpic = false;
		hasInteractedWithEpic = false;
	}

	private void Awake()
	{
		fade = GetComponent<ModalFade>();
		unlockBasicsRow.OnPressed += HandleUnlockBasicsPressed;
		abandonQuestConfirmation.okButton.OnPressed += HandleAbandonQuestConfirmed;
		changeActiveQuestConfirmation.okButton.OnPressed += HandleChangeActiveQuestConfirmed;
		ScrollContainer obj = scrollContainer;
		obj.OnUserScrolledManually = (Action<ScrollContainer>)Delegate.Combine(obj.OnUserScrolledManually, new Action<ScrollContainer>(HandleUserScrolledManually));
		rowWeekly.claimRewardButton.OnPressed += HandleClaimWeeklyReward;
		ReferralController singleton = ReferralController.singleton;
		singleton.OnReferralDataChanged = (Action<ReferralDataModel>)Delegate.Combine(singleton.OnReferralDataChanged, new Action<ReferralDataModel>(HandleReferralDataChanged));
		ReferralQuestRow referralQuestRow = rowReferral;
		referralQuestRow.OnClaimReferralReward = (Action)Delegate.Combine(referralQuestRow.OnClaimReferralReward, new Action(HandleClaimReferralReward));
		rowReferral.OnPressed += HandleReferralRowPressed;
		rowReferral.scrollContainer = scrollContainer;
		eventRow.OnPressed += HandleEventRowPressed;
		eventRow.OnStartPressed += HandleEventStartPressed;
		eventRow.OnShowRewards += HandleShowEventRewards;
		eventRow.OnShowLeaderboard += HandleShowEventLeaderboard;
		eventRow.OnShowObjectiveExtraInfo += HandleShowObjectiveExtraInfo;
		eventRow.OnLastChanceTriggered += HandleLastChanceToPremium;
		eventRow.scrollContainer = scrollContainer;
		genericInfoDialog.okButton.OnPressed += delegate
		{
			genericInfoDialog.Hide();
		};
		ScrollContainer obj2 = scrollContainer;
		obj2.OnUserScrolledManually = (Action<ScrollContainer>)Delegate.Combine(obj2.OnUserScrolledManually, new Action<ScrollContainer>(HandleUserScrolledContainer));
	}

	protected override void OnDestroy()
	{
		RemoveAllCallbacks();
		unlockBasicsRow.OnPressed -= HandleUnlockBasicsPressed;
		abandonQuestConfirmation.okButton.OnPressed -= HandleAbandonQuestConfirmed;
		changeActiveQuestConfirmation.okButton.OnPressed -= HandleChangeActiveQuestConfirmed;
		ScrollContainer obj = scrollContainer;
		obj.OnUserScrolledManually = (Action<ScrollContainer>)Delegate.Remove(obj.OnUserScrolledManually, new Action<ScrollContainer>(HandleUserScrolledManually));
		rowWeekly.claimRewardButton.OnPressed -= HandleClaimWeeklyReward;
		ReferralController singleton = ReferralController.singleton;
		singleton.OnReferralDataChanged = (Action<ReferralDataModel>)Delegate.Remove(singleton.OnReferralDataChanged, new Action<ReferralDataModel>(HandleReferralDataChanged));
		ReferralQuestRow referralQuestRow = rowReferral;
		referralQuestRow.OnClaimReferralReward = (Action)Delegate.Remove(referralQuestRow.OnClaimReferralReward, new Action(HandleClaimReferralReward));
		rowReferral.OnPressed -= HandleReferralRowPressed;
		rowReferral.scrollContainer = null;
		eventRow.OnPressed -= HandleEventRowPressed;
		eventRow.OnStartPressed -= HandleEventStartPressed;
		eventRow.OnShowRewards -= HandleShowEventRewards;
		eventRow.OnShowLeaderboard -= HandleShowEventLeaderboard;
		eventRow.OnShowObjectiveExtraInfo -= HandleShowObjectiveExtraInfo;
		eventRow.OnLastChanceTriggered -= HandleLastChanceToPremium;
		eventRow.scrollContainer = null;
		base.OnDestroy();
	}

	private void RemoveAllCallbacks()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			DialogButton obj = rows[i] as DialogButton;
			obj.OnPressed -= CustomQuestsController.Singleton.HandleQuestButtonPressed;
			obj.OnPressed -= HandleAdvancedRowPressed;
			CustomQuestsRowBasic customQuestsRowBasic = obj as CustomQuestsRowBasic;
			if (customQuestsRowBasic != null)
			{
				customQuestsRowBasic.claimRewardButton.ClearOnPressed();
			}
		}
	}

	private void HandleAdvancedRowPressed(DialogButton button)
	{
		lastPressedAdvancedRow = button;
		focusedRow = button;
		hasInteractedWithEpic = true;
		CustomQuestsRowAdvanced customQuestsRowAdvanced = button as CustomQuestsRowAdvanced;
		if (customQuestsRowAdvanced != null && customQuestsRowAdvanced.currentRowState == CustomQuestsRowAdvanced.RowState.Locked)
		{
			scrollContainer.ScrollPositionToCentralizeRow(button);
			CustomQuestsController.Singleton.SetEpicRevealed(customQuestsRowAdvanced.QuestDef.id);
			SetState(State.QuestStoneActivation1);
			AnalyticsMacros.EpicQuestUnlocked();
		}
	}

	public CustomQuestsRowAdvanced GetRowForQuest(Data.CustomQuest questDef)
	{
		foreach (IAsciiObject row in rows)
		{
			if (row is CustomQuestsRowAdvanced)
			{
				CustomQuestsRowAdvanced customQuestsRowAdvanced = row as CustomQuestsRowAdvanced;
				if (customQuestsRowAdvanced.QuestDef == questDef)
				{
					return customQuestsRowAdvanced;
				}
			}
		}
		return null;
	}

	public CustomQuestsRowAdvanced GetRowForQuest(Data.CustomQuestInstance quest)
	{
		foreach (IAsciiObject row in rows)
		{
			if (row is CustomQuestsRowAdvanced)
			{
				CustomQuestsRowAdvanced customQuestsRowAdvanced = row as CustomQuestsRowAdvanced;
				if (customQuestsRowAdvanced.quest == quest)
				{
					return customQuestsRowAdvanced;
				}
			}
		}
		return null;
	}

	public void MarkDirty()
	{
		isDirty = true;
	}

	private void CheckDailyRefresh()
	{
		DateTime now = DateTime.Now;
		if (lastDateTime.DayOfYear != now.DayOfYear)
		{
			lastDateTime = now;
			isDirty = true;
		}
	}
}
