using Kongregate;
using UnityEngine;

public class KartridgeAPI : MonoBehaviour
{
	private readonly uint gameId;

	public Character character;

	public HoverTooltip tooltip;

	private static KartridgeAPI instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		if (character.platform == platform.Kartridge)
		{
			Debug.Log("Initializing SDK");
			if (Application.platform != RuntimePlatform.WindowsEditor && KartridgeBindings.KongregateAPI_RestartWithKartridgeIfNeeded(305458u))
			{
				Debug.Log("Re-launching via Kartridge");
				Application.Quit();
			}
			if (KartridgeBindings.KongregateAPI_Initialize(null))
			{
				Log("Initialized API");
			}
			else
			{
				Log("Could not initialize API, is Kartridge running?");
			}
			KartridgeBindings.KongregateAPI_SetEventCallback(OnKongregateEvent);
			if (character.platform == platform.Kartridge)
			{
				InvokeRepeating("submitBadgeProgress", 10f, 5f);
			}
		}
	}

	private void Update()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateAPI_Update();
		}
	}

	private void OnDestroy()
	{
		Debug.Log("Shutting down the Kongregate API");
		KartridgeBindings.KongregateAPI_Shutdown();
	}

	private void OnKongregateEvent(string name, string payload)
	{
		if (name == "user")
		{
			string text = KartridgeBindings.KongregateServices_GetUsername();
			if (text == "")
			{
				text = "Bob";
			}
			character.playerName = text;
		}
	}

	private void OnItemInstancesReceived()
	{
		KartridgeBindings.ItemInstance[] array = KartridgeBindings.KongregateIAP_GetItemInstances();
		Log("User item instances received:");
		KartridgeBindings.ItemInstance[] array2 = array;
		foreach (KartridgeBindings.ItemInstance itemInstance in array2)
		{
			Log("Instance Id " + itemInstance.Id + ": " + itemInstance.Identifier + ", consumable=" + itemInstance.Consumable.ToString());
		}
	}

	private void Log(string text)
	{
		Debug.Log(text);
	}

	public void submitBadgeProgress()
	{
		if (character.platform == platform.Kartridge)
		{
			if (character.settings.badge2Part1Complete)
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part1Complete", 1L);
			}
			else
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part1Complete", 0L);
			}
			if (character.settings.badge2Part2Complete)
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part2Complete", 1L);
			}
			else
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part2Complete", 0L);
			}
			if (character.settings.badge2Part3Complete)
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part3Complete", 1L);
			}
			else
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part3Complete", 0L);
			}
			if (character.settings.badge2Part4Complete)
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part4Complete", 1L);
			}
			else
			{
				KartridgeBindings.KongregateStats_Submit("Badge2Part4Complete", 0L);
			}
			if (character.highestBoss >= 7)
			{
				KartridgeBindings.KongregateStats_Submit("Badge1Complete", 1L);
			}
			else
			{
				KartridgeBindings.KongregateStats_Submit("Badge1Complete", 0L);
			}
		}
	}

	public void OnSubmitStat()
	{
		int num = Random.Range(0, 10000);
		Log("Submitting score: " + num);
		KartridgeBindings.KongregateStats_Submit("score", num);
	}

	public void OnSubmitStat2()
	{
		int num = Random.Range(0, 10000);
		Log("Submitting score2: " + num);
		KartridgeBindings.KongregateStats_Submit("score2", num);
	}

	public void startBuy20KAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap20k", consume: false, OnPurchaseItemResult);
		}
	}

	public void startBuy100KAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap100k", consume: true, OnPurchaseItemResult);
		}
	}

	public void startBuy200KAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap200k", consume: true, OnPurchaseItemResult);
		}
	}

	public void startBuy400KAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap400k", consume: true, OnPurchaseItemResult);
		}
	}

	public void startBuy1MAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap1m", consume: true, OnPurchaseItemResult);
		}
	}

	public void startBuy2MAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("ap2m", consume: true, OnPurchaseItemResult);
		}
	}

	public void startNewPlayerAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("npp", consume: true, OnPurchaseItemResult);
		}
	}

	public void startAscendedNewbieAP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("anp", consume: true, OnPurchaseItemResult);
		}
	}

	public void startAscendedNewbie2AP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("anp2", consume: true, OnPurchaseItemResult);
		}
	}

	public void startRes3AP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("res3ap", consume: true, OnPurchaseItemResult);
		}
	}

	public void startAscendedNewbie3AP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("anp3", consume: true, OnPurchaseItemResult);
		}
	}

	public void startAscendedNewbie4AP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("anp4", consume: true, OnPurchaseItemResult);
		}
	}

	public void startFashionPack1AP()
	{
		if (character.platform == platform.Kartridge)
		{
			KartridgeBindings.KongregateIAP_PurchaseItem("pic1", consume: true, OnPurchaseItemResult);
		}
	}

	public void OnPurchaseItemResult(bool success, KartridgeBindings.ItemInstance instance)
	{
		if (success)
		{
			switch (instance.Identifier)
			{
			case "ap20k":
				consume20KPurchase();
				break;
			case "ap100k":
				consume100KPurchase();
				break;
			case "ap200k":
				consume200KPurchase();
				break;
			case "ap400k":
				consume400KPurchase();
				break;
			case "ap1m":
				consume1MPurchase();
				break;
			case "ap2m":
				consume2MPurchase();
				break;
			case "npp":
				consumeNewPlayerPurchase();
				break;
			case "anp":
				consumeAscendedNewbiePurchase();
				break;
			case "anp2":
				consumeAscendedNewbiePurchase2();
				break;
			case "res3ap":
				consumeRes3Purchase();
				break;
			case "anp3":
				consumeAscendedNewbiePurchase3();
				break;
			case "pic1":
				consumeFashionPack1();
				break;
			case "anp4":
				consumeAscendedNewbiePurchase4();
				break;
			}
		}
		else
		{
			tooltip.showOverrideTooltip("You didn't buy anything, but it's the thought that counts <3.", 3f);
		}
	}

	public void consume20KPurchase()
	{
		character.addAP(20000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(20000L).ToString("###,##0") + " AP has been added!", 5f);
		character.allArbitrary.updateMenu();
	}

	public void consume100KPurchase()
	{
		character.addAP(110000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(100000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(10000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
	}

	public void consume200KPurchase()
	{
		character.addAP(225000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(200000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(25000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
	}

	public void consume400KPurchase()
	{
		character.addAP(460000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(400000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(60000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
	}

	public void consume1MPurchase()
	{
		character.addAP(1200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(1000000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(200000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
	}

	public void consume2MPurchase()
	{
		character.addAP(3200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(2500000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(700000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
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
			character.arbitrary.curArbitraryPoints += 100000L;
			text += "\n<b>An extra 100000 AP Since you already have the Improved Loot Filter!</b>";
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
		text += "\n<b>Plus, you can PM me for a personalized insult!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.APPackDisplay.refreshMenu();
		character.allArbitrary.updateMenu();
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
		character.arbitrary.beastButterCount += 4;
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
		text += "\n<b>Plus, you can PM me for a personalized compliment!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeITOPODNamePack()
	{
		character.arbitrary.nameSlotsBought++;
		if (character.arbitrary.nameSlotsBought == 1)
		{
			character.addAP(1200000);
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! Since this is your first purchase, you've received a bonus of <b>" + character.checkAPAdded(1200000L).ToString("###,##0") + "</b> AP! I have to add names manually on my server, so it may take a day or two for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Kongregate!", 12f);
		}
		else
		{
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! I have to add names manually on my server, so it may take a day or two for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Kongregate!", 12f);
		}
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeAscendedNewbiePurchase2()
	{
		string text = "Thank you so much for buying the Ascended Ascended Pack! You've received:\n\n<b>" + character.checkAPAdded(700000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>50 Poop!</b>";
		character.addAP(700000);
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
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Orange Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[293]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Orange Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[293])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Orange Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(293, 10);
			text += "\n<b>An Orange Heart!</b>";
		}
		if (character.arbitrary.hasFasterQuests)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already bought Faster Questing!</b>";
		}
		else
		{
			character.arbitrary.hasFasterQuests = true;
			text += "\n<b>Faster Questing!</b>";
		}
		character.inventory.unlockedKittyArt[3] = true;
		text += "\n<b>THE GOLDEN KITTY</b>";
		character.arbitrary.boughtAscendedNewbiePack2 = true;
		text += "\n<b>Plus, you can PM me for a personalized pun!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeRes3Purchase()
	{
		string text = "Thank you so much for buying the Resource 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of each Resource 3 Potion!</b>";
		character.addAP(600000);
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Grey Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[297]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Grey Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[297])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Grey Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(297, 10);
			text += "\n<b>A Grey Heart!</b>";
		}
		text += "\n<b>You can now fully customize Resource 3's Colour! Check Page 2 of the Settings Menu.</b>";
		character.arbitrary.boughtRes3Pack = true;
		text += "\n<b>Plus, you can PM me for a personalized NUMBER! No one else can have the number I give you, it's yours and yours alone.</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeAscendedNewbiePurchase3()
	{
		string text = "Thank you so much for buying the Ascended ^ 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(500000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(500000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Blue Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[196]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Blue Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[196])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Blue Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(196, 10);
			text += "\n<b>A Blue Heart!</b>";
		}
		if (character.arbitrary.wishSpeedBoster)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already bought Faster Wishes!</b>";
		}
		else
		{
			character.arbitrary.wishSpeedBoster = true;
			text += "\n<b>Faster Wishes!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack3 = true;
		text += "\n<b>Plus, you can PM me, and i'll send back a kitten pic or video!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeFashionPack1()
	{
		character.arbitrary.boughtFashionPack1 = true;
		character.portraits.portraitUnlocked[1] = true;
		character.portraits.portraitUnlocked[2] = true;
		character.portraits.portraitUnlocked[3] = true;
		character.portraits.portraitUnlocked[4] = true;
		character.portraits.portraitUnlocked[5] = true;
		character.portraits.portraitUnlocked[6] = true;
		character.portraits.portraitUnlocked[7] = true;
		character.portraits.portraitUnlocked[8] = true;
		character.portraits.portraitUnlocked[9] = true;
		character.portraits.portraitUnlocked[10] = true;
		character.addAP(200000);
		string message = "Thank you so much for buying the Sexy Player Fashion Pack! You've unlocked 10 sexy new pics for your player in the Fight Boss Menu, PLUS a bonus " + character.checkAPAdded(200000L).ToString("###,##0") + "AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(message, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	public void consumeAscendedNewbiePurchase4()
	{
		string text = "Thank you so much for buying the Ascended ^ 4 Pack! You've received:\n\n<b>" + character.checkAPAdded(300000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(300000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		character.arbitrary.mayoSpeedPotCount += 4;
		character.arbitrary.cardTierUpperCount += 100;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had no space for the Rainbow Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[390]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had the Rainbow Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[390])
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you already had a maxxed out Rainbow Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(390, 10);
			text += "\n<b>A Rainbow Heart!</b>";
		}
		if (!character.arbitrary.boughtFoils)
		{
			character.arbitrary.boughtFoils = true;
			text += "\n<b>Perma Foils!</b>";
		}
		else
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already have Perma Foils!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack4 = true;
		text += "\n<b>Plus, you can PM me, and I'll do something... weird.</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}
}
