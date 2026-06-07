using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Character character;

	public AdventureController ac;

	public InventoryController inventoryController;

	public PlayerLog log;

	public bool isBlocking;

	public bool isParrying;

	public bool isCharged;

	public bool autoAttacking;

	public float chargeFactor = 1f;

	public float offenseBuffFactor = 1f;

	public float defenseBuffFactor = 1f;

	public float offenseDebuffFactor = 1f;

	public float defenseDebuffFactor = 1f;

	public float offenseDebuffTime;

	public float defenseDebuffTime;

	public float atkDebuff;

	public float defDebuff;

	public bool defenseBuff;

	public bool offenseBuff;

	public bool ultimateBuff;

	public float blockTime = -1f;

	public float defenseBuffTime = -1f;

	public float offenseBuffTime = -1f;

	public float ultimateBuffTime = -1f;

	public float megaBuffTime = -1f;

	public float paralyzeTime;

	public float hyperRegenTime = -1f;

	public bool regularDisabled;

	public bool strongDisabled;

	public bool pierceDisabled;

	public bool ultimateDisabled;

	public bool defBuffDisabled;

	public bool offBuffDisabled;

	public bool healDisabled;

	public bool ultiBuffDisabled;

	public bool megaBuffDisabled;

	public bool canUseMove { get; set; }

	public float moveTimer { get; set; }

	public void Start()
	{
		defenseBuffTime = -1f;
		offenseBuffTime = -1f;
		ultimateBuffTime = -1f;
		megaBuffTime = -1f;
		blockTime = -1f;
	}

	public void Update()
	{
		if (paralyzeTime > 0f)
		{
			paralyzeTime -= Time.deltaTime;
			if (paralyzeTime <= 0f)
			{
				paralyzeTime = 0f;
				log.AddEvent("You've broken out of the paralyze effect! Start kicking some ass, pronto!");
			}
			return;
		}
		if (blockTime >= 0f)
		{
			blockTime += Time.deltaTime;
		}
		if (defenseBuffTime >= 0f)
		{
			defenseBuffTime += Time.deltaTime;
		}
		if (offenseBuffTime >= 0f)
		{
			offenseBuffTime += Time.deltaTime;
		}
		if (ultimateBuffTime >= 0f)
		{
			ultimateBuffTime += Time.deltaTime;
		}
		if (megaBuffTime >= 0f)
		{
			megaBuffTime += Time.deltaTime;
		}
		if (hyperRegenTime >= 0f)
		{
			hyperRegenTime -= Time.deltaTime;
		}
		if (defenseDebuffTime >= 0f)
		{
			defenseDebuffTime -= Time.deltaTime;
		}
		if (offenseDebuffTime >= 0f)
		{
			offenseDebuffTime -= Time.deltaTime;
		}
		if (defenseBuffTime >= character.defenseBuffDuration())
		{
			defenseBuffTime = -1f;
			defenseBuffFactor /= 1.2f;
		}
		if (offenseBuffTime >= character.offenseBuffDuration())
		{
			offenseBuffTime = -1f;
			offenseBuffFactor /= 1.2f;
		}
		if (ultimateBuffTime >= character.ultimateBuffDuration())
		{
			ultimateBuffTime = -1f;
			offenseBuffFactor /= 1.3f;
			defenseBuffFactor /= 1.3f;
		}
		if (megaBuffTime >= character.megaBuffDuration())
		{
			megaBuffTime = -1f;
			offenseBuffFactor /= 1.2f;
			defenseBuffFactor /= 1.2f;
		}
		if (hyperRegenTime <= 0f)
		{
			hyperRegenTime = -1f;
		}
		if (defenseDebuffTime <= 0f && defenseDebuffTime != -1f)
		{
			defenseDebuffTime = -1f;
			defenseDebuffFactor *= defDebuff;
		}
		if (offenseDebuffTime <= 0f && offenseDebuffTime != -1f)
		{
			offenseDebuffTime = -1f;
			offenseDebuffFactor *= atkDebuff;
		}
		moveTimer -= Time.deltaTime;
		if (moveTimer <= 0f)
		{
			canUseMove = true;
			moveTimer = 0f;
		}
		if (blockTime >= 3f)
		{
			isBlocking = false;
		}
	}

	public void reset()
	{
		offenseDebuffFactor = 1f;
		defenseDebuffFactor = 1f;
		defenseDebuffTime = -1f;
		offenseDebuffTime = -1f;
		atkDebuff = 1f;
		defDebuff = 1f;
	}

	public void paralyzed(float time)
	{
		paralyzeTime = time;
	}

	public float takeDamage(float damage)
	{
		if (isBlocking)
		{
			damage = damage / (1f / character.advancedTrainingController.block.blockBonus(0)) / chargeFactor;
			chargeFactor = 1f;
		}
		if (isParrying)
		{
			damage /= character.adventureController.parryMulti * chargeFactor;
			isParrying = false;
			if (character.inventory.itemList.beast1complete)
			{
				attack(3f);
			}
			else
			{
				attack(1f);
			}
			chargeFactor = 1f;
		}
		if (character.adventure.beastModeOn)
		{
			damage *= 3f;
		}
		damage = Mathf.Floor(damage / defenseBuffFactor / defenseDebuffFactor);
		character.adventure.curHP -= damage;
		if (damage > character.stats.highestDamageTaken && character.adventure.curHP > 0f)
		{
			character.stats.highestDamageTaken = damage;
		}
		return damage;
	}

	public float minDamage()
	{
		return 0f;
	}

	public float baseDamage()
	{
		return character.totalAdvAttack() - ac.currentEnemy.defense / 2f;
	}

	public float baseDamage(float pierceFactor)
	{
		return character.totalAdvAttack() - ac.currentEnemy.defense / pierceFactor;
	}

	public bool moveCheck()
	{
		return !paralyzeCheck();
	}

	public bool paralyzeCheck()
	{
		if (paralyzeTime > 0f)
		{
			return true;
		}
		return false;
	}

	public void idleAttack()
	{
		ac.enemyAI.lastAttackID = 1;
		float num = Random.Range(0.8f, 1.2f);
		float num2 = Mathf.Max(minDamage(), baseDamage());
		num2 *= num;
		num2 *= character.idleAttackPower();
		num2 = ac.enemyAI.takeDamage(num2);
		log.AddEvent(damageText(num2));
	}

	public void attack(float factor)
	{
		ac.enemyAI.lastAttackID = 2;
		float num = Random.Range(0.8f, 1.2f);
		float num2 = Mathf.Max(minDamage(), baseDamage());
		num2 = num2 * offenseBuffFactor * offenseDebuffFactor * chargeFactor * num * factor;
		chargeFactor = 1f;
		num2 = ac.enemyAI.takeDamage(num2);
		log.AddEvent(damageText(num2));
	}

	public void regularAttack()
	{
		if (ac.currentEnemy != null)
		{
			ac.enemyAI.lastAttackID = 3;
			float num = Random.Range(0.8f, 1.2f);
			float num2 = Mathf.Max(minDamage(), baseDamage());
			num2 = num2 * offenseBuffFactor * offenseDebuffFactor * chargeFactor * character.adventureController.regAttackMulti * num;
			chargeFactor = 1f;
			num2 = ac.enemyAI.takeDamage(num2);
			log.AddEvent(damageText(num2));
		}
	}

	public void strongAttack()
	{
		if (ac.currentEnemy != null)
		{
			ac.enemyAI.lastAttackID = 4;
			float num = Random.Range(0.8f, 1.2f);
			float num2 = Mathf.Max(minDamage(), baseDamage());
			num2 = num2 * offenseBuffFactor * chargeFactor * character.adventureController.strongAttackMulti * num;
			chargeFactor = 1f;
			num2 = ac.enemyAI.takeDamage(num2);
			log.AddEvent(damageText(num2));
		}
	}

	public void pierceAttack()
	{
		if (ac.currentEnemy != null)
		{
			ac.enemyAI.lastAttackID = 5;
			float num = Random.Range(0.8f, 1.2f);
			float num2 = Mathf.Max(minDamage(), baseDamage(3f));
			num2 = num2 * offenseBuffFactor * chargeFactor * character.adventureController.strongAttackMulti * num;
			chargeFactor = 1f;
			num2 = ac.enemyAI.takeDamage(num2);
			log.AddEvent(damageText(num2));
		}
	}

	public void ultimateAttack()
	{
		if (ac.currentEnemy != null)
		{
			ac.enemyAI.lastAttackID = 6;
			float num = Random.Range(0.8f, 1.2f);
			float num2 = Mathf.Max(minDamage(), baseDamage());
			num2 = num2 * offenseBuffFactor * chargeFactor * character.ultimateAttackPower() * num;
			chargeFactor = 1f;
			num2 = ac.enemyAI.takeDamage(num2);
			log.AddEvent(damageText(num2));
		}
	}

	public void block()
	{
		blockTime = 0f;
		isBlocking = true;
	}

	public void parry()
	{
		isParrying = true;
	}

	public void charge()
	{
		chargeFactor = character.adventureController.chargeMulti;
		if (character.inventory.itemList.megaComplete)
		{
			chargeFactor *= 1.1f;
		}
	}

	public void heal()
	{
		float num = character.totalAdvHP();
		float num2 = num * 0.15f;
		if (character.adventure.curHP + num2 > num)
		{
			num2 = num - character.adventure.curHP;
		}
		character.adventure.curHP += num2;
		log.AddEvent("You healed yourself for " + character.display(num2) + " HP!");
	}

	public void buffOffense()
	{
		offenseBuffTime = 0f;
		offenseBuffFactor *= 1.2f;
	}

	public void buffDefense()
	{
		defenseBuffTime = 0f;
		defenseBuffFactor *= 1.2f;
	}

	public void buffUltimate()
	{
		ultimateBuffTime = 0f;
		offenseBuffFactor *= 1.3f;
		defenseBuffFactor *= 1.3f;
		float value = Random.value;
		if (value > 0.67f)
		{
			log.AddEvent("You unleash all your nerd rage, massively buffing your Power and Toughness.");
		}
		else if (value > 0.33f)
		{
			log.AddEvent("You start to glow and your hair turns blonde. Somehow this makes your Power and Toughness a lot stronger!");
		}
		else if (value > 0.01f)
		{
			log.AddEvent("You strain to power yourself up but overdo it- you sharted a little bit.");
			log.AddEvent("You still got the Power and Toughness buff though, don't worry!");
		}
		else
		{
			log.AddEvent("You raised your Power and Toughness by some number. Woo.");
			log.AddEvent("This message was programmed to come up rarely, and also to be boring.");
		}
	}

	public void megaBuff()
	{
		megaBuffTime = 0f;
		offenseBuffFactor *= 1.2f;
		defenseBuffFactor *= 1.2f;
		log.AddEvent("You have unleashed MEGABUFF. May your foes tremble in fear for the next 15 seconds!");
	}

	public void move69()
	{
		if (character.adventure.move69Used < 69)
		{
			character.adventure.move69Used++;
		}
		if (character.adventure.move69Used < 69)
		{
			log.AddEvent("A million realties collide in your mind, echoing a unified message: " + sixtyNineWords(character.adventure.move69Used));
		}
		else
		{
			log.AddEvent(character.itemInfo.makeTitanLevelledLoot(481, 100) + " NEARS.");
		}
	}

	public string sixtyNineWords(int number)
	{
		switch (number)
		{
		case 1:
			return "ONE";
		case 2:
			return "TWO";
		case 3:
			return "THREE";
		case 4:
			return "FOUR";
		case 5:
			return "FIVE";
		case 6:
			return "SIX";
		case 7:
			return "SEVEN";
		case 8:
			return "EIGHT";
		case 9:
			return "NINE";
		case 10:
			return "TEN";
		case 11:
			return "ELEVEN";
		case 12:
			return "TWELVE";
		case 13:
			return "THIRTEEN";
		case 14:
			return "FOURTEEN";
		case 15:
			return "FIFTEEN";
		case 16:
			return "SIXTEEN";
		case 17:
			return "SEVENTEEN";
		case 18:
			return "EIGHTEEN";
		case 19:
			return "NINETEEN";
		case 20:
			return "TWENTY";
		case 21:
			return "TWENTY ONE";
		case 22:
			return "TWENTY TWO";
		case 23:
			return "TWENTY THREE";
		case 24:
			return "TWENTY FOUR";
		case 25:
			return "TWENTY FIVE";
		case 26:
			return "TWENTY SIX";
		case 27:
			return "TWENTY SEVEN";
		case 28:
			return "TWENTY EIGHT";
		case 29:
			return "TWENTY NINE";
		case 30:
			return "THIRTY";
		case 31:
			return "THIRTY ONE";
		case 32:
			return "THIRTY TWO";
		case 33:
			return "THIRTY THREE";
		case 34:
			return "THIRTY FOUR";
		case 35:
			return "THIRTY FIVE";
		case 36:
			return "THIRTY SIX";
		case 37:
			return "THIRTY SEVEN";
		case 38:
			return "THIRTY EIGHT";
		case 39:
			return "THIRTY NINE";
		case 40:
			return "FORTY";
		case 41:
			return "FORTY ONE";
		case 42:
			return "FORTY TWO";
		case 43:
			return "FORTY THREE";
		case 44:
			return "FORTY FOUR";
		case 45:
			return "FORTY FIVE";
		case 46:
			return "FORTY SIX";
		case 47:
			return "FORTY SEVEN";
		case 48:
			return "FORTY EIGHT";
		case 49:
			return "FORTY NINE";
		case 50:
			return "FIFTY";
		case 51:
			return "FIFTY ONE";
		case 52:
			return "FIFTY TWO";
		case 53:
			return "FIFTY THREE";
		case 54:
			return "FIFTY FOUR";
		case 55:
			return "FIFTY FIVE";
		case 56:
			return "FIFTY SIX";
		case 57:
			return "FIFTY SEVEN";
		case 58:
			return "FIFTY EIGHT";
		case 59:
			return "FIFTY NINE";
		case 60:
			return "SIXTY";
		case 61:
			return "SIXTY ONE";
		case 62:
			return "SIXTY TWO";
		case 63:
			return "SIXTY THREE";
		case 64:
			return "SIXTY FOUR";
		case 65:
			return "SIXTY FIVE";
		case 66:
			return "SIXTY SIX";
		case 67:
			return "SIXTY SEVEN";
		case 68:
			return "SIXTY EIGHT";
		default:
			return "Butts";
		}
	}

	public void paralyzeEnemy()
	{
		if (ac.currentEnemy != null)
		{
			ac.enemyAI.paralyzed(character.paralyzePower());
			log.AddEvent("You gaze longingly into the eyes of your foe in a really creepy way. They freeze in terror for a moment!");
		}
	}

	public void toggleBeastMode()
	{
		character.adventure.beastModeOn = !character.adventure.beastModeOn;
		if (character.adventure.beastModeOn)
		{
			log.AddEvent("BEAST MODE ACTIVATED! BLOOOOOOOOOOOOOOOOOOOOOOOOD!!!!!!!");
		}
		else
		{
			log.AddEvent("You focus your thoughts on the badly drawn kitten and calm yourself down again. Ah....");
		}
	}

	public void hyperRegen()
	{
		hyperRegenTime = 5f;
	}

	public void debuffAttack(float amount, float time)
	{
		atkDebuff = amount;
		offenseDebuffFactor /= atkDebuff;
		offenseDebuffTime = time;
	}

	public void debuffDefense(float amount, float time)
	{
		defDebuff = amount;
		defenseDebuffFactor /= defDebuff;
		defenseDebuffTime = time;
	}

	public void usedMove()
	{
		canUseMove = false;
		if (character.inventory.itemList.redLiquidComplete)
		{
			moveTimer = 0.8f;
		}
		else
		{
			moveTimer = 1f;
		}
	}

	private string damageText(float damage)
	{
		if (damage > character.stats.highestDamageDealt)
		{
			character.stats.highestDamageDealt = damage;
		}
		string text = "You hit " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		if (damage > 1E+38f)
		{
			text = "You NGU-BLASTED " + ac.currentEnemy.name + "'s ass for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+37f)
		{
			text = "You outsource your damage message for " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+37f)
		{
			text = "You compact " + ac.currentEnemy.name + " into a singularity for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+36f)
		{
			text = "You rip out all of " + ac.currentEnemy.name + "'s teeth for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+36f)
		{
			text = "You reenact how babies are made to " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+35f)
		{
			text = "You give " + ac.currentEnemy.name + " a bear-hug for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+35f)
		{
			text = "You spontaneously combust " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+34f)
		{
			text = "You combine your Energy, Magic & " + character.res3.res3Name + " at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+34f)
		{
			text = "You discombobulated " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+33f)
		{
			text = "You soil " + ac.currentEnemy.name + "'s underpants for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+33f)
		{
			text = "You mine the block " + ac.currentEnemy.name + " was standing on for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+32f)
		{
			text = "You combine all your previous attacks onto " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+32f)
		{
			text = "You convince " + ac.currentEnemy.name + " to hug a woodchipper for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+31f)
		{
			text = "You mess with " + ac.currentEnemy.name + "'s wandoos update settings for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+31f)
		{
			text = "You YEETED " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+30f)
		{
			text = "You masticate onto " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! No I said MASTICATE";
		}
		else if (damage > 1E+30f)
		{
			text = "You sic your trusty battle corgi onto " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+29f)
		{
			text = "You tar and feather " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+29f)
		{
			text = "You carve your initials onto " + ac.currentEnemy.name + "'s ass for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+28f)
		{
			text = "You shoot a rubber band at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+28f)
		{
			text = "You flip " + ac.currentEnemy.name + " the bird for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+27f)
		{
			text = "You unfriended " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! :(";
		}
		else if (damage > 1E+27f)
		{
			text = "You match with " + ac.currentEnemy.name + " on a dating site for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+26f)
		{
			text = "You throw a temper tantrum at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+26f)
		{
			text = "You glare menacingly at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+25f)
		{
			text = "You explain anime at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+25f)
		{
			text = "You kickflip over " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! Totally Awesome!";
		}
		else if (damage > 3E+24f)
		{
			text = "You remove " + ac.currentEnemy.name + "'s kidney for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+24f)
		{
			text = "You slap " + ac.currentEnemy.name + " with an eggplant emoji for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+23f)
		{
			text = "You hurl a moon at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+23f)
		{
			text = "You prank call " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+22f)
		{
			text = ac.currentEnemy.name + " lost " + character.display(damage) + " HP. That's it.";
		}
		else if (damage > 1E+22f)
		{
			text = "You splash random fluids from the Beast on " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+21f)
		{
			text = "You inflict bodily harm onto " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+21f)
		{
			text = "You boop " + ac.currentEnemy.name + " gently on the nose for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+20f)
		{
			text = "You rolled a nat 20 and crit " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+20f)
		{
			text = "You crush " + ac.currentEnemy.name + " with the might of your EVIL NGUs for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+19f)
		{
			text = "You trick " + ac.currentEnemy.name + " into playing a crappy idle game for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+19f)
		{
			text = "You sent " + ac.currentEnemy.name + " back to the shadow realm for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+18f)
		{
			text = "You beat " + ac.currentEnemy.name + " with the remains of the last foe for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+18f)
		{
			text = "You make " + ac.currentEnemy.name + " step on a lego for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+17f)
		{
			text = "You throw POCKET SAND at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+17f)
		{
			text = "You slap your sticky foot at " + ac.currentEnemy.name + "'s tushy for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+16f)
		{
			text = "You humiliate " + ac.currentEnemy.name + " with a low-effort damage message for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+16f)
		{
			text = "You give " + ac.currentEnemy.name + " a prostate exam with a cactus for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+15f)
		{
			text = "You tell " + ac.currentEnemy.name + " their parents don't love them for " + character.display(damage) + " emotional damage!";
		}
		else if (damage > 1E+15f)
		{
			text = "You roar at " + ac.currentEnemy.name + " like a sexual tyrannosaur for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+14f)
		{
			text = "You throw a stupid newbie at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+14f)
		{
			text = "You lightly tapped " + ac.currentEnemy.name + " and exploded them for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+13f)
		{
			text = "You dunked on " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+13f)
		{
			text = "You drew " + ac.currentEnemy.name + " like one of your french girls for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+12f)
		{
			text = "You gave " + ac.currentEnemy.name + " an atomic wedgie for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+12f)
		{
			text = "You scowled at " + ac.currentEnemy.name + " with all your might for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+11f)
		{
			text = "You ground up " + ac.currentEnemy.name + " into a fine paste for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+11f)
		{
			text = "You chewed up " + ac.currentEnemy.name + "'s right pinky for " + character.display(damage) + " damage!";
		}
		else if (damage > 3E+10f)
		{
			text = "You mangled " + ac.currentEnemy.name + "'s left pinky for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+10f)
		{
			text = "You peed on " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! Too far, dude.";
		}
		else if (damage > 3E+09f)
		{
			text = "You crashed two gigantic meteors into " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 1E+09f)
		{
			text = "You erased " + ac.currentEnemy.name + " from the timeline for " + character.display(damage) + " damage!";
		}
		else if (damage > 300000000f)
		{
			text = "You disappointed " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! :c";
		}
		else if (damage > 100000000f)
		{
			text = "You whacked " + ac.currentEnemy.name + "'s hands with a ruler for " + character.display(damage) + " damage!";
		}
		else if (damage > 50000000f)
		{
			text = "You sent " + ac.currentEnemy.name + " to the 43rd dimension for " + character.display(damage) + " damage!";
		}
		else if ((double)damage > 25000000.0)
		{
			text = "You compressed " + ac.currentEnemy.name + " into a black hole for " + character.display(damage) + " damage!";
		}
		else if (damage > 10240000f)
		{
			text = "You smacked " + ac.currentEnemy.name + " with the force of 1000 suns for " + character.display(damage) + " damage!";
		}
		else if (damage > 5120000f)
		{
			text = "You lightly tapped " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! Wait, what?";
		}
		else if (damage > 2560000f)
		{
			text = "You destroyed " + ac.currentEnemy.name + "'s family tree for " + character.display(damage) + " damage!";
		}
		else if (damage > 1280000f)
		{
			text = "You used Bubblebeam on " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! Super Effective!";
		}
		else if (damage > 640000f)
		{
			text = "You had carnal relations with " + ac.currentEnemy.name + "'s mother for " + character.display(damage) + " damage!";
		}
		else if (damage > 320000f)
		{
			text = "You sang horrible karaoke at " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 160000f)
		{
			text = "You insulted every single cell in " + ac.currentEnemy.name + "'s body individually for " + character.display(damage) + " damage!";
		}
		else if (damage > 80000f)
		{
			text = "You critically hit " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 40000f)
		{
			text = "You destroyed " + ac.currentEnemy.name + "'s sense of self worth for " + character.display(damage) + " damage!";
		}
		else if (damage > 20000f)
		{
			text = "You laid the smackdown on " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 10000f)
		{
			text = "You 'BOOM HEADSHOT'ed " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 6000f)
		{
			text = "You set every atom of " + ac.currentEnemy.name + "'s body on fire for " + character.display(damage) + " damage!";
		}
		else if (damage > 4000f)
		{
			text = "You ANNIHILATED " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 3000f)
		{
			text = "You disassembled " + ac.currentEnemy.name + " into a 500-piece lego set for " + character.display(damage) + " damage!";
		}
		else if (damage > 2000f)
		{
			text = "You melted " + ac.currentEnemy.name + " into a gross puddle of goo for " + character.display(damage) + " damage!";
		}
		else if (damage > 1000f)
		{
			text = "You FLORIFIED " + ac.currentEnemy.name + " for " + character.display(damage) + " damage! What does that even mean?";
		}
		else if (damage > 800f)
		{
			text = "You detonated " + ac.currentEnemy.name + " like a neutron star for " + character.display(damage) + " damage!";
		}
		else if (damage > 600f)
		{
			text = "You blew " + ac.currentEnemy.name + " into bits of shrapnel for " + character.display(damage) + " damage!";
		}
		else if (damage > 400f)
		{
			text = "You incinerated " + ac.currentEnemy.name + " into charred bits for " + character.display(damage) + " damage!";
		}
		else if (damage > 300f)
		{
			text = "You smashed " + ac.currentEnemy.name + "'s chest in for " + character.display(damage) + " damage!";
		}
		else if (damage > 200f)
		{
			text = "You cruelly dismembered " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 100f)
		{
			text = "You brutally massacred " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 80f)
		{
			text = "You decimated " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 60f)
		{
			text = "You crushed " + ac.currentEnemy.name + " for " + character.display(damage) + " damage!";
		}
		else if (damage > 40f)
		{
			text = "You slashed " + ac.currentEnemy.name + " deep for " + character.display(damage) + " damage!";
		}
		else if (damage > 30f)
		{
			text = "You attacked " + ac.currentEnemy.name + " viciously for " + character.display(damage) + " damage!";
		}
		else if (damage > 20f)
		{
			text = "You hit " + ac.currentEnemy.name + " extremely hard for " + character.display(damage) + " damage!";
		}
		else if (damage > 15f)
		{
			text = "You hit " + ac.currentEnemy.name + " very hard for " + character.display(damage) + " damage!";
		}
		else if (damage > 10f)
		{
			text = "You hit " + ac.currentEnemy.name + " hard for " + character.display(damage) + " damage!";
		}
		return "<color=green>" + text + "</color>";
	}

	public void clearDisableFlags()
	{
		ultiBuffDisabled = false;
		regularDisabled = false;
		strongDisabled = false;
		pierceDisabled = false;
		ultimateDisabled = false;
		defBuffDisabled = false;
		offBuffDisabled = false;
		healDisabled = false;
		megaBuffDisabled = false;
	}

	public void moveDisabled()
	{
		if (!ultimateDisabled)
		{
			ultimateDisabled = true;
		}
		else if (!healDisabled)
		{
			healDisabled = true;
		}
		else if (!pierceDisabled)
		{
			pierceDisabled = true;
		}
		else if (!ultiBuffDisabled)
		{
			ultiBuffDisabled = true;
		}
		else if (!strongDisabled)
		{
			strongDisabled = true;
		}
		else if (!offBuffDisabled)
		{
			offBuffDisabled = true;
		}
		else if (!regularDisabled)
		{
			regularDisabled = true;
		}
	}

	public float timeDilation(float oldTime)
	{
		if (ac.enemyAI.auraID == 4)
		{
			return oldTime / 2f;
		}
		if (ac.enemyAI.kneeCapped)
		{
			return oldTime / 3f;
		}
		return oldTime;
	}
}
