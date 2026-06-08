using System.Collections.Generic;
using UnityEngine;

public class Poena : Enemy
{
	public DebuffStatMod mirrorBuff;

	public DebuffStatMod critChanceBuff;

	public DebuffStatMod critMultBuff;

	public DebuffStatMod damageBuff;

	public int healBase = 9;

	public int healLevelMult = 1;

	public int removeMirrorFrame = 5;

	public int addMirrorFrame = 6;

	private DebuffStatMod mirrorBuffInstance;

	protected override void SetState(State newState)
	{
		if (newState == State.WakingUp)
		{
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			gameCamera.SetupLerpToPos(gameCamera.PositionX, gameCamera.PositionY + 3, gameCamera.PositionZ, 0.2f);
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX - 23, base.PositionZ);
			GameStates.Singleton.hero.PauseAI(3f);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		}
		if (base.CurrentState == State.WakingUp)
		{
			Cleanse();
			AddMirror();
			GameStates.Singleton.hero.RestoreAI();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			MusicController.singleton.Play("poena");
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState != State.Attacking)
		{
			return;
		}
		if (base.stateElapsedTics == removeMirrorFrame)
		{
			RemoveMirror();
		}
		else if (!HasMirror() && base.weapon.CurrentState == Weapon.State.Performing)
		{
			int num = addMirrorFrame * base.weapon.GetPerfTics() / base.weapon.perf;
			if (base.weapon.StateElapsedTics >= base.weapon.GetPerfTics() - num)
			{
				RemoveAllBuffs();
				AddMirror();
			}
		}
	}

	private void AddMirror()
	{
		if (mirrorBuffInstance == null && Alive)
		{
			mirrorBuffInstance = Object.Instantiate(mirrorBuff);
			mirrorBuffInstance.character = this;
			mirrorBuffInstance.Init();
			AddStatModifier(mirrorBuffInstance);
		}
	}

	private void RemoveMirror()
	{
		if (mirrorBuffInstance != null)
		{
			mirrorBuffInstance.End();
			mirrorBuffInstance = null;
		}
	}

	private bool HasMirror()
	{
		return mirrorBuffInstance != null;
	}

	private void RemoveAllBuffs()
	{
		if (!base.statModController)
		{
			return;
		}
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list2 = base.statModController.debuffs[i];
			for (int j = 0; j < list2.Count; j++)
			{
				StatModifier statModifier = list2[j];
				if (statModifier.isPositiveBuff)
				{
					list.Add(statModifier);
				}
			}
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			list[num].End();
		}
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		Character hero = GameStates.Singleton.hero;
		if (c == this && !debuff.isPositiveBuff && hero.Alive && HasMirror())
		{
			DebuffStatMod debuffStatMod = Object.Instantiate(debuff);
			debuffStatMod.sourceItem = base.weapon;
			debuffStatMod.character = hero;
			debuffStatMod.statData = debuff.statData;
			debuffStatMod.ticDuration = debuff.ticDuration;
			debuffStatMod.element = debuff.element;
			debuffStatMod.Init();
			hero.AddStatModifier(debuffStatMod);
		}
	}

	private void HandleTookDamage(Character c, Damage dmg)
	{
		if (!(c == this) || !Alive || !HasMirror())
		{
			return;
		}
		if (HasOffensiveUnmake())
		{
			GameStates.Singleton.hero.Die(DeathReason.Custom);
			AchievementController.singleton.ReportSelfUnmakeMirror();
			return;
		}
		if (dmg.isCritical)
		{
			ApplyDebuff(critChanceBuff, this, 99999);
			ApplyDebuff(critMultBuff, this, 99999);
		}
		if (damageBuff != null && dmg.type != Damage.Type.Dot)
		{
			ApplyDebuff(damageBuff, this, 99999);
		}
	}

	private void HandleCharacterHealed(Character c, Damage heal)
	{
		if (c == GameStates.Singleton.hero && HasMirror() && heal.tags.Contains("lifesteal"))
		{
			Damage damage = new Damage();
			damage.Owner = heal.Owner;
			damage.amount = heal.amount * (healBase + healLevelMult * level);
			damage.tags = heal.tags;
			ApplyHeal(damage);
		}
	}

	private DebuffStatMod ApplyDebuff(DebuffStatMod debuffPrefab, Character target, int duration)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = base.weapon;
			debuffStatMod.character = target;
			debuffStatMod.element = GetElement();
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.ticDuration = duration;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for " + this);
		}
		return debuffStatMod;
	}

	private bool HasOffensiveUnmake()
	{
		Hero hero = GameStates.Singleton.hero;
		if (!HasUnmakeAbility(hero.RightHand))
		{
			return HasUnmakeAbility(hero.LeftHand);
		}
		return true;
	}

	private bool HasUnmakeAbility(Weapon w)
	{
		if (w != null)
		{
			return HasUnmakeAbility(w.statModController);
		}
		return false;
	}

	private bool HasUnmakeAbility(StatModController controller)
	{
		if (controller != null)
		{
			for (int i = 0; i < controller.statModifiers.Count; i++)
			{
				if (controller.statModifiers[i].id == "insta_kill")
				{
					return true;
				}
			}
		}
		return false;
	}

	protected override void Awake()
	{
		base.Awake();
		StatModController.OnDebuffAdded += HandleDebuffAdded;
		StatModController.OnDebuffReset += HandleDebuffAdded;
		Character.OnCharacterTookDamage += HandleTookDamage;
		Character.OnCharacterWasHealed += HandleCharacterHealed;
	}

	protected override void OnDestroy()
	{
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		StatModController.OnDebuffReset -= HandleDebuffAdded;
		Character.OnCharacterTookDamage -= HandleTookDamage;
		Character.OnCharacterWasHealed -= HandleCharacterHealed;
		base.OnDestroy();
	}
}
