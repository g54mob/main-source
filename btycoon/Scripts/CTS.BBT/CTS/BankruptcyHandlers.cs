using System;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BankruptcyHandlers : MonoSingleton<BankruptcyHandlers>
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		private GameOverUIData _gameOver;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private int _maxMonthsInRed = 2;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Feedback Settings")]
		private string _bankruptIcon;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private string _bankruptTitle;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		[TextArea]
		private string _bankruptText;

		private int _howManyMonthsInRed;

		public static event Action Bankrupted;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			_howManyMonthsInRed = 0;
			SceneReset.Reset += Reset;
			CalendarHandlers.NewMonth += CheckBankruptcy;
		}

		private void OnDisable()
		{
			SceneReset.Reset -= Reset;
			CalendarHandlers.NewMonth -= CheckBankruptcy;
		}

		private void Reset()
		{
			_howManyMonthsInRed = 0;
		}

		private void CheckBankruptcy()
		{
			if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney >= 0)
			{
				if (_howManyMonthsInRed != 0)
				{
					_howManyMonthsInRed = 0;
				}
			}
			else if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney < 0)
			{
				_howManyMonthsInRed++;
				if (_howManyMonthsInRed >= _maxMonthsInRed)
				{
					DeclareBankruptcy();
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void DeclareBankruptcy()
		{
			BankruptcyHandlers.Bankrupted?.Invoke();
			CTSSingleton<GameOver>.Instance.EndGame(_gameOver);
		}
	}
}
