using System;
using System.Collections.Generic;
using Coffee.UIEffectInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	public sealed class UIEffectContext
	{
		private static readonly UIEffectContext s_DefaultContext;

		private static readonly List<UIVertex> s_WorkingVertices;

		private static readonly int s_SrcBlend;

		private static readonly int s_DstBlend;

		private static readonly int s_ToneIntensity;

		private static readonly int s_ColorFilter;

		private static readonly int s_ColorValue;

		private static readonly int s_ColorIntensity;

		private static readonly int s_ColorGlow;

		private static readonly int s_SamplingIntensity;

		private static readonly int s_SamplingWidth;

		private static readonly int s_SamplingScale;

		private static readonly int s_TransitionRate;

		private static readonly int s_TransitionReverse;

		private static readonly int s_TransitionTex;

		private static readonly int s_TransitionTex_ST;

		private static readonly int s_TransitionTex_Speed;

		private static readonly int s_TransitionWidth;

		private static readonly int s_TransitionSoftness;

		private static readonly int s_TransitionRange;

		private static readonly int s_TransitionColorFilter;

		private static readonly int s_TransitionColor;

		private static readonly int s_TransitionColorGlow;

		private static readonly int s_TransitionPatternReverse;

		private static readonly int s_TransitionAutoPlaySpeed;

		private static readonly int s_TransitionGradientTex;

		private static readonly int s_TargetColor;

		private static readonly int s_TargetRange;

		private static readonly int s_TargetSoftness;

		private static readonly int s_ShadowColorFilter;

		private static readonly int s_ShadowColor;

		private static readonly int s_ShadowBlurIntensity;

		private static readonly int s_ShadowColorGlow;

		private static readonly int s_EdgeWidth;

		private static readonly int s_EdgeColorFilter;

		private static readonly int s_EdgeColor;

		private static readonly int s_EdgeColorGlow;

		private static readonly int s_EdgeShinyAutoPlaySpeed;

		private static readonly int s_EdgeShinyRate;

		private static readonly int s_EdgeShinyWidth;

		private static readonly int s_PatternArea;

		private static readonly int s_DetailIntensity;

		private static readonly int s_DetailThreshold;

		private static readonly int s_DetailColor;

		private static readonly int s_DetailTex;

		private static readonly int s_DetailTex_ST;

		private static readonly int s_DetailTex_Speed;

		private static readonly int s_GradationIntensity;

		private static readonly int s_GradationColorFilter;

		private static readonly int s_GradationColor1;

		private static readonly int s_GradationColor2;

		private static readonly int s_GradationColor3;

		private static readonly int s_GradationColor4;

		private static readonly int s_GradationTex;

		private static readonly int s_GradationTex_ST;

		private static readonly int s_GradationRadial;

		private static readonly int s_RootViewMatrix;

		private static readonly int s_GradViewMatrix;

		private static readonly int s_MirrorRootViewMatrix;

		private static readonly int s_MirrorGradViewMatrix;

		private static readonly int s_CanvasToWorldMatrix;

		private static readonly string[] s_ToneKeywords;

		private static readonly string[] s_ColorKeywords;

		private static readonly string[] s_SamplingKeywords;

		private static readonly string[] s_TransitionKeywords;

		private static readonly string[] s_TargetKeywords;

		private static readonly string[] s_EdgeKeywords;

		private static readonly string[] s_DetailKeywords;

		private static readonly string[] s_GradationKeywords;

		private static readonly Vector2[][] s_ShadowVectors;

		public static Func<UIVertex, Rect, UIVertex> onModifyVertex;

		public ToneFilter m_ToneFilter;

		public float m_ToneIntensity;

		public ColorFilter m_ColorFilter;

		public float m_ColorIntensity;

		public Color m_Color;

		public bool m_ColorGlow;

		public SamplingFilter m_SamplingFilter;

		public float m_SamplingIntensity;

		public float m_SamplingWidth;

		public TransitionFilter m_TransitionFilter;

		public float m_TransitionRate;

		public bool m_TransitionReverse;

		public Texture m_TransitionTex;

		public Vector2 m_TransitionTexScale;

		public Vector2 m_TransitionTexOffset;

		public Vector2 m_TransitionTexSpeed;

		public float m_TransitionRotation;

		public bool m_TransitionKeepAspectRatio;

		public float m_TransitionWidth;

		public float m_TransitionSoftness;

		public MinMax01 m_TransitionRange;

		public ColorFilter m_TransitionColorFilter;

		public Color m_TransitionColor;

		public bool m_TransitionColorGlow;

		public bool m_TransitionPatternReverse;

		public float m_TransitionAutoPlaySpeed;

		public Gradient m_TransitionGradient;

		public TargetMode m_TargetMode;

		public Color m_TargetColor;

		public float m_TargetRange;

		public float m_TargetSoftness;

		public BlendMode m_SrcBlendMode;

		public BlendMode m_DstBlendMode;

		public ShadowMode m_ShadowMode;

		public Vector2 m_ShadowDistance;

		public int m_ShadowIteration;

		public float m_ShadowFade;

		public float m_ShadowMirrorScale;

		public float m_ShadowBlurIntensity;

		public ColorFilter m_ShadowColorFilter;

		public Color m_ShadowColor;

		public bool m_ShadowColorGlow;

		public EdgeMode m_EdgeMode;

		public float m_EdgeShinyRate;

		public float m_EdgeWidth;

		public ColorFilter m_EdgeColorFilter;

		public Color m_EdgeColor;

		public bool m_EdgeColorGlow;

		public float m_EdgeShinyWidth;

		public float m_EdgeShinyAutoPlaySpeed;

		public PatternArea m_PatternArea;

		public GradationMode m_GradationMode;

		public float m_GradationIntensity;

		public GradationColorFilter m_GradationColorFilter;

		public Color m_GradationColor1;

		public Color m_GradationColor2;

		public Color m_GradationColor3;

		public Color m_GradationColor4;

		public Gradient m_GradationGradient;

		public float m_GradationOffset;

		public float m_GradationScale;

		public float m_GradationRotation;

		public TextureWrapMode m_GradationWrapMode;

		public bool m_GradationReverse;

		public DetailFilter m_DetailFilter;

		public float m_DetailIntensity;

		public MinMax01 m_DetailThreshold;

		public Color m_DetailColor;

		public Texture m_DetailTex;

		public Vector2 m_DetailTexScale;

		public Vector2 m_DetailTexOffset;

		public Vector2 m_DetailTexSpeed;

		public Flip m_Flip;

		private Texture2D _gradationRampTex;

		private Texture2D _transitionRampTex;

		private bool _isGradientDirty;

		private bool _isTransitionGradientDirty;

		private static readonly Color[] s_Colors;

		private static readonly InternalObjectPool<Texture2D> s_TexturePool;

		public bool willModifyMaterial => false;

		public bool willModifyVertex => false;

		public bool useViewMatrix => false;

		private Texture2D gradationRampTex => null;

		private Texture2D transitionRampTex => null;

		public void Reset()
		{
		}

		private void CopyFrom(UIEffectContext src)
		{
		}

		public void SetGradationDirty()
		{
		}

		public void SetTransitionGradationDirty()
		{
		}

		public void ApplyToMaterial(Material material, float actualSamplingScale = 1f)
		{
		}

		public void SetEnablePreview(bool enable, Material material)
		{
		}

		public void UpdateViewMatrix(Material material, RectTransform transitionRoot, Canvas canvas)
		{
		}

		private Vector4 GetGradationScaleAndOffset()
		{
			return default(Vector4);
		}

		private float GetGradationRotation()
		{
			return 0f;
		}

		private static float GetMultiplier(float deg)
		{
			return 0f;
		}

		private static void SetKeyword(Material material, Span<string> keywords, int index)
		{
		}

		public void ModifyMesh(Graphic graphic, Canvas canvas, RectTransform transitionRoot, VertexHelper vh, bool canModifyShape)
		{
		}

		private void ApplyShadow(List<UIVertex> verts, RectTransform transitionRoot, Flip flip)
		{
		}

		private static void ApplyFlipWithoutEffect(VertexHelper vh, Flip flip)
		{
		}

		private static void ApplyFlipWithEffect(List<UIVertex> verts, Flip flip)
		{
		}

		private Vector4 GetExpandSize(bool canModifyShape)
		{
			return default(Vector4);
		}

		private static Color ApplyColorSpace(Color color)
		{
			return default(Color);
		}
	}
}
