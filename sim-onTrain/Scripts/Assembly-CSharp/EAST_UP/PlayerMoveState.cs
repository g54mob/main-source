using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public class PlayerMoveState : PlayerBaseState
	{
		private float targetSpeed;

		private PlayerStateType previousState;

		public PlayerMoveState(EASTUP_PlayerStateMachine stateMachine, EASTUP_PlayerController player, PlayerStateType previousState, InputReader animationStates)
			: base(stateMachine, player, animationStates)
		{
			this.previousState = previousState;
		}

		public override void Enter()
		{
		}

		public override void HandleInput()
		{
			player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
			targetSpeed = (Input.GetKey(KeyCode.LeftShift) ? player.sprintSpeed : player.walkSpeed);
		}

		public override void LogicUpdate()
		{
			if (previousState != PlayerStateType.Moving)
			{
				previousState = PlayerStateType.Moving;
				return;
			}
			player.CheckGround();
			player.CheckStairs();
			CheckJump();
			if (IsOnSteepSlope())
			{
				stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Idle, animationStates));
			}
			else if (Input.GetKeyDown(KeyCode.C))
			{
				stateMachine.ChangeState(new PlayerCrouchState(stateMachine, player, animationStates));
			}
			else if (Input.GetKeyDown(KeyCode.Z))
			{
				stateMachine.ChangeState(new PlayerProneState(stateMachine, player, animationStates));
			}
			else if (player.moveInput.magnitude < 0.1f)
			{
				player.currentSpeed = Mathf.SmoothDamp(player.currentSpeed, 0f, ref player.speedSmoothVelocity, player.speedSmoothTime);
				if (player.currentSpeed < 0.1f && player.rb.velocity.magnitude < 0.1f)
				{
					stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Moving, animationStates));
				}
			}
			else
			{
				player.currentSpeed = Mathf.SmoothDamp(player.currentSpeed, targetSpeed, ref player.speedSmoothVelocity, player.speedSmoothTime);
			}
		}

		protected void CheckJump()
		{
			if (Input.GetButtonDown("Jump") && player.isGrounded)
			{
				stateMachine.ChangeState(new PlayerJumpState(stateMachine, player, PlayerStateType.Moving, animationStates));
			}
		}

		public override void PhysicsUpdate()
		{
			Vector3 vector = player.CalculateMoveDirection() * player.currentSpeed;
			if (player.isOnStairs)
			{
				vector *= 0.8f;
				if (player.rb.velocity.y < -0.1f)
				{
					vector.y = 0f;
				}
			}
			else if (player.isGrounded)
			{
				if (Vector3.Angle(player.groundNormal, Vector3.up) <= player.maxSlopeAngle)
				{
					vector = Vector3.ProjectOnPlane(vector, player.groundNormal);
					vector.y = player.rb.velocity.y;
				}
				else
				{
					vector = Vector3.zero;
					vector.y = player.rb.velocity.y;
				}
			}
			else
			{
				vector.y = player.rb.velocity.y;
			}
			float num = (player.isOnStairs ? 15f : 5f);
			player.rb.velocity = Vector3.Lerp(player.rb.velocity, vector, Time.fixedDeltaTime * num);
		}

		public override void Exit()
		{
			player.speedSmoothVelocity = 0f;
		}
	}
}
