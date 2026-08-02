using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public abstract class PlayerBaseState
	{
		protected EASTUP_PlayerStateMachine stateMachine;

		protected EASTUP_PlayerController player;

		protected InputReader animationStates;

		protected bool preventNextSpaceAction;

		public PlayerBaseState(EASTUP_PlayerStateMachine stateMachine, EASTUP_PlayerController player, InputReader animationStates)
		{
			this.stateMachine = stateMachine;
			this.player = player;
			preventNextSpaceAction = false;
			this.animationStates = animationStates;
		}

		public abstract void Enter();

		public abstract void HandleInput();

		public abstract void LogicUpdate();

		public abstract void PhysicsUpdate();

		public abstract void Exit();

		protected bool IsOnSteepSlope()
		{
			if (player.isGrounded)
			{
				return Vector3.Angle(player.groundNormal, Vector3.up) > player.maxSlopeAngle;
			}
			return false;
		}
	}
}
