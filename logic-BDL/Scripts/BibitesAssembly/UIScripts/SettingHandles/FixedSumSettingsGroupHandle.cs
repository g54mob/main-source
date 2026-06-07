using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class FixedSumSettingsGroupHandle : SettingsListHandle
	{
		public float fixedSumValue = 1f;

		private List<FloatSettingSlider> sliders = new List<FloatSettingSlider>();

		private List<float> values = new List<float>();

		private bool alreadyDoingMemberChanged;

		private bool initialized;

		public FixedSumSettingsGroupHandle()
		{
			SerializationHelper.settingsLoadingDone.AddListener(EqualizeAfterLoad);
		}

		public override void ReleaseDependencies()
		{
			base.ReleaseDependencies();
			SerializationHelper.settingsLoadingDone.RemoveListener(EqualizeAfterLoad);
		}

		public override void CreateUIElement(GameObject _parent)
		{
			if (Settings == null)
			{
				return;
			}
			SettingsGroupReference groupReference = Object.Instantiate(UIPrefabsHolder.Instance.SettingGroupPrefab, _parent.transform).GetComponent<SettingsGroupReference>();
			groupReference.titleText.text = GroupTitle;
			Settings.ForEach(delegate(ISettingHandle s)
			{
				s.CreateUIElement(groupReference.settingsHolder);
				if (s is FloatSettingSlider floatSettingSlider)
				{
					sliders.Add(floatSettingSlider);
					floatSettingSlider.changeIsRevertable = false;
					floatSettingSlider.slider.onValueChanged.AddListener(OnAMemberChange);
					floatSettingSlider.sliderDragHandler.onBeginDrag.AddListener(DragStarted);
					floatSettingSlider.sliderDragHandler.onEndDrag.AddListener(OnEndDrag);
				}
			});
			initialized = true;
		}

		public override void HideUIElement()
		{
		}

		public override void ShowUIElement()
		{
		}

		private void EqualizeAfterLoad()
		{
			if (!initialized)
			{
				return;
			}
			float sum = Settings.Sum((ISettingHandle s) => (!(s is FloatSettingSlider floatSettingSlider)) ? 0f : floatSettingSlider.setting.val);
			Settings.ForEach(delegate(ISettingHandle s)
			{
				if (s is FloatSettingSlider floatSettingSlider)
				{
					floatSettingSlider.setting.SetValue(floatSettingSlider.setting.val * (fixedSumValue / sum));
				}
			});
		}

		private void DragStarted(float val)
		{
			values.Clear();
			foreach (FloatSettingSlider slider in sliders)
			{
				values.Add(slider.setting.val);
			}
		}

		private void OnEndDrag(float val)
		{
			List<IRevertableAction> list = new List<IRevertableAction>();
			for (int i = 0; i < sliders.Count; i++)
			{
				FloatSettingSlider floatSettingSlider = sliders[i];
				list.Add(new ChangeSettingHandleAction<NumericSetting<float>, float>(floatSettingSlider, values[i], floatSettingSlider.setting.val));
			}
			UINavigationManager.AddRevertableActionToStack(new RevertableGroupAction(list));
		}

		private void OnAMemberChange(float newValue)
		{
			if (!alreadyDoingMemberChanged && !SerializationHelper.loadingSettings)
			{
				alreadyDoingMemberChanged = true;
				FloatSettingSlider changed = sliders.OrderBy((FloatSettingSlider s) => Mathf.Abs(s.GetValue() - newValue)).FirstOrDefault();
				List<FloatSettingSlider> inBounds = sliders.Where((FloatSettingSlider s) => s != changed && s.setting.val >= s.setting.minValue && s.setting.val <= s.setting.maxValue).ToList();
				sliders.ForEach(delegate(FloatSettingSlider s)
				{
					s.setting.val = Mathf.Clamp(s.setting.val, s.setting.minValue, s.setting.maxValue);
				});
				float sum = sliders.Sum((FloatSettingSlider s) => s.setting.val);
				inBounds.ForEach(delegate(FloatSettingSlider s)
				{
					s.setting.SetValue(s.setting.val - (sum - fixedSumValue) / (float)inBounds.Count);
				});
				alreadyDoingMemberChanged = false;
			}
		}
	}
}
