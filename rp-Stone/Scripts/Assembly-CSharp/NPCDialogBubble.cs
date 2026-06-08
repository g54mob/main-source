using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogBubble : DialogNineSlice
{
	public enum NPCDialogState
	{
		In = 0,
		WritingMessage = 1,
		WaitingForSkip = 2,
		Out = 3,
		Done = 4
	}

	public AsciiString messageLabel;

	public AsciiMultiColorTextBox textBox;

	public int preferredWidth = 20;

	public int textPadding = 2;

	public string userTapSfx;

	public bool playerCanSkip = true;

	public bool playerCanClose = true;

	public int autoHideTime = -1;

	private int _stateElapsedTics;

	[SerializeField]
	private int _sourceX;

	[SerializeField]
	private int _sourceY;

	private int totalLetters;

	private int lettersRemaining;

	public NPCDialogState npcDialogState { get; private set; }

	public int lineCount { get; private set; }

	public event Action OnDone;

	public event Action OnTextDisplayed;

	public void SetMessage(string message)
	{
		textBox.Text = message;
		textBox.UpdateContents();
		lineCount = textBox.Lines.Count;
		totalLetters = 0;
		lettersRemaining = 0;
		for (int i = 0; i < textBox.Lines.Count; i++)
		{
			totalLetters += textBox.Lines[i].Length;
		}
		Height = lineCount + 2;
		int num = preferredWidth;
		for (int j = 0; j < textBox.Lines.Count; j++)
		{
			num = Mathf.Max(num, textBox.Lines[j].Length + textPadding * 2);
		}
		Width = num;
	}

	public void SetNPCMouthPosition(int screenX, int screenY)
	{
		_sourceX = screenX;
		_sourceY = screenY;
	}

	private void Update()
	{
		if (playerCanSkip && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
		{
			TryToSkip();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		_stateElapsedTics++;
		if (base.CurrentState == State.Disabled)
		{
			if (npcDialogState != NPCDialogState.Done)
			{
				npcDialogState = NPCDialogState.Done;
				this.OnDone?.Invoke();
			}
		}
		else if (base.CurrentState == State.In)
		{
			npcDialogState = NPCDialogState.In;
		}
		else if (base.CurrentState == State.Out)
		{
			npcDialogState = NPCDialogState.Out;
		}
		else if (base.CurrentState == State.Idle)
		{
			if (npcDialogState == NPCDialogState.In || npcDialogState == NPCDialogState.Out)
			{
				npcDialogState = NPCDialogState.WritingMessage;
			}
			else if (npcDialogState == NPCDialogState.WritingMessage)
			{
				lettersRemaining++;
				if (lettersRemaining >= totalLetters)
				{
					npcDialogState = NPCDialogState.WaitingForSkip;
					this.OnTextDisplayed?.Invoke();
				}
			}
		}
		if (playerCanSkip && AsciiMouse.singleton.down0)
		{
			TryToSkip();
		}
		if (autoHideTime > 0 && _stateElapsedTics >= autoHideTime && npcDialogState == NPCDialogState.WaitingForSkip)
		{
			Hide();
		}
	}

	private void TryToSkip()
	{
		if (GameStates.Singleton.CurrentState != GameStates.State.PlayPaused && GameStates.Singleton.CurrentState != GameStates.State.SequentialPopupRewards && GameStates.Singleton.stateElapsedTics > 5)
		{
			if (npcDialogState == NPCDialogState.In || npcDialogState == NPCDialogState.WritingMessage)
			{
				npcDialogState = NPCDialogState.WaitingForSkip;
				lettersRemaining = totalLetters;
				base.SetState(State.Idle);
				this.OnTextDisplayed?.Invoke();
			}
			else if (playerCanClose && npcDialogState == NPCDialogState.WaitingForSkip)
			{
				SfxController.singleton.Play(userTapSfx);
				Hide();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (offsetX < -PositionX)
		{
			offsetX = -PositionX;
		}
		if (offsetX > r.width - Width - PositionX)
		{
			offsetX = r.width - Width - PositionX;
		}
		if (offsetY < -PositionY)
		{
			offsetY = -PositionY;
		}
		if (offsetY > r.height - lineCount - PositionY - 2)
		{
			offsetY = r.height - lineCount - PositionY - 2;
		}
		base.Draw(r, offsetX, offsetY);
		if (npcDialogState != NPCDialogState.WritingMessage && npcDialogState != NPCDialogState.WaitingForSkip)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY;
		messageLabel.alignment = AsciiString.Alignment.Center;
		int num = lettersRemaining;
		bool flag = false;
		int num2 = 0;
		for (int i = 0; i < textBox.Lines.Count; i++)
		{
			string text = textBox.Lines[i];
			int length = text.Length;
			if (length > num)
			{
				flag = true;
				text = text.Substring(0, num);
				text = text.PadRight(length, ' ');
			}
			else
			{
				num -= text.Length;
			}
			messageLabel.SetValue(text);
			messageLabel.SetColorMask(textBox.ColorMask, num2);
			messageLabel.Draw(r, offsetX + Width / 2, offsetY + 1 + i);
			if (flag || num <= 0)
			{
				break;
			}
			num2 += text.Length;
		}
		if (_sourceX < offsetX && _sourceY < offsetY)
		{
			r.SetCell(offsetX, offsetY, 92);
		}
		else if (_sourceX >= offsetX + Width && _sourceY < offsetY)
		{
			r.SetCell(offsetX + Width - 1, offsetY, 47);
		}
		else if (_sourceX < offsetX && _sourceY >= offsetY + Height)
		{
			r.SetCell(offsetX, offsetY + Height - 1, 47);
		}
		else if (_sourceX >= offsetX + Width && _sourceY >= offsetY + Height)
		{
			r.SetCell(offsetX + Width - 1, offsetY + Height - 1, 92);
		}
		else if (_sourceX < offsetX)
		{
			r.SetCell(offsetX, _sourceY, SpecialSymbols.Map('\''));
			r.SetCell(offsetX - 1, _sourceY, SpecialSymbols.Map('─'), edgeSymbols.color);
		}
		else if (_sourceX >= offsetX + Width)
		{
			r.SetCell(offsetX + Width - 1, _sourceY, SpecialSymbols.Map('\''));
			r.SetCell(offsetX + Width, _sourceY, SpecialSymbols.Map('─'), edgeSymbols.color);
		}
		else if (_sourceY < offsetY)
		{
			r.SetCell(_sourceX, offsetY, 39);
			r.SetCell(_sourceX - 1, offsetY, SpecialSymbols.Map('\u00b4'));
			r.SetCell(_sourceX, offsetY - 1, SpecialSymbols.Map('│'), edgeSymbols.color);
		}
		else if (_sourceY >= offsetY + Height)
		{
			r.SetCell(_sourceX, offsetY + Height - 1, 46);
			r.SetCell(_sourceX + 1, offsetY + Height - 1, 44);
			r.SetCell(_sourceX, offsetY + Height, SpecialSymbols.Map('│'), edgeSymbols.color);
		}
	}

	public void Show()
	{
		_stateElapsedTics = 0;
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	public void SkipToWaiting()
	{
		if (npcDialogState == NPCDialogState.In || npcDialogState == NPCDialogState.WritingMessage)
		{
			npcDialogState = NPCDialogState.WaitingForSkip;
			lettersRemaining = totalLetters;
			base.SetState(State.Idle);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.SetState(State.Disabled);
		npcDialogState = NPCDialogState.Done;
	}

	public void ClearDone()
	{
		this.OnDone = null;
	}

	[StonescriptNativeMethod]
	public object SetOffset(List<object> parameters, InvocationContext ctx)
	{
		if (parameters[0] != null)
		{
			PositionX = (int)parameters[0];
		}
		if (parameters.Count >= 2 && parameters[1] != null)
		{
			PositionY = (int)parameters[1];
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object Close(List<object> parameters, InvocationContext ctx)
	{
		Hide();
		return null;
	}

	[StonescriptNativeGetter("PlayerCanClose")]
	public object GetPlayerCanClose()
	{
		return playerCanClose;
	}

	[StonescriptNativeSetter("PlayerCanClose")]
	public void SetPlayerCanClose(object value)
	{
		playerCanClose = (bool)value;
	}

	[StonescriptNativeGetter("Duration")]
	public object GetDuration()
	{
		return autoHideTime;
	}

	[StonescriptNativeSetter("Duration")]
	public void SetDuration(object value)
	{
		autoHideTime = (int)value;
	}
}
