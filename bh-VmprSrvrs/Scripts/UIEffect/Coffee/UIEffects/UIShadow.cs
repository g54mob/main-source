using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[RequireComponent(typeof(Graphic))]
	[AddComponentMenu("UI/UIEffects/UIShadow", 100)]
	public class UIShadow : BaseMeshEffect, IParameterTexture
	{
		private static readonly List<UIShadow> tmpShadows;

		private static readonly List<UIVertex> s_Verts;

		private int _graphicVertexCount;

		private UIEffect _uiEffect;

		[Tooltip("How far is the blurring shadow from the graphic.")]
		[FormerlySerializedAs("m_Blur")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_BlurFactor;

		[Tooltip("Shadow effect style.")]
		[SerializeField]
		private ShadowStyle m_Style;

		[SerializeField]
		private Color m_EffectColor;

		[SerializeField]
		private Vector2 m_EffectDistance;

		[SerializeField]
		private bool m_UseGraphicAlpha;

		private const float kMaxEffectDistance = 600f;

		public Color effectColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Vector2 effectDistance
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool useGraphicAlpha
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float blurFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ShadowStyle style
		{
			get
			{
				return default(ShadowStyle);
			}
			set
			{
			}
		}

		public int parameterIndex { get; set; }

		public ParameterTexture paramTex { get; private set; }

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void ModifyMesh(VertexHelper vh, Graphic graphic)
		{
		}

		private void ApplyShadow(List<UIVertex> verts, Color color, ref int start, ref int end, Vector2 distance, ShadowStyle style, bool alpha)
		{
		}

		private void ApplyShadowZeroAlloc(List<UIVertex> verts, Color color, ref int start, ref int end, float x, float y, bool alpha)
		{
		}
	}
}
