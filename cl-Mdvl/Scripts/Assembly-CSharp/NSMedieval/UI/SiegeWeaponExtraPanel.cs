using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Stockpiles;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class SiegeWeaponExtraPanel : SelectionExtraWindowView
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
		private TMP_InputField siegeWeaponName;

		[SerializeField]
		private LayoutGroupView resourcesListParent;

		[SerializeField]
		private SoundButton copyButton;

		[SerializeField]
		private SoundButton pasteButton;

		private List<ResourceGroups> allResourceGroups;

		private Dictionary<string, TreeInfo> cachedTreeInfo = new Dictionary<string, TreeInfo>();

		private Dictionary<ResourceGroups, List<ResourceGroups>> groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>();

		private Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>();

		private Dictionary<ResourceGroups, List<Resource>> resourceParents = new Dictionary<ResourceGroups, List<Resource>>();

		private Dictionary<Resource, ResourceToggleItemView> resources = new Dictionary<Resource, ResourceToggleItemView>();

		private Dictionary<string, List<Resource>> resourcesWithQuality = new Dictionary<string, List<Resource>>();

		private List<SiegeWeaponComponentInstance> siegeWeaponComponentInstances;

		private Dictionary<string, List<SiegeWeaponComponentInstance>> siegeWeaponInstancesByTypeDictionary;

		private HashSet<ResourceGroups> commonResourceGroups;

		private HashSet<Resource> mutualAllowedResources;

		private string selectionId = string.Empty;

		public void UpdatePanel(InfoPanelSiegeWeapon infoPanelStockpile)
		{
			siegeWeaponComponentInstances = infoPanelStockpile.SiegeWeaponComponentInstances;
			if (siegeWeaponComponentInstances == null || siegeWeaponComponentInstances.Count == 0 || siegeWeaponComponentInstances.All((SiegeWeaponComponentInstance x) => x.HasDisposed))
			{
				Hide();
				return;
			}
			if (siegeWeaponComponentInstances.Count == 1)
			{
				SiegeWeaponComponentInstance siegeWeaponComponentInstance = siegeWeaponComponentInstances.FirstOrDefault();
				siegeWeaponComponentInstance?.Map.SiegeWeaponComponentManager.ShowSiegeWeaponsRange(visible: false);
				siegeWeaponComponentInstance?.ShowRange(visible: true);
			}
			else
			{
				VillageManager.ActiveVillage.Map.SiegeWeaponComponentManager.ShowSiegeWeaponsRange(visible: false);
			}
			pasteButton.interactable = siegeWeaponComponentInstances.First().Map.SiegeWeaponComponentManager.SiegeWeaponCopySettingsData != null;
			siegeWeaponInstancesByTypeDictionary = GetSiegeWeaponsByTypeDictionary();
			mutualAllowedResources = new HashSet<Resource>();
			mutualAllowedResources.UnionWith(GetMutualAllowedResources(siegeWeaponInstancesByTypeDictionary.Values.SelectMany((List<SiegeWeaponComponentInstance> x) => x.Where((SiegeWeaponComponentInstance y) => y != null && !y.HasDisposed))));
			commonResourceGroups = GetMutualResourceGroups();
			string text = ((siegeWeaponComponentInstances.Count == 1) ? siegeWeaponComponentInstances.First().BaseBuildingBlueprint.GetID() : GetCombinedIds());
			if (selectionId == text)
			{
				RefreshTree();
				_ = siegeWeaponComponentInstances.Count;
				_ = 1;
			}
			else
			{
				ResetGroups();
				SetupGroups();
				RefreshTree();
			}
		}

		public override void Hide()
		{
			VillageManager.ActiveVillage?.Map?.SiegeWeaponComponentManager?.ShowSiegeWeaponsRange(visible: false);
			EventSystem.current.SetSelectedGameObject(null);
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
			base.Hide();
			siegeWeaponComponentInstances?.Clear();
		}

		private Dictionary<string, List<SiegeWeaponComponentInstance>> GetSiegeWeaponsByTypeDictionary()
		{
			Dictionary<string, List<SiegeWeaponComponentInstance>> dictionary = new Dictionary<string, List<SiegeWeaponComponentInstance>>();
			foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
			{
				string iD = siegeWeaponComponentInstance.Blueprint.GetID();
				if (!dictionary.ContainsKey(iD))
				{
					dictionary.Add(iD, new List<SiegeWeaponComponentInstance>());
				}
				dictionary[iD].Add(siegeWeaponComponentInstance);
			}
			return dictionary;
		}

		private IEnumerable<Resource> GetMutualAllowedResources(IEnumerable<SiegeWeaponComponentInstance> sameTypeSiegeWeapons)
		{
			if (!sameTypeSiegeWeapons.Any())
			{
				return new List<Resource>();
			}
			IEnumerable<Resource> enumerable = sameTypeSiegeWeapons.First().ResourcesFilter.AllowedResourceTypes;
			foreach (SiegeWeaponComponentInstance item in sameTypeSiegeWeapons.Skip(1))
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
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = siegeWeaponComponentInstances.FirstOrDefault((SiegeWeaponComponentInstance x) => !x.HasDisposed);
			if (siegeWeaponComponentInstance == null)
			{
				return hashSet;
			}
			hashSet.UnionWith(siegeWeaponComponentInstance.ResourceGroups);
			foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance2 in siegeWeaponComponentInstances)
			{
				if (!siegeWeaponComponentInstance2.HasDisposed && siegeWeaponComponentInstance2 != siegeWeaponComponentInstance)
				{
					hashSet.IntersectWith(siegeWeaponComponentInstance2.ResourceGroups);
				}
			}
			return hashSet;
		}

		private void RefreshTree()
		{
			if (siegeWeaponComponentInstances == null)
			{
				return;
			}
			if (siegeWeaponComponentInstances.Count > 1)
			{
				siegeWeaponName.SetTextWithoutNotify("-");
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource in resources)
				{
					resource.Value.GroupSelectToggle.SetIsOnWithoutNotify(mutualAllowedResources.Contains(resource.Key));
					UpdateResourceParentSelection(resource.Key);
				}
			}
			else
			{
				SiegeWeaponComponentInstance siegeWeaponComponentInstance = siegeWeaponComponentInstances.First();
				siegeWeaponName.SetTextWithoutNotify(siegeWeaponComponentInstance.SiegeWeaponName);
				foreach (KeyValuePair<Resource, ResourceToggleItemView> resource2 in resources)
				{
					resource2.Value.GroupSelectToggle.isOn = siegeWeaponComponentInstance.ResourcesFilter.IsBlueprintAllowed(resource2.Key);
				}
			}
			OnGroupExpansion();
			Show();
		}

		private void OnGroupToggleChange(ResourceGroups group, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				if (siegeWeaponComponentInstances != null)
				{
					UpdateGroupChildren(group, value);
				}
			});
		}

		private void OnResourceToggleChange(Resource resource, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool allowed)
			{
				if (siegeWeaponComponentInstances == null)
				{
					return;
				}
				resources[resource].SetSelected(allowed);
				UpdateResourceParentSelection(resource);
				foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
				{
					if (siegeWeaponComponentInstance.ResourcesFilter.DefaultAllowedResources.Contains(resource))
					{
						siegeWeaponComponentInstance.AllowResource(resource, allowed);
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
				foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
				{
					if (siegeWeaponComponentInstance.ResourcesFilter.DefaultAllowedResources.Contains(item))
					{
						siegeWeaponComponentInstance.AllowResource(item, allowed);
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
			resourcesWithQuality[resource.GroupIdentifier].ForEach(delegate(Resource item)
			{
				foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
				{
					siegeWeaponComponentInstance.AllowResource(item, allowed);
				}
			});
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
			base.Initialize();
			copyButton.onClick.AddListener(delegate
			{
				VillageMap map = VillageManager.ActiveVillage.Map;
				if (map != null)
				{
					map.SiegeWeaponComponentManager.SetSiegeWeaponCopyFilter(new SiegeWeaponCopySettingsData(siegeWeaponComponentInstances.First()));
					pasteButton.interactable = true;
				}
			});
			pasteButton.onClick.AddListener(delegate
			{
				VillageMap map = VillageManager.ActiveVillage.Map;
				if (map != null)
				{
					foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
					{
						siegeWeaponComponentInstance.PasteSettings(map.SiegeWeaponComponentManager.SiegeWeaponCopySettingsData);
					}
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						siegeWeaponInstancesByTypeDictionary = GetSiegeWeaponsByTypeDictionary();
						mutualAllowedResources = new HashSet<Resource>();
						mutualAllowedResources.UnionWith(GetMutualAllowedResources(siegeWeaponInstancesByTypeDictionary.Values.SelectMany((List<SiegeWeaponComponentInstance> x) => x.Where((SiegeWeaponComponentInstance y) => y != null && !y.HasDisposed))));
						commonResourceGroups = GetMutualResourceGroups();
						ResetGroups();
						SetupGroups();
						RefreshTree();
					});
				}
			});
			siegeWeaponName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			siegeWeaponName.onDeselect.AddListener(OnNameEdit);
			siegeWeaponName.onEndEdit.AddListener(OnNameEdit);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= OnGroupExpansion;
			}
			allResourceGroups.Clear();
			siegeWeaponInstancesByTypeDictionary.Clear();
			siegeWeaponComponentInstances.Clear();
			commonResourceGroups.Clear();
			mutualAllowedResources.Clear();
			cachedTreeInfo = null;
			groupParents = null;
			resourceGroups = null;
			resourceParents = null;
			resources = null;
			resourcesWithQuality = null;
			siegeWeaponComponentInstances = null;
			siegeWeaponInstancesByTypeDictionary = null;
			base.OnDestroy();
		}

		private void SetupGroups()
		{
			if (siegeWeaponComponentInstances.Count == 1)
			{
				SetupGroupsSingleSiegeWeaponSelected(siegeWeaponComponentInstances.First());
			}
			else
			{
				SetupGroupsMultipleSiegeWeaponsSelected();
			}
		}

		private void SetupGroupsSingleSiegeWeaponSelected(SiegeWeaponComponentInstance siegeWeaponInstance)
		{
			selectionId = siegeWeaponInstance.BaseBuildingBlueprint.GetID();
			if (cachedTreeInfo.ContainsKey(selectionId))
			{
				TreeInfo treeInfo = cachedTreeInfo[selectionId];
				resources = new Dictionary<Resource, ResourceToggleItemView>(treeInfo.Resources);
				this.resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(treeInfo.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(treeInfo.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(treeInfo.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(treeInfo.ResourcesWithQuality);
				ResourceGroups[] array = this.resourceGroups.Keys.ToArray();
				foreach (ResourceGroups resourceGroups in array)
				{
					if (resourceGroups.Depth != 0)
					{
						this.resourceGroups[resourceGroups].SetExpanded(groupExpanded: false);
						this.resourceGroups[resourceGroups].RotateToggleSprite();
						this.resourceGroups[resourceGroups].UpdateChildren();
					}
					else
					{
						this.resourceGroups[resourceGroups].gameObject.SetActive(value: true);
						this.resourceGroups[resourceGroups].SetExpanded(groupExpanded: false);
						this.resourceGroups[resourceGroups].RotateToggleSprite();
						this.resourceGroups[resourceGroups].UpdateChildren();
					}
				}
				return;
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
				if (siegeWeaponInstance.ResourceGroups.Contains(allResourceGroup))
				{
					this.resourceGroups.Add(allResourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
				}
			}
			treeInfo2.SetResourceGroups(this.resourceGroups);
			foreach (ResourceGroups allResourceGroup2 in allResourceGroups)
			{
				if (!siegeWeaponInstance.ResourceGroups.Contains(allResourceGroup2))
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
							parent = this.resourceGroups[allResourceGroup3].transform;
							this.resourceGroups[allResourceGroup3].AddChild(this.resourceGroups[allResourceGroup2]);
							if (!groupParents.ContainsKey(allResourceGroup3))
							{
								groupParents.Add(allResourceGroup3, new List<ResourceGroups>());
							}
							groupParents[allResourceGroup3].Add(allResourceGroup2);
							nameKey = subGroupID;
							goto end_IL_032e;
						}
					}
					continue;
					end_IL_032e:
					break;
				}
				this.resourceGroups[allResourceGroup2].transform.SetParent(parent);
				this.resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				this.resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, this.resourceGroups[allResourceGroup2]);
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
			list.AddRange(siegeWeaponInstancesByTypeDictionary.Keys.OrderByDescending((string x) => x));
			return string.Join("_", list);
		}

		private void SetupGroupsMultipleSiegeWeaponsSelected()
		{
			selectionId = GetCombinedIds();
			if (cachedTreeInfo.ContainsKey(selectionId))
			{
				TreeInfo treeInfo = cachedTreeInfo[selectionId];
				resources = new Dictionary<Resource, ResourceToggleItemView>(treeInfo.Resources);
				this.resourceGroups = new Dictionary<ResourceGroups, ResourceToggleItemView>(treeInfo.ResourceGroups);
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>(treeInfo.GroupParents);
				resourceParents = new Dictionary<ResourceGroups, List<Resource>>(treeInfo.ResourceParents);
				resourcesWithQuality = new Dictionary<string, List<Resource>>(treeInfo.ResourcesWithQuality);
				ResourceGroups[] array = this.resourceGroups.Keys.ToArray();
				foreach (ResourceGroups resourceGroups in array)
				{
					if (resourceGroups.Depth != 0)
					{
						this.resourceGroups[resourceGroups].SetExpanded(groupExpanded: false);
						this.resourceGroups[resourceGroups].RotateToggleSprite();
						this.resourceGroups[resourceGroups].UpdateChildren();
					}
					else
					{
						this.resourceGroups[resourceGroups].gameObject.SetActive(value: true);
						this.resourceGroups[resourceGroups].SetExpanded(groupExpanded: false);
						this.resourceGroups[resourceGroups].RotateToggleSprite();
						this.resourceGroups[resourceGroups].UpdateChildren();
					}
				}
				return;
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
				if (commonResourceGroups.Contains(allResourceGroup) && !this.resourceGroups.ContainsKey(allResourceGroup))
				{
					this.resourceGroups.Add(allResourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
				}
			}
			treeInfo2.SetResourceGroups(this.resourceGroups);
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
							parent = this.resourceGroups[allResourceGroup3].transform;
							this.resourceGroups[allResourceGroup3].AddChild(this.resourceGroups[allResourceGroup2]);
							if (!groupParents.ContainsKey(allResourceGroup3))
							{
								groupParents.Add(allResourceGroup3, new List<ResourceGroups>());
							}
							groupParents[allResourceGroup3].Add(allResourceGroup2);
							nameKey = subGroupID;
							goto end_IL_0338;
						}
					}
					continue;
					end_IL_0338:
					break;
				}
				this.resourceGroups[allResourceGroup2].transform.SetParent(parent);
				this.resourceGroups[allResourceGroup2].gameObject.name = nameKey;
				this.resourceGroups[allResourceGroup2].SetupGroup(nameKey, "group", allResourceGroup2.Depth);
				OnGroupToggleChange(allResourceGroup2, this.resourceGroups[allResourceGroup2]);
				AddGroupResources(allResourceGroup2);
			}
			treeInfo2.SetGroupParents(groupParents);
			treeInfo2.SetResourcesWithQuality(resourcesWithQuality);
			treeInfo2.SetResources(resources);
			treeInfo2.SetResourceParents(resourceParents);
		}

		private void ResetGroups()
		{
			ResourceGroups[] array = resourceGroups.Keys.ToArray();
			foreach (ResourceGroups key in array)
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
				foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
				{
					if (siegeWeaponComponentInstance.ResourcesFilter.DefaultAllowedResources.Contains(allItem) && !resources.ContainsKey(allItem))
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

		private void OnGroupExpansion()
		{
			if (resourcesListParent != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(resourcesListParent.transform as RectTransform);
			}
		}

		private void OnNameEdit(string value)
		{
			if (siegeWeaponComponentInstances == null)
			{
				return;
			}
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			foreach (SiegeWeaponComponentInstance siegeWeaponComponentInstance in siegeWeaponComponentInstances)
			{
				siegeWeaponComponentInstance.SetName(value);
			}
		}
	}
}
