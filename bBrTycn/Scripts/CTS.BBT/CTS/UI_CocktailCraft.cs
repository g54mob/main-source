using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_CocktailCraft : MonoSingleton<UI_CocktailCraft>
	{
		[SerializeField]
		private UI_IngredientItem _prefab;

		[SerializeField]
		private Transform _content;

		[SerializeField]
		private FilterButton _filterButtonPrefab;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private SerializableDictionary<string, int> _categoriesToggles;

		private int _currentPage;

		[field: SerializeField]
		public Sprite FreeSlotSprite { get; private set; }

		[field: SerializeField]
		public Sprite usedSlotSprite { get; private set; }

		[field: SerializeField]
		public Sprite LockedSlotSprite { get; private set; }

		private void Start()
		{
			CreateCategory();
			PopulateStorageItem();
		}

		private void OnEnable()
		{
			MonoSingleton<CocktailVisualSpawner>.Instance.SetCamera();
		}

		private void PopulateStorageItem()
		{
			foreach (string key in StorageManager.StockItems.Keys)
			{
				UnityEngine.Object.Instantiate(_prefab, _content).SetItemData(StorageManager.StockItems[key]);
			}
		}

		private void CreateCategory()
		{
			List<FilterButton> list = new List<FilterButton>();
			foreach (string key in _categoriesToggles.Keys)
			{
				FilterButton filterButton = UnityEngine.Object.Instantiate(_filterButtonPrefab, _toggleGroup.transform);
				filterButton.SetButtoninfo(null, key, _categoriesToggles[key]);
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
			if (p_toogled)
			{
				_currentPage = _tags;
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
