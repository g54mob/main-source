using System.Collections.Generic;

namespace TH20
{
	public class MessagePresenter : MustCallDestroy
	{
		private MessagePresenterConfig _config;

		[DontSave]
		private HUD _hud;

		private GameTime _gameTime;

		[DontSave]
		private Level _level;

		private Notifications _notifications;

		private readonly List<NotificationMessage> _openMessagesQueue = new List<NotificationMessage>();

		[DontSave]
		private bool _wasPausedOnOpen;

		[DontSave]
		private NotificationMessageUI _currentOpenMessageDiaglogue;

		private NotificationMessage _currentOpenMessage;

		public NotificationMessage CurrentOpenMessage => _currentOpenMessage;

		public bool HasQueuedMessagesToOpen => _openMessagesQueue.Count > 0;

		public void Setup(MessagePresenterConfig config, GameTime gameTime, HUD hud, Level level, Notifications notifications)
		{
			_config = config;
			_hud = hud;
			_gameTime = gameTime;
			_level = level;
			_notifications = notifications;
		}

		public void RestoreFromSave(HUD hud, Level level)
		{
			_hud = hud;
			_level = level;
			if (_currentOpenMessage != null)
			{
				if (!(_currentOpenMessage is NotificationDynamicMessage))
				{
					_gameTime.IsSuperPaused = true;
					CreateMessageDialogue(_currentOpenMessage);
				}
				else
				{
					DestroyCurrentOpenMessage();
				}
			}
		}

		public override void Destroy()
		{
			DestroyCurrentOpenMessage();
			_openMessagesQueue.ClearAndCallDestroy();
			base.Destroy();
		}

		public void DestroyCurrentOpenMessage()
		{
			if (_currentOpenMessage != null)
			{
				_currentOpenMessage.Destroy();
				_currentOpenMessage = null;
			}
		}

		public bool TryOpenQueuedMessage()
		{
			if (HasQueuedMessagesToOpen)
			{
				NotificationMessage message = _openMessagesQueue[0];
				_openMessagesQueue.RemoveAt(0);
				return OpenOrQueueMessage(message);
			}
			return false;
		}

		public bool OpenOrQueueMessage(NotificationMessage message)
		{
			if (_currentOpenMessageDiaglogue != null)
			{
				_openMessagesQueue.Add(message);
				return false;
			}
			_wasPausedOnOpen = _gameTime.IsSuperPaused;
			_gameTime.IsSuperPaused = true;
			CreateMessageDialogue(message);
			return true;
		}

		private void CreateMessageDialogue(NotificationMessage message)
		{
			_currentOpenMessage = message;
			_currentOpenMessageDiaglogue = _hud.CreateMenu<NotificationMessageUI>((message.Definition.DialogPrefab != null) ? message.Definition.DialogPrefab : _config.MessageDialogPrefab);
			if (_currentOpenMessageDiaglogue != null)
			{
				_currentOpenMessageDiaglogue.Setup(message, _level, _notifications);
			}
		}

		public bool OpenMessageInInbox(NotificationMessage message)
		{
			if (_currentOpenMessageDiaglogue != null)
			{
				return false;
			}
			InboxMenu inboxMenu = _hud.FindMenu<InboxMenu>();
			if (inboxMenu != null && !inboxMenu.IsClosed() && !inboxMenu.IsClosing())
			{
				return false;
			}
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(InboxMenu m)
			{
				m.Setup(InboxMenu.Mode.Inbox);
				m.SelectInboxMessage(message);
				m.ScrollToSelectedMessage();
			});
			return true;
		}

		public bool CloseCurrentOpenMessage()
		{
			if (_currentOpenMessageDiaglogue == null)
			{
				return false;
			}
			_currentOpenMessageDiaglogue.CloseMenu();
			_currentOpenMessageDiaglogue = null;
			_currentOpenMessage = null;
			if (!_wasPausedOnOpen)
			{
				_gameTime.IsSuperPaused = false;
			}
			return true;
		}

		public void Remove(NotificationMessage message)
		{
			_openMessagesQueue.Remove(message);
			if (_currentOpenMessage == message)
			{
				CloseCurrentOpenMessage();
			}
		}
	}
}
