using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatBoostPurchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public Character character;

	public Text attackBoostText;

	public Text defenseBoostText;

	public ConfirmationBox box;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int attack10Cost = 30;

	private int attack100Cost = 300;

	private int attack1KCost = 3000;

	private int defense10Cost = 30;

	private int defense100Cost = 300;

	private int defense1KCost = 3000;

	public InputField attackInput;

	public Button attackBuyButton;

	public InputField defenseInput;

	public Button defenseBuyButton;

	private void Awake()
	{
		noAction = cancel;
	}

	private void Start()
	{
		updateStatPurchases();
	}

	private void cancel()
	{
	}

	public void refresh()
	{
		updateStatPurchases();
	}

	private void updateStatPurchases()
	{
		if (character.menuID == 35)
		{
			attackBoostText.text = "<b>Attack Boost For Rich Jerks:</b>\n" + NumberOutput.suffixFormat(100f * character.attackBoost, character.settings.numberDisplay) + " %";
			defenseBoostText.text = "<b>Defense Boost For Rich Jerks:</b>\n" + NumberOutput.suffixFormat(100f * character.defenseBoost, character.settings.numberDisplay) + " %";
			attackBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customAttackCost(character.settings.customAttackInput)) + " EXP";
			defenseBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customDefenseCost(character.settings.customDefenseInput)) + " EXP";
			attackInput.text = character.settings.customAttackInput.ToString();
			defenseInput.text = character.settings.customDefenseInput.ToString();
		}
	}

	public void attack10()
	{
		if (character.realExp < attack10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAttack10;
			box.displayBox("Are you sure you want to buy +10% boost to Attack for " + attack10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAttack10();
		}
	}

	private void buyAttack10()
	{
		character.realExp -= attack10Cost;
		character.attackBoost += 0.1f;
		tooltip.showTooltip("You successfully bought +10% to your attack stat! What a hero!", 1f);
		updateStatPurchases();
	}

	public void attack100()
	{
		if (character.realExp < attack100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAttack100;
			box.displayBox("Are you sure you want to buy +100% boost to Attack for " + attack100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAttack100();
		}
	}

	private void buyAttack100()
	{
		character.realExp -= attack100Cost;
		character.attackBoost += 1f;
		tooltip.showTooltip("You just bought +100% to your attack stat! Your mother and I are proud of you.", 2f);
		updateStatPurchases();
	}

	public void attack1K()
	{
		if (character.realExp < attack1KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAttack1K;
			box.displayBox("Are you sure you want to buy +1K% boost to Attack for " + attack1KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAttack1K();
		}
	}

	private void buyAttack1K()
	{
		character.realExp -= attack1KCost;
		character.attackBoost += 10f;
		tooltip.showTooltip("You just bought +1K% to your attack stat! :o", 2f);
		updateStatPurchases();
	}

	public void defense10()
	{
		if (character.realExp < defense10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDefense10;
			box.displayBox("Are you sure you want to buy +10% boost to Defense for " + defense10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDefense10();
		}
	}

	private void buyDefense10()
	{
		character.realExp -= defense10Cost;
		character.defenseBoost += 0.1f;
		tooltip.showTooltip("You just bought +10% to your defense stat! What a rockstar!", 1f);
		updateStatPurchases();
	}

	public void defense100()
	{
		if (character.realExp < defense100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDefense100;
			box.displayBox("Are you sure you want to buy +100% boost to Defense for " + defense100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDefense100();
		}
	}

	private void buyDefense100()
	{
		character.realExp -= defense100Cost;
		character.defenseBoost += 1f;
		tooltip.showTooltip("You just bought +100% to your defense stat! Turtle Mode Engaged!", 1f);
		updateStatPurchases();
	}

	public void defense1K()
	{
		if (character.realExp < defense1KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDefense1K;
			box.displayBox("Are you sure you want to buy +1K% boost to Defense for " + defense1KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDefense1K();
		}
	}

	private void buyDefense1K()
	{
		character.realExp -= defense1KCost;
		character.defenseBoost += 10f;
		tooltip.showTooltip("You just bought +1K% to your defense stat! TURTLE! TURTLE!", 1f);
		updateStatPurchases();
	}

	public void tryCustomAttack()
	{
		float num = character.settings.customAttackInput;
		long num2 = customAttackCost(num);
		if (num2 >= 0 && !(num < 0f))
		{
			if (character.realExp < num2)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomAttack;
				box.displayBox("Are you sure you want to buy +" + num + "% to your Attack stat for " + NumberOutput.expPrint(num2) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomAttack();
			}
		}
	}

	private void buyCustomAttack()
	{
		float num = character.settings.customAttackInput;
		long num2 = customAttackCost(num);
		if (num2 >= 0 && !(num < 0f) && character.realExp >= num2)
		{
			character.realExp -= num2;
			character.attackBoost += num / 100f;
			tooltip.showTooltip("You've successfully bought +" + num + "% to your Attack stat! You're such a rich jerk ;).", 3f);
			updateStatPurchases();
		}
	}

	public void tryCustomDefense()
	{
		float num = character.settings.customDefenseInput;
		long num2 = customDefenseCost(num);
		if (num2 >= 0 && !(num < 0f))
		{
			if (character.realExp < num2)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomDefense;
				box.displayBox("Are you sure you want to buy +" + num + "% to your Defense stat for " + NumberOutput.expPrint(num2) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomDefense();
			}
		}
	}

	private void buyCustomDefense()
	{
		float num = character.settings.customDefenseInput;
		long num2 = customDefenseCost(num);
		if (num2 >= 0 && !(num < 0f) && character.realExp >= num2)
		{
			character.realExp -= num2;
			character.defenseBoost += num / 100f;
			tooltip.showTooltip("You've successfully bought +" + num + "% to your Defense stat! You're such a rich jerk ;).", 3f);
			updateStatPurchases();
		}
	}

	public long customAttackCost(float amount)
	{
		return (long)(amount * 3f);
	}

	public long customDefenseCost(float amount)
	{
		return (long)(amount * 3f);
	}

	public void updateCustomAttackInput()
	{
		if (attackInput.text == "")
		{
			attackInput.text = "1";
		}
		character.settings.customAttackInput = long.Parse(attackInput.text);
		if (character.settings.customAttackInput < 1)
		{
			character.settings.customAttackInput = 1L;
		}
		if (character.settings.customAttackInput > 100000000000L)
		{
			character.settings.customAttackInput = 100000000000L;
		}
		attackInput.text = character.settings.customAttackInput.ToString();
		refresh();
	}

	public void updateCustomDefenseInput()
	{
		if (defenseInput.text == "")
		{
			defenseInput.text = "1";
		}
		character.settings.customDefenseInput = long.Parse(defenseInput.text);
		if (character.settings.customDefenseInput < 1)
		{
			character.settings.customDefenseInput = 1L;
		}
		if (character.settings.customDefenseInput > 100000000000L)
		{
			character.settings.customDefenseInput = 100000000000L;
		}
		defenseInput.text = character.settings.customDefenseInput.ToString();
		refresh();
	}
}
