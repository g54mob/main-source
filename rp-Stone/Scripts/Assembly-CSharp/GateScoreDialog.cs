public class GateScoreDialog : ScrollBG
{
	private enum SubState
	{
		Title = 0,
		Subtitle = 1,
		Fiends = 2,
		Money = 3,
		Consumables = 4,
		TotalScore = 5,
		NewHighScore = 6,
		BestScore = 7
	}

	public AsciiString title;

	public AsciiString subTitle;

	public AsciiString fiendsLabel;

	public IncreasingNumberString fiendsValueLabel;

	public AsciiString moneyLeftLabel;

	public IncreasingNumberString moneyLeftValueLabel;

	public AsciiString consumablesLabel;

	public IncreasingNumberString consumablesValueLabel;

	public AsciiString totalScoreLabel;

	public IncreasingNumberString totalScoreValueLabel;

	public AsciiString bestScoreLabel;

	public AsciiString bestScoreValue;

	public AsciiString newHighScoreLabel;

	public int newHighscoreBlinkPeriod = 40;

	public int consumableIconX;

	public int consumableIconY;

	private SubState currentSubState;

	private int subStateElapsedTime;

	public GateData.Result result { get; set; }

	private void ChangeSubState(SubState newSubState)
	{
		switch (newSubState)
		{
		case SubState.Title:
		{
			string value = GameStates.Singleton.gateController.CurrentGate.name;
			title.SetValue(value);
			break;
		}
		case SubState.Fiends:
			fiendsValueLabel.displayedValue = 0L;
			fiendsValueLabel.targetValue = result.enemiesKilled;
			break;
		case SubState.Money:
			moneyLeftValueLabel.displayedValue = 0L;
			moneyLeftValueLabel.targetValue = result.moneyLeft;
			break;
		case SubState.Consumables:
			consumablesValueLabel.displayedValue = 0L;
			consumablesValueLabel.targetValue = result.consumablePoints;
			break;
		case SubState.TotalScore:
			totalScoreValueLabel.displayedValue = 0L;
			totalScoreValueLabel.targetValue = result.totalScore;
			break;
		}
		currentSubState = newSubState;
		subStateElapsedTime = 0;
	}

	public void Show()
	{
		SetState(State.In);
		ChangeSubState(SubState.Title);
	}

	public void Hide()
	{
		SetState(State.Out);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		subStateElapsedTime++;
		if (base.CurrentState == State.Idle && AsciiMouse.singleton.up0)
		{
			Hide();
		}
		if (currentSubState == SubState.Title && subStateElapsedTime >= 10)
		{
			ChangeSubState(SubState.Subtitle);
		}
		else if (currentSubState == SubState.Subtitle && subStateElapsedTime >= 10)
		{
			ChangeSubState(SubState.Fiends);
		}
		else if (currentSubState == SubState.Fiends)
		{
			fiendsValueLabel.UpdateTic();
			if (subStateElapsedTime >= 10 && fiendsValueLabel.displayedValue == fiendsValueLabel.targetValue)
			{
				ChangeSubState(SubState.Money);
			}
		}
		else if (currentSubState == SubState.Money)
		{
			moneyLeftValueLabel.UpdateTic();
			if (subStateElapsedTime >= 10 && moneyLeftValueLabel.displayedValue == moneyLeftValueLabel.targetValue)
			{
				ChangeSubState(SubState.Consumables);
			}
		}
		else if (currentSubState == SubState.Consumables)
		{
			consumablesValueLabel.UpdateTic();
			if (subStateElapsedTime >= 10 && consumablesValueLabel.displayedValue == consumablesValueLabel.targetValue)
			{
				ChangeSubState(SubState.TotalScore);
			}
		}
		else if (currentSubState == SubState.TotalScore)
		{
			totalScoreValueLabel.UpdateTic();
			if (subStateElapsedTime >= 10 && totalScoreValueLabel.displayedValue == totalScoreValueLabel.targetValue)
			{
				ChangeSubState(SubState.NewHighScore);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (scaleX >= 0.1f)
		{
			int num = (int)((float)Width * scaleX);
			int num2 = offsetX + PositionX + (Width - num) / 2;
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				left = num2,
				right = num2
			});
			if (currentSubState == SubState.BestScore)
			{
				bestScoreLabel.Draw(r, offsetX, offsetY);
				bestScoreValue.Draw(r, offsetX, offsetY);
			}
			else if (currentSubState == SubState.NewHighScore && subStateElapsedTime % newHighscoreBlinkPeriod < newHighscoreBlinkPeriod >> 1)
			{
				newHighScoreLabel.Draw(r, offsetX, offsetY);
			}
			switch (currentSubState)
			{
			case SubState.TotalScore:
			case SubState.NewHighScore:
			case SubState.BestScore:
				totalScoreLabel.Draw(r, offsetX, offsetY);
				totalScoreValueLabel.Draw(r, offsetX, offsetY);
				goto case SubState.Consumables;
			case SubState.Consumables:
				consumablesLabel.Draw(r, offsetX, offsetY);
				consumablesValueLabel.Draw(r, offsetX, offsetY);
				goto case SubState.Money;
			case SubState.Money:
				moneyLeftLabel.Draw(r, offsetX, offsetY);
				moneyLeftValueLabel.Draw(r, offsetX, offsetY);
				goto case SubState.Fiends;
			case SubState.Fiends:
				fiendsLabel.Draw(r, offsetX, offsetY);
				fiendsValueLabel.Draw(r, offsetX, offsetY);
				goto case SubState.Subtitle;
			case SubState.Subtitle:
				subTitle.Draw(r, offsetX, offsetY);
				goto case SubState.Title;
			case SubState.Title:
				title.Draw(r, offsetX, offsetY);
				break;
			}
			r.PopClip();
		}
	}
}
