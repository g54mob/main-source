using UnityEngine;

namespace GPUInstancerPro
{
	[CreateAssetMenu(menuName = "Rendering/GPU Instancer Pro/Profile", order = 511)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#Profile_Settings")]
	public class GPUIProfile : ScriptableObject, IGPUIParameterBufferData
	{
		public enum DepthSortMode
		{
			None = 0,
			FrontToBack = 1,
			BackToFront = 2
		}

		public bool isShadowCasting = true;

		public bool isDistanceCulling = true;

		public bool isFrustumCulling = true;

		public bool isOcclusionCulling = true;

		public bool isShadowFrustumCulling;

		public bool isShadowOcclusionCulling;

		public bool isShadowDistanceCulling = true;

		public bool isLODCrossFade;

		public bool isAnimateCrossFade = true;

		public bool isOverrideShadowLayer;

		public bool isCalculateInstancingBounds;

		[Range(0f, 100f)]
		public float minCullingDistance;

		[Range(0f, 100f)]
		public float minShadowCullingDistance = 20f;

		public Vector2 minMaxDistance = new Vector2(0f, 500f);

		[Range(0f, 10f)]
		public float frustumOffset = 0.01f;

		[Range(0f, 0.01f)]
		public float occlusionOffset = 0.0001f;

		[Range(0f, 5f)]
		public float occlusionOffsetSizeMultiplier;

		[Range(0f, 100f)]
		public float shadowFrustumOffset = 10f;

		[Range(0f, 0.01f)]
		public float shadowOcclusionOffset = 0.001f;

		[Range(0f, 5f)]
		public float shadowOcclusionOffsetSizeMultiplier = 0.5f;

		[Range(1f, 3f)]
		public int occlusionAccuracy = 1;

		public Vector3 boundsOffset;

		[Range(0.01f, 10f)]
		public float lodBiasAdjustment = 1f;

		[Range(0f, 1000f)]
		public float customShadowDistance;

		public float[] shadowLODMap = new float[8] { 0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f };

		[Range(0.1f, 20f)]
		public float lodCrossFadeAnimateSpeed = 4f;

		[Range(0f, 7f)]
		public int maximumLODLevel;

		public int shadowLayerOverride;

		public uint shadowRenderingLayerOverride;

		public bool enablePerObjectMotionVectors;

		public GPUILightProbeSetting lightProbeSetting = GPUILightProbeSetting.Single;

		public Vector3 lightProbePositionOffset;

		[SerializeField]
		[HideInInspector]
		public bool isDefaultProfile;

		private static GPUIProfile _defaultProfile;

		public static GPUIProfile defaultGPUSkinningProfile;

		public static GPUIProfile DefaultProfile
		{
			get
			{
				if (_defaultProfile == null)
				{
					_defaultProfile = ScriptableObject.CreateInstance<GPUIProfile>();
					_defaultProfile.isDefaultProfile = true;
				}
				return _defaultProfile;
			}
		}

		public static GPUIProfile CreateNewProfile(string name, GPUIProfile copyFrom = null)
		{
			GPUIProfile gPUIProfile = ((!(copyFrom == null)) ? Object.Instantiate(copyFrom) : ScriptableObject.CreateInstance<GPUIProfile>());
			gPUIProfile.name = (string.IsNullOrEmpty(name) ? "New GPUI Profile" : (name + " Profile"));
			gPUIProfile.isDefaultProfile = false;
			return gPUIProfile;
		}

		public void CopyValuesFrom(GPUIProfile copyFrom)
		{
			isShadowCasting = copyFrom.isShadowCasting;
			isDistanceCulling = copyFrom.isDistanceCulling;
			isFrustumCulling = copyFrom.isFrustumCulling;
			isOcclusionCulling = copyFrom.isOcclusionCulling;
			isShadowFrustumCulling = copyFrom.isShadowFrustumCulling;
			isShadowOcclusionCulling = copyFrom.isShadowOcclusionCulling;
			isShadowDistanceCulling = copyFrom.isShadowDistanceCulling;
			isLODCrossFade = copyFrom.isLODCrossFade;
			isAnimateCrossFade = copyFrom.isAnimateCrossFade;
			minCullingDistance = copyFrom.minCullingDistance;
			minShadowCullingDistance = copyFrom.minShadowCullingDistance;
			minMaxDistance = copyFrom.minMaxDistance;
			frustumOffset = copyFrom.frustumOffset;
			shadowFrustumOffset = copyFrom.shadowFrustumOffset;
			shadowOcclusionOffset = copyFrom.shadowOcclusionOffset;
			occlusionAccuracy = copyFrom.occlusionAccuracy;
			boundsOffset = copyFrom.boundsOffset;
			lodBiasAdjustment = copyFrom.lodBiasAdjustment;
			customShadowDistance = copyFrom.customShadowDistance;
			shadowLODMap = copyFrom.shadowLODMap;
			lodCrossFadeAnimateSpeed = copyFrom.lodCrossFadeAnimateSpeed;
			maximumLODLevel = copyFrom.maximumLODLevel;
			enablePerObjectMotionVectors = copyFrom.enablePerObjectMotionVectors;
			lightProbeSetting = copyFrom.lightProbeSetting;
		}

		public void SetParameterBufferData()
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				return;
			}
			GPUIDataBuffer<float> parameterBuffer = GPUIRenderingSystem.Instance.ParameterBuffer;
			if (TryGetParameterBufferIndex(out var index))
			{
				parameterBuffer[index] = minCullingDistance;
				parameterBuffer[index + 1] = minMaxDistance.x;
				parameterBuffer[index + 2] = GetMaxDistance();
				parameterBuffer[index + 3] = GetFrustumOffset();
				parameterBuffer[index + 4] = GetOcclusionOffset();
				parameterBuffer[index + 5] = occlusionAccuracy;
				parameterBuffer[index + 6] = boundsOffset.x;
				parameterBuffer[index + 7] = boundsOffset.y;
				parameterBuffer[index + 8] = boundsOffset.z;
				parameterBuffer[index + 9] = GetLODBiasAdjustment();
				parameterBuffer[index + 10] = GetShadowDistance();
				for (int i = 0; i < 8; i++)
				{
					parameterBuffer[index + 11 + i] = shadowLODMap[i];
				}
				parameterBuffer[index + 20] = lodCrossFadeAnimateSpeed;
				parameterBuffer[index + 21] = GetShadowFrustumOffset();
				parameterBuffer[index + 22] = GetShadowOcclusionOffset();
				parameterBuffer[index + 23] = minShadowCullingDistance;
				parameterBuffer[index + 24] = occlusionOffsetSizeMultiplier;
				parameterBuffer[index + 25] = shadowOcclusionOffsetSizeMultiplier;
			}
			else
			{
				GPUIRenderingSystem.Instance.ParameterBufferIndexes.Add(this, parameterBuffer.Length);
				parameterBuffer.Add(minCullingDistance, minMaxDistance.x, GetMaxDistance(), GetFrustumOffset(), GetOcclusionOffset(), occlusionAccuracy, boundsOffset.x, boundsOffset.y, boundsOffset.z, GetLODBiasAdjustment(), GetShadowDistance());
				parameterBuffer.Add(shadowLODMap);
				parameterBuffer.Add(0f, lodCrossFadeAnimateSpeed, GetShadowFrustumOffset(), GetShadowOcclusionOffset(), minShadowCullingDistance, occlusionOffsetSizeMultiplier, shadowOcclusionOffsetSizeMultiplier);
			}
		}

		public bool TryGetParameterBufferIndex(out int index)
		{
			return GPUIRenderingSystem.Instance.ParameterBufferIndexes.TryGetValue(this, out index);
		}

		public float GetMaxDistance()
		{
			if (isDistanceCulling)
			{
				return minMaxDistance.y;
			}
			return -1f;
		}

		public float GetLODBiasAdjustment()
		{
			if (!(lodBiasAdjustment > 0f))
			{
				return 1f;
			}
			return lodBiasAdjustment;
		}

		public float GetShadowDistance()
		{
			if (!isShadowDistanceCulling)
			{
				return 0f;
			}
			if (customShadowDistance > 0f)
			{
				return customShadowDistance;
			}
			return GPUIRuntimeSettings.Instance.GetDefaultShadowDistance();
		}

		public float GetFrustumOffset()
		{
			if (!isFrustumCulling)
			{
				return -1f;
			}
			return frustumOffset;
		}

		public float GetOcclusionOffset()
		{
			if (!isOcclusionCulling)
			{
				return -1f;
			}
			return occlusionOffset;
		}

		public float GetShadowFrustumOffset()
		{
			if (!isShadowFrustumCulling)
			{
				return -1f;
			}
			return shadowFrustumOffset;
		}

		public float GetShadowOcclusionOffset()
		{
			if (!isShadowOcclusionCulling)
			{
				return -1f;
			}
			return shadowOcclusionOffset;
		}

		public void SetShadowFrustumCulling(bool value)
		{
			isShadowFrustumCulling = value;
			SetParameterBufferData();
		}

		public void SetShadowFrustumOffset(float value)
		{
			shadowFrustumOffset = value;
			SetParameterBufferData();
		}

		public void SetShadowOcclusionCulling(bool value)
		{
			isShadowOcclusionCulling = value;
			SetParameterBufferData();
		}

		public void SetShadowOcclusionOffset(float value)
		{
			shadowOcclusionOffset = value;
			SetParameterBufferData();
		}

		public void SetShadowMinCullingDistance(float value)
		{
			minShadowCullingDistance = value;
			SetParameterBufferData();
		}

		public void SetLightProbeSetting(int value)
		{
			if (value >= 0 && value <= 2)
			{
				lightProbeSetting = (GPUILightProbeSetting)value;
			}
		}

		public bool HasLODLevelShadows(int lodLevel)
		{
			for (int i = 0; i < 8; i++)
			{
				if (shadowLODMap[i] == (float)lodLevel)
				{
					return true;
				}
			}
			return false;
		}
	}
}
