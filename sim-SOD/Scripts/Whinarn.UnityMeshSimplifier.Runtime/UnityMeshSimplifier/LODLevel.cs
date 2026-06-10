using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityMeshSimplifier
{
	[Serializable]
	public struct LODLevel
	{
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The screen relative height to use for the transition.")]
		private float screenRelativeTransitionHeight;

		[Tooltip("The width of the cross-fade transition zone (proportion to the current LOD's whole length).")]
		[SerializeField]
		[Range(0f, 1f)]
		private float fadeTransitionWidth;

		[Tooltip("The desired quality for this level.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float quality;

		[Tooltip("If all renderers and meshes under this level should be combined into one, where possible.")]
		[SerializeField]
		private bool combineMeshes;

		[Tooltip("If all sub-meshes should be combined into one, where possible.")]
		[SerializeField]
		private bool combineSubMeshes;

		[Tooltip("The renderers used in this level.")]
		[SerializeField]
		private Renderer[] renderers;

		[Tooltip("The skin quality to use for renderers on this level.")]
		[SerializeField]
		private SkinQuality skinQuality;

		[SerializeField]
		[Tooltip("The shadow casting mode for renderers on this level.")]
		private ShadowCastingMode shadowCastingMode;

		[Tooltip("If renderers on this level should receive shadows.")]
		[SerializeField]
		private bool receiveShadows;

		[SerializeField]
		[Tooltip("The motion vector generation mode for renderers on this level.")]
		private MotionVectorGenerationMode motionVectorGenerationMode;

		[SerializeField]
		[Tooltip("If renderers on this level should use skinned motion vectors.")]
		private bool skinnedMotionVectors;

		[SerializeField]
		[Tooltip("The light probe usage for renderers on this level.")]
		private LightProbeUsage lightProbeUsage;

		[Tooltip("The reflection probe usage for renderers on this level.")]
		[SerializeField]
		private ReflectionProbeUsage reflectionProbeUsage;

		public float ScreenRelativeTransitionHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FadeTransitionWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Quality
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool CombineMeshes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CombineSubMeshes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Renderer[] Renderers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SkinQuality SkinQuality
		{
			get
			{
				return default(SkinQuality);
			}
			set
			{
			}
		}

		public ShadowCastingMode ShadowCastingMode
		{
			get
			{
				return default(ShadowCastingMode);
			}
			set
			{
			}
		}

		public bool ReceiveShadows
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MotionVectorGenerationMode MotionVectorGenerationMode
		{
			get
			{
				return default(MotionVectorGenerationMode);
			}
			set
			{
			}
		}

		public bool SkinnedMotionVectors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LightProbeUsage LightProbeUsage
		{
			get
			{
				return default(LightProbeUsage);
			}
			set
			{
			}
		}

		public ReflectionProbeUsage ReflectionProbeUsage
		{
			get
			{
				return default(ReflectionProbeUsage);
			}
			set
			{
			}
		}

		public LODLevel(float screenRelativeTransitionHeight, float quality)
		{
			this.screenRelativeTransitionHeight = 0f;
			fadeTransitionWidth = 0f;
			this.quality = 0f;
			combineMeshes = false;
			combineSubMeshes = false;
			renderers = null;
			skinQuality = default(SkinQuality);
			shadowCastingMode = default(ShadowCastingMode);
			receiveShadows = false;
			motionVectorGenerationMode = default(MotionVectorGenerationMode);
			skinnedMotionVectors = false;
			lightProbeUsage = default(LightProbeUsage);
			reflectionProbeUsage = default(ReflectionProbeUsage);
		}

		public LODLevel(float screenRelativeTransitionHeight, float fadeTransitionWidth, float quality, bool combineMeshes, bool combineSubMeshes)
		{
			this.screenRelativeTransitionHeight = 0f;
			this.fadeTransitionWidth = 0f;
			this.quality = 0f;
			this.combineMeshes = false;
			this.combineSubMeshes = false;
			renderers = null;
			skinQuality = default(SkinQuality);
			shadowCastingMode = default(ShadowCastingMode);
			receiveShadows = false;
			motionVectorGenerationMode = default(MotionVectorGenerationMode);
			skinnedMotionVectors = false;
			lightProbeUsage = default(LightProbeUsage);
			reflectionProbeUsage = default(ReflectionProbeUsage);
		}

		public LODLevel(float screenRelativeTransitionHeight, float fadeTransitionWidth, float quality, bool combineMeshes, bool combineSubMeshes, Renderer[] renderers)
		{
			this.screenRelativeTransitionHeight = 0f;
			this.fadeTransitionWidth = 0f;
			this.quality = 0f;
			this.combineMeshes = false;
			this.combineSubMeshes = false;
			this.renderers = null;
			skinQuality = default(SkinQuality);
			shadowCastingMode = default(ShadowCastingMode);
			receiveShadows = false;
			motionVectorGenerationMode = default(MotionVectorGenerationMode);
			skinnedMotionVectors = false;
			lightProbeUsage = default(LightProbeUsage);
			reflectionProbeUsage = default(ReflectionProbeUsage);
		}
	}
}
