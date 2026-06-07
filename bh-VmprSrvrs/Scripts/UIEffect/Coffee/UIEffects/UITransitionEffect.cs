using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[AddComponentMenu("UI/UIEffects/UITransitionEffect", 5)]
	public class UITransitionEffect : BaseMaterialEffect
	{
		public enum EffectMode
		{
			Fade = 1,
			Cutoff = 2,
			Dissolve = 3
		}

		private const uint k_ShaderId = 40u;

		private static readonly int k_TransitionTexId;

		private static readonly ParameterTexture s_ParamTex;

		private bool _lastKeepAspectRatio;

		private static Texture _defaultTransitionTexture;

		[Tooltip("Effect mode.")]
		[SerializeField]
		private EffectMode m_EffectMode;

		[Tooltip("Effect factor between 0(hidden) and 1(shown).")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_EffectFactor;

		[Tooltip("Transition texture (single channel texture).")]
		[SerializeField]
		private Texture m_TransitionTexture;

		[Header("Advanced Option")]
		[Tooltip("The area for effect.")]
		[SerializeField]
		private EffectArea m_EffectArea;

		[Tooltip("Keep effect aspect ratio.")]
		[SerializeField]
		private bool m_KeepAspectRatio;

		[Tooltip("Dissolve edge width.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_DissolveWidth;

		[Tooltip("Dissolve edge softness.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_DissolveSoftness;

		[Tooltip("Dissolve edge color.")]
		[SerializeField]
		[ColorUsage(false)]
		private Color m_DissolveColor;

		[Tooltip("Disable the graphic's raycast target on hidden.")]
		[SerializeField]
		private bool m_PassRayOnHidden;

		[Header("Effect Player")]
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

		public override ParameterTexture paramTex => null;

		public float dissolveWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float dissolveSoftness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color dissolveColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool passRayOnHidden
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public EffectPlayer effectPlayer => null;

		public void Show(bool reset = true)
		{
		}

		public void Hide(bool reset = true)
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

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
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
