using System;
using UnityEngine;

public class Nagaraja : Enemy
{
	[Serializable]
	public class TongueSprite
	{
		public int range = 23;

		public AsciiSprite sprite;
	}

	public enum WailingType
	{
		WailingNoBrick = 0,
		WailingWithBrick23 = 1,
		WailingWithBrick14 = 2
	}

	private enum NagarajaState
	{
		Asleep = 0,
		IdleIntoTongue = 1,
		IdleIntoPoison = 2,
		TongueAttackSmell = 3,
		TongueAttackWrap = 4,
		TongueAttackDelay = 5,
		TongueAttackLift = 6,
		TongueAttackEat = 7,
		TongueDamaged = 8,
		GameOver = 9,
		FadingOut = 10,
		PoisonAttack = 11,
		Wailing = 12,
		Dead = 13
	}

	public int idleTongueDuration = 124;

	public int idlePoisonDuration = 100;

	public int smellDuration = 90;

	public int wrapDuration = 20;

	public int delayDuration = 60;

	public int damagedDuration = 60;

	private int liftDuration = 18;

	private int eatDuration = 25;

	private int gameOverDuration = 100;

	private int wailingDuration = 108;

	public AsciiAnimation bodyAttackAnm;

	public AsciiAnimation bodyDamagedAnm;

	public AsciiAnimation bodyEatAnm;

	public AsciiAnimation tongueWrapFeetAnm;

	public AsciiSprite tongueChoke;

	public AsciiAnimation bodyWailingAnm;

	public TongueSprite[] tongueSmell;

	public TongueSprite[] tongueWrap;

	public TongueSprite[] tongueDamaged;

	public TongueSprite[] tongueLift;

	public TongueSprite[] tongueEat;

	private int[][] liftData = new int[10][]
	{
		new int[21]
		{
			23, -50, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 6, -6, 9, -9, 15, -10, 17, -10, 17,
			-10
		},
		new int[21]
		{
			21, -52, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 6, -6, 9, -9, 13, -10, 15, -10, 15,
			-10
		},
		new int[21]
		{
			19, -54, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 6, -6, 9, -9, 11, -10, 13, -10, 13,
			-10
		},
		new int[21]
		{
			17, -56, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 6, -6, 8, -9, 9, -10, 11, -10, 11,
			-10
		},
		new int[21]
		{
			15, -58, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 6, -6, 7, -9, 8, -10, 9, -10, 9,
			-10
		},
		new int[21]
		{
			13, -60, 91, 1, 0, 1, -1, 3, -2, 5,
			-4, 5, -6, 5, -9, 5, -10, 7, -10, 7,
			-10
		},
		new int[21]
		{
			11, -62, 91, 1, 0, 1, -1, 2, -2, 3,
			-4, 3, -6, 3, -9, 3, -10, 5, -10, 5,
			-10
		},
		new int[21]
		{
			9, -64, 91, 1, 0, 1, -1, 1, -2, 1,
			-4, 1, -6, 1, -9, 1, -10, 3, -10, 3,
			-10
		},
		new int[21]
		{
			7, -68, 91, 1, 0, 0, -1, 0, -2, 0,
			-4, 0, -6, 0, -9, 0, -10, 2, -10, 2,
			-10
		},
		new int[21]
		{
			5, -68, 91, 3, 0, 1, -1, 0, -2, 0,
			-4, 0, -6, 0, -9, 0, -10, 2, -10, 2,
			-10
		}
	};

	private int[] eatData = new int[27]
	{
		11, -61, 77, 5, -10, 5, -10, 5, -10, 5,
		-10, 5, -10, 5, -10, 5, -10, 6, -10, 10,
		-10, 14, -10, 15, -10, 15, -10
	};

	public WailingType wailingType;

	public Decoration fallingParticlePrefab;

	public Decoration fallingBigBrickPrefab;

	public int fallingBrickBaseDamage = 10;

	public int poisonsInARow = 1;

	private int numPoisonsInRowAdded;

	public bool ignoreDotDamage;

	private int elapsedNagarajaTics;

	private int lastRange = -1;

	private NagarajaState lastState;

	private AsciiSprite lastSprite;

	private int lastStateDuration;

	private int[] lastHeroLift;

	private int lastHitpointsEvaluated;

	private NagarajaState nagarajaState { get; set; }

	private NagarajaState prevNagarajaState { get; set; }

	private void SetNagarajaState(NagarajaState newState)
	{
		switch (newState)
		{
		case NagarajaState.TongueAttackSmell:
			base.MySprite = bodyAttackAnm.Sprite;
			bodyAttackAnm.Stop();
			bodyAttackAnm.Play();
			SfxController.singleton.Play("nagaraja_tongue_smell");
			break;
		case NagarajaState.TongueAttackWrap:
			tongueWrapFeetAnm.Stop();
			tongueWrapFeetAnm.Play();
			SfxController.singleton.Play("nagaraja_tongue_wrap", ignoreDuplicateSfxInSameFrame: true, 0.2f);
			break;
		case NagarajaState.TongueDamaged:
			base.MySprite = bodyDamagedAnm.Sprite;
			bodyDamagedAnm.Stop();
			bodyDamagedAnm.Play();
			SfxController.singleton.Play("nagaraja_tongue_damaged");
			break;
		case NagarajaState.TongueAttackLift:
		{
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			Hero hero = GameStates.Singleton.hero;
			hero.PauseAI(999f);
			hero.SetState(Hero.State.Choked);
			hero.Cleanse();
			hero.PositionY = 100;
			if (hero.PositionX < 49)
			{
				hero.PositionX = 49;
			}
			else if (hero.PositionX % 2 == 0)
			{
				hero.PositionX--;
			}
			MusicController.singleton.FadeToSilence(0.25f);
			SfxController.singleton.Play("nagaraja_tongue_lift");
			break;
		}
		case NagarajaState.TongueAttackEat:
			base.MySprite = bodyEatAnm.Sprite;
			bodyEatAnm.Stop();
			bodyEatAnm.Play();
			GameStates.Singleton.hero.PositionX = 49;
			SfxController.singleton.Play("nagaraja_attack_eat", ignoreDuplicateSfxInSameFrame: true, 0.75f);
			SfxController.singleton.Play("nagaraja_attack_swallow", ignoreDuplicateSfxInSameFrame: true, 2f);
			SfxController.singleton.Play("nagaraja_attack_lick", ignoreDuplicateSfxInSameFrame: true, 2.8f);
			break;
		case NagarajaState.FadingOut:
			GameStates.Singleton.TransitionToState(GameStates.State.QuestScreen, TransitionManager.Type.SlowFadeToBlack);
			break;
		case NagarajaState.PoisonAttack:
			base.weapon.SetState(Weapon.State.Waiting);
			break;
		case NagarajaState.Wailing:
			base.MySprite = bodyWailingAnm.Sprite;
			bodyWailingAnm.Stop();
			bodyWailingAnm.Play();
			SfxController.singleton.Play("nagaraja_wail");
			break;
		default:
			if (base.MySprite != walkSprite)
			{
				base.MySprite = walkSprite;
				AsciiAnimation component = walkSprite.GetComponent<AsciiAnimation>();
				if (component != null)
				{
					component.Stop();
					component.Play();
				}
			}
			break;
		case NagarajaState.TongueAttackDelay:
		case NagarajaState.GameOver:
			break;
		}
		prevNagarajaState = nagarajaState;
		nagarajaState = newState;
		elapsedNagarajaTics = 0;
	}

	protected override void SetState(State newState)
	{
		if (base.CurrentState == State.Sleeping)
		{
			PlayChains();
		}
		else if (base.CurrentState == State.WakingUp)
		{
			SetNagarajaState(NagarajaState.IdleIntoTongue);
		}
		if (newState == State.Dying)
		{
			SetNagarajaState(NagarajaState.Dead);
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedNagarajaTics++;
		if (nagarajaState == NagarajaState.IdleIntoTongue && elapsedNagarajaTics >= idleTongueDuration)
		{
			SetNagarajaState(NagarajaState.TongueAttackSmell);
		}
		else if (nagarajaState == NagarajaState.IdleIntoPoison && elapsedNagarajaTics >= idlePoisonDuration)
		{
			numPoisonsInRowAdded = 0;
			SetNagarajaState(NagarajaState.PoisonAttack);
		}
		else if (nagarajaState == NagarajaState.TongueAttackSmell && elapsedNagarajaTics >= smellDuration)
		{
			SetNagarajaState(nagarajaState + 1);
		}
		else if (nagarajaState == NagarajaState.TongueAttackWrap && elapsedNagarajaTics >= wrapDuration)
		{
			SetNagarajaState(nagarajaState + 1);
		}
		else if (nagarajaState == NagarajaState.TongueAttackDelay && elapsedNagarajaTics >= delayDuration)
		{
			SetNagarajaState(nagarajaState + 1);
		}
		else if (nagarajaState == NagarajaState.TongueAttackLift && elapsedNagarajaTics >= liftDuration)
		{
			SetNagarajaState(nagarajaState + 1);
		}
		else if (nagarajaState == NagarajaState.TongueAttackEat && elapsedNagarajaTics >= eatDuration)
		{
			SetNagarajaState(NagarajaState.GameOver);
		}
		else if (nagarajaState == NagarajaState.TongueDamaged && elapsedNagarajaTics >= damagedDuration)
		{
			SetNagarajaState(NagarajaState.IdleIntoPoison);
		}
		else if (nagarajaState == NagarajaState.GameOver && elapsedNagarajaTics >= gameOverDuration)
		{
			SetNagarajaState(NagarajaState.FadingOut);
		}
		else if (nagarajaState == NagarajaState.PoisonAttack)
		{
			if (base.weapon.IsOnCooldown())
			{
				SetNagarajaState(NagarajaState.IdleIntoTongue);
			}
			else if (base.weapon.IsPerforming() && numPoisonsInRowAdded < poisonsInARow - 1)
			{
				numPoisonsInRowAdded++;
				SetNagarajaState(NagarajaState.PoisonAttack);
			}
		}
		else
		{
			if (nagarajaState != NagarajaState.Wailing)
			{
				return;
			}
			if ((elapsedNagarajaTics >= 10 && elapsedNagarajaTics % 2 == 0) || (elapsedNagarajaTics >= 30 && elapsedNagarajaTics <= 55 && wailingType != WailingType.WailingNoBrick))
			{
				SpawnParticle();
			}
			if (elapsedNagarajaTics == 50 && wailingType != WailingType.WailingNoBrick)
			{
				SpawnBigBrick();
			}
			else if (elapsedNagarajaTics == 61 && wailingType != WailingType.WailingNoBrick)
			{
				Hero hero = GameStates.Singleton.hero;
				if (base.PositionX - hero.PositionX <= 10)
				{
					Damage damage = new Damage();
					damage.amount = Mathf.CeilToInt(hero.Armor) + fallingBrickBaseDamage + level;
					damage.isCritical = true;
					damage.Owner = this;
					damage.type = Damage.Type.Melee;
					damage.tags.Add("physical");
					hero.InflictDamage(damage);
				}
			}
			else if (elapsedNagarajaTics >= wailingDuration)
			{
				SetNagarajaState(NagarajaState.IdleIntoPoison);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		AsciiSprite asciiSprite = lastSprite;
		int num = lastStateDuration;
		int[] array = lastHeroLift;
		int num2 = base.PositionX - GameStates.Singleton.hero.PositionX;
		if (lastRange != num2 || lastState != nagarajaState)
		{
			lastRange = num2;
			lastState = nagarajaState;
			TongueSprite[] array2 = null;
			if (nagarajaState == NagarajaState.TongueAttackSmell)
			{
				array2 = tongueSmell;
				num = smellDuration;
			}
			else if (nagarajaState == NagarajaState.TongueAttackWrap)
			{
				array2 = tongueWrap;
				num = wrapDuration;
			}
			else if (nagarajaState == NagarajaState.TongueAttackDelay)
			{
				array2 = tongueWrap;
			}
			else if (nagarajaState == NagarajaState.TongueAttackLift)
			{
				array2 = tongueLift;
				num = liftDuration;
			}
			else if (nagarajaState == NagarajaState.TongueAttackEat)
			{
				array2 = tongueEat;
				num = eatDuration;
			}
			else if (nagarajaState == NagarajaState.TongueDamaged)
			{
				array2 = tongueDamaged;
				num = damagedDuration;
			}
			if (array2 != null && array2.Length != 0)
			{
				int num3 = 9999;
				for (int i = 0; i < array2.Length; i++)
				{
					int num4 = Mathf.Abs(num2 - array2[i].range);
					if (num3 > num4)
					{
						num3 = num4;
						asciiSprite = array2[i].sprite;
					}
				}
			}
			else
			{
				asciiSprite = null;
			}
			if (nagarajaState == NagarajaState.TongueAttackLift)
			{
				int num3 = 9999;
				for (int j = 0; j < liftData.Length; j++)
				{
					int[] array3 = liftData[j];
					int num5 = Mathf.Abs(num2 - array3[0]);
					if (num3 > num5)
					{
						num3 = num5;
						array = array3;
					}
				}
			}
			else
			{
				array = null;
			}
			lastSprite = asciiSprite;
			lastStateDuration = num;
			lastHeroLift = array;
		}
		if (asciiSprite != null)
		{
			int num7;
			if (nagarajaState != NagarajaState.TongueAttackDelay)
			{
				float num6 = (float)elapsedNagarajaTics / (float)num;
				num7 = Mathf.FloorToInt((float)asciiSprite.FrameCount * num6);
			}
			else
			{
				num7 = asciiSprite.FrameCount - 1;
			}
			asciiSprite.SetFrameIndex(num7);
			asciiSprite.Draw(r, offsetX, offsetY, 1f, base.colorTint);
			if (array != null)
			{
				num7 *= 2;
				int num8 = asciiSprite.lastDrawX + array[1];
				int num9 = asciiSprite.lastDrawY + array[2];
				int num10 = array[num7 + 3];
				int num11 = array[num7 + 4];
				GameStates.Singleton.hero.Draw(r, num8 + num10, num9 + num11);
			}
		}
		else if (nagarajaState == NagarajaState.TongueAttackEat)
		{
			int frameIndex = base.MySprite.GetFrameIndex();
			if (frameIndex <= 11)
			{
				frameIndex *= 2;
				int num12 = offsetX + eatData[1];
				int num13 = offsetY + eatData[2];
				int num14 = eatData[frameIndex + 3];
				int num15 = eatData[frameIndex + 4];
				GameStates.Singleton.hero.Draw(r, num12 + num14, num13 + num15);
			}
		}
	}

	private void HandlePostDrawHero(Hero hero, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (nagarajaState == NagarajaState.TongueAttackWrap || nagarajaState == NagarajaState.TongueAttackDelay)
		{
			tongueWrapFeetAnm.Sprite.Draw(r, offsetX, offsetY, 1f, base.colorTint);
		}
		else if (nagarajaState == NagarajaState.TongueAttackLift || nagarajaState == NagarajaState.TongueAttackEat)
		{
			tongueChoke.Draw(r, offsetX, offsetY, 1f, base.colorTint);
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (!(c == this) || dmg.amount <= 0 || (ignoreDotDamage && dmg.type == Damage.Type.Dot))
		{
			return;
		}
		if (nagarajaState == NagarajaState.TongueAttackDelay)
		{
			SetNagarajaState(NagarajaState.TongueDamaged);
		}
		else if (nagarajaState == NagarajaState.IdleIntoTongue || nagarajaState == NagarajaState.IdleIntoPoison)
		{
			if (wailingType == WailingType.WailingNoBrick)
			{
				int num = base.MaxHitpoints / 2;
				if (lastHitpointsEvaluated > num && num >= base.Hitpoints)
				{
					SetNagarajaState(NagarajaState.Wailing);
				}
			}
			else
			{
				int num2;
				int num3;
				if (wailingType == WailingType.WailingWithBrick23)
				{
					num2 = base.MaxHitpoints * 2 / 3;
					num3 = base.MaxHitpoints / 3;
				}
				else
				{
					num2 = base.MaxHitpoints * 3 / 4;
					num3 = base.MaxHitpoints / 4;
				}
				if (lastHitpointsEvaluated > num2 && num2 >= base.Hitpoints)
				{
					SetNagarajaState(NagarajaState.Wailing);
				}
				else if (lastHitpointsEvaluated > num3 && num3 >= base.Hitpoints)
				{
					SetNagarajaState(NagarajaState.Wailing);
				}
			}
			lastHitpointsEvaluated = base.Hitpoints;
		}
		else if (nagarajaState == NagarajaState.TongueAttackLift || nagarajaState == NagarajaState.TongueAttackEat || nagarajaState == NagarajaState.GameOver || nagarajaState == NagarajaState.FadingOut)
		{
			dmg.amount = 0;
		}
	}

	private void PlayChains()
	{
		GameObject gameObject = GameObject.Find("Chains");
		if ((bool)gameObject)
		{
			gameObject.GetComponent<AsciiAnimation>().Play();
		}
	}

	private void SpawnParticle()
	{
		Character character = UnityEngine.Object.Instantiate(fallingParticlePrefab);
		character.PositionX = base.PositionX + UnityEngine.Random.Range(-30, 30);
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ + UnityEngine.Random.Range(-4, 5);
		GameStates.Singleton.level.AddCharacter(character);
	}

	private void SpawnBigBrick()
	{
		Character character = UnityEngine.Object.Instantiate(fallingBigBrickPrefab);
		character.SetLevel(level);
		character.PositionX = base.PositionX - 4;
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ + 1;
		GameStates.Singleton.level.AddCharacter(character);
		SfxController.singleton.Play("nagaraja_wail_brick", ignoreDuplicateSfxInSameFrame: true, 0.2f);
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportNagarajaDefeated(this);
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
		if (GameStates.Singleton != null && GameStates.Singleton.hero != null)
		{
			GameStates.Singleton.hero.OnPostDrawHero += HandlePostDrawHero;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		if (GameStates.Singleton != null && GameStates.Singleton.hero != null)
		{
			GameStates.Singleton.hero.OnPostDrawHero -= HandlePostDrawHero;
		}
	}

	public override int GetStateNumericRepresentation()
	{
		if (nagarajaState == NagarajaState.Asleep || nagarajaState == NagarajaState.PoisonAttack)
		{
			return base.GetStateNumericRepresentation();
		}
		return (int)(100 + nagarajaState);
	}

	public override int GetStateTimeRepresentation()
	{
		if (nagarajaState == NagarajaState.Asleep || nagarajaState == NagarajaState.PoisonAttack)
		{
			return base.GetStateTimeRepresentation();
		}
		return elapsedNagarajaTics;
	}
}
