using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	public class GUI_PresetSwitcher : MonoBehaviour
	{
		private string activePresetName;

		[SerializeField]
		private Preset[] presets = new Preset[0];

		private Preset activePreset;

		public bool isObjectActivationOptionEnabled;

		public bool isComponentActivationOptionEnabled;

		public bool isObjectScaleOptionEnabled;

		public bool isRectSizeOptionEnabled;

		public bool isButtonInteractionOptionEnabled;

		public bool isCursorStateOptionEnabled;

		public bool isImageColorOptionEnabled;

		public bool isCanvasGroupOptionEnabled;

		public bool isSpriteOverrideOptionEnabled;

		public bool isLocalisedTextOptionEnabled;

		public bool isTextGroupOptionEnabled;

		public string ActivePresetName => activePresetName;

		private string RuleTogglesTitle
		{
			get
			{
				if (EnabledRuleTogglesCount <= 0)
				{
					return "Rule Toggles";
				}
				return $"Rule Toggles (enabled {EnabledRuleTogglesCount})";
			}
		}

		private int EnabledRuleTogglesCount => (isObjectActivationOptionEnabled ? 1 : 0) + (isComponentActivationOptionEnabled ? 1 : 0) + (isObjectScaleOptionEnabled ? 1 : 0) + (isRectSizeOptionEnabled ? 1 : 0) + (isButtonInteractionOptionEnabled ? 1 : 0) + (isCursorStateOptionEnabled ? 1 : 0) + (isImageColorOptionEnabled ? 1 : 0) + (isCanvasGroupOptionEnabled ? 1 : 0) + (isSpriteOverrideOptionEnabled ? 1 : 0) + (isLocalisedTextOptionEnabled ? 1 : 0) + (isTextGroupOptionEnabled ? 1 : 0);

		public event Action OnPresetChanged;

		public void ActivatePreset(PresetName presetName, bool forceActivate = false)
		{
			if (activePreset != null && !activePreset.HasCustomName && activePreset.Name == presetName && !forceActivate)
			{
				return;
			}
			Preset preset = null;
			Preset[] array = presets;
			foreach (Preset preset2 in array)
			{
				if (!preset2.HasCustomName && preset2.Name == presetName)
				{
					preset = preset2;
					break;
				}
			}
			if (preset != null)
			{
				bool num = activePreset != preset;
				activePreset = preset;
				activePreset.Apply();
				activePresetName = presetName.ToString();
				if (num)
				{
					this.OnPresetChanged?.Invoke();
				}
			}
			else
			{
				Debug.LogError(string.Format("[{0}] can't find preset to apply: {1}", "GUI_PresetSwitcher", presetName), base.gameObject);
			}
		}

		public void ActivatePreset(string presetCustomName, bool forceActivate = false)
		{
			if (activePreset != null && activePreset.HasCustomName && activePreset.CustomName == presetCustomName && !forceActivate)
			{
				return;
			}
			Preset preset = null;
			Preset[] array = presets;
			foreach (Preset preset2 in array)
			{
				if (preset2.HasCustomName && preset2.CustomName == presetCustomName)
				{
					preset = preset2;
					break;
				}
			}
			if (preset != null)
			{
				bool num = activePreset != preset;
				activePreset = preset;
				activePreset.Apply();
				activePresetName = presetCustomName;
				if (num)
				{
					this.OnPresetChanged?.Invoke();
				}
			}
			else
			{
				Debug.LogError("[GUI_PresetSwitcher] can't find preset to apply: " + presetCustomName, base.gameObject);
			}
		}

		private void ShowHideGameObjectActivationRules()
		{
			ToggleShowHide(typeof(GameObjectActivationRules), ref isObjectActivationOptionEnabled);
		}

		private void ShowHideMonoBehaviourActivationRules()
		{
			ToggleShowHide(typeof(MonoBehaviourActivationRules), ref isComponentActivationOptionEnabled);
		}

		private void ShowHideObjectScaleRules()
		{
			ToggleShowHide(typeof(ScaleRules), ref isObjectScaleOptionEnabled);
		}

		private void ShowHideRectSizeRules()
		{
			ToggleShowHide(typeof(RectSizeRules), ref isRectSizeOptionEnabled);
		}

		private void ShowHideButtonInteractionRules()
		{
			ToggleShowHide(typeof(ButtonInteractionRules), ref isButtonInteractionOptionEnabled);
		}

		private void ShowHideCursorStateRules()
		{
			ToggleShowHide(typeof(CursorStateSetterRules), ref isCursorStateOptionEnabled);
		}

		private void ShowHideImageColorRules()
		{
			ToggleShowHide(typeof(ImageColorRules), ref isImageColorOptionEnabled);
		}

		private void ShowHideCanvasGroupRules()
		{
			ToggleShowHide(typeof(CanvasGroupRules), ref isCanvasGroupOptionEnabled);
		}

		private void ShowHideSpriteOverrideRules()
		{
			ToggleShowHide(typeof(SpriteOverrideRules), ref isSpriteOverrideOptionEnabled);
		}

		private void ShowHideLocalisedTextRules()
		{
			ToggleShowHide(typeof(GUI_LocalisedTextRules), ref isLocalisedTextOptionEnabled);
		}

		private void ShowHideTextGroupRules()
		{
			ToggleShowHide(typeof(TextGroupRules), ref isTextGroupOptionEnabled);
		}

		private void ToggleShowHide(Type ruleType, ref bool optionFlag)
		{
			if (!TryShowHideOptionRules(ruleType, optionFlag))
			{
				optionFlag = !optionFlag;
			}
		}

		private bool TryShowHideOptionRules(Type ruleOptionType, bool isVisible)
		{
			Preset[] array;
			if (isVisible)
			{
				array = presets;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ShowHideOptionRules(ruleOptionType, isVisible: true);
				}
				return true;
			}
			array = presets;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsOptionRulesEmpty(ruleOptionType))
				{
					Debug.LogWarning("One of presets contains rule ruleOptionType");
					return false;
				}
			}
			array = presets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ShowHideOptionRules(ruleOptionType, isVisible: false);
			}
			return true;
		}

		private void OnPresetCollectionChanged()
		{
			Preset[] array = presets;
			foreach (Preset preset in array)
			{
				if (preset.Name == PresetName.None)
				{
					ShowVisibleOptionsOnPreset(preset);
				}
			}
		}

		private void ShowVisibleOptionsOnPreset(Preset preset)
		{
			if (isObjectActivationOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(GameObjectActivationRules), isVisible: true);
			}
			if (isComponentActivationOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(MonoBehaviourActivationRules), isVisible: true);
			}
			if (isObjectScaleOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(ScaleRules), isVisible: true);
			}
			if (isRectSizeOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(RectSizeRules), isVisible: true);
			}
			if (isButtonInteractionOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(ButtonInteractionRules), isVisible: true);
			}
			if (isCursorStateOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(CursorStateSetterRules), isVisible: true);
			}
			if (isImageColorOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(ImageColorRules), isVisible: true);
			}
			if (isCanvasGroupOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(CanvasGroupRules), isVisible: true);
			}
			if (isSpriteOverrideOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(SpriteOverrideRules), isVisible: true);
			}
			if (isLocalisedTextOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(GUI_LocalisedTextRules), isVisible: true);
			}
			if (isTextGroupOptionEnabled)
			{
				preset.ShowHideOptionRules(typeof(TextGroupRules), isVisible: true);
			}
		}
	}
}
