using ManagementScripts;
using SettingScripts;
using SimulationScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class ZonesEditorPanel : UIPanel
	{
		[SerializeField]
		private GameObject zoneGroupPrefab;

		[SerializeField]
		private Transform zoneGroupHolder;

		[SerializeField]
		private GameObject zoneItemPrefab;

		[SerializeField]
		private Transform zoneItemsHolder;

		public bool generatePreviews = true;

		[SerializeField]
		private GameObject zonePreviewPrefab;

		[SerializeField]
		private Transform zonePreviewHolder;

		[SerializeField]
		private GameObject noneZonesText;

		[SerializeField]
		private GameObject noneGroupsText;

		[SerializeField]
		private Button deleteAllButton;

		[SerializeField]
		private Button deleteAllGroupsButton;

		private ItemDictPool<ZoneSettings, ZoneSettingsHandle> zoneHandles;

		private ItemDictPool<ZoneGroupSettings, ZoneGroupHandle> zoneGroupHandles;

		private ItemDictPool<ZoneSettings, ZonePreview> zonePreviews;

		public RectTransform previewRT => zonePreviewHolder.GetComponent<RectTransform>();

		public override void InitPanel()
		{
			base.InitPanel();
			zoneHandles = new ItemDictPool<ZoneSettings, ZoneSettingsHandle>(zoneItemPrefab, zoneItemsHolder)
			{
				actionOnCreate = InitZoneHandle
			};
			zoneGroupHandles = new ItemDictPool<ZoneGroupSettings, ZoneGroupHandle>(zoneGroupPrefab, zoneGroupHolder)
			{
				actionOnCreate = InitZoneGroupHandle
			};
			if (generatePreviews)
			{
				zonePreviews = new ItemDictPool<ZoneSettings, ZonePreview>(zonePreviewPrefab, zonePreviewHolder);
			}
			ScenarioSettings.onZoneFromGroupAdded.AddListener(ZoneFromGroupAdded);
			ScenarioSettings.onZoneFromGroupRemoved.AddListener(ZoneFromGroupRemoved);
		}

		public override void ResetState()
		{
			zoneHandles.RetireAll();
			zoneGroupHandles.RetireAll();
			if (generatePreviews)
			{
				zonePreviews.RetireAll();
			}
		}

		public override void FillPanel()
		{
			base.FillPanel();
			noneZonesText.SetActive(ScenarioSettings.Instance.zones.Count > 0);
			ScenarioSettings.Instance.zones.ForEach(delegate(ZoneSettings z)
			{
				zoneHandles.GetItemWithKey(z);
				if (generatePreviews)
				{
					zonePreviews.GetItemWithKey(z);
				}
			});
			ScenarioSettings.Instance.zoneGroups.ForEach(delegate(ZoneGroupSettings z)
			{
				zoneGroupHandles.GetItemWithKey(z, delegate(ZoneGroupHandle h)
				{
					h.AssignSetting(z);
				});
				if (z.zones.Count < 1)
				{
					z.GenerateZones();
				}
				if (generatePreviews)
				{
					z.zones.ForEach(delegate(ZoneSettings zone)
					{
						zonePreviews.GetItemWithKey(zone);
					});
				}
			});
			noneZonesText.SetActive(ScenarioSettings.Instance.zones.Count < 1);
			noneGroupsText.SetActive(ScenarioSettings.Instance.zoneGroups.Count < 1);
			zoneHandles.ForEachActive(delegate(ZoneSettingsHandle z)
			{
				z.CloseEditSection();
			});
			zoneGroupHandles.ForEachActive(delegate(ZoneGroupHandle z)
			{
				z.ToggleBody(val: false);
			});
			deleteAllButton.interactable = zoneHandles.activeCount > 0;
			deleteAllGroupsButton.interactable = zoneGroupHandles.activeCount > 0;
			ScenarioSettings.onZoneBiomassChange.Invoke();
		}

		public void SetShowLabels(bool val)
		{
			zonePreviews.ForEachActive(delegate(ZonePreview z)
			{
				z.SetShowLabels(val);
			});
		}

		public void InitZoneHandle(ZoneSettingsHandle handle)
		{
			handle.onItemClicked.AddListener(ItemClicked);
			handle.onItemDelete.AddListener(ZoneDeleted);
		}

		public void InitZoneGroupHandle(ZoneGroupHandle handle)
		{
			handle.onGroupDelete.AddListener(GroupDeleted);
		}

		public void AddZone()
		{
			ZoneSettings newZoneSetting = new ZoneSettings(MatterMaterialManager.Plant);
			newZoneSetting.zoneName.SetValue($"Zone {zoneHandles.activeCount}");
			ScenarioSettings.Instance.AddNewZone(newZoneSetting);
			ZoneSettingsHandle itemWithKey = zoneHandles.GetItemWithKey(newZoneSetting, delegate(ZoneSettingsHandle h)
			{
				h.AssignSetting(newZoneSetting);
			});
			ItemClicked(itemWithKey);
			deleteAllButton.interactable = true;
			noneZonesText.SetActive(value: false);
			if (generatePreviews)
			{
				zonePreviews.GetItemWithKey(newZoneSetting, delegate(ZonePreview p)
				{
					p.AssignSetting(newZoneSetting);
				});
			}
		}

		public void AddZoneGroup()
		{
			ZoneGroupSettings newGroup = new ZoneGroupSettings();
			newGroup.groupName.SetValue($"Pockets{zoneGroupHandles.activeCount}");
			ScenarioSettings.Instance.zoneGroups.Add(newGroup);
			ZoneGroupHandle itemWithKey = zoneGroupHandles.GetItemWithKey(newGroup, delegate(ZoneGroupHandle z)
			{
				z.AssignSetting(newGroup);
			});
			itemWithKey.ToggleBody(val: true);
			itemWithKey.GenerateZones();
			deleteAllGroupsButton.interactable = true;
			noneGroupsText.SetActive(value: false);
		}

		private void ZoneFromGroupAdded(ZoneSettings zone)
		{
			if (base.isActiveAndEnabled && generatePreviews)
			{
				zonePreviews.GetItemWithKey(zone, delegate(ZonePreview p)
				{
					p.AssignSetting(zone);
				});
			}
		}

		private void ZoneFromGroupRemoved(ZoneSettings zone)
		{
			if (generatePreviews)
			{
				zonePreviews.RetireItemWithKey(zone);
			}
		}

		public void DeleteAllZones()
		{
			PopupManager.DisplayChoiceDialog("Delete All Zones", "Are you sure you want to delete all zones? You will lose all data", "Cancel", "YES", null, ActuallyDeleteAllZones);
		}

		public void ActuallyDeleteAllZones()
		{
			if (generatePreviews)
			{
				zoneHandles.ForEachActive(delegate(ZoneSettingsHandle z)
				{
					zonePreviews.RetireItemWithKey(z.settings);
				});
			}
			zoneHandles.RetireAll();
			ScenarioSettings.Instance.RemoveAllZones();
			deleteAllButton.interactable = false;
			noneZonesText.SetActive(value: true);
		}

		public void DeleteAllZoneGroups()
		{
			PopupManager.DisplayChoiceDialog("Delete All Zone groups", "Are you sure you want to delete all zone groups? You will lose all data", "Cancel", "YES", null, ActuallyDeleteAllZoneGroups);
		}

		public void ActuallyDeleteAllZoneGroups()
		{
			zoneGroupHandles.ForEachActive(delegate(ZoneGroupHandle z)
			{
				if (generatePreviews)
				{
					z.settings.zones.ForEach(delegate(ZoneSettings zone)
					{
						zonePreviews.RetireItemWithKey(zone);
					});
				}
				z.settings.ClearZones();
				ScenarioSettings.Instance.zoneGroups.Remove(z.settings);
			});
			zoneGroupHandles.RetireAll();
			ScenarioSettings.onZoneBiomassChange.Invoke();
			deleteAllGroupsButton.interactable = false;
			noneGroupsText.SetActive(value: true);
			ScenarioSettings.Instance.UpdateAllZonesList();
		}

		public bool SelectItemOfZone(Zone toSelect)
		{
			if (!zoneHandles.activeItems.ContainsKey(toSelect.settings))
			{
				return false;
			}
			ItemClicked(zoneHandles.activeItems[toSelect.settings]);
			return true;
		}

		private void ItemClicked(ZoneSettingsHandle settingsHandle)
		{
			settingsHandle.SelectItem();
		}

		private void ZoneDeleted(ZoneSettingsHandle settingsHandle)
		{
			if (generatePreviews)
			{
				zonePreviews.RetireItemWithKey(settingsHandle.settings);
			}
			ScenarioSettings.Instance.RemoveZone(settingsHandle.settings);
			zoneHandles.RetireItemWithKey(settingsHandle.settings);
			deleteAllButton.interactable = ScenarioSettings.Instance.zones.Count > 0;
			noneZonesText.SetActive(ScenarioSettings.Instance.zones.Count < 1);
		}

		private void GroupDeleted(ZoneGroupHandle groupHandle)
		{
			if (generatePreviews)
			{
				groupHandle.settings.zones.ForEach(delegate(ZoneSettings z)
				{
					zonePreviews.RetireItemWithKey(z);
				});
			}
			groupHandle.settings.ClearZones();
			ScenarioSettings.Instance.zoneGroups.Remove(groupHandle.settings);
			zoneGroupHandles.RetireItemWithKey(groupHandle.settings);
			ScenarioSettings.onZoneBiomassChange.Invoke();
			deleteAllGroupsButton.interactable = zoneGroupHandles.activeCount > 0;
			noneGroupsText.SetActive(ScenarioSettings.Instance.zones.Count < 1);
			ScenarioSettings.Instance.UpdateAllZonesList();
		}

		private void OnDestroy()
		{
			ScenarioSettings.onZoneFromGroupAdded.RemoveListener(ZoneFromGroupAdded);
			ScenarioSettings.onZoneFromGroupRemoved.RemoveListener(ZoneFromGroupRemoved);
		}
	}
}
