using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public class PlayerCrouchState : PlayerBaseState
	{
		public PlayerCrouchState(EASTUP_PlayerStateMachine stateMachine, EASTUP_PlayerController player, InputReader animationStates)
			: base(stateMachine, player, animationStates)
		{
		}

		public override void Enter()
		{
			player.isInStanceTransition = true;
			player.characterCollider.height = player.crouchHeight;
			player.characterCollider.center = new Vector3(0f, player.crouchHeight / 2f, 0f);
			player.currentSpeed = ((player.moveInput.magnitude > 0.1f) ? player.crouchSpeed : 0f);
			animationStates.onCrouchActivated();
		}

		public override void HandleInput()
		{
			player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
			if (Input.GetKeyDown(KeyCode.C))
			{
				if (player.currentSpeed > 0.1f)
				{
					stateMachine.ChangeState(new PlayerMoveState(stateMachine, player, PlayerStateType.Crouching, animationStates));
				}
				else
				{
					stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Crouching, animationStates));
				}
			}
			else if (Input.GetKeyDown(KeyCode.Z))
			{
				stateMachine.ChangeState(new PlayerProneState(stateMachine, player, animationStates));
			}
			else if (Input.GetButtonDown("Jump"))
			{
				if (player.currentSpeed > 0.1f)
				{
					stateMachine.ChangeState(new PlayerMoveState(stateMachine, player, PlayerStateType.Crouching, animationStates));
				}
				else
				{
					stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Crouching, animationStates));
				}
			}
		}

		public override void LogicUpdate()
		{
			player.CheckGround();
			player.CheckStairs();
			if (IsOnSteepSlope())
			{
				stateMachine.ChangeState(new PlayerIdleState(stateMachine, player, PlayerStateType.Idle, animationStates));
			}
			else if (player.moveInput.magnitude > 0.1f)
			{
				player.currentSpeed = Mathf.SmoothDamp(player.currentSpeed, player.crouchSpeed, ref player.speedSmoothVelocity, player.speedSmoothTime);
			}
			else
			{
				player.currentSpeed = Mathf.SmoothDamp(player.currentSpeed, 0f, ref player.speedSmoothVelocity, player.speedSmoothTime);
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
				float num = Vector3.Angle(player.groundNormal, Vector3.up);
				if (num <= player.maxSlopeAngle)
				{
					float num2 = 1.4f + num / player.maxSlopeAngle * 0.5f;
					vector *= num2;
					vector = Vector3.ProjectOnPlane(vector, player.groundNormal);
					if (player.rb.velocity.y >= 0f)
					{
						vector.y = player.rb.velocity.y + num * 0.05f;
					}
					else
					{
						vector.y = player.rb.velocity.y;
					}
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
			float num3 = (player.isOnStairs ? 15f : 5f);
			player.rb.velocity = Vector3.Lerp(player.rb.velocity, vector, Time.fixedDeltaTime * num3);
		}

		public override void Exit()
		{
			player.isInStanceTransition = false;
			if (stateMachine.CurrentStateType != PlayerStateType.Prone)
			{
				player.characterCollider.height = player.normalHeight;
				player.characterCollider.center = new Vector3(0f, player.normalHeight / 2f, 0f);
			}
			animationStates.onCrouchDeactivated();
			player.currentSpeed = 0f;
			player.speedSmoothVelocity = 0f;
		}
	}
}
