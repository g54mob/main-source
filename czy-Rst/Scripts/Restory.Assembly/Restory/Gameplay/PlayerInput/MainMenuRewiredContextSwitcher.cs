using System;
using Restory.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public class MainMenuRewiredContextSwitcher : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private string mainMenuTag = "MainMenu";

		[SerializeField]
		private string disableAll = "DisableAll";

		private IPlayerInput playerInput;

		private GlobalStateObserver globalStateObserver;

		private EventSystem eventSystem;

		[Inject]
		private void Construct(IPlayerInput playerInput, GlobalStateObserver globalStateObserver, EventSystem eventSystem)
		{
			this.playerInput = playerInput;
			this.globalStateObserver = globalStateObserver;
			this.eventSystem = eventSystem;
		}

		public void Initialize()
		{
			globalStateObserver.AddSubscriber(this, OnGlobalStateChange);
			OnGlobalStateChange();
		}

		public void Dispose()
		{
			globalStateObserver.RemoveSubscriber(this);
		}

		private void OnGlobalStateChange()
		{
			if (globalStateObserver.IsInInitializationState)
			{
				playerInput.SetMapEnableTag(disableAll);
				eventSystem.enabled = false;
			}
			else
			{
				playerInput.SetMapEnableTag(mainMenuTag);
				eventSystem.enabled = true;
			}
		}
	}
}
