using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class FoodWindow : Prop
	{
		public static HashSet<FoodWindow> AllFoodWindows;

		public List<Transform> OverHeadTicketSlots;

		public List<Transform> CounterTicketSlots;

		public List<Transform> CounterDishSlots;

		private static readonly int Swing;

		public int FreeSlots => 0;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<FoodOrder> FoodOrders { get; set; }

		public event EventHandler FoodOrdersChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Start()
		{
		}

		private void CheckIfThereIsAServerForFoodOrders(object sender, EventArgs e)
		{
		}

		private void CheckIfThereIsAServerForFoodOrders()
		{
		}

		public override void OnDestroy()
		{
		}

		public override void Awake()
		{
		}

		public int GetPositionInOrderWindow(FoodOrder foodOrder)
		{
			return 0;
		}

		public void AddFoodOrder(FoodOrder foodOrder)
		{
		}

		public void AddDish(FoodOrder foodOrder, GameItem dish)
		{
		}

		internal void SetToPreparation(FoodOrder foodOrder)
		{
		}

		public bool IsServingFoodOrder(FoodOrder foodOrder)
		{
			return false;
		}

		public GameItem GetDish(FoodOrder foodOrder)
		{
			return null;
		}

		public GameItem GetAndRemoveDish(FoodOrder foodOrder)
		{
			return null;
		}

		private GameItem RemoveDishForOrder(FoodOrder order)
		{
			return null;
		}

		public void RemoveFoodOrder(FoodOrder foodOrder)
		{
		}

		private void UpdateFoodOrderErrorMessage()
		{
		}

		protected override void Dying()
		{
		}

		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		public override void PostBuiltInit()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
