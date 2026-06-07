using System.Collections.Generic;
using Factory;
using Motorways.Views;

namespace Motorways
{
	public class InGameMessageUIManager : ICreatedInScopeHandler, MainMenuScreen.IObserver
	{
		[Dependency]
		private MainMenuScreen _mainMenu;

		[Dependency]
		private Scope _scope;

		[Dependency]
		private ActivePlayer _player;

		private InGameMessage _currentMessage;

		private List<StandaloneLocString> queuedMessages = new List<StandaloneLocString>();

		private bool _canShowMessages;

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("InGameMessage");

		public bool HasMessage => _currentMessage != null;

		public void DisplayMessage(StandaloneLocString localisedString)
		{
			queuedMessages.Add(localisedString);
			if (_currentMessage == null)
			{
				Log.Info("Displaying message " + localisedString);
				DisplayNextQueuedMessage();
			}
			else
			{
				Log.Info("Queueing message " + localisedString);
				_currentMessage.SetIcon(hasNextMessage: true);
				_currentMessage.ShowDismissIcon();
			}
		}

		private void DisplayNextQueuedMessage()
		{
			if (_canShowMessages && Diagnostics.Verify(_currentMessage == null, "The current message isn't null! This may mean we didn't finish the close animation before trying to show a new one.") && Diagnostics.Verify(queuedMessages.Count > 0, "We don't have any messages to show! Aborting."))
			{
				_currentMessage = _scope.Get<InGameMessage>();
				_currentMessage.SetMessage(queuedMessages[0], RemoveCurrentMessage);
				_currentMessage.MoveMessage(_mainMenu.inGameMessageStackStartPosition.position);
				queuedMessages.RemoveAt(0);
				_currentMessage.SetIcon(queuedMessages.Count > 0);
			}
		}

		public void OnMainMenuTransitionedIn()
		{
			_canShowMessages = true;
			if (queuedMessages.Count > 0)
			{
				DisplayNextQueuedMessage();
			}
		}

		public void OnMainMenuTransitionOut()
		{
			_canShowMessages = false;
			_currentMessage?.DismissMessage(_player.IsSkipTransitionsEnabled);
		}

		public void OnMainMenuExit()
		{
		}

		public void OnCreatedInScope(IScope scope)
		{
			_mainMenu.Subscribe(this);
			scope.Get<InGameMessageService>();
		}

		public void DismissCurrentMessage()
		{
			_currentMessage?.DismissMessage();
		}

		private void RemoveCurrentMessage()
		{
			_currentMessage = null;
			if (queuedMessages.Count > 0)
			{
				DisplayNextQueuedMessage();
			}
		}
	}
}
