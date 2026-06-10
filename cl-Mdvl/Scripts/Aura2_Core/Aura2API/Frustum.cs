using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	public class Frustum
	{
		private FrustumSettings _frustumSettings;

		private FrustumSettingsToId _frustumSettingsToId;

		private ComputeShader _computeMaximumDepthComputeShader;

		private Shader _processOcclusionMapShader;

		private Material _processOcclusionMapMaterial;

		public ComputeShader _computeVisibleCellsComputeShader;

		private ComputeShader _computeDataComputeShader;

		private uint _threadSizeX;

		private uint _threadSizeY;

		private uint _threadSizeZ;

		private ComputeBuffer[] _dispatchBuffers;

		private ComputeShader _computeAccumulationComputeShader;

		private float _farClip;

		private Vector4 _cameraRanges;

		private Vector4 _frustumRanges;

		private Vector4 _zParameters;

		private Vector4 _bufferResolutionVector;

		private Vector4 _bufferTexelSizeVector;

		private Camera _cameraComponent;

		private AuraCamera _auraComponent;

		private VolumesManager _volumesManager;

		private SpotLightsManager _spotLightsManager;

		private PointLightsManager _pointLightsManager;

		private Matrix4x4 _previousWorldToClipMatrix;

		private float[] _previousWorldToClipMatrixFloats;

		private Matrix4x4 _previousSecondaryWorldToClipMatrix;

		private float[] _previousSecondaryWorldToClipMatrixFloats;

		private TextureBuffers _workingBuffers;

		private Vector3Int _frustumGridResolution;

		private bool _previousOcclusionCullingState;

		private Vector4 _lightProbesCoefficientsTextureSizeVector;

		private Vector4 _lightProbesCoefficientsTextureHalfTexelSize;

		private ComputeShader _renderLightProbesTextureComputeShader;

		private bool _previousLightProbesState;

		private ComputeShader _applyMedianFilterComputeShader;

		private ComputeShader _applyBlurFilterComputeShader;

		private float[] _frustumCornersWorldPositionArray;

		private float[] _secondaryFrustumCornersWorldPositionArray;

		private Vector3Int FrustumGridResolution => _frustumGridResolution;

		private Vector4 BufferTexelSizeVector => _bufferTexelSizeVector;

		private Vector4 BufferResolutionVector => _bufferResolutionVector;

		private TextureBuffers WorkingBuffers
		{
			get
			{
				if (_workingBuffers == null)
				{
					_workingBuffers = new TextureBuffers();
				}
				return _workingBuffers;
			}
		}

		private SwappableRenderTexture DataVolumeTexture => WorkingBuffers.DataVolumeTexture;

		private RenderTexture FogVolumeTexture => WorkingBuffers.FogVolumeTexture;

		private SwappableRenderTexture OcclusionTexture => WorkingBuffers.OcclusionTexture;

		private SwappableRenderTexture SliceTexture => WorkingBuffers.SliceTexture;

		public Frustum(FrustumSettings frustumSettings, Camera camera, AuraCamera auraComponent)
		{
			_frustumSettings = frustumSettings;
			_frustumSettings.OnFrustumQualityChanged += _frustumSettings_OnFrustumQualityChanged;
			_cameraComponent = camera;
			_auraComponent = auraComponent;
			_volumesManager = new VolumesManager(_cameraComponent, _frustumSettings);
			_spotLightsManager = new SpotLightsManager(_cameraComponent, _frustumSettings);
			_pointLightsManager = new PointLightsManager(_cameraComponent, _frustumSettings);
			_frustumSettingsToId = new FrustumSettingsToId(_frustumSettings, _auraComponent, _volumesManager, _spotLightsManager, _pointLightsManager);
			InitializeResources();
			InitializeComputeBuffers();
			SetFrustumGridResolution(_frustumSettings.QualitySettings.frustumGridResolution);
			_previousOcclusionCullingState = _frustumSettingsToId.HasFlags(FrustumParameters.EnableOcclusionCulling);
			_previousLightProbesState = _frustumSettingsToId.HasFlags(FrustumParameters.EnableLightProbes);
			_cameraRanges = default(Vector4);
			_frustumRanges = default(Vector4);
			_zParameters = default(Vector4);
			_frustumCornersWorldPositionArray = new float[32];
			_secondaryFrustumCornersWorldPositionArray = new float[32];
			_previousWorldToClipMatrix = default(Matrix4x4);
			_previousWorldToClipMatrixFloats = new float[16];
			_previousSecondaryWorldToClipMatrix = default(Matrix4x4);
			_previousSecondaryWorldToClipMatrixFloats = new float[16];
		}

		private void _frustumSettings_OnFrustumQualityChanged()
		{
			SetFrustumGridResolution(_frustumSettings.QualitySettings.frustumGridResolution);
		}

		private void InitializeResources()
		{
			_computeMaximumDepthComputeShader = Aura.ResourcesCollection.computeMaximumDepthComputeShader;
			_computeVisibleCellsComputeShader = Aura.ResourcesCollection.computeVisibleCellsComputeShader;
			_processOcclusionMapShader = Aura.ResourcesCollection.processOcclusionMapShader;
			_computeDataComputeShader = Aura.ResourcesCollection.computeDataComputeShader;
			_computeAccumulationComputeShader = Aura.ResourcesCollection.computeAccumulationComputeShader;
			_renderLightProbesTextureComputeShader = Aura.ResourcesCollection.renderLightProbesTextureComputeShader;
			_applyMedianFilterComputeShader = Aura.ResourcesCollection.applyDenoisingFilterComputeShader;
			_applyBlurFilterComputeShader = Aura.ResourcesCollection.applyBlurFilterComputeShader;
		}

		public void ComputeData()
		{
			if (_frustumSettings.QualitySettings.displayVolumetricLightingBuffer)
			{
				Shader.EnableKeyword("AURA_DISPLAY_VOLUMETRIC_LIGHTING_ONLY");
			}
			else
			{
				Shader.DisableKeyword("AURA_DISPLAY_VOLUMETRIC_LIGHTING_ONLY");
			}
			if (_frustumSettings.QualitySettings.enableDithering)
			{
				Shader.EnableKeyword("AURA_USE_DITHERING");
			}
			else
			{
				Shader.DisableKeyword("AURA_USE_DITHERING");
			}
			if (_frustumSettings.QualitySettings.texture3DFiltering == Texture3DFiltering.Cubic)
			{
				Shader.EnableKeyword("AURA_USE_CUBIC_FILTERING");
			}
			else
			{
				Shader.DisableKeyword("AURA_USE_CUBIC_FILTERING");
			}
			_computeMaximumDepthComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
			_computeDataComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
			_computeAccumulationComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
			_computeVisibleCellsComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
			_computeMaximumDepthComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			_computeMaximumDepthComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			_computeVisibleCellsComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			_computeDataComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			_computeAccumulationComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			float num = Mathf.Max(0.001f, _frustumSettings.QualitySettings.depthBiasCoefficient);
			float num2 = 1f / num;
			_computeDataComputeShader.SetFloat("Aura_DepthBiasCoefficient", num);
			_computeAccumulationComputeShader.SetFloat("Aura_DepthBiasCoefficient", num);
			_computeVisibleCellsComputeShader.SetFloat("Aura_DepthBiasCoefficient", num);
			_computeDataComputeShader.SetFloat("Aura_DepthBiasReciproqualCoefficient", num2);
			_computeVisibleCellsComputeShader.SetInt("_frameID", _auraComponent.FrameId);
			_cameraRanges.x = _cameraComponent.nearClipPlane;
			_cameraRanges.y = _cameraComponent.farClipPlane;
			_frustumRanges.x = 1E-16f;
			_frustumRanges.y = Mathf.Min(_cameraComponent.farClipPlane, _frustumSettings.QualitySettings.farClipPlaneDistance);
			_zParameters.x = -1f + _cameraComponent.farClipPlane / _cameraComponent.nearClipPlane;
			_zParameters.y = 1f;
			_zParameters.z = _zParameters.x / _cameraComponent.farClipPlane;
			_zParameters.w = _zParameters.y / _cameraComponent.farClipPlane;
			Color color = (_frustumSettings.BaseSettings.useColor ? (_frustumSettings.BaseSettings.color * _frustumSettings.BaseSettings.colorStrength) : Color.black);
			float num3 = (_frustumSettings.BaseSettings.useDensity ? _frustumSettings.BaseSettings.density : 0f);
			float num4 = (_frustumSettings.BaseSettings.useExtinction ? _frustumSettings.BaseSettings.extinction : 1f);
			int kernelId = _frustumSettingsToId.GetKernelId(_cameraComponent);
			bool orthographic = _cameraComponent.orthographic;
			Shader.SetGlobalColor("Aura_BaseColor", color);
			Shader.SetGlobalFloat("Aura_BaseDensity", num3);
			Shader.SetGlobalFloat("Aura_Extinction", num4);
			Shader.SetGlobalVector("Aura_BufferResolution", BufferResolutionVector);
			Shader.SetGlobalVector("Aura_BufferTexelSize", BufferTexelSizeVector);
			Shader.SetGlobalTexture("Aura_VolumetricLightingTexture", FogVolumeTexture);
			Shader.SetGlobalFloat("Aura_DepthBiasCoefficient", num);
			Shader.SetGlobalFloat("Aura_DepthBiasReciproqualCoefficient", num2);
			Shader.SetGlobalVector("Aura_FrustumRanges", _frustumRanges);
			Graphics.ClearRandomWriteTargets();
			_frustumSettingsToId.ComputeFlags();
			bool flag = _frustumSettingsToId.HasFlags(FrustumParameters.EnableTemporalReprojection);
			_dispatchBuffers[5].SetCounterValue(0u);
			bool flag2 = _frustumSettingsToId.HasFlags(FrustumParameters.EnableOcclusionCulling);
			if (flag2)
			{
				_computeMaximumDepthComputeShader.SetTextureFromGlobal((int)_frustumSettings.QualitySettings.occlusionCullingAccuracy, "depthTexture", "_CameraDepthTexture");
				_computeMaximumDepthComputeShader.SetVector("cameraRanges", _frustumRanges);
				_computeMaximumDepthComputeShader.SetVector("zParameters", orthographic ? _cameraRanges : _zParameters);
				_computeMaximumDepthComputeShader.SetBool("isOrthographic", orthographic);
				_computeMaximumDepthComputeShader.SetTexture((int)_frustumSettings.QualitySettings.occlusionCullingAccuracy, "occlusionTexture", OcclusionTexture.WriteBuffer);
				_computeMaximumDepthComputeShader.DispatchIndirect((int)_frustumSettings.QualitySettings.occlusionCullingAccuracy, _dispatchBuffers[2]);
				OcclusionTexture.Swap();
				if (_processOcclusionMapMaterial == null)
				{
					_processOcclusionMapMaterial = new Material(_processOcclusionMapShader);
				}
				_processOcclusionMapMaterial.SetVector("bufferResolution", BufferResolutionVector);
				Graphics.Blit(OcclusionTexture.ReadBuffer, OcclusionTexture.WriteBuffer, _processOcclusionMapMaterial);
				OcclusionTexture.Swap();
				int kernelIndex = 2 + (flag ? 1 : 0);
				_computeVisibleCellsComputeShader.SetTexture(kernelIndex, "occlusionTexture", OcclusionTexture.ReadBuffer);
				_computeVisibleCellsComputeShader.SetBuffer(kernelIndex, "appendedCellsBuffer", _dispatchBuffers[5]);
				_computeVisibleCellsComputeShader.SetTexture(kernelIndex, "maximumSliceAmountTexture", SliceTexture.WriteBuffer);
				_computeVisibleCellsComputeShader.DispatchIndirect(kernelIndex, _dispatchBuffers[3]);
				ComputeBuffer.CopyCount(_dispatchBuffers[5], _dispatchBuffers[0], 0);
				SliceTexture.Swap();
				_computeVisibleCellsComputeShader.SetBuffer(4, "visibleCellsAmountBuffer", _dispatchBuffers[0]);
				_computeVisibleCellsComputeShader.SetBuffer(4, "sizeBuffer", _dispatchBuffers[1]);
				_computeVisibleCellsComputeShader.DispatchIndirect(kernelIndex, _dispatchBuffers[4]);
			}
			else
			{
				if (_previousOcclusionCullingState)
				{
					WorkingBuffers.ReleaseOcclusionTextureBuffer();
					WorkingBuffers.ReleaseSliceTextureBuffer();
					ComputeDispatchSizes();
				}
				int kernelIndex2 = (flag ? 1 : 0);
				_computeVisibleCellsComputeShader.SetTexture(kernelIndex2, "occlusionTexture", Aura.ResourcesCollection.dummyTexture);
				_computeVisibleCellsComputeShader.SetTexture(kernelIndex2, "maximumSliceAmountTexture", Aura.ResourcesCollection.DummyTextureUAV);
				_computeVisibleCellsComputeShader.SetBuffer(kernelIndex2, "appendedCellsBuffer", _dispatchBuffers[5]);
				_computeVisibleCellsComputeShader.DispatchIndirect(kernelIndex2, _dispatchBuffers[3]);
			}
			DataVolumeTexture.Swap();
			DataVolumeTexture.WriteBuffer.Clear(Vector4.zero);
			FogVolumeTexture.Clear(Vector4.zero);
			_computeDataComputeShader.SetTexture(kernelId, "lightingTexture", DataVolumeTexture.WriteBuffer);
			_computeDataComputeShader.SetTexture(kernelId, "previousFrameLightingVolumeTexture", DataVolumeTexture.ReadBuffer);
			_computeDataComputeShader.SetFloat("time", AuraCamera.Time);
			_computeDataComputeShader.SetVector("cameraPosition", _cameraComponent.transform.position.AsVector4(1f));
			_computeDataComputeShader.SetVector("cameraRanges", _frustumRanges);
			_computeDataComputeShader.SetFloat("baseDensity", num3);
			_computeDataComputeShader.SetBool("useScattering", _frustumSettings.BaseSettings.useScattering);
			_computeDataComputeShader.SetFloat("baseScattering", 1f - _frustumSettings.BaseSettings.scattering);
			_computeDataComputeShader.SetVector("baseTint", _frustumSettings.BaseSettings.useTint ? (_frustumSettings.BaseSettings.tint * _frustumSettings.BaseSettings.tintStrength) : Color.white);
			_computeDataComputeShader.SetVector("baseColor", color);
			if (_cameraComponent.GetCameraStereoMode() == StereoMode.SinglePass)
			{
				_cameraComponent.GetFrustumCorners(Camera.MonoOrStereoscopicEye.Left, _frustumRanges.x, _frustumRanges.y, ref _frustumCornersWorldPositionArray);
				_cameraComponent.GetFrustumCorners(Camera.MonoOrStereoscopicEye.Right, _frustumRanges.x, _frustumRanges.y, ref _secondaryFrustumCornersWorldPositionArray);
			}
			else
			{
				_cameraComponent.GetFrustumCorners(Camera.MonoOrStereoscopicEye.Mono, _frustumRanges.x, _frustumRanges.y, ref _frustumCornersWorldPositionArray);
			}
			_computeDataComputeShader.SetFloats("frustumCornersWorldPositionArray", _frustumCornersWorldPositionArray);
			_computeDataComputeShader.SetFloats("secondaryFrustumCornersWorldPositionArray", _secondaryFrustumCornersWorldPositionArray);
			_computeAccumulationComputeShader.SetFloats("frustumCornersWorldPositionArray", _frustumCornersWorldPositionArray);
			_computeAccumulationComputeShader.SetFloats("secondaryFrustumCornersWorldPositionArray", _secondaryFrustumCornersWorldPositionArray);
			_computeDataComputeShader.SetBool("useReprojection", flag);
			_computeDataComputeShader.SetFloat("temporalReprojectionFactor", _frustumSettings.QualitySettings.temporalReprojectionFactor);
			_computeDataComputeShader.SetFloats("previousFrameWorldToClipMatrix", _previousWorldToClipMatrixFloats);
			_computeDataComputeShader.SetFloats("previousFrameSecondaryWorldToClipMatrix", _previousSecondaryWorldToClipMatrixFloats);
			_computeDataComputeShader.SetTexture(kernelId, "previousMaximumSliceAmountTexture", SliceTexture.WriteBuffer);
			_computeDataComputeShader.SetVector("cameraRanges", _frustumRanges);
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableVolumes))
			{
				_computeDataComputeShader.SetBool("useVolumes", val: true);
				_computeDataComputeShader.SetInt("volumeCount", _volumesManager.Buffer.count);
				_computeDataComputeShader.SetBuffer(kernelId, "volumeDataBuffer", _volumesManager.Buffer);
			}
			else
			{
				_computeDataComputeShader.SetBool("useVolumes", val: false);
				_computeDataComputeShader.SetInt("volumeCount", 0);
				_computeDataComputeShader.SetBuffer(kernelId, "volumeDataBuffer", _volumesManager.EmptyBuffer);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableVolumesTexture2DMask))
			{
				_computeDataComputeShader.SetBool("useTexture2DMasks", val: true);
				_computeDataComputeShader.SetTexture(kernelId, "texture2DMaskAtlasTexture", AuraCamera.CommonDataManager.VolumesCommonDataManager.Texture2DMasksAtlas);
			}
			else
			{
				_computeDataComputeShader.SetBool("useTexture2DMasks", val: false);
				_computeDataComputeShader.SetTexture(kernelId, "texture2DMaskAtlasTexture", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableVolumesTexture3DMask))
			{
				_computeDataComputeShader.SetBool("useTexture3DMasks", val: true);
				_computeDataComputeShader.SetVector("texture3DMaskAtlasTextureSize", AuraCamera.CommonDataManager.VolumesCommonDataManager.Texture3DMasksAtlas.GetSize().AsVector4(0f));
				_computeDataComputeShader.SetTexture(kernelId, "texture3DMaskAtlasTexture", AuraCamera.CommonDataManager.VolumesCommonDataManager.Texture3DMasksAtlas);
			}
			else
			{
				_computeDataComputeShader.SetBool("useTexture3DMasks", val: false);
				_computeDataComputeShader.SetVector("texture3DMaskAtlasTextureSize", Vector4.zero);
				_computeDataComputeShader.SetTexture(kernelId, "texture3DMaskAtlasTexture", Aura.ResourcesCollection.dummyTexture3D);
			}
			_computeDataComputeShader.SetBool("useVolumesNoise", _frustumSettingsToId.HasFlags(FrustumParameters.EnableVolumesNoiseMask));
			_computeDataComputeShader.SetBool("useAmbientLighting", _frustumSettingsToId.HasFlags(FrustumParameters.EnableAmbientLighting));
			_computeDataComputeShader.SetInt("ambientMode", (int)RenderSettings.ambientMode);
			_computeDataComputeShader.SetVector("ambientColorBottom", RenderSettings.ambientGroundColor);
			_computeDataComputeShader.SetVector("ambientColorHorizon", (RenderSettings.ambientMode == AmbientMode.Trilight) ? RenderSettings.ambientEquatorColor : RenderSettings.ambientLight);
			_computeDataComputeShader.SetVector("ambientColorTop", RenderSettings.ambientSkyColor);
			_computeDataComputeShader.SetVector("ambientShAr", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.firstBandCoefficients.shAr);
			_computeDataComputeShader.SetVector("ambientShAb", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.firstBandCoefficients.shAb);
			_computeDataComputeShader.SetVector("ambientShAg", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.firstBandCoefficients.shAg);
			_computeDataComputeShader.SetVector("ambientShBr", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.shBr);
			_computeDataComputeShader.SetVector("ambientShBg", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.shBg);
			_computeDataComputeShader.SetVector("ambientShBb", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.shBb);
			_computeDataComputeShader.SetVector("ambientShC", AuraCamera.CommonDataManager.AmbientLightingCommonDataManager.Coefficients.shC);
			_computeDataComputeShader.SetFloat("ambientLightingFactor", _frustumSettings.BaseSettings.ambientLightingStrength * AmbientLightingCommonDataManager.GlobalStrength);
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableLightProbes))
			{
				_lightProbesCoefficientsTextureSizeVector = Vector3Extensions.AsVector4(WorkingBuffers.LightProbesCoefficientsTextureResolution, 1f);
				_lightProbesCoefficientsTextureHalfTexelSize = _lightProbesCoefficientsTextureSizeVector.GetReciproqual() * 0.5f;
				for (int i = 0; i < WorkingBuffers.LightProbesCoefficientsTextureResolution.x; i++)
				{
					float x = (float)i / (_lightProbesCoefficientsTextureSizeVector.x - 1f);
					for (int j = 0; j < WorkingBuffers.LightProbesCoefficientsTextureResolution.y; j++)
					{
						float y = (float)j / (_lightProbesCoefficientsTextureSizeVector.y - 1f);
						for (int k = 0; k < WorkingBuffers.LightProbesCoefficientsTextureResolution.z; k++)
						{
							float num5 = ((float)k + 1f) / _lightProbesCoefficientsTextureSizeVector.z;
							num5 = 1f - Mathf.Pow(1f - num5, _frustumSettings.QualitySettings.depthBiasCoefficient);
							int num6 = k * WorkingBuffers.LightProbesCoefficientsTextureResolution.x * WorkingBuffers.LightProbesCoefficientsTextureResolution.y + j * WorkingBuffers.LightProbesCoefficientsTextureResolution.x + i;
							Vector3 vector = _cameraComponent.ViewportToWorldPoint(new Vector3(x, y, num5 * _frustumSettings.QualitySettings.farClipPlaneDistance));
							bool flag3 = false;
							for (int l = 0; l < AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisteredLightProbesProxyVolumesList.Count; l++)
							{
								if (!Mathf.Approximately(AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisteredLightProbesProxyVolumesList[l].lightProbesMultiplier, 0f) && AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisteredLightProbesProxyVolumesList[l].Bounds.Contains(vector))
								{
									flag3 = true;
									break;
								}
							}
							if (flag3)
							{
								LightProbes.GetInterpolatedProbe(vector, null, out var probe);
								WorkingBuffers.LightProbesCoefficients[num6] = probe.RepackFirstBandForShaders();
							}
						}
					}
				}
				WorkingBuffers.LightProbesCoefficientsComputeBuffer.SetData(WorkingBuffers.LightProbesCoefficients);
				_renderLightProbesTextureComputeShader.SetTexture(0, "lightProbesCoefficientsTexture", WorkingBuffers.LightProbesCoefficientsTexture);
				_renderLightProbesTextureComputeShader.SetVector("lightProbesCoefficientsTextureSize", _lightProbesCoefficientsTextureSizeVector);
				_renderLightProbesTextureComputeShader.SetBuffer(0, "lightProbesCoefficientsBuffer", WorkingBuffers.LightProbesCoefficientsComputeBuffer);
				_renderLightProbesTextureComputeShader.Dispatch(0, WorkingBuffers.LightProbesCoefficientsTextureResolution.x, WorkingBuffers.LightProbesCoefficientsTextureResolution.y, WorkingBuffers.LightProbesCoefficientsTextureResolution.z);
				_computeDataComputeShader.SetBool("useLightProbes", val: true);
				_computeDataComputeShader.SetTexture(kernelId, "lightProbesCoefficientsTexture", WorkingBuffers.LightProbesCoefficientsTexture);
				_computeDataComputeShader.SetVector("lightProbesCoefficientsTextureHalfTexelSize", _lightProbesCoefficientsTextureHalfTexelSize);
			}
			else
			{
				if (_previousLightProbesState)
				{
					WorkingBuffers.ReleaseAllLightProbesBuffers();
				}
				_computeDataComputeShader.SetBool("useLightProbes", val: false);
				_computeDataComputeShader.SetTexture(kernelId, "lightProbesCoefficientsTexture", Aura.ResourcesCollection.dummyTexture3D);
				_computeDataComputeShader.SetVector("lightProbesCoefficientsTextureHalfTexelSize", Vector4.one);
			}
			_computeDataComputeShader.SetBool("useLightsCookies", _frustumSettingsToId.HasFlags(FrustumParameters.EnableLightsCookies));
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableDirectionalLights))
			{
				_computeDataComputeShader.SetBool("useDirectionalLights", val: true);
				_computeDataComputeShader.SetInt("directionalLightCount", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalLightsManager.DataBuffer.count);
				_computeDataComputeShader.SetBuffer(kernelId, "directionalLightDataBuffer", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalLightsManager.DataBuffer);
			}
			else
			{
				_computeDataComputeShader.SetBool("useDirectionalLights", val: false);
				_computeDataComputeShader.SetInt("directionalLightCount", 0);
				_computeDataComputeShader.SetBuffer(kernelId, "directionalLightDataBuffer", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalLightsManager.EmptyBuffer);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableDirectionalLightsShadows))
			{
				_computeDataComputeShader.SetBool("useDirectionalLightsShadows", val: true);
				_computeDataComputeShader.SetTexture(kernelId, "directionalShadowMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalShadowMapsArray);
				_computeDataComputeShader.SetTexture(kernelId, "directionalShadowDataArray", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalShadowDataArray);
			}
			else
			{
				_computeDataComputeShader.SetBool("useDirectionalLightsShadows", val: false);
				_computeDataComputeShader.SetTexture(kernelId, "directionalShadowMapsArray", Aura.ResourcesCollection.dummyTextureArray);
				_computeDataComputeShader.SetTexture(kernelId, "directionalShadowDataArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableLightsCookies) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasDirectionalCookieCasters)
			{
				_computeDataComputeShader.SetTexture(kernelId, "directionalCookieMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalCookieMapsArray);
			}
			else
			{
				_computeDataComputeShader.SetTexture(kernelId, "directionalCookieMapsArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableSpotLights))
			{
				_computeDataComputeShader.SetBool("useSpotLights", val: true);
				_computeDataComputeShader.SetInt("spotLightCount", _spotLightsManager.Buffer.count);
				_computeDataComputeShader.SetBuffer(kernelId, "spotLightDataBuffer", _spotLightsManager.Buffer);
			}
			else
			{
				_computeDataComputeShader.SetBool("useSpotLights", val: false);
				_computeDataComputeShader.SetInt("spotLightCount", 0);
				_computeDataComputeShader.SetBuffer(kernelId, "spotLightDataBuffer", _spotLightsManager.EmptyBuffer);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableSpotLightsShadows))
			{
				_computeDataComputeShader.SetBool("useSpotLightsShadows", val: true);
				_computeDataComputeShader.SetTexture(kernelId, "spotShadowMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.SpotShadowMapsArray);
			}
			else
			{
				_computeDataComputeShader.SetBool("useSpotLightsShadows", val: false);
				_computeDataComputeShader.SetTexture(kernelId, "spotShadowMapsArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableLightsCookies) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasSpotCookieCasters)
			{
				_computeDataComputeShader.SetTexture(kernelId, "spotCookieMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.SpotCookieMapsArray);
			}
			else
			{
				_computeDataComputeShader.SetTexture(kernelId, "spotCookieMapsArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnablePointLights))
			{
				_computeDataComputeShader.SetBool("usePointLights", val: true);
				_computeDataComputeShader.SetInt("pointLightCount", _pointLightsManager.Buffer.count);
				_computeDataComputeShader.SetBuffer(kernelId, "pointLightDataBuffer", _pointLightsManager.Buffer);
			}
			else
			{
				_computeDataComputeShader.SetBool("usePointLights", val: false);
				_computeDataComputeShader.SetInt("pointLightCount", 0);
				_computeDataComputeShader.SetBuffer(kernelId, "pointLightDataBuffer", _pointLightsManager.EmptyBuffer);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnablePointLightsShadows))
			{
				_computeDataComputeShader.SetBool("usePointLightsShadows", val: true);
				_computeDataComputeShader.SetTexture(kernelId, "pointShadowMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.PointShadowMapsArray);
			}
			else
			{
				_computeDataComputeShader.SetBool("usePointLightsShadows", val: false);
				_computeDataComputeShader.SetTexture(kernelId, "pointShadowMapsArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableLightsCookies) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasPointCookieCasters)
			{
				_computeDataComputeShader.SetTexture(kernelId, "pointCookieMapsArray", AuraCamera.CommonDataManager.LightsCommonDataManager.PointCookieMapsArray);
			}
			else
			{
				_computeDataComputeShader.SetTexture(kernelId, "pointCookieMapsArray", Aura.ResourcesCollection.dummyTextureArray);
			}
			_computeDataComputeShader.SetBuffer(kernelId, "visibleCellsAmountBuffer", _dispatchBuffers[0]);
			_computeDataComputeShader.SetBuffer(kernelId, "dispatchSizeBuffer", _dispatchBuffers[1]);
			_computeDataComputeShader.SetBuffer(kernelId, "visibleCellsBuffer", _dispatchBuffers[5]);
			_computeDataComputeShader.SetFloat("densityFactor", 0.0625f);
			_computeDataComputeShader.DispatchIndirect(kernelId, _dispatchBuffers[1]);
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableDenoisingFilter))
			{
				DataVolumeTexture.Swap();
				kernelId = (int)_frustumSettings.QualitySettings.EXPERIMENTAL_denoisingFilterRange;
				_applyMedianFilterComputeShader.SetBuffer(kernelId, "visibleCellsAmountBuffer", _dispatchBuffers[0]);
				_applyMedianFilterComputeShader.SetBuffer(kernelId, "dispatchSizeBuffer", _dispatchBuffers[1]);
				_applyMedianFilterComputeShader.SetBuffer(kernelId, "visibleCellsBuffer", _dispatchBuffers[5]);
				_applyMedianFilterComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
				_applyMedianFilterComputeShader.SetTexture(kernelId, "sourceTexture", DataVolumeTexture.ReadBuffer);
				_applyMedianFilterComputeShader.SetTexture(kernelId, "destinationTexture", DataVolumeTexture.WriteBuffer);
				_applyMedianFilterComputeShader.DispatchIndirect(kernelId, _dispatchBuffers[1]);
			}
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableBlurFilter))
			{
				DataVolumeTexture.Swap();
				kernelId = (int)((int)_frustumSettings.QualitySettings.EXPERIMENTAL_blurFilterType * 3 + _frustumSettings.QualitySettings.EXPERIMENTAL_blurFilterRange);
				_applyBlurFilterComputeShader.SetBuffer(kernelId, "visibleCellsAmountBuffer", _dispatchBuffers[0]);
				_applyBlurFilterComputeShader.SetBuffer(kernelId, "dispatchSizeBuffer", _dispatchBuffers[1]);
				_applyBlurFilterComputeShader.SetBuffer(kernelId, "visibleCellsBuffer", _dispatchBuffers[5]);
				_applyBlurFilterComputeShader.SetVector("Aura_BufferResolution", BufferResolutionVector);
				_applyBlurFilterComputeShader.SetVector("Aura_BufferTexelSize", BufferTexelSizeVector);
				_applyBlurFilterComputeShader.SetTexture(kernelId, "sourceTexture", DataVolumeTexture.ReadBuffer);
				_applyBlurFilterComputeShader.SetTexture(kernelId, "destinationTexture", DataVolumeTexture.WriteBuffer);
				_applyBlurFilterComputeShader.SetFloat("gaussianDeviation", _frustumSettings.QualitySettings.EXPERIMENTAL_blurFilterGaussianDeviation);
				_applyBlurFilterComputeShader.DispatchIndirect(kernelId, _dispatchBuffers[1]);
			}
			Shader.SetGlobalTexture("Aura_VolumetricDataTexture", DataVolumeTexture.WriteBuffer);
			kernelId = ((_cameraComponent.GetCameraStereoMode() == StereoMode.SinglePass) ? 1 : 0) + (_frustumSettings.QualitySettings.debugOcclusionCulling ? 2 : 0) + (flag2 ? 4 : 0);
			_computeAccumulationComputeShader.SetTexture(kernelId, "maximumSliceAmountTexture", flag2 ? ((Texture)SliceTexture.ReadBuffer) : ((Texture)Aura.ResourcesCollection.dummyTexture));
			_computeAccumulationComputeShader.SetVector("cameraPosition", _cameraComponent.transform.position);
			_computeAccumulationComputeShader.SetTexture(kernelId, "lightingTexture", DataVolumeTexture.WriteBuffer);
			_computeAccumulationComputeShader.SetFloat("extinction", num4);
			_computeAccumulationComputeShader.SetTexture(kernelId, "fogVolumeTexture", FogVolumeTexture);
			_computeAccumulationComputeShader.DispatchIndirect(kernelId, _dispatchBuffers[3]);
			if (_frustumSettingsToId.HasFlags(FrustumParameters.EnableTemporalReprojection))
			{
				if (_cameraComponent.GetCameraStereoMode() == StereoMode.SinglePass)
				{
					_cameraComponent.ResetStereoProjectionMatrices();
					_cameraComponent.GetWorldToClipMatrix(Camera.MonoOrStereoscopicEye.Left, _frustumRanges.x, _frustumRanges.y, ref _previousWorldToClipMatrix);
					_cameraComponent.GetWorldToClipMatrix(Camera.MonoOrStereoscopicEye.Right, _frustumRanges.x, _frustumRanges.y, ref _previousSecondaryWorldToClipMatrix);
					_previousSecondaryWorldToClipMatrix.ToFloatArray(ref _previousSecondaryWorldToClipMatrixFloats);
				}
				else
				{
					_cameraComponent.GetWorldToClipMatrix(Camera.MonoOrStereoscopicEye.Mono, _frustumRanges.x, _frustumRanges.y, ref _previousWorldToClipMatrix);
				}
				_previousWorldToClipMatrix.ToFloatArray(ref _previousWorldToClipMatrixFloats);
			}
			_previousOcclusionCullingState = _frustumSettingsToId.HasFlags(FrustumParameters.EnableOcclusionCulling);
			_previousLightProbesState = _frustumSettingsToId.HasFlags(FrustumParameters.EnableLightProbes);
		}

		public void Dispose()
		{
			ReleaseComputeBuffers();
			WorkingBuffers.ReleaseAllBuffers();
			DisposeManagers();
			_frustumSettings.OnFrustumQualityChanged -= _frustumSettings_OnFrustumQualityChanged;
		}

		private void DisposeManagers()
		{
			_volumesManager.Dispose();
			_volumesManager = null;
			_spotLightsManager.Dispose();
			_spotLightsManager = null;
			_pointLightsManager.Dispose();
			_pointLightsManager = null;
		}

		public void SetFrustumGridResolution(Vector3Int frustumGridResolution)
		{
			_computeDataComputeShader.GetKernelThreadGroupSizes(0, out _threadSizeX, out _threadSizeY, out _threadSizeZ);
			frustumGridResolution.x = frustumGridResolution.x.SnapMin((int)_threadSizeX);
			frustumGridResolution.y = frustumGridResolution.y.SnapMin((int)_threadSizeY);
			frustumGridResolution.z = frustumGridResolution.z.SnapMin((int)_threadSizeZ);
			_frustumSettings.QualitySettings.frustumGridResolution = frustumGridResolution;
			_frustumGridResolution = _frustumSettings.QualitySettings.GetFrustumGridResolution(_cameraComponent);
			_bufferResolutionVector = Vector3Extensions.AsVector4(_frustumGridResolution, 1f);
			_bufferTexelSizeVector = _bufferResolutionVector.GetReciproqual();
			WorkingBuffers.VolumetricBuffersResolution = _frustumGridResolution;
			ComputeDispatchSizes();
			if (_dispatchBuffers[5] != null)
			{
				ReleaseComputeBuffer(5);
			}
			_dispatchBuffers[5] = new ComputeBuffer(FrustumGridResolution.x * FrustumGridResolution.y * FrustumGridResolution.z, VisibleCellData.Size, ComputeBufferType.Append);
		}

		private void ComputeDispatchSizes()
		{
			Vector3Int frustumGridResolution = FrustumGridResolution;
			uint[] array = new uint[3]
			{
				(uint)(frustumGridResolution.x / (int)_threadSizeX),
				(uint)(frustumGridResolution.y / (int)_threadSizeY),
				(uint)(frustumGridResolution.z / (int)_threadSizeZ)
			};
			_dispatchBuffers[1].SetData(array);
			array[2] = 1u;
			_dispatchBuffers[3].SetData(array);
			array[0] = (uint)frustumGridResolution.x;
			array[1] = (uint)frustumGridResolution.y;
			_dispatchBuffers[2].SetData(array);
			array = new uint[1] { (uint)(frustumGridResolution.x * frustumGridResolution.y * frustumGridResolution.z) };
			_dispatchBuffers[0].SetData(array);
		}

		private void InitializeComputeBuffers()
		{
			_dispatchBuffers = new ComputeBuffer[6];
			_dispatchBuffers[0] = new ComputeBuffer(1, 4, ComputeBufferType.Raw);
			_dispatchBuffers[1] = new ComputeBuffer(3, 4, ComputeBufferType.DrawIndirect);
			_dispatchBuffers[2] = new ComputeBuffer(3, 4, ComputeBufferType.DrawIndirect);
			_dispatchBuffers[3] = new ComputeBuffer(3, 4, ComputeBufferType.DrawIndirect);
			_dispatchBuffers[4] = new ComputeBuffer(3, 4, ComputeBufferType.DrawIndirect);
			uint[] data = new uint[3] { 1u, 1u, 1u };
			_dispatchBuffers[4].SetData(data);
		}

		private void ReleaseComputeBuffer(int index)
		{
			_dispatchBuffers[index].Dispose();
			_dispatchBuffers[index] = null;
		}

		private void ReleaseComputeBuffers()
		{
			for (int i = 0; i < _dispatchBuffers.Length; i++)
			{
				ReleaseComputeBuffer(i);
			}
		}
	}
}
