using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SharedMaterialData
{
	private Transform _maskCanvas;

	private Canvas _canvas;

	private SuperTextMesh _stm;

	public Material refMat;

	public Font refFont;

	public Texture refTex;

	public Texture refMask;

	public Vector2 maskTiling;

	public FilterMode refFilter;

	public float uiStencilDepth;

	public SuperTextMesh.MaskMode uiMaskMode;

	private Material material;

	public string materialName;

	public Material AsMaterial
	{
		get
		{
			if (material == null)
			{
				material = new Material(refMat.shader);
			}
			else if (material.shader != refMat.shader)
			{
				material.shader = refMat.shader;
			}
			material.CopyPropertiesFromMaterial(refMat);
			material.SetTexture("_MainTex", refTex ?? refFont.material.mainTexture);
			material.SetTexture("_MaskTex", refMask);
			material.SetTextureScale("_MaskTex", maskTiling);
			if (material.HasProperty("_BaseMap"))
			{
				if (material.GetTexture("_BaseMap") != null)
				{
					material.GetTexture("_BaseMap").filterMode = refFilter;
				}
			}
			else if (material.HasProperty("_MainTex") && material.GetTexture("_MainTex") != null)
			{
				material.GetTexture("_MainTex").filterMode = refFilter;
			}
			if (material.HasProperty("_ZTestMode"))
			{
				if (_stm.uiMode)
				{
					int value = 4;
					if (_canvas != null && _canvas.renderMode == RenderMode.ScreenSpaceOverlay)
					{
						value = 8;
					}
					material.SetInt("_ZTestMode", value);
				}
				else if (material.GetInt("_ZTestMode") != 4 && material.GetInt("_ZTestMode") != 8)
				{
					material.SetInt("_ZTestMode", 4);
				}
			}
			if (uiStencilDepth > -1f)
			{
				int value2 = 8;
				if (uiStencilDepth > 0f)
				{
					value2 = ((uiMaskMode == SuperTextMesh.MaskMode.Inside) ? (_stm.uiMode ? 3 : 4) : ((uiMaskMode == SuperTextMesh.MaskMode.Outside) ? 7 : 0));
				}
				material.SetInt("_StencilComp", value2);
				material.SetInt("_Stencil", MaskDepthToID());
				material.SetInt("_StencilOp", 0);
				material.SetInt("_StencilWriteMask", (uiStencilDepth > 0f) ? 255 : 0);
				material.SetInt("_StencilReadMask", (uiStencilDepth > 0f) ? 255 : 0);
			}
			if (material.HasProperty("_FakeTexelSize"))
			{
				Texture texture = material.GetTexture("_MainTex");
				if (texture == null)
				{
					texture = Texture2D.whiteTexture;
				}
				material.SetVector("_FakeTexelSize", new Vector4(1f / (float)texture.width, 1f / (float)texture.height, texture.width, texture.height));
			}
			materialName = "";
			materialName += ((refMat != null) ? refMat.name : "NULL MATERTIAL");
			materialName += " - ";
			if (refFont != null)
			{
				materialName += refFont.name;
			}
			else if (refTex != null)
			{
				if (refMask != null)
				{
					materialName = materialName + refTex.name + "|" + refMask.name;
				}
				else
				{
					materialName = materialName + refTex.name + "|SILHOUETTE";
				}
			}
			else
			{
				materialName += "NULL";
			}
			materialName += " - ";
			materialName += refFilter;
			material.name = materialName;
			return material;
		}
	}

	public SharedMaterialData(SuperTextMesh stm)
	{
		SetValues(stm);
	}

	public SharedMaterialData(SuperTextMesh stm, STMTextInfo info)
	{
		SetValues(stm, info);
	}

	public void SetValues(SuperTextMesh stm)
	{
		_stm = stm;
		refMat = stm.textMaterial;
		refFont = stm.font;
		refFilter = stm.filterMode;
		if (stm.uiMode)
		{
			_maskCanvas = MaskUtilities.FindRootSortOverrideCanvas(stm.tr);
			_canvas = stm.tr.GetComponentInParent<Canvas>();
			uiStencilDepth = MaskUtilities.GetStencilDepth(stm.tr, _maskCanvas);
			uiMaskMode = stm.maskMode;
			return;
		}
		uiStencilDepth = -1f;
		SpriteMask componentInParent = stm.t.GetComponentInParent<SpriteMask>();
		if (componentInParent != null && componentInParent.enabled)
		{
			uiStencilDepth = 1f;
			uiMaskMode = stm.maskMode;
		}
	}

	public void SetValues(SuperTextMesh stm, STMTextInfo info)
	{
		_stm = stm;
		refMat = ((info.materialData != null) ? info.materialData.material : stm.textMaterial);
		refFont = ((info.fontData != null) ? info.fontData.font : stm.font);
		if (info.isQuad)
		{
			refFont = null;
			if (info.quadData.overrideFilterMode)
			{
				refFilter = info.quadData.filterMode;
			}
			else
			{
				refFilter = stm.filterMode;
			}
		}
		else if (info.fontData != null)
		{
			if (info.fontData.overrideFilterMode)
			{
				refFilter = info.fontData.filterMode;
			}
			else
			{
				refFilter = stm.filterMode;
			}
		}
		else
		{
			refFilter = stm.filterMode;
		}
		refMask = ((info.textureData != null) ? info.textureData.texture : null);
		maskTiling = ((info.textureData != null) ? info.textureData.tiling : Vector2.one);
		if (info.isQuad && !info.quadData.silhouette)
		{
			refMask = info.quadData.texture;
		}
		refTex = (info.isQuad ? info.quadData.texture : null);
		if (info.isQuad)
		{
			maskTiling = Vector2.one;
		}
		SetMaskingRelatedValues(stm);
	}

	public void SetMaskingRelatedValues(SuperTextMesh stm)
	{
		if (stm.uiMode)
		{
			_maskCanvas = MaskUtilities.FindRootSortOverrideCanvas(stm.tr);
			_canvas = stm.tr.GetComponentInParent<Canvas>();
			uiStencilDepth = MaskUtilities.GetStencilDepth(stm.tr, _maskCanvas);
			uiMaskMode = stm.maskMode;
			return;
		}
		uiStencilDepth = -1f;
		SpriteMask componentInParent = stm.t.GetComponentInParent<SpriteMask>();
		if (componentInParent != null && componentInParent.enabled)
		{
			uiStencilDepth = 1f;
		}
	}

	private int MaskDepthToID()
	{
		if (uiStencilDepth >= 8f)
		{
			Debug.Log("Attempting to use a mask with depth >= 8");
			return 0;
		}
		int num = ((_stm.maskMode == SuperTextMesh.MaskMode.Outside) ? (-1) : 0);
		return (int)(Mathf.Pow(2f, uiStencilDepth) - 1f + (float)num);
	}
}
