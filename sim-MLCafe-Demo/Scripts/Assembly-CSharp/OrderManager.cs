using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OrderManager : MonoBehaviour, IDataPersistence
{
	private List<PlacedOrder> orders = new List<PlacedOrder>();

	public static UnityEvent OnOrderChangeEvent = new UnityEvent();

	public static UnityEvent<PlacedOrder, GameTime> OnPlaceOrderEvent = new UnityEvent<PlacedOrder, GameTime>();

	private static OrderManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	public static List<PlacedOrder> GetCurrentOrders()
	{
		return instance.orders;
	}

	public static bool HasOrders()
	{
		return instance.orders.Count > 0;
	}

	public static bool PlacedOrder(List<CartItem> items, int totalPrice, int packages)
	{
		if (totalPrice > WalletSystem.GetPlayerWallet().GetBudgetIncludingOverdraw())
		{
			Debug.LogError("NOT ENOUGH MONEY, YOU GET INTO DEPT");
			return false;
		}
		WalletSystem.GetPlayerWallet().ForceRemoveAmount(totalPrice);
		int[] ids = items.Select((CartItem x) => x.itemId).ToArray();
		int[] amounts = items.Select((CartItem x) => x.amount).ToArray();
		PlacedOrder placedOrder = new PlacedOrder(ids, amounts, totalPrice, packages);
		instance.orders.Add(placedOrder);
		DeliverSystem.InitDeliveryTimeEvent(WorldTime.GetGlobalTime(), placedOrder);
		OnOrderChangeEvent.Invoke();
		OnPlaceOrderEvent.Invoke(placedOrder, WorldTime.GetGlobalTime());
		if (!TutorialManager.IsRunning() && !PopupMessageManager.GetCheckListPopUp().IsVisible())
		{
			return true;
		}
		for (int num = 0; num < items.Count; num++)
		{
			if (items[num].itemId == 25 && items[num].amount >= 4)
			{
				TutorialManager.TryCheckSectionChecklistOption("OrderTinyCups", TutorialManager.TutorialState.RunCafe);
			}
			if (items[num].itemId == 16 && items[num].amount >= 4)
			{
				TutorialManager.TryCheckSectionChecklistOption("OrderSmallCups", TutorialManager.TutorialState.RunCafe);
			}
			if (items[num].itemId == 43 && items[num].amount >= 1)
			{
				TutorialManager.TryCheckSectionChecklistOption("OrderCoffeeFilter", TutorialManager.TutorialState.RunCafe);
			}
		}
		return true;
	}

	public static void RemoveOrder(PlacedOrder order)
	{
		if (order == null || !instance.orders.Contains(order))
		{
			return;
		}
		instance.orders.Remove(order);
		if (instance.orders.Any((PlacedOrder x) => x == null))
		{
			instance.orders.RemoveAll((PlacedOrder x) => x == null);
		}
	}

	public static void ClearOrders()
	{
		instance.orders.Clear();
		OnOrderChangeEvent.Invoke();
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
		orders = data.placedOrders;
		foreach (PlacedOrder order in orders)
		{
			DeliverSystem.InitDeliveryTimeEvent(DeliverSystem.GetNextDayDeliveryTime(), order);
		}
	}

	public void SaveData(ref GameData data)
	{
		data.placedOrders = orders;
	}
}
