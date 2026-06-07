using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class Trader : MapObject, ISavable
{
	[Serializable]
	public struct FDiscountInfo
	{
		public int startCycle;

		public int maxTier;

		public int purchaseDiscountsAmount;

		public int saleDiscountsAmount;
	}

	[SerializeField]
	[Savable("traderElements", true, false)]
	private List<TraderElement> traderElements;

	[SerializeField]
	private FDiscountInfo[] discountInfos;

	[Savable("tokens", true, false)]
	private int tokens;

	[Savable("savedCycle", true, false)]
	private int savedCycle = -1;

	private TraderElement lastSelectedElement;

	private int lastSelectedAmount;

	public List<TraderElement> TraderElements => traderElements;

	public int Tokens
	{
		get
		{
			return tokens;
		}
		set
		{
			tokens = Mathf.Max(0, value);
			this.OnTokensChanged?.Invoke(tokens);
		}
	}

	public TraderElement LastSelectedElement
	{
		get
		{
			return lastSelectedElement;
		}
		set
		{
			lastSelectedElement = value;
		}
	}

	public int LastSelectedAmount
	{
		get
		{
			return lastSelectedAmount;
		}
		set
		{
			lastSelectedAmount = value;
		}
	}

	public event Action<int> OnTokensChanged;

	protected override void Awake()
	{
		base.Awake();
		lastSelectedElement = null;
		lastSelectedAmount = 1;
	}

	protected override void Start()
	{
		base.Start();
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			OnGameStarted();
			return;
		}
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void OnGameStarted()
	{
		SetupTraderElements();
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		OnCycleChanged(cyclesManager.CurrentCycle, cyclesManager.CurrentCycleMode);
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void SetupTraderElements()
	{
		for (int num = traderElements.Count - 1; num >= 0; num--)
		{
			traderElements[num].Trader = this;
		}
	}

	public void BuyTraderElement(TraderElement traderElement, int amount)
	{
		int num = Mathf.Min(amount, Tokens / traderElement.BuyPrice);
		if (num <= 0)
		{
			string localizedString = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_message_purchase_error").GetLocalizedString();
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error);
			return;
		}
		ResourceData resourceData = traderElement.ResourceData;
		LTFunctionLibrary.GetPlayerInventory().StoreObject(resourceData, num, Storage_ResourceData.EStoreSource.Trade);
		int num2 = traderElement.BuyPrice * num;
		Tokens -= num2;
		traderElement.UpdateDemand(num);
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "amount", num },
			{
				"resource",
				traderElement.ResourceData.DisplayName
			},
			{ "tokens", num2 }
		};
		string localizedString2 = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_message_purchase").GetLocalizedString(dictionary);
		LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString2, ENotificationType.Money);
	}

	public void SellTraderElement(TraderElement traderElement, int amount)
	{
		ResourceData resourceData = traderElement.ResourceData;
		int num = LTFunctionLibrary.GetPlayerInventory().RemoveStoredObjectByID(resourceData.Id, amount);
		if (num <= 0)
		{
			string localizedString = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_message_sale_error").GetLocalizedString();
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString, ENotificationType.Error);
			return;
		}
		int num2 = traderElement.SellPrice * num;
		Tokens += num2;
		traderElement.UpdateDemand(-num);
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "amount", num },
			{
				"resource",
				traderElement.ResourceData.DisplayName
			},
			{ "tokens", num2 }
		};
		string localizedString2 = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_message_sale").GetLocalizedString(dictionary);
		LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowNotification(localizedString2, ENotificationType.Money);
	}

	private void UpdateDiscounts(int cycle)
	{
		FDiscountInfo auxDiscountInfo = default(FDiscountInfo);
		auxDiscountInfo.startCycle = 0;
		FDiscountInfo[] array = discountInfos;
		for (int i = 0; i < array.Length; i++)
		{
			FDiscountInfo fDiscountInfo = array[i];
			if (fDiscountInfo.startCycle <= cycle && fDiscountInfo.startCycle >= auxDiscountInfo.startCycle)
			{
				auxDiscountInfo = fDiscountInfo;
			}
		}
		List<TraderElement> list = TraderElements.FindAll((TraderElement x) => x.Tier <= auxDiscountInfo.maxTier);
		list.Shuffle();
		int num = 0;
		for (int num2 = 0; num2 < auxDiscountInfo.purchaseDiscountsAmount; num2++)
		{
			list[num].HasPurchaseDiscount = true;
			num++;
		}
		for (int num3 = 0; num3 < auxDiscountInfo.saleDiscountsAmount; num3++)
		{
			list[num].HasSaleDiscount = true;
			num++;
		}
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		if (savedCycle == cycle || mode != ECycleMode.Neutral)
		{
			return;
		}
		foreach (TraderElement traderElement in traderElements)
		{
			traderElement.RebalanceDemand();
			traderElement.HasPurchaseDiscount = false;
			traderElement.HasSaleDiscount = false;
		}
		UpdateDiscounts(cycle);
	}

	public void OnSave()
	{
		savedCycle = LTFunctionLibrary.GetCyclesManager().CurrentCycle;
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
