using FIMSpace.Basics;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

public class DEMO_LegsAnim_RedirectExampleJoy : MonoBehaviour
{
	public LegsAnimator Legs;

	public Fimp_JoystickInput Joystick;

	public bool DebugWSAD;

	public Vector2 ConstantDebugInputVal = Vector2.zero;

	[Range(0f, 1f)]
	public float ModuleBlend = 1f;

	private LAM_DirectionalMovement module;

	private void Start()
	{
		module = Legs.GetModule<LAM_DirectionalMovement>();
	}

	private void Update()
	{
		UpdateInputs();
		Legs.User_SetIsMoving(Legs.DesiredMovementDirection.magnitude > 0f);
		module.ModuleBlend = ModuleBlend;
	}

	private void UpdateInputs()
	{
		if (ConstantDebugInputVal != Vector2.zero)
		{
			Legs.User_SetDesiredMovementDirection(new Vector3(ConstantDebugInputVal.x, 0f, ConstantDebugInputVal.y).normalized);
			return;
		}
		if (DebugWSAD)
		{
			Vector2 zero = Vector2.zero;
			if (Input.GetKey(KeyCode.W))
			{
				zero += Vector2.up;
			}
			if (Input.GetKey(KeyCode.S))
			{
				zero += Vector2.down;
			}
			if (Input.GetKey(KeyCode.A))
			{
				zero += Vector2.left;
			}
			if (Input.GetKey(KeyCode.D))
			{
				zero += Vector2.right;
			}
			zero.Normalize();
			Legs.User_SetDesiredMovementDirection(new Vector3(zero.x, 0f, zero.y));
			if (zero != Vector2.zero)
			{
				return;
			}
		}
		Legs.User_SetDesiredMovementDirection(new Vector3(Joystick.OutputValue.x, 0f, Joystick.OutputValue.y));
	}
}
