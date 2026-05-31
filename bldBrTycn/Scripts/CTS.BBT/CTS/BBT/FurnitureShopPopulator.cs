using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Furnitures;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class FurnitureShopPopulator : MonoSingleton<FurnitureShopPopulator>
	{
		[SerializeField]
		private UIFurnitureButton _furnitureButtonPrefab;

		[SerializeField]
		private bool _debug;

		[SerializeField]
		private Scrollbar _scrollbar;

		[SerializeField]
		private UI_SearchBar _searchBar;

		[SerializeField]
		private EFurnitureTags _tagExcluseFromStyleSelection;

		private readonly List<UIFurnitureButton> _uIFurnitureButtons = new List<UIFurnitureButton>();

		private EFurnitureTags _filters;

		private bool _useThemeFilter = true;

		private EBarStyle _styleFilters;

		private List<FurnitureSO> _disponibleFurnitures = new List<FurnitureSO>();

		public void Highlight(EFurnitureTags furnitureTags)
		{
			if (!CTSSingleton<Highlighter>.TryGetInstance(out var outInstance))
			{
				return;
			}
			foreach (UIFurnitureButton uIFurnitureButton in _uIFurnitureButtons)
			{
				if (uIFurnitureButton.AssignedFurniture.Tags.HasFlagNonAlloc(furnitureTags))
				{
					outInstance.Highlight((RectTransform)uIFurnitureButton.transform);
				}
			}
		}

		public void StopHighlight(EFurnitureTags furnitureTags)
		{
			if (!CTSSingleton<Highlighter>.TryGetInstance(out var outInstance))
			{
				return;
			}
			foreach (UIFurnitureButton uIFurnitureButton in _uIFurnitureButtons)
			{
				if (uIFurnitureButton.AssignedFurniture.Tags.HasFlagNonAlloc(furnitureTags))
				{
					outInstance.StopHighlight((RectTransform)uIFurnitureButton.transform);
				}
			}
		}

		private void Start()
		{
			foreach (FurnitureSO loadedFurniture in FurnitureLoader.LoadedFurnitures)
			{
				if (loadedFurniture.HasPrefab && ItemValidUnlocked(loadedFurniture))
				{
					_disponibleFurnitures.Add(loadedFurniture);
				}
			}
			PopulateFurnitures();
			ShowNotFilteredButtons();
			ReorderBy(E_OrderSort.ByTagAndStyle);
		}

		private void OnEnable()
		{
			FurnitureShop.FurnitureShopOpened += OnFurnitureShopOpened;
			FurniturePlacer.FurniturePickedUp += OnFurniturePickedUp;
			FurnitureController.StaticFurniturePlaced += OnFurniturePlaced;
			ThemeManager.OnStyleChanged += OnThemeStyleChanged;
			_styleFilters = MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle;
		}

		private void OnThemeStyleChanged(EBarStyle obj)
		{
			SetFilter(obj);
		}

		private void UnlockingManager_OnNewKeyAdded(EUnlockKey obj)
		{
			IncrementPopulateDay();
		}

		private void OnDisable()
		{
			FurnitureShop.FurnitureShopOpened -= OnFurnitureShopOpened;
			FurniturePlacer.FurniturePickedUp -= OnFurniturePickedUp;
			FurnitureController.StaticFurniturePlaced -= OnFurniturePlaced;
			ThemeManager.OnStyleChanged -= OnThemeStyleChanged;
		}

		private void OnFurnitureShopOpened()
		{
			SetFilter(MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle);
		}

		private void OnFurniturePlaced(FurnitureController obj)
		{
			foreach (UIFurnitureButton uIFurnitureButton in _uIFurnitureButtons)
			{
				if (uIFurnitureButton.isActiveAndEnabled)
				{
					uIFurnitureButton.RefreshData();
				}
			}
		}

		private void OnFurniturePickedUp(Furniture obj)
		{
			if ((bool)obj)
			{
				return;
			}
			foreach (UIFurnitureButton uIFurnitureButton in _uIFurnitureButtons)
			{
				if (uIFurnitureButton.isActiveAndEnabled)
				{
					uIFurnitureButton.RefreshData();
				}
			}
		}

		public void UseThemeFilter(bool value)
		{
			_useThemeFilter = value;
			ShowNotFilteredButtons();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestPopulateDay()
		{
			IncrementPopulateDay();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestPopulateDay5()
		{
			SetPopulateDay(5);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestResetPopulateDay()
		{
			ResetPopulateDay();
		}

		public static void SetPopulateDay(int _day)
		{
			MonoSingleton<FurnitureShopPopulator>.Instance?.ShowNotFilteredButtons();
			MonoSingleton<FurnitureShopPopulator>.Instance?.ReorderBy(E_OrderSort.ByTagAndStyle);
		}

		public static void ResetPopulateDay()
		{
			MonoSingleton<FurnitureShopPopulator>.Instance?.ShowNotFilteredButtons();
			MonoSingleton<FurnitureShopPopulator>.Instance?.ReorderBy(E_OrderSort.ByTagAndStyle);
		}

		public static void IncrementPopulateDay()
		{
			MonoSingleton<FurnitureShopPopulator>.Instance?.ShowNotFilteredButtons();
			MonoSingleton<FurnitureShopPopulator>.Instance?.ReorderBy(E_OrderSort.ByTagAndStyle);
		}

		private void PopulateFurnitures()
		{
			if (_disponibleFurnitures.Count == 0)
			{
				return;
			}
			foreach (FurnitureSO disponibleFurniture in _disponibleFurnitures)
			{
				if (disponibleFurniture.GetValidationState != AbsLockableItemSO.ELockState.Removed)
				{
					UIFurnitureButton uIFurnitureButton = CTSFactory.Instantiate(_furnitureButtonPrefab, base.transform, instantiateInWorldSpace: false, false);
					uIFurnitureButton.AssignFurniture(disponibleFurniture);
					uIFurnitureButton.gameObject.SetActive(value: true);
					_uIFurnitureButtons.Add(uIFurnitureButton);
				}
			}
		}

		public void ReorderBy(E_OrderSort sort)
		{
			for (int i = 0; i < _uIFurnitureButtons.Count; i++)
			{
				_uIFurnitureButtons[i].transform.SetParent(null);
			}
			List<UIFurnitureButton> list = sort switch
			{
				E_OrderSort.ByPrice => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.PurchasePrice).ToList(), 
				E_OrderSort.ByName => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.Name).ToList(), 
				E_OrderSort.ByTag => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.OrderByTag()).ToList(), 
				E_OrderSort.ByStyle => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.OrderByStyle()).ToList(), 
				E_OrderSort.ByTagAndStyle => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.OrderByTagAndStyle()).ToList(), 
				_ => _uIFurnitureButtons.OrderBy((UIFurnitureButton x) => x.AssignedFurniture.name).ToList(), 
			};
			_uIFurnitureButtons.Clear();
			_uIFurnitureButtons.AddRange(list);
			for (int num = 0; num < list.Count; num++)
			{
				_uIFurnitureButtons[num].transform.SetParent(base.transform);
			}
		}

		private void ShowNotFilteredButtons()
		{
			foreach (UIFurnitureButton uIFurnitureButton in _uIFurnitureButtons)
			{
				bool flag = uIFurnitureButton.AssignedFurniture.ContainsKey(UnlockingManager.UnlockKey) && _filters.HasFlagNonAlloc(uIFurnitureButton.AssignedFurniture.Tags) && IsValidStyle(uIFurnitureButton.AssignedFurniture);
				uIFurnitureButton.gameObject.SetActive(flag);
				if (flag)
				{
					uIFurnitureButton.RefreshData();
				}
			}
			_scrollbar.value = 1f;
			bool IsValidStyle(FurnitureSO furniture)
			{
				if (!_useThemeFilter)
				{
					return true;
				}
				if (_styleFilters == EBarStyle.None)
				{
					return true;
				}
				if (_tagExcluseFromStyleSelection.HasFlagNonAlloc(furniture.Tags))
				{
					return true;
				}
				return _styleFilters == furniture.Style;
			}
		}

		public void SearchBarFilter()
		{
			ShowNotFilteredButtons();
		}

		public void ToggleFilter(EFurnitureTags p_tag)
		{
			_filters ^= p_tag;
			ShowNotFilteredButtons();
		}

		public void AddFilter(EFurnitureTags p_tag)
		{
			_filters |= p_tag;
			ShowNotFilteredButtons();
		}

		public void RemoveFilter(EFurnitureTags p_tag)
		{
			_filters &= ~p_tag;
			ShowNotFilteredButtons();
		}

		public void SetFilter(EFurnitureTags p_tag)
		{
			_filters = p_tag;
			ShowNotFilteredButtons();
		}

		public void SetFilter(EBarStyle p_tag)
		{
			_styleFilters = p_tag;
			ShowNotFilteredButtons();
		}

		private bool ItemValidUnlocked(FurnitureSO p_item)
		{
			return p_item.GetValidationState != AbsLockableItemSO.ELockState.Removed;
		}

		protected override void SingletonAwake()
		{
			UnlockingManager.OnNewKeyAdded += UnlockingManager_OnNewKeyAdded;
		}

		protected override void OnSingletonDestroy()
		{
			UnlockingManager.OnNewKeyAdded -= UnlockingManager_OnNewKeyAdded;
		}
	}
}
