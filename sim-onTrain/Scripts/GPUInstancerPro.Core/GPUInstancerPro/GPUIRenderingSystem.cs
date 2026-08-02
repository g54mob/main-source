using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(1000)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Debugger_Window")]
	public sealed class GPUIRenderingSystem : MonoBehaviour, IGPUIDisposable, IDisposable
	{
		[NonSerialized]
		private RenderParams _renderParams;

		[NonSerialized]
		private Bounds _worldBounds;

		[NonSerialized]
		private List<IGPUIDisposable> _dependentDisposables;

		[NonSerialized]
		private int _lastDrawCallFrame;

		[NonSerialized]
		private float _lastDrawCallTime;

		private static MaterialPropertyBlock _emptyMPB;

		public static GPUIRenderingSystem Instance { get; private set; }

		public static bool IsActive
		{
			get
			{
				if (Instance != null)
				{
					return Instance.IsInitialized;
				}
				return false;
			}
		}

		public bool IsInitialized { get; private set; }

		public GPUIMaterialProvider MaterialProvider { get; private set; }

		public GPUILODGroupDataProvider LODGroupDataProvider { get; private set; }

		public GPUIRenderSourceGroupProvider RenderSourceGroupProvider { get; private set; }

		public GPUIRenderSourceProvider RenderSourceProvider { get; private set; }

		public GPUICameraDataProvider CameraDataProvider { get; private set; }

		public GPUITreeProxyProvider TreeProxyProvider { get; private set; }

		public GPUIDataBuffer<float> ParameterBuffer { get; private set; }

		public Dictionary<IGPUIParameterBufferData, int> ParameterBufferIndexes { get; private set; }

		public List<GPUIManager> ActiveGPUIManagers { get; private set; }

		public float TimeSinceLastDrawCall { get; private set; }

		public bool IsPaused { get; private set; }

		public UnityEvent OnCommandBufferModified { get; private set; }

		public GPUICameraEvent OnPreCull { get; private set; }

		public GPUICameraEvent OnPreRender { get; private set; }

		public GPUICameraEvent OnPostRender { get; private set; }

		public static MaterialPropertyBlock EmptyMPB
		{
			get
			{
				if (_emptyMPB == null)
				{
					_emptyMPB = new MaterialPropertyBlock();
				}
				return _emptyMPB;
			}
		}

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				DestroyInstance();
			}
			else if (Instance == null)
			{
				Instance = this;
				Initialize();
			}
		}

		private void OnEnable()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			if (CheckIsSingleton())
			{
				Initialize();
				UpdateCommandBuffers();
			}
		}

		private void OnDisable()
		{
			Dispose();
		}

		private static void CameraOnPreCull(Camera camera)
		{
			if (Instance.RenderSourceGroupProvider.Count != 0)
			{
				ProcessCamera(camera);
			}
		}

		private static void CameraOnPostRender(Camera camera)
		{
			if (Instance.CameraDataProvider.TryGetData(camera.GetInstanceID(), out var result))
			{
				result.UpdateHiZTexture(default(ScriptableRenderContext));
			}
		}

		private static void CameraOnBeginRendering(ScriptableRenderContext context, Camera camera)
		{
			CameraOnPreCull(camera);
		}

		private static void CameraOnEndRendering(ScriptableRenderContext context, Camera camera)
		{
			if (Instance.CameraDataProvider.TryGetData(camera.GetInstanceID(), out var result))
			{
				result.UpdateHiZTexture(context);
			}
		}

		private void OnEndContextRendering(ScriptableRenderContext context, List<Camera> list)
		{
			int frameCount = Time.frameCount;
			foreach (GPUIRenderSourceGroup value in RenderSourceGroupProvider.Values)
			{
				value.UpdateTransformBufferData(frameCount);
			}
		}

		private static void ProcessCamera(Camera camera)
		{
			Instance.ParameterBuffer.UpdateBufferData();
			CameraType cameraType = camera.cameraType;
			GPUICameraDataProvider cameraDataProvider = Instance.CameraDataProvider;
			if (cameraDataProvider.Count == 0)
			{
				cameraDataProvider.RegisterDefaultCamera();
			}
			GPUICameraData result;
			bool flag = cameraDataProvider.TryGetData(camera.GetInstanceID(), out result);
			if (!flag && cameraType == CameraType.Reflection)
			{
				result = new GPUICameraData(camera);
				cameraDataProvider.AddCameraData(result);
				flag = true;
				Instance.UpdateCommandBuffers(result);
			}
			if (!flag)
			{
				return;
			}
			int frameCount = Time.frameCount;
			if (result._lastUpdateFrame != frameCount)
			{
				if (result._lastUpdateFrame != frameCount)
				{
					Instance.OnPreCull?.Invoke(result);
					result.UpdateCameraData();
					result._lastUpdateFrame = frameCount;
				}
				ProcessCameraData(camera, result, invokeEvents: true);
			}
		}

		private static void ProcessCameraData(Camera camera, GPUICameraData cameraData, bool invokeEvents)
		{
			if (cameraData._commandBuffer.Buffer != null)
			{
				if (invokeEvents)
				{
					Instance.OnPreRender?.Invoke(cameraData);
				}
				Instance._renderParams.camera = camera;
				Instance.MakeDrawCalls(cameraData);
				if (invokeEvents)
				{
					Instance.OnPostRender?.Invoke(cameraData);
				}
			}
		}

		private void MakeDrawCalls(GPUICameraData cameraData)
		{
			if (cameraData.ActiveCamera == null)
			{
				return;
			}
			if (_lastDrawCallFrame != Time.frameCount)
			{
				_lastDrawCallFrame = Time.frameCount;
				TimeSinceLastDrawCall = Time.realtimeSinceStartup - _lastDrawCallTime;
				_lastDrawCallTime = Time.realtimeSinceStartup;
			}
			_worldBounds.center = cameraData.GetCameraPosition();
			_worldBounds.size = GPUIRuntimeSettings.Instance.instancingBoundsSize;
			_renderParams.worldBounds = _worldBounds;
			int cullingMask = cameraData.ActiveCamera.cullingMask;
			int maximumLODLevel = QualitySettings.maximumLODLevel;
			foreach (GPUIRenderSourceGroup value in RenderSourceGroupProvider.Values)
			{
				GPUILODGroupData lODGroupData = value.LODGroupData;
				if (value.BufferSize <= 0 || value.InstanceCount <= 0 || !(lODGroupData != null) || !cameraData.TryGetVisibilityBufferIndex(value, out var visibilityBufferIndex))
				{
					continue;
				}
				MaterialPropertyBlock materialPropertyBlock = value.GetMaterialPropertyBlock(lODGroupData, cameraData);
				value.ApplyMaterialPropertyOverrides(materialPropertyBlock, -1, -1);
				value.TransformBufferData.SetMPBBuffers(materialPropertyBlock, cameraData);
				_renderParams.matProps = materialPropertyBlock;
				int num = (int)cameraData._visibilityBuffer[visibilityBufferIndex].commandStartIndex;
				int length = lODGroupData.Length;
				int maximumLODLevel2 = GetMaximumLODLevel(length, value.Profile.maximumLODLevel, maximumLODLevel);
				_renderParams.shadowCastingMode = ShadowCastingMode.Off;
				for (int i = 0; i < length; i++)
				{
					materialPropertyBlock.SetInt(GPUIConstants.PROP_instanceDataBufferShift, value.BufferSize * i);
					value.ApplyMaterialPropertyOverrides(materialPropertyBlock, i, -1);
					GPUILODData gPUILODData = lODGroupData[i];
					for (int j = 0; j < gPUILODData.Length; j++)
					{
						GPUIRendererData gPUIRendererData = gPUILODData[j];
						Mesh mesh = gPUIRendererData.GetMesh();
						if (mesh != null && GPUIUtility.IsInLayer(cullingMask, gPUIRendererData.layer) && !gPUIRendererData.IsShadowsOnly && i >= maximumLODLevel2)
						{
							_renderParams.receiveShadows = gPUIRendererData.receiveShadows;
							value.ApplyMaterialPropertyOverrides(materialPropertyBlock, i, j);
							materialPropertyBlock.SetMatrix(GPUIConstants.PROP_gpuiTransformOffset, gPUIRendererData.transformOffset);
							_renderParams.layer = gPUIRendererData.layer;
							if (gPUIRendererData.motionVectorGenerationMode == MotionVectorGenerationMode.Object && !value.TransformBufferData.HasPreviousFrameTransformBuffer)
							{
								_renderParams.motionVectorMode = MotionVectorGenerationMode.Camera;
							}
							else
							{
								_renderParams.motionVectorMode = gPUIRendererData.motionVectorGenerationMode;
							}
							_renderParams.renderingLayerMask = gPUIRendererData.renderingLayerMask;
							if (Application.isPlaying && gPUIRendererData.replacementMaterials == null)
							{
								gPUIRendererData.InitializeReplacementMaterials(MaterialProvider);
							}
							for (int k = 0; k < gPUIRendererData.rendererMaterials.Length; k++)
							{
								_renderParams.material = GetReplacementMaterial(gPUIRendererData, k, value.ShaderKeywords);
								GPUIUtility.RenderMeshIndirect(in _renderParams, mesh, cameraData._commandBuffer, 1, num);
								num++;
							}
						}
						else
						{
							num += gPUIRendererData.rendererMaterials.Length;
						}
					}
				}
				if (!value.Profile.isShadowCasting)
				{
					continue;
				}
				_renderParams.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
				for (int l = 0; l < length; l++)
				{
					materialPropertyBlock.SetInt(GPUIConstants.PROP_instanceDataBufferShift, value.BufferSize * (l + length));
					GPUILODData gPUILODData2 = lODGroupData[l];
					for (int m = 0; m < gPUILODData2.Length; m++)
					{
						GPUIRendererData gPUIRendererData2 = gPUILODData2[m];
						Mesh mesh2 = gPUIRendererData2.GetMesh();
						if (mesh2 != null && GPUIUtility.IsInLayer(cullingMask, gPUIRendererData2.layer) && gPUIRendererData2.IsShadowCasting && l >= maximumLODLevel2)
						{
							_renderParams.receiveShadows = gPUIRendererData2.receiveShadows;
							materialPropertyBlock.SetMatrix(GPUIConstants.PROP_gpuiTransformOffset, gPUIRendererData2.transformOffset);
							_renderParams.layer = gPUIRendererData2.layer;
							if (Application.isPlaying && gPUIRendererData2.replacementMaterials == null)
							{
								gPUIRendererData2.InitializeReplacementMaterials(MaterialProvider);
							}
							for (int n = 0; n < gPUIRendererData2.rendererMaterials.Length; n++)
							{
								_renderParams.material = GetReplacementMaterial(gPUIRendererData2, n, value.ShaderKeywords);
								GPUIUtility.RenderMeshIndirect(in _renderParams, mesh2, cameraData._commandBuffer, 1, num);
								num++;
							}
						}
						else
						{
							num += gPUIRendererData2.rendererMaterials.Length;
						}
					}
				}
			}
		}

		private int GetMaximumLODLevel(int lodCount, int profileMaximumLODLevel, int qualityMaximumLODLevel)
		{
			if (lodCount <= 1)
			{
				return 0;
			}
			return Mathf.Max(profileMaximumLODLevel, qualityMaximumLODLevel);
		}

		private Material GetReplacementMaterial(GPUIRendererData renderer, int materialIndex, List<string> keywords)
		{
			Material replacementMat = null;
			if (Application.isPlaying)
			{
				replacementMat = renderer.replacementMaterials[materialIndex];
			}
			if (replacementMat == null && MaterialProvider.TryGetReplacementMaterial(renderer.rendererMaterials[materialIndex], keywords, renderer.isSkinnedMesh ? "CROWD" : null, out replacementMat) && Application.isPlaying)
			{
				renderer.replacementMaterials[materialIndex] = replacementMat;
			}
			return replacementMat;
		}

		private bool CheckIsSingleton()
		{
			if (Instance == null)
			{
				DestroyInstance();
				return false;
			}
			if (Instance != this)
			{
				DestroyInstance();
				return false;
			}
			return true;
		}

		private void Initialize()
		{
			if (!GPUIRuntimeSettings.Instance.IsSupportedPlatform())
			{
				DestroyInstance();
			}
			else
			{
				if (IsInitialized)
				{
					return;
				}
				IsInitialized = true;
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
				MaterialProvider = new GPUIMaterialProvider();
				MaterialProvider.Initialize();
				LODGroupDataProvider = new GPUILODGroupDataProvider();
				LODGroupDataProvider.Initialize();
				RenderSourceGroupProvider = new GPUIRenderSourceGroupProvider();
				RenderSourceGroupProvider.Initialize();
				RenderSourceProvider = new GPUIRenderSourceProvider();
				RenderSourceProvider.Initialize();
				CameraDataProvider = new GPUICameraDataProvider();
				CameraDataProvider.Initialize();
				TreeProxyProvider = new GPUITreeProxyProvider();
				TreeProxyProvider.Initialize();
				ParameterBuffer = new GPUIDataBuffer<float>("Parameter");
				ParameterBufferIndexes = new Dictionary<IGPUIParameterBufferData, int>();
				ActiveGPUIManagers = new List<GPUIManager>();
				_renderParams = new RenderParams(GPUIShaderBindings.Instance.ErrorMaterial);
				_worldBounds = new Bounds(Vector3.zero, GPUIRuntimeSettings.Instance.instancingBoundsSize);
				_dependentDisposables = new List<IGPUIDisposable>();
				OnCommandBufferModified = new UnityEvent();
				OnPreCull = new GPUICameraEvent();
				OnPreRender = new GPUICameraEvent();
				OnPostRender = new GPUICameraEvent();
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(CameraOnPreCull));
				RenderPipelineManager.beginCameraRendering -= CameraOnBeginRendering;
				if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
				{
					Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(CameraOnPreCull));
				}
				else
				{
					RenderPipelineManager.beginCameraRendering += CameraOnBeginRendering;
				}
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(CameraOnPostRender));
				RenderPipelineManager.endCameraRendering -= CameraOnEndRendering;
				if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
				{
					Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(CameraOnPostRender));
					return;
				}
				RenderPipelineManager.endCameraRendering += CameraOnEndRendering;
				if (GPUIRuntimeSettings.Instance.IsHDRP)
				{
					RenderPipelineManager.endContextRendering += OnEndContextRendering;
				}
			}
		}

		public static bool SetGlobalWindVector()
		{
			WindZone[] array = UnityEngine.Object.FindObjectsByType<WindZone>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].mode == WindZoneMode.Directional)
				{
					Shader.SetGlobalVector("_Wind", new Vector4(array[i].windTurbulence, array[i].windPulseMagnitude, array[i].windPulseFrequency, array[i].windMain));
					return true;
				}
			}
			return false;
		}

		public void Dispose()
		{
			IsInitialized = false;
			if (MaterialProvider != null)
			{
				MaterialProvider.Dispose();
				MaterialProvider = null;
			}
			if (LODGroupDataProvider != null)
			{
				LODGroupDataProvider.Dispose();
				LODGroupDataProvider = null;
			}
			if (RenderSourceGroupProvider != null)
			{
				RenderSourceGroupProvider.Dispose();
				RenderSourceGroupProvider = null;
			}
			if (RenderSourceProvider != null)
			{
				RenderSourceProvider.Dispose();
				RenderSourceProvider = null;
			}
			if (CameraDataProvider != null)
			{
				CameraDataProvider.Dispose();
				CameraDataProvider = null;
			}
			if (TreeProxyProvider != null)
			{
				TreeProxyProvider.Dispose();
				TreeProxyProvider = null;
			}
			if (ParameterBuffer != null)
			{
				ParameterBuffer.Dispose();
				ParameterBuffer = null;
			}
			if (_dependentDisposables != null)
			{
				foreach (IGPUIDisposable dependentDisposable in _dependentDisposables)
				{
					dependentDisposable.Dispose();
				}
				_dependentDisposables = null;
			}
			ParameterBufferIndexes = null;
			ActiveGPUIManagers = null;
			if (!IsActive)
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(CameraOnPreCull));
				RenderPipelineManager.beginCameraRendering -= CameraOnBeginRendering;
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(CameraOnPostRender));
				RenderPipelineManager.endCameraRendering -= CameraOnEndRendering;
				RenderPipelineManager.endContextRendering -= OnEndContextRendering;
			}
		}

		public void ReleaseBuffers()
		{
			if (CameraDataProvider != null)
			{
				CameraDataProvider.ReleaseBuffers();
			}
			if (ParameterBuffer != null)
			{
				ParameterBuffer.ReleaseBuffers();
			}
		}

		private void DestroyInstance()
		{
			base.gameObject.DestroyGeneric();
		}

		public static void ResetRenderingSystem()
		{
			if (Instance != null)
			{
				Instance.DestroyInstance();
			}
			InitializeRenderingSystem();
		}

		public static void RegenerateRenderers()
		{
			if (Instance != null)
			{
				Instance.LODGroupDataProvider.RegenerateLODGroups();
				Instance.UpdateCommandBuffers(forceNew: true);
				Instance.UpdateParameterBufferData();
				Instance.MaterialProvider.Reset();
			}
		}

		public static void InitializeRenderingSystem()
		{
			if (IsActive)
			{
				return;
			}
			if (Instance == null)
			{
				GameObject gameObject = new GameObject();
				Instance = gameObject.AddComponent<GPUIRenderingSystem>();
				if (Instance == null)
				{
					return;
				}
				gameObject.name = "===GPUI Rendering System [" + Instance.GetInstanceID() + "]===";
				gameObject.hideFlags = HideFlags.HideAndDontSave;
			}
			Instance.Initialize();
		}

		public static void AddActiveManager(GPUIManager manager)
		{
			InitializeRenderingSystem();
			if (!Instance.ActiveGPUIManagers.Contains(manager))
			{
				Instance.ActiveGPUIManagers.Add(manager);
			}
		}

		public static void RemoveActiveManager(GPUIManager manager)
		{
			if (Instance != null && Instance.IsInitialized)
			{
				Instance.ActiveGPUIManagers.Remove(manager);
			}
		}

		public static bool RegisterRenderer(UnityEngine.Object source, GameObject prefab, out int rendererKey, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			return RegisterRenderer(source, prefab, GPUIProfile.DefaultProfile, out rendererKey, groupID, transformBufferType, shaderKeywords);
		}

		public static bool RegisterRenderer(UnityEngine.Object source, GameObject prefab, GPUIProfile profile, out int rendererKey, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			GPUIPrototype prototype = new GPUIPrototype(prefab, profile);
			return RegisterRenderer(source, prototype, out rendererKey, groupID, transformBufferType, shaderKeywords);
		}

		public static bool RegisterRenderer(UnityEngine.Object source, GPUIPrototype prototype, out int rendererKey, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			InitializeRenderingSystem();
			return RegisterRenderer(source, prototype.GetKey(), Instance.LODGroupDataProvider.GetOrCreateLODGroupData(prototype), prototype.profile, out rendererKey, groupID, transformBufferType, shaderKeywords);
		}

		public static bool RegisterRenderer(UnityEngine.Object source, int prototypeKey, GPUILODGroupData lodGroupData, GPUIProfile profile, out int rendererKey, int groupID, GPUITransformBufferType transformBufferType, List<string> shaderKeywords)
		{
			InitializeRenderingSystem();
			rendererKey = 0;
			if (source == null)
			{
				Debug.LogError("Source is null!");
				return false;
			}
			if (lodGroupData == null)
			{
				Debug.LogError("LODGroupData is null!", source);
				return false;
			}
			if (profile == null)
			{
				Debug.LogError("Profile is null!", source);
				return false;
			}
			if (profile.isLODCrossFade && (shaderKeywords == null || !shaderKeywords.Contains("LOD_FADE_CROSSFADE")))
			{
				if (shaderKeywords == null)
				{
					shaderKeywords = new List<string>();
				}
				shaderKeywords.Add("LOD_FADE_CROSSFADE");
			}
			GPUIRenderSourceGroup orCreateRenderSourceGroup = Instance.RenderSourceGroupProvider.GetOrCreateRenderSourceGroup(prototypeKey, lodGroupData, profile, groupID, transformBufferType, shaderKeywords);
			GPUIRenderSource gPUIRenderSource = new GPUIRenderSource(source, orCreateRenderSourceGroup);
			rendererKey = gPUIRenderSource.Key;
			if (orCreateRenderSourceGroup.AddRenderSource(source, gPUIRenderSource))
			{
				return Instance.RenderSourceProvider.AddOrSet(rendererKey, gPUIRenderSource);
			}
			return false;
		}

		public static int GetBufferSize(int renderKey)
		{
			if (IsActive && Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				return result.bufferSize;
			}
			return 0;
		}

		public static bool SetBufferSize(int renderKey, int bufferSize, bool isCopyPreviousData = true)
		{
			if (bufferSize < 0)
			{
				Debug.LogError("Buffer size is not set for renderer with key: " + renderKey);
				return false;
			}
			if (bufferSize > GPUIConstants.MAX_BUFFER_SIZE)
			{
				Debug.LogError(bufferSize.ToString("#,0") + " exceeds maximum allowed buffer size (" + GPUIConstants.MAX_BUFFER_SIZE.ToString("#,0") + ").");
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetBufferSize(bufferSize, isCopyPreviousData);
				return true;
			}
			Debug.LogError("Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static int GetInstanceCount(int renderKey)
		{
			if (IsActive && Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				return result.instanceCount;
			}
			return 0;
		}

		public static bool SetInstanceCount(int renderKey, int instanceCount)
		{
			if (instanceCount < 0)
			{
				Debug.LogError("Instance Count is not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetInstanceCount(instanceCount);
				return true;
			}
			Debug.LogError("Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : struct
		{
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError("Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : struct
		{
			if (matrices == null)
			{
				Debug.LogError("Matrices are not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError("Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : struct
		{
			if (matrices == null)
			{
				Debug.LogError("Matrices are not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError("Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static void AddMaterialPropertyOverride(int renderKey, string propertyName, object propertyValue, int lodIndex = -1, int rendererIndex = -1)
		{
			AddMaterialPropertyOverride(renderKey, Shader.PropertyToID(propertyName), propertyValue, lodIndex, rendererIndex);
		}

		public static void AddMaterialPropertyOverride(int renderKey, int nameID, object propertyValue, int lodIndex = -1, int rendererIndex = -1)
		{
			GPUIRenderSource result;
			if (Instance == null)
			{
				Debug.LogError("Rendering system is not initialized. Can not override MaterialPropertyBlock.");
			}
			else if (Instance.RenderSourceProvider.TryGetData(renderKey, out result))
			{
				result.renderSourceGroup.AddMaterialPropertyOverride(nameID, propertyValue, lodIndex, rendererIndex);
			}
			else
			{
				Debug.LogError("Renderer is not registered with key: " + renderKey);
			}
		}

		public static void AddDependentDisposable(IGPUIDisposable gpuiDisposable)
		{
			if (Instance == null)
			{
				Debug.LogError("Rendering system is not initialized. Can not add Disposable.");
			}
			else if (!Instance._dependentDisposables.Contains(gpuiDisposable))
			{
				Instance._dependentDisposables.Add(gpuiDisposable);
			}
		}

		public static void AddDependentDisposable(int renderKey, IGPUIDisposable gpuiDisposable)
		{
			GPUIRenderSource result;
			if (Instance == null)
			{
				Debug.LogError("Rendering system is not initialized. Can not add Disposable.");
			}
			else if (Instance.RenderSourceProvider.TryGetData(renderKey, out result))
			{
				result.renderSourceGroup.AddDependentDisposable(gpuiDisposable);
			}
			else
			{
				Debug.LogError("Renderer is not registered with key: " + renderKey);
			}
		}

		public static void DisposeRenderer(int renderKey)
		{
			if (!(Instance == null) && Instance.IsInitialized)
			{
				Instance.RenderSourceProvider.DisposeRenderer(renderKey);
			}
		}

		internal void UpdateCommandBuffers(bool forceNew = false)
		{
			if (CameraDataProvider == null)
			{
				return;
			}
			foreach (GPUICameraData value in CameraDataProvider.Values)
			{
				UpdateCommandBuffers(value, forceNew);
			}
			OnCommandBufferModified?.Invoke();
		}

		internal void UpdateCommandBuffers(GPUICameraData cameraData, bool forceNew = false)
		{
			if (forceNew)
			{
				cameraData.ClearVisibilityData();
			}
			foreach (GPUIRenderSourceGroup value in RenderSourceGroupProvider.Values)
			{
				value.TransformBufferData?.ReleaseInstanceDataBuffers(cameraData);
				value.UpdateCommandBuffer(cameraData);
			}
		}

		internal void UpdateCommandBuffers(GPUIRenderSourceGroup rsg)
		{
			foreach (GPUICameraData value in CameraDataProvider.Values)
			{
				rsg.UpdateCommandBuffer(value);
			}
		}

		public static bool TryGetLODGroupData(GPUIPrototype prototype, out GPUILODGroupData lodGroupData)
		{
			if (prototype == null)
			{
				lodGroupData = null;
				return false;
			}
			return TryGetLODGroupData(prototype.GetKey(), out lodGroupData);
		}

		public static bool TryGetLODGroupData(int key, out GPUILODGroupData lodGroupData)
		{
			if (!IsActive)
			{
				lodGroupData = null;
				return false;
			}
			return Instance.LODGroupDataProvider.TryGetData(key, out lodGroupData);
		}

		public static bool TryGetRenderSourceGroup(int runtimeRenderKey, out GPUIRenderSourceGroup renderSourceGroup)
		{
			renderSourceGroup = null;
			if (!IsActive || runtimeRenderKey == 0)
			{
				return false;
			}
			foreach (GPUIRenderSourceGroup value in Instance.RenderSourceGroupProvider.Values)
			{
				foreach (GPUIRenderSource renderSource in value.RenderSources)
				{
					if (renderSource.Key == runtimeRenderKey)
					{
						renderSourceGroup = value;
						return renderSourceGroup != null;
					}
				}
			}
			return false;
		}

		public static bool TryGetRenderSource(int runtimeRenderKey, out GPUIRenderSource renderSource)
		{
			renderSource = null;
			if (!IsActive || runtimeRenderKey == 0)
			{
				return false;
			}
			return Instance.RenderSourceProvider.TryGetData(runtimeRenderKey, out renderSource);
		}

		public static bool TryGetTransformBuffer(int runtimeRenderKey, out GraphicsBuffer transformBuffer, out int bufferStartIndex, GPUICameraData cameraData = null, bool resetCrossFade = true)
		{
			int bufferSize;
			return TryGetTransformBuffer(runtimeRenderKey, out transformBuffer, out bufferStartIndex, out bufferSize, cameraData, resetCrossFade);
		}

		public static bool TryGetTransformBuffer(int runtimeRenderKey, out GraphicsBuffer transformBuffer, out int bufferStartIndex, out int bufferSize, GPUICameraData cameraData = null, bool resetCrossFade = true)
		{
			transformBuffer = null;
			if (TryGetTransformBuffer(runtimeRenderKey, out GPUIShaderBuffer shaderBuffer, out bufferStartIndex, out bufferSize, cameraData, resetCrossFade))
			{
				transformBuffer = shaderBuffer.Buffer;
				return transformBuffer != null;
			}
			return false;
		}

		public static bool TryGetTransformBuffer(int runtimeRenderKey, out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, GPUICameraData cameraData = null, bool resetCrossFade = true)
		{
			int bufferSize;
			return TryGetTransformBuffer(runtimeRenderKey, out shaderBuffer, out bufferStartIndex, out bufferSize, cameraData, resetCrossFade);
		}

		public static bool TryGetTransformBuffer(int runtimeRenderKey, out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, GPUICameraData cameraData = null, bool resetCrossFade = true)
		{
			shaderBuffer = null;
			bufferStartIndex = 0;
			bufferSize = 0;
			if (!IsActive)
			{
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(runtimeRenderKey, out var result) && result.renderSourceGroup != null)
			{
				bufferStartIndex = result.bufferStartIndex;
				bufferSize = result.bufferSize;
				GPUITransformBufferData transformBufferData = result.renderSourceGroup.TransformBufferData;
				if (transformBufferData != null)
				{
					if (resetCrossFade)
					{
						transformBufferData.resetCrossFadeDataFrame = Time.frameCount;
					}
					if (cameraData == null)
					{
						shaderBuffer = transformBufferData.GetTransformBuffer();
					}
					else
					{
						shaderBuffer = transformBufferData.GetTransformBuffer(cameraData);
					}
					return shaderBuffer != null;
				}
			}
			return false;
		}

		internal static void AddCameraData(GPUICameraData cameraData)
		{
			InitializeRenderingSystem();
			Instance.CameraDataProvider.AddCameraData(cameraData);
		}

		internal void UpdateParameterBufferData()
		{
			foreach (IGPUIParameterBufferData key in ParameterBufferIndexes.Keys)
			{
				key.SetParameterBufferData();
			}
		}
	}
}
