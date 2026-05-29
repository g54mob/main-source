using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;

namespace CTS.BBT.AI
{
	public sealed class GroupOrder
	{
		private readonly CustomerGroupData _groupData;

		private WorkerChore _currentChore;

		private readonly Resource<OrderPlate> PlatePrefab = new Resource<OrderPlate>("Pfb_OrderPlate");

		private PooledRef<OrderPlate> _plate;

		public CustomerOrder.EStatus Status { get; private set; }

		public List<CustomerOrder> Orders { get; } = new List<CustomerOrder>();

		public bool Destroyed { get; private set; }

		public Table AssignedTable => Orders[0].CustomerRef.GroupData.AssignedTable;

		public StationDrink Station { get; set; }

		public List<ItemSlot> StationSlots { get; } = new List<ItemSlot>();

		public OrderPlate Plate
		{
			get
			{
				if (!_plate.TryGetValue(out var outValue))
				{
					outValue = Pooler.Pull(PlatePrefab.Value);
					_plate = new PooledRef<OrderPlate>(outValue);
				}
				return outValue;
			}
			set
			{
				_plate = new PooledRef<OrderPlate>(value);
			}
		}

		private GroupOrder()
		{
		}

		public GroupOrder(Customer p_customer)
		{
			_groupData = p_customer.GroupData;
			_groupData.CurrentOrders.Add(this);
		}

		public void RecalculateStatus()
		{
			CustomerOrder.EStatus eStatus = CustomerOrder.EStatus.Delivered;
			foreach (CustomerOrder order in Orders)
			{
				if (order.Status < eStatus)
				{
					eStatus = order.Status;
				}
			}
			Status = eStatus;
		}

		public void AddOrder(CustomerOrder p_order)
		{
			Orders.Add(p_order);
			CreateOrderChore();
		}

		public void CreateOrderChore()
		{
			if (_currentChore == null && (bool)_groupData.AssignedTable)
			{
				ChoreCategory p_category = (_groupData.Members[0].IsVampire ? ChoreCategory.ServiceVampire : ChoreCategory.Service);
				_currentChore = new WorkerChoreHub(p_category, new ActionHubGroupOrder(this), _groupData.AssignedTable.Furniture.RoomObject);
				MonoSingleton<ChoreList>.Instance.AddToList(_currentChore);
				_currentChore.AddContext(_groupData.AssignedTable);
			}
		}

		public void RemoveOrder(CustomerOrder order)
		{
			Orders.Remove(order);
			if (Orders.Count <= 0)
			{
				order.CustomerRef.GroupData.ClearGroupOrder(order.GroupOrder);
				return;
			}
			switch (Status)
			{
			case CustomerOrder.EStatus.WaitingToOrder:
				foreach (CustomerOrder order2 in Orders)
				{
					if (order2.Status == CustomerOrder.EStatus.WaitingToOrder)
					{
						return;
					}
				}
				CreatePreparationChores();
				break;
			case CustomerOrder.EStatus.Ordered:
				foreach (CustomerOrder order3 in Orders)
				{
					if (order3.Status == CustomerOrder.EStatus.Ordered)
					{
						return;
					}
				}
				CreateDeliveryChores();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case CustomerOrder.EStatus.Prepared:
			case CustomerOrder.EStatus.Delivered:
				break;
			}
		}

		public bool IsOrderWaiting()
		{
			foreach (CustomerOrder order in Orders)
			{
				if (order.Status < CustomerOrder.EStatus.Ordered)
				{
					return true;
				}
			}
			return false;
		}

		public void CreatePreparationChores()
		{
			Status = CustomerOrder.EStatus.Ordered;
			if (Orders.Count <= 0)
			{
				return;
			}
			WorkerChoreGroupOrderPreparation workerChoreGroupOrderPreparation = (WorkerChoreGroupOrderPreparation)(_currentChore = new WorkerChoreGroupOrderPreparation(ChoreCategory.Drinks, this));
			workerChoreGroupOrderPreparation.AddContext(_groupData.AssignedTable);
			for (int num = Orders.Count - 1; num >= 0; num--)
			{
				CustomerOrder customerOrder = Orders[num];
				if (customerOrder.Status != CustomerOrder.EStatus.Prepared)
				{
					if (customerOrder.Status != CustomerOrder.EStatus.Ordered)
					{
						customerOrder.CustomerRef.ClearOrder();
					}
					else
					{
						WorkerChoreDrinkPreparation p_chore = (WorkerChoreDrinkPreparation)(customerOrder.Chore = new WorkerChoreDrinkPreparation(ChoreCategory.Drinks, customerOrder.CustomerRef, workerChoreGroupOrderPreparation));
						customerOrder.Chore.AddContext(customerOrder.CustomerRef);
						workerChoreGroupOrderPreparation.AddChore(p_chore);
					}
				}
			}
			MonoSingleton<ChoreList>.Instance.AddToList(workerChoreGroupOrderPreparation);
		}

		public void CreateDeliveryChores()
		{
			StationSlots.Clear();
			Status = CustomerOrder.EStatus.Prepared;
			if (Orders.Count <= 0)
			{
				return;
			}
			ChoreCategory choreCategory = (_groupData.Members[0].IsVampire ? ChoreCategory.ServiceVampire : ChoreCategory.Service);
			WorkerChorePlateDelivery workerChorePlateDelivery = new WorkerChorePlateDelivery(choreCategory, this);
			workerChorePlateDelivery.ChorePriority = 10;
			_currentChore = workerChorePlateDelivery;
			workerChorePlateDelivery.AddContext(_groupData.AssignedTable);
			foreach (CustomerOrder order in Orders)
			{
				if (order.Status != CustomerOrder.EStatus.Delivered)
				{
					_ = order.Status;
					_ = 2;
					WorkerChoreDrinkDelivery p_chore = (WorkerChoreDrinkDelivery)(order.Chore = new WorkerChoreDrinkDelivery(choreCategory, order, workerChorePlateDelivery));
					order.Chore.AddContext(order.CustomerRef);
					order.Chore.VisibleInActionList = false;
					workerChorePlateDelivery.AddChore(p_chore);
				}
			}
			MonoSingleton<ChoreList>.Instance.AddToList(workerChorePlateDelivery);
		}

		public void Destroy()
		{
			Destroyed = true;
			_currentChore?.DestroyChore();
		}
	}
}
