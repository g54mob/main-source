using System;
using System.Collections.Generic;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public class SubSettingsGroupHandle : ISettingHandle
	{
		public SubSettingsGroupReference GroupRef;

		public SubSettingsToggleMaster MasterToggle;

		public string GroupTitle = "";

		public List<ISettingHandle> Settings;

		public void CreateUIElement(GameObject _parent)
		{
			if (Settings != null)
			{
				GroupRef = UnityEngine.Object.Instantiate(UIPrefabsHolder.Instance.SubSettingsGroupPrefab, _parent.transform).GetComponent<SubSettingsGroupReference>();
				GroupRef.titleText.text = GroupTitle;
				if (MasterToggle != null)
				{
					MasterToggle.setting.OnValueChangeWithPrecedent.RemoveAllListeners();
					MasterToggle.CreateUIElement(GroupRef.toggleHolder);
					MasterToggle.setting.OnValueChangeWithPrecedent.AddListener(OnMasterToggled);
					MasterToggle.ToggleRef.editSubSettingsButton.onClick.AddListener(ToggleSubSettingsPanel);
				}
				Settings.ForEach(delegate(ISettingHandle _r)
				{
					_r.CreateUIElement(GroupRef.settingsHolder);
				});
				GroupRef.ResetAllButton.GetComponent<Button>().onClick.AddListener(ResetValue);
				CloseSubSettingsPanel();
			}
		}

		public void ResetValue()
		{
			Settings?.ForEach(delegate(ISettingHandle _s)
			{
				_s.ResetValue();
			});
			MasterToggle?.ResetValue();
		}

		public void UpdateUIElement()
		{
			Settings?.ForEach(delegate(ISettingHandle _s)
			{
				_s.UpdateUIElement();
			});
			MasterToggle?.UpdateUIElement();
		}

		public void ReleaseDependencies()
		{
			MasterToggle.setting.OnValueChangeWithPrecedent.RemoveListener(OnMasterToggled);
		}

		public void InitUIElement()
		{
			throw new NotImplementedException();
		}

		public void HideUIElement()
		{
			GroupRef.gameObject.SetActive(value: false);
		}

		public void ShowUIElement()
		{
			GroupRef.gameObject.SetActive(value: true);
		}

		public void SetInteractable(bool isInteractable)
		{
			Settings?.ForEach(delegate(ISettingHandle s)
			{
				s.SetInteractable(isInteractable);
			});
		}

		private void OnMasterToggled(bool _newValue, bool _prevValue)
		{
			if (!_newValue)
			{
				CloseSubSettingsPanel();
			}
		}

		private void ToggleSubSettingsPanel()
		{
			GroupRef.SubSettingsPanel.SetActive(!GroupRef.SubSettingsPanel.activeSelf);
		}

		private void CloseSubSettingsPanel()
		{
			GroupRef.SubSettingsPanel.SetActive(value: false);
		}

		public SubSettingsGroupHandle()
		{
		}

		public SubSettingsGroupHandle(Setting<bool> masterSetting)
		{
			MasterToggle = new SubSettingsToggleMaster(masterSetting);
		}
	}
}
