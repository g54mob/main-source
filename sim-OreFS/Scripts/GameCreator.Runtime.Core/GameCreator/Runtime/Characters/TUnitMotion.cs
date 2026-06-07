using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Motion")]
	public abstract class TUnitMotion : TUnit, IUnitMotion, IUnitCommon
	{
		private const float MIN_STOP_THRESHOLD = 0.01f;

		[NonSerialized]
		protected Character.MovementType m_MovementType;

		[NonSerialized]
		protected MotionTransient m_Transient;

		[NonSerialized]
		protected TMotion m_MotionData;

		[NonSerialized]
		protected bool m_IsJumping;

		[NonSerialized]
		protected float m_IsJumpingForce;

		[NonSerialized]
		protected float m_StopDistance;

		[NonSerialized]
		protected float m_FollowMinDistance;

		[NonSerialized]
		protected float m_FollowMaxDistance;

		[SerializeField]
		protected MotionInteraction m_Interaction;

		public Vector3 MoveDirection { get; set; }

		public Vector3 MovePosition { get; set; }

		public Vector3 MoveRotation { get; set; }

		public float StopThreshold => m_StopDistance;

		public float FollowMinDistance => m_FollowMinDistance;

		public float FollowMaxDistance => m_FollowMaxDistance;

		public Character.MovementType MovementType
		{
			get
			{
				return m_MovementType;
			}
			set
			{
				m_MovementType = value;
			}
		}

		public bool IsJumping => m_IsJumping;

		public float IsJumpingForce
		{
			get
			{
				if (!IsJumping)
				{
					return 0f;
				}
				return m_IsJumpingForce;
			}
		}

		public abstract float LinearSpeed { get; set; }

		public abstract float AngularSpeed { get; set; }

		public AnimFloat StandLevel { get; }

		public abstract float GravityUpwards { get; set; }

		public abstract float GravityDownwards { get; set; }

		public abstract float TerminalVelocity { get; set; }

		public abstract float JumpForce { get; set; }

		public abstract float JumpCooldown { get; set; }

		public abstract int DashInSuccession { get; set; }

		public abstract bool DashInAir { get; set; }

		public abstract float DashCooldown { get; set; }

		public abstract float Mass { get; set; }

		public abstract float Height { get; set; }

		public abstract float Radius { get; set; }

		public abstract bool UseAcceleration { get; set; }

		public abstract float Acceleration { get; set; }

		public abstract float Deceleration { get; set; }

		public abstract bool CanJump { get; set; }

		public abstract int AirJumps { get; set; }

		public float InteractionRadius
		{
			get
			{
				return m_Interaction.Radius;
			}
			set
			{
				m_Interaction.Radius = value;
			}
		}

		public InteractionMode InteractionMode
		{
			get
			{
				return m_Interaction.Mode;
			}
			set
			{
				m_Interaction.Mode = value;
			}
		}

		protected TUnitMotion()
		{
			MoveDirection = Vector3.zero;
			StandLevel = new AnimFloat(1f, 1f);
			m_MovementType = Character.MovementType.None;
			m_Interaction = new MotionInteraction();
		}

		public virtual void OnStartup(Character character)
		{
			base.Character = character;
			m_Transient = new MotionTransient(this);
		}

		public virtual void AfterStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void OnDispose(Character character)
		{
			base.Character = character;
		}

		public virtual void OnEnable()
		{
			base.Character.EventAfterUpdate += AfterCharacterUpdate;
		}

		public virtual void OnDisable()
		{
			base.Character.EventAfterUpdate -= AfterCharacterUpdate;
		}

		public virtual void OnUpdate()
		{
			if (base.Character.IsDead)
			{
				m_MovementType = Character.MovementType.None;
				return;
			}
			m_MovementType = m_MotionData?.Update() ?? Character.MovementType.None;
			m_MovementType = m_Transient?.Update() ?? Character.MovementType.None;
			StandLevel.UpdateWithDelta(base.Character.Time.DeltaTime);
		}

		public virtual void OnFixedUpdate()
		{
		}

		public void SetMotionTransient(Vector3 direction, float speed, float duration, float fade)
		{
			m_Transient.Set(direction, speed, duration, fade);
		}

		public virtual void MoveToDirection(Vector3 velocity, Space space, int priority)
		{
			if (UpdateMotionData<MotionToDirection>(priority) && m_MotionData is MotionToDirection motionToDirection)
			{
				m_MovementType = motionToDirection.Setup(velocity, space);
			}
		}

		public virtual void StopToDirection(int priority)
		{
			if (UpdateMotionData<MotionToDirection>(priority) && m_MotionData is MotionToDirection motionToDirection && motionToDirection.Priority <= priority)
			{
				motionToDirection.Stop(success: true);
			}
		}

		public virtual void MoveToLocation(Location location, float stopDistance, Action<Character, bool> onFinish, int priority)
		{
			m_StopDistance = Mathf.Max(stopDistance, 0.01f);
			if (!UpdateMotionData<MotionToLocation>(priority))
			{
				onFinish?.Invoke(base.Character, arg2: false);
			}
			else if (m_MotionData is MotionToLocation motionToLocation)
			{
				m_MovementType = motionToLocation.Setup(location, m_StopDistance, onFinish);
			}
		}

		public virtual void MoveToTransform(Transform target, float stopDistance, Action<Character, bool> onFinish, int priority)
		{
			m_StopDistance = Mathf.Max(stopDistance, 0.01f);
			if (!UpdateMotionData<MotionToTransform>(priority))
			{
				onFinish?.Invoke(base.Character, arg2: false);
			}
			else if (m_MotionData is MotionToTransform motionToTransform)
			{
				m_MovementType = motionToTransform.Setup(target, m_StopDistance, onFinish);
			}
		}

		public virtual void MoveToMarker(Marker marker, float stopDistance, Action<Character, bool> onFinish, int priority)
		{
			m_StopDistance = Mathf.Max(stopDistance, marker.StopDistance, 0.01f);
			if (!UpdateMotionData<MotionToMarker>(priority))
			{
				onFinish?.Invoke(base.Character, arg2: false);
			}
			else if (m_MotionData is MotionToMarker motionToMarker)
			{
				m_MovementType = motionToMarker.Setup(marker, m_StopDistance, onFinish);
			}
		}

		public virtual void StartFollowingTarget(Transform target, float minRadius, float maxRadius, int priority)
		{
			m_FollowMinDistance = minRadius;
			m_FollowMaxDistance = maxRadius;
			if (UpdateMotionData<MotionFollow>(priority) && m_MotionData is MotionFollow motionFollow)
			{
				m_MovementType = motionFollow.Setup(target, minRadius, maxRadius);
			}
		}

		public virtual void StopFollowingTarget(int priority)
		{
			if (m_MotionData is MotionFollow motionFollow && motionFollow.Priority <= priority)
			{
				motionFollow.Stop(success: true);
			}
		}

		public virtual MotionFollowData GetFollowingTarget()
		{
			if (!(m_MotionData is MotionFollow motionFollow))
			{
				return MotionFollowData.None;
			}
			return new MotionFollowData(motionFollow.Target, motionFollow.MinRadius, motionFollow.MaxRadius);
		}

		protected bool UpdateMotionData<T>(int priority) where T : TMotion, new()
		{
			if (priority < m_MotionData?.Priority)
			{
				return false;
			}
			if (m_MotionData is T)
			{
				m_MotionData.Priority = priority;
				return true;
			}
			m_MotionData?.Stop(success: false);
			m_MotionData = new T();
			m_MotionData.Initialize(this, priority);
			return true;
		}

		public virtual void Jump()
		{
			Jump(JumpForce);
		}

		public virtual void Jump(float force)
		{
			if (!base.Character.IsDead && CanJump)
			{
				m_IsJumping = true;
				m_IsJumpingForce = force;
			}
		}

		public void ForceJump()
		{
			ForceJump(JumpForce);
		}

		public void ForceJump(float force)
		{
			m_IsJumping = true;
			m_IsJumpingForce = force;
		}

		private void AfterCharacterUpdate()
		{
			m_IsJumping = false;
		}

		public virtual void OnDrawGizmos(Character character)
		{
			if (character.IsDead)
			{
				Gizmos.color = Color.red;
			}
			else
			{
				Gizmos.color = (character.IsPlayer ? Color.green : Color.cyan);
			}
			Vector3 vector = character.transform.position - Vector3.up * Height * 0.5f;
			GizmosExtension.Cylinder(vector, Height, Radius);
			GizmosExtension.Triangle(vector + character.transform.TransformDirection(Vector3.forward) * (Radius + 0.1f), character.transform.rotation, 0.25f);
			m_Interaction.DrawGizmos(character);
			if (Application.isPlaying)
			{
				m_MotionData?.OnDrawGizmos();
			}
		}
	}
}
