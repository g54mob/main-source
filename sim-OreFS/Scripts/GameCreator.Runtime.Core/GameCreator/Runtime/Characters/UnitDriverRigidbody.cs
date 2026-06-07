using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Rigidbody (obsolete)")]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	[Category("Rigidbody (obsolete)")]
	[Description("Moves the Character using a physics based Rigidbody component")]
	public class UnitDriverRigidbody : TUnitDriver
	{
		[SerializeField]
		protected PhysicsMaterial m_Material;

		[SerializeField]
		private RigidbodyInterpolation m_Interpolation = RigidbodyInterpolation.Interpolate;

		[SerializeField]
		protected float m_GroundDistance = 0.1f;

		[SerializeField]
		protected LayerMask m_GroundMask = -5;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		[NonSerialized]
		protected CapsuleCollider m_Capsule;

		[NonSerialized]
		protected Rigidbody m_Rigidbody;

		[NonSerialized]
		private RaycastHit[] m_HitsBuffer = new RaycastHit[1];

		[NonSerialized]
		protected float m_LastVerticalSpeed;

		[NonSerialized]
		protected float m_LastMovementSpeed;

		[NonSerialized]
		protected bool m_IsGrounded;

		[NonSerialized]
		protected AnimFloat m_IsGroundedSmooth;

		[NonSerialized]
		protected AnimVector3 m_FloorNormal;

		[NonSerialized]
		protected int m_GroundFrame = -100;

		[NonSerialized]
		protected float m_GroundTime = -100f;

		[NonSerialized]
		protected float m_JumpTime = -100f;

		[NonSerialized]
		private DriverAdditionalTranslation m_AddTranslation;

		public override Vector3 WorldMoveDirection => m_Rigidbody.linearVelocity;

		public override Vector3 LocalMoveDirection => base.Transform.InverseTransformDirection(WorldMoveDirection);

		public override float SkinWidth => 0f;

		public override bool IsGrounded
		{
			get
			{
				if (!m_ForceGrounded)
				{
					return m_IsGrounded;
				}
				return true;
			}
		}

		public override Vector3 FloorNormal => m_FloorNormal.Current;

		public override bool Collision
		{
			get
			{
				return m_Capsule.enabled;
			}
			set
			{
				m_Capsule.enabled = value;
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

		public UnitDriverRigidbody()
		{
			m_LastVerticalSpeed = 0f;
			m_LastMovementSpeed = 0f;
		}

		public override void OnEnable()
		{
			if (base.Character != null)
			{
				m_GroundTime = base.Character.Time.Time;
				m_GroundFrame = base.Character.Time.Frame;
			}
		}

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_IsGroundedSmooth = new AnimFloat(1f, 0.01f);
			m_FloorNormal = new AnimVector3(Vector3.up, 0.05f);
			m_Capsule = base.Character.GetComponent<CapsuleCollider>();
			if (!m_Capsule)
			{
				GameObject gameObject = base.Character.gameObject;
				m_Capsule = gameObject.AddComponent<CapsuleCollider>();
				m_Capsule.hideFlags = HideFlags.HideInInspector;
			}
			m_Rigidbody = base.Character.GetComponent<Rigidbody>();
			if (!m_Rigidbody)
			{
				GameObject gameObject2 = base.Character.gameObject;
				m_Rigidbody = gameObject2.AddComponent<Rigidbody>();
				m_Rigidbody.hideFlags = HideFlags.HideInInspector;
			}
			character.Ragdoll.EventBeforeStartRagdoll += OnStartRagdoll;
			character.Ragdoll.EventAfterStartRecover += OnEndRagdoll;
			m_Rigidbody.useGravity = false;
			m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			UnityEngine.Object.Destroy(m_Capsule);
			UnityEngine.Object.Destroy(m_Rigidbody);
			character.Ragdoll.EventBeforeStartRagdoll -= OnStartRagdoll;
			character.Ragdoll.EventAfterStartRecover -= OnEndRagdoll;
		}

		public override void OnUpdate()
		{
			if (!base.Character.IsDead)
			{
				UpdateProperties();
				UpdateJump(base.Character.Motion);
			}
		}

		public override void OnFixedUpdate()
		{
			if (!base.Character.IsDead)
			{
				CheckGround(base.Character.Motion);
				UpdateGravity(base.Character.Motion);
				UpdateTranslation(base.Character.Motion);
				m_Axonometry?.ProcessPosition(this, base.Transform.position);
			}
		}

		protected virtual void UpdateProperties()
		{
			m_FloorNormal.UpdateWithDelta(base.Character.Time.DeltaTime);
			float height = base.Character.Motion.Height;
			float radius = base.Character.Motion.Radius;
			if (Math.Abs(m_Capsule.height - height) > float.Epsilon)
			{
				m_Capsule.height = height;
			}
			if (Math.Abs(m_Capsule.radius - radius) > float.Epsilon)
			{
				m_Capsule.radius = radius;
			}
			if (m_Capsule.center != Vector3.zero)
			{
				m_Capsule.center = Vector3.zero;
			}
			if (m_Material != null)
			{
				m_Capsule.material = m_Material;
			}
			if (m_Rigidbody.interpolation != m_Interpolation)
			{
				m_Rigidbody.interpolation = m_Interpolation;
			}
			if (Math.Abs(m_Rigidbody.mass - base.Character.Motion.Mass) > float.Epsilon)
			{
				m_Rigidbody.mass = base.Character.Motion.Mass;
			}
		}

		protected virtual void CheckGround(IUnitMotion motion)
		{
			int num = Physics.RaycastNonAlloc(base.Character.Feet + Vector3.up * m_GroundDistance, Vector3.down, m_HitsBuffer, m_GroundDistance * 2f, m_GroundMask, QueryTriggerInteraction.Ignore);
			m_IsGrounded = num > 0;
			m_FloorNormal.Target = (m_IsGrounded ? m_HitsBuffer[0].normal : Vector3.up);
			float fixedDeltaTime = base.Character.Time.FixedDeltaTime;
			m_IsGroundedSmooth.UpdateWithDelta(m_IsGrounded ? 1f : 0f, 0.3f, fixedDeltaTime);
		}

		protected virtual void UpdateJump(IUnitMotion motion)
		{
			if (motion.IsJumping && motion.CanJump && m_JumpTime + motion.JumpCooldown < base.Character.Time.Time)
			{
				m_Rigidbody.AddForce(Vector3.up * motion.IsJumpingForce, ForceMode.VelocityChange);
				m_JumpTime = base.Character.Time.Time;
				base.Character.OnJump(motion.IsJumpingForce);
			}
		}

		protected virtual void UpdateGravity(IUnitMotion motion)
		{
			Vector3 vector = Vector3.up * m_Rigidbody.mass;
			float num = ((WorldMoveDirection.y >= 0f) ? motion.GravityUpwards : motion.GravityDownwards);
			num *= base.GravityInfluence;
			m_Rigidbody.AddForce(vector * num, ForceMode.Force);
			if (m_ForceGrounded || m_IsGrounded)
			{
				if (base.Character.Time.Time - m_GroundTime > 0.3f && base.Character.Time.Frame - m_GroundFrame > 2)
				{
					base.Character.OnLand(m_LastVerticalSpeed);
				}
				m_GroundTime = base.Character.Time.Time;
				m_GroundFrame = base.Character.Time.Frame;
			}
			Vector3 linearVelocity = m_Rigidbody.linearVelocity;
			m_Rigidbody.linearVelocity = new Vector3(linearVelocity.x, Mathf.Max(linearVelocity.y, motion.TerminalVelocity), linearVelocity.z);
			m_LastVerticalSpeed = m_Rigidbody.linearVelocity.y;
		}

		protected virtual void UpdateTranslation(IUnitMotion motion)
		{
			Vector3 a = ((!base.UpdateKinematics) ? Vector3.zero : (motion.MovementType switch
			{
				Character.MovementType.MoveToDirection => UpdateMoveToDirection(motion), 
				Character.MovementType.MoveToPosition => UpdateMoveToPosition(motion), 
				_ => Vector3.zero, 
			}));
			Vector3 rootMotionDeltaPosition = base.Character.Animim.RootMotionDeltaPosition;
			Vector3 vector = Vector3.Lerp(a, rootMotionDeltaPosition, base.Character.RootMotionPosition);
			Vector3 vector2 = m_Axonometry?.ProcessTranslation(this, vector) ?? vector;
			Vector3 vector3 = Vector3.Scale(m_Rigidbody.linearVelocity, Vector3Plane.NormalUp);
			float magnitude = vector2.XY().magnitude;
			float num = ((magnitude >= m_LastMovementSpeed) ? (base.Character.Motion.Acceleration * base.Character.Motion.Mass) : (base.Character.Motion.Mass / base.Character.Motion.Deceleration));
			m_LastMovementSpeed = magnitude;
			vector2 = vector2.normalized;
			vector2 *= (base.Character.Motion.UseAcceleration ? num : 9999f);
			if (vector3.magnitude >= base.Character.Motion.LinearSpeed)
			{
				if (Mathf.Abs(vector3.x + vector2.x) >= Mathf.Abs(vector3.x))
				{
					vector2.x = 0f;
				}
				if (Mathf.Abs(vector3.z + vector2.z) >= Mathf.Abs(vector3.z))
				{
					vector2.z = 0f;
				}
			}
			Vector3 vector4 = new Vector3(vector2.x, m_Rigidbody.linearVelocity.y, vector2.z);
			vector4 = m_Axonometry?.ProcessTranslation(this, vector4) ?? vector4;
			m_Rigidbody.AddForce(vector4, ForceMode.Acceleration);
			Vector3 vector5 = m_AddTranslation.Consume();
			if (vector5 != Vector3.zero)
			{
				m_Rigidbody.AddForce(vector5, ForceMode.VelocityChange);
			}
		}

		protected virtual Vector3 UpdateMoveToDirection(IUnitMotion motion)
		{
			return motion.MoveDirection;
		}

		protected virtual Vector3 UpdateMoveToPosition(IUnitMotion motion)
		{
			float num = Vector3.Distance(base.Character.Feet, motion.MovePosition);
			float num2 = Math.Max(motion.Height, motion.Radius * 2f);
			float num3 = motion.MoveDirection.magnitude;
			if (num < num2)
			{
				num3 = Mathf.Lerp(motion.LinearSpeed, motion.LinearSpeed * 0.25f, 1f - Mathf.Clamp01(num / num2));
			}
			return motion.MoveDirection.normalized * num3;
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

		private void OnStartRagdoll()
		{
			m_Rigidbody.isKinematic = true;
			m_Capsule.enabled = false;
		}

		private void OnEndRagdoll()
		{
			m_Capsule.enabled = true;
			m_Rigidbody.isKinematic = false;
			m_Rigidbody.linearVelocity = Vector3.zero;
		}

		public override void ResetVerticalVelocity()
		{
			m_Rigidbody.linearVelocity = new Vector3(m_Rigidbody.linearVelocity.x, 0f, m_Rigidbody.linearVelocity.z);
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
			return "Rigidbody";
		}
	}
}
