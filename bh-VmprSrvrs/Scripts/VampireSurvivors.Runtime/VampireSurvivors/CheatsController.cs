using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine.SceneManagement;
using Zenject;

namespace VampireSurvivors
{
	public class CheatsController : IInitializable, IDisposable
	{
		private List<CheatData> _gameplayCheats;

		private List<CheatData> _menuCheats;

		[Inject]
		private SignalBus _signalBus;

		private Player _player;

		public void Initialize()
		{
		}

		private void UnloadCheats(Scene arg0)
		{
		}

		private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
		{
		}

		private void LoadCheats(string sceneName)
		{
		}

		public void Dispose()
		{
		}

		private void AddAllGameplayCheats()
		{
		}

		private void AddAllMenuCheats()
		{
		}

		private void AddGameplayCheat(string label, Action cb)
		{
		}

		private void AddMenuCheat(string label, Action cb)
		{
		}

		private void ResumeGame()
		{
		}

		public List<CheatData> GetCheats()
		{
			return null;
		}
	}
}
