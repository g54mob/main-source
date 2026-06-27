using FMODUnity;
using Restory.Audio;
using Restory.Infrastructure.StateMachine;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.RegularPayment
{
	public sealed class GUI_RegularPaymentSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_RegularPayment regularPayment;

		[SerializeField]
		private EventReference openEnvelopeSound;

		[SerializeField]
		private EventReference closeEnvelopeSound;

		private IAudioPlayerService audioPlayer;

		private GlobalStateObserver globalStateObserver;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer, GlobalStateObserver globalStateObserver)
		{
			this.globalStateObserver = globalStateObserver;
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			regularPayment.OnIsVisibleChanged += ResolveVisibilityChanged;
		}

		private void OnDisable()
		{
			if (regularPayment.MonoShellExists())
			{
				regularPayment.OnIsVisibleChanged -= ResolveVisibilityChanged;
			}
		}

		private void ResolveVisibilityChanged()
		{
			if (globalStateObserver.IsInGameLoop)
			{
				audioPlayer.PlaySoundEventOneShot(regularPayment.IsVisible ? openEnvelopeSound : closeEnvelopeSound);
			}
		}
	}
}
