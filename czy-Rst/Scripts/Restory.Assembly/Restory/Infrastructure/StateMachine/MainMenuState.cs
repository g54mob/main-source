using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.TimeSystems;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine
{
	public class MainMenuState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<MainMenuState>
		{
		}

		private readonly GUI_FadeScreens fadeScreens;

		private readonly TimeScalingService timeScalingService;

		[Inject]
		public MainMenuState(GUI_FadeScreens fadeScreens, TimeScalingService timeScalingService)
		{
			this.fadeScreens = fadeScreens;
			this.timeScalingService = timeScalingService;
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			timeScalingService.ResetTimeScaleToDefault();
			fadeScreens.FadeOut();
			Debug.Log("MainMenuState Enter state");
		}

		public void Exit()
		{
			Debug.Log("MainMenuState Exit state");
		}
	}
}
