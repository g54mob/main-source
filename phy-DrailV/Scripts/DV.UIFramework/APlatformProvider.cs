using System;
using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using TMPro;
using UnityEngine;

public abstract class APlatformProvider : SingletonBehaviour<APlatformProvider>
{
	[Flags]
	public enum Platform : byte
	{
		Windows = 1,
		Linux = 2,
		SteamDeck = 4,
		SteamVR = 8,
		GeForceNOW = 0x10,
		Any = byte.MaxValue
	}

	public readonly struct TextInputRequest
	{
		public readonly TMP_InputField InputField;

		public readonly bool IsMultiLine;

		public readonly string Description;

		public readonly Action<TextInputResult> OnTextInput;

		public TextInputRequest(TMP_InputField inputField, bool isMultiLine, string description, Action<TextInputResult> onTextInput)
		{
			InputField = inputField;
			IsMultiLine = isMultiLine;
			Description = description;
			OnTextInput = onTextInput;
		}
	}

	public readonly struct TextInputResult
	{
		public readonly bool IsFinished;

		public readonly bool SaveText;

		public readonly string Text;

		public TextInputResult(bool isFinished, bool saveText, string text)
		{
			IsFinished = isFinished;
			SaveText = saveText;
			Text = text;
		}
	}

	public readonly List<Func<bool>> OnCanStartTextInput = new List<Func<bool>>();

	private static Coroutine inputAwaitingRoutine;

	public virtual Platform CurrentPlatform => Platform.Windows;

	public abstract bool MustStayInGame { get; }

	public abstract bool SupportsBugReporting { get; }

	public abstract string RecommendedGraphicsPreset_VR { get; }

	public abstract string RecommendedGraphicsPreset_NonVR { get; }

	private bool CanStartTextInput => OnCanStartTextInput.TrueForAll((Func<bool> f) => f());

	public event Action<TextInputRequest> OnTextInputStarted;

	public event Action OnTextInputFinished;

	public event Action FileOrFolderOpened;

	public abstract void OpenURL(string url);

	public void RequestTextInput(TextInputRequest request)
	{
		if (CanStartTextInput)
		{
			this.OnTextInputStarted?.Invoke(request);
			return;
		}
		if (inputAwaitingRoutine != null)
		{
			StopCoroutine(inputAwaitingRoutine);
		}
		inputAwaitingRoutine = StartCoroutine(WaitToStartInput(request));
	}

	private IEnumerator WaitToStartInput(TextInputRequest request)
	{
		yield return null;
		while (!CanStartTextInput)
		{
			yield return null;
		}
		inputAwaitingRoutine = null;
		if ((bool)request.InputField && request.InputField.gameObject.activeInHierarchy)
		{
			this.OnTextInputStarted?.Invoke(request);
		}
	}

	public void FinishTextInput()
	{
		this.OnTextInputFinished?.Invoke();
		if (inputAwaitingRoutine != null)
		{
			StopCoroutine(inputAwaitingRoutine);
			inputAwaitingRoutine = null;
		}
	}

	public void OnFileOrFolderOpened()
	{
		this.FileOrFolderOpened?.Invoke();
	}
}
