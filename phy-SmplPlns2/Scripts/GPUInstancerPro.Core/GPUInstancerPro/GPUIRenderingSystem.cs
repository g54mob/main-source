using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(1000)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Debugger_Window")]
	public sealed class GPUIRenderingSystem : MonoBehaviour, IGPUIDisposable, IDisposable
	{
		public delegate void OnBufferDataModifiedCallback(GPUITransformBufferData transformBufferData);

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

		public Action OnCommandBufferModified;

		public Action<GPUICameraData> OnPreCull;

		public Action<GPUICameraData> OnPreRender;

		public Action<GPUICameraData> OnPostRender;

		private static UnityAction _onRenderingSystemInitialized;

		private List<GPUISystemExtension> _activeSystemExtensions;

		private static MaterialPropertyBlock _emptyMPB;

		public static OnBufferDataModifiedCallback OnBufferDataModified;

		private GraphicsBuffer _lightProbesSphericalHarmonicsBuffer;

		private GraphicsBuffer _lightProbesOcclusionProbesBuffer;

		private List<Vector3> _lightProbesPositions;

		private List<SphericalHarmonicsL2> _lightProbesSphericalHarmonics;

		private List<Vector4> _lightProbesOcclusionProbes;

		private int _pendingLightProbeUpdateFrame;

		private int _lastLightProbeBufferUsedFrame;

		private HashSet<int> _ignoreCameraIIDCollection;

		public static List<Renderer> prefabRendererList = new List<Renderer>();

		[NonSerialized]
		public WindZone windZone;

		[NonSerialized]
		internal bool _hasTreeCreatorWind;

		[NonSerialized]
		private Vector4 _windZoneValues;

		[NonSerialized]
		private Vector3 _windDirection;

		internal GPUIDataBuffer<int> _instancingBoundsMinMaxBuffer;

		private Action<GPUIDataBuffer<int>> _calculateInstancingBoundsCallback;

		internal bool _requireInstancingBoundsDataRead;

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

		public GraphicsBuffer DummyGraphicsBuffer { get; private set; }

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

		private void LateUpdate()
		{
			if (_hasTreeCreatorWind)
			{
				SetWindZoneValues();
			}
			if (_requireInstancingBoundsDataRead && !_instancingBoundsMinMaxBuffer.IsDataRequested())
			{
				_instancingBoundsMinMaxBuffer.AsyncDataRequest(_calculateInstancingBoundsCallback, writeToDataAfterReadback: true);
				_requireInstancingBoundsDataRead = false;
			}
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
			if (Instance.CameraDataProvider.TryGetData(camera.GetInstanceID(), out var result))
			{
				result.UpdateHiZTextureOnBeginRendering(camera, context);
			}
		}

		private static void CameraOnEndRendering(ScriptableRenderContext context, Camera camera)
		{
			if (Instance.CameraDataProvider.TryGetData(camera.GetInstanceID(), out var result))
			{
				result.UpdateHiZTexture(context);
			}
		}

		private static void OnEndContextRendering(ScriptableRenderContext context, List<Camera> list)
		{
			int frameCount = Time.frameCount;
			foreach (GPUIRenderSourceGroup value in Instance.RenderSourceGroupProvider.Values)
			{
				value.UpdateTransformBufferData(frameCount);
			}
		}

		private static void ProcessCamera(Camera camera)
		{
			GPUIRenderingSystem instance = Instance;
			instance.ParameterBuffer.UpdateBufferData();
			instance.ExecuteLightProbeUpdates();
			CameraType cameraType = camera.cameraType;
			int instanceID = camera.GetInstanceID();
			GPUICameraDataProvider cameraDataProvider = instance.CameraDataProvider;
			if (cameraDataProvider.Count == 0)
			{
				cameraDataProvider.RegisterDefaultCamera();
			}
			GPUICameraData result;
			bool flag = cameraDataProvider.TryGetData(instanceID, out result);
			if (!flag && !instance._ignoreCameraIIDCollection.Contains(instanceID))
			{
				if (cameraType == CameraType.Reflection)
				{
					result = new GPUICameraData(camera);
					cameraDataProvider.AddCameraData(result);
					flag = true;
				}
				else if (GPUIRuntimeSettings.Instance.cameraLoadingType != GPUICameraLoadingType.GPUICameraComponent && camera.CompareTag("MainCamera"))
				{
					result = cameraDataProvider.AddCamera(camera);
					flag = result != null;
				}
				if (flag)
				{
					instance.UpdateCommandBuffers(result);
				}
				else
				{
					instance._ignoreCameraIIDCollection.Add(instanceID);
				}
			}
			if (flag && (!result.IsVRCulling || XRSettings.stereoRenderingMode != XRSettings.StereoRenderingMode.MultiPass || result.ActiveCamera.stereoActiveEye != Camera.MonoOrStereoscopicEye.Right))
			{
				instance.ExecuteOnPreCull(result);
				result.UpdateCameraData();
				ProcessCameraData(camera, result, invokeEvents: true);
			}
		}

		private static void ProcessCameraData(Camera camera, GPUICameraData cameraData, bool invokeEvents)
		{
			if (cameraData._commandBuffer.Buffer == null)
			{
				return;
			}
			GPUIRenderingSystem instance = Instance;
			Vector3 center = cameraData.GetCameraPosition();
			if (invokeEvents)
			{
				instance.ExecuteOnPreRender(cameraData);
				if (Application.isPlaying)
				{
					instance.TreeProxyProvider.SetTreeProxyPosition(cameraData.GetCameraPosition());
				}
			}
			else
			{
				center = camera.transform.position;
			}
			instance._worldBounds.center = center;
			instance._worldBounds.size = GPUIRuntimeSettings.Instance.instancingBoundsSize;
			instance._renderParams.camera = camera;
			instance.MakeDrawCalls(cameraData);
			if (invokeEvents)
			{
				instance.ExecuteOnPostRender(cameraData);
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
			int cullingMask = cameraData.ActiveCamera.cullingMask;
			int maximumLODLevel = QualitySettings.maximumLODLevel;
			foreach (GPUIRenderSourceGroup value in RenderSourceGroupProvider.Values)
			{
				GPUILODGroupData lODGroupData = value.LODGroupData;
				if (value.BufferSize <= 0 || value.InstanceCount <= 0 || !(lODGroupData != null) || !cameraData.TryGetVisibilityBufferIndex(value, out var visibilityBufferIndex))
				{
					continue;
				}
				GPUITransformBufferData transformBufferData = value.TransformBufferData;
				MaterialPropertyBlock materialPropertyBlock = value.GetMaterialPropertyBlock(lODGroupData);
				value.ApplyMaterialPropertyOverrides(materialPropertyBlock, -1, -1);
				transformBufferData.SetMPBBuffers(materialPropertyBlock, cameraData);
				materialPropertyBlock.SetInt(GPUIConstants.PROP_rsgCommandStartIndex, (int)cameraData._visibilityBuffer[visibilityBufferIndex].commandStartIndex);
				_renderParams.matProps = materialPropertyBlock;
				GPUIProfile profile = value.Profile;
				bool isShadowCasting = profile.isShadowCasting;
				bool isProfileAllowLightProbes = profile.lightProbeSetting != GPUILightProbeSetting.Off;
				if (profile.isCalculateInstancingBounds && transformBufferData.HasInstancingBounds)
				{
					_renderParams.worldBounds = transformBufferData._instancingBounds;
				}
				else
				{
					_renderParams.worldBounds = _worldBounds;
				}
				int length = lODGroupData.Length;
				int maximumLODLevel2 = GetMaximumLODLevel(length, profile.maximumLODLevel, maximumLODLevel);
				for (int i = 0; i < length; i++)
				{
					RenderLOD(i, cameraData, cullingMask, value, lODGroupData, visibilityBufferIndex, materialPropertyBlock, isShadowCasting, length, maximumLODLevel2, 0, isProfileAllowLightProbes);
				}
				if (length == 1 && lODGroupData.optionalRendererCount > 0)
				{
					_ = lODGroupData[0];
					for (int j = 0; j < lODGroupData.optionalRendererCount; j++)
					{
						RenderLOD(0, cameraData, cullingMask, value, lODGroupData, visibilityBufferIndex, materialPropertyBlock, isShadowCasting, length, maximumLODLevel2, j + 1, isProfileAllowLightProbes);
					}
				}
			}
		}

		private void RenderLOD(int lodNo, GPUICameraData cameraData, int cullingMask, GPUIRenderSourceGroup renderSourceGroup, GPUILODGroupData lodGroupData, int visibilityBufferIndex, MaterialPropertyBlock mpb, bool isProfileShadowCasting, int lodCount, int maximumLODLevel, int optionalRendererNo, bool isProfileAllowLightProbes)
		{
			GPUIProfile profile = renderSourceGroup.Profile;
			if (isProfileShadowCasting && !profile.HasLODLevelShadows(lodNo))
			{
				isProfileShadowCasting = false;
			}
			bool isOverrideShadowLayer = profile.isOverrideShadowLayer;
			int shadowLayerOverride = profile.shadowLayerOverride;
			uint shadowRenderingLayerOverride = profile.shadowRenderingLayerOverride;
			bool flag = true;
			if (isProfileShadowCasting && isOverrideShadowLayer)
			{
				flag = GPUIUtility.IsInLayer(cullingMask, shadowLayerOverride);
			}
			int num = visibilityBufferIndex + lodNo + optionalRendererNo * 2;
			int num2 = (int)cameraData._visibilityBuffer[num].commandStartIndex;
			int num3 = (int)cameraData._visibilityBuffer[num + lodCount].commandStartIndex;
			int num4 = ((!isProfileShadowCasting) ? 1 : 2);
			renderSourceGroup.ApplyMaterialPropertyOverrides(mpb, lodNo, -1);
			GPUILODData gPUILODData = lodGroupData[lodNo];
			for (int i = 0; i < gPUILODData.Length; i++)
			{
				GPUIRendererData gPUIRendererData = gPUILODData[i];
				if (gPUIRendererData.optionalRendererNo != optionalRendererNo)
				{
					continue;
				}
				Mesh mesh = gPUIRendererData.GetMesh();
				if (mesh != null && GPUIUtility.IsInLayer(cullingMask, gPUIRendererData.layer) && lodNo >= maximumLODLevel)
				{
					_renderParams.receiveShadows = gPUIRendererData.receiveShadows;
					_renderParams.lightProbeUsage = (isProfileAllowLightProbes ? gPUIRendererData.lightProbeUsage : LightProbeUsage.Off);
					renderSourceGroup.ApplyMaterialPropertyOverrides(mpb, lodNo, i);
					_renderParams.layer = gPUIRendererData.layer;
					if (gPUIRendererData.motionVectorGenerationMode == MotionVectorGenerationMode.Object && !renderSourceGroup.TransformBufferData.HasPreviousFrameTransformBuffer)
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
					for (int j = 0; j < gPUIRendererData.rendererMaterials.Length; j++)
					{
						_renderParams.material = GetReplacementMaterial(gPUIRendererData, j, renderSourceGroup.ShaderKeywords);
						_ = renderSourceGroup.BufferSize;
						if (!gPUIRendererData.IsShadowsOnly)
						{
							_renderParams.shadowCastingMode = ShadowCastingMode.Off;
							GPUIUtility.RenderMeshIndirect(in _renderParams, mesh, cameraData._commandBuffer, 1, num2);
						}
						if (isProfileShadowCasting && gPUIRendererData.IsShadowCasting && flag)
						{
							if (isOverrideShadowLayer)
							{
								_renderParams.layer = shadowLayerOverride;
								_renderParams.renderingLayerMask = shadowRenderingLayerOverride;
							}
							_renderParams.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
							GPUIUtility.RenderMeshIndirect(in _renderParams, mesh, cameraData._commandBuffer, 1, num3);
						}
						num2++;
						num3++;
					}
				}
				else
				{
					num2 += gPUIRendererData.rendererMaterials.Length;
					num3 += gPUIRendererData.rendererMaterials.Length;
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
			if (replacementMat == null)
			{
				string extensionCode = null;
				if (MaterialProvider.TryGetReplacementMaterial(renderer.rendererMaterials[materialIndex], keywords, extensionCode, out replacementMat) && Application.isPlaying)
				{
					renderer.replacementMaterials[materialIndex] = replacementMat;
				}
			}
			return replacementMat;
		}

		private void ExecuteOnPreCull(GPUICameraData cameraData)
		{
			OnPreCull?.Invoke(cameraData);
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.ExecuteOnPreCull(cameraData);
				}
			}
		}

		private void ExecuteOnPreRender(GPUICameraData cameraData)
		{
			OnPreRender?.Invoke(cameraData);
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.ExecuteOnPreRender(cameraData);
				}
			}
		}

		private void ExecuteOnPostRender(GPUICameraData cameraData)
		{
			OnPostRender?.Invoke(cameraData);
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.ExecuteOnPostRender(cameraData);
				}
			}
		}

		public static void OnLightProbesUpdated()
		{
			if (IsActive && Application.isPlaying)
			{
				Instance._pendingLightProbeUpdateFrame = Time.frameCount;
			}
		}

		public static bool WillUpdateLightProbes()
		{
			if (!IsActive)
			{
				return false;
			}
			return Instance._pendingLightProbeUpdateFrame >= 0;
		}

		private void ExecuteLightProbeUpdates()
		{
			int frameCount = Time.frameCount;
			if (_pendingLightProbeUpdateFrame < 0)
			{
				if (_lightProbesPositions != null && _lastLightProbeBufferUsedFrame < frameCount - 30)
				{
					ReleaseLightProbeBuffers();
				}
			}
			else
			{
				if (_pendingLightProbeUpdateFrame + 2 >= frameCount)
				{
					return;
				}
				_lastLightProbeBufferUsedFrame = frameCount;
				_pendingLightProbeUpdateFrame = -1;
				foreach (GPUIRenderSource value in Instance.RenderSourceProvider.Values)
				{
					if (value.source is IGPUILightProbeDataProvider iGPUILightProbeDataProvider)
					{
						iGPUILightProbeDataProvider.OnLightProbesUpdated();
					}
				}
			}
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
				_activeSystemExtensions = new List<GPUISystemExtension>();
				_onRenderingSystemInitialized?.Invoke();
				if (DummyGraphicsBuffer != null)
				{
					DummyGraphicsBuffer.Dispose();
				}
				DummyGraphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 1, 4);
				_ignoreCameraIIDCollection = new HashSet<int>();
				if (prefabRendererList == null)
				{
					prefabRendererList = new List<Renderer>();
				}
				_instancingBoundsMinMaxBuffer = new GPUIDataBuffer<int>("InstancingBoundsBuffer");
				_calculateInstancingBoundsCallback = CalculateInstancingBoundsCallback;
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
				}
				else
				{
					RenderPipelineManager.endCameraRendering += CameraOnEndRendering;
					if (!GPUIRuntimeSettings.Instance.IsBuiltInRP)
					{
						RenderPipelineManager.endContextRendering -= OnEndContextRendering;
						RenderPipelineManager.endContextRendering += OnEndContextRendering;
					}
				}
				LightProbes.lightProbesUpdated -= OnLightProbesUpdated;
				LightProbes.lightProbesUpdated += OnLightProbesUpdated;
			}
		}

		public void Dispose()
		{
			IsInitialized = false;
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				activeSystemExtension.Dispose();
			}
			_activeSystemExtensions = null;
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
			if (DummyGraphicsBuffer != null)
			{
				DummyGraphicsBuffer.Dispose();
				DummyGraphicsBuffer = null;
			}
			_ignoreCameraIIDCollection = null;
			ReleaseLightProbeBuffers();
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
			OnCommandBufferModified = null;
			OnPreCull = null;
			OnPreRender = null;
			OnPostRender = null;
			if (_instancingBoundsMinMaxBuffer != null)
			{
				_instancingBoundsMinMaxBuffer.Dispose();
				_instancingBoundsMinMaxBuffer = null;
			}
			if (!IsActive)
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(CameraOnPreCull));
				RenderPipelineManager.beginCameraRendering -= CameraOnBeginRendering;
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(CameraOnPostRender));
				RenderPipelineManager.endCameraRendering -= CameraOnEndRendering;
				RenderPipelineManager.endContextRendering -= OnEndContextRendering;
				LightProbes.lightProbesUpdated -= OnLightProbesUpdated;
			}
		}

		public void ReleaseLightProbeBuffers()
		{
			if (_lightProbesSphericalHarmonicsBuffer != null)
			{
				_lightProbesSphericalHarmonicsBuffer.Dispose();
				_lightProbesSphericalHarmonicsBuffer = null;
			}
			if (_lightProbesOcclusionProbesBuffer != null)
			{
				_lightProbesOcclusionProbesBuffer.Dispose();
				_lightProbesOcclusionProbesBuffer = null;
			}
			_lightProbesPositions = null;
			_lightProbesSphericalHarmonics = null;
			_lightProbesOcclusionProbes = null;
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

		public static void AddOnRenderingSystemInitializedListener(UnityAction action)
		{
			_onRenderingSystemInitialized = (UnityAction)Delegate.Remove(_onRenderingSystemInitialized, action);
			_onRenderingSystemInitialized = (UnityAction)Delegate.Combine(_onRenderingSystemInitialized, action);
			if (IsActive)
			{
				action();
			}
		}

		public void AddRenderingSystemExtension(GPUISystemExtension systemExtension)
		{
			if (!_activeSystemExtensions.Contains(systemExtension))
			{
				_activeSystemExtensions.Add(systemExtension);
			}
		}

		public void RemoveRenderingSystemExtension(GPUISystemExtension systemExtension)
		{
			_activeSystemExtensions.Remove(systemExtension);
		}

		public static bool RegisterRenderer(UnityEngine.Object source, GameObject prefab, out int rendererKey, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			return RegisterRenderer(source, prefab, GPUIProfile.DefaultProfile, out rendererKey, groupID, transformBufferType, shaderKeywords);
		}

		public static bool RegisterRenderer(UnityEngine.Object source, GameObject prefab, GPUIProfile profile, out int rendererKey, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			if (prefab == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Given prefab is null! Can not register renderer.");
				rendererKey = 0;
				return false;
			}
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Source is null!");
				return false;
			}
			if (lodGroupData == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "LODGroupData is null!", source);
				return false;
			}
			if (profile == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Profile is null!", source);
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
			if (Instance.RenderSourceProvider.TryCreateRenderSource(source, orCreateRenderSourceGroup, out var renderSource))
			{
				rendererKey = renderSource.Key;
				return true;
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Buffer size is not set for renderer with key: " + renderKey);
				return false;
			}
			if (bufferSize > GPUIConstants.MAX_BUFFER_SIZE)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + bufferSize.ToString("#,0") + " exceeds maximum allowed buffer size (" + GPUIConstants.MAX_BUFFER_SIZE.ToString("#,0") + ").");
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetBufferSize(bufferSize, isCopyPreviousData);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Instance Count is not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetInstanceCount(instanceCount);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : unmanaged
		{
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : unmanaged
		{
			if (matrices == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Matrices are not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static bool SetTransformBufferData<T>(int renderKey, List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer = true) where T : unmanaged
		{
			if (matrices == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Matrices are not set for renderer with key: " + renderKey);
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.SetTransformBufferData(matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			return false;
		}

		public static void AddMaterialPropertyOverride(int renderKey, string propertyName, object propertyValue, int lodIndex = -1, int rendererIndex = -1, bool isPersistent = false)
		{
			AddMaterialPropertyOverride(renderKey, Shader.PropertyToID(propertyName), propertyValue, lodIndex, rendererIndex, isPersistent);
		}

		public static void AddMaterialPropertyOverride(int renderKey, int nameID, object propertyValue, int lodIndex = -1, int rendererIndex = -1, bool isPersistent = false)
		{
			GPUIRenderSource result;
			if (Instance == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Rendering system is not initialized. Can not override MaterialPropertyBlock.");
			}
			else if (Instance.RenderSourceProvider.TryGetData(renderKey, out result))
			{
				result.renderSourceGroup.AddMaterialPropertyOverride(nameID, propertyValue, lodIndex, rendererIndex, isPersistent);
			}
			else
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			}
		}

		public static void AddMaterialPropertyOverrideToRenderSourceGroup(int renderSourceGroupKey, int nameID, object propertyValue, int lodIndex = -1, int rendererIndex = -1, bool isPersistent = false)
		{
			GPUIRenderSourceGroup result;
			if (Instance == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Rendering system is not initialized. Can not override MaterialPropertyBlock.");
			}
			else if (Instance.RenderSourceGroupProvider.TryGetData(renderSourceGroupKey, out result))
			{
				result.AddMaterialPropertyOverride(nameID, propertyValue, lodIndex, rendererIndex, isPersistent);
			}
			else
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "RenderSourceGroup is not registered with key: " + result);
			}
		}

		public static void RemoveMaterialPropertyOverrides(int renderKey, string propertyName)
		{
			RemoveMaterialPropertyOverrides(renderKey, Shader.PropertyToID(propertyName));
		}

		public static void RemoveMaterialPropertyOverrides(int renderKey, int nameID)
		{
			if (!(Instance == null) && Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.renderSourceGroup.RemoveMaterialPropertyOverrides(nameID);
			}
		}

		public static void ClearMaterialPropertyOverrides(int renderKey)
		{
			if (!(Instance == null) && Instance.RenderSourceProvider.TryGetData(renderKey, out var result))
			{
				result.renderSourceGroup.ClearMaterialPropertyOverrides();
			}
		}

		public static void AddDependentDisposable(IGPUIDisposable gpuiDisposable)
		{
			if (Instance == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Rendering system is not initialized. Can not add Disposable.");
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
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Rendering system is not initialized. Can not add Disposable.");
			}
			else if (Instance.RenderSourceProvider.TryGetData(renderKey, out result))
			{
				result.renderSourceGroup.AddDependentDisposable(gpuiDisposable);
			}
			else
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Renderer is not registered with key: " + renderKey);
			}
		}

		public static bool AddDependentDisposableToRenderSourceGroup(int renderSourceGroupKey, IGPUIDisposable gpuiDisposable)
		{
			if (Instance == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Rendering system is not initialized. Can not add Disposable.");
				return false;
			}
			if (Instance.RenderSourceGroupProvider.TryGetData(renderSourceGroupKey, out var result))
			{
				result.AddDependentDisposable(gpuiDisposable);
				return true;
			}
			Debug.LogError(GPUIConstants.LOG_PREFIX + "Render Source Group is not registered with key: " + renderSourceGroupKey);
			return false;
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

		public static bool TryGetLODGroupData(int prototypeKey, out GPUILODGroupData lodGroupData)
		{
			if (!IsActive)
			{
				lodGroupData = null;
				return false;
			}
			return Instance.LODGroupDataProvider.TryGetData(prototypeKey, out lodGroupData);
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
			if (TryGetTransformBufferData(runtimeRenderKey, out var transformBufferData, out bufferStartIndex, out bufferSize, resetCrossFade))
			{
				shaderBuffer = transformBufferData.GetTransformBuffer(cameraData);
				return shaderBuffer != null;
			}
			return false;
		}

		public static bool TryGetTransformBufferData(int runtimeRenderKey, out GPUITransformBufferData transformBufferData, out int bufferStartIndex, out int bufferSize, bool resetCrossFade = true)
		{
			transformBufferData = null;
			bufferStartIndex = 0;
			bufferSize = 0;
			if (runtimeRenderKey == 0 || !IsActive)
			{
				return false;
			}
			if (Instance.RenderSourceProvider.TryGetData(runtimeRenderKey, out var result) && result.renderSourceGroup != null)
			{
				bufferStartIndex = result.bufferStartIndex;
				bufferSize = result.bufferSize;
				transformBufferData = result.renderSourceGroup.TransformBufferData;
				if (transformBufferData != null)
				{
					if (resetCrossFade)
					{
						transformBufferData.resetCrossFadeDataFrame = Time.frameCount;
					}
					return true;
				}
			}
			return false;
		}

		public static void SetLODColorDebuggingEnabled(int runtimeRenderKey, bool enabled, string colorPropertyName = null)
		{
			if (runtimeRenderKey != 0 && IsActive && Instance.RenderSourceProvider.TryGetData(runtimeRenderKey, out var result) && result.renderSourceGroup != null)
			{
				result.renderSourceGroup.SetLODColorDebuggingEnabled(enabled, colorPropertyName);
			}
		}

		internal void OnCreatedRenderSourceGroup(GPUIRenderSourceGroup rsg)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnCreatedRenderSourceGroup(rsg);
				}
			}
		}

		internal void OnRemovedRenderSourceGroup(int key)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnRemovedRenderSourceGroup(key);
				}
			}
		}

		internal void OnRenderSourceGroupBufferSizeChanged(GPUIRenderSourceGroup rsg)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnRenderSourceGroupBufferSizeChanged(rsg);
				}
			}
		}

		internal void OnCreatedRenderSource(GPUIRenderSource rs)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnCreatedRenderSource(rs);
				}
			}
		}

		internal void OnRemovedRenderSource(int key)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnRemovedRenderSource(key);
				}
			}
		}

		internal void OnRenderSourceBufferSizeChanged(GPUIRenderSource rs, int previousBufferSize)
		{
			foreach (GPUISystemExtension activeSystemExtension in _activeSystemExtensions)
			{
				if (activeSystemExtension != null)
				{
					activeSystemExtension.OnRenderSourceBufferSizeChanged(rs, previousBufferSize);
				}
			}
		}

		public void SetOptionalRendererStatusData(int runtimeRenderKey, NativeArray<uint> optionalRendererStatusData)
		{
			if (RenderSourceProvider.TryGetData(runtimeRenderKey, out var result) && result.renderSourceGroup != null)
			{
				result.renderSourceGroup.TransformBufferData.SetOptionalRendererStatusBufferData(optionalRendererStatusData, result.bufferStartIndex);
			}
		}

		internal unsafe void CalculateInterpolatedLightAndOcclusionProbes(GPUITransformBufferData transformBufferData, void* p_matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int rsgBufferSize, Vector3 positionOffset)
		{
			_lastLightProbeBufferUsedFrame = Time.frameCount;
			if (_lightProbesPositions == null)
			{
				_lightProbesPositions = new List<Vector3>(count);
			}
			if (_lightProbesSphericalHarmonics == null)
			{
				_lightProbesSphericalHarmonics = new List<SphericalHarmonicsL2>(count);
			}
			if (_lightProbesOcclusionProbes == null)
			{
				_lightProbesOcclusionProbes = new List<Vector4>(count);
			}
			if (_lightProbesSphericalHarmonicsBuffer == null || _lightProbesSphericalHarmonicsBuffer.count < count)
			{
				if (_lightProbesSphericalHarmonicsBuffer != null)
				{
					_lightProbesSphericalHarmonicsBuffer.Dispose();
				}
				_lightProbesSphericalHarmonicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, count, sizeof(SphericalHarmonicsL2));
			}
			if (_lightProbesOcclusionProbesBuffer == null || _lightProbesOcclusionProbesBuffer.count < count)
			{
				if (_lightProbesOcclusionProbesBuffer != null)
				{
					_lightProbesOcclusionProbesBuffer.Dispose();
				}
				_lightProbesOcclusionProbesBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, count, 16);
			}
			GPUIUtility.CalculateInterpolatedLightAndOcclusionProbes(ref transformBufferData._perInstanceLightProbesBuffer, p_matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, rsgBufferSize, _lightProbesPositions, _lightProbesSphericalHarmonics, _lightProbesOcclusionProbes, _lightProbesSphericalHarmonicsBuffer, _lightProbesOcclusionProbesBuffer, positionOffset);
		}

		public Transform GetInstanceTransform(int runtimeRenderKey, int bufferIndex)
		{
			if (runtimeRenderKey == 0 || !Instance.RenderSourceProvider.TryGetData(runtimeRenderKey, out var result) || !(result.source is IGPUIInstanceTransformProvider iGPUIInstanceTransformProvider))
			{
				return null;
			}
			return iGPUIInstanceTransformProvider.GetInstanceTransformWithRenderKey(runtimeRenderKey, bufferIndex);
		}

		public Transform GetInstanceTransformFromRSG(int rsgKey, int rsgBufferIndex)
		{
			if (rsgKey == 0 || !Instance.RenderSourceGroupProvider.TryGetData(rsgKey, out var result))
			{
				return null;
			}
			foreach (GPUIRenderSource renderSource in result.RenderSources)
			{
				if (rsgBufferIndex >= renderSource.bufferStartIndex && rsgBufferIndex < renderSource.bufferStartIndex + renderSource.bufferSize)
				{
					if (!(renderSource.source is IGPUIInstanceTransformProvider iGPUIInstanceTransformProvider))
					{
						return null;
					}
					return iGPUIInstanceTransformProvider.GetInstanceTransformWithRenderKey(renderSource.Key, rsgBufferIndex - renderSource.bufferStartIndex);
				}
			}
			return null;
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

		[Obsolete("SetGlobalWindVector is deprecated and will be removed in a future update. Please use SetTreeCreatorWindParams instead")]
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

		public static bool SetTreeCreatorWindParams()
		{
			if (!IsActive)
			{
				return false;
			}
			return Instance.SetWindZoneValues();
		}

		public bool SetWindZoneValues()
		{
			_hasTreeCreatorWind = true;
			bool flag = false;
			if (windZone != null && windZone.gameObject.activeInHierarchy)
			{
				flag = true;
			}
			else
			{
				WindZone[] array = UnityEngine.Object.FindObjectsByType<WindZone>(FindObjectsSortMode.None);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].mode == WindZoneMode.Directional)
					{
						windZone = array[i];
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				Vector4 vector = new Vector4(windZone.windTurbulence, windZone.windPulseMagnitude, windZone.windPulseFrequency, windZone.windMain);
				if (_windZoneValues != vector)
				{
					_windZoneValues = vector;
					Shader.SetGlobalVector(GPUIConstants.PROP_GPUIWindZone, _windZoneValues);
				}
				Vector3 forward = windZone.transform.forward;
				if (_windDirection != forward)
				{
					_windDirection = forward;
					Shader.SetGlobalVector(GPUIConstants.PROP_GPUIWindDirection, _windDirection);
				}
			}
			return flag;
		}

		private void CalculateInstancingBoundsCallback(GPUIDataBuffer<int> buffer)
		{
			if (!IsInitialized)
			{
				return;
			}
			foreach (GPUIRenderSourceGroup value in Instance.RenderSourceGroupProvider.Values)
			{
				if (value == null)
				{
					continue;
				}
				GPUITransformBufferData transformBufferData = value.TransformBufferData;
				if (transformBufferData != null && transformBufferData._instancingBoundsIndex >= 0 && !transformBufferData.HasInstancingBounds && transformBufferData._instancingBoundsIndex < _instancingBoundsMinMaxBuffer.Length)
				{
					int instancingBoundsIndex = transformBufferData._instancingBoundsIndex;
					int num = _instancingBoundsMinMaxBuffer[instancingBoundsIndex];
					int num2 = _instancingBoundsMinMaxBuffer[instancingBoundsIndex + 3];
					if (num == int.MaxValue || num2 == int.MinValue || num == num2)
					{
						transformBufferData.RequireInstancingBoundsUpdate();
						continue;
					}
					int num3 = _instancingBoundsMinMaxBuffer[instancingBoundsIndex + 1];
					int num4 = _instancingBoundsMinMaxBuffer[instancingBoundsIndex + 2];
					int num5 = _instancingBoundsMinMaxBuffer[instancingBoundsIndex + 4];
					int num6 = _instancingBoundsMinMaxBuffer[instancingBoundsIndex + 5];
					Vector3 boundsOffset = value.Profile.boundsOffset;
					transformBufferData.HasInstancingBounds = true;
					transformBufferData._instancingBounds = new Bounds(new Vector3((float)(num + num2) / 2f, (float)(num3 + num5) / 2f, (float)(num4 + num6) / 2f), new Vector3(num2 - num, num5 - num3, num6 - num4) + boundsOffset);
				}
			}
		}
	}
}
