using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Animation")]
	public abstract class TUnitAnimim : TUnit, IUnitAnimim, IUnitCommon
	{
		protected const float LAND_RECOVERY_SMOOTH_IN = 0.3f;

		protected const float LAND_RECOVERY_DURATION = 0.1f;

		protected const float LAND_RECOVERY_SMOOTH_OUT = 0.5f;

		protected const float MODEL_OFFSET_WEIGHT_SMOOTH = 5f;

		public static readonly int[] PHASES = new int[4]
		{
			Animator.StringToHash("Phase-0"),
			Animator.StringToHash("Phase-1"),
			Animator.StringToHash("Phase-2"),
			Animator.StringToHash("Phase-3")
		};

		[SerializeField]
		protected Vector3 m_Position;

		[SerializeField]
		protected Vector3 m_Rotation = Vector3.zero;

		[SerializeField]
		protected Vector3 m_Scale = Vector3.one;

		[SerializeField]
		protected float m_SmoothTime = 0.5f;

		[SerializeField]
		protected Transform m_Mannequin;

		[SerializeField]
		protected Animator m_Animator;

		[SerializeField]
		protected State m_StartState;

		[SerializeField]
		protected Reaction m_Reaction;

		[NonSerialized]
		private AnimimAnimatorProxy m_AnimatorProxy;

		[NonSerialized]
		private AnimVector3 m_Offset = new AnimVector3(Vector3.zero, 5f);

		public float SmoothTime
		{
			get
			{
				return m_SmoothTime;
			}
			set
			{
				m_SmoothTime = Math.Max(0f, value);
			}
		}

		public Vector3 Position
		{
			get
			{
				return m_Offset.Target;
			}
			set
			{
				m_Offset.Target = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return Quaternion.Euler(m_Rotation);
			}
			set
			{
				m_Rotation = value.eulerAngles;
			}
		}

		public Vector3 Scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}

		public Transform Mannequin
		{
			get
			{
				if (m_Mannequin == null)
				{
					if (!(Animator != null))
					{
						return null;
					}
					return Animator.transform;
				}
				return m_Mannequin;
			}
			set
			{
				m_Mannequin = value;
			}
		}

		public Animator Animator
		{
			get
			{
				return m_Animator;
			}
			set
			{
				m_Animator = value;
			}
		}

		public Reaction Reaction
		{
			get
			{
				return m_Reaction;
			}
			set
			{
				m_Reaction = value;
			}
		}

		public Vector3 RootMotionDeltaPosition { get; private set; }

		public Quaternion RootMotionDeltaRotation { get; private set; }

		public event Action<int> EventOnAnimatorIK;

		public virtual void OnStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void AfterStartup(Character character)
		{
			base.Character = character;
			if (m_StartState != null)
			{
				base.Character.States.SetState(m_StartState, -1, BlendMode.Blend, new ConfigState(0f, 1f, 1f, 0f, 0f));
			}
		}

		public virtual void OnDispose(Character character)
		{
			base.Character = character;
			if (base.Character.Ragdoll.IsRagdoll && m_Animator != null)
			{
				UnityEngine.Object.Destroy(m_Animator.gameObject);
			}
		}

		public virtual void OnEnable()
		{
			base.Character.EventLand += OnLand;
		}

		public virtual void OnDisable()
		{
			base.Character.EventLand -= OnLand;
		}

		public virtual void OnUpdate()
		{
			RequireAnimatorProxy();
			OnUpdateModelLocation();
		}

		public virtual void OnFixedUpdate()
		{
		}

		public void ApplyMannequinPosition()
		{
			if (!base.Character.Ragdoll.IsRagdoll)
			{
				Vector3 vector = Vector3.up * (base.Character.Motion.Height * -0.5f);
				Vector3 vector2 = m_Offset.Current - Vector3.up * base.Character.Driver.SkinWidth;
				Vector3 localPosition = vector + vector2 + m_Position;
				Mannequin.localPosition = localPosition;
			}
		}

		public void ApplyMannequinRotation()
		{
			if (!base.Character.Ragdoll.IsRagdoll)
			{
				Mannequin.localRotation = Quaternion.Euler(m_Rotation);
			}
		}

		public void ApplyMannequinScale()
		{
			if (!base.Character.Ragdoll.IsRagdoll)
			{
				Mannequin.localScale = m_Scale;
			}
		}

		private void RequireAnimatorProxy()
		{
			if (!(m_AnimatorProxy != null))
			{
				m_AnimatorProxy = Animator.gameObject.AddComponent<AnimimAnimatorProxy>();
				m_AnimatorProxy.Animim = this;
			}
		}

		private void OnUpdateModelLocation()
		{
			if (!base.Character.Ragdoll.IsRagdoll)
			{
				m_Offset.UpdateWithDelta(base.Character.Time.DeltaTime);
				ApplyMannequinPosition();
				ApplyMannequinRotation();
				ApplyMannequinScale();
			}
		}

		private void OnLand(float velocity)
		{
			IUnitMotion motion = base.Character.Motion;
			float num = Math.Abs(velocity) / (motion.JumpForce * 4f);
			motion.StandLevel.SetTransient(new AnimFloat.Transient(Mathf.Clamp01(motion.StandLevel.Current - num), 0.3f, 0.1f, 0.5f));
		}

		public void OnAnimatorIK(int layerIndex)
		{
			this.EventOnAnimatorIK?.Invoke(layerIndex);
		}

		public void OnAnimatorMove()
		{
			Animator.applyRootMotion = true;
			RootMotionDeltaPosition = Animator.deltaPosition;
			RootMotionDeltaRotation = Animator.deltaRotation;
		}

		public virtual void OnDrawGizmos(Character character)
		{
		}
	}
}
