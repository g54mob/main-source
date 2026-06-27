using System;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public class Preset
	{
		public PresetName Name;

		public string CustomName;

		public bool HasCustomName;

		[HideInInspector]
		public bool IsGameObjectActivationRulesVisible;

		[HideInInspector]
		public bool IsMonoBehaviourActivationRulesVisible;

		[HideInInspector]
		public bool IsScaleRulesVisible;

		[HideInInspector]
		public bool IsRectSizeRulesVisible;

		[HideInInspector]
		public bool IsCanvasGroupRulesVisible;

		[HideInInspector]
		public bool IsSpriteOverrideRulesVisible;

		[HideInInspector]
		public bool IsImageColorRulesVisible;

		[HideInInspector]
		public bool IsButtonInteractionRulesVisible;

		[HideInInspector]
		public bool IsTextGroupRulesVisible;

		[HideInInspector]
		public bool IsCursorStateSetterRulesVisible;

		[HideInInspector]
		public bool IsLocalisedTextRulesVisible;

		public GameObjectActivationRules GameObjectRules;

		public MonoBehaviourActivationRules ComponentRules;

		public ScaleRules ScaleRules;

		public RectSizeRules RectSizeRules;

		public CanvasGroupRules CanvasGroupRules;

		public SpriteOverrideRules SpriteOverrideRules;

		public ImageColorRules ImageColorRules;

		public ButtonInteractionRules ButtonInteractionRules;

		public TextGroupRules TextGroupRules;

		public CursorStateSetterRules CursorStateSetterRules;

		public GUI_LocalisedTextRules LocalisedTextRules;

		private string AllRules
		{
			get
			{
				if (VisibleRulesCount <= 0)
				{
					return "All Rules";
				}
				return $"All Rules ({VisibleRulesCount})";
			}
		}

		private int VisibleRulesCount => (IsGameObjectActivationRulesVisible ? 1 : 0) + (IsMonoBehaviourActivationRulesVisible ? 1 : 0) + (IsScaleRulesVisible ? 1 : 0) + (IsRectSizeRulesVisible ? 1 : 0) + (IsCanvasGroupRulesVisible ? 1 : 0) + (IsSpriteOverrideRulesVisible ? 1 : 0) + (IsImageColorRulesVisible ? 1 : 0) + (IsButtonInteractionRulesVisible ? 1 : 0) + (IsTextGroupRulesVisible ? 1 : 0) + (IsCursorStateSetterRulesVisible ? 1 : 0) + (IsLocalisedTextRulesVisible ? 1 : 0);

		public void Apply()
		{
			GameObjectRules.Apply();
			CanvasGroupRules.Apply();
			SpriteOverrideRules.Apply();
			ImageColorRules.Apply();
			ButtonInteractionRules.Apply();
			TextGroupRules.Apply();
			ScaleRules.Apply();
			RectSizeRules.Apply();
			ComponentRules.Apply();
			LocalisedTextRules.Apply();
			CursorStateSetterRules.Apply();
		}

		public void ShowHideOptionRules(Type ruleOptionType, bool isVisible)
		{
			if (ruleOptionType == typeof(GameObjectActivationRules))
			{
				IsGameObjectActivationRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(MonoBehaviourActivationRules))
			{
				IsMonoBehaviourActivationRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(ScaleRules))
			{
				IsScaleRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(RectSizeRules))
			{
				IsRectSizeRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(CanvasGroupRules))
			{
				IsCanvasGroupRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(SpriteOverrideRules))
			{
				IsSpriteOverrideRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(ImageColorRules))
			{
				IsImageColorRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(ButtonInteractionRules))
			{
				IsButtonInteractionRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(TextGroupRules))
			{
				IsTextGroupRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(CursorStateSetterRules))
			{
				IsCursorStateSetterRulesVisible = isVisible;
			}
			else if (ruleOptionType == typeof(GUI_LocalisedTextRules))
			{
				IsLocalisedTextRulesVisible = isVisible;
			}
			else
			{
				Debug.LogWarning($"Failed to change unhandled rule option type {ruleOptionType}");
			}
		}

		public bool IsOptionRulesEmpty(Type ruleOptionType)
		{
			if (ruleOptionType == typeof(GameObjectActivationRules))
			{
				return GameObjectRules.IsEmpty;
			}
			if (ruleOptionType == typeof(MonoBehaviourActivationRules))
			{
				return ComponentRules.IsEmpty;
			}
			if (ruleOptionType == typeof(ScaleRules))
			{
				return ScaleRules.IsEmpty;
			}
			if (ruleOptionType == typeof(RectSizeRules))
			{
				return RectSizeRules.IsEmpty;
			}
			if (ruleOptionType == typeof(CanvasGroupRules))
			{
				return CanvasGroupRules.IsEmpty;
			}
			if (ruleOptionType == typeof(SpriteOverrideRules))
			{
				return SpriteOverrideRules.IsEmpty;
			}
			if (ruleOptionType == typeof(ImageColorRules))
			{
				return ImageColorRules.IsEmpty;
			}
			if (ruleOptionType == typeof(ButtonInteractionRules))
			{
				return ButtonInteractionRules.IsEmpty;
			}
			if (ruleOptionType == typeof(TextGroupRules))
			{
				return TextGroupRules.IsEmpty;
			}
			if (ruleOptionType == typeof(CursorStateSetterRules))
			{
				return CursorStateSetterRules.IsEmpty;
			}
			if (ruleOptionType == typeof(GUI_LocalisedTextRules))
			{
				return LocalisedTextRules.IsEmpty;
			}
			return WarnAndReturnFalse(ruleOptionType);
		}

		private bool WarnAndReturnFalse(Type ruleOptionType)
		{
			Debug.LogWarning($"Failed to check unhandled rule option type {ruleOptionType}");
			return false;
		}

		private bool IsInvalidPresetName()
		{
			return Name == PresetName.None;
		}

		private bool IsInvalidCustomName()
		{
			return string.IsNullOrEmpty(CustomName);
		}
	}
}
