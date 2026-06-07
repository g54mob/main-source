using System;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils.Enums;

namespace Presentation.UI.Overlays
{
	public class MenuModalDialog : UIModalDialog
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[Header("Layout")]
		[SerializeField]
		private RectTransform _panel;

		[SerializeField]
		private Button _bgButton;

		[SerializeField]
		private GameObject _header;

		[SerializeField]
		private TextMeshProUGUI _titleField;

		[SerializeField]
		private TextMeshProUGUI _textField;

		[SerializeField]
		private TextMeshProUGUI _extraTextField;

		[SerializeField]
		private GameObject _mediaContent;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[Header("Buttons")]
		[SerializeField]
		private Button _successButton;

		[SerializeField]
		private TextMeshProUGUI _successButtonTextField;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private TextMeshProUGUI _cancelButtonTextField;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _forceCancelMenuModalDialogEvent;

		[SerializeField]
		private BaseEvent _closedMenuModalDialogEvent;

		private bool _hasVideo;

		private bool _hasImage;

		private Action _successCallback;

		private Action _cancelCallback;

		private bool _hasSuccessCallback;

		private bool _hasCancelCallback;

		private MenuModalDialogDto _currentDto;

		private readonly Dictionary<Sizes, int> _sizes = new Dictionary<Sizes, int>
		{
			{
				Sizes.Xs,
				768
			},
			{
				Sizes.S,
				1152
			},
			{
				Sizes.M,
				1386
			},
			{
				Sizes.L,
				1920
			},
			{
				Sizes.Xl,
				2304
			}
		};

		private readonly Dictionary<Sizes, int> _textSizes = new Dictionary<Sizes, int>
		{
			{
				Sizes.Xs,
				28
			},
			{
				Sizes.S,
				32
			},
			{
				Sizes.M,
				36
			},
			{
				Sizes.L,
				40
			},
			{
				Sizes.Xl,
				44
			}
		};

		private readonly Dictionary<Sizes, int> _titleSizes = new Dictionary<Sizes, int>
		{
			{
				Sizes.Xs,
				28
			},
			{
				Sizes.S,
				32
			},
			{
				Sizes.M,
				36
			},
			{
				Sizes.L,
				40
			},
			{
				Sizes.Xl,
				44
			}
		};

		private void Awake()
		{
			base.gameObject.SetActive(value: false);
			_bgButton.onClick.AddListener(OnPanelPressed);
			_forceCancelMenuModalDialogEvent.Register(ForceCancel);
		}

		private void OnDestroy()
		{
			_bgButton.onClick.RemoveListener(OnPanelPressed);
			_forceCancelMenuModalDialogEvent.UnRegister(ForceCancel);
		}

		public override void ShowModal(AbstractUIModalDialogData menuData)
		{
			MenuModalDialogDto menuModalDialogDto = (_currentDto = (menuData as UIMenuModalDialogData).Dto);
			_panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sizes[menuModalDialogDto.ModalSize]);
			SetMainButtons(menuModalDialogDto);
			BuildPage(menuModalDialogDto);
			SetTextSize(menuModalDialogDto.TextSize, menuModalDialogDto.TitleSize);
			base.gameObject.SetActive(value: true);
		}

		public override void HideModal()
		{
			if (_hasVideo)
			{
				StopVideo();
			}
			_closedMenuModalDialogEvent.Fire();
			base.gameObject.SetActive(value: false);
		}

		public override bool TryCanCancel()
		{
			if (_currentDto.ShowCancelButton)
			{
				ForceCancel();
			}
			else
			{
				OnPanelPressed();
			}
			return false;
		}

		private void SetMainButtons(MenuModalDialogDto dto)
		{
			_successButtonTextField.SetText(dto.SuccessButtonText);
			EventSystem.current.SetSelectedGameObject(_successButton.gameObject);
			if (dto.ShowCancelButton)
			{
				_cancelButtonTextField.SetText(dto.CancelButtonText);
			}
			_cancelButton.gameObject.SetActive(dto.ShowCancelButton);
			HandleMainCallbacks(dto);
		}

		private void BuildPage(MenuModalDialogDto dto)
		{
			string title = dto.Title;
			_header.SetActive(!string.IsNullOrEmpty(title));
			_titleField.SetText(title);
			if (!string.IsNullOrEmpty(dto.ExtraText))
			{
				_textField.SetText(dto.Text);
				_extraTextField.SetText(dto.ExtraText);
				_textField.gameObject.SetActive(value: true);
				_extraTextField.gameObject.SetActive(value: true);
			}
			else
			{
				_textField.SetText(string.Empty);
				_extraTextField.SetText(dto.Text);
				_textField.gameObject.SetActive(value: false);
				_extraTextField.gameObject.SetActive(value: true);
			}
			SetTextAlignment(dto.TextAlignment);
			SetImageContent(dto.ImageSprite);
			SetVideoContent(dto.VideoName);
			_mediaContent.SetActive(_hasVideo || _hasImage);
		}

		private void SetTextAlignment(TextAlignmentOptions alignment)
		{
			_textField.alignment = alignment;
			_extraTextField.alignment = alignment;
		}

		private void SetTextSize(Sizes textSize, Sizes titleSize)
		{
			_textField.fontSize = _textSizes[textSize];
			_extraTextField.fontSize = _textSizes[textSize];
			_titleField.fontSize = _titleSizes[titleSize];
		}

		private void SetImageContent(Sprite imagesprite)
		{
			_hasImage = imagesprite != null;
			_image.gameObject.SetActive(_hasImage);
			if (_hasImage)
			{
				_image.sprite = imagesprite;
			}
		}

		private void SetVideoContent(string videoName)
		{
			_hasVideo = !string.IsNullOrEmpty(videoName);
			if (!_hasVideo)
			{
				_videoPlayer.gameObject.SetActive(value: false);
				return;
			}
			_videoPlayer.url = Application.streamingAssetsPath + "/Videos/" + videoName;
			if (_videoPlayer.isPrepared)
			{
				_videoPlayer.Play();
			}
			else
			{
				_videoPlayer.prepareCompleted += PlayVideo;
				_videoPlayer.Prepare();
			}
			_videoPlayer.gameObject.SetActive(value: true);
		}

		private void PlayVideo(VideoPlayer source)
		{
			_videoPlayer.Play();
		}

		private void StopVideo()
		{
			_videoPlayer.prepareCompleted -= PlayVideo;
			_videoPlayer.Stop();
		}

		private void HandleMainCallbacks(MenuModalDialogDto dto)
		{
			_successCallback = dto.SuccessCallback;
			_hasSuccessCallback = _successCallback != null;
			_successButton.onClick.AddListener(OnSuccessButtonClicked);
			_cancelCallback = dto.CancelCallback;
			_hasCancelCallback = _cancelCallback != null;
			if (dto.ShowCancelButton)
			{
				_cancelButton.onClick.AddListener(OnCancelButtonClicked);
			}
		}

		private void OnPanelPressed()
		{
			RectTransform obj = _successButton.transform as RectTransform;
			obj.DOKill();
			obj.localScale = Vector3.one;
			obj.DOPunchScale(Vector2.one * 0.3f, 0.2f, 4);
		}

		private void OnSuccessButtonClicked()
		{
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			_cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
			if (_hasSuccessCallback)
			{
				_successCallback();
			}
		}

		private void OnCancelButtonClicked()
		{
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
			if (_hasCancelCallback)
			{
				_cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
				_cancelCallback();
			}
		}

		private void ForceCancel()
		{
			OnCancelButtonClicked();
		}
	}
}
