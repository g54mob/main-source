using System;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextSlide : CreditsASlide
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

	public string message = "";

	public int preferredWidth = 30;

	public int ticDuration = 30;

	public Color[] colors;

	public List<string> _messageLines;

	private string lastMessage;

	public bool dontParseMessageLines;

	private int totalLetters;

	private int lettersRemaining;

	private int elapsedTics;

	private bool skipBuffered;

	private List<Color> colorMask = new List<Color>();

	public State currentState { get; private set; }

	public event Action<CreditsTextSlide> OnDone;

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
		ParseColors();
		if ((_messageLines == null || _messageLines.Count == 0 || lastMessage != message) && !dontParseMessageLines)
		{
			lastMessage = message;
			string[] array = Utils.BreakIntoLines(message, preferredWidth);
			_messageLines = new List<string>();
			for (int i = 0; i < array.Length; i++)
			{
				_messageLines.Add(array[i]);
			}
		}
		totalLetters = 0;
		if (_messageLines == null)
		{
			return;
		}
		for (int j = 0; j < _messageLines.Count; j++)
		{
			if (_messageLines[j].StartsWith("tid"))
			{
				_messageLines[j] = Te.xt(_messageLines[j]);
			}
			totalLetters += _messageLines[j].Length;
		}
		lettersRemaining = 0;
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
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		int num = Mathf.Clamp(spaceOnTop - 1, 0, 10);
		int num2 = Mathf.Clamp(spaceOnBottom + num - 3, -2, 8);
		int num3 = Mathf.Max(preferredWidth, topFrame.Sprite.width, bottomFrame.Sprite.width);
		int num4 = topFrame.Sprite.height + bottomFrame.Sprite.height + _messageLines.Count + spaceOnTop + spaceOnBottom;
		for (int i = 0; i < num4; i++)
		{
			int y = offsetY + i - num4 / 2;
			for (int j = 0; j < num3; j++)
			{
				int x = offsetX + j - num3 / 2;
				r.SetCell(x, y, ' ', Color.white, Color.black);
			}
		}
		offsetY -= _messageLines.Count >> 1;
		offsetY -= num;
		topFrame.Sprite.Draw(r, offsetX, offsetY);
		bottomFrame.Sprite.Draw(r, offsetX, offsetY + _messageLines.Count + num2);
		messageLabel.alignment = AsciiString.Alignment.Center;
		int num5 = lettersRemaining;
		bool flag = false;
		int num6 = 0;
		for (int k = 0; k < _messageLines.Count; k++)
		{
			string text = _messageLines[k];
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
			Color color = ((k < colors.Length) ? colors[k] : ColorConstants.white);
			messageLabel.color = color;
			messageLabel.SetValue(text);
			messageLabel.SetColorMask(colorMask, num6);
			messageLabel.Draw(r, offsetX, offsetY + num + k);
			if (!flag && num5 > 0)
			{
				num6 += text.Length + 1;
				continue;
			}
			break;
		}
	}

	public override bool IsDone()
	{
		return currentState == State.Done;
	}

	private void ParseColors()
	{
		colorMask.Clear();
		int num = 0;
		while (true)
		{
			num = message.IndexOf("[color=", num);
			if (num < 0)
			{
				break;
			}
			int num2 = message.IndexOf("]", num);
			int num3 = message.IndexOf("[/color]", num2);
			string colorStr = message.Substring(num + 7, num2 - num - 7);
			num2++;
			string text = message.Substring(0, num);
			string text2 = message.Substring(num2, num3 - num2);
			num3 += 8;
			string text3 = message.Substring(num3);
			message = text + text2 + text3;
			int startIndex = 0;
			while (true)
			{
				startIndex = text.IndexOf("\\n", startIndex);
				if (startIndex < 0)
				{
					break;
				}
				startIndex += 2;
				num--;
			}
			AddColorInRange(colorStr, num, text2.Length);
		}
	}

	private void AddColorInRange(string colorStr, int startIndex, int length)
	{
		Color color = default(Color);
		if (ColorUtility.TryParseHtmlString(colorStr, out color))
		{
			AddColorInRange(color, startIndex, length);
		}
		else
		{
			Utils.LogError("Failed to parse color from string value: " + colorStr);
		}
	}

	private void AddColorInRange(Color color, int startIndex, int length)
	{
		for (int i = 0; i < startIndex + length; i++)
		{
			if (i >= startIndex)
			{
				if (i < colorMask.Count)
				{
					colorMask[i] = color;
				}
				else
				{
					colorMask.Add(color);
				}
			}
			else if (i >= colorMask.Count)
			{
				colorMask.Add(messageLabel.color);
			}
		}
	}
}
