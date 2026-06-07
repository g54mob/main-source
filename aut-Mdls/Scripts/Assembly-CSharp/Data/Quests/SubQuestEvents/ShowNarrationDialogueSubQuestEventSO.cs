#define ENABLE_DEBUG_WARNINGS
using System;
using System.Collections.Generic;
using Events.UI.Overlays;
using NaughtyAttributes;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show Narration Dialogue", fileName = "ShowNarrationDialogue", order = 4)]
	public class ShowNarrationDialogueSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowNarrationDialogEvent _showNarrationDialogEvent;

		[LocaKey]
		[SerializeField]
		private string _titleKey = "ModalOnboarding1.Title";

		[LocaKey]
		[SerializeField]
		private string _textKey = "ModalOnboarding1.Text";

		[SerializeField]
		private string _videoName = "ModalOnboarding1.video";

		[SerializeField]
		private Sprite _image;

		[SerializeField]
		private float _delay;

		[SerializeField]
		private bool _hasButton;

		[SerializeField]
		private bool _allowPageSkip;

		[SerializeField]
		private NarrationDto.Narrators _narratorCharacter;

		[SerializeField]
		private bool _closePreviousNarrator = true;

		[LocaKey]
		[SerializeField]
		private string _buttonText;

		[SerializeField]
		private NarrationDto.EButtonActionType _buttonActionType;

		[SerializeField]
		private List<ModelDialogPageContent> _modalPagesToOpen = new List<ModelDialogPageContent>();

		private Action _onCloseCallback;

		public void SetOnCloseCallback(Action onNarrationClosed)
		{
			_onCloseCallback = onNarrationClosed;
		}

		[Button("Execute", EButtonEnableMode.Always)]
		public override void Execute()
		{
			NarrationDto narrationDto = ((!(_image != null)) ? new NarrationDto(_titleKey, _textKey, _narratorCharacter, _closePreviousNarrator, _videoName) : new NarrationDto(_titleKey, _textKey, _narratorCharacter, _closePreviousNarrator, _image));
			if (_delay > 0f)
			{
				narrationDto.AddDelay(_delay);
			}
			if (_hasButton)
			{
				switch (_buttonActionType)
				{
				case NarrationDto.EButtonActionType.OpenModalDialog:
					if (_modalPagesToOpen.Count > 0)
					{
						ModalDialogContent[] array = new ModalDialogContent[_modalPagesToOpen.Count];
						for (int i = 0; i < _modalPagesToOpen.Count; i++)
						{
							array[i] = new ModalDialogContent(_modalPagesToOpen[i].TitleKey, _modalPagesToOpen[i].TextKey, _modalPagesToOpen[i].VideoName, _modalPagesToOpen[i].Sprite, _modalPagesToOpen[i].ExtraTextKey);
						}
						narrationDto.AddOpenModalButton(_buttonText, new ModalDialogDto(array, Sizes.M, null, showCancelButton: false, null, _allowPageSkip));
					}
					else
					{
						this.LogWarning("The modal dialog info is empty", "ShowNarrationDialogueSubQuestEventSo", 75);
					}
					break;
				case NarrationDto.EButtonActionType.OpenGlossaryItem:
					narrationDto.AddOpenGlossaryButton(_buttonText);
					break;
				case NarrationDto.EButtonActionType.CloseNarrator:
					narrationDto.AddCloseNarratorButton(_buttonText, _onCloseCallback);
					break;
				}
			}
			_showNarrationDialogEvent.Fire(narrationDto);
		}
	}
}
