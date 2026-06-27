using System;
using Restory.Audio;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine
{
	public class GameResultsState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<GameResultsState>
		{
		}

		private readonly SoundLoopEmittersService soundLoopEmitters;

		private readonly GUI_FadeScreens fadeScreens;

		public GameResultsState(SoundLoopEmittersService soundLoopEmitters, GUI_FadeScreens fadeScreens)
		{
			this.soundLoopEmitters = soundLoopEmitters;
			this.fadeScreens = fadeScreens;
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			fadeScreens.FadeOut();
			Debug.Log("GameResultsState Enter state");
			soundLoopEmitters.StartEmittersPlayback();
		}

		public void Exit()
		{
			Debug.Log("GameResultsState Exit state");
		}
	}
}
