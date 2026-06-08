using UnityEngine;

public class QuarterstaffActivatedAbility : WeaponActivatedAbility
{
	private const int MAX_DASH_AMOUNT = 5;

	public CustomAttack superAttack;

	public Decoration dashVfxPrefab;

	public override SuperAbilityActivationState ActivateAbility()
	{
		base.ActivateAbility();
		Hero hero = GameStates.Singleton.hero;
		int num = hero.PositionX + 5;
		Enemy targetEnemy = hero.GetComponent<HeroAI>().targetEnemy;
		if (targetEnemy != null)
		{
			int num2 = targetEnemy.PositionX - myWeapon.range;
			if (num > num2)
			{
				num = num2;
			}
			if (num < hero.PositionX)
			{
				num = hero.PositionX;
			}
			int value = targetEnemy.PositionY - hero.PositionY;
			value = Mathf.Clamp(value, -2, 2);
			hero.PositionY += value;
		}
		if (num > GameStates.Singleton.level.heroLimitX)
		{
			num = GameStates.Singleton.level.heroLimitX;
		}
		hero.PositionX = num;
		Decoration decoration = Object.Instantiate(dashVfxPrefab);
		decoration.PositionX = hero.PositionX;
		decoration.PositionY = hero.PositionY;
		decoration.PositionZ = hero.PositionZ;
		GameStates.Singleton.level.AddCharacter(decoration);
		SetAttack(superAttack);
		myWeapon.Attack(myWeapon.Owner);
		return null;
	}

	protected override void HandleWeaponStateChange(Weapon w, Weapon.State newState, Weapon.State prevState)
	{
		base.HandleWeaponStateChange(w, newState, prevState);
		if (newState == Weapon.State.Cooldown || newState == Weapon.State.Waiting)
		{
			if (currentAttack == superAttack)
			{
				SetAttack(base.defaultAttack);
			}
			RemoveAllAddedBuffs();
		}
	}

	protected override void HandleUnequipped(Character c, Weapon w)
	{
		base.HandleUnequipped(c, w);
		RemoveAllAddedBuffs();
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (dmg.bullet != null && dmg.bullet.weapon == myWeapon && currentAttack == superAttack)
		{
			CompoundShieldEventController.ReportQuarterstaffStunned();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		base.OnDestroy();
	}
}
