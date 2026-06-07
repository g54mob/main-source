using System;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class PlayerCharacterMovement : CharacterComponent
	{
		public enum EMovementMode
		{
			IDLE = 0,
			WALKING = 1,
			SPRINTING = 2,
			CROUCHING = 3
		}

		[SerializeField]
		private CharacterController m_characterController;

		[SerializeField]
		private Transform m_directionReference;

		[SerializeField]
		private GroundDetection m_groundDetection;

		private float m_verticalSpeed;

		private bool m_needToUpdateHeight = true;

		public Vector3 CurrentMoveInput { get; private set; }

		public bool IsSprinting { get; private set; }

		public bool IsCrouching { get; private set; }

		public EMovementMode MovementMode { get; private set; }

		public static event Action<Character> Teleported;

		protected override void OnEnable()
		{
			base.OnEnable();
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.MOVEMENT, OnUpdate);
			IsCrouching = false;
			m_needToUpdateHeight = true;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.MOVEMENT, OnUpdate);
		}

		private void OnUpdate(float deltaTime)
		{
			m_groundDetection.Refresh();
			CalculateGravity(deltaTime);
			m_characterController.Move(GetVelocity() * deltaTime);
			UpdateHeight();
			UpdateMovementMode(GetMoveDirection());
		}

		public void Move(Vector3 moveInput)
		{
			CurrentMoveInput = moveInput;
		}

		public void SetPosition(Vector3 position)
		{
			PlayerCharacterMovement.Teleported?.Invoke(m_character);
			m_characterController.enabled = false;
			m_characterController.transform.position = position;
			m_characterController.enabled = true;
		}

		public void Sprint(bool sprint)
		{
			if (IsCrouching && sprint)
			{
				IsCrouching = false;
				m_needToUpdateHeight = true;
			}
			IsSprinting = sprint;
		}

		public void Jump()
		{
			if (m_groundDetection.IsGrounded && !IsCrouching)
			{
				m_verticalSpeed = Mathf.Sqrt(-2f * (0f - PlayerMovementSettings.GravityForce) * PlayerMovementSettings.JumpHeight);
			}
		}

		public void Crouch()
		{
			IsCrouching = !IsCrouching;
			if (IsSprinting && IsCrouching)
			{
				IsSprinting = false;
			}
			m_needToUpdateHeight = true;
		}

		private void CalculateGravity(float deltaTime)
		{
			if (m_groundDetection.IsGrounded)
			{
				if (m_verticalSpeed <= 0f)
				{
					m_verticalSpeed = 0f - PlayerMovementSettings.GravityForce;
				}
			}
			else if (m_verticalSpeed > 0f - PlayerMovementSettings.MaxVerticalSpeed)
			{
				m_verticalSpeed -= PlayerMovementSettings.GravityForce * deltaTime;
			}
			else
			{
				m_verticalSpeed = 0f - PlayerMovementSettings.MaxVerticalSpeed;
			}
		}

		private void UpdateHeight()
		{
			if (m_needToUpdateHeight)
			{
				float num = (IsCrouching ? PlayerMovementSettings.CrouchHeight : PlayerMovementSettings.BaseHeight);
				Vector3 b = Vector3.up * num;
				m_directionReference.localPosition = Vector3.Lerp(m_directionReference.localPosition, b, PlayerMovementSettings.CrouchTransitionSpeed);
				if (Mathf.Approximately(m_directionReference.localPosition.y, num))
				{
					m_needToUpdateHeight = false;
				}
			}
		}

		private Vector3 GetMoveDirection()
		{
			return Quaternion.Euler(0f, m_directionReference.eulerAngles.y, 0f) * CurrentMoveInput;
		}

		public float GetSpeed()
		{
			if (GetMoveDirection() == Vector3.zero)
			{
				return 0f;
			}
			float result = PlayerMovementSettings.MaxWalkingSpeed;
			if (IsCrouching)
			{
				result = PlayerMovementSettings.MaxCrouchingSpeed;
			}
			else if (IsSprinting)
			{
				result = PlayerMovementSettings.MaxSprintingSpeed;
			}
			return result;
		}

		private Vector3 GetVelocity()
		{
			Vector3 moveDirection = GetMoveDirection();
			float speed = GetSpeed();
			Vector3 vector = moveDirection * speed;
			return new Vector3(vector.x, m_verticalSpeed, vector.z);
		}

		private void UpdateMovementMode(Vector3 moveDirection)
		{
			if (moveDirection == Vector3.zero)
			{
				MovementMode = EMovementMode.IDLE;
			}
			else if (IsSprinting)
			{
				MovementMode = EMovementMode.SPRINTING;
			}
			else if (IsCrouching)
			{
				MovementMode = EMovementMode.CROUCHING;
			}
			else
			{
				MovementMode = EMovementMode.WALKING;
			}
		}
	}
}
