using System;
using System.Collections.Generic;
using Restory.Data.Licenses;
using Restory.UI.Presenters.Shops.Elements;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Elements
{
	public class GUI_LicenseShopElementCustomPool : IDisposable
	{
		private readonly DiContainer diContainer;

		private readonly Dictionary<LicenseInfo, GUI_LicenseShopItem> pool = new Dictionary<LicenseInfo, GUI_LicenseShopItem>();

		private bool isDisposed;

		[Inject]
		public GUI_LicenseShopElementCustomPool(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public GUI_LicenseShopItem GetItem(LicenseInfo licenseInfo)
		{
			if (pool.TryGetValue(licenseInfo, out var value) && (bool)value)
			{
				value.transform.localScale = Vector3.one;
				value.gameObject.SetActive(value: true);
				return value;
			}
			value = diContainer.InstantiatePrefabForComponent<GUI_LicenseShopItem>(licenseInfo.ShopItemPrefab.gameObject);
			pool[licenseInfo] = value;
			return value;
		}

		public void Release(GUI_LicenseShopItem licenseShopItem)
		{
			if ((bool)licenseShopItem)
			{
				licenseShopItem.gameObject.SetActive(value: false);
				if (!isDisposed && !pool.ContainsKey(licenseShopItem.Item.License))
				{
					Debug.LogError("pool not contains licenseShopItem for release");
				}
			}
		}

		public void ReleaseAll()
		{
			foreach (GUI_LicenseShopItem value in pool.Values)
			{
				if ((bool)value)
				{
					value.gameObject.SetActive(value: false);
				}
			}
		}

		public void Dispose()
		{
			isDisposed = true;
			pool.Clear();
		}
	}
}
