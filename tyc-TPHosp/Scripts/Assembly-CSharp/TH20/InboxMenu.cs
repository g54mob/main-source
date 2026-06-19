using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class InboxMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		public enum Mode
		{
			Inbox = 0,
			Archive = 1
		}

		[SerializeField]
		private InboxMenuData _data;

		private Level _level;

		private InputManager _inputManager;

		private Notifications _notifications;

		private Mode _currentMode;

		private CharacterMugShot _characterMugShot;

		private List<NotificationMessage> _inboxMessages = new List<NotificationMessage>();

		private List<NotificationMessages.Definition> _archiveMessages = new List<NotificationMessages.Definition>();

		private List<InboxMessageRow> _rows = new List<InboxMessageRow>();

		private int _selectedRowIndex = -1;

		public void Initialise(Level level)
		{
			_level = level;
			_notifications = _level.Notifications;
			_inputManager = _level.InputManager;
			_inputManager.AddGraphicRayCaster(_data.GraphicRaycaster);
			Notifications notifications = _notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Combine(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			_data.CloseButton.onPrimaryDown.AddListener(CloseMenu);
			_data.InboxButton.onPrimaryDown.AddListener(delegate
			{
				EnterMode(Mode.Inbox);
			});
			_data.ArchiveButton.onPrimaryDown.AddListener(delegate
			{
				EnterMode(Mode.Archive);
			});
		}

		public void Setup(Mode mode)
		{
			_currentMode = mode;
			RebuildMessages();
			if (mode == Mode.Inbox)
			{
				SelectInboxMessage(-1);
			}
			else
			{
				SelectArchiveMessage(-1);
			}
			InspectorMenu inspectorMenu = _level.HUD.FindMenu<InspectorMenu>();
			if (inspectorMenu != null)
			{
				inspectorMenu.CloseAndRestoreGeneralNotifications();
			}
		}

		private void EnterMode(Mode mode)
		{
			if (_currentMode != mode)
			{
				_currentMode = mode;
				RebuildMessages();
				_data.MessagesTable.RowsScrollRect.verticalNormalizedPosition = 1f;
				switch (mode)
				{
				case Mode.Inbox:
					SelectInboxMessage(-1);
					break;
				case Mode.Archive:
					SelectArchiveMessage(-1);
					break;
				}
			}
		}

		private void RebuildMessages()
		{
			_data.InboxMessageCountGameObject.SetActive(_notifications.NumOfMessages > 0);
			_data.InboxMessageCountText.text = _notifications.NumOfMessages.ToString("0");
			_selectedRowIndex = -1;
			switch (_currentMode)
			{
			case Mode.Inbox:
				_data.InboxButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				_data.ArchiveButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				break;
			case Mode.Archive:
				_data.InboxButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_data.ArchiveButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				break;
			}
			foreach (Transform row in _data.MessagesTable.Rows)
			{
				UnityEngine.Object.Destroy(row.gameObject);
			}
			_data.MessagesTable.Rows.DetachChildren();
			if (_currentMode == Mode.Inbox)
			{
				RebuildInboxMessageList();
			}
			else
			{
				RebuildArchiveMessageList();
			}
		}

		private void RebuildArchiveMessageList()
		{
			_rows.Clear();
			_archiveMessages.Clear();
			_archiveMessages.AddRange(_notifications.ArchiveMessages);
			_archiveMessages.Reverse();
			for (int i = 0; i < _data.ChoiceTransforms.Length; i++)
			{
				_data.ChoiceTransforms[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < _archiveMessages.Count; j++)
			{
				NotificationMessages.Definition definition = _archiveMessages[j];
				InboxMessageRow component = _data.MessagesTable.InstantiateAsRow(_data.InboxMessageRowPrefab).GetComponent<InboxMessageRow>();
				component.RowSelectedImage.enabled = false;
				if (definition._icon != null)
				{
					component.MessageIcon.sprite = definition._icon;
				}
				int index = j;
				component.MessageTitleText.text = definition.GetTitleString();
				component.RowButton.onPrimaryDown.AddListener(delegate
				{
					SelectArchiveMessage(index);
				});
				_rows.Add(component);
			}
		}

		private void RebuildInboxMessageList()
		{
			_rows.Clear();
			_inboxMessages.Clear();
			_inboxMessages.AddRange(_notifications.NotificationMessages);
			_inboxMessages.Reverse();
			for (int i = 0; i < _data.ChoiceTransforms.Length; i++)
			{
				_data.ChoiceTransforms[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < _inboxMessages.Count; j++)
			{
				NotificationMessage message = _inboxMessages[j];
				InboxMessageRow component = _data.MessagesTable.InstantiateAsRow(_data.InboxMessageRowPrefab).GetComponent<InboxMessageRow>();
				component.RowSelectedImage.enabled = false;
				if (message.Definition._icon != null)
				{
					component.MessageIcon.sprite = message.Definition._icon;
				}
				component.MessageTitleText.text = message.GetTooltipText();
				int index = j;
				component.RowButton.onPrimaryDown.AddListener(delegate
				{
					SelectInboxMessage(index);
				});
				component.RowButton.onSecondaryDown.AddListener(delegate
				{
					CloseMessage(message, message.Definition.DefaultChoice);
				});
				_rows.Add(component);
			}
		}

		private void PrepareMessagePanel()
		{
			_data.MessageTitleText.text = string.Empty;
			GameObjectUtils.SetActive(_data.StandardContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.ChallengeContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffChallengeContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffPromotionContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffSuccessContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffWarningContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffResignationContentsPanel, isActive: false);
			GameObjectUtils.SetActive(_data.StaffTrainingContentsPanel, isActive: false);
			if (_characterMugShot != null)
			{
				_characterMugShot.Destroy();
				_characterMugShot = null;
			}
			_data.Mugshot.gameObject.SetActive(value: false);
			for (int i = 0; i < _data.ChoiceTransforms.Length; i++)
			{
				_data.ChoiceButtons[i].onPrimaryDown.RemoveAllListeners();
				_data.ChoiceTransforms[i].gameObject.SetActive(value: false);
			}
		}

		public void SelectInboxMessage(NotificationMessage message)
		{
			SelectInboxMessage(_inboxMessages.IndexOf(message));
		}

		public void SelectInboxMessage(int messageIndex)
		{
			EnterMode(Mode.Inbox);
			if (_selectedRowIndex >= 0)
			{
				_rows[_selectedRowIndex].RowSelectedImage.enabled = false;
			}
			PrepareMessagePanel();
			if (messageIndex < 0 || messageIndex >= _inboxMessages.Count)
			{
				return;
			}
			NotificationMessage notificationMessage = _inboxMessages[messageIndex];
			_rows[messageIndex].RowSelectedImage.enabled = true;
			_data.MessageTitleText.text = notificationMessage.GetTitleText();
			if (notificationMessage is NotificationStaff { Staff: var staff } && staff.Visual.IsActive())
			{
				_data.Mugshot.gameObject.SetActive(value: true);
				_characterMugShot = CharacterMugShot.FromCharacterVisual(staff.Visual, 256, 256, staff.Level.HUD.GetConfig().MugshotConfig);
				if (_characterMugShot != null)
				{
					_data.MugshotImage.texture = _characterMugShot.Texture;
				}
			}
			_selectedRowIndex = messageIndex;
			if (_currentMode == Mode.Inbox)
			{
				SetupChoicesButtons(notificationMessage);
			}
			if (notificationMessage is NotificationStaffPromotion message)
			{
				GameObjectUtils.SetActive(_data.StaffPromotionContentsPanel, isActive: true);
				_data.StaffPromotionContentsData.Setup(message);
			}
			else if (notificationMessage is NotificationStaffTrainingRequired message2)
			{
				GameObjectUtils.SetActive(_data.StaffTrainingContentsPanel, isActive: true);
				_data.StaffTrainingContentsData.Setup(message2, _level, _data.ChoiceButtonAnimators);
			}
			else if (notificationMessage is NotificationStaffChallenge message3)
			{
				GameObjectUtils.SetActive(_data.StaffChallengeContentsPanel, isActive: true);
				_data.StaffChallengeContentsData.Setup(message3);
			}
			else if (notificationMessage is NotificationChallenge message4)
			{
				GameObjectUtils.SetActive(_data.ChallengeContentsPanel, isActive: true);
				_data.ChallengeContentsData.Setup(message4);
			}
			else if (notificationMessage.Definition.DialogPrefab != null && notificationMessage.Definition.DialogPrefab.GetComponent<StaffResignationWarningNotificationUI>() != null)
			{
				GameObjectUtils.SetActive(_data.StaffResignationContentsPanel, isActive: true);
				_data.StaffResignationContentsData.SetupWarning(_level, notificationMessage);
			}
			else if (notificationMessage.Definition.DialogPrefab != null && notificationMessage.Definition.DialogPrefab.GetComponent<StaffResignationSuccessNotificationUI>() != null)
			{
				GameObjectUtils.SetActive(_data.StaffResignationContentsPanel, isActive: true);
				_data.StaffResignationContentsData.SetupSuccess(notificationMessage);
			}
			else if (notificationMessage.Definition.DialogPrefab != null && notificationMessage.Definition.DialogPrefab.GetComponent<StaffResignationLetterNotificationUI>() != null)
			{
				GameObjectUtils.SetActive(_data.StaffResignationContentsPanel, isActive: true);
				_data.StaffResignationContentsData.SetupFailed(notificationMessage);
			}
			else
			{
				GameObjectUtils.SetActive(_data.StandardContentsPanel, isActive: true);
				_data.StandardContentsData.Setup(notificationMessage.GetMessageText());
			}
		}

		private void SelectArchiveMessage(int archiveIndex)
		{
			EnterMode(Mode.Archive);
			if (_selectedRowIndex >= 0)
			{
				_rows[_selectedRowIndex].RowSelectedImage.enabled = false;
			}
			PrepareMessagePanel();
			if (archiveIndex >= 0 && archiveIndex < _archiveMessages.Count)
			{
				_rows[archiveIndex].RowSelectedImage.enabled = true;
				_data.MessageTitleText.text = _archiveMessages[archiveIndex].GetTitleString();
				_selectedRowIndex = archiveIndex;
				GameObjectUtils.SetActive(_data.StandardContentsPanel, isActive: true);
				_data.StandardContentsData.Setup(_archiveMessages[archiveIndex].GetTextString());
			}
		}

		private void SetupChoicesButtons(NotificationMessage message)
		{
			string[] choices = message.Definition.GetChoices();
			int num = ((choices != null) ? choices.Length : 0);
			for (int i = 0; i < num; i++)
			{
				TMP_Text componentInChildren = _data.ChoiceButtons[i].GetComponentInChildren<TMP_Text>();
				if (componentInChildren != null && choices != null && choices[i] != null)
				{
					componentInChildren.text = choices[i];
				}
				_data.ChoiceTransforms[i].gameObject.SetActive(value: true);
				_data.ChoiceButtonAnimators[i].CurrentState = ButtonAnimator.State.Selectable;
				int choice = i;
				_data.ChoiceButtons[i].onPrimaryDown.AddListener(delegate
				{
					CloseMessage(message, choice);
				});
			}
		}

		public void ScrollToSelectedMessage()
		{
			if (_selectedRowIndex >= 0 && _inboxMessages.Count > 1)
			{
				float num = (float)_selectedRowIndex / (float)(_inboxMessages.Count - 1);
				_data.MessagesTable.RowsScrollRect.verticalNormalizedPosition = 1f - num;
			}
		}

		private void CloseMessage(NotificationMessage message, int choice)
		{
			_notifications.Remove(message);
			if (message.Delegate != null)
			{
				message.Delegate(choice);
			}
			if (_notifications.NotificationMessages.Count == 0)
			{
				CloseMenu();
			}
		}

		private void OnNotificationRemoved(NotificationMessage message)
		{
			int selectedRowIndex = _selectedRowIndex;
			RebuildMessages();
			if (selectedRowIndex >= 0 && _rows.Count > 0)
			{
				if (_currentMode == Mode.Inbox)
				{
					int messageIndex = Mathf.Clamp(selectedRowIndex, 0, _rows.Count - 1);
					SelectInboxMessage(messageIndex);
				}
				else
				{
					int messageIndex = Mathf.Clamp(selectedRowIndex, 0, _rows.Count - 1);
					SelectArchiveMessage(messageIndex);
				}
			}
			else if (_currentMode == Mode.Inbox)
			{
				SelectInboxMessage(-1);
			}
			else
			{
				SelectArchiveMessage(-1);
			}
		}

		public override void Destroy()
		{
			_inputManager.RemoveGraphicRayCaster(_data.GraphicRaycaster);
			Notifications notifications = _notifications;
			notifications.OnNotificationRemoved = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationRemoved, new Action<NotificationMessage>(OnNotificationRemoved));
			if (_characterMugShot != null)
			{
				_characterMugShot.Destroy();
			}
		}
	}
}
