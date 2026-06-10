using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Sound;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ConstructionPanelManager : PanelBase
	{
		[SerializeField]
		private ConstructionPanelExtraView constructionExtraView;

		[SerializeField]
		private LayoutGroupView buildingsGroupe;

		[SerializeField]
		private TMP_Text panleTitle;

		[SerializeField]
		private GridLayoutGroup layoutGroup;

		private readonly Dictionary<BuildingCategoryUI, HashSet<string>> subcategoriesByCategory = new Dictionary<BuildingCategoryUI, HashSet<string>>();

		private readonly Dictionary<string, HashSet<string>> buildingIdsBySubcategory = new Dictionary<string, HashSet<string>>();

		private readonly List<BuildButtonLayoutItemView> categoryButtons = new List<BuildButtonLayoutItemView>();

		private readonly HashSet<string> highlightedSubcategories = new HashSet<string>();

		private readonly Dictionary<string, List<KeyValuePair<string, bool>>> selectionDefaults = new Dictionary<string, List<KeyValuePair<string, bool>>>();

		private readonly List<ButtonLayoutItemView> subCategoryButtons = new List<ButtonLayoutItemView>();

		private readonly Dictionary<string, int> subcategoryIndexDictionary = new Dictionary<string, int>();

		private string currentBuildingID = string.Empty;

		private int currentCategoryButtonIndex = -1;

		private KeyValuePair<string, HashSet<string>> currentSubcategory;

		private int defaultColumnCount;

		private bool buildingUnlockedRefresh;

		private bool researchUnlockedUpdateUIAfterLoading;

		public BuildingCategoryUI CurrentCategory { get; private set; }

		public event Action<BuildingCategoryUI, bool> NotificationUpdate;

		public event Action PanelClosed;

		private void Awake()
		{
			constructionExtraView.Hide();
		}

		protected override void Start()
		{
			base.Start();
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			MonoSingleton<ResearchController>.Instance.ActivateResearchEvent += OnResearchActivated;
			MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent += DeselectCurrent;
			MonoSingleton<SelectionManager>.Instance.ResetOrderEvent += DeselectCurrent;
			MonoSingleton<BuildingPlacementManager>.Instance.EmptyClickEvent += OnEmptyClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelectableObjectSelected;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectNothingClickEvent += delegate
			{
				OnSelectableObjectSelected(null);
			};
			MonoSingleton<GlobalSaveController>.Instance.BuildingUnlockedEvent += OnBuildingUnlocked;
		}

		private void OnGameLoaded(bool fromSave)
		{
			if (researchUnlockedUpdateUIAfterLoading)
			{
				MonoSingleton<TaskController>.Instance.OptimizedCall("ConstructionPanelManager", "OnResearchActivated", UpdatePanel);
				researchUnlockedUpdateUIAfterLoading = false;
			}
		}

		protected override void OnOtherPanelOpened(string panelName, PanelGroupType panelGroup)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("This group: ");
				messageBuilder.AppendFormatted(GetGroupType());
				messageBuilder.AppendLiteral(", other ");
				messageBuilder.AppendFormatted(panelName);
				messageBuilder.AppendLiteral(" group: ");
				messageBuilder.AppendFormatted(panelGroup);
				messageBuilder.AppendLiteral(" ");
			}
			Log.Trace(messageBuilder);
			if (panelGroup == PanelGroupType.LowerRight)
			{
				Hide();
			}
		}

		private void OnEmptyClick()
		{
			if (MainPanel.activeInHierarchy)
			{
				Hide();
			}
		}

		public void SetupCopyBuildingListener()
		{
			MonoSingleton<UIController>.Instance.CopyBuildingEvent += OnCopyBuilding;
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.LowerLeft;
		}

		public void HighlightSubcategories(BuildingCategoryUI category, IEnumerable<string> subcategories)
		{
			highlightedSubcategories.Clear();
			highlightedSubcategories.AddRange(subcategories);
			Show();
		}

		public void DeselectCurrent()
		{
			foreach (BuildButtonLayoutItemView categoryButton in categoryButtons)
			{
				categoryButton.Select(select: false);
			}
			foreach (ButtonLayoutItemView subCategoryButton in subCategoryButtons)
			{
				subCategoryButton.Select(select: false);
			}
			currentBuildingID = string.Empty;
			constructionExtraView.Hide();
		}

		public void OpenPanel(BuildingCategoryUI category, IEnumerable<string> subcategories)
		{
			highlightedSubcategories.Clear();
			highlightedSubcategories.AddRange(subcategories);
			OpenPanel(category);
		}

		public override void Show()
		{
			base.Show();
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_BuildPanelOpen");
		}

		public override void Hide()
		{
			if (base.gameObject.activeInHierarchy)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClose");
				highlightedSubcategories.Clear();
				currentCategoryButtonIndex = -1;
				CurrentCategory = BuildingCategoryUI.None;
				this.PanelClosed?.Invoke();
				base.Hide();
			}
		}

		protected override void UpdatePanel()
		{
			if (CurrentCategory == BuildingCategoryUI.None && !MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools)
			{
				return;
			}
			foreach (BuildButtonLayoutItemView categoryButton in categoryButtons)
			{
				categoryButton.gameObject.SetActive(value: false);
				categoryButton.EnableHighlight(enable: false);
				categoryButton.EnableVariantIcon(enable: false);
			}
			panleTitle.SetText(MonoSingleton<LocalizationController>.Instance.GetText("menu_" + CurrentCategory.ToString().ToLower()));
			Action action = null;
			subcategoryIndexDictionary.Clear();
			int num = 0;
			if (subcategoriesByCategory.Count == 0)
			{
				Log.Info("subcategoriesByCategory.Count is 0. Initializing categories.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				InitializeCategories();
			}
			bool isEnabled;
			if (!subcategoriesByCategory.TryGetValue(CurrentCategory, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Subcategories HashSet is null for ");
					messageBuilder.AppendFormatted(CurrentCategory);
					messageBuilder.AppendLiteral(" category.");
				}
				Log.Error(messageBuilder);
				return;
			}
			foreach (string item in value)
			{
				int index = num;
				if (categoryButtons.Count <= index)
				{
					BuildButtonLayoutItemView buildButtonLayoutItemView = CreateCategoryButton();
					categoryButtons.Add(buildButtonLayoutItemView);
					buildButtonLayoutItemView.gameObject.SetActive(value: false);
				}
				try
				{
					string defaultBuildingVersion = GetDefaultBuildingVersion(item);
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(item);
						messageBuilder2.AppendLiteral(": Default building version: ");
						messageBuilder2.AppendFormatted(defaultBuildingVersion);
					}
					Log.Trace(messageBuilder2);
					if (!MonoSingleton<ResearchManager>.Instance.Researched(defaultBuildingVersion))
					{
						continue;
					}
					categoryButtons[index].SetButtonData(defaultBuildingVersion, BuildingUtils.GetLocalizedName(defaultBuildingVersion), selected: false);
					categoryButtons[index].SetImageData(defaultBuildingVersion, BuildingUtils.GetIconPath(defaultBuildingVersion), BuildingUtils.GetIconColor(defaultBuildingVersion));
					BuildingButtonTooltipViewNew buildingButtonTooltipViewNew = categoryButtons[index].TooltipNew as BuildingButtonTooltipViewNew;
					if (buildingButtonTooltipViewNew != null)
					{
						buildingButtonTooltipViewNew.Init(defaultBuildingVersion);
					}
					subcategoryIndexDictionary.TryAdd(item, num);
					KeyValuePair<string, HashSet<string>> currentSubcategoryBuildings = new KeyValuePair<string, HashSet<string>>(item, buildingIdsBySubcategory[item]);
					categoryButtons[index].Button.AddCleanListener(delegate
					{
						categoryButtons[index].EnableHighlight(enable: false);
						MonoSingleton<StorageCommonManager>.Instance.ClearCopiedStorage();
						MonoSingleton<FuelDeliveryManager>.Instance.SetFuelConsumerCopyFilter(null);
						CategoryButtonClick(index, currentSubcategoryBuildings);
					});
					if (currentSubcategory.Key == item)
					{
						action = delegate
						{
							CategoryButtonClick(index, currentSubcategoryBuildings);
						};
					}
					categoryButtons[index].EnableHighlight(highlightedSubcategories.Contains(item));
					categoryButtons[index].EnableVariantIcon(HasVariations(currentSubcategoryBuildings));
					categoryButtons[index].gameObject.SetActive(value: true);
					num++;
				}
				catch (Exception ex)
				{
					FVLogInfoInterpolationHandler messageBuilder3 = new FVLogInfoInterpolationHandler(42, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					if (isEnabled)
					{
						messageBuilder3.AppendLiteral("Couldn't find default building! For ");
						messageBuilder3.AppendFormatted(item);
						messageBuilder3.AppendLiteral(" in ");
						messageBuilder3.AppendFormatted(CurrentCategory);
						messageBuilder3.AppendLiteral(": ");
						messageBuilder3.AppendFormatted(ex.Message);
					}
					Log.Info(messageBuilder3);
				}
			}
			if (categoryButtons.Cast<ButtonLayoutItemView>().Count((ButtonLayoutItemView itemView) => itemView.gameObject.activeSelf) == 0)
			{
				MonoSingleton<ResearchUIController>.Instance.HideBaseConstructionButton(CurrentCategory);
			}
			SelectCategoryButton(currentCategoryButtonIndex);
			action?.Invoke();
		}

		private bool HasVariations(KeyValuePair<string, HashSet<string>> subCategory)
		{
			if (TutorialManager.IsTutorialActive)
			{
				return false;
			}
			int num = 0;
			string defaultBuildingVersion = GetDefaultBuildingVersion(subCategory.Key);
			foreach (string item in subCategory.Value)
			{
				if (!(defaultBuildingVersion == item) && ShouldShowVariant(item))
				{
					num++;
				}
			}
			return num > 0;
		}

		private Dictionary<string, bool> GetSeenBuildings()
		{
			if (GlobalSaveController.CurrentVillageData.SeenBuildings.Count > 0)
			{
				return GlobalSaveController.CurrentVillageData.SeenBuildings;
			}
			foreach (KeyValuePair<BuildingCategoryUI, HashSet<string>> item in subcategoriesByCategory)
			{
				foreach (string item2 in item.Value)
				{
					string defaultBuildingVersion = GetDefaultBuildingVersion(item2);
					SetSeenBuilding(defaultBuildingVersion, MonoSingleton<ResearchManager>.Instance.Researched(defaultBuildingVersion));
				}
			}
			return GlobalSaveController.CurrentVillageData.SeenBuildings;
		}

		private void SetSeenBuilding(string defaultBuilding, bool seen = true)
		{
			if (GlobalSaveController.CurrentVillageData.SeenBuildings.ContainsKey(defaultBuilding))
			{
				GlobalSaveController.CurrentVillageData.SeenBuildings[defaultBuilding] = seen;
			}
			else
			{
				GlobalSaveController.CurrentVillageData.SeenBuildings.Add(defaultBuilding, seen);
			}
		}

		private void OnCopyBuilding(string id, BuildingCategoryUI categoryUI, BuildingSubCategoryUI subCategoryUI)
		{
			OpenPanel(categoryUI);
			if (subcategoriesByCategory[CurrentCategory] == null)
			{
				Log.Info("subcategories is null - first inquiry", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				return;
			}
			if (subCategoryUI == BuildingSubCategoryUI.None)
			{
				KeyValuePair<string, HashSet<string>> subCategory = buildingIdsBySubcategory.FirstOrDefault((KeyValuePair<string, HashSet<string>> x) => x.Value.Any((string v) => v.Equals(id)));
				if (!subcategoryIndexDictionary.ContainsKey(id))
				{
					Hide();
				}
				else if (subCategory.Equals(null))
				{
					Log.Info("target is null - first inquiry", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					Hide();
				}
				else if (subCategory.Value == null)
				{
					Log.Error("target.Value is null; something's wrong.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					Hide();
				}
				else
				{
					int categoryButtonIndex = subcategoryIndexDictionary[id];
					CategoryButtonClick(categoryButtonIndex, subCategory);
				}
				return;
			}
			KeyValuePair<string, HashSet<string>> subCategory2 = buildingIdsBySubcategory.FirstOrDefault((KeyValuePair<string, HashSet<string>> x) => x.Value.Any((string v) => v.Equals(id)));
			if (!subcategoryIndexDictionary.ContainsKey(subCategoryUI.ToString()))
			{
				Hide();
			}
			else if (subCategory2.Equals(null))
			{
				Log.Info("target is null - second inquiry", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				Hide();
			}
			else
			{
				int categoryButtonIndex2 = subcategoryIndexDictionary[subCategoryUI.ToString()];
				CategoryButtonClick(categoryButtonIndex2, subCategory2, id);
			}
		}

		private void OpenPanel(BuildingCategoryUI category)
		{
			currentCategoryButtonIndex = -1;
			currentSubcategory = default(KeyValuePair<string, HashSet<string>>);
			if (subcategoriesByCategory.Count == 0 || buildingUnlockedRefresh)
			{
				InitializeCategories();
				buildingUnlockedRefresh = false;
			}
			MonoSingleton<SelectableObjectController>.Instance.OnDeselectAll();
			constructionExtraView.Hide();
			if (!base.gameObject.activeSelf || CurrentCategory != category)
			{
				CurrentCategory = category;
				Show();
			}
			else
			{
				Hide();
			}
		}

		private void CategoryButtonClick(int categoryButtonIndex, KeyValuePair<string, HashSet<string>> subCategory, string buildingToCopyID = "")
		{
			if (subCategory.Equals(null))
			{
				Log.Error("subCategory is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				Hide();
				return;
			}
			if (subCategory.Value == null)
			{
				Log.Error("subCategory.Value is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				Hide();
				return;
			}
			currentSubcategory = subCategory;
			currentCategoryButtonIndex = categoryButtonIndex;
			currentBuildingID = ((buildingToCopyID != "") ? buildingToCopyID : GetDefaultBuildingVersion());
			int index = categoryButtonIndex;
			SelectCategoryButton(index);
			SetExtraPanelData(currentBuildingID, HasVariations(subCategory));
			foreach (ButtonLayoutItemView subCategoryButton in subCategoryButtons)
			{
				subCategoryButton.gameObject.SetActive(value: false);
			}
			int num = 0;
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!GlobalSaveController.CurrentVillageData.ExistingResources.Contains(allItem.GetID()) && MonoSingleton<ResourcePileTracker>.Instance.GetCount(allItem).TotalCount > 1)
				{
					GlobalSaveController.CurrentVillageData.ExistingResources.Add(allItem.GetID());
				}
			}
			foreach (string buildingID in subCategory.Value)
			{
				if (!(GetDefaultBuildingVersion(subCategory.Key) != buildingID) || ShouldShowVariant(buildingID))
				{
					if (subCategoryButtons.Count <= num)
					{
						subCategoryButtons.Add(CreateSubCategoryButton());
					}
					ButtonLayoutItemView currentSubcategoryButton = subCategoryButtons[num];
					currentSubcategoryButton.SetButtonData(buildingID, BuildingUtils.GetLocalizedName(buildingID), buildingID == GetDefaultBuildingVersion());
					currentSubcategoryButton.SetImageData(buildingID, BuildingUtils.GetIconPath(buildingID), BuildingUtils.GetIconColor(buildingID));
					if (currentSubcategoryButton.TooltipNew is BuildingButtonTooltipViewNew buildingButtonTooltipViewNew)
					{
						buildingButtonTooltipViewNew.Init(buildingID);
					}
					if (buildingToCopyID == buildingID)
					{
						SetSelectionDefaults();
						CopyBuildingSelectSubcategory(currentSubcategoryButton);
						RefreshCategoryButton(index);
					}
					currentSubcategoryButton.Button.onClick.RemoveAllListeners();
					currentSubcategoryButton.Button.onClick.AddListener(delegate
					{
						currentBuildingID = buildingID;
						SetSelectionDefaults();
						SelectSubcategory(currentSubcategoryButton);
						RefreshCategoryButton(index);
						BuildButtonClick();
						SetExtraPanelData(buildingID, HasVariations(subCategory));
						MonoSingleton<StorageCommonManager>.Instance.ClearCopiedStorage();
						MonoSingleton<FuelDeliveryManager>.Instance.SetFuelConsumerCopyFilter(null);
					});
					currentSubcategoryButton.gameObject.SetActive(value: true);
					currentSubcategoryButton.name = buildingID;
					num++;
				}
			}
			BuildButtonClick();
		}

		private bool ShouldShowVariant(string buildingID)
		{
			if (IsBuildingSeenByPlayer(buildingID))
			{
				return true;
			}
			if (!MonoSingleton<ResearchManager>.Instance.Researched(buildingID) && !MonoSingleton<ResearchManager>.Instance.UnlockedByDefault(buildingID))
			{
				return false;
			}
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools || !MonoSingleton<BuildingPlacementManager>.Instance.VariantsUnlocked)
			{
				if (!BuildableMaterialExists(buildingID))
				{
					return false;
				}
				if (ZoneUtils.Item(buildingID) is Cropfield { IsDefault: false } cropfield && !GlobalSaveController.CurrentVillageData.ExistingResources.Contains(cropfield.SeedId))
				{
					return false;
				}
			}
			return true;
		}

		private static bool BuildableMaterialExists(string buildingID)
		{
			BaseBuildingBlueprint byID = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(buildingID);
			if (byID != null && byID.Materials?.Dictionary != null && byID.Materials.Dictionary.Count != 0)
			{
				string item = byID.Materials.Dictionary.Keys.First();
				if (!GlobalSaveController.CurrentVillageData.ExistingResources.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		private void RefreshCategoryButton(int index)
		{
			categoryButtons[currentCategoryButtonIndex].SetButtonData(currentBuildingID, BuildingUtils.GetLocalizedName(currentBuildingID), selected: true);
			categoryButtons[currentCategoryButtonIndex].SetImageData(currentBuildingID, BuildingUtils.GetIconPath(currentBuildingID), BuildingUtils.GetIconColor(currentBuildingID));
			BuildingButtonTooltipViewNew buildingButtonTooltipViewNew = categoryButtons[index].TooltipNew as BuildingButtonTooltipViewNew;
			if (buildingButtonTooltipViewNew != null)
			{
				buildingButtonTooltipViewNew.Init(currentBuildingID);
			}
		}

		private void SetExtraPanelData(string buildingId, bool hasVariants)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(buildingId);
				messageBuilder.AppendLiteral(" Has Variants: ");
				messageBuilder.AppendFormatted(hasVariants);
			}
			Log.Trace(messageBuilder);
			constructionExtraView.SetupPanel(buildingId, hasVariants);
		}

		private void SelectSubcategory(ButtonLayoutItemView subCategoryButton)
		{
			foreach (ButtonLayoutItemView subCategoryButton2 in subCategoryButtons)
			{
				subCategoryButton2.Select(subCategoryButton2 == subCategoryButton);
			}
		}

		private void CopyBuildingSelectSubcategory(ButtonLayoutItemView subCategoryButton)
		{
			foreach (ButtonLayoutItemView subCategoryButton2 in subCategoryButtons)
			{
				if (subCategoryButton2 == subCategoryButton)
				{
					subCategoryButton2.Select(select: true);
				}
				else
				{
					subCategoryButton2.Select(select: false);
				}
			}
		}

		private void BuildButtonClick()
		{
			if (currentBuildingID == null)
			{
				Log.Warning("currentBuildingID is null. This should not happen. ", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				return;
			}
			if (currentBuildingID == string.Empty)
			{
				Log.Warning("currentBuildingID is empty. This should not happen. ", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				return;
			}
			if (currentSubcategory.Key == null)
			{
				Log.Warning("ConstructionPanelManager - this.currentSubcategory.Key is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				return;
			}
			if (MonoSingleton<MoveBuildingsManager>.Instance.BuildingToMove != null || MonoSingleton<MoveBuildingsManager>.Instance.PileToInstall != null)
			{
				string text = currentBuildingID;
				MonoSingleton<BuildingPlacementManager>.Instance.CancelSelection(resetCancelPlacement: true);
				currentBuildingID = text;
			}
			MonoSingleton<UIController>.Instance.BuildButtonClick();
			if (currentSubcategory.Key.ToLower() == BuildingSubCategoryUI.SubCtgStockpiles.ToString().ToLower() || currentSubcategory.Key.ToLower() == BuildingSubCategoryUI.SubCtgCropfields.ToString().ToLower() || currentSubcategory.Key.ToLower() == BuildingSubCategoryUI.SubCtgCropfieldsBush.ToString().ToLower() || currentSubcategory.Key.ToLower() == BuildingSubCategoryUI.SubCtgCropfieldsTree.ToString().ToLower())
			{
				if (MonoSingleton<UIController>.Instance == null)
				{
					Log.Warning("UIController.Instance is null, something is not right.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					return;
				}
				MonoSingleton<UIController>.Instance.ModifyZoneButtonClicked();
				MonoSingleton<UIController>.Instance.SelectBuilding(currentBuildingID);
			}
			else if (MonoSingleton<BuildingPlacementManager>.Instance == null)
			{
				Log.Warning("BuildingPlacementManager.Instance is null, something is not right. ", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
			}
			else
			{
				MonoSingleton<BuildingPlacementManager>.Instance.InitializeBuilding(currentBuildingID);
			}
		}

		private void SelectCategoryButton(int index)
		{
			if (index > -1)
			{
				SetSeenBuilding(GetDefaultBuildingVersion(currentSubcategory.Key));
				UpdateShownNotifications(CurrentCategory);
			}
			Dictionary<string, bool> seenBuildings = GetSeenBuildings();
			for (int i = 0; i < categoryButtons.Count; i++)
			{
				string getId = categoryButtons[i].GetId;
				if (categoryButtons[i].gameObject.activeInHierarchy && getId != null)
				{
					categoryButtons[i].Select(i == index);
					if (seenBuildings.TryGetValue(getId, out var value))
					{
						categoryButtons[i].EnableNotification(!value);
					}
				}
			}
		}

		private bool IsBuildingSeenByPlayer(string buildingId)
		{
			bool value;
			return GetSeenBuildings().TryGetValue(buildingId, out value) && value;
		}

		private BuildButtonLayoutItemView CreateCategoryButton()
		{
			return UnityEngine.Object.Instantiate(buildingsGroupe.Prefab, buildingsGroupe.gameObject.transform) as BuildButtonLayoutItemView;
		}

		private ButtonLayoutItemView CreateSubCategoryButton()
		{
			return UnityEngine.Object.Instantiate(constructionExtraView.SubcategoryPanel.Prefab, constructionExtraView.SubcategoryPanel.gameObject.transform) as ButtonLayoutItemView;
		}

		private void UpdateShownNotifications(BuildingCategoryUI category)
		{
			Dictionary<string, bool> seenBuildings = GetSeenBuildings();
			foreach (string item in subcategoriesByCategory[category])
			{
				string defaultBuildingVersion = GetDefaultBuildingVersion(item);
				if (string.IsNullOrEmpty(defaultBuildingVersion) || !seenBuildings.TryGetValue(defaultBuildingVersion, out var value))
				{
					continue;
				}
				if (!value && MonoSingleton<ResearchManager>.Instance.Researched(defaultBuildingVersion))
				{
					this.NotificationUpdate?.Invoke(category, arg2: true);
					return;
				}
				foreach (string item2 in buildingIdsBySubcategory[item])
				{
					defaultBuildingVersion = GetDefaultBuildingVersion(item2);
					if (!string.IsNullOrEmpty(defaultBuildingVersion) && seenBuildings.TryGetValue(defaultBuildingVersion, out var value2) && !value2 && MonoSingleton<ResearchManager>.Instance.Researched(defaultBuildingVersion))
					{
						this.NotificationUpdate?.Invoke(category, arg2: true);
						return;
					}
				}
			}
			this.NotificationUpdate?.Invoke(category, arg2: false);
		}

		private void InitializeCategories()
		{
			subcategoriesByCategory.Clear();
			buildingIdsBySubcategory.Clear();
			BuildingCategoryUI[] buildingCategoryUI = EnumValues.BuildingCategoryUI;
			foreach (BuildingCategoryUI buildingCategoryUI2 in buildingCategoryUI)
			{
				if (buildingCategoryUI2 == BuildingCategoryUI.None && !MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools)
				{
					continue;
				}
				HashSet<string> value = new HashSet<string>();
				if (!subcategoriesByCategory.TryAdd(buildingCategoryUI2, value))
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("BuildingCategoryUI ");
						messageBuilder.AppendFormatted(buildingCategoryUI2);
						messageBuilder.AppendLiteral(" is already added!");
					}
					Log.Error(messageBuilder);
					continue;
				}
				foreach (BaseBuildingBlueprint allItem in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems())
				{
					if (!MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(allItem.GetID()) && allItem.BuildingCategoryUI == buildingCategoryUI2)
					{
						string sub = allItem.BuildingSubCategoryUI.ToString();
						if (allItem.BuildingSubCategoryUI == BuildingSubCategoryUI.None)
						{
							sub = allItem.GetID();
						}
						AddToSubcategoryLocal(buildingCategoryUI2, sub, allItem.GetID());
					}
				}
				foreach (Stockpile allItem2 in Repository<StockpileRepository, Stockpile>.Instance.GetAllItems())
				{
					if (allItem2.BuildingCategoryUI == buildingCategoryUI2)
					{
						string sub2 = allItem2.BuildingSubCategoryUI.ToString();
						if (allItem2.BuildingSubCategoryUI == BuildingSubCategoryUI.None)
						{
							sub2 = allItem2.GetID();
						}
						AddToSubcategoryLocal(buildingCategoryUI2, sub2, allItem2.GetID());
					}
				}
				foreach (Cropfield allItem3 in Repository<CropfieldRepository, Cropfield>.Instance.GetAllItems())
				{
					if (allItem3.BuildingCategoryUI == buildingCategoryUI2)
					{
						string sub3 = allItem3.BuildingSubCategoryUI.ToString();
						if (allItem3.BuildingSubCategoryUI == BuildingSubCategoryUI.None)
						{
							sub3 = allItem3.GetID();
						}
						AddToSubcategoryLocal(buildingCategoryUI2, sub3, allItem3.GetID());
					}
				}
			}
			InitializeSelectionDefaults();
			void AddToSubcategoryLocal(BuildingCategoryUI category, string text, string buildingId)
			{
				subcategoriesByCategory[category].Add(text);
				if (!buildingIdsBySubcategory.ContainsKey(text))
				{
					buildingIdsBySubcategory.Add(text, new HashSet<string>());
				}
				buildingIdsBySubcategory[text].Add(buildingId);
				if (!selectionDefaults.ContainsKey(text))
				{
					selectionDefaults.Add(text, new List<KeyValuePair<string, bool>>());
				}
				selectionDefaults[text].Add(new KeyValuePair<string, bool>(buildingId, value: false));
			}
		}

		private void InitializeSelectionDefaults()
		{
			Log.Debug("Initializing selection defaults...", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
			foreach (KeyValuePair<string, List<KeyValuePair<string, bool>>> selectionDefault in selectionDefaults)
			{
				int num = -1;
				bool flag = false;
				foreach (KeyValuePair<string, bool> item in selectionDefault.Value.ToList())
				{
					if (selectionDefault.Value.Count == 1)
					{
						selectionDefault.Value[0] = new KeyValuePair<string, bool>(item.Key, value: true);
						break;
					}
					num++;
					if (MonoSingleton<ResearchManager>.Instance.Researched(item.Key))
					{
						flag = true;
						selectionDefault.Value[num] = new KeyValuePair<string, bool>(item.Key, value: true);
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(selectionDefault.Key);
							messageBuilder.AppendLiteral(" defaultBuildingSet: ");
							messageBuilder.AppendFormatted(item.Key);
						}
						Log.Trace(messageBuilder);
						break;
					}
				}
				if (!flag && selectionDefault.Value.Count > 0)
				{
					selectionDefault.Value[0] = new KeyValuePair<string, bool>(selectionDefault.Value[0].Key, value: true);
				}
				if (num != -1)
				{
					continue;
				}
				using List<KeyValuePair<string, bool>>.Enumerator enumerator2 = selectionDefault.Value.ToList().GetEnumerator();
				if (enumerator2.MoveNext())
				{
					KeyValuePair<string, bool> current3 = enumerator2.Current;
					selectionDefault.Value[0] = new KeyValuePair<string, bool>(current3.Key, value: true);
				}
			}
		}

		private void SetSelectionDefaults()
		{
			Log.Debug("Setting selection defaults...", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
			foreach (KeyValuePair<string, List<KeyValuePair<string, bool>>> selectionDefault in selectionDefaults)
			{
				if (!(selectionDefault.Key == currentSubcategory.Key))
				{
					continue;
				}
				int num = 0;
				{
					foreach (KeyValuePair<string, bool> item in selectionDefault.Value.ToList())
					{
						if (item.Key == currentBuildingID)
						{
							selectionDefault.Value[num] = new KeyValuePair<string, bool>(item.Key, value: true);
						}
						else
						{
							selectionDefault.Value[num] = new KeyValuePair<string, bool>(item.Key, value: false);
						}
						num++;
					}
					break;
				}
			}
		}

		private string GetDefaultBuildingVersion(string subCategory = "")
		{
			subCategory = ((subCategory == string.Empty) ? currentSubcategory.Key : subCategory);
			foreach (KeyValuePair<string, List<KeyValuePair<string, bool>>> selectionDefault in selectionDefaults)
			{
				if (!(selectionDefault.Key == subCategory))
				{
					continue;
				}
				foreach (KeyValuePair<string, bool> item in selectionDefault.Value)
				{
					if (item.Value)
					{
						return item.Key;
					}
				}
			}
			return string.Empty;
		}

		private void OnSelectableObjectSelected(SelectableObject obj)
		{
			MonoSingleton<BuildingPlacementManager>.Instance.CancelSelection();
			Hide();
		}

		private void OnResearchActivated(ResearchNodeInstance obj, bool afterLoading = false, bool forceUnlock = false)
		{
			currentSubcategory = default(KeyValuePair<string, HashSet<string>>);
			if (!afterLoading)
			{
				MonoSingleton<TaskController>.Instance.OptimizedCall("ConstructionPanelManager", "OnResearchActivated", UpdatePanel);
			}
			else
			{
				researchUnlockedUpdateUIAfterLoading = true;
			}
			foreach (BuildingCategoryUI category in subcategoriesByCategory.Keys)
			{
				MonoSingleton<TaskController>.Instance.OptimizedCall("UpdateShownNotifications", category.ToString(), delegate
				{
					UpdateShownNotifications(category);
				});
			}
		}

		private void OnBuildingUnlocked(string id)
		{
			buildingUnlockedRefresh = true;
		}

		public void Initialize()
		{
			InitializeCategories();
			foreach (BuildingCategoryUI key in subcategoriesByCategory.Keys)
			{
				UpdateShownNotifications(key);
			}
			Invoke("Hide", 1f);
		}

		public void SetCategoriesInteractable(HashSet<string> ids, bool interactable)
		{
			foreach (BuildButtonLayoutItemView categoryButton in categoryButtons)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(categoryButton.GetId);
					messageBuilder.AppendLiteral(" contains ");
					messageBuilder.AppendFormatted(ids.Contains(categoryButton.GetId));
				}
				Log.Trace(messageBuilder);
				categoryButton.Button.interactable = (ids.Contains(categoryButton.GetId) ? interactable : (!interactable));
			}
		}

		public void SetSubCategoriesInteractable(HashSet<string> ids, bool interactable)
		{
			foreach (ButtonLayoutItemView subCategoryButton in subCategoryButtons)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(subCategoryButton.GetId);
				}
				Log.Trace(messageBuilder);
				subCategoryButton.Button.interactable = (ids.Contains(subCategoryButton.GetId) ? interactable : (!interactable));
			}
		}

		public RectTransform GetSubcategoryTransform(string category)
		{
			foreach (BuildButtonLayoutItemView categoryButton in categoryButtons)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\ConstructionPanelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(categoryButton.GetId);
					messageBuilder.AppendLiteral(" contains ");
					messageBuilder.AppendFormatted(category);
				}
				Log.Trace(messageBuilder);
				if (categoryButton.GetId == category)
				{
					return categoryButton.gameObject.GetComponent<RectTransform>();
				}
			}
			return null;
		}
	}
}
