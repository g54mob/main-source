using System;
using UnityEngine;

public class CustomQuestsStoryDialog : CreditsASlide
{
	public enum State
	{
		RevealingLetters = 0,
		WaitingForSkip = 1,
		Done = 2
	}

	public AsciiAnimation topFrame;

	public AsciiAnimation bottomFrame;

	public ModalFade modalFade;

	public int spaceOnTop = 2;

	public int spaceOnBottom = 2;

	public AsciiString messageLabel;

	public AsciiMultiColorTextBox textBox;

	private string message = "";

	public int ticDuration = 30;

	private int totalLetters;

	private int lettersRemaining;

	private int elapsedTics;

	private bool skipBuffered;

	public Action<CustomQuestsStoryDialog> OnOut;

	private bool fadingOut;

	public int lineCount { get; private set; }

	public State currentState { get; private set; }

	public bool FadingOut => fadingOut;

	public event Action<CustomQuestsStoryDialog> OnDone;

	public void FadeOut()
	{
		fadingOut = true;
		modalFade.active = false;
	}

	public void SetMessage(string newMessage)
	{
		message = newMessage;
		Reset();
	}

	public override void Reset()
	{
		topFrame.Sprite.Load();
		bottomFrame.Sprite.Load();
		currentState = State.RevealingLetters;
		elapsedTics = 0;
		skipBuffered = false;
		topFrame.Stop();
		bottomFrame.Stop();
		topFrame.Play();
		bottomFrame.Play();
		if (modalFade != null)
		{
			modalFade.active = true;
		}
		textBox.Text = message;
		textBox.UpdateContents();
		lineCount = textBox.Lines.Count;
		totalLetters = 0;
		lettersRemaining = 0;
		for (int i = 0; i < textBox.Lines.Count; i++)
		{
			totalLetters += textBox.Lines[i].Length;
		}
	}

	public override bool IsDone()
	{
		return currentState == State.Done;
	}

	public override void UpdateTic()
	{
		elapsedTics++;
		if (currentState == State.RevealingLetters)
		{
			lettersRemaining++;
			if (skipBuffered || lettersRemaining >= totalLetters)
			{
				currentState = State.WaitingForSkip;
				skipBuffered = false;
				lettersRemaining = totalLetters;
				topFrame.Stop();
				bottomFrame.Stop();
				topFrame.Sprite.SetFrameIndex(topFrame.Sprite.FrameCount - 1);
				bottomFrame.Sprite.SetFrameIndex(bottomFrame.Sprite.FrameCount - 1);
			}
		}
		else if (currentState == State.WaitingForSkip && (skipBuffered || (elapsedTics >= ticDuration && ticDuration > 0)))
		{
			currentState = State.Done;
			skipBuffered = false;
			this.OnDone?.Invoke(this);
		}
		if (fadingOut && modalFade.Alpha <= 0f)
		{
			fadingOut = false;
			OnOut?.Invoke(this);
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			skipBuffered = true;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!fadingOut)
		{
			DoDraw(r, offsetX, offsetY);
		}
		else if (modalFade != null)
		{
			modalFade.Draw(r);
		}
	}

	private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		int num = Mathf.Clamp(spaceOnTop - 1, 0, 10);
		int num2 = Mathf.Clamp(spaceOnBottom + num - 3, -2, 8);
		int num3 = Mathf.Max(textBox.width, topFrame.Sprite.width, bottomFrame.Sprite.width);
		int num4 = topFrame.Sprite.height + bottomFrame.Sprite.height + lineCount + spaceOnTop + spaceOnBottom;
		for (int i = 0; i < num4; i++)
		{
			int y = offsetY + i - num4 / 2;
			for (int j = 0; j < num3; j++)
			{
				int x = offsetX + j - num3 / 2;
				r.SetCell(x, y, ' ', Color.white, Color.black);
			}
		}
		offsetY -= lineCount >> 1;
		offsetY -= num;
		topFrame.Sprite.Draw(r, offsetX, offsetY);
		bottomFrame.Sprite.Draw(r, offsetX, offsetY + lineCount + num2);
		messageLabel.alignment = AsciiString.Alignment.Center;
		int num5 = lettersRemaining;
		bool flag = false;
		int num6 = 0;
		for (int k = 0; k < textBox.Lines.Count; k++)
		{
			string text = textBox.Lines[k];
			int length = text.Length;
			if (length > num5)
			{
				flag = true;
				text = text.Substring(0, num5);
				text = text.PadRight(length, ' ');
			}
			else
			{
				num5 -= text.Length;
			}
			messageLabel.SetValue(text);
			messageLabel.SetColorMask(textBox.ColorMask, num6);
			messageLabel.Draw(r, offsetX, offsetY + num + k);
			if (!flag && num5 > 0)
			{
				num6 += text.Length;
				continue;
			}
			break;
		}
	}
}
