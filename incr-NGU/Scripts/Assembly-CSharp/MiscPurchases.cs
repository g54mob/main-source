using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiscPurchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Character character;

	public Button autoAdvanceButton;

	public Button energybutton1Button;

	public Button energyButton2Button;

	public Button magicButton1Button;

	public Button magicButton2Button;

	public Button beard1Button;

	public Button digger1Button;

	public Button digger2Button;

	public Button macguffin1Button;

	public Button macguffin2Button;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int energyButton1Cost = 50;

	private int energyButton2Cost = 500;

	private int magicButton1Cost = 100;

	private int magicButton2Cost = 1000;

	private int autoAdvanceCost = 300;

	private int beard1Cost = 50000;

	private int digger1Cost = 25000;

	private int macguffin1Cost = 10000000;

	private int macguffin2Cost = 100000000;

	private void Awake()
	{
		noAction = cancel;
	}

	private void cancel()
	{
	}

	private void Start()
	{
		updateMiscPurchases();
	}

	public void refresh()
	{
		updateMiscPurchases();
	}

	private void updateMiscPurchases()
	{
		if (character.purchases.hasAutoAdvance)
		{
			autoAdvanceButton.interactable = false;
			autoAdvanceButton.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			autoAdvanceButton.interactable = true;
			autoAdvanceButton.GetComponentInChildren<Text>().text = "Buy for " + autoAdvanceCost + " EXP";
		}
		if (character.purchases.hasCustomEnergyButton1)
		{
			energybutton1Button.interactable = false;
			energybutton1Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			energybutton1Button.interactable = true;
			energybutton1Button.GetComponentInChildren<Text>().text = "Buy for " + energyButton1Cost + " EXP";
		}
		if (character.purchases.hasCustomEnergyButton2)
		{
			energyButton2Button.interactable = false;
			energyButton2Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			energyButton2Button.interactable = true;
			energyButton2Button.GetComponentInChildren<Text>().text = "Buy for " + energyButton2Cost + " EXP";
		}
		if (character.purchases.hasCustomMagicButton1)
		{
			magicButton1Button.interactable = false;
			magicButton1Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			magicButton1Button.interactable = true;
			magicButton1Button.GetComponentInChildren<Text>().text = "Buy for " + magicButton1Cost + " EXP";
		}
		if (character.purchases.hasCustomMagicButton2)
		{
			magicButton2Button.interactable = false;
			magicButton2Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			magicButton2Button.interactable = true;
			magicButton2Button.GetComponentInChildren<Text>().text = "Buy for " + magicButton2Cost + " EXP";
		}
		if (character.purchases.hasBeardSlot1)
		{
			beard1Button.interactable = false;
			beard1Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			beard1Button.interactable = true;
			beard1Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(beard1Cost) + " EXP";
		}
		if (character.purchases.hasDiggerSlot1)
		{
			digger1Button.interactable = false;
			digger1Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			digger1Button.interactable = true;
			digger1Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(digger1Cost) + " EXP";
		}
		if (character.purchases.hasMacguffinSlot1)
		{
			macguffin1Button.interactable = false;
			macguffin1Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			macguffin1Button.interactable = true;
			macguffin1Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(macguffin1Cost) + " EXP";
		}
		if (character.purchases.hasMacguffinSlot2)
		{
			macguffin2Button.interactable = false;
			macguffin2Button.GetComponentInChildren<Text>().text = "BOUGHT";
		}
		else
		{
			macguffin2Button.interactable = true;
			macguffin2Button.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(macguffin2Cost) + " EXP";
		}
	}

	public void autoAdvance()
	{
		if (character.realExp < autoAdvanceCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyAutoAdvance;
			box.displayBox("Are you sure you want to buy Auto Advance for training for " + autoAdvanceCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyAutoAdvance();
		}
	}

	private void buyAutoAdvance()
	{
		character.realExp -= autoAdvanceCost;
		character.purchases.hasAutoAdvance = true;
		tooltip.showTooltip("You've successfully bought Auto Advance! When you unlock a new training, all but 1 of the energy from the previous trainings will advance to the next, without having to do a thing!", 5f);
		updateMiscPurchases();
	}

	public void energyButton1()
	{
		if (character.realExp < energyButton1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyButton1;
			box.displayBox("Are you sure you want to buy Custom Input Button 1 for " + energyButton1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyButton1();
		}
	}

	private void buyEnergyButton1()
	{
		character.realExp -= energyButton1Cost;
		character.purchases.hasCustomEnergyButton1 = true;
		tooltip.showTooltip("You've successfully bought Custom Input Button 1! You can type in a number in the input box up top, and hit SHIFT+CLICK on Custom Button 1 to set the button to that value. Then, clicking on the button will set the input box to that number! Convenient!", 5f);
		updateMiscPurchases();
	}

	public void energyButton2()
	{
		if (character.realExp < energyButton2Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyButton2;
			box.displayBox("Are you sure you want to buy Custom Input Button 3 for " + energyButton2Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyButton2();
		}
	}

	private void buyEnergyButton2()
	{
		character.realExp -= energyButton2Cost;
		character.purchases.hasCustomEnergyButton2 = true;
		tooltip.showTooltip("You've successfully bought Custom Input Button 3! You can type in a number in the input box up top, and hit SHIFT+CLICK on Custom Button 2 to set the button to that value. Then, clicking on the button will set the input box to that number! Convenient!", 5f);
		updateMiscPurchases();
	}

	public void magicButton1()
	{
		if (character.realExp < magicButton1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMagicButton1;
			box.displayBox("Are you sure you want to buy Custom Input Button 2 for " + magicButton1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMagicButton1();
		}
	}

	private void buyMagicButton1()
	{
		character.realExp -= magicButton1Cost;
		character.purchases.hasCustomMagicButton1 = true;
		tooltip.showTooltip("You've successfully bought Custom Input Button 2! You can type in a number in the input box up top, and hit SHIFT+CLICK on Custom Magic Button 1 to set the button to that value. Then, clicking on the button will set the input box to that number! Convenient!", 5f);
		updateMiscPurchases();
	}

	public void magicButton2()
	{
		if (character.realExp < magicButton2Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMagicButton2;
			box.displayBox("Are you sure you want to buy Custom Input Button 4 for " + magicButton2Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMagicButton2();
		}
	}

	private void buyMagicButton2()
	{
		character.realExp -= magicButton2Cost;
		character.purchases.hasCustomMagicButton2 = true;
		tooltip.showTooltip("You've successfully bought Custom Input Button 4! You can type in a number in the input box up top, and hit SHIFT+CLICK on Custom Magic Button 1 to set the button to that value. Then, clicking on the button will set the input box to that number! Convenient!", 5f);
		updateMiscPurchases();
	}

	public void beard1()
	{
		if (character.realExp < beard1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buybeard1;
			box.displayBox("Are you sure you want to buy an Extra Beard Slot for " + beard1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buybeard1();
		}
	}

	private void buybeard1()
	{
		character.realExp -= beard1Cost;
		character.purchases.hasBeardSlot1 = true;
		tooltip.showTooltip("You've successfully bought an extra Beard Slot! Now you can have one more beard active at the same time!", 5f);
		updateMiscPurchases();
	}

	public void digger1()
	{
		if (character.realExp < digger1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buydigger1;
			box.displayBox("Are you sure you want to buy an extra Digger Slot for " + digger1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buydigger1();
		}
	}

	private void buydigger1()
	{
		character.realExp -= digger1Cost;
		character.purchases.hasDiggerSlot1 = true;
		tooltip.showTooltip("You've successfully bought an extra Digger Slot! Now you can have one more Gold Digger active at the same time!", 5f);
		updateMiscPurchases();
	}

	public void macguffin1()
	{
		if (character.realExp < macguffin1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMacguffin1;
			box.displayBox("Are you sure you want to buy an extra MacGuffin Slot for " + macguffin1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMacguffin1();
		}
	}

	private void buyMacguffin1()
	{
		character.realExp -= macguffin1Cost;
		character.purchases.hasMacguffinSlot1 = true;
		character.inventoryController.updateMacguffinCount();
		tooltip.showTooltip("You've successfully bought an extra MacGuffin Slot! Go 'Guff it up!", 5f);
		updateMiscPurchases();
	}

	public void macguffin2()
	{
		if (character.realExp < macguffin2Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMacguffin2;
			box.displayBox("Are you sure you want to buy an extra MacGuffin Slot for " + macguffin2Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMacguffin2();
		}
	}

	private void buyMacguffin2()
	{
		character.realExp -= macguffin2Cost;
		character.purchases.hasMacguffinSlot2 = true;
		character.inventoryController.updateMacguffinCount();
		tooltip.showTooltip("You've successfully bought an extra MacGuffin Slot! Go 'Guff it up!", 5f);
		updateMiscPurchases();
	}
}
