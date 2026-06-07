using UnityEngine;
using UnityEngine.InputSystem;

public class SCC_InputManager : SCC_Singleton<SCC_InputManager>
{
	public SCC_Inputs inputs;

	[Header("Input Action References - Keyboard/Stick")]
	public InputActionReference moveAction;

	[Header("Input Action References - Gamepad Triggers")]
	public InputActionReference throttleAction;

	public InputActionReference brakeAction;

	[Header("Input Action References - Other")]
	public InputActionReference handbrakeAction;

	private void Awake()
	{
		inputs = new SCC_Inputs();
	}

	private void OnEnable()
	{
		if (moveAction != null)
		{
			moveAction.action.Enable();
		}
		if (throttleAction != null)
		{
			throttleAction.action.Enable();
		}
		if (brakeAction != null)
		{
			brakeAction.action.Enable();
		}
		if (handbrakeAction != null)
		{
			handbrakeAction.action.Enable();
		}
	}

	private void OnDisable()
	{
		if (moveAction != null)
		{
			moveAction.action.Disable();
		}
		if (throttleAction != null)
		{
			throttleAction.action.Disable();
		}
		if (brakeAction != null)
		{
			brakeAction.action.Disable();
		}
		if (handbrakeAction != null)
		{
			handbrakeAction.action.Disable();
		}
	}

	private void Update()
	{
		if (inputs == null)
		{
			inputs = new SCC_Inputs();
		}
		GetInputs();
	}

	public void GetInputs()
	{
		Vector2 vector = ((moveAction != null) ? moveAction.action.ReadValue<Vector2>() : Vector2.zero);
		float b = ((throttleAction != null) ? throttleAction.action.ReadValue<float>() : 0f);
		float b2 = ((brakeAction != null) ? brakeAction.action.ReadValue<float>() : 0f);
		float steerInput = vector.x;
		float num = vector.y;
		float magnitude = vector.magnitude;
		if (magnitude > 0.001f)
		{
			float num2 = magnitude / Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
			steerInput = Mathf.Clamp(vector.x * num2, -1f, 1f);
			num = Mathf.Clamp(vector.y * num2, -1f, 1f);
		}
		inputs.throttleInput = Mathf.Max(Mathf.Clamp01(num), b);
		inputs.brakeInput = Mathf.Max(Mathf.Clamp01(0f - num), b2);
		inputs.steerInput = steerInput;
		inputs.handbrakeInput = ((handbrakeAction != null) ? handbrakeAction.action.ReadValue<float>() : 0f);
	}
}
