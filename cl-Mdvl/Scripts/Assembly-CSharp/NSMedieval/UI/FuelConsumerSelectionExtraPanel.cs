using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class FuelConsumerSelectionExtraPanel : SelectionExtraWindowView
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
		}

		[SerializeField]
		private LayoutGroupView resourcesListParent;

		[SerializeField]
		private SoundButton copyButton;

		[SerializeField]
		private SoundButton pasteButton;

		[SerializeField]
		private SoundButton selectAllButton;

		[SerializeField]
		private SoundButton clearAllButton;

		[SerializeField]
		private TMP_Dropdown priorityDropdown;

		[SerializeField]
		private GameObject intensityObjects;

		[SerializeField]
		private TMP_Dropdown intensityDropdown;

		[SerializeField]
		private TMP_Text fuelRemainingText;

		[SerializeField]
		private TMP_Text priorityText;

		[SerializeField]
		private TMP_Text intensityText;

		private List<ResourceGroups> allResourceGroups;

		private Dictionary<string, TreeInfo> cachedTreeInfo = new Dictionary<string, TreeInfo>();

		private Dictionary<ResourceGroups, List<ResourceGroups>> groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>();

		private Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>();

		private Dictionary<ResourceGroups, List<Resource>> resourceParents = new Dictionary<ResourceGroups, List<Resource>>();

		private Dictionary<Resource, ResourceToggleItemView> resources = new Dictionary<Resource, ResourceToggleItemView>();

		private Dictionary<string, List<Resource>> resourcesWithQuality = new Dictionary<string, List<Resource>>();

		private List<FuelConsumerComponentInstance> fuelConsumers;

		private Dictionary<string, List<FuelConsumerComponentInstance>> fuelConsumersByTypeDictionary;

		private HashSet<ResourceGroups> commonResourceGroups;

		private HashSet<Resource> mutualAllowedResources;

		private string selectionId = string.Empty;

		public void UpdatePanel(InfoPanelFuelConsumer infoPanelStockpile)
		{
			if (fuelConsumers != null)
			{
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					if (fuelConsumer != null)
					{
						fuelConsumer.FuelAddedEvent -= OnFuelAdded;
						fuelConsumer.FuelConsumedEvent -= OnFuelConsumed;
					}
				}
			}
			fuelConsumers = infoPanelStockpile.FuelConsumerComponentInstances;
			if (fuelConsumers == null || fuelConsumers.Count == 0 || fuelConsumers.All((FuelConsumerComponentInstance x) => x.HasDisposed))
			{
				Hide();
				return;
			}
			pasteButton.interactable = MonoSingleton<FuelDeliveryManager>.Instance.FuelConsumerCopySettingsData != null;
			fuelConsumersByTypeDictionary = GetFuelConsumersByTypeDictionary();
			mutualAllowedResources = new HashSet<Resource>();
			mutualAllowedResources.UnionWith(GetMutualAllowedResources(fuelConsumersByTypeDictionary.Values.SelectMany((List<FuelConsumerComponentInstance> x) => x.Where((FuelConsumerComponentInstance y) => y != null && !y.HasDisposed))));
			commonResourceGroups = GetMutualResourceGroups();
			string text = ((fuelConsumers.Count == 1) ? fuelConsumers.First().BaseBuildingBlueprint.GetID() : GetCombinedIds());
			if (selectionId == text)
			{
				RefreshTree();
				RefreshFuelUI();
				if (fuelConsumers.Count == 1)
				{
					AddCallbacks();
				}
				return;
			}
			ResetGroups();
			SetupGroups();
			RefreshTree();
			RefreshFuelUI();
			if (fuelConsumers.Count == 1)
			{
				AddCallbacks();
			}
			void AddCallbacks()
			{
				FuelConsumerComponentInstance fuelConsumerComponentInstance = fuelConsumers.First();
				fuelConsumerComponentInstance.FuelAddedEvent += OnFuelAdded;
				fuelConsumerComponentInstance.FuelConsumedEvent += OnFuelConsumed;
			}
		}

		public override void Hide()
		{
			if (fuelConsumers != null && fuelConsumers.Count == 1)
			{
				FuelConsumerComponentInstance fuelConsumerComponentInstance = fuelConsumers.First();
				if (fuelConsumerComponentInstance != null)
				{
					fuelConsumerComponentInstance.FuelAddedEvent -= OnFuelAdded;
					fuelConsumerComponentInstance.FuelConsumedEvent -= OnFuelConsumed;
				}
			}
			EventSystem.current.SetSelectedGameObject(null);
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
			base.Hide();
			fuelConsumers?.Clear();
		}

		private Dictionary<string, List<FuelConsumerComponentInstance>> GetFuelConsumersByTypeDictionary()
		{
			Dictionary<string, List<FuelConsumerComponentInstance>> dictionary = new Dictionary<string, List<FuelConsumerComponentInstance>>();
			foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
			{
				string iD = fuelConsumer.Blueprint.GetID();
				if (!dictionary.ContainsKey(iD))
				{
					dictionary.Add(iD, new List<FuelConsumerComponentInstance>());
				}
				dictionary[iD].Add(fuelConsumer);
			}
			return dictionary;
		}

		private IEnumerable<Resource> GetMutualAllowedResources(IEnumerable<FuelConsumerComponentInstance> sameTypeFuelConsumers)
		{
			if (sameTypeFuelConsumers.Count() == 0)
			{
				return new List<Resource>();
			}
			IEnumerable<Resource> enumerable = sameTypeFuelConsumers.First().ResourcesFilter.AllowedResourceTypes;
			foreach (FuelConsumerComponentInstance item in sameTypeFuelConsumers.Skip(1))
			{
				if (item != null && !item.HasDisposed)
				{
					enumerable = enumerable.Intersect(item.ResourcesFilter.AllowedResourceTypes);
				}
			}
			return enumerable;
		}

		private HashSet<ResourceGroups> GetMutualResourceGroups()
		{
			HashSet<ResourceGroups> hashSet = new HashSet<ResourceGroups>();
			FuelConsumerComponentInstance fuelConsumerComponentInstance = fuelConsumers.FirstOrDefault((FuelConsumerComponentInstance x) => !x.HasDisposed);
			if (fuelConsumerComponentInstance == null)
			{
				return hashSet;
			}
			hashSet.UnionWith(fuelConsumerComponentInstance.ResourceGroups);
			foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
			{
				if (!fuelConsumer.HasDisposed && fuelConsumer != fuelConsumerComponentInstance)
				{
					hashSet.IntersectWith(fuelConsumer.ResourceGroups);
				}
			}
			return hashSet;
		}

		private void RefreshFuelUI()
		{
			if (fuelConsumers == null || fuelConsumers.Count > 1)
			{
				fuelRemainingText.SetText("-");
				return;
			}
			FuelConsumerComponentInstance fuelConsumerComponentInstance = fuelConsumers.First();
			string timeFormatByHours = UiUtils.GetTimeFormatByHours(fuelConsumerComponentInstance.CurrentCalories / fuelConsumerComponentInstance.BurnRate, isDuration: true);
			float requiredCalories = fuelConsumerComponentInstance.Blueprint.RequiredCalories;
			int num = (int)(fuelConsumerComponentInstance.CurrentCalories / requiredCalories * 100f);
			fuelRemainingText.SetText((timeFormatByHours == string.Empty) ? string.Format("{0}: <style=AltColor>{1}%</style>", MonoSingleton<LocalizationController>.Instance.GetText("fuel_type"), num) : string.Format("{0}: <style=AltColor>{1}%</style> ({2})", MonoSingleton<LocalizationController>.Instance.GetText("fuel_type"), num, timeFormatByHours));
		}

		private void OnFuelAdded()
		{
			RefreshFuelUI();
		}

		private void OnFuelConsumed()
		{
			RefreshFuelUI();
		}

		private void RefreshTree()
		{
			if (fuelConsumers == null || fuelConsumers.Count == 0)
			{
				return;
			}
			if (fuelConsumers.Count > 1)
			{
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource in resources)
				{
					resource.Value.GroupSelectToggle.SetIsOnWithoutNotify(mutualAllowedResources.Contains(resource.Key));
					UpdateResourceParentSelection(resource.Key);
				}
				bool flag = fuelConsumers.Any((FuelConsumerComponentInstance x) => x.Blueprint.CachedThermalModels.Count > 2);
				intensityObjects.SetActive(flag);
				if (flag)
				{
					intensityDropdown.SetValueWithoutNotify((int)(fuelConsumers.Last().ThermalModelIntensity - 1));
				}
			}
			else
			{
				FuelConsumerComponentInstance fuelConsumerComponentInstance = fuelConsumers.First();
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource2 in resources)
				{
					resource2.Value.GroupSelectToggle.isOn = fuelConsumerComponentInstance.ResourcesFilter.IsBlueprintAllowed(resource2.Key);
				}
				if (fuelConsumerComponentInstance.Blueprint.CachedThermalModels.Count > 2)
				{
					intensityDropdown.SetValueWithoutNotify((int)(fuelConsumerComponentInstance.ThermalModelIntensity - 1));
					intensityObjects.SetActive(value: true);
				}
				else
				{
					intensityObjects.SetActive(value: false);
				}
			}
			priorityDropdown.SetValueWithoutNotify((int)fuelConsumers.Last().RefuelPriority);
			OnGroupExpansion();
			Show();
		}

		private void OnGroupToggleChange(ResourceGroups group, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				if (fuelConsumers != null)
				{
					UpdateGroupChildren(group, value);
				}
			});
		}

		private void OnResourceToggleChange(Resource resource, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool allowed)
			{
				if (fuelConsumers == null)
				{
					return;
				}
				resources[resource].SetSelected(allowed);
				UpdateResourceParentSelection(resource);
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					if (fuelConsumer.ResourcesFilter.DefaultAllowedResources.Contains(resource))
					{
						fuelConsumer.AllowFuel(resource, allowed);
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
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					if (fuelConsumer.ResourcesFilter.DefaultAllowedResources.Contains(item))
					{
						fuelConsumer.AllowFuel(item, allowed);
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
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					fuelConsumer.AllowFuel(item, allowed);
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

		private void OnDisable()
		{
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= OnGroupExpansion;
			}
		}

		private void OnEnable()
		{
			MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent += OnGroupExpansion;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= OnGroupExpansion;
			}
		}

		public override void Initialize()
		{
			selectAllButton.onClick.AddListener(OnSelectAllClick);
			clearAllButton.onClick.AddListener(OnClearAllClick);
			SetupPriorityDropdown();
			SetupThermalModelDropdown();
			base.Initialize();
			copyButton.onClick.AddListener(delegate
			{
				MonoSingleton<FuelDeliveryManager>.Instance.SetFuelConsumerCopyFilter(new FuelConsumerCopySettingsData(fuelConsumers.First()));
				pasteButton.interactable = true;
			});
			pasteButton.onClick.AddListener(delegate
			{
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					fuelConsumer.PasteFuelConsumerSettings(MonoSingleton<FuelDeliveryManager>.Instance.FuelConsumerCopySettingsData);
				}
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					fuelConsumersByTypeDictionary = GetFuelConsumersByTypeDictionary();
					mutualAllowedResources = new HashSet<Resource>();
					mutualAllowedResources.UnionWith(GetMutualAllowedResources(fuelConsumersByTypeDictionary.Values.SelectMany((List<FuelConsumerComponentInstance> x) => x.Where((FuelConsumerComponentInstance y) => y != null && !y.HasDisposed))));
					commonResourceGroups = GetMutualResourceGroups();
					ResetGroups();
					SetupGroups();
					RefreshTree();
					RefreshFuelUI();
				});
			});
		}

		private void SetupPriorityDropdown()
		{
			priorityText.text += ":";
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

		private void SetupThermalModelDropdown()
		{
			intensityText.text += ":";
			List<string> list = new List<string>();
			ThermalModelIntensity[] thermalModelIntensities = EnumValues.ThermalModelIntensities;
			for (int i = 0; i < thermalModelIntensities.Length; i++)
			{
				ThermalModelIntensity thermalModelIntensity = thermalModelIntensities[i];
				if (thermalModelIntensity != ThermalModelIntensity.Off)
				{
					string text = thermalModelIntensity.ToString();
					text = "general_" + char.ToLower(text[0]) + text.Substring(1);
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text));
				}
			}
			intensityDropdown.AddOptions(list);
			intensityDropdown.onValueChanged.AddListener(delegate
			{
				OnThermalModelChange();
			});
		}

		private void SetupGroups()
		{
			if (fuelConsumers.Count == 1)
			{
				SetupGroupsSingleFuelConsumerSelected(fuelConsumers.First());
			}
			else
			{
				SetupGroupsMultipleFuelConsumersSelected();
			}
		}

		private void SetupGroupsSingleFuelConsumerSelected(FuelConsumerComponentInstance fuelConsumer)
		{
			selectionId = fuelConsumer.BaseBuildingBlueprint.GetID();
			if (cachedTreeInfo.ContainsKey(selectionId))
			{
				TreeInfo treeInfo = cachedTreeInfo[selectionId];
				resources = new Dictionary<Resource, ResourceToggleItemView>(treeInfo.Resources);
				resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(treeInfo.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(treeInfo.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(treeInfo.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(treeInfo.ResourcesWithQuality);
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
			TreeInfo treeInfo2 = new TreeInfo();
			cachedTreeInfo.Add(selectionId, treeInfo2);
			if (allResourceGroups == null || allResourceGroups.Count == 0)
			{
				allResourceGroups = new List<ResourceGroups>();
				allResourceGroups.AddRange(Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.GetByID("all_resource_groups").ResourceGroups);
			}
			foreach (ResourceGroups allResourceGroup in allResourceGroups)
			{
				if (fuelConsumer.ResourceGroups.Contains(allResourceGroup))
				{
					resourceGroups.Add(allResourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
				}
			}
			treeInfo2.SetResourceGroups(resourceGroups);
			foreach (ResourceGroups allResourceGroup2 in allResourceGroups)
			{
				if (!fuelConsumer.ResourceGroups.Contains(allResourceGroup2))
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
							goto end_IL_0336;
						}
					}
					continue;
					end_IL_0336:
					break;
				}
				resourceGroups[allResourceGroup2].transform.SetParent(parent);
				resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, resourceGroups[allResourceGroup2]);
				AddGroupResources(allResourceGroup2);
			}
			treeInfo2.SetGroupParents(groupParents);
			treeInfo2.SetResourcesWithQuality(resourcesWithQuality);
			treeInfo2.SetResources(resources);
			treeInfo2.SetResourceParents(resourceParents);
		}

		private string GetCombinedIds()
		{
			List<string> list = new List<string>();
			list.AddRange(fuelConsumersByTypeDictionary.Keys.OrderByDescending((string x) => x));
			return string.Join("_", list);
		}

		private void SetupGroupsMultipleFuelConsumersSelected()
		{
			selectionId = GetCombinedIds();
			if (cachedTreeInfo.ContainsKey(selectionId))
			{
				TreeInfo treeInfo = cachedTreeInfo[selectionId];
				resources = new Dictionary<Resource, ResourceToggleItemView>(treeInfo.Resources);
				resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(treeInfo.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(treeInfo.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(treeInfo.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(treeInfo.ResourcesWithQuality);
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
			TreeInfo treeInfo2 = new TreeInfo();
			cachedTreeInfo.Add(selectionId, treeInfo2);
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
			treeInfo2.SetResourceGroups(resourceGroups);
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
							goto end_IL_0340;
						}
					}
					continue;
					end_IL_0340:
					break;
				}
				resourceGroups[allResourceGroup2].transform.SetParent(parent);
				resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, resourceGroups[allResourceGroup2]);
				AddGroupResources(allResourceGroup2);
			}
			treeInfo2.SetGroupParents(groupParents);
			treeInfo2.SetResourcesWithQuality(resourcesWithQuality);
			treeInfo2.SetResources(resources);
			treeInfo2.SetResourceParents(resourceParents);
		}

		private void ResetGroups()
		{
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
						List<Resource> value = new List<Resource>();
						if (resourcesWithQuality.TryGetValue(allItem.GroupIdentifier, out value))
						{
							value.Add(allItem);
							resourcesWithQuality[allItem.GroupIdentifier] = value;
						}
						continue;
					}
					resourcesWithQuality.Add(allItem.GroupIdentifier, new List<Resource>());
					nameKey = allItem.GroupIdentifier;
				}
				foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
				{
					if (fuelConsumer.ResourcesFilter.DefaultAllowedResources.Contains(allItem) && !resources.ContainsKey(allItem))
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
		}

		private void OnPriorityChanged()
		{
			ZonePriority value = (ZonePriority)priorityDropdown.value;
			foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
			{
				fuelConsumer.SetRefuelPriority(value);
			}
		}

		private void OnThermalModelChange()
		{
			ThermalModelIntensity burnIntensity = (ThermalModelIntensity)(intensityDropdown.value + 1);
			foreach (FuelConsumerComponentInstance fuelConsumer in fuelConsumers)
			{
				if (fuelConsumer.Blueprint.CachedThermalModels.Count > 2)
				{
					fuelConsumer.SetBurnIntensity(burnIntensity);
				}
			}
			RefreshFuelUI();
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
	}
}
