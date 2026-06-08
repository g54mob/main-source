using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestScreen : ScrollContainerScreen
{
	public delegate int DifficultyOverride(Data.Quest questData, int difficulty);

	public QuestDifficultySubMenu difficultySubMenu;

	public QuestDifficultySubMenuAdvanced difficultySubMenuAdvanced;

	public QuestRow rowPrefab;

	public ShopQuestRow shopRowPrefab;

	public HauntedGateQuestRow hauntedRowPrefab;

	public ShopQuestRow uulaaShopRowPrefab;

	private EventController.EventData lastActiveEvent;

	public LocationLeaderboardScreen leaderboardScreen;

	private int lastGridWidth;

	private int lastGridHeight;

	private int pendingScrollCheck;

	public DifficultyOverride difficultyOverride;

	public event Action<Data.Quest> OnQuestSelected;

	public event Action<Data.Quest> OnQuestTimerCompleted;

	protected virtual List<Data.Quest> GetDataList()
	{
		return QuestController.singleton.AvailableQuests;
	}

	public bool IsCurrentStateIdle()
	{
		if (difficultySubMenu != null && difficultySubMenu.CurrentState != DialogNineSlice.State.Disabled)
		{
			return false;
		}
		if (difficultySubMenuAdvanced != null && difficultySubMenuAdvanced.CurrentState != DialogNineSlice.State.Disabled)
		{
			return false;
		}
		if (leaderboardScreen != null && leaderboardScreen.CurrentState != DialogNineSlice.State.Disabled)
		{
			return false;
		}
		return true;
	}

	public override void UpdateTic()
	{
		if (difficultySubMenu != null && difficultySubMenu.CurrentState != DialogNineSlice.State.Disabled)
		{
			difficultySubMenu.UpdateTic();
		}
		else if (difficultySubMenuAdvanced != null && difficultySubMenuAdvanced.CurrentState != DialogNineSlice.State.Disabled)
		{
			difficultySubMenuAdvanced.UpdateTic();
		}
		else
		{
			base.UpdateTic();
		}
		if (leaderboardScreen != null && leaderboardScreen.CurrentState != DialogNineSlice.State.Disabled)
		{
			leaderboardScreen.UpdateTic();
		}
		UpdateScrollCheck();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateGridSizeChanged(r.width, r.height);
		base.Draw(r, offsetX, offsetY);
		if (difficultySubMenu != null && difficultySubMenu.CurrentState != DialogNineSlice.State.Disabled)
		{
			difficultySubMenu.Draw(r, offsetX, offsetY);
		}
		else if (difficultySubMenuAdvanced != null && difficultySubMenuAdvanced.CurrentState != DialogNineSlice.State.Disabled)
		{
			difficultySubMenuAdvanced.Draw(r, r.width >> 1, offsetY);
		}
		if (leaderboardScreen != null && leaderboardScreen.CurrentState != DialogNineSlice.State.Disabled)
		{
			leaderboardScreen.Draw(r, r.width / 2, r.height / 2);
		}
	}

	public bool IsShowingDifficultySubMenu()
	{
		if (!(difficultySubMenu != null) || difficultySubMenu.CurrentState == DialogNineSlice.State.Disabled)
		{
			if (difficultySubMenuAdvanced != null)
			{
				return difficultySubMenuAdvanced.CurrentState != DialogNineSlice.State.Disabled;
			}
			return false;
		}
		return true;
	}

	public void ShowDifficultySubMenu(Data.Quest questData)
	{
		if (OuroborosWeapon.singleton == null || OuroborosWeapon.singleton.level <= 1)
		{
			difficultySubMenu.Setup(questData);
			difficultySubMenu.Show();
		}
		else
		{
			difficultySubMenuAdvanced.Setup(questData);
			difficultySubMenuAdvanced.Show();
		}
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
		if (difficultySubMenu != null && difficultySubMenu.CurrentState == DialogNineSlice.State.Idle)
		{
			difficultySubMenu.HideImmediatly();
		}
		if (difficultySubMenuAdvanced != null && difficultySubMenuAdvanced.CurrentState == DialogNineSlice.State.Idle)
		{
			difficultySubMenuAdvanced.HideImmediatly();
		}
		if (leaderboardScreen != null && leaderboardScreen.CurrentState == DialogNineSlice.State.Idle)
		{
			leaderboardScreen.HideImmediatly();
		}
		RemoveAllCallbacks();
		RecycleAllRows();
		List<Data.Quest> dataList = GetDataList();
		if (dataList != null)
		{
			for (int i = 0; i < dataList.Count; i++)
			{
				Data.Quest quest = dataList[i];
				QuestRow questRow = rowPrefab;
				if (quest.id == "mushroom_shop")
				{
					questRow = shopRowPrefab;
				}
				else if (quest.id == "undead_crypt_intro")
				{
					questRow = hauntedRowPrefab;
				}
				else if (quest.id == "uulaa_shop")
				{
					questRow = uulaaShopRowPrefab;
				}
				QuestRow obj = AddRowFromPrefab(questRow) as QuestRow;
				obj.OnPressed += HandleOnRowPressed;
				obj.OnProgressBarComplete += HandleOnProgressBarComplete;
				obj.QuestData = quest;
				obj.SetStarDifficulty(QuestController.singleton.GetStarDifficultyForQuest(quest.id), animated: false);
			}
		}
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		scrollContainer.Height = Mathf.Min(asciiRenderer.height - 1, rows.Count * (rowPrefab.Height - 1) + 1);
		scrollContainer.scrollBar.Height = scrollContainer.Height;
		scrollContainer.PositionY = (asciiRenderer.height - 1 - scrollContainer.Height) / 2 + 1;
		scrollContainer.scrollBar.PositionY = scrollContainer.PositionY;
		scrollContainer.ConstrainScrollY();
		pendingScrollCheck = 2;
	}

	private void UpdateScrollCheck()
	{
		if (GameStates.Singleton.navBar.IsTransitioning() || pendingScrollCheck-- != 0)
		{
			return;
		}
		bool flag = false;
		EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
		if (activeAndStartedEvent != null && activeAndStartedEvent != lastActiveEvent)
		{
			lastActiveEvent = activeAndStartedEvent;
			if (!string.IsNullOrEmpty(activeAndStartedEvent.uniqueLocation))
			{
				for (int i = 0; i < rows.Count; i++)
				{
					QuestRow questRow = rows[i] as QuestRow;
					if (questRow.QuestData.id == activeAndStartedEvent.uniqueLocation)
					{
						scrollContainer.ComputeOffsets();
						int rowPositionY = scrollContainer.GetRowPositionY(questRow);
						scrollContainer.SetScrollY(rowPositionY - 8, jumpToPosition: false);
						flag = true;
						break;
					}
				}
			}
		}
		if (flag || scrollContainer.totalContentLength <= scrollContainer.Height)
		{
			return;
		}
		int num = scrollContainer.ScrollY % 6;
		if ((num == 0 || num == 1 || num == 5) && !QuestController.singleton.IsAvailable("fungus_forest") && (GameStates.Singleton.level.QuestData == null || GameStates.Singleton.level.QuestData.id != "rocky_plateau"))
		{
			scrollContainer.ComputeOffsets();
			if (scrollContainer.ScrollY > (scrollContainer.totalContentLength - scrollContainer.Height) / 2)
			{
				scrollContainer.SetScrollY(scrollContainer.ScrollY - 3, jumpToPosition: false);
			}
			else
			{
				scrollContainer.SetScrollY(scrollContainer.ScrollY + 3, jumpToPosition: false);
			}
			flag = true;
		}
	}

	private void Start()
	{
		if (difficultySubMenu != null)
		{
			QuestDifficultySubMenu questDifficultySubMenu = difficultySubMenu;
			questDifficultySubMenu.OnQuestDifficultySelected = (Action<Data.Quest, int>)Delegate.Combine(questDifficultySubMenu.OnQuestDifficultySelected, new Action<Data.Quest, int>(HandleQuestDifficultySelected));
			difficultySubMenu.OnShowLeaderboard += HandleShowQuestLeaderboard;
		}
		if (difficultySubMenuAdvanced != null)
		{
			QuestDifficultySubMenuAdvanced questDifficultySubMenuAdvanced = difficultySubMenuAdvanced;
			questDifficultySubMenuAdvanced.OnQuestDifficultySelected = (Action<Data.Quest, int>)Delegate.Combine(questDifficultySubMenuAdvanced.OnQuestDifficultySelected, new Action<Data.Quest, int>(HandleQuestDifficultySelected));
			difficultySubMenuAdvanced.OnShowLeaderboard += HandleShowQuestLeaderboard;
		}
	}

	protected override void OnDestroy()
	{
		RemoveAllCallbacks();
		if (difficultySubMenu != null)
		{
			QuestDifficultySubMenu questDifficultySubMenu = difficultySubMenu;
			questDifficultySubMenu.OnQuestDifficultySelected = (Action<Data.Quest, int>)Delegate.Remove(questDifficultySubMenu.OnQuestDifficultySelected, new Action<Data.Quest, int>(HandleQuestDifficultySelected));
			difficultySubMenu.OnShowLeaderboard -= HandleShowQuestLeaderboard;
		}
		if (difficultySubMenuAdvanced != null)
		{
			QuestDifficultySubMenuAdvanced questDifficultySubMenuAdvanced = difficultySubMenuAdvanced;
			questDifficultySubMenuAdvanced.OnQuestDifficultySelected = (Action<Data.Quest, int>)Delegate.Remove(questDifficultySubMenuAdvanced.OnQuestDifficultySelected, new Action<Data.Quest, int>(HandleQuestDifficultySelected));
			difficultySubMenuAdvanced.OnShowLeaderboard -= HandleShowQuestLeaderboard;
		}
		base.OnDestroy();
	}

	private void RemoveAllCallbacks()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			QuestRow obj = rows[i] as QuestRow;
			obj.OnPressed -= HandleOnRowPressed;
			obj.OnProgressBarComplete -= HandleOnProgressBarComplete;
		}
	}

	protected virtual void HandleOnRowPressed(DialogButton button)
	{
		QuestRow questRow = button as QuestRow;
		if (questRow.mode == QuestRow.Mode.Normal || questRow.mode == QuestRow.Mode.NormalWithCost)
		{
			if (QuestController.singleton.PlayerHasSufficientResourcesToPlay(questRow.QuestData))
			{
				QuestController.singleton.DeductCostsToPlay(questRow.QuestData);
				SfxController.singleton.Play("confirm");
				if (questRow.QuestData.timeProgress != null)
				{
					questRow.BeginProgress();
				}
				int num = QuestController.singleton.GetStarDifficultyForQuest(questRow.QuestData.id);
				int num2 = 4;
				if (questRow.QuestData.id == "rocky_plateau")
				{
					num2 = 6;
				}
				if (difficultyOverride != null)
				{
					num = difficultyOverride(questRow.QuestData, num);
				}
				if (num >= num2)
				{
					ShowDifficultySubMenu(questRow.QuestData);
				}
				else
				{
					FireQuestSelected(questRow.QuestData);
				}
			}
			else
			{
				SfxController.singleton.Play("click");
				List<Data.Cost> insufficientResources = QuestController.singleton.GetInsufficientResources(questRow.QuestData);
				questRow.DisplayInsufficientResources(insufficientResources);
			}
		}
		else
		{
			SfxController.singleton.Play("click");
		}
	}

	private void HandleQuestDifficultySelected(Data.Quest questData, int difficulty)
	{
		OfflineFarmController.singleton.ReportQuestDifficultySelected(questData.id, difficulty);
		questData = QuestController.singleton.GetQuestByIdAndDifficulty(questData.id, difficulty);
		FireQuestSelected(questData);
	}

	public bool ShouldShowMoneyHUD()
	{
		if (!(leaderboardScreen == null))
		{
			return leaderboardScreen.ShouldShowMoneyHUD();
		}
		return true;
	}

	private void FireQuestSelected(Data.Quest questData)
	{
		if (this.OnQuestSelected != null)
		{
			this.OnQuestSelected(questData);
		}
	}

	private void HandleOnProgressBarComplete(Data.Quest quest)
	{
		SfxController.singleton.Play("buy");
		if (this.OnQuestTimerCompleted != null)
		{
			this.OnQuestTimerCompleted(quest);
		}
	}

	private void HandleShowQuestLeaderboard(string questId, int difficulty, string questName)
	{
		string leaderboardId = questId + "_" + difficulty;
		leaderboardScreen.Show(leaderboardId, questName, difficulty);
	}
}
