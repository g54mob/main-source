using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Research;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ConstructionPanelView : UIView, IObserver
	{
		[SerializeField]
		private LayoutGroupView constructionCategoryGroup;

		[SerializeField]
		private ConstructionPanelManager constructionManager;

		private BuildButtonLayoutItemView selected;

		private RectTransform rectTransform;

		private BuildButtonLayoutItemView noneGroup;

		private readonly List<BuildButtonLayoutItemView> baseCategoryButtons = new List<BuildButtonLayoutItemView>();

		private Dictionary<BuildingCategoryUI, BuildButtonLayoutItemView> dictionary = new Dictionary<BuildingCategoryUI, BuildButtonLayoutItemView>();

		public BuildingCategoryUI CurrentCategory => constructionManager.CurrentCategory;

		public ConstructionPanelManager ConstructionManager => constructionManager;

		public event Action<BuildingCategoryUI> ShowCategoryEvent;

		public event Action ClosePanelEvent;

		public void OpenPanelAndHighlight(BuildingCategoryUI category, IEnumerable<string> subcategories)
		{
			if (category == CurrentCategory)
			{
				constructionManager.HighlightSubcategories(category, subcategories);
				return;
			}
			constructionManager.OpenPanel(category, subcategories);
			HandleSelection(dictionary[category]);
		}

		private void CreateCategoryButtons()
		{
			foreach (BuildingCategoryUI category in GetExistingCategories())
			{
				if (category.Equals(BuildingCategoryUI.None))
				{
					continue;
				}
				BuildButtonLayoutItemView groupItem = UnityEngine.Object.Instantiate(constructionCategoryGroup.Prefab, constructionCategoryGroup.gameObject.transform) as BuildButtonLayoutItemView;
				KeyInputEvent keyInputEvent = (KeyInputEvent)Enum.Parse(typeof(KeyInputEvent), category.ToString());
				if (category != BuildingCategoryUI.None)
				{
					MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(keyInputEvent, delegate
					{
						ShowPanel(category, groupItem);
					});
				}
				string text = category.ToString();
				string id = text[0].ToString().ToUpper() + text.Substring(1);
				if ((object)groupItem != null)
				{
					groupItem.SetButtonData(id, category.ToString().ToLower(), MonoSingleton<LocalizationController>.Instance.GetText("menu_" + category.ToString().ToLower()), MonoSingleton<GlobalSaveController>.Instance.GetKeyCode(keyInputEvent).ToString());
					if (groupItem.TooltipNew is ButtonKeyCommandTooltipViewNew buttonKeyCommandTooltipViewNew)
					{
						buttonKeyCommandTooltipViewNew.Init(string.Empty, keyInputEvent);
					}
					groupItem.Button.onClick.AddListener(delegate
					{
						ShowPanel(category, groupItem);
					});
					baseCategoryButtons.Add(groupItem);
					if (!dictionary.ContainsKey(category))
					{
						dictionary.Add(category, groupItem);
					}
					if (ShouldHide(category))
					{
						groupItem.gameObject.SetActive(value: false);
					}
				}
			}
			constructionManager.Initialize();
			LayoutRebuilder.ForceRebuildLayoutImmediate(constructionCategoryGroup.gameObject.GetComponent<RectTransform>());
		}

		private bool ShouldHide(BuildingCategoryUI category)
		{
			if (Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems().Any((BaseBuildingBlueprint item) => item.BuildingCategoryUI.Equals(category) && MonoSingleton<ResearchManager>.Instance.UnlockedByDefault(item.GetID())))
			{
				return false;
			}
			if (Repository<StockpileRepository, Stockpile>.Instance.GetAllItems().Any((Stockpile item) => item.BuildingCategoryUI.Equals(category) && MonoSingleton<ResearchManager>.Instance.UnlockedByDefault(item.GetID())))
			{
				return false;
			}
			if (Repository<CropfieldRepository, Cropfield>.Instance.GetAllItems().Any((Cropfield item) => item.BuildingCategoryUI.Equals(category) && MonoSingleton<ResearchManager>.Instance.UnlockedByDefault(item.GetID())))
			{
				return false;
			}
			return true;
		}

		private List<BuildingCategoryUI> GetExistingCategories()
		{
			HashSet<BuildingCategoryUI> hashSet = new HashSet<BuildingCategoryUI>();
			BuildingCategoryUI[] buildingCategoryUI = EnumValues.BuildingCategoryUI;
			for (int i = 0; i < buildingCategoryUI.Length; i++)
			{
				BuildingCategoryUI category = buildingCategoryUI[i];
				if (!category.Equals(BuildingCategoryUI.None))
				{
					KeyValuePair<BuildingCategoryUI, List<string>> keyValuePair = new KeyValuePair<BuildingCategoryUI, List<string>>(category, new List<string>());
					if (Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems().Any((BaseBuildingBlueprint item) => item.BuildingCategoryUI == category))
					{
						hashSet.Add(keyValuePair.Key);
					}
					if (category.Equals(BuildingCategoryUI.Zone))
					{
						hashSet.Add(category);
					}
				}
			}
			return hashSet.ToList();
		}

		private void ShowPanel(BuildingCategoryUI category, BuildButtonLayoutItemView button)
		{
			constructionManager.OpenPanel(category, new HashSet<string>());
			HandleSelection(button);
			this.ShowCategoryEvent?.Invoke(category);
		}

		private void HandleSelection(BuildButtonLayoutItemView button)
		{
			if (!constructionManager.gameObject.activeInHierarchy)
			{
				return;
			}
			if (selected == button)
			{
				selected = null;
				{
					foreach (BuildButtonLayoutItemView baseCategoryButton in baseCategoryButtons)
					{
						baseCategoryButton.Select(select: false);
					}
					return;
				}
			}
			foreach (BuildButtonLayoutItemView baseCategoryButton2 in baseCategoryButtons)
			{
				baseCategoryButton2.Select(button == baseCategoryButton2);
			}
			selected = button;
		}

		private void OnNotificationCheck(BuildingCategoryUI category, bool setActive)
		{
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].EnableNotification(setActive);
			}
		}

		private void Start()
		{
			rectTransform = base.gameObject.GetComponent<RectTransform>();
			MonoSingleton<World>.Instance.MapLoadedEvent += Initialize;
			constructionManager.NotificationUpdate += OnNotificationCheck;
			constructionManager.PanelClosed += DeselectCurrent;
			constructionManager.SetupCopyBuildingListener();
			constructionManager.Show();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(constructionManager.Hide);
		}

		private void DeselectCurrent()
		{
			selected = null;
			HandleSelection(null);
			this.ClosePanelEvent?.Invoke();
		}

		private void Initialize(bool afterLoad)
		{
			CreateCategoryButtons();
			MonoSingleton<ResearchUIController>.Instance.ShowBaseConstructionButtonEvent += OnShowBaseConstructionButton;
			MonoSingleton<ResearchUIController>.Instance.HideBaseConstructionButtonEvent += OnHideBaseConstructionButton;
			MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsToggledEvent += OnCraftableBuildingsEnabled;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<ResearchUIController>.IsInstantiated())
			{
				MonoSingleton<ResearchUIController>.Instance.ShowBaseConstructionButtonEvent -= OnShowBaseConstructionButton;
				MonoSingleton<ResearchUIController>.Instance.HideBaseConstructionButtonEvent -= OnHideBaseConstructionButton;
			}
			if (MonoSingleton<BuildingPlacementManager>.IsInstantiated())
			{
				MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsToggledEvent -= OnCraftableBuildingsEnabled;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= Initialize;
			}
			base.OnDestroy();
		}

		private void OnShowBaseConstructionButton(BuildingCategoryUI buildingCategoryUI)
		{
			if (dictionary.ContainsKey(buildingCategoryUI) && (buildingCategoryUI != BuildingCategoryUI.None || MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsEnabled))
			{
				dictionary[buildingCategoryUI].gameObject.SetActive(value: true);
				LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			}
		}

		private void OnHideBaseConstructionButton(BuildingCategoryUI buildingCategoryUI)
		{
			if (dictionary.ContainsKey(buildingCategoryUI) && ShouldHide(buildingCategoryUI))
			{
				dictionary[buildingCategoryUI].gameObject.SetActive(value: false);
			}
		}

		private void OnCraftableBuildingsEnabled()
		{
			if (noneGroup != null)
			{
				noneGroup.gameObject.SetActive(MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsEnabled);
			}
		}

		public void SetCategoriesInteractable(HashSet<BuildingCategoryUI> categories, bool interactable)
		{
			foreach (KeyValuePair<BuildingCategoryUI, BuildButtonLayoutItemView> item in dictionary)
			{
				if (categories != null && categories.Contains(item.Key))
				{
					item.Value.Button.interactable = interactable;
				}
				else
				{
					item.Value.Button.interactable = !interactable;
				}
			}
		}

		public RectTransform GetCategoryTransform(BuildingCategoryUI category)
		{
			if (dictionary.TryGetValue(category, out var value))
			{
				return value.gameObject.GetComponent<RectTransform>();
			}
			return null;
		}
	}
}
