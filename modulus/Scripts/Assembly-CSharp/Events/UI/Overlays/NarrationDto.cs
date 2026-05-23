using System;
using UnityEngine;

namespace Events.UI.Overlays
{
	public class NarrationDto
	{
		public enum EButtonActionType
		{
			OpenModalDialog = 0,
			OpenGlossaryItem = 1,
			CloseNarrator = 2
		}

		public enum Narrators
		{
			AtlasColony = 0,
			GNN = 1,
			Intro = 2
		}

		private string _textKey;

		private string _titleKey;

		private string _buttonText;

		public string Text { get; private set; }

		public string Title { get; private set; }

		public Sprite ImageSprite { get; private set; }

		public string VideoName { get; private set; }

		public float Delay { get; private set; }

		public bool HasButton { get; private set; }

		public string ButtonText { get; private set; }

		public Narrators NarratorType { get; private set; }

		public bool ClosePreviousNarrator { get; private set; }

		public EButtonActionType ButtonActionType { get; private set; }

		public ModalDialogDto ButtonTargetModalDialogDto { get; private set; }

		public Action OnCloseCallback { get; private set; }

		public NarrationDto(string titleKey, string textKey, Narrators narratorType, bool closePreviousNarrator)
		{
			Title = titleKey;
			Text = textKey;
			NarratorType = narratorType;
			ClosePreviousNarrator = closePreviousNarrator;
		}

		public NarrationDto(string titleKey, string textKey, Narrators narratorType, bool closePreviousNarrator, Sprite imageSprite)
			: this(titleKey, textKey, narratorType, closePreviousNarrator)
		{
			ImageSprite = imageSprite;
		}

		public NarrationDto(string titleKey, string textKey, Narrators narratorType, bool closePreviousNarrator, string videoName)
			: this(titleKey, textKey, narratorType, closePreviousNarrator)
		{
			VideoName = videoName;
		}

		public void AddDelay(float delay)
		{
			Delay = delay;
		}

		public void AddOpenModalButton(string buttonText, ModalDialogDto modalDialog)
		{
			ButtonActionType = EButtonActionType.OpenModalDialog;
			HasButton = true;
			ButtonText = buttonText;
			ButtonTargetModalDialogDto = modalDialog;
		}

		public void AddOpenGlossaryButton(string buttonText)
		{
			ButtonActionType = EButtonActionType.OpenGlossaryItem;
			HasButton = true;
			ButtonText = buttonText;
		}

		public void AddCloseNarratorButton(string buttonText, Action onCloseCallback)
		{
			ButtonActionType = EButtonActionType.CloseNarrator;
			HasButton = true;
			ButtonText = buttonText;
			OnCloseCallback = onCloseCallback;
		}
	}
}
