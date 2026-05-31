using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Workbench.Wolfsbane.Multiplayer;

public class PlayerAnimation : MonoBehaviour
{
	public enum CleaningState
	{
		None = 0,
		Dust = 1,
		Dirt = 2
	}

	public enum UpperIdleState
	{
		None = 0,
		Carry = 1,
		Hold = 2
	}

	public enum IdleState
	{
		Locomotion = 0,
		Vehicle_Driver = 1,
		Vehicle_Passenger = 2
	}

	public enum DriverState
	{
		Car = 0,
		Motorcycle = 1,
		Bicycle = 2
	}

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private CharacterController m_Controller;

	[SerializeField]
	private bool m_BlendTreeSmoothing;

	[SerializeField]
	private float m_SmoothingValue;

	private Vector2 m_SmoothedMovement;

	private Vector2 m_SmoothedMovementVelocity;

	[SerializeField]
	private Rig m_LookAtRig;

	[SerializeField]
	private Rig m_DirtCleaningRig;

	private NetworkedAnimation m_NetworkedAnimation;

	private NetworkPlayerAnimation m_NetworkPlayerAnimation;

	private static readonly int MovementX;

	private static readonly int MovementY;

	private static readonly int Interact;

	private static readonly int IsGrounded;

	private static readonly int JumpHash;

	private static readonly int IdleStateHash;

	private Tween m_RigToggleTween;

	public PlayerInstance m_PlayerInstance;

	private bool m_WasGrounded;

	private bool IsLocalPlayer => false;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void SetVehicleIndex(DriverState state)
	{
	}

	public void SetIdleState(IdleState state)
	{
	}

	private void ProcessMovement()
	{
	}

	public void ToggleCarrying_Broadcast(bool enabled)
	{
	}

	public void ToggleCarrying(bool enabled)
	{
	}

	public void ToggleHolding(bool enabled)
	{
	}

	public void ToggleHoldingLocal(bool enabled)
	{
	}

	private void SetUpperBodyState(UpperIdleState value)
	{
	}

	private void ToggleLookAt(bool enabled)
	{
	}

	private void PlayUpperBody(string anim)
	{
	}

	public void PlayInteraction()
	{
	}

	private void OnPlayerJumped()
	{
	}

	public void PlayJump()
	{
	}

	public void PlaySwing()
	{
	}

	public void SetCleaningState(CleaningState state)
	{
	}

	public void SetCleaningRigWeight(float weight)
	{
	}
}
