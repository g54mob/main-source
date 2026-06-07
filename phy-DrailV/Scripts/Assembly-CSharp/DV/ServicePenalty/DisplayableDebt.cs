using System;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.ServicePenalty
{
	public abstract class DisplayableDebt
	{
		public abstract string ID { get; }

		public DateTime ActivationTime { get; private set; }

		public bool IsActivationTimeSet => ActivationTime != DateTime.MinValue;

		public virtual bool IsPayable => true;

		public virtual bool IsTaxable => false;

		public virtual bool IsStaged => false;

		public abstract DebtType GetDebtType();

		public abstract float GetTotalPrice();

		public abstract CarDebtData[] GetCarDebts();

		public float GetTotalPriceOfResources(ResourceType[] resources)
		{
			float num = 0f;
			CarDebtData[] carDebts = GetCarDebts();
			foreach (CarDebtData carDebtData in carDebts)
			{
				num += carDebtData.GetTotalPriceOfResources(resources, IsTaxable);
			}
			return num;
		}

		public virtual void UpdateDebtState()
		{
			if (IsStaged)
			{
				Debug.LogError($"Attempt to update debt state that is already staged [{GetDebtType()}]!");
			}
		}

		protected void UpdateActivationTime()
		{
			bool flag = GetTotalPrice() <= 0f;
			if (ActivationTime == DateTime.MinValue)
			{
				if (!flag)
				{
					ActivationTimeToCurrentTime();
				}
			}
			else if (flag)
			{
				ClearActivationTime();
			}
		}

		protected void ClearActivationTime()
		{
			ActivationTime = DateTime.MinValue;
		}

		protected void SetActivationTime(DateTime activationTime)
		{
			ActivationTime = activationTime;
		}

		protected void ActivationTimeToCurrentTime()
		{
			ActivationTime = SingletonBehaviour<DateTimeWrapper>.Instance.DateTime;
		}

		public virtual void Pay()
		{
			if (!IsPayable)
			{
				Debug.LogError($"Attempt to pay debt that isn't ready for paying [{GetDebtType()}]!");
			}
			else
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.UpdateInsuranceFeePaidAmount(GetTotalPrice());
			}
		}
	}
}
