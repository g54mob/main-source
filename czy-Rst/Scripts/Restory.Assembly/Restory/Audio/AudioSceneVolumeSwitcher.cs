using System;
using System.Collections;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class AudioSceneVolumeSwitcher : IInitializable, IDisposable
	{
		private readonly IAudioPlayerService audioPlayerService;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly GlobalStateObserver globalStateObserver;

		private Coroutine changeVolumeAfterEndOfFrameCoroutine;

		private float targetVolumeValue;

		private float currentVolumeValue;

		public AudioSceneVolumeSwitcher(IAudioPlayerService audioPlayerService, GlobalStateObserver globalStateObserver, ICoroutineRunner coroutineRunner)
		{
			this.globalStateObserver = globalStateObserver;
			this.coroutineRunner = coroutineRunner;
			this.audioPlayerService = audioPlayerService;
		}

		public void Initialize()
		{
			currentVolumeValue = ((!DoesStateBlockSound(globalStateObserver.ActiveState)) ? 1 : 0);
			audioPlayerService.SetSceneVolume(currentVolumeValue);
		}

		public void Dispose()
		{
			if (changeVolumeAfterEndOfFrameCoroutine != null && coroutineRunner is MonoBehaviour monoBehaviour && monoBehaviour.MonoShellExists())
			{
				coroutineRunner.Stop(changeVolumeAfterEndOfFrameCoroutine);
				changeVolumeAfterEndOfFrameCoroutine = null;
			}
		}

		public void RequestVolumeChange(float newValue)
		{
			targetVolumeValue = ((newValue < targetVolumeValue) ? newValue : targetVolumeValue);
			if (changeVolumeAfterEndOfFrameCoroutine == null)
			{
				changeVolumeAfterEndOfFrameCoroutine = coroutineRunner.Run(ChangeVolumeAfterEndOfFrameCoroutine());
			}
		}

		private IEnumerator ChangeVolumeAfterEndOfFrameCoroutine()
		{
			yield return new WaitForEndOfFrame();
			if (!DoesStateBlockSound(globalStateObserver.ActiveState) || targetVolumeValue < currentVolumeValue)
			{
				audioPlayerService.SetSceneVolume(targetVolumeValue);
			}
			currentVolumeValue = targetVolumeValue;
			targetVolumeValue = 1f;
			changeVolumeAfterEndOfFrameCoroutine = null;
		}

		private static bool DoesStateBlockSound(IExitableState state)
		{
			if (!(state is LoadPresetListState) && !(state is LoadProgressState) && !(state is InstallServicesState) && !(state is StartLoadingPresetListState) && !(state is DisposePresetListState))
			{
				return state is FinalSelectionState;
			}
			return true;
		}
	}
}
