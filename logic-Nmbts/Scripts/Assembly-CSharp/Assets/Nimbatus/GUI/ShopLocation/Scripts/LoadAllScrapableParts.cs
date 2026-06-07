using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class LoadAllScrapableParts : MonoBehaviour
	{
		public UIGrid ItemGrid;

		public ScrapableItem ItemPrefab;

		public UIScrollView ItemPanel;

		public void Start()
		{
			FillUp();
		}

		public void FillUp()
		{
			List<Weapon> list = (from w in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.Weapon).OfType<Weapon>()
				where w.CurrentStackSize > 0
				select w).ToList();
			List<DroneData> drones = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones;
			ItemGrid.enabled = true;
			(from Transform child in ItemGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			foreach (Weapon item in (IEnumerable<Weapon>)list)
			{
				ScrapableItem scrapableItem = Object.Instantiate(ItemPrefab);
				scrapableItem.ShowInUseWarning = drones.Any((DroneData d) => d.GetNumberOfParts(item.UniqueId) > 0);
				scrapableItem.Init(ItemPanel, item);
				scrapableItem.transform.position = ItemGrid.transform.position;
				scrapableItem.transform.parent = ItemGrid.transform;
				scrapableItem.transform.localScale = ItemPrefab.transform.localScale;
			}
			ItemGrid.Reposition();
			ItemPanel.ResetPosition();
			ItemPanel.UpdateScrollbars(true);
		}
	}
}
