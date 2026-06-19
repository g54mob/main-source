using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class InWorldMessages : MustCallDestroy
	{
		public enum MessageType
		{
			Info = 0,
			Income = 1,
			Cost = 2
		}

		private class Message
		{
			public InWorldHUDElement Element;

			public CanvasGroup CanvasGroup;

			public Vector3 StartPosition;

			public float StartTime;

			public float DisplayTime;
		}

		private readonly InWorldMessagesConfig _config;

		private readonly HUD _hud;

		private readonly GameObject _messagePrefab;

		private readonly List<Message> _messages = new List<Message>();

		private readonly List<Message> _expiredMessages = new List<Message>();

		[DontSave]
		private List<InWorldHUDElement> _messageGameobjectPool;

		public InWorldMessages(HUD hud)
		{
			_hud = hud;
			_config = hud.GetConfig().InWorldMessagesConfig;
			_messagePrefab = hud.GetConfig().InWorldMessagePrefab;
		}

		public void ShowMessage(string text, Vector3 location, float displayTime, MessageType messageType)
		{
			if (_messageGameobjectPool == null)
			{
				_messageGameobjectPool = new List<InWorldHUDElement>(32);
			}
			InWorldHUDElement inWorldHUDElement;
			if (_messageGameobjectPool.Count > 0)
			{
				inWorldHUDElement = _messageGameobjectPool[_messageGameobjectPool.Count - 1];
				inWorldHUDElement.gameObject.SetActive(value: true);
				_messageGameobjectPool.RemoveAt(_messageGameobjectPool.Count - 1);
			}
			else
			{
				inWorldHUDElement = Object.Instantiate(_messagePrefab).GetComponent<InWorldHUDElement>();
			}
			TMP_Text componentInChildren = inWorldHUDElement.gameObject.GetComponentInChildren<TMP_Text>();
			CanvasGroup component = inWorldHUDElement.gameObject.GetComponent<CanvasGroup>();
			if (componentInChildren != null)
			{
				componentInChildren.text = text;
				switch (messageType)
				{
				case MessageType.Info:
					componentInChildren.color = _config.InfoTextColor;
					break;
				case MessageType.Income:
					componentInChildren.color = _config.IncomeTextColor;
					break;
				case MessageType.Cost:
					componentInChildren.color = _config.CostTextColor;
					break;
				}
			}
			inWorldHUDElement.Position = location;
			inWorldHUDElement.CanBeHidden = true;
			_hud.AddElement(inWorldHUDElement);
			_messages.Add(new Message
			{
				Element = inWorldHUDElement,
				CanvasGroup = component,
				StartPosition = location,
				StartTime = 0f,
				DisplayTime = displayTime
			});
		}

		public void Update(float deltaTime)
		{
			for (int i = 0; i < _messages.Count; i++)
			{
				Message message = _messages[i];
				message.StartTime += deltaTime;
				if (message.StartTime >= message.DisplayTime)
				{
					_expiredMessages.Add(message);
					continue;
				}
				float num = message.StartTime / message.DisplayTime;
				Vector3 position = message.StartPosition + Vector3.up * num * 4f;
				message.Element.Position = position;
				if (message.CanvasGroup != null)
				{
					message.CanvasGroup.alpha = 1f - num * num * num;
				}
			}
			for (int j = 0; j < _expiredMessages.Count; j++)
			{
				Message message2 = _expiredMessages[j];
				_hud.RemoveElement(message2.Element);
				message2.Element.gameObject.SetActive(value: false);
				_messageGameobjectPool.Add(message2.Element);
				_messages.Remove(message2);
			}
			_expiredMessages.Clear();
		}
	}
}
