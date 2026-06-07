using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Procedural
{
	[Serializable]
	public class TaggedItemPropertiesRandomizer
	{
		public enum Modes
		{
			Random = 0,
			RandomFromCachedList = 1
		}

		[SerializeField]
		private Modes _mode;

		[SerializeField]
		private Item.Tags _tag = Item.Tags.Food;

		[SerializeField]
		private ItemProperties[] _itemsToExclude;

		[SerializeField]
		[Tooltip("The amount of times the items are added to the cached list.")]
		[ConditionalEnumHide("_mode", 1, false, HideInInspector = true)]
		private int _cachedListRefillCount = 1;

		private List<ItemProperties> _itemPropertiesToRandomize;

		private List<ItemProperties> _itemPropertiesToDistribute;

		public void Initialize()
		{
			_itemPropertiesToRandomize = new List<ItemProperties>();
			foreach (ItemProperties item in GameManager.Settings.ItemSettings.ReturnItemPropertiesWithTag(_tag))
			{
				if (!_itemsToExclude.Contains(item))
				{
					_itemPropertiesToRandomize.Add(item);
				}
			}
			if (_mode == Modes.RandomFromCachedList)
			{
				if (_itemPropertiesToDistribute == null)
				{
					_itemPropertiesToDistribute = new List<ItemProperties>();
				}
				else
				{
					_itemPropertiesToDistribute.Clear();
				}
			}
		}

		public ItemProperties GetRandom()
		{
			switch (_mode)
			{
			case Modes.Random:
				return _itemPropertiesToRandomize[UnityEngine.Random.Range(0, _itemPropertiesToRandomize.Count)];
			case Modes.RandomFromCachedList:
				if (_itemPropertiesToDistribute.Count == 0)
				{
					_cachedListRefillCount = Mathf.Max(1, _cachedListRefillCount);
					for (int i = 0; i < _cachedListRefillCount; i++)
					{
						_itemPropertiesToDistribute.AddRange(_itemPropertiesToRandomize);
					}
				}
				while (0 < _itemPropertiesToDistribute.Count)
				{
					int index = UnityEngine.Random.Range(0, _itemPropertiesToDistribute.Count);
					ItemProperties itemProperties = _itemPropertiesToDistribute[index];
					_itemPropertiesToDistribute.RemoveAt(index);
					if (!(itemProperties == null))
					{
						return itemProperties;
					}
				}
				Debug.LogException(new Exception("Unable to return random item. It seems like there are some null references in the item list"));
				return null;
			default:
				Debug.LogException(new NotImplementedException());
				return null;
			}
		}
	}
}
