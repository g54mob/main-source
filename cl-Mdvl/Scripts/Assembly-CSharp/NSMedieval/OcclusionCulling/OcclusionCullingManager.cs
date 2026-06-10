using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NGS.MeshFusionPro;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Stockpiles;
using NSMedieval.Tools.Math;
using NSMedieval.UI;
using NSMedieval.Village.Map;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.OcclusionCulling
{
	public class OcclusionCullingManager : MonoSingleton<OcclusionCullingManager>
	{
		private static readonly Vec3Int ChunkSize = new Vec3Int(2, 1, 2);

		private const int HiZWidth = 1024;

		private const int HiZHeight = 512;

		private const float FrustumCullMargin = 20f;

		private const int TemporalHysteresisFrames = 15;

		private const float UpdateFrequencySeconds = 1f / 30f;

		private const int RotatingBufferCount = 3;

		private static readonly int VoxelsInChunk = ChunkSize.x * ChunkSize.y * ChunkSize.z;

		private static readonly int InputDepthTexturePropId = Shader.PropertyToID("_InputDepthTexture");

		private static readonly int ResultPropId = Shader.PropertyToID("_Result");

		private static readonly int InputMipTexturePropId = Shader.PropertyToID("_InputMipTexture");

		private static readonly int HiZTextureId = Shader.PropertyToID("_HiZTexture");

		private static readonly int BoxesCenterId = Shader.PropertyToID("_BoxesCenter");

		private static readonly int BoxesExtentsId = Shader.PropertyToID("_BoxesExtents");

		private static readonly int ViewMatrixId = Shader.PropertyToID("_ViewMatrix");

		private static readonly int ProjectionMatrixId = Shader.PropertyToID("_ProjectionMatrix");

		private static readonly int BoxesVisibleId = Shader.PropertyToID("_BoxesVisible");

		private static readonly int FarPlaneId = Shader.PropertyToID("_FarPlane");

		private static readonly int NearPlaneId = Shader.PropertyToID("_NearPlane");

		private static readonly int WorldLayerId = Shader.PropertyToID("_WorldLayer");

		private static readonly int FrustumCullMarginId = Shader.PropertyToID("_FrustumCullMargin");

		private static readonly int ScreenWidthId = Shader.PropertyToID("_ScreenWidth");

		private static readonly int ScreenHeightId = Shader.PropertyToID("_ScreenHeight");

		private static readonly int ObjectCountId = Shader.PropertyToID("_ObjectCount");

		private static readonly int ZBufferParamsId = Shader.PropertyToID("_ZBufferParams");

		private OcclusionChunk[] chunks;

		private int activeChunkCount;

		private int headChunkIndex;

		private int tailChunkIndex;

		private GraphicsBuffer cubeMeshVertices;

		private GraphicsBuffer cubeMeshTriangles;

		private Mesh cubeMesh;

		[SerializeField]
		private Material occluderDepthMaterial;

		private RenderTexture occluderDepthRenderTexture;

		private Matrix4x4[] chunkOccluderBoxMatrices;

		[SerializeField]
		private ComputeShader hiZShader;

		private RenderTexture hiZTexture;

		private ComputeBuffer[] boxesOccludeeCenterBuffers;

		private ComputeBuffer[] boxesOccludeeExtentsBuffers;

		private ComputeBuffer[] isChunkVisibleBuffers;

		private bool[] isBufferDirty;

		private int depthCopyKernelId;

		private int downSampleKernelId;

		private int cullKernelId;

		private CommandBuffer commandBuffer;

		private static Vec3Int chunkWorldSize;

		private Camera mainCamera;

		private bool isInitialized;

		private VillageMap villageMap;

		private float lastUpdateTime;

		private int bufferIndex;

		private int activeChunkListVersion;

		public bool IsReadbackPaused { get; set; }

		public void InitAfterLoad(VillageMap villageMap)
		{
			if (SystemInfo.supportsComputeShaders)
			{
				this.villageMap = villageMap;
				depthCopyKernelId = hiZShader.FindKernel("DepthCopy");
				downSampleKernelId = hiZShader.FindKernel("DownSample");
				cullKernelId = hiZShader.FindKernel("Cull");
				commandBuffer = new CommandBuffer();
				mainCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
				CreateHiZTextures();
				hiZShader.SetInt(ScreenWidthId, Screen.width);
				hiZShader.SetInt(ScreenHeightId, Screen.height);
				hiZShader.SetFloat(FrustumCullMarginId, 20f);
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cubeMesh = gameObject.GetComponent<MeshFilter>().mesh;
				UnityEngine.Object.Destroy(gameObject);
				cubeMeshTriangles = new GraphicsBuffer(GraphicsBuffer.Target.Structured, cubeMesh.triangles.Length, 4);
				cubeMeshTriangles.SetData(cubeMesh.triangles);
				cubeMeshVertices = new GraphicsBuffer(GraphicsBuffer.Target.Structured, cubeMesh.vertices.Length, 12);
				cubeMeshVertices.SetData(cubeMesh.vertices);
				Vec3Int size = this.villageMap.Size;
				chunkWorldSize.x = Mathf.CeilToInt((float)size.x / (float)ChunkSize.x);
				chunkWorldSize.y = Mathf.CeilToInt((float)size.y / (float)ChunkSize.y);
				chunkWorldSize.z = Mathf.CeilToInt((float)size.z / (float)ChunkSize.z);
				int num = chunkWorldSize.x * chunkWorldSize.y * chunkWorldSize.z;
				chunks = new OcclusionChunk[num];
				for (int i = 0; i < chunks.Length; i++)
				{
					chunks[i] = OcclusionChunk.New();
				}
				headChunkIndex = -1;
				tailChunkIndex = -1;
				activeChunkCount = 0;
				isBufferDirty = new bool[3];
				InitializeChunks();
				CombinedLODGroup.ObjectActivated += RegisterObject;
				CombinedLODGroup.ObjectDeactivated += UnregisterObject;
				CombinedLODGroup.BoundsChanged += OnFusedMeshBoundsChanged;
				MonoSingleton<StockpileController>.Instance.StockpilePlacedEvent += OnStockpilePlaced;
				MonoSingleton<StockpileController>.Instance.StockpileDestroyedEvent += OnStockpileDestroyed;
				MonoSingleton<CropsController>.Instance.CropfieldPlacedEvent += OnCropfieldPlaced;
				MonoSingleton<CropsController>.Instance.CropfieldDestroyedEvent += OnCropfieldDestroyed;
				this.villageMap.RoofComponentManager.SetRoofsVisibleEvent += OnRoofsVisibleChanged;
				IsReadbackPaused = true;
				MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameplayStart;
				isInitialized = true;
			}
		}

		public void RegisterObject(IOcclusionObject occlusionObject)
		{
			if (isInitialized && occlusionObject != null && occlusionObject.OcclusionCullingMode != OcclusionCullingMode.Disabled && !LoadingController.IsSceneTransition)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("RegisterObject ");
					messageBuilder.AppendFormatted(occlusionObject);
				}
				Log.Trace(messageBuilder);
				int num = NodePositionToChunkIndex(occlusionObject.WorldPosition.ToGridVec3Int());
				ref OcclusionChunk reference = ref chunks[num];
				if (!reference.IsAlive)
				{
					AddToLinkedList(ref reference, num, bufferIndex);
				}
				ref List<IOcclusionObject> objects = ref reference.Objects;
				if (objects == null)
				{
					objects = new List<IOcclusionObject>();
				}
				if (!reference.Objects.Contains(occlusionObject))
				{
					reference.Objects.Add(occlusionObject);
				}
				RecalculateChunkBounds(ref reference);
				SetChunkVisible(ref reference, isVisible: true);
				EnsureBuffers();
				SetBuffersDirty();
			}
		}

		private void SetBuffersDirty()
		{
			for (int i = 0; i < 3; i++)
			{
				isBufferDirty[i] = true;
			}
		}

		public void UnregisterObject(IOcclusionObject occlusionObject)
		{
			if (!isInitialized || occlusionObject == null || LoadingController.IsSceneTransition)
			{
				return;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("UnregisterObject ");
				messageBuilder.AppendFormatted(occlusionObject);
			}
			Log.Trace(messageBuilder);
			Vec3Int nodePosition = occlusionObject.WorldPosition.ToGridVec3Int();
			int num = NodePositionToChunkIndex(in nodePosition);
			ref OcclusionChunk reference = ref chunks[num];
			if (!reference.IsAlive)
			{
				Log.Trace("Chunk update failed: Tried to remove a building for a chunk that is not alive", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			}
			else if (reference.Objects == null)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(94, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Chunk.Objects is null, this should not happen! Happened while removing an occlusion object at ");
					messageBuilder2.AppendFormatted(nodePosition);
				}
				Log.Error(messageBuilder2);
			}
			else
			{
				reference.Objects.Remove(occlusionObject);
				if (reference.Objects.Count == 0)
				{
					RemoveFromLinkedList(ref reference, bufferIndex);
					return;
				}
				RecalculateChunkBounds(ref reference);
				SetChunkVisible(ref reference, isVisible: true);
				SetBuffersDirty();
			}
		}

		public void RefreshChunk(IOcclusionObject occlusionObject)
		{
			if (isInitialized && !LoadingController.IsSceneTransition)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("RefreshChunk ");
					messageBuilder.AppendFormatted(occlusionObject);
				}
				Log.Trace(messageBuilder);
				int num = NodePositionToChunkIndex(occlusionObject.WorldPosition.ToGridVec3Int());
				ref OcclusionChunk reference = ref chunks[num];
				if (!reference.IsAlive)
				{
					Log.Trace("Chunk refresh failed: chunk is not alive", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
				}
				else if (reference.Objects != null)
				{
					RecalculateChunkBounds(ref reference);
					SetChunkVisible(ref reference, isVisible: true);
					SetBuffersDirty();
				}
			}
		}

		private void InitializeChunks()
		{
			Log.Trace("Initializing chunks...", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			foreach (CombinedLODGroup activeObject in CombinedLODGroup.ActiveObjects)
			{
				int num = NodePositionToChunkIndex(activeObject.WorldPosition.ToGridVec3Int());
				ref OcclusionChunk reference = ref chunks[num];
				if (!reference.IsAlive)
				{
					AddToLinkedList(ref reference, num, 0);
				}
				ref List<IOcclusionObject> objects = ref reference.Objects;
				if (objects == null)
				{
					objects = new List<IOcclusionObject>();
				}
				if (!reference.Objects.Contains(activeObject))
				{
					reference.Objects.Add(activeObject);
				}
			}
			foreach (BuildingType key in villageMap.BuildingsManagerMain.TypeInstanceView.Keys)
			{
				foreach (var (baseBuildingInstance2, item) in villageMap.BuildingsManagerMain.TypeInstanceView[key])
				{
					if (baseBuildingInstance2.Blueprint.OcclusionCullingMode != OcclusionCullingMode.Disabled)
					{
						int num2 = NodePositionToChunkIndex(baseBuildingInstance2.WorldPosition.ToGridVec3Int());
						ref OcclusionChunk reference2 = ref chunks[num2];
						if (!reference2.IsAlive)
						{
							AddToLinkedList(ref reference2, num2, 0);
						}
						ref List<IOcclusionObject> objects = ref reference2.Objects;
						if (objects == null)
						{
							objects = new List<IOcclusionObject>();
						}
						if (!reference2.Objects.Contains(item))
						{
							reference2.Objects.Add(item);
						}
					}
				}
			}
			foreach (var (resourcePileInstance2, resourcePileView2) in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				if (resourcePileInstance2 != null && !(resourcePileView2 == null))
				{
					int num3 = NodePositionToChunkIndex(resourcePileInstance2.GridDataPosition);
					ref OcclusionChunk reference3 = ref chunks[num3];
					if (!reference3.IsAlive)
					{
						AddToLinkedList(ref reference3, num3, 0);
					}
					HideResource hideResource = resourcePileView2.HideResource;
					ref List<IOcclusionObject> objects = ref reference3.Objects;
					if (objects == null)
					{
						objects = new List<IOcclusionObject>();
					}
					if (!reference3.Objects.Contains(hideResource))
					{
						reference3.Objects.Add(hideResource);
					}
				}
			}
			foreach (var (plantMapResourceInstance2, plantMapResourceView2) in MonoSingleton<PlantResourceManager>.Instance.InstanceView)
			{
				if (plantMapResourceInstance2 != null && !(plantMapResourceView2 == null) && plantMapResourceView2.OcclusionCullingMode != OcclusionCullingMode.Disabled)
				{
					int num4 = NodePositionToChunkIndex(plantMapResourceInstance2.GridDataPosition);
					ref OcclusionChunk reference4 = ref chunks[num4];
					if (!reference4.IsAlive)
					{
						AddToLinkedList(ref reference4, num4, 0);
					}
					ref List<IOcclusionObject> objects = ref reference4.Objects;
					if (objects == null)
					{
						objects = new List<IOcclusionObject>();
					}
					if (!reference4.Objects.Contains(plantMapResourceView2))
					{
						reference4.Objects.Add(plantMapResourceView2);
					}
				}
			}
			foreach (StockpileInstance stockpile in MonoSingleton<StockpileManager>.Instance.Stockpiles)
			{
				StockpileView stockpileView = stockpile?.GetView() as StockpileView;
				if (!(stockpileView == null) && stockpileView.OcclusionCullingMode != OcclusionCullingMode.Disabled)
				{
					int num5 = NodePositionToChunkIndex(stockpile.GridDataPosition);
					ref OcclusionChunk reference5 = ref chunks[num5];
					if (!reference5.IsAlive)
					{
						AddToLinkedList(ref reference5, num5, 0);
					}
					ref List<IOcclusionObject> objects = ref reference5.Objects;
					if (objects == null)
					{
						objects = new List<IOcclusionObject>();
					}
					if (!reference5.Objects.Contains(stockpileView))
					{
						reference5.Objects.Add(stockpileView);
					}
				}
			}
			foreach (CropfieldInstance cropfield in MonoSingleton<CropsManager>.Instance.Cropfields)
			{
				CropView cropView = cropfield?.GetView() as CropView;
				if (!(cropView == null) && cropView.OcclusionCullingMode != OcclusionCullingMode.Disabled)
				{
					int num6 = NodePositionToChunkIndex(cropfield.GridDataPosition);
					ref OcclusionChunk reference6 = ref chunks[num6];
					if (!reference6.IsAlive)
					{
						AddToLinkedList(ref reference6, num6, 0);
					}
					ref List<IOcclusionObject> objects = ref reference6.Objects;
					if (objects == null)
					{
						objects = new List<IOcclusionObject>();
					}
					if (!reference6.Objects.Contains(cropView))
					{
						reference6.Objects.Add(cropView);
					}
				}
			}
			int nextIndex = headChunkIndex;
			while (nextIndex != -1)
			{
				ref OcclusionChunk reference7 = ref chunks[nextIndex];
				RecalculateChunkBounds(ref reference7, updateTransformMatrix: false);
				SetChunkVisible(ref reference7, isVisible: true);
				nextIndex = reference7.NextIndex;
			}
			SetBuffersDirty();
			Log.Trace("Chunks initialized!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
		}

		private void OnRoofsVisibleChanged(bool isVisible)
		{
			foreach (RoofComponentInstance componentInstance in villageMap.RoofComponentManager.ComponentInstances)
			{
				RefreshChunk(componentInstance.OwnerBuilding.GetView() as BaseBuildingViewComponent);
			}
		}

		private void OnGameplayStart(bool _)
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(1f).Then(delegate
			{
				IsReadbackPaused = false;
			});
		}

		private void OnStockpilePlaced(StockpileInstance stockpile)
		{
			if (stockpile != null && !stockpile.HasDisposed)
			{
				RegisterObject(stockpile.GetView() as StockpileView);
			}
		}

		private void OnStockpileDestroyed(StockpileInstance stockpile)
		{
			if (stockpile != null)
			{
				UnregisterObject(stockpile.GetView() as StockpileView);
			}
		}

		private void OnCropfieldPlaced(CropfieldInstance cropfield)
		{
			if (cropfield != null)
			{
				RegisterObject(cropfield.GetView() as CropView);
			}
		}

		private void OnCropfieldDestroyed(CropfieldInstance cropfield)
		{
			if (cropfield != null)
			{
				UnregisterObject(cropfield.GetView() as CropView);
			}
		}

		private void OnFusedMeshBoundsChanged(CombinedLODGroup fusedMesh)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnFusedMeshBoundsChanged ");
				messageBuilder.AppendFormatted(fusedMesh);
			}
			Log.Trace(messageBuilder);
			int num = NodePositionToChunkIndex(fusedMesh.WorldPosition.ToGridVec3Int());
			ref OcclusionChunk chunk = ref chunks[num];
			RecalculateChunkBounds(ref chunk);
			SetChunkVisible(ref chunk, isVisible: true);
			EnsureBuffers();
			SetBuffersDirty();
		}

		private void Start()
		{
			lastUpdateTime = -1000f;
		}

		private void Update()
		{
			if (!isInitialized || activeChunkCount == 0 || Time.unscaledTime - lastUpdateTime < 1f / 30f)
			{
				return;
			}
			lastUpdateTime = Time.unscaledTime;
			if (isBufferDirty[bufferIndex])
			{
				isBufferDirty[bufferIndex] = false;
				WriteAllChunksToBuffers(bufferIndex);
			}
			hiZShader.SetInt(ScreenWidthId, Screen.width);
			hiZShader.SetInt(ScreenHeightId, Screen.height);
			hiZShader.SetVector(ZBufferParamsId, Shader.GetGlobalVector(ZBufferParamsId));
			hiZShader.SetFloat(FarPlaneId, mainCamera.farClipPlane);
			hiZShader.SetFloat(NearPlaneId, mainCamera.nearClipPlane);
			commandBuffer.Clear();
			commandBuffer.SetViewMatrix(mainCamera.worldToCameraMatrix);
			commandBuffer.SetProjectionMatrix(mainCamera.projectionMatrix);
			commandBuffer.SetRenderTarget(occluderDepthRenderTexture);
			commandBuffer.SetViewport(new Rect(0f, 0f, 1024f, 512f));
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commandBuffer.DrawMeshInstanced(cubeMesh, 0, occluderDepthMaterial, -1, chunkOccluderBoxMatrices, activeChunkCount);
			MapChunk[,] array = MonoSingleton<World>.Instance.ChunkGenerator.Chunks;
			foreach (MapChunk mapChunk in array)
			{
				commandBuffer.DrawRenderer(mapChunk.TopRenderer, occluderDepthMaterial);
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
			hiZShader.SetTexture(depthCopyKernelId, InputDepthTexturePropId, occluderDepthRenderTexture);
			hiZShader.SetTexture(depthCopyKernelId, ResultPropId, hiZTexture);
			hiZShader.Dispatch(depthCopyKernelId, 128, 64, 1);
			for (int k = 1; k < occluderDepthRenderTexture.mipmapCount; k++)
			{
				int num = Mathf.Max(1, hiZTexture.width >> k);
				int num2 = Mathf.Max(1, hiZTexture.height >> k);
				int threadGroupsX = Mathf.CeilToInt((float)num / 8f);
				int threadGroupsY = Mathf.CeilToInt((float)num2 / 8f);
				hiZShader.SetTexture(downSampleKernelId, InputMipTexturePropId, hiZTexture, k - 1);
				hiZShader.SetTexture(downSampleKernelId, ResultPropId, hiZTexture, k);
				hiZShader.Dispatch(downSampleKernelId, threadGroupsX, threadGroupsY, 1);
			}
			hiZShader.SetTexture(cullKernelId, HiZTextureId, hiZTexture);
			hiZShader.SetBuffer(cullKernelId, BoxesCenterId, boxesOccludeeCenterBuffers[bufferIndex]);
			hiZShader.SetBuffer(cullKernelId, BoxesExtentsId, boxesOccludeeExtentsBuffers[bufferIndex]);
			hiZShader.SetMatrix(ViewMatrixId, mainCamera.worldToCameraMatrix);
			hiZShader.SetMatrix(ProjectionMatrixId, GL.GetGPUProjectionMatrix(mainCamera.projectionMatrix, renderIntoTexture: true));
			hiZShader.SetBuffer(cullKernelId, BoxesVisibleId, isChunkVisibleBuffers[bufferIndex]);
			hiZShader.SetFloat(WorldLayerId, MonoSingleton<World>.Instance.LayerLevel);
			hiZShader.SetInt("_InputDataVersion", activeChunkListVersion);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Dispatch for ");
				messageBuilder.AppendFormatted(Time.frameCount);
				messageBuilder.AppendLiteral(", buffer index ");
				messageBuilder.AppendFormatted(bufferIndex);
			}
			Log.Trace(messageBuilder);
			hiZShader.Dispatch(cullKernelId, Mathf.CeilToInt((float)activeChunkCount / 64f), 1, 1);
			AsyncGPUReadback.Request(isChunkVisibleBuffers[bufferIndex], OnIsVisibleBufferRead);
			bufferIndex = (bufferIndex + 1) % 3;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			chunks = null;
			mainCamera = null;
			commandBuffer?.Release();
			commandBuffer = null;
			cubeMeshVertices?.Release();
			cubeMeshVertices = null;
			cubeMeshTriangles?.Release();
			cubeMeshTriangles = null;
			occluderDepthRenderTexture?.Release();
			occluderDepthRenderTexture = null;
			hiZTexture?.Release();
			hiZTexture = null;
			for (int i = 0; i < 3; i++)
			{
				boxesOccludeeCenterBuffers[i]?.Release();
				boxesOccludeeCenterBuffers[i] = null;
				boxesOccludeeExtentsBuffers[i]?.Release();
				boxesOccludeeExtentsBuffers[i] = null;
				isChunkVisibleBuffers[i]?.Release();
				isChunkVisibleBuffers[i] = null;
			}
			boxesOccludeeCenterBuffers = null;
			boxesOccludeeExtentsBuffers = null;
			isChunkVisibleBuffers = null;
			isBufferDirty = null;
			CombinedLODGroup.ObjectActivated -= RegisterObject;
			CombinedLODGroup.ObjectDeactivated -= UnregisterObject;
			CombinedLODGroup.BoundsChanged -= OnFusedMeshBoundsChanged;
			if (MonoSingleton<StockpileController>.IsInstantiated())
			{
				MonoSingleton<StockpileController>.Instance.StockpilePlacedEvent -= OnStockpilePlaced;
				MonoSingleton<StockpileController>.Instance.StockpileDestroyedEvent -= OnStockpileDestroyed;
			}
			if (MonoSingleton<CropsController>.IsInstantiated())
			{
				MonoSingleton<CropsController>.Instance.CropfieldPlacedEvent -= OnCropfieldPlaced;
				MonoSingleton<CropsController>.Instance.CropfieldDestroyedEvent -= OnCropfieldDestroyed;
			}
			if (villageMap?.RoofComponentManager != null)
			{
				villageMap.RoofComponentManager.SetRoofsVisibleEvent -= OnRoofsVisibleChanged;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			}
			villageMap = null;
			isInitialized = false;
		}

		private void OnIsVisibleBufferRead(AsyncGPUReadbackRequest request)
		{
			if (IsReadbackPaused || chunks == null || activeChunkCount == 0)
			{
				return;
			}
			if (request.hasError)
			{
				Log.Error("GPU readback error!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
				return;
			}
			NativeArray<int> data = request.GetData<int>();
			int num = data[0];
			if (activeChunkListVersion != num)
			{
				return;
			}
			int length = data.Length;
			int nextIndex = headChunkIndex;
			int num2 = 1;
			while (num2 < length + 1 && nextIndex != -1)
			{
				ref OcclusionChunk reference = ref chunks[nextIndex];
				bool flag = data[num2] == 1;
				if (reference.IsVisible != flag)
				{
					SetChunkVisible(ref reference, flag);
				}
				num2++;
				nextIndex = reference.NextIndex;
			}
		}

		[BurstCompile]
		private static int NodePositionToChunkIndex(in Vec3Int nodePosition)
		{
			Vec3Int vec3Int = nodePosition / ChunkSize;
			return vec3Int.z * chunkWorldSize.x * chunkWorldSize.y + vec3Int.y * chunkWorldSize.x + vec3Int.x;
		}

		private void WriteAllChunksToBuffers(int bufferIndex)
		{
			Log.Trace("Write all chunks to buffers", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			EnsureBuffers();
			int num = activeChunkCount;
			hiZShader.SetInt(ObjectCountId, num);
			if (num != 0)
			{
				NativeArray<float3> nativeArray = boxesOccludeeCenterBuffers[bufferIndex].BeginWrite<float3>(0, num);
				NativeArray<float3> nativeArray2 = boxesOccludeeExtentsBuffers[bufferIndex].BeginWrite<float3>(0, num);
				int nextIndex = headChunkIndex;
				int num2 = 0;
				while (nextIndex != -1)
				{
					ref OcclusionChunk reference = ref chunks[nextIndex];
					Bounds bounds = reference.Bounds;
					nativeArray[num2] = bounds.center;
					nativeArray2[num2] = bounds.extents;
					Bounds occluderBounds = reference.OccluderBounds;
					chunkOccluderBoxMatrices[num2] = Matrix4x4.Translate(occluderBounds.center) * Matrix4x4.Scale(occluderBounds.size);
					nextIndex = reference.NextIndex;
					num2++;
				}
				boxesOccludeeCenterBuffers[bufferIndex].EndWrite<float3>(num);
				boxesOccludeeExtentsBuffers[bufferIndex].EndWrite<float3>(num);
			}
		}

		private void AddToLinkedList(ref OcclusionChunk newChunk, int newChunkIndex, int bufferIndex)
		{
			Log.Trace("Adding new chunk to linked list", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			if (activeChunkCount == 0)
			{
				newChunk.PreviousIndex = -1;
				newChunk.NextIndex = -1;
				headChunkIndex = newChunkIndex;
			}
			else
			{
				chunks[tailChunkIndex].NextIndex = newChunkIndex;
				newChunk.PreviousIndex = tailChunkIndex;
				newChunk.NextIndex = -1;
			}
			tailChunkIndex = newChunkIndex;
			activeChunkCount++;
			hiZShader.SetInt(ObjectCountId, activeChunkCount);
			EnsureBuffers();
			activeChunkListVersion++;
		}

		private void RemoveFromLinkedList(ref OcclusionChunk chunk, int bufferIndex)
		{
			Log.Trace("Removing chunk from linked list", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
			if (chunk.PreviousIndex == -1)
			{
				headChunkIndex = chunk.NextIndex;
			}
			else
			{
				chunks[chunk.PreviousIndex].NextIndex = chunk.NextIndex;
			}
			if (chunk.NextIndex == -1)
			{
				tailChunkIndex = chunk.PreviousIndex;
			}
			else
			{
				chunks[chunk.NextIndex].PreviousIndex = chunk.PreviousIndex;
			}
			activeChunkCount--;
			hiZShader.SetInt(ObjectCountId, activeChunkCount);
			chunk.Reset();
			SetBuffersDirty();
			activeChunkListVersion++;
		}

		private void EnsureBuffers()
		{
			if (boxesOccludeeCenterBuffers == null)
			{
				boxesOccludeeCenterBuffers = new ComputeBuffer[3];
			}
			if (boxesOccludeeExtentsBuffers == null)
			{
				boxesOccludeeExtentsBuffers = new ComputeBuffer[3];
			}
			if (isChunkVisibleBuffers == null)
			{
				isChunkVisibleBuffers = new ComputeBuffer[3];
			}
			for (int i = 0; i < 3; i++)
			{
				if (boxesOccludeeCenterBuffers[i] == null || boxesOccludeeCenterBuffers[i].count < activeChunkCount)
				{
					int val = FoxyMath.NextPowerOfTwo(activeChunkCount);
					val = Math.Max(val, 256);
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\OcclusionCulling\\OcclusionCullingManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Resizing buffers at index ");
						messageBuilder.AppendFormatted(i);
						messageBuilder.AppendLiteral(" to ");
						messageBuilder.AppendFormatted(val);
					}
					Log.Trace(messageBuilder);
					bool num = boxesOccludeeCenterBuffers[i] != null;
					boxesOccludeeCenterBuffers[i]?.Release();
					boxesOccludeeExtentsBuffers[i]?.Release();
					isChunkVisibleBuffers[i]?.Release();
					boxesOccludeeCenterBuffers[i] = new ComputeBuffer(val, 12, ComputeBufferType.Structured, ComputeBufferMode.SubUpdates);
					boxesOccludeeExtentsBuffers[i] = new ComputeBuffer(val, 12, ComputeBufferType.Structured, ComputeBufferMode.SubUpdates);
					isChunkVisibleBuffers[i] = new ComputeBuffer(val + 1, 4, ComputeBufferType.Structured);
					if (chunkOccluderBoxMatrices == null)
					{
						chunkOccluderBoxMatrices = new Matrix4x4[val];
					}
					else
					{
						Array.Resize(ref chunkOccluderBoxMatrices, val);
					}
					if (num)
					{
						SetBuffersDirty();
					}
				}
			}
		}

		private void RecalculateChunkBounds(ref OcclusionChunk chunk, bool updateTransformMatrix = true)
		{
			int count = chunk.Objects.Count;
			if (count == 0)
			{
				chunk.OccluderBounds = default(Bounds);
				chunk.Bounds = default(Bounds);
				return;
			}
			chunk.Bounds = default(Bounds);
			chunk.OccluderBounds = default(Bounds);
			for (int i = 0; i < count; i++)
			{
				IOcclusionObject occlusionObject = chunk.Objects[i];
				if (occlusionObject == null)
				{
					continue;
				}
				Bounds occlusionLocalSpaceBoundingBox = occlusionObject.OcclusionLocalSpaceBoundingBox;
				occlusionLocalSpaceBoundingBox.center += occlusionObject.WorldPosition;
				if (chunk.Bounds == default(Bounds))
				{
					chunk.Bounds = occlusionLocalSpaceBoundingBox;
				}
				else
				{
					chunk.Bounds.Encapsulate(occlusionLocalSpaceBoundingBox);
				}
				if (occlusionObject.OcclusionCullingMode == OcclusionCullingMode.Enabled)
				{
					if (chunk.OccluderBounds == default(Bounds))
					{
						chunk.OccluderBounds = occlusionLocalSpaceBoundingBox;
					}
					else
					{
						chunk.OccluderBounds.Encapsulate(occlusionLocalSpaceBoundingBox);
					}
				}
			}
			if (!updateTransformMatrix)
			{
				return;
			}
			int nextIndex = headChunkIndex;
			int num = 0;
			while (nextIndex != -1)
			{
				ref OcclusionChunk reference = ref chunks[nextIndex];
				if (reference.OccluderBounds.center == chunk.OccluderBounds.center && reference.PreviousIndex == chunk.PreviousIndex && reference.NextIndex == chunk.NextIndex)
				{
					Bounds occluderBounds = chunk.OccluderBounds;
					chunkOccluderBoxMatrices[num] = Matrix4x4.Translate(occluderBounds.center) * Matrix4x4.Scale(occluderBounds.size);
					break;
				}
				nextIndex = reference.NextIndex;
				num++;
			}
		}

		private static void SetChunkVisible(ref OcclusionChunk chunk, bool isVisible)
		{
			if (isVisible)
			{
				chunk.ConsecutiveInvisibleFramesLeft = 15;
			}
			else
			{
				chunk.ConsecutiveInvisibleFramesLeft = Math.Max(0, chunk.ConsecutiveInvisibleFramesLeft - 1);
			}
			if (chunk.IsVisible != isVisible && (isVisible || chunk.ConsecutiveInvisibleFramesLeft <= 0) && chunk.IsVisible != isVisible)
			{
				chunk.IsVisible = isVisible;
				for (int i = 0; i < chunk.Objects.Count; i++)
				{
					chunk.Objects[i].IsOcclusionCulled = !isVisible;
				}
			}
		}

		private void CreateHiZTextures()
		{
			if (!(occluderDepthRenderTexture != null))
			{
				if (occluderDepthRenderTexture != null)
				{
					occluderDepthRenderTexture.Release();
					occluderDepthRenderTexture = null;
				}
				if (hiZTexture != null)
				{
					hiZTexture.Release();
					hiZTexture = null;
				}
				occluderDepthRenderTexture = new RenderTexture(1024, 512, 32, RenderTextureFormat.Depth, RenderTextureReadWrite.Linear)
				{
					useMipMap = true,
					autoGenerateMips = false,
					filterMode = FilterMode.Point,
					wrapMode = TextureWrapMode.Clamp
				};
				occluderDepthRenderTexture.Create();
				hiZTexture = new RenderTexture(1024, 512, 32, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear)
				{
					enableRandomWrite = true,
					useMipMap = true,
					autoGenerateMips = false,
					filterMode = FilterMode.Point,
					wrapMode = TextureWrapMode.Clamp
				};
				hiZTexture.Create();
			}
		}
	}
}
