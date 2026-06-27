using System;
using Restory.Audio;
using Restory.Data.Locations;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class GameLauncherState : IState, IExitableState, IDisposable, IPayloadedState<GameScenesPreset>
	{
		public class Factory : PlaceholderFactory<GameLauncherState>
		{
		}

		private readonly SoundLoopEmittersService soundLoopEmitters;

		private readonly GUI_FadeScreens fadeScreens;

		public GameScenesPreset ActivePreset { get; private set; }

		public GameLauncherState(SoundLoopEmittersService soundLoopEmitters, GUI_FadeScreens fadeScreens)
		{
			this.soundLoopEmitters = soundLoopEmitters;
			this.fadeScreens = fadeScreens;
		}

		public void Dispose()
		{
		}

		public void Enter(GameScenesPreset payload)
		{
			Enter();
			ActivePreset = payload;
		}

		public void Enter()
		{
			fadeScreens.FadeOut();
			Debug.Log("GameLauncherState Enter state");
			soundLoopEmitters.StartEmittersPlayback();
		}

		public void Exit()
		{
			Debug.Log("GameLauncherState Exit state");
		}
	}
}
