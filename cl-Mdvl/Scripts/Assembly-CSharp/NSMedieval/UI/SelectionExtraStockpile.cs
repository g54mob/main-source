using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class SelectionExtraStockpile : SelectionExtraWindowView
	{
		private class TreeInfo
		{
			public Dictionary<Resource, ResourceToggleItemView> Resources { get; private set; } = new Dictionary<Resource, ResourceToggleItemView>();

			public Dictionary<ResourceGroups, ResourceToggleItemView> ResourceGroups { get; private set; } = new Dictionary<ResourceGroups, ResourceToggleItemView>();

			public Dictionary<ResourceGroups, List<ResourceGroups>> GroupParents { get; private set; } = new Dictionary<ResourceGroups, List<ResourceGroups>>();

			public Dictionary<ResourceGroups, List<Resource>> ResourceParents { get; private set; } = new Dictionary<ResourceGroups, List<Resource>>();

			public Dictionary<string, List<Resource>> ResourcesWithQuality { get; private set; } = new Dictionary<string, List<Resource>>();

			public void SetResources(Dictionary<Resource, ResourceToggleItemView> resources)
			{
				Resources = new Dictionary<Resource, ResourceToggleItemView>(resources);
			}

			public void SetResourceGroups(Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroups)
			{
				ResourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(resourceGroups);
			}

			public void SetGroupParents(Dictionary<ResourceGroups, List<ResourceGroups>> groupParents)
			{
				GroupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(groupParents);
			}

			public void SetResourceParents(Dictionary<ResourceGroups, List<Resource>> resourceParents)
			{
				ResourceParents = new Dictionary<ResourceGroups, List<Resource>>(resourceParents);
			}

			public void SetResourcesWithQuality(Dictionary<string, List<Resource>> resourcesWithQuality)
			{
				ResourcesWithQuality = new Dictionary<string, List<Resource>>(resourcesWithQuality);
			}

			public bool IsValid()
			{
				if (Resources != null)
				{
					return Resources.Count != 0;
				}
				return false;
			}
		}

		[SerializeField]
		private LayoutGroupView resourcesListParent;

		[SerializeField]
		private TMP_InputField stockpileName;

		[SerializeField]
		private SoundButton copyButton;

		[SerializeField]
		private SoundButton pasteButton;

		[SerializeField]
		private SoundButton selectAllButton;

		[SerializeField]
		private SoundButton clearAllButton;

		[SerializeField]
		private Toggle forbidUseInProductionToggle;

		[SerializeField]
		private RangedSliderItemView hitpointsSliderGroup;

		[SerializeField]
		private RangedSliderItemView itemQualitySliderGroup;

		[SerializeField]
		private TMP_Dropdown presetDropdown;

		[SerializeField]
		private TMP_Dropdown priorityDropdown;

		private List<ResourceGroups> allResourceGroups;

		private Dictionary<string, TreeInfo> cachedTreeInfo = new Dictionary<string, TreeInfo>();

		private Dictionary<ResourceGroups, List<ResourceGroups>> groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>();

		private Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>();

		private Dictionary<ResourceGroups, List<Resource>> resourceParents = new Dictionary<ResourceGroups, List<Resource>>();

		private Dictionary<Resource, ResourceToggleItemView> resources = new Dictionary<Resource, ResourceToggleItemView>();

		private Dictionary<string, List<Resource>> resourcesWithQuality = new Dictionary<string, List<Resource>>();

		private List<string> stockpilePresets = new List<string>();

		private List<IStorage> storageObjects;

		private Dictionary<string, List<IStorage>> shelfByTypeDictionary;

		private HashSet<ResourceGroups> commonResourceGroups;

		private HashSet<Resource> mutualAllowedResources;

		private int storageObjectsInPreviousTick;

		private bool refreshSliders;

		private bool refreshInput;

		private string selectionId = string.Empty;

		public void UpdatePanel(InfoPanelStockpile infoPanelStockpile)
		{
			storageObjects = infoPanelStockpile.StorageObjects;
			if (storageObjectsInPreviousTick != storageObjects.Count)
			{
				refreshInput = true;
				refreshSliders = true;
				storageObjectsInPreviousTick = storageObjects.Count;
			}
			if (storageObjects.Count == 0 || storageObjects.Any((IStorage x) => !x.IsPlayerOwned))
			{
				Hide();
				return;
			}
			pasteButton.interactable = MonoSingleton<StorageCommonManager>.Instance.CopiedStorage != null;
			shelfByTypeDictionary = GetStorageByTypeDictionary();
			mutualAllowedResources = new HashSet<Resource>();
			IEnumerable<Resource> enumerable = GetMutualAllowedResources(shelfByTypeDictionary.Values.SelectMany((List<IStorage> x) => x));
			if (enumerable != null)
			{
				mutualAllowedResources.UnionWith(enumerable);
			}
			GetMutualResourceGroups(ref commonResourceGroups);
			string text = ((storageObjects.Count == 1) ? storageObjects.First().ObjectId : GetCombinedIds());
			if (selectionId == text)
			{
				Refresh();
				return;
			}
			ResetGroups();
			SetupGroups();
			Refresh();
		}

		private Dictionary<string, List<IStorage>> GetStorageByTypeDictionary()
		{
			Dictionary<string, List<IStorage>> dictionary = new Dictionary<string, List<IStorage>>();
			foreach (IStorage storageObject in storageObjects)
			{
				if (storageObject != null)
				{
					string objectId = storageObject.ObjectId;
					if (!dictionary.ContainsKey(objectId))
					{
						dictionary.Add(objectId, new List<IStorage>());
					}
					dictionary[objectId].Add(storageObject);
				}
			}
			return dictionary;
		}

		private IEnumerable<Resource> GetMutualAllowedResources(IEnumerable<IStorage> sameTypeStorage)
		{
			if (sameTypeStorage == null)
			{
				return null;
			}
			IEnumerable<Resource> enumerable = null;
			foreach (IStorage item in sameTypeStorage)
			{
				if (item != null && !item.HasDisposed)
				{
					if (item.ResourcesFilter == null)
					{
						Log.Warning("IStorage.ResourceFilter was null. This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Stockpiles\\SelectionExtraStockpile.cs");
						return null;
					}
					if (item.ResourcesFilter.AllowedResourceTypes == null)
					{
						Log.Warning("IStorage.ResourceFilter.AllowedResourceTypes was null. This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Stockpiles\\SelectionExtraStockpile.cs");
						return null;
					}
					if (item.ResourcesFilter.AllowedResourceTypes.Count == 0)
					{
						return null;
					}
					enumerable = ((enumerable != null || item.ResourcesFilter.AllowedResourceTypes.Count <= 0) ? enumerable?.Intersect(item.ResourcesFilter.AllowedResourceTypes) : item.ResourcesFilter.AllowedResourceTypes);
				}
			}
			return enumerable;
		}

		private void GetMutualResourceGroups(ref HashSet<ResourceGroups> outputSet)
		{
			if (outputSet == null)
			{
				outputSet = new HashSet<ResourceGroups>();
			}
			else
			{
				outputSet.Clear();
			}
			List<ResourceGroups> defaultResourceGroups = storageObjects[0].DefaultResourceGroups;
			if (defaultResourceGroups != null)
			{
				outputSet.UnionWith(defaultResourceGroups);
			}
			foreach (IStorage item in storageObjects.Skip(1))
			{
				if (item.DefaultResourceGroups != null)
				{
					outputSet.IntersectWith(item.DefaultResourceGroups);
				}
			}
		}

		public override void Hide()
		{
			storageObjects = null;
			selectionId = string.Empty;
			storageObjectsInPreviousTick = 0;
			refreshSliders = false;
			refreshInput = false;
			EventSystem.current.SetSelectedGameObject(null);
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
			base.Hide();
		}

		private void Refresh()
		{
			RefreshTree();
			RefreshSliders();
		}

		private void RefreshSliders()
		{
			if (refreshSliders)
			{
				refreshSliders = false;
				IStorage storage = storageObjects.Last();
				if (storage?.ResourcesFilter != null && !(hitpointsSliderGroup == null) && !(hitpointsSliderGroup.Slider == null) && !(itemQualitySliderGroup == null) && !(itemQualitySliderGroup.Slider == null))
				{
					float num = (float)storage.ResourcesFilter.HitPointsPercent.Min / 100f;
					float num2 = (float)storage.ResourcesFilter.HitPointsPercent.Max / 100f;
					hitpointsSliderGroup.Slider.LowValue = num;
					hitpointsSliderGroup.Slider.HighValue = num2;
					OnHitpointsSliderDrag(num, num2);
					int min = storage.ResourcesFilter.Quality.Min;
					int max = storage.ResourcesFilter.Quality.Max;
					itemQualitySliderGroup.Slider.LowValue = min;
					itemQualitySliderGroup.Slider.HighValue = max;
					OnQualitySliderDrag(min, max);
					forbidUseInProductionToggle.SetIsOnWithoutNotify(storage.CanBeUsedInProduction);
				}
			}
		}

		private void RefreshTree()
		{
			if (storageObjects.Count > 1)
			{
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource in resources)
				{
					resource.Value.GroupSelectToggle.SetIsOnWithoutNotify(mutualAllowedResources.Contains(resource.Key));
					UpdateResourceParentSelection(resource.Key);
				}
			}
			else
			{
				IStorage storage = storageObjects.First();
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource2 in resources)
				{
					resource2.Value.GroupSelectToggle.isOn = storage.IsBlueprintAllowed(resource2.Key);
				}
			}
			if (refreshInput)
			{
				refreshInput = false;
				string text = storageObjects.First().StorageName;
				if (storageObjects.Count > 1)
				{
					foreach (IStorage storageObject in storageObjects)
					{
						if (storageObject.StorageName != text)
						{
							text = "-";
							break;
						}
					}
				}
				stockpileName.SetTextWithoutNotify(text);
			}
			priorityDropdown.SetValueWithoutNotify((int)(storageObjects.Last().Priority - 1));
			OnGroupExpansion();
			Show();
		}

		private void ChangePreset(Stockpile currentStockpile = null)
		{
			if (currentStockpile == null)
			{
				currentStockpile = Repository<StockpileRepository, Stockpile>.Instance.GetByID(MonoSingleton<UIController>.Instance.StockpileBlueprint);
			}
			foreach (ResourceGroups key in resourceGroups.Keys)
			{
				bool allowed = false;
				foreach (ResourceGroups resourceGroup in currentStockpile.ResourceGroups)
				{
					if (key.GetID() == resourceGroup.GetID())
					{
						allowed = true;
					}
				}
				UpdateGroupChildren(key, allowed);
			}
			RefreshTree();
		}

		private void OnGroupToggleChange(ResourceGroups group, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				if (storageObjects != null)
				{
					UpdateGroupChildren(group, value);
				}
			});
		}

		private void OnResourceToggleChange(Resource resource, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool allowed)
			{
				if (storageObjects == null)
				{
					return;
				}
				resources[resource].SetSelected(allowed);
				UpdateResourceParentSelection(resource);
				foreach (IStorage storageObject in storageObjects)
				{
					if (storageObject is ShelfComponentInstance shelfComponentInstance)
					{
						foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
						{
							if (item.ResourcesFilter.DefaultAllowedResources.Contains(resource))
							{
								storageObject.AllowResource(resource, allowed);
								if (resource.HasQuality && resourcesWithQuality.ContainsKey(resource.GroupIdentifier))
								{
									SetItemsAllowed(resource, allowed);
								}
							}
						}
					}
					else if (storageObject.ResourcesFilter.DefaultAllowedResources.Contains(resource))
					{
						storageObject.AllowResource(resource, allowed);
						if (resource.HasQuality && resourcesWithQuality.ContainsKey(resource.GroupIdentifier))
						{
							SetItemsAllowed(resource, allowed);
						}
					}
				}
			});
		}

		private void UpdateGroupChildren(ResourceGroups group, bool allowed)
		{
			if (resourceParents.ContainsKey(group))
			{
				SetResourcesAllowed(allowed, group);
			}
			else
			{
				if (!groupParents.ContainsKey(group))
				{
					return;
				}
				foreach (ResourceGroups item in groupParents[group])
				{
					resourceGroups[group].SetSelected(allowed);
					UpdateGroupChildren(item, allowed);
				}
			}
		}

		private void SetUpGroupsAllowed(bool allowed)
		{
			foreach (ResourceGroups key in resourceGroups.Keys)
			{
				resourceGroups[key].SetSelected(allowed);
			}
		}

		private void SetResourcesAllowed(bool allowed, ResourceGroups group = null)
		{
			List<Resource> list = resources.Keys.ToList();
			if (group != null)
			{
				list = resourceParents[group];
			}
			Resource resource = null;
			foreach (Resource item in list)
			{
				resources[item].SetSelected(allowed);
				foreach (IStorage storageObject in storageObjects)
				{
					if (storageObject is ShelfComponentInstance shelfComponentInstance)
					{
						foreach (UniversalStorage item2 in shelfComponentInstance.AllStorage)
						{
							if (item2.ResourcesFilter.DefaultAllowedResources.Contains(item))
							{
								item2.AllowResource(item, allowed);
								resource = item;
								if (item.HasQuality && resourcesWithQuality.ContainsKey(item.GroupIdentifier))
								{
									SetItemsAllowed(item, allowed);
								}
							}
						}
					}
					else if (storageObject.ResourcesFilter.DefaultAllowedResources.Contains(item))
					{
						storageObject.AllowResource(item, allowed);
						resource = item;
						if (item.HasQuality && resourcesWithQuality.ContainsKey(item.GroupIdentifier))
						{
							SetItemsAllowed(item, allowed);
						}
					}
				}
			}
			if (resource != null)
			{
				UpdateResourceParentSelection(resource);
			}
		}

		private void SetItemsAllowed(Resource resource, bool allowed)
		{
			foreach (Resource item in resourcesWithQuality[resource.GroupIdentifier])
			{
				foreach (IStorage storageObject in storageObjects)
				{
					if (storageObject is ShelfComponentInstance shelfComponentInstance)
					{
						foreach (UniversalStorage item2 in shelfComponentInstance.AllStorage)
						{
							if (item2.ResourcesFilter.DefaultAllowedResources.Contains(item))
							{
								storageObject.AllowResource(item, allowed);
							}
						}
					}
					else if (storageObject.ResourcesFilter.DefaultAllowedResources.Contains(item))
					{
						storageObject.AllowResource(item, allowed);
					}
				}
			}
		}

		private void UpdateResourceParentSelection(Resource resource)
		{
			int num = 0;
			foreach (KeyValuePair<ResourceGroups, List<Resource>> resourceParent in resourceParents)
			{
				if (!resourceParent.Value.Contains(resource))
				{
					continue;
				}
				int count = resourceParent.Value.Count;
				foreach (Resource item in resourceParent.Value)
				{
					if (resources[item].GroupSelectToggle.isOn)
					{
						num++;
					}
				}
				if (num == 0)
				{
					resourceGroups[resourceParent.Key].SetSelected(selected: false);
				}
				else if (count == num)
				{
					resourceGroups[resourceParent.Key].SetSelectedFull();
				}
				else
				{
					resourceGroups[resourceParent.Key].SetSelectedPartial();
				}
				UpdateGroupParentSelection(resourceParent.Key);
			}
		}

		private void UpdateGroupParentSelection(ResourceGroups childGroup)
		{
			ResourceGroups groupParent = GetGroupParent(childGroup);
			if (groupParent == null)
			{
				return;
			}
			List<ResourceGroups> list = groupParents[groupParent];
			int num = 0;
			int num2 = 0;
			bool flag = false;
			num = list.Count;
			foreach (ResourceGroups item in list)
			{
				if (resourceGroups[item].GroupSelectToggle.isOn)
				{
					num2++;
				}
				if (resourceGroups[item].PartiallySelected)
				{
					flag = true;
				}
			}
			if (num2 == 0)
			{
				resourceGroups[groupParent].SetSelected(selected: false);
			}
			else if (num == num2 && !flag)
			{
				resourceGroups[groupParent].SetSelectedFull();
			}
			else
			{
				resourceGroups[groupParent].SetSelectedPartial();
			}
			UpdateGroupParentSelection(groupParent);
		}

		private ResourceGroups GetGroupParent(ResourceGroups childGroup)
		{
			foreach (KeyValuePair<ResourceGroups, List<ResourceGroups>> groupParent in groupParents)
			{
				if (groupParent.Value.Contains(childGroup))
				{
					return groupParent.Key;
				}
			}
			return null;
		}

		public override void Initialize()
		{
			MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent += OnGroupExpansion;
			selectAllButton.onClick.AddListener(OnSelectAllClick);
			clearAllButton.onClick.AddListener(OnClearAllClick);
			forbidUseInProductionToggle.onValueChanged.AddListener(OnForbidUseInProductionClick);
			copyButton.onClick.AddListener(delegate
			{
				MonoSingleton<StorageCommonManager>.Instance.OnCopyStorage(storageObjects.First());
				pasteButton.interactable = true;
			});
			pasteButton.onClick.AddListener(delegate
			{
				MonoSingleton<StorageCommonManager>.Instance.PasteStorageSettingsTo(storageObjects);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					shelfByTypeDictionary = GetStorageByTypeDictionary();
					mutualAllowedResources = new HashSet<Resource>();
					IEnumerable<Resource> enumerable = GetMutualAllowedResources(shelfByTypeDictionary.Values.SelectMany((List<IStorage> x) => x));
					if (enumerable != null)
					{
						mutualAllowedResources.UnionWith(enumerable);
					}
					GetMutualResourceGroups(ref commonResourceGroups);
					Refresh();
				});
			});
			hitpointsSliderGroup.Slider.OnRangeSliderMouseUp += OnHitpointsSliderMouseUp;
			hitpointsSliderGroup.Slider.OnValueChanged.AddListener(OnHitpointsSliderDrag);
			itemQualitySliderGroup.Slider.OnRangeSliderMouseUp += OnQualitySliderMouseUp;
			itemQualitySliderGroup.Slider.OnValueChanged.AddListener(OnQualitySliderDrag);
			stockpileName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			stockpileName.onDeselect.AddListener(OnNameEdit);
			stockpileName.onEndEdit.AddListener(OnNameEdit);
			SetupPresetDropdown();
			SetupPriorityDropdown();
			base.Initialize();
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= OnGroupExpansion;
			}
			shelfByTypeDictionary.Clear();
			cachedTreeInfo = null;
			groupParents = null;
			resourceGroups = null;
			resourceParents = null;
			resources = null;
			resourcesWithQuality = null;
			stockpilePresets = null;
			base.OnDestroy();
		}

		private void SetupPresetDropdown()
		{
			List<string> list = new List<string>();
			foreach (Stockpile allItem in Repository<StockpileRepository, Stockpile>.Instance.GetAllItems())
			{
				if (allItem.BuildingCategoryUI == BuildingCategoryUI.Zone)
				{
					stockpilePresets.Add(allItem.ToString());
					list.Add(BuildingUtils.GetLocalizedName(allItem.GetID()));
				}
			}
			presetDropdown.AddOptions(list);
			presetDropdown.onValueChanged.AddListener(delegate
			{
				OnLoadPreset();
			});
		}

		private void SetupPriorityDropdown()
		{
			List<string> list = new List<string>();
			ZonePriority[] zonePriorities = EnumValues.ZonePriorities;
			for (int i = 0; i < zonePriorities.Length; i++)
			{
				ZonePriority zonePriority = zonePriorities[i];
				if (zonePriority != ZonePriority.None && zonePriority != ZonePriority.Last)
				{
					string text = zonePriority.ToString();
					text = "general_" + char.ToLower(text[0]) + text.Substring(1);
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text));
				}
			}
			priorityDropdown.AddOptions(list);
			priorityDropdown.onValueChanged.AddListener(delegate
			{
				OnPriorityChanged();
			});
		}

		private void SetupGroups()
		{
			if (storageObjects.Count == 1)
			{
				SetupGroupsSingleStorageSelected(storageObjects.First());
			}
			else
			{
				SetupGroupsMultipleStorageSelected();
			}
		}

		private string GetCombinedIds()
		{
			List<string> list = new List<string>();
			list.AddRange(shelfByTypeDictionary.Keys.OrderByDescending((string x) => x));
			return string.Join("_", list);
		}

		private void SetupGroupsMultipleStorageSelected()
		{
			selectionId = GetCombinedIds();
			if (cachedTreeInfo.TryGetValue(selectionId, out var value) && value.IsValid())
			{
				resources = new Dictionary<Resource, ResourceToggleItemView>(value.Resources);
				resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(value.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(value.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(value.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(value.ResourcesWithQuality);
				{
					foreach (ResourceGroups key in resourceGroups.Keys)
					{
						if (key.Depth != 0)
						{
							resourceGroups[key].SetExpanded(groupExpanded: false);
							resourceGroups[key].RotateToggleSprite();
							resourceGroups[key].UpdateChildren();
						}
						else
						{
							resourceGroups[key].gameObject.SetActive(value: true);
							resourceGroups[key].SetExpanded(groupExpanded: false);
							resourceGroups[key].RotateToggleSprite();
							resourceGroups[key].UpdateChildren();
						}
					}
					return;
				}
			}
			TreeInfo treeInfo = new TreeInfo();
			cachedTreeInfo[selectionId] = treeInfo;
			if (allResourceGroups == null || allResourceGroups.Count == 0)
			{
				allResourceGroups = new List<ResourceGroups>();
				allResourceGroups.AddRange(Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.GetByID("all_resource_groups").ResourceGroups);
			}
			foreach (ResourceGroups allResourceGroup in allResourceGroups)
			{
				if (commonResourceGroups.Contains(allResourceGroup) && !resourceGroups.ContainsKey(allResourceGroup))
				{
					resourceGroups.Add(allResourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
				}
			}
			treeInfo.SetResourceGroups(resourceGroups);
			foreach (ResourceGroups allResourceGroup2 in allResourceGroups)
			{
				if (!commonResourceGroups.Contains(allResourceGroup2))
				{
					continue;
				}
				string nameKey = allResourceGroup2.GetID();
				Transform parent = resourcesListParent.transform;
				foreach (ResourceGroups allResourceGroup3 in allResourceGroups)
				{
					foreach (string subGroupID in allResourceGroup3.SubGroupIDs)
					{
						if (allResourceGroup2.GetID() == subGroupID)
						{
							parent = resourceGroups[allResourceGroup3].transform;
							resourceGroups[allResourceGroup3].AddChild(resourceGroups[allResourceGroup2]);
							if (!groupParents.ContainsKey(allResourceGroup3))
							{
								groupParents.Add(allResourceGroup3, new List<ResourceGroups>());
							}
							groupParents[allResourceGroup3].Add(allResourceGroup2);
							nameKey = subGroupID;
							goto end_IL_033b;
						}
					}
					continue;
					end_IL_033b:
					break;
				}
				resourceGroups[allResourceGroup2].transform.SetParent(parent);
				resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, resourceGroups[allResourceGroup2]);
				AddGroupResources(allResourceGroup2);
			}
			treeInfo.SetGroupParents(groupParents);
			treeInfo.SetResourcesWithQuality(resourcesWithQuality);
			treeInfo.SetResources(resources);
			treeInfo.SetResourceParents(resourceParents);
		}

		private void SetupGroupsSingleStorageSelected(IStorage storage)
		{
			selectionId = storage.ObjectId;
			if (cachedTreeInfo.TryGetValue(selectionId, out var value) && value.IsValid())
			{
				resources = new Dictionary<Resource, ResourceToggleItemView>(value.Resources);
				resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(value.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(value.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(value.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(value.ResourcesWithQuality);
				{
					foreach (ResourceGroups key in resourceGroups.Keys)
					{
						if (key.Depth != 0)
						{
							resourceGroups[key].SetExpanded(groupExpanded: false);
							resourceGroups[key].RotateToggleSprite();
							resourceGroups[key].UpdateChildren();
						}
						else
						{
							resourceGroups[key].gameObject.SetActive(value: true);
							resourceGroups[key].SetExpanded(groupExpanded: false);
							resourceGroups[key].RotateToggleSprite();
							resourceGroups[key].UpdateChildren();
						}
					}
					return;
				}
			}
			TreeInfo treeInfo = new TreeInfo();
			cachedTreeInfo[selectionId] = treeInfo;
			if (allResourceGroups == null || allResourceGroups.Count == 0)
			{
				allResourceGroups = new List<ResourceGroups>();
				allResourceGroups.AddRange(Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.GetByID("all_resource_groups").ResourceGroups);
			}
			foreach (ResourceGroups allResourceGroup in allResourceGroups)
			{
				if (storage.DefaultResourceGroups.Contains(allResourceGroup))
				{
					resourceGroups.Add(allResourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
				}
			}
			treeInfo.SetResourceGroups(resourceGroups);
			foreach (ResourceGroups allResourceGroup2 in allResourceGroups)
			{
				if (!storage.DefaultResourceGroups.Contains(allResourceGroup2))
				{
					continue;
				}
				string nameKey = allResourceGroup2.GetID();
				Transform parent = resourcesListParent.transform;
				foreach (ResourceGroups allResourceGroup3 in allResourceGroups)
				{
					foreach (string subGroupID in allResourceGroup3.SubGroupIDs)
					{
						if (allResourceGroup2.GetID() == subGroupID)
						{
							parent = resourceGroups[allResourceGroup3].transform;
							resourceGroups[allResourceGroup3].AddChild(resourceGroups[allResourceGroup2]);
							if (!groupParents.ContainsKey(allResourceGroup3))
							{
								groupParents.Add(allResourceGroup3, new List<ResourceGroups>());
							}
							groupParents[allResourceGroup3].Add(allResourceGroup2);
							nameKey = subGroupID;
							goto end_IL_032c;
						}
					}
					continue;
					end_IL_032c:
					break;
				}
				resourceGroups[allResourceGroup2].transform.SetParent(parent);
				resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, resourceGroups[allResourceGroup2]);
				AddGroupResources(allResourceGroup2);
			}
			treeInfo.SetGroupParents(groupParents);
			treeInfo.SetResourcesWithQuality(resourcesWithQuality);
			treeInfo.SetResources(resources);
			treeInfo.SetResourceParents(resourceParents);
		}

		private void ResetGroups()
		{
			Log.Debug("ResetGroups", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Stockpiles\\SelectionExtraStockpile.cs");
			foreach (ResourceGroups key in resourceGroups.Keys)
			{
				resourceGroups[key].gameObject.SetActive(value: false);
			}
			resources.Clear();
			resourceGroups.Clear();
			groupParents.Clear();
			resourceParents.Clear();
			resourcesWithQuality.Clear();
		}

		private void AddGroupResources(ResourceGroups node)
		{
			Log.Debug("AddGroupResources", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Stockpiles\\SelectionExtraStockpile.cs");
			ResourceToggleItemView resourceToggleItemView = resourceGroups[node];
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!(allItem.SortingGroup == node.GetID()))
				{
					continue;
				}
				string nameKey = allItem.GetID();
				if (allItem.HasQuality)
				{
					if (resourcesWithQuality.ContainsKey(allItem.GroupIdentifier))
					{
						if (resourcesWithQuality.TryGetValue(allItem.GroupIdentifier, out var value))
						{
							value.Add(allItem);
							resourcesWithQuality[allItem.GroupIdentifier] = value;
						}
						continue;
					}
					resourcesWithQuality.Add(allItem.GroupIdentifier, new List<Resource>());
					nameKey = ((!allItem.Tainted) ? allItem.ProtoId : (allItem.ProtoId + "_tainted"));
				}
				if (!resources.ContainsKey(allItem))
				{
					ResourceToggleItemView component = UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourceToggleItemView.transform).GetComponent<ResourceToggleItemView>();
					component.gameObject.name = nameKey;
					component.SetupGroup(nameKey, "name", node.Depth + 1);
					resourceToggleItemView.AddChild(component);
					OnResourceToggleChange(allItem, component);
					if (!resourceParents.ContainsKey(node))
					{
						resourceParents.Add(node, new List<Resource>());
					}
					resources.Add(allItem, component);
					resourceParents[node].Add(allItem);
				}
			}
		}

		private void OnLoadPreset()
		{
			MonoSingleton<UIController>.Instance.StockpileBlueprint = stockpilePresets[presetDropdown.value];
			ChangePreset();
		}

		private void OnPriorityChanged()
		{
			ZonePriority priority = (ZonePriority)(priorityDropdown.value + 1);
			foreach (IStorage storageObject in storageObjects)
			{
				storageObject.SetPriority(priority);
			}
		}

		private void OnHitpointsSliderMouseUp(float low, float high)
		{
			OnHitpointsSliderDrag(low, high);
			foreach (IStorage storageObject in storageObjects)
			{
				storageObject.SetHitPointsPercent(new IntRange((int)(low * 100f), (int)(high * 100f)));
			}
		}

		private void OnHitpointsSliderDrag(float low, float high)
		{
			string formattedRange = $"{Mathf.Round(low * 100f)}% -  {Mathf.Round(high * 100f)}%";
			hitpointsSliderGroup.SetSliderData("hit_points", formattedRange);
		}

		private void OnQualitySliderMouseUp(float low, float high)
		{
			OnQualitySliderDrag(low, high);
			foreach (IStorage storageObject in storageObjects)
			{
				storageObject.SetQuality(new IntRange((int)low, (int)high));
			}
		}

		private void OnQualitySliderDrag(float low, float high)
		{
			string formattedRange = MonoSingleton<LocalizationController>.Instance.GetText($"quality_{(ProductQuality)low}") + " - " + MonoSingleton<LocalizationController>.Instance.GetText($"quality_{(ProductQuality)high}");
			itemQualitySliderGroup.SetSliderData("quality", formattedRange);
		}

		private void OnForbidUseInProductionClick(bool state)
		{
			forbidUseInProductionToggle.isOn = state;
			foreach (IStorage storageObject in storageObjects)
			{
				storageObject.SetCanBeUsedInProduction(state);
			}
		}

		private void OnSelectAllClick()
		{
			SetUpGroupsAllowed(allowed: true);
			SetResourcesAllowed(allowed: true);
		}

		private void OnClearAllClick()
		{
			SetUpGroupsAllowed(allowed: false);
			SetResourcesAllowed(allowed: false);
		}

		private void OnGroupExpansion()
		{
			if (resourcesListParent != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(resourcesListParent.transform as RectTransform);
			}
		}

		private void OnNameEdit(string value)
		{
			if (storageObjects == null)
			{
				return;
			}
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			foreach (IStorage storageObject in storageObjects)
			{
				storageObject.SetName(value);
			}
		}
	}
}
