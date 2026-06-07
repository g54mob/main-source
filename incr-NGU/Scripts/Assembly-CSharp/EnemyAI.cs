using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Character character;

	public PlayerLog log;

	public PlayerController player;

	public AdventureController ac;

	private float enemyAttackTimer;

	private int poisonEffect;

	private int paralyzeEffect;

	private int chargeCooldown;

	private float defenseBuffCooldown;

	private float tempAttack;

	private float tempDefense;

	private float defenseFactor = 1f;

	private bool firstStrike = true;

	private bool rapidMode;

	private int rapidEffect;

	public int growCount;

	private int locustCount;

	private float paralyzeTime;

	private int skipturn;

	public float bleedDamage;

	public bool invincible;

	public int invincibleCount;

	public int growRate = 1;

	public int waldoAttackID;

	public int lastAttackID;

	public bool waldoSays = true;

	public bool inWaldoSaysLoop;

	public bool kneeCapped;

	public bool explosionMode;

	public int explosionCount;

	public int auraID;

	public int nerdHacks;

	public int glopCount;

	public void Update()
	{
		if (ac.currentEnemy == null)
		{
			return;
		}
		if (paralyzeTime > 0f)
		{
			paralyzeTime -= Time.deltaTime;
			if (paralyzeTime <= 0f)
			{
				paralyzeTime = 0f;
				log.AddEvent(ac.currentEnemy.name + " has broken free of your paralyzing gaze!");
			}
			return;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss1)
		{
			theButcherAI();
			return;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss2)
		{
			corruptedTreeAI();
			return;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss3)
		{
			jakeAI();
			return;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss4)
		{
			uugAI();
			return;
		}
		if (isWaldo())
		{
			waldoAI();
			return;
		}
		if (ac.currentEnemy.enemyType == enemyType.guardian)
		{
			guardianAI();
			return;
		}
		if (isBeast())
		{
			beastAI();
			return;
		}
		if (isNerd())
		{
			nerdAI();
			return;
		}
		if (isGodmother())
		{
			godmotherAI();
			return;
		}
		if (isExile())
		{
			exileAI();
			return;
		}
		if (isItHungers())
		{
			itHungersAI();
			return;
		}
		if (isRockLobster())
		{
			rockLobsterAI();
			return;
		}
		if (isAmalgamate())
		{
			amalgamateAI();
			return;
		}
		if (isRat())
		{
			ratAI();
			return;
		}
		if (isTraitor())
		{
			traitorAI();
			return;
		}
		enemyAttackTimer += Time.deltaTime;
		if (defenseBuffCooldown > 5f)
		{
			defenseFactor = 1f;
		}
		if (firstStrike)
		{
			if (enemyAttackTimer >= ac.currentEnemy.attackRate * 1.5f)
			{
				enemyAttackTimer = 0f;
				firstStrike = false;
				doAction();
			}
		}
		else if (rapidMode)
		{
			if ((double)enemyAttackTimer >= (double)ac.currentEnemy.attackRate * 0.3)
			{
				enemyAttackTimer = 0f;
				doAction();
			}
		}
		else if (enemyAttackTimer >= ac.currentEnemy.attackRate)
		{
			enemyAttackTimer = 0f;
			doAction();
		}
	}

	public void doAction()
	{
		switch (ac.currentEnemy.AI)
		{
		case AI.normal:
			regularAttack();
			break;
		case AI.poison:
			poisonAttack();
			break;
		case AI.charger:
			chargeAttack();
			break;
		case AI.exploder:
			explode();
			break;
		case AI.paralyze:
			paralyzeAI();
			break;
		case AI.rapid:
			rapidAI();
			break;
		case AI.grower:
			growerAI();
			break;
		default:
			regularAttack();
			break;
		}
	}

	public float minDamage()
	{
		return ac.currentEnemy.attack * 0.1f;
	}

	public float playerDefense()
	{
		return character.totalAdvDefense();
	}

	public float baseDamage()
	{
		return ac.currentEnemy.attack - playerDefense() * player.defenseBuffFactor * player.defenseDebuffFactor / 2f;
	}

	public void paralyzed(float time)
	{
		paralyzeTime = time;
	}

	private void regularAttack()
	{
		float num = attack();
		log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num) + " damage!", 2);
	}

	private float attack(float factor)
	{
		float num = Random.Range(0.8f, 1.2f);
		float damage = Mathf.Max(minDamage(), baseDamage()) * num * factor;
		return player.takeDamage(damage);
	}

	private float attack()
	{
		float num = Random.Range(0.8f, 1.2f);
		float damage = Mathf.Max(minDamage(), baseDamage()) * num;
		return player.takeDamage(damage);
	}

	private float reflectDamage(float amount)
	{
		return player.takeDamage(amount / 50f);
	}

	private void poisonAttack()
	{
		if (poisonEffect < 0)
		{
			regularAttack();
		}
		else if (poisonEffect == 0)
		{
			float num = attack();
			log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num) + " damage! You've also been poisoned!", 2);
		}
		else if (poisonEffect <= 5)
		{
			float num2 = attack();
			float num3 = Mathf.Floor(ac.currentEnemy.attack * 0.2f * Random.Range(0.8f, 1.2f));
			character.adventure.curHP -= num3;
			log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num2) + " damage!", 2);
			log.AddEvent("You also take " + character.display(num3) + " poison damage!", 2);
			poisonEffect++;
		}
		else
		{
			float num4 = attack();
			log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num4) + " damage! Your poison has worn off.", 2);
			poisonEffect = -3;
		}
		poisonEffect++;
	}

	private void chargeAttack()
	{
		chargeCooldown++;
		if (chargeCooldown < 3)
		{
			regularAttack();
		}
		else if (chargeCooldown == 3)
		{
			log.AddEvent(ac.currentEnemy.name + " starts glowing red... huge attack incoming!", 2);
		}
		else if (chargeCooldown >= 5)
		{
			float num = attack(4f);
			log.AddEvent(ac.currentEnemy.name + " unleashed a MASSIVE attack for " + character.display(num) + " damage!", 2);
			chargeCooldown = 0;
		}
	}

	private void paralyzeAI()
	{
		if (paralyzeEffect < 0)
		{
			regularAttack();
		}
		else if (paralyzeEffect == 1)
		{
			float num = attack();
			log.AddEvent(ac.currentEnemy.name + " attacks for " + character.display(num) + " damage! You feel yourself beginning to slow down...", 2);
		}
		else if (paralyzeEffect == 2)
		{
			float num2 = attack();
			player.paralyzed(2f);
			paralyzeEffect = -10;
			log.AddEvent(ac.currentEnemy.name + " attacks for " + character.display(num2) + " damage! You're now fully paralyzed, oh crap!", 2);
		}
		paralyzeEffect++;
	}

	private void rapidAI()
	{
		rapidEffect++;
		if (rapidEffect < 5)
		{
			regularAttack();
		}
		else if (rapidEffect == 5)
		{
			log.AddEvent(ac.currentEnemy.name + " starts shaking violently! What's about to happen?", 2);
		}
		else if (rapidEffect >= 8)
		{
			if (rapidEffect == 8)
			{
				rapidMode = true;
				float num = attack();
				log.AddEvent(ac.currentEnemy.name + " surged forward and started attacking crazy fast!", 2);
				log.AddEvent("You were attacked for " + character.display(num) + " damage!", 2);
			}
			else if (rapidEffect < 14)
			{
				regularAttack();
			}
			else
			{
				rapidMode = false;
				rapidEffect = 0;
				float num2 = attack();
				log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num2) + " damage! They seem to have stopped freaking out.", 2);
			}
		}
	}

	private void growerAI()
	{
		growCount++;
		float num = attack(1f + Mathf.Floor(growCount / 2) / 5f);
		if (growCount % 2 == 0)
		{
			log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num) + " damage! They swell up in size, too! Creepy!", 2);
		}
		else
		{
			log.AddEvent(ac.currentEnemy.name + " has attacked for " + character.display(num) + " damage!", 2);
		}
	}

	public float takeDamage(float damage)
	{
		damage = Mathf.Floor(damage / defenseFactor);
		if (invincible)
		{
			damage = 0f;
		}
		if (invincibleCount > 0)
		{
			damage = 0f;
			invincibleCount--;
		}
		if (isBeast() && auraID == 3)
		{
			damage /= 3f;
		}
		ac.currentEnemy.curHP -= damage;
		if (inWaldoSaysLoop)
		{
			if (!didCorrectWaldoMove())
			{
				if (waldoSays)
				{
					log.AddEvent("The demented hiker cackles, 'YOU DIDN'T DO WHAT WALDERP SAYS, SUCKER! TIME TO DIEEEEEEEEE!'");
					log.AddEvent("He pulls out a big red button and presses it.");
				}
				else
				{
					log.AddEvent("The demented hiker cackles, 'I DIDN'T SAY WALDERP SAYS, SUCKER! TIME TO DIEEEEEEEEE!'");
					log.AddEvent("He pulls out a big red button and presses it.");
				}
				explode();
			}
			else
			{
				waldoAttackID = 0;
				lastAttackID = 0;
				inWaldoSaysLoop = false;
			}
		}
		if (isBeast() && auraID == 5)
		{
			float num = reflectDamage(damage);
			log.AddEvent("Your attack bounces back off THE BEAST's rubbery hide!");
			log.AddEvent("You hit yourself for " + character.display(num) + " damage!", 2);
		}
		if (isNerd() && lastAttackID == 6 && nerdHacks > 0)
		{
			log.AddEvent("The Greasy Nerd reels back from the blow, weakened - your ultimate attack reversed his last round of hacking!");
			growCount -= 8;
			nerdHacks--;
		}
		return damage;
	}

	private void explode()
	{
		float num = attack(1000f);
		log.AddEvent(ac.currentEnemy.name + " detonated like a thermonuclear explosive for " + character.display(num) + " damage!", 2);
		log.AddEvent("You are almost certainly dead.", 2);
		if (character.adventure.curHP > 1f)
		{
			character.allAchievements.markAchievementAsComplete(126);
		}
	}

	private void locusts()
	{
		locustCount++;
	}

	private void disableMove()
	{
		ac.playerController.moveDisabled();
	}

	private float suicide()
	{
		float num = float.MaxValue;
		ac.currentEnemy.curHP -= num;
		return num;
	}

	public void resetAI()
	{
		paralyzeEffect = 0;
		poisonEffect = 0;
		chargeCooldown = 0;
		enemyAttackTimer = 0f;
		defenseBuffCooldown = 0f;
		defenseFactor = 1f;
		firstStrike = true;
		rapidMode = false;
		rapidEffect = 0;
		growCount = 0;
		bleedDamage = 0f;
		paralyzeTime = 0f;
		player.reset();
		locustCount = 0;
		skipturn = 0;
		invincible = false;
		waldoAttackID = 0;
		waldoSays = true;
		inWaldoSaysLoop = false;
		auraID = 0;
		nerdHacks = 0;
		kneeCapped = false;
		explosionMode = false;
		explosionCount = 0;
		glopCount = 0;
		invincibleCount = 0;
		growRate = 1;
	}

	private void theButcherAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		paralyzeEffect++;
		if (paralyzeEffect > 20)
		{
			paralyzeEffect = 20;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		int num2 = Random.Range(1, 8);
		float num3 = 1f + (float)growCount / 100f;
		switch (num2)
		{
		case 1:
			num = attack(1f * num3);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num3);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(2f * num3);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(2f * num3);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 5:
			if (paralyzeEffect < 10)
			{
				num = attack(1f * num3);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			}
			else
			{
				player.paralyzed(4f);
				log.AddEvent(ac.currentEnemy.name + " start screaming obscenities at you! It freaks you out so much you're frozen in fear!", 2);
				paralyzeEffect = 0;
			}
			break;
		case 6:
			num = attack(1f * num3);
			bleedDamage += 2f;
			log.AddEvent(ac.currentEnemy.name + " hacked your limbs for  " + character.display(num) + " damage! You feel yourself bleed...", 2);
			break;
		default:
			num = attack(1f * num3);
			bleedDamage += 2f;
			log.AddEvent(ac.currentEnemy.name + " hacked your limbs for  " + character.display(num) + " damage! You feel yourself bleed...", 2);
			break;
		}
	}

	private void corruptedTreeAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		paralyzeEffect++;
		if (paralyzeEffect > 20)
		{
			paralyzeEffect = 20;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		int num2 = Random.Range(1, 8);
		float num3 = 1f + (float)growCount / 100f;
		switch (num2)
		{
		case 1:
			num = attack(1f * num3);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num3);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1.5f * num3);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num3);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 5:
			if (player.offenseDebuffTime == -1f)
			{
				player.debuffAttack(1.5f, 15f);
				log.AddEvent(ac.currentEnemy.name + " shoots out a cloud of spores! Your arms feel so heavy all of a sudden...", 2);
			}
			else
			{
				num = attack(1f * num3);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			}
			break;
		case 6:
			if (player.defenseDebuffTime == -1f)
			{
				player.debuffDefense(1.5f, 15f);
				log.AddEvent(ac.currentEnemy.name + " shoots out a cloud of spores! You cough and wheeze, the energy draining from your body...", 2);
			}
			else
			{
				num = attack(1f * num3);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			}
			break;
		default:
			num = attack(1f * num3);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	private void jakeAI()
	{
		enemyAttackTimer += Time.deltaTime;
		float num = 0f;
		float num2 = 1f + (float)growCount / 100f;
		if (skipturn < 0)
		{
			skipturn++;
			if (skipturn == 0)
			{
				rapidMode = true;
				locustCount = -10;
			}
		}
		else if (rapidMode && enemyAttackTimer > ac.currentEnemy.attackRate * 0.15f)
		{
			enemyAttackTimer = 0f;
			locustCount++;
			num = attack(0.5f * num2);
			log.AddEvent("LOCUSTS ATTACK YOUR FACE FOR " + character.display(num) + " DAMAGE!", 2);
			if (locustCount >= 0)
			{
				rapidMode = false;
			}
		}
		else
		{
			if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
			{
				return;
			}
			paralyzeEffect++;
			if (paralyzeEffect > 20)
			{
				paralyzeEffect = 20;
			}
			enemyAttackTimer = 0f;
			growCount++;
			locustCount++;
			int num3 = Random.Range(1, 6);
			num2 = 1f + (float)growCount / 100f;
			if (growCount % 20 == 1)
			{
				disableMove();
				log.AddEvent(ac.currentEnemy.name + " tucks his arms into his shirt and starts flapping his empty sleeves back and forth!", 2);
				log.AddEvent("You're so confused by this display that one of your moves has been disabled!", 2);
				return;
			}
			switch (num3)
			{
			case 1:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 2:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 3:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 4:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 5:
				if (locustCount < 10)
				{
					num = attack(1f * num2);
					log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				}
				else
				{
					log.AddEvent(ac.currentEnemy.name + " opens his mouth unnaturally wide and shoots out 100,000 FREAKING LOCUSTS! INCOMING!!!", 2);
					skipturn = -1;
				}
				break;
			default:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
		}
	}

	private void uugAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		int num3 = character.inventoryController.apathyCheck();
		if (num3 < 0)
		{
			invincible = true;
			growCount += 400;
			if (growCount <= 536870911)
			{
				growCount *= 2;
			}
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			log.AddEvent(ac.currentEnemy.name + " also screeches horrible insults at you - He even calls you a Droop ;_;!", 2);
			log.AddEvent("You fall over crying as UUG feeds off your emotions and grows immensely in power.", 2);
			log.AddEvent("Wait - you've heard that name before. Who the heck is Droop? Anyways, time to die.", 2);
			return;
		}
		if (num3 < 100)
		{
			if (growCount < 536870911)
			{
				growCount += 100 - num3;
				growCount = Mathf.CeilToInt((float)growCount * (2f - (float)num3 / 100f));
			}
			log.AddEvent(ac.currentEnemy.name + " also screeches horrible insults at you - He even calls you a Droop ;_;!", 2);
			log.AddEvent("You manage to resist the worst of UUG's emotional abuse, but he's still growing stronger!", 2);
		}
		else if (num3 >= 100)
		{
			log.AddEvent(ac.currentEnemy.name + " screeches horrible insults at you - He even calls you a Droop ;_;! ", 2);
			log.AddEvent("Using your ring of Apathy, you channel your inner Honey Badger and stop giving a fuck. UUG looks dismayed!", 2);
		}
		switch (Random.Range(1, 5))
		{
		case 1:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	public bool isWaldo()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss5 || ac.currentEnemy.enemyType == enemyType.waldo1 || ac.currentEnemy.enemyType == enemyType.waldo2 || ac.currentEnemy.enemyType == enemyType.waldo3 || ac.currentEnemy.enemyType == enemyType.waldo4)
		{
			return true;
		}
		return false;
	}

	public void waldoAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		if (growCount % 6 == 2)
		{
			inWaldoSaysLoop = true;
			string text = "";
			if (Random.Range(0, 2) == 0)
			{
				waldoSays = true;
				text += "WALDERP SAYS ";
			}
			else
			{
				waldoSays = false;
			}
			waldoAttackID = Random.Range(2, 7);
			switch (waldoAttackID)
			{
			case 2:
				waldoAttackID = 3;
				log.AddEvent(text + "HIT ME WITH A REGULAR ATTACK", 2);
				break;
			case 3:
				log.AddEvent(text + "HIT ME WITH A REGULAR ATTACK", 2);
				break;
			case 4:
				log.AddEvent(text + "HIT ME WITH A STRONG ATTACK", 2);
				break;
			case 5:
				log.AddEvent(text + "HIT ME WITH A PIERCING ATTACK", 2);
				break;
			case 6:
				log.AddEvent(text + "HIT ME WITH AN ULTIMATE ATTACK", 2);
				break;
			}
		}
		else if (growCount % 6 == 3 && inWaldoSaysLoop)
		{
			log.AddEvent("YOU DIDN'T DO WHAT I SAID AT ALL, SUCKER! TIME TO DIEEEEEEEEE!'");
			log.AddEvent("He pulls out a big red button and presses it.");
			explode();
			waldoSays = false;
			inWaldoSaysLoop = false;
		}
		else
		{
			switch (Random.Range(1, 5))
			{
			case 1:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 2:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 3:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 4:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			default:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
		}
	}

	public bool didCorrectWaldoMove()
	{
		if (!isWaldo())
		{
			return true;
		}
		if (waldoAttackID == 0 || lastAttackID == 0)
		{
			return true;
		}
		if (lastAttackID == waldoAttackID && !waldoSays)
		{
			return false;
		}
		if (lastAttackID != waldoAttackID && waldoSays)
		{
			return false;
		}
		return true;
	}

	public bool isBeast()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss6V1 || ac.currentEnemy.enemyType == enemyType.bigBoss6V2 || ac.currentEnemy.enemyType == enemyType.bigBoss6V3 || ac.currentEnemy.enemyType == enemyType.bigBoss6V4)
		{
			return true;
		}
		return false;
	}

	public bool isNerd()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss7V1 || ac.currentEnemy.enemyType == enemyType.bigBoss7V2 || ac.currentEnemy.enemyType == enemyType.bigBoss7V3 || ac.currentEnemy.enemyType == enemyType.bigBoss7V4)
		{
			return true;
		}
		return false;
	}

	public bool isGodmother()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss8V1 || ac.currentEnemy.enemyType == enemyType.bigBoss8V2 || ac.currentEnemy.enemyType == enemyType.bigBoss8V3 || ac.currentEnemy.enemyType == enemyType.bigBoss8V4)
		{
			return true;
		}
		return false;
	}

	public bool isExile()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss9V1 || ac.currentEnemy.enemyType == enemyType.bigBoss9V2 || ac.currentEnemy.enemyType == enemyType.bigBoss9V3 || ac.currentEnemy.enemyType == enemyType.bigBoss9V4)
		{
			return true;
		}
		return false;
	}

	public bool isItHungers()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss10V1 || ac.currentEnemy.enemyType == enemyType.bigBoss10V2 || ac.currentEnemy.enemyType == enemyType.bigBoss10V3 || ac.currentEnemy.enemyType == enemyType.bigBoss10V4)
		{
			return true;
		}
		return false;
	}

	public bool isRockLobster()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss11V1 || ac.currentEnemy.enemyType == enemyType.bigBoss11V2 || ac.currentEnemy.enemyType == enemyType.bigBoss11V3 || ac.currentEnemy.enemyType == enemyType.bigBoss11V4)
		{
			return true;
		}
		return false;
	}

	public bool isAmalgamate()
	{
		if (ac.currentEnemy.enemyType == enemyType.bigBoss12V1 || ac.currentEnemy.enemyType == enemyType.bigBoss12V2 || ac.currentEnemy.enemyType == enemyType.bigBoss12V3 || ac.currentEnemy.enemyType == enemyType.bigBoss12V4)
		{
			return true;
		}
		return false;
	}

	public bool isRat()
	{
		if (ac.currentEnemy.enemyType == enemyType.finalBoss)
		{
			return true;
		}
		return false;
	}

	public bool isTraitor()
	{
		if (ac.currentEnemy.enemyType == enemyType.finalfinalboss)
		{
			return true;
		}
		return false;
	}

	public void guardianAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (enemyAttackTimer > ac.currentEnemy.attackRate)
		{
			float num = 0f;
			enemyAttackTimer = 0f;
			growCount++;
			float num2 = 1f + (float)growCount / 100f;
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
		}
	}

	public void beastAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		if (growCount % 10 == 3)
		{
			doAura();
			return;
		}
		int num3 = Random.Range(1, 5);
		if (auraID == 2)
		{
			num = attack(2f * num2);
			log.AddEvent(ac.currentEnemy.name + " performs a POWER SMASH for " + character.display(num) + " damage!", 2);
			return;
		}
		switch (num3)
		{
		case 1:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	public void doAura()
	{
		int min = 0;
		int num = 0;
		switch (ac.currentEnemy.enemyType)
		{
		default:
			return;
		case enemyType.bigBoss6V1:
			num = 3;
			break;
		case enemyType.bigBoss6V2:
			num = 4;
			break;
		case enemyType.bigBoss6V3:
			num = 5;
			break;
		case enemyType.bigBoss6V4:
			num = 6;
			break;
		case enemyType.boss7Guardian:
			return;
		}
		switch (auraID = Random.Range(min, num + 1))
		{
		case 1:
			log.AddEvent(ac.currentEnemy.name + " casts HYPER RED ANIME AURA! They start healing super fast!", 2);
			break;
		case 2:
			log.AddEvent(ac.currentEnemy.name + " equips the POWER SMASH badge, oh crap! This is gonna hurt!", 2);
			break;
		case 3:
			log.AddEvent(ac.currentEnemy.name + " start vomiting grey goop all over, and begins rolling around in it!", 2);
			log.AddEvent("Oh snap - it's grown a layer of metal armor!", 2);
			break;
		case 4:
			log.AddEvent(ac.currentEnemy.name + " pulls out an alarm clock from one of its slimy folds and eats it! WTF?", 2);
			log.AddEvent("You feel like everything has sped up around you! Or are you slower? ", 2);
			break;
		case 5:
			log.AddEvent(ac.currentEnemy.name + " projectile vomits a lump of rubbery slime and slathers it all over its sluggish body!", 2);
			log.AddEvent("Be careful how you attack it!", 2);
			break;
		case 6:
			log.AddEvent(ac.currentEnemy.name + " rips a rancid smelling fart! You double over, gagging on the smell!", 2);
			log.AddEvent("You feel this putrid cloud sapping away your health!", 2);
			break;
		}
	}

	public void nerdAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (enemyAttackTimer > ac.currentEnemy.attackRate)
		{
			float num = 0f;
			enemyAttackTimer = 0f;
			growCount++;
			float num2 = 1f + (float)growCount / 100f;
			if (growCount % 8 == 3)
			{
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " gives you a left hook for " + character.display(num) + " damage!", 2);
				log.AddEvent("At the same time, the Nerd slips a Power Glove onto their right hand!", 2);
				log.AddEvent("Watch out, this is gonna be bad!", 2);
			}
			else if (growCount % 8 == 4)
			{
				num = attack(5f * num2);
				log.AddEvent(ac.currentEnemy.name + " gives you a taste of the Power Glove for " + character.display(num) + " damage!", 2);
				log.AddEvent("They hit you so hard their glove broke! You're safe for a little while longer. ", 2);
			}
			else if (growCount % 8 == 7)
			{
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + "attacked for " + character.display(num) + " damage!", 2);
				growCount += 8;
				log.AddEvent("The Greasy Nerd opens up CheatEngine on their PC and hacks NGU, raising their power by 8%! ", 2);
				nerdHacks++;
			}
			switch (Random.Range(1, 5))
			{
			case 1:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 2:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 3:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 4:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			default:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
		}
	}

	public void rapidExplosions(float time)
	{
	}

	public void godmotherAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (explosionMode)
		{
			if (enemyAttackTimer > ac.currentEnemy.attackRate / 5f)
			{
				enemyAttackTimer = 0f;
				float num = 1f + (float)growCount / 100f;
				float num2 = attack(25f * num);
				log.AddEvent(ac.currentEnemy.name + " EXPLODES FOR " + character.display(num2) + " DAMAGE!", 2);
				explosionCount++;
				if (explosionCount >= 4)
				{
					explosionCount = 0;
					explosionMode = false;
				}
			}
		}
		else
		{
			if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
			{
				return;
			}
			float num3 = 0f;
			enemyAttackTimer = 0f;
			growCount++;
			float num4 = 1f + (float)growCount / 100f;
			if (growCount % 9 == 1 && kneeCapped)
			{
				kneeCapped = false;
				log.AddEvent("Your knees start to feel better again! Phew.", 2);
			}
			if (growCount % 9 == 3)
			{
				num3 = attack(1f * num4);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num3) + " damage!", 2);
				log.AddEvent(ac.currentEnemy.name + " starts glowing white! HIT THE FREAKIN' DECK!", 2);
				return;
			}
			if (growCount % 9 == 4)
			{
				log.AddEvent(ac.currentEnemy.name + " STARTS EXPLODING LIKE CRAZY!!!", 2);
				explosionMode = true;
				return;
			}
			if (growCount % 9 == 8)
			{
				num3 = attack(1f * num4);
				log.AddEvent(ac.currentEnemy.name + "attacked for " + character.display(num3) + " damage!", 2);
				log.AddEvent("The Godmother orders one of her goons to bash your knees with a baseball bat! OWIE OW OW!!", 2);
				log.AddEvent("Your move cooldowns have been crippled!", 2);
				kneeCapped = true;
				return;
			}
			switch (Random.Range(1, 5))
			{
			case 1:
				num3 = attack(1f * num4);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num3) + " damage!", 2);
				break;
			case 2:
				num3 = attack(1f * num4);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num3) + " damage!", 2);
				break;
			case 3:
				num3 = attack(1.5f * num4);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num3) + " damage!", 2);
				break;
			case 4:
				num3 = attack(1.5f * num4);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num3) + " damage!", 2);
				break;
			default:
				num3 = attack(1f * num4);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num3) + " damage!", 2);
				break;
			}
		}
	}

	public void exileAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		int num3 = 10;
		if (ac.currentEnemy.enemyType == enemyType.bigBoss9V2)
		{
			num3 = 9;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss9V3)
		{
			num3 = 8;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss9V4)
		{
			num3 = 7;
		}
		if (growCount % num3 == 4 && auraID == 1000)
		{
			num = attack(6f * num2);
			log.AddEvent(ac.currentEnemy.name + "'s buster unleashes a giant charge blast!", 2);
			log.AddEvent(ac.currentEnemy.name + " blasts you for " + character.display(num) + " damage!", 2);
			auraID = 0;
			return;
		}
		if (growCount % num3 == 3)
		{
			doExileAura();
			return;
		}
		switch (Random.Range(1, 5))
		{
		case 1:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	public void doExileAura()
	{
		int min = 1;
		int num = 1;
		float num2 = 0f;
		float num3 = 1f + (float)growCount / 100f;
		switch (ac.currentEnemy.enemyType)
		{
		default:
			return;
		case enemyType.bigBoss9V1:
			num = 2;
			break;
		case enemyType.bigBoss9V2:
			num = 3;
			break;
		case enemyType.bigBoss9V3:
			num = 4;
			break;
		case enemyType.bigBoss9V4:
			num = 5;
			break;
		}
		int num4 = Random.Range(min, num);
		auraID = 0;
		switch (num4)
		{
		case 1:
			auraID = 1000;
			log.AddEvent(ac.currentEnemy.name + " starts charging up the Buster Arm! GET DOWN!!", 2);
			break;
		case 2:
			auraID = 6;
			log.AddEvent(ac.currentEnemy.name + " gores you with their antlers! You're bleeding heavily now!", 2);
			break;
		case 3:
			log.AddEvent(ac.currentEnemy.name + " raises their antennae and controls your mind! You can't control your body at all!", 2);
			player.paralyzed(2f);
			break;
		case 4:
			num2 = attack(2f * num3);
			heal(0.1f);
			log.AddEvent(ac.currentEnemy.name + " wraps their tentacle around you and saps away your life!", 2);
			log.AddEvent(ac.currentEnemy.name + " hits you for " + character.display(num2) + " damage and heals by 10%!", 2);
			break;
		}
	}

	public void heal(float percent)
	{
		if (percent < 0f || percent > 1f)
		{
			return;
		}
		float num = ac.currentEnemy.maxHP * percent;
		if ((double)ac.currentEnemy.curHP + (double)num >= 3.4028234663852886E+38)
		{
			ac.currentEnemy.curHP = ac.currentEnemy.maxHP;
			return;
		}
		ac.currentEnemy.curHP += num;
		if (ac.currentEnemy.curHP > ac.currentEnemy.maxHP)
		{
			ac.currentEnemy.curHP = ac.currentEnemy.maxHP;
		}
	}

	public void itHungersAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		if (glopCount == 0)
		{
			checkAndUseGlop();
		}
		if (glopCount <= 0)
		{
			invincible = true;
			growCount += 400;
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " DEVOURS YOU for " + character.display(num) + " damage!", 2);
			log.AddEvent(ac.currentEnemy.name + " it's completely invulnerable to your attacks!", 2);
			log.AddEvent("If only you could poison it with some bad cooking!", 2);
			return;
		}
		glopCount--;
		invincible = false;
		switch (Random.Range(1, 6))
		{
		case 1:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 5:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	public void checkAndUseGlop()
	{
		for (int i = 0; i < character.inventory.inventory.Count; i++)
		{
			if (character.inventory.inventory[i].id == 372 && character.inventory.inventory[i].removable)
			{
				character.inventory.deleteItem(i);
				character.inventoryController.updateItem(i);
				glopCount += 5;
				break;
			}
		}
	}

	private void rockLobsterAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (enemyAttackTimer > ac.currentEnemy.attackRate)
		{
			float num = 0f;
			enemyAttackTimer = 0f;
			growCount++;
			float num2 = 1f + (float)growCount / 100f;
			int num3 = 1;
			if (ac.currentEnemy.enemyType == enemyType.bigBoss11V2)
			{
				num3 = 2;
			}
			if (ac.currentEnemy.enemyType == enemyType.bigBoss11V3)
			{
				num3 = 3;
			}
			if (ac.currentEnemy.enemyType == enemyType.bigBoss11V4)
			{
				num3 = 4;
			}
			List<string> list = new List<string>();
			list.Add("SHELLSHOCK");
			if (num3 >= 2)
			{
				list.Add("HARD KNOCK");
			}
			if (num3 >= 3)
			{
				list.Add("ELECTRIC EEL");
			}
			if (num3 >= 4)
			{
				list.Add("ROCK LOBSTER");
			}
			int num4 = Random.Range(0, 5);
			string text = list[Random.Range(0, list.Count)];
			switch (num4)
			{
			case 0:
				num = attack(1f * num2);
				log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 1:
				num = attack(1f * num2);
				log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 2:
				num = attack(1f * num2);
				log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 3:
				num = attack(1.5f * num2);
				log.AddEvent(text + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 4:
				num = attack(1.5f * num2);
				log.AddEvent(text + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			default:
				num = attack(1f * num2);
				log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
		}
	}

	private void amalgamateAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		growCount++;
		float num2 = 1f + (float)growCount / 100f;
		int num3 = 1;
		if (ac.currentEnemy.enemyType == enemyType.bigBoss12V2)
		{
			num3 = 2;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss12V3)
		{
			num3 = 3;
		}
		if (ac.currentEnemy.enemyType == enemyType.bigBoss12V4)
		{
			num3 = 4;
		}
		int num4 = character.inventoryController.apathyCheck();
		if (num4 < 0 && num3 >= 4)
		{
			invincible = true;
			growCount += 400;
			if (growCount <= 536870911)
			{
				growCount *= 2;
			}
			num = attack(1f * num2);
			log.AddEvent("UUG THE UNMENTIONABLE attacked for " + character.display(num) + " damage!", 2);
			log.AddEvent("UUG THE UNMENTIONABLE also screeches horrible insults at you - He even calls you a Droop ;_;!", 2);
			log.AddEvent("You fall over crying as UUG feeds off your emotions and grows immensely in power.", 2);
			log.AddEvent("Dammit, you forgot your ring! Anyways, time to die.", 2);
			return;
		}
		if (num4 < 100 && num3 >= 4)
		{
			if (growCount < 536870911)
			{
				growCount += 100 - num4;
				growCount = Mathf.CeilToInt((float)growCount * (2f - (float)num4 / 100f));
			}
			log.AddEvent("UUG THE UNMENTIONABLE also screeches horrible insults at you - He even calls you a Droop ;_;!", 2);
			log.AddEvent("You manage to resist the worst of UUG's emotional abuse, but he's still growing stronger!", 2);
		}
		else if (num4 >= 100 && num3 >= 4)
		{
			log.AddEvent("UUG THE UNMENTIONABLE screeches horrible insults at you - He even calls you a Droop ;_;! ", 2);
			log.AddEvent("Using your ring of Apathy, you channel your inner Honey Badger and stop giving a fuck. UUG looks dismayed!", 2);
		}
		List<string> list = new List<string>();
		list.Add("Gordon Ramsay Bolton");
		if (num3 >= 2)
		{
			list.Add("Corrupted Tree");
		}
		if (num3 >= 3)
		{
			list.Add("Jake From Accounting");
		}
		if (num3 >= 4)
		{
			list.Add("UUG the Unmentionable");
		}
		int num5 = Random.Range(0, 5);
		string text = list[Random.Range(0, list.Count)];
		if (growCount % 20 == 3 && num3 >= 2)
		{
			player.debuffAttack(1.3f, 12f);
			player.debuffAttack(1.3f, 12f);
			log.AddEvent("GRAND CORRUPTED TREE shoots out a cloud of spores! Your arms feel so heavy all of a sudden...", 2);
			return;
		}
		if (growCount % 20 == 10)
		{
			player.paralyzed(4f);
			log.AddEvent("GORDON RAMSAY BOLTON starts screaming obscenities at you and you're frozen in fear!", 2);
			return;
		}
		if (growCount % 20 == 15 && num3 >= 3)
		{
			disableMove();
			log.AddEvent("JAKE FROM ACCOUNTING tucks his arms into his shirt and starts flapping his empty sleeves back and forth!", 2);
			log.AddEvent("You're so confused by this display that one of your moves has been disabled!", 2);
			return;
		}
		switch (num5)
		{
		case 0:
			num = attack(1f * num2);
			log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 1:
			num = attack(1f * num2);
			log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1.5f * num2);
			log.AddEvent(text + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(text + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(text + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}

	private void ratAI()
	{
		enemyAttackTimer += Time.deltaTime;
		float num = 0f;
		float num2 = 1f + (float)growCount / 100f;
		if (rapidMode && enemyAttackTimer > ac.currentEnemy.attackRate * 0.15f)
		{
			enemyAttackTimer = 0f;
			locustCount++;
			num = attack(0.45f * num2);
			log.AddEvent("A TRILLION RATS SLASH YOUR FACE FOR " + character.display(num) + " DAMAGE!", 2);
			if (locustCount >= 0)
			{
				rapidMode = false;
			}
		}
		else
		{
			if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
			{
				return;
			}
			enemyAttackTimer = 0f;
			growCount++;
			locustCount++;
			Debug.Log(locustCount);
			Debug.Log(rapidMode);
			if (skipturn < 0)
			{
				skipturn++;
				if (skipturn == 0)
				{
					rapidMode = true;
					locustCount = -10;
				}
				return;
			}
			int num3 = Random.Range(0, 6);
			Debug.Log("move" + num3);
			switch (num3)
			{
			case 1:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 2:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 3:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			case 4:
				num = attack(1.5f * num2);
				log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
				break;
			case 5:
				if (locustCount < 10)
				{
					num = attack(1f * num2);
					log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				}
				else
				{
					log.AddEvent(ac.currentEnemy.name + " summons a TRILLION ANGRY RATS  TO EAT YOUR FACE! INCOMING!!!", 2);
					skipturn = -1;
				}
				break;
			default:
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
		}
	}

	private void traitorAI()
	{
		enemyAttackTimer += Time.deltaTime;
		if (!(enemyAttackTimer > ac.currentEnemy.attackRate))
		{
			return;
		}
		float num = 0f;
		enemyAttackTimer = 0f;
		if (growRate < 1)
		{
			growCount++;
		}
		else
		{
			growCount += growRate;
		}
		float num2 = 1f + (float)growCount / 100f;
		switch (Random.Range(0, 9))
		{
		case 1:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 2:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 3:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		case 4:
			num = attack(1.5f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a power attack for " + character.display(num) + " damage!", 2);
			break;
		case 5:
			num = attack(2f * num2);
			log.AddEvent(ac.currentEnemy.name + " unleashed a SUPER power attack for " + character.display(num) + " damage!", 2);
			break;
		case 6:
			if (character.adventure.curHP > 0.2f * character.totalAdvHP())
			{
				character.adventure.curHP = 0.2f * character.totalAdvHP();
				log.AddEvent(ac.currentEnemy.name + " unleashes the power of the MacGuffins to reduce your HP to critical levels!");
			}
			else
			{
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			}
			break;
		case 7:
			if (invincibleCount > 5)
			{
				num = attack(1f * num2);
				log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
				break;
			}
			invincibleCount += 2;
			if (invincibleCount > 2)
			{
				log.AddEvent(ac.currentEnemy.name + "'s MacGuffins glow Green and the energy shield strengthens!");
			}
			else
			{
				log.AddEvent(ac.currentEnemy.name + "'s MacGuffins glow Green and an energy shield materializes!");
			}
			break;
		case 8:
			growRate++;
			log.AddEvent(ac.currentEnemy.name + " glows red! Theyt've permanently sped up their power growth!");
			break;
		default:
			num = attack(1f * num2);
			log.AddEvent(ac.currentEnemy.name + " attacked for " + character.display(num) + " damage!", 2);
			break;
		}
	}
}
