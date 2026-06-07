using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

namespace JBooth.MicroVerseCore
{
	public class PreviewRenderer
	{
		public enum FilterSetType
		{
			Height = 0,
			Slope = 1,
			Angle = 2,
			Curvature = 3,
			Flow = 4,
			Texture = 5
		}

		private static Material brushPreviewMat;

		private static Material noiseMat;

		private static Material filterSetMat;

		public static Noise noisePreview;

		public static FilterSet.Filter filter;

		public static FilterSet filterSet;

		public static FilterSetType filterSetType;

		private static float kNormalizedHeightScale => PaintContext.kNormalizedHeightScale;

		public static void DrawNoisePreview()
		{
			if (noisePreview == null || MicroVerse.instance == null)
			{
				return;
			}
			if (!noiseMat)
			{
				noiseMat = new Material(Shader.Find("Hidden/MicroVerse/PreviewNoiseWorld"));
			}
			Terrain[] terrains = MicroVerse.instance.terrains;
			foreach (Terrain terrain in terrains)
			{
				if (terrain != null)
				{
					List<string> list = new List<string>();
					int vertexCount = SetupDrawing(terrain, noiseMat);
					noiseMat.SetVector("_TerrainSize", new Vector2(terrain.terrainData.size.x, terrain.terrainData.size.z));
					noiseMat.SetTexture("_NoiseTexture", noisePreview.texture);
					noiseMat.SetTextureScale("_NoiseTexture", noisePreview.GetTextureScale());
					noiseMat.SetTextureOffset("_NoiseTexture", noisePreview.GetTextureOffset());
					noisePreview.EnableKeyword(noiseMat, "_", list);
					noiseMat.SetVector("_Param", noisePreview.GetParamVector());
					noiseMat.SetVector("_Param2", noisePreview.GetParam2Vector());
					noiseMat.SetFloat("_NoiseChannel", (float)noisePreview.channel);
					noiseMat.SetColor("_Color", MicroVerse.instance.options.colors.noisePreviewColor);
					noiseMat.SetVector("_Remap", new Vector2(0f - noisePreview.displayGamma, 1f + noisePreview.displayGamma));
					noiseMat.shaderKeywords = list.ToArray();
					Graphics.DrawProceduralNow(MeshTopology.Triangles, vertexCount);
				}
			}
		}

		public static void DrawFilterSetPreview()
		{
			if ((filter == null && filterSetType != FilterSetType.Texture) || (filterSetType == FilterSetType.Texture && filterSet == null) || MicroVerse.instance == null)
			{
				return;
			}
			if (!filterSetMat)
			{
				filterSetMat = new Material(Shader.Find("Hidden/MicroVerse/PreviewFilterWorld"));
			}
			Terrain[] terrains = MicroVerse.instance.terrains;
			foreach (Terrain terrain in terrains)
			{
				if (terrain == null)
				{
					continue;
				}
				float num = terrain.terrainData.heightmapScale.y * 2f;
				if (filter != null)
				{
					filterSetMat.SetVector("_HeightRange", filter.range / num);
					filterSetMat.SetVector("_HeightSmoothness", filter.smoothness / num);
					filterSetMat.SetVector("_SlopeRange", filter.range * (MathF.PI / 180f));
					filterSetMat.SetVector("_SlopeSmoothness", filter.smoothness * (MathF.PI / 180f));
					filterSetMat.SetVector("_AngleRange", filter.range * (MathF.PI / 180f));
					filterSetMat.SetVector("_AngleSmoothness", filter.smoothness * (MathF.PI / 180f));
					filterSetMat.SetVector("_CurvatureRange", filter.range);
					filterSetMat.SetVector("_CurvatureSmoothness", filter.smoothness);
					filterSetMat.SetVector("_FlowRange", filter.range);
					filterSetMat.SetVector("_FlowSmoothness", filter.smoothness);
					filterSetMat.SetColor("_Color", MicroVerse.instance.options.colors.filterPreviewColor);
				}
				filterSetMat.SetTexture("_Normalmap", terrain.normalmapTexture);
				filterSetMat.DisableKeyword("_HEIGHTFILTER");
				filterSetMat.DisableKeyword("_SLOPEFILTER");
				filterSetMat.DisableKeyword("_ANGLEFILTER");
				filterSetMat.DisableKeyword("_CURVATUREFILTER");
				filterSetMat.DisableKeyword("_FLOWFILTER");
				filterSetMat.DisableKeyword("_TEXTUREFILTER");
				filterSetMat.DisableKeyword("_USECURVE");
				if (filter != null && filter.filterType == FilterSet.Filter.FilterType.Curve)
				{
					filterSetMat.EnableKeyword("_USECURVE");
					filterSetMat.SetTexture("_Curve", filter.curveTexture);
				}
				RenderTexture renderTexture = null;
				RenderTexture renderTexture2 = null;
				switch (filterSetType)
				{
				case FilterSetType.Height:
					filterSetMat.EnableKeyword("_HEIGHTFILTER");
					break;
				case FilterSetType.Slope:
					filterSetMat.EnableKeyword("_SLOPEFILTER");
					break;
				case FilterSetType.Angle:
					filterSetMat.EnableKeyword("_ANGLEFILTER");
					break;
				case FilterSetType.Curvature:
				{
					filterSetMat.EnableKeyword("_CURVATUREFILTER");
					filterSetMat.SetFloat("_MipBias", filter.mipBias);
					Dictionary<Terrain, RenderTexture> dictionary2 = new Dictionary<Terrain, RenderTexture>();
					dictionary2.Add(terrain, terrain.normalmapTexture);
					if (terrain.leftNeighbor != null)
					{
						dictionary2.Add(terrain.leftNeighbor, terrain.leftNeighbor.normalmapTexture);
					}
					if (terrain.rightNeighbor != null)
					{
						dictionary2.Add(terrain.rightNeighbor, terrain.rightNeighbor.normalmapTexture);
					}
					if (terrain.topNeighbor != null)
					{
						dictionary2.Add(terrain.topNeighbor, terrain.topNeighbor.normalmapTexture);
					}
					if (terrain.bottomNeighbor != null)
					{
						dictionary2.Add(terrain.bottomNeighbor, terrain.bottomNeighbor.normalmapTexture);
					}
					RenderTexture active2 = RenderTexture.active;
					renderTexture = MapGen.GenerateCurvatureMap(terrain, dictionary2, terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight);
					renderTexture.name = "Temp::CurvaturePreview";
					RenderTexture.active = active2;
					filterSetMat.SetTexture("_Curvemap", renderTexture);
					break;
				}
				case FilterSetType.Flow:
				{
					filterSetMat.EnableKeyword("_FLOWFILTER");
					Dictionary<Terrain, RenderTexture> dictionary = new Dictionary<Terrain, RenderTexture>();
					dictionary.Add(terrain, terrain.terrainData.heightmapTexture);
					RenderTexture active = RenderTexture.active;
					renderTexture2 = MapGen.GenerateFlowMap(terrain, dictionary);
					renderTexture2.name = "Temp::FlowPreview";
					RenderTexture.active = active;
					filterSetMat.SetTexture("_Flowmap", renderTexture2);
					break;
				}
				case FilterSetType.Texture:
					if (filterSet != null)
					{
						filterSetMat.EnableKeyword("_TEXTUREFILTER");
						filterSetMat.SetVectorArray("_TextureLayerWeights", filterSet.GetTextureWeights(terrain.terrainData.terrainLayers));
						filterSetMat.SetTexture("_Control0", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control1", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control2", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control3", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control4", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control5", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control6", Texture2D.blackTexture);
						filterSetMat.SetTexture("_Control7", Texture2D.blackTexture);
						Texture2D[] alphamapTextures = terrain.terrainData.alphamapTextures;
						for (int j = 0; j < terrain.terrainData.alphamapTextureCount; j++)
						{
							filterSetMat.SetTexture("_Control" + j, alphamapTextures[j]);
						}
					}
					break;
				}
				int vertexCount = SetupDrawing(terrain, filterSetMat);
				Graphics.DrawProceduralNow(MeshTopology.Triangles, vertexCount);
				if (renderTexture != null)
				{
					RenderTexture.ReleaseTemporary(renderTexture);
				}
				if (renderTexture2 != null)
				{
					RenderTexture.ReleaseTemporary(renderTexture2);
				}
			}
		}

		public static void DrawStampPreview(IModifier mod, Terrain[] terrains, Transform transform, FalloffFilter filter, Color color, Texture2D colorTex = null)
		{
			if (!MicroVerse.instance.options.colors.drawStampPreviews)
			{
				DrawNoisePreview();
				DrawFilterSetPreview();
				return;
			}
			foreach (Terrain terrain in terrains)
			{
				if (terrain == null)
				{
					continue;
				}
				Bounds bounds = terrain.terrainData.bounds;
				bounds.center = terrain.transform.position;
				bounds.center += new Vector3(bounds.size.x * 0.5f, 0f, bounds.size.z * 0.5f);
				if (bounds.Intersects(mod.GetBounds()))
				{
					if (filter.filterType == FalloffFilter.FilterType.Range)
					{
						Draw(terrain, transform, filter.falloffRange, color, colorTex);
					}
					else if (filter.filterType == FalloffFilter.FilterType.Texture)
					{
						Draw(terrain, transform, filter.texture, color, colorTex, (int)filter.textureChannel);
					}
				}
			}
			DrawNoisePreview();
			DrawFilterSetPreview();
		}

		public static void Draw(Terrain terrain, Texture2D tex)
		{
			if ((bool)terrain)
			{
				if (!brushPreviewMat)
				{
					brushPreviewMat = new Material(Shader.Find("Hidden/MicroVerse/PreviewStamp"));
				}
				int vertexCount = SetupDrawing(terrain, brushPreviewMat);
				brushPreviewMat.DisableKeyword("_USEFALLOFFTEXTURE");
				brushPreviewMat.EnableKeyword("_NOFALLOFF");
				brushPreviewMat.SetTexture("_ColorTex", tex);
				brushPreviewMat.SetColor("_Color", Color.white);
				brushPreviewMat.SetTexture("_MainTex", Texture2D.whiteTexture);
				Graphics.DrawProceduralNow(MeshTopology.Triangles, vertexCount);
			}
		}

		public static void Draw(Terrain terrain, Transform transform, Texture2D tex, Color color, Texture2D colorTex = null, int channel = 0)
		{
			if ((bool)terrain)
			{
				if (!brushPreviewMat)
				{
					brushPreviewMat = new Material(Shader.Find("Hidden/MicroVerse/PreviewStamp"));
				}
				if (!((double)color.a < 0.05))
				{
					int vertexCount = SetupDrawing(terrain, transform, brushPreviewMat);
					brushPreviewMat.DisableKeyword("_USEFALLOFFTEXTURE");
					brushPreviewMat.SetTexture("_ColorTex", colorTex);
					brushPreviewMat.SetColor("_Color", color);
					brushPreviewMat.EnableKeyword("_USEFALLOFFTEXTURE");
					brushPreviewMat.SetTexture("_MainTex", tex);
					brushPreviewMat.SetFloat("_FalloffChannel", channel);
					Graphics.DrawProceduralNow(MeshTopology.Triangles, vertexCount);
				}
			}
		}

		public static void Draw(Terrain terrain, Transform transform, Vector2 falloffRange, Color color, Texture2D colorTex = null, int falloffChannel = 0)
		{
			if ((bool)terrain)
			{
				if (!brushPreviewMat)
				{
					brushPreviewMat = new Material(Shader.Find("Hidden/MicroVerse/PreviewStamp"));
				}
				if (!(color.a < 0.01f))
				{
					int vertexCount = SetupDrawing(terrain, transform, brushPreviewMat);
					brushPreviewMat.DisableKeyword("_USEFALLOFFTEXTURE");
					brushPreviewMat.SetTexture("_ColorTex", colorTex);
					brushPreviewMat.SetColor("_Color", color);
					brushPreviewMat.SetVector("_Falloff", falloffRange);
					brushPreviewMat.SetFloat("_FalloffChannel", falloffChannel);
					Graphics.DrawProceduralNow(MeshTopology.Triangles, vertexCount);
				}
			}
		}

		private static int SetupDrawing(Terrain terrain, Material mat)
		{
			Texture heightmapTexture = terrain.terrainData.heightmapTexture;
			RectInt rectInt = new RectInt(0, 0, heightmapTexture.width, heightmapTexture.height);
			Vector2 vector = new Vector2(terrain.terrainData.size.x / (float)heightmapTexture.width, terrain.terrainData.size.z / (float)heightmapTexture.height);
			int num = rectInt.width + 1;
			int num2 = rectInt.height + 1;
			int num3 = num * num2 * 6;
			int num4 = 1;
			while (num3 >= 32768)
			{
				num = (num + 1) / 2;
				num2 = (num2 + 1) / 2;
				num3 = num * num2 * 6;
				num4 *= 2;
			}
			mat.SetVector("_QuadRez", new Vector4(num, num2, num3, num4));
			float num5 = 1f / (float)heightmapTexture.width;
			float num6 = 1f / (float)heightmapTexture.height;
			mat.SetVector("_HeightmapUV_PCPixelsX", new Vector4(num5, 0f, 0f, 0f));
			mat.SetVector("_HeightmapUV_PCPixelsY", new Vector4(0f, num6, 0f, 0f));
			mat.SetVector("_HeightmapUV_Offset", new Vector4(0.5f * num5, 0.5f * num6, 0f, 0f));
			mat.SetTexture("_Heightmap", heightmapTexture);
			float x = vector.x;
			float y = terrain.terrainData.heightmapScale.y / kNormalizedHeightScale;
			float y2 = vector.y;
			mat.SetVector("_ObjectPos_PCPixelsX", new Vector4(x, 0f, 0f, 0f));
			mat.SetVector("_ObjectPos_HeightMapSample", new Vector4(0f, y, 0f, 0f));
			mat.SetVector("_ObjectPos_PCPixelsY", new Vector4(0f, 0f, y2, 0f));
			mat.SetVector("_ObjectPos_Offset", new Vector4((float)rectInt.xMin * x, 1f, (float)rectInt.yMin * y2 + vector.y * 0f, 1f));
			BrushTransform brushTransform = TerrainPaintUtility.CalculateBrushTransform(terrain, new Vector2(0.5f, 0.5f), terrain.terrainData.size.x, 0f);
			float num7 = (float)rectInt.xMin * vector.x;
			float num8 = (float)rectInt.yMin * vector.y;
			float x2 = vector.x;
			float y3 = vector.y;
			Vector2 vector2 = x2 * brushTransform.targetX;
			Vector2 vector3 = y3 * brushTransform.targetY;
			Vector2 vector4 = brushTransform.targetOrigin + num7 * brushTransform.targetX + num8 * brushTransform.targetY;
			mat.SetVector("_BrushUV_PCPixelsX", new Vector4(vector2.x, vector2.y, 0f, 0f));
			mat.SetVector("_BrushUV_PCPixelsY", new Vector4(vector3.x, vector3.y, 0f, 0f));
			mat.SetVector("_BrushUV_Offset", new Vector4(vector4.x, vector4.y, 0f, 1f));
			mat.SetVector("_TerrainObjectToWorldOffset", terrain.GetPosition());
			mat.SetPass(0);
			return num3;
		}

		private static int SetupDrawing(Terrain terrain, Transform stampTransform, Material mat)
		{
			mat.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(terrain, stampTransform));
			return SetupDrawing(terrain, mat);
		}
	}
}
