using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UniversalInventorySystem
{
	[Serializable]
	[AddComponentMenu("UniversalInventorySystem/Item")]
	[CreateAssetMenu(fileName = "Item", menuName = "UniversalInventorySystem/Item", order = 1)]
	public class Item : ScriptableObject
	{
		[Inject]
		private InventoryHandler inventoryHandler;

		public string itemName;

		public int id;

		public Sprite sprite;

		public int maxAmount;

		public bool destroyOnUse;

		public int useHowManyWhenUsed;

		public bool stackable;

		public int maxDurability;

		public bool hasDurability;

		public bool showAmount;

		[SerializeField]
		private List<DurabilityImage> _durabilityImages;

		public ToolTipInfo tooltip;

		public List<DurabilityImage> durabilityImages
		{
			get
			{
				return _durabilityImages;
			}
			set
			{
				_durabilityImages = SortDurabilityImages(value);
			}
		}

		public void OnEnable()
		{
			_durabilityImages = SortDurabilityImages(_durabilityImages);
		}

		public void OnUse(Inventory inv, int slot)
		{
		}

		public void OnDrop(Inventory inv, bool tss, int slot, int amount, bool dbui, Vector3? pos)
		{
		}

		public static List<DurabilityImage> SortDurabilityImages(List<DurabilityImage> inputArray)
		{
			if (inputArray == null)
			{
				return inputArray;
			}
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].durability > inputArray[num].durability)
					{
						checked
						{
							int durability = inputArray[num - 1].durability;
							inputArray[num - 1].durability = inputArray[num].durability;
							inputArray[num].durability = durability;
						}
					}
				}
			}
			return inputArray;
		}
	}
}
