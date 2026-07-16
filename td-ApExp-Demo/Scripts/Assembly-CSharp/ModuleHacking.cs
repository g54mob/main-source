using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModuleHacking : Module
{
	private EnemyBase[] hackableEnemies;

	[NonSerialized]
	public List<(EnemyBase, StatusEffect)> hackedEnemies;

	[SerializeField]
	private Transform dishTf;

	[NonSerialized]
	public bool canHackEliteUnits;

	[SerializeField]
	private StatusEffect statusEffectHack;

	[NonSerialized]
	public float prob;

	public override bool CanBeActivated => true;

	public event Delegates.HealthChangeHandler HackedEnemyHit;

	public event Action<EnemyBase> OnEnemyHacked;

	public event Action<EnemyBase> OnHackExpiration;

	private new void Awake()
	{
		base.Awake();
		hackedEnemies = new List<(EnemyBase, StatusEffect)>();
	}

	private new void Update()
	{
		base.Update();
		if (!base.IsFullyBroken && !base.IsEMPattached)
		{
			base.cooldownTimeElapsed += Time.deltaTime;
			if (base.cooldownTimeElapsed >= GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
			{
				dishTf.Rotate(0f, 0f, Time.deltaTime * 180f);
				anim.Play("Ready");
			}
			if (base.cooldownTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
			{
				anim.Play("Charging");
			}
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (EnemyManager.Instance.Enemies.Count == 0)
		{
			return false;
		}
		if (base.cooldownTimeElapsed < GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary))
		{
			return false;
		}
		int hackCount = (int)GetUpgradedStatValueByStatType(StatTypes.count);
		hackableEnemies = GetHackableEnemies(hackCount);
		if (hackableEnemies == null || hackableEnemies.Length == 0)
		{
			return false;
		}
		return base.CanInteract();
	}

	public EnemyBase[] GetHackableEnemies(int hackCount)
	{
		List<EnemyBase> list = new List<EnemyBase>();
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (IsEnemyHackable(enemy))
			{
				list.Add(enemy);
			}
		}
		return list.OrderBy((EnemyBase _) => UnityEngine.Random.value).Take(hackCount).ToArray();
	}

	public bool IsEnemyHackable(Unit enemy)
	{
		if (enemy.IsHackable && enemy.IsEnemy && !enemy.IsElite)
		{
			return true;
		}
		return false;
	}

	public override void Activate()
	{
		EnemyBase[] array = hackableEnemies;
		foreach (EnemyBase enemyToHack in array)
		{
			HackEnemy(enemyToHack);
			UpdateMainStat(1f);
		}
		base.cooldownTimeElapsed = 0f;
		hackableEnemies = null;
		PlayModuleUniqueSound();
		base.Activate();
	}

	public void HackEnemy(EnemyBase enemyToHack)
	{
		enemyToHack.IsHacked = true;
		StatusEffect statusEffect = enemyToHack.GetComponent<StatusEffectComponent>().ApplyStatusEffect(statusEffectHack, enemyToHack);
		if (ProbUtils.CheckWithLuck(prob))
		{
			statusEffect.SetDuration(-1f);
		}
		else
		{
			statusEffect.SetDuration(GetUpgradedStatValueByStatType(StatTypes.duration));
		}
		statusEffect.Expired += OnHackExpired;
		hackedEnemies.Add((enemyToHack, statusEffect));
		enemyToHack.TargetDamaged += OnHackedEnemyDamageTarget;
		this.OnEnemyHacked?.Invoke(enemyToHack);
	}

	public void ForceInfiniteHack(EnemyBase enemyToHack)
	{
		enemyToHack.IsHacked = true;
		StatusEffect statusEffect = enemyToHack.GetComponent<StatusEffectComponent>().ApplyStatusEffect(statusEffectHack, enemyToHack);
		statusEffect.SetDuration(-1f);
		statusEffect.Expired += OnHackExpired;
		hackedEnemies.Add((enemyToHack, statusEffect));
		enemyToHack.TargetDamaged += OnHackedEnemyDamageTarget;
	}

	private void StopAllHacking()
	{
		while (hackedEnemies.Count > 0)
		{
			if (hackedEnemies[0].Item1 != null)
			{
				StopHack(hackedEnemies[0].Item1, hackedEnemies[0].Item2);
			}
		}
	}

	private void OnHackExpired(Unit unit, StatusEffect statusEffect)
	{
		if (!(unit == null) && !(statusEffect == null))
		{
			DeregisterHackedEnemy(unit as EnemyBase, statusEffect);
			this.OnHackExpiration?.Invoke(unit as EnemyBase);
		}
	}

	private void StopHack(EnemyBase enemy, StatusEffect statusEffect)
	{
		statusEffect.Expire();
	}

	private void DeregisterHackedEnemy(EnemyBase enemy, StatusEffect statusEffect)
	{
		enemy.IsHacked = false;
		hackedEnemies.Remove((enemy, statusEffect));
	}

	protected override void HandleLevelCompleted()
	{
		StopAllHacking();
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		anim.Play("Dead");
		StopAllHacking();
	}

	private void OnHackedEnemyDamageTarget(HealthChangeInfo info)
	{
		this.HackedEnemyHit?.Invoke(info);
	}
}
