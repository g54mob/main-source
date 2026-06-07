using System;
using Data.FactoryFloor.GameMode;
using NaughtyAttributes;
using UnityEngine;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/CurrentGameMode", fileName = "CurrentGameMode", order = 0)]
	public class CurrentGameMode : ScriptableObject
	{
		[SerializeField]
		[Required(null)]
		private GameModeSO _defaultGameMode;

		private GameModeSO _currentGameMode;

		public GameModeSO Mode
		{
			get
			{
				if (!(_currentGameMode != null))
				{
					return _defaultGameMode;
				}
				return _currentGameMode;
			}
		}

		public event Action<GameModeSO> CurrentGameModeChanged;

		public void SwitchTo(GameModeSO gameMode)
		{
			_currentGameMode = gameMode;
			_currentGameMode.Init();
			this.CurrentGameModeChanged?.Invoke(gameMode);
		}

		private void OnEnable()
		{
			_currentGameMode = _defaultGameMode;
		}
	}
}
