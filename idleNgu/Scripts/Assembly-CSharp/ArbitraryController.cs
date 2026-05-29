using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArbitraryController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Text APDisplay;

	public Image itemImage;

	public Text itemInfo;

	public Button buyAPButton;

	public int id;

	public string itemName;

	private string message;

	public string tooltipMessage;

	private UnityAction yesAction;

	private UnityAction noAction;

	public int menu;

	public int baseEnergyPotion1Cost = 5000;

	public int baseEnergyPotion2Cost = 10000;

	public int baseMagicPotion1Cost = 5000;

	public int baseMagicPotion2Cost = 10000;

	public int baselootCharm1Cost = 5000;

	public int baseEnergyBarBar1Cost = 10000;

	public int baseMagicBarBar1Cost = 10000;

	public void Start()
	{
		noAction = cancel;
		if (id <= 6 || id == 26 || id == 27 || id == 30 || id == 59 || id == 60 || id == 61 || id == 79)
		{
			InvokeRepeating("updateMenu", 0f, 0.1f);
		}
	}

	public int energyPotion1Cost()
	{
		int num = 5000;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int energyPotion2Cost()
	{
		return 10000;
	}

	public int energyPotion3Cost()
	{
		return 100000;
	}

	public int magicPotion1Cost()
	{
		int num = 5000;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int magicPotion2Cost()
	{
		int num = 10000;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int magicPotion3Cost()
	{
		return 100000;
	}

	public int res3Potion1Cost()
	{
		int num = 4000;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int res3Potion2Cost()
	{
		return 40000;
	}

	public int res3Potion3Cost()
	{
		return 40000;
	}

	public int energyBarBar1Cost()
	{
		int num = baseEnergyBarBar1Cost;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int magicBarBar1Cost()
	{
		int num = baseMagicBarBar1Cost;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int lootCharm1Cost()
	{
		int num = baselootCharm1Cost;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int energyCapCost()
	{
		int num = 7500;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int magicCapCost()
	{
		int num = 7500;
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public long lootFilterCost()
	{
		return 100000L;
	}

	public long autoBoostMergeCost()
	{
		return 100000L;
	}

	public long instaTrainCost()
	{
		return 10000L;
	}

	public long exp500Cost()
	{
		return 100000L;
	}

	public long exp200Cost()
	{
		return 40000L;
	}

	public long exp2KCost()
	{
		return 400000L;
	}

	public long heartCost()
	{
		return 225000L;
	}

	public long customPercentSet1Cost()
	{
		return 25000L;
	}

	public long customPercentSet2Cost()
	{
		return 100000L;
	}

	public long customIdlePercentSet1Cost()
	{
		return 125000L;
	}

	public long res3PercentSet1Cost()
	{
		return 50000L;
	}

	public long res3PercentSet2Cost()
	{
		return 150000L;
	}

	public long res3IdlePercentSet1Cost()
	{
		return 150000L;
	}

	public long nguCapModifierCost()
	{
		return 100000L;
	}

	public void addPoints(int points)
	{
		character.arbitrary.curArbitraryPoints += points;
		character.arbitrary.lifetimePoints += points;
	}

	public long yellowHeartCost()
	{
		return 150000L;
	}

	public long inventoryCost()
	{
		long num = 3000 + character.arbitrary.inventorySpaces * 100;
		if (character.arbitrary.boughtNewbiePack)
		{
			num -= 1200;
		}
		if (num > 10000)
		{
			num = 10000L;
		}
		return num;
	}

	public long maxSpaces()
	{
		return 166L;
	}

	public long maxLoadoutSpaces()
	{
		return 7L;
	}

	public long maxBeardSpaces()
	{
		return 4L;
	}

	public long maxDiggerSpaces()
	{
		return 6L;
	}

	public long maxMacguffinSpaces()
	{
		return 11L;
	}

	public int maxInvMergeSpaces()
	{
		return 4;
	}

	public int maxDeckSpaces()
	{
		return 50;
	}

	public int maxMayoGenSlots()
	{
		return 2;
	}

	public long starterPackCost()
	{
		return 75000L;
	}

	public long acc4Cost()
	{
		return 225000L;
	}

	public long acc5Cost()
	{
		return 225000L;
	}

	public long acc6Cost()
	{
		return 500000L;
	}

	public long acc7Cost()
	{
		return 500000L;
	}

	public long acc8Cost()
	{
		return 500000L;
	}

	public long acc9Cost()
	{
		return 675000L;
	}

	public long poop1Cost()
	{
		return 3000L;
	}

	public long poop10Cost()
	{
		return 25000L;
	}

	public long poop100Cost()
	{
		return 225000L;
	}

	public long yggdrasilReminderCost()
	{
		return 50000L;
	}

	public long extendedSpinBankCost()
	{
		return 100000L;
	}

	public long loadoutSlotCost()
	{
		return 50000 + character.arbitrary.curLoadoutSlots * 10000;
	}

	public long beardSlotCost()
	{
		if (character.arbitrary.beardSlots >= 1)
		{
			return 225000L;
		}
		return 110000L;
	}

	public long diggerSlotCost()
	{
		if (character.arbitrary.diggerSlots >= 1)
		{
			return 225000L;
		}
		return 110000L;
	}

	public long infinityCubeFilterCost()
	{
		return 15000L;
	}

	public long lootCharm2Cost()
	{
		return 50000L;
	}

	public long heartBrownCost()
	{
		return 225000L;
	}

	public long heartGreenCost()
	{
		return 225000L;
	}

	public long heartBlueCost()
	{
		return 225000L;
	}

	public long heartPurpleCost()
	{
		return 225000L;
	}

	public long heartGreyCost()
	{
		return 225000L;
	}

	public long heartOrangeCost()
	{
		return 225000L;
	}

	public long heartPinkCost()
	{
		return 175000L;
	}

	public long heartRainbowCost()
	{
		return 500000L;
	}

	public long daycareSpeedCost()
	{
		return 125000L;
	}

	public long pill1Cost()
	{
		return 2500L;
	}

	public long pill10Cost()
	{
		return 20000L;
	}

	public long pill100Cost()
	{
		return 175000L;
	}

	public long lazyITOPODCost()
	{
		return 225000L;
	}

	public long macguffinSlotCost()
	{
		if (character.arbitrary.macguffinSlots < 2)
		{
			return 100000L;
		}
		return 225000L;
	}

	public long remainingInvCost(int limit)
	{
		long num = inventoryCost();
		long num2 = character.arbitrary.inventorySpaces;
		long num3 = 0L;
		long num4 = 0L;
		while (num2 < maxSpaces() && num4 < limit)
		{
			num2++;
			num4++;
			num3 += num;
			num += 100;
			if (num > 10000)
			{
				num = 10000L;
			}
		}
		return num3;
	}

	public long macguffinBooster1Cost()
	{
		return 50000L;
	}

	public long beastButter1Cost()
	{
		return 10000L;
	}

	public long beastButter10Cost()
	{
		return 90000L;
	}

	public long beastButter100Cost()
	{
		return 800000L;
	}

	public long questLightCost()
	{
		return 50000L;
	}

	public long fasterQuests1Cost()
	{
		return 250000L;
	}

	public long extendedQuestBankCost()
	{
		return 125000L;
	}

	public long PP25Cost()
	{
		return 100000L;
	}

	public long PP100Cost()
	{
		return 400000L;
	}

	public long PP500Cost()
	{
		return 2000000L;
	}

	public long autoNukeCost()
	{
		return 65000L;
	}

	public long daycareArtCost()
	{
		return 250000L;
	}

	public long res3NameGenratorCost()
	{
		return 85000L;
	}

	public long fasterWishesCost()
	{
		return 250000L;
	}

	public long invMergeSlotCost()
	{
		switch (character.arbitrary.invMergeSlots)
		{
		case 0:
			return 50000L;
		case 1:
			return 150000L;
		case 2:
			return 250000L;
		default:
			return 500000L;
		}
	}

	public long advLightCost()
	{
		return 75000L;
	}

	public long advAdvancerCost()
	{
		return 65000L;
	}

	public long goToQuestCost()
	{
		return 100000L;
	}

	public long mayoGenCost()
	{
		return 250000L;
	}

	public long tagSlotCost()
	{
		return 250000L;
	}

	public long deckSizeCost()
	{
		return 25000L;
	}

	public long cardTierConsumableCost()
	{
		return 40000L;
	}

	public long mayoSpeedConsumableCost()
	{
		return 40000L;
	}

	public void startEnergyPotion1AP()
	{
		if (character.arbitrary.curArbitraryPoints < energyPotion1Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy an Energy Potion α! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyEnergyPotion1AP;
		box.displayBox("Are you sure you want to buy an Energy Potion α for " + energyPotion1Cost() + " AP?", yesAction, noAction);
	}

	public void buyEnergyPotion1AP()
	{
		character.arbitrary.curArbitraryPoints -= energyPotion1Cost();
		character.arbitrary.energyPotion1Count++;
		updateMenu();
	}

	public void startEnergyPotion2AP()
	{
		if (character.arbitrary.curArbitraryPoints < energyPotion2Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy an Energy Potion β! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyEnergyPotion2AP;
		box.displayBox("Are you sure you want to buy an Energy Potion β for " + energyPotion2Cost() + " AP?", yesAction, noAction);
	}

	public void buyEnergyPotion2AP()
	{
		character.arbitrary.curArbitraryPoints -= energyPotion2Cost();
		character.arbitrary.energyPotion2Count++;
		updateMenu();
	}

	public void startEnergyPotion3AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyEnergyPotion3;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyEnergyPotion3()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.energyPotion3Count++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startMagicPotion1AP()
	{
		if (character.arbitrary.curArbitraryPoints < magicPotion1Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy a " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyMagicPotion1AP;
		box.displayBox("Are you sure you want to buy a Magic Potion α for " + magicPotion1Cost() + " AP?", yesAction, noAction);
	}

	public void buyMagicPotion1AP()
	{
		character.arbitrary.curArbitraryPoints -= magicPotion1Cost();
		character.arbitrary.magicPotion1Count++;
		updateMenu();
	}

	public void startMagicPotion2AP()
	{
		if (character.arbitrary.curArbitraryPoints < magicPotion2Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy a " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyMagicPotion2AP;
		box.displayBox("Are you sure you want to buy a Magic Potion β for " + magicPotion2Cost() + " AP?", yesAction, noAction);
	}

	public void buyMagicPotion2AP()
	{
		character.arbitrary.curArbitraryPoints -= magicPotion2Cost();
		character.arbitrary.magicPotion2Count++;
		updateMenu();
	}

	public void startMagicPotion3AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyMagicPotion3;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyMagicPotion3()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.magicPotion3Count++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startRes3Potion1AP()
	{
		if (!character.res3.res3On)
		{
			tooltip.showOverrideTooltip("You haven't yet progressed far enough for this item to be relevant to you. You'll get there soon, friend.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + character.res3.res3Name + " Potion α!", 2f);
			return;
		}
		yesAction = buyRes3Potion1;
		box.displayBox("Are you sure you want to buy " + character.res3.res3Name + " Potion α for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3Potion1()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.res3Potion1Count++;
		tooltip.showTooltip("You've successfully bought " + character.res3.res3Name + " Potion α!", 2f);
		updateMenu();
	}

	public void startRes3Potion2AP()
	{
		if (!character.res3.res3On)
		{
			tooltip.showOverrideTooltip("You haven't yet progressed far enough for this item to be relevant to you. You'll get there soon, friend.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + character.res3.res3Name + " Potion β!", 2f);
			return;
		}
		yesAction = buyRes3Potion2;
		box.displayBox("Are you sure you want to buy " + character.res3.res3Name + " Potion β for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3Potion2()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.res3Potion2Count++;
		tooltip.showTooltip("You've successfully bought " + character.res3.res3Name + " Potion β!", 2f);
		updateMenu();
	}

	public void startRes3Potion3AP()
	{
		if (!character.res3.res3On)
		{
			tooltip.showOverrideTooltip("You haven't yet progressed far enough for this item to be relevant to you. You'll get there soon, friend.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + character.res3.res3Name + " Potion δ!", 2f);
			return;
		}
		yesAction = buyRes3Potion3;
		box.displayBox("Are you sure you want to buy " + character.res3.res3Name + " Potion δ for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3Potion3()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.res3Potion3Count++;
		tooltip.showTooltip("You've successfully bought " + character.res3.res3Name + " Potion δ!", 2f);
		updateMenu();
	}

	public void startLootCharm1AP()
	{
		if (character.arbitrary.curArbitraryPoints < lootCharm1Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy a Looting Charm! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyLootCharm1AP;
		box.displayBox("Are you sure you want to buy a Looting Charm for " + lootCharm1Cost() + " AP?", yesAction, noAction);
	}

	public void buyLootCharm1AP()
	{
		character.arbitrary.curArbitraryPoints -= lootCharm1Cost();
		character.arbitrary.lootCharm1Count++;
		updateMenu();
	}

	public void startEnergyBarBar1AP()
	{
		if (character.arbitrary.curArbitraryPoints < energyBarBar1Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy an Energy Bar Bar! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyEnergyBarBar1AP;
		box.displayBox("Are you sure you want to buy an Energy Bar Bar for " + energyBarBar1Cost() + " AP?", yesAction, noAction);
	}

	public void buyEnergyBarBar1AP()
	{
		character.arbitrary.curArbitraryPoints -= energyBarBar1Cost();
		character.arbitrary.energyBarBar1Count++;
		updateMenu();
	}

	public void startMagicBarBar1AP()
	{
		if (character.arbitrary.curArbitraryPoints < magicBarBar1Cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy a Magic Bar Bar! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyMagicBarBar1AP;
		box.displayBox("Are you sure you want to buy a Magic Bar Bar for " + magicBarBar1Cost() + " AP?", yesAction, noAction);
	}

	public void buyMagicBarBar1AP()
	{
		character.arbitrary.curArbitraryPoints -= magicBarBar1Cost();
		character.arbitrary.magicBarBar1Count++;
		updateMenu();
	}

	public void startLootFilterAP()
	{
		if (character.arbitrary.lootFilter)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought the improved Loot Filter!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < lootFilterCost())
		{
			tooltip.showTooltip("You don't have enough AP to buy the improved Loot Filter! Though to be fair, it costs a fair bit.", 3f);
			return;
		}
		yesAction = buyLootFilterAP;
		box.displayBox("Are you sure you want to buy the improved Loot Filter for " + lootFilterCost() + " AP?", yesAction, noAction);
	}

	public void buyLootFilterAP()
	{
		character.arbitrary.curArbitraryPoints -= lootFilterCost();
		character.arbitrary.lootFilter = true;
		updateMenu();
	}

	public void startAutoMergeBoostAP()
	{
		if (character.arbitrary.improvedAutoBoostMerge)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought Reduced Auto Boost and Merge Timers!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < autoBoostMergeCost())
		{
			tooltip.showTooltip("You don't have enough AP to buy Reduced Auto Boost and Merge Timers! Though to be fair, it costs a hell of a lot.", 3f);
			return;
		}
		yesAction = buyAutoBoostMergeAP;
		box.displayBox("Are you sure you want to buy Reduced Auto Boost and Merge Timers for " + autoBoostMergeCost() + " AP?", yesAction, noAction);
	}

	public void buyAutoBoostMergeAP()
	{
		character.arbitrary.curArbitraryPoints -= autoBoostMergeCost();
		character.arbitrary.improvedAutoBoostMerge = true;
		updateMenu();
	}

	public void startInstaTrainingAP()
	{
		if (character.arbitrary.instaTrain)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < instaTrainCost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 3f);
			return;
		}
		yesAction = buyInstaTrainAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + instaTrainCost() + " AP?", yesAction, noAction);
	}

	public void buyInstaTrainAP()
	{
		character.arbitrary.curArbitraryPoints -= instaTrainCost();
		character.arbitrary.instaTrain = true;
		updateMenu();
	}

	public void start500ExpAP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy500ExpAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy500ExpAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.addExp(500L);
		tooltip.showTooltip("You've successfully bought 500 Exp! Classy!", 2f);
		updateMenu();
	}

	public void start200ExpAP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy200ExpAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy200ExpAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.addExp(200L);
		tooltip.showTooltip("You've successfully bought 200 Exp! Stylish!", 2f);
		updateMenu();
	}

	public void start2KExpAP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy2KExpAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy2KExpAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.addExp(2000L);
		tooltip.showTooltip("You've successfully bought 2000 Exp! Ritzy!", 2f);
		updateMenu();
	}

	public void startHeartAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[119])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(119, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startCustomPercent1AP()
	{
		if (character.purchases.hasCustomEnergyPercent1 && character.purchases.hasCustomMagicPercent1)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyCustomPercent1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyCustomPercent1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomEnergyPercent1 = true;
		character.purchases.hasCustomMagicPercent1 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startCustomPercent2AP()
	{
		if (character.purchases.hasCustomEnergyPercent2 && character.purchases.hasCustomMagicPercent2)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyCustomPercent2AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyCustomPercent2AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomEnergyPercent2 = true;
		character.purchases.hasCustomMagicPercent2 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startCustomIdlePercent1AP()
	{
		if (character.purchases.hasCustomIdleEnergyPercent1 && character.purchases.hasCustomIdleMagicPercent1)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyCustomIdlePercent1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyCustomIdlePercent1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomIdleEnergyPercent1 = true;
		character.purchases.hasCustomIdleMagicPercent1 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startRes3Percent1AP()
	{
		if (character.purchases.hasCustomRes3Percent1)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyRes3Percent1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3Percent1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomRes3Percent1 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startRes3Percent2AP()
	{
		if (character.purchases.hasCustomRes3Percent2)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyRes3Percent2AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3Percent2AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomRes3Percent2 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startRes3IdlePercent1AP()
	{
		if (character.purchases.hasCustomIdleRes3Percent1)
		{
			tooltip.showTooltip("Are you so eager to throw away all your AP? You already bought " + itemName + ".", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyRes3IdlePercent1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3IdlePercent1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.purchases.hasCustomIdleRes3Percent1 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startYellowHeartAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[129])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyYellowHeartAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyYellowHeartAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(129, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startInventoryAP()
	{
		if (character.arbitrary.inventorySpaces >= maxSpaces())
		{
			tooltip.showTooltip("You've bought the max number of spaces available with AP (for now!)", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyInventoryAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyInventoryAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.inventorySpaces++;
		string text = "You've successfully bought\nExtra Inventory ";
		text = text.PadRight(text.Length + character.arbitrary.inventorySpaces);
		tooltip.showTooltip(text + "Space!", 2f);
		character.inventoryController.updateInvCount();
		updateMenu();
	}

	public void start10InventoryAP()
	{
		if (character.arbitrary.inventorySpaces >= maxSpaces())
		{
			tooltip.showTooltip("You've bought the max number of spaces available with AP (for now!)", 2f);
			return;
		}
		long num = remainingInvCost(10);
		if (character.arbitrary.curArbitraryPoints < num)
		{
			tooltip.showTooltip("You don't have enough AP to buy 10 inventory slots!", 2f);
			return;
		}
		yesAction = buy10InventoryAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + num + " AP?", yesAction, noAction);
	}

	public void buy10InventoryAP()
	{
		character.arbitrary.curArbitraryPoints -= remainingInvCost(10);
		character.arbitrary.inventorySpaces += 10;
		if (character.arbitrary.inventorySpaces > maxSpaces())
		{
			character.arbitrary.inventorySpaces = (int)maxSpaces();
		}
		tooltip.showTooltip("You've successfully bought all the inventory space!", 2f);
		character.inventoryController.updateInvCount();
		updateMenu();
	}

	public void startStarterPackAP()
	{
		if (character.arbitrary.hasStarterPack)
		{
			tooltip.showTooltip("You can only buy this once, that's why it's a STARTER pack!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyStarterPackAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyStarterPackAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.addExp(500L);
		character.arbitrary.inventorySpaces += 5;
		if (character.arbitrary.inventorySpaces > maxSpaces())
		{
			character.arbitrary.inventorySpaces = (int)maxSpaces();
		}
		character.inventoryController.updateInvCount();
		character.arbitrary.hasStarterPack = true;
		tooltip.showTooltip("You've successfully bought the " + itemName + "! Don't forget to PM me for a free personalized insult!", 4f);
		updateMenu();
	}

	public void startAcc4AP()
	{
		if (character.arbitrary.hasAcc4)
		{
			tooltip.showTooltip("Ahem... you already bought this. Yeah. Bye.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc4AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc4AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc4 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startAcc5AP()
	{
		if (character.arbitrary.hasAcc5)
		{
			tooltip.showTooltip("Ahem... you already bought this. Yeah. Bye.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc5AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc5AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc5 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startAcc6AP()
	{
		if (character.arbitrary.hasAcc6)
		{
			tooltip.showTooltip("Ahem... you already bought this. Yeah. Bye.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc6AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc6AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc6 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startAcc7AP()
	{
		if (character.arbitrary.hasAcc7)
		{
			tooltip.showTooltip("You bought this. You do not need to buy it again. Authorities have been notified and will terminate you in 3...2...1...", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc7AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc7AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc7 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startAcc8AP()
	{
		if (character.arbitrary.hasAcc8)
		{
			tooltip.showTooltip("You bought this. You do not need to buy it again. Authorities have been notified and will terminate you in 3...2...1...", 2f);
			return;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			tooltip.showTooltip("You aren't in Evil difficulty or above so you can't buy this! I'm such a meanie, aren't I.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc8AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc8AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc8 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startAcc9AP()
	{
		if (character.arbitrary.hasAcc9)
		{
			tooltip.showTooltip("You bought this. You do not need to buy it again. Authorities have been notified and will terminate you in 3...2...1...", 2f);
			return;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			tooltip.showTooltip("You aren't in Evil difficulty or above so you can't buy this! I'm such a meanie, aren't I.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAcc9AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAcc9AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasAcc9 = true;
		character.inventoryController.updateInventory();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		character.inventoryController.updateAccCount();
		updateMenu();
	}

	public void startPoop1AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy 1 " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPoop1AP;
		box.displayBox("Are you sure you want to buy 1 " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPoop1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.poop1Count++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startPoop10AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy 10 " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPoop10AP;
		box.displayBox("Are you sure you want to buy 10 " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPoop10AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.poop1Count += 10;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startPoop100AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy 100 " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPoop100AP;
		box.displayBox("Are you sure you want to buy 100 " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPoop100AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.poop1Count += 100;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startYggReminderAP()
	{
		if (character.arbitrary.hasYggdrasilReminder)
		{
			tooltip.showTooltip("I guess I need to REMIND you that you already bought this reminder.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyYggReminderAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyYggReminderAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasYggdrasilReminder = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startExtendedSpinBankAP()
	{
		if (character.arbitrary.hasExtendedSpinBank)
		{
			tooltip.showTooltip("You already bought " + itemName + "!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyExtendedSpinBankAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyExtendedSpinBankAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasExtendedSpinBank = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startLoadoutSlotAP()
	{
		if (character.arbitrary.curLoadoutSlots >= maxLoadoutSpaces())
		{
			tooltip.showTooltip("You already bought all the loadout slots you can get with AP!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyLoadoutSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyLoadoutSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.curLoadoutSlots++;
		tooltip.showTooltip("You've successfully bought a " + itemName + "!", 4f);
		updateMenu();
	}

	public void startBeardAP()
	{
		if (!character.settings.beardsOn)
		{
			tooltip.showTooltip("You don't even have beards unlocked yet! Why are you trying to buy this?", 2f);
			return;
		}
		if (character.arbitrary.beardSlots >= maxBeardSpaces())
		{
			tooltip.showTooltip("You already bought all the beard slots you can get with AP!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyBeardAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyBeardAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.beardSlots++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startCubeFilterAP()
	{
		if (character.arbitrary.hasCubeFilter)
		{
			tooltip.showTooltip("You already bought this. Look, see where it says 'BOUGHT'?", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyCubeFilterAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyCubeFilterAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasCubeFilter = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startLootCharm2AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyLootCharm2AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyLootCharm2AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.lootCharm2Count++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startHeartBrown()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[162])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartBrown;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartBrown()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(162, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startDaycareSpeedAP()
	{
		if (character.arbitrary.hasDaycareSpeed)
		{
			tooltip.showOverrideTooltip("You already bought this! This thing here. Yeah, it's been bought. I see the 'Bought!' text right there.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyDaycareSpeedAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyDaycareSpeedAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasDaycareSpeed = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startHeartGreenAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[171])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartGreenAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartGreenAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(171, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	private void cancel()
	{
	}

	public void startPill1AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPill1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPill1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.buffedKills += 1000L;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
		character.adventureController.updatePillUI();
	}

	public void startPill10AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPill10AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPill10AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.buffedKills += 10000L;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
		character.adventureController.updatePillUI();
	}

	public void startPill100AP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyPill100AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyPill100AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.buffedKills += 100000L;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
		character.adventureController.updatePillUI();
	}

	public void startHeartBlueAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[196])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartBlueAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartBlueAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(196, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startLazyITOPODAP()
	{
		if (character.arbitrary.boughtLazyITOPOD)
		{
			tooltip.showOverrideTooltip("You already bought this! Waste your AP elsewhere!", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyLazyITOPODAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyLazyITOPODAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.boughtLazyITOPOD = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startDiggerSlotAP()
	{
		if (!character.settings.diggersOn)
		{
			tooltip.showTooltip("You don't even have diggers unlocked yet! Why are you trying to buy this?", 2f);
			return;
		}
		if (character.arbitrary.diggerSlots >= maxDiggerSpaces())
		{
			tooltip.showTooltip("You already bought all the digger slots you can get with AP!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyDiggerSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyDiggerSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.diggerSlots++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startMacguffinSlotAP()
	{
		if (!character.achievements.achievementComplete[145])
		{
			tooltip.showTooltip("You don't even have MacGuffins unlocked yet! Why are you trying to buy this?", 2f);
			return;
		}
		if (character.arbitrary.macguffinSlots >= maxMacguffinSpaces())
		{
			tooltip.showTooltip("You already bought all the MacGuffin slots you can get with AP!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyMacguffinSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyMacguffinSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.macguffinSlots++;
		character.inventoryController.updateMacguffinCount();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startHeartPurpleAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[212])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartPurpleAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartPurpleAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(212, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startHeartGreyAP()
	{
		if (!character.res3.res3On)
		{
			tooltip.showOverrideTooltip("You haven't yet progressed far enough for this item to be relevant to you. You'll get there soon, friend.", 2f);
			return;
		}
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[297])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartGreyAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartGreyAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(297, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startMacguffinBooster1AP()
	{
		if (!character.achievements.achievementComplete[145])
		{
			tooltip.showTooltip("You haven't even unlocked MacGuffins yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyMacguffinBooster1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyMacguffinBooster1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.macGuffinBooster1Count++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startBeastButter1AP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyBeastButter1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyBeastButter1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.beastButterCount++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startBeastButter10AP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyBeastButter10AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyBeastButter10AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.beastButterCount += 10;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startBeastButter100AP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyBeastButter100AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyBeastButter100AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.beastButterCount += 100;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startQuestLightAP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyQuestLightAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyQuestLightAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasQuestLight = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startFasterQuests1AP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyFasterQuests1AP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyFasterQuests1AP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasFasterQuests = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startExtendedQuestBankAP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You haven't even unlocked Questing yet! Don't bother trying to buy this til you do. It's for your own good.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyExtendedQuestBankAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyExtendedQuestBankAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasExtendedQuestBank = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startHeartOrangeAP()
	{
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[293])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartOrangeAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartOrangeAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(293, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void start25ppAP()
	{
		if (!character.settings.itopodOn)
		{
			tooltip.showTooltip("I appreciate yer moxie kid, but ya gotta have the ITOPOD unlocked to even use this dang currency!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy25ppAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy25ppAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.perkPoints += 25L;
		tooltip.showTooltip("You've successfully bought 25 PP! Cool Beans!", 2f);
		updateMenu();
	}

	public void start100ppAP()
	{
		if (!character.settings.itopodOn)
		{
			tooltip.showTooltip("I appreciate yer moxie kid, but ya gotta have the ITOPOD unlocked to even use this dang currency!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy100ppAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy100ppAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.perkPoints += 100L;
		tooltip.showTooltip("You've successfully bought 100 PP! Cooler Beans!", 2f);
		updateMenu();
	}

	public void start500ppAP()
	{
		if (!character.settings.itopodOn)
		{
			tooltip.showTooltip("I appreciate yer moxie kid, but ya gotta have the ITOPOD unlocked to even use this dang currency!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buy500ppAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buy500ppAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.adventure.itopod.perkPoints += 500L;
		tooltip.showTooltip("You've successfully bought 500 PP! Coolest Beans!", 2f);
		updateMenu();
	}

	public void startAutoNukeAP()
	{
		if (character.arbitrary.boughtAutoNuke)
		{
			tooltip.showTooltip("You bought this already. SMH.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAutoNukeAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAutoNukeAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.boughtAutoNuke = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startDaycareArtAP()
	{
		if (character.arbitrary.boughtDaycareArt)
		{
			tooltip.showTooltip("You bought this already. The Daycare Kitty is at maximum happy!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyDaycareArtAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyDaycareArtAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.boughtDaycareArt = true;
		character.inventoryController.updateKittyArtCount();
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startNGUCapModifierAP()
	{
		if (character.arbitrary.hasNGUCapModifier)
		{
			tooltip.showTooltip("You bought this already. Now go before I bust a cap in your ass!", 2f);
			return;
		}
		if (!character.settings.nguOn)
		{
			tooltip.showOverrideTooltip("You don't even have an NGU, you can't buy this. Confused about what an NGU is? You'll soon learn, my child.", 2.5f);
			return;
		}
		if (!character.settings.beastOn)
		{
			tooltip.showOverrideTooltip("This purchase is tied to some advanced NGU functions which you will unlock later. Come back when you've got those first!", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyNGUCapModifierAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyNGUCapModifierAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.hasNGUCapModifier = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startRes3NameGeneratorAP()
	{
		if (!character.res3.res3On)
		{
			tooltip.showOverrideTooltip("This purchase is for those with Resource 3 unlocked. Come back when you've got that first!", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyRes3NameGeneratorAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyRes3NameGeneratorAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.res3NameGeneratorBought = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startFasterWishAP()
	{
		if (!character.wishes.wishesOn)
		{
			tooltip.showOverrideTooltip("This purchase is something you haven't unlocked. Come back when you've got that first!", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyFasterWishAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyFasterWishAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.wishSpeedBoster = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startInvMergeSlotAP()
	{
		if (!character.purchases.hasAutoMerge)
		{
			tooltip.showTooltip("You don't even have Automerge unlocked yet! Why are you trying to buy this?", 2f);
			return;
		}
		if (character.arbitrary.invMergeSlots >= maxInvMergeSpaces())
		{
			tooltip.showTooltip("You already bought all the Inventory Merge slots you can get with AP!", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "! Haha, you're poor.", 3f);
			return;
		}
		yesAction = buyInvMergeSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyInvMergeSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.invMergeSlots++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 4f);
		updateMenu();
	}

	public void startHeartPinkAP()
	{
		if (!character.res3.res3On || !character.wishes.wishesOn)
		{
			tooltip.showOverrideTooltip("You haven't yet progressed far enough for this item to be relevant to you. You'll get there soon, friend.", 2f);
			return;
		}
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[344])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartPinkAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartPinkAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(344, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startAdvLightAP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAdvLightAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAdvLightAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.advLightBought = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startAdvAdvancerAP()
	{
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyAdvAdvancerAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyAdvAdvancerAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.advAdvancerBought = true;
		character.adventure.didAdvAdvance = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startGoToQuestAP()
	{
		if (!character.settings.beastOn)
		{
			tooltip.showTooltip("You don't even have Quests unlocked! Go away 'til you have it.", 2f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyGoToQuestAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyGoToQuestAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.goToQuestZoneBought = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startDeckSlotAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showTooltip("You don't even have Cards to begin with - Come back once you actually have them, buttbreath.", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		if (character.arbitrary.deckSpaceBought >= maxDeckSpaces())
		{
			tooltip.showTooltip("You've already bought all the Max Deck Size you can! That deck is so huge it could be used as a murder weapon...", 2.5f);
			return;
		}
		yesAction = buyDeckSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyDeckSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.deckSpaceBought++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startMayoGenAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showTooltip("You don't even have Cards to begin with - Come back once you actually have them, buttbreath.", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		if (character.arbitrary.mayoGenSlots >= maxMayoGenSlots())
		{
			tooltip.showTooltip("You've already bought all the Mayo Generators you can! You have one hell of an addiction to Mayo...", 2.5f);
			return;
		}
		yesAction = buyMayoGenAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyMayoGenAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.mayoGenSlots++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startTagSlotAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showTooltip("You don't even have Cards to begin with - Come back once you actually have them, buttbreath.", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		if (character.arbitrary.gotTagslot1)
		{
			tooltip.showTooltip("You've already bought this Tag Slot, ya frickin' hoser!", 2.5f);
			return;
		}
		yesAction = buyTagSlotAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyTagSlotAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.gotTagslot1 = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startMayoSpeedConsumableAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showTooltip("You don't even have Cards to begin with - Come back once you actually have them, buttbreath.", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyMayoSpeedConsumableAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyMayoSpeedConsumableAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.mayoSpeedPotCount++;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startCardTierConsumableAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showTooltip("You don't even have Cards to begin with - Come back once you actually have them, buttbreath.", 2.5f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyCardTierConsumableAP;
		box.displayBox("Are you sure you want to buy 25 " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyCardTierConsumableAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.cardTierUpperCount += 25;
		tooltip.showTooltip("You've successfully bought 25 " + itemName + "!", 2f);
		updateMenu();
	}

	public void startHeartRainbowAP()
	{
		if (!character.cards.cardsOn)
		{
			tooltip.showOverrideTooltip("Hol' up - this heart is meant for later in progression. It would be too OP for you now. Try later!", 4f);
			return;
		}
		if (!character.inventoryController.freeSpace())
		{
			tooltip.showOverrideTooltip("Hold on! Free up space in your inventory first!", 3f);
			return;
		}
		if (character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[390])
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.settings.filterOn && character.settings.filterAccessory)
		{
			tooltip.showOverrideTooltip("Hold on! Don't filter this item, bozo the clown.", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyHeartRainbowAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyHeartRainbowAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.itemInfo.makeLevelledLoot(390, 10);
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void startFoilUnlockAP()
	{
		if (character.arbitrary.boughtFoils)
		{
			tooltip.showTooltip("You already bought this, dimwit - if your cards were any shinier they'd set fire to your eyeballs!", 3f);
			return;
		}
		if (character.arbitrary.curArbitraryPoints < cost())
		{
			tooltip.showTooltip("You don't have enough AP to buy " + itemName + "!", 2f);
			return;
		}
		yesAction = buyFoilUnlockAP;
		box.displayBox("Are you sure you want to buy " + itemName + " for " + cost() + " AP?", yesAction, noAction);
	}

	public void buyFoilUnlockAP()
	{
		character.arbitrary.curArbitraryPoints -= cost();
		character.arbitrary.boughtFoils = true;
		tooltip.showTooltip("You've successfully bought " + itemName + "!", 2f);
		updateMenu();
	}

	public void updateMenu()
	{
		if (character.menuID != menu)
		{
			return;
		}
		if (id == 35 || id == 36 || id == 37)
		{
			updatePill();
			return;
		}
		if (id >= 7 && (id < 18 || id > 20) && id != 26 && id != 27 && id != 30 && id != 43 && (id < 44 || id > 46) && (id < 59 || id > 61) && id != 78 && id != 79)
		{
			updateSpecial();
			return;
		}
		string text = "Buy";
		if (id == 18 || id == 44)
		{
			text += " 1";
		}
		if (id == 19 || id == 45)
		{
			text += " 10";
		}
		if (id == 20 || id == 46)
		{
			text += " 100";
		}
		if (id == 78)
		{
			text += " 25";
		}
		text = text + " for " + cost().ToString("###,###") + " AP";
		itemInfo.text = "<b>" + itemName + "</b>";
		Text text2 = itemInfo;
		text2.text = text2.text + "\nYou currently have: " + count();
		Text text3 = itemInfo;
		text3.text = text3.text + "\n" + useStatus();
		character.allArbitrary.updateText();
		if (shouldDisableBuyButton(id))
		{
			if (id == 32)
			{
				buyAPButton.GetComponentInChildren<Text>().text = "Kitty!";
			}
			else
			{
				buyAPButton.GetComponentInChildren<Text>().text = "Bought!";
			}
			buyAPButton.interactable = false;
		}
		else
		{
			buyAPButton.GetComponentInChildren<Text>().text = text;
			buyAPButton.interactable = true;
		}
	}

	public void updatePill()
	{
		string text = "Buy";
		if (id == 35)
		{
			text += " 1K";
		}
		if (id == 36)
		{
			text += " 10K";
		}
		if (id == 37)
		{
			text += " 100K";
		}
		text = text + " for " + cost().ToString("###,###") + " AP";
		buyAPButton.GetComponentInChildren<Text>().text = text;
		itemInfo.text = "<b>" + itemName + "</b>";
		Text text2 = itemInfo;
		text2.text = text2.text + "\n" + useStatus();
		character.allArbitrary.updateText();
	}

	public void updateSpecial()
	{
		itemInfo.text = "<b>" + itemName + "</b>";
		Text text = itemInfo;
		text.text = text.text + "\n" + useStatus();
		character.allArbitrary.updateText();
		if (shouldDisableBuyButton(id))
		{
			if (id == 32)
			{
				buyAPButton.GetComponentInChildren<Text>().text = "Kitty!";
			}
			else
			{
				buyAPButton.GetComponentInChildren<Text>().text = "Bought!";
			}
			buyAPButton.interactable = false;
		}
		else
		{
			buyAPButton.GetComponentInChildren<Text>().text = "Buy for " + cost().ToString("###,###") + " AP";
			buyAPButton.interactable = true;
		}
	}

	public void buyAP()
	{
		switch (id)
		{
		case 0:
			startEnergyPotion1AP();
			break;
		case 1:
			startEnergyPotion2AP();
			break;
		case 2:
			startMagicPotion1AP();
			break;
		case 3:
			startMagicPotion2AP();
			break;
		case 4:
			startLootCharm1AP();
			break;
		case 5:
			startEnergyBarBar1AP();
			break;
		case 6:
			startMagicBarBar1AP();
			break;
		case 7:
			startLootFilterAP();
			break;
		case 8:
			startAutoMergeBoostAP();
			break;
		case 9:
			startInstaTrainingAP();
			break;
		case 10:
			start500ExpAP();
			break;
		case 11:
			startHeartAP();
			break;
		case 12:
			startCustomPercent1AP();
			break;
		case 13:
			startCustomPercent2AP();
			break;
		case 14:
			startYellowHeartAP();
			break;
		case 15:
			startInventoryAP();
			break;
		case 16:
			startStarterPackAP();
			break;
		case 17:
			startAcc4AP();
			break;
		case 18:
			startPoop1AP();
			break;
		case 19:
			startPoop10AP();
			break;
		case 20:
			startPoop100AP();
			break;
		case 21:
			startYggReminderAP();
			break;
		case 22:
			startExtendedSpinBankAP();
			break;
		case 23:
			start200ExpAP();
			break;
		case 24:
			start2KExpAP();
			break;
		case 25:
			startLoadoutSlotAP();
			break;
		case 26:
			startEnergyPotion3AP();
			break;
		case 27:
			startMagicPotion3AP();
			break;
		case 28:
			startBeardAP();
			break;
		case 29:
			startCubeFilterAP();
			break;
		case 30:
			startLootCharm2AP();
			break;
		case 31:
			startHeartBrown();
			break;
		case 32:
			startDaycareSpeedAP();
			break;
		case 33:
			startHeartGreenAP();
			break;
		case 34:
			startAcc5AP();
			break;
		case 35:
			startPill1AP();
			break;
		case 36:
			startPill10AP();
			break;
		case 37:
			startPill100AP();
			break;
		case 38:
			startHeartBlueAP();
			break;
		case 39:
			startLazyITOPODAP();
			break;
		case 40:
			startDiggerSlotAP();
			break;
		case 41:
			startMacguffinSlotAP();
			break;
		case 42:
			startHeartPurpleAP();
			break;
		case 43:
			startMacguffinBooster1AP();
			break;
		case 44:
			startBeastButter1AP();
			break;
		case 45:
			startBeastButter10AP();
			break;
		case 46:
			startBeastButter100AP();
			break;
		case 47:
			startQuestLightAP();
			break;
		case 48:
			startFasterQuests1AP();
			break;
		case 49:
			startExtendedQuestBankAP();
			break;
		case 50:
			startHeartOrangeAP();
			break;
		case 51:
			start25ppAP();
			break;
		case 52:
			start100ppAP();
			break;
		case 53:
			start500ppAP();
			break;
		case 54:
			startAcc6AP();
			break;
		case 55:
			startCustomIdlePercent1AP();
			break;
		case 56:
			startAutoNukeAP();
			break;
		case 57:
			startDaycareArtAP();
			break;
		case 58:
			startNGUCapModifierAP();
			break;
		case 59:
			startRes3Potion1AP();
			break;
		case 60:
			startRes3Potion2AP();
			break;
		case 61:
			startRes3Potion3AP();
			break;
		case 62:
			startAcc7AP();
			break;
		case 63:
			startHeartGreyAP();
			break;
		case 64:
			startRes3Percent1AP();
			break;
		case 65:
			startRes3Percent2AP();
			break;
		case 66:
			startRes3IdlePercent1AP();
			break;
		case 67:
			startRes3NameGeneratorAP();
			break;
		case 68:
			startFasterWishAP();
			break;
		case 69:
			startInvMergeSlotAP();
			break;
		case 70:
			startHeartPinkAP();
			break;
		case 71:
			startAdvLightAP();
			break;
		case 72:
			startAdvAdvancerAP();
			break;
		case 73:
			startGoToQuestAP();
			break;
		case 74:
			startAcc8AP();
			break;
		case 75:
			startDeckSlotAP();
			break;
		case 76:
			startMayoGenAP();
			break;
		case 77:
			startTagSlotAP();
			break;
		case 78:
			startCardTierConsumableAP();
			break;
		case 79:
			startMayoSpeedConsumableAP();
			break;
		case 80:
			startHeartRainbowAP();
			break;
		case 81:
			startAcc9AP();
			break;
		}
	}

	public long cost()
	{
		switch (id)
		{
		case 0:
			return energyPotion1Cost();
		case 1:
			return energyPotion2Cost();
		case 2:
			return magicPotion1Cost();
		case 3:
			return magicPotion2Cost();
		case 4:
			return lootCharm1Cost();
		case 5:
			return energyBarBar1Cost();
		case 6:
			return magicBarBar1Cost();
		case 7:
			return lootFilterCost();
		case 8:
			return autoBoostMergeCost();
		case 9:
			return instaTrainCost();
		case 10:
			return exp500Cost();
		case 11:
			return heartCost();
		case 12:
			return customPercentSet1Cost();
		case 13:
			return customPercentSet2Cost();
		case 14:
			return yellowHeartCost();
		case 15:
			return inventoryCost();
		case 16:
			return starterPackCost();
		case 17:
			return acc4Cost();
		case 18:
			return poop1Cost();
		case 19:
			return poop10Cost();
		case 20:
			return poop100Cost();
		case 21:
			return yggdrasilReminderCost();
		case 22:
			return extendedSpinBankCost();
		case 23:
			return exp200Cost();
		case 24:
			return exp2KCost();
		case 25:
			return loadoutSlotCost();
		case 26:
			return energyPotion3Cost();
		case 27:
			return magicPotion3Cost();
		case 28:
			return beardSlotCost();
		case 29:
			return infinityCubeFilterCost();
		case 30:
			return lootCharm2Cost();
		case 31:
			return heartBrownCost();
		case 32:
			return daycareSpeedCost();
		case 33:
			return heartGreenCost();
		case 34:
			return acc5Cost();
		case 35:
			return pill1Cost();
		case 36:
			return pill10Cost();
		case 37:
			return pill100Cost();
		case 38:
			return heartBlueCost();
		case 39:
			return lazyITOPODCost();
		case 40:
			return diggerSlotCost();
		case 41:
			return macguffinSlotCost();
		case 42:
			return heartPurpleCost();
		case 43:
			return macguffinBooster1Cost();
		case 44:
			return beastButter1Cost();
		case 45:
			return beastButter10Cost();
		case 46:
			return beastButter100Cost();
		case 47:
			return questLightCost();
		case 48:
			return fasterQuests1Cost();
		case 49:
			return extendedQuestBankCost();
		case 50:
			return heartOrangeCost();
		case 51:
			return PP25Cost();
		case 52:
			return PP100Cost();
		case 53:
			return PP500Cost();
		case 54:
			return acc6Cost();
		case 55:
			return customIdlePercentSet1Cost();
		case 56:
			return autoNukeCost();
		case 57:
			return daycareArtCost();
		case 58:
			return nguCapModifierCost();
		case 59:
			return res3Potion1Cost();
		case 60:
			return res3Potion2Cost();
		case 61:
			return res3Potion3Cost();
		case 62:
			return acc7Cost();
		case 63:
			return heartGreyCost();
		case 64:
			return res3PercentSet1Cost();
		case 65:
			return res3PercentSet2Cost();
		case 66:
			return res3IdlePercentSet1Cost();
		case 67:
			return res3NameGenratorCost();
		case 68:
			return fasterWishesCost();
		case 69:
			return invMergeSlotCost();
		case 70:
			return heartPinkCost();
		case 71:
			return advLightCost();
		case 72:
			return advAdvancerCost();
		case 73:
			return goToQuestCost();
		case 74:
			return acc8Cost();
		case 75:
			return deckSizeCost();
		case 76:
			return mayoGenCost();
		case 77:
			return tagSlotCost();
		case 78:
			return cardTierConsumableCost();
		case 79:
			return mayoSpeedConsumableCost();
		case 80:
			return heartRainbowCost();
		case 81:
			return acc9Cost();
		default:
			return 0L;
		}
	}

	public int count()
	{
		switch (id)
		{
		case 0:
			return character.arbitrary.energyPotion1Count;
		case 1:
			return character.arbitrary.energyPotion2Count;
		case 2:
			return character.arbitrary.magicPotion1Count;
		case 3:
			return character.arbitrary.magicPotion2Count;
		case 4:
			return character.arbitrary.lootCharm1Count;
		case 5:
			return character.arbitrary.energyBarBar1Count;
		case 6:
			return character.arbitrary.magicBarBar1Count;
		case 18:
			return character.arbitrary.poop1Count;
		case 19:
			return character.arbitrary.poop1Count;
		case 20:
			return character.arbitrary.poop1Count;
		case 26:
			return character.arbitrary.energyPotion3Count;
		case 27:
			return character.arbitrary.magicPotion3Count;
		case 30:
			return character.arbitrary.lootCharm2Count;
		case 43:
			return character.arbitrary.macGuffinBooster1Count;
		case 44:
			return character.arbitrary.beastButterCount;
		case 45:
			return character.arbitrary.beastButterCount;
		case 46:
			return character.arbitrary.beastButterCount;
		case 59:
			return character.arbitrary.res3Potion1Count;
		case 60:
			return character.arbitrary.res3Potion2Count;
		case 61:
			return character.arbitrary.res3Potion3Count;
		case 78:
			return character.arbitrary.cardTierUpperCount;
		case 79:
			return character.arbitrary.mayoSpeedPotCount;
		default:
			return 0;
		}
	}

	public bool shouldDisableBuyButton(int id)
	{
		switch (id)
		{
		case 7:
			return character.arbitrary.lootFilter;
		case 8:
			return character.arbitrary.improvedAutoBoostMerge;
		case 9:
			return character.arbitrary.instaTrain;
		case 12:
			if (character.purchases.hasCustomEnergyPercent1)
			{
				return character.purchases.hasCustomMagicPercent1;
			}
			return false;
		case 13:
			if (character.purchases.hasCustomEnergyPercent2)
			{
				return character.purchases.hasCustomMagicPercent2;
			}
			return false;
		case 15:
			return character.arbitrary.inventorySpaces >= maxSpaces();
		case 17:
			return character.arbitrary.hasAcc4;
		case 21:
			return character.arbitrary.hasYggdrasilReminder;
		case 22:
			return character.arbitrary.hasExtendedSpinBank;
		case 25:
			return character.arbitrary.curLoadoutSlots >= maxLoadoutSpaces();
		case 28:
			return character.arbitrary.beardSlots >= maxBeardSpaces();
		case 29:
			return character.arbitrary.hasCubeFilter;
		case 32:
			return character.arbitrary.hasDaycareSpeed;
		case 34:
			return character.arbitrary.hasAcc5;
		case 39:
			return character.arbitrary.boughtLazyITOPOD;
		case 40:
			return character.arbitrary.diggerSlots >= maxDiggerSpaces();
		case 41:
			return character.arbitrary.macguffinSlots >= maxMacguffinSpaces();
		case 47:
			return character.arbitrary.hasQuestLight;
		case 48:
			return character.arbitrary.hasFasterQuests;
		case 49:
			return character.arbitrary.hasExtendedQuestBank;
		case 54:
			return character.arbitrary.hasAcc6;
		case 55:
			if (character.purchases.hasCustomIdleEnergyPercent1)
			{
				return character.purchases.hasCustomIdleMagicPercent1;
			}
			return false;
		case 56:
			return character.arbitrary.boughtAutoNuke;
		case 57:
			return character.arbitrary.boughtDaycareArt;
		case 58:
			return character.arbitrary.hasNGUCapModifier;
		case 62:
			return character.arbitrary.hasAcc7;
		case 64:
			return character.purchases.hasCustomRes3Percent1;
		case 65:
			return character.purchases.hasCustomRes3Percent2;
		case 66:
			return character.purchases.hasCustomIdleRes3Percent1;
		case 67:
			return character.arbitrary.res3NameGeneratorBought;
		case 68:
			return character.arbitrary.wishSpeedBoster;
		case 69:
			return character.arbitrary.invMergeSlots >= maxInvMergeSpaces();
		case 71:
			return character.arbitrary.advLightBought;
		case 72:
			return character.arbitrary.advAdvancerBought;
		case 73:
			return character.arbitrary.goToQuestZoneBought;
		case 74:
			return character.arbitrary.hasAcc8;
		case 75:
			return character.arbitrary.deckSpaceBought >= maxDeckSpaces();
		case 76:
			return character.arbitrary.mayoGenSlots >= maxMayoGenSlots();
		case 77:
			return character.arbitrary.gotTagslot1;
		case 81:
			return character.arbitrary.hasAcc9;
		default:
			return false;
		}
	}

	public string useStatus()
	{
		switch (id)
		{
		case 0:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.energyPotion1Time.totalseconds);
		case 1:
			if (character.arbitrary.energyPotion2InUse)
			{
				return "Activated";
			}
			return "Not Activated";
		case 2:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.magicPotion1Time.totalseconds);
		case 3:
			if (character.arbitrary.magicPotion2InUse)
			{
				return "Activated";
			}
			return "Not Activated";
		case 4:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.lootcharm1Time.totalseconds);
		case 5:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.energyBarBar1Time.totalseconds);
		case 6:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.magicBarBar1Time.totalseconds);
		case 7:
			if (character.arbitrary.lootFilter)
			{
				return "BOUGHT!";
			}
			break;
		case 8:
			if (character.arbitrary.improvedAutoBoostMerge)
			{
				return "BOUGHT!";
			}
			break;
		case 9:
			if (character.arbitrary.instaTrain)
			{
				return "BOUGHT!";
			}
			break;
		case 12:
			if (character.purchases.hasCustomEnergyPercent1 && character.purchases.hasCustomMagicPercent1)
			{
				return "BOUGHT!";
			}
			break;
		case 13:
			if (character.purchases.hasCustomEnergyPercent2 && character.purchases.hasCustomMagicPercent2)
			{
				return "BOUGHT!";
			}
			break;
		case 15:
			return "Bought: " + character.arbitrary.inventorySpaces + " / " + maxSpaces();
		case 16:
			if (character.arbitrary.hasStarterPack)
			{
				return "BOUGHT!";
			}
			break;
		case 17:
			if (character.arbitrary.hasAcc4)
			{
				return "BOUGHT!";
			}
			break;
		case 21:
			if (character.arbitrary.hasYggdrasilReminder)
			{
				return "BOUGHT!";
			}
			break;
		case 22:
			if (character.arbitrary.hasExtendedSpinBank)
			{
				return "BOUGHT!";
			}
			break;
		case 25:
			return "Bought: " + character.arbitrary.curLoadoutSlots + " / " + maxLoadoutSpaces();
		case 26:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.energyPotion1Time.totalseconds);
		case 27:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.magicPotion1Time.totalseconds);
		case 28:
			return "Bought: " + character.arbitrary.beardSlots + " / " + maxBeardSpaces();
		case 29:
			if (character.arbitrary.hasCubeFilter)
			{
				return "BOUGHT!";
			}
			break;
		case 30:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.lootcharm1Time.totalseconds);
		case 32:
			if (character.arbitrary.hasDaycareSpeed)
			{
				return "BOUGHT!";
			}
			break;
		case 34:
			if (character.arbitrary.hasAcc5)
			{
				return "BOUGHT!";
			}
			break;
		case 35:
			return "Buff Kills Left: " + character.adventure.itopod.buffedKills.ToString("###,##0");
		case 36:
			return "Buff Kills Left: " + character.adventure.itopod.buffedKills.ToString("###,##0");
		case 37:
			return "Buff Kills Left: " + character.adventure.itopod.buffedKills.ToString("###,##0");
		case 39:
			if (character.arbitrary.boughtLazyITOPOD)
			{
				return "BOUGHT!";
			}
			break;
		case 40:
			return "Bought: " + character.arbitrary.diggerSlots + " / " + maxDiggerSpaces();
		case 41:
			return "Bought: " + character.arbitrary.macguffinSlots + " / " + maxMacguffinSpaces();
		case 43:
			if (character.arbitrary.macGuffinBooster1InUse)
			{
				return "Active";
			}
			if (character.arbitrary.macGuffinBooster1Time.totalseconds > 0.0)
			{
				return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.macGuffinBooster1Time.totalseconds);
			}
			return "Inactive";
		case 47:
			if (character.arbitrary.hasQuestLight)
			{
				return "BOUGHT!";
			}
			break;
		case 48:
			if (character.arbitrary.hasFasterQuests)
			{
				return "BOUGHT!";
			}
			break;
		case 49:
			if (character.arbitrary.hasExtendedQuestBank)
			{
				return "BOUGHT!";
			}
			break;
		case 54:
			if (character.arbitrary.hasAcc6)
			{
				return "BOUGHT!";
			}
			break;
		case 55:
			if (character.purchases.hasCustomIdleEnergyPercent1 && character.purchases.hasCustomIdleMagicPercent1)
			{
				return "BOUGHT!";
			}
			break;
		case 58:
			if (character.arbitrary.hasNGUCapModifier)
			{
				return "BOUGHT!";
			}
			break;
		case 59:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.res3Potion1Time.totalseconds);
		case 60:
			if (character.arbitrary.res3Potion2InUse)
			{
				return "Activated";
			}
			return "Not Activated";
		case 61:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.res3Potion1Time.totalseconds);
		case 62:
			if (character.arbitrary.hasAcc7)
			{
				return "BOUGHT!";
			}
			break;
		case 64:
			if (character.purchases.hasCustomRes3Percent1)
			{
				return "BOUGHT!";
			}
			break;
		case 65:
			if (character.purchases.hasCustomRes3Percent2)
			{
				return "BOUGHT!";
			}
			break;
		case 66:
			if (character.purchases.hasCustomIdleRes3Percent1)
			{
				return "BOUGHT!";
			}
			break;
		case 69:
			return "Bought: " + character.arbitrary.invMergeSlots + " / " + maxInvMergeSpaces();
		case 71:
			if (character.arbitrary.advLightBought)
			{
				return "BOUGHT!";
			}
			break;
		case 72:
			if (character.arbitrary.advAdvancerBought)
			{
				return "BOUGHT!";
			}
			break;
		case 73:
			if (character.arbitrary.goToQuestZoneBought)
			{
				return "BOUGHT!";
			}
			break;
		case 74:
			if (character.arbitrary.hasAcc8)
			{
				return "BOUGHT!";
			}
			break;
		case 75:
			return "Bought: " + character.arbitrary.deckSpaceBought + " / " + maxDeckSpaces();
		case 76:
			return "Bought: " + character.arbitrary.mayoGenSlots + " / " + maxMayoGenSlots();
		case 77:
			if (character.arbitrary.gotTagslot1)
			{
				return "BOUGHT!";
			}
			break;
		case 79:
			return "Time Left: " + NumberOutput.timeOutput(character.arbitrary.mayoSpeedPotTime.totalseconds);
		default:
			return "";
		}
		return "";
	}

	public void displayTooltip()
	{
		tooltip.showTooltip(tooltipMessage);
	}

	public void useItem()
	{
		switch (id)
		{
		case 0:
			startUseEnergyPotion1();
			break;
		case 1:
			startUseEnergyPotion2();
			break;
		case 2:
			startUseMagicPotion1();
			break;
		case 3:
			startUseMagicPotion2();
			break;
		case 4:
			startUseLootCharm1();
			break;
		case 5:
			startUseEnergyBarBar1();
			break;
		case 6:
			startUseMagicBarBar1();
			break;
		case 26:
			startUseEnergyPotion3();
			break;
		case 27:
			startUseMagicPotion3();
			break;
		case 30:
			startUseLootCharm2();
			break;
		case 43:
			startUseMacguffinBooster1();
			break;
		case 59:
			startUseRes3Potion1();
			break;
		case 60:
			startUseRes3Potion2();
			break;
		case 61:
			startUseRes3Potion3();
			break;
		case 79:
			startUseMayoSpeedPot();
			break;
		}
	}

	private void startUseEnergyPotion1()
	{
		if (character.arbitrary.energyPotion1Count <= 0)
		{
			tooltip.showTooltip("You don't have any Energy Potion α! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useEnergyPotion1;
		box.displayBox("Are you sure you want to use an Energy Potion α? This will add 60 minutes to Energy Potion α's activation time.", yesAction, noAction);
	}

	private void useEnergyPotion1()
	{
		character.arbitrary.energyPotion1Time.advanceTime(3600);
		character.arbitrary.energyPotion1Count--;
		updateMenu();
	}

	private void startUseEnergyPotion2()
	{
		if (character.arbitrary.energyPotion2InUse)
		{
			tooltip.showTooltip("Energy Potion β is already active! Ugh, I have to save you from yourself.", 3f);
			return;
		}
		if (character.arbitrary.energyPotion2Count <= 0)
		{
			tooltip.showTooltip("You don't have any Energy Potion β! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useEnergyPotion2;
		box.displayBox("Are you sure you want to use an Energy Potion β?", yesAction, noAction);
	}

	private void useEnergyPotion2()
	{
		character.arbitrary.energyPotion2InUse = true;
		character.arbitrary.energyPotion2Count--;
		updateMenu();
	}

	private void startUseEnergyPotion3()
	{
		if (character.arbitrary.energyPotion3Count <= 0)
		{
			tooltip.showTooltip("You don't have any Energy Potion δ! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useEnergyPotion3;
		box.displayBox("Are you sure you want to use an Energy Potion δ? This will add 24 hours of 2x Energy Power.", yesAction, noAction);
	}

	private void useEnergyPotion3()
	{
		character.arbitrary.energyPotion1Time.advanceTime(86400);
		character.arbitrary.energyPotion3Count--;
		updateMenu();
	}

	private void startUseMagicPotion1()
	{
		if (character.arbitrary.magicPotion1Count <= 0)
		{
			tooltip.showTooltip("You don't have any Magic Potion α! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useMagicPotion1;
		box.displayBox("Are you sure you want to use a Magic Potion α? This will add 60 minutes to Magic Potion α's activation time.", yesAction, noAction);
	}

	private void useMagicPotion1()
	{
		character.arbitrary.magicPotion1Time.advanceTime(3600);
		character.arbitrary.magicPotion1Count--;
		updateMenu();
	}

	private void startUseMagicPotion2()
	{
		if (character.arbitrary.magicPotion2InUse)
		{
			tooltip.showTooltip("Magic Potion β is already active! Ugh, I have to save you from yourself.", 3f);
			return;
		}
		if (character.arbitrary.magicPotion2Count <= 0)
		{
			tooltip.showTooltip("You don't have any Magic Potion β! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useMagicPotion2;
		box.displayBox("Are you sure you want to use a Magic Potion β?", yesAction, noAction);
	}

	private void useMagicPotion2()
	{
		character.arbitrary.magicPotion2InUse = true;
		character.arbitrary.magicPotion2Count--;
		updateMenu();
	}

	private void startUseMagicPotion3()
	{
		if (character.arbitrary.magicPotion3Count <= 0)
		{
			tooltip.showTooltip("You don't have any Magic Potion δ! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useMagicPotion3;
		box.displayBox("Are you sure you want to use a Magic Potion δ? This will add 24 hours of 2x Magic Power.", yesAction, noAction);
	}

	private void useMagicPotion3()
	{
		if (character.arbitrary.magicPotion3Count > 0)
		{
			character.arbitrary.magicPotion1Time.advanceTime(86400);
			character.arbitrary.magicPotion3Count--;
			updateMenu();
		}
	}

	private void startUseRes3Potion1()
	{
		if (character.arbitrary.res3Potion1Count <= 0)
		{
			tooltip.showTooltip("You don't have any " + character.res3.res3Name + " Potion α! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useRes3Potion1;
		box.displayBox("Are you sure you want to use a " + character.res3.res3Name + " Potion α? This will add 60 minutes to " + character.res3.res3Name + " Potion α's activation time.", yesAction, noAction);
	}

	private void useRes3Potion1()
	{
		character.arbitrary.res3Potion1Time.advanceTime(3600);
		character.arbitrary.res3Potion1Count--;
		updateMenu();
	}

	private void startUseRes3Potion2()
	{
		if (character.arbitrary.res3Potion2InUse)
		{
			tooltip.showTooltip(character.res3.res3Name + " Potion β is already active! Ugh, I have to save you from yourself.", 3f);
			return;
		}
		if (character.arbitrary.res3Potion2Count <= 0)
		{
			tooltip.showTooltip("You don't have any " + character.res3.res3Name + " Potion β! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useRes3Potion2;
		box.displayBox("Are you sure you want to use a " + character.res3.res3Name + " Potion β?", yesAction, noAction);
	}

	private void useRes3Potion2()
	{
		character.arbitrary.res3Potion2InUse = true;
		character.arbitrary.res3Potion2Count--;
		updateMenu();
	}

	private void startUseRes3Potion3()
	{
		if (character.arbitrary.res3Potion3Count <= 0)
		{
			tooltip.showTooltip("You don't have any " + character.res3.res3Name + " Potion δ! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useRes3Potion3;
		box.displayBox("Are you sure you want to use a " + character.res3.res3Name + " Potion δ? This will add 24 hours of 2x " + character.res3.res3Name + " Power.", yesAction, noAction);
	}

	private void useRes3Potion3()
	{
		if (character.arbitrary.res3Potion3Count > 0)
		{
			character.arbitrary.res3Potion1Time.advanceTime(86400);
			character.arbitrary.res3Potion3Count--;
			updateMenu();
		}
	}

	private void startUseLootCharm1()
	{
		if (character.arbitrary.lootCharm1Count <= 0)
		{
			tooltip.showTooltip("You don't have any Lucky Charms! I bet some kids stole them.", 3f);
			return;
		}
		yesAction = useLootCharm1;
		box.displayBox("Are you sure you want to use your Lucky Charm? This will add 30 minutes to Lucky Charm's activation time.", yesAction, noAction);
	}

	private void useLootCharm1()
	{
		character.arbitrary.lootcharm1Time.advanceTime(1800);
		character.arbitrary.lootCharm1Count--;
		updateMenu();
	}

	private void startUseEnergyBarBar1()
	{
		if (character.arbitrary.energyBarBar1Count <= 0)
		{
			tooltip.showTooltip("You don't have any Energy Bar Bars! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useEnergyBarBar1;
		box.displayBox("Are you sure you want to use an Energy Bar Bar? This will add 60 minutes to Energy Bar Bar's activation time.", yesAction, noAction);
	}

	private void useEnergyBarBar1()
	{
		character.arbitrary.energyBarBar1Time.advanceTime(3600);
		character.arbitrary.energyBarBar1Count--;
		updateMenu();
	}

	private void startUseMagicBarBar1()
	{
		if (character.arbitrary.magicBarBar1Count <= 0)
		{
			tooltip.showTooltip("You don't have any Magic Bar Bars! Take this moment to reflect on your failures in life.", 3f);
			return;
		}
		yesAction = useMagicBarBar1;
		box.displayBox("Are you sure you want to use a Magic Bar Bar? This will add 60 minutes to Magic Bar Bar's activation time.", yesAction, noAction);
	}

	private void useMagicBarBar1()
	{
		character.arbitrary.magicBarBar1Time.advanceTime(3600);
		character.arbitrary.magicBarBar1Count--;
		updateMenu();
	}

	private void startUseLootCharm2()
	{
		if (character.arbitrary.lootCharm2Count <= 0)
		{
			tooltip.showTooltip("You don't have any Super Lucky Charms! I bet some kids stole them.", 3f);
			return;
		}
		yesAction = useLootCharm2;
		box.displayBox("Are you sure you want to use your Super Lucky Charm? This will add 12 hours to Lucky Charm's activation time.", yesAction, noAction);
	}

	private void useLootCharm2()
	{
		character.arbitrary.lootcharm1Time.advanceTime(43200);
		character.arbitrary.lootCharm2Count--;
		updateMenu();
	}

	private void startUseMacguffinBooster1()
	{
		if (character.arbitrary.macGuffinBooster1Count <= 0)
		{
			tooltip.showTooltip("You don't have any MacGuffin Muffins! :c", 3f);
			return;
		}
		yesAction = useMacguffinBooster1;
		box.displayBox("Are you sure you want to use your MacGuffin Muffin? This will add 24 hours to the MacGuffin Muffin's activation time.", yesAction, noAction);
	}

	private void useMacguffinBooster1()
	{
		character.arbitrary.macGuffinBooster1Time.advanceTime(86400);
		character.arbitrary.macGuffinBooster1Count--;
		character.arbitrary.macGuffinBooster1InUse = true;
		updateMenu();
	}

	private void startUseMayoSpeedPot()
	{
		if (character.arbitrary.mayoSpeedPotCount <= 0)
		{
			tooltip.showTooltip("You don't have any Mayo Infusers! This is truly a sad day.", 3f);
			return;
		}
		yesAction = useMayoSpeedPot;
		box.displayBox("Are you sure you want to use a Mayo Infuser? This will add 24 hours of 2x Mayo Gen Speed.", yesAction, noAction);
	}

	private void useMayoSpeedPot()
	{
		if (character.arbitrary.mayoSpeedPotCount > 0)
		{
			character.arbitrary.mayoSpeedPotTime.advanceTime(86400);
			character.arbitrary.mayoSpeedPotCount--;
			updateMenu();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id == 11)
		{
			Equipment equipment = character.itemInfo.genLoot(119, dontmark: false);
			equipment.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment) + "\n\n" + tooltipMessage);
		}
		else if (id == 14)
		{
			Equipment equipment2 = character.itemInfo.genLoot(129, dontmark: false);
			equipment2.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment2) + "\n\n" + tooltipMessage);
		}
		else if (id == 31)
		{
			Equipment equipment3 = character.itemInfo.genLoot(162, dontmark: false);
			equipment3.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment3) + "\n\n" + tooltipMessage);
		}
		else if (id == 33)
		{
			Equipment equipment4 = character.itemInfo.genLoot(171, dontmark: false);
			equipment4.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment4) + "\n\n" + tooltipMessage);
		}
		else if (id == 38)
		{
			Equipment equipment5 = character.itemInfo.genLoot(196, dontmark: false);
			equipment5.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment5) + "\n\n" + tooltipMessage);
		}
		else if (id == 42)
		{
			Equipment equipment6 = character.itemInfo.genLoot(212, dontmark: false);
			equipment6.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment6) + "\n\n" + tooltipMessage);
		}
		else if (id == 50)
		{
			Equipment equipment7 = character.itemInfo.genLoot(293, dontmark: false);
			equipment7.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment7) + "\n\n" + tooltipMessage);
		}
		else if (id == 59)
		{
			if (!character.res3.res3On)
			{
				tooltip.showTooltip("You do not yet have the means to use this, but one day... you will!");
			}
			else
			{
				tooltip.showTooltip("This potion grants 3x " + character.res3.res3Name + " Power for 60 minutes, but lasts through rebirths! This is best used on multiple short rebirths. Stacks with Resource 3 Potion β.");
			}
		}
		else if (id == 60)
		{
			if (!character.res3.res3On)
			{
				tooltip.showTooltip("You do not yet have the means to use this, but one day... you will!");
			}
			else
			{
				tooltip.showTooltip("This potion grants 2x " + character.res3.res3Name + " Power for the rest of your rebirth, no matter how long it takes! Stacks with Resource 3 Potion α.");
			}
		}
		else if (id == 61)
		{
			if (!character.res3.res3On)
			{
				tooltip.showTooltip("You do not yet have the means to use this, but one day... you will!");
			}
			else
			{
				tooltip.showTooltip("This potion works just like Resource 3 Potion α, but lasts for 24 hours! Effect does NOT stack with Resource 3 potion α, but the duration does.");
			}
		}
		else if (id == 63)
		{
			if (!character.res3.res3On)
			{
				tooltip.showTooltip("You cannot yet purchase this. You need to unlock a feature first!");
				return;
			}
			Equipment equipment8 = character.itemInfo.genLoot(297, dontmark: false);
			equipment8.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment8) + "\n\n" + tooltipMessage);
		}
		else if (id == 70)
		{
			if (!character.wishes.wishesOn)
			{
				tooltip.showTooltip("You cannot yet purchase this. You need to unlock a feature first!");
				return;
			}
			Equipment equipment9 = character.itemInfo.genLoot(344, dontmark: false);
			equipment9.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment9) + "\n\n" + tooltipMessage);
		}
		else if (id == 78)
		{
			if (!character.cards.cardsOn)
			{
				tooltip.showTooltip("You cannot yet purchase this. You need to unlock a feature first!");
			}
			else
			{
				tooltip.showTooltip("You can use this pen to poorly counterfeit +2 Tiers on the next 25 spawned Cards. Why don't you simply write an even higher number? Because shut the hell up, that's why! :D");
			}
		}
		else if (id == 79)
		{
			if (!character.cards.cardsOn)
			{
				tooltip.showTooltip("You cannot yet purchase this. You need to unlock a feature first!");
			}
			else
			{
				tooltip.showTooltip("This uhhh... 'Mayo Infuser' will help you generate more Mayo to play your Cards. Somehow. It makes a huge mess, and for the 24 hours you'll have 2x Mayo generation Speed! It even helps Fruit Yields too!");
			}
		}
		else if (id == 80)
		{
			if (!character.cards.cardsOn)
			{
				tooltip.showTooltip("You cannot yet purchase this. You need to unlock a feature first!");
				return;
			}
			Equipment equipment10 = character.itemInfo.genLoot(390, dontmark: false);
			equipment10.level = 10;
			tooltip.showTooltip(character.inventoryController.itemTooltipText(equipment10) + "\n\n" + tooltipMessage);
		}
		else
		{
			displayTooltip();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void dosellout()
	{
		tooltip.showTooltip("Hey there, and thanks for clicking this button. I'm still working on being a sellout so for now Kred purchasing isn't in, but you can still buy these items with AP! :D", 5f);
	}
}
