using System;
using System.Collections;
using Data.Variables;
using Events;
using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using Presentation.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.UI.Overlays
{
	public abstract class NarrationDialog : MonoBehaviour
	{
		[SerializeField]
		private GameObject _canvas;

		[SerializeField]
		private GameObject _expandedContent;

		[SerializeField]
		private TextMeshProUGUI _expandedTitleField;

		[SerializeField]
		private TextMeshProUGUI _expandedTextField;

		[SerializeField]
		private Button _contentButton;

		[SerializeField]
		private TextMeshProUGUI _contentButtonText;

		[SerializeField]
		private HudUIPositionHelper _positionHelper;

		[Header("Events")]
		[SerializeField]
		private ShowNarrationDialogEvent _showNarrationDialogEvent;

		[SerializeField]
		private BaseEvent _hideNarrationDialogEvent;

		[SerializeField]
		private BaseEvent _narrationWasClosedEvent;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private NarrationDialogQueueSO _narrationDialogQueueSO;

		[SerializeField]
		private InputActionReference _fastForwardNarration;

		[Header("Narration anim")]
		[SerializeField]
		private float _narrationAppearTime;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		private NarrationDto _dto;

		private Coroutine _delayCoroutine;

		private Coroutine _narrationCoroutine;

		protected bool _narratorTalking;

		private bool _fastForwardPressed;

		public event Action<NarrationDto> OnNarrationStartShow;

		public event Action OnCurrentNarrationDtoUpdate;

		public event Action OnNarrationHide;

		private void OnEnable()
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
			_canvas.SetActive(value: false);
			_showNarrationDialogEvent.Register(TryShow);
			_hideNarrationDialogEvent.Register(Hide);
			_narrationWasClosedEvent.Register(TryShowNext);
			if ((bool)_fastForwardNarration)
			{
				_fastForwardNarration.action.performed += OnFastForwardPressed;
			}
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			OnLanguageUpdate();
		}

		private void OnFastForwardPressed(InputAction.CallbackContext inputAction)
		{
			_fastForwardPressed = true;
		}

		private void OnDisable()
		{
			UnInitialize();
		}

		private void OnDestroy()
		{
			UnInitialize();
		}

		protected virtual void UnInitialize()
		{
			if (_delayCoroutine != null)
			{
				StopCoroutine(_delayCoroutine);
				_delayCoroutine = null;
			}
			StopNarrationCoutine();
			_narrationDialogQueueSO.NarratorQueue.Clear();
			_narrationDialogQueueSO.NarrationIsOpen = false;
			_showNarrationDialogEvent.UnRegister(TryShow);
			_hideNarrationDialogEvent.UnRegister(Hide);
			_narrationWasClosedEvent.UnRegister(TryShowNext);
			if ((bool)_fastForwardNarration)
			{
				_fastForwardNarration.action.performed -= OnFastForwardPressed;
			}
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void TryShow(NarrationDto dto)
		{
			if (!CanShow(dto))
			{
				return;
			}
			if (_narrationDialogQueueSO.NarrationIsOpen && !dto.ClosePreviousNarrator)
			{
				_narrationDialogQueueSO.NarratorQueue.Enqueue(dto);
				return;
			}
			_narrationDialogQueueSO.NarrationIsOpen = true;
			if (dto.Delay > 0f)
			{
				if (_delayCoroutine != null)
				{
					StopCoroutine(_delayCoroutine);
				}
				_delayCoroutine = StartCoroutine(WaitForDelay(dto));
			}
			else
			{
				PrepareShow(dto);
				StartShow();
			}
		}

		private IEnumerator WaitForDelay(NarrationDto dto)
		{
			yield return new WaitForSeconds(dto.Delay);
			PrepareShow(dto);
			StartShow();
		}

		private void StartShow()
		{
			_canvas.SetActive(value: true);
			_positionHelper.Refresh();
			LayoutRebuilder.ForceRebuildLayoutImmediate(_expandedContent.transform as RectTransform);
			StopNarrationCoutine();
			_narrationCoroutine = StartCoroutine(StartNarration());
		}

		private void StopNarrationCoutine()
		{
			if (_narrationCoroutine != null)
			{
				StopCoroutine(_narrationCoroutine);
				EndNarrationAnim();
			}
		}

		private IEnumerator StartNarration()
		{
			StartNarrationAnim();
			char[] array = _expandedTextField.text.ToCharArray();
			_expandedTextField.SetText("");
			string fullText = "";
			char[] array2 = array;
			foreach (char c in array2)
			{
				TextMeshProUGUI expandedTextField = _expandedTextField;
				string text;
				fullText = (text = fullText + c);
				expandedTextField.SetText(text);
				if (!_fastForwardPressed)
				{
					yield return new WaitForSeconds(_narrationAppearTime);
				}
			}
			yield return null;
			EndNarrationAnim();
		}

		protected virtual void StartNarrationAnim()
		{
			_narratorTalking = true;
			_fastForwardPressed = false;
			this.OnNarrationStartShow?.Invoke(_dto);
		}

		protected virtual void EndNarrationAnim()
		{
			if (_narratorTalking)
			{
				_audioManagerLocator?.AudioManager.StopNarratorTalkLoop();
			}
			_contentButton.gameObject.SetActive(_dto.HasButton);
			_narratorTalking = false;
			_fastForwardPressed = false;
			_narrationCoroutine = null;
		}

		protected virtual void PrepareShow(NarrationDto dto)
		{
			_dto = dto;
			_expandedTitleField.SetText(LocalizationUtility.GetLocalizedText(dto.Title));
			_expandedTextField.SetText(LocalizationUtility.GetLocalizedText(dto.Text));
			SetButtonContent();
		}

		private void OnLanguageUpdate()
		{
			if (_dto != null)
			{
				_expandedTitleField.SetText(LocalizationUtility.GetLocalizedText(_dto.Title));
				_expandedTextField.SetText(LocalizationUtility.GetLocalizedText(_dto.Text));
				if (_dto.HasButton)
				{
					_contentButtonText.SetText(LocalizationUtility.GetLocalizedText(_dto.ButtonText));
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(_expandedContent.transform as RectTransform);
				this.OnCurrentNarrationDtoUpdate?.Invoke();
			}
		}

		protected virtual void Hide()
		{
			if (_delayCoroutine != null)
			{
				StopCoroutine(_delayCoroutine);
				_delayCoroutine = null;
			}
			StopNarrationCoutine();
			if (_dto != null && _dto.HasButton)
			{
				_contentButton.onClick.RemoveListener(OnContentButtonClick);
			}
			_canvas.SetActive(value: false);
			_narrationDialogQueueSO.NarrationIsOpen = false;
			_narrationWasClosedEvent.Fire();
			this.OnNarrationHide?.Invoke();
		}

		private void TryShowNext()
		{
			if (_narrationDialogQueueSO.NarratorQueue.TryPeek(out var result) && CanShow(result))
			{
				TryShow(_narrationDialogQueueSO.NarratorQueue.Dequeue());
			}
		}

		protected abstract bool CanShow(NarrationDto dto);

		private void SetButtonContent()
		{
			_contentButton.gameObject.SetActive(value: false);
			if (_dto.HasButton)
			{
				_contentButton.onClick.AddListener(OnContentButtonClick);
				_contentButtonText.SetText(LocalizationUtility.GetLocalizedText(_dto.ButtonText));
			}
		}

		public void OnContentButtonClick()
		{
			switch (_dto.ButtonActionType)
			{
			case NarrationDto.EButtonActionType.OpenModalDialog:
				OpenModalDialog();
				break;
			case NarrationDto.EButtonActionType.CloseNarrator:
				_dto.OnCloseCallback?.Invoke();
				Hide();
				break;
			case NarrationDto.EButtonActionType.OpenGlossaryItem:
				break;
			}
		}

		private void OpenModalDialog()
		{
			_showModalDialogEvent.Fire(new UIModaldialogData(_dto.ButtonTargetModalDialogDto));
		}
	}
}
