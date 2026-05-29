using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class YggdrasilEXPPurchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Character character;

	public Button[] fruitButtons = new Button[20];

	public string[] fruitNames = new string[20];

	private UnityAction yesAction;

	private UnityAction noAction;

	public long[] fruitCosts = new long[20];

	private int fruitToBuy;

	private void Awake()
	{
		noAction = cancel;
	}

	private void cancel()
	{
	}

	private void Start()
	{
		updateYggdrasilPurchases();
	}

	public void refresh()
	{
		updateYggdrasilPurchases();
	}

	private void updateYggdrasilPurchases()
	{
		for (int i = 0; i < fruitButtons.Length; i++)
		{
			if (character.yggdrasil.fruits[i].permCostPaid)
			{
				fruitButtons[i].GetComponentInChildren<Text>().text = "BOUGHT!";
				fruitButtons[i].interactable = false;
			}
			else
			{
				fruitButtons[i].GetComponentInChildren<Text>().text = "Buy for " + prettyPrint(fruitCosts[i]) + " EXP";
				fruitButtons[i].interactable = true;
			}
		}
	}

	public void startFruitPurchase(int id)
	{
		if (id >= 0 && id < character.yggdrasil.fruits.Count)
		{
			if (character.realExp < fruitCosts[id])
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.yggdrasil.fruits[id].permCostPaid)
			{
				tooltip.showTooltip("You already bought this!", 2f);
			}
			else if (!canBuy(id))
			{
				tooltip.showTooltip("You don't have the cap required to buy this upgrade! You need " + capRequired(id) + "!", 2f);
			}
			else if (character.yggdrasil.fruits[id].maxTier == 0L)
			{
				tooltip.showTooltip("You need to unlock this fruit before you can buy auto-activation for it! Walk before you can run and all that, right?", 2f);
			}
			else if (character.settings.expPopups)
			{
				fruitToBuy = id;
				yesAction = buyFruit;
				box.displayBox("Are you sure you want to buy Auto Activation for " + fruitNames[id] + " for " + fruitCosts[id] + " EXP?", yesAction, noAction);
			}
			else
			{
				fruitToBuy = id;
				buyFruit();
			}
		}
	}

	public string capRequired(int id)
	{
		long num = character.yggdrasilController.activationCost[id] * 10;
		if (character.yggdrasilController.usesEnergy[id])
		{
			return NumberOutput.suffixFormat(num, character.settings.numberDisplay) + " Energy Cap";
		}
		return NumberOutput.suffixFormat(num, character.settings.numberDisplay) + " Magic Cap";
	}

	private void buyFruit()
	{
		character.realExp -= fruitCosts[fruitToBuy];
		character.yggdrasil.fruits[fruitToBuy].permCostPaid = true;
		tooltip.showTooltip("You've successfully unlocked auto-activation for " + fruitNames[fruitToBuy] + "!", 3f);
		updateYggdrasilPurchases();
	}

	private string prettyPrint(long cost)
	{
		return NumberOutput.expPrint(cost);
	}

	public bool canBuy(int id)
	{
		long num = character.yggdrasilController.activationCost[id] * 10;
		bool flag = character.yggdrasilController.usesEnergy[id];
		if (flag && character.totalCapEnergy() >= num)
		{
			return true;
		}
		if (!flag && character.totalCapMagic() >= num)
		{
			return true;
		}
		return false;
	}
}
