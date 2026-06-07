using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Themes
{
	[Serializable]
	public class ThemeMaterialCollection
	{
		[NonReorderable]
		[EnumTypedArray(typeof(ThemedMaterialType))]
		public Material[] materialBindings = new Material[86];

		private Dictionary<ThemedMaterialType, List<Renderer>> _boundRenderers = new Dictionary<ThemedMaterialType, List<Renderer>>();

		[NonReorderable]
		[EnumTypedArray(typeof(ThemedMaterialType))]
		public MaterialPropertyBlock[] materialProperties = new MaterialPropertyBlock[86];

		private static readonly int MainTex = Shader.PropertyToID("_MainTex");

		private const float MountainDotSize = 0.2f;

		public void ConstructPropertyBlocks()
		{
			for (int i = 0; i < materialProperties.Length; i++)
			{
				materialProperties[i] = new MaterialPropertyBlock();
			}
		}

		public void BindRendererToThemeTarget(Renderer renderer, ThemedMaterialType themeTarget)
		{
			if (!_boundRenderers.ContainsKey(themeTarget))
			{
				_boundRenderers.Add(themeTarget, new List<Renderer>());
			}
			if (!_boundRenderers[themeTarget].Contains(renderer))
			{
				_boundRenderers[themeTarget].Add(renderer);
			}
			if ((int)themeTarget < materialProperties.Length && materialProperties[(int)themeTarget] != null)
			{
				renderer.SetPropertyBlock(materialProperties[(int)themeTarget]);
			}
		}

		public bool UnbindRendererFromThemeTarget(Renderer renderer, ThemedMaterialType themeTarget)
		{
			if (_boundRenderers.ContainsKey(themeTarget))
			{
				return _boundRenderers[themeTarget].Remove(renderer);
			}
			return false;
		}

		public Color GetBlendedColor(ThemedMaterialType colorTarget, Theme oldTheme, Theme newTheme, float progress, bool applyOverrides, bool blendOverrides, string propertyToChange = "_Color")
		{
			Color a = ((!blendOverrides) ? (applyOverrides ? oldTheme.GetDeleteModeColor(colorTarget, propertyToChange) : oldTheme.GetColor(colorTarget, propertyToChange)) : ((!applyOverrides) ? oldTheme.GetDeleteModeColor(colorTarget, propertyToChange) : oldTheme.GetColor(colorTarget, propertyToChange)));
			Color b = (applyOverrides ? newTheme.GetDeleteModeColor(colorTarget, propertyToChange) : newTheme.GetColor(colorTarget, propertyToChange));
			return Color.LerpUnclamped(a, b, progress);
		}

		public void ApplyTheme(Theme oldTheme, Theme newTheme, float progress, bool applyOverrides, bool blendOverrides)
		{
			for (int i = 0; i < 86; i++)
			{
				ThemedMaterialType themedMaterialType = (ThemedMaterialType)i;
				foreach (ThemedColor color in newTheme.GetColors(themedMaterialType))
				{
					if (Diagnostics.Verify(materialBindings.Length > i, "There aren't enough material bindings for enums! Check for an earlier assert for more information.") && materialBindings[i] != null)
					{
						Color blendedColor = GetBlendedColor(themedMaterialType, oldTheme, newTheme, progress, applyOverrides, blendOverrides, color.propertyToChange);
						materialBindings[i].SetColor(color.propertyToChange, blendedColor);
						materialProperties[i].SetColor(color.propertyToChange, blendedColor);
					}
				}
			}
			for (int j = 0; j < 86; j++)
			{
				ThemedMaterialType key = (ThemedMaterialType)j;
				if (!_boundRenderers.ContainsKey(key))
				{
					continue;
				}
				foreach (Renderer item in _boundRenderers[key])
				{
					if (item is SpriteRenderer spriteRenderer)
					{
						materialProperties[j].SetTexture(MainTex, spriteRenderer.sprite.texture);
					}
					item.SetPropertyBlock(materialProperties[j]);
				}
			}
		}

		public void SetWorldGridThickness(float thickness)
		{
			if (!_boundRenderers.ContainsKey(ThemedMaterialType.WorldGrid))
			{
				return;
			}
			for (int i = 0; i < _boundRenderers[ThemedMaterialType.WorldGrid].Count; i++)
			{
				Renderer renderer = _boundRenderers[ThemedMaterialType.WorldGrid][i];
				if (renderer == null)
				{
					_boundRenderers[ThemedMaterialType.WorldGrid].RemoveAt(i);
					i--;
				}
				else
				{
					renderer.sharedMaterial.SetFloat("_Thickness", thickness);
				}
			}
		}

		public void SetMountainDotDiagonalRatio(float newRatio)
		{
			for (int i = 32; i <= 34; i++)
			{
				materialBindings[i].GetFloat("_DiagonalThickness");
				materialBindings[i].SetFloat("_DotDiagonalRatio", Mathf.Lerp(0.2f, 1f, newRatio));
				materialProperties[i].SetFloat("_DotDiagonalRatio", Mathf.Lerp(0.2f, 1f, newRatio));
				if (!_boundRenderers.ContainsKey((ThemedMaterialType)i))
				{
					continue;
				}
				foreach (Renderer item in _boundRenderers[(ThemedMaterialType)i])
				{
					item.SetPropertyBlock(materialProperties[i]);
				}
			}
		}
	}
}
