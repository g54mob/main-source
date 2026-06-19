using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class NotificationMenuListItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private GameObject _tooltip;

		[SerializeField]
		private float _tooltipShowTime = 2f;

		[SerializeField]
		private TMP_Text _tooltipText;

		[SerializeField]
		private GameObject _messageCountGameObject;

		[SerializeField]
		private TMP_Text _messageCounText;

		private List<NotificationMessage> _messages = new List<NotificationMessage>(8);

		private Notifications _notifications;

		private bool _showTooltip;

		private float _lastOpenMessageTimeStamp;

		public Sprite Icon => _icon.sprite;

		public int MessagesCount => _messages.Count;

		public void Setup(Sprite icon, NotificationMessage message, Notifications notifications)
		{
			_lastOpenMessageTimeStamp = 0f;
			_notifications = notifications;
			_icon.sprite = icon;
			AddMessage(message);
			_tooltip.gameObject.SetActive(value: false);
		}

		public void AddMessage(NotificationMessage message)
		{
			_messages.Add(message);
			_messageCounText.text = _messages.Count.ToString();
			UpdateTooltipText();
			_messageCountGameObject.SetActive(_messages.Count > 1);
			if (_messages.Count > 1)
			{
				OnDuplicateMessageAdded();
			}
		}

		private void OnDuplicateMessageAdded()
		{
			if (base.gameObject.activeInHierarchy)
			{
				_animator.SetParameter("Pulse");
				StopAllCoroutines();
				StartCoroutine(ShowTooltipCoroutine());
			}
		}

		private IEnumerator ShowTooltipCoroutine()
		{
			_showTooltip = true;
			GameObjectUtils.SetActive(_tooltip.gameObject, isActive: true);
			float showTime = GameTime.unscaledTime + _tooltipShowTime;
			while (showTime > GameTime.unscaledTime)
			{
				yield return null;
			}
			_showTooltip = false;
			GameObjectUtils.SetActive(_tooltip.gameObject, isActive: false);
		}

		public bool RemoveMessage(NotificationMessage message)
		{
			if (_messages.Remove(message))
			{
				UpdateTooltipText();
				_messageCounText.text = _messages.Count.ToString();
				_messageCountGameObject.SetActive(_messages.Count > 1);
				return true;
			}
			return false;
		}

		public bool ContainsMessage(NotificationMessage message)
		{
			if (_messages.Contains(message))
			{
				return true;
			}
			return false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			NotificationMessage notificationMessage = _messages[_messages.Count - 1];
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				_lastOpenMessageTimeStamp = Time.unscaledTime;
				_notifications.Open(notificationMessage);
			}
			else if (eventData.button == PointerEventData.InputButton.Right && notificationMessage.Definition.CanBeDismissed && Time.unscaledTime - _lastOpenMessageTimeStamp > 1f)
			{
				_notifications.Remove(notificationMessage);
				if (notificationMessage.Delegate != null)
				{
					notificationMessage.Delegate(notificationMessage.Definition.DefaultChoice);
				}
			}
		}

		private void UpdateTooltipText()
		{
			if (_messages.Count > 0)
			{
				_tooltipText.text = "Fw: " + _messages[_messages.Count - 1].GetTooltipText();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UpdateTooltipText();
			GameObjectUtils.SetActive(_tooltip.gameObject, isActive: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			GameObjectUtils.SetActive(_tooltip.gameObject, _showTooltip);
		}
	}
}
