using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CashRegisterModule : MonoBehaviour
{
	[Serializable]
	public class CashRegisterModuleData
	{
		public float unitsToBuy;

		public float pricePerUnit;

		public string resourceName;

		public Sprite resourceIcon;

		public TrainCar car;

		public float TotalPrice => unitsToBuy * pricePerUnit;

		public CashRegisterModuleData()
		{
		}

		public CashRegisterModuleData(CashRegisterModuleData other, bool copyUnitsToBuy = false, bool copyPrice = false)
		{
			unitsToBuy = (copyUnitsToBuy ? other.unitsToBuy : 0f);
			pricePerUnit = (copyPrice ? other.pricePerUnit : 0f);
			resourceName = other.resourceName;
			resourceIcon = other.resourceIcon;
			car = other.car;
		}
	}

	public virtual CashRegisterModuleData Data { get; } = new CashRegisterModuleData();

	public virtual bool IsReady => true;

	public event Action OnUnitsToBuyChanged;

	protected virtual void Start()
	{
		InitializeData();
	}

	protected virtual void SetUnitsToBuy(float amount)
	{
		if (Data.unitsToBuy != amount)
		{
			Data.unitsToBuy = amount;
			this.OnUnitsToBuyChanged?.Invoke();
		}
	}

	public virtual void CancelShopping()
	{
		ResetData();
	}

	public abstract void ResetData();

	public virtual double GetTotalPrice()
	{
		return Data.TotalPrice;
	}

	public virtual float GetTotalUnitsInBasket()
	{
		return Data.unitsToBuy;
	}

	public virtual IReadOnlyList<CashRegisterModuleData> GetAllNonZeroPurchaseData()
	{
		List<CashRegisterModuleData> list = new List<CashRegisterModuleData>();
		if (Data.unitsToBuy > 0f)
		{
			list.Add(Data);
		}
		return list;
	}

	public abstract void GetBoughtResource();

	protected abstract void InitializeData();
}
