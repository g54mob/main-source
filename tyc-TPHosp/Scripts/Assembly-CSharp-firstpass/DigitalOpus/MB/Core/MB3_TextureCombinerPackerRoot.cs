using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	internal abstract class MB3_TextureCombinerPackerRoot : MB_ITextureCombinerPacker
	{
		internal static void CreateTemporaryTexturesForAtlas(List<MB_TexSet> distinctMaterialTextures, MB3_TextureCombiner combiner, int propIdx, MB3_TextureCombinerPipeline.TexturePipelineData data)
		{
			for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
			{
				MB_TexSet mB_TexSet = data.distinctMaterialTextures[i];
				if (mB_TexSet.ts[propIdx].isNull)
				{
					Color colorForTemporaryTexture = data.nonTexturePropertyBlender.GetColorForTemporaryTexture(mB_TexSet.matsAndGOs.mats[0].mat, data.texPropertyNames[propIdx]);
					mB_TexSet.CreateColoredTexToReplaceNull(data.texPropertyNames[propIdx].name, propIdx, data._fixOutOfBoundsUVs, combiner, colorForTemporaryTexture);
				}
			}
		}

		public static AtlasPackingResult[] CalculateAtlasRectanglesStatic(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
			{
				list.Add(new Vector2(data.distinctMaterialTextures[i].idealWidth, data.distinctMaterialTextures[i].idealHeight));
			}
			MB2_TexturePacker mB2_TexturePacker = MB3_TextureCombinerPipeline.CreateTexturePacker(data._packingAlgorithm);
			mB2_TexturePacker.atlasMustBePowerOfTwo = data._meshBakerTexturePackerForcePowerOfTwo;
			List<AtlasPadding> list2 = new List<AtlasPadding>();
			for (int j = 0; j < list.Count; j++)
			{
				AtlasPadding item = new AtlasPadding
				{
					topBottom = data._atlasPadding,
					leftRight = data._atlasPadding
				};
				if (data._packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal)
				{
					item.leftRight = 0;
				}
				if (data._packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical)
				{
					item.topBottom = 0;
				}
				list2.Add(item);
			}
			return mB2_TexturePacker.GetRects(list, list2, data._maxAtlasWidth, data._maxAtlasHeight, doMultiAtlas);
		}

		public static void MakeProceduralTexturesReadable(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
		{
			Debug.LogError("TODO this should be done as close to textures being used as possible due to memory issues.");
		}

		public virtual IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
		{
			for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
			{
				for (int j = 0; j < data.texPropertyNames.Count; j++)
				{
					MeshBakerMaterialTexture meshBakerMaterialTexture = data.distinctMaterialTextures[i].ts[j];
					if (!meshBakerMaterialTexture.isNull && textureEditorMethods != null)
					{
						Texture texture2D = meshBakerMaterialTexture.GetTexture2D();
						progressInfo?.Invoke($"Convert texture {texture2D} to readable format ", 0.5f);
						textureEditorMethods.AddTextureFormat((Texture2D)texture2D, data.texPropertyNames[j].isNormalMap);
					}
				}
			}
			yield break;
		}

		public virtual AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
		{
			return CalculateAtlasRectanglesStatic(data, doMultiAtlas, LOG_LEVEL);
		}

		public abstract IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL);
	}
}
