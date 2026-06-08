using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik.CreativeMode;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class CreativeModeConfigurationUi : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<GroupTypeSliderReference, bool> _003C_003E9__11_0;

			public static Func<GroupTypeSliderReference, bool> _003C_003E9__11_1;

			internal bool _003COnEnable_003Eb__11_0(GroupTypeSliderReference x)
			{
				return x.groupType.id == GroupTypeId.TrainTracks;
			}

			internal bool _003COnEnable_003Eb__11_1(GroupTypeSliderReference x)
			{
				return x.groupType.id == GroupTypeId.TrainTracks;
			}
		}

		[SerializeField]
		private CreativeModeConfiguration creativeModeConfiguration;

		[SerializeField]
		private MainMenuScreen navigationBar;

		[SerializeField]
		private bool reactToInputDeviceChanged;

		[SerializeField]
		private bool visibleWhenGamepadConnected;

		[SerializeField]
		private List<GroupTypeSliderReference> groupTypeSliders;

		[SerializeField]
		private List<BiomeToggleReference> biomeToggles;

		[SerializeField]
		[FormerlySerializedAs("oneColumnToggles")]
		private bool singleToggleColumn;

		private Dictionary<GroupType, Slider> sliderByGroupType;

		private void Awake()
		{
			sliderByGroupType = new Dictionary<GroupType, Slider>();
			foreach (GroupTypeSliderReference groupTypeSlider in groupTypeSliders)
			{
				sliderByGroupType.Add(groupTypeSlider.groupType, groupTypeSlider.slider);
			}
		}

		private void Start()
		{
			creativeModeConfiguration.OnReset += UpdateUiBasedOnConfiguration;
			UpdateUiBasedOnConfiguration();
			if (reactToInputDeviceChanged)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged += UpdateUiBasedOnInputDevice;
			}
		}

		private void UpdateUiBasedOnInputDevice(InputDevice inputDevice)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (!visibleWhenGamepadConnected && inputDevice != InputDevice.MouseKeyboard)
				{
					Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.CreativeMode_Configuration_Gamepad);
				}
				else if (visibleWhenGamepadConnected && inputDevice == InputDevice.MouseKeyboard)
				{
					Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.CreativeMode_Configuration);
				}
			}
		}

		private void OnEnable()
		{
			foreach (BiomeToggleReference biomeToggle in biomeToggles)
			{
				biomeToggle.toggle.gameObject.SetActive(biomeToggle.biome.IsUnlocked);
			}
			UpdateUiBasedOnConfiguration();
			if (singleToggleColumn)
			{
				for (int i = 0; i < biomeToggles.Count; i++)
				{
					Navigation navigation = biomeToggles[i].toggle.navigation;
					navigation.selectOnUp = ((i == 0) ? ((Selectable)Enumerable.First(groupTypeSliders, (GroupTypeSliderReference x) => x.groupType.id == GroupTypeId.TrainTracks).slider) : ((Selectable)biomeToggles[i - 1].toggle));
					navigation.selectOnDown = ((biomeToggles.Count > i + 1 && biomeToggles[i + 1].biome.IsUnlocked) ? biomeToggles[i + 1].toggle : null);
					biomeToggles[i].toggle.navigation = navigation;
				}
				return;
			}
			for (int num = 0; num < biomeToggles.Count; num++)
			{
				Navigation navigation2 = biomeToggles[num].toggle.navigation;
				navigation2.selectOnLeft = ((num % 2 == 0) ? (navigationBar ? navigationBar.defaultSelectable : null) : biomeToggles[num - 1].toggle);
				navigation2.selectOnRight = ((biomeToggles.Count > num + 1 && biomeToggles[num + 1].biome.IsUnlocked) ? biomeToggles[num + 1].toggle : null);
				navigation2.selectOnDown = ((biomeToggles.Count > num + 2 && biomeToggles[num + 2].biome.IsUnlocked) ? biomeToggles[num + 2].toggle : null);
				navigation2.selectOnUp = ((num >= 2) ? ((Selectable)biomeToggles[num - 2].toggle) : ((Selectable)((groupTypeSliders.Count > 0) ? Enumerable.First(groupTypeSliders, (GroupTypeSliderReference x) => x.groupType.id == GroupTypeId.TrainTracks).slider : null)));
				biomeToggles[num].toggle.navigation = navigation2;
			}
		}

		private void UpdateUiBasedOnConfiguration()
		{
			foreach (GroupTypeSliderReference groupTypeSlider in groupTypeSliders)
			{
				groupTypeSlider.slider.SetValueWithoutNotify(creativeModeConfiguration.GetGroupTypeProbability(groupTypeSlider.groupType.id) * groupTypeSlider.slider.maxValue);
			}
			foreach (BiomeToggleReference biomeToggle in biomeToggles)
			{
				biomeToggle.toggle.SetIsOnWithoutNotify(!creativeModeConfiguration.excludedBiomes.Contains(biomeToggle.biome.Id));
			}
		}

		public void UpdateGroupTypeProbability(GroupType groupType)
		{
			creativeModeConfiguration.SetGroupTypeProbability(groupType.id, sliderByGroupType[groupType].value / sliderByGroupType[groupType].maxValue);
		}

		public void UpdateSelectedBiomes()
		{
			List<BiomeToggleReference> list = new List<BiomeToggleReference>();
			List<BiomeId> list2 = new List<BiomeId>();
			foreach (BiomeToggleReference biomeToggle in biomeToggles)
			{
				if (!biomeToggle.toggle.isOn)
				{
					list2.Add(biomeToggle.biome.Id);
				}
				else
				{
					list.Add(biomeToggle);
				}
				biomeToggle.toggle.interactable = true;
			}
			if (list2.Count == biomeToggles.Count)
			{
				list2.Remove(BiomeId.Standard);
			}
			creativeModeConfiguration.SetExcludedBiomes(list2);
			if (OverwritingSingleton<GameSession>.Instance.GameMode.id == GameModeId.Creative)
			{
				return;
			}
			string text = "";
			foreach (BiomeId item in list2)
			{
				string text2 = text;
				int num = (int)item;
				text = text2 + num;
			}
			PlayerPrefsAccessor.SetString("ExcludedBiomesClassic", text);
		}

		private void OnDestroy()
		{
			creativeModeConfiguration.OnReset -= UpdateUiBasedOnConfiguration;
			if (reactToInputDeviceChanged && (bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= UpdateUiBasedOnInputDevice;
			}
		}
	}
}
