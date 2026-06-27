using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class GameIntroState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<GameIntroState>
		{
		}

		private readonly GUI_FadeScreens fadeScreens;

		[Inject]
		public GameIntroState(GUI_FadeScreens fadeScreens)
		{
			this.fadeScreens = fadeScreens;
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			fadeScreens.FadeOut();
			Debug.Log("GameIntroState Enter state");
		}

		public void Exit()
		{
			Debug.Log("GameIntroState Exit state");
		}
	}
}
