using UnityEngine;

namespace Coffee.UIEffects
{
	public class UIEffectReplica : UIEffectBase, ISerializationCallbackReceiver
	{
		[SerializeField]
		private UIEffect m_Target;

		[SerializeField]
		private UIEffectPreset m_Preset;

		[SerializeField]
		private bool m_UseTargetTransform;

		[SerializeField]
		protected float m_SamplingScale;

		[SerializeField]
		protected bool m_AllowToModifyMeshShape;

		[SerializeField]
		protected RectTransform m_CustomRoot;

		private UIEffect _currentTarget;

		public UIEffect target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UIEffectPreset preset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool useTargetTransform
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

		public override float actualSamplingScale => 0f;

		public override bool canModifyShape => false;

		public override uint effectId => 0u;

		public override UIEffectContext context => null;

		public override RectTransform transitionRoot => null;

		private bool isTargetInScene => false;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void RefreshTarget(UIEffect newTarget)
		{
		}

		internal override void UpdateContext(UIEffectContext dst)
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

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
