using UnityEngine;

public class GoalBookEntryUI : AsciiObject
{
	public enum State
	{
		Incomplete = 0,
		Complete = 1,
		EnteringComplete = 2,
		EnteringIncomplete = 3,
		Special = 4
	}

	public AsciiTextBox textBox;

	private Color completedColor;

	private int elapsedTics;

	public bool isHalfEntry { get; set; }

	public State currentState { get; protected set; }

	public void SetText(string text)
	{
		textBox.Text = text;
		Width = textBox.width;
		Height = textBox.lineCount;
	}

	public void SetText(string[] lines)
	{
		textBox.SetLines(lines);
		Width = textBox.width;
		Height = textBox.lineCount;
	}

	public void SetState(State newState)
	{
		currentState = newState;
		switch (newState)
		{
		case State.Complete:
		case State.EnteringIncomplete:
			textBox.color = completedColor;
			break;
		default:
			textBox.color = ColorConstants.white;
			break;
		case State.Special:
			break;
		}
		elapsedTics = 0;
	}

	public override void UpdateTic()
	{
		if (currentState == State.EnteringComplete)
		{
			if (++elapsedTics >= 15)
			{
				SetState(State.Complete);
				return;
			}
			float t = (float)elapsedTics / 15f;
			textBox.color = Color.Lerp(ColorConstants.white, completedColor, t);
		}
		else if (currentState == State.EnteringIncomplete)
		{
			if (++elapsedTics >= 15)
			{
				SetState(State.Incomplete);
				return;
			}
			float t2 = (float)elapsedTics / 15f;
			textBox.color = Color.Lerp(completedColor, ColorConstants.white, t2);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		textBox.Draw(r, offsetX, offsetY);
		if (isHalfEntry || currentState == State.Special)
		{
			return;
		}
		Color rewardGreen = ColorConstants.rewardGreen;
		int value = 111;
		if (currentState == State.Complete)
		{
			rewardGreen = completedColor;
			value = SpecialSymbols.Map('•');
		}
		else if (currentState == State.EnteringComplete)
		{
			switch (elapsedTics / 3)
			{
			case 1:
				rewardGreen = completedColor;
				break;
			case 2:
			case 4:
				rewardGreen = completedColor;
				value = SpecialSymbols.Map('•');
				break;
			case 3:
				rewardGreen = completedColor;
				value = SpecialSymbols.Map('·');
				break;
			}
		}
		else if (currentState == State.EnteringIncomplete)
		{
			switch (elapsedTics / 3)
			{
			case 0:
				rewardGreen = completedColor;
				value = SpecialSymbols.Map('·');
				break;
			case 1:
				value = SpecialSymbols.Map('·');
				break;
			case 2:
				value = SpecialSymbols.Map('•');
				break;
			case 3:
				value = SpecialSymbols.Map('o');
				break;
			case 4:
				value = SpecialSymbols.Map('O');
				break;
			}
		}
		r.SetCell(offsetX - 2, offsetY, value, rewardGreen);
	}

	protected virtual void Awake()
	{
		if (textBox == null)
		{
			textBox = new AsciiTextBox();
			textBox.width = 27;
			textBox.color = ColorConstants.grey;
		}
		completedColor = textBox.color;
	}
}
