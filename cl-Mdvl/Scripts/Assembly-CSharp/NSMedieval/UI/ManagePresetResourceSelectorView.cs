using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ManagePresetResourceSelectorView : MonoBehaviour
	{
		public class SelectionChangedEventInfo
		{
			public readonly List<string> AllowedResources = new List<string>();

			public readonly List<string> ForbiddenResources = new List<string>();
		}

		private ManageGroupPreset currentPreset;

		private ManageGroup manageGroup;

		[SerializeField]
		private LayoutGroupView scrollViewParent;

		private List<GameObject> currentRootObjects;

		private Dictionary<ResourceGroups, List<ResourceGroups>> groupParents;

		private Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroupPairs;

		private Dictionary<ResourceGroups, HashSet<Resource>> resourceParents;

		private Dictionary<string, HashSet<Resource>> resourcesWithQuality;

		private Dictionary<Resource, ResourceToggleItemView> resourcePairs;

		private SelectionChangedEventInfo selectionChangedEventInfo;

		private List<string> presetAllowedResources;

		private List<string> presetForbiddenResources;

		public Dictionary<Resource, ResourceToggleItemView> ResourcePairs => resourcePairs;

		public event Action NotifyLockedEvent;

		public event Action<SelectionChangedEventInfo> SelectionChangedEvent;

		public void Setup(ManageGroupPreset preset, List<string> allowedResources, List<string> forbiddenResources)
		{
			currentPreset = preset;
			manageGroup = preset.GetManageGroup();
			presetAllowedResources = allowedResources;
			presetForbiddenResources = forbiddenResources;
			if (currentRootObjects == null)
			{
				currentRootObjects = new List<GameObject>();
			}
			if (groupParents == null)
			{
				groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>();
			}
			if (resourceGroupPairs == null)
			{
				resourceGroupPairs = new Dictionary<ResourceGroups, ResourceToggleItemView>();
			}
			if (resourcePairs == null)
			{
				resourcePairs = new Dictionary<Resource, ResourceToggleItemView>();
			}
			if (resourceParents == null)
			{
				resourceParents = new Dictionary<ResourceGroups, HashSet<Resource>>();
			}
			if (resourcesWithQuality == null)
			{
				resourcesWithQuality = new Dictionary<string, HashSet<Resource>>();
			}
			if (selectionChangedEventInfo == null)
			{
				selectionChangedEventInfo = new SelectionChangedEventInfo();
			}
			resourceParents.Clear();
			resourcePairs.Clear();
			resourcesWithQuality.Clear();
			resourceGroupPairs.Clear();
			groupParents.Clear();
			currentRootObjects.Clear();
			foreach (ResourceGroups resourceGroup in manageGroup.ResourceGroups)
			{
				resourceGroupPairs.Add(resourceGroup, UnityEngine.Object.Instantiate(scrollViewParent.Prefab, scrollViewParent.transform).GetComponent<ResourceToggleItemView>());
			}
			foreach (ResourceGroups resourceGroup2 in manageGroup.ResourceGroups)
			{
				if (resourceGroup2.Depth == 0)
				{
					resourceGroupPairs[resourceGroup2].transform.SetParent(scrollViewParent.transform);
					currentRootObjects.Add(resourceGroupPairs[resourceGroup2].gameObject);
				}
				foreach (string subGroupID in resourceGroup2.SubGroupIDs)
				{
					ResourceGroups resourceGroups = manageGroup.ResourceGroups.FirstOrDefault((ResourceGroups item) => item.GetID() == subGroupID);
					resourceGroupPairs[resourceGroup2].AddChild(resourceGroupPairs[resourceGroups]);
					resourceGroupPairs[resourceGroups].transform.SetParent(resourceGroupPairs[resourceGroup2].transform);
					if (!groupParents.ContainsKey(resourceGroup2))
					{
						groupParents.Add(resourceGroup2, new List<ResourceGroups>());
					}
					groupParents[resourceGroup2].Add(resourceGroups);
				}
				resourceGroupPairs[resourceGroup2].gameObject.name = resourceGroup2.GetID();
				resourceGroupPairs[resourceGroup2].SetupGroup(resourceGroup2.GetID(), "group", resourceGroup2.Depth);
				OnGroupToggleChange(resourceGroup2, resourceGroupPairs[resourceGroup2]);
				AddGroupResources(resourceGroup2);
			}
			ChangeToPreset(currentPreset, presetAllowedResources, presetForbiddenResources);
		}

		public void OnHide()
		{
			currentRootObjects.ForEach(UnityEngine.Object.Destroy);
		}

		public void SelectAll()
		{
			SetUpGroupsAllowed(allowed: true);
			SetResourcesAllowed(allowed: true);
		}

		public void ClearAll()
		{
			SetUpGroupsAllowed(allowed: false);
			SetResourcesAllowed(allowed: false);
		}

		public void ChangeToPreset(ManageGroupPreset preset, List<string> allowedResources, List<string> forbiddenResources)
		{
			currentPreset = preset;
			manageGroup = preset.GetManageGroup();
			bool flag = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(preset.GetID());
			presetAllowedResources = allowedResources;
			presetForbiddenResources = forbiddenResources;
			foreach (Resource key in resourcePairs.Keys)
			{
				string item = key.GetID();
				if (key.HasQuality)
				{
					item = key.GroupIdentifier;
				}
				OnResourceAllow(key, presetAllowedResources.Contains(item), silent: true);
			}
			foreach (KeyValuePair<ResourceGroups, ResourceToggleItemView> resourceGroupPair in resourceGroupPairs)
			{
				resourceGroupPair.Value.GroupSelectToggle.interactable = !flag;
			}
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair in resourcePairs)
			{
				string item2 = resourcePair.Key.GetID();
				if (resourcePair.Key.HasQuality)
				{
					item2 = resourcePair.Key.GroupIdentifier;
				}
				if (presetAllowedResources.Contains(item2))
				{
					resourcePair.Value.GroupSelectToggle.isOn = true;
				}
				else
				{
					resourcePair.Value.GroupSelectToggle.isOn = false;
				}
				resourcePair.Value.GroupSelectToggle.interactable = !flag;
			}
		}

		public void RefreshLayout()
		{
			if (!(scrollViewParent == null))
			{
				RectTransform rectTransform = scrollViewParent.transform as RectTransform;
				if (!(rectTransform == null))
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
				}
			}
		}

		private void OnGroupToggleChange(ResourceGroups group, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.RemoveAllListeners();
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				if (!(manageGroup == null))
				{
					UpdateGroupChlidren(group, value);
				}
			});
			view.GroupSelectToggle.onNonInteractableClick.AddListener(NotifyLocked);
		}

		private void NotifyLocked()
		{
			this.NotifyLockedEvent?.Invoke();
		}

		private void UpdateGroupChlidren(ResourceGroups group, bool allowed)
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
					resourceGroupPairs[group].SetSelected(allowed);
					UpdateGroupChlidren(item, allowed);
				}
			}
		}

		private void SetUpGroupsAllowed(bool allowed)
		{
			foreach (ResourceGroups key in resourceGroupPairs.Keys)
			{
				resourceGroupPairs[key].SetSelected(allowed);
			}
		}

		private void OnResourceAllow(Resource resource, bool allowed, bool silent = false)
		{
			resourcePairs[resource].SetSelected(allowed);
			if (silent)
			{
				UpdateResourceParentSelection(resource);
				return;
			}
			OnResourcesEdit();
			UpdateResourceParentSelection(resource);
		}

		private void SetResourcesAllowed(bool allowed, ResourceGroups group = null)
		{
			IEnumerable<Resource> enumerable = resourcePairs.Keys;
			if (group != null)
			{
				enumerable = resourceParents[group];
			}
			Resource resource = null;
			foreach (Resource item in enumerable)
			{
				resourcePairs[item].SetSelected(allowed);
				resource = item;
			}
			OnResourcesEdit();
			UpdateResourceParentSelection(resource);
		}

		private void UpdateResourceParentSelection(Resource resource)
		{
			if (resource == null)
			{
				return;
			}
			int num = 0;
			foreach (KeyValuePair<ResourceGroups, HashSet<Resource>> resourceParent in resourceParents)
			{
				if (!resourceParent.Value.Contains(resource))
				{
					continue;
				}
				int count = resourceParent.Value.Count;
				foreach (Resource item in resourceParent.Value)
				{
					if (resourcePairs[item].GroupSelectToggle.isOn)
					{
						num++;
					}
				}
				if (num == 0)
				{
					resourceGroupPairs[resourceParent.Key].SetSelected(selected: false);
				}
				else if (count == num)
				{
					resourceGroupPairs[resourceParent.Key].SetSelectedFull();
				}
				else
				{
					resourceGroupPairs[resourceParent.Key].SetSelectedPartial();
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
			bool flag = false;
			int count = list.Count;
			foreach (ResourceGroups item in list)
			{
				if (resourceGroupPairs[item].GroupSelectToggle.isOn)
				{
					num++;
				}
				if (resourceGroupPairs[item].PartiallySelected)
				{
					flag = true;
				}
			}
			if (num == 0)
			{
				resourceGroupPairs[groupParent].SetSelected(selected: false);
			}
			else if (count == num && !flag)
			{
				resourceGroupPairs[groupParent].SetSelectedFull();
			}
			else
			{
				resourceGroupPairs[groupParent].SetSelectedPartial();
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

		private void AddGroupResources(ResourceGroups node)
		{
			ResourceToggleItemView parent = resourceGroupPairs[node];
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				string text = allItem.GetID();
				if (allItem.SortingGroup != node.GetID())
				{
					continue;
				}
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
					resourcesWithQuality.Add(allItem.GroupIdentifier, new HashSet<Resource>());
					text = allItem.GroupIdentifier;
				}
				resourcePairs.Add(allItem, GetResourceToggleItemView(node, parent, text, allItem));
				if (!resourceParents.ContainsKey(node))
				{
					resourceParents.Add(node, new HashSet<Resource>());
				}
				resourceParents[node].Add(allItem);
				if (!allItem.RottenId.Equals(string.Empty))
				{
					Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(allItem.RottenId);
					if (!(byID == null) && !(byID.SortingGroup != node.GetID()) && !resourcePairs.ContainsKey(byID))
					{
						resourcePairs.Add(byID, GetResourceToggleItemView(node, parent, byID.GetID(), byID));
						resourceParents[node].Add(byID);
					}
				}
			}
		}

		private ResourceToggleItemView GetResourceToggleItemView(ResourceGroups node, ResourceToggleItemView parent, string name, Resource resource)
		{
			ResourceToggleItemView component = UnityEngine.Object.Instantiate(scrollViewParent.Prefab, parent.transform).GetComponent<ResourceToggleItemView>();
			component.gameObject.name = name;
			component.SetupGroup(name, "name", node.Depth + 1);
			parent.AddChild(component);
			component.GroupSelectToggle.onValueChanged.AddListener(delegate(bool allowed)
			{
				OnResourceAllow(resource, allowed);
			});
			component.GroupSelectToggle.onNonInteractableClick.AddListener(NotifyLocked);
			return component;
		}

		private void OnResourcesEdit()
		{
			List<string> allowedResources = selectionChangedEventInfo.AllowedResources;
			List<string> forbiddenResources = selectionChangedEventInfo.ForbiddenResources;
			allowedResources.Clear();
			forbiddenResources.Clear();
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair in resourcePairs)
			{
				string item = resourcePair.Key.GetID();
				if (resourcePair.Key.HasQuality)
				{
					item = resourcePair.Key.GroupIdentifier;
				}
				if (resourcePair.Value.GroupSelectToggle.isOn)
				{
					allowedResources.Add(item);
				}
				else
				{
					forbiddenResources.Add(item);
				}
			}
			this.SelectionChangedEvent?.Invoke(selectionChangedEventInfo);
		}
	}
}
