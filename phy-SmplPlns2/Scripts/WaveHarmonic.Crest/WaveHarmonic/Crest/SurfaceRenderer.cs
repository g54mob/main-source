#define UNITY_2022_3_OR_NEWER
using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.Universal;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class SurfaceRenderer : Versioned
	{
		[Serializable]
		internal sealed class DebugFields
		{
			[HideInInspector]
			[Tooltip("Whether to generate water geometry tiles uniformly (with overlaps).")]
			[SerializeField]
			public bool _UniformTiles;

			[HideInInspector]
			[Tooltip("Disable generating a wide strip of triangles at the outer edge to extend water to edge of view frustum.")]
			[SerializeField]
			public bool _DisableSkirt;

			[HideInInspector]
			[Tooltip("Toggle the Draw Renderer Bounds on each chunk.")]
			[SerializeField]
			public bool _DrawRendererBounds;
		}

		internal enum SurfaceSelfIntersectionFixMode
		{
			[Tooltip("Uses VFACE/IsFrontFace.")]
			Off = 0,
			[Tooltip("Force entire water surface to render as below water.")]
			ForceBelowWater = 1,
			[Tooltip("Force entire water surface to render as above water.")]
			ForceAboveWater = 2,
			[Tooltip("Force entire water surface to render as above or below water if beyond a distance from surface, otherwise use mask/facing.")]
			On = 3,
			[Tooltip("Force entire water surface to render as above or below water if beyond a distance from surface (except in special circumstances like  Portals).")]
			Automatic = 4
		}

		private enum ForceFacing
		{
			None = 0,
			BelowWater = 1,
			AboveWater = 2,
			Facing = 3
		}

		internal static class ShaderIDs
		{
			public static class Unity
			{
				public static readonly int s_BuiltInSurface = Shader.PropertyToID("_BUILTIN_Surface");

				public static readonly int s_BuiltInTransparentReceiveShadows = Shader.PropertyToID("_BUILTIN_TransparentReceiveShadows");
			}

			public static readonly int s_ForceUnderwater = Shader.PropertyToID("g_Crest_ForceUnderwater");

			public static readonly int s_LodAlphaBlackPointFade = Shader.PropertyToID("g_Crest_LodAlphaBlackPointFade");

			public static readonly int s_LodAlphaBlackPointWhitePointFade = Shader.PropertyToID("g_Crest_LodAlphaBlackPointWhitePointFade");

			public static readonly int s_BuiltShadowCasterZTest = Shader.PropertyToID("_Crest_BUILTIN_ShadowCasterZTest");

			public static readonly int s_ChunkMeshScaleAlpha = Shader.PropertyToID("_Crest_ChunkMeshScaleAlpha");

			public static readonly int s_ChunkGeometryGridWidth = Shader.PropertyToID("_Crest_ChunkGeometryGridWidth");

			public static readonly int s_ChunkFarNormalsWeight = Shader.PropertyToID("_Crest_ChunkFarNormalsWeight");

			public static readonly int s_ChunkNormalScrollSpeed = Shader.PropertyToID("_Crest_ChunkNormalScrollSpeed");

			public static readonly int s_NormalMapParameters = Shader.PropertyToID("_Crest_NormalMapParameters");

			public static readonly int s_DataType = Shader.PropertyToID("_Crest_DataType");

			public static readonly int s_Exposure = Shader.PropertyToID("_Crest_Exposure");

			public static readonly int s_Range = Shader.PropertyToID("_Crest_Range");

			public static readonly int s_Saturate = Shader.PropertyToID("_Crest_Saturate");

			public static int s_WaterLine = Shader.PropertyToID("_Crest_WaterLine");

			public static int s_WaterLineSnappedPosition = Shader.PropertyToID("_Crest_WaterLineSnappedPosition");

			public static int s_WaterLineResolution = Shader.PropertyToID("_Crest_WaterLineResolution");

			public static int s_WaterLineTexel = Shader.PropertyToID("_Crest_WaterLineTexel");

			public static int s_WaterLineFlatWater = Shader.PropertyToID("_Crest_WaterLineFlatWater");

			public static readonly int s_DummyTarget = Shader.PropertyToID("_Crest_DummyTarget");

			public static readonly int s_WorldToShadow = Shader.PropertyToID("_Crest_WorldToShadow");
		}

		internal struct SurfaceDataParameters
		{
			public Vector2 _SnappedPosition;

			public Vector2 _Resolution;

			public float _Texel;
		}

		internal sealed class WaterSurfaceRenderPass : ScriptableRenderPass
		{
			private class PassData
			{
				public RendererListHandle _RendererList;
			}

			private readonly WaterRenderer _Water;

			private ShaderTagId _ShaderTagID = new ShaderTagId("DepthOnly");

			private readonly RenderGraphHelper.PassData _PassData = new RenderGraphHelper.PassData();

			public static WaterSurfaceRenderPass Instance { get; set; }

			public WaterSurfaceRenderPass(WaterRenderer water)
			{
				_Water = water;
				base.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
				ConfigureInput(ScriptableRenderPassInput.None);
			}

			public static void Enable(WaterRenderer water)
			{
				Instance = new WaterSurfaceRenderPass(water);
			}

			internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
			{
				if (IsTransparent(_Water.Surface.Material))
				{
					ScriptableRenderPassInput passInput = ScriptableRenderPassInput.Depth | ScriptableRenderPassInput.Color;
					ConfigureInput(passInput);
					camera.GetUniversalAdditionalCameraData().scriptableRenderer.EnqueuePass(Instance);
				}
			}

			public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
			{
				if (!_Water.RenderBeforeTransparency)
				{
					return;
				}
				PassData passData;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder = graph.AddRasterRenderPass<PassData>("Crest.DrawWater/Surface", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Surface\\SurfaceRenderer.Universal.cs", 85);
				UniversalResourceData universalResourceData = frame.Get<UniversalResourceData>();
				UniversalCameraData universalCameraData = frame.Get<UniversalCameraData>();
				UniversalRenderingData universalRenderingData = frame.Get<UniversalRenderingData>();
				rasterRenderGraphBuilder.UseTexture(universalResourceData.cameraDepthTexture);
				rasterRenderGraphBuilder.UseTexture(universalResourceData.cameraOpaqueTexture);
				rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
				RendererListDesc rendererListDesc = new RendererListDesc(_ShaderTagID, universalRenderingData.cullResults, universalCameraData.camera);
				rendererListDesc.layerMask = 1 << _Water.Surface.Layer;
				rendererListDesc.overrideShader = _Water.Surface.Material.shader;
				rendererListDesc.overrideShaderPassIndex = 0;
				rendererListDesc.renderQueueRange = RenderQueueRange.transparent;
				rendererListDesc.sortingCriteria = SortingCriteria.CommonOpaque;
				rendererListDesc.rendererConfiguration = universalRenderingData.perObjectData;
				RendererListDesc desc = rendererListDesc;
				passData._RendererList = graph.CreateRendererList(in desc);
				rasterRenderGraphBuilder.UseRendererList(in passData._RendererList);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					context.cmd.DrawRendererList(data._RendererList);
				});
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (_Water.RenderBeforeTransparency)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("Crest.DrawWater/Surface");
					RendererListDesc rendererListDesc = new RendererListDesc(_ShaderTagID, renderingData.cullResults, renderingData.cameraData.camera);
					rendererListDesc.layerMask = 1 << _Water.Surface.Layer;
					rendererListDesc.overrideShader = _Water.Surface.Material.shader;
					rendererListDesc.overrideShaderPassIndex = 0;
					rendererListDesc.renderQueueRange = RenderQueueRange.transparent;
					rendererListDesc.sortingCriteria = SortingCriteria.CommonOpaque;
					rendererListDesc.rendererConfiguration = renderingData.perObjectData;
					RendererListDesc desc = rendererListDesc;
					commandBuffer.DrawRendererList(context.CreateRendererList(desc));
					context.ExecuteCommandBuffer(commandBuffer);
					CommandBufferPool.Release(commandBuffer);
				}
			}
		}

		private static class Builder
		{
			internal enum PatchType
			{
				Interior = 0,
				Fat = 1,
				FatX = 2,
				FatXSlimZ = 3,
				FatXOuter = 4,
				FatXZ = 5,
				FatXZOuter = 6,
				SlimX = 7,
				SlimXZ = 8,
				SlimXFatZ = 9,
				Count = 10
			}

			private static readonly Vector2[] s_Offsets = new Vector2[12]
			{
				new Vector2(-1.5f, 1.5f),
				new Vector2(-0.5f, 1.5f),
				new Vector2(0.5f, 1.5f),
				new Vector2(1.5f, 1.5f),
				new Vector2(-1.5f, 0.5f),
				new Vector2(1.5f, 0.5f),
				new Vector2(-1.5f, -0.5f),
				new Vector2(1.5f, -0.5f),
				new Vector2(-1.5f, -1.5f),
				new Vector2(-0.5f, -1.5f),
				new Vector2(0.5f, -1.5f),
				new Vector2(1.5f, -1.5f)
			};

			internal static readonly Vector2[] s_OffsetsFirstLod = new Vector2[16]
			{
				new Vector2(-0.5f, 0.5f),
				new Vector2(0.5f, 0.5f),
				new Vector2(-0.5f, -0.5f),
				new Vector2(0.5f, -0.5f),
				new Vector2(-1.5f, 1.5f),
				new Vector2(-0.5f, 1.5f),
				new Vector2(0.5f, 1.5f),
				new Vector2(1.5f, 1.5f),
				new Vector2(-1.5f, 0.5f),
				new Vector2(1.5f, 0.5f),
				new Vector2(-1.5f, -0.5f),
				new Vector2(1.5f, -0.5f),
				new Vector2(-1.5f, -1.5f),
				new Vector2(-0.5f, -1.5f),
				new Vector2(0.5f, -1.5f),
				new Vector2(1.5f, -1.5f)
			};

			private static readonly PatchType[] s_PatchTypes = new PatchType[12]
			{
				PatchType.SlimXFatZ,
				PatchType.SlimX,
				PatchType.SlimX,
				PatchType.SlimXZ,
				PatchType.FatX,
				PatchType.SlimX,
				PatchType.FatX,
				PatchType.SlimX,
				PatchType.FatXZ,
				PatchType.FatX,
				PatchType.FatX,
				PatchType.FatXSlimZ
			};

			private static readonly PatchType[] s_PatchTypesFirstLod = new PatchType[16]
			{
				PatchType.Interior,
				PatchType.Interior,
				PatchType.Interior,
				PatchType.Interior,
				PatchType.SlimXFatZ,
				PatchType.SlimX,
				PatchType.SlimX,
				PatchType.SlimXZ,
				PatchType.FatX,
				PatchType.SlimX,
				PatchType.FatX,
				PatchType.SlimX,
				PatchType.FatXZ,
				PatchType.FatX,
				PatchType.FatX,
				PatchType.FatXSlimZ
			};

			private static readonly PatchType[] s_PatchTypesLastLod = new PatchType[12]
			{
				PatchType.FatXZOuter,
				PatchType.FatXOuter,
				PatchType.FatXOuter,
				PatchType.FatXZOuter,
				PatchType.FatXOuter,
				PatchType.FatXOuter,
				PatchType.FatXOuter,
				PatchType.FatXOuter,
				PatchType.FatXZOuter,
				PatchType.FatXOuter,
				PatchType.FatXOuter,
				PatchType.FatXZOuter
			};

			private static int s_SiblingIndex;

			public static Transform GenerateMesh(WaterRenderer water, SurfaceRenderer surface, List<WaterChunkRenderer> tiles, int lodDataResolution, int geoDownSampleFactor, int lodCount)
			{
				if (lodCount < 1)
				{
					Debug.LogError("Crest: Invalid LOD count: " + lodCount, water);
					return null;
				}
				s_SiblingIndex = 0;
				GameObject gameObject = new GameObject("Root");
				gameObject.hideFlags = (water._Debug._ShowHiddenObjects ? HideFlags.DontSave : HideFlags.HideAndDontSave);
				gameObject.transform.parent = water.Container.transform;
				gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				gameObject.transform.localScale = Vector3.one;
				float vertDensity = Mathf.Round(0.25f * (float)lodDataResolution / (float)geoDownSampleFactor);
				for (int i = 0; i < 10; i++)
				{
					surface._Meshes[i] = BuildPatch(water, (PatchType)i, vertDensity);
				}
				for (int j = 0; j < lodCount; j++)
				{
					CreateLOD(water, surface, tiles, gameObject.transform, j, lodCount, surface._Meshes, lodDataResolution, geoDownSampleFactor, surface.Layer);
				}
				return gameObject.transform;
			}

			private static Mesh BuildPatch(WaterRenderer water, PatchType pt, float vertDensity)
			{
				List<Vector3> list = new List<Vector3>();
				List<int> list2 = new List<int>();
				float num = 1f / vertDensity;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				switch (pt)
				{
				case PatchType.Fat:
					num2 = (num3 = (num4 = (num5 = 1f)));
					break;
				case PatchType.FatX:
				case PatchType.FatXOuter:
					num3 = 1f;
					break;
				case PatchType.FatXZ:
				case PatchType.FatXZOuter:
					num3 = (num5 = 1f);
					break;
				case PatchType.FatXSlimZ:
					num3 = 1f;
					num5 = -1f;
					break;
				case PatchType.SlimX:
					num3 = -1f;
					break;
				case PatchType.SlimXZ:
					num3 = (num5 = -1f);
					break;
				case PatchType.SlimXFatZ:
					num3 = -1f;
					num5 = 1f;
					break;
				}
				float num6 = 1f + vertDensity + num2 + num3;
				float num7 = 1f + vertDensity + num4 + num5;
				float a = -0.5f - num2 * num;
				float a2 = -0.5f - num4 * num;
				float b = 0.5f + num3 * num;
				float b2 = 0.5f + num5 * num;
				float num8 = water._ExtentsSizeMultiplier * (float)(16 - water.LodLevels);
				for (float num9 = 0f; num9 < num7; num9 += 1f)
				{
					float num10 = Mathf.Lerp(a2, b2, num9 / (num7 - 1f));
					if (pt == PatchType.FatXZOuter && num9 == num7 - 1f)
					{
						num10 *= num8;
					}
					for (float num11 = 0f; num11 < num6; num11 += 1f)
					{
						float num12 = Mathf.Lerp(a, b, num11 / (num6 - 1f));
						if (num11 == num6 - 1f && (pt == PatchType.FatXOuter || pt == PatchType.FatXZOuter))
						{
							num12 *= num8;
						}
						list.Add(new Vector3(num12, 0f, num10));
					}
				}
				int num13 = (int)num6 - 1;
				int num14 = (int)num7 - 1;
				for (int i = 0; i < num14; i++)
				{
					for (int j = 0; j < num13; j++)
					{
						bool flag = false;
						if (j % 2 == 1)
						{
							flag = !flag;
						}
						if (i % 2 == 1)
						{
							flag = !flag;
						}
						int num15 = j + i * (num13 + 1);
						int item = num15 + 1;
						int num16 = num15 + (num13 + 1);
						int item2 = num16 + 1;
						if (!flag)
						{
							list2.Add(item2);
							list2.Add(item);
							list2.Add(num15);
							list2.Add(num15);
							list2.Add(num16);
							list2.Add(item2);
						}
						else
						{
							list2.Add(item2);
							list2.Add(item);
							list2.Add(num16);
							list2.Add(num15);
							list2.Add(num16);
							list2.Add(item);
						}
					}
				}
				Mesh mesh = new Mesh();
				if (list != null && list.Count > 0)
				{
					Vector3[] array = new Vector3[list.Count];
					list.CopyTo(array);
					int[] array2 = new int[list2.Count];
					list2.CopyTo(array2);
					mesh.SetIndices((int[])null, MeshTopology.Triangles, 0);
					mesh.vertices = array;
					mesh.normals = null;
					mesh.SetIndices(array2, MeshTopology.Triangles, 0);
					mesh.RecalculateBounds();
					Bounds bounds = mesh.bounds;
					num *= 3f;
					bounds.extents = new Vector3(bounds.extents.x + num, bounds.extents.y, bounds.extents.z + num);
					mesh.bounds = bounds;
					mesh.name = pt.ToString();
				}
				return mesh;
			}

			private static void CreateLOD(WaterRenderer water, SurfaceRenderer surface, List<WaterChunkRenderer> tiles, Transform parent, int lodIndex, int lodCount, Mesh[] meshData, int lodDataResolution, int geoDownSampleFactor, int layer)
			{
				float num = Mathf.Pow(2f, lodIndex);
				bool flag = lodIndex == lodCount - 1;
				Vector2[] array;
				PatchType[] array2;
				if (lodIndex != 0)
				{
					array = s_Offsets;
					array2 = (flag ? s_PatchTypesLastLod : s_PatchTypes);
				}
				else
				{
					array = s_OffsetsFirstLod;
					array2 = s_PatchTypesFirstLod;
				}
				for (int i = 0; i < array.Length; i++)
				{
					GameObject gameObject = (surface._ChunkTemplate ? Helpers.InstantiatePrefab(surface._ChunkTemplate) : new GameObject());
					gameObject.hideFlags = (water._Debug._ShowHiddenObjects ? HideFlags.DontSave : HideFlags.HideAndDontSave);
					gameObject.name = $"Tile_L{lodIndex}_{array2[i]}";
					gameObject.layer = layer;
					gameObject.transform.parent = parent;
					Vector2 vector = array[i];
					gameObject.transform.localPosition = num * new Vector3(vector.x, 0f, vector.y);
					gameObject.transform.localScale = new Vector3(num, 1f, num);
					if (!gameObject.TryGetComponent<MeshRenderer>(out var component))
					{
						component = gameObject.AddComponent<MeshRenderer>();
						component.lightProbeUsage = LightProbeUsage.Off;
					}
					int num2 = -lodCount + ((array2[i] == PatchType.Interior) ? (-1) : lodIndex);
					WaterChunkRenderer waterChunkRenderer = gameObject.AddComponent<WaterChunkRenderer>();
					Mesh mesh = meshData[(int)array2[i]];
					gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
					waterChunkRenderer._Water = water;
					waterChunkRenderer._SortingOrder = num2;
					waterChunkRenderer._SiblingIndex = s_SiblingIndex++;
					waterChunkRenderer.Initialize(lodIndex, component, mesh);
					tiles.Add(waterChunkRenderer);
					waterChunkRenderer._DrawRenderBounds = water.Surface._Debug._DrawRendererBounds;
					if (RenderPipelineHelper.IsHighDefinition)
					{
						component.rendererPriority = num2;
					}
					else if (!water.Surface.AllowRenderQueueSorting)
					{
						component.sortingOrder = num2;
					}
					component.shadowCastingMode = (water.Surface.CastShadows ? ShadowCastingMode.On : ShadowCastingMode.Off);
					component.receiveShadows = false;
					component.motionVectorGenerationMode = (water.WriteMotionVectors ? MotionVectorGenerationMode.Object : MotionVectorGenerationMode.ForceNoMotion);
					component.material = water.Surface.Material;
					OnCreateChunkRenderer?.Invoke(component);
					PatchType patchType = array2[i];
					if (patchType == PatchType.FatX || patchType == PatchType.FatXOuter || patchType == PatchType.SlimX || patchType == PatchType.SlimXFatZ)
					{
						if (Mathf.Abs(vector.y) >= Mathf.Abs(vector.x))
						{
							gameObject.transform.localEulerAngles = 90f * Mathf.Sign(vector.y) * -Vector3.up;
						}
						else
						{
							gameObject.transform.localEulerAngles = ((vector.x < 0f) ? (Vector3.up * 180f) : Vector3.zero);
						}
					}
					patchType = array2[i];
					if (patchType == PatchType.FatXZ || patchType == PatchType.SlimXZ || patchType == PatchType.FatXSlimZ || patchType == PatchType.FatXZOuter)
					{
						Vector3 normalized = new Vector3(1f, 0f, 1f).normalized;
						Vector3 normalized2 = gameObject.transform.localPosition.normalized;
						if (Mathf.Abs(gameObject.transform.localPosition.x) < 0.0001f || Mathf.Abs(Mathf.Abs(gameObject.transform.localPosition.x) - Mathf.Abs(gameObject.transform.localPosition.z)) > 0.001f)
						{
							Debug.LogWarning("Crest: Skipped rotating a patch because it isn't a corner, click here to highlight.", gameObject);
							continue;
						}
						if (Vector3.Dot(normalized, normalized2) < -0.99f)
						{
							gameObject.transform.localEulerAngles = Vector3.up * 180f;
						}
						else
						{
							gameObject.transform.localRotation = Quaternion.FromToRotation(normalized, normalized2);
						}
					}
					Bounds bounds = mesh.bounds;
					bounds = bounds.Rotate(waterChunkRenderer.transform.rotation);
					waterChunkRenderer._LocalBounds = bounds;
					waterChunkRenderer._LocalScale = waterChunkRenderer.transform.localScale.x;
				}
			}
		}

		[Tooltip("Whether the underwater effect is enabled.\n\nAllocates/releases resources if state has changed.")]
		[SerializeField]
		internal bool _Enabled = true;

		[Tooltip("The water chunk renderers will have this layer.")]
		[SerializeField]
		internal int _Layer = 4;

		[Tooltip("The meshing solution for the water surface.")]
		[SerializeField]
		private WaterMeshType _MeshType;

		[Tooltip("Template for water chunks as a prefab.\n\nThe only requirements are that the prefab must contain a MeshRenderer at the root and not a MeshFilter or WaterChunkRenderer. MR values will be overwritten where necessary and the prefabs are linked in edit mode.")]
		[SerializeField]
		internal GameObject _ChunkTemplate;

		[Tooltip("Whether to support using the surface material with other renderers.\n\nAlso requires enabling Custom Mesh on the material.")]
		[SerializeField]
		private bool _SupportCustomRenderers = true;

		[Tooltip("Material to use for the water surface.")]
		[SerializeField]
		internal Material _Material;

		[Tooltip("Underwater will copy from this material if set.\n\nUseful for overriding properties for the underwater effect. To see what properties can be overriden, see the disabled properties on the underwater material. This does not affect the surface.")]
		[SerializeField]
		internal Material _VolumeMaterial;

		[Tooltip("Have the water surface cast shadows for albedo (both foam and custom).")]
		[SerializeField]
		internal bool _CastShadows;

		[Tooltip("Whether 'Water Body' components will cull the water tiles.\n\nDisable if you want to use the 'Material Override' feature and still have an ocean.")]
		[SerializeField]
		internal bool _WaterBodyCulling = true;

		[Tooltip("How many frames to distribute the chunk bounds calculation.\n\nThe chunk bounds are calculated per frame to ensure culling is correct when using inputs that affect displacement. Some performance can be saved by distributing the load over several frames. The higher the frames, the longer it will take - lowest being instant.")]
		[SerializeField]
		internal int _TimeSliceBoundsUpdateFrameCount = 1;

		[Tooltip("Rules to exclude cameras from surface rendering.\n\nThese are exclusion rules, so for all cameras, select Nothing. These rules are applied on top of the Layer rules.")]
		[SerializeField]
		internal WaterCameraExclusion _CameraExclusions = WaterCameraExclusion.Hidden | WaterCameraExclusion.Reflection;

		[Tooltip("How to handle self-intersections of the water surface.\n\nThey can be caused by choppy waves which can cause a flipped underwater effect. When not using the portals/volumes, this fix is only applied when within 2 metres of the water surface. Automatic will disable the fix if portals/volumes are used which is the recommend setting.")]
		[SerializeField]
		internal SurfaceSelfIntersectionFixMode _SurfaceSelfIntersectionFixMode = SurfaceSelfIntersectionFixMode.Automatic;

		[Tooltip("Whether to allow sorting using the render queue.\n\nIf you need to change the minor part of the render queue (eg +100), then enable this option. As a side effect, it will also disable the front-to-back rendering optimization for Crest. This option does not affect changing the major part of the render queue (eg AlphaTest, Transparent), as that is always allowed.\n\nRender queue sorting is required for some third-party integrations.")]
		[SerializeField]
		internal bool _AllowRenderQueueSorting;

		[HideInInspector]
		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		private const string k_DrawWaterSurface = "Surface";

		internal WaterRenderer _Water;

		internal bool _Rebuild;

		private Renderer _RendererTemplate;

		private readonly MaterialPropertyBlock[] _PerCascadeMPB = new MaterialPropertyBlock[15];

		private float _LodAlphaBlackPointFade;

		private float _LodAlphaBlackPointWhitePointFade;

		internal readonly Plane[] _CameraFrustumPlanes = new Plane[6];

		private bool _CanSkipCulling;

		internal bool _DoneChunkVisibility;

		internal Material _MotionVectorMaterial;

		private bool _ForceRenderingOff;

		private Material _VisualizeDataMaterial;

		private bool _QueueMotionVectors;

		private Matrix4x4[] _PreviousObjectToWorld;

		internal Dictionary<Camera, MaterialPropertyBlock[]> _PerCameraPerCascadeMPB = new Dictionary<Camera, MaterialPropertyBlock[]>();

		internal Dictionary<Camera, Vector4[]> _PerCameraNormalMapParameters = new Dictionary<Camera, Vector4[]>();

		internal Dictionary<Camera, Matrix4x4[]> _PerCameraPreviousObjectToWorld = new Dictionary<Camera, Matrix4x4[]>();

		private readonly Vector4[] _NormalMapParameters = new Vector4[15];

		internal const int k_SurfaceDataShaderPass = 2;

		private RenderTexture _HeightRT;

		private CommandBuffer _BeforeRenderingCommands;

		private Material _DisplacedMaterial;

		internal SurfaceDataParameters _SurfaceDataParameters;

		internal MaterialPropertyBlock _SurfaceDataMPB;

		private CommandBuffer _DrawWaterSurfaceBuffer;

		private MaterialPropertyBlock _QuadMeshMPB;

		private Material _ForceShadowsMaterial;

		private ComputeBuffer _ShadowMatrixBuffer;

		private readonly Matrix4x4[] _ShadowMatrixDefaults = new Matrix4x4[4]
		{
			Matrix4x4.zero,
			Matrix4x4.zero,
			Matrix4x4.zero,
			Matrix4x4.zero
		};

		private Material _CaptureShadowMatrices;

		private CommandBuffer _DeferredShadowMapBuffer;

		private CommandBuffer _ScreenSpaceShadowMapBuffer;

		private readonly Mesh[] _Meshes = new Mesh[10];

		public bool AllowRenderQueueSorting
		{
			get
			{
				return _AllowRenderQueueSorting;
			}
			set
			{
				_AllowRenderQueueSorting = value;
			}
		}

		public WaterCameraExclusion CameraExclusions
		{
			get
			{
				return _CameraExclusions;
			}
			set
			{
				_CameraExclusions = value;
			}
		}

		public bool CastShadows
		{
			get
			{
				return GetCastShadows();
			}
			set
			{
				_CastShadows = value;
			}
		}

		public bool Enabled
		{
			get
			{
				return GetEnabled();
			}
			set
			{
				SetEnabled(_Enabled, _Enabled = value);
			}
		}

		public int Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}

		public Material Material
		{
			get
			{
				return _Material;
			}
			set
			{
				_Material = value;
			}
		}

		public bool SupportCustomRenderers
		{
			get
			{
				return _SupportCustomRenderers;
			}
			set
			{
				_SupportCustomRenderers = value;
			}
		}

		public int TimeSliceBoundsUpdateFrameCount
		{
			get
			{
				return _TimeSliceBoundsUpdateFrameCount;
			}
			set
			{
				_TimeSliceBoundsUpdateFrameCount = value;
			}
		}

		public Material VolumeMaterial
		{
			get
			{
				return _VolumeMaterial;
			}
			set
			{
				_VolumeMaterial = value;
			}
		}

		public bool WaterBodyCulling
		{
			get
			{
				return _WaterBodyCulling;
			}
			set
			{
				_WaterBodyCulling = value;
			}
		}

		internal Transform Root { get; private set; }

		internal List<WaterChunkRenderer> Chunks { get; } = new List<WaterChunkRenderer>();

		internal MaterialPropertyBlock[] PerCascadeMPB { get; private set; }

		public static Action<Renderer> OnCreateChunkRenderer { get; set; }

		internal Material AboveOrBelowSurfaceMaterial
		{
			get
			{
				if (!(_VolumeMaterial == null))
				{
					return _VolumeMaterial;
				}
				return _Material;
			}
		}

		internal bool IsQuadMesh => _MeshType == WaterMeshType.Quad;

		internal bool ForceRenderingOff
		{
			get
			{
				return _ForceRenderingOff;
			}
			set
			{
				_ForceRenderingOff = value;
				if (_Enabled)
				{
					Root.gameObject.SetActive(!_ForceRenderingOff && !IsQuadMesh);
				}
			}
		}

		internal Material VisualizeDataMaterial
		{
			get
			{
				if (_VisualizeDataMaterial == null)
				{
					_VisualizeDataMaterial = new Material(Shader.Find("Hidden/Crest/Debug/Visualize Data"));
				}
				return _VisualizeDataMaterial;
			}
		}

		private bool QueueMotionVectors
		{
			get
			{
				if (_QueueMotionVectors)
				{
					return !IsQuadMesh;
				}
				return false;
			}
		}

		internal Matrix4x4[] PreviousObjectToWorld { get; private set; }

		private Vector4[] NormalMapParameters { get; set; }

		internal RenderTexture HeightRT => _HeightRT;

		internal void Initialize()
		{
			Root = Builder.GenerateMesh(_Water, this, Chunks, _Water.LodResolution, _Water._GeometryDownSampleFactor, _Water.LodLevels);
			if (_ChunkTemplate != null)
			{
				_RendererTemplate = _ChunkTemplate.GetComponent<Renderer>();
			}
			Root.position = _Water.Position;
			Root.localScale = new Vector3(_Water.Scale, 1f, _Water.Scale);
			PerCascadeMPB = _PerCascadeMPB;
			NormalMapParameters = _NormalMapParameters;
			_PreviousObjectToWorld = new Matrix4x4[Chunks.Count];
			PreviousObjectToWorld = _PreviousObjectToWorld;
			InitializeProperties();
			float num = (float)_Water.LodResolution * 0.25f / (float)_Water._GeometryDownSampleFactor;
			_LodAlphaBlackPointFade = 0.4f / (num / 8f);
			_LodAlphaBlackPointWhitePointFade = 1f - _LodAlphaBlackPointFade - _LodAlphaBlackPointFade;
			Shader.SetGlobalFloat(ShaderIDs.s_LodAlphaBlackPointFade, _LodAlphaBlackPointFade);
			Shader.SetGlobalFloat(ShaderIDs.s_LodAlphaBlackPointWhitePointFade, _LodAlphaBlackPointWhitePointFade);
			UpdateMaterial(_Material, ref _MotionVectorMaterial);
			_CanSkipCulling = false;
			if (RenderPipelineHelper.IsLegacy)
			{
				LegacyOnEnable();
			}
		}

		internal void OnDestroy()
		{
			for (int i = 0; i < _Meshes?.Length; i++)
			{
				Helpers.Destroy(_Meshes[i]);
				_Meshes[i] = null;
			}
			Chunks.Clear();
			CoreUtils.Destroy(_MotionVectorMaterial);
			CoreUtils.Destroy(_DisplacedMaterial);
			_PerCameraPerCascadeMPB.Clear();
			_PerCameraNormalMapParameters.Clear();
			_PerCameraPreviousObjectToWorld.Clear();
			if (Root != null)
			{
				CoreUtils.Destroy(Root.gameObject);
				Root = null;
			}
			if (RenderPipelineHelper.IsLegacy)
			{
				LegacyOnDisable();
			}
		}

		private void ShowHiddenObjects(bool show)
		{
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				chunk.gameObject.hideFlags = (show ? HideFlags.DontSave : HideFlags.HideAndDontSave);
			}
		}

		internal void UpdateChunkVisibility(Camera camera)
		{
			if (_DoneChunkVisibility || IsQuadMesh)
			{
				return;
			}
			GeometryUtility.CalculateFrustumPlanes(camera, _CameraFrustumPlanes);
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				Renderer rend = chunk.Rend;
				if (!(rend == null))
				{
					chunk._Visible = GeometryUtility.TestPlanesAABB(_CameraFrustumPlanes, rend.bounds);
				}
			}
			_DoneChunkVisibility = true;
		}

		internal void UpdateMaterial(Material material, ref Material motion)
		{
			if (!(material == null))
			{
				bool enabled = !_Water.RenderBeforeTransparency;
				material.SetShaderPassEnabled("Forward", enabled);
				material.SetShaderPassEnabled("ForwardAdd", enabled);
				material.SetShaderPassEnabled("ForwardBase", enabled);
				material.SetShaderPassEnabled("UniversalForward", enabled);
				if (RenderPipelineHelper.IsHighDefinition)
				{
					material.SetShaderPassEnabled("ShadowCaster", _CastShadows);
				}
				UpdateMotionVectorsMaterial(material, ref motion);
			}
		}

		internal static bool IsTransparent(Material material)
		{
			if (!RenderPipelineHelper.IsLegacy)
			{
				return material.IsKeywordEnabled("_SURFACE_TYPE_TRANSPARENT");
			}
			return material.IsKeywordEnabled("_BUILTIN_SURFACE_TYPE_TRANSPARENT");
		}

		private void Rebuild()
		{
			OnDestroy();
			Initialize();
			_Rebuild = false;
		}

		internal bool ShouldRender(Camera camera)
		{
			if (!_Enabled)
			{
				return false;
			}
			if (!WaterRenderer.ShouldRender(camera, Layer, _CameraExclusions))
			{
				return false;
			}
			if (camera == _Water.Reflections.ReflectionCamera)
			{
				return false;
			}
			if (Material == null)
			{
				return false;
			}
			return true;
		}

		internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			WritePerCameraMaterialParameters(camera);
			if (ShouldRenderMotionVectors(camera) && QueueMotionVectors)
			{
				UpdateChunkVisibility(camera);
				foreach (WaterChunkRenderer chunk in Chunks)
				{
					chunk.RenderMotionVectors(this, camera);
				}
			}
			if (RenderPipelineHelper.IsUniversal)
			{
				WaterSurfaceRenderPass.Instance?.OnBeginCameraRendering(context, camera);
			}
			else if (RenderPipelineHelper.IsLegacy)
			{
				OnBeginCameraRenderingLegacy(camera);
			}
		}

		internal void OnEndCameraRendering(Camera camera)
		{
			_DoneChunkVisibility = false;
			if (RenderPipelineHelper.IsLegacy)
			{
				OnEndCameraRenderingLegacy(camera);
			}
		}

		private void InitializeProperties()
		{
			Array.Fill(NormalMapParameters, new Vector4(0f, 0f, 1f, 0f));
			for (int i = 0; i < PerCascadeMPB.Length; i++)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetInteger(Lod.ShaderIDs.s_LodIndex, i);
				materialPropertyBlock.SetFloat(ShaderIDs.s_ChunkFarNormalsWeight, 1f);
				PerCascadeMPB[i] = materialPropertyBlock;
			}
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				PreviousObjectToWorld[chunk._SiblingIndex] = chunk.transform.localToWorldMatrix;
			}
		}

		private void WritePerCameraMaterialParameters(Camera camera)
		{
			if (!(Material == null))
			{
				if (!_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Volume) && _SurfaceSelfIntersectionFixMode == SurfaceSelfIntersectionFixMode.Automatic)
				{
					Shader.SetGlobalInteger(ShaderIDs.s_ForceUnderwater, 2);
					return;
				}
				_Water.UpdatePerCameraHeight(camera);
				float viewerHeightAboveWaterPerCamera = _Water._ViewerHeightAboveWaterPerCamera;
				ForceFacing value = _SurfaceSelfIntersectionFixMode switch
				{
					SurfaceSelfIntersectionFixMode.On => _Water._PerCameraHeightReady ? ((viewerHeightAboveWaterPerCamera < -2f) ? ForceFacing.BelowWater : ((viewerHeightAboveWaterPerCamera > 2f) ? ForceFacing.AboveWater : ForceFacing.None)) : ForceFacing.None, 
					SurfaceSelfIntersectionFixMode.Automatic => (!_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Portal) && _Water._PerCameraHeightReady) ? ((viewerHeightAboveWaterPerCamera < -2f) ? ForceFacing.BelowWater : ((viewerHeightAboveWaterPerCamera > 2f) ? ForceFacing.AboveWater : ForceFacing.None)) : ForceFacing.None, 
					SurfaceSelfIntersectionFixMode.Off => ForceFacing.Facing, 
					_ => (ForceFacing)_SurfaceSelfIntersectionFixMode, 
				};
				Shader.SetGlobalInteger(ShaderIDs.s_ForceUnderwater, (int)value);
			}
		}

		internal void LateUpdate()
		{
			if (_Rebuild)
			{
				Rebuild();
			}
			if (_ForceRenderingOff)
			{
				return;
			}
			LoadCameraData(_Water.CurrentCamera);
			Root.position = _Water.Position;
			Root.localScale = new Vector3(_Water.Scale, 1f, _Water.Scale);
			Root.gameObject.SetActive(!IsQuadMesh);
			if (Material != null)
			{
				LocalKeyword keyword = Material.shader.keywordSpace.FindKeyword("_CREST_CUSTOM_MESH");
				if (keyword.isValid)
				{
					Material.SetKeyword(in keyword, IsQuadMesh);
				}
			}
			WritePerCascadeInstanceData();
			if (IsQuadMesh || _SupportCustomRenderers)
			{
				Shader.SetGlobalVectorArray(ShaderIDs.s_NormalMapParameters, NormalMapParameters);
			}
			if (IsQuadMesh)
			{
				LateUpdateQuadMesh();
				return;
			}
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				chunk.UpdateMeshBounds(_Water, this);
			}
			ApplyWaterBodyCulling();
			LateUpdateMotionVectors();
			UpdateMaterial(_Material, ref _MotionVectorMaterial);
			foreach (WaterBody waterBody in WaterBody.WaterBodies)
			{
				if (waterBody._Material != null)
				{
					UpdateMaterial(waterBody._Material, ref waterBody._MotionVectorMaterial);
				}
			}
			foreach (WaterChunkRenderer chunk2 in Chunks)
			{
				chunk2.OnLateUpdate();
			}
		}

		private void WritePerCascadeInstanceData()
		{
			int lodLevels = _Water.LodLevels;
			float num = (float)_Water.LodResolution * 0.25f / (float)_Water._GeometryDownSampleFactor;
			PerCascadeMPB[0].SetFloat(ShaderIDs.s_ChunkMeshScaleAlpha, _Water.ScaleCouldIncrease ? _Water.ViewerAltitudeLevelAlpha : 0f);
			float num2 = (_Water.ScaleCouldDecrease ? _Water.ViewerAltitudeLevelAlpha : 1f);
			PerCascadeMPB[lodLevels - 1].SetFloat(ShaderIDs.s_ChunkFarNormalsWeight, num2);
			NormalMapParameters[lodLevels - 1] = new Vector4(0f, 0f, num2, 0f);
			for (int i = 0; i < lodLevels; i++)
			{
				MaterialPropertyBlock obj = PerCascadeMPB[i];
				float num3 = _Water.CascadeData.Current[i].x / num;
				obj.SetFloat(ShaderIDs.s_ChunkGeometryGridWidth, num3);
				float num4 = 1.875f;
				float p = 1.4f;
				float num5 = num3 / (float)_Water._GeometryDownSampleFactor;
				Vector2 vector = new Vector2(Mathf.Pow(Mathf.Log(1f + 2f * num5) * num4, p), Mathf.Pow(Mathf.Log(1f + 4f * num5) * num4, p));
				obj.SetVector(ShaderIDs.s_ChunkNormalScrollSpeed, vector);
				Vector4 vector2 = NormalMapParameters[i];
				vector2.x = vector.x;
				vector2.y = vector.y;
				NormalMapParameters[i] = vector2;
			}
		}

		private void ApplyWaterBodyCulling()
		{
			bool flag = WaterBody.WaterBodies.Count == 0 && _CanSkipCulling;
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				if (chunk.Rend == null)
				{
					continue;
				}
				chunk._Culled = false;
				chunk.MaterialOverridden = false;
				if (!flag)
				{
					Bounds bounds = chunk.Rend.bounds;
					Rect unexpandedBoundsXZ = chunk.UnexpandedBoundsXZ;
					float num = 0f;
					bool flag2 = false;
					foreach (WaterBody waterBody in WaterBody.WaterBodies)
					{
						if (flag2 && waterBody.AboveSurfaceMaterial == null)
						{
							continue;
						}
						Bounds aABB = waterBody.AABB;
						if (!(aABB.max.x > bounds.min.x) || !(aABB.min.x < bounds.max.x) || !(aABB.max.z > bounds.min.z) || !(aABB.min.z < bounds.max.z))
						{
							continue;
						}
						flag2 = true;
						if (waterBody.AboveSurfaceMaterial != null)
						{
							float num2 = 0f;
							float num3 = Mathf.Max(aABB.min.x, unexpandedBoundsXZ.min.x);
							float num4 = Mathf.Min(aABB.max.x, unexpandedBoundsXZ.max.x);
							float num5 = Mathf.Max(aABB.min.z, unexpandedBoundsXZ.min.y);
							float num6 = Mathf.Min(aABB.max.z, unexpandedBoundsXZ.max.y);
							if (num3 < num4 && num5 < num6)
							{
								num2 = (num4 - num3) * (num6 - num5);
							}
							if (num2 > num)
							{
								chunk.MaterialOverridden = true;
								chunk.Rend.sharedMaterial = waterBody.AboveSurfaceMaterial;
								chunk._MotionVectorMaterial = waterBody._MotionVectorMaterial;
								num = num2;
							}
						}
						else
						{
							chunk.MaterialOverridden = false;
						}
					}
					chunk._Culled = _WaterBodyCulling && !flag2 && WaterBody.WaterBodies.Count > 0;
				}
				chunk.Rend.enabled = !chunk._Culled;
			}
			_CanSkipCulling = WaterBody.WaterBodies.Count == 0;
		}

		internal void Render(Camera camera, CommandBuffer buffer, Material material = null, int pass = 0, bool culled = false, MaterialPropertyBlock mpb = null)
		{
			bool flag = material == null;
			if (flag && Material == null)
			{
				return;
			}
			if (IsQuadMesh)
			{
				buffer.DrawMesh(Helpers.QuadMesh, Matrix4x4.TRS(Root.position, Quaternion.Euler(90f, 0f, 0f), new Vector3(10000f, 10000f, 1f)), flag ? Material : material, 0, pass, mpb);
				return;
			}
			UpdateChunkVisibility(camera);
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				Renderer rend = chunk.Rend;
				if (!(rend == null) && chunk._Visible && (!culled || !chunk._Culled))
				{
					if (!chunk._WaterDataHasBeenBound)
					{
						chunk.Bind();
					}
					if (flag)
					{
						material = rend.sharedMaterial;
					}
					buffer.DrawRenderer(rend, material, 0, pass);
				}
			}
		}

		private bool GetEnabled()
		{
			if (_Enabled)
			{
				return !_Water.IsRunningWithoutGraphics;
			}
			return false;
		}

		private void SetEnabled(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled)
			{
				if (_Enabled)
				{
					Initialize();
				}
				else
				{
					OnDestroy();
				}
			}
		}

		private void SetLayer(int previous, int current)
		{
			if (previous == current)
			{
				return;
			}
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				chunk.gameObject.layer = current;
			}
		}

		private bool GetCastShadows()
		{
			return _CastShadows;
		}

		private void SetCastShadows(bool previous, bool current)
		{
			if (previous == current)
			{
				return;
			}
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				chunk.Rend.shadowCastingMode = (current ? ShadowCastingMode.On : ShadowCastingMode.Off);
			}
		}

		private void SetAllowRenderQueueSorting(bool previous, bool current)
		{
			if (previous == current)
			{
				return;
			}
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				chunk.Rend.sortingOrder = (current ? chunk._SortingOrder : 0);
			}
		}

		private bool ShouldRenderMotionVectors(Camera camera)
		{
			if (!camera.depthTextureMode.HasFlag(DepthTextureMode.MotionVectors))
			{
				return false;
			}
			return true;
		}

		private void LateUpdateMotionVectors()
		{
			_QueueMotionVectors = false;
			if (RenderPipelineHelper.IsHighDefinition || !Application.isPlaying || !_Water.WriteMotionVectors || !IsTransparent(Material))
			{
				return;
			}
			ArrayPool<Camera> shared = ArrayPool<Camera>.Shared;
			Camera[] array = shared.Rent(Camera.allCamerasCount);
			Camera.GetAllCameras(array);
			for (int i = 0; i < Camera.allCamerasCount; i++)
			{
				Camera camera = array[i];
				if (ShouldRender(camera) && ShouldRenderMotionVectors(camera))
				{
					_QueueMotionVectors = true;
				}
			}
			shared.Return(array);
		}

		private void UpdateMotionVectorsMaterial(Material surface, ref Material motion)
		{
			if (QueueMotionVectors)
			{
				if (motion == null || motion.shader != surface.shader)
				{
					CoreUtils.Destroy(motion);
					motion = CoreUtils.CreateEngineMaterial(surface.shader);
					motion.SetShaderPassEnabled("ForwardBase", enabled: false);
					motion.SetShaderPassEnabled("ForwardAdd", enabled: false);
					motion.SetShaderPassEnabled("Deferred", enabled: false);
					motion.SetShaderPassEnabled("UniversalForward", enabled: false);
					motion.SetShaderPassEnabled("UniversalGBuffer", enabled: false);
					motion.SetShaderPassEnabled("Universal2D", enabled: false);
					motion.SetShaderPassEnabled("ShadowCaster", enabled: false);
					motion.SetShaderPassEnabled("DepthOnly", enabled: false);
					motion.SetShaderPassEnabled("DepthNormals", enabled: false);
					motion.SetShaderPassEnabled("Meta", enabled: false);
					motion.SetShaderPassEnabled("SceneSelectionPass", enabled: false);
					motion.SetShaderPassEnabled("Picking", enabled: false);
					motion.SetShaderPassEnabled("MotionVectors", enabled: true);
				}
				motion.CopyMatchingPropertiesFromMaterial(surface);
				motion.renderQueue = 2000;
				motion.SetOverrideTag("RenderType", "Opaque");
				motion.SetFloat(WaveHarmonic.Crest.ShaderIDs.Unity.s_Surface, 0f);
				motion.SetFloat(WaveHarmonic.Crest.ShaderIDs.Unity.s_SrcBlend, 1f);
				motion.SetFloat(WaveHarmonic.Crest.ShaderIDs.Unity.s_DstBlend, 0f);
				motion.SetFloat(ShaderIDs.s_BuiltShadowCasterZTest, 1f);
			}
		}

		private void LoadCameraData(Camera camera)
		{
			if (!_Water.IsSingleViewpointMode)
			{
				if (!_PerCameraPerCascadeMPB.ContainsKey(camera))
				{
					PerCascadeMPB = new MaterialPropertyBlock[15];
					_PerCameraPerCascadeMPB.Add(camera, PerCascadeMPB);
					NormalMapParameters = new Vector4[15];
					_PerCameraNormalMapParameters.Add(camera, NormalMapParameters);
					PreviousObjectToWorld = new Matrix4x4[Chunks.Count];
					_PerCameraPreviousObjectToWorld.Add(camera, PreviousObjectToWorld);
					InitializeProperties();
				}
				else
				{
					PerCascadeMPB = _PerCameraPerCascadeMPB[camera];
					NormalMapParameters = _PerCameraNormalMapParameters[camera];
					PreviousObjectToWorld = _PerCameraPreviousObjectToWorld[camera];
				}
			}
		}

		internal void RemoveCameraData(Camera camera)
		{
			if (_PerCameraPerCascadeMPB.ContainsKey(camera))
			{
				_PerCameraPerCascadeMPB.Remove(camera);
				_PerCameraNormalMapParameters.Remove(camera);
				_PerCameraPreviousObjectToWorld.Remove(camera);
			}
		}

		private void LateUpdateQuadMesh()
		{
			Vector3 vector = new Vector3(10000f * _Water.Scale, 10000f * _Water.Scale, 1f);
			Bounds bounds = Helpers.QuadMesh.bounds;
			bounds.Expand(vector);
			RenderParams rparams = new RenderParams
			{
				motionVectorMode = MotionVectorGenerationMode.Camera,
				material = Material,
				worldBounds = Root.TransformBounds(bounds),
				layer = Layer,
				shadowCastingMode = (CastShadows ? ShadowCastingMode.On : ShadowCastingMode.Off),
				lightProbeUsage = LightProbeUsage.Off,
				reflectionProbeUsage = ReflectionProbeUsage.BlendProbesAndSkybox,
				renderingLayerMask = ((!(_RendererTemplate != null)) ? 1u : _RendererTemplate.renderingLayerMask)
			};
			Graphics.RenderMesh(in rparams, Helpers.QuadMesh, 0, Matrix4x4.TRS(Root.position, Quaternion.Euler(90f, 0f, 0f), vector));
			UpdateMaterial(_Material, ref _MotionVectorMaterial);
		}

		internal void BindDisplacedSurfaceData<T>(T properties) where T : IPropertyWrapper
		{
			int s_WaterLine = ShaderIDs.s_WaterLine;
			RenderTexture heightRT = HeightRT;
			properties.SetTexture(s_WaterLine, heightRT);
			int s_WaterLineSnappedPosition = ShaderIDs.s_WaterLineSnappedPosition;
			Vector4 value = _SurfaceDataParameters._SnappedPosition;
			properties.SetVector(s_WaterLineSnappedPosition, value);
			int s_WaterLineResolution = ShaderIDs.s_WaterLineResolution;
			Vector4 value2 = _SurfaceDataParameters._Resolution;
			properties.SetVector(s_WaterLineResolution, value2);
			int s_WaterLineTexel = ShaderIDs.s_WaterLineTexel;
			float texel = _SurfaceDataParameters._Texel;
			properties.SetFloat(s_WaterLineTexel, texel);
		}

		internal void UpdateDisplacedSurfaceData(Camera camera)
		{
			Helpers.SetGlobalBoolean(ShaderIDs.s_WaterLineFlatWater, IsQuadMesh);
			if (IsQuadMesh)
			{
				return;
			}
			float num = 1f + camera.nearClipPlane * 2f;
			Bounds bounds = new Bounds(camera.transform.position, Vector3.one * num);
			if (_DisplacedMaterial == null)
			{
				_DisplacedMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._UnderwaterMask);
			}
			if (_BeforeRenderingCommands == null)
			{
				_BeforeRenderingCommands = new CommandBuffer();
			}
			CommandBuffer beforeRenderingCommands = _BeforeRenderingCommands;
			beforeRenderingCommands.name = "Crest.DrawMask";
			beforeRenderingCommands.Clear();
			UpdateDisplacedSurfaceData(beforeRenderingCommands, bounds, "_Crest_WaterLine", ref _HeightRT, 0.0125f, 2048, out _SurfaceDataParameters);
			if (_SurfaceDataMPB == null)
			{
				_SurfaceDataMPB = new MaterialPropertyBlock();
			}
			PropertyWrapperMPB properties = new PropertyWrapperMPB(_SurfaceDataMPB);
			BindDisplacedSurfaceData(properties);
			int num2 = 0;
			MaterialPropertyBlock properties2 = PerCascadeMPB[num2];
			Transform viewpoint = _Water.Viewpoint;
			if (viewpoint == null || (viewpoint != camera.transform && Vector3.Distance(viewpoint.position, camera.transform.position) > 0.01f))
			{
				foreach (WaterChunkRenderer chunk in _Water.Surface.Chunks)
				{
					if (bounds.IntersectsXZ(chunk.Rend.bounds))
					{
						beforeRenderingCommands.DrawMesh(chunk._Mesh, chunk.transform.localToWorldMatrix, _DisplacedMaterial, 0, 2, chunk._MaterialPropertyBlock);
					}
				}
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					beforeRenderingCommands.DrawMesh(_Meshes[num2], Root.localToWorldMatrix * Matrix4x4.TRS(Builder.s_OffsetsFirstLod[i].XNZ(), Quaternion.identity, Vector3.one), _DisplacedMaterial, 0, 2, properties2);
				}
			}
			Graphics.ExecuteCommandBuffer(beforeRenderingCommands);
		}

		internal void UpdateDisplacedSurfaceData(CommandBuffer commands, Bounds bounds, string name, ref RenderTexture target, float texel, int maximumResolution, out SurfaceDataParameters parameters)
		{
			Vector2 vector = bounds.size.XZ();
			Vector2 vector2 = bounds.center.XZ();
			Vector2Int vector2Int = new Vector2Int(Mathf.CeilToInt(vector.x / texel), Mathf.CeilToInt(vector.y / texel));
			if (Mathf.Max(vector2Int.x, vector2Int.y) > maximumResolution)
			{
				texel = Mathf.Max(vector.x, vector.y) / (float)maximumResolution;
				vector2Int = new Vector2Int(Mathf.CeilToInt(vector.x / texel), Mathf.CeilToInt(vector.y / texel));
			}
			Vector2 vector3 = vector2 - new Vector2(Mathf.Repeat(vector2.x, texel), Mathf.Repeat(vector2.y, texel));
			parameters = new SurfaceDataParameters
			{
				_SnappedPosition = vector3,
				_Resolution = vector2Int,
				_Texel = texel
			};
			Matrix4x4 view = WaterRenderer.CalculateViewMatrixFromSnappedPositionRHS(vector3.XNZ());
			Matrix4x4 proj = Matrix4x4.Ortho(vector.x * -0.5f, vector.x * 0.5f, vector.y * -0.5f, vector.y * 0.5f, 1f, 20000f);
			if (target == null)
			{
				target = new RenderTexture(vector2Int.x, vector2Int.y, 0)
				{
					name = name,
					graphicsFormat = GraphicsFormat.R32_SFloat
				};
			}
			else if (target.width != vector2Int.x || target.height != vector2Int.y)
			{
				target.Release();
				target.width = vector2Int.x;
				target.height = vector2Int.y;
			}
			if (!target.IsCreated())
			{
				target.Create();
			}
			commands.SetViewProjectionMatrices(view, proj);
			commands.SetRenderTarget(target);
			commands.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commands.SetGlobalTexture(ShaderIDs.s_WaterLine, target);
			commands.SetGlobalVector(ShaderIDs.s_WaterLineSnappedPosition, vector3);
			commands.SetGlobalVector(ShaderIDs.s_WaterLineResolution, (Vector2)vector2Int);
			commands.SetGlobalFloat(ShaderIDs.s_WaterLineTexel, texel);
		}

		private void OnBeginCameraRenderingLegacy(Camera camera)
		{
			_Water.UpdateMatrices(camera);
			if (IsTransparent(Material))
			{
				if (_DrawWaterSurfaceBuffer == null)
				{
					_DrawWaterSurfaceBuffer = new CommandBuffer
					{
						name = "Crest.DrawWater"
					};
				}
				_DrawWaterSurfaceBuffer.Clear();
				_Water.OnBeginCameraOpaqueTexture(camera);
				SetUpShadows(camera);
				if (_Water.RenderBeforeTransparency)
				{
					Draw(_DrawWaterSurfaceBuffer, camera);
				}
				camera.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, _DrawWaterSurfaceBuffer);
			}
		}

		private void OnEndCameraRenderingLegacy(Camera camera)
		{
			_Water.OnEndCameraOpaqueTexture(camera);
			if (_DrawWaterSurfaceBuffer != null)
			{
				camera.RemoveCommandBuffer(CameraEvent.BeforeForwardAlpha, _DrawWaterSurfaceBuffer);
			}
			if (QualitySettings.shadows != UnityEngine.ShadowQuality.Disable && _Water.PrimaryLight != null)
			{
				if (_ScreenSpaceShadowMapBuffer != null)
				{
					_Water.PrimaryLight.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, _ScreenSpaceShadowMapBuffer);
				}
				if (_DeferredShadowMapBuffer != null)
				{
					_Water.PrimaryLight.RemoveCommandBuffer(LightEvent.AfterShadowMap, _DeferredShadowMapBuffer);
				}
			}
			Shader.SetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_ShadowMapTexture, Texture2D.whiteTexture);
		}

		internal void Draw(CommandBuffer commands, Camera camera)
		{
			commands.BeginSample("Surface");
			CoreUtils.SetRenderTarget(commands, BuiltinRenderTextureType.CameraTarget);
			Light sun = RenderSettings.sun;
			if (sun != null)
			{
				commands.SetGlobalVector(WaveHarmonic.Crest.ShaderIDs.Unity.s_LightColor0, sun.FinalColor());
				commands.SetGlobalVector(WaveHarmonic.Crest.ShaderIDs.Unity.s_WorldSpaceLightPos0, -sun.transform.forward);
			}
			commands.SetShaderKeyword("LIGHTPROBE_SH", enabled: true);
			if (IsQuadMesh)
			{
				if (_QuadMeshMPB == null)
				{
					_QuadMeshMPB = new MaterialPropertyBlock();
				}
				new PropertyWrapperMPB(_QuadMeshMPB).SetSHCoefficients(Root.position);
				Render(camera, commands, Material, 0, culled: false, _QuadMeshMPB);
				commands.EndSample("Surface");
				return;
			}
			UpdateChunkVisibility(camera);
			foreach (WaterChunkRenderer chunk in Chunks)
			{
				Renderer rend = chunk.Rend;
				if (!(chunk.Rend == null) && chunk._Visible && !chunk._Culled)
				{
					if (!chunk._WaterDataHasBeenBound)
					{
						chunk.Bind();
					}
					commands.DrawRenderer(chunk.Rend, rend.sharedMaterial, 0, 0);
				}
			}
			commands.EndSample("Surface");
		}

		private void LegacyOnEnable()
		{
			if (_ShadowMatrixBuffer == null)
			{
				_ShadowMatrixBuffer = new ComputeBuffer(4, 64, ComputeBufferType.Structured);
			}
			_ShadowMatrixBuffer.SetData(_ShadowMatrixDefaults);
		}

		private void LegacyOnDisable()
		{
			_ShadowMatrixBuffer?.Dispose();
			_ShadowMatrixBuffer = null;
		}

		private void SetUpShadows(Camera camera)
		{
			if (QualitySettings.shadows == UnityEngine.ShadowQuality.Disable || _Water.PrimaryLight == null)
			{
				return;
			}
			Transform transform = camera.transform;
			if (_ForceShadowsMaterial == null)
			{
				_ForceShadowsMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._ForceShadows);
			}
			RenderParams rparams = new RenderParams(_ForceShadowsMaterial);
			rparams.receiveShadows = true;
			rparams.shadowCastingMode = ShadowCastingMode.Off;
			Graphics.RenderMesh(in rparams, Helpers.QuadMesh, 0, (QualitySettings.shadowProjection == ShadowProjection.StableFit) ? Matrix4x4.TRS(transform.position + transform.forward, Quaternion.LookRotation(transform.forward), Vector3.one * 0.01f) : Matrix4x4.TRS(Vector3.up * _Water.SeaLevel, Quaternion.LookRotation(-Vector3.up), Vector3.one * 100f));
			if (Material.IsKeywordEnabled("_BUILTIN_TRANSPARENT_RECEIVES_SHADOWS"))
			{
				if (_CaptureShadowMatrices == null)
				{
					_CaptureShadowMatrices = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._CaptureShadowMatrices);
				}
				Shader.SetGlobalBuffer(ShaderIDs.s_WorldToShadow, _ShadowMatrixBuffer);
				if (_ScreenSpaceShadowMapBuffer == null)
				{
					_ScreenSpaceShadowMapBuffer = new CommandBuffer
					{
						name = "Crest.DrawWater"
					};
				}
				_ScreenSpaceShadowMapBuffer.Clear();
				_ScreenSpaceShadowMapBuffer.GetTemporaryRT(ShaderIDs.s_DummyTarget, new RenderTextureDescriptor(4, 4));
				CoreUtils.SetRenderTarget(_ScreenSpaceShadowMapBuffer, ShaderIDs.s_DummyTarget);
				_ScreenSpaceShadowMapBuffer.ClearRandomWriteTargets();
				_ScreenSpaceShadowMapBuffer.SetRandomWriteTarget(1, _ShadowMatrixBuffer);
				_ScreenSpaceShadowMapBuffer.DrawProcedural(Matrix4x4.identity, _CaptureShadowMatrices, 0, MeshTopology.Triangles, 3);
				_ScreenSpaceShadowMapBuffer.ClearRandomWriteTargets();
				_ScreenSpaceShadowMapBuffer.ReleaseTemporaryRT(ShaderIDs.s_DummyTarget);
				_Water.PrimaryLight.AddCommandBuffer(LightEvent.AfterScreenspaceMask, _ScreenSpaceShadowMapBuffer);
				if (_DeferredShadowMapBuffer == null)
				{
					_DeferredShadowMapBuffer = new CommandBuffer
					{
						name = "Crest.DrawWater"
					};
				}
				_DeferredShadowMapBuffer.Clear();
				_DeferredShadowMapBuffer.SetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_ShadowMapTexture, BuiltinRenderTextureType.CurrentActive);
				_Water.PrimaryLight.AddCommandBuffer(LightEvent.AfterShadowMap, _DeferredShadowMapBuffer);
				_DrawWaterSurfaceBuffer.SetKeyword(new GlobalKeyword("SHADOWS_SINGLE_CASCADE"), QualitySettings.shadowCascades == 1);
				_DrawWaterSurfaceBuffer.SetKeyword(new GlobalKeyword("SHADOWS_SPLIT_SPHERES"), QualitySettings.shadowProjection == ShadowProjection.StableFit);
				_DrawWaterSurfaceBuffer.SetKeyword(new GlobalKeyword("SHADOWS_SOFT"), QualitySettings.shadows == UnityEngine.ShadowQuality.All);
			}
		}
	}
}
