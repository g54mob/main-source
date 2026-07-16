using UnityEngine;

public class E1_B_ControllerBehind : StateBase
{
	private CentipedeController controller;

	public override string Key => "Behind";

	public E1_B_ControllerBehind(StateMachine sm, CentipedeController controller)
		: base(sm)
	{
		transitionStates = new string[1] { "Combat" };
		this.controller = controller;
	}

	public E1_B_ControllerBehind(StateMachine sm, string[] transitionStates, CentipedeController controller)
		: base(sm, transitionStates)
	{
		this.controller = controller;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		controller.offScreen = true;
		controller.yOffsetSide *= -1f;
	}

	public override void UpdateState()
	{
		controller.xOffset += controller.moveSpeed * Time.deltaTime;
		controller.SetSpeeds(controller.moveSpeed);
		controller.offscreenTimeOffset = Time.time;
		if (controller.xOffset >= controller.trainFrontX - 0.5f)
		{
			controller.offScreen = false;
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
