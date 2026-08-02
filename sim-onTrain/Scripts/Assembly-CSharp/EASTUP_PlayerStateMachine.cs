using EAST_UP;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

public class EASTUP_PlayerStateMachine : MonoBehaviour
{
	private PlayerBaseState currentState;

	private EASTUP_PlayerController playerController;

	private float timeInCurrentState;

	[SerializeField]
	private InputReader animationStatesReader;

	private string currentStateName => currentState?.GetType().Name ?? "No State";

	public PlayerStateType CurrentStateType { get; private set; }

	private void Awake()
	{
		playerController = GetComponent<EASTUP_PlayerController>();
	}

	public void Initialize(PlayerBaseState startingState)
	{
		currentState = startingState;
		currentState.Enter();
		if (startingState is PlayerIdleState)
		{
			CurrentStateType = PlayerStateType.Idle;
		}
		else if (startingState is PlayerMoveState)
		{
			CurrentStateType = PlayerStateType.Moving;
		}
		else if (startingState is PlayerJumpState)
		{
			CurrentStateType = PlayerStateType.Jumping;
		}
		else if (startingState is PlayerCrouchState)
		{
			CurrentStateType = PlayerStateType.Crouching;
		}
	}

	public void ChangeState(PlayerBaseState newState)
	{
		currentState.Exit();
		currentState = newState;
		currentState.Enter();
		if (newState is PlayerIdleState)
		{
			CurrentStateType = PlayerStateType.Idle;
		}
		else if (newState is PlayerMoveState)
		{
			CurrentStateType = PlayerStateType.Moving;
		}
		else if (newState is PlayerJumpState)
		{
			CurrentStateType = PlayerStateType.Jumping;
		}
		else if (newState is PlayerCrouchState)
		{
			CurrentStateType = PlayerStateType.Crouching;
		}
		else if (newState is PlayerProneState)
		{
			CurrentStateType = PlayerStateType.Prone;
		}
		timeInCurrentState = 0f;
	}

	private void Update()
	{
		if (currentState != null)
		{
			timeInCurrentState += Time.deltaTime;
			currentState.HandleInput();
			currentState.LogicUpdate();
		}
	}

	private void FixedUpdate()
	{
		if (currentState != null)
		{
			currentState.PhysicsUpdate();
		}
	}
}
