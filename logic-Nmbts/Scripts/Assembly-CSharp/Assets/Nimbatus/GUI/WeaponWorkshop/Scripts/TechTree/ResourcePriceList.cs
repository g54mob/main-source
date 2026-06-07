using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class ResourcePriceList : SerializedMonoBehaviour
	{
		public ResourcePriceItem ItemPrefab;

		public UIGrid Grid;

		public void Fill(IBuyable item)
		{
			Dictionary<ETerrainMaterial, int> price = item.GetPrice();
			Fill(price);
		}

		public void Fill(Dictionary<ETerrainMaterial, int> priceList)
		{
			(from Transform child in Grid.transform
				select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			foreach (KeyValuePair<ETerrainMaterial, int> price in priceList)
			{
				int value = price.Value;
				ETerrainMaterial key = price.Key;
				if (value > 0)
				{
					ResourcePriceItem resourcePriceItem = Object.Instantiate(ItemPrefab);
					resourcePriceItem.Init(key, value);
					resourcePriceItem.transform.position = Grid.transform.position;
					resourcePriceItem.transform.parent = Grid.transform;
					resourcePriceItem.transform.localScale = Grid.transform.localScale;
				}
			}
			Grid.Reposition();
			Grid.enabled = false;
		}
	}
}
