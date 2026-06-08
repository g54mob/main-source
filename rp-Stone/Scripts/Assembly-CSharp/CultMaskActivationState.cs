using System.Collections.Generic;
using UnityEngine;

public class CultMaskActivationState : SuperAbilityActivationState
{
	public class MaskState : State
	{
		public static readonly State NagarajaEnter = new State("NagarajaEnter");

		public static readonly State NagarajaSpit = new State("NagarajaSpit");

		public static readonly State NagarajaExit = new State("NagarajaExit");
	}

	private readonly int RANGE = 30;

	public AsciiAnimation nagarajaEnterAnm;

	public AsciiAnimation nagarajaSpitAnm;

	public AsciiAnimation nagarajaExitAnm;

	public AsciiAnimation playerBowingAnm;

	public Bullet poisonBulletPrefab;

	public DebuffStatMod feebleDebuffPrefab;

	private int totalSpits;

	private int spitCount;

	private bool isRenderingHero;

	private List<Enemy> possibleTargets = new List<Enemy>();

	private List<Bullet> activeBullets = new List<Bullet>();

	public override void Activate()
	{
		base.Activate();
		totalSpits = Mathf.FloorToInt(ComputeStatWithId("feeble_count"));
		spitCount = 0;
		GameStates singleton = GameStates.Singleton;
		GameCamera gameCamera = singleton.level.gameCamera;
		possibleTargets.Clear();
		for (int num = singleton.level.Enemies.Count - 1; num >= 0; num--)
		{
			Enemy enemy = singleton.level.Enemies[num];
			if (enemy.Alive && enemy.PositionX < gameCamera.PositionX + RANGE)
			{
				possibleTargets.Add(enemy);
			}
		}
		Weapon w = base.sourceItem as Weapon;
		_ApplyWeaponCosmetics(w, nagarajaEnterAnm);
		_ApplyWeaponCosmetics(w, nagarajaSpitAnm);
		_ApplyWeaponCosmetics(w, nagarajaExitAnm);
		_ApplyWeaponCosmetics(w, playerBowingAnm);
	}

	private void _ApplyWeaponCosmetics(Weapon w, AsciiAnimation anm)
	{
		_ApplyWeaponCosmetics(w, anm.Sprite);
	}

	private void _ApplyWeaponCosmetics(Weapon w, AsciiSprite sprite)
	{
		if (w != null && sprite != null)
		{
			w.LoadSprite(sprite);
		}
	}

	private void Spit()
	{
		if (possibleTargets.Count > 0)
		{
			int index = Random.Range(0, possibleTargets.Count);
			Enemy enemy = possibleTargets[index];
			Bullet bullet = Object.Instantiate(poisonBulletPrefab);
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			bullet.PositionX = gameCamera.PositionX - 13;
			bullet.PositionY = enemy.PositionZ - 7;
			bullet.PositionZ = enemy.PositionZ;
			bullet.Owner = base.sourceItem.Owner;
			bullet.weapon = base.sourceItem as Weapon;
			bullet.target = enemy;
			ItemData.Rarity.Type rarityType = base.sourceItem.GetRarityType();
			switch (rarityType)
			{
			case ItemData.Rarity.Type.Transcendent:
				bullet.gameObject.AddComponent<AsciiSpritePPRainbow>();
				break;
			default:
				bullet.colorTint = ItemData.Rarity.GetColorForRarity(rarityType);
				break;
			case ItemData.Rarity.Type.Common:
				break;
			}
			int damage = Mathf.FloorToInt(ComputeStatWithId("feeble_damage"));
			bullet.SetDamage(damage);
			bullet.tags.Add("mask");
			bullet.tags.Add("nagaraja");
			bullet.tags.Add("activated_ability");
			activeBullets.Add(bullet);
			GameStates.Singleton.level.AddCharacter(bullet);
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.amount > 0 && dmg.Owner != null && base.sourceItem != null && dmg.Owner == base.sourceItem.Owner && dmg.tags.Contains("nagaraja"))
		{
			FloatingText floatingText = c.ShowFloatingText("∞");
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.red;
			}
			AddDebuff(c, feebleDebuffPrefab);
		}
	}

	private DebuffStatMod AddDebuff(Character c, DebuffStatMod debuffPrefab)
	{
		Hero hero = GameStates.Singleton.hero;
		if (!hero.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = base.sourceItem;
			debuffStatMod.character = hero;
			debuffStatMod.ticDuration = Mathf.FloorToInt(30f * ComputeStatWithId("feeble_duration"));
			debuffStatMod.element = ItemData.Element.Poison;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			c.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		if (!(base.sourceItem.Owner == null))
		{
			Hero hero = GameStates.Singleton.hero;
			if (c != hero && c != null && debuff != null && !debuff.isPositiveBuff)
			{
				int num = Mathf.FloorToInt(ComputeStatWithId("increase_debuff_durations"));
				debuff.ticDuration = debuff.ticDuration * (100 + num) / 100;
			}
		}
	}

	private int ComputeDamageAmountPerFoe()
	{
		return Mathf.FloorToInt(ComputeStatWithId("feeble_damage"));
	}

	protected override void SetState(State newState)
	{
		if (newState == State.Starting)
		{
			if (GameStates.Singleton.hero.renderingEnabled)
			{
				GameStates.Singleton.hero.renderingEnabled = false;
				isRenderingHero = true;
				playerBowingAnm.Stop();
				playerBowingAnm.Play();
				Weapon weapon = base.sourceItem as Weapon;
				if (weapon != null && weapon.idleSprite != null)
				{
					playerBowingAnm.Sprite.colorOverride = weapon.idleSprite.colorOverride;
				}
			}
			else
			{
				isRenderingHero = false;
			}
		}
		else if (newState == MaskState.NagarajaEnter)
		{
			nagarajaEnterAnm.Stop();
			nagarajaEnterAnm.Play();
		}
		else if (newState == MaskState.NagarajaSpit)
		{
			nagarajaSpitAnm.Stop();
			nagarajaSpitAnm.Play();
		}
		else if (newState == MaskState.NagarajaExit)
		{
			nagarajaExitAnm.Stop();
			nagarajaExitAnm.Play();
		}
		else if (newState == State.Done)
		{
			if (isRenderingHero)
			{
				GameStates.Singleton.hero.renderingEnabled = true;
			}
			activeBullets.Clear();
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == State.Starting && stateElapsedTics == 1)
		{
			SfxController.singleton.Play("mask_summon_1");
		}
		else if (base.currentState == MaskState.NagarajaEnter && stateElapsedTics == 8)
		{
			SfxController.singleton.Play("mask_summon_2");
		}
		else if (base.currentState == MaskState.NagarajaSpit && stateElapsedTics == 1)
		{
			SfxController.singleton.Play("nagaraja_poison_attack");
		}
		if (base.currentState == State.Starting)
		{
			if (stateElapsedTics == 12)
			{
				SetState(MaskState.NagarajaEnter);
			}
		}
		else if (base.currentState == MaskState.NagarajaEnter && stateElapsedTics == 29)
		{
			if (possibleTargets.Count > 0)
			{
				SetState(MaskState.NagarajaSpit);
			}
			else
			{
				SetState(MaskState.NagarajaExit);
			}
		}
		else if (base.currentState == MaskState.NagarajaSpit)
		{
			if (stateElapsedTics == 10)
			{
				Spit();
				spitCount++;
			}
			else if (stateElapsedTics == 16)
			{
				if (spitCount >= totalSpits)
				{
					SetState(MaskState.NagarajaExit);
				}
				else
				{
					SetState(MaskState.NagarajaSpit);
				}
			}
		}
		else if (base.currentState == MaskState.NagarajaExit && stateElapsedTics == 28)
		{
			SetState(State.Done);
		}
		for (int num = activeBullets.Count - 1; num >= 0; num--)
		{
			Bullet bullet = activeBullets[num];
			if (bullet != null && bullet.gameObject != null)
			{
				bullet.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
		if (isRenderingHero)
		{
			int lastDrawX = GameStates.Singleton.hero.lastDrawX;
			int lastDrawY = GameStates.Singleton.hero.lastDrawY;
			playerBowingAnm.Sprite.Draw(r, lastDrawX, lastDrawY);
		}
		int num = -2;
		if (base.currentState == MaskState.NagarajaEnter)
		{
			nagarajaEnterAnm.Sprite.Draw(r, r.width / 2 + num, 0);
		}
		else if (base.currentState == MaskState.NagarajaSpit)
		{
			nagarajaSpitAnm.Sprite.Draw(r, r.width / 2 + num, 0);
			for (int i = 0; i < activeBullets.Count; i++)
			{
				Bullet bullet = activeBullets[i];
				bullet.Draw(r, bullet.lastDrawX - bullet.PositionX, bullet.lastDrawY - bullet.PositionZ + bullet.PositionY);
			}
		}
		else if (base.currentState == MaskState.NagarajaExit)
		{
			nagarajaExitAnm.Sprite.Draw(r, r.width / 2 + num, 0);
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
