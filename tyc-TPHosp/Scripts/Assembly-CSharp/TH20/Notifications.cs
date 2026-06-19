using System;
using System.Collections.Generic;
using UnityConsole;

namespace TH20
{
	public class Notifications : MustCallDestroy, IGameEventsBase
	{
		public Action<NotificationMessage> OnNotificationSent;

		public Action<NotificationMessage> OnNotificationRemoved;

		public Action<NotificationMessage> OnMessageOpen;

		public Action<NotificationMessage, bool> OnMessageClose;

		private readonly MessagePresenter _messagePresenter;

		private readonly List<NotificationMessage> _messages = new List<NotificationMessage>();

		private List<NotificationMessages.Definition> _archive = new List<NotificationMessages.Definition>();

		private readonly List<NotificationMessage> _popupMessages = new List<NotificationMessage>();

		private readonly List<NotificationMessage> _cachedTimedOutMessages = new List<NotificationMessage>();

		private readonly List<string> _namedMessages = new List<string>();

		private readonly Level _level;

		[DontSave]
		private bool _useInbox = true;

		public NotificationMessages MessageDefinitions { get; private set; }

		public bool IsMessageOpen => _messagePresenter.CurrentOpenMessage != null;

		public NotificationMessage OpenMessage => _messagePresenter.CurrentOpenMessage;

		public int NumOfMessages => _messages.Count;

		public List<NotificationMessage> NotificationMessages => new List<NotificationMessage>(_messages);

		public List<NotificationMessages.Definition> ArchiveMessages => new List<NotificationMessages.Definition>(_archive);

		public Notifications(NotificationMessages messages, GameTime gameTime, HUD hud, Level level, MessagePresenterConfig dialogueMessageManagerConfig)
		{
			_level = level;
			GameEventsRegistry.RegisterLevelEvent(this);
			_messagePresenter = new MessagePresenter();
			_messagePresenter.Setup(dialogueMessageManagerConfig, gameTime, hud, level, this);
			MessageDefinitions = messages;
			ConsoleCommandsDatabase.RegisterCommand("EnableInbox", "Enable Inbox Menu", "EnableInbox", Debug_EnableInbox);
			ConsoleCommandsDatabase.RegisterCommand("DisableInbox", "Disable Inbox Menu", "DisableInbox", Debug_DisableInbox);
		}

		public void RestoreFromSave(HUD hud, Level level)
		{
			_useInbox = true;
			if (_archive == null)
			{
				_archive = new List<NotificationMessages.Definition>();
			}
			foreach (NotificationMessage message in _messages)
			{
				message.RestoreFromSave();
			}
			_messagePresenter.RestoreFromSave(hud, level);
			ConsoleCommandsDatabase.RegisterCommand("EnableInbox", "Enable Inbox Menu", "EnableInbox", Debug_EnableInbox);
			ConsoleCommandsDatabase.RegisterCommand("DisableInbox", "Disable Inbox Menu", "DisableInbox", Debug_DisableInbox);
			CloseAllPopupMenus();
		}

		public void GetNotificationMessages(List<NotificationMessage> messages)
		{
			messages.AddRange(_messages);
		}

		public void Update()
		{
			for (int i = 0; i < _messages.Count; i++)
			{
				if (_messages[i].HasTimedOut)
				{
					_cachedTimedOutMessages.Add(_messages[i]);
				}
			}
			if (_cachedTimedOutMessages.Count != 0)
			{
				foreach (NotificationMessage cachedTimedOutMessage in _cachedTimedOutMessages)
				{
					Remove(cachedTimedOutMessage);
					if (cachedTimedOutMessage.Delegate != null)
					{
						cachedTimedOutMessage.Delegate(cachedTimedOutMessage.Definition.DefaultChoice);
					}
				}
			}
			_cachedTimedOutMessages.Clear();
		}

		public void VerifyEvents()
		{
			OnNotificationSent.VerifyIsNull();
			OnNotificationRemoved.VerifyIsNull();
			OnMessageOpen.VerifyIsNull();
			OnMessageClose.VerifyIsNull();
		}

		public override void Destroy()
		{
			_messages.ClearAndCallDestroy();
			_popupMessages.ClearAndCallDestroy();
			_archive.Clear();
			_messagePresenter.Destroy();
			ConsoleCommandsDatabase.UnRegisterCommand("EnableInbox");
			ConsoleCommandsDatabase.UnRegisterCommand("DisableInbox");
			base.Destroy();
		}

		public void Send(NotificationMessage message)
		{
			if (message.Definition._showImmediately)
			{
				Open(message);
				return;
			}
			_messages.Add(message);
			OnNotificationSent.InvokeSafe(message);
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.NotificationReceived);
		}

		public void Open(NotificationMessage message)
		{
			if (_useInbox)
			{
				if (message.Definition.CanBeIgnored && !message.Definition._showImmediately)
				{
					_messagePresenter.OpenMessageInInbox(message);
				}
				else if (_messagePresenter.OpenOrQueueMessage(message))
				{
					OnMessageOpen.InvokeSafe(message);
				}
			}
			else if (_messagePresenter.OpenOrQueueMessage(message))
			{
				OnMessageOpen.InvokeSafe(message);
			}
		}

		public void OpenPopup(NotificationMessage message)
		{
			_popupMessages.Add(message);
			message.Definition.CanBeIgnored = false;
			Open(message);
		}

		public void CloseAllPopupMenus()
		{
			while (_popupMessages.Count > 0)
			{
				Remove(_popupMessages[0], bInvokeRemovedDelegate: false);
			}
			_popupMessages.Clear();
		}

		public bool IsMessageTypePopupOpen(NotificationMessages.Definition messageDefinition)
		{
			bool result = false;
			foreach (NotificationMessage popupMessage in _popupMessages)
			{
				if (popupMessage.Definition == messageDefinition)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public bool OpenNamed(NotificationMessage message, string name)
		{
			if (name.IsNullOrEmpty())
			{
				Open(message);
				return true;
			}
			if (_namedMessages.Contains(name))
			{
				return false;
			}
			_namedMessages.Add(name);
			OpenPopup(message);
			return true;
		}

		public bool SendNamed(NotificationMessage message, string name)
		{
			if (name.IsNullOrEmpty())
			{
				Send(message);
				return true;
			}
			if (_namedMessages.Contains(name))
			{
				return false;
			}
			_namedMessages.Add(name);
			Send(message);
			return true;
		}

		public void CloseCurrentOpenMessage()
		{
			NotificationMessage currentOpenMessage = _messagePresenter.CurrentOpenMessage;
			if (_messagePresenter.CloseCurrentOpenMessage())
			{
				OnMessageClose.InvokeSafe(currentOpenMessage, _messagePresenter.HasQueuedMessagesToOpen);
				if (_messagePresenter.TryOpenQueuedMessage())
				{
					OnMessageOpen.InvokeSafe(_messagePresenter.CurrentOpenMessage);
				}
			}
		}

		private bool CanArchive(NotificationMessages.Definition definition)
		{
			if (definition is NotificationMessages.DefinitionDynamic)
			{
				return false;
			}
			return definition.CanArchiveDefinition;
		}

		public void Remove(NotificationMessage message, bool bInvokeRemovedDelegate = true)
		{
			_messagePresenter.Remove(message);
			_messages.Remove(message);
			_popupMessages.Remove(message);
			if (CanArchive(message.Definition))
			{
				_archive.AddUnique(message.Definition);
			}
			message.Destroy();
			if (bInvokeRemovedDelegate)
			{
				OnNotificationRemoved.InvokeSafe(message);
			}
		}

		public NotificationMessage GetMessageFor(Character character)
		{
			foreach (NotificationMessage message in _messages)
			{
				if (character == message.GetCharacter())
				{
					return message;
				}
			}
			return null;
		}

		private ConsoleCommandResult Debug_DisableInbox(string[] args)
		{
			_useInbox = false;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnableInbox(string[] args)
		{
			_useInbox = true;
			return ConsoleCommandResult.Succeeded();
		}
	}
}
