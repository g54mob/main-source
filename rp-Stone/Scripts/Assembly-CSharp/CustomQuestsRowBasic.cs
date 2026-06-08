using UnityEngine;

public class CustomQuestsRowBasic : CustomQuestsRow, INewIndicatorProvider
{
	public enum RowState
	{
		Normal = 0,
		Completed = 1
	}

	public AsciiTextBox titleBox;

	public FilledProgressBar progressBar;

	public int rewardIconX;

	public int rewardIconY;

	private AsciiSprite rewardIcon;

	public DialogButton claimRewardButton;

	public RowState currentRowState;

	public void Setup(Data.CustomQuestInstance quest)
	{
		base.quest = quest;
		SetRowState(RowState.Normal);
		titleBox.Text = quest.status;
		if (titleBox.lineCount == 1)
		{
			titleBox.positionY = 2;
		}
		else
		{
			titleBox.positionY = 1;
		}
		Item reward = quest.reward;
		rewardIcon = reward.GetIcon();
		progressBar.targetPercent = (float)quest.progress / (float)quest.target;
		progressBar.label.SetValue($"{quest.progress}/{quest.target}");
		if (quest.completed)
		{
			SetRowState(RowState.Completed);
		}
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
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		titleBox.Draw(r, num, num2);
		rewardIcon.Draw(r, num + rewardIconX, num2 + rewardIconY);
		progressBar.Draw(r, num, num2);
		if (currentRowState == RowState.Completed)
		{
			claimRewardButton.Draw(r, num, num2);
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
}
