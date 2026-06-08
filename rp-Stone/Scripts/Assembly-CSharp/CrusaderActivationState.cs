using System.Collections.Generic;
using UnityEngine;

public class CrusaderActivationState : SuperAbilityActivationState
{
	public class CrusaderState : State
	{
		public static readonly State Cross = new State("Cross");
	}

	public AsciiAnimation cross;

	public DebuffStatMod pureBuffPrefab;

	public override void Activate()
	{
		base.Activate();
	}

	protected override void SetState(State newState)
	{
		if (newState == CrusaderState.Cross)
		{
			cross.Stop();
			cross.Play();
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == CrusaderState.Cross)
		{
			_ = stateElapsedTics;
			_ = 1;
		}
		if (base.currentState == State.Starting)
		{
			SetState(CrusaderState.Cross);
		}
		else if (base.currentState == CrusaderState.Cross && stateElapsedTics == 15)
		{
			SetState(State.Done);
			Hero hero = GameStates.Singleton.hero;
			CountDebuffsAndHeal(hero);
			hero.Cleanse();
			AddBuff(hero, pureBuffPrefab);
		}
	}

	private DebuffStatMod AddBuff(Character target, DebuffStatMod debuffPrefab)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			Hero hero = GameStates.Singleton.hero;
			debuffStatMod.sourceItem = base.sourceItem;
			debuffStatMod.character = hero;
			debuffStatMod.ticDuration = Mathf.FloorToInt(30f * ComputeStatWithId("pure_duration"));
			debuffStatMod.element = ItemData.Element.Vigor;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	private void CountDebuffsAndHeal(Character target)
	{
		int num = 0;
		for (int i = 0; i < target.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = target.statModController.debuffs[i];
			for (int j = 0; j < list.Count; j++)
			{
				StatModifier statModifier = list[j];
				if (!statModifier.isPositiveBuff && statModifier.ticDuration > 0 && statModifier.cleansable)
				{
					num++;
				}
			}
		}
		Damage damage = new Damage();
		damage.amount = num;
		damage.tags.Add("crusader_shield");
		target.ApplyHeal(damage);
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
		if (base.currentState == CrusaderState.Cross)
		{
			int lastDrawX = GameStates.Singleton.hero.lastDrawX;
			int lastDrawY = GameStates.Singleton.hero.lastDrawY;
			cross.Sprite.Draw(r, lastDrawX, lastDrawY);
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
