using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class MarketStore : WorldManager
	{
		private Dictionary<int, List<BaseShopBoxData>> m_marketStoreDatas;

		private List<UI_MarketStore> m_marketStoreInterfaces = new List<UI_MarketStore>();

		[Header("Tutorial")]
		[SerializeField]
		private TutorialData m_sellTutorialData;

		public bool Initialized => m_marketStoreDatas != null;

		public TutorialData SellTutorialData => m_sellTutorialData;

		public static event Action<float> BoughtLicense;

		public static event Action<float> BoughtBoxes;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
				FetchMarketStoreDatas();
				break;
			case EWorldEvent.START:
				InitAllMarketStoreInterfacesDatas();
				break;
			}
		}

		public void Register(UI_MarketStore marketStoreInterface)
		{
			m_marketStoreInterfaces.Add(marketStoreInterface);
			if (World.HasExecuted(EWorldEvent.START))
			{
				InitMarketStoreInterfaceDatas(marketStoreInterface);
			}
		}

		public void Unregister(UI_MarketStore marketStoreInterface)
		{
			m_marketStoreInterfaces.Remove(marketStoreInterface);
		}

		protected virtual void FetchMarketStoreDatas()
		{
			m_marketStoreDatas = new Dictionary<int, List<BaseShopBoxData>>();
			foreach (BaseShopBoxData item in MarketStoreDatabase.Enumerate())
			{
				if (item.Sellable)
				{
					if (m_marketStoreDatas.TryGetValue(item.Type, out var value))
					{
						value.Add(item);
						continue;
					}
					List<BaseShopBoxData> value2 = new List<BaseShopBoxData> { item };
					m_marketStoreDatas[item.Type] = value2;
				}
			}
		}

		protected virtual void InitAllMarketStoreInterfacesDatas()
		{
			foreach (UI_MarketStore marketStoreInterface in m_marketStoreInterfaces)
			{
				InitMarketStoreInterfaceDatas(marketStoreInterface);
			}
		}

		protected virtual void InitMarketStoreInterfaceDatas(UI_MarketStore marketStoreInterface)
		{
			marketStoreInterface.Init();
		}

		public virtual IEnumerable<KeyValuePair<int, List<BaseShopBoxData>>> GetMarketStoreDatas()
		{
			foreach (var (key, collection) in m_marketStoreDatas)
			{
				yield return new KeyValuePair<int, List<BaseShopBoxData>>(key, new List<BaseShopBoxData>(collection));
			}
		}

		public virtual void BuyLicense(BaseShopBoxData data)
		{
			if (!MarketStoreSettings.EverythingFree)
			{
				World.GameState.ConsumeMoney(data.LicensePrice);
			}
			PriceManager.UnlockLicense(data.UID);
			MarketStore.BoughtLicense?.Invoke(data.LicensePrice);
		}

		public virtual bool Checkout(Dictionary<BaseShopBoxData, int> cart)
		{
			float num = 0f;
			int num2 = 0;
			BaseShopBoxData key;
			int value;
			foreach (KeyValuePair<BaseShopBoxData, int> item in cart)
			{
				item.Deconstruct(out key, out value);
				BaseShopBoxData data = key;
				int num3 = value;
				num += GetDataPrice(data) * (float)num3;
				num2 += num3;
			}
			float num4 = num + MarketStoreSettings.ComputeDeliveryFees(num2);
			if (MarketStoreSettings.EverythingFree || World.GameState.ConsumeMoney(num4))
			{
				foreach (KeyValuePair<BaseShopBoxData, int> item2 in cart)
				{
					item2.Deconstruct(out key, out value);
					BaseShopBoxData data2 = key;
					int quantity = value;
					World.DeliverySystem.Deliver(data2, quantity);
				}
				World.GameState.TriggerXPRewardEvent(ESimulatorXPRewardEvent.BUY_OBJECT, num2);
				World.ScoreManager.GainReward(ESimulatorXPRewardEvent.BUY_OBJECT, num2);
				MarketStore.BoughtBoxes?.Invoke(num4);
				if (SaveSettings.AutoSaveOnCheckout)
				{
					SaveManager.AutoSaveAfterClassicUpdate();
				}
				GameAnalytics.NewOrAddDesignEvent("id_analytics_deliver", 1f);
				GameAnalytics.NewOrAddDesignEvent("id_analytics_marketbuy", num2);
				return true;
			}
			return false;
		}

		public virtual float GetDataPrice(BaseShopBoxData data)
		{
			if (data is ExtensionShopBoxData extensionShopBoxData)
			{
				if (extensionShopBoxData.ShopExtension)
				{
					return ShopExtensionSettings.GetCurrentShopExtensionPrice();
				}
				if (extensionShopBoxData.ReserveExtension)
				{
					return ShopExtensionSettings.GetCurrentReserveExtensionPrice();
				}
			}
			return data.Price;
		}

		public static bool IsDataAvailable(BaseShopBoxData data)
		{
			if (data is ExtensionShopBoxData extensionShopBoxData)
			{
				if (extensionShopBoxData.ShopExtension)
				{
					return ShopExtensionSettings.CanExtendShop();
				}
				if (extensionShopBoxData.ReserveExtension)
				{
					return ShopExtensionSettings.CanExtendReserve();
				}
			}
			return true;
		}

		public static bool IsDataLocked(BaseShopBoxData data)
		{
			if (!data.LockedByDefault || MarketStoreSettings.UnlockAll)
			{
				return false;
			}
			if (data is ExtensionShopBoxData || !MarketStoreSettings.NeedToPayLicenses)
			{
				return GameState.ShopLevel < GetRequiredShopLevel(data);
			}
			return !PriceManager.IsLicenseUnlocked(data.UID);
		}

		public static int GetRequiredShopLevel(BaseShopBoxData data)
		{
			if (data is ExtensionShopBoxData extensionShopBoxData)
			{
				if (extensionShopBoxData.ShopExtension)
				{
					return ShopExtensionSettings.GetCurrentShopExtensionShopLevel();
				}
				if (extensionShopBoxData.ReserveExtension)
				{
					return ShopExtensionSettings.GetCurrentReserveExtensionShopLevel();
				}
			}
			return data.RequiredShopLevel;
		}
	}
}
