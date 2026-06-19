using System.Collections.Generic;
using System.Text;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB2_TextureBakeResults : ScriptableObject
{
	public class Material2AtlasRectangleMapper
	{
		private MB2_TextureBakeResults tbr;

		private int[] numTimesMatAppearsInAtlas;

		private MB_MaterialAndUVRect[] matsAndSrcUVRect;

		public Material2AtlasRectangleMapper(MB2_TextureBakeResults res)
		{
			tbr = res;
			matsAndSrcUVRect = res.materialsAndUVRects;
			numTimesMatAppearsInAtlas = new int[matsAndSrcUVRect.Length];
			for (int i = 0; i < matsAndSrcUVRect.Length; i++)
			{
				if (numTimesMatAppearsInAtlas[i] > 1)
				{
					continue;
				}
				int num = 1;
				for (int j = i + 1; j < matsAndSrcUVRect.Length; j++)
				{
					if (matsAndSrcUVRect[i].material == matsAndSrcUVRect[j].material)
					{
						num++;
					}
				}
				numTimesMatAppearsInAtlas[i] = num;
				if (num <= 1)
				{
					continue;
				}
				for (int k = i + 1; k < matsAndSrcUVRect.Length; k++)
				{
					if (matsAndSrcUVRect[i].material == matsAndSrcUVRect[k].material)
					{
						numTimesMatAppearsInAtlas[k] = num;
					}
				}
			}
		}

		public bool TryMapMaterialToUVRect(Material mat, Mesh m, int submeshIdx, int idxInResultMats, MB3_MeshCombinerSingle.MeshChannelsCache meshChannelCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisCache, out MB_TextureTilingTreatment tilingTreatment, out Rect rectInAtlas, out Rect encapsulatingRectOut, out Rect sourceMaterialTilingOut, ref string errorMsg, MB2_LogLevel logLevel)
		{
			if (tbr.version < VERSION)
			{
				UpgradeToCurrentVersion(tbr);
			}
			tilingTreatment = MB_TextureTilingTreatment.unknown;
			if (tbr.materialsAndUVRects.Length == 0)
			{
				errorMsg = "The 'Texture Bake Result' needs to be re-baked to be compatible with this version of Mesh Baker. Please re-bake using the MB3_TextureBaker.";
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				return false;
			}
			if (mat == null)
			{
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				errorMsg = $"Mesh {m.name} Had no material on submesh {submeshIdx} cannot map to a material in the atlas";
				return false;
			}
			if (submeshIdx >= m.subMeshCount)
			{
				errorMsg = "Submesh index is greater than the number of submeshes";
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				return false;
			}
			int num = -1;
			for (int i = 0; i < matsAndSrcUVRect.Length; i++)
			{
				if (mat == matsAndSrcUVRect[i].material)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				errorMsg = $"Material {mat.name} could not be found in the Texture Bake Result";
				return false;
			}
			if (!tbr.resultMaterials[idxInResultMats].considerMeshUVs)
			{
				if (numTimesMatAppearsInAtlas[num] != 1)
				{
					Debug.LogError("There is a problem with this TextureBakeResults. FixOutOfBoundsUVs is false and a material appears more than once.");
				}
				MB_MaterialAndUVRect mB_MaterialAndUVRect = matsAndSrcUVRect[num];
				rectInAtlas = mB_MaterialAndUVRect.atlasRect;
				tilingTreatment = mB_MaterialAndUVRect.tilingTreatment;
				encapsulatingRectOut = mB_MaterialAndUVRect.GetEncapsulatingRect();
				sourceMaterialTilingOut = mB_MaterialAndUVRect.GetMaterialTilingRect();
				return true;
			}
			if (!meshAnalysisCache.TryGetValue(m.GetInstanceID(), out var value))
			{
				value = new MB_Utility.MeshAnalysisResult[m.subMeshCount];
				for (int j = 0; j < m.subMeshCount; j++)
				{
					MB_Utility.hasOutOfBoundsUVs(meshChannelCache.GetUv0Raw(m), m, ref value[j], j);
				}
				meshAnalysisCache.Add(m.GetInstanceID(), value);
			}
			bool flag = false;
			Rect rect = new Rect(0f, 0f, 0f, 0f);
			Rect rect2 = new Rect(0f, 0f, 0f, 0f);
			if (logLevel >= MB2_LogLevel.trace)
			{
				Debug.Log(string.Format("Trying to find a rectangle in atlas capable of holding tiled sampling rect for mesh {0} using material {1} meshUVrect={2}", m, mat, value[submeshIdx].uvRect.ToString("f5")));
			}
			for (int k = num; k < matsAndSrcUVRect.Length; k++)
			{
				MB_MaterialAndUVRect mB_MaterialAndUVRect2 = matsAndSrcUVRect[k];
				if (!(mB_MaterialAndUVRect2.material == mat))
				{
					continue;
				}
				if (mB_MaterialAndUVRect2.allPropsUseSameTiling)
				{
					rect = mB_MaterialAndUVRect2.allPropsUseSameTiling_samplingEncapsulatinRect;
					rect2 = mB_MaterialAndUVRect2.allPropsUseSameTiling_sourceMaterialTiling;
				}
				else
				{
					rect = mB_MaterialAndUVRect2.propsUseDifferntTiling_srcUVsamplingRect;
					rect2 = new Rect(0f, 0f, 1f, 1f);
				}
				if (IsMeshAndMaterialRectEnclosedByAtlasRect(mB_MaterialAndUVRect2.tilingTreatment, value[submeshIdx].uvRect, rect2, rect, logLevel))
				{
					if (logLevel >= MB2_LogLevel.trace)
					{
						Debug.Log("Found rect in atlas capable of containing tiled sampling rect for mesh " + m?.ToString() + " at idx=" + k);
					}
					num = k;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				MB_MaterialAndUVRect mB_MaterialAndUVRect3 = matsAndSrcUVRect[num];
				rectInAtlas = mB_MaterialAndUVRect3.atlasRect;
				tilingTreatment = mB_MaterialAndUVRect3.tilingTreatment;
				encapsulatingRectOut = mB_MaterialAndUVRect3.GetEncapsulatingRect();
				sourceMaterialTilingOut = mB_MaterialAndUVRect3.GetMaterialTilingRect();
				return true;
			}
			rectInAtlas = default(Rect);
			encapsulatingRectOut = default(Rect);
			sourceMaterialTilingOut = default(Rect);
			errorMsg = $"Could not find a tiled rectangle in the atlas capable of containing the uv and material tiling on mesh {m.name} for material {mat}. Was this mesh included when atlases were baked?";
			return false;
		}

		private void UpgradeToCurrentVersion(MB2_TextureBakeResults tbr)
		{
			if (tbr.version < 3252)
			{
				for (int i = 0; i < tbr.materialsAndUVRects.Length; i++)
				{
					tbr.materialsAndUVRects[i].allPropsUseSameTiling = true;
				}
			}
		}
	}

	public int version;

	public MB_MaterialAndUVRect[] materialsAndUVRects;

	public MB_MultiMaterial[] resultMaterials;

	public bool doMultiMaterial;

	public static int VERSION => 3252;

	public MB2_TextureBakeResults()
	{
		version = VERSION;
	}

	private void OnEnable()
	{
		if (version < 3251)
		{
			for (int i = 0; i < materialsAndUVRects.Length; i++)
			{
				materialsAndUVRects[i].allPropsUseSameTiling = true;
			}
		}
		version = VERSION;
	}

	public static MB2_TextureBakeResults CreateForMaterialsOnRenderer(GameObject[] gos, List<Material> matsOnTargetRenderer)
	{
		HashSet<Material> hashSet = new HashSet<Material>(matsOnTargetRenderer);
		for (int i = 0; i < gos.Length; i++)
		{
			if (gos[i] == null)
			{
				Debug.LogError($"Game object {i} in list of objects to add was null");
				return null;
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(gos[i]);
			if (gOMaterials.Length == 0)
			{
				Debug.LogError($"Game object {i} in list of objects to add no renderer");
				return null;
			}
			for (int j = 0; j < gOMaterials.Length; j++)
			{
				if (!hashSet.Contains(gOMaterials[j]))
				{
					hashSet.Add(gOMaterials[j]);
				}
			}
		}
		Material[] array = new Material[hashSet.Count];
		hashSet.CopyTo(array);
		MB2_TextureBakeResults mB2_TextureBakeResults = (MB2_TextureBakeResults)ScriptableObject.CreateInstance(typeof(MB2_TextureBakeResults));
		List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] != null)
			{
				MB_MaterialAndUVRect item = new MB_MaterialAndUVRect(array[k], new Rect(0f, 0f, 1f, 1f), allPropsUseSameTiling: true, new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 0f, 0f), MB_TextureTilingTreatment.none, "");
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		mB2_TextureBakeResults.resultMaterials = new MB_MultiMaterial[list.Count];
		for (int l = 0; l < list.Count; l++)
		{
			mB2_TextureBakeResults.resultMaterials[l] = new MB_MultiMaterial();
			List<Material> list2 = new List<Material>();
			list2.Add(list[l].material);
			mB2_TextureBakeResults.resultMaterials[l].sourceMaterials = list2;
			mB2_TextureBakeResults.resultMaterials[l].combinedMaterial = list[l].material;
			mB2_TextureBakeResults.resultMaterials[l].considerMeshUVs = false;
		}
		if (array.Length == 1)
		{
			mB2_TextureBakeResults.doMultiMaterial = false;
		}
		else
		{
			mB2_TextureBakeResults.doMultiMaterial = true;
		}
		mB2_TextureBakeResults.materialsAndUVRects = list.ToArray();
		return mB2_TextureBakeResults;
	}

	public bool DoAnyResultMatsUseConsiderMeshUVs()
	{
		if (resultMaterials == null)
		{
			return false;
		}
		for (int i = 0; i < resultMaterials.Length; i++)
		{
			if (resultMaterials[i].considerMeshUVs)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsMaterial(Material m)
	{
		for (int i = 0; i < materialsAndUVRects.Length; i++)
		{
			if (materialsAndUVRects[i].material == m)
			{
				return true;
			}
		}
		return false;
	}

	public string GetDescription()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Shaders:\n");
		HashSet<Shader> hashSet = new HashSet<Shader>();
		if (materialsAndUVRects != null)
		{
			for (int i = 0; i < materialsAndUVRects.Length; i++)
			{
				if (materialsAndUVRects[i].material != null)
				{
					hashSet.Add(materialsAndUVRects[i].material.shader);
				}
			}
		}
		foreach (Shader item in hashSet)
		{
			stringBuilder.Append("  ").Append(item.name).AppendLine();
		}
		stringBuilder.Append("Materials:\n");
		if (materialsAndUVRects != null)
		{
			for (int j = 0; j < materialsAndUVRects.Length; j++)
			{
				if (materialsAndUVRects[j].material != null)
				{
					stringBuilder.Append("  ").Append(materialsAndUVRects[j].material.name).AppendLine();
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static bool IsMeshAndMaterialRectEnclosedByAtlasRect(MB_TextureTilingTreatment tilingTreatment, Rect uvR, Rect sourceMaterialTiling, Rect samplingEncapsulatinRect, MB2_LogLevel logLevel)
	{
		Rect rect = default(Rect);
		rect = MB3_UVTransformUtility.CombineTransforms(ref uvR, ref sourceMaterialTiling);
		if (logLevel >= MB2_LogLevel.trace && logLevel >= MB2_LogLevel.trace)
		{
			Debug.Log("IsMeshAndMaterialRectEnclosedByAtlasRect Rect in atlas uvR=" + uvR.ToString("f5") + " sourceMaterialTiling=" + sourceMaterialTiling.ToString("f5") + "Potential Rect (must fit in encapsulating) " + rect.ToString("f5") + " encapsulating=" + samplingEncapsulatinRect.ToString("f5") + " tilingTreatment=" + tilingTreatment);
		}
		switch (tilingTreatment)
		{
		case MB_TextureTilingTreatment.edgeToEdgeX:
			if (MB3_UVTransformUtility.LineSegmentContainsShifted(samplingEncapsulatinRect.y, samplingEncapsulatinRect.height, rect.y, rect.height))
			{
				return true;
			}
			break;
		case MB_TextureTilingTreatment.edgeToEdgeY:
			if (MB3_UVTransformUtility.LineSegmentContainsShifted(samplingEncapsulatinRect.x, samplingEncapsulatinRect.width, rect.x, rect.width))
			{
				return true;
			}
			break;
		case MB_TextureTilingTreatment.edgeToEdgeXY:
			return true;
		default:
			if (MB3_UVTransformUtility.RectContainsShifted(ref samplingEncapsulatinRect, ref rect))
			{
				return true;
			}
			break;
		}
		return false;
	}
}
