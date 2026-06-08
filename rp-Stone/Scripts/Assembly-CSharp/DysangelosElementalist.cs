using System;
using UnityEngine;

public class DysangelosElementalist : Enemy, IPostAsciiRendererEffect
{
	[Serializable]
	public class AttackData
	{
		public AsciiSprite cast;

		public AsciiSprite perf;

		public Weapon weapon;
	}

	private enum ElementalistState
	{
		Waiting = 0,
		WhiteFadeBack = 1,
		PreFightPause = 2,
		Fighting = 3,
		TalkDefeated = 4,
		ExperienceDialog = 5,
		Completed = 6,
		EvolvingToPerfected = 7,
		EvolvingWhiteFlash = 8
	}

	private int heroApproachOffsetX = -18;

	public DebuffStatMod poisonDebuff;

	public DebuffStatMod vigorBuff;

	public DebuffStatMod fireDebuff;

	public DebuffStatMod iceDebuff;

	public int chillBaseDuration = 660;

	public AsciiParticleEmitter fireUnmadeEmitter;

	public AsciiSprite fireArmIdleSprite;

	public AsciiSprite fireArmCastSprite;

	public AsciiSprite fireArmPerfSprite;

	public Bullet doNothingBulletPrefab;

	public AsciiAnimation eyeAnm;

	public AsciiAnimation idleAnm;

	public AsciiAnimation defeatedTalking;

	public AsciiAnimation defeatedEvolvingAnm;

	public AsciiAnimation evolvingSansFireAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public DysangelosPerfected perfectedPrefab;

	public Decoration sunDogPrefab;

	public Decoration summerParticlesPrefab;

	private Decoration sunDogInstance;

	private Decoration summerParticlesInstance;

	public AttackData[] attacks;

	private int attackIndex = -1;

	private int elapsedElementalistTics;

	private ItemData.Element currentElement;

	private int immuneToDebuffsRemaining;

	private bool fireArmUnmade;

	private float whiteScreenPercent;

	private ElementalistState elementalistState { get; set; }

	public override bool Alive
	{
		get
		{
			if (elementalistState > ElementalistState.Fighting)
			{
				return false;
			}
			return base.Alive;
		}
	}

	private void SetElementalistState(ElementalistState newState)
	{
		switch (newState)
		{
		case ElementalistState.WhiteFadeBack:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			base.MySprite = idleAnm.Sprite;
			idleAnm.Play();
			BigHead.seeingBossTime = 2f;
			MusicController.singleton.Play("rocky_plateau_fight");
			SpawnSummerSolsticeCosmetics();
			break;
		case ElementalistState.PreFightPause:
			MoneyUI.singleton.hideTopHUD = true;
			GameStates.Singleton.hud.currentEnemy = this;
			GameStates.Singleton.hud.UpdateEnemyHitpoints();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			break;
		case ElementalistState.Fighting:
			GameStates.Singleton.hero.RestoreAI();
			WakeUp();
			break;
		case ElementalistState.TalkDefeated:
			SetupDefeated();
			base.MySprite = defeatedTalking.Sprite;
			defeatedTalking.Play();
			SetupDialog(Te.xt("You've grown stronger than I imagined. No matter! This isn't even my final form!"));
			dialogBubble.PositionY++;
			SfxController.singleton.Play("elementalist_death");
			MusicController.singleton.FadeToSilence();
			break;
		case ElementalistState.ExperienceDialog:
			GameStates.Singleton.level.XpEarned += 20;
			GameStates.Singleton.ScheduleXpDialog();
			break;
		case ElementalistState.Completed:
			GameStates.Singleton.CompleteQuest();
			break;
		case ElementalistState.EvolvingToPerfected:
			SetupDefeated();
			if (fireArmUnmade)
			{
				base.MySprite = evolvingSansFireAnm.Sprite;
				evolvingSansFireAnm.Play();
			}
			else
			{
				base.MySprite = defeatedEvolvingAnm.Sprite;
				defeatedEvolvingAnm.Play();
			}
			SfxController.singleton.Play("elementalist_evolving", ignoreDuplicateSfxInSameFrame: true, 1.4f);
			break;
		case ElementalistState.EvolvingWhiteFlash:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			break;
		}
		elementalistState = newState;
		elapsedElementalistTics = 0;
	}

	private void SetupDefeated()
	{
		GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
		GameStates.Singleton.hero.StopAttacking();
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		GameStates.Singleton.hud.currentEnemy = null;
		Cleanse();
		base.weapon.SetState(Weapon.State.Waiting);
		base.SetState(State.Sleeping);
	}

	protected override void SetState(State newState)
	{
		if (newState != State.WakingUp || (elementalistState >= ElementalistState.WhiteFadeBack && elementalistState < ElementalistState.TalkDefeated))
		{
			if (newState == State.Attacking)
			{
				NextAttack();
			}
			base.SetState(newState);
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedElementalistTics++;
		immuneToDebuffsRemaining--;
		if (elementalistState == ElementalistState.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			SetElementalistState(ElementalistState.WhiteFadeBack);
		}
		else if (elementalistState == ElementalistState.WhiteFadeBack)
		{
			if (elapsedElementalistTics == 30)
			{
				eyeAnm.Play();
			}
			else if (elapsedElementalistTics >= 60)
			{
				SetElementalistState(elementalistState + 1);
			}
		}
		else if (elementalistState == ElementalistState.PreFightPause && elapsedElementalistTics >= 30)
		{
			SetElementalistState(elementalistState + 1);
		}
		else if (elementalistState != ElementalistState.Fighting)
		{
			if (elementalistState == ElementalistState.TalkDefeated)
			{
				GameStates.Singleton.hud.currentEnemy = null;
			}
			else if (elementalistState == ElementalistState.ExperienceDialog && elapsedElementalistTics >= 5)
			{
				SetElementalistState(elementalistState + 1);
			}
			else if (elementalistState == ElementalistState.EvolvingToPerfected && elapsedElementalistTics >= 150)
			{
				SetElementalistState(elementalistState + 1);
			}
			else if (elementalistState == ElementalistState.EvolvingWhiteFlash && elapsedElementalistTics >= 15)
			{
				Evolve();
			}
		}
		if (elementalistState == ElementalistState.TalkDefeated)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void HandleDialogButtonDone()
	{
		SetElementalistState(elementalistState + 1);
	}

	private void NextAttack()
	{
		attackIndex = UnityEngine.Random.Range(0, attacks.Length);
		AttackData attackData = attacks[attackIndex];
		attackCastSprite = attackData.cast;
		attackPerfSprite = attackData.perf;
		base.weapon = attackData.weapon;
		base.weapon.Owner = this;
		base.weapon.LoadAbilities();
		currentElement = base.weapon.element;
		tags[2] = currentElement.ToString();
		string replaceWith = ItemData.CharForElement(currentElement).ToString();
		eyeAnm.Sprite.stringReplacements[0].replaceWith = replaceWith;
		eyeAnm.Sprite.Reload();
		eyeAnm.Stop();
		eyeAnm.Play();
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (elementalistState >= ElementalistState.TalkDefeated)
		{
			dmg.amount = 0;
		}
		else if (c == this)
		{
			if (dmg.bullet != null && dmg.bullet.weapon != null && dmg.bullet.weapon.element == ItemData.CounteredBy(currentElement))
			{
				dmg.amount *= 2;
				dmg.isCritical = true;
			}
		}
		else
		{
			if (!(dmg.Owner == this) || !(dmg.bullet != null) || !(dmg.bullet.weapon == base.weapon))
			{
				return;
			}
			ItemData.Element element = ItemData.CounteredBy(currentElement);
			ItemData.Element element2 = ItemData.Counters(currentElement);
			Hero hero = GameStates.Singleton.hero;
			bool flag = (hero.LeftHand != null && hero.LeftHand.element == element) || (hero.RightHand != null && hero.RightHand.element == element) || (hero.faerie != null && hero.faerie.weapon != null && hero.faerie.weapon.element == element);
			bool flag2 = (hero.LeftHand != null && hero.LeftHand.element == element2) || (hero.RightHand != null && hero.RightHand.element == element2) || (hero.faerie != null && hero.faerie.weapon != null && hero.faerie.weapon.element == element2);
			if (currentElement == ItemData.Element.Poison && !flag)
			{
				int num = 1;
				if (level > 5)
				{
					num++;
				}
				if (level > 15)
				{
					num++;
				}
				if (level > 25)
				{
					num++;
				}
				if (level > 0 && flag2)
				{
					num *= 2;
				}
				while (num-- > 0)
				{
					ApplyDebuff(poisonDebuff, hero, 1800);
				}
			}
			else if (currentElement == ItemData.Element.Vigor)
			{
				Cleanse();
				immuneToDebuffsRemaining = 900;
				ApplyDebuff(vigorBuff, this, immuneToDebuffsRemaining);
				if (flag)
				{
					dmg.amount = 0;
					hero.ShowFloatingText(Te.xt("MISSED"));
					return;
				}
				Damage damage = new Damage();
				damage.amount = 200 + 100 * level;
				ApplyHeal(damage);
				SfxController.singleton.Play("life_gain");
			}
			else if (currentElement == ItemData.Element.AEther)
			{
				if (!flag && dmg.amount > 0)
				{
					dmg.isCritical = true;
					dmg.amount = Mathf.CeilToInt(((float)hero.Hitpoints + hero.Armor) / 2f);
					if (dmg.amount <= 0)
					{
						dmg.amount = 1;
					}
				}
			}
			else if (currentElement == ItemData.Element.Fire)
			{
				if (!flag)
				{
					int duration = 120 + 30 * level;
					ApplyDebuff(fireDebuff, hero, duration);
				}
				if (HasUnmakeAbility(hero.statModController) || HasUnmakeAbility(hero.LeftHand) || HasUnmakeAbility(hero.RightHand) || (hero.faerie != null && HasUnmakeAbility(hero.faerie.weapon)))
				{
					fireArmUnmade = true;
					Damage damage2 = new Damage();
					damage2.amount = Mathf.RoundToInt((float)base.MaxHitpoints * 0.02f);
					damage2.isCritical = true;
					damage2.Owner = hero;
					InflictDamage(damage2);
					fireArmIdleSprite.pivotX = 1000;
					fireArmCastSprite.pivotX = 1000;
					fireArmPerfSprite.pivotX = 1000;
					base.weapon.bulletPrefab = doNothingBulletPrefab;
					InstaKillOnHitStatMod.EmitParticlesFromSprite(fireUnmadeEmitter, fireArmCastSprite);
					SfxController.singleton.Play("insta_kill");
				}
			}
			else if (currentElement == ItemData.Element.Ice && !flag)
			{
				int duration2 = chillBaseDuration + 60 * level;
				ApplyDebuff(iceDebuff, hero, duration2);
			}
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		if (elementalistState < ElementalistState.TalkDefeated)
		{
			if (GameStates.Singleton.level.QuestData.level <= 4)
			{
				SetElementalistState(ElementalistState.TalkDefeated);
			}
			else
			{
				SetElementalistState(ElementalistState.EvolvingToPerfected);
			}
		}
	}

	public override void AddStatModifier(StatModifier modifier)
	{
		DebuffStatMod debuffStatMod = modifier as DebuffStatMod;
		if (immuneToDebuffsRemaining <= 0 || debuffStatMod == null || debuffStatMod.isPositiveBuff)
		{
			base.AddStatModifier(modifier);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (elementalistState != ElementalistState.TalkDefeated || elapsedElementalistTics % 4 <= 1)
		{
			base.Draw(r, offsetX, offsetY);
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (elementalistState == ElementalistState.TalkDefeated)
		{
			dialogBubble.SetNPCMouthPosition(idleSprite.lastDrawX + 2, idleSprite.lastDrawY);
			int offsetX2 = (r.width - dialogBubble.Width >> 1) - 9;
			int offsetY2 = base.lastDrawY - dialogBubble.Height / 2 - 8;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (whiteScreenPercent <= 0f || GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			r.RemovePostEffect(this);
			return;
		}
		Color b = ColorConstants.offWhite;
		if (!AdditionalSettings.isScreenFlash)
		{
			b = Color.black;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetForeground();
				cell.SetForeground(Color.Lerp(foreground, b, whiteScreenPercent));
				Color background = cell.GetBackground();
				cell.SetBackground(Color.Lerp(background, b, whiteScreenPercent));
			}
		}
	}

	private void Update()
	{
		if (elementalistState != ElementalistState.EvolvingWhiteFlash)
		{
			whiteScreenPercent -= Time.deltaTime * 0.5f;
		}
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 19;
		dialogBubble.PositionY = 8;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private DebuffStatMod ApplyDebuff(DebuffStatMod debuffPrefab, Character target, int duration)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = UnityEngine.Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = base.weapon;
			debuffStatMod.character = target;
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

	private void Evolve()
	{
		Character character = UnityEngine.Object.Instantiate(perfectedPrefab);
		character.PositionX = base.PositionX;
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ;
		GameStates.Singleton.level.AddCharacter(character);
		character.SetLevel(level);
		GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
		GameStates.Singleton.level.RemoveCharacter(this);
		UnityEngine.Object.Destroy(base.gameObject);
		CleanupSummerSolsticeCosmetics();
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

	private bool HasUnmakeAbility(Weapon w)
	{
		if (w != null)
		{
			return HasUnmakeAbility(w.statModController);
		}
		return false;
	}

	private bool HasMoondial()
	{
		return Inventory.Singleton.HasItemById("moon_stone");
	}

	private void SpawnSummerSolsticeCosmetics()
	{
		if (EventController.singleton.IsEventActiveAndStarted("summer") && HasMoondial())
		{
			sunDogInstance = SpawnSummerSolsticeDeco(sunDogPrefab);
			summerParticlesInstance = SpawnSummerSolsticeDeco(summerParticlesPrefab);
		}
	}

	private Decoration SpawnSummerSolsticeDeco(Decoration decorationPrefab)
	{
		Decoration decoration = UnityEngine.Object.Instantiate(decorationPrefab);
		decoration.PositionX = base.PositionX;
		decoration.PositionY = base.PositionY;
		decoration.PositionZ = base.PositionZ + 1;
		GameStates.Singleton.level.AddCharacter(decoration);
		return decoration;
	}

	private void CleanupSummerSolsticeCosmetics()
	{
		if (sunDogInstance != null)
		{
			sunDogInstance.Die(DeathReason.DecorationCleanup);
		}
		if (summerParticlesInstance != null)
		{
			summerParticlesInstance.Die(DeathReason.DecorationCleanup);
		}
	}

	public override void Init()
	{
		base.Init();
		idleSprite = idleAnm.Sprite;
		SetElementalistState(ElementalistState.WhiteFadeBack);
		GameStates.Singleton.SetGameTime(0);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	protected override void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			UnityEngine.Object.Destroy(dialogBubble.gameObject);
		}
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		base.OnDestroy();
	}

	public override int GetStateNumericRepresentation()
	{
		if (elementalistState == ElementalistState.Fighting)
		{
			return base.GetStateNumericRepresentation();
		}
		return (int)(100 + elementalistState);
	}

	public override int GetStateTimeRepresentation()
	{
		if (elementalistState == ElementalistState.Fighting)
		{
			return base.GetStateTimeRepresentation();
		}
		return elapsedElementalistTics;
	}
}
