using System.Collections.Generic;
using System.Linq;
using DV.CashRegister;
using TMPro;
using UnityEngine;

namespace DV.Shops
{
	public class DebugCreateShopScanItems : MonoBehaviour
	{
		public ItemsConfig itemsConfig;

		public ScanItemCashRegisterModule scanItemPrefab;

		public float xOffset = -0.6f;

		public float yOffset = 0.3f;

		public int numHorizontal = 10;

		public GameObject enableAfterSpawn;

		private void Start()
		{
			CashRegisterWithModules componentInChildren = enableAfterSpawn.GetComponentInChildren<CashRegisterWithModules>(includeInactive: true);
			GlobalShopController component = enableAfterSpawn.GetComponent<GlobalShopController>();
			Shop component2 = enableAfterSpawn.GetComponent<Shop>();
			GameObject gameObject = new GameObject();
			gameObject.SetActive(value: false);
			List<ScanItemCashRegisterModule> list = new List<ScanItemCashRegisterModule>();
			for (int i = 0; i < itemsConfig.items.Count; i++)
			{
				InventoryItemSpec inventoryItemSpec = itemsConfig.items[i];
				if (!(inventoryItemSpec == null))
				{
					GameObject obj = Object.Instantiate(scanItemPrefab.gameObject, gameObject.transform);
					ScanItemCashRegisterModule component3 = obj.GetComponent<ScanItemCashRegisterModule>();
					list.Add(component3);
					component3.sellingItemSpec = inventoryItemSpec;
					float z = (float)(i % numHorizontal) * xOffset;
					float y = (float)(i / numHorizontal) * yOffset;
					obj.transform.position = base.transform.position + new Vector3(0f, y, z);
					obj.transform.Rotate(Vector3.up, 90f);
					obj.transform.SetParent(enableAfterSpawn.transform, worldPositionStays: true);
				}
			}
			Object.Destroy(gameObject);
			CashRegisterModule[] registerModules = list.ToArray();
			componentInChildren.registerModules = registerModules;
			component2.scanItemResourceModules = list.ToArray();
			component.shopItemsData = list.Select((ScanItemCashRegisterModule s) => new ShopItemData
			{
				item = s.sellingItemSpec,
				initialAmount = 1,
				allowedToHaveAmount = 1,
				basePrice = 1f
			}).ToList();
			enableAfterSpawn.SetActive(value: true);
			foreach (ScanItemCashRegisterModule item in list)
			{
				item.transform.Find("Texts/Description").GetComponent<TMP_Text>().text = item.descriptionText;
			}
		}
	}
}
