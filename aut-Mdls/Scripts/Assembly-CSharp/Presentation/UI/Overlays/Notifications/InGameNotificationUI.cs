#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Events.UI.Overlays;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.Overlays.Notifications
{
	public class InGameNotificationUI : MonoBehaviour
	{
		[SerializeField]
		private InGameNotificationWidget _basicNotificationPrefab;

		[SerializeField]
		private InGameNotificationWidget _momumentNotificationPrefab;

		[SerializeField]
		private InGameNotificationWidget _deliveryNotificationPrefab;

		[SerializeField]
		private InGameNotificationWidget _challengeNotificationPrefab;

		[SerializeField]
		private InGameNotificationWidget _rewardNotificationPrefab;

		[SerializeField]
		private InGameNotificationWidget _gnnGateProgressNotificationPrefab;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private RectTransform _widgetParent;

		[SerializeField]
		private ShowIngameNotificationEvent _showIngameNotificationEvent;

		[SerializeField]
		private HideIngameNotificationEvent _hideIngameNotificationEvent;

		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		[SerializeField]
		private BaseEvent<float> _QuestUIHeightChangedEvent;

		[SerializeField]
		private float _spacingBetweenQuestsAndNotifications = 40f;

		private readonly List<(InGameNotificationWidget, float)> _queue = new List<(InGameNotificationWidget, float)>();

		private readonly Dictionary<object, InGameNotificationWidget> _identifierToNotification = new Dictionary<object, InGameNotificationWidget>();

		private bool _forceUpdateFlag;

		private float _rectHeight;

		private void Awake()
		{
			_showIngameNotificationEvent.RegisterMainThread(HandleShowIngameNotificationEvent);
			_hideIngameNotificationEvent.Register(HandleHideIngameNotificationEvent);
			_startLoadingSaveEvent.Register(HandleStartLoadingSave);
			_rectHeight = _widgetParent.rect.height;
			_QuestUIHeightChangedEvent.Register(OnQuestUIHeightChanged);
		}

		private void HandleStartLoadingSave()
		{
			_identifierToNotification.Clear();
			foreach (var item in _queue)
			{
				Object.Destroy(item.Item1);
			}
			_queue.Clear();
		}

		private void OnDestroy()
		{
			_showIngameNotificationEvent.UnRegisterMainThread(HandleShowIngameNotificationEvent);
			_hideIngameNotificationEvent.UnRegister(HandleHideIngameNotificationEvent);
			_startLoadingSaveEvent.UnRegister(HandleStartLoadingSave);
			_QuestUIHeightChangedEvent.UnRegister(OnQuestUIHeightChanged);
		}

		private void OnQuestUIHeightChanged(float questUIHeight)
		{
			_rectTransform.DOKill();
			_rectTransform.DOSizeDelta(new Vector2(_rectTransform.rect.width, (base.transform.parent as RectTransform).rect.height - (questUIHeight + _spacingBetweenQuestsAndNotifications)), 0.3f);
		}

		private void HandleShowIngameNotificationEvent(InGameNotificationDto dto)
		{
			ShowNotification(dto);
		}

		private void HandleHideIngameNotificationEvent(object identifier)
		{
			if (!_identifierToNotification.TryGetValue(identifier, out var value))
			{
				this.LogWarning(string.Format("Could not find a {0} for the {1} \"{2}\"", "InGameNotificationWidget", "identifier", identifier), "HandleHideIngameNotificationEvent", 81);
				return;
			}
			bool flag = false;
			for (int num = _queue.Count - 1; num >= 0; num--)
			{
				if (_queue[num].Item1 == value)
				{
					_queue.RemoveAt(num);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				value.AnimateOut();
			}
		}

		public void ShowNotification(InGameNotificationDto inGameNotificationDto)
		{
			InGameNotificationWidget inGameNotificationWidget = Object.Instantiate(inGameNotificationDto.Type switch
			{
				InGameNotificationType.Delivery => _deliveryNotificationPrefab, 
				InGameNotificationType.Challenge => _challengeNotificationPrefab, 
				InGameNotificationType.Monument => _momumentNotificationPrefab, 
				InGameNotificationType.Reward => _rewardNotificationPrefab, 
				InGameNotificationType.GnnGateProgress => _gnnGateProgressNotificationPrefab, 
				_ => _basicNotificationPrefab, 
			}, _widgetParent);
			if (inGameNotificationDto.Identifier != null)
			{
				if (_identifierToNotification.TryGetValue(inGameNotificationDto.Identifier, out var value))
				{
					value.AnimateOut();
					_identifierToNotification[inGameNotificationDto.Identifier] = inGameNotificationWidget;
				}
				else
				{
					_identifierToNotification.Add(inGameNotificationDto.Identifier, inGameNotificationWidget);
				}
			}
			AddToQueue(inGameNotificationWidget, inGameNotificationWidget.Build(inGameNotificationDto, SetForceUpdateFlag, OnWidgetDestroyed));
		}

		private void AddToQueue(InGameNotificationWidget widget, float widgetHeight)
		{
			_queue.Add((widget, widgetHeight));
			LayoutRebuilder.ForceRebuildLayoutImmediate(_widgetParent);
			TryShowNextWidget();
		}

		private void TryShowNextWidget()
		{
			if (_queue.Count != 0)
			{
				(InGameNotificationWidget, float) tuple = _queue[0];
				while (tuple.Item1 == null)
				{
					_queue.RemoveAt(0);
					tuple = _queue[0];
				}
				if (Mathf.Abs(tuple.Item1.RectTransform.anchoredPosition.y) + tuple.Item2 < _rectHeight)
				{
					_queue.RemoveAt(0);
					tuple.Item1.Show();
				}
			}
		}

		private void OnWidgetDestroyed(InGameNotificationWidget inGameNotificationWidget, object identifier)
		{
			if (identifier != null && _identifierToNotification.TryGetValue(identifier, out var value) && value == inGameNotificationWidget)
			{
				_identifierToNotification.Remove(identifier);
			}
			TryShowNextWidget();
		}

		private void SetForceUpdateFlag()
		{
			_forceUpdateFlag = true;
		}

		private void LateUpdate()
		{
			if (_forceUpdateFlag)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(_widgetParent);
			}
		}
	}
}
