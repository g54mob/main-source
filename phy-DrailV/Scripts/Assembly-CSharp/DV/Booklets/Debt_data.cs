using System;
using DV.ServicePenalty;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	[Serializable]
	public class Debt_data
	{
		public string ID;

		public DebtType debtType;

		public float totalPriceOfDamageableResources;

		public float sumOfDebts1;

		public float sumOfDebts2;

		public float environmentDamageTotalPrice;

		public float totalPrice;

		public bool isTaxable;

		public bool isStaged;

		public CarDebtData[] debtData;

		public bool countsInFeeTolerance;

		public bool IsJobDebt
		{
			get
			{
				if (debtType != DebtType.ExistingJob)
				{
					return debtType == DebtType.StagedJob;
				}
				return true;
			}
		}

		public bool IsJobOrOther
		{
			get
			{
				if (!IsJobDebt && debtType != DebtType.ExistingOther)
				{
					return debtType == DebtType.StagedOther;
				}
				return true;
			}
		}

		public bool IsLocoDebt
		{
			get
			{
				if (debtType != DebtType.ExistingLoco)
				{
					return debtType == DebtType.StagedLoco;
				}
				return true;
			}
		}

		public bool IsOwnedCarDebt
		{
			get
			{
				if (debtType != DebtType.ExistingOwnedCar)
				{
					return debtType == DebtType.StagedOwnedCar;
				}
				return true;
			}
		}

		public ResourceType[] EnvironmentDamageTypes
		{
			get
			{
				if (!IsJobOrOther)
				{
					return C.ENVIRONMENT_DAMAGE_TYPES_LOCO;
				}
				return C.ENVIRONMENT_DAMAGE_TYPES_CARGO;
			}
		}

		public Debt_data(string ID, DebtType debtType, float totalPriceOfDamageableResources, float sumOfDebts1, float sumOfDebts2, float environmentDamageTotalPrice, float totalPrice, bool isTaxable, bool isStaged, CarDebtData[] debtData, bool countsInFeeTolerance)
		{
			this.ID = ID;
			this.debtType = debtType;
			this.totalPriceOfDamageableResources = totalPriceOfDamageableResources;
			this.sumOfDebts1 = sumOfDebts1;
			this.sumOfDebts2 = sumOfDebts2;
			this.environmentDamageTotalPrice = environmentDamageTotalPrice;
			this.totalPrice = totalPrice;
			this.isTaxable = isTaxable;
			this.isStaged = isStaged;
			this.debtData = debtData;
			this.countsInFeeTolerance = countsInFeeTolerance;
		}

		public Debt_data(DisplayableDebt debt)
		{
			ID = debt.ID;
			debtType = debt.GetDebtType();
			totalPriceOfDamageableResources = debt.GetTotalPriceOfResources(ResourceTypes.DamageableResources);
			sumOfDebts1 = (IsJobOrOther ? debt.GetTotalPriceOfResources(new ResourceType[1] { ResourceType.Car_DMG }) : totalPriceOfDamageableResources);
			sumOfDebts2 = debt.GetTotalPriceOfResources((!IsJobOrOther) ? ResourceTypes.ConsumableResources : new ResourceType[1] { ResourceType.Cargo_DMG });
			environmentDamageTotalPrice = (IsOwnedCarDebt ? 0f : debt.GetTotalPriceOfResources(EnvironmentDamageTypes));
			totalPrice = debt.GetTotalPrice();
			isTaxable = debt.IsTaxable;
			isStaged = debt.IsStaged;
			debtData = debt.GetCarDebts();
			countsInFeeTolerance = debt.ActivationTime < SingletonBehaviour<DateTimeWrapper>.Instance.GetDateTimeOfMostRecentHour(7);
		}

		public int GetNumberOfPagesForDebt(bool filterOutUnchangedDebts, ResourceType[] typesToExclude = null)
		{
			int num = 0;
			CarDebtData[] array = debtData;
			foreach (CarDebtData carDebtData in array)
			{
				num += carDebtData.GetNumberOfDebtComponents(filterOutUnchangedDebts, typesToExclude);
			}
			int num2 = Mathf.CeilToInt((float)num / 4f);
			int num3 = ((!IsOwnedCarDebt) ? 1 : 0);
			return 1 + num2 + num3;
		}
	}
}
