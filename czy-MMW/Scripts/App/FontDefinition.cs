using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class FontDefinition
{
	[SerializeField]
	private string _charset;

	[SerializeField]
	private TMP_FontAsset _font;

	private Dictionary<long, Material> _customMaterials = new Dictionary<long, Material>();

	private static int ID_GlowInner = Shader.PropertyToID("_GlowInner");

	public string Charset => _charset;

	public TMP_FontAsset FontAsset => _font;

	public Material GetCustomMaterial(FontStyles style, Material baseCustomMaterial)
	{
		long key = ((long)baseCustomMaterial.GetHashCode() << 32) | (long)style;
		if (_customMaterials.TryGetValue(key, out var value))
		{
			return value;
		}
		Material material = _font.material;
		if ((style & FontStyles.Bold) == FontStyles.Bold)
		{
			for (int num = _font.fontWeightTable.Length - 1; num >= 0; num--)
			{
				TMP_FontAsset regularTypeface = _font.fontWeightTable[num].regularTypeface;
				if (regularTypeface != null)
				{
					material = regularTypeface.material;
					break;
				}
			}
		}
		Material material2 = new Material(material);
		CopyKeyword(material2, baseCustomMaterial, ShaderUtilities.Keyword_Bevel);
		CopyKeyword(material2, baseCustomMaterial, ShaderUtilities.Keyword_Glow);
		CopyKeyword(material2, baseCustomMaterial, ShaderUtilities.Keyword_Underlay);
		CopyKeyword(material2, baseCustomMaterial, ShaderUtilities.Keyword_Ratios);
		CopyKeyword(material2, baseCustomMaterial, ShaderUtilities.Keyword_Outline);
		CopyColor(material2, baseCustomMaterial, ShaderUtilities.ID_UnderlayColor);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_UnderlayOffsetX);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_UnderlayOffsetY);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_UnderlayDilate);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_UnderlaySoftness);
		CopyColor(material2, baseCustomMaterial, ShaderUtilities.ID_GlowColor);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_GlowOffset);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_GlowPower);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_GlowOuter);
		CopyFloat(material2, baseCustomMaterial, ID_GlowInner);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_ScaleRatio_A);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_ScaleRatio_B);
		CopyFloat(material2, baseCustomMaterial, ShaderUtilities.ID_ScaleRatio_C);
		_customMaterials.Add(key, material2);
		return material2;
	}

	private void CopyKeyword(Material targetMaterial, Material sourceMaterial, string keyword)
	{
		if (sourceMaterial.IsKeywordEnabled(keyword))
		{
			targetMaterial.EnableKeyword(keyword);
		}
		else
		{
			targetMaterial.DisableKeyword(keyword);
		}
	}

	private void CopyColor(Material targetMaterial, Material sourceMaterial, int nameId)
	{
		targetMaterial.SetColor(nameId, sourceMaterial.GetColor(nameId));
	}

	private void CopyFloat(Material targetMaterial, Material sourceMaterial, int nameId)
	{
		targetMaterial.SetFloat(nameId, sourceMaterial.GetFloat(nameId));
	}
}
