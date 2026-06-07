using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class ChooseOneSettingHandle : SettingsListHandle
	{
		private List<SettingToggle> offToggles = new List<SettingToggle>();

		private List<Setting<bool>> settings = new List<Setting<bool>>();

		private SettingToggle onToggle;

		private bool alreadyDoingMemberChanged;

		private bool initialized;

		public ChooseOneSettingHandle()
		{
			SerializationHelper.settingsLoadingDone.AddListener(EqualizeAfterLoad);
		}

		public override void ReleaseDependencies()
		{
			base.ReleaseDependencies();
			SerializationHelper.settingsLoadingDone.RemoveListener(EqualizeAfterLoad);
			settings.ForEach(delegate(Setting<bool> s)
			{
				s.UnSubscribe(OnAMemberChange);
			});
		}

		public override void CreateUIElement(GameObject _parent)
		{
			if (Settings == null)
			{
				return;
			}
			SettingsGroupReference groupReference = Object.Instantiate(UIPrefabsHolder.Instance.SettingGroupPrefab, _parent.transform).GetComponent<SettingsGroupReference>();
			groupReference.titleText.text = GroupTitle;
			settings.ForEach(delegate(Setting<bool> s)
			{
				s.UnSubscribe(OnAMemberChange);
			});
			settings.Clear();
			Settings.ForEach(delegate(ISettingHandle s)
			{
				s.CreateUIElement(groupReference.settingsHolder);
				if (s is SettingToggle settingToggle)
				{
					offToggles.Add(settingToggle);
					settingToggle.changeIsRevertable = false;
					settings.Add(settingToggle.setting);
					settingToggle.setting.Subscribe(OnAMemberChange);
				}
			});
			onToggle = offToggles.FirstOrDefault((SettingToggle t) => t.toggle.isOn) ?? offToggles[0];
			offToggles.Remove(onToggle);
			initialized = true;
		}

		private void EqualizeAfterLoad()
		{
			if (initialized)
			{
				if (onToggle != null)
				{
					offToggles.Add(onToggle);
				}
				onToggle = offToggles.FirstOrDefault((SettingToggle t) => t.toggle.isOn) ?? offToggles[0];
				offToggles.Remove(onToggle);
				ChangingMember();
				onToggle.setting.SetValue(_value: true);
				offToggles.ForEach(delegate(SettingToggle t)
				{
					t.setting.SetValue(_value: false);
				});
				ChangingMemberDone();
			}
		}

		public override void HideUIElement()
		{
		}

		public override void ShowUIElement()
		{
		}

		private void ChangingMember()
		{
			alreadyDoingMemberChanged = true;
		}

		private void ChangingMemberDone()
		{
			alreadyDoingMemberChanged = false;
		}

		public void OnAMemberChange(bool newValue)
		{
			if (!alreadyDoingMemberChanged && initialized && !SerializationHelper.loadingSettings)
			{
				ChangingMember();
				List<IRevertableAction> obj = new List<IRevertableAction>
				{
					new RevertableAction(ChangingMember, ChangingMember)
				};
				onToggle.setting.SetValue(_value: false);
				obj.Add(new ChangeSettingHandleAction<Setting<bool>, bool>(onToggle, from: true, to: false, addToStack: false));
				SettingToggle item = onToggle;
				onToggle = offToggles.FirstOrDefault((SettingToggle t) => t.toggle.isOn == newValue) ?? offToggles[0];
				offToggles.Remove(onToggle);
				offToggles.Add(item);
				onToggle.setting.SetValue(_value: true);
				obj.Add(new ChangeSettingHandleAction<Setting<bool>, bool>(onToggle, from: false, to: true, addToStack: false));
				obj.Add(new RevertableAction(ChangingMemberDone, ChangingMemberDone));
				UINavigationManager.AddRevertableActionToStack(new RevertableGroupAction(obj));
				ChangingMemberDone();
			}
		}
	}
}
