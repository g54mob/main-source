using UnityEngine;

public class AcronianScout : Enemy
{
	public enum ScoutState
	{
		Waiting = 0,
		Intro1 = 1,
		Intro2 = 2,
		Intro3 = 3,
		Attacking = 4,
		Outro1 = 5,
		Outro2 = 6,
		Outro3 = 7,
		FlyingAway = 8,
		Done = 9
	}

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public int bubbleOffsetX = -12;

	public int bubbleOffsetY = 3;

	public bool showDialog = true;

	public Weapon superAttackWeapon;

	public AsciiSprite superAttackCast;

	public AsciiAnimation superAttackFocusVFX;

	public AsciiSprite superAttackParticlesVFX;

	public int attacksUntilSuperAttack = 5;

	public int focusVfxDelay = 60;

	public int pushDelay = 10;

	public int pushDistance = 9;

	private ScoutState currentScoutState;

	private int elapsedScoutTics;

	private int startingX;

	private int attackCount;

	private Weapon defaultWeapon;

	private AsciiSprite defaultAttackCast;

	private void SetScoutState(ScoutState newState)
	{
		switch (newState)
		{
		case ScoutState.Intro1:
			StopHeroAI();
			base.MySprite = idleSprite;
			SetupDialog(Te.xt("tid_scout_dialog_0"));
			SfxController.singleton.Play("scout_dialog");
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case ScoutState.Intro2:
			SetupDialog(Te.xt("tid_scout_dialog_1"));
			SfxController.singleton.Play("scout_dialog");
			break;
		case ScoutState.Intro3:
			SetupDialog(Te.xt("tid_scout_dialog_2"));
			SfxController.singleton.Play("scout_dialog");
			break;
		case ScoutState.Attacking:
			RestoreHeroAI();
			base.MySprite = walkSprite;
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			break;
		case ScoutState.Outro1:
			base.Hitpoints = 1;
			Cleanse();
			GameStates.Singleton.hero.SetMoveDestination(startingX - 24, base.PositionZ);
			GameStates.Singleton.hero.StopAttacking();
			base.weapon.SetState(Weapon.State.Waiting);
			SetState(State.Engaging);
			SetupDialog(Te.xt("tid_scout_dialog_3"));
			SfxController.singleton.Play("scout_dialog");
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case ScoutState.Outro2:
			SetupDialog(Te.xt("tid_scout_dialog_4"));
			SfxController.singleton.Play("scout_dialog");
			break;
		case ScoutState.Outro3:
			SetupDialog(string.Format(Te.xt("tid_scout_dialog_5"), HeroSettings.name));
			SfxController.singleton.Play("scout_dialog");
			break;
		case ScoutState.FlyingAway:
			Cleanse();
			base.weapon.SetState(Weapon.State.Waiting);
			SetState(State.Sleeping);
			base.MySprite = deathSprite;
			deathSprite.GetComponent<AsciiAnimation>().Play();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			break;
		case ScoutState.Done:
			RestoreHeroAI();
			deathDurationTics = 0;
			Die(DeathReason.Custom);
			break;
		}
		currentScoutState = newState;
		elapsedScoutTics = 0;
	}

	public override void UpdateTic()
	{
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			return;
		}
		elapsedScoutTics++;
		if (IsDialogState())
		{
			dialogBubble.UpdateTic();
			if (!IsDialogState())
			{
				return;
			}
			if (base.PositionX != startingX)
			{
				base.MySprite = walkSprite;
				if (elapsedScoutTics % 3 == 0)
				{
					if (base.PositionX > startingX)
					{
						base.PositionX--;
					}
					else
					{
						base.PositionX++;
					}
				}
			}
			else
			{
				base.MySprite = idleSprite;
			}
			return;
		}
		if (currentScoutState == ScoutState.FlyingAway)
		{
			if (elapsedScoutTics >= 36)
			{
				SetScoutState(ScoutState.Done);
			}
			return;
		}
		base.UpdateTic();
		if (!(base.weapon == superAttackWeapon))
		{
			return;
		}
		if (base.stateElapsedTics == focusVfxDelay)
		{
			superAttackFocusVFX.Play();
			SfxController.singleton.Play("scout_focus");
		}
		if (base.stateElapsedTics > pushDelay && base.stateElapsedTics % 2 == 0)
		{
			int num = base.PositionX - pushDistance;
			Hero hero = GameStates.Singleton.hero;
			if (hero.PositionX > num)
			{
				hero.PositionX--;
			}
		}
	}

	private bool IsDialogState()
	{
		if (currentScoutState != ScoutState.Intro1 && currentScoutState != ScoutState.Intro2 && currentScoutState != ScoutState.Intro3 && currentScoutState != ScoutState.Outro1 && currentScoutState != ScoutState.Outro2)
		{
			return currentScoutState == ScoutState.Outro3;
		}
		return true;
	}

	protected override void SetState(State newState)
	{
		if (base.CurrentState == State.Sleeping && newState == State.WakingUp)
		{
			if (showDialog)
			{
				SfxController.singleton.Play("prompt_choice", ignoreDuplicateSfxInSameFrame: true, 0.4f);
			}
			else
			{
				SfxController.singleton.Play("scout_arrives");
			}
		}
		bool flag = false;
		if (showDialog && base.CurrentState == State.WakingUp && currentScoutState == ScoutState.Waiting)
		{
			flag = true;
		}
		else if (superAttackWeapon != null && newState == State.Engaging)
		{
			if (attackCount == attacksUntilSuperAttack && base.weapon != superAttackWeapon)
			{
				SetupSuperAttackWeapon();
			}
			else if (attackCount > attacksUntilSuperAttack && base.weapon == superAttackWeapon)
			{
				SetupDefaultWeapon();
			}
		}
		base.SetState(newState);
		if (flag)
		{
			SetScoutState(ScoutState.Intro1);
		}
	}

	private void SetupSuperAttackWeapon()
	{
		defaultWeapon = base.weapon;
		defaultAttackCast = attackCastSprite;
		attackCastSprite = superAttackCast;
		base.weapon = superAttackWeapon;
		base.weapon.Owner = this;
		base.weapon.LoadAbilities();
	}

	private void SetupDefaultWeapon()
	{
		attackCastSprite = defaultAttackCast;
		base.weapon = defaultWeapon;
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		if (!showDialog || currentScoutState == ScoutState.FlyingAway || currentScoutState == ScoutState.Done)
		{
			base.Die(reason, dmg);
		}
		else if (currentScoutState == ScoutState.Attacking)
		{
			Cleanse();
			SetScoutState(ScoutState.Outro1);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentScoutState != ScoutState.Waiting && currentScoutState != ScoutState.Done)
		{
			int screenX = base.MySprite.lastDrawX + base.MySprite.pivotX + mouthOffsetX;
			int screenY = base.MySprite.lastDrawY + base.MySprite.pivotY + mouthOffsetY;
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
			screenX = base.MySprite.lastDrawX + base.MySprite.pivotX + bubbleOffsetX;
			screenY = base.MySprite.lastDrawY + base.MySprite.pivotY + bubbleOffsetY;
			dialogBubble.Draw(r, screenX, screenY);
		}
		if (superAttackFocusVFX != null && superAttackFocusVFX.Playing)
		{
			superAttackFocusVFX.Sprite.Draw(r, offsetX, offsetY);
		}
		if (superAttackParticlesVFX != null && base.weapon == superAttackWeapon && base.CurrentState == State.Attacking && base.weapon.CurrentState == Weapon.State.Casting)
		{
			superAttackParticlesVFX.Draw(r, offsetX, offsetY);
		}
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void HandleDialogDone()
	{
		SetScoutState(currentScoutState + 1);
	}

	private void StopHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
		GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
	}

	private void RestoreHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
	}

	private void HandleCharacterAttackEnded(Character c, Character target, Weapon w)
	{
		if (c == this)
		{
			attackCount++;
		}
	}

	public override void Init()
	{
		base.Init();
		startingX = base.PositionX;
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogDone;
		Character.OnCharacterAttackEnded += HandleCharacterAttackEnded;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogDone;
			Object.Destroy(dialogBubble.gameObject);
		}
		Character.OnCharacterAttackEnded -= HandleCharacterAttackEnded;
	}
}
