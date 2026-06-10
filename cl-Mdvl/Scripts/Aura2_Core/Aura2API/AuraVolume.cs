using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	[AddComponentMenu("Aura 2/Aura Volume", 2)]
	[ExecuteInEditMode]
	public class AuraVolume : CullableObject
	{
		[SerializeField]
		public VolumeInjectionShape volumeShape;

		public bool useAsLightProbesProxyVolume;

		public float lightProbesMultiplier = 1f;

		public Texture2DMask texture2DMask;

		public Texture3DMask texture3DMask;

		public DynamicNoiseParameters noiseMask;

		public VolumeInjectionCommonParameters densityInjection;

		public VolumeInjectionCommonParameters scatteringInjection;

		public VolumeInjectionColorParameters lightInjection;

		public VolumeInjectionColorParameters tintInjection;

		public VolumeInjectionCommonParameters ambientInjection;

		public VolumeInjectionCommonParameters boostInjection;

		private VolumeData _volumeData;

		private bool _isInitialized;

		private Bounds _bounds;

		private bool _previousUseAsLightProbesProxyVolume;

		private bool _previousTexture2DMaskUsage;

		private Texture2D _previousTexture2DMask;

		private bool _previousTexture3DMaskUsage;

		private Texture3D _previousTexture3DMask;

		public Bounds Bounds
		{
			get
			{
				if (base.transform.hasChanged)
				{
					_bounds = new Bounds(base.BoundingSphere.position, Vector3.zero);
					switch (volumeShape.shape)
					{
					default:
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, -0.5f, -0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, 0.5f, -0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, 0.5f, -0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, -0.5f, -0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, -0.5f, 0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, 0.5f, 0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, 0.5f, 0.5f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, -0.5f, 0.5f)));
						break;
					case VolumeType.Global:
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, -0.5f, -0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, 0.5f, -0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, 0.5f, -0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, -0.5f, -0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, -0.5f, 0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, 0.5f, 0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, 0.5f, 0.5f) * 2f));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, -0.5f, 0.5f) * 2f));
						break;
					case VolumeType.Layer:
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0f, 0f, 0f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0f, 1f, 0f)));
						break;
					case VolumeType.Cone:
						_bounds.Encapsulate(base.transform.position);
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(Vector3.forward));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, -0.5f, 1f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(-0.5f, 0.5f, 1f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, 0.5f, 1f)));
						_bounds.Encapsulate(base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(0.5f, -0.5f, 1f)));
						break;
					}
					base.transform.hasChanged = false;
				}
				return _bounds;
			}
		}

		public bool UsesTexture2DMasking
		{
			get
			{
				if (texture2DMask.enable)
				{
					return texture2DMask.texture != null;
				}
				return false;
			}
		}

		public bool ShoukdComputeTexture2DMasking
		{
			get
			{
				if (UsesTexture2DMasking)
				{
					if ((!densityInjection.enable || !densityInjection.useTexture2DMask) && (!scatteringInjection.enable || !scatteringInjection.useTexture2DMask) && (!lightInjection.injectionParameters.enable || !lightInjection.injectionParameters.useTexture2DMask))
					{
						if (tintInjection.injectionParameters.enable)
						{
							return tintInjection.injectionParameters.useTexture2DMask;
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public bool UsesTexture3DMasking
		{
			get
			{
				if (texture3DMask.enable)
				{
					return texture3DMask.texture != null;
				}
				return false;
			}
		}

		public bool ShouldComputeTexture3DMasking
		{
			get
			{
				if (UsesTexture3DMasking)
				{
					if ((!densityInjection.enable || !densityInjection.useTexture3DMask) && (!scatteringInjection.enable || !scatteringInjection.useTexture3DMask) && (!lightInjection.injectionParameters.enable || !lightInjection.injectionParameters.useTexture3DMask))
					{
						if (tintInjection.injectionParameters.enable)
						{
							return tintInjection.injectionParameters.useTexture3DMask;
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public bool ShouldComputeNoise
		{
			get
			{
				if (noiseMask.enable)
				{
					if ((!densityInjection.enable || !densityInjection.useNoiseMask) && (!scatteringInjection.enable || !scatteringInjection.useNoiseMask) && (!lightInjection.injectionParameters.enable || !lightInjection.injectionParameters.useNoiseMask))
					{
						if (tintInjection.injectionParameters.enable)
						{
							return tintInjection.injectionParameters.useNoiseMask;
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsActive { get; private set; }

		public event Action<AuraVolume> OnUninitialize;

		private void OnEnable()
		{
			if (!Aura.IsCompatible)
			{
				base.enabled = false;
			}
			else
			{
				Initialize();
			}
		}

		private void Update()
		{
			if (useAsLightProbesProxyVolume != _previousUseAsLightProbesProxyVolume || UsesTexture2DMasking != _previousTexture2DMaskUsage || texture2DMask.texture != _previousTexture2DMask || UsesTexture3DMasking != _previousTexture3DMaskUsage || texture3DMask.texture != _previousTexture3DMask)
			{
				Reinitialize();
			}
		}

		private void OnDisable()
		{
			Uninitialize();
		}

		private void Reset()
		{
			SetDefaultValues(this);
		}

		private void Initialize()
		{
			AuraCamera.OnRegisteredAuraCamerasListChanged += AuraCamera_OnRegistredAuraCamerasListChanged;
			IsActive = AuraCamera.HasRegisteredAuraCameras;
			if (IsActive)
			{
				AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisterVolume(this);
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
				_volumeData = default(VolumeData);
				_previousUseAsLightProbesProxyVolume = useAsLightProbesProxyVolume;
				_previousTexture2DMaskUsage = UsesTexture2DMasking;
				_previousTexture2DMask = texture2DMask.texture;
				_previousTexture3DMaskUsage = UsesTexture3DMasking;
				_previousTexture3DMask = texture3DMask.texture;
				_isInitialized = true;
			}
		}

		private void Uninitialize()
		{
			AuraCamera.OnRegisteredAuraCamerasListChanged -= AuraCamera_OnRegistredAuraCamerasListChanged;
			if (_isInitialized)
			{
				if (this.OnUninitialize != null)
				{
					this.OnUninitialize(this);
				}
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
				_isInitialized = false;
			}
		}

		private void Reinitialize()
		{
			Uninitialize();
			Initialize();
		}

		private void AuraCamera_OnRegistredAuraCamerasListChanged()
		{
			if ((!IsActive && AuraCamera.HasRegisteredAuraCameras) || (IsActive && !AuraCamera.HasRegisteredAuraCameras))
			{
				Reinitialize();
			}
		}

		private void Camera_onPreCull(Camera camera)
		{
			if (IsActive && AuraCamera.IsFirstRegisteredCamera(camera))
			{
				if (this == null)
				{
					Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(Camera_onPreCull));
				}
				else
				{
					UpdateBoundingSphere();
				}
			}
		}

		private void Camera_onPreRender(Camera camera)
		{
			if (IsActive && AuraCamera.IsFirstRegisteredCamera(camera))
			{
				if (this == null)
				{
					Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
				}
				else
				{
					PackData();
				}
			}
		}

		private void PackData()
		{
			_volumeData.transform = MatrixFloats.ToMatrixFloats(base.transform.worldToLocalMatrix);
			_volumeData.shape = (int)volumeShape.shape;
			_volumeData.falloffExponent = volumeShape.fading.falloffExponent;
			switch (volumeShape.shape)
			{
			case VolumeType.Box:
				_volumeData.xPositiveFade = volumeShape.fading.xPositiveCubeFade;
				_volumeData.xNegativeFade = volumeShape.fading.xNegativeCubeFade;
				_volumeData.yPositiveFade = volumeShape.fading.yPositiveCubeFade;
				_volumeData.yNegativeFade = volumeShape.fading.yNegativeCubeFade;
				_volumeData.zPositiveFade = volumeShape.fading.zPositiveCubeFade;
				_volumeData.zNegativeFade = volumeShape.fading.zNegativeCubeFade;
				break;
			case VolumeType.Cone:
				_volumeData.xPositiveFade = volumeShape.fading.angularConeFade;
				_volumeData.zPositiveFade = volumeShape.fading.distanceConeFade;
				break;
			case VolumeType.Cylinder:
				_volumeData.xPositiveFade = volumeShape.fading.widthCylinderFade;
				_volumeData.yPositiveFade = volumeShape.fading.yPositiveCylinderFade;
				_volumeData.yNegativeFade = volumeShape.fading.yNegativeCylinderFade;
				break;
			case VolumeType.Sphere:
				_volumeData.xPositiveFade = volumeShape.fading.distanceSphereFade;
				break;
			}
			_volumeData.useAsLightProbesProxyVolume = (useAsLightProbesProxyVolume ? 1 : 0);
			_volumeData.lightProbesMultiplier = lightProbesMultiplier * MathF.PI;
			if (ShoukdComputeTexture2DMasking)
			{
				Matrix4x4 inverse = texture2DMask.transform.Matrix.inverse;
				_volumeData.texture2DMaskData.transform = MatrixFloats.ToMatrixFloats((noiseMask.transform.space == Space.Self) ? (inverse * base.transform.worldToLocalMatrix) : inverse);
			}
			_volumeData.texture2DMaskData.index = texture2DMask.textureIndex;
			if (ShouldComputeTexture3DMasking)
			{
				Matrix4x4 inverse2 = texture3DMask.transform.Matrix.inverse;
				_volumeData.texture3DMaskData.transform = MatrixFloats.ToMatrixFloats((noiseMask.transform.space == Space.Self) ? (inverse2 * base.transform.worldToLocalMatrix) : inverse2);
			}
			_volumeData.texture3DMaskData.index = texture3DMask.textureIndex;
			_volumeData.noiseData.enable = (ShouldComputeNoise ? 1 : 0);
			if (ShouldComputeNoise)
			{
				Matrix4x4 inverse3 = noiseMask.transform.Matrix.inverse;
				_volumeData.noiseData.transform = MatrixFloats.ToMatrixFloats((noiseMask.transform.space == Space.Self) ? (inverse3 * base.transform.worldToLocalMatrix) : inverse3);
				_volumeData.noiseData.speed = noiseMask.speed;
			}
			_volumeData.injectDensity = (densityInjection.enable ? 1 : 0);
			_volumeData.densityValue = densityInjection.strength;
			_volumeData.densityNoiseLevelsParameters = ((!densityInjection.useNoiseMask) ? LevelsParameters.One.Data : (densityInjection.useNoiseMaskLevels ? densityInjection.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.densityTexture2DMaskLevelsParameters = ((!densityInjection.useTexture2DMask) ? LevelsParameters.One.Data : (densityInjection.useTexture2DMaskLevels ? densityInjection.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.densityTexture3DMaskLevelsParameters = ((!densityInjection.useTexture3DMask) ? LevelsParameters.One.Data : (densityInjection.useTexture3DMaskLevels ? densityInjection.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.injectScattering = (scatteringInjection.enable ? 1 : 0);
			_volumeData.scatteringValue = scatteringInjection.strength;
			_volumeData.scatteringNoiseLevelsParameters = ((!scatteringInjection.useNoiseMask) ? LevelsParameters.One.Data : (scatteringInjection.useNoiseMaskLevels ? scatteringInjection.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.scatteringTexture2DMaskLevelsParameters = ((!scatteringInjection.useTexture2DMask) ? LevelsParameters.One.Data : (scatteringInjection.useTexture2DMaskLevels ? scatteringInjection.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.scatteringTexture3DMaskLevelsParameters = ((!scatteringInjection.useTexture3DMask) ? LevelsParameters.One.Data : (scatteringInjection.useTexture3DMaskLevels ? scatteringInjection.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.injectColor = (lightInjection.injectionParameters.enable ? 1 : 0);
			_volumeData.colorValue = (Vector4)(lightInjection.color * lightInjection.injectionParameters.strength);
			_volumeData.colorNoiseLevelsParameters = ((!lightInjection.injectionParameters.useNoiseMask) ? LevelsParameters.One.Data : (lightInjection.injectionParameters.useNoiseMaskLevels ? lightInjection.injectionParameters.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.colorTexture2DMaskLevelsParameters = ((!lightInjection.injectionParameters.useTexture2DMask) ? LevelsParameters.One.Data : (lightInjection.injectionParameters.useTexture2DMaskLevels ? lightInjection.injectionParameters.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.colorTexture3DMaskLevelsParameters = ((!lightInjection.injectionParameters.useTexture3DMask) ? LevelsParameters.One.Data : (lightInjection.injectionParameters.useTexture3DMaskLevels ? lightInjection.injectionParameters.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.injectTint = (tintInjection.injectionParameters.enable ? 1 : 0);
			_volumeData.tintColor = (Vector4)(tintInjection.color * tintInjection.injectionParameters.strength);
			_volumeData.tintNoiseLevelsParameters = ((!tintInjection.injectionParameters.useNoiseMask) ? LevelsParameters.One.Data : (tintInjection.injectionParameters.useNoiseMaskLevels ? tintInjection.injectionParameters.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.tintTexture2DMaskLevelsParameters = ((!tintInjection.injectionParameters.useTexture2DMask) ? LevelsParameters.One.Data : (tintInjection.injectionParameters.useTexture2DMaskLevels ? tintInjection.injectionParameters.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.tintTexture3DMaskLevelsParameters = ((!tintInjection.injectionParameters.useTexture3DMask) ? LevelsParameters.One.Data : (tintInjection.injectionParameters.useTexture3DMaskLevels ? tintInjection.injectionParameters.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.injectAmbient = (ambientInjection.enable ? 1 : 0);
			_volumeData.ambientLightingValue = ambientInjection.strength;
			_volumeData.ambientNoiseLevelsParameters = ((!ambientInjection.useNoiseMask) ? LevelsParameters.One.Data : (ambientInjection.useNoiseMaskLevels ? ambientInjection.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.ambientTexture2DMaskLevelsParameters = ((!ambientInjection.useTexture2DMask) ? LevelsParameters.One.Data : (ambientInjection.useTexture2DMaskLevels ? ambientInjection.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.ambientTexture3DMaskLevelsParameters = ((!ambientInjection.useTexture3DMask) ? LevelsParameters.One.Data : (ambientInjection.useTexture3DMaskLevels ? ambientInjection.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.injectBoost = (boostInjection.enable ? 1 : 0);
			_volumeData.boostValue = boostInjection.strength;
			_volumeData.boostNoiseLevelsParameters = ((!boostInjection.useNoiseMask) ? LevelsParameters.One.Data : (boostInjection.useNoiseMaskLevels ? boostInjection.noiseMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.boostTexture2DMaskLevelsParameters = ((!boostInjection.useTexture2DMask) ? LevelsParameters.One.Data : (boostInjection.useTexture2DMaskLevels ? boostInjection.texture2DMaskLevelParameters.Data : LevelsParameters.Default.Data));
			_volumeData.boostTexture3DMaskLevelsParameters = ((!boostInjection.useTexture3DMask) ? LevelsParameters.One.Data : (boostInjection.useTexture3DMaskLevels ? boostInjection.texture3DMaskLevelParameters.Data : LevelsParameters.Default.Data));
		}

		public VolumeData GetData()
		{
			return _volumeData;
		}

		private float GetRadiusFromScale()
		{
			return base.transform.localScale.magnitude;
		}

		private void UpdateBoundingSphere()
		{
			Vector3 position = base.transform.position;
			float radius = float.MaxValue;
			switch (volumeShape.shape)
			{
			case VolumeType.Box:
				radius = GetRadiusFromScale() * 0.5f;
				break;
			case VolumeType.Sphere:
				radius = Mathf.Max(Mathf.Abs(base.transform.localScale.x), Mathf.Max(Mathf.Abs(base.transform.localScale.y), Mathf.Abs(base.transform.localScale.z))) * 0.5f;
				break;
			case VolumeType.Cylinder:
				radius = GetRadiusFromScale() * 0.5f;
				break;
			case VolumeType.Cone:
				position += base.transform.forward * base.transform.localScale.z * 0.5f;
				radius = GetRadiusFromScale() * 0.5f;
				break;
			}
			UpdateBoundingSphere(position, radius);
		}

		private static void SetDefaultValues(AuraVolume auraVolume)
		{
			auraVolume.volumeShape.fading.falloffExponent = 3f;
			auraVolume.volumeShape.fading.xPositiveCubeFade = 0.25f;
			auraVolume.volumeShape.fading.xNegativeCubeFade = 0.25f;
			auraVolume.volumeShape.fading.yPositiveCubeFade = 0.25f;
			auraVolume.volumeShape.fading.yNegativeCubeFade = 0.25f;
			auraVolume.volumeShape.fading.zPositiveCubeFade = 0.25f;
			auraVolume.volumeShape.fading.zNegativeCubeFade = 0.25f;
			auraVolume.volumeShape.fading.angularConeFade = 0.5f;
			auraVolume.volumeShape.fading.distanceConeFade = 0.5f;
			auraVolume.volumeShape.fading.widthCylinderFade = 0.5f;
			auraVolume.volumeShape.fading.yNegativeCylinderFade = 0.25f;
			auraVolume.volumeShape.fading.yPositiveCylinderFade = 0.25f;
			auraVolume.volumeShape.fading.distanceSphereFade = 0.5f;
			auraVolume.texture2DMask.SetDefaultValues();
			auraVolume.texture3DMask.SetDefaultValues();
			auraVolume.noiseMask.speed = 0.125f;
			auraVolume.noiseMask.transform.scale = Vector3.one * 5f;
			auraVolume.densityInjection.useNoiseMask = true;
			auraVolume.densityInjection.useNoiseMaskLevels = true;
			auraVolume.densityInjection.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.densityInjection.noiseMaskLevelParameters.contrast = 5f;
			auraVolume.densityInjection.useTexture2DMask = true;
			auraVolume.densityInjection.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.densityInjection.useTexture3DMask = true;
			auraVolume.densityInjection.texture3DMaskLevelParameters.SetDefaultValues();
			auraVolume.densityInjection.enable = true;
			auraVolume.densityInjection.strength = 5f;
			auraVolume.scatteringInjection.useNoiseMask = true;
			auraVolume.scatteringInjection.useNoiseMaskLevels = true;
			auraVolume.scatteringInjection.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.scatteringInjection.noiseMaskLevelParameters.contrast = 3f;
			auraVolume.scatteringInjection.noiseMaskLevelParameters.outputLowValue = -1f;
			auraVolume.scatteringInjection.useTexture2DMask = true;
			auraVolume.scatteringInjection.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.scatteringInjection.texture2DMaskLevelParameters.outputLowValue = -1f;
			auraVolume.scatteringInjection.useTexture3DMask = true;
			auraVolume.scatteringInjection.texture3DMaskLevelParameters.SetDefaultValues();
			auraVolume.scatteringInjection.texture3DMaskLevelParameters.outputLowValue = -1f;
			auraVolume.scatteringInjection.strength = 0.25f;
			auraVolume.lightInjection.injectionParameters.useNoiseMask = true;
			auraVolume.lightInjection.injectionParameters.useNoiseMaskLevels = true;
			auraVolume.lightInjection.injectionParameters.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.lightInjection.injectionParameters.noiseMaskLevelParameters.contrast = 5f;
			auraVolume.lightInjection.injectionParameters.useTexture2DMask = true;
			auraVolume.lightInjection.injectionParameters.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.lightInjection.injectionParameters.useTexture3DMask = true;
			auraVolume.lightInjection.injectionParameters.texture3DMaskLevelParameters.SetDefaultValues();
			auraVolume.lightInjection.injectionParameters.strength = 1f;
			auraVolume.lightInjection.color = Color.white;
			auraVolume.tintInjection.injectionParameters.useNoiseMask = true;
			auraVolume.tintInjection.injectionParameters.useNoiseMaskLevels = true;
			auraVolume.tintInjection.injectionParameters.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.tintInjection.injectionParameters.noiseMaskLevelParameters.contrast = 5f;
			auraVolume.tintInjection.injectionParameters.useTexture2DMask = true;
			auraVolume.tintInjection.injectionParameters.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.tintInjection.injectionParameters.useTexture3DMask = true;
			auraVolume.tintInjection.injectionParameters.texture3DMaskLevelParameters.SetDefaultValues();
			auraVolume.tintInjection.injectionParameters.strength = 1f;
			auraVolume.tintInjection.color = Color.white;
			auraVolume.ambientInjection.strength = 1f;
			auraVolume.ambientInjection.useNoiseMask = true;
			auraVolume.ambientInjection.useNoiseMaskLevels = true;
			auraVolume.ambientInjection.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.ambientInjection.noiseMaskLevelParameters.contrast = 5f;
			auraVolume.ambientInjection.useTexture2DMask = true;
			auraVolume.ambientInjection.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.ambientInjection.useTexture3DMask = true;
			auraVolume.ambientInjection.texture3DMaskLevelParameters.SetDefaultValues();
			auraVolume.boostInjection.strength = 1f;
			auraVolume.boostInjection.useNoiseMask = true;
			auraVolume.boostInjection.useNoiseMaskLevels = true;
			auraVolume.boostInjection.noiseMaskLevelParameters.SetDefaultValues();
			auraVolume.boostInjection.noiseMaskLevelParameters.contrast = 5f;
			auraVolume.boostInjection.useTexture2DMask = true;
			auraVolume.boostInjection.texture2DMaskLevelParameters.SetDefaultValues();
			auraVolume.boostInjection.useTexture3DMask = true;
			auraVolume.boostInjection.texture3DMaskLevelParameters.SetDefaultValues();
		}

		public static GameObject CreateGameObject(string name, VolumeType shape)
		{
			GameObject obj = new GameObject(name);
			obj.transform.localScale = Vector3.one * 3f;
			AuraVolume auraVolume = obj.AddComponent<AuraVolume>();
			auraVolume.volumeShape.shape = shape;
			SetDefaultValues(auraVolume);
			return obj;
		}
	}
}
