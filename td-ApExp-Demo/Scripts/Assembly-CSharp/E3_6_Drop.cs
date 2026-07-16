using UnityEngine;

public class E3_6_Drop : StateBaseEnemy
{
	private E3_6_Paradropper dropper;

	private Module[] targets;

	private int shotCounter;

	public override string Key => "Drop";

	public E3_6_Drop(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E3_6_Drop(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		dropper = enemy as E3_6_Paradropper;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Drop");
		dropper.SetPlaneFlyNormal();
		targets = dropper.GetDropTargets();
		_ = Train.Instance.MODULE_HALF_WIDTH;
		dropper.HealthComponent.RemoveImmunityBuff();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		dropper.Move();
		if (shotCounter >= targets.Length || !((dropper.transform.position - targets[shotCounter].transform.position).magnitude < dropper.DropProximityToModule))
		{
			return;
		}
		if (targets[shotCounter].IsFullyBroken)
		{
			shotCounter++;
			return;
		}
		if (Random.Range(0f, 1f) <= dropper.ModuleDropChance)
		{
			E3_6_Chicken e3_6_Chicken = dropper.SpawnChicken(targets[shotCounter]);
			if (e3_6_Chicken != null)
			{
				e3_6_Chicken.TargetUnit = targets[shotCounter];
			}
		}
		shotCounter++;
	}

	public override void ExitState()
	{
		dropper.Despawn();
	}

	public override bool CanExit()
	{
		return dropper.IsInPosition;
	}
}
