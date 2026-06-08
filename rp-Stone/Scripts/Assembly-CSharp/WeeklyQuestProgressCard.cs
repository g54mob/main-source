using System.Collections.Generic;
using UnityEngine;

public class WeeklyQuestProgressCard : AsciiObject
{
	private enum State
	{
		Hidden = 0,
		In1 = 1,
		In2 = 2,
		Idle = 3,
		GoalCompleted1 = 4,
		GoalCompleted2 = 5,
		GoalCompleted3 = 6,
		PostGoalCompletedPause = 7,
		Out = 8
	}

	private readonly int GOAL_COMPLETED_DURATION = 15;

	public AsciiString mainTitle;

	public AsciiString timeTitle;

	public AsciiString goalTitle;

	public AsciiString averageTime;

	public AsciiString goalTime;

	private List<Color> betterColorMask = new List<Color>(new Color[5]
	{
		Color.green,
		Color.green,
		Color.green,
		Color.green,
		Color.green
	});

	private List<Color> worseColorMask = new List<Color>(new Color[5]
	{
		Color.red,
		Color.red,
		Color.red,
		Color.red,
		Color.red
	});

	private State currentState;

	private int elapsedTics;

	private bool isGoalCompleted;

	private float f_posX;

	private float f_velX;

	public float f_accelX = 1f;

	public float f_deccelX = 2f;

	public float f_accelOutX = 1f;

	public static WeeklyQuestProgressCard singleton { get; private set; }

	public void Show(int prevAverage, int newAverage, int goal)
	{
		isGoalCompleted = newAverage <= goal;
		string text = Te.xt("tid_time_suffix_frames");
		int num = prevAverage / 30;
		int num2 = prevAverage - num * 30;
		string text2 = Utils.FormatTimeCasual(num, morePrecision: true);
		text2 = text2 + " " + num2 + text;
		int colorMaskStartIndex = -(text2.Length + 1);
		int num3 = prevAverage - newAverage;
		List<Color> colorMask = betterColorMask;
		if (num3 < 0)
		{
			colorMask = worseColorMask;
			text2 = text2 + " +" + -num3 + text;
		}
		else
		{
			text2 = text2 + " -" + num3 + text;
		}
		averageTime.SetValue(text2);
		averageTime.SetColorMask(colorMask, colorMaskStartIndex);
		num = goal / 30;
		num2 = goal - num * 30;
		text2 = Utils.FormatTimeCasual(num, morePrecision: true);
		text2 = text2 + " " + num2 + Te.xt("tid_time_suffix_frames");
		goalTime.SetValue(text2);
		SetState(State.In1);
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.In1:
			f_posX = 0f;
			f_velX = 0f;
			break;
		case State.Idle:
			f_posX = -Width;
			break;
		case State.GoalCompleted1:
			SfxController.singleton.Play("level_up");
			break;
		case State.Out:
			f_velX = 0f;
			break;
		}
		currentState = newState;
		elapsedTics = 0;
	}

	public override void UpdateTic()
	{
		if (currentState == State.Hidden)
		{
			return;
		}
		elapsedTics++;
		if (currentState == State.In1)
		{
			f_velX -= f_accelX;
			f_posX += f_velX;
			if (f_posX < (float)(-Width))
			{
				SetState(State.In2);
			}
		}
		else if (currentState == State.In2)
		{
			f_velX += f_deccelX;
			f_posX += f_velX;
			if (f_posX >= (float)(-Width))
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.Idle)
		{
			if (isGoalCompleted && elapsedTics >= 15)
			{
				SetState(State.GoalCompleted1);
			}
			else if (elapsedTics >= 120)
			{
				SetState(State.Out);
			}
		}
		else if (currentState == State.GoalCompleted1 && elapsedTics >= GOAL_COMPLETED_DURATION)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.GoalCompleted2)
		{
			if (elapsedTics >= GOAL_COMPLETED_DURATION)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.GoalCompleted3 && elapsedTics >= GOAL_COMPLETED_DURATION)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.PostGoalCompletedPause && elapsedTics >= 30)
		{
			SetState(State.Out);
		}
		else if (currentState == State.Out)
		{
			f_velX += f_accelOutX;
			f_posX += f_velX;
			if (f_posX > 0f)
			{
				SetState(State.Hidden);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState != State.Hidden)
		{
			offsetX += PositionX;
			offsetX += Mathf.RoundToInt(f_posX);
			offsetY += PositionY;
			DrawBorder(r, offsetX, offsetY);
			mainTitle.Draw(r, offsetX, offsetY);
			timeTitle.Draw(r, offsetX, offsetY);
			goalTitle.Draw(r, offsetX, offsetY);
			averageTime.Draw(r, offsetX, offsetY);
			goalTime.Draw(r, offsetX, offsetY);
			if (currentState == State.GoalCompleted1)
			{
				SetBrightness(r, offsetX, offsetY, (float)elapsedTics / (float)GOAL_COMPLETED_DURATION);
			}
			else if (currentState == State.GoalCompleted2)
			{
				SetBrightness(r, offsetX, offsetY, 1f);
			}
			else if (currentState == State.GoalCompleted3)
			{
				SetBrightness(r, offsetX, offsetY, 1f - (float)elapsedTics / (float)GOAL_COMPLETED_DURATION);
			}
		}
	}

	private void DrawBorder(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < Width; i++)
		{
			int x = i + offsetX;
			for (int j = 0; j < Height; j++)
			{
				int y = j + offsetY;
				char c = ' ';
				if (i == 0)
				{
					c = ((j != 0) ? ((j != Height - 1) ? '│' : '└') : '┌');
				}
				else if (i == Width - 1)
				{
					c = ((j != 0) ? ((j != Height - 1) ? '│' : '┘') : '┐');
				}
				else if (j == 0 || j == Height - 1)
				{
					c = '─';
				}
				r.SetCell(x, y, SpecialSymbols.Map(c), ColorConstants.darkGrey, ColorConstants.black);
			}
		}
	}

	private void SetBrightness(AsciiRenderProcedural r, int offsetX, int offsetY, float percent)
	{
		for (int i = 0; i < Width; i++)
		{
			int x = i + offsetX;
			for (int j = 0; j < Height; j++)
			{
				int y = j + offsetY;
				AsciiCellProcedural cell = r.GetCell(x, y);
				if (cell != null)
				{
					cell.SetForeground(Color.Lerp(cell.GetForeground(), ColorConstants.white, percent));
					cell.SetBackground(Color.Lerp(cell.GetBackground(), ColorConstants.white, percent));
				}
			}
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
