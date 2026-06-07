using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Cheats
{
	public class CheatCodeManager : IInitializable, IDisposable
	{
		protected class CheatCodeCombo
		{
			public List<KeyCode> Combo;

			public List<string> ActionCombo;

			public Action OnComboComplete;

			private int _currentIndex;

			private bool _isComplete;

			public void CheckComboKeyboard(Keyboard keyboard)
			{
			}

			public void CheckComboController(Player player)
			{
			}

			private IGamepadTemplate GetGamepad(Player player)
			{
				return null;
			}
		}

		protected Player _player;

		protected PlayerOptions _playerOptions;

		protected AchievementManager _achievementManager;

		protected readonly List<CheatCodeCombo> _cheatCodeCombos;

		[Inject]
		private void Construct(PlayerOptions playerOptions, AchievementManager achievementManager)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public virtual void InternalUpdate()
		{
		}

		protected virtual void AddCheatCodeCombos()
		{
		}

		private void CheckForCheatCodeComboActivation()
		{
		}
	}
}
