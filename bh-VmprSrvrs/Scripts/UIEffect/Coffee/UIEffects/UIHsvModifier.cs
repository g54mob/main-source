using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[AddComponentMenu("UI/UIEffects/UIHsvModifier", 4)]
	public class UIHsvModifier : BaseMaterialEffect
	{
		private const uint k_ShaderId = 48u;

		private static readonly ParameterTexture s_ParamTex;

		[Header("Target")]
		[Tooltip("Target color to affect hsv shift.")]
		[SerializeField]
		[ColorUsage(false)]
		private Color m_TargetColor;

		[Tooltip("Color range to affect hsv shift [0 ~ 1].")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Range;

		[Header("Adjustment")]
		[Tooltip("Hue shift [-0.5 ~ 0.5].")]
		[SerializeField]
		[Range(-0.5f, 0.5f)]
		private float m_Hue;

		[Tooltip("Saturation shift [-0.5 ~ 0.5].")]
		[SerializeField]
		[Range(-0.5f, 0.5f)]
		private float m_Saturation;

		[Tooltip("Value shift [-0.5 ~ 0.5].")]
		[SerializeField]
		[Range(-0.5f, 0.5f)]
		private float m_Value;

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

		public float range
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float saturation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float hue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override ParameterTexture paramTex => null;

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
	}
}
