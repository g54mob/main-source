using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	internal class MB3_TextureCombinerPackerMeshBaker : MB3_TextureCombinerPackerRoot
	{
		public override bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
		{
			return true;
		}

		public override IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
		{
			Rect[] uvRects = packedAtlasRects.rects;
			int atlasSizeX = packedAtlasRects.atlasX;
			int atlasSizeY = packedAtlasRects.atlasY;
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Generated atlas will be " + atlasSizeX + "x" + atlasSizeY);
			}
			for (int propIdx = 0; propIdx < data.numAtlases; propIdx++)
			{
				Texture2D atlas = null;
				ShaderTextureProperty property = data.texPropertyNames[propIdx];
				if (!MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(propIdx, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					atlas = null;
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("=== Not creating atlas for " + property.name + " because textures are null and default value parameters are the same.");
					}
				}
				else
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("=== Creating atlas for " + property.name);
					}
					GC.Collect();
					MB3_TextureCombinerPackerRoot.CreateTemporaryTexturesForAtlas(data.distinctMaterialTextures, combiner, propIdx, data);
					Color[][] atlasPixels = new Color[atlasSizeY][];
					for (int i = 0; i < atlasPixels.Length; i++)
					{
						atlasPixels[i] = new Color[atlasSizeX];
					}
					bool isNormalMap = false;
					if (property.isNormalMap)
					{
						isNormalMap = true;
					}
					for (int texSetIdx = 0; texSetIdx < data.distinctMaterialTextures.Count; texSetIdx++)
					{
						MB_TexSet texSet = data.distinctMaterialTextures[texSetIdx];
						MeshBakerMaterialTexture matTex = texSet.ts[propIdx];
						string s = "Creating Atlas '" + property.name + "' texture " + matTex.GetTexName();
						if (progressInfo != null)
						{
							progressInfo(s, 0.01f);
						}
						if (LOG_LEVEL >= MB2_LogLevel.trace)
						{
							UnityEngine.Debug.Log(string.Format("Adding texture {0} to atlas {1} for texSet {2} srcMat {3}", matTex.GetTexName(), property.name, texSetIdx, texSet.matsAndGOs.mats[0].GetMaterialName()));
						}
						Rect r = uvRects[texSetIdx];
						Texture2D t = texSet.ts[propIdx].GetTexture2D();
						int x = Mathf.RoundToInt(r.x * (float)atlasSizeX);
						int y = Mathf.RoundToInt(r.y * (float)atlasSizeY);
						int ww = Mathf.RoundToInt(r.width * (float)atlasSizeX);
						int hh = Mathf.RoundToInt(r.height * (float)atlasSizeY);
						if (ww == 0 || hh == 0)
						{
							UnityEngine.Debug.LogError("Image in atlas has no height or width " + r);
						}
						if (progressInfo != null)
						{
							progressInfo(s + " set ReadWrite flag", 0.01f);
						}
						if (textureEditorMethods != null)
						{
							textureEditorMethods.SetReadWriteFlag(t, true, true);
						}
						if (progressInfo != null)
						{
							progressInfo(s + "Copying to atlas: '" + matTex.GetTexName() + "'", 0.02f);
						}
						yield return CopyScaledAndTiledToAtlas(srcSamplingRect: texSet.ts[propIdx].GetEncapsulatingSamplingRect(), source: texSet.ts[propIdx], sourceMaterial: texSet, shaderPropertyName: property, targX: x, targY: y, targW: ww, targH: hh, padding: packedAtlasRects.padding[texSetIdx], atlasPixels: atlasPixels, isNormalMap: isNormalMap, data: data, combiner: combiner, progressInfo: progressInfo, LOG_LEVEL: LOG_LEVEL);
					}
					yield return data.numAtlases;
					if (progressInfo != null)
					{
						progressInfo("Applying changes to atlas: '" + property.name + "'", 0.03f);
					}
					atlas = new Texture2D(atlasSizeX, atlasSizeY, TextureFormat.ARGB32, true);
					for (int j = 0; j < atlasPixels.Length; j++)
					{
						atlas.SetPixels(0, j, atlasSizeX, 1, atlasPixels[j]);
					}
					atlas.Apply();
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Saving atlas " + property.name + " w=" + atlas.width + " h=" + atlas.height);
					}
				}
				atlases[propIdx] = atlas;
				if (progressInfo != null)
				{
					progressInfo("Saving atlas: '" + property.name + "'", 0.04f);
				}
				Stopwatch sw = new Stopwatch();
				sw.Start();
				if (data.resultType == MB2_TextureBakeResults.ResultType.atlas)
				{
					MB3_TextureCombinerPackerRoot.SaveAtlasAndConfigureResultMaterial(data, textureEditorMethods, atlases[propIdx], data.texPropertyNames[propIdx], propIdx);
				}
				combiner._destroyTemporaryTextures(data.texPropertyNames[propIdx].name);
			}
		}

		internal static IEnumerator CopyScaledAndTiledToAtlas(MeshBakerMaterialTexture source, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName, DRect srcSamplingRect, int targX, int targY, int targW, int targH, AtlasPadding padding, Color[][] atlasPixels, bool isNormalMap, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo = null, MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info)
		{
			Texture2D t = source.GetTexture2D();
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log(string.Format("CopyScaledAndTiledToAtlas: {0} inAtlasX={1} inAtlasY={2} inAtlasW={3} inAtlasH={4} paddX={5} paddY={6} srcSamplingRect={7}", t, targX, targY, targW, targH, padding.leftRight, padding.topBottom, srcSamplingRect));
			}
			float newWidth = targW;
			float newHeight = targH;
			float scx = (float)srcSamplingRect.width;
			float scy = (float)srcSamplingRect.height;
			float ox = (float)srcSamplingRect.x;
			float oy = (float)srcSamplingRect.y;
			int w = (int)newWidth;
			int h = (int)newHeight;
			if (data._considerNonTextureProperties)
			{
				t = combiner._createTextureCopy(shaderPropertyName.name, t);
				t = data.nonTexturePropertyBlender.TintTextureWithTextureCombiner(t, sourceMaterial, shaderPropertyName);
			}
			for (int i = 0; i < w; i++)
			{
				if (progressInfo != null && w > 0)
				{
					progressInfo("CopyScaledAndTiledToAtlas " + ((float)i / (float)w * 100f).ToString("F0"), 0.2f);
				}
				for (int j = 0; j < h; j++)
				{
					float u = (float)i / newWidth * scx + ox;
					float v = (float)j / newHeight * scy + oy;
					atlasPixels[targY + j][targX + i] = t.GetPixelBilinear(u, v);
				}
			}
			for (int k = 0; k < w; k++)
			{
				for (int l = 1; l <= padding.topBottom; l++)
				{
					atlasPixels[targY - l][targX + k] = atlasPixels[targY][targX + k];
					atlasPixels[targY + h - 1 + l][targX + k] = atlasPixels[targY + h - 1][targX + k];
				}
			}
			for (int m = 0; m < h; m++)
			{
				for (int n = 1; n <= padding.leftRight; n++)
				{
					atlasPixels[targY + m][targX - n] = atlasPixels[targY + m][targX];
					atlasPixels[targY + m][targX + w + n - 1] = atlasPixels[targY + m][targX + w - 1];
				}
			}
			for (int num = 1; num <= padding.leftRight; num++)
			{
				for (int num2 = 1; num2 <= padding.topBottom; num2++)
				{
					atlasPixels[targY - num2][targX - num] = atlasPixels[targY][targX];
					atlasPixels[targY + h - 1 + num2][targX - num] = atlasPixels[targY + h - 1][targX];
					atlasPixels[targY + h - 1 + num2][targX + w + num - 1] = atlasPixels[targY + h - 1][targX + w - 1];
					atlasPixels[targY - num2][targX + w + num - 1] = atlasPixels[targY][targX + w - 1];
					yield return null;
				}
				yield return null;
			}
		}
	}
}
