using System;
using System.Collections.Generic;
using System.Diagnostics;
using Client;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Themes
{
	[CreateAssetMenu(menuName = "Motorways/Themes/Theme")]
	public class Theme : ScriptableObject, ITheme
	{
		[Serializable]
		public class BlurSettings
		{
			public float blurLevelsRange = 0.7f;

			public float blurLevelsOffset = -0.1f;
		}

		public const string UpdateThemeAutomaticallyEditorPrefKey = "UpdateThemesAutomatically";

		[Space(10f)]
		public List<ColorGroup> buildingColorGroups;

		public List<ThemeGroup> themedColors;

		[Space(10f)]
		public DeleteModeOverrideList deleteModeOverrides;

		[Slider(-1, 1)]
		public float overrideDarkenMultiplier;

		[Slider(-1, 1)]
		public float overrideSaturationMultiplier;

		public List<DeleteModeOverride> additionalDeleteModeOverrides;

		public ThemeGroup customDeleteModeOverrides;

		[Space(10f)]
		public BlurSettings screenBackgroundBlur;

		[NonSerialized]
		private bool _colorsInitialized;

		[NonSerialized]
		private bool _deleteModeColorsInitialized;

		[NonSerialized]
		private Dictionary<ThemedMaterialType, List<ThemedColor>> _typeToColors;

		[NonSerialized]
		private Dictionary<ThemedMaterialType, List<ThemedColor>> _typeToDeleteModeColor;

		public Color GetColor(ThemedMaterialType type, string propertyToChange = "_Color")
		{
			if (!_colorsInitialized)
			{
				Initialize();
			}
			if (_typeToColors.TryGetValue(type, out var value))
			{
				if (value.Count == 1)
				{
					return value[0].color;
				}
				foreach (ThemedColor item in value)
				{
					if (item.propertyToChange == propertyToChange)
					{
						return item.color;
					}
				}
			}
			Diagnostics.Log.Error("Themes", "Theme {0} doesn't have a color of property {1} for {2}! Defaulting to magenta", base.name, propertyToChange, type);
			return Color.magenta;
		}

		public List<ThemedColor> GetColors(ThemedMaterialType type)
		{
			if (!_colorsInitialized)
			{
				Initialize();
			}
			if (_typeToColors.TryGetValue(type, out var value))
			{
				return value;
			}
			Diagnostics.Log.Error("Themes", "Theme {0} doesn't have any colors for {1}! Returning an empty list.", base.name, type);
			return new List<ThemedColor>();
		}

		public Color GetDeleteModeColor(ThemedMaterialType type, string propertyToChange = "_Color")
		{
			if (!_deleteModeColorsInitialized)
			{
				Initialize();
			}
			if (_typeToDeleteModeColor.TryGetValue(type, out var value))
			{
				if (value.Count == 1)
				{
					return value[0].color;
				}
				foreach (ThemedColor item in value)
				{
					if (item.propertyToChange == propertyToChange)
					{
						return item.color;
					}
				}
			}
			Diagnostics.Log.Error("Themes", "Theme {0} doesn't have a delete mode color of property {1} for {2}! Defaulting to magenta", base.name, propertyToChange, type);
			return Color.magenta;
		}

		private Color CalculateDeleteModeColor(ThemedMaterialType type, string propertyToChange = "_Color")
		{
			Color color = GetColor(type, propertyToChange);
			if (deleteModeOverrides != null && deleteModeOverrides.themeTypesToOverride.Contains(type))
			{
				Color.RGBToHSV(color, out var H, out var S, out var V);
				Vector3 additionalDeleteModeOverrideValues = GetAdditionalDeleteModeOverrideValues(type);
				H += additionalDeleteModeOverrideValues.x;
				S *= overrideSaturationMultiplier + additionalDeleteModeOverrideValues.y;
				V *= overrideDarkenMultiplier + additionalDeleteModeOverrideValues.z;
				Color color2 = Color.HSVToRGB(H, S, V);
				color2.a = color.a;
				color = color2;
			}
			return color;
		}

		private Vector3 GetAdditionalDeleteModeOverrideValues(ThemedMaterialType type)
		{
			foreach (DeleteModeOverride additionalDeleteModeOverride in additionalDeleteModeOverrides)
			{
				if (additionalDeleteModeOverride.type == type.ToString())
				{
					return new Vector3(additionalDeleteModeOverride.hueOverride, additionalDeleteModeOverride.additionalSaturationMultiplier, additionalDeleteModeOverride.additionalDarkenMultiplier);
				}
			}
			return Vector3.zero;
		}

		public Color GetBuildingColor(int groupIndex, ThemeComponentGroupTarget groupTheme)
		{
			if (groupIndex == -1)
			{
				return Color.white;
			}
			if (Diagnostics.Verify(groupIndex < buildingColorGroups.Count, this, "Unable to find matching building color group for index: {0} - targets.Length: {1}", groupIndex, buildingColorGroups.Count))
			{
				return buildingColorGroups[groupIndex].GetColor(groupTheme);
			}
			return Color.magenta;
		}

		public void Initialize()
		{
			_typeToColors = new Dictionary<ThemedMaterialType, List<ThemedColor>>();
			foreach (ThemeGroup themedColor2 in themedColors)
			{
				foreach (ThemedColor themedColor3 in themedColor2.themedColors)
				{
					if (!_typeToColors.ContainsKey(themedColor3.MaterialType))
					{
						_typeToColors.Add(themedColor3.MaterialType, new List<ThemedColor>());
					}
					_typeToColors[themedColor3.MaterialType].Add(themedColor3);
				}
			}
			_colorsInitialized = true;
			_typeToDeleteModeColor = new Dictionary<ThemedMaterialType, List<ThemedColor>>();
			foreach (ThemedColor themedColor4 in customDeleteModeOverrides.themedColors)
			{
				if (!_typeToDeleteModeColor.ContainsKey(themedColor4.MaterialType))
				{
					_typeToDeleteModeColor.Add(themedColor4.MaterialType, new List<ThemedColor>());
				}
				_typeToDeleteModeColor[themedColor4.MaterialType].Add(themedColor4);
			}
			foreach (ThemeGroup themedColor5 in themedColors)
			{
				foreach (ThemedColor themedColor in themedColor5.themedColors)
				{
					if (!_typeToDeleteModeColor.ContainsKey(themedColor.MaterialType))
					{
						_typeToDeleteModeColor.Add(themedColor.MaterialType, new List<ThemedColor>());
					}
					if (_typeToDeleteModeColor[themedColor.MaterialType].Find((ThemedColor existingColor) => existingColor.propertyToChange == themedColor.propertyToChange) == null)
					{
						Color color = CalculateDeleteModeColor(themedColor.MaterialType, themedColor.propertyToChange);
						_typeToDeleteModeColor[themedColor.MaterialType].Add(new ThemedColor(themedColor.MaterialType, color, themedColor.propertyToChange));
					}
				}
			}
			_deleteModeColorsInitialized = true;
		}

		[Button(null)]
		public void UpdateTheme()
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void UpdateInGameTheme()
		{
			if (Application.isPlaying && Application.isEditor)
			{
				(UnityEngine.Object.FindObjectOfType<AppRuntime>()?.App?.Scope?.Get<MotorwaysThemeDatabase>())?.UpdateThemeFromCurrentDefinition(forceUpdate: true);
			}
		}
	}
}
