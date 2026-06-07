using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;

namespace AmplifyOcclusion
{
	[Preserve]
	public class AmplifyAmbientOcclusionRenderer : PostProcessEffectRenderer<AmplifyOcclusionEffect>, IAmbientOcclusionMethod
	{
		private struct CmdBuffer
		{
			public CommandBuffer cmdBuffer;

			public CameraEvent cmdBufferEvent;

			public string cmdBufferName;
		}

		private static int m_nextID;

		private int m_myID;

		private string m_myIDstring;

		private float m_oneOverDepthScale = 1.5266243E-05f;

		private bool m_HDR = true;

		private bool m_MSAA = true;

		private PerPixelNormalSource m_prevPerPixelNormals;

		private ApplicationMethod m_prevApplyMethod;

		private bool m_prevDeferredReflections;

		private SampleCountLevel m_prevSampleCount;

		private bool m_prevDownsample;

		private bool m_prevCacheAware;

		private bool m_prevBlurEnabled;

		private int m_prevBlurRadius;

		private int m_prevBlurPasses;

		private bool m_prevFilterEnabled = true;

		private bool m_prevFilterDownsample = true;

		private bool m_prevHDR = true;

		private bool m_prevMSAA = true;

		private bool m_performComposite;

		private Camera m_targetCamera;

		private RenderTargetIdentifier[] applyDebugTargetsTemporal = new RenderTargetIdentifier[2];

		private RenderTargetIdentifier[] applyDeferredTargets_Log_Temporal = new RenderTargetIdentifier[3];

		private RenderTargetIdentifier[] applyDeferredTargetsTemporal = new RenderTargetIdentifier[3];

		private RenderTargetIdentifier[] applyOcclusionTemporal = new RenderTargetIdentifier[2];

		private RenderTargetIdentifier[] applyPostEffectTargetsTemporal = new RenderTargetIdentifier[2];

		private bool useMRTBlendingFallback;

		private bool checkedforMRTBlendingFallback;

		private CmdBuffer m_commandBuffer_Parameters;

		private CmdBuffer m_commandBuffer_Occlusion;

		private CmdBuffer m_commandBuffer_Apply;

		private static Mesh m_quadMesh;

		private static Material m_occlusionMat;

		private static Material m_blurMat;

		private static Material m_applyOcclusionMat;

		private RenderTextureFormat m_accumTemporalRTFormat;

		private RenderTextureFormat m_temporaryEmissionRTFormat = RenderTextureFormat.ARGB2101010;

		private RenderTextureFormat m_motionIntensityRTFormat = RenderTextureFormat.R8;

		private bool m_clearHistory = true;

		private RenderTexture m_occlusionDepthRT;

		private RenderTexture[] m_temporalAccumRT;

		private RenderTexture m_depthMipmap;

		private uint m_sampleStep;

		private uint m_curTemporalIdx;

		private uint m_prevTemporalIdx;

		private string[] m_tmpMipString;

		private int m_numberMips;

		private readonly RenderTargetIdentifier[] m_applyDeferredTargets = new RenderTargetIdentifier[2]
		{
			BuiltinRenderTextureType.GBuffer0,
			BuiltinRenderTextureType.CameraTarget
		};

		private readonly RenderTargetIdentifier[] m_applyDeferredTargets_Log = new RenderTargetIdentifier[2]
		{
			BuiltinRenderTextureType.GBuffer0,
			BuiltinRenderTextureType.GBuffer3
		};

		private TargetDesc m_target;

		private AmplifyOcclusionViewProjMatrix m_viewProjMatrix = new AmplifyOcclusionViewProjMatrix();

		private bool UsingTemporalFilter
		{
			get
			{
				if (m_sampleStep != 0 && (bool)base.settings.FilterEnabled)
				{
					return m_targetCamera.cameraType != CameraType.SceneView;
				}
				return false;
			}
		}

		private bool UsingMotionVectors
		{
			get
			{
				if (UsingTemporalFilter)
				{
					return (ApplicationMethod)base.settings.ApplyMethod != ApplicationMethod.Deferred;
				}
				return false;
			}
		}

		private bool UsingFilterDownsample
		{
			get
			{
				if ((bool)base.settings.Downsample && (bool)base.settings.FilterDownsample)
				{
					return UsingTemporalFilter;
				}
				return false;
			}
		}

		private void createCommandBuffer(ref CmdBuffer aCmdBuffer, string aCmdBufferName, CameraEvent aCameraEvent)
		{
			if (aCmdBuffer.cmdBuffer != null)
			{
				cleanupCommandBuffer(ref aCmdBuffer);
			}
			aCmdBuffer.cmdBufferName = aCmdBufferName;
			aCmdBuffer.cmdBuffer = new CommandBuffer();
			aCmdBuffer.cmdBuffer.name = aCmdBufferName;
			aCmdBuffer.cmdBufferEvent = aCameraEvent;
		}

		private void cleanupCommandBuffer(ref CmdBuffer aCmdBuffer)
		{
			CommandBuffer[] commandBuffers = m_targetCamera.GetCommandBuffers(aCmdBuffer.cmdBufferEvent);
			for (int i = 0; i < commandBuffers.Length; i++)
			{
				if (commandBuffers[i].name == aCmdBuffer.cmdBufferName)
				{
					m_targetCamera.RemoveCommandBuffer(aCmdBuffer.cmdBufferEvent, commandBuffers[i]);
				}
			}
			aCmdBuffer.cmdBufferName = null;
			aCmdBuffer.cmdBufferEvent = CameraEvent.BeforeDepthTexture;
			aCmdBuffer.cmdBuffer = null;
		}

		private void createQuadMesh()
		{
			if (m_quadMesh == null)
			{
				m_quadMesh = new Mesh();
				m_quadMesh.vertices = new Vector3[4]
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(1f, 1f, 0f),
					new Vector3(1f, 0f, 0f)
				};
				m_quadMesh.uv = new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				};
				m_quadMesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
				m_quadMesh.normals = new Vector3[0];
				m_quadMesh.tangents = new Vector4[0];
				m_quadMesh.colors32 = new Color32[0];
				m_quadMesh.colors = new Color[0];
			}
		}

		private void PerformBlit(CommandBuffer cb, Material mat, int pass)
		{
			cb.DrawMesh(m_quadMesh, Matrix4x4.identity, mat, 0, pass);
		}

		private void checkMaterials(bool aThroughErrorMsg)
		{
			if (m_occlusionMat == null)
			{
				m_occlusionMat = AmplifyOcclusionCommon.CreateMaterialWithShaderName("Hidden/Amplify Occlusion/Occlusion", aThroughErrorMsg);
			}
			if (m_blurMat == null)
			{
				m_blurMat = AmplifyOcclusionCommon.CreateMaterialWithShaderName("Hidden/Amplify Occlusion/Blur", aThroughErrorMsg);
			}
			if (m_applyOcclusionMat == null)
			{
				m_applyOcclusionMat = AmplifyOcclusionCommon.CreateMaterialWithShaderName("Hidden/Amplify Occlusion/Apply", aThroughErrorMsg);
			}
			if (m_applyOcclusionMat != null && !checkedforMRTBlendingFallback)
			{
				checkedforMRTBlendingFallback = true;
				useMRTBlendingFallback = m_applyOcclusionMat.GetTag("MRTBlending", searchFallbacks: false).ToUpper() != "TRUE";
			}
		}

		public override void Init()
		{
			base.Init();
			m_myID = m_nextID;
			m_myIDstring = m_myID.ToString();
			m_nextID++;
			if ((bool)base.settings.CacheAware)
			{
				if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RFloat))
				{
					base.settings.CacheAware.value = false;
					Debug.LogWarning("[AmplifyOcclusion] System does not support RFloat RenderTextureFormat. CacheAware will be disabled.");
				}
				else if (SystemInfo.copyTextureSupport == CopyTextureSupport.None)
				{
					base.settings.CacheAware.value = false;
					Debug.LogWarning("[AmplifyOcclusion] System does not support CopyTexture. CacheAware will be disabled.");
				}
				else if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2 || SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3)
				{
					base.settings.CacheAware.value = false;
					Debug.LogWarningFormat("[AmplifyOcclusion] CacheAware is not supported on {0} devices. CacheAware will be disabled.", SystemInfo.graphicsDeviceType);
				}
			}
			checkMaterials(aThroughErrorMsg: false);
			createQuadMesh();
			if (GraphicsSettings.HasShaderDefine(Graphics.activeTier, BuiltinShaderDefine.SHADER_API_MOBILE))
			{
				m_oneOverDepthScale = 6.106497E-05f;
			}
		}

		private void ComputeTo(PostProcessRenderContext context)
		{
			CommandBuffer command = context.command;
			UpdateGlobalShaderConstants(command);
			UpdateGlobalShaderConstants_Matrices(command);
			UpdateGlobalShaderConstants_AmbientOcclusion(command);
			checkParamsChanged();
			commandBuffer_FillComputeOcclusion(command);
		}

		private void ApplyTo(PostProcessRenderContext context)
		{
			CommandBuffer command = context.command;
			if ((ApplicationMethod)base.settings.ApplyMethod == ApplicationMethod.Debug)
			{
				commandBuffer_FillApplyDebug(command);
			}
			else if ((ApplicationMethod)base.settings.ApplyMethod == ApplicationMethod.PostEffect)
			{
				commandBuffer_FillApplyPostEffect(command);
			}
			else
			{
				bool logTarget = !m_HDR;
				commandBuffer_FillApplyDeferred(command, logTarget, context.singlePassStereoMode);
			}
			updateParams();
			m_sampleStep++;
		}

		private bool PreRenderCheck(PostProcessRenderContext context)
		{
			CheckCamera(context.camera);
			checkMaterials(aThroughErrorMsg: true);
			if (m_targetCamera != null)
			{
				bool prevDeferredReflections = GraphicsSettings.GetShaderMode(BuiltinShaderType.DeferredReflections) != BuiltinShaderMode.Disabled;
				m_prevPerPixelNormals = base.settings.PerPixelNormals;
				m_prevApplyMethod = base.settings.ApplyMethod;
				m_prevDeferredReflections = prevDeferredReflections;
				if (AmplifyOcclusionCommon.IsStereoMultiPassEnabled(m_targetCamera))
				{
					uint num = (m_sampleStep >> 1) & 1;
					uint num2 = m_sampleStep & 1;
					m_curTemporalIdx = num2 * 2 + num;
					m_prevTemporalIdx = num2 * 2 + (1 - num);
				}
				else
				{
					m_prevTemporalIdx = 1 - (m_curTemporalIdx = m_sampleStep & 1);
				}
				return true;
			}
			return false;
		}

		public void RenderAfterOpaque(PostProcessRenderContext context)
		{
			if (PreRenderCheck(context))
			{
				ComputeTo(context);
				ApplyTo(context);
			}
		}

		public void RenderAmbientOnly(PostProcessRenderContext context)
		{
			if (PreRenderCheck(context))
			{
				ComputeTo(context);
				m_performComposite = true;
			}
			else
			{
				m_performComposite = false;
			}
		}

		public void CompositeAmbientOnly(PostProcessRenderContext context)
		{
			if (m_performComposite)
			{
				ApplyTo(context);
			}
		}

		private void Reset()
		{
			if (m_commandBuffer_Parameters.cmdBuffer != null)
			{
				cleanupCommandBuffer(ref m_commandBuffer_Parameters);
			}
			if (m_commandBuffer_Occlusion.cmdBuffer != null)
			{
				cleanupCommandBuffer(ref m_commandBuffer_Occlusion);
			}
			if (m_commandBuffer_Apply.cmdBuffer != null)
			{
				cleanupCommandBuffer(ref m_commandBuffer_Apply);
			}
			AmplifyOcclusionCommon.SafeReleaseRT(ref m_occlusionDepthRT);
			AmplifyOcclusionCommon.SafeReleaseRT(ref m_depthMipmap);
			releaseTemporalRT();
			m_tmpMipString = null;
		}

		public override void Release()
		{
			Reset();
		}

		private void releaseTemporalRT()
		{
			if (m_temporalAccumRT != null)
			{
				for (int i = 0; i < m_temporalAccumRT.Length; i++)
				{
					AmplifyOcclusionCommon.SafeReleaseRT(ref m_temporalAccumRT[i]);
				}
			}
			m_temporalAccumRT = null;
		}

		private void ClearHistory(CommandBuffer cb)
		{
			m_clearHistory = false;
			if (m_temporalAccumRT != null && m_occlusionDepthRT != null)
			{
				for (int i = 0; i < m_temporalAccumRT.Length; i++)
				{
					cb.SetRenderTarget(m_temporalAccumRT[i]);
					PerformBlit(cb, m_occlusionMat, 34);
				}
			}
		}

		public override void ResetHistory()
		{
			m_clearHistory = true;
		}

		private void checkParamsChanged()
		{
			bool allowHDR = m_targetCamera.allowHDR;
			bool flag = m_targetCamera.allowMSAA && m_targetCamera.actualRenderingPath != RenderingPath.DeferredLighting && m_targetCamera.actualRenderingPath != RenderingPath.DeferredShading && QualitySettings.antiAliasing >= 1;
			int antiAliasing = ((!flag) ? 1 : QualitySettings.antiAliasing);
			if (m_occlusionDepthRT != null && (m_occlusionDepthRT.width != m_target.width || m_occlusionDepthRT.height != m_target.height || m_prevMSAA != flag || !m_occlusionDepthRT.IsCreated() || m_prevFilterEnabled != (bool)base.settings.FilterEnabled || m_prevFilterDownsample != UsingFilterDownsample || (m_temporalAccumRT != null && (!m_temporalAccumRT[0].IsCreated() || !m_temporalAccumRT[1].IsCreated()))))
			{
				AmplifyOcclusionCommon.SafeReleaseRT(ref m_occlusionDepthRT);
				AmplifyOcclusionCommon.SafeReleaseRT(ref m_depthMipmap);
				releaseTemporalRT();
			}
			if (m_temporalAccumRT != null)
			{
				if (AmplifyOcclusionCommon.IsStereoMultiPassEnabled(m_targetCamera))
				{
					if (m_temporalAccumRT.Length != 4)
					{
						m_temporalAccumRT = null;
					}
				}
				else if (m_temporalAccumRT.Length != 2)
				{
					m_temporalAccumRT = null;
				}
			}
			if (m_occlusionDepthRT == null)
			{
				m_occlusionDepthRT = AmplifyOcclusionCommon.SafeAllocateRT("_AO_OcclusionDepthTexture", m_target.width, m_target.height, base.settings.m_occlusionRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
			}
			if (m_temporalAccumRT == null && (bool)base.settings.FilterEnabled)
			{
				if (AmplifyOcclusionCommon.IsStereoMultiPassEnabled(m_targetCamera))
				{
					m_temporalAccumRT = new RenderTexture[4];
				}
				else
				{
					m_temporalAccumRT = new RenderTexture[2];
				}
				for (int i = 0; i < m_temporalAccumRT.Length; i++)
				{
					m_temporalAccumRT[i] = AmplifyOcclusionCommon.SafeAllocateRT("_AO_TemporalAccum_" + i, m_target.width, m_target.height, m_accumTemporalRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear, antiAliasing);
				}
				m_clearHistory = true;
			}
			if ((bool)base.settings.CacheAware && m_depthMipmap == null)
			{
				m_depthMipmap = AmplifyOcclusionCommon.SafeAllocateRT("_AO_DepthMipmap", m_target.fullWidth >> 1, m_target.fullHeight >> 1, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear, FilterMode.Point, 1, aUseMipMap: true);
				int num = Mathf.Min(m_target.fullWidth, m_target.fullHeight);
				m_numberMips = (int)(Mathf.Log(num, 2f) + 1f) - 1;
				m_tmpMipString = null;
				m_tmpMipString = new string[m_numberMips];
				for (int j = 0; j < m_numberMips; j++)
				{
					m_tmpMipString[j] = "_AO_TmpMip_" + j;
				}
			}
			else if (!base.settings.CacheAware && m_depthMipmap != null)
			{
				AmplifyOcclusionCommon.SafeReleaseRT(ref m_depthMipmap);
				m_tmpMipString = null;
			}
			if (m_prevSampleCount != (SampleCountLevel)base.settings.SampleCount || m_prevDownsample != (bool)base.settings.Downsample || m_prevCacheAware != (bool)base.settings.CacheAware || m_prevBlurEnabled != (bool)base.settings.BlurEnabled || ((m_prevBlurPasses != (int)base.settings.BlurPasses || m_prevBlurRadius != (int)base.settings.BlurRadius) && (bool)base.settings.BlurEnabled) || m_prevFilterEnabled != (bool)base.settings.FilterEnabled || m_prevFilterDownsample != UsingFilterDownsample || m_prevHDR != allowHDR || m_prevMSAA != flag)
			{
				m_clearHistory |= m_prevHDR != allowHDR;
				m_clearHistory |= m_prevMSAA != flag;
				m_HDR = allowHDR;
				m_MSAA = flag;
			}
		}

		private void updateParams()
		{
			m_prevSampleCount = base.settings.SampleCount;
			m_prevDownsample = base.settings.Downsample;
			m_prevCacheAware = base.settings.CacheAware;
			m_prevBlurEnabled = base.settings.BlurEnabled;
			m_prevBlurPasses = base.settings.BlurPasses;
			m_prevBlurRadius = base.settings.BlurRadius;
			m_prevFilterEnabled = base.settings.FilterEnabled;
			m_prevFilterDownsample = UsingFilterDownsample;
			m_prevHDR = m_HDR;
			m_prevMSAA = m_MSAA;
		}

		private void CheckCamera(Camera currentCamera)
		{
			if (!(m_targetCamera == null) && !(m_targetCamera != currentCamera))
			{
				return;
			}
			m_targetCamera = currentCamera;
			if (m_targetCamera.actualRenderingPath != RenderingPath.DeferredShading)
			{
				if ((PerPixelNormalSource)base.settings.PerPixelNormals != PerPixelNormalSource.None && (PerPixelNormalSource)base.settings.PerPixelNormals != PerPixelNormalSource.Camera)
				{
					base.settings.PerPixelNormals.value = PerPixelNormalSource.Camera;
					if (m_targetCamera.cameraType != CameraType.SceneView)
					{
						Debug.LogWarning("[AmplifyOcclusion] GBuffer Normals only available in Camera Deferred Shading mode. Switched to Camera source.");
					}
				}
				if ((ApplicationMethod)base.settings.ApplyMethod == ApplicationMethod.Deferred)
				{
					base.settings.ApplyMethod.value = ApplicationMethod.PostEffect;
					if (m_targetCamera.cameraType != CameraType.SceneView)
					{
						Debug.LogWarning("[AmplifyOcclusion] Deferred Method requires a Deferred Shading path. Switching to Post Effect Method.");
					}
				}
			}
			else if ((PerPixelNormalSource)base.settings.PerPixelNormals == PerPixelNormalSource.Camera)
			{
				base.settings.PerPixelNormals.value = PerPixelNormalSource.GBuffer;
				if (m_targetCamera.cameraType != CameraType.SceneView)
				{
					Debug.LogWarning("[AmplifyOcclusion] Camera Normals not supported for Deferred Method. Switching to GBuffer Normals.");
				}
			}
			if ((m_targetCamera.depthTextureMode & DepthTextureMode.Depth) == 0)
			{
				m_targetCamera.depthTextureMode |= DepthTextureMode.Depth;
			}
			if ((PerPixelNormalSource)base.settings.PerPixelNormals == PerPixelNormalSource.Camera && (m_targetCamera.depthTextureMode & DepthTextureMode.DepthNormals) == 0)
			{
				m_targetCamera.depthTextureMode |= DepthTextureMode.DepthNormals;
			}
			if (UsingMotionVectors && (m_targetCamera.depthTextureMode & DepthTextureMode.MotionVectors) == 0)
			{
				m_targetCamera.depthTextureMode |= DepthTextureMode.MotionVectors;
			}
		}

		public override void Render(PostProcessRenderContext context)
		{
		}

		private void commandBuffer_FillComputeOcclusion(CommandBuffer cb)
		{
			cb.BeginSample("AO 1 - ComputeOcclusion");
			if ((PerPixelNormalSource)base.settings.PerPixelNormals == PerPixelNormalSource.GBuffer || (PerPixelNormalSource)base.settings.PerPixelNormals == PerPixelNormalSource.GBufferOctaEncoded)
			{
				cb.SetGlobalTexture(PropertyID._AO_GBufferNormals, BuiltinRenderTextureType.GBuffer2);
			}
			Vector4 value = new Vector4(1f / (float)m_target.fullWidth, 1f / (float)m_target.fullHeight, m_target.fullWidth, m_target.fullHeight);
			int num = (int)((int)base.settings.SampleCount.GetValue<SampleCountLevel>() * AmplifyOcclusionCommon.PerPixelNormalSourceCount + base.settings.PerPixelNormals.GetValue<PerPixelNormalSource>());
			if ((bool)base.settings.CacheAware)
			{
				num += 16;
				int num2 = 0;
				for (int i = 0; i < m_numberMips; i++)
				{
					int width = m_target.fullWidth >> i + 1;
					int height = m_target.fullHeight >> i + 1;
					int num3 = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, m_tmpMipString[i], width, height, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
					cb.SetRenderTarget(num3);
					PerformBlit(cb, m_occlusionMat, (i == 0) ? 36 : 35);
					cb.CopyTexture(num3, 0, 0, m_depthMipmap, 0, i);
					if (num2 != 0)
					{
						AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num2);
					}
					num2 = num3;
					cb.SetGlobalTexture(PropertyID._AO_CurrDepthSource, num3);
				}
				AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num2);
				cb.SetGlobalTexture(PropertyID._AO_SourceDepthMipmap, m_depthMipmap);
			}
			if ((bool)base.settings.Downsample && !UsingFilterDownsample)
			{
				int num4 = m_target.fullWidth / 2;
				int num5 = m_target.fullHeight / 2;
				int num6 = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_SmallOcclusionTexture", num4, num5, base.settings.m_occlusionRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
				cb.SetGlobalVector(PropertyID._AO_Source_TexelSize, value);
				cb.SetGlobalVector(PropertyID._AO_Target_TexelSize, new Vector4(1f / ((float)m_target.fullWidth / 2f), 1f / ((float)m_target.fullHeight / 2f), (float)m_target.fullWidth / 2f, (float)m_target.fullHeight / 2f));
				cb.SetRenderTarget(num6);
				PerformBlit(cb, m_occlusionMat, num);
				cb.SetRenderTarget((Texture)null);
				cb.EndSample("AO 1 - ComputeOcclusion");
				if ((bool)base.settings.BlurEnabled)
				{
					commandBuffer_Blur(cb, num6, num4, num5);
				}
				cb.BeginSample("AO 2b - Combine");
				cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, num6);
				cb.SetGlobalVector(PropertyID._AO_Target_TexelSize, value);
				cb.SetRenderTarget(m_occlusionDepthRT);
				PerformBlit(cb, m_occlusionMat, 32);
				AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num6);
				cb.SetRenderTarget((Texture)null);
				cb.EndSample("AO 2b - Combine");
			}
			else
			{
				cb.SetGlobalVector(PropertyID._AO_Source_TexelSize, value);
				if (UsingFilterDownsample)
				{
					cb.SetGlobalVector(PropertyID._AO_Target_TexelSize, new Vector4(1f / ((float)m_target.fullWidth / 2f), 1f / ((float)m_target.fullHeight / 2f), (float)m_target.fullWidth / 2f, (float)m_target.fullHeight / 2f));
				}
				else
				{
					cb.SetGlobalVector(PropertyID._AO_Target_TexelSize, new Vector4(1f / (float)m_target.width, 1f / (float)m_target.height, m_target.width, m_target.height));
				}
				cb.SetRenderTarget(m_occlusionDepthRT);
				PerformBlit(cb, m_occlusionMat, num);
				cb.SetRenderTarget((Texture)null);
				cb.EndSample("AO 1 - ComputeOcclusion");
				if ((bool)base.settings.BlurEnabled)
				{
					commandBuffer_Blur(cb, m_occlusionDepthRT, m_target.width, m_target.height);
				}
			}
		}

		public bool IsAmbientOnly(PostProcessRenderContext context)
		{
			return (ApplicationMethod)base.settings.ApplyMethod == ApplicationMethod.Deferred;
		}

		public bool DoCompositingInBeforeReflections(PostProcessRenderContext context)
		{
			return true;
		}

		private int commandBuffer_NeighborMotionIntensity(CommandBuffer cb, int aSourceWidth, int aSourceHeight)
		{
			int num = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_IntensityTmp", aSourceWidth / 4, aSourceHeight / 4, m_motionIntensityRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
			cb.SetRenderTarget(num);
			cb.SetGlobalVector("_AO_Target_TexelSize", new Vector4(1f / ((float)aSourceWidth / 4f), 1f / ((float)aSourceHeight / 4f), (float)aSourceWidth / 4f, (float)aSourceHeight / 4f));
			PerformBlit(cb, m_occlusionMat, 33);
			int num2 = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_BlurIntensityTmp", aSourceWidth / 4, aSourceHeight / 4, m_motionIntensityRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
			cb.SetGlobalTexture(PropertyID._AO_CurrMotionIntensity, num);
			cb.SetRenderTarget(num2);
			PerformBlit(cb, m_blurMat, 8);
			cb.SetGlobalTexture(PropertyID._AO_CurrMotionIntensity, num2);
			cb.SetRenderTarget(num);
			PerformBlit(cb, m_blurMat, 9);
			AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num2);
			cb.SetGlobalTexture(PropertyID._AO_CurrMotionIntensity, num);
			return num;
		}

		private void commandBuffer_Blur(CommandBuffer cb, RenderTargetIdentifier aSourceRT, int aSourceWidth, int aSourceHeight)
		{
			cb.BeginSample("AO 2 - Blur");
			int num = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_BlurTmp", aSourceWidth, aSourceHeight, base.settings.m_occlusionRTFormat, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
			for (int i = 0; i < (int)base.settings.BlurPasses; i++)
			{
				cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, aSourceRT);
				int pass = ((int)base.settings.BlurRadius - 1) * 2;
				cb.SetRenderTarget(num);
				PerformBlit(cb, m_blurMat, pass);
				cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, num);
				int pass2 = 1 + ((int)base.settings.BlurRadius - 1) * 2;
				cb.SetRenderTarget(aSourceRT);
				PerformBlit(cb, m_blurMat, pass2);
			}
			AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num);
			cb.SetRenderTarget((Texture)null);
			cb.EndSample("AO 2 - Blur");
		}

		private int getTemporalPass()
		{
			if (!UsingMotionVectors || m_sampleStep <= 1)
			{
				return 0;
			}
			return 1;
		}

		private void commandBuffer_TemporalFilter(CommandBuffer cb)
		{
			if (m_clearHistory)
			{
				ClearHistory(cb);
			}
			float value = Mathf.Lerp(0.01f, 0.99f, base.settings.FilterBlending);
			cb.SetGlobalFloat(PropertyID._AO_TemporalCurveAdj, value);
			cb.SetGlobalFloat(PropertyID._AO_TemporalMotionSensibility, (float)base.settings.FilterResponse * (float)base.settings.FilterResponse + 0.01f);
			cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, m_occlusionDepthRT);
			cb.SetGlobalTexture(PropertyID._AO_TemporalAccumm, m_temporalAccumRT[m_prevTemporalIdx]);
		}

		private void commandBuffer_FillApplyDeferred(CommandBuffer cb, bool logTarget, SinglePassStereoMode stereoMode)
		{
			cb.BeginSample("AO 3 - ApplyDeferred");
			if (!logTarget)
			{
				if (UsingTemporalFilter)
				{
					commandBuffer_TemporalFilter(cb);
					int id = 0;
					if (UsingMotionVectors)
					{
						id = commandBuffer_NeighborMotionIntensity(cb, m_target.fullWidth, m_target.fullHeight);
					}
					if (!UsingFilterDownsample)
					{
						int num = 0;
						if (useMRTBlendingFallback)
						{
							num = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_ApplyOcclusionTexture", m_target.fullWidth, m_target.fullHeight, RenderTextureFormat.ARGB32);
							applyOcclusionTemporal[0] = num;
							applyOcclusionTemporal[1] = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
							cb.SetRenderTarget(applyOcclusionTemporal, applyOcclusionTemporal[0]);
							PerformBlit(cb, m_applyOcclusionMat, 10 + getTemporalPass());
						}
						else
						{
							applyDeferredTargetsTemporal[0] = m_applyDeferredTargets[0];
							applyDeferredTargetsTemporal[1] = m_applyDeferredTargets[1];
							applyDeferredTargetsTemporal[2] = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
							cb.SetRenderTarget(applyDeferredTargetsTemporal, applyDeferredTargetsTemporal[0]);
							PerformBlit(cb, m_applyOcclusionMat, 4 + getTemporalPass());
						}
						if (useMRTBlendingFallback)
						{
							cb.SetGlobalTexture("_AO_ApplyOcclusionTexture", num);
							applyOcclusionTemporal[0] = m_applyDeferredTargets[0];
							applyOcclusionTemporal[1] = m_applyDeferredTargets[1];
							cb.SetRenderTarget(applyOcclusionTemporal, applyOcclusionTemporal[0]);
							PerformBlit(cb, m_applyOcclusionMat, 13);
							AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num);
						}
					}
					else
					{
						RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
						cb.SetRenderTarget(renderTargetIdentifier);
						PerformBlit(cb, m_occlusionMat, 37 + getTemporalPass());
						cb.SetGlobalTexture(PropertyID._AO_TemporalAccumm, renderTargetIdentifier);
						cb.SetRenderTarget(m_applyDeferredTargets, m_applyDeferredTargets[0]);
						PerformBlit(cb, m_applyOcclusionMat, 16);
					}
					if (UsingMotionVectors)
					{
						AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, id);
					}
				}
				else
				{
					cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, m_occlusionDepthRT);
					cb.SetRenderTarget(m_applyDeferredTargets, m_applyDeferredTargets[0]);
					PerformBlit(cb, m_applyOcclusionMat, 3);
				}
			}
			else
			{
				int num2 = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_tmpAlbedo", m_target.fullWidth, m_target.fullHeight, RenderTextureFormat.ARGB32);
				int num3 = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_tmpEmission", m_target.fullWidth, m_target.fullHeight, m_temporaryEmissionRTFormat);
				cb.Blit(BuiltinRenderTextureType.GBuffer0, num2, RuntimeUtilities.stereoCopyMaterial);
				cb.Blit(BuiltinRenderTextureType.GBuffer3, num3, RuntimeUtilities.stereoCopyMaterial);
				cb.SetGlobalTexture(PropertyID._AO_GBufferAlbedo, num2);
				cb.SetGlobalTexture(PropertyID._AO_GBufferEmission, num3);
				if (UsingTemporalFilter)
				{
					commandBuffer_TemporalFilter(cb);
					int id2 = 0;
					if (UsingMotionVectors)
					{
						id2 = commandBuffer_NeighborMotionIntensity(cb, m_target.fullWidth, m_target.fullHeight);
					}
					if (!UsingFilterDownsample)
					{
						applyDeferredTargets_Log_Temporal[0] = m_applyDeferredTargets_Log[0];
						applyDeferredTargets_Log_Temporal[1] = m_applyDeferredTargets_Log[1];
						applyDeferredTargets_Log_Temporal[2] = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
						cb.SetRenderTarget(applyDeferredTargets_Log_Temporal, applyDeferredTargets_Log_Temporal[0]);
						PerformBlit(cb, m_applyOcclusionMat, 7 + getTemporalPass());
					}
					else
					{
						RenderTargetIdentifier renderTargetIdentifier2 = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
						cb.SetRenderTarget(renderTargetIdentifier2);
						PerformBlit(cb, m_occlusionMat, 37 + getTemporalPass());
						cb.SetGlobalTexture(PropertyID._AO_TemporalAccumm, renderTargetIdentifier2);
						cb.SetRenderTarget(m_applyDeferredTargets_Log, m_applyDeferredTargets_Log[0]);
						PerformBlit(cb, m_applyOcclusionMat, 17);
					}
					if (UsingMotionVectors)
					{
						AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, id2);
					}
				}
				else
				{
					cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, m_occlusionDepthRT);
					cb.SetRenderTarget(m_applyDeferredTargets_Log, m_applyDeferredTargets_Log[0]);
					PerformBlit(cb, m_applyOcclusionMat, 6);
				}
				AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num2);
				AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num3);
			}
			cb.SetRenderTarget((Texture)null);
			cb.EndSample("AO 3 - ApplyDeferred");
		}

		private void commandBuffer_FillApplyPostEffect(CommandBuffer cb)
		{
			cb.BeginSample("AO 3 - ApplyPostEffect");
			if (UsingTemporalFilter)
			{
				commandBuffer_TemporalFilter(cb);
				int id = 0;
				if (UsingMotionVectors)
				{
					id = commandBuffer_NeighborMotionIntensity(cb, m_target.fullWidth, m_target.fullHeight);
				}
				if (!UsingFilterDownsample)
				{
					int num = 0;
					if (useMRTBlendingFallback)
					{
						num = AmplifyOcclusionCommon.SafeAllocateTemporaryRT(cb, "_AO_ApplyOcclusionTexture", m_target.fullWidth, m_target.fullHeight, RenderTextureFormat.ARGB32);
						applyPostEffectTargetsTemporal[0] = num;
					}
					else
					{
						applyPostEffectTargetsTemporal[0] = BuiltinRenderTextureType.CameraTarget;
					}
					applyPostEffectTargetsTemporal[1] = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
					cb.SetRenderTarget(applyPostEffectTargetsTemporal, applyPostEffectTargetsTemporal[0]);
					PerformBlit(cb, m_applyOcclusionMat, 10 + getTemporalPass());
					if (useMRTBlendingFallback)
					{
						cb.SetGlobalTexture("_AO_ApplyOcclusionTexture", num);
						cb.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
						PerformBlit(cb, m_applyOcclusionMat, 12);
						AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, num);
					}
				}
				else
				{
					RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
					cb.SetRenderTarget(renderTargetIdentifier);
					PerformBlit(cb, m_occlusionMat, 37 + getTemporalPass());
					cb.SetGlobalTexture(PropertyID._AO_TemporalAccumm, renderTargetIdentifier);
					cb.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
					PerformBlit(cb, m_applyOcclusionMat, 15);
				}
				if (UsingMotionVectors)
				{
					AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, id);
				}
			}
			else
			{
				cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, m_occlusionDepthRT);
				cb.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
				PerformBlit(cb, m_applyOcclusionMat, 9);
			}
			cb.SetRenderTarget((Texture)null);
			cb.EndSample("AO 3 - ApplyPostEffect");
		}

		private void commandBuffer_FillApplyDebug(CommandBuffer cb)
		{
			cb.BeginSample("AO 3 - ApplyDebug");
			if (UsingTemporalFilter)
			{
				commandBuffer_TemporalFilter(cb);
				int id = 0;
				if (UsingMotionVectors)
				{
					id = commandBuffer_NeighborMotionIntensity(cb, m_target.fullWidth, m_target.fullHeight);
				}
				if (!UsingFilterDownsample)
				{
					applyDebugTargetsTemporal[0] = BuiltinRenderTextureType.CameraTarget;
					applyDebugTargetsTemporal[1] = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
					cb.SetRenderTarget(applyDebugTargetsTemporal, applyDebugTargetsTemporal[0]);
					PerformBlit(cb, m_applyOcclusionMat, 1 + getTemporalPass());
				}
				else
				{
					RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(m_temporalAccumRT[m_curTemporalIdx]);
					cb.SetRenderTarget(renderTargetIdentifier);
					PerformBlit(cb, m_occlusionMat, 37 + getTemporalPass());
					cb.SetGlobalTexture(PropertyID._AO_TemporalAccumm, renderTargetIdentifier);
					cb.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
					PerformBlit(cb, m_applyOcclusionMat, 14);
				}
				if (UsingMotionVectors)
				{
					AmplifyOcclusionCommon.SafeReleaseTemporaryRT(cb, id);
				}
			}
			else
			{
				cb.SetGlobalTexture(PropertyID._AO_CurrOcclusionDepth, m_occlusionDepthRT);
				cb.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
				PerformBlit(cb, m_applyOcclusionMat, 0);
			}
			cb.SetRenderTarget((Texture)null);
			cb.EndSample("AO 3 - ApplyDebug");
		}

		public new void PostRender()
		{
			if (m_occlusionDepthRT != null)
			{
				m_occlusionDepthRT.MarkRestoreExpected();
			}
			if (m_temporalAccumRT != null)
			{
				RenderTexture[] temporalAccumRT = m_temporalAccumRT;
				for (int i = 0; i < temporalAccumRT.Length; i++)
				{
					temporalAccumRT[i].MarkRestoreExpected();
				}
			}
		}

		private void UpdateGlobalShaderConstants(CommandBuffer cb)
		{
			AmplifyOcclusionCommon.UpdateGlobalShaderConstants(cb, ref m_target, m_targetCamera, base.settings.Downsample, UsingFilterDownsample);
		}

		private void UpdateGlobalShaderConstants_AmbientOcclusion(CommandBuffer cb)
		{
			cb.SetGlobalFloat(PropertyID._AO_Radius, base.settings.Radius);
			cb.SetGlobalFloat(PropertyID._AO_PowExponent, base.settings.PowerExponent);
			cb.SetGlobalFloat(PropertyID._AO_Bias, (float)base.settings.Bias * (float)base.settings.Bias);
			Color value = base.settings.Tint.GetValue<Color>();
			cb.SetGlobalColor(PropertyID._AO_Levels, new Color(value.r, value.g, value.b, base.settings.Intensity));
			float num = 1f - (float)base.settings.Thickness;
			cb.SetGlobalFloat(PropertyID._AO_ThicknessDecay, (1f - num * num) * 0.98f);
			float num2 = m_targetCamera.farClipPlane * m_oneOverDepthScale;
			cb.SetGlobalFloat(PropertyID._AO_BufDepthToLinearEye, num2);
			if ((bool)base.settings.BlurEnabled)
			{
				float value2 = (float)base.settings.BlurSharpness * 100f * num2;
				cb.SetGlobalFloat(PropertyID._AO_BlurSharpness, value2);
			}
			if ((bool)base.settings.FadeEnabled)
			{
				base.settings.FadeStart.value = Mathf.Max(0f, base.settings.FadeStart);
				base.settings.FadeLength.value = Mathf.Max(0.01f, base.settings.FadeLength);
				float y = 1f / (float)base.settings.FadeLength;
				cb.SetGlobalVector(PropertyID._AO_FadeParams, new Vector2(base.settings.FadeStart, y));
				float num3 = 1f - (float)base.settings.FadeToThickness;
				cb.SetGlobalVector(PropertyID._AO_FadeValues, new Vector4(base.settings.FadeToIntensity, base.settings.FadeToRadius, base.settings.FadeToPowerExponent, (1f - num3 * num3) * 0.98f));
				Color value3 = base.settings.FadeToTint.GetValue<Color>();
				cb.SetGlobalColor(PropertyID._AO_FadeToTint, new Color(value3.r, value3.g, value3.b, 0f));
			}
			else
			{
				cb.SetGlobalVector(PropertyID._AO_FadeParams, new Vector2(0f, 0f));
			}
			if (UsingTemporalFilter)
			{
				AmplifyOcclusionCommon.CommandBuffer_TemporalFilterDirectionsOffsets(cb, m_sampleStep);
				return;
			}
			cb.SetGlobalFloat(PropertyID._AO_TemporalDirections, 0f);
			cb.SetGlobalFloat(PropertyID._AO_TemporalOffsets, 0f);
		}

		private void UpdateGlobalShaderConstants_Matrices(CommandBuffer cb)
		{
			m_viewProjMatrix.UpdateGlobalShaderConstants_Matrices(cb, m_targetCamera, UsingTemporalFilter);
		}
	}
}
