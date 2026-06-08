using System.Collections.Generic;
using Duskers.EnemyStates;
using UnityEngine;

public class SlimeBrain : BaseEnemyBrain
{
	private EnemyManager _enemyManager;

	public StateSlimeReplicate StateSlimeReplicate { get; private set; }

	public StateSlimeCombat StateSlimeCombat { get; private set; }

	public StateGlobalSlime StateGlobalSlime { get; private set; }

	public StateSlimeHibernate StateSlimeHibernate { get; private set; }

	public float GeneralReplicateTimer { get; set; }

	public float CombatReplicateTimer { get; set; }

	public SlimeEnemy SlimeEnemy
	{
		get
		{
			return (SlimeEnemy)ThisEnemy;
		}
	}

	public List<SlimeEnemy> OtherSlimes { get; private set; }

	public bool CheckForSplit { get; set; }

	public SlimeBrain(BaseEnemy enemy)
		: base(enemy)
	{
		GeneralReplicateTimer = 20f;
		CombatReplicateTimer = 20f;
		_enemyManager = EnemyManager.Instance;
		CheckForSplit = true;
		OtherSlimes = new List<SlimeEnemy>();
	}

	public override void CreateStateInstances()
	{
		StateGlobalSlime = new StateGlobalSlime(this);
		base.StateNil = new StateNil(this);
		StateSlimeReplicate = new StateSlimeReplicate(this);
		StateSlimeCombat = new StateSlimeCombat(this);
		StateSlimeHibernate = new StateSlimeHibernate(this);
	}

	protected override void SetInitialState()
	{
		_stateMachine.ChangeState(StateSlimeReplicate);
	}

	protected override void SetGlobalState()
	{
		_stateMachine.SetGlobalState(StateGlobalSlime);
	}

	public override void Update()
	{
		if (GeneralReplicateTimer > 0f)
		{
			GeneralReplicateTimer -= Time.deltaTime;
		}
		if (CombatReplicateTimer > 0f)
		{
			CombatReplicateTimer -= Time.deltaTime;
		}
		base.Update();
	}

	public void PassBrainToSlime(SlimeEnemy slime)
	{
		if (slime == null)
		{
			Debug.LogWarning("PassBrainToSlime - slime is null!!!");
		}
		if (slime != null)
		{
			slime.SlimeBrainId = base.Id;
		}
		SlimeEnemy.SetBrain(null);
		if (slime != null)
		{
			slime.SetBrain(this);
		}
		SetThisEnemy(slime);
		UpdateOtherSlimesList();
	}

	public void UpdateOtherSlimesList()
	{
		OtherSlimes.Clear();
		foreach (BaseEnemy enemy in _enemyManager.Enemies)
		{
			if (enemy != SlimeEnemy && enemy is SlimeEnemy && ((SlimeEnemy)enemy).SlimeBrainId == base.Id)
			{
				OtherSlimes.Add((SlimeEnemy)enemy);
			}
		}
	}

	public void Hibernate()
	{
		_stateMachine.ChangeState(StateSlimeHibernate);
	}
}
