using System.Collections.Generic;
using Client;
using Factory;
using Motorways.Constants;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class CombinedMeshThemeComponent : IThemeComponent
	{
		private const int InvalidIndex = -1;

		private static readonly ThemeComponentGroupTarget[] ThemeComponentGroupTargets = new ThemeComponentGroupTarget[9]
		{
			ThemeComponentGroupTarget.CarBase,
			ThemeComponentGroupTarget.CarHeadlights,
			ThemeComponentGroupTarget.CarWindows,
			ThemeComponentGroupTarget.BuildingBase,
			ThemeComponentGroupTarget.BuildingSide,
			ThemeComponentGroupTarget.BuildingTop,
			ThemeComponentGroupTarget.BuildingSelfShadow,
			ThemeComponentGroupTarget.HouseBase,
			ThemeComponentGroupTarget.HouseShadow
		};

		private static readonly ThemedMaterialType[] ThemedMaterialTypes = new ThemedMaterialType[3]
		{
			ThemedMaterialType.RoadInner,
			ThemedMaterialType.CarparkDetail,
			ThemedMaterialType.CarparkOutline
		};

		private readonly Vector4[] _colors = new Vector4[ThemedMaterialTypes.Length + MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS * ThemeComponentGroupTargets.Length];

		[Dependency]
		private CombinedMeshMaterials _combinedMeshMaterials;

		public static void SetRelativeVertexColorIndexForMesh(Mesh mesh, ThemeComponentGroupTarget groupTarget)
		{
			int id = RelativeComponentGroupTargetIndex(groupTarget);
			SetVertexColorIndexForMesh(mesh, id);
		}

		public static int RelativeThemeComponentGroupTargetOffsetForGroup(int groupIndex)
		{
			return groupIndex * ThemeComponentGroupTargets.Length;
		}

		public static void SetAbsoluteVertexColorIndexForMesh(Mesh mesh, ThemedMaterialType themedMaterialType)
		{
			int id = AbsoluteThemedMaterialTypeIndex(themedMaterialType);
			SetVertexColorIndexForMesh(mesh, id);
		}

		private static void SetVertexColorIndexForMesh(Mesh mesh, int id)
		{
			List<Color> list = new List<Color>();
			mesh.GetColors(list);
			if (list.Count == 0)
			{
				for (int i = 0; i < mesh.vertexCount; i++)
				{
					list.Add(new Color(id, 0f, 0f, 1f));
				}
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[j] = new Color(id, 0f, 0f, list[j].a);
				}
			}
			mesh.SetColors(list);
		}

		private static int AbsoluteThemedMaterialTypeIndex(ThemedMaterialType themedMaterialType)
		{
			for (int i = 0; i < ThemedMaterialTypes.Length; i++)
			{
				if (themedMaterialType == ThemedMaterialTypes[i])
				{
					return i;
				}
			}
			Diagnostics.FailAssert("ThemedMaterialType '{0}' is not registered in CombinedMeshThemeComponent", themedMaterialType);
			return -1;
		}

		private static int ThemeComponentGroupTargetOffsetForGroup(int groupIndex)
		{
			return ThemedMaterialTypes.Length + RelativeThemeComponentGroupTargetOffsetForGroup(groupIndex);
		}

		private static int RelativeComponentGroupTargetIndex(ThemeComponentGroupTarget groupTarget)
		{
			for (int i = 0; i < ThemeComponentGroupTargets.Length; i++)
			{
				if (groupTarget == ThemeComponentGroupTargets[i])
				{
					return ThemedMaterialTypes.Length + i;
				}
			}
			return -1;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_combinedMeshMaterials.vehicleMaterial.SetInt(ShaderConstants.ThemeComponentGroupTargetCount, ThemeComponentGroupTargets.Length);
		}

		public void ApplyTheme(ITheme theme)
		{
			Theme theme2 = (Theme)theme;
			for (int i = 0; i < ThemedMaterialTypes.Length; i++)
			{
				ThemedMaterialType type = ThemedMaterialTypes[i];
				_colors[i] = theme2.GetColor(type);
			}
			for (int j = 0; j < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; j++)
			{
				int num = ThemeComponentGroupTargetOffsetForGroup(j);
				for (int k = 0; k < ThemeComponentGroupTargets.Length; k++)
				{
					ThemeComponentGroupTarget groupTheme = ThemeComponentGroupTargets[k];
					_colors[num + k] = theme2.GetBuildingColor(j, groupTheme);
				}
			}
			_combinedMeshMaterials.vehicleMaterial.SetVectorArray(ShaderConstants.Colors, _colors);
			_combinedMeshMaterials.vertexColorMaterial.SetVectorArray(ShaderConstants.Colors, _colors);
			_combinedMeshMaterials.vehicleMaterial.SetColor(ShaderConstants.ShadowColor, theme2.GetColor(ThemedMaterialType.Shadow));
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Theme theme = (Theme)oldTheme;
			Theme theme2 = (Theme)newTheme;
			for (int i = 0; i < ThemedMaterialTypes.Length; i++)
			{
				ThemedMaterialType type = ThemedMaterialTypes[i];
				Color color = theme.GetColor(type);
				Color color2 = theme2.GetColor(type);
				_colors[i] = Color.Lerp(color, color2, progress);
			}
			for (int j = 0; j < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; j++)
			{
				int num = ThemeComponentGroupTargetOffsetForGroup(j);
				for (int k = 0; k < ThemeComponentGroupTargets.Length; k++)
				{
					ThemeComponentGroupTarget groupTheme = ThemeComponentGroupTargets[k];
					Color buildingColor = theme.GetBuildingColor(j, groupTheme);
					Color buildingColor2 = theme2.GetBuildingColor(j, groupTheme);
					_colors[num + k] = Color.Lerp(buildingColor, buildingColor2, progress);
				}
			}
			_combinedMeshMaterials.vehicleMaterial.SetVectorArray(ShaderConstants.Colors, _colors);
			_combinedMeshMaterials.vertexColorMaterial.SetVectorArray(ShaderConstants.Colors, _colors);
			Color value = Color.LerpUnclamped(theme.GetColor(ThemedMaterialType.Shadow), theme2.GetColor(ThemedMaterialType.Shadow), progress);
			_combinedMeshMaterials.vehicleMaterial.SetColor(ShaderConstants.ShadowColor, value);
			return ThemeBlendingResult.ContinueBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
