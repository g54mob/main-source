using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdventurePurchases : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Text attackText;

	public Text defenseText;

	public Text maxHPText;

	public Text hpRegenText;

	public Text filterText;

	public Text acc3SlotText;

	public Text recycleText;

	public Text inventoryText;

	public Button inventoryButton;

	public Button filterButton;

	public Button recycleButton;

	public Button acc3Button;

	public Button acc5Button;

	public Button autoMergeButton;

	public Button loadout1Button;

	public Button loadout2Button;

	public Button daycareUnlockButton;

	public Button daycareSlot2Button;

	public Button daycareSlot3Button;

	public Button invMergeButton;

	public InventoryController ic;

	public InputField powerInput;

	public Button powerBuyButton;

	public InputField toughnessInput;

	public Button toughnessBuyButton;

	public InputField HPInput;

	public Button HPBuyButton;

	public InputField regenInput;

	public Button regenBuyButton;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int attack1Cost = 3;

	private int attack10Cost = 30;

	private int attack100Cost = 300;

	private int attack1000Cost = 3000;

	private int attack10KCost = 30000;

	private int defense1Cost = 3;

	private int defense10Cost = 30;

	private int defense100Cost = 300;

	private int defense1000Cost = 3000;

	private int defense10KCost = 30000;

	private int hp10Cost = 3;

	private int hp100Cost = 30;

	private int hp1KCost = 300;

	private int hp10KCost = 3000;

	private int hp100KCost = 30000;

	private int hpRegen1Cost = 50;

	private int hpRegen10Cost = 500;

	private int hpRegen100Cost = 5000;

	private int hpRegen1000Cost = 50000;

	private int hpRegen10KCost = 500000;

	private int filterCost = 20;

	private int acc3Cost = 3000;

	private int acc5Cost = 30000;

	private int recycleCost = 100;

	private int combineCost = 10;

	private int autoMergeCost = 200;

	private int loadout1Cost = 1000;

	private int loadout2Cost = 10000;

	private int daycareUnlockCost = 250;

	private int daycareSlot2Cost = 25000;

	private int daycareSlot3Cost = 500000;

	private int invMergeUnlockCost = 1000;

	public int currentCombineCost()
	{
		return (int)Mathf.Max(10f, (float)combineCost * Mathf.Pow(character.purchases.boostCombineLevel, 2f));
	}

	private void Awake()
	{
		noAction = cancel;
	}

	private void Start()
	{
		updateAdventureStats();
	}

	public void refresh()
	{
		updateAdventureStats();
	}

	private void cancel()
	{
	}

	private int invSpaceCost()
	{
		int spaces = character.inventory.spaces;
		if (spaces >= 60 || spaces < 24)
		{
			return 0;
		}
		if (spaces >= 24 && spaces < 36)
		{
			return 2;
		}
		return (spaces - 35) * 4;
	}

	private void updateAdventureStats()
	{
		if (character.menuID == 33)
		{
			attackText.text = "<b>Total Power:</b>\n" + NumberOutput.suffixFormat(character.totalAdvAttack(), character.settings.numberDisplay) + "\n\n<b>Base Power:</b>\n" + NumberOutput.suffixFormat(character.adventure.attack, character.settings.numberDisplay);
			defenseText.text = "<b>Total Toughness:</b>\n" + NumberOutput.suffixFormat(character.totalAdvDefense(), character.settings.numberDisplay) + "\n\n<b>Base Toughness:</b>\n" + NumberOutput.suffixFormat(character.adventure.defense, character.settings.numberDisplay);
			maxHPText.text = "<b>Total Max Health:</b>\n" + NumberOutput.suffixFormat(character.totalAdvHP(), character.settings.numberDisplay) + "\n\n<b>Base Max Health:</b>\n" + NumberOutput.suffixFormat(character.adventure.maxHP, character.settings.numberDisplay);
			hpRegenText.text = "<b>Total Health Regen:</b>\n" + NumberOutput.suffixFormat(character.totalAdvHPRegen(), character.settings.numberDisplay) + "\n\n<b>Base Health Regen:</b>\n" + NumberOutput.suffixFormat(character.adventure.regen, character.settings.numberDisplay) + "/s";
			powerBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customPowerCost(character.settings.customPowerInput)) + " EXP";
			toughnessBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customToughnessCost(character.settings.customToughnessInput)) + " EXP";
			HPBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customHPCost(character.settings.customHPInput)) + " EXP";
			regenBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customRegenCost(character.settings.customRegenInput)) + " EXP";
			powerInput.text = character.settings.customPowerInput.ToString();
			toughnessInput.text = character.settings.customToughnessInput.ToString();
			HPInput.text = character.settings.customHPInput.ToString();
			regenInput.text = character.settings.customRegenInput.ToString();
		}
		if (character.menuID == 34)
		{
			inventoryText.text = "<b>Inventory Spaces:</b>\n" + character.inventory.spaces + "/60";
			recycleText.text = "<b>Boost Recycling:</b> " + (character.purchases.boost * 100f + (float)character.allChallenges.basicChallenge.completions() * 10f) + "%";
			if (character.inventory.spaces >= 60)
			{
				inventoryButton.interactable = false;
				inventoryButton.GetComponentInChildren<Text>().text = "MAX BOUGHT!";
			}
			else
			{
				inventoryButton.GetComponentInChildren<Text>().text = "+1 for " + invSpaceCost() + " EXP";
				inventoryButton.interactable = true;
			}
			if (character.purchases.hasFilter)
			{
				filterButton.interactable = false;
				filterButton.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				filterButton.interactable = true;
				filterButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(filterCost) + " EXP";
			}
			if (character.purchases.hasAcc3)
			{
				acc3Button.interactable = false;
				acc3Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				acc3Button.interactable = true;
				acc3Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(acc3Cost) + " EXP";
			}
			if (character.purchases.hasAcc5)
			{
				acc5Button.interactable = false;
				acc5Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				acc5Button.interactable = true;
				acc5Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(acc5Cost) + " EXP";
			}
			if (character.purchases.boost >= 0.5f)
			{
				recycleButton.interactable = false;
				recycleButton.GetComponentInChildren<Text>().text = "MAX";
			}
			else
			{
				recycleButton.interactable = true;
				recycleButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(recycleCost) + " EXP";
			}
			if (character.purchases.hasAutoMerge)
			{
				autoMergeButton.interactable = false;
				autoMergeButton.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				autoMergeButton.interactable = true;
				autoMergeButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(autoMergeCost) + " EXP";
			}
			if (character.purchases.hasloadout1)
			{
				loadout1Button.interactable = false;
				loadout1Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				loadout1Button.interactable = true;
				loadout1Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(loadout1Cost) + " EXP";
			}
			if (character.purchases.hasloadout2)
			{
				loadout2Button.interactable = false;
				loadout2Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				loadout2Button.interactable = true;
				loadout2Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(loadout2Cost) + " EXP";
			}
			if (character.purchases.hasDaycare)
			{
				daycareUnlockButton.interactable = false;
				daycareUnlockButton.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				daycareUnlockButton.interactable = true;
				daycareUnlockButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(daycareUnlockCost) + " EXP";
			}
			if (character.purchases.hasDaycareSlot2)
			{
				daycareSlot2Button.interactable = false;
				daycareSlot2Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				daycareSlot2Button.interactable = true;
				daycareSlot2Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(daycareSlot2Cost) + " EXP";
			}
			if (character.purchases.hasDaycareSlot3)
			{
				daycareSlot3Button.interactable = false;
				daycareSlot3Button.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				daycareSlot3Button.interactable = true;
				daycareSlot3Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(daycareSlot3Cost) + " EXP";
			}
			if (character.purchases.hasInvMerge)
			{
				invMergeButton.interactable = false;
				invMergeButton.GetComponentInChildren<Text>().text = "BOUGHT";
			}
			else
			{
				invMergeButton.interactable = true;
				invMergeButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(invMergeUnlockCost) + " EXP";
			}
		}
	}

	public void add1Attack()
	{
		if (character.realExp < attack1Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1Attack;
			box.displayBox("Are you sure you want to buy +1 Power for the Adventure Feature for " + attack1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1Attack();
		}
	}

	private void buy1Attack()
	{
		character.adventure.attack += 1f;
		character.realExp -= attack1Cost;
		tooltip.showTooltip("You've succesfully bought +1 Power for the Adventure Feature! Time to kill some monsters!", 2f);
		updateAdventureStats();
	}

	public void add10Attack()
	{
		if (character.realExp < attack10Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10Attack;
			box.displayBox("Are you sure you want to buy +10 Power for the Adventure Feature for " + attack10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10Attack();
		}
	}

	private void buy10Attack()
	{
		character.adventure.attack += 10f;
		character.realExp -= attack10Cost;
		tooltip.showTooltip("You've succesfully bought +10 Power for the Adventure Feature! Getting stronger all the time!", 2f);
		updateAdventureStats();
	}

	public void add100Attack()
	{
		if (character.realExp < attack100Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100Attack;
			box.displayBox("Are you sure you want to buy +100 Power for the Adventure Feature for " + attack100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100Attack();
		}
	}

	private void buy100Attack()
	{
		character.adventure.attack += 100f;
		character.realExp -= attack100Cost;
		tooltip.showTooltip("You've succesfully bought +100 Power for the Adventure Feature! You're unstoppable!", 2f);
		updateAdventureStats();
	}

	public void add1000Attack()
	{
		if (character.realExp < attack1000Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1000Attack;
			box.displayBox("Are you sure you want to buy +1000 Power for the Adventure Feature for " + attack1000Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1000Attack();
		}
	}

	private void buy1000Attack()
	{
		character.adventure.attack += 1000f;
		character.realExp -= attack1000Cost;
		tooltip.showTooltip("You've succesfully bought +1000 Power for the Adventure Feature! Holy crap!", 2f);
		updateAdventureStats();
	}

	public void add10KAttack()
	{
		if (character.realExp < attack10KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10KAttack;
			box.displayBox("Are you sure you want to buy +10K Power for the Adventure Feature for " + attack10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10KAttack();
		}
	}

	private void buy10KAttack()
	{
		character.adventure.attack += 10000f;
		character.realExp -= attack10KCost;
		tooltip.showTooltip("You've succesfully bought +10K Power for the Adventure Feature! Holy crap!", 2f);
		updateAdventureStats();
	}

	public void add1Defense()
	{
		if (character.realExp < defense1Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1Defense;
			box.displayBox("Are you sure you want to buy +1 Toughness for the Adventure Feature for " + defense1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1Defense();
		}
	}

	private void buy1Defense()
	{
		character.adventure.defense += 1f;
		character.realExp -= defense1Cost;
		tooltip.showTooltip("You've succesfully bought +1 Toughness for the Adventure Feature! Time to... not be killed BY monsters?", 2f);
		updateAdventureStats();
	}

	public void add10Defense()
	{
		if (character.realExp < defense10Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10Defense;
			box.displayBox("Are you sure you want to buy +10 Toughness for the Adventure Feature for " + defense10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10Defense();
		}
	}

	private void buy10Defense()
	{
		character.adventure.defense += 10f;
		character.realExp -= defense10Cost;
		tooltip.showTooltip("You've succesfully bought +10 Toughness for the Adventure Feature! Getting pretty hard to kill!", 2f);
		updateAdventureStats();
	}

	public void add100Defense()
	{
		if (character.realExp < defense100Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100Defense;
			box.displayBox("Are you sure you want to buy +100 Toughness for the Adventure Feature for " + defense100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100Defense();
		}
	}

	private void buy100Defense()
	{
		character.adventure.defense += 100f;
		character.realExp -= defense100Cost;
		tooltip.showTooltip("You've succesfully bought +100 Toughness for the Adventure Feature! Incredible!", 2f);
		updateAdventureStats();
	}

	public void add1000Defense()
	{
		if (character.realExp < defense1000Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1000Defense;
			box.displayBox("Are you sure you want to buy +1000 Toughness for the Adventure Feature for " + defense1000Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1000Defense();
		}
	}

	private void buy1000Defense()
	{
		character.adventure.defense += 1000f;
		character.realExp -= defense1000Cost;
		tooltip.showTooltip("You've succesfully bought +1000 Toughness for the Adventure Feature! I'd give you a pat on your back but I think I'd just break my hand.", 2f);
		updateAdventureStats();
	}

	public void add10KDefense()
	{
		if (character.realExp < defense10KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10KDefense;
			box.displayBox("Are you sure you want to buy +10K Toughness for the Adventure Feature for " + defense10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10KDefense();
		}
	}

	private void buy10KDefense()
	{
		character.adventure.defense += 10000f;
		character.realExp -= defense10KCost;
		tooltip.showTooltip("You've succesfully bought +10K Toughness for the Adventure Feature! I'd give you a pat on your back but I think I'd just break my hand.", 2f);
		updateAdventureStats();
	}

	public void add10Hp()
	{
		if (character.realExp < hp10Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10HP;
			box.displayBox("Are you sure you want to buy +10 Max HP for the Adventure Feature for " + hp10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10HP();
		}
	}

	private void buy10HP()
	{
		character.adventure.maxHP += 10f;
		character.realExp -= hp10Cost;
		tooltip.showTooltip("You've succesfully bought +10 Max HP for the Adventure Feature!", 2f);
		updateAdventureStats();
	}

	public void add100Hp()
	{
		if (character.realExp < hp100Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100HP;
			box.displayBox("Are you sure you want to buy +100 Max HP for the Adventure Feature for " + hp100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100HP();
		}
	}

	private void buy100HP()
	{
		character.adventure.maxHP += 100f;
		character.realExp -= hp100Cost;
		tooltip.showTooltip("You've succesfully bought +100 Max HP for the Adventure Feature!", 2f);
		updateAdventureStats();
	}

	public void add1000Hp()
	{
		if (character.realExp < hp1KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1KHP;
			box.displayBox("Are you sure you want to buy +1K Max HP for the Adventure Feature for " + hp1KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1KHP();
		}
	}

	private void buy1KHP()
	{
		character.adventure.maxHP += 1000f;
		character.realExp -= hp1KCost;
		tooltip.showTooltip("You've succesfully bought +1K Max HP for the Adventure Feature!", 2f);
		updateAdventureStats();
	}

	public void add10KHp()
	{
		if (character.realExp < hp10KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10KHP;
			box.displayBox("Are you sure you want to buy +10K Max HP for the Adventure Feature for " + hp10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10KHP();
		}
	}

	private void buy10KHP()
	{
		character.adventure.maxHP += 10000f;
		character.realExp -= hp10KCost;
		tooltip.showTooltip("You've succesfully bought +10K Max HP for the Adventure Feature! Can you even be killed?", 2f);
		updateAdventureStats();
	}

	public void add100KHp()
	{
		if (character.realExp < hp100KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100KHP;
			box.displayBox("Are you sure you want to buy +100K Max HP for the Adventure Feature for " + hp100KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100KHP();
		}
	}

	private void buy100KHP()
	{
		character.adventure.maxHP += 100000f;
		character.realExp -= hp100KCost;
		tooltip.showTooltip("You've succesfully bought +100K Max HP for the Adventure Feature! Can you even be killed?", 2f);
		updateAdventureStats();
	}

	public void add1HpRegen()
	{
		if (character.realExp < hpRegen1Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1HPRegen;
			box.displayBox("Are you sure you want to buy +1 HP Regen for the Adventure Feature for " + hpRegen1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1HPRegen();
		}
	}

	private void buy1HPRegen()
	{
		character.adventure.regen += 1f;
		character.realExp -= hpRegen1Cost;
		tooltip.showTooltip("You've succesfully bought +1 Hp Regen for the Adventure Feature!", 2f);
		updateAdventureStats();
	}

	public void add10HpRegen()
	{
		if (character.realExp < hpRegen10Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10HPRegen;
			box.displayBox("Are you sure you want to buy +10 HP Regen for the Adventure Feature for " + hpRegen10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10HPRegen();
		}
	}

	private void buy10HPRegen()
	{
		character.adventure.regen += 10f;
		character.realExp -= hpRegen10Cost;
		tooltip.showTooltip("You've succesfully bought +10 Hp Regen for the Adventure Feature!", 2f);
		updateAdventureStats();
	}

	public void add100HpRegen()
	{
		if (character.realExp < hpRegen100Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100HPRegen;
			box.displayBox("Are you sure you want to buy +100 HP Regen for the Adventure Feature for " + hpRegen100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100HPRegen();
		}
	}

	private void buy100HPRegen()
	{
		character.adventure.regen += 100f;
		character.realExp -= hpRegen100Cost;
		tooltip.showTooltip("You've succesfully bought +100 Hp Regen for the Adventure Feature! Watch those wounds heal up!", 2f);
		updateAdventureStats();
	}

	public void add1000HpRegen()
	{
		if (character.realExp < hpRegen1000Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1000HPRegen;
			box.displayBox("Are you sure you want to buy +1000 HP Regen for the Adventure Feature for " + hpRegen1000Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1000HPRegen();
		}
	}

	private void buy1000HPRegen()
	{
		character.adventure.regen += 1000f;
		character.realExp -= hpRegen1000Cost;
		tooltip.showTooltip("You've succesfully bought +1000 Hp Regen for the Adventure Feature! You're like, Wolverine or something.", 2f);
		updateAdventureStats();
	}

	public void add10KHpRegen()
	{
		if (character.realExp < hpRegen10KCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10KHPRegen;
			box.displayBox("Are you sure you want to buy +10K HP Regen for the Adventure Feature for " + hpRegen10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10KHPRegen();
		}
	}

	private void buy10KHPRegen()
	{
		character.adventure.regen += 10000f;
		character.realExp -= hpRegen10KCost;
		tooltip.showTooltip("You've succesfully bought +10K Hp Regen for the Adventure Feature! You're like, Deadpool or something.", 2f);
		updateAdventureStats();
	}

	public void addInventorySpace()
	{
		if (character.inventory.spaces >= 60)
		{
			tooltip.showTooltip("You have the maximum number of inventory spaces already! Sheesh, such a loot goblin.", 2f);
		}
		else if (character.realExp < invSpaceCost())
		{
			tooltip.showTooltip("Not enough EXP!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyInventorySpace;
			box.displayBox("Are you sure you want to buy an additional inventory space for " + invSpaceCost() + " EXP?", yesAction, noAction);
		}
		else
		{
			buyInventorySpace();
		}
	}

	private void buyInventorySpace()
	{
		character.realExp -= invSpaceCost();
		character.inventory.spaces++;
		tooltip.showTooltip("You've succesfully bought a new inventory space for the Adventure Feature!", 2f);
		character.inventoryController.updateInvCount();
		updateAdventureStats();
		if (character.inventory.spaces >= 60)
		{
			inventoryButton.interactable = false;
			inventoryButton.GetComponentInChildren<Text>().text = "MAX SPACES BOUGHT!";
		}
		ic.updateInventory();
	}

	public void addFilter()
	{
		if (character.realExp < filterCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyFilter;
			box.displayBox("Are you sure you want to buy the Basic Loot Filter for " + filterCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyFilter();
		}
	}

	private void buyFilter()
	{
		character.purchases.hasFilter = true;
		character.realExp -= filterCost;
		tooltip.showOverrideTooltip("You've succesfully bought the Basic Loot Filter! Head to the settings menu and then click on an item type to prevent items of that type from dropping!", 6f);
		updateAdventureStats();
	}

	public void addAcc3()
	{
		if (character.realExp < acc3Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAcc3;
			box.displayBox("Are you sure you want to buy the extra Accessory slot for " + acc3Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAcc3();
		}
	}

	private void buyAcc3()
	{
		character.purchases.hasAcc3 = true;
		character.realExp -= acc3Cost;
		tooltip.showTooltip("You've succesfully bought the extra accessory slot! More options, more power!", 2f);
		updateAdventureStats();
		ic.updateAllAccs();
		ic.updateInventory();
		character.inventoryController.updateAccCount();
	}

	public void addRecycleBoost()
	{
		if (character.realExp < recycleCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRecycleBoost;
			box.displayBox("Are you sure you want to buy 10% Boost Recycling for " + recycleCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRecycleBoost();
		}
	}

	private void buyRecycleBoost()
	{
		character.realExp -= recycleCost;
		character.purchases.boost += 0.1f;
		if (character.purchases.boost >= 0.5f)
		{
			character.purchases.boost = 0.5f;
		}
		tooltip.showTooltip("You've succesfully bought 10% Boost Recycling! Booooooooooooooooooost!", 2f);
		updateAdventureStats();
	}

	public void addAutoMerge()
	{
		if (character.realExp < autoMergeCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAutoMerge;
			box.displayBox("Are you sure you want to buy Auto Merge for " + autoMergeCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAutoMerge();
		}
	}

	private void buyAutoMerge()
	{
		character.realExp -= autoMergeCost;
		character.purchases.hasAutoMerge = true;
		tooltip.showTooltip("You've succesfully bought Auto Merge. Enjoy the perks of merging without all of that pesky effort getting in the way!", 2f);
		updateAdventureStats();
	}

	public void addCombineBoost()
	{
		if (character.realExp < currentCombineCost())
		{
			tooltip.showTooltip("Not enough exp!", 2f);
			return;
		}
		yesAction = buyCombineBoost;
		box.displayBox("Are you sure you want to buy +1% Boost Combine Chance for " + currentCombineCost() + " EXP?", yesAction, noAction);
	}

	private void buyCombineBoost()
	{
		character.realExp -= currentCombineCost();
		character.purchases.boostCombineLevel++;
		if (character.purchases.boostCombineLevel > 50)
		{
			character.purchases.boostCombineLevel = 50;
		}
		tooltip.showTooltip("You've succesfully bought +1% Boost Combine Chance! Booooooooooooooooooost!", 2f);
		updateAdventureStats();
	}

	public void addAcc5()
	{
		if (character.realExp < acc5Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAcc5;
			box.displayBox("Are you sure you want to buy a bonus Accessory slot for " + acc5Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAcc5();
		}
	}

	private void buyAcc5()
	{
		character.purchases.hasAcc5 = true;
		character.realExp -= acc5Cost;
		tooltip.showTooltip("You've succesfully bought the extra accessory slot! More options, more power!", 2f);
		updateAdventureStats();
		ic.updateAllAccs();
		ic.updateInventory();
		character.inventoryController.updateAccCount();
	}

	public void addLoadout1()
	{
		if (character.realExp < loadout1Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyLoadout1;
			box.displayBox("Are you sure you want to buy 2 loadout slots for " + loadout1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyLoadout1();
		}
	}

	private void buyLoadout1()
	{
		character.purchases.hasloadout1 = true;
		character.realExp -= loadout1Cost;
		tooltip.showTooltip("You've succesfully bought 2 loadout slots! More options, more power!", 2f);
		updateAdventureStats();
		ic.updateAllAccs();
		ic.updateInventory();
	}

	public void addLoadout2()
	{
		if (character.realExp < loadout2Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyLoadout2;
			box.displayBox("Are you sure you want to buy a bonus loadout slot for " + loadout2Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyLoadout2();
		}
	}

	private void buyLoadout2()
	{
		character.purchases.hasloadout2 = true;
		character.realExp -= loadout2Cost;
		tooltip.showTooltip("You've succesfully bought an extra loadout slot! More options, more power!", 2f);
		updateAdventureStats();
		ic.updateAllAccs();
		ic.updateInventory();
	}

	public void startDaycare()
	{
		if (character.realExp < daycareUnlockCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDaycare;
			box.displayBox("Are you sure you want to unlock the Item Daycare  for " + daycareUnlockCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDaycare();
		}
	}

	private void buyDaycare()
	{
		character.purchases.hasDaycare = true;
		character.realExp -= daycareUnlockCost;
		tooltip.showTooltip("You've succesfully unlocked the Item Daycare! Go check it out in the inventory menu!", 2f);
		ic.updateDaycareCount();
		updateAdventureStats();
	}

	public void startDaycareSlot2()
	{
		if (character.realExp < daycareSlot2Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (!character.purchases.hasDaycare)
		{
			tooltip.showTooltip("You have to buy the daycare first, Ser Dumbass of House Moron.", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDaycareSlot2;
			box.displayBox("Are you sure you want to buy a bonus daycare slot for " + daycareSlot2Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDaycareSlot2();
		}
	}

	private void buyDaycareSlot2()
	{
		character.purchases.hasDaycareSlot2 = true;
		character.realExp -= daycareSlot2Cost;
		tooltip.showTooltip("You've succesfully bought a new daycare slot! More free levels on stuff, woohoo!", 2f);
		ic.updateDaycareCount();
		updateAdventureStats();
	}

	public void startDaycareSlot3()
	{
		if (character.realExp < daycareSlot3Cost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (!character.purchases.hasDaycare)
		{
			tooltip.showTooltip("You have to buy the daycare first, Ser Dumbass of House Moron.", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyDaycareSlot3;
			box.displayBox("Are you sure you want to buy a bonus daycare slot for " + daycareSlot3Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyDaycareSlot3();
		}
	}

	private void buyDaycareSlot3()
	{
		character.purchases.hasDaycareSlot3 = true;
		character.realExp -= daycareSlot3Cost;
		tooltip.showTooltip("You've succesfully bought a new daycare slot! More free levels on stuff, woohoo!", 2f);
		ic.updateDaycareCount();
		updateAdventureStats();
	}

	public void startInvMergeUnlock()
	{
		if (character.realExp < invMergeUnlockCost)
		{
			tooltip.showTooltip("Not enough exp!", 2f);
		}
		else if (!character.purchases.hasAutoMerge)
		{
			tooltip.showTooltip("You have to buy Automerge first, Ser Moron of House Dumbass.", 2f);
		}
		else if (character.purchases.hasInvMerge)
		{
			tooltip.showTooltip("You already bought this dang thing!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyInvMergeUnlock;
			box.displayBox("Are you sure you want to buy an Inventory Merge Slot for " + invMergeUnlockCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyInvMergeUnlock();
		}
	}

	private void buyInvMergeUnlock()
	{
		character.purchases.hasInvMerge = true;
		character.realExp -= invMergeUnlockCost;
		tooltip.showTooltip("You've succesfully bought an Inventory Merge slot-tols egreM yrotnevnI na thguob yllufseccus ev'uoY! ", 2f);
		updateAdventureStats();
	}

	public long customPowerCost(long amount)
	{
		return amount * 3;
	}

	public long customToughnessCost(long amount)
	{
		return amount * 3;
	}

	public long customHPCost(long amount)
	{
		return amount * 3 / 10;
	}

	public long customRegenCost(long amount)
	{
		return amount * 50;
	}

	public void updateCustomPowerInput()
	{
		if (powerInput.text == "")
		{
			powerInput.text = "1";
		}
		character.settings.customPowerInput = long.Parse(powerInput.text);
		if (character.settings.customPowerInput < 0)
		{
			character.settings.customPowerInput = 1L;
		}
		if (character.settings.customPowerInput > 3000000000000000000L)
		{
			character.settings.customPowerInput = 3000000000000000000L;
		}
		powerInput.text = character.settings.customPowerInput.ToString();
		refresh();
	}

	public void updateCustomToughnessInput()
	{
		if (toughnessInput.text == "")
		{
			toughnessInput.text = "1";
		}
		character.settings.customToughnessInput = long.Parse(toughnessInput.text);
		if (character.settings.customToughnessInput < 0)
		{
			character.settings.customToughnessInput = 1L;
		}
		if (character.settings.customToughnessInput > 3000000000000000000L)
		{
			character.settings.customToughnessInput = 3000000000000000000L;
		}
		toughnessInput.text = character.settings.customToughnessInput.ToString();
		refresh();
	}

	public void updateCustomHPInput()
	{
		if (HPInput.text == "")
		{
			HPInput.text = "10";
		}
		character.settings.customHPInput = long.Parse(HPInput.text);
		if (character.settings.customHPInput < 10)
		{
			character.settings.customHPInput = 10L;
		}
		long num = character.settings.customHPInput / 10;
		character.settings.customHPInput = num * 10;
		if (character.settings.customHPInput < 10)
		{
			character.settings.customHPInput = 10L;
		}
		if (character.settings.customHPInput > 3000000000000000000L)
		{
			character.settings.customHPInput = 3000000000000000000L;
		}
		HPInput.text = character.settings.customHPInput.ToString();
		refresh();
	}

	public void updateCustomRegenInput()
	{
		if (regenInput.text == "")
		{
			regenInput.text = "1";
		}
		character.settings.customRegenInput = long.Parse(regenInput.text);
		if (character.settings.customRegenInput < 0)
		{
			character.settings.customRegenInput = 1L;
		}
		if (character.settings.customRegenInput > 100000000000000000L)
		{
			character.settings.customRegenInput = 100000000000000000L;
		}
		regenInput.text = character.settings.customRegenInput.ToString();
		refresh();
	}

	public void tryCustomPower()
	{
		long customPowerInput = character.settings.customPowerInput;
		long num = customPowerCost(customPowerInput);
		if (num >= 0 && num <= long.MaxValue && customPowerInput >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.adventure.attack + (float)customPowerInput > float.MaxValue)
			{
				tooltip.showTooltip("You've somehow hit the maximum Power I can possibly give you! You're TOO STRONK.", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomPower;
				box.displayBox("Are you sure you want to buy " + character.display(customPowerInput) + " Power for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomPower();
			}
		}
	}

	private void buyCustomPower()
	{
		long customPowerInput = character.settings.customPowerInput;
		long num = customPowerCost(customPowerInput);
		if (num >= 0 && customPowerInput >= 0 && character.realExp >= num && !(character.adventure.attack + (float)customPowerInput > float.MaxValue))
		{
			character.realExp -= num;
			character.adventure.attack += customPowerInput;
			tooltip.showTooltip("You've successfully bought +" + character.display(customPowerInput) + " Power for Adventure! That sure is a custom amount you bought.", 3f);
			updateAdventureStats();
		}
	}

	public void tryCustomToughness()
	{
		long customToughnessInput = character.settings.customToughnessInput;
		long num = customToughnessCost(customToughnessInput);
		if (num >= 0 && num <= long.MaxValue && customToughnessInput >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.adventure.defense + (float)customToughnessInput > float.MaxValue)
			{
				tooltip.showTooltip("You've somehow hit the maximum Toughness I can possibly give you! You're TOO STRONK.", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomToughness;
				box.displayBox("Are you sure you want to buy " + character.display(customToughnessInput) + " Toughness for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomToughness();
			}
		}
	}

	private void buyCustomToughness()
	{
		long customToughnessInput = character.settings.customToughnessInput;
		long num = customToughnessCost(customToughnessInput);
		if (num >= 0 && customToughnessInput >= 0 && character.realExp >= num && !(character.adventure.defense + (float)customToughnessInput > float.MaxValue))
		{
			character.realExp -= num;
			character.adventure.defense += customToughnessInput;
			tooltip.showTooltip("You've successfully bought +" + character.display(customToughnessInput) + " Toughness for Adventure! That sure is a custom amount you bought.", 3f);
			updateAdventureStats();
		}
	}

	public void tryCustomHP()
	{
		long customHPInput = character.settings.customHPInput;
		long num = customHPCost(customHPInput);
		if (num >= 0 && num <= long.MaxValue && customHPInput >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.adventure.maxHP + (float)customHPInput > float.MaxValue)
			{
				tooltip.showTooltip("You've somehow hit the maximum HP I can possibly give you! You're TOO STRONK.", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomHP;
				box.displayBox("Are you sure you want to buy " + character.display(customHPInput) + " HP for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomHP();
			}
		}
	}

	private void buyCustomHP()
	{
		long customHPInput = character.settings.customHPInput;
		long num = customHPCost(customHPInput);
		if (num >= 0 && customHPInput >= 0 && character.realExp >= num && !(character.adventure.maxHP + (float)customHPInput > float.MaxValue))
		{
			character.realExp -= num;
			character.adventure.maxHP += customHPInput;
			tooltip.showTooltip("You've successfully bought +" + character.display(customHPInput) + " HP for Adventure! That sure is a custom amount you bought.", 3f);
			updateAdventureStats();
		}
	}

	public void tryCustomRegen()
	{
		long customRegenInput = character.settings.customRegenInput;
		long num = customRegenCost(customRegenInput);
		if (num >= 0 && num <= long.MaxValue && customRegenInput >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.adventure.regen + (float)customRegenInput > float.MaxValue)
			{
				tooltip.showTooltip("You've somehow hit the maximum HP Regen I can possibly give you! You're TOO STRONK.", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomregen;
				box.displayBox("Are you sure you want to buy " + character.display(customRegenInput) + " HP Regen for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomregen();
			}
		}
	}

	private void buyCustomregen()
	{
		long customRegenInput = character.settings.customRegenInput;
		long num = customRegenCost(customRegenInput);
		if (num >= 0 && customRegenInput >= 0 && character.realExp >= num && !(character.adventure.regen + (float)customRegenInput > float.MaxValue))
		{
			character.realExp -= num;
			character.adventure.regen += customRegenInput;
			tooltip.showTooltip("You've successfully bought +" + character.display(customRegenInput) + " HP Regen for Adventure! That sure is a custom amount you bought.", 3f);
			updateAdventureStats();
		}
	}
}
