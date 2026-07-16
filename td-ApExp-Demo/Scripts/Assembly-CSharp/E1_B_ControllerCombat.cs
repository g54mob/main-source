using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E1_B_ControllerCombat : StateBase
{
	private CentipedeController controller;

	private float combatTimer;

	public override string Key => "Combat";

	public E1_B_ControllerCombat(StateMachine sm, CentipedeController controller)
		: base(sm)
	{
		transitionStates = new string[1] { "Retreat" };
		this.controller = controller;
	}

	public E1_B_ControllerCombat(StateMachine sm, string[] transitionStates, CentipedeController controller)
		: base(sm, transitionStates)
	{
		this.controller = controller;
	}

	public override bool CanEnter()
	{
		for (int i = 0; i < controller.enemiesActive.Count; i++)
		{
			controller.enemiesActive[i].isReadyToOpenAndArm = false;
		}
		for (int j = 0; j < controller.enemies.Length; j++)
		{
			if (!controller.enemies[j].HealthComponent.IsDead && !controller.enemies[j].IsEMPd && controller.enemies[j].sm.CurrentState.Key != "Idle")
			{
				return false;
			}
		}
		return !controller.offScreen;
	}

	public override void EnterState()
	{
		NewArmamentPattern();
	}

	public override void UpdateState()
	{
		combatTimer -= Time.deltaTime;
		controller.SetSpeeds(controller.moveSpeed * Train.Instance.TrainSpeedNormalized);
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		PingPongMovement();
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
		if (!(combatTimer <= 0f))
		{
			return controller.enemiesActive.Count == 0;
		}
		return true;
	}

	private void NewArmamentPattern()
	{
		List<EnemyCentipede> list = new List<EnemyCentipede>(controller.enemiesAlive);
		int count = Mathf.Min(list.Count, controller.activePartCount);
		list = list.OrderBy((EnemyCentipede x) => Guid.NewGuid()).ToList();
		controller.enemiesActive = list.Take(count).ToList();
		for (int num = 0; num < controller.enemiesActive.Count; num++)
		{
			controller.enemiesActive[num].isReadyToOpenAndArm = true;
		}
		combatTimer = controller.timeBetweenArmamentSwaps;
	}

	private void PingPongMovement()
	{
		float t = Mathf.PingPong((Time.time - controller.offscreenTimeOffset) / 2f, controller.slitherFrequency) * Train.Instance.TrainSpeedNormalized * controller.moveSpeed / controller.slitherFrequency;
		float t2 = Mathf.SmoothStep(0f, 1f, t);
		controller.xOffset = Mathf.Lerp(controller.trainFrontX - 0.5f, controller.trainFrontX + 0.5f, t2);
	}
}
