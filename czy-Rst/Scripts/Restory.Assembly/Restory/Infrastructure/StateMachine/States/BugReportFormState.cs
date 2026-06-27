using System;
using Restory.Audio;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.TimeSystems;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class BugReportFormState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<BugReportFormState>
		{
		}

		private readonly TimeScalingService timeScaler;

		private readonly IAudioPlayerService audioPlayer;

		private float savedTimeScale;

		public BugReportFormState(TimeScalingService timeScaler, IAudioPlayerService audioPlayer)
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
			audioPlayer.ResumeAllPausedSounds();
			timeScaler.SetTimeScale(savedTimeScale);
		}
	}
}
