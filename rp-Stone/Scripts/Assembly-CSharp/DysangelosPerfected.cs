using System;
using System.Collections.Generic;
using UnityEngine;

public class DysangelosPerfected : Enemy, IPostAsciiRendererEffect
{
	[Serializable]
	public class AttackData
	{
		public AsciiSprite cast;

		public AsciiSprite perf;

		public Weapon weapon;
	}

	private enum PerfectedState
	{
		Waiting = 0,
		WhiteFadeBack = 1,
		TalkIAmPerfect = 2,
		TalkAcropolisWillKneel = 3,
		PreFightPause = 4,
		Fighting = 5,
		ArmedOut = 6,
		Unarmed = 7,
		ArmedIn = 8,
		PreSuperAttackPause = 9,
		SuperAttackIn = 10,
		SuperAttackLoopA = 11,
		SuperAttackLoopB = 12,
		SuperAttackLoopC = 13,
		SuperAttackOut = 14,
		PostSuperAttackPause = 15,
		Defeated = 16,
		ExperienceDialog = 17,
		Completed = 18
	}

	private const string DYSANGELOS_PERFECTED_INTRO = "dysangelos_perfected_intro";

	private int heroApproachOffsetX = -18;

	public int defenseArmorBase = 500;

	public int defenseArmorPerLevel = 100;

	public int unarmedLoopCount = 4;

	public int superAttackDurationA = 90;

	public int superAttackDurationB = 84;

	public int superAttackDurationC = 45;

	public DebuffStatMod adaptiveAEtherBuff;

	public DebuffStatMod adaptiveFireBuff;

	public DebuffStatMod adaptiveIceBuff;

	public DebuffStatMod adaptivePoisonBuff;

	public DebuffStatMod adaptiveVigorBuff;

	public AsciiAnimation idleArmedAnm;

	public AsciiAnimation idleUnarmedAnm;

	public AsciiAnimation armedInAnm;

	public AsciiAnimation armedOutAnm;

	public AsciiAnimation superAttackIn;

	public AsciiAnimation superAttackLoop;

	public AsciiAnimation superAttackOut;

	public AsciiAnimation superAttackSummon;

	public AsciiAnimation defeatedTalking;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public DysangelosSuperEnergyBall energyBallPrefab;

	public DysangelosEpilogue epiloguePrefab;

	public DysangelosDevolvedReturning devolvedPrefab;

	public Decoration sunDogPrefab;

	public Decoration summerParticlesPrefab;

	private Decoration sunDogInstance;

	private Decoration summerParticlesInstance;

	public AttackData[] attacks;

	private int attackIndex = -1;

	public Action<DysangelosPerfected> OnDefeated;

	private int elapsedPerfectedTics;

	private bool superAttackPending;

	private Sfx unarmedLoopSfx;

	private float whiteScreenPercent;

	private int[] elementalDamageTaken = new int[7];

	private ItemData.Element lastAdaptiveDefenseType;

	private PerfectedState perfectedState { get; set; }

	private void SetPerfectedState(PerfectedState newState)
	{
		StopUnarmedLoopSfx();
		switch (newState)
		{
		case PerfectedState.WhiteFadeBack:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			base.MySprite = idleArmedAnm.Sprite;
			idleArmedAnm.Play();
			BigHead.seeingBossTime = 2f;
			MusicController.singleton.Play("rocky_plateau_fight");
			SpawnSummerSolsticeCosmetics();
			break;
		case PerfectedState.TalkIAmPerfect:
			SetupDialog(Te.xt("Ahh, yes. Now, I am perfect."));
			SfxController.singleton.Play("perfected_talk");
			OuroborosWeapon.healingBlocked = true;
			break;
		case PerfectedState.TalkAcropolisWillKneel:
			SetupDialog(Te.xt("Acropolis will kneel to my rule. A formidable capital for my dominion."));
			SfxController.singleton.Play("perfected_talk");
			break;
		case PerfectedState.PreFightPause:
			MoneyUI.singleton.hideTopHUD = true;
			GameStates.Singleton.hud.currentEnemy = this;
			GameStates.Singleton.hud.UpdateEnemyHitpoints();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			OuroborosWeapon.healingBlocked = false;
			break;
		case PerfectedState.Fighting:
			GameStates.Singleton.hero.RestoreAI();
			WakeUp();
			break;
		case PerfectedState.ArmedOut:
			base.SetState(State.Sleeping);
			base.MySprite = armedOutAnm.Sprite;
			armedOutAnm.Play();
			SfxController.singleton.Play("perfected_fly_start");
			break;
		case PerfectedState.Unarmed:
			base.MySprite = idleUnarmedAnm.Sprite;
			idleUnarmedAnm.Stop();
			idleUnarmedAnm.Play();
			unarmedLoopSfx = SfxController.singleton.Play("perfected_fly_loop");
			break;
		case PerfectedState.ArmedIn:
			base.MySprite = armedInAnm.Sprite;
			armedInAnm.Play();
			SfxController.singleton.Play("perfected_fly_end");
			break;
		case PerfectedState.PreSuperAttackPause:
			base.SetState(State.Sleeping);
			break;
		case PerfectedState.SuperAttackIn:
			base.MySprite = superAttackIn.Sprite;
			superAttackIn.Play();
			SfxController.singleton.Play("perfected_summon", ignoreDuplicateSfxInSameFrame: true, 0.2f);
			break;
		case PerfectedState.SuperAttackLoopA:
			base.MySprite = superAttackLoop.Sprite;
			superAttackLoop.Stop();
			superAttackLoop.Play();
			break;
		case PerfectedState.SuperAttackLoopB:
			superAttackSummon.Play();
			break;
		case PerfectedState.SuperAttackLoopC:
			SummonEnergyBall();
			break;
		case PerfectedState.SuperAttackOut:
			base.MySprite = superAttackOut.Sprite;
			superAttackOut.Play();
			break;
		case PerfectedState.PostSuperAttackPause:
			base.MySprite = idleSprite;
			break;
		case PerfectedState.Defeated:
			SetupDefeated();
			base.MySprite = deathSprite;
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = -1f;
			SfxController.singleton.Play("perfected_death");
			MusicController.singleton.FadeToSilence();
			if (OnDefeated != null)
			{
				OnDefeated(this);
			}
			break;
		}
		perfectedState = newState;
		elapsedPerfectedTics = 0;
	}

	private void SetupDefeated()
	{
		GameStates.Singleton.hero.frozenTics = 115;
		GameStates.Singleton.hero.walkingAnimation.Pause();
		GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		GameStates.Singleton.hud.currentEnemy = null;
		Cleanse();
		base.weapon.SetState(Weapon.State.Waiting);
		base.SetState(State.Sleeping);
	}

	private void StopUnarmedLoopSfx()
	{
		if (unarmedLoopSfx != null)
		{
			unarmedLoopSfx.Stop();
			unarmedLoopSfx = null;
		}
	}

	protected override void SetState(State newState)
	{
		if (newState == State.WakingUp && (perfectedState <= PerfectedState.TalkAcropolisWillKneel || perfectedState == PerfectedState.ArmedOut || perfectedState == PerfectedState.Unarmed || perfectedState == PerfectedState.ArmedIn || perfectedState == PerfectedState.PreSuperAttackPause || perfectedState == PerfectedState.SuperAttackIn || perfectedState == PerfectedState.SuperAttackLoopA || perfectedState == PerfectedState.SuperAttackLoopB || perfectedState == PerfectedState.SuperAttackLoopC || perfectedState == PerfectedState.SuperAttackOut || perfectedState == PerfectedState.PostSuperAttackPause || perfectedState >= PerfectedState.Defeated))
		{
			return;
		}
		if (newState == State.Attacking)
		{
			NextAttack();
		}
		else
		{
			if (newState == State.Engaging && superAttackPending && attackIndex == 1)
			{
				superAttackPending = false;
				attackIndex = -1;
				SetPerfectedState(PerfectedState.PreSuperAttackPause);
				return;
			}
			if (newState == State.Engaging && attackIndex == 2)
			{
				superAttackPending = true;
				attackIndex = -1;
				SetPerfectedState(PerfectedState.ArmedOut);
				return;
			}
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedPerfectedTics++;
		if (perfectedState == PerfectedState.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			SetPerfectedState(PerfectedState.WhiteFadeBack);
		}
		else if (perfectedState == PerfectedState.WhiteFadeBack)
		{
			if (elapsedPerfectedTics >= 60)
			{
				if (!ProgressFlags.GetFlag("dysangelos_perfected_intro"))
				{
					ProgressFlags.SetFlag("dysangelos_perfected_intro");
					SetPerfectedState(PerfectedState.TalkIAmPerfect);
				}
				else
				{
					SetPerfectedState(PerfectedState.PreFightPause);
				}
			}
		}
		else if (perfectedState == PerfectedState.PreFightPause && elapsedPerfectedTics >= 30)
		{
			SetPerfectedState(perfectedState + 1);
		}
		else if (perfectedState != PerfectedState.Fighting)
		{
			if (perfectedState == PerfectedState.ArmedOut && elapsedPerfectedTics >= 9)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.Unarmed && elapsedPerfectedTics >= 75 * unarmedLoopCount)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.ArmedIn && elapsedPerfectedTics >= 14)
			{
				SetPerfectedState(PerfectedState.Fighting);
			}
			else if (perfectedState == PerfectedState.PreSuperAttackPause && elapsedPerfectedTics >= 60)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.SuperAttackIn && elapsedPerfectedTics >= 15)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.SuperAttackLoopA && elapsedPerfectedTics >= superAttackDurationA)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.SuperAttackLoopB && elapsedPerfectedTics >= superAttackDurationB)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.SuperAttackLoopC && elapsedPerfectedTics >= superAttackDurationC)
			{
				SetPerfectedState(perfectedState + 1);
			}
			else if (perfectedState == PerfectedState.SuperAttackOut && elapsedPerfectedTics >= 15)
			{
				SetPerfectedState(PerfectedState.PostSuperAttackPause);
			}
			else if (perfectedState == PerfectedState.PostSuperAttackPause && elapsedPerfectedTics >= 90)
			{
				SetPerfectedState(PerfectedState.Fighting);
			}
			else if (perfectedState == PerfectedState.Defeated)
			{
				GameStates.Singleton.hud.currentEnemy = null;
				if (elapsedPerfectedTics == 112)
				{
					AchievementController.singleton.ReportDysangelosDefeated(this);
				}
				else if (elapsedPerfectedTics == 135)
				{
					GameStates.Singleton.hero.walkingAnimation.Play();
					Devolve();
				}
				else if (elapsedPerfectedTics % 5 == 4 && elapsedPerfectedTics < 110)
				{
					CameraShake.singleton.ShakeCamera(2f, 0.2f);
				}
			}
			else if (perfectedState == PerfectedState.ExperienceDialog && elapsedPerfectedTics >= 5)
			{
				SetPerfectedState(perfectedState + 1);
			}
		}
		if (perfectedState == PerfectedState.TalkIAmPerfect || perfectedState == PerfectedState.TalkAcropolisWillKneel)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void Devolve()
	{
		GameStates.Singleton.level.LoadBackground("RockyPlateau/bg_rocky_plateau_3");
		GameStates.Singleton.level.LoadForeground("RockyPlateau/fg_rocky_plateau_3");
		Character character;
		if (HasMoondial())
		{
			character = UnityEngine.Object.Instantiate(devolvedPrefab);
			character.SetLevel(level);
		}
		else
		{
			character = UnityEngine.Object.Instantiate(epiloguePrefab);
		}
		character.PositionX = base.PositionX;
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ;
		GameStates.Singleton.level.AddCharacter(character);
		if (!QuestController.singleton.IsAvailableWorkstation("mutate"))
		{
			QuestController.singleton.MakeAvailable("make_bowl");
			QuestController.singleton.MakeAvailable("mutate");
		}
		GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
		GameStates.Singleton.level.RemoveCharacter(this);
		UnityEngine.Object.Destroy(base.gameObject);
		CleanupSummerSolsticeCosmetics();
	}

	private void HandleDialogButtonDone()
	{
		SetPerfectedState(perfectedState + 1);
	}

	private void NextAttack()
	{
		attackIndex = (attackIndex + 1) % attacks.Length;
		AttackData attackData = attacks[attackIndex];
		attackCastSprite = attackData.cast;
		attackPerfSprite = attackData.perf;
		base.weapon = attackData.weapon;
		base.weapon.Owner = this;
		base.weapon.LoadAbilities();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (perfectedState < PerfectedState.Defeated || elapsedPerfectedTics % 4 <= 1)
		{
			base.Draw(r, offsetX, offsetY);
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (perfectedState == PerfectedState.SuperAttackLoopB)
		{
			superAttackSummon.Sprite.Draw(r, offsetX, offsetY);
		}
		if (perfectedState == PerfectedState.TalkIAmPerfect || perfectedState == PerfectedState.TalkAcropolisWillKneel)
		{
			dialogBubble.SetNPCMouthPosition(idleSprite.lastDrawX + 16, idleSprite.lastDrawY);
			int offsetX2 = (r.width - dialogBubble.Width >> 1) - 9;
			int offsetY2 = base.lastDrawY - dialogBubble.Height / 2 - 7;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if ((perfectedState != PerfectedState.Defeated && whiteScreenPercent <= 0f) || GameStates.Singleton.CurrentState < GameStates.State.Playing)
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
		if (perfectedState == PerfectedState.Defeated)
		{
			whiteScreenPercent += Time.deltaTime * 0.5f;
		}
		else
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

	private void HandleDefenseWeaponStateChange(Weapon weapon, Weapon.State newState, Weapon.State currentState)
	{
		if (newState == Weapon.State.Performing && Alive)
		{
			float num = defenseArmorBase + defenseArmorPerLevel * level;
			num -= HeavyHammerActivatedAbility.CalculateArmorLostToFatigue(this, num);
			base.Armor += num;
			base.MaxArmor = num;
			Character.FireOnArmorGained(this, num);
			AddElementalDefenseBuff();
		}
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (!(c != this) && dmg.isCritical && perfectedState >= PerfectedState.SuperAttackLoopA && perfectedState <= PerfectedState.SuperAttackLoopC)
		{
			dmg.amount = Mathf.RoundToInt((float)dmg.amount * 1.5f);
			dmg.criticalMultiplier *= 1.5f;
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == this)
		{
			AddDamageForElementalDefenseCalculation(dmg);
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		if (perfectedState != PerfectedState.Defeated)
		{
			SetPerfectedState(PerfectedState.Defeated);
		}
	}

	private void SummonEnergyBall()
	{
		DysangelosSuperEnergyBall dysangelosSuperEnergyBall = UnityEngine.Object.Instantiate(energyBallPrefab);
		dysangelosSuperEnergyBall.SetLevel(level);
		dysangelosSuperEnergyBall.PositionX = base.PositionX + 10;
		dysangelosSuperEnergyBall.PositionY = base.PositionY;
		dysangelosSuperEnergyBall.PositionZ = base.PositionZ + 1;
		dysangelosSuperEnergyBall.SetDysangelos(this);
		GameStates.Singleton.level.AddCharacter(dysangelosSuperEnergyBall);
	}

	private void AddDamageForElementalDefenseCalculation(Damage dmg)
	{
		if (dmg.amount > 0 && dmg.bullet != null && dmg.bullet.weapon != null)
		{
			ItemData.Element element = dmg.bullet.weapon.element;
			elementalDamageTaken[(int)element] += dmg.amount;
		}
	}

	private void AddElementalDefenseBuff()
	{
		ItemData.Element element = ItemData.Element.Stone;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < elementalDamageTaken.Length; i++)
		{
			int num3 = elementalDamageTaken[i];
			elementalDamageTaken[i] = 0;
			if (num3 > num)
			{
				num2 = num;
				num = num3;
				element = (ItemData.Element)i;
			}
			else if (num3 > num2)
			{
				num2 = num3;
			}
		}
		if (element == ItemData.Element.Stone || num <= num2)
		{
			return;
		}
		string inStr = ItemData.NameForElement(element);
		string message = "[" + Te.xt(inStr) + "]";
		FloatingText floatingText = ShowFloatingText(message, 15);
		if (floatingText != null)
		{
			floatingText.Message.color = ColorConstants.green;
			floatingText.PositionX += 2;
			floatingText.PositionY += 3;
			floatingText.fadeOutDuration = 1.5f;
		}
		if (lastAdaptiveDefenseType != element && lastAdaptiveDefenseType != ItemData.Element.Stone && base.statModController != null && base.statModController.debuffs != null)
		{
			for (int j = 0; j < base.statModController.debuffs.Count; j++)
			{
				List<StatModifier> list = base.statModController.debuffs[j];
				if (list.Count > 0 && list[0] is AdaptiveDefenseStatMod)
				{
					for (int num4 = list.Count - 1; num4 >= 0; num4--)
					{
						list[num4].End();
					}
				}
			}
		}
		lastAdaptiveDefenseType = element;
		DebuffStatMod debuffStatMod = adaptiveIceBuff;
		switch (element)
		{
		case ItemData.Element.Poison:
			debuffStatMod = adaptivePoisonBuff;
			break;
		case ItemData.Element.Vigor:
			debuffStatMod = adaptiveVigorBuff;
			break;
		case ItemData.Element.AEther:
			debuffStatMod = adaptiveAEtherBuff;
			break;
		case ItemData.Element.Fire:
			debuffStatMod = adaptiveFireBuff;
			break;
		}
		DebuffStatMod debuffStatMod2 = UnityEngine.Object.Instantiate(debuffStatMod);
		if (debuffStatMod2 != null)
		{
			debuffStatMod2.sourceItem = base.weapon;
			debuffStatMod2.character = this;
			debuffStatMod2.Init();
			AddStatModifier(debuffStatMod2);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffStatMod?.ToString() + " for " + this);
		}
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
		decoration.PositionX = base.PositionX + 1;
		decoration.PositionY = base.PositionY - 2;
		decoration.PositionZ = base.PositionZ - 1;
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
		idleSprite = idleArmedAnm.Sprite;
		SetPerfectedState(PerfectedState.WhiteFadeBack);
		GameStates.Singleton.SetGameTime(0);
		SfxController.singleton.Preload("perfected_fly_loop");
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
		Weapon obj = attacks[2].weapon;
		obj.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Combine(obj.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleDefenseWeaponStateChange));
	}

	protected override void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			UnityEngine.Object.Destroy(dialogBubble.gameObject);
		}
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		if (attacks[2].weapon != null)
		{
			Weapon obj = attacks[2].weapon;
			obj.OnStateChange = (Action<Weapon, Weapon.State, Weapon.State>)Delegate.Remove(obj.OnStateChange, new Action<Weapon, Weapon.State, Weapon.State>(HandleDefenseWeaponStateChange));
		}
		base.OnDestroy();
	}

	public override int GetStateNumericRepresentation()
	{
		if (perfectedState == PerfectedState.Fighting)
		{
			return base.GetStateNumericRepresentation();
		}
		return (int)(100 + perfectedState);
	}

	public override int GetStateTimeRepresentation()
	{
		if (perfectedState == PerfectedState.Fighting)
		{
			return base.GetStateTimeRepresentation();
		}
		return elapsedPerfectedTics;
	}
}
