using System.Collections;
using DV.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace DV.Shops
{
	public class ShopShelves : MonoBehaviour
	{
		public ShopShelvesVerifiedSeeds seeds;

		public ShelfPlacer[] shelves;

		private IEnumerator Start()
		{
			yield return null;
			float num = float.MaxValue;
			Shop shop = null;
			foreach (Shop globalShop in SingletonBehaviour<GlobalShopController>.Instance.globalShopList)
			{
				float num2 = Vector3.SqrMagnitude(globalShop.transform.position - base.transform.position);
				if (num2 < num)
				{
					num = num2;
					shop = globalShop;
				}
			}
			Unity.Mathematics.Random random = seeds.GetRandom();
			if (!(shop == null))
			{
				SpawnShopItems(shop, random);
			}
		}

		public bool SpawnShopItems(Shop shop, Unity.Mathematics.Random random)
		{
			ScanItemCashRegisterModule[] scanItemResourceModules = shop.scanItemResourceModules;
			foreach (ScanItemCashRegisterModule scanItemCashRegisterModule in scanItemResourceModules)
			{
				int num = random.NextInt(0, shelves.Length);
				bool flag = false;
				for (int j = 0; j < shelves.Length; j++)
				{
					if (shelves[(j + num) % shelves.Length].TryPlaceOnAnyShelf(scanItemCashRegisterModule.GetComponent<ShelfItem>(), random))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Debug.LogError("Did not manage to place the shelf item on any shelves!", scanItemCashRegisterModule.gameObject);
					return false;
				}
			}
			return true;
		}
	}
}
