using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
	public Character character;

	public ItemNameDesc itemInfo;

	public ItemController[] inventory = new ItemController[60];

	public HoverTooltip tooltip;

	public Button autoMergeToggle;

	public Image mergeImage;

	public Button autoBoostToggle;

	public Image boostImage;

	public Button[] pageButtons;

	public Button[] loadoutButtons;

	public Button loadoutTabButton;

	public LoadoutController headController;

	public LoadoutController chestController;

	public LoadoutController legsController;

	public LoadoutController bootsController;

	public LoadoutController weaponController;

	public LoadoutController weapon2Controller;

	public LoadoutController infinityCubeController;

	public List<LoadoutController> accesories = new List<LoadoutController>();

	public List<DaycareItemController> daycares = new List<DaycareItemController>();

	public List<LoadoutController> macguffins = new List<LoadoutController>();

	public GameObject macguffinAnchor;

	public GameObject macguffinPanel;

	public Text macguffinText;

	public List<string> macguffinBonuses;

	public Button macguffinButton;

	public MultiLoadoutController loadoutsController;

	public AllDaycareController daycaresController;

	public Trash trash;

	public EquipmentDisplay display;

	public Dictionary<specType, float> bonuses = new Dictionary<specType, float>();

	public Button powerToggle;

	public Button toughToggle;

	public Button specialToggle;

	public Button noneToggle;

	public Text autoTransformTitleText;

	private string bonusDisplay;

	public bool mergeAllMode;

	public bool boostAllMode;

	public bool midDrag;

	public bool daycareUp;

	public bool macguffinUp;

	public double portraitCheck;

	public double endChecker;

	private void Awake()
	{
	}

	private void Start()
	{
		midDrag = false;
		character.inventory.validateInventory();
	}

	private void Update()
	{
		if (character.inventory.mergeTime.totalseconds < (double)autoMergeTime())
		{
			character.inventory.mergeTime.advanceTime(Time.deltaTime);
		}
		else
		{
			character.inventory.mergeTime.totalseconds = autoMergeTime();
		}
		if (character.inventory.boostTime.totalseconds < (double)autoBoostTime())
		{
			character.inventory.boostTime.advanceTime(Time.deltaTime);
		}
		else
		{
			character.inventory.boostTime.totalseconds = autoBoostTime();
		}
		if (character.inventory.mergeTime.totalseconds >= (double)autoMergeTime() && character.purchases.hasAutoMerge && character.settings.autoMergeOn && !midDrag)
		{
			autoMerge();
			character.inventory.mergeTime.reset();
		}
		if (character.inventory.boostTime.totalseconds >= (double)autoBoostTime() && character.purchases.hasAutoBoost && character.settings.autoBoostOn && !midDrag)
		{
			autoBoost();
			character.inventory.boostTime.reset();
		}
		portraitCheck += Time.deltaTime;
		if (portraitCheck >= 3.0)
		{
			portraitCheck = 0.0;
			if (character.inventory.macguffinBonuses[8] > 2.5f && !character.portraits.portraitUnlocked[57])
			{
				character.portraits.portraitUnlocked[57] = true;
			}
			if (character.inventory.macguffinBonuses[9] > 2.5f && !character.portraits.portraitUnlocked[58])
			{
				character.portraits.portraitUnlocked[58] = true;
			}
		}
		endChecker += Time.deltaTime;
		if (endChecker >= 30.0)
		{
			endChecker = 0.0;
			if (character.highestSadisticBoss >= 225)
			{
				runEndItemChecker();
			}
		}
	}

	public void reset()
	{
	}

	public int curSpaces()
	{
		int num = character.inventory.spaces + character.allChallenges.noEquipmentChallenge.completions() * 8 + character.allChallenges.noEquipmentChallenge.evilCompletions() * 3 + character.arbitrary.inventorySpaces + (int)character.adventureController.itopod.totalInvSpaces() + character.beastQuestPerkController.totalInventorySpaces() + character.wishesController.totalInventorySpaces();
		if (character.allChallenges.noEquipmentChallenge.completions() >= character.allChallenges.noEquipmentChallenge.maxCompletions)
		{
			num += 10;
		}
		if (character.allChallenges.noEquipmentChallenge.evilCompletions() >= character.allChallenges.noEquipmentChallenge.maxCompletions)
		{
			num += 9;
		}
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public int accessorySpaces()
	{
		int num = 2;
		if (character.purchases.hasAcc3)
		{
			num++;
		}
		if (character.arbitrary.hasAcc4)
		{
			num++;
		}
		if (character.arbitrary.hasAcc5)
		{
			num++;
		}
		if (character.purchases.hasAcc5)
		{
			num++;
		}
		if (character.arbitrary.hasAcc6)
		{
			num++;
		}
		if (character.arbitrary.hasAcc7)
		{
			num++;
		}
		if (character.arbitrary.hasAcc8)
		{
			num++;
		}
		if (character.arbitrary.hasAcc9)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.completions() >= 2)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.evilCompletions() >= 1)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 7)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[29] >= 1)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[18] >= 1)
		{
			num++;
		}
		if (character.wishes.wishes[109].level > 0)
		{
			num++;
		}
		return num;
	}

	public int macguffinSpaces()
	{
		int num = 1 + character.arbitrary.macguffinSlots;
		if (character.inventory.itemList.edgyComplete)
		{
			num++;
		}
		if (character.purchases.hasMacguffinSlot1)
		{
			num++;
		}
		if (character.purchases.hasMacguffinSlot2)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[66] >= 1)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[67] >= 1)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[88] >= 1)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.evilCompletions() >= 2)
		{
			num++;
		}
		if (character.allChallenges.noEquipmentChallenge.evilCompletions() >= character.allChallenges.noEquipmentChallenge.maxCompletions)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[19] >= 1)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[50] >= 1)
		{
			num++;
		}
		return num;
	}

	public int daycareSpaces()
	{
		int num = 0;
		if (character.purchases.hasDaycare)
		{
			num++;
		}
		if (character.purchases.hasDaycareSlot2)
		{
			num++;
		}
		if (character.purchases.hasDaycareSlot3)
		{
			num++;
		}
		if (character.allChallenges.blindChallenge.completions() >= 10)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.evilCompletions() >= 3)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[86] >= 1)
		{
			num++;
		}
		return num;
	}

	public void updateInvCount()
	{
		character.inventory.updateInvSpaces(curSpaces());
	}

	public void updateAccCount()
	{
		character.inventory.updateAccSpaces(accessorySpaces());
		character.inventory.updateLoadoutAccs(accessorySpaces());
	}

	public void updateKittyArtCount()
	{
		while (character.inventory.unlockedKittyArt.Count < character.inventory.kittyArtSize())
		{
			character.inventory.unlockedKittyArt.Add(item: false);
		}
		character.inventory.unlockedKittyArt[0] = true;
		if (character.arbitrary.boughtDaycareArt)
		{
			character.inventory.unlockedKittyArt[4] = true;
			character.inventory.unlockedKittyArt[5] = true;
			character.inventory.unlockedKittyArt[6] = true;
			character.inventory.unlockedKittyArt[7] = true;
			character.inventory.unlockedKittyArt[9] = true;
		}
		if (character.adventure.itopod.perkLevel[94] >= 1597)
		{
			character.inventory.unlockedKittyArt[8] = true;
		}
	}

	public void updateMacguffinCount()
	{
		character.inventory.updateMacguffinSpaces(macguffinSpaces());
	}

	public void updateDaycareCount()
	{
		character.inventory.updateDaycareSpaces(daycareSpaces());
	}

	public int loadoutSpaces()
	{
		int num = character.arbitrary.curLoadoutSlots;
		if (character.purchases.hasloadout1)
		{
			num += 2;
		}
		if (character.purchases.hasloadout2)
		{
			num++;
		}
		if (num > 10)
		{
			num = 10;
		}
		return num;
	}

	public float autoMergeTime()
	{
		float num = 3600f;
		num *= 1f - (float)character.allChallenges.noEquipmentChallenge.completions() * 0.1f;
		if (character.arbitrary.improvedAutoBoostMerge)
		{
			num *= 0.5f;
		}
		return num;
	}

	public float autoBoostTime()
	{
		float num = 3600f;
		num *= 1f - (float)character.allChallenges.noEquipmentChallenge.completions() * 0.1f;
		if (character.arbitrary.improvedAutoBoostMerge)
		{
			num *= 0.5f;
		}
		return num;
	}

	public void updateItem(int i)
	{
		if (i >= 0 && i < character.inventoryController.curSpaces())
		{
			inventory[i % 60].updateItem();
		}
	}

	public void updateInventory()
	{
		for (int i = 0; i < inventory.Length; i++)
		{
			inventory[i].updateItem();
		}
		updateAllAccs();
		updateAllDaycares();
		updateAllMacguffins();
		updateBoots();
		updateChest();
		updateHead();
		updateLegs();
		updateWeapon();
		updateWeapon2();
		updateTrash();
		updateInfinityCube();
		updateLoadoutButtons();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
		updateToggleState();
		updateBoostToggleState();
		updateTransformToggles();
		loadoutsController.refresh();
		updatePageButtons();
		updateMacguffinText();
		updateMacguffinButton();
	}

	public void updatePageButtons()
	{
		int num = curPages();
		for (int i = 0; i < pageButtons.Length; i++)
		{
			if (i < num)
			{
				pageButtons[i].gameObject.SetActive(value: true);
			}
			else
			{
				pageButtons[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void updateLoadoutButtons()
	{
		int num = loadoutSpaces();
		for (int i = 0; i < loadoutButtons.Length; i++)
		{
			if (i < num)
			{
				loadoutButtons[i].gameObject.SetActive(value: true);
			}
			else
			{
				loadoutButtons[i].gameObject.SetActive(value: false);
			}
		}
		if (num > 0)
		{
			loadoutTabButton.gameObject.SetActive(value: true);
		}
		else
		{
			loadoutTabButton.gameObject.SetActive(value: false);
		}
	}

	public void updateMacguffinButton()
	{
		if (character.achievements.achievementComplete[145])
		{
			macguffinButton.gameObject.SetActive(value: true);
		}
		else
		{
			macguffinButton.gameObject.SetActive(value: false);
		}
	}

	public int curPages()
	{
		if (curSpaces() <= 60)
		{
			return 1;
		}
		if (curSpaces() <= 120)
		{
			return 2;
		}
		if (curSpaces() <= 180)
		{
			return 3;
		}
		if (curSpaces() <= 240)
		{
			return 4;
		}
		if (curSpaces() <= 300)
		{
			return 5;
		}
		if (curSpaces() <= 360)
		{
			return 6;
		}
		if (curSpaces() <= 420)
		{
			return 7;
		}
		if (curSpaces() <= 480)
		{
			return 8;
		}
		return 9;
	}

	public void refresh()
	{
		updateInventory();
		loadoutsController.refresh();
	}

	public float adventureAttackBonus()
	{
		return attackBonus();
	}

	public float adventureDefenseBonus()
	{
		return defenseBonus();
	}

	public float adventureHPBonus()
	{
		return attackBonus() * 3f;
	}

	public float adventureHPRegenBonus()
	{
		return defenseBonus() * 0.03f;
	}

	public float cubePower()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		float num = character.adventure.attack + character.inventoryController.adventureAttackBonus();
		if (character.inventory.cubePower > num)
		{
			return num + Mathf.Pow(character.inventory.cubePower - num, 0.5f);
		}
		return character.inventory.cubePower;
	}

	public float cubePowerSoftcap()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		return character.adventure.attack + character.inventoryController.adventureAttackBonus();
	}

	public float cubeToughness()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		float num = character.adventure.defense + character.inventoryController.adventureDefenseBonus();
		if (character.inventory.cubeToughness > num)
		{
			return num + Mathf.Pow(character.inventory.cubeToughness - num, 0.5f);
		}
		return character.inventory.cubeToughness;
	}

	public float cubeToughnessSoftcap()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		return character.adventure.defense + character.inventoryController.adventureDefenseBonus();
	}

	public float attackBonus()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		if (character.inventory.disabled)
		{
			return 0f;
		}
		float num = equipAttackBonus(character.inventory.weapon) + equipAttackBonus(character.inventory.head) + equipAttackBonus(character.inventory.chest) + equipAttackBonus(character.inventory.legs) + equipAttackBonus(character.inventory.boots) + equipAttackBonus(character.inventory.weapon2) * weapon2Factor();
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			num += equipAttackBonus(character.inventory.accs[i]);
		}
		return num;
	}

	public float defenseBonus()
	{
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return 0f;
		}
		if (character.inventory.disabled)
		{
			return 0f;
		}
		float num = equipDefenseBonus(character.inventory.weapon) + equipDefenseBonus(character.inventory.head) + equipDefenseBonus(character.inventory.chest) + equipDefenseBonus(character.inventory.legs) + equipDefenseBonus(character.inventory.boots) + equipDefenseBonus(character.inventory.weapon2) * weapon2Factor();
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			num += equipDefenseBonus(character.inventory.accs[i]);
		}
		return num;
	}

	public float equipAttackBonus(Equipment equip)
	{
		return Mathf.Floor(equip.curAttack * Mathf.Min((float)character.effectiveBossID() / (float)equip.bossRequired, 1f));
	}

	public float equipDefenseBonus(Equipment equip)
	{
		return Mathf.Floor(equip.curDefense * Mathf.Min((float)character.effectiveBossID() / (float)equip.bossRequired, 1f));
	}

	public float equipSpecBonus(specType type, Equipment equip)
	{
		float num = 0f;
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			return num;
		}
		if (character.inventory.disabled)
		{
			return 0f;
		}
		if (equip.spec1Type == specType.None)
		{
			return num;
		}
		if (equip.spec1Type == type)
		{
			float num2 = Mathf.Floor(equip.spec1Cur * Mathf.Min((float)character.effectiveBossID() / (float)equip.bossRequired, 1f));
			num += num2;
		}
		if (equip.spec2Type == type)
		{
			float num3 = Mathf.Floor(equip.spec2Cur * Mathf.Min((float)character.effectiveBossID() / (float)equip.bossRequired, 1f));
			num += num3;
		}
		if (equip.spec3Type == type)
		{
			float num4 = Mathf.Floor(equip.spec3Cur * Mathf.Min((float)character.effectiveBossID() / (float)equip.bossRequired, 1f));
			num += num4;
		}
		return num;
	}

	public float specBonus(specType type)
	{
		float num = equipSpecBonus(type, character.inventory.weapon) + equipSpecBonus(type, character.inventory.head) + equipSpecBonus(type, character.inventory.chest) + equipSpecBonus(type, character.inventory.legs) + equipSpecBonus(type, character.inventory.boots) + equipSpecBonus(type, character.inventory.weapon2) * weapon2Factor();
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			num += equipSpecBonus(type, character.inventory.accs[i]);
		}
		return num;
	}

	public float weapon2Factor()
	{
		if (!weapon2Unlocked())
		{
			return 0f;
		}
		float num = (float)character.wishes.wishes[28].level * character.wishesController.properties[28].effectPerLevel + (float)character.wishes.wishes[45].level * character.wishesController.properties[45].effectPerLevel;
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}

	public void updateAcc(int id)
	{
		if (id <= accesories.Count && id >= 0)
		{
			accesories[id].updateItem();
			updateBonuses();
			display.updateDisplay(bonusDisplay);
		}
	}

	public void updateMacguffin(int id)
	{
		if (id <= macguffins.Count && id >= 0)
		{
			macguffins[id].updateItem();
			updateBonuses();
			display.updateDisplay(bonusDisplay);
		}
	}

	public void updateDaycare(int id)
	{
		if (id <= daycares.Count && id >= 0)
		{
			daycares[id].updateItem();
			updateBonuses();
			display.updateDisplay(bonusDisplay);
		}
	}

	public void updateAllDaycares()
	{
		for (int i = 0; i < daycares.Count; i++)
		{
			daycares[i].updateItem();
		}
		updateBonuses();
		display.updateDisplay(bonusDisplay);
		daycaresController.updateKitty();
	}

	public void updateAllMacguffins()
	{
		for (int i = 0; i < macguffins.Count; i++)
		{
			macguffins[i].updateItem();
		}
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateAllAccs()
	{
		for (int i = 0; i < accesories.Count; i++)
		{
			accesories[i].updateItem();
		}
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateHead()
	{
		headController.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateChest()
	{
		chestController.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateLegs()
	{
		legsController.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateBoots()
	{
		bootsController.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateWeapon()
	{
		weaponController.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateWeapon2()
	{
		weapon2Controller.updateItem();
		updateBonuses();
		display.updateDisplay(bonusDisplay);
	}

	public void updateTrash()
	{
		trash.updateItem();
	}

	public void updateInfinityCube()
	{
		infinityCubeController.updateItem();
	}

	public int infinityCubeTier()
	{
		float num = character.inventory.cubePower + character.inventory.cubeToughness;
		if (num < 100f)
		{
			return 0;
		}
		int num2 = (int)(Mathf.Log10(num) - 1f);
		if (num2 > 10)
		{
			num2 = 10;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		return num2;
	}

	public float cubeLootBonus()
	{
		if (infinityCubeTier() <= 0)
		{
			return 0f;
		}
		if (infinityCubeTier() == 1)
		{
			return 0.5f;
		}
		return 0.5f + (float)(infinityCubeTier() - 1) * 0.2f;
	}

	public float cubeGoldBonus()
	{
		if (infinityCubeTier() <= 1)
		{
			return 0f;
		}
		if (infinityCubeTier() == 2)
		{
			return 0.5f;
		}
		return Mathf.Pow(infinityCubeTier() - 1, 1.3f) / 2f;
	}

	public float cubeHackBonus()
	{
		if (infinityCubeTier() <= 7)
		{
			return 0f;
		}
		if (infinityCubeTier() == 8)
		{
			return 0.1f;
		}
		if (infinityCubeTier() == 9)
		{
			return 0.15f;
		}
		if (infinityCubeTier() >= 10)
		{
			return 0.2f;
		}
		return 0f;
	}

	public float cubeWishBonus()
	{
		if (infinityCubeTier() <= 8)
		{
			return 0f;
		}
		if (infinityCubeTier() == 9)
		{
			return 0.1f;
		}
		if (infinityCubeTier() >= 10)
		{
			return 0.2f;
		}
		return 0f;
	}

	public void updateBonuses()
	{
		bonusDisplay = "";
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		bool flag13 = false;
		bool flag14 = false;
		foreach (specType value in Enum.GetValues(typeof(specType)))
		{
			float bonusFactor = getBonusFactor(specBonus(value), value);
			bonuses[value] = bonusFactor;
		}
		foreach (specType value2 in Enum.GetValues(typeof(specType)))
		{
			if (specBonus(value2) == 0f)
			{
				continue;
			}
			switch (value2)
			{
			case specType.BoostRecycle:
				bonusDisplay = string.Concat(bonusDisplay, "\n<b>", value2, ":</b> ", bonuses[value2] * 100f, "%");
				break;
			case specType.EnergyCap:
				if (!flag3)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyCap] + bonuses[specType.AllCap] + bonuses[specType.EnergyCap3]) * 100f).ToString("###,##0.##") + "%";
					flag3 = true;
				}
				break;
			case specType.EnergyCap3:
				if (!flag3)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyCap] + bonuses[specType.AllCap] + bonuses[specType.EnergyCap3]) * 100f).ToString("###,##0.##") + "%";
					flag3 = true;
				}
				break;
			case specType.MagicCap:
				if (!flag4)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicCap] + bonuses[specType.AllCap] + bonuses[specType.MagicCap3]) * 100f).ToString("###,##0.##") + "%";
					flag4 = true;
				}
				break;
			case specType.MagicCap3:
				if (!flag4)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicCap] + bonuses[specType.AllCap] + bonuses[specType.MagicCap3]) * 100f).ToString("###,##0.##") + "%";
					flag4 = true;
				}
				break;
			case specType.AllCap:
				if (!flag3)
				{
					bonusDisplay = bonusDisplay + "\n<b>Energy Cap:</b> " + ((bonuses[specType.EnergyCap] + bonuses[specType.AllCap] + bonuses[specType.EnergyCap3]) * 100f).ToString("###,##0.##") + "%";
					flag3 = true;
				}
				if (!flag4)
				{
					bonusDisplay = bonusDisplay + "\n<b>Magic Cap:</b> " + ((bonuses[specType.MagicCap] + bonuses[specType.AllCap] + bonuses[specType.MagicCap3]) * 100f).ToString("###,##0.##") + "%";
					flag4 = true;
				}
				break;
			case specType.EnergyPower:
				if (!flag)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPower] + bonuses[specType.EnergyPower2] + bonuses[specType.EnergyPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag = true;
				}
				break;
			case specType.MagicPower:
				if (!flag2)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPower] + bonuses[specType.MagicPower2] + bonuses[specType.MagicPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag2 = true;
				}
				break;
			case specType.EnergyPower2:
				if (!flag)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPower] + bonuses[specType.EnergyPower2] + bonuses[specType.EnergyPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag = true;
				}
				break;
			case specType.MagicPower2:
				if (!flag2)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPower] + bonuses[specType.MagicPower2] + bonuses[specType.MagicPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag2 = true;
				}
				break;
			case specType.AllPower:
				if (!flag2)
				{
					bonusDisplay = bonusDisplay + "\n<b>Magic Power:</b> " + ((bonuses[specType.MagicPower] + bonuses[specType.MagicPower2] + bonuses[specType.MagicPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag2 = true;
				}
				if (!flag)
				{
					bonusDisplay = bonusDisplay + "\n<b>Energy Power:</b> " + ((bonuses[specType.EnergyPower] + bonuses[specType.EnergyPower2] + bonuses[specType.EnergyPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag = true;
				}
				break;
			case specType.EnergyPower3:
				if (!flag)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPower] + bonuses[specType.EnergyPower2] + bonuses[specType.EnergyPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag = true;
				}
				break;
			case specType.MagicPower3:
				if (!flag2)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPower] + bonuses[specType.MagicPower2] + bonuses[specType.MagicPower3] + bonuses[specType.AllPower]) * 100f).ToString("###,##0.##") + "%";
					flag2 = true;
				}
				break;
			case specType.EnergyPerBar:
				if (!flag5)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPerBar] + bonuses[specType.EnergyPerBar2] + bonuses[specType.EnergyPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag5 = true;
				}
				break;
			case specType.EnergyPerBar2:
				if (!flag5)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPerBar] + bonuses[specType.EnergyPerBar2] + bonuses[specType.EnergyPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag5 = true;
				}
				break;
			case specType.MagicPerBar:
				if (!flag6)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPerBar] + bonuses[specType.MagicPerBar2] + bonuses[specType.MagicPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag6 = true;
				}
				break;
			case specType.MagicPerBar2:
				if (!flag6)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPerBar] + bonuses[specType.MagicPerBar2] + bonuses[specType.MagicPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag6 = true;
				}
				break;
			case specType.AllPerBar:
				if (!flag6)
				{
					bonusDisplay = bonusDisplay + "\n<b>Magic Bars:</b> " + ((bonuses[specType.MagicPerBar] + bonuses[specType.MagicPerBar2] + bonuses[specType.MagicPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag6 = true;
				}
				if (!flag5)
				{
					bonusDisplay = bonusDisplay + "\n<b>Energy Bars:</b> " + ((bonuses[specType.EnergyPerBar] + bonuses[specType.EnergyPerBar2] + bonuses[specType.EnergyPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag5 = true;
				}
				break;
			case specType.MagicPerBar3:
				if (!flag6)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.MagicPerBar] + bonuses[specType.MagicPerBar2] + bonuses[specType.MagicPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag6 = true;
				}
				break;
			case specType.EnergyPerBar3:
				if (!flag5)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.EnergyPerBar] + bonuses[specType.EnergyPerBar2] + bonuses[specType.EnergyPerBar3] + bonuses[specType.AllPerBar]) * 100f).ToString("###,##0.##") + "%";
					flag5 = true;
				}
				break;
			case specType.Res3Power:
				bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + (bonuses[specType.Res3Power] * 100f).ToString("###,##0.##") + "%";
				break;
			case specType.Res3Cap:
				bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + (bonuses[specType.Res3Cap] * 100f).ToString("###,##0.##") + "%";
				break;
			case specType.Res3Bar:
				bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + (bonuses[specType.Res3Bar] * 100f).ToString("###,##0.##") + "%";
				break;
			case specType.EnergySpeed:
				bonusDisplay = bonusDisplay + "\n<b>Energy Speed:</b> " + (bonuses[value2] * 100f).ToString("#0.##") + "%";
				break;
			case specType.GoldDropAmount:
				if (!flag11)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.GoldDropAmount] + bonuses[specType.GoldDrop2] + cubeGoldBonus()) * 100f).ToString("###,##0.##") + "%";
					flag11 = true;
				}
				break;
			case specType.GoldDrop2:
				if (!flag11)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.GoldDropAmount] + bonuses[specType.GoldDrop2] + cubeGoldBonus()) * 100f).ToString("###,##0.##") + "%";
					flag11 = true;
				}
				break;
			case specType.AdvTraining:
				if (!flag9)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.AdvTraining] + bonuses[specType.AdvTraining2]) * 100f).ToString("#0.##") + "%";
					flag9 = true;
				}
				break;
			case specType.AdvTraining2:
				if (!flag9)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.AdvTraining] + bonuses[specType.AdvTraining2]) * 100f).ToString("#0.##") + "%";
					flag9 = true;
				}
				break;
			case specType.NGU:
				if (!flag8)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.NGU] + bonuses[specType.NGU2]) * 100f).ToString("###,##0.##") + "%";
					flag8 = true;
				}
				break;
			case specType.NGU2:
				if (!flag8)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.NGU] + bonuses[specType.NGU2]) * 100f).ToString("###,##0.##") + "%";
					flag8 = true;
				}
				break;
			case specType.Wandoos98:
				if (!flag7)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Wandoos98] + bonuses[specType.Wandoos2]) * 100f).ToString("#0.##") + "%";
					flag7 = true;
				}
				break;
			case specType.Wandoos2:
				if (!flag7)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Wandoos98] + bonuses[specType.Wandoos2]) * 100f).ToString("#0.##") + "%";
					flag7 = true;
				}
				break;
			case specType.Beards:
				if (!flag10)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Beards] + bonuses[specType.Beards2]) * 100f).ToString("#0.##") + "%";
					flag10 = true;
				}
				break;
			case specType.Beards2:
				if (!flag10)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Beards] + bonuses[specType.Beards2]) * 100f).ToString("#0.##") + "%";
					flag10 = true;
				}
				break;
			case specType.Looting:
				if (!flag12)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Looting] + bonuses[specType.Looting2] + cubeLootBonus()) * 100f).ToString("#0.##") + "%";
					flag12 = true;
				}
				break;
			case specType.Looting2:
				if (!flag12)
				{
					bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + ((bonuses[specType.Looting] + bonuses[specType.Looting2] + cubeLootBonus()) * 100f).ToString("#0.##") + "%";
					flag12 = true;
				}
				break;
			case specType.MagicSpeed:
				bonusDisplay = bonusDisplay + "\n<b>Magic Speed:</b> " + (bonuses[value2] * 100f).ToString("#0.##") + "%";
				break;
			case specType.DaycareSpeed:
				bonusDisplay = bonusDisplay + "\n<b>Daycare Speed:</b> " + (bonuses[value2] * 100f).ToString("#0.##") + "%";
				break;
			case specType.HackSpeed:
				if (!flag13)
				{
					flag13 = true;
					bonusDisplay = bonusDisplay + "\n<b>Hack Speed:</b> " + ((bonuses[value2] + cubeHackBonus()) * 100f).ToString("#0.##") + "%";
				}
				break;
			case specType.WishSpeed:
				if (!flag14)
				{
					flag14 = true;
					bonusDisplay = bonusDisplay + "\n<b>Wish Speed:</b> " + ((bonuses[value2] + cubeWishBonus()) * 100f).ToString("#0.##") + "%";
				}
				break;
			default:
				bonusDisplay = bonusDisplay + "\n<b>" + effectName(value2) + ":</b> " + (bonuses[value2] * 100f).ToString("###,##0.##") + "%";
				break;
			}
		}
		if (!flag12 && infinityCubeTier() >= 1)
		{
			bonusDisplay = bonusDisplay + "\n<b>" + effectName(specType.Looting) + ":</b> " + ((bonuses[specType.Looting] + bonuses[specType.Looting2] + cubeLootBonus()) * 100f).ToString("#0.##") + "%";
			flag12 = true;
		}
		if (!flag11 && infinityCubeTier() >= 1)
		{
			bonusDisplay = bonusDisplay + "\n<b>" + effectName(specType.GoldDrop2) + ":</b> " + ((bonuses[specType.GoldDropAmount] + bonuses[specType.GoldDrop2] + cubeGoldBonus()) * 100f).ToString("#0.##") + "%";
			flag11 = true;
		}
		if (!flag13 && infinityCubeTier() >= 8)
		{
			bonusDisplay = bonusDisplay + "\n<b>" + effectName(specType.HackSpeed) + ":</b> " + ((bonuses[specType.HackSpeed] + cubeHackBonus()) * 100f).ToString("#0.##") + "%";
			flag11 = true;
		}
		if (!flag14 && infinityCubeTier() >= 9)
		{
			bonusDisplay = bonusDisplay + "\n<b>" + effectName(specType.WishSpeed) + ":</b> " + ((bonuses[specType.WishSpeed] + cubeWishBonus()) * 100f).ToString("#0.##") + "%";
			flag11 = true;
		}
	}

	public void startBonuses()
	{
		foreach (specType value in Enum.GetValues(typeof(specType)))
		{
			float num = specBonus(value);
			switch (value)
			{
			case specType.BoostRecycle:
				num /= 1000f;
				break;
			case specType.Looting:
				num /= 1000f;
				break;
			default:
				num /= 100f;
				break;
			}
			bonuses[value] = num;
		}
	}

	public void updateItemStats()
	{
		for (int i = 0; i < character.inventory.inventory.Count; i++)
		{
			validateInventoryStats(i);
		}
		for (int j = 0; j < character.inventory.accs.Count; j++)
		{
			validateAccessoryStats(j);
		}
		for (int k = 0; k < character.inventory.daycare.Count; k++)
		{
			validateDaycareStats(k);
		}
		bootsController.updateBootsStats();
		chestController.updateChestStats();
		headController.updateHeadStats();
		legsController.updateLegsStats();
		weaponController.updateWeaponStats();
		trash.updateTrashStats();
	}

	public void validateInventoryStats(int id)
	{
		int id2 = character.inventory.inventory[id].id;
		if (id2 != 0)
		{
			int rboss = itemInfo.bossRequired[id2];
			part ptype = itemInfo.type[id2];
			float capatk = itemInfo.capAttack[id2];
			float curatk = itemInfo.curAttack[id2];
			float capdef = itemInfo.capDefense[id2];
			float curdef = itemInfo.curDefense[id2];
			specType type = itemInfo.specType1[id2];
			float capspec = itemInfo.capSpec1[id2];
			float curspec = itemInfo.curSpec1[id2];
			specType type2 = itemInfo.specType2[id2];
			float capspec2 = itemInfo.capSpec2[id2];
			float curspec2 = itemInfo.curSpec2[id2];
			specType type3 = itemInfo.specType3[id2];
			float capspec3 = itemInfo.capSpec3[id2];
			float curspec3 = itemInfo.curSpec3[id2];
			string npath = "";
			bool punique = itemInfo.unique[id2];
			character.inventory.inventory[id].updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void validateAccessoryStats(int id)
	{
		int id2 = character.inventory.accs[id].id;
		if (id2 != 0)
		{
			int rboss = itemInfo.bossRequired[id2];
			part ptype = itemInfo.type[id2];
			float capatk = itemInfo.capAttack[id2];
			float curatk = itemInfo.curAttack[id2];
			float capdef = itemInfo.capDefense[id2];
			float curdef = itemInfo.curDefense[id2];
			specType type = itemInfo.specType1[id2];
			float capspec = itemInfo.capSpec1[id2];
			float curspec = itemInfo.curSpec1[id2];
			specType type2 = itemInfo.specType2[id2];
			float capspec2 = itemInfo.capSpec2[id2];
			float curspec2 = itemInfo.curSpec2[id2];
			specType type3 = itemInfo.specType3[id2];
			float capspec3 = itemInfo.capSpec3[id2];
			float curspec3 = itemInfo.curSpec3[id2];
			string npath = "";
			bool punique = itemInfo.unique[id2];
			character.inventory.accs[id].updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void validateDaycareStats(int id)
	{
		int id2 = character.inventory.daycare[id].id;
		if (id2 != 0)
		{
			int rboss = itemInfo.bossRequired[id2];
			part ptype = itemInfo.type[id2];
			float capatk = itemInfo.capAttack[id2];
			float curatk = itemInfo.curAttack[id2];
			float capdef = itemInfo.capDefense[id2];
			float curdef = itemInfo.curDefense[id2];
			specType type = itemInfo.specType1[id2];
			float capspec = itemInfo.capSpec1[id2];
			float curspec = itemInfo.curSpec1[id2];
			specType type2 = itemInfo.specType2[id2];
			float capspec2 = itemInfo.capSpec2[id2];
			float curspec2 = itemInfo.curSpec2[id2];
			specType type3 = itemInfo.specType3[id2];
			float capspec3 = itemInfo.capSpec3[id2];
			float curspec3 = itemInfo.curSpec3[id2];
			string npath = "";
			bool punique = itemInfo.unique[id2];
			character.inventory.daycare[id].updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void swapHead()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (item < 0 && item2 < 0)
		{
			return;
		}
		int num = accessoryID(item);
		int num2 = accessoryID(item2);
		if (num >= 0 || num2 >= 0)
		{
			return;
		}
		if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Head)
		{
			if (mergeable(character.inventory.head, character.inventory.inventory[item2]))
			{
				int num3 = checkItemTransform(character.inventory.head);
				if (num3 > 0)
				{
					character.inventory.deleteHead();
					character.inventory.head = itemInfo.genLoot(num3);
				}
				else
				{
					character.inventory.head.mergeItem(character.inventory.inventory[item2]);
					character.inventory.deleteItem(item2);
				}
				checkItemTransform(character.inventory.head);
				return;
			}
			long num4 = character.totalCapEnergy();
			long num5 = character.totalCapMagic();
			long num6 = character.totalCapRes3();
			character.inventory.swapHead();
			updateHead();
			long num7 = character.totalCapEnergy();
			long num8 = character.totalCapMagic();
			long num9 = character.totalCapRes3();
			long num10 = num4 - num7;
			long num11 = num5 - num8;
			long num12 = num6 - num9;
			if (character.curEnergy - character.idleEnergy > num7)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num10 - character.idleEnergy) + " Idle Energy before swapping out this helmet, bub!", 2f);
				character.inventory.swapHead();
				updateBonuses();
				return;
			}
			if (character.magic.curMagic - character.magic.idleMagic > num8)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num11 - character.magic.idleMagic) + " Idle Magic before swapping out this helmet, bub!", 2f);
				character.inventory.swapHead();
				updateBonuses();
				return;
			}
			if (character.res3.curRes3 - character.res3.idleRes3 > num9)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num12 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out this helmet, bub!", 2f);
				character.inventory.swapHead();
				updateBonuses();
				return;
			}
		}
		if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.head.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
		{
			degradeBoost();
		}
	}

	public void swapChest()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (item < 0 && item2 < 0)
		{
			return;
		}
		int num = accessoryID(item);
		int num2 = accessoryID(item2);
		if (num >= 0 || num2 >= 0)
		{
			return;
		}
		int num3 = daycareID(item);
		int num4 = daycareID(item2);
		if (num3 >= 0 || num4 >= 0)
		{
			return;
		}
		if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Chest)
		{
			if (mergeable(character.inventory.chest, character.inventory.inventory[item2]))
			{
				int num5 = checkItemTransform(character.inventory.chest);
				if (num5 > 0)
				{
					character.inventory.deleteChest();
					character.inventory.chest = itemInfo.genLoot(num5);
				}
				else
				{
					character.inventory.chest.mergeItem(character.inventory.inventory[item2]);
					character.inventory.deleteItem(item2);
				}
				checkItemTransform(character.inventory.chest);
				return;
			}
			long num6 = character.totalCapEnergy();
			long num7 = character.totalCapMagic();
			long num8 = character.totalCapRes3();
			character.inventory.swapChest();
			updateBonuses();
			long num9 = character.totalCapEnergy();
			long num10 = character.totalCapMagic();
			long num11 = character.totalCapRes3();
			long num12 = num6 - num9;
			long num13 = num7 - num10;
			long num14 = num8 - num11;
			if (character.curEnergy - character.idleEnergy > num9)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num12 - character.idleEnergy) + " Idle Energy before swapping out this chest, bub!", 2f);
				character.inventory.swapChest();
				updateBonuses();
				return;
			}
			if (character.magic.curMagic - character.magic.idleMagic > num10)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num13 - character.magic.idleMagic) + " Idle Magic before swapping out this chest, bub!", 2f);
				character.inventory.swapChest();
				updateBonuses();
				return;
			}
			if (character.res3.curRes3 - character.res3.idleRes3 > num11)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num14 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out this chest, bub!", 2f);
				character.inventory.swapChest();
				updateBonuses();
				return;
			}
		}
		if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.chest.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
		{
			degradeBoost();
		}
	}

	public void swapLegs()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (item < 0 && item2 < 0)
		{
			return;
		}
		int num = accessoryID(item);
		int num2 = accessoryID(item2);
		if (num >= 0 || num2 >= 0)
		{
			return;
		}
		int num3 = daycareID(item);
		int num4 = daycareID(item2);
		if (num3 >= 0 || num4 >= 0)
		{
			return;
		}
		if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Legs)
		{
			if (mergeable(character.inventory.legs, character.inventory.inventory[item2]))
			{
				int num5 = checkItemTransform(character.inventory.legs);
				if (num5 > 0)
				{
					character.inventory.deleteLegs();
					character.inventory.legs = itemInfo.genLoot(num5);
				}
				else
				{
					character.inventory.legs.mergeItem(character.inventory.inventory[item2]);
					character.inventory.deleteItem(item2);
				}
				checkItemTransform(character.inventory.legs);
				return;
			}
			long num6 = character.totalCapEnergy();
			long num7 = character.totalCapMagic();
			long num8 = character.totalCapRes3();
			character.inventory.swapLegs();
			updateBonuses();
			long num9 = character.totalCapEnergy();
			long num10 = character.totalCapMagic();
			long num11 = character.totalCapRes3();
			long num12 = num6 - num9;
			long num13 = num7 - num10;
			long num14 = num8 - num11;
			if (character.curEnergy - character.idleEnergy > num9)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num12 - character.idleEnergy) + " Idle Energy before swapping out these legs, bub!", 2f);
				character.inventory.swapLegs();
				updateBonuses();
				return;
			}
			if (character.magic.curMagic - character.magic.idleMagic > num10)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num13 - character.magic.idleMagic) + " Idle Magic before swapping out these legs, bub!", 2f);
				character.inventory.swapLegs();
				updateBonuses();
				return;
			}
			if (character.res3.curRes3 - character.res3.idleRes3 > num11)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num14 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out these legs, bub!", 2f);
				character.inventory.swapLegs();
				updateBonuses();
				return;
			}
		}
		if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.legs.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
		{
			degradeBoost();
		}
	}

	public void swapBoots()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (item < 0 && item2 < 0)
		{
			return;
		}
		int num = accessoryID(item);
		int num2 = accessoryID(item2);
		if (num >= 0 || num2 >= 0)
		{
			return;
		}
		int num3 = daycareID(item);
		int num4 = daycareID(item2);
		if (num3 >= 0 || num4 >= 0)
		{
			return;
		}
		if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Boots)
		{
			if (mergeable(character.inventory.boots, character.inventory.inventory[item2]))
			{
				int num5 = checkItemTransform(character.inventory.boots);
				if (num5 > 0)
				{
					character.inventory.deleteBoots();
					character.inventory.boots = itemInfo.genLoot(num5);
				}
				else
				{
					character.inventory.boots.mergeItem(character.inventory.inventory[item2]);
					character.inventory.deleteItem(item2);
				}
				checkItemTransform(character.inventory.boots);
				return;
			}
			long num6 = character.totalCapEnergy();
			long num7 = character.totalCapMagic();
			long num8 = character.totalCapRes3();
			character.inventory.swapBoots();
			updateBonuses();
			long num9 = character.totalCapEnergy();
			long num10 = character.totalCapMagic();
			long num11 = character.totalCapRes3();
			long num12 = num6 - num9;
			long num13 = num7 - num10;
			long num14 = num8 - num11;
			if (character.curEnergy - character.idleEnergy > num9)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num12 - character.idleEnergy) + " Idle Energy before swapping out these boots, bub!", 2f);
				character.inventory.swapBoots();
				updateBonuses();
				return;
			}
			if (character.magic.curMagic - character.magic.idleMagic > num10)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num13 - character.magic.idleMagic) + " Idle Magic before swapping out these boots, bub!", 2f);
				character.inventory.swapBoots();
				updateBonuses();
				return;
			}
			if (character.res3.curRes3 - character.res3.idleRes3 > num11)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num14 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out these boots, bub!", 2f);
				character.inventory.swapBoots();
				updateBonuses();
				return;
			}
		}
		if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.boots.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
		{
			degradeBoost();
		}
	}

	public void swapWeapon()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if ((item == -5 && item2 == -6) || (item == -6 && item2 == -5))
		{
			long num = character.totalCapEnergy();
			long num2 = character.totalCapMagic();
			long num3 = character.totalCapRes3();
			character.inventory.swapWeapons();
			updateBonuses();
			long num4 = character.totalCapEnergy();
			long num5 = character.totalCapMagic();
			long num6 = character.totalCapRes3();
			long num7 = num - num4;
			long num8 = num2 - num5;
			long num9 = num3 - num6;
			if (character.curEnergy - character.idleEnergy > num4)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num7 - character.idleEnergy) + " Idle Energy before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
			else if (character.magic.curMagic - character.magic.idleMagic > num5)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num8 - character.magic.idleMagic) + " Idle Magic before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
			else if (character.res3.curRes3 - character.res3.idleRes3 > num6)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num9 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
		}
		else
		{
			if (item < 0 && item2 < 0)
			{
				return;
			}
			int num10 = accessoryID(item);
			int num11 = accessoryID(item2);
			if (num10 >= 0 || num11 >= 0)
			{
				return;
			}
			int num12 = daycareID(item);
			int num13 = daycareID(item2);
			if (num12 >= 0 || num13 >= 0)
			{
				return;
			}
			if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Weapon)
			{
				if (mergeable(character.inventory.weapon, character.inventory.inventory[item2]))
				{
					int num14 = checkItemTransform(character.inventory.weapon);
					if (num14 > 0)
					{
						character.inventory.deleteWeapon();
						character.inventory.weapon = itemInfo.genLoot(num14);
					}
					else
					{
						character.inventory.weapon.mergeItem(character.inventory.inventory[item2]);
						character.inventory.deleteItem(item2);
					}
					checkItemTransform(character.inventory.weapon);
					return;
				}
				if (alreadyEquipped(character.inventory.inventory[item2].id))
				{
					return;
				}
				long num15 = character.totalCapEnergy();
				long num16 = character.totalCapMagic();
				long num17 = character.totalCapRes3();
				character.inventory.swapWeapon();
				updateBonuses();
				long num18 = character.totalCapEnergy();
				long num19 = character.totalCapMagic();
				long num20 = character.totalCapRes3();
				long num21 = num15 - num18;
				long num22 = num16 - num19;
				long num23 = num17 - num20;
				if (character.curEnergy - character.idleEnergy > num18)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num21 - character.idleEnergy) + " Idle Energy before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon();
					updateBonuses();
					return;
				}
				if (character.magic.curMagic - character.magic.idleMagic > num19)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num22 - character.magic.idleMagic) + " Idle Magic before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon();
					updateBonuses();
					return;
				}
				if (character.res3.curRes3 - character.res3.idleRes3 > num20)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num23 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon();
					updateBonuses();
					return;
				}
			}
			if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.weapon.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
			{
				degradeBoost();
			}
		}
	}

	public void swapWeapon2()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if ((item == -5 && item2 == -6) || (item == -6 && item2 == -5))
		{
			long num = character.totalCapEnergy();
			long num2 = character.totalCapMagic();
			long num3 = character.totalCapRes3();
			character.inventory.swapWeapons();
			updateBonuses();
			long num4 = character.totalCapEnergy();
			long num5 = character.totalCapMagic();
			long num6 = character.totalCapRes3();
			long num7 = num - num4;
			long num8 = num2 - num5;
			long num9 = num3 - num6;
			if (character.curEnergy - character.idleEnergy > num4)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num7 - character.idleEnergy) + " Idle Energy before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
			else if (character.magic.curMagic - character.magic.idleMagic > num5)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num8 - character.magic.idleMagic) + " Idle Magic before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
			else if (character.res3.curRes3 - character.res3.idleRes3 > num6)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num9 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping these 2 weapons. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapWeapons();
				updateBonuses();
			}
		}
		else
		{
			if (item < 0 && item2 < 0)
			{
				return;
			}
			int num10 = accessoryID(item);
			int num11 = accessoryID(item2);
			if (num10 >= 0 || num11 >= 0)
			{
				return;
			}
			int num12 = daycareID(item);
			int num13 = daycareID(item2);
			if (num12 >= 0 || num13 >= 0)
			{
				return;
			}
			if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Weapon)
			{
				if (mergeable(character.inventory.weapon2, character.inventory.inventory[item2]))
				{
					int num14 = checkItemTransform(character.inventory.weapon2);
					if (num14 > 0)
					{
						character.inventory.deleteWeapon2();
						character.inventory.weapon2 = itemInfo.genLoot(num14);
					}
					else
					{
						Debug.Log("bad");
						character.inventory.weapon2.mergeItem(character.inventory.inventory[item2]);
						character.inventory.deleteItem(item2);
					}
					checkItemTransform(character.inventory.weapon2);
					return;
				}
				if (alreadyEquipped(character.inventory.inventory[item2].id))
				{
					return;
				}
				long num15 = character.totalCapEnergy();
				long num16 = character.totalCapMagic();
				long num17 = character.totalCapRes3();
				character.inventory.swapWeapon2();
				updateBonuses();
				long num18 = character.totalCapEnergy();
				long num19 = character.totalCapMagic();
				long num20 = character.totalCapRes3();
				long num21 = num15 - num18;
				long num22 = num16 - num19;
				long num23 = num17 - num20;
				if (character.curEnergy - character.idleEnergy > num18)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num21 - character.idleEnergy) + " Idle Energy before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon2();
					updateBonuses();
					return;
				}
				if (character.magic.curMagic - character.magic.idleMagic > num19)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num22 - character.magic.idleMagic) + " Idle Magic before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon2();
					updateBonuses();
					return;
				}
				if (character.res3.curRes3 - character.res3.idleRes3 > num20)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num23 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out this weapon, bub!", 2f);
					character.inventory.swapWeapon2();
					updateBonuses();
					return;
				}
			}
			if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.weapon2.boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
			{
				degradeBoost();
			}
		}
	}

	public int accessoryID(int id)
	{
		int num = id - 10000;
		if (num < 0 || num > character.inventory.accs.Count)
		{
			return -1;
		}
		return num;
	}

	public int daycareID(int id)
	{
		int num = id - 100000;
		if (num < 0 || num > character.inventory.daycare.Count)
		{
			return -1;
		}
		return num;
	}

	public void swapAcc()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		int num = accessoryID(item);
		int num2 = accessoryID(item2);
		int num3 = daycareID(item);
		int num4 = daycareID(item2);
		if (num3 >= 0 || num4 >= 0)
		{
			return;
		}
		if (num != -1 && num2 != -1 && num != num2)
		{
			long num5 = character.totalCapEnergy();
			long num6 = character.totalCapMagic();
			long num7 = character.totalCapRes3();
			character.inventory.swapAccs(num, num2);
			updateBonuses();
			long num8 = character.totalCapEnergy();
			long num9 = character.totalCapMagic();
			long num10 = character.totalCapRes3();
			long num11 = num5 - num8;
			long num12 = num6 - num9;
			long num13 = num7 - num10;
			if (character.curEnergy - character.idleEnergy > num8)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num11 - character.idleEnergy) + " Idle Energy before swapping these 2 accessories. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapAccs(num, num2);
				updateBonuses();
			}
			else if (character.magic.curMagic - character.magic.idleMagic > num9)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num12 - character.magic.idleMagic) + " Idle Magic before swapping these 2 accessories. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapAccs(num, num2);
				updateBonuses();
			}
			else if (character.res3.curRes3 - character.res3.idleRes3 > num10)
			{
				tooltip.showOverrideTooltip("You need to free up " + character.display(num13 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping these 2 accessories. This is due to a dumb quirk in the math. I'm sorry for the inconvenience.", 2f);
				character.inventory.swapAccs(num, num2);
				updateBonuses();
			}
		}
		else
		{
			if (item < 0 || item2 < 0 || num < 0 || num >= character.inventory.accs.Count || (item < 0 && item2 < 0))
			{
				return;
			}
			if (character.inventory.inventory[item2].id == 0 || character.inventory.inventory[item2].type == part.Accessory)
			{
				if (mergeable(character.inventory.accs[num], character.inventory.inventory[item2]))
				{
					if (num < character.inventory.accs.Count)
					{
						if (checkItemTransform(character.inventory.accs[num]) > 0)
						{
							tooltip.showOverrideTooltip("You need to move the equipped item into your inventory to transform it!", 2f);
						}
						else
						{
							character.inventory.accs[num].mergeItem(character.inventory.inventory[item2]);
							character.inventory.deleteItem(item2);
						}
						checkItemTransform(character.inventory.accs[num]);
					}
					return;
				}
				if (num >= character.inventory.accs.Count || alreadyEquipped(character.inventory.inventory[item2].id))
				{
					return;
				}
				long num14 = character.totalCapEnergy();
				long num15 = character.totalCapMagic();
				long num16 = character.totalCapRes3();
				character.inventory.swapAccWithItem(num, item2);
				updateBonuses();
				long num17 = character.totalCapEnergy();
				long num18 = character.totalCapMagic();
				long num19 = character.totalCapRes3();
				long num20 = num14 - num17;
				long num21 = num15 - num18;
				long num22 = num16 - num19;
				if (character.curEnergy - character.idleEnergy > num17)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num20 - character.idleEnergy) + " Idle Energy before swapping out this accessory, bub!", 2f);
					character.inventory.swapAccWithItem(num, item2);
					updateBonuses();
					return;
				}
				if (character.magic.curMagic - character.magic.idleMagic > num18)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num21 - character.magic.idleMagic) + " Idle Magic before swapping out this accessory, bub!", 2f);
					character.inventory.swapAccWithItem(num, item2);
					updateBonuses();
					return;
				}
				if (character.res3.curRes3 - character.res3.idleRes3 > num19)
				{
					tooltip.showOverrideTooltip("You need to free up " + character.display(num22 - character.res3.idleRes3) + " Idle " + character.res3.res3Name + " before swapping out this accessory, bub!", 2f);
					character.inventory.swapAccWithItem(num, item2);
					updateBonuses();
					return;
				}
			}
			if (character.inventory.inventory[item2].isBoost() && character.inventory.inventory[item2].removable && character.inventory.accs[num].boostEquip(character.inventory.inventory[item2], character.allItemList.boostBonus()))
			{
				degradeBoost();
			}
		}
	}

	public void swapDaycare()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (daycareID(item) >= 0 && daycareID(item2) < 0 && item2 >= 0 && item2 <= character.inventory.inventory.Count && !alreadyInDaycare(character.inventory.inventory[item2].id))
		{
			if (character.inventory.inventory[item2].type == part.MacGuffin && character.adventure.itopod.perkLevel[56] < 1)
			{
				tooltip.showOverrideTooltip("You need to buy the 'MacGuffin Daycare' Perk before the Daycare Kitty can take care of your MacGuffins!", 3f);
				return;
			}
			int levelsToAdd = daycares[daycareID(item)].levelsAdded();
			character.inventory.swapDaycareWithItem(daycareID(item), item2, levelsToAdd);
			checkIfItemMaxxed(character.inventory.inventory[item2]);
			daycares[daycareID(item)].updateItem();
			character.inventory.daycareTimers[daycareID(item)].reset();
		}
	}

	public int toMacGuffinIndex(int globalID)
	{
		if (globalID - 1000000 < 0 || globalID >= 2000000 || globalID - 1000000 > character.inventory.macguffins.Count)
		{
			return -1;
		}
		return globalID - 1000000;
	}

	public int globalMacguffinID(int index)
	{
		return index + 1000000;
	}

	public void swapMacguffin()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		int num = toMacGuffinIndex(item);
		if (num >= 0 && toMacGuffinIndex(item2) >= 0)
		{
			character.inventory.swapMacguffins(toMacGuffinIndex(item), toMacGuffinIndex(item2));
		}
		else
		{
			if (num < 0 || item2 < 0 || item2 > character.inventory.inventory.Count)
			{
				return;
			}
			if (mergeable(character.inventory.macguffins[num], character.inventory.inventory[item2]))
			{
				character.inventory.macguffins[num].mergeItem(character.inventory.inventory[item2]);
				character.inventory.deleteItem(item2);
				if (checkItemTransform(character.inventory.macguffins[num]) <= 0)
				{
				}
			}
			else
			{
				if (alreadyInMacguffins(character.inventory.inventory[item2].id) || (character.inventory.inventory[item2].id != 0 && character.inventory.inventory[item2].type != part.MacGuffin))
				{
					return;
				}
				character.inventory.swapMacguffinWithItem(num, item2);
			}
		}
		macguffins[num].updateItem();
	}

	public void swapItems()
	{
		int item = character.inventory.item1;
		int item2 = character.inventory.item2;
		if (item >= 0 && item2 >= 0 && item != item2)
		{
			if (mergeable(character.inventory.inventory[item], character.inventory.inventory[item2]))
			{
				int num = checkItemTransform(character.inventory.inventory[item]);
				int num2 = checkItemTransform(character.inventory.inventory[item2]);
				if (num > 0)
				{
					character.inventory.deleteItem(item);
					character.inventory.deleteItem(item2);
					itemInfo.makeLoot(num, item2);
				}
				else if (num2 > 0)
				{
					character.inventory.deleteItem(item);
					character.inventory.deleteItem(item2);
					itemInfo.makeLoot(num2, item2);
				}
				else
				{
					character.inventory.inventory[item2].mergeItem(character.inventory.inventory[item]);
					character.inventory.deleteItem(item);
					checkIfItemMaxxed(character.inventory.inventory[item2]);
				}
				checkItemTransform(character.inventory.inventory[item2]);
			}
			else if (character.inventory.inventory[item].isBoost() && character.inventory.inventory[item].removable && character.inventory.inventory[item2].isEquipment())
			{
				if (character.inventory.inventory[item2].boostEquip(character.inventory.inventory[item], character.allItemList.boostBonus()))
				{
					degradeBoost(item);
				}
			}
			else if (!character.inventory.inventory[item].isBoost() || !character.inventory.inventory[item2].isBoost() || character.inventory.inventory[item].id != character.inventory.inventory[item2].id)
			{
				character.inventory.swapItems();
			}
		}
		item = -1;
		item2 = -1;
	}

	public void degradeBoost()
	{
		int item = character.inventory.item2;
		int id = character.inventory.inventory[item].id;
		character.inventory.deleteItem(item);
		UnityEngine.Random.state = character.boostState;
		float num = UnityEngine.Random.value;
		character.boostState = UnityEngine.Random.state;
		if (num < character.totalRecycleBonus() && id != 1 && id != 14 && id != 27)
		{
			itemInfo.makeLoot(id - 1, item);
		}
	}

	public void degradeBoost(int id)
	{
		int id2 = character.inventory.inventory[id].id;
		if (character.inventory.inventory[id].isBoost())
		{
			character.inventory.deleteItem(id);
			UnityEngine.Random.state = character.boostState;
			float num = UnityEngine.Random.value;
			character.boostState = UnityEngine.Random.state;
			if (num < character.totalRecycleBonus() && id2 != 1 && id2 != 14 && id2 != 27)
			{
				itemInfo.makeLoot(id2 - 1, id);
			}
		}
	}

	public bool mergeable(Equipment item1, Equipment item2)
	{
		if (!item1.removable && !item2.removable)
		{
			return false;
		}
		if (item1.id == item2.id && item1.type == part.MacGuffin && item2.type == part.MacGuffin)
		{
			return true;
		}
		if ((item1.level >= 100 && !item1.removable) || (item2.level >= 100 && !item2.removable))
		{
			return false;
		}
		if (item1.id == item2.id && item1.id != 0 && (item1.type == part.Accessory || item1.type == part.Head || item1.type == part.Chest || item1.type == part.Legs || item1.type == part.Boots || item1.type == part.Weapon || item1.type == part.Misc))
		{
			return true;
		}
		if (item1.isBoost() && item2.isBoost() && item1.id == item2.id && !character.inventory.itemList.itemMaxxed[item1.id])
		{
			return true;
		}
		return false;
	}

	public bool willCreate100(Equipment item1, Equipment item2)
	{
		if (item1.level + item2.level < 99)
		{
			return false;
		}
		return true;
	}

	public string randomLevelUp()
	{
		int num = -5 - accessorySpaces();
		if (num > -5)
		{
			num = -5;
		}
		int num2 = UnityEngine.Random.Range(num, 0);
		string text = "";
		switch (num2)
		{
		case -10:
			if (accessorySpaces() >= 5)
			{
				character.inventory.accs[4].levelUp();
				text = " " + itemInfo.itemName[character.inventory.accs[4].id].ToString() + " ";
			}
			else
			{
				text = " your butt ";
			}
			break;
		case -9:
			if (accessorySpaces() >= 4)
			{
				character.inventory.accs[3].levelUp();
				text = " " + itemInfo.itemName[character.inventory.accs[3].id].ToString() + " ";
			}
			else
			{
				text = " your butt ";
			}
			break;
		case -8:
			if (accessorySpaces() >= 3)
			{
				character.inventory.accs[2].levelUp();
				text = " " + itemInfo.itemName[character.inventory.accs[2].id].ToString() + " ";
			}
			else
			{
				text = " your butt ";
			}
			break;
		case -7:
			character.inventory.accs[1].levelUp();
			text = " " + itemInfo.itemName[character.inventory.accs[1].id].ToString() + " ";
			break;
		case -6:
			character.inventory.accs[0].levelUp();
			text = " " + itemInfo.itemName[character.inventory.accs[0].id].ToString() + " ";
			break;
		case -5:
			character.inventory.weapon.levelUp();
			text = " " + itemInfo.itemName[character.inventory.weapon.id].ToString() + " ";
			break;
		case -4:
			character.inventory.boots.levelUp();
			text = " " + itemInfo.itemName[character.inventory.boots.id].ToString() + " ";
			break;
		case -3:
			character.inventory.legs.levelUp();
			text = " " + itemInfo.itemName[character.inventory.legs.id].ToString() + " ";
			break;
		case -2:
			character.inventory.chest.levelUp();
			text = " " + itemInfo.itemName[character.inventory.chest.id].ToString() + " ";
			break;
		case -1:
			character.inventory.head.levelUp();
			text = " " + itemInfo.itemName[character.inventory.head.id].ToString() + " ";
			break;
		default:
			character.inventory.head.levelUp();
			text = " " + itemInfo.itemName[character.inventory.head.id].ToString() + " ";
			break;
		}
		if (UnityEngine.Random.Range(0, 100) == 1)
		{
			text = " your butt ";
		}
		checkIfMaxxedAll();
		return text;
	}

	public void allLevelUp()
	{
		character.inventory.weapon.levelUp();
		character.inventory.boots.levelUp();
		character.inventory.legs.levelUp();
		character.inventory.chest.levelUp();
		character.inventory.head.levelUp();
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			character.inventory.accs[i].levelUp();
		}
		if (weapon2Unlocked())
		{
			character.inventory.weapon2.levelUp();
		}
		checkIfMaxxedAll();
	}

	public void daycareLevelUp()
	{
		for (int i = 0; i < character.inventory.daycare.Count; i++)
		{
			character.inventory.daycare[i].levelUp();
		}
	}

	public void checkIfMaxxedAll()
	{
		checkIfItemMaxxed(character.inventory.head);
		checkIfItemMaxxed(character.inventory.chest);
		checkIfItemMaxxed(character.inventory.legs);
		checkIfItemMaxxed(character.inventory.boots);
		checkIfItemMaxxed(character.inventory.weapon);
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			checkIfItemMaxxed(character.inventory.accs[i]);
		}
		if (weapon2Unlocked())
		{
			checkIfItemMaxxed(character.inventory.weapon2);
		}
	}

	public bool checkItemLevelup(int pid)
	{
		switch (pid)
		{
		case 94:
			return false;
		case 67:
			return false;
		default:
			return true;
		}
	}

	private bool alreadyEquipped(int pid)
	{
		if (pid == 0)
		{
			return false;
		}
		if (character.inventory.head.id == pid || character.inventory.chest.id == pid || character.inventory.legs.id == pid || character.inventory.boots.id == pid || character.inventory.weapon.id == pid || character.inventory.weapon2.id == pid)
		{
			return true;
		}
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.inventory.accs[i].id == pid)
			{
				return true;
			}
		}
		return false;
	}

	private bool alreadyInDaycare(int pid)
	{
		if (pid == 0)
		{
			return false;
		}
		for (int i = 0; i < character.inventory.daycare.Count; i++)
		{
			if (character.inventory.daycare[i].id == pid)
			{
				return true;
			}
		}
		return false;
	}

	private bool alreadyInMacguffins(int pid)
	{
		if (pid == 0)
		{
			return false;
		}
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id == pid)
			{
				return true;
			}
		}
		return false;
	}

	public int checkItemTransform(Equipment item)
	{
		if (item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
		}
		if (item.id == 53 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 76;
		}
		if (item.id == 76 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 94;
		}
		if (item.id == 94 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 142;
		}
		if (item.id == 142 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 170;
		}
		if (item.id == 170 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 229;
		}
		if (item.id == 229 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 295;
		}
		if (item.id == 295 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 388;
		}
		if (item.id == 388 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 430;
		}
		if (item.id == 430 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 504;
		}
		if (item.id == 504 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 480;
		}
		if (item.id == 120 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 121;
		}
		if (item.id == 67 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 128;
		}
		if (item.id == 128 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 169;
		}
		if (item.id == 169 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 230;
		}
		if (item.id == 230 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 296;
		}
		if (item.id == 296 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 389;
		}
		if (item.id == 389 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 431;
		}
		if (item.id == 431 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 505;
		}
		if (item.id == 505 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 485;
		}
		if (item.id == 154 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 159;
		}
		if (item.id == 195 && item.level >= 100 && character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			character.allItemList.markItemAsMaxxed(item.id);
			return 506;
		}
		return -1;
	}

	public void checkIfItemMaxxed(Equipment item)
	{
		if (item.id != 0 && item.level >= 100)
		{
			character.allItemList.markItemAsMaxxed(item.id);
		}
	}

	public bool transformable(int id)
	{
		switch (id)
		{
		case 53:
			return true;
		case 76:
			return true;
		case 100:
			return true;
		default:
			return false;
		}
	}

	public void applyAllBoosts(int id)
	{
		if ((id >= curSpaces() && id < 10000) || id < -10)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < character.inventory.inventory.Count; i++)
		{
			character.inventory.item1 = id;
			character.inventory.item2 = i;
			int id2 = character.inventory.inventory[character.inventory.item2].id;
			if (id == i || !character.inventory.inventory[character.inventory.item2].isBoost() || !character.inventory.inventory[character.inventory.item2].removable)
			{
				continue;
			}
			switch (id)
			{
			case -1:
				swapHead();
				break;
			case -2:
				swapChest();
				break;
			case -3:
				swapLegs();
				break;
			case -4:
				swapBoots();
				break;
			case -5:
				swapWeapon();
				break;
			case -6:
				swapWeapon2();
				break;
			}
			if (isAccessoryID(id))
			{
				swapAcc();
			}
			if (id >= 0 && !isAccessoryID(id) && !isMacGuffinID(id))
			{
				character.inventory.item1 = i;
				character.inventory.item2 = id;
				swapItems();
				if (character.settings.autoboostRecycledBoosts)
				{
					if (character.inventory.inventory[character.inventory.item1].id != id2 && character.inventory.inventory[character.inventory.item1].id != 0)
					{
						i--;
						num++;
					}
					else
					{
						num = 0;
					}
				}
			}
			else if (character.settings.autoboostRecycledBoosts)
			{
				if (character.inventory.inventory[character.inventory.item2].id != id2 && character.inventory.inventory[character.inventory.item2].id != 0)
				{
					i--;
					num++;
				}
				else
				{
					num = 0;
				}
			}
			if (num > 30)
			{
				break;
			}
		}
		updateInventory();
		character.inventory.item1 = 0;
		character.inventory.item2 = 0;
	}

	public void mergeAll(int id)
	{
		if ((id >= curSpaces() && id < 10000) || id < -10)
		{
			return;
		}
		for (int i = 0; i < character.inventory.inventory.Count; i++)
		{
			character.inventory.item1 = id;
			character.inventory.item2 = i;
			if (id == i)
			{
				continue;
			}
			if (id >= 0 && id < 10000)
			{
				if (character.inventory.inventory[character.inventory.item2].isMacGuffin() && character.inventory.inventory[character.inventory.item2].id == character.inventory.inventory[character.inventory.item1].id && character.inventory.inventory[character.inventory.item2].removable && !character.inventory.inventory[character.inventory.item2].isBoost())
				{
					character.inventory.item1 = i;
					character.inventory.item2 = id;
					swapItems();
				}
				else if (character.inventory.inventory[character.inventory.item2].id == character.inventory.inventory[character.inventory.item1].id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.inventory[character.inventory.item1].level < 100 && !character.inventory.inventory[character.inventory.item2].isBoost())
				{
					character.inventory.item1 = i;
					character.inventory.item2 = id;
					swapItems();
				}
				else if (character.inventory.inventory[character.inventory.item2].id == character.inventory.inventory[character.inventory.item1].id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level + character.inventory.inventory[character.inventory.item1].level <= 100 && character.inventory.inventory[character.inventory.item2].isBoost() && !character.inventory.itemList.itemMaxxed[character.inventory.inventory[character.inventory.item2].id])
				{
					character.inventory.item1 = i;
					character.inventory.item2 = id;
					swapItems();
				}
				continue;
			}
			if (isAccessoryID(id))
			{
				int num = id - 10000;
				if (num < character.inventory.accs.Count && character.inventory.inventory[character.inventory.item2].id == character.inventory.accs[num].id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.accs[num].level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapAcc();
				}
				continue;
			}
			if (toMacGuffinIndex(id) >= 0)
			{
				int num2 = toMacGuffinIndex(id);
				if (num2 < character.inventory.macguffins.Count && character.inventory.inventory[character.inventory.item2].id == character.inventory.macguffins[num2].id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].isMacGuffin())
				{
					swapMacguffin();
				}
				continue;
			}
			character.inventory.item1 = id;
			switch (id)
			{
			case -1:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.head.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level != 100 && character.inventory.head.level != 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapHead();
				}
				break;
			case -2:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.chest.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.chest.level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapChest();
				}
				break;
			case -3:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.legs.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.legs.level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapLegs();
				}
				break;
			case -4:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.boots.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.boots.level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapBoots();
				}
				break;
			case -5:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.weapon.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.weapon.level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapWeapon();
				}
				break;
			case -6:
				if (character.inventory.inventory[character.inventory.item2].id == character.inventory.weapon2.id && character.inventory.inventory[character.inventory.item2].removable && character.inventory.inventory[character.inventory.item2].level < 100 && character.inventory.weapon2.level < 100 && character.inventory.inventory[character.inventory.item2].isEquipment())
				{
					swapWeapon2();
				}
				break;
			}
		}
		character.inventory.item1 = 0;
		character.inventory.item2 = 0;
		updateInventory();
	}

	public int totalInvMergeSlots()
	{
		int num = 0;
		if (character.purchases.hasInvMerge)
		{
			num++;
		}
		num += character.arbitrary.invMergeSlots;
		if (character.beastQuest.quirkLevel[55] >= 1)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[111] >= 1)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[112] >= 1)
		{
			num++;
		}
		if (num < 0)
		{
			num = 0;
		}
		if (num > 10)
		{
			num = 10;
		}
		return num;
	}

	public void autoMerge()
	{
		mergeAll(-1);
		mergeAll(-2);
		mergeAll(-3);
		mergeAll(-4);
		mergeAll(-5);
		if (weapon2Unlocked())
		{
			mergeAll(-6);
		}
		for (int i = 10000; accessoryID(i) < accessorySpaces(); i++)
		{
			mergeAll(i);
		}
		for (int j = 1000000; j - 1000000 < character.inventory.macguffins.Count; j++)
		{
			mergeAll(j);
		}
		if (totalInvMergeSlots() > 0 && character.settings.invAutoMergeOn)
		{
			for (int k = 0; k < totalInvMergeSlots(); k++)
			{
				mergeAll(k);
			}
		}
		updateInventory();
	}

	public bool weapon2Unlocked()
	{
		return character.wishes.wishes[28].level > 0;
	}

	public void autoBoost()
	{
		applyAllBoosts(-1);
		applyAllBoosts(-2);
		applyAllBoosts(-3);
		applyAllBoosts(-4);
		applyAllBoosts(-5);
		if (weapon2Unlocked())
		{
			applyAllBoosts(-6);
		}
		for (int i = 10000; accessoryID(i) < accessorySpaces(); i++)
		{
			applyAllBoosts(i);
		}
		if (totalInvMergeSlots() > 0 && character.settings.invAutoBoostOn)
		{
			for (int j = 0; j < totalInvMergeSlots(); j++)
			{
				if (character.inventory.inventory[j].isEquipment())
				{
					applyAllBoosts(j);
				}
			}
		}
		infinityCubeAll();
		updateInventory();
	}

	public void toggleAutoMerge()
	{
		if (!character.purchases.hasAutoMerge)
		{
			tooltip.showTooltip("You need to buy Auto merge in the EXP Menu to activate this!", 2f);
			return;
		}
		character.settings.autoMergeOn = !character.settings.autoMergeOn;
		updateToggleState();
	}

	public void updateToggleState()
	{
		if (!character.settings.autoMergeOn || !character.purchases.hasAutoMerge)
		{
			mergeImage.color = Color.clear;
		}
		else
		{
			mergeImage.color = Color.white;
		}
	}

	public void toggleAutoBoost()
	{
		if (character.allChallenges.noEquipmentChallenge.completions() <= 0)
		{
			tooltip.showTooltip("You need to unlock Auto Boost by completing the No Equipment Challenge!", 2f);
			return;
		}
		character.settings.autoBoostOn = !character.settings.autoBoostOn;
		updateBoostToggleState();
	}

	public void updateBoostToggleState()
	{
		if (!character.settings.autoBoostOn || character.allChallenges.noEquipmentChallenge.completions() <= 0)
		{
			boostImage.color = Color.clear;
		}
		else
		{
			boostImage.color = Color.white;
		}
	}

	public string itemTooltipText(int id)
	{
		Equipment equipment = new Equipment();
		if (isMacGuffinID(id))
		{
			if (id - 1000000 < 0)
			{
				return "";
			}
			if (id - 1000000 >= character.inventory.macguffins.Count)
			{
				return "";
			}
			equipment = character.inventory.macguffins[id - 1000000];
		}
		else if (isAccessoryID(id))
		{
			if (id - 10000 < 0)
			{
				return "";
			}
			if (id - 10000 >= character.inventory.accs.Count)
			{
				return "";
			}
			equipment = character.inventory.accs[id - 10000];
		}
		else
		{
			switch (id)
			{
			case -1:
				equipment = character.inventory.head;
				break;
			case -2:
				equipment = character.inventory.chest;
				break;
			case -3:
				equipment = character.inventory.legs;
				break;
			case -4:
				equipment = character.inventory.boots;
				break;
			case -5:
				equipment = character.inventory.weapon;
				break;
			case -6:
				equipment = character.inventory.weapon2;
				break;
			case -69:
				equipment = character.inventory.trash;
				break;
			default:
				if (id > character.inventoryController.curSpaces())
				{
					return "";
				}
				if (id < 0)
				{
					return "";
				}
				equipment = character.inventory.inventory[id];
				break;
			}
		}
		if (equipment.id == 0)
		{
			if (id == -69)
			{
				return "Drag items onto this spot to Trash them from your inventory. You can recover the last item you tossed in here, but after that, it's gone!";
			}
			switch (id)
			{
			case -1:
				return "This would be a good place to equip a Helmet... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find one!";
			case -2:
				return "This would be a good place to equip a Chestpiece... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find one!";
			case -3:
				return "This would be a good place to equip some Leggings.. IF YOU HAD SOME. Go kill some bosses in Adventure mode and find some!";
			case -4:
				return "This would be a good place to equip some boots... IF YOU HAD A PAIR. Go kill some bosses in Adventure mode and find some!";
			case -5:
				return "This would be a good place to equip a Weapon... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find one!";
			case -6:
				return "This would be a good place to equip a Weapon... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find one!";
			}
			if (id >= 0 && id < totalInvMergeSlots())
			{
				return "<b><color=blue>THIS IS AN INVENTORY AUTOMERGE SLOT. AUTOMERGE AND AUTOBOOST WILL BE PERFORMED ON THIS SLOT. NO ITEMS WILL DROP IN THESE SLOTS.</color></b>";
			}
			if (isAccessoryID(id))
			{
				return "This would be a good place to equip an Accessory... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find some!";
			}
			if (isMacGuffinID(id))
			{
				return "This would be a good place to equip a MacGuffin Fragment... IF YOU HAD ONE. Go kill some bosses in Adventure mode and find some!";
			}
		}
		return itemTooltipText(equipment);
	}

	public string itemTooltipText(Equipment item)
	{
		string text = "";
		if (item.id == 288)
		{
			text = "<b>" + itemInfo.itemName[item.id] + " Level " + item.level;
			if (item.level == 69)
			{
				text += " lol";
			}
			text += "</b>";
			if (item.type == part.Misc)
			{
				text += " <b><color=#ff7011ff>CONSUMABLE</color></b>";
			}
			text = text + "\n\n" + itemInfo.itemDesc[item.id];
			text = ((!character.adventure.skeletonWhacked) ? (text + "\n\n<b>Skeleton</b>") : (text + "\n\n<i><color=#555555ff>Skeleton</color></i>"));
			text = ((!character.adventure.icarusWhacked) ? (text + "\n<b>Icarus Proudbottom</b>") : (text + "\n<i><color=#555555ff>Icarus Proudbottom</color></i>"));
			text += "\n";
			text = ((!character.adventure.kingCircleWhacked) ? (text + "\n<b>King Circle</b>") : (text + "\n<i><color=#555555ff>King Circle</color></i>"));
			text = ((!character.adventure.robBossWhacked) ? (text + "\n<b>Rob Boss</b>") : (text + "\n<i><color=#555555ff>Rob Boss</color></i>"));
			text += "\n\nThere's a weird gap in the list of names. Why would they put that there?";
			if (character.adventure.skeletonWhacked && character.adventure.icarusWhacked && character.adventure.kingCircleWhacked && character.adventure.emptyNameWhacked && character.adventure.robBossWhacked)
			{
				text += "\n\n<b>You should head back to the Consigliere now that you completed the list!</b>";
			}
			else if (character.adventure.skeletonWhacked && character.adventure.icarusWhacked && character.adventure.kingCircleWhacked && character.adventure.robBossWhacked)
			{
				text += "\n\n<b>You feel like this Death Note should be complete, but that blank space still gives you the spoops.</b>";
			}
			return text;
		}
		if (item.type == part.Misc)
		{
			text = "<b>" + itemInfo.itemName[item.id] + " Level " + item.level;
			if (item.level == 69)
			{
				text += " lol";
			}
			text += "</b>";
			if (!item.removable)
			{
				text += " <b><color=red>PROTECTED</color></b>";
			}
			if (item.type == part.Misc)
			{
				text += " <b><color=#ff7011ff>CONSUMABLE</color></b>";
			}
			text = text + "\n\n" + itemInfo.itemDesc[item.id];
			if (character.beastQuestController.isQuestItem(item.id))
			{
				text = text + " This item is found in <b>" + character.beastQuestController.questItemLocation(item.id) + "</b>.";
			}
			return text;
		}
		if (item.isBoost())
		{
			text = "<b>" + itemInfo.itemName[item.id] + " Level " + item.level;
			if (item.level == 69)
			{
				text += " lol";
			}
			text += "</b>";
			if (!item.removable)
			{
				text += " <b><color=red>PROTECTED</color></b>";
			}
			if (item.type == part.Misc)
			{
				text += " <b><color=#ff7011ff>CONSUMABLE</color></b>";
			}
			text = text + "\n\n" + itemInfo.itemDesc[item.id];
			if (item.type == part.atkBoost)
			{
				text = text + "\n<b>Total Boost with Bonuses:</b> " + (item.capAttack * character.allItemList.boostBonus()).ToString("###,##0.##");
			}
			if (item.type == part.defBoost)
			{
				text = text + "\n<b>Total Boost with Bonuses:</b> " + (item.capDefense * character.allItemList.boostBonus()).ToString("###,##0.##");
			}
			if (item.type == part.specBoost)
			{
				text = text + "\n<b>Total Boost with Bonuses:</b> " + (item.spec1Cap * character.allItemList.boostBonus()).ToString("###,##0.##");
			}
			return text;
		}
		if (item.type == part.MacGuffin)
		{
			text = ((item.id == 298) ? ("<b>" + character.res3.res3Name + " Power MacGuffin Fragment Level " + item.level + " " + item.type) : ((item.id == 299) ? ("<b>" + character.res3.res3Name + " Cap MacGuffin Fragment Level " + item.level + " " + item.type) : ((item.id != 300) ? ("<b>" + itemInfo.itemName[item.id] + " Level " + item.level + " " + item.type) : ("<b>" + character.res3.res3Name + " Bar MacGuffin Fragment Level " + item.level + " " + item.type))));
			if (item.level == 69)
			{
				text += " lol";
			}
			text += "</b>";
			if (!item.removable)
			{
				text += " <b><color=red>PROTECTED</color></b>";
			}
			if (checkItemTransform(item) > 0)
			{
				text += " <b><color=purple>TRANSFORMABLE</color></b>";
			}
			text = text + "\n\n" + itemInfo.itemDesc[item.id];
			float num = 0f;
			switch (item.id)
			{
			case 198:
				num = energyPowerBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[0] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[0] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[0] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 199:
				num = energyCapBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[1] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[1] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[1] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 200:
				num = magicPowerBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[2] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[2] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[2] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 201:
				num = magicCapBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[3] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[3] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[3] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 202:
				num = energyNGUBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[4] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[4] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[4] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 203:
				num = energyNGUBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[5] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[5] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[5] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 204:
				num = magicNGUBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[6] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[6] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[6] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 205:
				num = magicBarBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[7] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[7] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[7] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 206:
				num = energyBeardBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[8] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[8] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[8] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 207:
				num = magicBeardBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[9] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[9] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[9] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 208:
				num = dropChanceBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[10] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[10] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[10] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 209:
				num = goldBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[11] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[11] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[11] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 210:
				num = augSpeedBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[12] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[12] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[12] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 211:
				num = energyWandoosBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[15] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[15] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[15] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 228:
				num = powerBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[13] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[13] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[13] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 250:
				num = magicWandoosBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[16] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[16] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[16] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 289:
				num = numberBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[17] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[17] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[17] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 290:
				num = bloodBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[18] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[18] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[18] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 291:
				num = adventureBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + macguffinBonuses[19] + " bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[19] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[19] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 298:
				num = res3PowerBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + character.res3.res3Name + " Power bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[20] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[20] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 299:
				num = res3CapBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + character.res3.res3Name + " Cap bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[21] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[21] + num) * 100f).ToString("###,##0.###") + "</b>%";
			case 300:
				num = res3BarBonusPerRebirth(item);
				return text + "\n\nCurrently, this MacGuffin will increase your " + character.res3.res3Name + " Bar bonus by <b>" + (num * 100f).ToString("###,##0.###") + "</b>% upon rebirth, taking your bonus from <b>" + (character.inventory.macguffinBonuses[22] * 100f).ToString("###,##0.###") + "</b>% to <b>" + ((character.inventory.macguffinBonuses[22] + num) * 100f).ToString("###,##0.###") + "</b>%";
			default:
				return text + "\n\nTell 4G he made a goof with the MacGuffins!";
			}
		}
		text = "<b>" + itemInfo.itemName[item.id] + " Level " + item.level + " " + item.type;
		if (item.level == 69)
		{
			text += " lol";
		}
		text += "</b>";
		if (!item.removable)
		{
			text += " <b><color=red>PROTECTED</color></b>";
		}
		if (checkItemTransform(item) > 0)
		{
			text += " <b><color=purple>TRANSFORMABLE</color></b>";
		}
		if (item.id == 53 && item.level >= 40)
		{
			text += "\n\nYou sense that you are cursed to loot these, no matter what zone you're in.";
		}
		text = text + "\n\n" + itemInfo.itemDesc[item.id];
		if (item.isEquipment())
		{
			string text2 = "\n";
			string text3 = "";
			bool flag = true;
			bool flag2 = false;
			if (item.capAttack != 0f)
			{
				if (flag)
				{
					text3 += "\n\n<b>Stats</b>";
					flag = false;
					flag2 = true;
				}
				float num2 = Mathf.Floor(item.curAttack * Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f));
				text2 = "\n<b>Power:</b> " + num2.ToString("###,##0") + " / " + Mathf.Floor(item.capAttack * (1f + (float)item.level / 100f)).ToString("###,##0") + "\n<b>Max Health:</b> " + (num2 * 3f).ToString("###,##0.##") + " / " + (Mathf.Floor(item.capAttack * (1f + (float)item.level / 100f)) * 3f).ToString("###,##0.##");
				if (item.curAttack >= Mathf.Floor(item.capAttack * (1f + (float)item.level / 100f)))
				{
					text2 = "<color=green>" + text2 + "</color>";
				}
				text3 += text2;
			}
			if (item.capDefense != 0f)
			{
				if (flag)
				{
					text3 += "\n\n<b>Stats</b>\n";
					flag = false;
				}
				else if (flag2)
				{
					text3 += "\n";
				}
				float num3 = Mathf.Floor(item.curDefense * Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f));
				text2 = "<b>Toughness:</b> " + num3.ToString("###,##0") + " / " + Mathf.Floor(item.capDefense * (1f + (float)item.level / 100f)).ToString("###,##0") + "\n<b>Health Regen:</b> " + (num3 * 0.03f).ToString("###,##0.##") + " / " + (Mathf.Floor(item.capDefense * (1f + (float)item.level / 100f)) * 0.03f).ToString("###,##0.##");
				if (item.curDefense >= Mathf.Floor(item.capDefense * (1f + (float)item.level / 100f)))
				{
					text2 = "<color=green>" + text2 + "</color>";
				}
				text3 += text2;
			}
			if (item.spec1Type != specType.None)
			{
				if (flag)
				{
					if (item.spec1Type != specType.None)
					{
						text3 += "\n\n<b>Stats</b>\n";
					}
					flag = false;
				}
				else
				{
					text3 += "\n";
				}
				text3 += "<b>\nSpecial Bonuses</b>";
				float amount = Mathf.Floor(item.spec1Cur * Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f));
				float num4 = Mathf.Floor(item.spec1Cap * (1f + (float)item.level / 100f));
				string text4 = "\n<b>" + effectName(item.spec1Type) + ":</b> " + amount.ToString("###,##0.##") + " / " + num4.ToString("###,##0.##") + " (" + effectBonus(amount, item.spec1Type).ToString("###,##0.##") + "%)";
				if (item.spec1Cur >= Mathf.Floor(item.spec1Cap * (1f + (float)item.level / 100f)))
				{
					text4 = "<color=green>" + text4 + "</color>";
				}
				text3 += text4;
			}
			if (item.spec2Type != specType.None)
			{
				float amount2 = Mathf.Floor(item.spec2Cur * Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f));
				float num5 = Mathf.Floor(item.spec2Cap * (1f + (float)item.level / 100f));
				string text5 = "\n<b>" + effectName(item.spec2Type) + ":</b> " + amount2.ToString("###,##0.##") + " / " + num5.ToString("###,##0.##") + " (" + effectBonus(amount2, item.spec2Type).ToString("###,##0.##") + "%)";
				if (item.spec2Cur >= Mathf.Floor(item.spec2Cap * (1f + (float)item.level / 100f)))
				{
					text5 = "<color=green>" + text5 + "</color>";
				}
				text3 += text5;
			}
			if (item.spec3Type != specType.None)
			{
				float amount3 = Mathf.Floor(item.spec3Cur * Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f));
				float num6 = Mathf.Floor(item.spec3Cap * (1f + (float)item.level / 100f));
				string text6 = "\n<b>" + effectName(item.spec3Type) + ":</b> " + amount3.ToString("###,##0.##") + " / " + num6.ToString("###,##0.##") + " (" + effectBonus(amount3, item.spec3Type).ToString("###,##0.##") + "%)";
				if (item.spec3Cur >= Mathf.Floor(item.spec3Cap * (1f + (float)item.level / 100f)))
				{
					text6 = "<color=green>" + text6 + "</color>";
				}
				text3 += text6;
			}
			text += text3;
			if (item.bossRequired > character.effectiveBossID())
			{
				text = text + "\n\n<b>NOTE: This item is currently <color=red>" + (Mathf.Min((float)character.effectiveBossID() / (float)item.bossRequired, 1f) * 100f).ToString("#0.0") + "%</color> effective. 100% effectiveness gained by Boss " + item.bossRequired + ".</b>";
			}
		}
		return text;
	}

	private string effectName(specType type)
	{
		string text = "";
		switch (type)
		{
		case specType.AdvTraining:
			return "Advanced Training";
		case specType.EnergyPerBar:
			return "Energy Bars";
		case specType.EnergyPerBar2:
			return "Energy Bars";
		case specType.MagicPerBar:
			return "Magic Bars";
		case specType.MagicPerBar2:
			return "Magic Bars";
		case specType.EnergyPower:
			return "Energy Power";
		case specType.EnergyPower2:
			return "Energy Power";
		case specType.MagicPower:
			return "Magic Power";
		case specType.MagicPower2:
			return "Magic Power";
		case specType.EnergyCap:
			return "Energy Cap";
		case specType.MagicCap:
			return "Magic Cap";
		case specType.Looting:
			return "Drop Chance";
		case specType.Cooldown:
			return "Move Cooldowns";
		case specType.Wandoos98:
			return "Wandoos Speed";
		case specType.Seeds:
			return "Seed Gain";
		case specType.GoldDropAmount:
			return "Gold Drops";
		case specType.Beards:
			return "Beard Speed";
		case specType.EnergySpeed:
			return "Energy Speed";
		case specType.MagicSpeed:
			return "Magic Speed";
		case specType.AllPower:
			return "EM Power";
		case specType.Augs:
			return "Aug Speed";
		case specType.AllPerBar:
			return "EM Bars";
		case specType.AllCap:
			return "EM Cap";
		case specType.EnergyPower3:
			return "Energy Power";
		case specType.EnergyPerBar3:
			return "Energy Bars";
		case specType.EnergyCap3:
			return "Energy Cap";
		case specType.MagicCap3:
			return "Magic Cap";
		case specType.MagicPerBar3:
			return "Magic Bars";
		case specType.MagicPower3:
			return "Magic Power";
		case specType.GoldDrop2:
			return "Gold Drops";
		case specType.Looting2:
			return "Drop Chance";
		case specType.AdvTraining2:
			return "Advanced Training";
		case specType.NGU:
			return "NGU Speed";
		case specType.NGU2:
			return "NGU Speed";
		case specType.Wandoos2:
			return "Wandoos Speed";
		case specType.Beards2:
			return "Beard Speed";
		case specType.Yggdrasil:
			return "Yggdrasil Yield";
		case specType.DaycareSpeed:
			return "Daycare Speed";
		case specType.QuestDrop:
			return "Quest Drops";
		case specType.Blood:
			return "Blood Gain";
		case specType.Res3Power:
			return character.res3.res3Name + " Power";
		case specType.Res3Cap:
			return character.res3.res3Name + " Cap";
		case specType.Res3Bar:
			return character.res3.res3Name + " Bars";
		case specType.HackSpeed:
			return "Hack Speed";
		case specType.WishSpeed:
			return "Wish Speed";
		default:
			return type.ToString();
		}
	}

	private float effectBonus(float amount, specType type)
	{
		switch (type)
		{
		case specType.BoostRecycle:
			return amount / 10f;
		case specType.Looting:
			return amount / 10f;
		case specType.Cooldown:
			return amount / 100f;
		case specType.Wandoos98:
			return amount / 100f;
		case specType.AdvTraining:
			return amount / 100f;
		case specType.EnergyPower2:
			return amount / 10f;
		case specType.MagicPower2:
			return amount / 10f;
		case specType.EnergyPerBar2:
			return amount / 10f;
		case specType.MagicPerBar2:
			return amount / 10f;
		case specType.EnergyCap:
			return amount / 100f;
		case specType.MagicCap:
			return amount / 100f;
		case specType.NGU:
			return amount / 100f;
		case specType.Respawn:
			return amount / 1000f;
		case specType.EXP:
			return amount / 10000f;
		case specType.AP:
			return amount / 10000f;
		case specType.Beards:
			return amount / 1000f;
		case specType.Seeds:
			return amount / 1000f;
		case specType.AllCap:
			return amount / 10000f;
		case specType.AllPerBar:
			return amount / 1000f;
		case specType.AllPower:
			return amount / 1000f;
		case specType.Augs:
			return amount / 10000f;
		case specType.EnergyPower3:
			return amount / 1000f;
		case specType.EnergyPerBar3:
			return amount / 1000f;
		case specType.EnergyCap3:
			return amount / 10000f;
		case specType.MagicCap3:
			return amount / 10000f;
		case specType.MagicPerBar3:
			return amount / 1000f;
		case specType.MagicPower3:
			return amount / 1000f;
		case specType.GoldDrop2:
			return amount / 1000f;
		case specType.Looting2:
			return amount / 10000f;
		case specType.AdvTraining2:
			return amount / 10000f;
		case specType.NGU2:
			return amount / 10000f;
		case specType.Wandoos2:
			return amount / 10000f;
		case specType.Beards2:
			return amount / 10000f;
		case specType.Yggdrasil:
			return amount / 100000f;
		case specType.DaycareSpeed:
			return amount / 100000f;
		case specType.QuestDrop:
			return amount / 1000000f;
		case specType.Blood:
			return amount / 1000000f;
		case specType.Res3Power:
			return amount / 1000000f;
		case specType.Res3Cap:
			return amount / 10000000f;
		case specType.Res3Bar:
			return amount / 1000000f;
		case specType.HackSpeed:
			return amount / 10000000f;
		case specType.WishSpeed:
			return amount / 10000000f;
		default:
			return amount;
		}
	}

	public float getBonusFactor(float amount, specType type)
	{
		switch (type)
		{
		case specType.BoostRecycle:
			return amount / 1000f;
		case specType.Looting:
			return amount / 1000f;
		case specType.Cooldown:
			return amount / 10000f;
		case specType.Wandoos98:
			return amount / 10000f;
		case specType.AdvTraining:
			return amount / 10000f;
		case specType.EnergyPower2:
			return amount / 1000f;
		case specType.MagicPower2:
			return amount / 1000f;
		case specType.EnergyPerBar2:
			return amount / 1000f;
		case specType.MagicPerBar2:
			return amount / 1000f;
		case specType.EnergyCap:
			return amount / 10000f;
		case specType.MagicCap:
			return amount / 10000f;
		case specType.NGU:
			return amount / 10000f;
		case specType.Respawn:
			return amount / 100000f;
		case specType.EXP:
			return amount / 1000000f;
		case specType.AP:
			return amount / 1000000f;
		case specType.Beards:
			return amount / 100000f;
		case specType.Seeds:
			return amount / 100000f;
		case specType.AllCap:
			return amount / 1000000f;
		case specType.AllPerBar:
			return amount / 100000f;
		case specType.AllPower:
			return amount / 100000f;
		case specType.Augs:
			return amount / 1000000f;
		case specType.EnergyPower3:
			return amount / 100000f;
		case specType.EnergyPerBar3:
			return amount / 100000f;
		case specType.EnergyCap3:
			return amount / 1000000f;
		case specType.MagicCap3:
			return amount / 1000000f;
		case specType.MagicPerBar3:
			return amount / 100000f;
		case specType.MagicPower3:
			return amount / 100000f;
		case specType.GoldDrop2:
			return amount / 100000f;
		case specType.Looting2:
			return amount / 1000000f;
		case specType.AdvTraining2:
			return amount / 1000000f;
		case specType.NGU2:
			return amount / 1000000f;
		case specType.Wandoos2:
			return amount / 1000000f;
		case specType.Beards2:
			return amount / 1000000f;
		case specType.Yggdrasil:
			return amount / 10000000f;
		case specType.DaycareSpeed:
			return amount / 10000000f;
		case specType.QuestDrop:
			return amount / 100000000f;
		case specType.Blood:
			return amount / 100000000f;
		case specType.Res3Power:
			return amount / 100000000f;
		case specType.Res3Cap:
			return amount / 1E+09f;
		case specType.Res3Bar:
			return amount / 100000000f;
		case specType.HackSpeed:
			return amount / 1E+09f;
		case specType.WishSpeed:
			return amount / 1E+09f;
		default:
			return amount / 100f;
		}
	}

	public long equipEnergyChange(Equipment newEquip, int id)
	{
		Equipment equip;
		if (isAccessoryID(id))
		{
			equip = character.inventory.accs[accessoryID(id)];
		}
		else
		{
			switch (id)
			{
			case -1:
				equip = character.inventory.head;
				break;
			case -2:
				equip = character.inventory.chest;
				break;
			case -3:
				equip = character.inventory.legs;
				break;
			case -4:
				equip = character.inventory.boots;
				break;
			case -5:
				equip = character.inventory.weapon;
				break;
			default:
				return 0L;
			}
		}
		float bonusFactor = getBonusFactor(equipSpecBonus(specType.EnergyCap, equip), specType.EnergyCap);
		float bonusFactor2 = getBonusFactor(equipSpecBonus(specType.EnergyCap, newEquip), specType.EnergyCap);
		long num = Convert.ToInt64((float)character.capEnergy * bonusFactor);
		long num2 = Convert.ToInt64((float)character.capEnergy * bonusFactor2);
		Debug.Log(num);
		Debug.Log(num2);
		return num - num2;
	}

	public long equipMagicChange(Equipment newEquip, int id)
	{
		Equipment equip;
		if (isAccessoryID(id))
		{
			equip = character.inventory.accs[accessoryID(id)];
		}
		else
		{
			switch (id)
			{
			case -1:
				equip = character.inventory.head;
				break;
			case -2:
				equip = character.inventory.chest;
				break;
			case -3:
				equip = character.inventory.legs;
				break;
			case -4:
				equip = character.inventory.boots;
				break;
			case -5:
				equip = character.inventory.weapon;
				break;
			default:
				return 0L;
			}
		}
		float bonusFactor = getBonusFactor(equipSpecBonus(specType.MagicCap, equip), specType.MagicCap);
		float bonusFactor2 = getBonusFactor(equipSpecBonus(specType.MagicCap, newEquip), specType.MagicCap);
		long num = Convert.ToInt64((float)character.magic.capMagic * bonusFactor);
		long num2 = Convert.ToInt64((float)character.magic.capMagic * bonusFactor2);
		return num - num2;
	}

	public bool freeSpace()
	{
		int num = totalInvMergeSlots();
		if (num < 0)
		{
			num = 0;
		}
		for (int i = num; i < curSpaces(); i++)
		{
			if (character.inventory.inventory[i].id == 0)
			{
				return true;
			}
		}
		return false;
	}

	public void changePage(int pageID)
	{
		int num = pageID * 60;
		for (int i = 0; i < inventory.Length; i++)
		{
			if (!(inventory[i] == null))
			{
				inventory[i].id = num;
				num++;
				inventory[i].updateItem();
			}
		}
	}

	public int apathyCheck()
	{
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.inventory.accs[i].id == 135)
			{
				return character.inventory.accs[i].level;
			}
		}
		return -1;
	}

	public bool isAccessoryID(int id)
	{
		if (id >= 10000)
		{
			return id < 100000;
		}
		return false;
	}

	public bool isMacGuffinID(int id)
	{
		if (id >= 1000000)
		{
			return id < 2000000;
		}
		return false;
	}

	public void assignCurrentEquipToLoadout(int loadoutID)
	{
		if (loadoutID >= character.inventory.loadouts.Count)
		{
			return;
		}
		if (character.inventory.head.id == 0)
		{
			character.inventory.loadouts[loadoutID].head = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].head = -1;
		}
		if (character.inventory.chest.id == 0)
		{
			character.inventory.loadouts[loadoutID].chest = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].chest = -2;
		}
		if (character.inventory.legs.id == 0)
		{
			character.inventory.loadouts[loadoutID].legs = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].legs = -3;
		}
		if (character.inventory.boots.id == 0)
		{
			character.inventory.loadouts[loadoutID].boots = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].boots = -4;
		}
		if (character.inventory.weapon.id == 0)
		{
			character.inventory.loadouts[loadoutID].weapon = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].weapon = -5;
		}
		if (character.inventory.weapon2.id == 0)
		{
			character.inventory.loadouts[loadoutID].weapon2 = -1000;
		}
		else
		{
			character.inventory.loadouts[loadoutID].weapon2 = -6;
		}
		for (int i = 10000; accessoryID(i) < character.inventory.accs.Count; i++)
		{
			int num = accessoryID(i);
			if (num >= character.inventory.accs.Count)
			{
				character.inventory.loadouts[loadoutID].accessories[accessoryID(i)] = -1000;
			}
			else if (character.inventory.accs[num].id == 0)
			{
				character.inventory.loadouts[loadoutID].accessories[accessoryID(i)] = -1000;
			}
			else
			{
				character.inventory.loadouts[loadoutID].accessories[accessoryID(i)] = i;
			}
		}
	}

	public void equipLoadout(int loadoutID)
	{
		if (loadoutID >= loadoutSpaces())
		{
			return;
		}
		if (character.settings.unassignWhenSwapping)
		{
			character.removeAllEnergyAndMagic();
			if (character.arbitrary.instaTrain)
			{
				character.idleEnergy -= 12L;
				character.training.attackEnergy[0] += 6L;
				character.training.defenseEnergy[0] += 6L;
			}
		}
		if (character.inventory.loadouts[loadoutID].head != -1000 && character.inventory.loadouts[loadoutID].head < 100000 && character.inventory.loadouts[loadoutID].head != -1 && (character.inventory.loadouts[loadoutID].head >= 0 || character.inventory.loadouts[loadoutID].head < 10000))
		{
			character.inventory.item1 = -1;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].head;
			swapHead();
			updateBonuses();
		}
		if (character.inventory.loadouts[loadoutID].chest != -1000 && character.inventory.loadouts[loadoutID].chest < 100000 && character.inventory.loadouts[loadoutID].chest != -1 && (character.inventory.loadouts[loadoutID].chest >= 0 || character.inventory.loadouts[loadoutID].chest < 10000))
		{
			character.inventory.item1 = -2;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].chest;
			swapChest();
			updateBonuses();
		}
		if (character.inventory.loadouts[loadoutID].legs != -1000 && character.inventory.loadouts[loadoutID].legs < 100000 && character.inventory.loadouts[loadoutID].legs != -1 && (character.inventory.loadouts[loadoutID].legs >= 0 || character.inventory.loadouts[loadoutID].legs < 10000))
		{
			character.inventory.item1 = -3;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].legs;
			swapLegs();
			updateBonuses();
		}
		if (character.inventory.loadouts[loadoutID].boots != -1000 && character.inventory.loadouts[loadoutID].boots < 100000 && character.inventory.loadouts[loadoutID].boots != -1 && (character.inventory.loadouts[loadoutID].boots >= 0 || character.inventory.loadouts[loadoutID].boots < 10000))
		{
			character.inventory.item1 = -4;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].boots;
			swapBoots();
			updateBonuses();
		}
		if (character.inventory.loadouts[loadoutID].weapon != -1000 && character.inventory.loadouts[loadoutID].weapon < 100000 && character.inventory.loadouts[loadoutID].weapon != -1 && (character.inventory.loadouts[loadoutID].weapon >= 0 || character.inventory.loadouts[loadoutID].weapon < 10000))
		{
			character.inventory.item1 = -5;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].weapon;
			swapWeapon();
			updateBonuses();
		}
		if (character.wishes.wishes[28].level >= 1 && character.inventory.loadouts[loadoutID].weapon2 != -1000 && character.inventory.loadouts[loadoutID].weapon2 < 100000 && character.inventory.loadouts[loadoutID].weapon2 != -1 && (character.inventory.loadouts[loadoutID].weapon2 >= 0 || character.inventory.loadouts[loadoutID].weapon < 10000))
		{
			character.inventory.item1 = -6;
			character.inventory.item2 = character.inventory.loadouts[loadoutID].weapon2;
			swapWeapon2();
			updateBonuses();
		}
		for (int i = 0; i < character.inventory.loadouts[loadoutID].accessories.Count; i++)
		{
			if (character.inventory.loadouts[loadoutID].accessories[i] != -1000 && character.inventory.loadouts[loadoutID].accessories[i] < 100000 && accessoryID(character.inventory.loadouts[loadoutID].accessories[i]) != i && character.inventory.loadouts[loadoutID].accessories[i] >= 0)
			{
				character.inventory.item1 = i + 10000;
				character.inventory.item2 = character.inventory.loadouts[loadoutID].accessories[i];
				swapAcc();
				updateBonuses();
			}
		}
		updateInventory();
	}

	public void infinityCubeAll()
	{
		for (int i = 0; i < curSpaces(); i++)
		{
			if (character.inventory.inventory[i].isBoost() && character.inventory.inventory[i].removable)
			{
				infinityCubeBoost(i);
			}
		}
	}

	public void infinityCubeBoost(int itemID)
	{
		if (itemID >= curSpaces() || itemID >= character.inventory.inventory.Count)
		{
			return;
		}
		float num = 100f;
		if (character.adventure.itopod.perkLevel[26] >= 1)
		{
			num = 50f;
		}
		num /= character.wishesController.totalBoostRatioDivider();
		if (character.settings.autoboostRecycledBoosts)
		{
			while (character.inventory.inventory[itemID].id != 0)
			{
				if (character.inventory.inventory[itemID].type == part.specBoost)
				{
					character.inventory.cubePower += character.inventory.inventory[itemID].spec1Cap * character.allItemList.boostBonus() / (num * 2f);
					character.inventory.cubeToughness += character.inventory.inventory[itemID].spec1Cap * character.allItemList.boostBonus() / (num * 2f);
				}
				else if (character.inventory.inventory[itemID].type == part.atkBoost)
				{
					character.inventory.cubePower += character.inventory.inventory[itemID].capAttack * character.allItemList.boostBonus() / num;
				}
				else
				{
					if (character.inventory.inventory[itemID].type != part.defBoost)
					{
						break;
					}
					character.inventory.cubeToughness += character.inventory.inventory[itemID].capDefense * character.allItemList.boostBonus() / num;
				}
				character.inventoryController.degradeBoost(itemID);
			}
			return;
		}
		if (character.inventory.inventory[itemID].type == part.specBoost)
		{
			character.inventory.cubePower += character.inventory.inventory[itemID].spec1Cap * character.allItemList.boostBonus() / (num * 2f);
			character.inventory.cubeToughness += character.inventory.inventory[itemID].spec1Cap * character.allItemList.boostBonus() / (num * 2f);
		}
		else if (character.inventory.inventory[itemID].type == part.atkBoost)
		{
			character.inventory.cubePower += character.inventory.inventory[itemID].capAttack * character.allItemList.boostBonus() / num;
		}
		else
		{
			if (character.inventory.inventory[itemID].type != part.defBoost)
			{
				return;
			}
			character.inventory.cubeToughness += character.inventory.inventory[itemID].capDefense * character.allItemList.boostBonus() / num;
		}
		character.inventoryController.degradeBoost(itemID);
	}

	public void autoDaycare(int id)
	{
		int num = id;
		for (int i = 0; i < character.inventory.daycare.Count; i++)
		{
			if (character.inventory.daycare[i].id == 0)
			{
				num = i + 100000;
				character.inventory.item1 = num;
				character.inventory.item2 = id;
				swapDaycare();
				updateDaycare(i);
				updateItem(id);
				break;
			}
		}
		character.inventory.item1 = 0;
		character.inventory.item2 = 0;
	}

	public bool checkforAccEquipped(int accID)
	{
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.inventory.accs[i].id == accID)
			{
				return true;
			}
		}
		return false;
	}

	public void showMacguffinPanel()
	{
		character.inventoryController.loadoutsController.hidePanel();
		character.inventoryController.daycaresController.hidePanel();
		macguffinPanel.transform.position = macguffinAnchor.transform.position;
		character.inventoryController.macguffinUp = true;
	}

	public void hideMacguffinPanel()
	{
		macguffinPanel.transform.position = new Vector3(-5000f, -5000f);
		character.inventoryController.macguffinUp = false;
	}

	public int macGuffinLevel(int targetID)
	{
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id == targetID)
			{
				return character.inventory.macguffins[i].level;
			}
		}
		return -1;
	}

	public float macGuffinBonusTimeFactor()
	{
		float num = 0f;
		if (character.rebirthTime.totalseconds < 180.0)
		{
			num = 0f;
		}
		else if (character.settings.rebirthDifficulty >= difficulty.sadistic && character.allChallenges.trollChallenge.sadisticCompletions() >= 2)
		{
			num = ((character.rebirthTime.totalseconds <= 1800.0 && character.rebirthTime.totalseconds >= 180.0) ? Mathf.Pow((float)(character.rebirthTime.totalseconds / 1800.0), 2f) : ((!(character.rebirthTime.totalseconds <= 86400.0)) ? (48f * Mathf.Pow((float)(character.rebirthTime.totalseconds / 86400.0), 0.4f)) : Mathf.Pow((float)(character.rebirthTime.totalseconds / 1800.0), 1f)));
			if (num > 104.86f)
			{
				num = 104.86f;
			}
		}
		else if (character.rebirthTime.totalseconds <= 1800.0 && character.rebirthTime.totalseconds >= 180.0)
		{
			num = Mathf.Pow((float)(character.rebirthTime.totalseconds / 1800.0), 2f);
			if (num > 20f)
			{
				num = 20f;
			}
		}
		else
		{
			num = Mathf.Pow((float)(character.rebirthTime.totalseconds / 1800.0), 0.5f);
			if (num > 20f)
			{
				num = 20f;
			}
		}
		if (character.arbitrary.macGuffinBooster1Time.totalseconds > 0.0 || character.arbitrary.macGuffinBooster1InUse)
		{
			num *= character.allArbitrary.potionModifier();
		}
		return num;
	}

	public float energyPowerBonusPerRebirth()
	{
		long num = macGuffinLevel(198) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float energyPowerBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyPowerBonus()
	{
		float num = energyPowerBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[0] += num;
	}

	public float energyCapBonusPerRebirth()
	{
		long num = macGuffinLevel(199) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float energyCapBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyCapBonus()
	{
		float num = energyCapBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[1] += num;
	}

	public float magicPowerBonusPerRebirth()
	{
		long num = macGuffinLevel(200) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float magicPowerBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applymagicPowerBonus()
	{
		float num = magicPowerBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[2] += num;
	}

	public float magicCapBonusPerRebirth()
	{
		long num = macGuffinLevel(201) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float magicCapBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applymagicCapBonus()
	{
		float num = magicCapBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[3] += num;
	}

	public float energyNGUBonusPerRebirth()
	{
		long num = macGuffinLevel(202) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float energyNGUBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyNGUBonus()
	{
		float num = energyNGUBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[4] += num;
	}

	public float magicNGUBonusPerRebirth()
	{
		long num = macGuffinLevel(203) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float magicNGUBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyMagicNGUBonus()
	{
		float num = magicNGUBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[5] += num;
	}

	public float energyBarBonusPerRebirth()
	{
		long num = macGuffinLevel(204) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float energyBarBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyBarBonus()
	{
		float num = energyBarBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[6] += num;
	}

	public float magicBarBonusPerRebirth()
	{
		long num = macGuffinLevel(205) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float magicBarBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyMagicBarBonus()
	{
		float num = magicBarBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[7] += num;
	}

	public float energyBeardBonusPerRebirth()
	{
		long num = macGuffinLevel(206) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float energyBeardBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyBeardBonus()
	{
		float num = energyBeardBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[8] += num;
	}

	public float magicBeardBonusPerRebirth()
	{
		long num = macGuffinLevel(207) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float magicBeardBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyMagicBeardBonus()
	{
		float num = magicBeardBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[9] += num;
	}

	public float dropChanceBonusPerRebirth()
	{
		long num = macGuffinLevel(208) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float dropChanceBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyDropChanceBonus()
	{
		float num = dropChanceBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[10] += num;
	}

	public float goldBonusPerRebirth()
	{
		long num = macGuffinLevel(209) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 5E-05f * macGuffinBonusTimeFactor();
	}

	public float goldBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 5E-05f * macGuffinBonusTimeFactor();
	}

	public void applyGoldBonus()
	{
		float num = goldBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[11] += num;
	}

	public float augSpeedBonusPerRebirth()
	{
		long num = macGuffinLevel(210) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float augSpeedBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyAugSpeedBonus()
	{
		float num = augSpeedBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[12] += num;
	}

	public float powerBonusPerRebirth()
	{
		long num = macGuffinLevel(228) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 0.0001f * macGuffinBonusTimeFactor();
	}

	public float powerBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		return (float)num * 0.0001f * macGuffinBonusTimeFactor();
	}

	public void applyPowerBonus()
	{
		float num = powerBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[13] += num;
	}

	public float energyWandoosBonusPerRebirth()
	{
		long num = macGuffinLevel(211) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 2E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 2E-05f * macGuffinBonusTimeFactor();
	}

	public float energyWandoosBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 2E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 2E-05f * macGuffinBonusTimeFactor();
	}

	public void applyEnergyWandoosBonus()
	{
		float num = energyWandoosBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[15] += num;
	}

	public float magicWandoosBonusPerRebirth()
	{
		long num = macGuffinLevel(250) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 2E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 2E-05f * macGuffinBonusTimeFactor();
	}

	public float magicWandoosBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 2E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 2E-05f * macGuffinBonusTimeFactor();
	}

	public void applyMagicWandoosBonus()
	{
		float num = magicWandoosBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[16] += num;
	}

	public float numberBonusPerRebirth()
	{
		long num = macGuffinLevel(289) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 5E-05f * macGuffinBonusTimeFactor();
	}

	public float numberBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.25f) * 31.63f * 5E-05f * macGuffinBonusTimeFactor();
	}

	public void applyNumberBonus()
	{
		float num = numberBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[17] += num;
	}

	public float bloodBonusPerRebirth()
	{
		long num = macGuffinLevel(290) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 3E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 3E-05f * macGuffinBonusTimeFactor();
	}

	public float bloodBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 3E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 3E-05f * macGuffinBonusTimeFactor();
	}

	public void applyBloodBonus()
	{
		float num = bloodBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[18] += num;
	}

	public float adventureBonusPerRebirth()
	{
		long num = macGuffinLevel(291) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public float adventureBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 1E-05f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 1E-05f * macGuffinBonusTimeFactor();
	}

	public void applyAdventureBonus()
	{
		float num = adventureBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[19] += num;
	}

	public float res3PowerBonusPerRebirth()
	{
		long num = macGuffinLevel(298) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public float res3PowerBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.3f) * 25.12f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public void applyres3PowerBonus()
	{
		float num = res3PowerBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[20] += num;
	}

	public float res3CapBonusPerRebirth()
	{
		long num = macGuffinLevel(299) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public float res3CapBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public void applyres3CapBonus()
	{
		float num = res3CapBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[21] += num;
	}

	public float res3BarBonusPerRebirth()
	{
		long num = macGuffinLevel(300) + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public float res3BarBonusPerRebirth(Equipment item)
	{
		long num = item.level + 1;
		if (num <= 0)
		{
			return 0f;
		}
		if (num <= 100)
		{
			return (float)num * 5E-06f * macGuffinBonusTimeFactor();
		}
		return Mathf.Pow(num, 0.2f) * 39.81f * 5E-06f * macGuffinBonusTimeFactor();
	}

	public void applyRes3BarBonus()
	{
		float num = res3BarBonusPerRebirth();
		if (num < 0f)
		{
			num = 0f;
		}
		character.inventory.macguffinBonuses[22] += num;
	}

	public void updateMacguffinText()
	{
		macguffinText.text = "";
		for (int i = 0; i < character.inventory.macguffinBonuses.Count; i++)
		{
			switch (i)
			{
			case 20:
				if (character.inventory.macguffinBonuses[i] > 1f && character.inventory.macguffinBonuses[i] < 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Power: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0.###") + " %</b>\n";
				}
				else if (character.inventory.macguffinBonuses[i] > 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Power: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0") + " %</b>\n";
				}
				break;
			case 21:
				if (character.inventory.macguffinBonuses[i] > 1f && character.inventory.macguffinBonuses[i] < 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Cap: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0.###") + " %</b>\n";
				}
				else if (character.inventory.macguffinBonuses[i] > 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Cap: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0") + " %</b>\n";
				}
				break;
			case 22:
				if (character.inventory.macguffinBonuses[i] > 1f && character.inventory.macguffinBonuses[i] < 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Bar: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0.###") + " %</b>\n";
				}
				else if (character.inventory.macguffinBonuses[i] > 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + character.res3.res3Name + " Bar: " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0") + " %</b>\n";
				}
				break;
			default:
				if (character.inventory.macguffinBonuses[i] > 1f && character.inventory.macguffinBonuses[i] < 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + macguffinBonuses[i] + ": " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0.###") + " %</b>\n";
				}
				else if (character.inventory.macguffinBonuses[i] > 100f)
				{
					Text text = macguffinText;
					text.text = text.text + "<b>" + macguffinBonuses[i] + ": " + (character.inventory.macguffinBonuses[i] * 100f).ToString("###,##0") + " %</b>\n";
				}
				break;
			}
		}
	}

	public void applyAllMacguffinBonuses()
	{
		applyEnergyPowerBonus();
		applymagicPowerBonus();
		applyEnergyCapBonus();
		applymagicCapBonus();
		applyEnergyNGUBonus();
		applyMagicNGUBonus();
		applyEnergyBarBonus();
		applyMagicBarBonus();
		applyEnergyBeardBonus();
		applyMagicBeardBonus();
		applyDropChanceBonus();
		applyGoldBonus();
		applyAugSpeedBonus();
		applyPowerBonus();
		applyEnergyWandoosBonus();
		applyMagicWandoosBonus();
		applyNumberBonus();
		applyBloodBonus();
		applyAdventureBonus();
		applyres3PowerBonus();
		applyres3CapBonus();
		applyRes3BarBonus();
	}

	public void levelRandomMacguffin(int levelsToAdd)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id != 0 && character.inventory.macguffins[i].isMacGuffin())
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			tooltip.showOverrideTooltip("Your spell fizzled and did nothing - you had no MacGuffin equipped!!", 1.5f);
			character.bloodMagicController.spells.lastMacguffin1 = "Last Spell Result: Your spell fizzled and did nothing - you had no MacGuffin equipped!!";
			return;
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		int num = list[index];
		if (num < 0 || num >= character.inventory.macguffinBonuses.Count || character.inventory.macguffins[num].isMacGuffin())
		{
			character.inventory.macguffins[num].level += levelsToAdd;
			tooltip.showOverrideTooltip("Your " + itemInfo.itemName[character.inventory.macguffins[num].id] + " has gained <b>" + levelsToAdd + "</b> level(s)!", 1.5f);
			character.bloodMagicController.spells.lastMacguffin1 = "Last Spell Result: Your " + itemInfo.itemName[character.inventory.macguffins[num].id] + " gained <b>" + levelsToAdd + "</b> level(s)!";
			if (character.inventory.macguffins[num].level >= 100)
			{
				character.allItemList.markItemAsMaxxed(character.inventory.macguffins[num].id);
			}
			character.inventoryController.updateAllMacguffins();
		}
	}

	public void levelFirstMacguffin(int levelsToAdd)
	{
		int num = 0;
		if (!character.inventory.macguffins[num].isMacGuffin())
		{
			tooltip.showOverrideTooltip("Your spell fizzled and did nothing - you had no MacGuffin equipped in the first slot!!", 1.5f);
			character.bloodMagicController.spells.lastMacguffin1 = "Last Spell Result: Your spell fizzled and did nothing - you had no MacGuffin equipped!!";
		}
		else if (num >= 0 && num < character.inventory.macguffinBonuses.Count && character.inventory.macguffins[num].isMacGuffin())
		{
			character.inventory.macguffins[num].level += levelsToAdd;
			tooltip.showOverrideTooltip("Your " + itemInfo.itemName[character.inventory.macguffins[num].id] + " has gained <b>" + levelsToAdd + "</b> level(s)!", 1.5f);
			character.bloodMagicController.spells.lastMacguffin1 = "Last Spell Result: Your " + itemInfo.itemName[character.inventory.macguffins[num].id] + " gained <b>" + levelsToAdd + "</b> level(s)!";
			if (character.inventory.macguffins[num].level >= 100)
			{
				character.allItemList.markItemAsMaxxed(character.inventory.macguffins[num].id);
			}
			character.inventoryController.updateAllMacguffins();
		}
	}

	public int levelRandomMacguffinFruit(int levelsToAdd)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id != 0 && character.inventory.macguffins[i].isMacGuffin())
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return -1;
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		int num = list[index];
		if (num >= 0 && num < character.inventory.macguffinBonuses.Count && character.inventory.macguffins[num].isMacGuffin())
		{
			character.inventory.macguffins[num].level += levelsToAdd;
			if (character.inventory.macguffins[num].level >= 100)
			{
				character.allItemList.markItemAsMaxxed(character.inventory.macguffins[num].id);
			}
			character.inventoryController.updateAllMacguffins();
			return num;
		}
		return -1;
	}

	public int levelFirstMacguffinFruit(int levelsToAdd)
	{
		int num = 0;
		if (num >= 0 && num < character.inventory.macguffinBonuses.Count && character.inventory.macguffins[num].isMacGuffin())
		{
			character.inventory.macguffins[num].level += levelsToAdd;
			if (character.inventory.macguffins[num].level >= 100)
			{
				character.allItemList.markItemAsMaxxed(character.inventory.macguffins[num].id);
			}
			character.inventoryController.updateAllMacguffins();
			return num;
		}
		return -1;
	}

	public void levelAllMacguffins(int levelsToAdd)
	{
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id != 0 && character.inventory.macguffins[i].isMacGuffin())
			{
				character.inventory.macguffins[i].level += levelsToAdd;
				if (character.inventory.macguffins[i].level >= 100)
				{
					character.allItemList.markItemAsMaxxed(character.inventory.macguffins[i].id);
				}
			}
		}
		tooltip.showOverrideTooltip("All of your equipped MacGuffins have gained <b>" + levelsToAdd + "</b> level(s)! If you had none equipped that's your own damn fault. 'Can't go around being your MacGuffin Mommy.", 1.5f);
		character.bloodMagicController.spells.lastMacguffin2 = "Last Spell Result: All of your equipped MacGuffins gained <b>" + levelsToAdd + "</b> level(s)!";
		character.inventoryController.updateAllMacguffins();
	}

	public void levelAllMacguffinsFruit(int levelsToAdd)
	{
		for (int i = 0; i < character.inventory.macguffins.Count; i++)
		{
			if (character.inventory.macguffins[i].id != 0 && character.inventory.macguffins[i].isMacGuffin())
			{
				character.inventory.macguffins[i].level += levelsToAdd;
				if (character.inventory.macguffins[i].level >= 100)
				{
					character.allItemList.markItemAsMaxxed(character.inventory.macguffins[i].id);
				}
			}
		}
		character.inventoryController.updateAllMacguffins();
	}

	public void dumpAllIntoQuest(int itemID)
	{
		for (int i = 0; i < character.inventory.inventory.Count; i++)
		{
			if (character.inventory.inventory[i].removable)
			{
				bool flag = false;
				if ((character.adventure.itopod.perkLevel[66] <= 0) ? character.beastQuestController.checkItemConsumed(character.inventory.inventory[i].id) : character.beastQuestController.checkItemConsumed(character.inventory.inventory[i].id, character.inventory.inventory[i].level))
				{
					character.inventory.deleteItem(i);
				}
			}
		}
		updateInventory();
		tooltip.showTooltip("BLOOP! All applicable Quest Items have been deposited!", 2f);
	}

	public bool exileAssembled()
	{
		if (character.inventory.inventory.Count < 24)
		{
			return false;
		}
		if (character.adventure.zone != 1)
		{
			return false;
		}
		if (character.inventory.inventory[0].id == 340 && character.inventory.inventory[1].id == 336 && character.inventory.inventory[2].id == 338 && character.inventory.inventory[12].id == 339 && character.inventory.inventory[14].id == 337)
		{
			return true;
		}
		return false;
	}

	public bool exileSpecialAssembled()
	{
		if (character.inventory.inventory.Count < 24)
		{
			return false;
		}
		if (character.adventure.zone != 1)
		{
			return false;
		}
		if (character.inventory.inventory[0].id == 340 && character.inventory.inventory[1].id == 336 && character.inventory.inventory[2].id == 338 && character.inventory.inventory[12].id == 339 && character.inventory.inventory[13].id == 341 && character.inventory.inventory[14].id == 337)
		{
			return true;
		}
		return false;
	}

	public void attemptToMakeGlop()
	{
		int num = itemInfo.findItemToDelete(367);
		if (num == -1)
		{
			tooltip.showOverrideTooltip("You're missing a Well Done Steak with Ketchup to make the Glop!", 2f);
			return;
		}
		int num2 = itemInfo.findItemToDelete(368);
		if (num2 == -1)
		{
			tooltip.showOverrideTooltip("You're missing a Pickle Ice Cream to make the Glop!", 2f);
			return;
		}
		int num3 = itemInfo.findItemToDelete(369);
		if (num3 == -1)
		{
			tooltip.showOverrideTooltip("You're missing A Can of Surstromming to make the Glop!", 2f);
			return;
		}
		int num4 = itemInfo.findItemToDelete(370);
		if (num4 == -1)
		{
			tooltip.showOverrideTooltip("You're missing A Jar of Marmite to make the Glop!", 2f);
			return;
		}
		int num5 = itemInfo.findItemToDelete(371);
		if (num5 == -1)
		{
			tooltip.showOverrideTooltip("You're missing a Pizza With Pineapple to make the Glop!", 2f);
		}
		else if (num != -1 && num2 != -1 && num3 != -1 && num4 != -1 && num5 != -1)
		{
			character.inventory.deleteItem(num);
			updateItem(num);
			character.inventory.deleteItem(num2);
			updateItem(num2);
			character.inventory.deleteItem(num3);
			updateItem(num3);
			character.inventory.deleteItem(num4);
			updateItem(num4);
			character.inventory.deleteItem(num5);
			updateItem(num5);
			character.itemInfo.makeLoot(372);
			tooltip.showOverrideTooltip("You head back to Spiky Haired Guy's place and borrow a hazmat suit to assemble the Glop. It melts through the plate a bit and spontaneously combusts at least three times in the making, but you now have a weapon to take on IT HUNGERS! Unless you filtered this item, in which case you're an idiot.", 10f);
		}
	}

	public void quickShortcutsTooltip()
	{
		tooltip.showTooltip("<b>Keyboard Shortcuts:\n\nA+Click item: Use all possible boosts on this item.\nD+Click item: Merge all possible copies onto this item.\nCTRL+Click item: Trash/consumes/transforms item based on context.\nSHIFT+Click item: Protect item from trashing or transforming.\nRight Click Item: Quick-equip.</b>");
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void updateTransformToggles()
	{
		if (character.menuID != 4)
		{
			return;
		}
		if (character.challenges.levelChallenge10k.curCompletions < character.allChallenges.level100Challenge.maxCompletions)
		{
			powerToggle.gameObject.SetActive(value: false);
			toughToggle.gameObject.SetActive(value: false);
			specialToggle.gameObject.SetActive(value: false);
			noneToggle.gameObject.SetActive(value: false);
			autoTransformTitleText.gameObject.SetActive(value: false);
			return;
		}
		powerToggle.gameObject.SetActive(value: true);
		toughToggle.gameObject.SetActive(value: true);
		specialToggle.gameObject.SetActive(value: true);
		noneToggle.gameObject.SetActive(value: true);
		autoTransformTitleText.gameObject.SetActive(value: true);
		switch (character.settings.autoTransform)
		{
		case 0:
			powerToggle.interactable = true;
			toughToggle.interactable = true;
			specialToggle.interactable = true;
			noneToggle.interactable = false;
			break;
		case 1:
			powerToggle.interactable = false;
			toughToggle.interactable = true;
			specialToggle.interactable = true;
			noneToggle.interactable = true;
			break;
		case 2:
			powerToggle.interactable = true;
			toughToggle.interactable = false;
			specialToggle.interactable = true;
			noneToggle.interactable = true;
			break;
		case 3:
			powerToggle.interactable = true;
			toughToggle.interactable = true;
			specialToggle.interactable = false;
			noneToggle.interactable = true;
			break;
		default:
			powerToggle.interactable = true;
			toughToggle.interactable = true;
			specialToggle.interactable = true;
			noneToggle.interactable = true;
			break;
		}
	}

	public void selectAutoPowerTransform()
	{
		character.settings.autoTransform = 1;
		updateTransformToggles();
	}

	public void selectAutoToughTransform()
	{
		character.settings.autoTransform = 2;
		updateTransformToggles();
	}

	public void selectAutoSpecialTransform()
	{
		character.settings.autoTransform = 3;
		updateTransformToggles();
	}

	public void selectAutoNoneTransform()
	{
		character.settings.autoTransform = 0;
		updateTransformToggles();
	}

	public void runEndItemChecker()
	{
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			if (character.adventure.itopod.perkLevel[231] >= 1 && character.itemInfo.findIndexWithID(482) == -1)
			{
				character.itemInfo.makeLevelledLoot(482, 100);
			}
			if (character.beastQuest.quirkLevel[176] >= 1 && character.itemInfo.findIndexWithID(486) == -1)
			{
				character.itemInfo.makeLevelledLoot(486, 100);
			}
			if (character.wishes.wishes[203].level >= 1 && character.itemInfo.findIndexWithID(490) == -1)
			{
				character.itemInfo.makeLevelledLoot(490, 100);
			}
			if (character.hacks.hacks[15].level >= 1 && character.itemInfo.findIndexWithID(488) == -1)
			{
				character.itemInfo.makeLevelledLoot(488, 100);
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic && character.highestSadisticBoss >= 300 && character.itemInfo.findIndexWithID(487) == -1)
			{
				character.itemInfo.makeLevelledLoot(487, 100);
			}
		}
	}
}
