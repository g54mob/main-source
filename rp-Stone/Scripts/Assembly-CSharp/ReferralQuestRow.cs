using System;
using UnityEngine;

public class ReferralQuestRow : DialogButton
{
	public enum RowState
	{
		Closed = 0,
		Open = 1,
		Opening = 2,
		Closing = 3
	}

	public AsciiString title;

	public AsciiString newLabel;

	public AsciiString codePrefix;

	public AsciiString codeLabel;

	public DialogButton copyButton;

	public int rewardIconX;

	public int rewardIconY;

	public string rewardIconPath;

	private AsciiSprite rewardIcon;

	public AsciiMultiColorTextBox infoBox;

	public FilledProgressBar progressBar;

	public AsciiString timeRemaining;

	public DialogButton claimRewardButton;

	public RowState currentRowState;

	private int initialHeight;

	private int targetHeight;

	public Action OnClaimReferralReward;

	private ButtonSheen mySheen;

	private bool playSheenAnim;

	private bool isProgressBarShowing;

	public ScrollContainer scrollContainer { get; set; }

	public ReferralDataModel data { get; private set; }

	public void Setup(ReferralDataModel data)
	{
		this.data = data;
		SetRowState(RowState.Closed);
		if (rewardIcon == null)
		{
			rewardIcon = IconLoader.Singleton.GetSharedIcon(rewardIconPath);
		}
		if (data != null)
		{
			codeLabel.SetValue(data.referralKey);
			UpdateTimeRemainingLabel();
			UpdateProgressBar();
			UpdateInfoText();
			playSheenAnim = data.isNewQuestRow || data.redemptionCount.GetValue() == 0;
		}
	}

	public void Close()
	{
		SetRowState(RowState.Closed);
	}

	public void SetRowState(RowState newState)
	{
		switch (newState)
		{
		case RowState.Closed:
			Height = initialHeight;
			scrollContainer.UpdateForHeightChange();
			GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			break;
		case RowState.Opening:
			targetHeight = ComputeOpenedHeight();
			data.isNewQuestRow = false;
			break;
		case RowState.Closing:
			targetHeight = initialHeight;
			break;
		case RowState.Open:
			targetHeight = ComputeOpenedHeight();
			Height = targetHeight;
			scrollContainer.UpdateForHeightChange();
			GameStates.Singleton.customQuestsScreen.ScheduleUpdateContainerPosition();
			break;
		}
		currentRowState = newState;
	}

	public override void UpdateTic()
	{
		if (currentRowState != RowState.Opening && currentRowState != RowState.Closing)
		{
			base.UpdateTic();
		}
		if (base.ElapsedStateTics % 120 == 0)
		{
			SetCopyButtonEnabled(value: true);
		}
		if (base.ElapsedStateTics % 15 == 0)
		{
			UpdateTimeRemainingLabel();
		}
		if (currentRowState == RowState.Open)
		{
			if (copyButton.enabled)
			{
				copyButton.UpdateTic();
			}
			if (claimRewardButton.enabled)
			{
				claimRewardButton.UpdateTic();
			}
		}
		else if (currentRowState == RowState.Opening)
		{
			Height++;
			scrollContainer.UpdateForHeightChange();
			if (Height >= targetHeight)
			{
				SetRowState(RowState.Open);
			}
		}
		else if (currentRowState == RowState.Closing)
		{
			Height--;
			scrollContainer.UpdateForHeightChange();
			if (Height <= targetHeight)
			{
				SetRowState(RowState.Closed);
			}
		}
		else if (currentRowState == RowState.Closed && claimRewardButton.enabled)
		{
			claimRewardButton.UpdateTic();
		}
	}

	private int ComputeOpenedHeight()
	{
		int num = 12 + infoBox.lineCount;
		if (isProgressBarShowing || claimRewardButton.enabled)
		{
			num++;
		}
		return num;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (data == null)
		{
			return;
		}
		base.Draw(r, offsetX, offsetY);
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		if (currentRowState == RowState.Closed && data.isNewQuestRow)
		{
			newLabel.Draw(r, num, num2);
		}
		if (currentRowState == RowState.Closed || currentRowState == RowState.Closing)
		{
			if ((bool)rewardIcon)
			{
				rewardIcon.Draw(r, num + rewardIconX, num2 + rewardIconY);
			}
			if (claimRewardButton.enabled)
			{
				title.Draw(r, num, num2);
				claimRewardButton.Draw(r, num, num2 + 3);
			}
			else
			{
				title.Draw(r, num, num2 + 1);
				timeRemaining.Draw(r, num - timeRemaining.PositionX + Width / 2, num2 + Height - 2);
			}
		}
		else
		{
			title.Draw(r, num, num2);
			if ((bool)rewardIcon)
			{
				rewardIcon.Draw(r, num + rewardIconX, num2 + rewardIconY + 1);
			}
			if (claimRewardButton.enabled)
			{
				claimRewardButton.Draw(r, num + 1, num2 + infoBox.positionY + infoBox.lineCount);
			}
			else if (isProgressBarShowing)
			{
				progressBar.Draw(r, num, num2 + infoBox.positionY + infoBox.lineCount);
			}
			codePrefix.Draw(r, num, num2);
			codeLabel.Draw(r, num + codePrefix.Length, num2);
			copyButton.Draw(r, num, num2);
			infoBox.Draw(r, num, num2);
			if (isProgressBarShowing)
			{
				timeRemaining.Draw(r, num, num2 + infoBox.positionY + infoBox.lineCount + 1);
			}
			else if (!claimRewardButton.enabled)
			{
				timeRemaining.Draw(r, num - timeRemaining.PositionX + Width / 2, num2 + Height - 2);
			}
		}
		if (playSheenAnim && base.lastDrawnY > 0 && base.lastDrawnY + Height < r.height)
		{
			playSheenAnim = false;
			mySheen.Play();
		}
		mySheen.Draw(r, num, num2);
	}

	private void UpdateTimeRemainingLabel()
	{
		if (data == null)
		{
			timeRemaining.Clear();
		}
		else if (data.HasExpired())
		{
			if (timeRemaining.Value != "")
			{
				timeRemaining.Clear();
				GameStates.Singleton.customQuestsScreen.MarkDirty();
			}
		}
		else
		{
			string value = Utils.FormatTimeCasual((int)(data.expiration - DateTime.Now).TotalSeconds);
			timeRemaining.SetValue(value);
		}
	}

	private void UpdateProgressBar()
	{
		claimRewardButton.enabled = data.HasTreasureToCollect();
		isProgressBarShowing = data.progressGoal > 1 && !claimRewardButton.enabled;
		if (isProgressBarShowing)
		{
			progressBar.targetPercent = (float)data.progressValue / (float)data.progressGoal;
			progressBar.label.SetValue($"{data.progressValue}/{data.progressGoal}");
		}
	}

	private void UpdateInfoText()
	{
		if (isProgressBarShowing)
		{
			infoBox.Text = Te.xt("tid_referral_description") + "\n\n" + Te.xt("tid_referral_extension");
		}
		else
		{
			infoBox.Text = Te.xt("tid_referral_description");
		}
	}

	private void SetCopyButtonEnabled(bool value)
	{
		if (value)
		{
			copyButton.label.color = ColorConstants.white;
		}
		else
		{
			copyButton.label.color = copyButton.edgeSymbols.color;
		}
		copyButton.enabled = value;
	}

	private void HandleOnPressed(DialogButton btn)
	{
		if (claimRewardButton.enabled)
		{
			HandleClaimRewardPressed(null);
		}
		else if (currentRowState == RowState.Closed)
		{
			SetRowState(RowState.Opening);
		}
		else if (currentRowState == RowState.Open)
		{
			SetRowState(RowState.Closing);
		}
	}

	private void HandleClaimRewardPressed(DialogButton btn)
	{
		if (OnClaimReferralReward != null)
		{
			OnClaimReferralReward();
		}
	}

	private void HandleCopyPressed(DialogButton btn)
	{
		SetCopyButtonEnabled(value: false);
		GUIUtility.systemCopyBuffer = codeLabel.Value;
	}

	protected override void Awake()
	{
		base.Awake();
		base.OnPressed += HandleOnPressed;
		copyButton.OnPressed += HandleCopyPressed;
		claimRewardButton.OnPressed += HandleClaimRewardPressed;
		initialHeight = Height;
		mySheen = GetComponent<ButtonSheen>();
	}

	protected override void OnDestroy()
	{
		base.OnPressed -= HandleOnPressed;
		copyButton.OnPressed -= HandleCopyPressed;
		claimRewardButton.OnPressed -= HandleClaimRewardPressed;
		base.OnDestroy();
	}
}
