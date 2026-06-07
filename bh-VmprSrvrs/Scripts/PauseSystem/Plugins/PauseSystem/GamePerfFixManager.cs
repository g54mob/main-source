using System.Collections.Generic;
using UnityEngine;

namespace Plugins.PauseSystem
{
	public class GamePerfFixManager : MonoBehaviour
	{
		private readonly HashSet<GameMonoBehaviour> _gameMonoBehaviours;

		private readonly HashSet<GameMonoBehaviour> _gameMonoBehavioursToAdd;

		private readonly HashSet<GameMonoBehaviour> _gameMonoBehavioursToRemove;

		private static GamePerfFixManager _sInstance;

		public static GamePerfFixManager Instance => null;

		private void Awake()
		{
		}

		protected internal void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void AddBehaviour(GameMonoBehaviour gameMonoBehaviour)
		{
		}

		public void RemoveBehaviour(GameMonoBehaviour gameMonoBehaviour)
		{
		}

		private void UpdateHashSetElements()
		{
		}
	}
}
