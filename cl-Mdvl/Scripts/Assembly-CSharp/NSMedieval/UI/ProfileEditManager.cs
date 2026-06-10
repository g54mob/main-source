using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class ProfileEditManager : ClosableUIView
	{
		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private TMP_Text titleLabel;

		[SerializeField]
		private LayoutGroupView resourcesListParent;

		[FormerlySerializedAs("stockpileName")]
		[SerializeField]
		private SafeTMP_InputField presetName;

		[SerializeField]
		private SoundButton addNewButton;

		[SerializeField]
		private SoundButton selectAllButton;

		[SerializeField]
		private SoundButton clearAllButton;

		[SerializeField]
		private RangedSliderItemView hitpointsSliderGroup;

		[SerializeField]
		private RangedSliderItemView itemQualitySliderGroup;

		[SerializeField]
		private TMP_Dropdown presetDropdown;

		[SerializeField]
		private SoundButton deletePresetButton;

		[SerializeField]
		private CustomToggle forceUnequipToggle;

		[SerializeField]
		private string[] hideQualityGroups;

		[SerializeField]
		private string[] hideHitpointsGroups;

		private ManageGroupPreset currentPreset;

		private List<GameObject> currentRootObjects;

		private Dictionary<ResourceGroups, List<ResourceGroups>> groupParents;

		private List<ManageGroupPreset> groupPresets;

		private ManageGroup manageGroup;

		private Dictionary<ResourceGroups, ResourceToggleItemView> resourceGroupPairs;

		private Dictionary<Resource, ResourceToggleItemView> resourcePairs;

		private Dictionary<ResourceGroups, HashSet<Resource>> resourceParents;

		private Dictionary<string, HashSet<Resource>> resourcesWithQuality;

		private string selectedPreset;

		private ManagePanelManager panelManager;

		public void ShowPanel(ManagePanelManager panelManager, ManageGroup manageGroup, string selectedPreset)
		{
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			panelManager.DisableInput();
			this.panelManager = panelManager;
			this.manageGroup = manageGroup;
			this.selectedPreset = selectedPreset;
			titleLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText("edit_" + manageGroup.GroupName + "_profiles"));
			bool flag = hideQualityGroups.Contains(manageGroup.GetID());
			bool flag2 = hideHitpointsGroups.Contains(manageGroup.GetID());
			itemQualitySliderGroup.gameObject.SetActive(!flag);
			hitpointsSliderGroup.gameObject.SetActive(!flag2);
			itemQualitySliderGroup.transform.parent.gameObject.SetActive(!flag && !flag2);
			MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent += RefreshLayout;
			SetupGroups();
		}

		public override void Hide()
		{
			MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= RefreshLayout;
			}
			panelManager.InvokeProfileEditedEvent();
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			currentRootObjects.ForEach(UnityEngine.Object.Destroy);
			panelManager.EnableInput();
			base.Hide();
		}

		private void OnPresetChange(ManageGroupPreset newPreset = null)
		{
			currentPreset = newPreset ?? groupPresets.FirstOrDefault();
			if (currentPreset == null)
			{
				return;
			}
			panelManager.InvokeProfileChangedEvent(currentPreset.GroupId, currentPreset.GetID());
			bool flag = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(currentPreset.GetID());
			deletePresetButton.interactable = !flag;
			foreach (Resource key in resourcePairs.Keys)
			{
				string item = key.GetID();
				if (key.HasQuality)
				{
					item = key.GroupIdentifier;
				}
				OnResourceAllow(key, currentPreset.DefaultAllowedResources.Contains(item), silent: true);
			}
			presetDropdown.SetValueWithoutNotify(groupPresets.IndexOf(currentPreset));
			presetName.SetTextWithoutNotify(MonoSingleton<LocalizationController>.Instance.GetText(currentPreset.DisplayName));
			presetName.interactable = !flag;
			hitpointsSliderGroup.Slider.SetValueWithoutNotify(currentPreset.HitpointsMin, currentPreset.HitpointsMax);
			OnHitpointsSliderDrag(currentPreset.HitpointsMin, currentPreset.HitpointsMax);
			hitpointsSliderGroup.Slider.interactable = !flag;
			itemQualitySliderGroup.Slider.SetValueWithoutNotify(currentPreset.QualityMin, currentPreset.QualityMax);
			OnQualitySliderDrag(currentPreset.QualityMin, currentPreset.QualityMax);
			itemQualitySliderGroup.Slider.interactable = !flag;
			forceUnequipToggle.isOn = currentPreset.ForceUnequipInvalid;
			forceUnequipToggle.interactable = !flag;
			selectAllButton.interactable = !flag;
			clearAllButton.interactable = !flag;
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
				if (currentPreset.DefaultAllowedResources.Contains(item2))
				{
					resourcePair.Value.GroupSelectToggle.isOn = true;
				}
				else
				{
					resourcePair.Value.GroupSelectToggle.isOn = false;
				}
				resourcePair.Value.GroupSelectToggle.interactable = !flag;
			}
			RefreshLayout();
		}

		private void UpdateHitpointsSlider()
		{
			string formattedRange = $"{Mathf.Round(currentPreset.HitpointsMin * 100f)}% -  {Mathf.Round(currentPreset.HitpointsMax * 100f)}%";
			hitpointsSliderGroup.SetSliderData("hit_points", formattedRange);
		}

		private void UpdateQualitySlider()
		{
			string formattedRange = $"{currentPreset.QualityMin} - {currentPreset.QualityMax}";
			itemQualitySliderGroup.SetSliderData("quality", formattedRange);
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
			OnResourcesEdit(delegate
			{
				UpdateResourceParentSelection(resource);
			});
		}

		private void SetResourcesAllowed(bool allowed, ResourceGroups group = null)
		{
			IEnumerable<Resource> enumerable = resourcePairs.Keys;
			if (group != null)
			{
				enumerable = resourceParents[group];
			}
			Resource last = null;
			foreach (Resource item in enumerable)
			{
				resourcePairs[item].SetSelected(allowed);
				last = item;
			}
			OnResourcesEdit(delegate
			{
				UpdateResourceParentSelection(last);
			});
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

		private void Start()
		{
			closeButton.onClick.AddListener(OnCloseClick);
			selectAllButton.onClick.AddListener(OnSelectAllClick);
			selectAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			clearAllButton.onClick.AddListener(OnClearAllClick);
			clearAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			hitpointsSliderGroup.Slider.OnRangeSliderMouseUp += OnHitpointsSliderMouseUp;
			hitpointsSliderGroup.Slider.OnValueChanged.AddListener(OnHitpointsSliderDrag);
			hitpointsSliderGroup.Slider.NonInteractableClickEvent.AddListener(NotifyLocked);
			itemQualitySliderGroup.Slider.OnRangeSliderMouseUp += OnQualitySliderMouseUp;
			itemQualitySliderGroup.Slider.OnValueChanged.AddListener(OnQualitySliderDrag);
			itemQualitySliderGroup.Slider.NonInteractableClickEvent.AddListener(NotifyLocked);
			presetName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			presetName.onDeselect.AddListener(OnNameEdit);
			presetName.onEndEdit.AddListener(OnNameEdit);
			presetName.onNonInteractableClick.AddListener(NotifyLocked);
			addNewButton.onClick.AddListener(OnNewPresetClick);
			deletePresetButton.onClick.AddListener(OnDeletePresetClick);
			deletePresetButton.onNonInteractableClick.AddListener(NotifyLocked);
			forceUnequipToggle.onValueChanged.AddListener(OnForceUnequipToggled);
			forceUnequipToggle.onNonInteractableClick.AddListener(NotifyLocked);
		}

		private void OnForceUnequipToggled(bool value)
		{
			if (!Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(currentPreset.GetID()))
			{
				currentPreset.ForceUnequipInvalid = value;
				ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSliderGroup.Slider.LowValue, hitpointsSliderGroup.Slider.HighValue), new IntRange((int)itemQualitySliderGroup.Slider.LowValue, (int)itemQualitySliderGroup.Slider.HighValue), currentPreset.DefaultAllowedResources, currentPreset.DefaultForbiddenResources, currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid);
				SavePreset(manageGroupPreset);
				HandlePresets();
				OnPresetChange(manageGroupPreset);
			}
		}

		private void SavePreset(ManageGroupPreset preset)
		{
			Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UpdateUserPreset(preset);
		}

		private void NotifyLocked()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("manage_panel_cant_change"));
		}

		private void SetupGroups()
		{
			resourceParents = new Dictionary<ResourceGroups, HashSet<Resource>>();
			resourcePairs = new Dictionary<Resource, ResourceToggleItemView>();
			resourcesWithQuality = new Dictionary<string, HashSet<Resource>>();
			resourceGroupPairs = new Dictionary<ResourceGroups, ResourceToggleItemView>();
			groupParents = new Dictionary<ResourceGroups, List<ResourceGroups>>();
			currentRootObjects = new List<GameObject>();
			foreach (ResourceGroups resourceGroup in manageGroup.ResourceGroups)
			{
				resourceGroupPairs.Add(resourceGroup, UnityEngine.Object.Instantiate(resourcesListParent.Prefab, resourcesListParent.transform).GetComponent<ResourceToggleItemView>());
			}
			foreach (ResourceGroups resourceGroup2 in manageGroup.ResourceGroups)
			{
				if (resourceGroup2.Depth == 0)
				{
					resourceGroupPairs[resourceGroup2].transform.SetParent(resourcesListParent.transform);
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
			HandlePresets(initialize: true);
			OnPresetChange(groupPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GetID() == selectedPreset));
			Show();
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
			ResourceToggleItemView component = UnityEngine.Object.Instantiate(resourcesListParent.Prefab, parent.transform).GetComponent<ResourceToggleItemView>();
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

		private void HandlePresets(bool initialize = false)
		{
			groupPresets = new List<ManageGroupPreset>();
			List<string> list = new List<string>();
			foreach (ManageGroupPreset userPreset in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets)
			{
				if (!(userPreset.GroupId != manageGroup.GetID()))
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(userPreset.DisplayName);
					if (Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(userPreset.GetID()))
					{
						text = "<style=AltColor>" + text + "</style>";
					}
					list.Add(text);
					groupPresets.Add(userPreset);
				}
			}
			presetDropdown.ClearOptions();
			presetDropdown.AddOptions(list);
			presetDropdown.onValueChanged.AddListener(OnLoadPreset);
		}

		private void OnHitpointsSliderMouseUp(float low, float high)
		{
			OnHitpointsSliderDrag(low, high);
			UpdateHitpointsSlider();
			OnSliderValueChange();
		}

		private void OnHitpointsSliderDrag(float low, float high)
		{
			string formattedRange = $"{Mathf.Round(low * 100f)}% -  {Mathf.Round(high * 100f)}%";
			hitpointsSliderGroup.SetSliderData("hit_points", formattedRange);
		}

		private void OnQualitySliderMouseUp(float low, float high)
		{
			OnQualitySliderDrag(low, high);
			UpdateQualitySlider();
			OnSliderValueChange();
		}

		private void OnQualitySliderDrag(float low, float high)
		{
			string formattedRange = MonoSingleton<LocalizationController>.Instance.GetText($"quality_{(ProductQuality)low}") + " - " + MonoSingleton<LocalizationController>.Instance.GetText($"quality_{(ProductQuality)high}");
			itemQualitySliderGroup.SetSliderData("quality", formattedRange);
		}

		private void OnLoadPreset(int value)
		{
			OnPresetChange(groupPresets[value]);
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

		private void OnSliderValueChange()
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSliderGroup.Slider.LowValue, hitpointsSliderGroup.Slider.HighValue), new IntRange((int)itemQualitySliderGroup.Slider.LowValue, (int)itemQualitySliderGroup.Slider.HighValue), currentPreset.DefaultAllowedResources, currentPreset.DefaultForbiddenResources, currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnResourcesEdit(Action callback)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair in resourcePairs)
			{
				string item = resourcePair.Key.GetID();
				if (resourcePair.Key.HasQuality)
				{
					item = resourcePair.Key.GroupIdentifier;
				}
				if (resourcePair.Value.GroupSelectToggle.isOn)
				{
					list.Add(item);
				}
				else
				{
					list2.Add(item);
				}
			}
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSliderGroup.Slider.LowValue, hitpointsSliderGroup.Slider.HighValue), new IntRange((int)itemQualitySliderGroup.Slider.LowValue, (int)itemQualitySliderGroup.Slider.HighValue), list, list2, currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
			callback();
		}

		private void OnNameEdit(string displayName)
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), displayName, currentPreset.GroupId, new FloatRange(hitpointsSliderGroup.Slider.LowValue, hitpointsSliderGroup.Slider.HighValue), new IntRange((int)itemQualitySliderGroup.Slider.LowValue, (int)itemQualitySliderGroup.Slider.HighValue), currentPreset.DefaultAllowedResources, currentPreset.DefaultForbiddenResources, currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnNewPresetClick()
		{
			string text = Guid.NewGuid().ToString();
			string id = "custom_profile_" + text;
			string displayName = MonoSingleton<LocalizationController>.Instance.GetText("profile") + " " + text.Substring(0, 6) + "...";
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair in resourcePairs)
			{
				string item = resourcePair.Key.GetID();
				if (resourcePair.Key.HasQuality)
				{
					item = resourcePair.Key.GroupIdentifier;
				}
				if (resourcePair.Value.GroupSelectToggle.isOn)
				{
					list.Add(item);
				}
				else
				{
					list2.Add(item);
				}
			}
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(id, displayName, currentPreset.GroupId, new FloatRange(0f, 1f), new IntRange(1, 6), list, list2, defaultPreset: false, forceUnequipInvalid: false);
			Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.AddUserPreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnDeletePresetClick()
		{
			ManageGroupPreset manageGroupPreset = currentPreset;
			Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.DeleteUserPreset(currentPreset);
			panelManager.InvokeProfileDeletedEvent(manageGroupPreset.GroupId, manageGroupPreset.GetID());
			HandlePresets();
			OnPresetChange();
		}

		private void OnCloseClick()
		{
			Hide();
		}

		private void RefreshLayout()
		{
			if (!(resourcesListParent == null))
			{
				RectTransform rectTransform = resourcesListParent.transform as RectTransform;
				if (!(rectTransform == null))
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
				}
			}
		}
	}
}
