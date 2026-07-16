using UnityEngine;
using UnityEngine.InputSystem;

public struct MoveInput
{
	public InputDevice Device;

	public Vector2 Move;

	public MoveInput(InputDevice device, Vector2 move)
	{
		Device = device;
		Move = move;
	}
}
