using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.Sprite
{
	[BurstCompile]
	public static class SpriteInstancingManager
	{
		public struct AtlasStats
		{
			public bool isValid;

			public int width;

			public int height;

			public int spriteCount;

			public int totalSpriteSize;

			public float buildTime;

			public int size => width * height;

			public float emptySpacePercent
			{
				get
				{
					if (size != 0)
					{
						return 100f * (float)(size - totalSpriteSize) / (float)size;
					}
					return 0f;
				}
			}
		}

		public struct InstanceData
		{
			public Matrix4x4 localToWorld;

			public Vector4 rect;

			public Vector2 pivot;

			public Color color;

			public Color emissiveColor;

			public Color flashColor;

			public Color outlineColor;

			public Vector3 gradientIndices;

			public Vector3 transformAnimParams;

			public float maskParam;

			public static int stride => 180;
		}

		public class DrawData : IDisposable
		{
			public ComputeBuffer buffer;

			public ComputeBuffer args;

			public uint[] argsData;

			public MaterialPropertyBlock properties;

			private static int _InstanceData = Shader.PropertyToID("_InstanceData");

			private static int _MainTex = Shader.PropertyToID("_MainTex");

			private static int _EmissiveTex = Shader.PropertyToID("_EmissiveTex");

			private static int _NormalTex = Shader.PropertyToID("_NormalTex");

			public DrawData()
			{
				properties = new MaterialPropertyBlock();
				args = new ComputeBuffer(5, 4, ComputeBufferType.DrawIndirect, ComputeBufferMode.Immutable);
				argsData = new uint[5]
				{
					quad.GetIndexCount(0),
					0u,
					quad.GetIndexStart(0),
					quad.GetBaseVertex(0),
					0u
				};
				args.SetData(argsData);
			}

			public void CheckSize(int count)
			{
				int num = Mathf.CeilToInt((float)count / 1000f);
				count = 1000 * num;
				if (buffer == null || buffer.count != count)
				{
					if (buffer != null)
					{
						buffer.Dispose();
						buffer.Release();
					}
					buffer = new ComputeBuffer(count, InstanceData.stride, ComputeBufferType.Default, ComputeBufferMode.Immutable);
					properties.SetBuffer(_InstanceData, buffer);
				}
			}

			public void ScheduleDraw(Material material, Texture texture, Texture emissiveTexture, Texture normalTexture, int count, int layer, bool castShadows)
			{
				properties.SetTexture(_MainTex, texture);
				properties.SetTexture(_EmissiveTex, emissiveTexture);
				properties.SetTexture(_NormalTex, normalTexture);
				argsData[1] = (uint)count;
				args.SetData(argsData, 1, 1, 1);
				ShadowCastingMode castShadows2 = (castShadows ? ShadowCastingMode.On : ShadowCastingMode.Off);
				Graphics.DrawMeshInstancedIndirect(quad, 0, material, new Bounds(Vector3.zero, Vector3.one * 9999f), args, 0, properties, castShadows2, receiveShadows: false, layer, null, LightProbeUsage.Off);
			}

			public void Dispose()
			{
				if (buffer != null)
				{
					buffer.Dispose();
					buffer.Release();
				}
				if (args != null)
				{
					args.Dispose();
					args.Release();
				}
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CompressAtlasInternal_000000D2_0024PostfixBurstDelegate(in NativeArray<Color32> atlasPixels, bool sRGB, ref NativeArray<ushort> colorIndices, ref NativeList<Color> colors);

		internal static class CompressAtlasInternal_000000D2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<CompressAtlasInternal_000000D2_0024PostfixBurstDelegate>(CompressAtlasInternal).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in NativeArray<Color32> atlasPixels, bool sRGB, ref NativeArray<ushort> colorIndices, ref NativeList<Color> colors)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref NativeArray<Color32>, bool, ref NativeArray<ushort>, ref NativeList<Color>, void>)functionPointer)(ref atlasPixels, sRGB, ref colorIndices, ref colors);
						return;
					}
				}
				CompressAtlasInternal_0024BurstManaged(in atlasPixels, sRGB, ref colorIndices, ref colors);
			}
		}

		private const int BUFFER_CHUNK_SIZE = 1000;

		public static readonly Dictionary<(Texture, Material, int), DrawData> data;

		private static readonly Dictionary<Material, Material> s_runtimeMaterials;

		public static bool renderAtlas;

		public static AtlasStats atlasStats;

		public static RenderTexture atlas;

		public static RenderTexture emissiveAtlas;

		public static RenderTexture normalAtlas;

		private static GlobalKeyword s_compressAtlasKeyword;

		private static GlobalKeyword s_disableNormalAtlasKeyword;

		private static Mesh s_quad;

		private static bool s_displayedLoadingMsg;

		private static bool s_displayedCreationMsg;

		private static int s_holdFrame;

		private static int s_prevFrameCount;

		private static readonly List<SpriteData> s_spriteDataList;

		private static readonly Dictionary<SpriteData, RectInt> s_spriteRects;

		public static Mesh quad
		{
			get
			{
				if (s_quad == null)
				{
					s_quad = CreateQuad();
				}
				return s_quad;
			}
		}

		public static bool isIteratingInstanceLists { get; private set; }

		public static int spriteRectCount { get; private set; }

		public static Texture GetAtlas()
		{
			return atlas;
		}

		public static Texture GetEmissiveAtlas()
		{
			return emissiveAtlas;
		}

		public static Texture GetNormalAtlas()
		{
			return normalAtlas;
		}

		static SpriteInstancingManager()
		{
			data = new Dictionary<(Texture, Material, int), DrawData>();
			s_runtimeMaterials = new Dictionary<Material, Material>();
			s_compressAtlasKeyword = GlobalKeyword.Create("SPRITE_INSTANCING_USE_COMPRESSED_ATLASES");
			s_disableNormalAtlasKeyword = GlobalKeyword.Create("SPRITE_INSTANCING_DISABLE_NORMAL_ATLAS");
			s_displayedLoadingMsg = false;
			s_displayedCreationMsg = false;
			isIteratingInstanceLists = false;
			s_spriteDataList = new List<SpriteData>();
			s_spriteRects = new Dictionary<SpriteData, RectInt>();
			AppDomain.CurrentDomain.DomainUnload += Dispose;
		}

		private static void Dispose(object sender, EventArgs e)
		{
			foreach (DrawData value in data.Values)
			{
				value.Dispose();
			}
			data.Clear();
		}

		public static void UpdateAndDraw()
		{
			if (!SpriteAssetManager.isLoaded)
			{
				if (!s_displayedLoadingMsg)
				{
					UnityEngine.Debug.Log("SpriteInstancing.UpdateAndDraw awaiting SpriteAsset loading...");
					s_displayedLoadingMsg = true;
				}
				s_holdFrame = 1;
				return;
			}
			SpriteAssetManager.UpdateShaderParameters();
			if (atlas == null)
			{
				if (!s_displayedCreationMsg)
				{
					UnityEngine.Debug.Log("SpriteInstancing.UpdateAndDraw awaiting atlas creation...");
					s_displayedCreationMsg = true;
				}
				s_holdFrame = 1;
			}
			else if (s_holdFrame > 0)
			{
				s_holdFrame--;
			}
			else
			{
				if (Time.frameCount == s_prevFrameCount)
				{
					return;
				}
				isIteratingInstanceLists = true;
				s_prevFrameCount = Time.frameCount;
				Shader.SetGlobalFloat(ShaderIDs.TransformAnimationTime, Time.time);
				Shader.DisableKeyword(in s_compressAtlasKeyword);
				Shader.DisableKeyword(in s_disableNormalAtlasKeyword);
				foreach (KeyValuePair<SpriteObject.GroupIdentifier, Dictionary<int, SpriteObject>> instanceList in SpriteObject.instanceLists)
				{
					SpriteObject.GroupIdentifier key = instanceList.Key;
					Material material = key.material;
					bool castShadows = key.castShadows;
					int layer = key.layer;
					Dictionary<int, SpriteObject> value = instanceList.Value;
					Texture texture = GetAtlas();
					Texture emissiveTexture = GetEmissiveAtlas();
					Texture normalTexture = GetNormalAtlas();
					if (value == null || value.Count < 1)
					{
						continue;
					}
					if (material == null)
					{
						UnityEngine.Debug.LogError("Material was null");
						continue;
					}
					if (texture == null)
					{
						UnityEngine.Debug.LogError("Atlas was null");
						continue;
					}
					DrawData drawData = GetDrawData(texture, material, layer, value.Count);
					if (drawData != null)
					{
						SpriteObject.UpdateSpritesAndWriteInstanceData(value, drawData.buffer);
						if (!s_runtimeMaterials.TryGetValue(material, out var value2) || value2 == null || value2.Equals(null))
						{
							value2 = UnityEngine.Object.Instantiate(material);
							value2.EnableKeyword("INSTANCING_ENABLED");
							s_runtimeMaterials[material] = value2;
						}
						if (value2 == null || value2.Equals(null))
						{
							UnityEngine.Debug.LogError("Runtime material was null");
						}
						else
						{
							drawData.ScheduleDraw(value2, texture, emissiveTexture, normalTexture, value.Count, layer, castShadows);
						}
					}
				}
				isIteratingInstanceLists = false;
			}
		}

		private static DrawData GetDrawData(Texture texture, Material material, int layer, int renderersCount)
		{
			if (!data.TryGetValue((texture, material, layer), out var value))
			{
				value = new DrawData();
				data.Add((texture, material, layer), value);
			}
			value.CheckSize(renderersCount);
			return value;
		}

		private static Mesh CreateQuad()
		{
			return new Mesh
			{
				vertices = new Vector3[4]
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(1f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(1f, 1f, 0f)
				},
				triangles = new int[6] { 0, 2, 1, 2, 3, 1 },
				normals = new Vector3[4]
				{
					-Vector3.forward,
					-Vector3.forward,
					-Vector3.forward,
					-Vector3.forward
				},
				uv = new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(1f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f)
				}
			};
		}

		public static void ReleaseAtlas()
		{
			if (atlas != null)
			{
				atlas.Release();
				atlas = null;
			}
			if (emissiveAtlas != null)
			{
				emissiveAtlas.Release();
				emissiveAtlas = null;
			}
			if (normalAtlas != null)
			{
				normalAtlas.Release();
				normalAtlas = null;
			}
		}

		public static void CreateAtlas(IList<SpriteAssetBase> assets)
		{
			atlasStats = default(AtlasStats);
			if (assets.Count < 1)
			{
				UnityEngine.Debug.LogError("Unable to create sprite atlas: Asset list was empty");
				return;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			s_spriteDataList.Clear();
			foreach (SpriteAssetBase asset in assets)
			{
				if (asset is SpriteAsset)
				{
					ProcessSpriteAsset(asset as SpriteAsset);
				}
				else if (asset is SpriteAssetSkin)
				{
					ProcessSpriteAssetSkin(asset as SpriteAssetSkin);
				}
			}
			if (!BuildAtlas(s_spriteDataList, out atlas, out emissiveAtlas, out normalAtlas))
			{
				UnityEngine.Debug.LogError("BuildAtlas failed");
			}
			else
			{
				atlasStats.isValid = true;
				atlasStats.height = atlas.height;
				atlasStats.width = atlas.width;
				atlasStats.buildTime = (float)stopwatch.Elapsed.TotalSeconds;
				atlasStats.spriteCount = s_spriteDataList.Count;
				atlasStats.totalSpriteSize = 0;
				foreach (SpriteData s_spriteData in s_spriteDataList)
				{
					Texture2D texture = s_spriteData.texture;
					if (!(texture == null))
					{
						atlasStats.totalSpriteSize += texture.height * texture.width;
					}
				}
				UnityEngine.Debug.Log($"SpriteInstancingAtlas: Packed {s_spriteDataList.Count} sprites (total size: {atlasStats.totalSpriteSize}) into atlas of size {atlasStats.width}x{atlasStats.height} = {atlasStats.size} (wasted space: {atlasStats.emptySpacePercent:F2}%) in {atlasStats.buildTime * 1000f:F2} ms");
			}
			foreach (SpriteAssetBase asset2 in assets)
			{
				if (asset2 is SpriteAsset)
				{
					ExtractSpriteAssetData(asset2 as SpriteAsset);
				}
				else if (asset2 is SpriteAssetSkin)
				{
					ExtractSpriteAssetSkinData(asset2 as SpriteAssetSkin);
				}
			}
		}

		private static void AddSpriteListData(SpriteData spriteData)
		{
			s_spriteDataList.Add(spriteData);
		}

		private static void ProcessSpriteAsset(SpriteAsset spriteAsset)
		{
			if (spriteAsset == null)
			{
				return;
			}
			if (spriteAsset.staticSpriteData.hasAnyTexture)
			{
				AddSpriteListData(spriteAsset.staticSpriteData);
			}
			for (int i = 0; i < spriteAsset.staticVariantCount; i++)
			{
				SpriteData staticVariant = spriteAsset.GetStaticVariant(i);
				if (staticVariant.hasAnyTexture)
				{
					AddSpriteListData(staticVariant);
				}
			}
			for (int j = 0; j < spriteAsset.animationCount; j++)
			{
				FrameAnimation animationAt = spriteAsset.GetAnimationAt(j);
				if (animationAt == null)
				{
					continue;
				}
				if (animationAt.spriteData.hasAnyTexture)
				{
					AddSpriteListData(animationAt.spriteData);
				}
				for (int k = 0; k < animationAt.variantCount; k++)
				{
					SpriteData variant = animationAt.GetVariant(k);
					if (variant.hasAnyTexture)
					{
						AddSpriteListData(variant);
					}
				}
			}
		}

		private static void ProcessSpriteAssetSkin(SpriteAssetSkin spriteAssetSkin)
		{
			if (spriteAssetSkin == null)
			{
				return;
			}
			if (spriteAssetSkin.staticReplacementData != null)
			{
				if (spriteAssetSkin.staticReplacementData.spriteData.hasAnyTexture)
				{
					AddSpriteListData(spriteAssetSkin.staticReplacementData.spriteData);
				}
				for (int i = 0; i < spriteAssetSkin.staticReplacementData.variantCount; i++)
				{
					SpriteData variant = spriteAssetSkin.staticReplacementData.GetVariant(i);
					if (variant.hasAnyTexture)
					{
						AddSpriteListData(variant);
					}
				}
			}
			for (int j = 0; j < spriteAssetSkin.replacementDataCount; j++)
			{
				SpriteAssetSkin.ReplacementData replacementAt = spriteAssetSkin.GetReplacementAt(j);
				if (replacementAt == null)
				{
					continue;
				}
				if (replacementAt.spriteData.hasAnyTexture)
				{
					AddSpriteListData(replacementAt.spriteData);
				}
				for (int k = 0; k < replacementAt.variantCount; k++)
				{
					SpriteData variant2 = replacementAt.GetVariant(k);
					if (variant2.hasAnyTexture)
					{
						AddSpriteListData(variant2);
					}
				}
			}
		}

		private static void ExtractSpriteAssetData(SpriteAsset spriteAsset)
		{
			if (spriteAsset == null)
			{
				return;
			}
			int num = 0;
			SpriteData staticSpriteData = spriteAsset.staticSpriteData;
			if (staticSpriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(staticSpriteData, out var value))
			{
				spriteAsset.staticAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
			}
			for (int i = 0; i < spriteAsset.staticVariantCount; i++)
			{
				staticSpriteData = spriteAsset.GetStaticVariant(i);
				if (staticSpriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(staticSpriteData, out value))
				{
					spriteAsset.staticAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
				}
			}
			num = 0;
			for (int j = 0; j < spriteAsset.animationCount; j++)
			{
				FrameAnimation animationAt = spriteAsset.GetAnimationAt(j);
				if (animationAt == null)
				{
					continue;
				}
				staticSpriteData = animationAt.spriteData;
				if (staticSpriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(staticSpriteData, out value))
				{
					spriteAsset.animationAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
				}
				for (int k = 0; k < animationAt.variantCount; k++)
				{
					staticSpriteData = animationAt.GetVariant(k);
					if (staticSpriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(staticSpriteData, out value))
					{
						spriteAsset.animationAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
					}
				}
			}
		}

		private static void ExtractSpriteAssetSkinData(SpriteAssetSkin spriteAssetSkin)
		{
			if (spriteAssetSkin == null)
			{
				return;
			}
			int num = 0;
			if (spriteAssetSkin.staticReplacementData != null && spriteAssetSkin.staticReplacementData.spriteData.hasAnyTexture)
			{
				SpriteData spriteData = spriteAssetSkin.staticReplacementData.spriteData;
				if (spriteAssetSkin.staticReplacementData.spriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(spriteData, out var value))
				{
					spriteAssetSkin.staticAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
				}
				for (int i = 0; i < spriteAssetSkin.staticReplacementData.variantCount; i++)
				{
					spriteData = spriteAssetSkin.staticReplacementData.GetVariant(i);
					if (spriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(spriteData, out value))
					{
						spriteAssetSkin.staticAtlasRects[num++] = new Vector4(value.x, value.y, value.width, value.height);
					}
				}
			}
			num = 0;
			for (int j = 0; j < spriteAssetSkin.replacementDataCount; j++)
			{
				SpriteAssetSkin.ReplacementData replacementAt = spriteAssetSkin.GetReplacementAt(j);
				if (replacementAt == null || !replacementAt.spriteData.hasAnyTexture)
				{
					continue;
				}
				SpriteData spriteData = replacementAt.spriteData;
				if (spriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(spriteData, out var value2))
				{
					spriteAssetSkin.animationAtlasRects[num++] = new Vector4(value2.x, value2.y, value2.width, value2.height);
				}
				for (int k = 0; k < replacementAt.variantCount; k++)
				{
					spriteData = replacementAt.GetVariant(k);
					if (spriteData.GetSrcTexture() != null && s_spriteRects.TryGetValue(spriteData, out value2))
					{
						spriteAssetSkin.animationAtlasRects[num++] = new Vector4(value2.x, value2.y, value2.width, value2.height);
					}
				}
			}
		}

		public static bool BuildAtlas(List<SpriteData> spriteDatas, out RenderTexture atlas, out RenderTexture emissiveAtlas, out RenderTexture normalAtlas)
		{
			s_spriteRects.Clear();
			atlas = null;
			emissiveAtlas = null;
			normalAtlas = null;
			Material material = new Material(Shader.Find("Hidden/SpriteAtlas"));
			HashSet<Texture2D> referencedTextures = new HashSet<Texture2D>();
			int num = 0;
			for (int i = 0; i < spriteDatas.Count; i++)
			{
				SpriteData spriteData = spriteDatas[i];
				Texture2D srcTexture = spriteData.GetSrcTexture();
				if (srcTexture != null)
				{
					num += srcTexture.width * srcTexture.height;
				}
				TryEmitMultiReferenceTextureWarning(referencedTextures, spriteData.texture);
				TryEmitMultiReferenceTextureWarning(referencedTextures, spriteData.emissiveTexture);
				TryEmitMultiReferenceTextureWarning(referencedTextures, spriteData.normalTexture);
			}
			if (!AtlasPacker.TryPack(spriteDatas, out var size, out var packedPositions))
			{
				UnityEngine.Debug.LogError("Packing failed");
				return false;
			}
			for (int j = 0; j < spriteDatas.Count; j++)
			{
				SpriteData spriteData2 = spriteDatas[j];
				Texture2D srcTexture2 = spriteData2.GetSrcTexture();
				int2 int5 = packedPositions[j];
				if (!s_spriteRects.TryAdd(spriteData2, new RectInt(int5.x, int5.y, srcTexture2.width, srcTexture2.height)))
				{
					UnityEngine.Debug.LogError("Duplicate SpriteData found in rect list!");
				}
			}
			packedPositions.Dispose();
			spriteRectCount = s_spriteRects.Count;
			if (renderAtlas)
			{
				atlas = new RenderTexture(size, size, 0, RenderTextureFormat.ARGB32)
				{
					name = "SpriteInstancingAtlas"
				};
				atlas.filterMode = FilterMode.Point;
				atlas.wrapMode = TextureWrapMode.Clamp;
				atlas.Create();
				CommandBuffer commandBuffer = new CommandBuffer();
				commandBuffer.SetRenderTarget(atlas);
				commandBuffer.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
				commandBuffer.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.Ortho(0f, 1f, 0f, 1f, -1f, 100f));
				emissiveAtlas = new RenderTexture(size, size, 0, RenderTextureFormat.ARGB32)
				{
					name = "SpriteInstancingAtlas (Emissive)"
				};
				emissiveAtlas.filterMode = FilterMode.Point;
				emissiveAtlas.wrapMode = TextureWrapMode.Clamp;
				emissiveAtlas.Create();
				CommandBuffer commandBuffer2 = new CommandBuffer();
				commandBuffer2.SetRenderTarget(emissiveAtlas);
				commandBuffer2.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
				commandBuffer2.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.Ortho(0f, 1f, 0f, 1f, -1f, 100f));
				normalAtlas = new RenderTexture(size, size, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear)
				{
					name = "SpriteInstancingAtlas (Normals)"
				};
				normalAtlas.filterMode = FilterMode.Point;
				normalAtlas.wrapMode = TextureWrapMode.Clamp;
				normalAtlas.Create();
				CommandBuffer commandBuffer3 = new CommandBuffer();
				commandBuffer3.SetRenderTarget(normalAtlas);
				commandBuffer3.ClearRenderTarget(clearDepth: false, clearColor: true, new Color(0.5f, 0.5f, 1f, 1f));
				commandBuffer3.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.Ortho(0f, 1f, 0f, 1f, -1f, 100f));
				for (int k = 0; k < spriteDatas.Count; k++)
				{
					SpriteData spriteData3 = spriteDatas[k];
					RectInt rectInt = s_spriteRects[spriteData3];
					if (spriteData3.texture != null)
					{
						commandBuffer.SetViewport(new Rect(rectInt.x, rectInt.y, rectInt.width, rectInt.height));
						commandBuffer.SetGlobalTexture(ShaderIDs.SpriteTexture, spriteData3.texture);
						commandBuffer.DrawMesh(quad, Matrix4x4.identity, material, 0, 0);
					}
					if (spriteData3.emissiveTexture != null)
					{
						commandBuffer2.SetViewport(new Rect(rectInt.x, rectInt.y, rectInt.width, rectInt.height));
						commandBuffer2.SetGlobalTexture(ShaderIDs.SpriteTexture, spriteData3.emissiveTexture);
						commandBuffer2.DrawMesh(quad, Matrix4x4.identity, material, 0, 0);
					}
					if (spriteData3.normalTexture != null)
					{
						commandBuffer3.SetViewport(new Rect(rectInt.x, rectInt.y, rectInt.width, rectInt.height));
						commandBuffer3.SetGlobalTexture(ShaderIDs.SpriteTexture, spriteData3.normalTexture);
						commandBuffer3.DrawMesh(quad, Matrix4x4.identity, material, 0, 1);
					}
				}
				Graphics.ExecuteCommandBuffer(commandBuffer);
				Graphics.ExecuteCommandBuffer(commandBuffer2);
				Graphics.ExecuteCommandBuffer(commandBuffer3);
			}
			return true;
		}

		private static Texture2D CompressAtlas(RenderTexture atlasTexture, string name, bool sRGB, out List<Color> colors)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Texture2D texture2D = new Texture2D(atlasTexture.width, atlasTexture.height, TextureFormat.RGBA32, mipChain: false, linear: false, createUninitialized: true);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = atlasTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, atlasTexture.width, atlasTexture.height), 0, 0);
			RenderTexture.active = active;
			NativeArray<Color32> atlasPixels = texture2D.GetPixelData<Color32>(0);
			NativeArray<ushort> colorIndices = new NativeArray<ushort>(atlasPixels.Length, Allocator.Temp);
			NativeList<Color> colors2 = new NativeList<Color>(4096, Allocator.Temp);
			CompressAtlasInternal(in atlasPixels, sRGB, ref colorIndices, ref colors2);
			colors = new List<Color>(colors2.Length);
			foreach (Color item in colors2)
			{
				colors.Add(item);
			}
			UnityEngine.Object.Destroy(texture2D);
			Texture2D texture2D2 = new Texture2D(atlasTexture.width, atlasTexture.height, TextureFormat.R16, mipChain: false, linear: true, createUninitialized: true);
			texture2D2.name = name;
			texture2D2.SetPixelData(colorIndices, 0);
			texture2D2.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			texture2D2.filterMode = FilterMode.Point;
			texture2D2.wrapMode = TextureWrapMode.Clamp;
			UnityEngine.Debug.Log($"Compressed {atlasTexture.name} in {stopwatch.Elapsed.TotalSeconds} s ({colors.Count} colors total)");
			return texture2D2;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pug_002ESprite_002ECompressAtlasInternal_000000D2_0024PostfixBurstDelegate))]
		private static void CompressAtlasInternal(in NativeArray<Color32> atlasPixels, bool sRGB, ref NativeArray<ushort> colorIndices, ref NativeList<Color> colors)
		{
			CompressAtlasInternal_000000D2_0024BurstDirectCall.Invoke(in atlasPixels, sRGB, ref colorIndices, ref colors);
		}

		private static void TryEmitMultiReferenceTextureWarning(HashSet<Texture2D> referencedTextures, Texture2D texture)
		{
			if (!(texture == null) && !referencedTextures.Contains(texture))
			{
				referencedTextures.Add(texture);
			}
		}

		private static int GetArea(Texture2D texture)
		{
			if (!(texture != null))
			{
				return 0;
			}
			return texture.width * texture.height;
		}

		private static int GetArea(Vector2Int v)
		{
			return v.x * v.y;
		}

		private static void FitAndSplit(Texture2D sprite, RectInt space, List<RectInt> emptySpace, out RectInt rect)
		{
			rect = space;
			rect.width = sprite.width;
			rect.height = sprite.height;
			RectInt rectInt = space;
			rectInt.width = sprite.width;
			rectInt.height -= sprite.height;
			rectInt.y += sprite.height;
			RectInt rectInt2 = space;
			rectInt2.width -= sprite.width;
			rectInt2.x += sprite.width;
			float a = rectInt.width * rectInt.height;
			float b = rectInt2.width * rectInt2.height;
			float num = Mathf.Min(a, b);
			RectInt rectInt3 = space;
			rectInt3.height -= sprite.height;
			rectInt3.y += sprite.height;
			RectInt rectInt4 = space;
			rectInt4.width -= sprite.width;
			rectInt4.x += sprite.width;
			rectInt4.height = sprite.height;
			float a2 = rectInt3.width * rectInt3.height;
			float b2 = rectInt4.width * rectInt4.height;
			float num2 = Mathf.Min(a2, b2);
			RectInt item;
			RectInt item2;
			if (num < num2)
			{
				item = rectInt;
				item2 = rectInt2;
			}
			else
			{
				item = rectInt3;
				item2 = rectInt4;
			}
			int area = GetArea(item.size);
			int area2 = GetArea(item2.size);
			if (area > 0)
			{
				emptySpace.Add(item);
			}
			if (area2 > 0)
			{
				emptySpace.Add(item2);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void CompressAtlasInternal_0024BurstManaged(in NativeArray<Color32> atlasPixels, bool sRGB, ref NativeArray<ushort> colorIndices, ref NativeList<Color> colors)
		{
			NativeHashMap<uint, ushort> nativeHashMap = new NativeHashMap<uint, ushort>(4096, Allocator.Temp);
			ushort num = 0;
			nativeHashMap.Add(0u, num++);
			colors.Add(Color.clear);
			uint num2 = 0u;
			ushort num3 = 0;
			for (int i = 0; i < atlasPixels.Length; i++)
			{
				Color32 color = atlasPixels[i];
				if (color.a == 0)
				{
					color = new Color32(0, 0, 0, 0);
				}
				uint num4 = (uint)((color.r << 24) | (color.g << 16) | (color.b << 8) | color.a);
				ushort item = 0;
				if (num4 == 0)
				{
					item = 0;
				}
				else if (num4 == num2)
				{
					item = num3;
				}
				else if (!nativeHashMap.TryGetValue(num4, out item))
				{
					item = num++;
					nativeHashMap.Add(num4, item);
					if (sRGB)
					{
						colors.Add(((Color)color).linear);
					}
					else
					{
						colors.Add((Color)color);
					}
				}
				colorIndices[i] = item;
				num2 = num4;
				num3 = item;
			}
		}
	}
}
