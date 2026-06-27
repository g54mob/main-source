using Restory.Data.InteractiveObjects;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.MoneyCash
{
	public class CashMoneyObjectFactory
	{
		private readonly InteractiveObjectInfo cashMoneyItemInfo;

		private readonly InteractiveObjectFactory factory;

		public InteractiveObjectInfo CashMoneyItemInfo => cashMoneyItemInfo;

		public CashMoneyObjectFactory(InteractiveObjectInfo cashMoneyItemInfo, InteractiveObjectFactory factory)
		{
			this.cashMoneyItemInfo = cashMoneyItemInfo;
			this.factory = factory;
		}

		public CashMoneyObject Create(int moneyAmount, Transform parent = null)
		{
			InteractiveObject interactiveObject = factory.CreateInteractiveObject(cashMoneyItemInfo, parent);
			if (!interactiveObject.TryGetComponent<CashMoneyObject>(out var component))
			{
				factory.DestroyInteractiveObject(interactiveObject);
				Debug.LogError("[CashMoneyService] tried to create money item, but its prefab has no required [CashMoneyObject] component!", cashMoneyItemInfo.Prefab);
				return null;
			}
			component.SetUp(moneyAmount);
			return component;
		}

		public void Destroy(CashMoneyObject cashMoneyObject)
		{
			if ((bool)cashMoneyObject.InteractiveObject)
			{
				factory.DestroyInteractiveObject(cashMoneyObject.InteractiveObject);
			}
		}
	}
}
