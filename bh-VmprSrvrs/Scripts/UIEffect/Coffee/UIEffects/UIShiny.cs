using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[AddComponentMenu("UI/UIEffects/UIShiny", 2)]
	public class UIShiny : BaseMaterialEffect
	{
		private const uint k_ShaderId = 8u;

		private static readonly ParameterTexture s_ParamTex;

		private float _lastRotation;

		private EffectArea _lastEffectArea;

		[Tooltip("Location for shiny effect.")]
		[FormerlySerializedAs("m_Location")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_EffectFactor;

		[Tooltip("Width for shiny effect.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Width;

		[Tooltip("Rotation for shiny effect.")]
		[SerializeField]
		[Range(-180f, 180f)]
		private float m_Rotation;

		[Tooltip("Softness for shiny effect.")]
		[SerializeField]
		[Range(0.01f, 1f)]
		private float m_Softness;

		[Tooltip("Brightness for shiny effect.")]
		[FormerlySerializedAs("m_Alpha")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Brightness;

		[Tooltip("Gloss factor for shiny effect.")]
		[FormerlySerializedAs("m_Highlight")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Gloss;

		[Header("Advanced Option")]
		[Tooltip("The area for effect.")]
		[SerializeField]
		protected EffectArea m_EffectArea;

		[SerializeField]
		private EffectPlayer m_Player;

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

		public float width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float softness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float gloss
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float rotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public EffectArea effectArea
		{
			get
			{
				return default(EffectArea);
			}
			set
			{
			}
		}

		public override ParameterTexture paramTex => null;

		public EffectPlayer effectPlayer => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
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

		public void Play(bool reset = true)
		{
		}

		public void Stop(bool reset = true)
		{
		}

		protected override void SetEffectParamsDirty()
		{
		}

		protected override void SetVerticesDirty()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}
	}
}
