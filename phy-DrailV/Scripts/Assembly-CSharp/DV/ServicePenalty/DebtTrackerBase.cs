using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.ServicePenalty
{
	public abstract class DebtTrackerBase
	{
		protected CarDebtData debtData;

		public abstract DebtComponent[] InitializeDebtComponents();

		public abstract void UpdateDebtValues();

		public CarDebtData GetDebtData()
		{
			return debtData;
		}

		public DebtComponent[] GetTrackedDebts()
		{
			return debtData?.GetTrackedDebts();
		}

		public void UpdateStartValueToEndValue()
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			for (int i = 0; i < trackedDebts.Length; i++)
			{
				trackedDebts[i].UpdateStartValueToEndValue();
			}
		}

		public float GetCurrentTotalPriceOfDebt(bool includeTax = false, bool ignoreEnvironmentDamage = false)
		{
			return debtData.GetTotalPriceOfDebt(includeTax, ignoreEnvironmentDamage);
		}

		public void TakeSnapshot(List<ResourceType> debtTypesToExcludeFromSnapshot = null)
		{
			UpdateDebtValues();
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			foreach (DebtComponent debtComponent in trackedDebts)
			{
				if (debtTypesToExcludeFromSnapshot == null || !debtTypesToExcludeFromSnapshot.Contains(debtComponent.Type))
				{
					debtComponent.SetSnapshot(debtComponent.EndValue);
				}
			}
		}

		public void ClearSnapshot()
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			for (int i = 0; i < trackedDebts.Length; i++)
			{
				trackedDebts[i].ClearSnapshot();
			}
		}
	}
}
