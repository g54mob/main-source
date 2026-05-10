using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
	private Vector2 m_Move;

	private Vector2 m_Look;

	private bool m_Sprint;

	private bool m_gamepadSprint;

	[SerializeField]
	private bool m_AnalogMovement;

	private bool m_CursorLocked;

	private bool m_CursorInputForLook;

	private PlayerInput m_PlayerInput;

	public Action onJump;

	public Vector2 Move => default(Vector2);

	public Vector2 Look => default(Vector2);

	public bool Sprint => false;

	public bool AnalogMovement => false;

	public bool CursorLocked => false;

	public bool CursorInputForLook => false;

	public bool IsCurrentDeviceMouse => false;

	public PlayerInput PlayerInput => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void OnMove(InputAction.CallbackContext context)
	{
	}

	public void OnLook(InputAction.CallbackContext context)
	{
	}

	public void OnJump(InputAction.CallbackContext context)
	{
	}

	public void OnSprint(InputAction.CallbackContext context)
	{
	}

	public void MoveInput(Vector2 newMoveDirection)
	{
	}

	public void LookInput(Vector2 newLookDirection)
	{
	}

	public void SprintInput(bool newSprintState)
	{
	}

	private void SetCursorState(bool newState)
	{
	}
}
