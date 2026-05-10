using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class GameOverMoney : GameOverListener
	{
		[SerializeField]
		private int _maxDaysInRed = 30;

		private int _daysInRedCount;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CalendarHandlers.NewDay += OnNewDay;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			CalendarHandlers.NewDay -= OnNewDay;
		}

		private void OnNewDay()
		{
			if (!MonoSingleton<MoneyHandler>.InstanceExists())
			{
				return;
			}
			if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney >= 0)
			{
				_daysInRedCount = 0;
				return;
			}
			_daysInRedCount++;
			if (_daysInRedCount >= _maxDaysInRed)
			{
				StartGameOver();
			}
		}

		public override bool IsGameOverValid()
		{
			return MonoSingleton<MoneyHandler>.Instance.CurrentMoney < 0;
		}
	}
}
