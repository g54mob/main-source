using UnityEngine;

[RequireComponent(typeof(SuperCharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerMachine : SuperStateMachine
{
	private enum PlayerStates
	{
		Idle = 0,
		Walk = 1,
		Jump = 2,
		Fall = 3
	}

	public Transform AnimatedMesh;

	public float WalkSpeed;

	public float WalkAcceleration;

	public float JumpAcceleration;

	public float JumpHeight;

	public float Gravity;

	private SuperCharacterController controller;

	private Vector3 moveDirection;

	private PlayerInputController input;

	public Vector3 lookDirection { get; private set; }

	private void Start()
	{
	}

	protected override void EarlyGlobalSuperUpdate()
	{
	}

	protected override void LateGlobalSuperUpdate()
	{
	}

	private bool AcquiringGround()
	{
		return false;
	}

	private bool MaintainingGround()
	{
		return false;
	}

	public void RotateGravity(Vector3 up)
	{
	}

	private Vector3 LocalMovement()
	{
		return default(Vector3);
	}

	private float CalculateJumpSpeed(float jumpHeight, float gravity)
	{
		return 0f;
	}

	private void Idle_EnterState()
	{
	}

	private void Idle_SuperUpdate()
	{
	}

	private void Idle_ExitState()
	{
	}

	private void Walk_SuperUpdate()
	{
	}

	private void Jump_EnterState()
	{
	}

	private void Jump_SuperUpdate()
	{
	}

	private void Fall_EnterState()
	{
	}

	private void Fall_SuperUpdate()
	{
	}
}
