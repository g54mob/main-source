using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponActivatedAbility : MonoBehaviour, IAbilityActivationProvider
{
	public enum BuffApplyPhase
	{
		Cast = 0,
		Perf = 1
	}

	public string abilityId;

	public int cooldown = 30;

	public SuperAbilityActivationState baseActivationState;

	public ItemData.Ability[] abilityStats;

	public BuffApplyPhase applyBuffsOn = BuffApplyPhase.Perf;

	public DebuffStatMod[] buffsToSelf;

	protected Weapon myWeapon;

	protected AbilityClock clock;

	protected CustomAttack currentAttack;

	protected List<DebuffStatMod> buffInstancesAdded = new List<DebuffStatMod>();

	public CustomAttack defaultAttack { get; private set; }

	public virtual string GetId()
	{
		return abilityId;
	}

	public virtual bool IsAvailable()
	{
		return true;
	}

	public AsciiSprite GetIcon()
	{
		return IconLoader.Singleton.GetSharedIcon(myWeapon.iconPath, 'o', ItemData.CharForElement(myWeapon.element));
	}

	public virtual bool IsEnabled()
	{
		return true;
	}

	public virtual bool IsWaiting()
	{
		return clock.GetPercent() >= 1f;
	}

	public virtual float GetCooldownRemaining()
	{
		return 1f - clock.GetPercent();
	}

	public virtual SuperAbilityActivationState ActivateAbility()
	{
		clock.duration = ComputeCooldown();
		clock.Play();
		if (applyBuffsOn == BuffApplyPhase.Cast)
		{
			ApplyBuffs();
		}
		return baseActivationState;
	}

	protected void ApplyBuffs()
	{
		for (int num = buffInstancesAdded.Count - 1; num >= 0; num--)
		{
			if (buffInstancesAdded[num] == null)
			{
				buffInstancesAdded.RemoveAt(num);
			}
		}
		for (int i = 0; i < buffsToSelf.Length; i++)
		{
			AddBuff(buffsToSelf[i]);
		}
	}

	protected void SetAttack(CustomAttack attack)
	{
		if (!attack.hasLoadedSprites)
		{
			attack.hasLoadedSprites = true;
			myWeapon.LoadSprites(attack.sprites, null, myWeapon.GetRarityType());
		}
		for (int i = 0; i < attack.sprites.Length; i++)
		{
			if (attack.sprites[i].maxDistance == 0 && attack.sprites[i].minDistance == 0)
			{
				attack.sprites[i].maxDistance = 999;
			}
		}
		myWeapon.rightHandSprites = attack.sprites;
		myWeapon.cast = attack.castTime;
		myWeapon.perf = attack.perfTime;
		myWeapon.cooldown = attack.cooldown;
		myWeapon.UpdateAttackSpeed();
		myWeapon.UpdateCurrentAttackSprites();
		myWeapon.UpdateSelectedSprite();
		if (attack.bulletPrefab != null)
		{
			myWeapon.bulletPrefab = attack.bulletPrefab;
		}
		currentAttack = attack;
	}

	protected DebuffStatMod AddBuff(DebuffStatMod buffPrefab)
	{
		Hero hero = GameStates.Singleton.hero;
		if (!hero.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = UnityEngine.Object.Instantiate(buffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = myWeapon;
			debuffStatMod.character = hero;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			hero.AddStatModifier(debuffStatMod);
			debuffStatMod.OnEnded += HandleBuffEnded;
			buffInstancesAdded.Add(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate buff " + buffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	protected void RemoveAllAddedBuffs()
	{
		for (int num = buffInstancesAdded.Count - 1; num >= 0; num--)
		{
			if (buffInstancesAdded[num] != null)
			{
				buffInstancesAdded[num].End();
			}
		}
	}

	private void HandleBuffEnded(StatModifier statMod)
	{
		DebuffStatMod debuffStatMod = (DebuffStatMod)statMod;
		if (debuffStatMod != null)
		{
			debuffStatMod.OnEnded -= HandleBuffEnded;
			buffInstancesAdded.Remove(debuffStatMod);
		}
	}

	protected virtual void HandleWeaponStateChange(Weapon w, Weapon.State newState, Weapon.State prevState)
	{
		if (newState == Weapon.State.Performing && applyBuffsOn == BuffApplyPhase.Perf)
		{
			ApplyBuffs();
		}
	}

	protected virtual void HandleCooldownComplete(AbilityClock c)
	{
	}

	protected virtual void HandleUnequipped(Character c, Weapon w)
	{
		if (w == myWeapon && currentAttack != defaultAttack)
		{
			SetAttack(defaultAttack);
		}
	}

	protected virtual int ComputeCooldown()
	{
		float num = ComputeStatWithId("cooldown");
		if (num > 0f)
		{
			return Mathf.FloorToInt(num * 30f);
		}
		return cooldown;
	}

	public float ComputeStatWithId(string searchId)
	{
		ItemData.Ability ability = FindAbilityWithId(searchId);
		if (ability != null)
		{
			float num = ItemFactory.GetLevelDisplayValueForItem(myWeapon);
			if (ability.applyRarity && myWeapon.rarity != null)
			{
				num = ((!ability.stat.rareStatOnly) ? (num + (float)myWeapon.rarity.levelBonus) : ((float)myWeapon.rarity.levelBonus));
			}
			else if (!ability.applyRarity && ability.stat.rareStatOnly)
			{
				if (!ability.stat.computeEvenIfRareOnly)
				{
					return 0f;
				}
				num = 0f;
			}
			return ability.stat.Compute(num);
		}
		return 0f;
	}

	public ItemData.Ability FindAbilityWithId(string searchId)
	{
		for (int i = 0; i < abilityStats.Length; i++)
		{
			ItemData.Ability ability = abilityStats[i];
			if (ability.id == searchId)
			{
				return ability;
			}
		}
		return null;
	}

	protected virtual void Awake()
	{
		if (baseActivationState != null)
		{
			baseActivationState.abilityId = GetId();
		}
		myWeapon = GetComponent<Weapon>();
		Weapon weapon = myWeapon;
		weapon.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Combine(weapon.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleWeaponStateChange));
		Character.OnCharacterUnequippedWeapon += HandleUnequipped;
		defaultAttack = new CustomAttack();
		defaultAttack.hasLoadedSprites = true;
		defaultAttack.castTime = myWeapon.cast;
		defaultAttack.perfTime = myWeapon.perf;
		defaultAttack.cooldown = myWeapon.cooldown;
		if (myWeapon.rightHandSprites.Length != 0)
		{
			defaultAttack.sprites = myWeapon.rightHandSprites;
		}
		else
		{
			defaultAttack.sprites = new Weapon.AttackSprites[1];
			defaultAttack.sprites[0] = new Weapon.AttackSprites();
			defaultAttack.sprites[0].idleSprite = myWeapon.idleSprite;
			defaultAttack.sprites[0].castSprite = myWeapon.castSprite;
			defaultAttack.sprites[0].perfSprite = myWeapon.perfSprite;
		}
		defaultAttack.bulletPrefab = myWeapon.bulletPrefab;
		currentAttack = defaultAttack;
		clock = AbilityClock.GetClockForAbility(abilityId);
		clock.OnComplete += HandleCooldownComplete;
	}

	protected virtual void OnDestroy()
	{
		Weapon weapon = myWeapon;
		weapon.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Remove(weapon.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleWeaponStateChange));
		Character.OnCharacterUnequippedWeapon -= HandleUnequipped;
		clock.OnComplete -= HandleCooldownComplete;
		clock = null;
	}
}
