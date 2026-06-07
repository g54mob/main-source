using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[AddComponentMenu("UI/UIEffect/UIShiny", 2)]
	public class UIShiny : UIEffectBase
	{
		public const string shaderName = "UI/Hidden/UI-Effect-Shiny";

		private static readonly ParameterTexture _ptex;

		[Tooltip("Location for shiny effect.")]
		[FormerlySerializedAs("m_Location")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_EffectFactor;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("Width for shiny effect.")]
		private float m_Width;

		[SerializeField]
		[Range(-180f, 180f)]
		[Tooltip("Rotation for shiny effect.")]
		private float m_Rotation;

		[Tooltip("Softness for shiny effect.")]
		[SerializeField]
		[Range(0.01f, 1f)]
		private float m_Softness;

		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("m_Alpha")]
		[Tooltip("Brightness for shiny effect.")]
		private float m_Brightness;

		[SerializeField]
		[FormerlySerializedAs("m_Highlight")]
		[Tooltip("Gloss factor for shiny effect.")]
		[Range(0f, 1f)]
		private float m_Gloss;

		[SerializeField]
		[Tooltip("The area for effect.")]
		protected EffectArea m_EffectArea;

		[SerializeField]
		private EffectPlayer m_Player;

		[HideInInspector]
		[Obsolete]
		[SerializeField]
		private bool m_Play;

		[Obsolete]
		[HideInInspector]
		[SerializeField]
		private bool m_Loop;

		[SerializeField]
		[HideInInspector]
		[Range(0.1f, 10f)]
		[Obsolete]
		private float m_Duration;

		[Range(0f, 10f)]
		[SerializeField]
		[HideInInspector]
		[Obsolete]
		private float m_LoopDelay;

		[SerializeField]
		[HideInInspector]
		[Obsolete]
		private AnimatorUpdateMode m_UpdateMode;

		private float _lastRotation;

		[Obsolete("Use effectFactor instead (UnityUpgradable) -> effectFactor")]
		public float location
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		[Obsolete("Use brightness instead (UnityUpgradable) -> brightness")]
		public float alpha
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

		[Obsolete("Use gloss instead (UnityUpgradable) -> gloss")]
		public float highlight
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

		public bool play
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool loop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float duration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float loopDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimatorUpdateMode updateMode
		{
			get
			{
				return default(AnimatorUpdateMode);
			}
			set
			{
			}
		}

		public override ParameterTexture ptex => null;

		private EffectPlayer _player => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void ModifyMesh(VertexHelper vh)
		{
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		protected override void SetDirty()
		{
		}
	}
}
