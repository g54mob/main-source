using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Resources;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.Types;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ManageEquipmentLayoutItemView : LayoutGroupItemView
	{
		[SerializeField]
		private EquipmentSlotType[] equipmentSlots;

		[SerializeField]
		private ResourceIconItemView[] equipmentIcons;

		[SerializeField]
		private GameObject[] forcedGroups;

		[SerializeField]
		private string dropdownManageGroupId;

		[SerializeField]
		private TMP_Dropdown manageGroupDropdown;

		[NonSerialized]
		private HashSet<EquipmentSlotType> slotTypes;

		private void Awake()
		{
			slotTypes = equipmentSlots.ToHashSet();
		}

		public void SetData(HumanoidInstance humanoid, Action<ManageGroup, string> dropdownEditCallback)
		{
			if (humanoid?.Inventory?.AvailableSlots == null)
			{
				return;
			}
			for (int i = 0; i < equipmentSlots.Length; i++)
			{
				EquipmentSlotType slot = equipmentSlots[i];
				ResourceIconItemView resourceIconItemView = equipmentIcons[i];
				GameObject gameObject = forcedGroups[i];
				gameObject.SetActive(value: false);
				resourceIconItemView.gameObject.SetActive(value: false);
				EquipmentInstance equipmentInstance = humanoid.Inventory.GetItem(slot);
				string text = ((!humanoid.Inventory.IsSlotBlocked(slot) && equipmentInstance != null) ? equipmentInstance.Id : ((equipmentInstance == null) ? "empty" : "blocked"));
				if (!(text != "empty"))
				{
					continue;
				}
				resourceIconItemView.gameObject.SetActive(value: true);
				if (equipmentInstance != null)
				{
					resourceIconItemView.SetData(equipmentInstance.Blueprint.GetID());
					if (resourceIconItemView.TooltipNew is EquipmentTooltipView equipmentTooltipView)
					{
						equipmentTooltipView.SetupData(equipmentInstance, humanoid);
					}
					gameObject.SetActive(humanoid.Inventory.GetEquipments().FirstOrDefault((EquipmentInstance instance) => instance.Blueprint.GetID() == equipmentInstance.Blueprint.GetID())?.IsManuallyEquiped ?? false);
				}
			}
			UpdateDropdownData(humanoid, dropdownEditCallback);
			base.gameObject.SetActive(value: true);
		}

		private void UpdateDropdownData(HumanoidInstance humanoid, Action<ManageGroup, string> dropdownEditCallback)
		{
			List<Action> callbacks = new List<Action>();
			List<string> list = new List<string>();
			int defaultValue = 0;
			int num = 0;
			ManageGroup manageGroup = Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(dropdownManageGroupId);
			if (manageGroup == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\WorkerManagePanel\\ManageEquipmentLayoutItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to initialize dropdown, manage group id '");
					messageBuilder.AppendFormatted(dropdownManageGroupId);
					messageBuilder.AppendLiteral("' not found!");
				}
				Log.Error(messageBuilder);
				return;
			}
			WorkerBehaviour worker = humanoid.WorkerBehaviour;
			foreach (ManageGroupPreset userPreset in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets)
			{
				string groupId = userPreset.GroupId;
				string presetId = userPreset.GetID();
				if (groupId == manageGroup.GetID())
				{
					string item = userPreset.DisplayName;
					if (!userPreset.GetID().Contains("custom_profile_"))
					{
						item = MonoSingleton<LocalizationController>.Instance.GetText(userPreset.DisplayName);
					}
					list.Add(item);
					callbacks.Add(delegate
					{
						worker.UpdateSingleManagePreset(groupId, presetId);
					});
					worker.SelectedManagePresets.Dictionary.TryAdd(groupId, presetId);
					if (worker.SelectedManagePresets.Dictionary[groupId] == presetId)
					{
						defaultValue = num;
					}
					num++;
				}
			}
			callbacks.Add(delegate
			{
				string arg = worker.SelectedManagePresets.Dictionary[manageGroup.GetID()];
				dropdownEditCallback(manageGroup, arg);
				manageGroupDropdown.SetValueWithoutNotify(defaultValue);
			});
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("edit_" + manageGroup.GroupName + "_profiles"));
			manageGroupDropdown.ClearOptions();
			manageGroupDropdown.AddOptions(list);
			manageGroupDropdown.SetValueWithoutNotify(defaultValue);
			manageGroupDropdown.onValueChanged.RemoveAllListeners();
			manageGroupDropdown.onValueChanged.AddListener(delegate(int value)
			{
				callbacks[value]();
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ToggleOn");
			});
		}
	}
}
