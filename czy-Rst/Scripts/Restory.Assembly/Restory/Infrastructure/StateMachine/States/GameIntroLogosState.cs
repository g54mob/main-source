using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class GameIntroLogosState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<GameIntroLogosState>
		{
		}

		private readonly GUI_FadeScreens fadeScreens;

		[Inject]
		public GameIntroLogosState(GUI_FadeScreens fadeScreens)
		{
			this.fadeScreens = fadeScreens;
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			fadeScreens.FadeOut();
			Debug.Log("GameIntroLogosState Enter state");
		}

		public void Exit()
		{
			Debug.Log("GameIntroLogosState Exit state");
		}
	}
}
