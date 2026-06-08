using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestDifficultySubMenuAdvanced : DialogNineSlice
{
	public ScrollContainer scrollContainer;

	public QuestDifficultyRow rowPrefab;

	public AsciiString title;

	public AsciiString timeToCompleteLabel;

	public AsciiString timeToCompleteValue;

	public AsciiTextBox treasuresInInventoryText;

	public AsciiTextBox maxTreasureLimitText;

	public MultiTreasureCountsUI treasuresUI;

	public AsciiString bestTimeLabel;

	public AsciiString averageTimeLabel;

	public AsciiString bestTimeValue;

	public AsciiString averageTimeValue;

	public DialogButton closeButton;

	public DialogButton exploreButton;

	public DialogButton offlineButton;

	public DialogButton leaderboardButton;

	public Action<Data.Quest, int> OnQuestDifficultySelected;

	public Action<Data.Quest, int> OnOfflineFarmSelected;

	private QuestDifficultyRow selectedDifficultyRow;

	private bool isInventoryFull;

	private bool hasTreasuresToOpen;

	private bool runEndsInDeath;

	private string questId;

	private int currentlySelectedDifficulty;

	private string questName;

	private bool allowOffline;

	private bool hasAddedRuneWarning;

	private static string PLAYER_PREFS_PRESSED_LEADERBOARD_BUTTON = "player_prefs_pressed_leaderboard_button";

	private List<QuestDifficultyRow> rows = new List<QuestDifficultyRow>();

	private Stack<QuestDifficultyRow> pool = new Stack<QuestDifficultyRow>();

	public event Action<string, int, string> OnShowLeaderboard;

	public void Setup(Data.Quest questData)
	{
		title.SetValue(Te.xt(questData.name));
		int a = 5;
		if (StarStoneWeapon.singleton != null)
		{
			a = StarStoneWeapon.singleton.level * 5;
		}
		int num = ((questData.id == "rocky_plateau") ? 5 : 3);
		int num2 = Mathf.Min(a, QuestController.singleton.GetStarDifficultyForQuest(questData.id));
		int lastPlayedDifficulty = OfflineFarmController.singleton.GetLastPlayedDifficulty(questData.id);
		int num3 = num2;
		if (lastPlayedDifficulty > 0 && lastPlayedDifficulty < num2 && lastPlayedDifficulty >= num)
		{
			num3 = lastPlayedDifficulty;
		}
		RecycleAllRows();
		for (int i = num; i <= num2; i++)
		{
			QuestDifficultyRow questDifficultyRow = AddRow();
			questDifficultyRow.quest = questData;
			questDifficultyRow.difficulty = i;
			if (i == num3)
			{
				selectedDifficultyRow = questDifficultyRow;
				questDifficultyRow.edgeSymbols.color = ColorConstants.white;
			}
			else
			{
				questDifficultyRow.edgeSymbols.color = edgeSymbols.color;
			}
		}
		scrollContainer.ScrollToBottom();
		scrollContainer.ComputeOffsets();
		int rowPositionY = scrollContainer.GetRowPositionY(selectedDifficultyRow);
		scrollContainer.SetScrollY(rowPositionY - 2, jumpToPosition: false);
		bestTimeLabel.SetValue(Te.xt("tid_best_clear_time"));
		averageTimeLabel.SetValue(Te.xt("tid_average_clear_time"));
		questId = questData.id;
		currentlySelectedDifficulty = num3;
		questName = questData.Name;
		UpdateContents();
	}

	private void UpdateContents()
	{
		string id = selectedDifficultyRow.quest.id;
		int difficulty = selectedDifficultyRow.difficulty;
		Data.Quest questByIdAndDifficulty = QuestController.singleton.GetQuestByIdAndDifficulty(id, difficulty);
		CrashReportController.singleton.AddBreadcrumb("qId:" + id);
		CrashReportController.singleton.AddBreadcrumb("dif:" + difficulty);
		CrashReportController.singleton.AddBreadcrumb("1 " + (questByIdAndDifficulty != null));
		OfflineFarmController.OfflineRunInfo runInfo = OfflineFarmController.singleton.ComputeOfflineRunInfo(id, difficulty);
		string expectedTreasureId = questByIdAndDifficulty.expectedTreasureId;
		float[] treasureProbabilities = TreasureFactory.singleton.GetTreasureProbabilities(expectedTreasureId, difficulty, id);
		treasuresUI.Clear();
		for (int i = 0; i < treasureProbabilities.Length; i++)
		{
			float num = treasureProbabilities[i];
			int num2 = Mathf.RoundToInt(num * (float)runInfo.treasuresFound);
			if (num2 > 0)
			{
				float amount = num2;
				if (num2 < 10)
				{
					amount = num * (float)runInfo.treasuresFound;
				}
				treasuresUI.DisplayTreasure(i, amount);
			}
		}
		Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(id, difficulty);
		if (statsForQuest == null || statsForQuest.bestTime <= 0)
		{
			bestTimeValue.SetValue("-");
		}
		else
		{
			bestTimeValue.SetValue(Utils.FormatTimeCasual(statsForQuest.bestTime / 30));
		}
		if (statsForQuest == null || statsForQuest.averageTime.GetValue() <= 0f)
		{
			averageTimeValue.SetValue("-");
			timeToCompleteValue.SetValue("-");
		}
		else
		{
			List<Color> colorMask = new List<Color>();
			string text = AddSpecialGlyphs(runInfo, colorMask);
			int num3 = Mathf.RoundToInt(statsForQuest.averageTime.GetValue() / 30f);
			averageTimeValue.SetValue(Utils.FormatTimeCasual(num3));
			int count = Inventory.Singleton.GetTreasures().Count;
			int treasurePickupLimit = Inventory.Singleton.GetTreasurePickupLimit();
			if (runInfo.treasuresFound == 0)
			{
				timeToCompleteValue.SetValue("-");
				if (runInfo.runEndsInDeath)
				{
					isInventoryFull = false;
				}
				else
				{
					isInventoryFull = true;
					maxTreasureLimitText.Text = string.Format(Te.xt("tid_treasure_limit_reached"), treasurePickupLimit);
				}
			}
			else
			{
				isInventoryFull = false;
				string text2 = Utils.FormatTimeCasual(runInfo.totalTimeSeconds);
				if (text.Length > 0)
				{
					timeToCompleteValue.SetValue(text2 + " " + text);
					timeToCompleteValue.SetColorMask(colorMask, -text2.Length - 1);
				}
				else
				{
					timeToCompleteValue.SetValue(text2);
					timeToCompleteValue.ClearColorMask();
				}
			}
			if (count > 0 && !isInventoryFull)
			{
				hasTreasuresToOpen = true;
				treasuresInInventoryText.Text = string.Format(Te.xt("tid_treasure_to_open"), count, treasurePickupLimit);
			}
			else
			{
				hasTreasuresToOpen = false;
			}
		}
		runEndsInDeath = runInfo.runEndsInDeath;
		if (runEndsInDeath)
		{
			timeToCompleteLabel.SetValue(Te.xt("tid_full_inventory_2"));
		}
		else
		{
			timeToCompleteLabel.SetValue(Te.xt("tid_full_inventory_time"));
		}
		int num4 = bestTimeLabel.Length + bestTimeValue.Length + 1;
		int num5 = averageTimeLabel.Length + averageTimeValue.Length + 1;
		int num6 = ((num4 <= num5) ? (title.PositionX + num5 / -2 + averageTimeLabel.Length) : (title.PositionX + num4 / -2 + bestTimeLabel.Length));
		num6--;
		bestTimeLabel.PositionX = num6;
		averageTimeLabel.PositionX = num6;
		UpdateButton(exploreButton, selectedDifficultyRow != null);
		allowOffline = runInfo.treasuresFound > 0;
		if (allowOffline && SaveFiles.singleton.storage.IsBusySaving())
		{
			offlineButton.label.SetValue(Te.xt("tid_ui_storage_saving"));
			UpdateButton(offlineButton, enabled: false);
		}
		else
		{
			offlineButton.label.SetValue(Te.xt("tid_button_offline"));
			UpdateButton(offlineButton, allowOffline);
		}
		if (currentlySelectedDifficulty % 5 != 0)
		{
			UpdateButton(leaderboardButton, enabled: false);
		}
		else
		{
			UpdateButton(leaderboardButton, enabled: true);
		}
	}

	private string AddSpecialGlyphs(OfflineFarmController.OfflineRunInfo runInfo, List<Color> colorMask)
	{
		string specialGlyphs = "";
		if (runInfo.runEndsInDeath)
		{
			specialGlyphs += "†";
			colorMask.Add(ColorConstants.red);
		}
		hasAddedRuneWarning = false;
		if (runInfo.aetherNeeded > runInfo.aetherUsed)
		{
			AddDownArrowIfNeeded(ref specialGlyphs, colorMask);
			specialGlyphs += "*";
			colorMask.Add(ColorConstants.rarityRare);
		}
		if (runInfo.fireNeeded > runInfo.fireUsed)
		{
			AddDownArrowIfNeeded(ref specialGlyphs, colorMask);
			specialGlyphs += "φ";
			colorMask.Add(ColorConstants.rarityRare);
		}
		if (runInfo.iceNeeded > runInfo.iceUsed)
		{
			AddDownArrowIfNeeded(ref specialGlyphs, colorMask);
			specialGlyphs += "❄";
			colorMask.Add(ColorConstants.rarityRare);
		}
		if (runInfo.poisonNeeded > runInfo.poisonUsed)
		{
			AddDownArrowIfNeeded(ref specialGlyphs, colorMask);
			specialGlyphs += "∞";
			colorMask.Add(ColorConstants.rarityRare);
		}
		if (runInfo.vigorNeeded > runInfo.vigorUsed)
		{
			AddDownArrowIfNeeded(ref specialGlyphs, colorMask);
			specialGlyphs += "♥";
			colorMask.Add(ColorConstants.rarityRare);
		}
		return specialGlyphs;
	}

	private void AddDownArrowIfNeeded(ref string specialGlyphs, List<Color> colorMask)
	{
		if (!hasAddedRuneWarning)
		{
			hasAddedRuneWarning = true;
			specialGlyphs += "↓";
			colorMask.Add(ColorConstants.rarityRare);
		}
	}

	public virtual void Show()
	{
		base.SetState(State.In);
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	public void HideImmediatly()
	{
		base.SetState(State.Disabled);
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && GameStates.Singleton.CurrentState == GameStates.State.QuestScreen && !GameStates.Singleton.isTransitioning && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle)
		{
			scrollContainer.UpdateTic();
			if (exploreButton.enabled)
			{
				exploreButton.UpdateTic();
			}
			if (offlineButton.enabled)
			{
				offlineButton.UpdateTic();
			}
			if (leaderboardButton.enabled)
			{
				leaderboardButton.UpdateTic();
			}
			else if (allowOffline && !SaveFiles.singleton.storage.IsBusySaving())
			{
				offlineButton.label.SetValue(Te.xt("tid_button_offline"));
				UpdateButton(offlineButton, enabled: true);
			}
		}
		closeButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			closeButton.Draw(r, offsetX, offsetY);
			scrollContainer.Draw(r, offsetX, offsetY);
			offsetX += scrollContainer.Width + 1;
			title.Draw(r, offsetX, offsetY);
			int offsetX2 = title.PositionX + offsetX - 4;
			int offsetY2 = title.PositionY + offsetY + 1;
			QuestRowStarString.Draw(r, offsetX2, offsetY2, selectedDifficultyRow.difficulty);
			if (hasTreasuresToOpen)
			{
				offsetY--;
			}
			timeToCompleteLabel.Draw(r, offsetX, offsetY);
			timeToCompleteValue.Draw(r, offsetX, offsetY);
			if (hasTreasuresToOpen)
			{
				offsetY--;
			}
			treasuresUI.Draw(r, offsetX, offsetY);
			if (hasTreasuresToOpen)
			{
				offsetY--;
			}
			bestTimeLabel.Draw(r, offsetX, offsetY);
			bestTimeValue.Draw(r, offsetX + bestTimeLabel.PositionX, offsetY + bestTimeLabel.PositionY);
			averageTimeLabel.Draw(r, offsetX, offsetY);
			averageTimeValue.Draw(r, offsetX + averageTimeLabel.PositionX, offsetY + averageTimeLabel.PositionY);
			if (hasTreasuresToOpen)
			{
				offsetY += 3;
				treasuresInInventoryText.Draw(r, offsetX, offsetY);
			}
			if (isInventoryFull)
			{
				maxTreasureLimitText.Draw(r, offsetX, offsetY);
			}
			exploreButton.Draw(r, offsetX, offsetY);
			offlineButton.Draw(r, offsetX, offsetY);
			if (leaderboardButton.enabled)
			{
				leaderboardButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void DrawButton(AsciiRenderProcedural r, int offsetX, int offsetY, DialogButton btn, int difficulty)
	{
		btn.Draw(r, offsetX, offsetY);
		offsetX += btn.PositionX;
		offsetY += btn.PositionY;
		QuestRowStarString.Draw(r, offsetX + 4, offsetY + 2, difficulty);
	}

	private void UpdateButton(DialogButton button, bool enabled)
	{
		button.enabled = enabled;
		if (enabled)
		{
			button.label.color = ColorConstants.white;
			button.edgeSymbols.color = ColorConstants.grey;
		}
		else
		{
			button.label.color = ColorConstants.darkGrey;
			button.edgeSymbols.color = ColorConstants.darkGrey;
		}
	}

	private void HandleOnRowPressed(DialogButton btn)
	{
		if (selectedDifficultyRow != null)
		{
			selectedDifficultyRow.edgeSymbols.color = edgeSymbols.color;
		}
		selectedDifficultyRow = (QuestDifficultyRow)btn;
		selectedDifficultyRow.edgeSymbols.color = ColorConstants.white;
		currentlySelectedDifficulty = selectedDifficultyRow.difficulty;
		UpdateContents();
	}

	private void HandleOnClosePressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	private void HandleExploreButtonPressed(DialogButton btn)
	{
		if (selectedDifficultyRow != null && OnQuestDifficultySelected != null)
		{
			OnQuestDifficultySelected(selectedDifficultyRow.quest, selectedDifficultyRow.difficulty);
		}
	}

	private void HandleOfflineButtonPressed(DialogButton btn)
	{
		OuroborosWeapon.questToReplay = null;
		Data.Quest quest = selectedDifficultyRow.quest;
		int difficulty = selectedDifficultyRow.difficulty;
		if (OfflineFarmController.singleton.BeginOfflineFarm(quest, difficulty) && OnOfflineFarmSelected != null)
		{
			OnOfflineFarmSelected(quest, difficulty);
		}
	}

	private void HandleLeaderboardButtonPressed(DialogButton btn)
	{
		this.OnShowLeaderboard?.Invoke(questId, currentlySelectedDifficulty, questName);
		if (!HasPressedLeaderboardButton())
		{
			AnalyticsMacros.LocationLeaderboardFirstOpen();
		}
		else
		{
			AnalyticsMacros.LocationLeaderboardOpen();
		}
		SetPressedLeaderboardButton();
		UpdateLeaderboardButtonBadge();
	}

	private void UpdateLeaderboardButtonBadge()
	{
		if (!HasPressedLeaderboardButton())
		{
			leaderboardButton.badge.number = -1;
		}
		else
		{
			leaderboardButton.badge.number = 0;
		}
	}

	private bool HasPressedLeaderboardButton()
	{
		return PlayerPrefs.HasKey(PLAYER_PREFS_PRESSED_LEADERBOARD_BUTTON);
	}

	private void SetPressedLeaderboardButton()
	{
		PlayerPrefs.SetString(PLAYER_PREFS_PRESSED_LEADERBOARD_BUTTON, "true");
	}

	protected override void Start()
	{
		base.Start();
		closeButton.OnPressed += HandleOnClosePressed;
		base.OnClickedOutside += HandleOnClickedOutside;
		exploreButton.OnPressed += HandleExploreButtonPressed;
		offlineButton.OnPressed += HandleOfflineButtonPressed;
		leaderboardButton.OnPressed += HandleLeaderboardButtonPressed;
		base.CurrentState = State.Disabled;
	}

	protected override void Awake()
	{
		base.Awake();
		UpdateLeaderboardButtonBadge();
	}

	protected void OnDestroy()
	{
		closeButton.OnPressed -= HandleOnClosePressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
		exploreButton.OnPressed -= HandleExploreButtonPressed;
		offlineButton.OnPressed -= HandleOfflineButtonPressed;
		leaderboardButton.OnPressed -= HandleLeaderboardButtonPressed;
		RecycleAllRows();
		while (pool.Count > 0)
		{
			pool.Pop().OnPressed -= HandleOnRowPressed;
		}
	}

	private void RecycleAllRows()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			pool.Push(rows[i]);
		}
		scrollContainer.Clear();
		rows.Clear();
	}

	private QuestDifficultyRow AddRow()
	{
		QuestDifficultyRow questDifficultyRow;
		if (pool.Count > 0)
		{
			questDifficultyRow = pool.Pop();
		}
		else
		{
			questDifficultyRow = UnityEngine.Object.Instantiate(rowPrefab);
			questDifficultyRow.OnPressed += HandleOnRowPressed;
		}
		rows.Add(questDifficultyRow);
		scrollContainer.AddRow(questDifficultyRow);
		return questDifficultyRow;
	}
}
