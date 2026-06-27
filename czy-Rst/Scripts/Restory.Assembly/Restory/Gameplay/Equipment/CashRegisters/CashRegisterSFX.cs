using System;
using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.CashRegisters
{
	public class CashRegisterSFX : MonoBehaviour
	{
		[SerializeField]
		private CashRegister cashRegister;

		[SerializeField]
		private CashRegisterVisualizer visualizer;

		[SerializeField]
		private EventReference moneyAddedSound;

		[SerializeField]
		private EventReference openingMovementSound;

		[SerializeField]
		private EventReference openingMovementFromPartiallyOpenSound;

		[SerializeField]
		private EventReference closingMovementSound;

		[SerializeField]
		private EventReference openingStartBellSound;

		[SerializeField]
		private EventReference openingEndHitSound;

		[SerializeField]
		private EventReference closingEndHitSound;

		private IAudioPlayerService audioPlayer;

		private CashDrawerState previousState;

		private EventInstance movementSoundInstance;

		private bool wasPreviousAnimationStillActive;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if (audioPlayer != null)
			{
				Init();
			}
		}

		private void Init()
		{
			previousState = cashRegister.CurrentState;
			cashRegister.OnMoneyAdded += ResolveMoneyAdded;
			visualizer.OnBeforeAnimationStarted += ResolvePreparingToStartAnimation;
			visualizer.OnAnimationStarted += ResolveAnimationStarted;
			visualizer.OnAnimationCompleted += ResolveAnimationCompleted;
		}

		private void OnDisable()
		{
			if (cashRegister.MonoShellExists())
			{
				cashRegister.OnMoneyAdded -= ResolveMoneyAdded;
			}
			if (visualizer.MonoShellExists())
			{
				visualizer.OnBeforeAnimationStarted += ResolvePreparingToStartAnimation;
				visualizer.OnAnimationStarted -= ResolveAnimationStarted;
				visualizer.OnAnimationCompleted -= ResolveAnimationCompleted;
			}
			audioPlayer?.StopSoundEventInstance(movementSoundInstance, allowFadeOut: false);
		}

		private void ResolveMoneyAdded()
		{
			audioPlayer.PlaySoundEventOneShot(moneyAddedSound, base.transform.position);
		}

		private void ResolvePreparingToStartAnimation()
		{
			wasPreviousAnimationStillActive = visualizer.IsAnimationActive;
		}

		private void ResolveAnimationStarted()
		{
			switch (cashRegister.CurrentState)
			{
			case CashDrawerState.Open:
				if (previousState == CashDrawerState.PartiallyOpen || wasPreviousAnimationStillActive)
				{
					StartPlayingMovementSound(openingMovementFromPartiallyOpenSound);
					break;
				}
				StartPlayingMovementSound(openingMovementSound);
				audioPlayer.PlaySoundEventOneShot(openingStartBellSound, base.gameObject);
				break;
			case CashDrawerState.Closed:
				StartPlayingMovementSound(closingMovementSound);
				break;
			case CashDrawerState.PartiallyOpen:
				switch (previousState)
				{
				case CashDrawerState.None:
					if (wasPreviousAnimationStillActive)
					{
						StartPlayingMovementSound(openingMovementFromPartiallyOpenSound);
						break;
					}
					StartPlayingMovementSound(openingMovementSound);
					audioPlayer.PlaySoundEventOneShot(openingStartBellSound, base.gameObject);
					break;
				case CashDrawerState.Open:
					StartPlayingMovementSound(closingMovementSound);
					break;
				case CashDrawerState.Closed:
					if (wasPreviousAnimationStillActive)
					{
						StartPlayingMovementSound(openingMovementFromPartiallyOpenSound);
						break;
					}
					StartPlayingMovementSound(openingMovementSound);
					audioPlayer.PlaySoundEventOneShot(openingStartBellSound, base.gameObject);
					break;
				default:
					throw new NotImplementedException();
				case CashDrawerState.PartiallyOpen:
					break;
				}
				break;
			default:
				throw new NotImplementedException();
			case CashDrawerState.None:
				break;
			}
			previousState = cashRegister.CurrentState;
		}

		private void StartPlayingMovementSound(EventReference movementSound)
		{
			audioPlayer.StopSoundEventInstance(movementSoundInstance, allowFadeOut: false);
			audioPlayer.TryToStartSoundEvent(movementSound, base.gameObject, out movementSoundInstance);
		}

		private void ResolveAnimationCompleted()
		{
			audioPlayer.StopSoundEventInstance(movementSoundInstance, allowFadeOut: false);
			movementSoundInstance.clearHandle();
			switch (cashRegister.CurrentState)
			{
			case CashDrawerState.Open:
				audioPlayer.PlaySoundEventOneShot(openingEndHitSound, base.gameObject);
				break;
			case CashDrawerState.Closed:
				audioPlayer.PlaySoundEventOneShot(closingEndHitSound, base.gameObject);
				break;
			default:
				throw new NotImplementedException();
			case CashDrawerState.None:
			case CashDrawerState.PartiallyOpen:
				break;
			}
		}
	}
}
