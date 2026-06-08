using System.Collections.Generic;
using UnityEngine;

public class BladeOfGodActivationState : SuperAbilityActivationState
{
	public class BladeState : State
	{
		public static readonly State PallasEnter = new State("PallasEnter");

		public static readonly State PallasExit = new State("PallasExit");
	}

	private readonly int RANGE = 30;

	public AsciiAnimation pallasAnm;

	public AsciiAnimation weaponFocusVfx;

	public DebuffStatMod smiteBuffPrefab;

	private int smiteGainedCount;

	private List<Damage> validDamageObjects = new List<Damage>();

	public override void Activate()
	{
		base.Activate();
		smiteGainedCount = 0;
	}

	private void DealDamage()
	{
		GameStates singleton = GameStates.Singleton;
		GameCamera gameCamera = singleton.level.gameCamera;
		Hero hero = singleton.hero;
		int amount = ComputeDamageAmountPerFoe();
		validDamageObjects.Clear();
		for (int num = singleton.level.Enemies.Count - 1; num >= 0; num--)
		{
			Enemy enemy = singleton.level.Enemies[num];
			if (enemy.Alive && enemy.PositionX < gameCamera.PositionX + RANGE)
			{
				Damage damage = new Damage();
				damage.type = Damage.Type.Super;
				damage.amount = amount;
				damage.Owner = hero;
				if (enemy.GetElement() == ItemData.Element.Fire)
				{
					damage.amount *= 2;
				}
				damage.tags.Add("blade_of_god");
				damage.tags.Add("AEther");
				damage.tags.Add("activated_ability");
				validDamageObjects.Add(damage);
				enemy.InflictDamage(damage);
			}
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.amount <= 0 || dmg.type != Damage.Type.Super || !dmg.tags.Contains("blade_of_god") || !validDamageObjects.Contains(dmg))
		{
			return;
		}
		FloatingText floatingText = c.ShowFloatingText("•" + dmg.amount + "•");
		if (c.Hitpoints <= 0)
		{
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.magenta;
			}
			AddBuff(smiteBuffPrefab);
			BladeOfGodGoals.singleton.ReportEnemyKilledWithBladeSuperAttack(c);
			smiteGainedCount++;
		}
	}

	private DebuffStatMod AddBuff(DebuffStatMod buffPrefab)
	{
		Hero hero = GameStates.Singleton.hero;
		if (!hero.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(buffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = base.sourceItem;
			debuffStatMod.character = hero;
			debuffStatMod.Init();
			hero.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate buff " + buffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(c != hero) || !(c != null) || !(debuff != null) || debuff.isPositiveBuff)
		{
			return;
		}
		int num = ComputeDamageBonusFromSmite();
		if (num > 0)
		{
			Damage damage = new Damage();
			damage.type = Damage.Type.Ranged;
			damage.amount = num;
			damage.Owner = hero;
			if (c.GetElement() == ItemData.Element.Fire)
			{
				damage.amount = Mathf.RoundToInt((float)num * 1.5f);
			}
			damage.tags.Add("magic");
			damage.tags.Add("AEther");
			int foeHealthBeforeSmite = c.Hitpoints + Mathf.CeilToInt(c.Armor);
			c.InflictDamage(damage);
			FloatingText floatingText = c.ShowFloatingText("•" + damage.amount + "•");
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.magenta;
			}
			BladeOfGodGoals.singleton.ReportSmiteDamage(num, damage, foeHealthBeforeSmite, c);
		}
	}

	private int ComputeDamageAmountPerFoe()
	{
		return Mathf.FloorToInt(ComputeStatWithId("blade_activated_damage"));
	}

	private int ComputeDamageBonusFromSmite()
	{
		int smiteCount = GetSmiteCount();
		if (smiteCount <= 0)
		{
			return 0;
		}
		return Mathf.FloorToInt(ComputeStatWithId("blade_smite_buff") * (float)smiteCount);
	}

	private int GetSmiteCount()
	{
		StatModController statModController = GameStates.Singleton.hero.statModController;
		if (statModController == null)
		{
			return 0;
		}
		if (statModController.debuffs == null)
		{
			return 0;
		}
		List<List<StatModifier>> debuffs = statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == "smite")
			{
				if (list[0].sourceItem != base.sourceItem)
				{
					return 0;
				}
				return list.Count;
			}
		}
		return 0;
	}

	protected override void SetState(State newState)
	{
		if (newState == State.Starting)
		{
			SetWeaponFrame(0);
		}
		else if (newState == BladeState.PallasEnter)
		{
			pallasAnm.Stop();
			pallasAnm.Play();
		}
		else if (newState == State.Done)
		{
			BladeOfGodGoals.singleton.ReportSmiteGained(smiteGainedCount);
			smiteGainedCount = 0;
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == State.Starting && stateElapsedTics == 1)
		{
			SfxController.singleton.Play("blade_raise");
		}
		else if (base.currentState == State.Starting && stateElapsedTics == 4)
		{
			SfxController.singleton.Play("blade_glow");
		}
		else if (base.currentState == BladeState.PallasEnter && stateElapsedTics == 10)
		{
			SfxController.singleton.Play("blade_pallas_attack");
		}
		if (base.currentState == State.Starting)
		{
			if (stateElapsedTics == 5)
			{
				weaponFocusVfx.Stop();
				weaponFocusVfx.Play();
			}
			if (stateElapsedTics <= 7)
			{
				SetWeaponFrame(stateElapsedTics);
			}
			else if (stateElapsedTics == 12)
			{
				SetState(BladeState.PallasEnter);
			}
		}
		else if (base.currentState == BladeState.PallasEnter && stateElapsedTics == 45)
		{
			DealDamage();
			SetState(BladeState.PallasExit);
		}
		else if (base.currentState == BladeState.PallasExit && stateElapsedTics == 15)
		{
			SetState(State.Done);
		}
	}

	private void SetWeaponFrame(int frameIndex)
	{
		if (base.sourceItem != null)
		{
			Weapon weapon = base.sourceItem as Weapon;
			if (weapon != null)
			{
				weapon.SetState(Weapon.State.Performing);
				weapon.SetStateElapsedTics(frameIndex);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
		if (weaponFocusVfx.Playing)
		{
			int lastDrawX = GameStates.Singleton.hero.lastDrawX;
			int lastDrawY = GameStates.Singleton.hero.lastDrawY;
			weaponFocusVfx.Sprite.Draw(r, lastDrawX, lastDrawY);
		}
		if (base.currentState == BladeState.PallasEnter || base.currentState == BladeState.PallasExit)
		{
			pallasAnm.Sprite.Draw(r, r.width / 2, 0);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
		StatModController.OnDebuffAdded += HandleDebuffAdded;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		base.OnDestroy();
	}
}
