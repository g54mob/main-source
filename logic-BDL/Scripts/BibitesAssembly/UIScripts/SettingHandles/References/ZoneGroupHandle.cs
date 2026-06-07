using System.Collections.Generic;
using SettingScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts.SettingHandles.References
{
	public class ZoneGroupHandle : PoolableDictItem<ZoneGroupSettings, ZoneGroupHandle>
	{
		public ZoneGroupSettings settings;

		[SerializeField]
		private GameObject orderButtonsHolder;

		[SerializeField]
		private ReorderableItem reorderer;

		[SerializeField]
		private ZoneSettingsHandle templateHandle;

		[SerializeField]
		private GameObject deleteButton;

		[SerializeField]
		private FloatValueTextHandle countValue;

		[SerializeField]
		private TextLineReference groupNameRef;

		[SerializeField]
		private SettingToggleReference scaleWithSimToggleRef;

		[SerializeField]
		private SettingSliderReference zoneDensitySliderRef;

		[SerializeField]
		private SettingSliderReference zoneCountSliderRef;

		[SerializeField]
		private GameObject body;

		[SerializeField]
		private Button openBodyButton;

		[SerializeField]
		private Button closeBodyButton;

		private TextLineHandle groupName = new TextLineHandle();

		private SettingToggle scaleWithSimToggle = new SettingToggle();

		private LogFloatSettingSlider zoneDensitySlider = new LogFloatSettingSlider(10f);

		private LogIntSettingSlider zoneCountSlider = new LogIntSettingSlider(10f);

		private List<ISettingHandle> settingsHandles;

		public UnityEvent<ZoneGroupHandle> onGroupDelete = new UnityEvent<ZoneGroupHandle>();

		private int prevCount = -1;

		public void ApplyChangesToAllZones()
		{
			settings.ApplyChangesToAllZones();
		}

		public void GenerateZones()
		{
			settings.GenerateZones();
		}

		public override void Initialize()
		{
			base.Initialize();
			groupName.LinkToRef(groupNameRef);
			scaleWithSimToggle.LinkToRef(scaleWithSimToggleRef);
			zoneDensitySlider.LinkToRef(zoneDensitySliderRef);
			zoneCountSlider.LinkToRef(zoneCountSliderRef);
			openBodyButton.onClick.AddListener(delegate
			{
				ToggleBody(val: true);
			});
			closeBodyButton.onClick.AddListener(delegate
			{
				ToggleBody(val: false);
			});
			settingsHandles = new List<ISettingHandle> { groupName, scaleWithSimToggle, zoneDensitySlider, zoneCountSlider };
			ToggleBody(val: true);
			templateHandle.Initialize();
		}

		public override void AssignKey(ZoneGroupSettings groupSettings)
		{
			AssignSetting(groupSettings);
		}

		public void AssignSetting(ZoneGroupSettings val)
		{
			settings = val;
			groupName.setting = settings.groupName;
			scaleWithSimToggle.setting = settings.scaleWithSim;
			zoneDensitySlider.setting = settings.zoneDensity;
			zoneCountSlider.setting = settings.zoneCount;
			settingsHandles.ForEach(delegate(ISettingHandle h)
			{
				h.InitUIElement();
			});
			settings.scaleWithSim.Subscribe(OnCountTypeChange);
			settings.zoneCount.Subscribe(OnCountChange);
			settings.zoneDensity.Subscribe(OnCountChange);
			settings.onAnyChangeFromTemplate.AddListener(ApplyChangesToAllZones);
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(OnChangeSimSize);
			OnCountTypeChange(settings.scaleWithSim.val);
			OnCountChange();
			templateHandle.AssignSetting(settings.template);
		}

		public override void Retire()
		{
			base.Retire();
			settings.scaleWithSim.UnSubscribe(OnCountTypeChange);
			settings.zoneCount.UnSubscribe(OnCountChange);
			settings.zoneDensity.UnSubscribe(OnCountChange);
			settings.onAnyChangeFromTemplate.RemoveListener(ApplyChangesToAllZones);
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(OnChangeSimSize);
			settingsHandles.ForEach(delegate(ISettingHandle h)
			{
				h.ReleaseDependencies();
			});
		}

		public void OnChangeSimSize(float value)
		{
			if (settings != null)
			{
				OnCountChange();
			}
		}

		private void OnCountTypeChange(bool val)
		{
			IForceUpdateSetting forceUpdateSetting;
			if (!val)
			{
				IForceUpdateSetting zoneCount = settings.zoneCount;
				forceUpdateSetting = zoneCount;
			}
			else
			{
				IForceUpdateSetting zoneCount = settings.zoneDensity;
				forceUpdateSetting = zoneCount;
			}
			forceUpdateSetting.ForceUpdate();
			zoneDensitySliderRef.gameObject.SetActive(val);
			zoneCountSliderRef.gameObject.SetActive(!val);
		}

		public void ToggleBody(bool val)
		{
			groupName.AllowEditOnClick(val);
			deleteButton.SetActive(val);
			body.SetActive(val);
			orderButtonsHolder.SetActive(val);
			if (val)
			{
				reorderer.UpdateButtons();
			}
			openBodyButton.gameObject.SetActive(!val);
			closeBodyButton.gameObject.SetActive(val);
		}

		public void OnCountChange()
		{
			if (settings.count != prevCount)
			{
				prevCount = settings.count;
				countValue.UpdateValue(settings.count);
				if (settings.zones.Count != settings.count)
				{
					settings.GenerateZones();
				}
			}
		}

		public void DeleteGroup()
		{
			onGroupDelete.Invoke(this);
		}
	}
}
