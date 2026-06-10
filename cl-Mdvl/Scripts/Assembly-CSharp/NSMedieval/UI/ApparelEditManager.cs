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
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI
{
	[Serializable]
	public class ApparelEditManager : ClosableUIView
	{
		[Header("Window Header")]
		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private TMP_Text titleLabel;

		[Header("Profiles Section")]
		[SerializeField]
		private SafeTMP_InputField presetName;

		[SerializeField]
		private TMP_Dropdown presetDropdown;

		[SerializeField]
		private SoundButton addNewButton;

		[SerializeField]
		private SoundButton deletePresetButton;

		[Header("Default Preset Settings")]
		[SerializeField]
		private ManagePresetResourceSelectorView defaultResourceSelector;

		[SerializeField]
		private SoundButton defaultSelectAllButton;

		[SerializeField]
		private SoundButton defaultClearAllButton;

		[SerializeField]
		private RangedSliderItemView hitpointsSlider;

		[SerializeField]
		private RangedSliderItemView itemQualitySlider;

		[SerializeField]
		private CustomToggle forceUnequipToggle;

		[SerializeField]
		private string[] hideQualityGroups;

		[SerializeField]
		private string[] hideHitpointsGroups;

		[FormerlySerializedAs("yearlyOverrideResourceTree")]
		[Header("Yearly Override Settings")]
		[SerializeField]
		private ManagePresetResourceSelectorView yearlyOverrideResourceSelector;

		[SerializeField]
		private LayoutGroupView yearlyOverrideResourcesListParent;

		[SerializeField]
		private SoundButton yearlyOverrideSelectAllButton;

		[SerializeField]
		private SoundButton yearlyOverrideClearAllButton;

		[SerializeField]
		private CustomToggle yearlyOverrideEnabledToggle;

		[SerializeField]
		private RangedSliderItemView yearlyOverrideDateSlider;

		private string selectedPreset;

		private ManagePanelManager panelManager;

		private ManageGroupPreset currentPreset;

		private ManageGroup manageGroup;

		private List<ManageGroupPreset> groupPresets;

		private WorldDate cachedWorldDate;

		private WorldDate DateTime
		{
			get
			{
				if (cachedWorldDate == null)
				{
					cachedWorldDate = GlobalSaveController.CurrentVillageData.DateAndTime;
				}
				return cachedWorldDate;
			}
		}

		public void ShowPanel(ManagePanelManager panelManager, ManageGroup manageGroup, string presetId)
		{
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			panelManager.DisableInput();
			this.panelManager = panelManager;
			this.manageGroup = manageGroup;
			selectedPreset = presetId;
			titleLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText("edit_" + manageGroup.GroupName + "_profiles"));
			bool flag = hideQualityGroups.Contains(manageGroup.GetID());
			bool flag2 = hideHitpointsGroups.Contains(manageGroup.GetID());
			itemQualitySlider.gameObject.SetActive(!flag);
			hitpointsSlider.gameObject.SetActive(!flag2);
			itemQualitySlider.transform.parent.gameObject.SetActive(!flag && !flag2);
			yearlyOverrideDateSlider.gameObject.SetActive(value: true);
			yearlyOverrideDateSlider.Slider.MinValue = 1f;
			yearlyOverrideDateSlider.Slider.MaxValue = DateTime.DaysInYear;
			yearlyOverrideDateSlider.Slider.WholeNumbers = true;
			MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent += RefreshLayout;
			ManageGroupPreset manageGroupPreset = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.GetByID(presetId) ?? Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GetID() == presetId);
			if (manageGroupPreset == null)
			{
				throw new Exception("Manage group preset not found while initializing apparel edit manager: this should not happen");
			}
			defaultResourceSelector.Setup(manageGroupPreset, manageGroupPreset.DefaultAllowedResources, manageGroupPreset.DefaultForbiddenResources);
			yearlyOverrideResourceSelector.Setup(manageGroupPreset, manageGroupPreset.YearlyOverrideAllowedResources, manageGroupPreset.YearlyOverrideForbiddenResources);
			HandlePresets(initialize: true);
			OnPresetChange(manageGroupPreset);
			Show();
		}

		public override void Hide()
		{
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnGroupUpdatedEvent -= RefreshLayout;
			}
			panelManager.InvokeProfileEditedEvent();
			defaultResourceSelector.OnHide();
			yearlyOverrideResourceSelector.OnHide();
			MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			panelManager.EnableInput();
			base.Hide();
		}

		private void OnPresetResourceSettingsChanged(ManagePresetResourceSelectorView.SelectionChangedEventInfo eventInfo)
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), eventInfo.AllowedResources.ToList(), eventInfo.ForbiddenResources.ToList(), currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid, currentPreset.YearlyOverrideAllowedResources.ToList(), currentPreset.YearlyOverrideForbiddenResources.ToList(), currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, currentPreset.IsYearlyOverrideEnabled);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnPresetYearlyOverrideResourceSettingsChanged(ManagePresetResourceSelectorView.SelectionChangedEventInfo eventInfo)
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), currentPreset.DefaultAllowedResources.ToList(), currentPreset.DefaultForbiddenResources.ToList(), currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid, eventInfo.AllowedResources.ToList(), eventInfo.ForbiddenResources.ToList(), currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, currentPreset.IsYearlyOverrideEnabled);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnPresetChange(ManageGroupPreset newPreset = null)
		{
			currentPreset = newPreset ?? groupPresets.FirstOrDefault();
			if (!(currentPreset == null))
			{
				panelManager.InvokeProfileChangedEvent(currentPreset.GroupId, currentPreset.GetID());
				bool flag = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(currentPreset.GetID());
				deletePresetButton.interactable = !flag;
				presetDropdown.SetValueWithoutNotify(groupPresets.IndexOf(currentPreset));
				presetName.SetTextWithoutNotify(MonoSingleton<LocalizationController>.Instance.GetText(currentPreset.DisplayName));
				presetName.interactable = !flag;
				hitpointsSlider.Slider.SetValueWithoutNotify(currentPreset.HitpointsMin, currentPreset.HitpointsMax);
				OnHitpointsSliderDrag(currentPreset.HitpointsMin, currentPreset.HitpointsMax);
				hitpointsSlider.Slider.interactable = !flag;
				itemQualitySlider.Slider.SetValueWithoutNotify(currentPreset.QualityMin, currentPreset.QualityMax);
				OnQualitySliderDrag(currentPreset.QualityMin, currentPreset.QualityMax);
				itemQualitySlider.Slider.interactable = !flag;
				forceUnequipToggle.isOn = currentPreset.ForceUnequipInvalid;
				forceUnequipToggle.interactable = !flag;
				yearlyOverrideEnabledToggle.isOn = currentPreset.IsYearlyOverrideEnabled;
				yearlyOverrideEnabledToggle.interactable = !flag;
				defaultSelectAllButton.interactable = !flag;
				defaultClearAllButton.interactable = !flag;
				yearlyOverrideSelectAllButton.interactable = !flag;
				yearlyOverrideClearAllButton.interactable = !flag;
				defaultResourceSelector.ChangeToPreset(currentPreset, currentPreset.DefaultAllowedResources, currentPreset.DefaultForbiddenResources);
				yearlyOverrideResourceSelector.ChangeToPreset(currentPreset, currentPreset.YearlyOverrideAllowedResources, currentPreset.YearlyOverrideForbiddenResources);
				yearlyOverrideDateSlider.Slider.interactable = !flag;
				yearlyOverrideDateSlider.Slider.SetValueWithoutNotify(currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax);
				OnYearlyOverrideDateSliderDrag(currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax);
				RefreshLayout();
			}
		}

		private void UpdateHitpointsSlider()
		{
			string formattedRange = $"{Mathf.Round(currentPreset.HitpointsMin * 100f)}% -  {Mathf.Round(currentPreset.HitpointsMax * 100f)}%";
			hitpointsSlider.SetSliderData("hit_points", formattedRange);
		}

		private void UpdateQualitySlider()
		{
			string formattedRange = $"{currentPreset.QualityMin} - {currentPreset.QualityMax}";
			itemQualitySlider.SetSliderData("quality", formattedRange);
		}

		private void UpdateYearlyOverrideDateSlider()
		{
			string seasonDayLocalized = DateTime.GetSeasonDayLocalized(currentPreset.YearlyOverrideDateMin);
			string seasonDayLocalized2 = DateTime.GetSeasonDayLocalized(currentPreset.YearlyOverrideDateMax);
			string formattedRange = seasonDayLocalized + " - " + seasonDayLocalized2;
			yearlyOverrideDateSlider.SetSliderData("yearly_override_dates", formattedRange);
		}

		private void Start()
		{
			closeButton.onClick.AddListener(OnCloseClick);
			defaultSelectAllButton.onClick.AddListener(OnDefaultSelectAllClick);
			defaultSelectAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			defaultClearAllButton.onClick.AddListener(OnDefaultClearAllClick);
			defaultClearAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			yearlyOverrideSelectAllButton.onClick.AddListener(OnYearlyOverrideSelectAllClick);
			yearlyOverrideSelectAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			yearlyOverrideClearAllButton.onClick.AddListener(OnYearlyOverrideClearAllClick);
			yearlyOverrideClearAllButton.onNonInteractableClick.AddListener(NotifyLocked);
			hitpointsSlider.Slider.OnRangeSliderMouseUp += OnHitpointsSliderMouseUp;
			hitpointsSlider.Slider.OnValueChanged.AddListener(OnHitpointsSliderDrag);
			hitpointsSlider.Slider.NonInteractableClickEvent.AddListener(NotifyLocked);
			itemQualitySlider.Slider.OnRangeSliderMouseUp += OnQualitySliderMouseUp;
			itemQualitySlider.Slider.OnValueChanged.AddListener(OnQualitySliderDrag);
			itemQualitySlider.Slider.NonInteractableClickEvent.AddListener(NotifyLocked);
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
			yearlyOverrideDateSlider.Slider.OnRangeSliderMouseUp += OnYearlyOverrideDateSliderMouseUp;
			yearlyOverrideDateSlider.Slider.OnValueChanged.AddListener(OnYearlyOverrideDateSliderDrag);
			yearlyOverrideDateSlider.Slider.NonInteractableClickEvent.AddListener(NotifyLocked);
			defaultResourceSelector.NotifyLockedEvent += NotifyLocked;
			defaultResourceSelector.SelectionChangedEvent += OnPresetResourceSettingsChanged;
			yearlyOverrideResourceSelector.NotifyLockedEvent += NotifyLocked;
			yearlyOverrideResourceSelector.SelectionChangedEvent += OnPresetYearlyOverrideResourceSettingsChanged;
			yearlyOverrideEnabledToggle.onValueChanged.AddListener(OnYearlyOverrideEnabledToggled);
			yearlyOverrideEnabledToggle.onNonInteractableClick.AddListener(NotifyLocked);
		}

		private void OnYearlyOverrideEnabledToggled(bool isYearlyOverrideEnabled)
		{
			if (!Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(currentPreset.GetID()))
			{
				ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), currentPreset.DefaultAllowedResources.ToList(), currentPreset.DefaultForbiddenResources.ToList(), currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid, currentPreset.YearlyOverrideAllowedResources.ToList(), currentPreset.YearlyOverrideForbiddenResources.ToList(), currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, isYearlyOverrideEnabled);
				SavePreset(manageGroupPreset);
				HandlePresets();
				OnPresetChange(manageGroupPreset);
			}
		}

		private void OnForceUnequipToggled(bool forceUnequip)
		{
			if (!Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(currentPreset.GetID()))
			{
				ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), currentPreset.DefaultAllowedResources.ToList(), currentPreset.DefaultForbiddenResources.ToList(), currentPreset.DefaultPreset, forceUnequip, currentPreset.YearlyOverrideAllowedResources.ToList(), currentPreset.YearlyOverrideForbiddenResources.ToList(), currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, currentPreset.IsYearlyOverrideEnabled);
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

		private void HandlePresets(bool initialize = false)
		{
			groupPresets = new List<ManageGroupPreset>();
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			foreach (ManageGroupPreset item in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.OrderBy((ManageGroupPreset preset) => (!Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(preset.GetID())) ? 1 : 0))
			{
				if (!(item.GroupId != manageGroup.GetID()))
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(item.DisplayName);
					if (Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.IsLocked(item.GetID()))
					{
						text = "<style=AltColor>" + text + "</style>";
					}
					pooledList.Add(text);
					groupPresets.Add(item);
				}
			}
			presetDropdown.ClearOptions();
			presetDropdown.AddOptions(pooledList.GetRawList());
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
			hitpointsSlider.SetSliderData("hit_points", formattedRange);
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
			itemQualitySlider.SetSliderData("quality", formattedRange);
		}

		private void OnYearlyOverrideDateSliderMouseUp(float low, float high)
		{
			OnYearlyOverrideDateSliderDrag(low, high);
			UpdateYearlyOverrideDateSlider();
			OnSliderValueChange();
		}

		private void OnYearlyOverrideDateSliderDrag(float low, float high)
		{
			string seasonDayLocalized = DateTime.GetSeasonDayLocalized((int)low);
			string seasonDayLocalized2 = DateTime.GetSeasonDayLocalized((int)high);
			string formattedRange = seasonDayLocalized + " - " + seasonDayLocalized2;
			yearlyOverrideDateSlider.SetSliderData(null, formattedRange);
		}

		private void OnLoadPreset(int value)
		{
			OnPresetChange(groupPresets[value]);
		}

		private void OnDefaultSelectAllClick()
		{
			defaultResourceSelector.SelectAll();
		}

		private void OnDefaultClearAllClick()
		{
			defaultResourceSelector.ClearAll();
		}

		private void OnYearlyOverrideSelectAllClick()
		{
			yearlyOverrideResourceSelector.SelectAll();
		}

		private void OnYearlyOverrideClearAllClick()
		{
			yearlyOverrideResourceSelector.ClearAll();
		}

		private void OnSliderValueChange()
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), currentPreset.DisplayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), currentPreset.DefaultAllowedResources.ToList(), currentPreset.DefaultForbiddenResources.ToList(), currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid, currentPreset.YearlyOverrideAllowedResources.ToList(), currentPreset.YearlyOverrideForbiddenResources.ToList(), (int)yearlyOverrideDateSlider.Slider.LowValue, (int)yearlyOverrideDateSlider.Slider.HighValue, currentPreset.IsYearlyOverrideEnabled);
			SavePreset(manageGroupPreset);
			HandlePresets();
			OnPresetChange(manageGroupPreset);
		}

		private void OnNameEdit(string displayName)
		{
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(currentPreset.GetID(), displayName, currentPreset.GroupId, new FloatRange(hitpointsSlider.Slider.LowValue, hitpointsSlider.Slider.HighValue), new IntRange((int)itemQualitySlider.Slider.LowValue, (int)itemQualitySlider.Slider.HighValue), currentPreset.DefaultAllowedResources.ToList(), currentPreset.DefaultForbiddenResources.ToList(), currentPreset.DefaultPreset, currentPreset.ForceUnequipInvalid, currentPreset.YearlyOverrideAllowedResources.ToList(), currentPreset.YearlyOverrideForbiddenResources.ToList(), currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, currentPreset.IsYearlyOverrideEnabled);
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
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair in defaultResourceSelector.ResourcePairs)
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
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			foreach (KeyValuePair<Resource, ResourceToggleItemView> resourcePair2 in yearlyOverrideResourceSelector.ResourcePairs)
			{
				string item2 = resourcePair2.Key.GetID();
				if (resourcePair2.Key.HasQuality)
				{
					item2 = resourcePair2.Key.GroupIdentifier;
				}
				if (resourcePair2.Value.GroupSelectToggle.isOn)
				{
					list3.Add(item2);
				}
				else
				{
					list4.Add(item2);
				}
			}
			ManageGroupPreset manageGroupPreset = new ManageGroupPreset(id, displayName, currentPreset.GroupId, new FloatRange(0f, 1f), new IntRange(1, 6), list, list2, defaultPreset: false, forceUnequipInvalid: false, list3, list4, currentPreset.YearlyOverrideDateMin, currentPreset.YearlyOverrideDateMax, currentPreset.IsYearlyOverrideEnabled);
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
			defaultResourceSelector.RefreshLayout();
			yearlyOverrideResourceSelector.RefreshLayout();
		}
	}
}
