using System;
using Restory.Audio;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class GamePauseState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<GamePauseState>
		{
		}

		private readonly TimeScalingService timeScaler;

		private readonly IAudioPlayerService audioPlayer;

		private float savedTimeScale;

		public GamePauseState(TimeScalingService timeScaler, IAudioPlayerService audioPlayer)
		{
			this.timeScaler = timeScaler;
			this.audioPlayer = audioPlayer;
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			audioPlayer.PauseAllSFX();
			savedTimeScale = timeScaler.CurrentTimeScale();
			timeScaler.SetTimeScale(0f);
		}

		public void Exit()
		{
			if (Assert())
			{
				audioPlayer.ResumeAllPausedSounds();
				timeScaler.SetTimeScale(savedTimeScale);
			}
		}

		private bool Assert()
		{
			if (audioPlayer == null)
			{
				Debug.LogException(new NullReferenceException("Audio player is null"));
				return false;
			}
			if (!timeScaler)
			{
				Debug.LogException(new NullReferenceException("Time Scaler player is null"));
				return false;
			}
			return true;
		}
	}
}
