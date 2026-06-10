using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public static class SharedMaterialDataStorage
{
	public static List<SharedMaterialData> allMaterials = new List<SharedMaterialData>();

	private static Transform Submesh_maskCanvas;

	private static float Submesh_stencilDepth;

	private static SharedMaterialData MaterialExists_material = null;

	public static SharedMaterialData DoesSharedMaterialExist(SuperTextMesh stm, STMTextInfo info)
	{
		if (stm.uiMode)
		{
			Submesh_maskCanvas = MaskUtilities.FindRootSortOverrideCanvas(stm.t);
			Submesh_stencilDepth = MaskUtilities.GetStencilDepth(stm.t, Submesh_maskCanvas);
		}
		else
		{
			Submesh_stencilDepth = -1f;
		}
		for (int i = 0; i < allMaterials.Count; i++)
		{
			MaterialExists_material = allMaterials[i];
			if (MaterialExists_material == null)
			{
				continue;
			}
			if (info.materialData != null)
			{
				if (MaterialExists_material.refMat != info.materialData.material)
				{
					continue;
				}
			}
			else if (MaterialExists_material.refMat != stm.textMaterial)
			{
				continue;
			}
			if (MaterialExists_material.uiStencilDepth != Submesh_stencilDepth || MaterialExists_material.uiMaskMode != stm.maskMode)
			{
				continue;
			}
			if (info.fontData != null)
			{
				if (info.quadData != null || MaterialExists_material.refFont == null || MaterialExists_material.refFont != info.fontData.font)
				{
					continue;
				}
				if (info.fontData.overrideFilterMode)
				{
					if (info.quadData != null && MaterialExists_material.refFilter != info.quadData.filterMode)
					{
						continue;
					}
				}
				else if (MaterialExists_material.refFilter != stm.filterMode)
				{
					continue;
				}
			}
			else if (info.quadData != null)
			{
				if (MaterialExists_material.refTex == null || MaterialExists_material.refTex != info.quadData.texture || MaterialExists_material.refTex == MaterialExists_material.refMask == info.quadData.silhouette)
				{
					continue;
				}
			}
			else if (MaterialExists_material.refFont != stm.font || MaterialExists_material.refTex != null || MaterialExists_material.refFilter != stm.filterMode)
			{
				continue;
			}
			if (!(info.textureData != null) || !(MaterialExists_material.refMask != info.textureData.texture))
			{
				return MaterialExists_material;
			}
		}
		return null;
	}

	public static SharedMaterialData DoesSharedMaterialExist(SuperTextMesh stm)
	{
		if (stm.uiMode)
		{
			Submesh_maskCanvas = MaskUtilities.FindRootSortOverrideCanvas(stm.t);
			Submesh_stencilDepth = MaskUtilities.GetStencilDepth(stm.t, Submesh_maskCanvas);
		}
		else
		{
			Submesh_stencilDepth = -1f;
		}
		for (int i = 0; i < allMaterials.Count; i++)
		{
			MaterialExists_material = allMaterials[i];
			if (MaterialExists_material != null && !(MaterialExists_material.refMat != stm.textMaterial) && MaterialExists_material.uiStencilDepth == Submesh_stencilDepth && MaterialExists_material.uiMaskMode == stm.maskMode && !(MaterialExists_material.refMask != null) && !(MaterialExists_material.refFont != stm.font) && !(MaterialExists_material.refTex != null) && MaterialExists_material.refFilter == stm.filterMode && !(MaterialExists_material.refMask != null))
			{
				return MaterialExists_material;
			}
		}
		return null;
	}
}
