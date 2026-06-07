using System;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using UnityEngine;

namespace Data.GameState
{
	[CreateAssetMenu(menuName = "General/Pause State", fileName = "PauseStateData", order = 0)]
	public class PauseStateData : ScriptableObject
	{
		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[SerializeField]
		private BoolVariableSO _pausedBuildMode;

		private int _currentGlobalUpdateMultiplier = 1;

		private DateTime _pauseStarted;

		public bool IsPaused { get; private set; }

		public event Action<bool> PauseStateChanged;

		private void OnEnable()
		{
			IsPaused = false;
			_pausedBuildMode.SetValue(value: false);
		}

		public void SetPausedBuildMode(bool active)
		{
			SetPauseState(active);
			_pausedBuildMode.SetValue(active);
		}

		public void SetPauseState(bool active)
		{
			IsPaused = active;
			if (active)
			{
				if (_globalUpdateMultiplier.Value > 0)
				{
					_currentGlobalUpdateMultiplier = _globalUpdateMultiplier.Value;
				}
				_globalUpdateMultiplier.SetValue(0);
				_pauseStarted = DateTime.Now;
			}
			else
			{
				_globalUpdateMultiplier.SetValue(_currentGlobalUpdateMultiplier);
				TimeSpan timeSpan = DateTime.Now - _pauseStarted;
				_saveInfoPersistentSO.RemovePausedDurationFromTotalPlayTime(timeSpan.TotalMinutes);
			}
			this.PauseStateChanged?.Invoke(active);
		}

		public bool CanSetPauseState()
		{
			return !_pausedBuildMode.Value;
		}

		public void TogglePause()
		{
			IsPaused = !IsPaused;
			SetPauseState(IsPaused);
		}

		public void TogglePausedBuildMode()
		{
			_pausedBuildMode.SetValue(!_pausedBuildMode.Value);
			SetPausedBuildMode(_pausedBuildMode.Value);
		}
	}
}
