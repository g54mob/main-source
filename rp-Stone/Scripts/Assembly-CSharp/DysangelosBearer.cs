using System;
using UnityEngine;

public class DysangelosBearer : Enemy, IPostAsciiRendererEffect
{
	[Serializable]
	public class AttackData
	{
		public AsciiSprite cast;

		public AsciiSprite perf;

		public Weapon weapon;
	}

	private enum BearerState
	{
		Waiting = 0,
		Approach = 1,
		PreEnterSmallPause = 2,
		DysangelosEnter = 3,
		PostEnterSmallPause = 4,
		TalkGreetings = 5,
		TalkNothingHappened = 6,
		RevealsIn = 7,
		TalkStonehead = 8,
		RevealsOut = 9,
		TalkTruePower = 10,
		TalkUnmakingYou = 11,
		TalkBelieveInLight = 12,
		TalkYourMemories = 13,
		TalkRealmOfDarkness = 14,
		Stealing = 15,
		WhiteFlash = 16,
		WhiteFadeBack = 17,
		PreFightPause = 18,
		Fighting = 19,
		TalkDefeated = 20,
		ExperienceDialog = 21,
		Completed = 22,
		TalkEvolving = 23,
		EvolvingToElementalist = 24,
		EvolvingWhiteFlash = 25,
		DevolvedTalking = 26,
		DevolvedStealing = 27
	}

	private const string DYSANGELOS_BEARER_INTRO = "dysangelos_bearer_intro";

	private const string DYSANGELOS_BEARER_UNMAKING_YOU = "dysangelos_bearer_unmaking_you";

	private const string DYSANGELOS_BEARER_RETURN_TO_STONE = "dysangelos_bearer_return_to_stone";

	private const string DYSANGELOS_BEARER_BELIEVE_IN_LIGHT = "dysangelos_bearer_believe_in_light";

	private int heroApproachOffsetX = -18;

	public AsciiAnimation dysangelosEnterAnm;

	public AsciiAnimation dysangelosIdleAnm;

	public AsciiAnimation dysangelosRevealingAnm;

	public AsciiAnimation dysangelosTossingStoneAnm;

	public AsciiAnimation dysangelosHidingAnm;

	public AsciiAnimation dysangelosStealingAnm;

	public AsciiAnimation bearerClosingMouthAnm;

	public AsciiAnimation defeatedTalkingAnm;

	public AsciiAnimation defeatedEvolvingAnm;

	public AsciiAnimation devolvedIdleAnm;

	public AsciiAnimation devolvedStealingAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public DysangelosElementalist elementalistPrefab;

	public Decoration sunDogPrefab;

	public Decoration summerParticlesPrefab;

	private Decoration sunDogInstance;

	private Decoration summerParticlesInstance;

	public AttackData[] attacks;

	private int attackIndex = -1;

	public int basicLoopsBeforeSuper = 1;

	public int superAttackDamageBase = 10;

	public int superAttackDamagePerLevel = 3;

	private int elapsedBearerTics;

	private int basicLoopCount;

	private int superAttackDamageCountdown = -1;

	private float whiteScreenPercent;

	private BearerState bearerState { get; set; }

	public override bool Alive
	{
		get
		{
			if (bearerState > BearerState.Fighting)
			{
				return false;
			}
			return base.Alive;
		}
	}

	private void SetBearerState(BearerState newState)
	{
		switch (newState)
		{
		case BearerState.Waiting:
			if (HasMoondial())
			{
				base.MySprite = devolvedIdleAnm.Sprite;
			}
			else
			{
				base.MySprite = dysangelosEnterAnm.Sprite;
			}
			break;
		case BearerState.Approach:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case BearerState.DysangelosEnter:
			dysangelosEnterAnm.Play();
			break;
		case BearerState.PostEnterSmallPause:
			base.MySprite = dysangelosIdleAnm.Sprite;
			dysangelosIdleAnm.Stop();
			dysangelosIdleAnm.Play();
			break;
		case BearerState.TalkGreetings:
			SetupDialog("Greetings {0}. I bear some important news.", HeroSettings.name);
			SfxController.singleton.Play("bearer3_talk");
			MusicController.singleton.Play("rocky_plateau_talk");
			break;
		case BearerState.TalkNothingHappened:
			SetupDialog("If you're wondering why nothing happened, it's because there are in fact ten Soul Stones. I carry with me the last one, you see, the [color=#00ffff]Moondial[/color].");
			SfxController.singleton.Play("bearer3_talk");
			break;
		case BearerState.RevealsIn:
			base.MySprite = dysangelosRevealingAnm.Sprite;
			dysangelosRevealingAnm.Play();
			break;
		case BearerState.TalkStonehead:
			base.MySprite = dysangelosTossingStoneAnm.Sprite;
			dysangelosTossingStoneAnm.Play();
			SetupDialog("When I first awoke you, I knew I had chosen the right stonehead for the job. Thank you for gathering all the Soul Stones for me.");
			SfxController.singleton.Play("bearer3_talk");
			break;
		case BearerState.RevealsOut:
			base.MySprite = dysangelosHidingAnm.Sprite;
			dysangelosHidingAnm.Play();
			break;
		case BearerState.TalkTruePower:
			base.MySprite = dysangelosIdleAnm.Sprite;
			SetupDialog("Now, let me show you their true power.");
			SfxController.singleton.Play("bearer3_talk");
			break;
		case BearerState.TalkUnmakingYou:
			SetupDialog("Unmaking you is the only way to release the Sight Stone. And I must have them all!");
			SfxController.singleton.Play("bearer4_talk");
			MusicController.singleton.Play("rocky_plateau_talk");
			break;
		case BearerState.TalkBelieveInLight:
			SetupDialog("Did you believe my tale of a world once full of Light?");
			SfxController.singleton.Play("bearer5_talk");
			MusicController.singleton.Play("rocky_plateau_talk");
			break;
		case BearerState.TalkYourMemories:
			SetupDialog("Those are your memories, revealed to me by the Sight Stone when I selected you atop the plateau. So intriguing.");
			SfxController.singleton.Play("bearer5_talk");
			break;
		case BearerState.TalkRealmOfDarkness:
			SetupDialog("Alas, this realm is of Darkness. It always was, and always will be. But, perhaps I can find this Light realm you seem to remember.");
			SfxController.singleton.Play("bearer5_talk");
			break;
		case BearerState.Stealing:
			base.MySprite = dysangelosStealingAnm.Sprite;
			dysangelosStealingAnm.Play();
			SfxController.singleton.Play("bearer_stealing", ignoreDuplicateSfxInSameFrame: true, 0.4f);
			break;
		case BearerState.WhiteFlash:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			MusicController.singleton.FadeToSilence(0.2f);
			GameStates.Singleton.SetGameTime(0);
			break;
		case BearerState.WhiteFadeBack:
			GameStates.Singleton.level.LoadBackground("RockyPlateau/Boss/bg_rocky_plateau_boss");
			GameStates.Singleton.level.LoadForeground("RockyPlateau/Boss/fg_rocky_plateau_boss");
			base.MySprite = bearerClosingMouthAnm.Sprite;
			bearerClosingMouthAnm.Play();
			SfxController.singleton.Play("bearer_scream", ignoreDuplicateSfxInSameFrame: true, 0.15f);
			BigHead.seeingBossTime = 2f;
			MusicController.singleton.Play("rocky_plateau_fight");
			SpawnSummerSolsticeCosmetics();
			break;
		case BearerState.PreFightPause:
			MoneyUI.singleton.hideTopHUD = true;
			GameStates.Singleton.hud.currentEnemy = this;
			GameStates.Singleton.hud.UpdateEnemyHitpoints();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			break;
		case BearerState.Fighting:
			GameStates.Singleton.hero.RestoreAI();
			WakeUp();
			break;
		case BearerState.TalkDefeated:
			SetupDefeated();
			SetupDialog("Impressive, but futile... The Star Stone will only make me stronger!");
			dialogBubble.PositionY++;
			SfxController.singleton.Play("bearer_death");
			MusicController.singleton.FadeToSilence();
			break;
		case BearerState.ExperienceDialog:
			GameStates.Singleton.level.XpEarned += 20;
			GameStates.Singleton.ScheduleXpDialog();
			break;
		case BearerState.Completed:
			GameStates.Singleton.CompleteQuest();
			break;
		case BearerState.TalkEvolving:
			SetupDefeated();
			SetupDialog("You will soon return to stone, and I will be unstoppable.");
			dialogBubble.PositionY++;
			SfxController.singleton.Play("bearer4_talk_evolving");
			OuroborosWeapon.healingBlocked = true;
			break;
		case BearerState.EvolvingToElementalist:
			SetupDefeated();
			base.MySprite = defeatedEvolvingAnm.Sprite;
			defeatedEvolvingAnm.Play();
			SfxController.singleton.Play("bearer_evolving", ignoreDuplicateSfxInSameFrame: true, 0.8f);
			OuroborosWeapon.healingBlocked = false;
			break;
		case BearerState.EvolvingWhiteFlash:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			break;
		case BearerState.DevolvedTalking:
			SetupDialog("Greetings {0}. Thank you for visiting. Looking for a challenge?", HeroSettings.name);
			dialogBubble.PositionY -= 8;
			SfxController.singleton.Play("devolved_talk");
			break;
		case BearerState.DevolvedStealing:
			base.MySprite = devolvedStealingAnm.Sprite;
			devolvedStealingAnm.Play();
			SfxController.singleton.Play("bearer_stealing", ignoreDuplicateSfxInSameFrame: true, 0.4f);
			break;
		}
		bearerState = newState;
		elapsedBearerTics = 0;
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
		base.MySprite = defeatedTalkingAnm.Sprite;
		defeatedTalkingAnm.Play();
	}

	protected override void SetState(State newState)
	{
		if (newState != State.WakingUp || (bearerState >= BearerState.WhiteFadeBack && bearerState < BearerState.TalkDefeated))
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
		elapsedBearerTics++;
		if (bearerState == BearerState.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX - 15)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.Approach && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.PreEnterSmallPause && elapsedBearerTics >= 20)
		{
			if (HasMoondial())
			{
				SetBearerState(BearerState.DevolvedTalking);
			}
			else
			{
				SetBearerState(BearerState.DysangelosEnter);
			}
		}
		else if (bearerState == BearerState.DysangelosEnter && !dysangelosEnterAnm.Playing)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.PostEnterSmallPause && elapsedBearerTics >= 20)
		{
			int num = GameStates.Singleton.level.QuestData.level;
			if (num == 3 && !ProgressFlags.GetFlag("dysangelos_bearer_intro"))
			{
				ProgressFlags.SetFlag("dysangelos_bearer_intro");
				SetBearerState(BearerState.TalkGreetings);
			}
			else if (num == 4 && !ProgressFlags.GetFlag("dysangelos_bearer_unmaking_you"))
			{
				ProgressFlags.SetFlag("dysangelos_bearer_unmaking_you");
				SetBearerState(BearerState.TalkUnmakingYou);
			}
			else if (num == 5 && !ProgressFlags.GetFlag("dysangelos_bearer_believe_in_light"))
			{
				ProgressFlags.SetFlag("dysangelos_bearer_believe_in_light");
				SetBearerState(BearerState.TalkBelieveInLight);
			}
			else
			{
				SetBearerState(BearerState.Stealing);
			}
		}
		else if (bearerState == BearerState.RevealsIn && !dysangelosRevealingAnm.Playing)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.RevealsOut && !dysangelosHidingAnm.Playing)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.Stealing && elapsedBearerTics >= 280)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.WhiteFlash && elapsedBearerTics >= 15)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.WhiteFadeBack && elapsedBearerTics >= 60)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.PreFightPause && elapsedBearerTics >= 30)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.Fighting)
		{
			UpdateFighting();
		}
		else if (bearerState == BearerState.TalkDefeated || bearerState == BearerState.TalkEvolving)
		{
			GameStates.Singleton.hud.currentEnemy = null;
		}
		else if (bearerState == BearerState.ExperienceDialog && elapsedBearerTics >= 5)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.EvolvingToElementalist && elapsedBearerTics >= 70)
		{
			SetBearerState(bearerState + 1);
		}
		else if (bearerState == BearerState.EvolvingWhiteFlash && elapsedBearerTics >= 15)
		{
			Evolve();
		}
		else if (bearerState == BearerState.DevolvedTalking)
		{
			if (elapsedBearerTics == 1 && GameStates.Singleton.level.QuestData.level >= 12)
			{
				dialogBubble.SkipToWaiting();
			}
			else if (elapsedBearerTics == 6 && GameStates.Singleton.level.QuestData.level >= 12)
			{
				dialogBubble.Hide();
			}
			else if (elapsedBearerTics >= 120)
			{
				dialogBubble.Hide();
			}
		}
		else if (bearerState == BearerState.DevolvedStealing && elapsedBearerTics >= 280)
		{
			SetBearerState(BearerState.WhiteFlash);
		}
		if (bearerState == BearerState.TalkGreetings || bearerState == BearerState.TalkNothingHappened || bearerState == BearerState.TalkStonehead || bearerState == BearerState.TalkTruePower || bearerState == BearerState.TalkUnmakingYou || bearerState == BearerState.TalkBelieveInLight || bearerState == BearerState.TalkYourMemories || bearerState == BearerState.TalkRealmOfDarkness || bearerState == BearerState.TalkDefeated || bearerState == BearerState.TalkEvolving || bearerState == BearerState.DevolvedTalking)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void Evolve()
	{
		Character character = UnityEngine.Object.Instantiate(elementalistPrefab);
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

	private void HandleDialogButtonDone()
	{
		if (bearerState == BearerState.TalkTruePower || bearerState == BearerState.TalkUnmakingYou || bearerState == BearerState.TalkRealmOfDarkness)
		{
			SetBearerState(BearerState.Stealing);
		}
		else
		{
			SetBearerState(bearerState + 1);
		}
	}

	private void NextAttack()
	{
		if (attackIndex >= attacks.Length - 1)
		{
			attackIndex = 0;
		}
		else if (attackIndex == attacks.Length - 2)
		{
			basicLoopCount++;
			if (basicLoopCount >= basicLoopsBeforeSuper)
			{
				basicLoopCount = 0;
				attackIndex++;
			}
			else
			{
				attackIndex = 0;
			}
		}
		else
		{
			attackIndex++;
		}
		AttackData attackData = attacks[attackIndex];
		attackCastSprite = attackData.cast;
		attackPerfSprite = attackData.perf;
		base.weapon = attackData.weapon;
		base.weapon.Owner = this;
		base.weapon.LoadAbilities();
	}

	private void UpdateFighting()
	{
		if (superAttackDamageCountdown > 0 && base.weapon.id == "super_attack")
		{
			superAttackDamageCountdown--;
			if (superAttackDamageCountdown <= 0)
			{
				DealSuperAttackDamage();
			}
		}
	}

	private void DealSuperAttackDamage()
	{
		int amount = superAttackDamageBase + superAttackDamagePerLevel * level;
		Damage damage = new Damage();
		damage.type = Damage.Type.Ranged;
		damage.amount = amount;
		damage.isCritical = true;
		damage.Owner = this;
		GameStates.Singleton.hero.InflictDamage(damage);
		superAttackDamageCountdown = -1;
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (superAttackDamageCountdown < 0 && dmg.Owner == this && base.weapon.id == "super_attack")
		{
			superAttackDamageCountdown = 25;
			dmg.amount = 0;
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		if (bearerState > BearerState.Fighting)
		{
			return;
		}
		int num = GameStates.Singleton.level.QuestData.level;
		if (bearerState != BearerState.TalkDefeated && num == 3)
		{
			SetBearerState(BearerState.TalkDefeated);
		}
		else if (bearerState != BearerState.TalkEvolving && num == 4)
		{
			if (!ProgressFlags.GetFlag("dysangelos_bearer_return_to_stone"))
			{
				ProgressFlags.SetFlag("dysangelos_bearer_return_to_stone");
				SetBearerState(BearerState.TalkEvolving);
			}
			else
			{
				SetBearerState(BearerState.EvolvingToElementalist);
			}
		}
		else if (bearerState != BearerState.EvolvingToElementalist && num >= 5)
		{
			SetBearerState(BearerState.EvolvingToElementalist);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (bearerState != BearerState.TalkDefeated || elapsedBearerTics % 4 <= 1)
		{
			base.Draw(r, offsetX, offsetY);
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (bearerState == BearerState.TalkGreetings || bearerState == BearerState.TalkNothingHappened || bearerState == BearerState.TalkStonehead || bearerState == BearerState.TalkTruePower || bearerState == BearerState.TalkUnmakingYou || bearerState == BearerState.TalkBelieveInLight || bearerState == BearerState.TalkYourMemories || bearerState == BearerState.TalkRealmOfDarkness || bearerState == BearerState.TalkDefeated || bearerState == BearerState.TalkEvolving || bearerState == BearerState.DevolvedTalking)
		{
			int screenX = dysangelosIdleAnm.Sprite.lastDrawX + 1;
			int screenY = dysangelosIdleAnm.Sprite.lastDrawY;
			if (bearerState == BearerState.DevolvedTalking)
			{
				screenX = devolvedIdleAnm.Sprite.lastDrawX + 2;
				screenY = devolvedIdleAnm.Sprite.lastDrawY + 2;
			}
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
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
		if (bearerState != BearerState.WhiteFlash && bearerState != BearerState.EvolvingWhiteFlash)
		{
			whiteScreenPercent -= Time.deltaTime * 0.5f;
		}
	}

	private void SetupDialog(string message)
	{
		_SetupDialog(Te.xt(message));
	}

	private void SetupDialog(string message, string param)
	{
		_SetupDialog(string.Format(Te.xt(message), param));
	}

	private void _SetupDialog(string message)
	{
		dialogBubble.PositionX = 19;
		dialogBubble.PositionY = 7;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private bool HasMoondial()
	{
		if (devolvedIdleAnm != null)
		{
			return Inventory.Singleton.HasItemById("moon_stone");
		}
		return false;
	}

	private void SpawnSummerSolsticeCosmetics()
	{
		if (EventController.singleton.IsEventActiveAndStarted("summer") && HasMoondial())
		{
			sunDogInstance = SpawnSummerSolsticeDeco(sunDogPrefab);
			summerParticlesInstance = SpawnSummerSolsticeDeco(summerParticlesPrefab);
			FullScreenSnow fullScreenSnow = UnityEngine.Object.FindObjectOfType<FullScreenSnow>();
			if ((bool)fullScreenSnow)
			{
				fullScreenSnow.pivotY = 9999;
			}
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
		SetBearerState(BearerState.Waiting);
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
		GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
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
		if (bearerState == BearerState.Fighting)
		{
			return base.GetStateNumericRepresentation();
		}
		return (int)(100 + bearerState);
	}

	public override int GetStateTimeRepresentation()
	{
		if (bearerState == BearerState.Fighting)
		{
			return base.GetStateTimeRepresentation();
		}
		return elapsedBearerTics;
	}
}
