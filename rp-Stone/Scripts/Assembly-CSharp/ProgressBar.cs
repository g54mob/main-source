using System;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
	public int PositionX;

	public int PositionY;

	public int Width = 10;

	public string leftSymbol = "(";

	public string rightSymbol = ")";

	public string barSymbol = "o";

	private char[] barSymbols = new char[10] { ' ', ' ', '·', '·', '•', '•', '*', '*', 'O', 'o' };

	private Data.TimeProgress timeData;

	private bool playing;

	private bool paused;

	private int lastCellsToDraw;

	public Data.TimeProgress TimeData
	{
		get
		{
			return timeData;
		}
		set
		{
			timeData = value;
		}
	}

	public bool Playing => playing;

	public bool Paused => paused;

	public event Action<Data.TimeProgress> OnComplete;

	public void Play()
	{
		playing = true;
		paused = false;
	}

	public void Pause()
	{
		paused = true;
	}

	public void Stop()
	{
		playing = false;
		paused = false;
	}

	private void Update()
	{
		if (!playing || paused)
		{
			return;
		}
		GameStates.State currentState = GameStates.Singleton.CurrentState;
		if (currentState != GameStates.State.QuestScreen && currentState != GameStates.State.WorkstationScreen && currentState != GameStates.State.ItemScreen)
		{
			return;
		}
		if (QuickCheats.SkipAheadKeyPressed())
		{
			timeData.elapsedMilliseconds = timeData.durationMilliseconds;
		}
		if (timeData == null)
		{
			return;
		}
		timeData.Update(Mathf.RoundToInt(Utils.deltaTime * 1000f));
		if (timeData.IsComplete())
		{
			Stop();
			if (this.OnComplete != null)
			{
				this.OnComplete(timeData);
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		int value = ((leftSymbol.Length > 0) ? leftSymbol[0] : '(');
		int value2 = ((rightSymbol.Length > 0) ? rightSymbol[0] : ')');
		int value3 = ((barSymbol.Length > 0) ? barSymbol[0] : 'o');
		r.SetCell(offsetX - 1, offsetY, value);
		r.SetCell(offsetX + Width, offsetY, value2);
		float num = (float)timeData.elapsedMilliseconds / (float)timeData.durationMilliseconds;
		int num2 = Mathf.FloorToInt((float)Width * num);
		for (int i = 0; i < num2; i++)
		{
			r.SetCell(i + offsetX, offsetY, value3);
		}
		if (num2 < Width)
		{
			int num3 = Mathf.Clamp(Mathf.FloorToInt(((float)Width * num - (float)num2) * (float)barSymbols.Length), 0, barSymbols.Length - 1);
			r.SetCell(num2 + offsetX, offsetY, SpecialSymbols.Map(barSymbols[num3]));
		}
		if (lastCellsToDraw != num2 && num2 < Width && num2 > 0)
		{
			lastCellsToDraw = num2;
			SfxController.singleton.Play("progress_" + num2);
		}
	}
}
