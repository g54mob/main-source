using System.Collections;
using CodeBase.Infrastructure;
using CodeBase.Logic;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		public LoadingCurtain CurtainPrefab;

		private Game _game;

		private void Awake()
		{
			_game = new Game(this, Object.Instantiate(CurtainPrefab));
			_game.StateMachine.Enter<BootstrapState>();
			Object.DontDestroyOnLoad(this);
		}

		Coroutine ICoroutineRunner.StartCoroutine(IEnumerator coroutine)
		{
			return StartCoroutine(coroutine);
		}
	}
}
