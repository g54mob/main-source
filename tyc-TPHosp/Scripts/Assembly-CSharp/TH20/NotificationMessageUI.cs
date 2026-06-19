using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class NotificationMessageUI : AnimatedMenuBase
	{
		public TMP_Text _titleText;

		public TMP_Text _messageText;

		public Button _closeButton;

		public Button[] _choiceButtons;

		public RectTransform[] _choiceTransforms;

		private NotificationMessage _message;

		private InputManager _inputManager;

		private Notifications _notifications;

		public virtual void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			_message = message;
			_inputManager = level.InputManager;
			_notifications = notifications;
			if (_titleText != null)
			{
				_titleText.text = message.GetTitleText();
			}
			string text = message.GetMessageText();
			if (text != null)
			{
				text = text.Replace("\\n", "\n");
			}
			if (_messageText != null)
			{
				_messageText.text = text;
			}
			string[] choices = message.Definition.GetChoices();
			int num = ((choices != null) ? choices.Length : 0);
			for (int i = 0; i < num; i++)
			{
				int buttonIdx = i;
				TMP_Text componentInChildren = _choiceButtons[i].GetComponentInChildren<TMP_Text>();
				if (componentInChildren != null && choices != null && choices[buttonIdx] != null)
				{
					componentInChildren.text = choices[buttonIdx];
				}
				_choiceButtons[buttonIdx].onClick.AddListener(delegate
				{
					CloseMessage(buttonIdx);
				});
			}
			for (int num2 = num; num2 < _choiceButtons.Length; num2++)
			{
				_choiceTransforms[num2].gameObject.SetActive(value: false);
			}
			if (_closeButton != null)
			{
				if (num > 1 && message.Definition.CanBeIgnored)
				{
					_closeButton.onClick.AddListener(_notifications.CloseCurrentOpenMessage);
				}
				else
				{
					GameObjectUtils.SetActive(_closeButton.gameObject, isActive: false);
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			if (_inputManager.GetKeyDown(KeyCode.Escape))
			{
				CloseMessage(_message.Definition.DefaultChoice);
			}
		}

		protected virtual void CloseMessage(int choice)
		{
			if (!IsClosing())
			{
				_notifications.CloseCurrentOpenMessage();
				_notifications.Remove(_message);
				if (_message.Delegate != null)
				{
					_message.Delegate(choice);
				}
			}
		}
	}
}
