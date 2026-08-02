using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public class PlayerJumpState : PlayerBaseState
	{
		private bool hasJumped;

		private PlayerStateType previousState;

		public PlayerJumpState(EASTUP_PlayerStateMachine stateMachine, EASTUP_PlayerController player, PlayerStateType previousState, InputReader animationStates)
			: base(stateMachine, player, animationStates)
		{
			this.previousState = previousState;
		}

		public override void Enter()
		{
			if (previousState == PlayerStateType.Crouching || previousState == PlayerStateType.Prone)
			{
				if (player.moveInput.magnitude > 0.1f)
				{
					stateMachine.ChangeState(new PlayerMoveState(stateMachine, player, PlayerStateType.Jumping, animationStates));
				}
				else
				{
					stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Jumping, animationStates));
				}
			}
			else
			{
				player.rb.velocity = new Vector3(player.rb.velocity.x, player.jumpForce, player.rb.velocity.z);
				hasJumped = true;
			}
		}

		public override void HandleInput()
		{
			player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		}

		public override void LogicUpdate()
		{
			player.CheckGround();
			if (IsOnSteepSlope())
			{
				stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Idle, animationStates));
			}
			else if (hasJumped && player.isGrounded && player.rb.velocity.y <= 0f)
			{
				if (player.moveInput.magnitude > 0.1f)
				{
					stateMachine.ChangeState(new PlayerMoveState(stateMachine, player, PlayerStateType.Jumping, animationStates));
				}
				else
				{
					stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Jumping, animationStates));
				}
			}
		}

		public override void PhysicsUpdate()
		{
			if (!player.isGrounded && player.moveInput.magnitude > 0.1f)
			{
				Vector3 vector = player.CalculateMoveDirection() * player.walkSpeed * player.airSpeedMultiplier;
				Vector3 velocity = player.rb.velocity;
				Vector3 b = new Vector3(vector.x, velocity.y, vector.z);
				player.rb.velocity = Vector3.Lerp(velocity, b, Time.fixedDeltaTime * 10f * player.airControlMultiplier);
			}
		}

		public override void Exit()
		{
			hasJumped = false;
		}
	}
}
