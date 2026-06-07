using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[ExecuteAlways]
	[RequireComponent(typeof(Graphic))]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/UIEffects/UIEffect", 1)]
	public class UIEffect : BaseMaterialEffect, IMaterialModifier
	{
		private enum BlurEx
		{
			None = 0,
			Ex = 1
		}

		private const uint k_ShaderId = 16u;

		private static readonly ParameterTexture s_ParamTex;

		[FormerlySerializedAs("m_ToneLevel")]
		[Tooltip("Effect factor between 0(no effect) and 1(complete effect).")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_EffectFactor;

		[Tooltip("Color effect factor between 0(no effect) and 1(complete effect).")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ColorFactor;

		[FormerlySerializedAs("m_Blur")]
		[Tooltip("How far is the blurring from the graphic.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_BlurFactor;

		[FormerlySerializedAs("m_ToneMode")]
		[Tooltip("Effect mode")]
		[SerializeField]
		private EffectMode m_EffectMode;

		[Tooltip("Color effect mode")]
		[SerializeField]
		private ColorMode m_ColorMode;

		[Tooltip("Blur effect mode")]
		[SerializeField]
		private BlurMode m_BlurMode;

		[Tooltip("Advanced blurring remove common artifacts in the blur effect for uGUI.")]
		[SerializeField]
		private bool m_AdvancedBlur;

		public AdditionalCanvasShaderChannels uvMaskChannel => default(AdditionalCanvasShaderChannels);

		public float effectFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorFactor
		{
			get
			{
				return 0f;
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

		public EffectMode effectMode
		{
			get
			{
				return default(EffectMode);
			}
			set
			{
			}
		}

		public ColorMode colorMode
		{
			get
			{
				return default(ColorMode);
			}
			set
			{
			}
		}

		public BlurMode blurMode
		{
			get
			{
				return default(BlurMode);
			}
			set
			{
			}
		}

		public override ParameterTexture paramTex => null;

		public bool advancedBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override Hash128 GetMaterialHash(Material material)
		{
			return default(Hash128);
		}

		public override void ModifyMaterial(Material newMaterial, Graphic graphic)
		{
		}

		public override void ModifyMesh(VertexHelper vh, Graphic graphic)
		{
		}

		protected override void SetEffectParamsDirty()
		{
		}

		private static void GetBounds(List<UIVertex> verts, int start, int count, ref Rect posBounds, ref Rect uvBounds, bool global)
		{
		}
	}
}
