using FMODUnity;
using Restory.EventSystems;
using Restory.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class ActiveSelectionServiceSFX : MonoBehaviour
	{
		[SerializeField]
		private ActiveSelectionService selectionService;

		[SerializeField]
		private EventReference selectionChangedSound;

		private IAudioPlayerService audioPlayer;

		private GlobalStateObserver globalStateObserver;

		private bool isLoading = true;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer, GlobalStateObserver globalStateObserver)
		{
			this.globalStateObserver = globalStateObserver;
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
			}
		}

		private void ResolveGlobalStateChanged()
		{
			GlobalStateObserver globalStateObserver = this.globalStateObserver;
			if (globalStateObserver != null && globalStateObserver.IsInInitializationState)
			{
				selectionService.CurrentSelectionChanged -= ResolveSelectionChanged;
				isLoading = true;
			}
			else if (isLoading)
			{
				globalStateObserver = this.globalStateObserver;
				if (globalStateObserver != null && globalStateObserver.IsInGameLoop)
				{
					selectionService.CurrentSelectionChanged += ResolveSelectionChanged;
					isLoading = false;
				}
			}
		}

		private void OnEnable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
			}
			ResolveGlobalStateChanged();
		}

		private void OnDisable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.RemoveSubscriber(this);
			}
			if (selectionService != null)
			{
				selectionService.CurrentSelectionChanged -= ResolveSelectionChanged;
			}
			isLoading = true;
		}

		private void ResolveSelectionChanged(GameObject newSelectedObject)
		{
			if (newSelectedObject != null)
			{
				audioPlayer.PlaySoundEventOneShot(selectionChangedSound);
			}
		}
	}
}
