using UnityEngine;

public class E1_B_ControllerRetreat : StateBase
{
	private CentipedeController controller;

	private float combatTimer;

	public override string Key => "Retreat";

	public E1_B_ControllerRetreat(StateMachine sm, CentipedeController controller)
		: base(sm)
	{
		transitionStates = new string[1] { "Behind" };
		this.controller = controller;
	}

	public E1_B_ControllerRetreat(StateMachine sm, string[] transitionStates, CentipedeController controller)
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
	}

	public override void UpdateState()
	{
		controller.xOffset -= Time.deltaTime * controller.moveSpeed;
		controller.SetSpeeds(controller.moveSpeed);
	}

	public override void ExitState()
	{
		for (int i = 0; i < controller.enemiesActive.Count; i++)
		{
			controller.enemiesActive[i].isReadyToOpenAndArm = false;
		}
	}

	public override bool CanExit()
	{
		return controller.xOffset <= controller.trainFrontX - 5f;
	}
}
