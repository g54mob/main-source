using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[AddComponentMenu("UI/UIEffects/UIDissolve", 3)]
	public class UIDissolve : BaseMaterialEffect, IMaterialModifier
	{
		private const uint k_ShaderId = 0u;

		private static readonly ParameterTexture s_ParamTex;

		private static readonly int k_TransitionTexId;

		private bool _lastKeepAspectRatio;

		private EffectArea _lastEffectArea;

		private static Texture _defaultTransitionTexture;

		[Tooltip("Current location[0-1] for dissolve effect. 0 is not dissolved, 1 is completely dissolved.")]
		[FormerlySerializedAs("m_Location")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_EffectFactor;

		[Tooltip("Edge width.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Width;

		[Tooltip("Edge softness.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Softness;

		[Tooltip("Edge color.")]
		[SerializeField]
		[ColorUsage(false)]
		private Color m_Color;

		[Tooltip("Edge color effect mode.")]
		[SerializeField]
		private ColorMode m_ColorMode;

		[Tooltip("Noise texture for dissolving (single channel texture).")]
		[SerializeField]
		[FormerlySerializedAs("m_NoiseTexture")]
		private Texture m_TransitionTexture;

		[Header("Advanced Option")]
		[Tooltip("The area for effect.")]
		[SerializeField]
		protected EffectArea m_EffectArea;

		[Tooltip("Keep effect aspect ratio.")]
		[SerializeField]
		private bool m_KeepAspectRatio;

		[Header("Effect Player")]
		[SerializeField]
		private EffectPlayer m_Player;

		[Tooltip("Reverse the dissolve effect.")]
		[FormerlySerializedAs("m_ReverseAnimation")]
		[SerializeField]
		private bool m_Reverse;

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

		private static Texture defaultTransitionTexture => null;

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

		public bool keepAspectRatio
		{
			get
			{
				return false;
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

		public override ParameterTexture paramTex => null;

		public EffectPlayer effectPlayer => null;

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

		protected override void SetVerticesDirty()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		public void Play(bool reset = true)
		{
		}

		public void Stop(bool reset = true)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
