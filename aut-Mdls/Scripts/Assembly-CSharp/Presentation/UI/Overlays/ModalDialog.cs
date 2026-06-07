#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Buttons;
using Presentation.UI.LayoutElements;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Overlays
{
	public class ModalDialog : UIModalDialog
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[Header("Layout")]
		[SerializeField]
		private Button _bgButton;

		[SerializeField]
		private GameObject _header;

		[SerializeField]
		private ModalDialogContentView _contentViewZero;

		[SerializeField]
		private PageIndicator _pageIndicator;

		[SerializeField]
		private TextMeshProUGUI _titleField;

		[Header("Buttons")]
		[SerializeField]
		private Button _successButton;

		[SerializeField]
		private ButtonEnabler _successButtonEnabler;

		[SerializeField]
		private TextMeshProUGUI _successButtonTextField;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private TextMeshProUGUI _cancelButtonTextField;

		[Header("Multipage buttons")]
		[SerializeField]
		private Button _nextButton;

		[SerializeField]
		private ButtonEnabler _nextButtonEnabler;

		[SerializeField]
		private Button _prevButton;

		[SerializeField]
		private ButtonEnabler _prevButtonEnabler;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _forceCancelModalDialogEvent;

		[SerializeField]
		private BaseEvent _closedModalDialogEvent;

		private Action _successCallback;

		private Action _cancelCallback;

		private bool _hasSuccessCallback;

		private bool _hasCancelCallback;

		private ModalDialogDto _currentDto;

		private int _currentPage;

		private int _pageAmount = 1;

		private bool _isMultiPageModal;

		private bool _allowPageSkip;

		private List<ModalDialogContentView> _contentViews;

		private ModalDialogContentView _currentContentView;

		private void Awake()
		{
			_contentViews = new List<ModalDialogContentView> { _contentViewZero };
			base.gameObject.SetActive(value: false);
			_bgButton.onClick.AddListener(OnPanelPressed);
			_forceCancelModalDialogEvent.Register(ForceCancel);
			_successButton.onClick.AddListener(OnSuccessButtonClicked);
			_cancelButton.onClick.AddListener(OnCancelButtonClicked);
			_nextButton.onClick.AddListener(OnNextButtonClicked);
			_prevButton.onClick.AddListener(OnPrevButtonClicked);
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
		}

		private void OnDestroy()
		{
			_bgButton.onClick.RemoveListener(OnPanelPressed);
			_forceCancelModalDialogEvent.UnRegister(ForceCancel);
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			_cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
			_nextButton.onClick.RemoveListener(OnNextButtonClicked);
			_prevButton.onClick.RemoveListener(OnPrevButtonClicked);
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		public override void ShowModal(AbstractUIModalDialogData menuData)
		{
			ModalDialogDto dto = (menuData as UIModaldialogData).Dto;
			if (dto == null)
			{
				this.DevException("Can't show a model with a null ModalDialogDto", "ShowModal", 99);
				return;
			}
			_isMultiPageModal = dto.DialogContent.Length > 1;
			_allowPageSkip = dto.AllowPageSkip;
			_currentPage = 0;
			_pageAmount = dto.DialogContent.Length;
			_currentDto = dto;
			_currentDto.UpdateTexts();
			SetPageIndicator();
			SetMainButtons(dto);
			SetMultiPageButtons();
			UpdateButtons();
			BuildPages(dto.DialogContent);
			base.gameObject.SetActive(value: true);
		}

		public override void HideModal()
		{
			for (int i = 0; i < _contentViews.Count; i++)
			{
				_contentViews[i].Reset();
			}
			if (_currentContentView != null)
			{
				_currentContentView.Hide();
			}
			_closedModalDialogEvent.Fire();
			base.gameObject.SetActive(value: false);
		}

		public override bool TryCanCancel()
		{
			if (_currentDto.ShowCancelButton)
			{
				ForceCancel();
			}
			return false;
		}

		private void OnLanguageUpdate()
		{
			if (_currentDto != null)
			{
				_currentDto.UpdateTexts();
				UpdateTitle(_currentDto.DialogContent[_currentPage].Title);
				_successButtonTextField.SetText(_currentDto.SuccessButtonText);
				if (_currentDto.ShowCancelButton)
				{
					_cancelButtonTextField.SetText(_currentDto.CancelButtonText);
				}
				for (int i = 0; i < _contentViews.Count; i++)
				{
					_contentViews[i].UpdateTexts();
				}
			}
		}

		private void SetPageIndicator()
		{
			_pageIndicator.gameObject.SetActive(_isMultiPageModal);
			if (_isMultiPageModal)
			{
				_pageIndicator.Initialize(_pageAmount);
			}
		}

		private void SetMultiPageButtons()
		{
			_prevButton.gameObject.SetActive(_isMultiPageModal);
			_nextButton.gameObject.SetActive(_isMultiPageModal);
			_successButtonEnabler.Interactable = false;
		}

		private void OnNextButtonClicked()
		{
			ChangePage(1);
		}

		private void OnPrevButtonClicked()
		{
			ChangePage(-1);
		}

		private void ChangePage(int direction)
		{
			_currentContentView.Hide(direction);
			_currentPage += direction;
			_currentContentView = _contentViews[_currentPage];
			_currentContentView.Show(direction);
			_pageIndicator.SetCurrentPage(_currentPage);
			UpdateTitle(_currentDto.DialogContent[_currentPage].Title);
			UpdateButtons();
		}

		private void SetMainButtons(ModalDialogDto dto)
		{
			_successButtonTextField.SetText(dto.SuccessButtonText);
			if (dto.ShowCancelButton)
			{
				_cancelButtonTextField.SetText(dto.CancelButtonText);
			}
			_cancelButton.gameObject.SetActive(dto.ShowCancelButton);
			HandleMainCallbacks(dto);
		}

		private void UpdateButtons()
		{
			if (!_isMultiPageModal)
			{
				_successButtonEnabler.Interactable = true;
				EventSystem.current.SetSelectedGameObject(_successButton.gameObject);
				return;
			}
			_prevButtonEnabler.Interactable = _currentPage > 0;
			_nextButtonEnabler.Interactable = _currentPage < _pageAmount - 1;
			_successButtonEnabler.Interactable = _allowPageSkip || _currentPage >= _pageAmount - 1;
			EventSystem.current.SetSelectedGameObject((_nextButtonEnabler.Interactable ? _nextButton : _successButton).gameObject);
		}

		private void BuildPages(ModalDialogContent[] pages)
		{
			string title = pages[0].Title;
			_header.SetActive(!string.IsNullOrEmpty(title));
			_titleField.SetText(title);
			for (int i = 0; i < _pageAmount; i++)
			{
				if (i > 0 && i >= _contentViews.Count)
				{
					ModalDialogContentView item = UnityEngine.Object.Instantiate(_contentViewZero, _contentViewZero.transform.parent);
					_contentViews.Add(item);
				}
				_contentViews[i].BuildContent(pages[i]);
			}
			_currentContentView = _contentViews[0];
			_currentContentView.Show();
		}

		private void UpdateTitle(string title)
		{
			_titleField.SetText(title);
		}

		private void HandleMainCallbacks(ModalDialogDto dto)
		{
			_successCallback = dto.SuccessCallback;
			_hasSuccessCallback = _successCallback != null;
			_cancelCallback = dto.CancelCallback;
			_hasCancelCallback = _cancelCallback != null;
		}

		private void OnPanelPressed()
		{
			if (_successButton.interactable)
			{
				RectTransform obj = _successButton.transform as RectTransform;
				obj.DOKill();
				obj.localScale = Vector3.one;
				obj.DOPunchScale(Vector2.one * 0.3f, 0.2f, 4);
			}
		}

		private void OnSuccessButtonClicked()
		{
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
			if (_hasSuccessCallback)
			{
				_successCallback();
				_hasSuccessCallback = false;
				_hasCancelCallback = false;
			}
		}

		private void OnCancelButtonClicked()
		{
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
			if (_hasCancelCallback)
			{
				_cancelCallback();
				_hasSuccessCallback = false;
				_hasCancelCallback = false;
			}
		}

		private void ForceCancel()
		{
			OnCancelButtonClicked();
		}
	}
}
