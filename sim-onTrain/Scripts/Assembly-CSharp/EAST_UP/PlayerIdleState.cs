using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public class PlayerIdleState : PlayerBaseState
	{
		private PlayerStateType previousState;

		public PlayerIdleState(EASTUP_PlayerStateMachine stateMachine, EASTUP_PlayerController player, PlayerStateType previousState, InputReader animationStates)
			: base(stateMachine, player, animationStates)
		{
			this.previousState = previousState;
		}

		public override void Enter()
		{
			player.rb.velocity = new Vector3(0f, player.rb.velocity.y, 0f);
			player.currentSpeed = 0f;
			player.speedSmoothVelocity = 0f;
		}

		public override void HandleInput()
		{
			player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}

		public override void LogicUpdate()
		{
			if (previousState != PlayerStateType.Idle)
			{
				previousState = PlayerStateType.Idle;
				return;
			}
			player.CheckGround();
			if (IsOnSteepSlope())
			{
				stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Idle, animationStates));
				return;
			}
			player.CheckStairs();
			CheckJump();
			if (Input.GetKeyDown(KeyCode.C) && previousState != PlayerStateType.Crouching)
			{
				stateMachine.ChangeState(new PlayerCrouchState(stateMachine, player, animationStates));
			}
			else if (Input.GetKeyDown(KeyCode.Z) && previousState != PlayerStateType.Prone)
			{
				stateMachine.ChangeState(new PlayerProneState(stateMachine, player, animationStates));
			}
			else if (player.moveInput.magnitude > 0.1f)
			{
				stateMachine.ChangeState(new PlayerMoveState(stateMachine, player, PlayerStateType.Idle, animationStates));
			}
		}

		protected void CheckJump()
		{
			if (Input.GetButtonDown("Jump") && player.isGrounded)
			{
				stateMachine.ChangeState(new PlayerJumpState(stateMachine, player, PlayerStateType.Idle, animationStates));
			}
		}

		public override void PhysicsUpdate()
		{
			Vector3 velocity = player.rb.velocity;
			if (player.isOnStairs && player.moveInput.magnitude > 0.1f)
			{
				Vector3 b = player.CalculateMoveDirection() * (player.currentSpeed * 0.8f);
				b.y = player.currentSpeed * 0.5f;
				player.rb.velocity = Vector3.Lerp(velocity, b, Time.fixedDeltaTime * 15f);
			}
			else if (new Vector2(velocity.x, velocity.z).magnitude > 0.01f)
			{
				Vector3 b2 = new Vector3(0f, velocity.y, 0f);
				player.rb.velocity = Vector3.Lerp(velocity, b2, Time.fixedDeltaTime * 15f);
			}
		}

		public override void Exit()
		{
		}
	}
}
