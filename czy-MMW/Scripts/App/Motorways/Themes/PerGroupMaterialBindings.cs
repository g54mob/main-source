using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Motorways.Themes
{
	[Serializable]
	public class PerGroupMaterialBindings
	{
		private class RenderersWithColor
		{
			public Color color = Color.magenta;

			public readonly List<Renderer> boundRenderers = new List<Renderer>();
		}

		[FormerlySerializedAs("sharedMat")]
		public Material sharedBuildingMaterial;

		public Material sharedVehicleMaterial;

		[EnumTypedArray(typeof(ThemeComponentGroupTarget))]
		[NonReorderable]
		public Material[] materialBindings = new Material[10];

		private MaterialPropertyBlock _materialPropertyBlock;

		private static readonly int ColorId = Shader.PropertyToID("_Color");

		private Dictionary<(int groupIndex, ThemeComponentGroupTarget componentGroupTarget), RenderersWithColor> _renderersWithColors = new Dictionary<(int, ThemeComponentGroupTarget), RenderersWithColor>();

		public PerGroupMaterialBindings()
		{
		}

		public PerGroupMaterialBindings(PerGroupMaterialBindings copy)
		{
			materialBindings = copy.materialBindings;
			sharedBuildingMaterial = copy.sharedBuildingMaterial;
			sharedVehicleMaterial = copy.sharedVehicleMaterial;
			for (int i = 0; i < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					ThemeComponentGroupTarget item = (ThemeComponentGroupTarget)j;
					_renderersWithColors.Add((i, item), new RenderersWithColor());
				}
			}
		}

		public void SetMaterialPropertyBlock(MaterialPropertyBlock materialPropertyBlock)
		{
			_materialPropertyBlock = materialPropertyBlock;
		}

		public Color GetBlendedColor(int groupIndex, ThemeComponentGroupTarget colorTarget, Theme oldTheme, Theme newTheme, float progress)
		{
			ColorGroup colorGroup = null;
			groupIndex %= Math.Min(oldTheme.buildingColorGroups.Count, newTheme.buildingColorGroups.Count);
			if (groupIndex >= 0 && groupIndex < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS && groupIndex < oldTheme.buildingColorGroups.Count && Diagnostics.Verify(oldTheme.buildingColorGroups[groupIndex] != null, "Color Group not set in theme {0} for index {1}", oldTheme, groupIndex))
			{
				colorGroup = oldTheme.buildingColorGroups[groupIndex];
			}
			ColorGroup colorGroup2 = null;
			if (groupIndex >= 0 && groupIndex < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS && groupIndex < newTheme.buildingColorGroups.Count && Diagnostics.Verify(newTheme.buildingColorGroups[groupIndex] != null, "Color Group not set in theme {0} for index {1}", newTheme, groupIndex))
			{
				colorGroup2 = newTheme.buildingColorGroups[groupIndex];
			}
			if (Diagnostics.Verify(colorGroup != null, "Old group is null for theme {0}!", oldTheme) && Diagnostics.Verify(colorGroup2 != null, "New group is null for theme {0}!", newTheme))
			{
				Color color = colorGroup.GetColor(colorTarget);
				Color color2 = colorGroup2.GetColor(colorTarget);
				return Color.LerpUnclamped(color, color2, progress);
			}
			return Color.magenta;
		}

		public void BindRendererToThemeTarget(Renderer renderer, int groupIndex, ThemeComponentGroupTarget themeTarget)
		{
			(int, ThemeComponentGroupTarget) key = (groupIndex, themeTarget);
			if (_renderersWithColors.TryGetValue(key, out var value))
			{
				if (!value.boundRenderers.Contains(renderer))
				{
					value.boundRenderers.Add(renderer);
				}
				if (themeTarget != ThemeComponentGroupTarget.CarHeadlights && themeTarget != ThemeComponentGroupTarget.CarHeadlightBeams && renderer.name != "TrainCarriageNAMEMUSTBECHANGEDINCODETOO")
				{
					bool flag = themeTarget == ThemeComponentGroupTarget.CarBase || themeTarget == ThemeComponentGroupTarget.CarWindows;
					renderer.sharedMaterial = (flag ? sharedVehicleMaterial : sharedBuildingMaterial);
				}
				renderer.GetPropertyBlock(_materialPropertyBlock);
				_materialPropertyBlock.SetColor(ColorId, value.color);
				renderer.SetPropertyBlock(_materialPropertyBlock);
			}
		}

		public bool UnbindRendererFromThemeTarget(Renderer renderer, int groupIndex)
		{
			bool result = false;
			foreach (KeyValuePair<(int, ThemeComponentGroupTarget), RenderersWithColor> renderersWithColor in _renderersWithColors)
			{
				if (renderersWithColor.Key.Item1 == groupIndex && renderersWithColor.Value.boundRenderers.Remove(renderer))
				{
					result = true;
					renderer.sharedMaterial = materialBindings[(int)renderersWithColor.Key.Item2];
				}
			}
			return result;
		}

		public void ApplyTheme(Theme oldTheme, Theme newTheme, float progress)
		{
			foreach (KeyValuePair<(int, ThemeComponentGroupTarget), RenderersWithColor> renderersWithColor in _renderersWithColors)
			{
				Color blendedColor = GetBlendedColor(renderersWithColor.Key.Item1, renderersWithColor.Key.Item2, oldTheme, newTheme, progress);
				renderersWithColor.Value.color = blendedColor;
				foreach (Renderer boundRenderer in renderersWithColor.Value.boundRenderers)
				{
					boundRenderer.GetPropertyBlock(_materialPropertyBlock);
					_materialPropertyBlock.SetColor(ColorId, blendedColor);
					boundRenderer.SetPropertyBlock(_materialPropertyBlock);
				}
			}
		}
	}
}
