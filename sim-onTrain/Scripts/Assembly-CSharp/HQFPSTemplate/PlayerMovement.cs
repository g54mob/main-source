using System;
using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerMovement : PlayerComponent
	{
		[Serializable]
		public class SprintingStateModule
		{
			public bool Enabled = true;

			[ShowIf("Enabled", true, 10f)]
			[Range(1f, 10f)]
			public float SpeedMultiplier = 4.5f;

			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 3f)]
			public float StepLength = 1.9f;
		}

		[Serializable]
		public class CoreMovementModule
		{
			[Range(0f, 20f)]
			public float Acceleration = 5f;

			[Range(0f, 20f)]
			public float Damping = 8f;

			[Range(0f, 1f)]
			public float AirborneControl = 0.15f;

			[Range(0f, 3f)]
			public float StepLength = 1.2f;

			[Range(0f, 10f)]
			public float ForwardSpeed = 2.5f;

			[Range(0f, 10f)]
			public float BackSpeed = 2.5f;

			[Range(0f, 10f)]
			public float SideSpeed = 2.5f;

			public AnimationCurve SlopeSpeedMult = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

			public float AntiBumpFactor = 1f;

			[Range(0f, 1f)]
			public float HeadBounceFactor = 0.65f;
		}

		[Serializable]
		public class JumpStateModule
		{
			public bool Enabled = true;

			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 3f)]
			public float JumpHeight = 1f;

			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 1.5f)]
			public float JumpTimer = 0.3f;
		}

		[Serializable]
		public class LowerHeightStateModule : SprintingStateModule
		{
			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 2f)]
			public float ControllerHeight = 1f;

			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 1f)]
			public float TransitionDuration = 0.3f;
		}

		[Serializable]
		public class SlidingStateModule
		{
			public bool Enabled;

			[ShowIf("Enabled", true, 10f)]
			[Range(20f, 90f)]
			public float SlideTreeshold = 32f;

			[ShowIf("Enabled", true, 10f)]
			[Range(0f, 50f)]
			public float SlideSpeed = 15f;
		}

		public PlayerInput_PC input;

		[HideInInspector]
		public bool isWeakenedByHunger;

		[HideInInspector]
		public float weaknessSpeedMultiplier = 0.7f;

		[HideInInspector]
		public bool isLockedRunningAnimation;

		[SerializeField]
		private CharacterController m_Controller;

		[SerializeField]
		private LayerMask m_ObstacleCheckMask = -1;

		[SerializeField]
		private float m_Gravity = 20f;

		[Space]
		[SerializeField]
		[Group]
		private CoreMovementModule m_CoreMovement;

		[SerializeField]
		[Group]
		public SprintingStateModule m_RunState;

		[SerializeField]
		[Group]
		private LowerHeightStateModule m_CrouchState;

		[SerializeField]
		[Group]
		private LowerHeightStateModule m_ProneState;

		[SerializeField]
		[Group]
		private JumpStateModule m_JumpState;

		[SerializeField]
		[Group]
		private SlidingStateModule m_SlidingState;

		private SprintingStateModule m_CurrentMovementState;

		private Vector3 m_DesiredVelocityLocal;

		private Vector3 m_SlideVelocity;

		private CollisionFlags m_CollisionFlags;

		private bool m_PreviouslyGrounded;

		private float m_LastLandTime;

		private float m_NextTimeCanChangeHeight;

		private float m_DistMovedSinceLastCycleEnded;

		private float m_CurrentStepLength;

		public bool IsGrounded => m_Controller.isGrounded;

		public Vector3 Velocity => m_Controller.velocity;

		public Vector3 SurfaceNormal { get; private set; }

		public float SlopeLimit => m_Controller.slopeLimit;

		public float DefaultHeight { get; private set; }

		private void Awake()
		{
			if (Physics.Raycast(base.transform.position + base.transform.up, -base.transform.up, out var hitInfo, 3f, -1, QueryTriggerInteraction.Ignore))
			{
				base.transform.position = hitInfo.point + Vector3.up * 0.08f;
			}
		}

		private void Start()
		{
			DefaultHeight = m_Controller.height;
			base.Player.IsGrounded.AddChangeListener(OnGroundingStateChanged);
			base.Player.Run.SetStartTryer(Try_Run);
			base.Player.Run.AddStopListener(StopRun);
			base.Player.Jump.SetStartTryer(Try_Jump);
			base.Player.Crouch.SetStartTryer(() => Try_ToggleCrouch(m_CrouchState));
			base.Player.Crouch.SetStopTryer(() => Try_ToggleCrouch(null));
			base.Player.Prone.SetStartTryer(() => Try_ToggleProne(m_ProneState));
			base.Player.Prone.SetStopTryer(() => Try_ToggleProne(null));
			base.Player.Death.AddListener(OnDeath);
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			Vector3 motion;
			if (IsGrounded)
			{
				motion = base.transform.TransformVector(m_DesiredVelocityLocal) * deltaTime;
				if (!base.Player.Jump.Active)
				{
					motion.y = 0f - m_CoreMovement.AntiBumpFactor;
				}
			}
			else
			{
				motion = base.transform.TransformVector(m_DesiredVelocityLocal * deltaTime);
			}
			m_CollisionFlags = m_Controller.Move(motion);
			if ((m_CollisionFlags & CollisionFlags.Below) == CollisionFlags.Below && !m_PreviouslyGrounded)
			{
				bool active = base.Player.Jump.Active;
				if (base.Player.Jump.Active)
				{
					base.Player.Jump.ForceStop();
				}
				base.Player.FallImpact.Send(Mathf.Abs(m_DesiredVelocityLocal.y));
				m_LastLandTime = Time.time;
				if (active)
				{
					m_DesiredVelocityLocal = Vector3.ClampMagnitude(m_DesiredVelocityLocal, 1f);
				}
			}
			if ((m_CollisionFlags & CollisionFlags.Above) == CollisionFlags.Above && !m_Controller.isGrounded && m_DesiredVelocityLocal.y > 0f)
			{
				m_DesiredVelocityLocal.y *= 0f - m_CoreMovement.HeadBounceFactor;
			}
			Vector3 targetVelocity = CalcTargetVelocity(base.Player.MoveInput.Get());
			if (!IsGrounded)
			{
				UpdateAirborneMovement(deltaTime, targetVelocity, ref m_DesiredVelocityLocal);
			}
			else if (!base.Player.Jump.Active)
			{
				UpdateGroundedMovement(deltaTime, targetVelocity, ref m_DesiredVelocityLocal);
			}
			base.Player.IsGrounded.Set(IsGrounded);
			base.Player.Velocity.Set(Velocity);
			m_PreviouslyGrounded = IsGrounded;
		}

		private void UpdateGroundedMovement(float deltaTime, Vector3 targetVelocity, ref Vector3 velocity)
		{
			float num = Vector3.Angle(Vector3.up, SurfaceNormal);
			targetVelocity *= m_CoreMovement.SlopeSpeedMult.Evaluate(num / SlopeLimit);
			float num2 = ((targetVelocity.sqrMagnitude > 0f) ? m_CoreMovement.Acceleration : m_CoreMovement.Damping);
			velocity = Vector3.Lerp(velocity, targetVelocity, num2 * deltaTime);
			if (!base.Player.Walk.Active && targetVelocity.sqrMagnitude > 0.05f && !base.Player.Run.Active && !base.Player.Crouch.Active)
			{
				base.Player.Walk.ForceStart();
			}
			else if (base.Player.Walk.Active && (targetVelocity.sqrMagnitude < 0.05f || base.Player.Run.Active || base.Player.Crouch.Active || base.Player.Prone.Active))
			{
				base.Player.Walk.ForceStop();
			}
			if (base.Player.Run.Active)
			{
				Vector2 vector = base.Player.MoveInput.Get();
				bool flag = vector.y < 0f;
				bool flag2 = vector.y <= 0.3f;
				if (flag || flag2 || targetVelocity.sqrMagnitude == 0f || base.Player.Stamina.Get() <= 0f)
				{
					base.Player.Run.ForceStop();
				}
			}
			if (m_SlidingState.Enabled)
			{
				if (num > m_SlidingState.SlideTreeshold && base.Player.MoveInput.Get().sqrMagnitude == 0f)
				{
					Vector3 vector2 = SurfaceNormal + Vector3.down;
					m_SlideVelocity += vector2 * m_SlidingState.SlideSpeed * deltaTime;
				}
				else
				{
					m_SlideVelocity = Vector3.Lerp(m_SlideVelocity, Vector3.zero, deltaTime * 10f);
				}
				velocity += base.transform.InverseTransformVector(m_SlideVelocity);
			}
			m_DistMovedSinceLastCycleEnded += m_DesiredVelocityLocal.magnitude * deltaTime;
			float stepLength = m_CoreMovement.StepLength;
			if (m_CurrentMovementState != null)
			{
				stepLength = m_CurrentMovementState.StepLength;
			}
			m_CurrentStepLength = Mathf.MoveTowards(m_CurrentStepLength, stepLength, deltaTime);
			if (m_DistMovedSinceLastCycleEnded > m_CurrentStepLength)
			{
				m_DistMovedSinceLastCycleEnded -= m_CurrentStepLength;
				base.Player.MoveCycleEnded.Send();
			}
			base.Player.MoveCycle.Set(m_DistMovedSinceLastCycleEnded / m_CurrentStepLength);
		}

		private void UpdateAirborneMovement(float deltaTime, Vector3 targetVelocity, ref Vector3 velocity)
		{
			if (m_PreviouslyGrounded && !base.Player.Jump.Active)
			{
				velocity.y = 0f;
			}
			velocity += targetVelocity * m_CoreMovement.Acceleration * m_CoreMovement.AirborneControl * deltaTime;
			velocity.y -= m_Gravity * deltaTime;
		}

		private bool Try_Run()
		{
			float num = base.Player.Stamina.Get();
			if (!m_RunState.Enabled || num < 15f)
			{
				return false;
			}
			if (isWeakenedByHunger)
			{
				return false;
			}
			if (isLockedRunningAnimation)
			{
				return false;
			}
			bool flag = base.Player.MoveInput.Get().y > 0.3f;
			int num2;
			if (base.Player.IsGrounded.Get() && flag && !base.Player.Crouch.Active && !base.Player.Aim.Active)
			{
				num2 = ((!base.Player.Prone.Active) ? 1 : 0);
				if (num2 != 0)
				{
					m_CurrentMovementState = m_RunState;
				}
			}
			else
			{
				num2 = 0;
			}
			return (byte)num2 != 0;
		}

		public SprintingStateModule ReturnCurrentState()
		{
			return m_CurrentMovementState;
		}

		private bool Try_Jump()
		{
			if (base.Player.Crouch.Active)
			{
				base.Player.Crouch.TryStop();
				return false;
			}
			if (base.Player.Prone.Active)
			{
				if (!base.Player.Prone.TryStop())
				{
					base.Player.Crouch.TryStart();
				}
				return false;
			}
			if (!m_JumpState.Enabled || !IsGrounded || base.Player.Crouch.Active || !(Time.time > m_LastLandTime + m_JumpState.JumpTimer))
			{
				return false;
			}
			float y = Mathf.Sqrt(2f * m_Gravity * m_JumpState.JumpHeight);
			m_DesiredVelocityLocal = new Vector3(m_DesiredVelocityLocal.x, y, m_DesiredVelocityLocal.z);
			return true;
		}

		private bool Try_ToggleCrouch(LowerHeightStateModule lowerHeightState)
		{
			if (!m_CrouchState.Enabled)
			{
				return false;
			}
			bool flag = (base.Player.Crouch.Active ? Try_ChangeControllerHeight(null) : Try_ChangeControllerHeight(lowerHeightState));
			if (flag && base.Player.Prone.Active)
			{
				base.Player.Prone.ForceStop();
			}
			return flag;
		}

		private bool Try_ToggleProne(LowerHeightStateModule lowerHeightState)
		{
			if (!m_ProneState.Enabled)
			{
				return false;
			}
			bool flag = (base.Player.Prone.Active ? Try_ChangeControllerHeight(null) : Try_ChangeControllerHeight(lowerHeightState));
			if (flag && base.Player.Crouch.Active)
			{
				base.Player.Crouch.ForceStop();
			}
			return flag;
		}

		private bool Try_ChangeControllerHeight(LowerHeightStateModule lowerHeightState)
		{
			bool flag = (Time.time > m_NextTimeCanChangeHeight || m_NextTimeCanChangeHeight == 0f) && base.Player.IsGrounded.Get() && !base.Player.Run.Active;
			if (flag)
			{
				float num = lowerHeightState?.ControllerHeight ?? DefaultHeight;
				if (num > m_Controller.height && DoCollisionCheck(checkAbove: true, Mathf.Abs(num - m_Controller.height)))
				{
					return false;
				}
				if (lowerHeightState != null)
				{
					m_NextTimeCanChangeHeight = Time.time + lowerHeightState.TransitionDuration;
				}
				SetHeight(num);
				m_CurrentMovementState = lowerHeightState;
			}
			return flag;
		}

		private void StopRun()
		{
			m_CurrentMovementState = null;
		}

		private void OnGroundingStateChanged(bool isGrounded)
		{
			if (!isGrounded)
			{
				base.Player.Walk.ForceStop();
				base.Player.Run.ForceStop();
			}
		}

		private Vector3 CalcTargetVelocity(Vector2 moveInput)
		{
			moveInput = Vector2.ClampMagnitude(moveInput, 1f);
			bool num = moveInput.sqrMagnitude > 0f;
			Vector3 vector = (num ? new Vector3(moveInput.x, 0f, moveInput.y) : m_DesiredVelocityLocal.normalized);
			float num2 = 0f;
			if (num)
			{
				num2 = m_CoreMovement.ForwardSpeed;
				if (Mathf.Abs(moveInput.x) > 0f)
				{
					num2 = m_CoreMovement.SideSpeed;
				}
				if (moveInput.y < 0f)
				{
					num2 = m_CoreMovement.BackSpeed;
				}
				if (base.Player.Run.Active)
				{
					if (num2 == m_CoreMovement.ForwardSpeed || num2 == m_CoreMovement.SideSpeed)
					{
						num2 = m_CurrentMovementState.SpeedMultiplier;
					}
				}
				else if (m_CurrentMovementState != null)
				{
					num2 *= m_CurrentMovementState.SpeedMultiplier;
				}
			}
			float num3 = num2 * base.Player.MovementSpeedFactor.Val;
			if (isWeakenedByHunger)
			{
				num3 *= weaknessSpeedMultiplier;
			}
			return vector * num3;
		}

		private bool DoCollisionCheck(bool checkAbove, float maxDistance)
		{
			Vector3 origin = base.transform.position + (checkAbove ? (Vector3.up * m_Controller.height) : Vector3.zero);
			Vector3 direction = (checkAbove ? Vector3.up : Vector3.down);
			return Physics.Raycast(origin, direction, maxDistance, m_ObstacleCheckMask, QueryTriggerInteraction.Ignore);
		}

		private void SetHeight(float height)
		{
			m_Controller.height = height;
			m_Controller.center = Vector3.up * height * 0.5f;
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			SurfaceNormal = hit.normal;
		}

		private void OnDeath()
		{
			m_DesiredVelocityLocal = Vector3.zero;
		}

		public void ResetMovementState()
		{
			m_DesiredVelocityLocal = Vector3.zero;
			m_SlideVelocity = Vector3.zero;
			m_CurrentMovementState = null;
			SetHeight(DefaultHeight);
			if (base.Player.Crouch.Active)
			{
				base.Player.Crouch.ForceStop();
			}
			if (base.Player.Prone.Active)
			{
				base.Player.Prone.ForceStop();
			}
			if (base.Player.Run.Active)
			{
				base.Player.Run.ForceStop();
			}
			if (base.Player.Walk.Active)
			{
				base.Player.Walk.ForceStop();
			}
			m_NextTimeCanChangeHeight = 0f;
			m_DistMovedSinceLastCycleEnded = 0f;
			Debug.Log("[PlayerMovement] Movement state reset to default");
		}
	}
}
