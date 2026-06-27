using System.Collections;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public class LogosIntroInputContextSwitcher : MonoBehaviour
	{
		[SerializeField]
		private string logosIntroControlsMapTag = "MainMenu";

		[SerializeField]
		private string disableAllControlsTag = "DisableAll";

		private GlobalStateObserver globalStateObserver;

		private IPlayerInput playerInput;

		private Coroutine initAfterSceneLoadedCoroutine;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver, IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
			this.globalStateObserver = globalStateObserver;
		}

		private void OnEnable()
		{
			playerInput?.SetMapEnableTag(disableAllControlsTag);
			initAfterSceneLoadedCoroutine = StartCoroutine(InitAfterSceneLoadedCoroutine());
		}

		private void OnDisable()
		{
			if (initAfterSceneLoadedCoroutine != null)
			{
				StopCoroutine(initAfterSceneLoadedCoroutine);
				initAfterSceneLoadedCoroutine = null;
			}
			playerInput?.SetMapEnableTag(disableAllControlsTag);
			globalStateObserver?.RemoveSubscriber(this);
		}

		private IEnumerator InitAfterSceneLoadedCoroutine()
		{
			yield return new WaitUntil(delegate
			{
				GlobalStateObserver globalStateObserver = this.globalStateObserver;
				return globalStateObserver != null && globalStateObserver.ActiveState is GameIntroLogosState;
			});
			playerInput.SetMapEnableTag(logosIntroControlsMapTag);
			globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
		}

		private void ResolveGlobalStateChanged()
		{
			if (globalStateObserver.IsInInitializationState)
			{
				playerInput?.SetMapEnableTag(disableAllControlsTag);
			}
			else
			{
				playerInput?.SetMapEnableTag(logosIntroControlsMapTag);
			}
		}
	}
}
