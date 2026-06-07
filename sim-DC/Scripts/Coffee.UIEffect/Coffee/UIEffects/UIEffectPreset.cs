using Coffee.UIEffectInternal;
using UnityEngine;
using UnityEngine.Rendering;

namespace Coffee.UIEffects
{
	[CreateAssetMenu]
	[ExecuteAlways]
	public class UIEffectPreset : ScriptableObject
	{
		internal static UIEffectPreset s_DefaultPreset;

		public ToneFilter m_ToneFilter;

		[Range(0f, 1f)]
		public float m_ToneIntensity;

		public ColorFilter m_ColorFilter;

		[Range(0f, 1f)]
		public float m_ColorIntensity;

		public Color m_Color;

		public bool m_ColorGlow;

		public SamplingFilter m_SamplingFilter;

		[Range(0f, 1f)]
		public float m_SamplingIntensity;

		[Range(0.5f, 10f)]
		public float m_SamplingWidth;

		public TransitionFilter m_TransitionFilter;

		[Range(0f, 1f)]
		public float m_TransitionRate;

		public bool m_TransitionReverse;

		public Texture m_TransitionTex;

		public Vector2 m_TransitionTexScale;

		public Vector2 m_TransitionTexOffset;

		public Vector2 m_TransitionTexSpeed;

		[Range(0f, 360f)]
		public float m_TransitionRotation;

		public bool m_TransitionKeepAspectRatio;

		[Range(0f, 1f)]
		public float m_TransitionWidth;

		[Range(0f, 1f)]
		public float m_TransitionSoftness;

		public MinMax01 m_TransitionRange;

		public ColorFilter m_TransitionColorFilter;

		public Color m_TransitionColor;

		public bool m_TransitionColorGlow;

		public bool m_TransitionPatternReverse;

		[Range(-5f, 5f)]
		public float m_TransitionAutoPlaySpeed;

		public Gradient m_TransitionGradient;

		public TargetMode m_TargetMode;

		public Color m_TargetColor;

		[Range(0f, 1f)]
		public float m_TargetRange;

		[Range(0f, 1f)]
		public float m_TargetSoftness;

		public BlendType m_BlendType;

		public BlendMode m_SrcBlendMode;

		public BlendMode m_DstBlendMode;

		public ShadowMode m_ShadowMode;

		public Vector2 m_ShadowDistance;

		[Range(1f, 5f)]
		public int m_ShadowIteration;

		[Range(0f, 1f)]
		public float m_ShadowFade;

		[Range(0f, 2f)]
		public float m_ShadowMirrorScale;

		[Range(0f, 1f)]
		public float m_ShadowBlurIntensity;

		public ColorFilter m_ShadowColorFilter;

		public Color m_ShadowColor;

		public bool m_ShadowColorGlow;

		public GradationMode m_GradationMode;

		[Range(0f, 1f)]
		public float m_GradationIntensity;

		public GradationColorFilter m_GradationColorFilter;

		public Color m_GradationColor1;

		public Color m_GradationColor2;

		public Color m_GradationColor3;

		public Color m_GradationColor4;

		public Gradient m_GradationGradient;

		[Range(-1f, 1f)]
		public float m_GradationOffset;

		public float m_GradationScale;

		[Range(0f, 360f)]
		public float m_GradationRotation;

		public TextureWrapMode m_GradationWrapMode;

		public bool m_GradationReverse;

		public EdgeMode m_EdgeMode;

		[Range(0f, 1f)]
		public float m_EdgeWidth;

		public ColorFilter m_EdgeColorFilter;

		public Color m_EdgeColor;

		public bool m_EdgeColorGlow;

		[Range(0f, 1f)]
		public float m_EdgeShinyRate;

		[Range(0f, 1f)]
		public float m_EdgeShinyWidth;

		[Range(-5f, 5f)]
		public float m_EdgeShinyAutoPlaySpeed;

		public PatternArea m_PatternArea;

		public DetailFilter m_DetailFilter;

		[Range(0f, 1f)]
		public float m_DetailIntensity;

		public Color m_DetailColor;

		public MinMax01 m_DetailThreshold;

		public Texture m_DetailTex;

		public Vector2 m_DetailTexScale;

		public Vector2 m_DetailTexOffset;

		public Vector2 m_DetailTexSpeed;

		public Flip m_Flip;

		internal static UIEffectPreset GetDefaultPreset()
		{
			return null;
		}

		public void UpdateContext(UIEffectContext dst)
		{
		}
	}
}
