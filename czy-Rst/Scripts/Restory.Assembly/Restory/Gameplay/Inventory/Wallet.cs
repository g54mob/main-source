using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Inventory
{
	public class Wallet : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private int moneyInWallet;

		public int MoneyAvailable => moneyInWallet;

		public bool IsEmpty => moneyInWallet == 0;

		public event Action OnMoneyAmountChanged;

		public void Init(int moneyAmount)
		{
			moneyInWallet = moneyAmount;
			this.OnMoneyAmountChanged?.Invoke();
		}

		public bool TryToAdd(int moneyAmountToAdd)
		{
			if (!IsOperationValueValid(moneyAmountToAdd))
			{
				return false;
			}
			moneyInWallet += moneyAmountToAdd;
			this.OnMoneyAmountChanged?.Invoke();
			return true;
		}

		public bool TryToRemove(int moneyAmountToRemove, bool canBringAccountToBelowZero = false)
		{
			if (!IsOperationValueValid(moneyAmountToRemove) || (!canBringAccountToBelowZero && moneyAmountToRemove > moneyInWallet))
			{
				return false;
			}
			moneyInWallet -= moneyAmountToRemove;
			this.OnMoneyAmountChanged?.Invoke();
			return true;
		}

		public void RestoreState(object state)
		{
			try
			{
				WalletSaveData walletSaveData = DataMigrationWizard.Migrate<WalletSaveData>(state, base.gameObject);
				Init(walletSaveData.MoneyInWallet);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new WalletSaveData
				{
					MoneyInWallet = moneyInWallet
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		private static bool IsOperationValueValid(int value)
		{
			return value > 0;
		}
	}
}
