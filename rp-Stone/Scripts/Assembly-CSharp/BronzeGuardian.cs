using System;
using UnityEngine;

public class BronzeGuardian : Enemy, IPostAsciiRendererEffect
{
	[Serializable]
	public class HammerData
	{
		public AsciiSprite idle;

		public AsciiSprite cast;

		public AsciiSprite perf;

		public AsciiSprite death;

		public AsciiSprite powerUp;

		public Weapon weapon;
	}

	private enum GuardianState
	{
		Asleep = 0,
		PreWakeupDelay = 1,
		Idle = 2,
		Attacking = 3,
		KnockUp = 4,
		Stuck = 5,
		Recovering = 6,
		PrePowerUpDelay = 7,
		PoweringUp = 8,
		Boom = 9,
		GameOver = 10,
		Dead = 11
	}

	public int idleHeroDistance = 20;

	public int stuckHeroDistance = 3;

	public int deadHeroDistance = 16;

	private int stuckDuration = 175;

	public HammerData[] hammerPowers;

	public int maxHammerPower;

	public AsciiAnimation powerUpEyeFlash;

	private int elapsedGuardianTics;

	private int recoverHeroStartX;

	private int recoverHeroStartY;

	private int currentHammerPower;

	private EnemyHelmet myHelmet;

	private AsciiRenderProcedural lastRenderer;

	private Sfx fuseSfx;

	private GuardianState guardianState { get; set; }

	private void SetGuardianState(GuardianState newState)
	{
		switch (newState)
		{
		case GuardianState.Stuck:
			GameStates.Singleton.level.heroLimitX = base.PositionX - stuckHeroDistance;
			break;
		case GuardianState.Dead:
			GameStates.Singleton.level.heroLimitX = base.PositionX - deadHeroDistance;
			break;
		default:
			GameStates.Singleton.level.heroLimitX = base.PositionX - idleHeroDistance;
			break;
		}
		if (newState == GuardianState.Idle && GameStates.Singleton.hero.PositionX > GameStates.Singleton.level.heroLimitX)
		{
			GameStates.Singleton.hero.PositionX = GameStates.Singleton.level.heroLimitX;
		}
		else
		{
			switch (newState)
			{
			case GuardianState.Recovering:
				recoverHeroStartX = GameStates.Singleton.hero.PositionX;
				recoverHeroStartY = GameStates.Singleton.hero.PositionY;
				break;
			case GuardianState.PoweringUp:
			{
				base.MySprite = hammerPowers[currentHammerPower].powerUp;
				AsciiAnimation component = base.MySprite.GetComponent<AsciiAnimation>();
				component.Stop();
				component.Play();
				powerUpEyeFlash.Stop();
				powerUpEyeFlash.Play();
				SfxController.singleton.Play("bronze_guardian_power_up");
				break;
			}
			case GuardianState.Boom:
				GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
				GameStates.Singleton.hero.PositionX -= 40;
				GameStates.Singleton.hero.PositionY = 100;
				GameStates.Singleton.hero.PauseAI(5f);
				GameStates.Singleton.hero.SetState(Hero.State.Idle);
				CameraShake.singleton.ShakeCamera(30f, 0.3f);
				AmbianceController.singleton.StopAllAmbient(0.07f);
				MusicController.singleton.FadeToSilence(0.07f);
				SfxController.singleton.StopAllSfx();
				SfxController.singleton.Play("bronze_guardian_ears_ring");
				GameStates.Singleton.hero.frozenTics = 90;
				SfxController.singleton.muteDuration = 3f;
				break;
			case GuardianState.GameOver:
				GameStates.Singleton.TransitionToState(GameStates.State.QuestScreen, TransitionManager.Type.WhiteToBlack);
				if (lastRenderer != null)
				{
					lastRenderer.RemovePostEffect(this);
				}
				break;
			case GuardianState.Dead:
				if (fuseSfx != null)
				{
					fuseSfx.Stop();
				}
				break;
			}
		}
		guardianState = newState;
		elapsedGuardianTics = 0;
	}

	protected override void SetState(State newState)
	{
		if (newState == State.WakingUp && guardianState < GuardianState.Idle)
		{
			if (guardianState == GuardianState.Asleep)
			{
				SetGuardianState(GuardianState.PreWakeupDelay);
			}
			return;
		}
		if (base.CurrentState == State.WakingUp)
		{
			CameraShake.singleton.ShakeCamera(3f, 0.2f);
			if (newState == State.Engaging)
			{
				SfxController.singleton.Play("bronze_guardian_steps");
			}
			base.weapon.SetState(Weapon.State.Cooldown);
		}
		else if (newState == State.Attacking)
		{
			SetGuardianState(GuardianState.Attacking);
		}
		else if (newState == State.Dying && guardianState != GuardianState.Recovering && GameStates.Singleton.hero.PositionY != 0)
		{
			SetGuardianState(GuardianState.Recovering);
		}
		else if (newState == State.Dying && guardianState != GuardianState.Recovering)
		{
			SetGuardianState(GuardianState.Dead);
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedGuardianTics++;
		if (guardianState == GuardianState.PreWakeupDelay && elapsedGuardianTics >= 30)
		{
			SetGuardianState(GuardianState.Idle);
		}
		else if (guardianState == GuardianState.Attacking && base.weapon.CurrentState == Weapon.State.Performing)
		{
			SetGuardianState(GuardianState.KnockUp);
		}
		else if (guardianState == GuardianState.KnockUp)
		{
			int num = 10;
			float num2 = (float)elapsedGuardianTics / (float)num;
			float a = 0f;
			float b = 3f;
			Hero hero = GameStates.Singleton.hero;
			float num3 = 6f * (1f - Mathf.Pow(2f * num2 - 1f, 2f));
			hero.PositionY = Mathf.RoundToInt(Mathf.Lerp(a, b, num2) + num3);
			if (elapsedGuardianTics >= num)
			{
				SetGuardianState(GuardianState.Stuck);
			}
		}
		else if (guardianState == GuardianState.Stuck)
		{
			if (elapsedGuardianTics >= stuckDuration)
			{
				SetGuardianState(GuardianState.Recovering);
				return;
			}
			Hero hero2 = GameStates.Singleton.hero;
			int num4 = base.PositionX - hero2.PositionX;
			if (num4 >= 18)
			{
				hero2.PositionY = 3;
			}
			else if (num4 >= 14)
			{
				hero2.PositionY = 1;
			}
			else if (num4 >= 9)
			{
				hero2.PositionY = 2;
			}
			else
			{
				hero2.PositionY = 3;
			}
		}
		else if (guardianState == GuardianState.Recovering)
		{
			int num5 = 20;
			float num6 = (float)elapsedGuardianTics / (float)num5;
			float a2 = recoverHeroStartX;
			float a3 = recoverHeroStartY;
			float b2 = base.PositionX - idleHeroDistance;
			float b3 = 0f;
			Hero hero3 = GameStates.Singleton.hero;
			hero3.PositionX = Mathf.RoundToInt(Mathf.Lerp(a2, b2, num6));
			float num7 = 7f * (1f - Mathf.Pow(2f * num6 - 1f, 2f));
			hero3.PositionY = Mathf.RoundToInt(Mathf.Lerp(a3, b3, num6) + num7);
			if (elapsedGuardianTics >= num5)
			{
				if (Alive)
				{
					SetGuardianState(GuardianState.PrePowerUpDelay);
				}
				else
				{
					SetGuardianState(GuardianState.Dead);
				}
			}
		}
		else if (guardianState == GuardianState.PrePowerUpDelay && elapsedGuardianTics >= 30 && base.CurrentState != State.Attacking)
		{
			if (currentHammerPower < maxHammerPower)
			{
				SetGuardianState(GuardianState.PoweringUp);
			}
			else
			{
				SetGuardianState(GuardianState.Idle);
			}
		}
		else if (guardianState == GuardianState.PoweringUp)
		{
			if (elapsedGuardianTics == 45)
			{
				FloatingText floatingText = ShowFloatingText(Te.xt("POWER UP"));
				if (floatingText != null)
				{
					floatingText.Message.color = ColorConstants.green;
					floatingText.PositionX -= 8;
					floatingText.PositionY -= 2;
				}
			}
			else if (elapsedGuardianTics >= 55)
			{
				SetPower(currentHammerPower + 1);
				if (currentHammerPower == 3)
				{
					fuseSfx = SfxController.singleton.Play("bronze_guardian_fuse");
				}
				base.MySprite = idleSprite;
				SetGuardianState(GuardianState.Idle);
			}
		}
		else if (guardianState == GuardianState.Boom && elapsedGuardianTics >= 105)
		{
			SetGuardianState(GuardianState.GameOver);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (guardianState == GuardianState.Boom && lastRenderer == null)
		{
			lastRenderer = r;
			r.AddPostEffect(this);
		}
	}

	private void HandlePostDraw(Character c, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (guardianState == GuardianState.PoweringUp)
		{
			int num = base.MySprite.lastDrawY;
			if (myHelmet.currentState == EnemyHelmet.State.Broken)
			{
				num--;
			}
			powerUpEyeFlash.Sprite.Draw(r, base.MySprite.lastDrawX, num, 1f, base.colorTint);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			lastRenderer = null;
			r.RemovePostEffect(this);
		}
		if (elapsedGuardianTics == 1 || elapsedGuardianTics == 4 || elapsedGuardianTics == 5)
		{
			for (int i = 0; i < r.width; i++)
			{
				for (int j = 0; j < r.height; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					Color background = cell.GetBackground();
					cell.SetBackground(Color.white);
					cell.SetForeground(background);
				}
			}
		}
		else
		{
			if (elapsedGuardianTics < 9)
			{
				return;
			}
			for (int k = 0; k < r.width; k++)
			{
				for (int l = 0; l < r.height; l++)
				{
					AsciiCellProcedural cell2 = r.GetCell(k, l);
					cell2.SetBackground(Color.white);
					cell2.SetForeground(Color.white);
				}
			}
		}
	}

	private void SetPower(int newPowerLevel)
	{
		newPowerLevel = Mathf.Clamp(newPowerLevel, 0, hammerPowers.Length - 1);
		if (currentHammerPower == newPowerLevel)
		{
			return;
		}
		currentHammerPower = newPowerLevel;
		HammerData hammerData = hammerPowers[newPowerLevel];
		idleSprite = hammerData.idle;
		attackCastSprite = hammerData.cast;
		attackPerfSprite = hammerData.perf;
		deathSprite = hammerData.death;
		base.weapon = hammerData.weapon;
		hammerData.weapon.Owner = this;
		hammerData.weapon.LoadAbilities();
		hammerData.weapon.SetState(Weapon.State.Cooldown);
		if (newPowerLevel != 3)
		{
			return;
		}
		AsciiAnimation[] componentsInChildren = idleSprite.GetComponentsInChildren<AsciiAnimation>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].Playing)
			{
				componentsInChildren[i].Play();
			}
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportGuardianDefeated(this);
	}

	private void HandleAttackEnded(Character character, Character target, Weapon weapon)
	{
		if (character == this && currentHammerPower == 3)
		{
			SetGuardianState(GuardianState.Boom);
		}
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c == this && guardianState >= GuardianState.Boom)
		{
			dmg.amount = 0;
		}
	}

	public override void Init()
	{
		base.Init();
		myHelmet = GetComponent<EnemyHelmet>();
		SetGuardianState(GuardianState.Asleep);
		Character.OnCharacterAttackEnded += HandleAttackEnded;
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	protected override void Start()
	{
		base.Start();
		powerUpEyeFlash.Sprite.Load();
		SfxController.singleton.Preload("bronze_guardian_fuse");
		base.OnPostDrawCharacter += HandlePostDraw;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Character.OnCharacterAttackEnded -= HandleAttackEnded;
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		if (lastRenderer != null)
		{
			lastRenderer.RemovePostEffect(this);
		}
		base.OnPostDrawCharacter -= HandlePostDraw;
	}
}
