using System;
using UnityEngine;

public class WeeklyQuestsRow : DialogButton, INewIndicatorProvider
{
	public enum RowState
	{
		Normal = 0,
		Completed = 1
	}

	public AsciiString weeklyHeader;

	public AsciiMultiColorTextBox titleBox;

	public AsciiString timeRemaining;

	public int rewardIconX;

	public int rewardIconY;

	public string rewardIconPath;

	private AsciiSprite rewardIcon;

	public DialogButton claimRewardButton;

	private ButtonSheen mySheen;

	public RowState currentRowState;

	public Data.WeeklyQuest quest;

	private float lastClockRefreshTime;

	public void Setup(Data.WeeklyQuest quest)
	{
		this.quest = quest;
		SetRowState(RowState.Normal);
		if (rewardIcon == null)
		{
			rewardIcon = IconLoader.Singleton.GetSharedIcon(rewardIconPath);
		}
		if (quest.type == Data.WeeklyQuest.Type.FindAllStones)
		{
			titleBox.Text = Te.xt("Find all Soul Stones");
		}
		else if (quest.type == Data.WeeklyQuest.Type.UpgradeStarOuro)
		{
			titleBox.Text = Te.xt("Upgrade") + ":\n• [color=#00ffff]" + Te.xt("Star Stone") + "[/color]\n• [color=#00ffff]" + Te.xt("Ouroboros Stone") + "[/color]";
		}
		else if (quest.type == Data.WeeklyQuest.Type.UpgradeStarStone)
		{
			titleBox.Text = Te.xt("Upgrade") + ":\n• [color=#00ffff]" + Te.xt("Star Stone") + "[/color]";
		}
		else if (quest.type == Data.WeeklyQuest.Type.UpgradeOuroboros)
		{
			titleBox.Text = Te.xt("Upgrade") + ":\n• [color=#00ffff]" + Te.xt("Ouroboros Stone") + "[/color]";
		}
		else if (quest.type == Data.WeeklyQuest.Type.ImproveStars)
		{
			SetupImproveStars(quest);
		}
		else if (quest.type == Data.WeeklyQuest.Type.ImproveTime)
		{
			SetupImproveTime(quest);
		}
		UpdateVerticalLayout(quest);
		if (quest.completed)
		{
			SetRowState(RowState.Completed);
		}
		else
		{
			UpdateTimeRemainingLabel();
		}
	}

	private void SetupImproveStars(Data.WeeklyQuest quest)
	{
		string arg = Te.xt(QuestController.singleton.GetQuestById(quest.locId).name);
		titleBox.Text = string.Format(Te.xt("Beat {0} at difficulty\n☆"), arg);
	}

	private void SetupImproveTime(Data.WeeklyQuest quest)
	{
		string arg = Te.xt(QuestController.singleton.GetQuestById(quest.locId).name);
		if (quest.completed)
		{
			titleBox.Text = string.Format(Te.xt("Improve your time in {0}"), arg);
			return;
		}
		int starDifficultyForQuest = QuestController.singleton.GetStarDifficultyForQuest(quest.locId);
		Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(quest.locId, starDifficultyForQuest);
		if (statsForQuest != null)
		{
			int num = Mathf.RoundToInt(statsForQuest.averageTime.GetValue()) - quest.goal;
			int num2 = Mathf.Max(1, num / 30);
			titleBox.Text = string.Format(Te.xt("Improve your time in {0} by {1} seconds"), arg, num2);
		}
		else
		{
			titleBox.Text = "No offline stats for " + quest.locId;
		}
	}

	private void UpdateVerticalLayout(Data.WeeklyQuest quest)
	{
		Height = 7;
		if (titleBox.lineCount == 1)
		{
			if (quest.completed)
			{
				titleBox.positionY = 2;
			}
			else
			{
				titleBox.positionY = 3;
			}
		}
		else if (titleBox.lineCount == 2)
		{
			if (quest.completed)
			{
				titleBox.positionY = 1;
			}
			else
			{
				titleBox.positionY = 3;
			}
		}
		else if (quest.completed)
		{
			titleBox.positionY = 1;
			int num = titleBox.lineCount - 2;
			Height += num;
		}
		else if (titleBox.lineCount == 3)
		{
			titleBox.positionY = 2;
		}
		else
		{
			titleBox.positionY = 1;
		}
		claimRewardButton.PositionY = Height - claimRewardButton.Height - 1;
	}

	private void SetRowState(RowState newState)
	{
		switch (newState)
		{
		case RowState.Normal:
			badge.number = 0;
			break;
		case RowState.Completed:
			badge.number = -1;
			break;
		}
		currentRowState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentRowState == RowState.Completed)
		{
			claimRewardButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (!quest.hasSeen && base.lastDrawnY > -2 && base.lastDrawnY < r.height - 3)
		{
			quest.hasSeen = true;
			CustomQuestsController.Singleton.UpdateBadge();
		}
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		if (titleBox.positionY > 1)
		{
			weeklyHeader.Draw(r, num + titleBox.positionX, num2 + titleBox.positionY - 1);
		}
		titleBox.Draw(r, num, num2);
		if ((bool)rewardIcon)
		{
			rewardIcon.Draw(r, num + rewardIconX, num2 + rewardIconY);
		}
		if (quest.type == Data.WeeklyQuest.Type.ImproveStars)
		{
			QuestRowStarString.Draw(r, num + titleBox.positionX, num2 + titleBox.positionY + titleBox.lineCount - 1, quest.goal);
		}
		if (currentRowState == RowState.Completed)
		{
			claimRewardButton.Draw(r, num, num2);
		}
		else
		{
			timeRemaining.Draw(r, num + Width / 2, num2);
		}
		mySheen.Draw(r, num, num2);
	}

	private void UpdateTimeRemainingLabel()
	{
		int num = (int)(WeeklyQuestsController.singleton.expiration - DateTime.Now).TotalSeconds;
		if (num > 0)
		{
			string value = Utils.FormatTimeCasual(num);
			timeRemaining.SetValue(value);
		}
		else
		{
			timeRemaining.Clear();
		}
	}

	private bool IsExpired()
	{
		return DateTime.Now > WeeklyQuestsController.singleton.expiration;
	}

	private void Update()
	{
		if (GameStates.Singleton.CurrentState < GameStates.State.Playing && GameStates.Singleton.CurrentState >= GameStates.State.QuestScreen && CustomQuestsController.Singleton.customQuestsScreen.currentState != CustomQuestsScreen.State.OpeningTreasure && Time.realtimeSinceStartup - lastClockRefreshTime >= 1f)
		{
			lastClockRefreshTime = Time.realtimeSinceStartup;
			UpdateTimeRemainingLabel();
			if (IsExpired())
			{
				WeeklyQuestsController.singleton.TryGenerateNew();
				if (!IsExpired())
				{
					CustomQuestsController.Singleton.customQuestsScreen.MarkDirty();
					mySheen.Play();
				}
			}
		}
		if (GameStates.Singleton.CurrentState == GameStates.State.CustomQuests)
		{
			mySheen.enabled = true;
		}
		else
		{
			mySheen.enabled = false;
		}
	}

	public virtual bool IsNewIndicating()
	{
		return currentRowState == RowState.Completed;
	}

	public virtual Color GetNewIndicatorColor()
	{
		return ColorConstants.rewardGreen;
	}

	public virtual string GetNewIndicatorString()
	{
		return Te.xt("!");
	}

	protected override void Awake()
	{
		base.Awake();
		mySheen = GetComponent<ButtonSheen>();
	}
}
