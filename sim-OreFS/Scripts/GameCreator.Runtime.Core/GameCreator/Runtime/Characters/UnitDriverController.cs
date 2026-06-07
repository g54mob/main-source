using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Controller")]
	[Image(typeof(IconCapsuleSolid), ColorTheme.Type.Green)]
	[Category("Character Controller")]
	[Description("Moves the Character using Unity's default Character Controller")]
	public class UnitDriverController : TUnitDriver
	{
		private const float MAX_SLOPE_SLIDE_FROM_CHARACTER = 90f;

		private const float EPSILON_SLIDE_FROM_CHARACTER = 0.001f;

		private const float VELOCITY_INTERVAL = 0.1f;

		[SerializeField]
		protected float m_SkinWidth = 0.08f;

		[SerializeField]
		protected float m_PushForce = 1f;

		[SerializeField]
		protected float m_MaxSlope = 45f;

		[SerializeField]
		protected float m_StepHeight = 0.3f;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		[NonSerialized]
		protected CharacterController m_Controller;

		[NonSerialized]
		protected Vector3 m_MoveDirection;

		[NonSerialized]
		protected float m_VerticalSpeed;

		[NonSerialized]
		protected AnimVector3 m_FloorNormal;

		[NonSerialized]
		protected int m_GroundFrame = -100;

		[NonSerialized]
		protected float m_GroundTime = -100f;

		[NonSerialized]
		protected float m_JumpTime = -100f;

		[NonSerialized]
		private DriverControllerComponent m_Helper;

		[NonSerialized]
		private DriverAdditionalTranslation m_AddTranslation;

		[NonSerialized]
		private Vector3 m_PreviousPosition;

		[NonSerialized]
		private Vector3 m_Velocity;

		[NonSerialized]
		private Vector3 m_AccumulatedDisplacement;

		[NonSerialized]
		private float m_AccumulatedTime;

		[NonSerialized]
		private Vector3 m_SlideFromCharacter;

		[NonSerialized]
		private int m_FrameSlideFromCharacter;

		[NonSerialized]
		private bool m_IsOnSteepSlope;

		public override Vector3 WorldMoveDirection
		{
			get
			{
				if (!(m_Controller != null))
				{
					return Vector3.zero;
				}
				return m_Velocity;
			}
		}

		public override Vector3 LocalMoveDirection => base.Transform.InverseTransformDirection(WorldMoveDirection);

		public override float SkinWidth
		{
			get
			{
				if (!(m_Controller != null))
				{
					return 0f;
				}
				return m_Controller.skinWidth;
			}
		}

		public override bool IsGrounded
		{
			get
			{
				if (m_Controller == null)
				{
					return false;
				}
				if (m_ForceGrounded)
				{
					return true;
				}
				bool flag = m_FrameSlideFromCharacter < Time.frameCount;
				if (m_Controller.isGrounded && flag)
				{
					return !m_IsOnSteepSlope;
				}
				return false;
			}
		}

		public override Vector3 FloorNormal => m_FloorNormal.Current;

		public override bool Collision
		{
			get
			{
				return m_Controller.detectCollisions;
			}
			set
			{
				m_Controller.detectCollisions = value;
			}
		}

		public override Axonometry Axonometry
		{
			get
			{
				return m_Axonometry;
			}
			set
			{
				m_Axonometry = value;
			}
		}

		public UnitDriverController()
		{
			m_MoveDirection = Vector3.zero;
			m_VerticalSpeed = 0f;
			m_SlideFromCharacter = Vector3.zero;
			m_FrameSlideFromCharacter = -1;
		}

		public override void OnEnable()
		{
			if (base.Character != null)
			{
				m_GroundTime = base.Character.Time.Time;
				m_GroundFrame = base.Character.Time.Frame;
				m_Velocity = Vector3.zero;
				m_IsOnSteepSlope = false;
				m_PreviousPosition = base.Transform.localPosition;
				if (base.Transform.parent != null)
				{
					Vector3 localScale = base.Transform.parent.localScale;
					m_PreviousPosition = Vector3.Scale(m_PreviousPosition, localScale);
				}
			}
		}

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_FloorNormal = new AnimVector3(Vector3.up, 0.15f);
			m_Controller = base.Character.GetComponent<CharacterController>();
			if (m_Controller == null)
			{
				GameObject gameObject = base.Character.gameObject;
				m_Controller = gameObject.AddComponent<CharacterController>();
				m_Controller.hideFlags = HideFlags.HideInInspector;
				float height = base.Character.Motion.Height;
				float radius = base.Character.Motion.Radius;
				m_Controller.height = height;
				m_Controller.radius = radius;
				m_Controller.center = Vector3.zero;
				m_Controller.skinWidth = m_SkinWidth;
				m_Controller.slopeLimit = m_MaxSlope;
				m_Controller.stepOffset = m_StepHeight;
				m_Controller.minMoveDistance = 0f;
			}
			m_Helper = DriverControllerComponent.Register(base.Character, OnControllerColliderHit);
			character.Ragdoll.EventBeforeStartRagdoll += OnStartRagdoll;
			character.Ragdoll.EventAfterStartRecover += OnEndRagdoll;
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			UnityEngine.Object.Destroy(m_Helper);
			UnityEngine.Object.Destroy(m_Controller);
			character.Ragdoll.EventBeforeStartRagdoll -= OnStartRagdoll;
			character.Ragdoll.EventAfterStartRecover -= OnEndRagdoll;
		}

		public override void OnUpdate()
		{
			if (!base.Character.IsDead && !(m_Controller == null))
			{
				UpdateProperties();
				UpdateGravity(base.Character.Motion);
				UpdateJump(base.Character.Motion);
				UpdateTranslation(base.Character.Motion);
				m_Axonometry?.ProcessPosition(this, base.Transform.position);
				Vector3 vector = base.Transform.localPosition;
				if (base.Transform.parent != null)
				{
					Vector3 localScale = base.Transform.parent.localScale;
					vector = Vector3.Scale(vector, localScale);
				}
				m_AccumulatedDisplacement += vector - m_PreviousPosition;
				m_AccumulatedTime += base.Character.Time.DeltaTime;
				if (m_AccumulatedTime >= 0.1f)
				{
					Vector3 vector2 = m_AccumulatedDisplacement / m_AccumulatedTime;
					m_Velocity = ((base.Transform.parent != null) ? base.Transform.parent.TransformDirection(vector2) : vector2);
					m_AccumulatedDisplacement = Vector3.zero;
					m_AccumulatedTime = 0f;
				}
				m_PreviousPosition = vector;
			}
		}

		public override void OnFixedUpdate()
		{
			if (!(m_Controller == null) && !base.Character.IsDead)
			{
				base.OnFixedUpdate();
				UpdatePhysicProperties();
			}
		}

		protected virtual void UpdateProperties()
		{
			m_FloorNormal.UpdateWithDelta(base.Character.Time.DeltaTime);
			m_MoveDirection = Vector3.zero;
			float num = Vector3.Angle(FloorNormal, Vector3.up);
			m_IsOnSteepSlope = IsGrounded && num > m_MaxSlope;
			if (Math.Abs(m_Controller.skinWidth - m_SkinWidth) > float.Epsilon)
			{
				m_Controller.skinWidth = m_SkinWidth;
			}
			if (Math.Abs(m_Controller.slopeLimit - m_MaxSlope) > float.Epsilon)
			{
				m_Controller.slopeLimit = m_MaxSlope;
			}
			if (Math.Abs(m_Controller.stepOffset - m_StepHeight) > float.Epsilon)
			{
				m_Controller.stepOffset = m_StepHeight;
			}
		}

		protected virtual void UpdatePhysicProperties()
		{
			float height = base.Character.Motion.Height;
			float radius = base.Character.Motion.Radius;
			if (Math.Abs(m_Controller.height - height) > float.Epsilon)
			{
				float num = (m_Controller.height - height) * 0.5f;
				base.Transform.localPosition += Vector3.down * num;
				m_Controller.height = height;
				base.Character.Animim.ApplyMannequinPosition();
			}
			if (Math.Abs(m_Controller.radius - radius) > float.Epsilon)
			{
				m_Controller.radius = radius;
			}
			if (m_Controller.center != Vector3.zero)
			{
				m_Controller.center = Vector3.zero;
			}
		}

		protected virtual void UpdateJump(IUnitMotion motion)
		{
			if (motion.IsJumping && m_JumpTime + motion.JumpCooldown < base.Character.Time.Time)
			{
				m_VerticalSpeed = motion.IsJumpingForce;
				m_JumpTime = base.Character.Time.Time;
				base.Character.OnJump(motion.IsJumpingForce);
			}
		}

		protected virtual void UpdateGravity(IUnitMotion motion)
		{
			float num = ((WorldMoveDirection.y >= 0f) ? motion.GravityUpwards : motion.GravityDownwards);
			num *= base.GravityInfluence;
			m_VerticalSpeed += num * base.Character.Time.DeltaTime;
			if (m_ForceGrounded || (m_Controller.isGrounded && !m_IsOnSteepSlope))
			{
				if (base.Character.Time.Time - m_GroundTime > 0.3f && base.Character.Time.Frame - m_GroundFrame > 2)
				{
					base.Character.OnLand(m_VerticalSpeed);
				}
				m_GroundTime = base.Character.Time.Time;
				m_GroundFrame = base.Character.Time.Frame;
				m_VerticalSpeed = Mathf.Max(m_VerticalSpeed, num);
			}
			m_VerticalSpeed = Mathf.Max(m_VerticalSpeed, motion.TerminalVelocity);
		}

		protected virtual void UpdateTranslation(IUnitMotion motion)
		{
			Vector3 motion2 = Vector3.up * (m_VerticalSpeed * base.Character.Time.DeltaTime);
			Vector3 vector = ((!base.UpdateKinematics) ? Vector3.zero : (motion.MovementType switch
			{
				Character.MovementType.MoveToDirection => UpdateMoveToDirection(motion), 
				Character.MovementType.MoveToPosition => UpdateMoveToPosition(motion), 
				_ => Vector3.zero, 
			}));
			Vector3 a = vector;
			Vector3 rootMotionDeltaPosition = base.Character.Animim.RootMotionDeltaPosition;
			Vector3 vector2 = Vector3.Lerp(a, rootMotionDeltaPosition, base.Character.RootMotionPosition);
			motion2 += m_Axonometry?.ProcessTranslation(this, vector2) ?? vector2;
			if (m_IsOnSteepSlope && m_Controller.isGrounded)
			{
				Vector3 normalized = Vector3.ProjectOnPlane(m_FloorNormal.Current, Vector3.up).normalized;
				motion2 += normalized * (Mathf.Abs(motion.GravityDownwards) * base.Character.Time.DeltaTime);
			}
			m_IsOnSteepSlope = false;
			if (m_FrameSlideFromCharacter >= Time.frameCount - 1)
			{
				float num = Mathf.Abs(motion.GravityDownwards) * base.Character.Time.DeltaTime;
				motion2 += m_SlideFromCharacter * num;
			}
			motion2 += m_AddTranslation.Consume();
			if (m_Controller.enabled)
			{
				m_Controller.Move(motion2);
			}
		}

		protected virtual Vector3 UpdateMoveToDirection(IUnitMotion motion)
		{
			m_MoveDirection = motion.MoveDirection;
			return m_MoveDirection * base.Character.Time.DeltaTime;
		}

		protected virtual Vector3 UpdateMoveToPosition(IUnitMotion motion)
		{
			float num = Vector3.Distance(base.Character.Feet, motion.MovePosition);
			float num2 = Math.Max(motion.Height, motion.Radius * 2f);
			float num3 = motion.MoveDirection.magnitude;
			if (num < num2)
			{
				num3 = Mathf.Lerp(motion.LinearSpeed, Mathf.Max(motion.LinearSpeed * 0.25f, 1f), 1f - Mathf.Clamp01(num / num2));
			}
			m_MoveDirection = motion.MoveDirection;
			return m_MoveDirection.normalized * (num3 * base.Character.Time.DeltaTime);
		}

		public override void SetPosition(Vector3 position)
		{
			position += Vector3.up * (base.Character.Motion.Height * 0.5f);
			base.Transform.position = position;
			Physics.SyncTransforms();
		}

		public override void SetRotation(Quaternion rotation)
		{
			base.Transform.rotation = rotation;
			Physics.SyncTransforms();
		}

		public override void SetScale(Vector3 scale)
		{
			base.Transform.localScale = scale;
			Physics.SyncTransforms();
		}

		public override void AddPosition(Vector3 amount)
		{
			m_AddTranslation.Add(amount);
		}

		public override void AddRotation(Quaternion amount)
		{
			base.Transform.rotation *= amount;
			Physics.SyncTransforms();
		}

		public override void AddScale(Vector3 scale)
		{
			base.Transform.localScale += scale;
			Physics.SyncTransforms();
		}

		public override void ResetVerticalVelocity()
		{
			m_VerticalSpeed = 0f;
		}

		protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
		{
			float angle = Vector3.Angle(hit.normal, Vector3.up);
			float num = Mathf.Min(base.Character.Motion.Radius, base.Character.Motion.Height * 0.5f);
			if (hit.point.y < base.Character.Feet.y + (num - 0.01f))
			{
				m_FloorNormal.Target = hit.normal;
			}
			OnColliderHitPushRigidbodies(hit, angle);
			OnColliderHitSlideFromCharacters(hit, angle);
		}

		private void OnColliderHitSlideFromCharacters(ControllerColliderHit hit, float angle)
		{
			if (!(WorldMoveDirection.y > 0f) && !(angle >= 90f))
			{
				Character character = hit.collider.Get<Character>();
				if (!(character == null))
				{
					Vector3 vector = Vector3.Scale(base.Character.transform.position, Vector3Plane.NormalUp) - Vector3.Scale(character.transform.position, Vector3Plane.NormalUp);
					vector = ((vector.sqrMagnitude > 0.001f) ? vector.normalized : character.transform.forward);
					vector.y = -1f;
					m_SlideFromCharacter = vector;
					m_FrameSlideFromCharacter = Time.frameCount;
				}
			}
		}

		private void OnColliderHitPushRigidbodies(ControllerColliderHit hit, float angle)
		{
			if (!(m_PushForce < float.Epsilon) && !(angle > 90f) && !(angle < 5f))
			{
				Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;
				if ((bool)attachedRigidbody && !attachedRigidbody.isKinematic)
				{
					Vector3 force = hit.controller.velocity * m_PushForce;
					force /= base.Character.Time.FixedDeltaTime;
					attachedRigidbody.AddForceAtPosition(force, hit.point, ForceMode.Force);
				}
			}
		}

		private void OnStartRagdoll()
		{
			m_Controller.enabled = false;
			m_Controller.detectCollisions = false;
		}

		private void OnEndRagdoll()
		{
			m_Controller.enabled = true;
			m_Controller.detectCollisions = true;
			m_Controller.Move(Vector3.zero);
			m_MoveDirection = Vector3.zero;
		}

		public override void OnDrawGizmos(Character character)
		{
			if (Application.isPlaying)
			{
				IUnitMotion motion = character.Motion;
				if (motion != null && motion.MovementType == Character.MovementType.MoveToPosition)
				{
					OnDrawGizmosToTarget(motion);
				}
			}
		}

		protected void OnDrawGizmosToTarget(IUnitMotion motion)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(base.Character.Feet, motion.MovePosition);
		}

		public override string ToString()
		{
			return "Character Controller";
		}
	}
}
