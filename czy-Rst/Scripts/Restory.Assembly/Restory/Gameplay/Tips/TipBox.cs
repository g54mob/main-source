using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Tips
{
	public class TipBox : MonoBehaviour, IDetectableObject, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private GameObject moneyObject;

		private bool skipDetectionDisable;

		public int AccumulatedTips { get; private set; }

		public bool CanBeDetected
		{
			set
			{
				if (skipDetectionDisable)
				{
					skipDetectionDisable = false;
					if (!value)
					{
						return;
					}
				}
				clickableTrigger.enabled = value;
			}
		}

		public event Action<int> OnTipsAdded;

		public event Action<int> OnTipsReturned;

		public event Action OnTipsRemoved;

		public void Init(int moneyAmount)
		{
			if (moneyAmount < 0)
			{
				Debug.LogError("moneyAmount can't be less than 0");
				return;
			}
			AccumulatedTips = moneyAmount;
			UpdateMoneyObject();
		}

		public bool TryAddTips(int moneyAmount)
		{
			if (moneyAmount < 1)
			{
				Debug.LogError("moneyAmount must be greater than 0");
				return false;
			}
			AccumulatedTips += moneyAmount;
			this.OnTipsAdded?.Invoke(moneyAmount);
			UpdateMoneyObject();
			return true;
		}

		public bool TryTakeTips(out int moneyAmount)
		{
			moneyAmount = AccumulatedTips;
			AccumulatedTips = 0;
			if (moneyAmount < 1)
			{
				return false;
			}
			skipDetectionDisable = true;
			this.OnTipsRemoved?.Invoke();
			UpdateMoneyObject();
			return true;
		}

		public void ReturnTips(int moneyAmount)
		{
			AccumulatedTips += moneyAmount;
			this.OnTipsReturned?.Invoke(moneyAmount);
			UpdateMoneyObject();
		}

		private void UpdateMoneyObject()
		{
			moneyObject.SetActive(AccumulatedTips > 0);
		}

		public object CaptureState()
		{
			try
			{
				return new TipBoxSaveData
				{
					AccumulatedTips = AccumulatedTips
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				TipBoxSaveData tipBoxSaveData = DataMigrationWizard.Migrate<TipBoxSaveData>(state, base.gameObject);
				AccumulatedTips = tipBoxSaveData.AccumulatedTips;
				UpdateMoneyObject();
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
