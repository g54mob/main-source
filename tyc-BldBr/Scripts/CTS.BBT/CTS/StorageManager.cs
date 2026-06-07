using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[Obsolete]
	public class StorageManager : MonoBehaviour
	{
		[Serializable]
		private struct Category
		{
			public string _name;
		}

		[Serializable]
		private struct Order
		{
			public Sprite _icon;

			public E_OrderSort _category;

			public FilterElement ConvertToFilterElement()
			{
				return new FilterElement
				{
					_icon = _icon,
					_tags = (int)_category
				};
			}

			public static FilterElement[] ConvertToElements(Order[] p_orders)
			{
				FilterElement[] array = new FilterElement[p_orders.Length];
				for (int i = 0; i < p_orders.Length; i++)
				{
					array[i] = p_orders[i].ConvertToFilterElement();
				}
				return array;
			}
		}

		private static Dictionary<string, StockItemSO> _stockItems;

		[SerializeField]
		private Transform _content;

		[SerializeField]
		private FilterButton _filterButtonPrefab;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private Category[] _categoriesToggles;

		public static Dictionary<string, StockItemSO> StockItems
		{
			get
			{
				if (_stockItems == null)
				{
					_stockItems = new Dictionary<string, StockItemSO>();
					StockItemSO[] array = Resources.LoadAll<StockItemSO>("Scriptables\\Stockables");
					for (int i = 0; i < array.Length; i++)
					{
						_stockItems.Add(array[i].name, array[i]);
					}
				}
				return _stockItems;
			}
		}

		private void Start()
		{
			CreateCategory();
		}

		private void CreateCategory()
		{
			List<FilterButton> list = new List<FilterButton>();
			for (int i = 0; i < _categoriesToggles.Length; i++)
			{
				FilterButton filterButton = UnityEngine.Object.Instantiate(_filterButtonPrefab, _toggleGroup.transform);
				filterButton.SetButtoninfo(null, _categoriesToggles[i]._name, 0);
				filterButton.OnToggleChanged = (Action<bool, int>)Delegate.Combine(filterButton.OnToggleChanged, new Action<bool, int>(SetFilter));
				filterButton.SetToggleGroup(_toggleGroup);
				list.Add(filterButton);
			}
			if (list.Count > 0)
			{
				list[0].SetToggled(toggled: true);
			}
		}

		private void SetFilter(bool p_toogled, int _tags)
		{
		}
	}
}
