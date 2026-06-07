using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays.Notifications
{
	public class InGameNotificationWidget : NotificationWithDuration
	{
		[Header("UI Refs")]
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private RectTransform _containerRectTransform;

		[SerializeField]
		private float _animationDuration = 0.75f;

		[Header("Content")]
		[SerializeField]
		protected TextMeshProUGUI _labelText;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private TextMeshProUGUI _buttonText;

		private InGameNotificationDto _currentInGameNotificationDto;

		private const float _notificationContainerWidth = 1000f;

		private float _notificationContainerY;

		private Action _setForceUpdateFlag;

		private Action<InGameNotificationWidget, object> _destroyWidget;

		private bool _isAnimatingOut;

		public RectTransform RectTransform => _rectTransform;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_button != null)
			{
				_button.onClick.RemoveListener(HandleButtonClicked);
			}
		}

		public float Build(InGameNotificationDto inGameNotificationDto, Action setForceUpdateFlag, Action<InGameNotificationWidget, object> destroyWidget)
		{
			_currentInGameNotificationDto = inGameNotificationDto;
			_notificationContainerY = _containerRectTransform.anchoredPosition.y;
			_setForceUpdateFlag = setForceUpdateFlag;
			_destroyWidget = destroyWidget;
			UpdateNotification(inGameNotificationDto);
			_rectTransform.localScale = new Vector3(1f, 0f, 1f);
			_rectTransform.gameObject.SetActive(value: true);
			return _rectTransform.sizeDelta.y;
		}

		public override void Show()
		{
			_rectTransform.localScale = Vector3.one;
			base.Show();
		}

		protected override void AnimateIn()
		{
			_containerRectTransform.anchoredPosition = new Vector2(-1000f, _notificationContainerY);
			_containerRectTransform.DOAnchorPos(new Vector2(0f, _notificationContainerY), _animationDuration).SetEase(Ease.OutCubic).OnComplete(base.StartTimer);
		}

		protected virtual void UpdateNotification(InGameNotificationDto inGameNotificationDto)
		{
			_labelText.text = inGameNotificationDto.LabelText;
			_icon.sprite = inGameNotificationDto.Sprite;
			_icon.gameObject.SetActive(inGameNotificationDto.Sprite != null);
			SetupTimer(inGameNotificationDto.Duration);
			SetupButton(inGameNotificationDto);
		}

		protected void SetupButton(InGameNotificationDto inGameNotificationDto)
		{
			if (_button != null)
			{
				if (inGameNotificationDto.ButtonCallback != null && !string.IsNullOrEmpty(inGameNotificationDto.ButtonTextLocaKey))
				{
					_button.onClick.AddListener(HandleButtonClicked);
					_buttonText.text = LocalizationUtility.GetLocalizedText(inGameNotificationDto.ButtonTextLocaKey);
				}
				else
				{
					_button.gameObject.SetActive(value: false);
				}
			}
		}

		private void HandleButtonClicked()
		{
			RemoveNotification();
		}

		protected override void RemoveNotification()
		{
			_currentInGameNotificationDto.ButtonCallback?.Invoke();
			AnimateOut();
		}

		public void AnimateOut()
		{
			if (_isAnimatingOut)
			{
				return;
			}
			_isAnimatingOut = true;
			base.RemoveNotification();
			if (_button != null)
			{
				_button.onClick.RemoveListener(HandleButtonClicked);
				_button.interactable = false;
			}
			_containerRectTransform.DOAnchorPos(new Vector2(-1000f, _notificationContainerY), _animationDuration).SetEase(Ease.InCubic).OnComplete(delegate
			{
				_rectTransform.DOSizeDelta(new Vector2(1000f, 0f), 0.3f).SetEase(Ease.OutCubic).OnUpdate(delegate
				{
					_setForceUpdateFlag?.Invoke();
				})
					.OnComplete(OnNotificationRemoved);
			});
		}

		private void OnNotificationRemoved()
		{
			_destroyWidget?.Invoke(this, _currentInGameNotificationDto.Identifier);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
