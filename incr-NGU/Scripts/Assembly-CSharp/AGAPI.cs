using System.Collections.Generic;
using UnityEngine;

public class AGAPI : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public string AGID = "";

	public List<string> packsAwarded;

	public void retrieveAGID()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalEval("ag.authenticateUser().then(function(user) {\r\n                SendMessage('AGAPI', 'onUserID', user.uid);\r\n                SendMessage('AGAPI', 'onUserName', user.username);\r\n            });");
		}
	}

	public void onUserID(string id)
	{
		AGID = id;
	}

	public void onUserName(string name)
	{
		character.playerName = name;
	}

	public void Start()
	{
		if (character.platform == platform.AG)
		{
			Invoke("retrieveAGID", 1f);
		}
	}

	public void initAPI()
	{
	}

	public void submitScores()
	{
		_ = character.settings.submitHighscores;
	}

	public void startBuy20KAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startBudgetAP");
		}
	}

	public void startBuy100KAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startLittleAP");
		}
	}

	public void startBuy200KAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startSmallAP");
		}
	}

	public void startBuy400KAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startMediumAP");
		}
	}

	public void startBuy1MAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startLargeAP");
		}
	}

	public void startBuy2MAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startHugeAP");
		}
	}

	public void startNewPlayerAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startNewbAP");
		}
	}

	public void startAscendedAP()
	{
		if (character.platform == platform.AG)
		{
			Application.ExternalCall("startAscendedAP");
		}
	}

	public void OnPurchaseSuccess()
	{
		if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("Looks like you bought something!", 2f);
		}
	}

	public void OnPurchaseFailure()
	{
		if (character.platform == platform.AG)
		{
			tooltip.showOverrideTooltip("Hm, that purchase didn't seem to go through. Try again?", 2f);
		}
	}

	public void consumeAnyOutstandingItems()
	{
		if (character.platform == platform.AG)
		{
			packsAwarded.Clear();
			Application.ExternalCall("consumeAnyOutstandingItems");
		}
	}

	public void displayMultiPack()
	{
		if (packsAwarded.Count == 0)
		{
			return;
		}
		if (packsAwarded.Count < 2)
		{
			packsAwarded.Clear();
			return;
		}
		string text = "Thank you! You've been credited the following packs:";
		for (int i = 0; i < packsAwarded.Count; i++)
		{
			text = text + "\n" + packsAwarded[i];
		}
		tooltip.showOverrideTooltip(text, 5f);
		packsAwarded.Clear();
	}

	public void consumePurchase(string skuName)
	{
		switch (skuName)
		{
		case "ni-budget_ap_pack:1":
			consume20KPurchase();
			packsAwarded.Add("Budget AP Pack");
			break;
		case "ni-little_ap_pack:1":
			consume100KPurchase();
			packsAwarded.Add("Little AP Pack");
			break;
		case "ni-small_ap_pack:1":
			consume200KPurchase();
			packsAwarded.Add("Small AP Pack");
			break;
		case "ni-medium_ap_pack:1":
			consume400KPurchase();
			packsAwarded.Add("Medium AP Pack");
			break;
		case "ni-large_ap_pack:1":
			consume1MPurchase();
			packsAwarded.Add("Large AP Pack");
			break;
		case "ni-huge_ap_pack:1":
			consume2MPurchase();
			packsAwarded.Add("Huge AP Pack");
			break;
		case "ni-stupid_newb_pack:1":
			consumeNewPlayerPurchase();
			packsAwarded.Add("Stupid Newbie Pack");
			break;
		case "ni-ascended_newbie_pack:1":
			consumeAscendedNewbiePurchase();
			packsAwarded.Add("Stupid Newbie Pack");
			break;
		}
	}

	public void consume20KPurchase()
	{
		character.addAP(20000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(20000L).ToString("###,##0") + " AP has been added!", 5f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume100KPurchase()
	{
		character.addAP(110000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(100000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(10000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume200KPurchase()
	{
		character.addAP(225000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(200000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(25000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume400KPurchase()
	{
		character.addAP(460000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(400000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(60000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume1MPurchase()
	{
		character.addAP(1200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(1000000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(200000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consume2MPurchase()
	{
		character.addAP(3200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(2500000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(700000L).ToString("###,##0") + " AP! I'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!", 10f);
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
		character.allArbitrary.updateMenu();
	}

	public void consumeNewPlayerPurchase()
	{
		string text = "Thank you so much for buying the Stupid Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(225000L).ToString("###,##0") + "AP!</b>\n<b>2 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(225000);
		character.arbitrary.energyPotion1Count += 2;
		character.arbitrary.energyPotion2Count += 2;
		character.arbitrary.energyPotion3Count += 2;
		character.arbitrary.magicPotion1Count += 2;
		character.arbitrary.magicPotion2Count += 2;
		character.arbitrary.magicPotion3Count += 2;
		character.arbitrary.lootCharm1Count += 2;
		character.arbitrary.energyBarBar1Count += 2;
		character.arbitrary.magicBarBar1Count += 2;
		character.arbitrary.poop1Count += 25;
		character.arbitrary.lootCharm2Count += 2;
		if (character.arbitrary.lootFilter)
		{
			character.addAP(100000);
			text = text + "\n<b>An extra " + character.checkAPAdded(100000L).ToString("###,##0") + " AP Since you already have the Improved Loot Filter!</b>";
		}
		else
		{
			character.arbitrary.lootFilter = true;
			text += "\n<b>The Improved Loot Filter!</b>";
		}
		long num = 0L;
		long num2 = character.arbitrary.inventorySpaces + 12 - character.allArbitrary.randomArbitraryController.maxSpaces();
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (num2 > 12)
		{
			num2 = 12L;
		}
		if (num2 > 0)
		{
			num = num2 * 10000;
		}
		if (num > 0)
		{
			character.arbitrary.curArbitraryPoints += num;
			character.arbitrary.curLifetimePoints += num;
			text = text + "\n<b>An extra " + num.ToString("###,##0") + " AP since you reached the max inventory spaces available!</b>";
		}
		else
		{
			text += "\n<b>12 inventory spaces!</b>";
		}
		character.arbitrary.inventorySpaces += 12;
		if (character.arbitrary.inventorySpaces > character.allArbitrary.randomArbitraryController.maxSpaces())
		{
			character.arbitrary.inventorySpaces = (int)character.allArbitrary.randomArbitraryController.maxSpaces();
		}
		character.arbitrary.boughtNewbiePack = true;
		character.inventoryController.updateInvCount();
		text += "\n<b>Plus, you can PM me for a personalized insult!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.APPackDisplay.refreshMenu();
		character.allArbitrary.updateMenu();
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
	}

	public void consumeAscendedNewbiePurchase()
	{
		string text = "Thank you so much for buying the Ascended Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(600000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Red Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[119]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Red Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[119])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Red Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(119, 10);
			text += "\n<b>A Red Heart!</b>";
		}
		if (character.arbitrary.boughtLazyITOPOD)
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already bought the Lazy ITOPOD Shifter!</b>";
		}
		else
		{
			character.arbitrary.boughtLazyITOPOD = true;
			text += "\n<b>The Lazy ITOPOD Shifter!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack = true;
		text += "\n<b>Plus, you can PM me for a personalized compliment!</b>\n\nI'm going to save your game online, but PLEASE make a file save as well to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		StartCoroutine(character.saveLoad.uploadAGSave(forced: false));
	}

	public void onPurchaseFailure()
	{
		tooltip.showOverrideTooltip("You didn't buy anything, but it's the thought that counts <3.", 3f);
	}

	public void onGuestPurchase()
	{
		tooltip.showOverrideTooltip("You'll need to log in to your Armor Games Account in order to buy something! Or go make an account, it's free and easy!", 3f);
	}
}
