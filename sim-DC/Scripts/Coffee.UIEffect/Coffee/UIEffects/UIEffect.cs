using System;
using System.Collections.Generic;
using Coffee.UIEffectInternal;
using UnityEngine;
using UnityEngine.Rendering;

namespace Coffee.UIEffects
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class UIEffect : UIEffectBase
	{
		[SerializeField]
		protected ToneFilter m_ToneFilter;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_ToneIntensity;

		[SerializeField]
		protected ColorFilter m_ColorFilter;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_ColorIntensity;

		[SerializeField]
		protected Color m_Color;

		[SerializeField]
		protected bool m_ColorGlow;

		[SerializeField]
		protected SamplingFilter m_SamplingFilter;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_SamplingIntensity;

		[Range(0.5f, 10f)]
		[SerializeField]
		protected float m_SamplingWidth;

		[SerializeField]
		protected float m_SamplingScale;

		[SerializeField]
		protected TransitionFilter m_TransitionFilter;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_TransitionRate;

		[SerializeField]
		protected bool m_TransitionReverse;

		[SerializeField]
		protected Texture m_TransitionTex;

		[SerializeField]
		protected Vector2 m_TransitionTexScale;

		[SerializeField]
		protected Vector2 m_TransitionTexOffset;

		[SerializeField]
		protected Vector2 m_TransitionTexSpeed;

		[Tooltip("Effect rotation (0–360).\nNOTE: This property is shared between `Transition Filter` and `Detail Filter`.")]
		[SerializeField]
		[Range(0f, 360f)]
		private float m_TransitionRotation;

		[Tooltip("The effect maintains its aspect ratio.\nNOTE: This property is shared between `Transition Filter`, `Gradation Mode`, and `Detail Filter`.")]
		[SerializeField]
		protected bool m_TransitionKeepAspectRatio;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_TransitionWidth;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_TransitionSoftness;

		[SerializeField]
		protected MinMax01 m_TransitionRange;

		[SerializeField]
		protected ColorFilter m_TransitionColorFilter;

		[SerializeField]
		protected Color m_TransitionColor;

		[SerializeField]
		protected bool m_TransitionColorGlow;

		[SerializeField]
		protected bool m_TransitionPatternReverse;

		[Range(-5f, 5f)]
		[SerializeField]
		protected float m_TransitionAutoPlaySpeed;

		[SerializeField]
		private Gradient m_TransitionGradient;

		[SerializeField]
		protected TargetMode m_TargetMode;

		[SerializeField]
		protected Color m_TargetColor;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_TargetRange;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_TargetSoftness;

		[SerializeField]
		protected BlendType m_BlendType;

		[SerializeField]
		protected BlendMode m_SrcBlendMode;

		[SerializeField]
		protected BlendMode m_DstBlendMode;

		[SerializeField]
		protected ShadowMode m_ShadowMode;

		[SerializeField]
		protected Vector2 m_ShadowDistance;

		[Range(1f, 5f)]
		[SerializeField]
		protected int m_ShadowIteration;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_ShadowFade;

		[Range(0f, 2f)]
		[SerializeField]
		protected float m_ShadowMirrorScale;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_ShadowBlurIntensity;

		[SerializeField]
		protected ColorFilter m_ShadowColorFilter;

		[SerializeField]
		protected Color m_ShadowColor;

		[SerializeField]
		protected bool m_ShadowColorGlow;

		[SerializeField]
		protected GradationMode m_GradationMode;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_GradationIntensity;

		[SerializeField]
		protected GradationColorFilter m_GradationColorFilter;

		[SerializeField]
		protected Color m_GradationColor1;

		[SerializeField]
		protected Color m_GradationColor2;

		[SerializeField]
		protected Color m_GradationColor3;

		[SerializeField]
		protected Color m_GradationColor4;

		[SerializeField]
		private Gradient m_GradationGradient;

		[Range(-1f, 1f)]
		[SerializeField]
		protected float m_GradationOffset;

		[SerializeField]
		protected float m_GradationScale;

		[SerializeField]
		[Range(0f, 360f)]
		private float m_GradationRotation;

		[SerializeField]
		protected TextureWrapMode m_GradationWrapMode;

		[SerializeField]
		protected bool m_GradationReverse;

		[SerializeField]
		protected bool m_AllowToModifyMeshShape;

		[SerializeField]
		protected EdgeMode m_EdgeMode;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_EdgeWidth;

		[SerializeField]
		protected ColorFilter m_EdgeColorFilter;

		[SerializeField]
		protected Color m_EdgeColor;

		[SerializeField]
		protected bool m_EdgeColorGlow;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_EdgeShinyRate;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_EdgeShinyWidth;

		[Range(-5f, 5f)]
		[SerializeField]
		protected float m_EdgeShinyAutoPlaySpeed;

		[SerializeField]
		protected PatternArea m_PatternArea;

		[SerializeField]
		protected DetailFilter m_DetailFilter;

		[Range(0f, 1f)]
		[SerializeField]
		protected float m_DetailIntensity;

		[SerializeField]
		protected MinMax01 m_DetailThreshold;

		[SerializeField]
		protected Color m_DetailColor;

		[SerializeField]
		protected Texture m_DetailTex;

		[SerializeField]
		protected Vector2 m_DetailTexScale;

		[SerializeField]
		protected Vector2 m_DetailTexOffset;

		[SerializeField]
		protected Vector2 m_DetailTexSpeed;

		[SerializeField]
		protected RectTransform m_CustomRoot;

		[SerializeField]
		protected Flip m_Flip;

		private List<UIEffectReplica> _replicas;

		public ToneFilter toneFilter
		{
			get
			{
				return default(ToneFilter);
			}
			set
			{
			}
		}

		public float toneIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ColorFilter colorFilter
		{
			get
			{
				return default(ColorFilter);
			}
			set
			{
			}
		}

		public float colorIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float colorHueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorSaturationShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorValueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorContrastShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorBrightnessShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool colorGlow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SamplingFilter samplingFilter
		{
			get
			{
				return default(SamplingFilter);
			}
			set
			{
			}
		}

		public float samplingIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float samplingWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float samplingScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override float actualSamplingScale => 0f;

		public override bool canModifyShape => false;

		public TransitionFilter transitionFilter
		{
			get
			{
				return default(TransitionFilter);
			}
			set
			{
			}
		}

		public float transitionRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool transitionReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Texture transitionTexture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 transitionTextureScale
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 transitionTextureOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 transitionTextureSpeed
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float transitionRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool transitionKeepAspectRatio
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float transitionWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionSoftness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MinMax01 transitionRange
		{
			get
			{
				return default(MinMax01);
			}
			set
			{
			}
		}

		public ColorFilter transitionColorFilter
		{
			get
			{
				return default(ColorFilter);
			}
			set
			{
			}
		}

		public Color transitionColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float transitionColorHueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionColorSaturationShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionColorValueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionColorContrastShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionColorBrightnessShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float transitionColorAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool transitionColorGlow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool transitionPatternReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float transitionAutoPlaySpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TargetMode targetMode
		{
			get
			{
				return default(TargetMode);
			}
			set
			{
			}
		}

		public Color targetColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float targetRange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float targetSoftness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BlendType blendType
		{
			get
			{
				return default(BlendType);
			}
			set
			{
			}
		}

		public BlendMode srcBlendMode
		{
			get
			{
				return default(BlendMode);
			}
			set
			{
			}
		}

		public BlendMode dstBlendMode
		{
			get
			{
				return default(BlendMode);
			}
			set
			{
			}
		}

		public ShadowMode shadowMode
		{
			get
			{
				return default(ShadowMode);
			}
			set
			{
			}
		}

		public Vector2 shadowDistance
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float shadowFade
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int shadowIteration
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float shadowMirrorScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowBlurIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ColorFilter shadowColorFilter
		{
			get
			{
				return default(ColorFilter);
			}
			set
			{
			}
		}

		public Color shadowColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float shadowColorHueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowColorSaturationShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowColorValueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowColorContrastShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowColorBrightnessShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadowColorAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("shadowGlow is deprecated. Use shadowColorGlow instead.", false)]
		public bool shadowGlow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool shadowColorGlow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public EdgeMode edgeMode
		{
			get
			{
				return default(EdgeMode);
			}
			set
			{
			}
		}

		public float edgeShinyRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ColorFilter edgeColorFilter
		{
			get
			{
				return default(ColorFilter);
			}
			set
			{
			}
		}

		public Color edgeColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float edgeColorHueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeColorSaturationShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeColorValueShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeColorContrastShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeColorBrightnessShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeColorAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool edgeColorGlow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float edgeShinyWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float edgeShinyAutoPlaySpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PatternArea patternArea
		{
			get
			{
				return default(PatternArea);
			}
			set
			{
			}
		}

		public GradationMode gradationMode
		{
			get
			{
				return default(GradationMode);
			}
			set
			{
			}
		}

		public float gradationIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public GradationColorFilter gradationColorFilter
		{
			get
			{
				return default(GradationColorFilter);
			}
			set
			{
			}
		}

		public Color gradationColor1
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color gradationColor2
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color gradationColor3
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color gradationColor4
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float gradationOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float gradationScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float gradationRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TextureWrapMode gradationWrapMode
		{
			get
			{
				return default(TextureWrapMode);
			}
			set
			{
			}
		}

		public bool gradationReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DetailFilter detailFilter
		{
			get
			{
				return default(DetailFilter);
			}
			set
			{
			}
		}

		public float detailIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MinMax01 detailThreshold
		{
			get
			{
				return default(MinMax01);
			}
			set
			{
			}
		}

		public Color detailColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float detailColorAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Texture detailTexture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 detailTextureScale
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 detailTextureOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 detailTextureSpeed
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool allowToModifyMeshShape
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public RectTransform customRoot
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Flip flip
		{
			get
			{
				return default(Flip);
			}
			set
			{
			}
		}

		public override RectTransform transitionRoot => null;

		public List<UIEffectReplica> replicas => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void SetVerticesDirty()
		{
		}

		public override void SetMaterialDirty()
		{
		}

		public void SetGradientKeys(Gradient gradient)
		{
		}

		public void GetGradientKeys(out GradientColorKey[] colorKeys, out GradientAlphaKey[] alphaKeys, out GradientMode mode)
		{
			colorKeys = null;
			alphaKeys = null;
			mode = default(GradientMode);
		}

		public void SetTransitionGradientKeys(Gradient gradient)
		{
		}

		public void GetTransitionGradientKeys(out GradientColorKey[] colorKeys, out GradientAlphaKey[] alphaKeys, out GradientMode mode)
		{
			colorKeys = null;
			alphaKeys = null;
			mode = default(GradientMode);
		}

		public void SetGradientKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode = GradientMode.Blend)
		{
		}

		public void SetTransitionGradientKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode = GradientMode.Blend)
		{
		}

		public override void ApplyContextToMaterial(Material material)
		{
		}

		public override void SetRate(float rate, UIEffectTweener.CullingMask mask)
		{
		}

		public override bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void LoadPreset(string presetName)
		{
		}

		public void LoadPreset(string presetName, bool append)
		{
		}

		public void LoadPreset(UIEffect src)
		{
		}

		public void LoadPreset(UIEffectPreset preset)
		{
		}

		public void LoadPreset(UIEffect src, bool append)
		{
		}

		public void LoadPreset(UIEffectPreset src, bool append)
		{
		}

		public void SavePreset(UIEffectPreset dst, bool append)
		{
		}

		internal override void UpdateContext(UIEffectContext dst)
		{
		}
	}
}
