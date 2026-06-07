using DV;
using DV.CabControls;
using DV.CabControls.NonVR;
using DV.Interaction.Inputs;
using UnityEngine;

public class LocomotiveRemoteKeyboardInput : MonoBehaviour
{
	private LocomotiveRemoteController controller;

	private ItemNonVR item;

	private void Start()
	{
		controller = GetComponent<LocomotiveRemoteController>();
		item = GetComponent<ItemNonVR>();
		item.Ungrabbed += UnGrabbed;
	}

	private void UnGrabbed(ControlImplBase impl)
	{
		controller.throttleJoystick.ForcePosition(0.5f);
		controller.brakeJoystick.ForcePosition(0.5f);
		controller.independentBrakeJoystick.ForcePosition(0.5f);
		controller.reverserJoystick.ForcePosition(0.5f);
		controller.sandJoystick.ForcePosition(0.5f);
		controller.hornJoystick.ForcePosition(0.5f);
	}

	private void Update()
	{
		if (TimeUtil.IsFlowing && item.IsGrabbed())
		{
			UpdateJoystick(InputManager.Actions.ThrottleIncremental, controller.throttleJoystick);
			UpdateJoystick(InputManager.Actions.BrakeIncremental, controller.brakeJoystick);
			UpdateJoystick(InputManager.Actions.IndependentBrakeIncremental, controller.independentBrakeJoystick);
			UpdateJoystick(InputManager.Actions.ReverserIncremental, controller.reverserJoystick);
			UpdateJoystick(InputManager.Actions.SandIncremental, controller.sandJoystick);
			UpdateJoystick(InputManager.Actions.HornIncremental, controller.hornJoystick);
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Couple))
			{
				controller.coupleButton.GetComponent<ControlImplBase>().Use();
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Uncouple))
			{
				controller.decoupleButton.GetComponent<ControlImplBase>().Use();
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.CouplerSelect))
			{
				controller.couplerSelectorKnob.GetComponent<SteppedJoint>().InvokePositionChanged(1f);
			}
			if (InputManager.NewPlayer.GetNegativeButtonDown(InputManager.Actions.CouplerSelect))
			{
				controller.couplerSelectorKnob.GetComponent<SteppedJoint>().InvokePositionChanged(-1f);
			}
		}
	}

	private void UpdateJoystick(int axis, JoystickDriver joystick)
	{
		if (InputManager.NewPlayer.GetButton(axis))
		{
			joystick.ForcePosition(0.95f);
		}
		else if (InputManager.NewPlayer.GetNegativeButton(axis))
		{
			joystick.ForcePosition(0.05f);
		}
		else if (InputManager.NewPlayer.GetAnyDirButtonUp(axis))
		{
			joystick.ForcePosition(0.5f);
		}
	}
}
