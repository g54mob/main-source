using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	[Serializable]
	public sealed class CustomerOrder
	{
		public enum EStatus
		{
			WaitingToOrder = 0,
			Ordered = 1,
			Prepared = 2,
			Delivered = 3
		}

		private EStatus _status;

		private int _orderPrice;

		public bool IsDestroyed { get; private set; }

		public EStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				if (_status != value)
				{
					LastStageTime = GameTime.Now;
					_status = value;
				}
			}
		}

		public DrinkSO DrinkData { get; set; }

		public EOrderResult Satisfaction { get; set; }

		public PooledRef<Drink> PreparedDrink { get; set; }

		public Customer CustomerRef { get; }

		public WorkerChore Chore { get; set; }

		public GroupOrder GroupOrder { get; }

		public GameTime LastStageTime { get; private set; }

		public List<StockStack> IngredientList { get; } = new List<StockStack>();

		public event Action Destroyed;

		public static event Action<DrinkSO, int> DrinkPayed;

		private CustomerOrder()
		{
		}

		public CustomerOrder(Customer p_customer, GroupOrder p_groupOrder)
		{
			CustomerRef = p_customer;
			p_customer.CurrentOrder = this;
			GroupOrder = p_groupOrder;
			LastStageTime = GameTime.Now;
		}

		public void Setup(DrinkSO drinkData, EOrderResult satisfaction)
		{
			DrinkData = drinkData;
			Status = EStatus.Ordered;
			Satisfaction = satisfaction;
			_orderPrice = drinkData.GetCurrentPriceWithDifficulty();
			drinkData.TryGetIngredients(IngredientList);
			if (GroupOrder.Status == EStatus.WaitingToOrder)
			{
				GroupOrder.RecalculateStatus();
				if (GroupOrder.Status == EStatus.Ordered)
				{
					GroupOrder.CreatePreparationChores();
				}
			}
		}

		public void SetPrepared()
		{
			Status = EStatus.Prepared;
			IngredientList.Clear();
		}

		public void Pay()
		{
			CustomerRef.SpendMoney(_orderPrice);
			CustomerOrder.DrinkPayed?.Invoke(DrinkData, _orderPrice);
			if (CustomerRef.IsVampire)
			{
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, _orderPrice, TransactionTag.VampireCustomer);
			}
			else
			{
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, _orderPrice, TransactionTag.HumanCustomer);
			}
		}

		public void Clear()
		{
			if (IsDestroyed)
			{
				return;
			}
			if (IngredientList.Count > 0)
			{
				foreach (StockStack ingredient in IngredientList)
				{
					Stocks.BarStock.ForceAdd(ingredient.ItemData.StockType, ingredient);
				}
				IngredientList.Clear();
			}
			IsDestroyed = true;
			this.Destroyed?.Invoke();
			GroupOrder.RemoveOrder(this);
			if (PreparedDrink.TryGetValue(out var outValue))
			{
				outValue.SetEmpty();
				outValue.CreateClearingChore();
				if (outValue.IsHeld)
				{
					CustomerRef.ObjectHolding.DropObject();
					if (NavMesh.SamplePosition(CustomerRef.transform.position + CustomerRef.transform.forward, out var hit, 1.5f, AgentsMover.AllAreas))
					{
						outValue.transform.SetPositionAndRotation(hit.position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
					}
					else
					{
						outValue.Clear();
					}
				}
			}
			WorkerChore chore = Chore;
			if (chore != null && chore.Status == AgentAction.EStatus.Idle)
			{
				Chore.DestroyChore();
			}
		}
	}
}
