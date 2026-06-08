using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestDifficultySubMenu : DialogNineSlice
{
	public AsciiString title;

	public AsciiString subtitle;

	public ScrollContainer scrollContainer;

	public QuestDifficultyRow rowPrefab;

	public DialogButton closeButton;

	public DialogButton leaderboardButton;

	public Action<Data.Quest, int> OnQuestDifficultySelected;

	private int defaultY;

	private int defaultHeight;

	public int testOffset;

	private string questId;

	private int currentlySelectedDifficulty;

	private string questName;

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
		int num2 = Mathf.Min(a, QuestController.singleton.GetStarDifficultyForQuest(questData.id) + testOffset);
		RecycleAllRows();
		for (int i = num; i <= num2; i++)
		{
			QuestDifficultyRow questDifficultyRow = AddRow();
			questDifficultyRow.quest = questData;
			questDifficultyRow.difficulty = i;
		}
		scrollContainer.ScrollToBottom();
		if (rows.Count < 3)
		{
			Height = defaultHeight - rowPrefab.Height;
			PositionY = defaultY + rowPrefab.Height / 2;
		}
		else
		{
			Height = defaultHeight;
			PositionY = defaultY;
		}
		scrollContainer.PositionY = scrollContainer.scrollBar.PositionY;
		scrollContainer.Height = scrollContainer.scrollBar.Height;
		if (rows.Count < 4)
		{
			scrollContainer.PositionY += 2;
			scrollContainer.Height -= 2;
		}
		questId = questData.id;
		currentlySelectedDifficulty = CalculateMaxAvailableLeaderboardLevel(num2);
		questName = questData.Name;
	}

	private void HandleOnRowPressed(DialogButton btn)
	{
		QuestDifficultyRow questDifficultyRow = (QuestDifficultyRow)btn;
		if (OnQuestDifficultySelected != null)
		{
			OnQuestDifficultySelected(questDifficultyRow.quest, questDifficultyRow.difficulty);
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
		if (base.CurrentState == State.Idle && GameStates.Singleton.CurrentState == GameStates.State.QuestScreen && Input.GetKeyDown(KeyCode.Escape))
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
		}
		closeButton.UpdateTic();
		if (ShouldShowLeaderboardButton())
		{
			leaderboardButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			if (rows.Count <= 3)
			{
				subtitle.Draw(r, offsetX, offsetY);
			}
			closeButton.Draw(r, offsetX, offsetY);
			scrollContainer.Draw(r, offsetX, offsetY);
			if (ShouldShowLeaderboardButton())
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

	protected override void Awake()
	{
		base.Awake();
		UpdateLeaderboardButtonBadge();
	}

	protected override void Start()
	{
		base.Start();
		closeButton.OnPressed += HandleOnClosePressed;
		base.OnClickedOutside += HandleOnClickedOutside;
		leaderboardButton.OnPressed += HandleLeaderboardButtonPressed;
		defaultHeight = Height;
		defaultY = PositionY;
		base.CurrentState = State.Disabled;
	}

	protected void OnDestroy()
	{
		closeButton.OnPressed -= HandleOnClosePressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
		leaderboardButton.OnPressed -= HandleLeaderboardButtonPressed;
		RecycleAllRows();
		while (pool.Count > 0)
		{
			pool.Pop().OnPressed -= HandleOnRowPressed;
		}
	}

	private void HandleOnClosePressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		Hide();
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

	private int CalculateMaxAvailableLeaderboardLevel(int maxLevel)
	{
		return maxLevel / 5 * 5;
	}

	private bool ShouldShowLeaderboardButton()
	{
		if (currentlySelectedDifficulty > 0)
		{
			return true;
		}
		return false;
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
