using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
	public int spaces;

	public int item1;

	public int item2;

	public Equipment head;

	public Equipment chest;

	public Equipment legs;

	public Equipment boots;

	public Equipment weapon;

	public Equipment weapon2;

	public Equipment acc1;

	public Equipment acc2;

	public Equipment acc3;

	public Equipment temp;

	public Equipment trash;

	public Equipment[] items = new Equipment[1];

	public Equipment[] accessories = new Equipment[6];

	public UnityEngine.Random.State boostCombineState;

	public List<Equipment> inventory = new List<Equipment>(10);

	public List<Equipment> accs = new List<Equipment>(10);

	public List<Equipment> macguffins = new List<Equipment>(1);

	public List<Equipment> daycare = new List<Equipment>();

	public List<PlayerTime> daycareTimers = new List<PlayerTime>();

	public ItemList itemList;

	public int autoMergeSlot1;

	public PlayerTime mergeTime = new PlayerTime();

	public PlayerTime boostTime = new PlayerTime();

	public List<Loadout> loadouts = new List<Loadout>();

	public float cubePower;

	public float cubeToughness;

	public int selectedGraphic;

	public bool disabled;

	public int kittyArt;

	public List<bool> unlockedKittyArt = new List<bool>();

	public List<float> macguffinBonuses = new List<float>(24);

	public Inventory()
	{
		spaces = 24;
		head = new Equipment();
		chest = new Equipment();
		legs = new Equipment();
		boots = new Equipment();
		weapon = new Equipment();
		weapon2 = new Equipment();
		acc1 = new Equipment();
		acc2 = new Equipment();
		acc3 = new Equipment();
		temp = new Equipment();
		trash = new Equipment();
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new Equipment();
		}
		for (int j = 0; j < accessories.Length; j++)
		{
			accessories[j] = new Equipment();
		}
		item1 = -1;
		item2 = -1;
		itemList = new ItemList();
		autoMergeSlot1 = 0;
		boostCombineState = default(UnityEngine.Random.State);
		while (loadouts.Count < loadoutsSize())
		{
			loadouts.Add(new Loadout());
		}
		for (int k = 0; k < loadouts.Count; k++)
		{
			loadouts[k].loadoutName = "Loadout " + (k + 1);
		}
		while (inventory.Count < 24)
		{
			inventory.Add(new Equipment());
		}
		while (accs.Count < 2)
		{
			accs.Add(new Equipment());
		}
		while (macguffins.Count < 1)
		{
			macguffins.Add(new Equipment());
		}
		while (daycare.Count < 1)
		{
			daycare.Add(new Equipment());
			daycareTimers.Add(new PlayerTime());
		}
		while (macguffinBonuses.Count < 24)
		{
			macguffinBonuses.Add(1f);
		}
		while (unlockedKittyArt.Count < kittyArtSize())
		{
			unlockedKittyArt.Add(item: false);
		}
		cubePower = 0f;
		cubeToughness = 0f;
		disabled = false;
		selectedGraphic = 0;
		kittyArt = 0;
	}

	public int loadoutsSize()
	{
		return 10;
	}

	public int kittyArtSize()
	{
		return 11;
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
		return defenseBonus() * 3f;
	}

	public float adventureHPRegenBonus()
	{
		return defenseBonus() * 0.03f;
	}

	public float attackBonus()
	{
		return weaponAttack() + acc1Attack() + acc2Attack() + acc3Attack() + headAttack() + chestAttack() + legsAttack() + bootsAttack();
	}

	public float defenseBonus()
	{
		return headDefense() + chestDefense() + legsDefense() + bootsDefense() + acc1Defense() + acc2Defense() + acc3Defense() + weaponDefense();
	}

	public float weaponAttack()
	{
		return weapon.curAttack;
	}

	public float weaponDefense()
	{
		return weapon.curDefense;
	}

	public float headDefense()
	{
		return head.curDefense;
	}

	public float chestDefense()
	{
		return chest.curDefense;
	}

	public float legsDefense()
	{
		return legs.curDefense;
	}

	public float bootsDefense()
	{
		return boots.curDefense;
	}

	public float headAttack()
	{
		return head.curAttack;
	}

	public float chestAttack()
	{
		return chest.curAttack;
	}

	public float legsAttack()
	{
		return legs.curAttack;
	}

	public float bootsAttack()
	{
		return boots.curAttack;
	}

	public float acc1Attack()
	{
		return acc1.curAttack;
	}

	public float acc1Defense()
	{
		return acc1.curDefense;
	}

	public float acc2Attack()
	{
		return acc2.curAttack;
	}

	public float acc2Defense()
	{
		return acc2.curDefense;
	}

	public float acc3Attack()
	{
		return acc3.curAttack;
	}

	public float acc3Defense()
	{
		return acc3.curDefense;
	}

	public void swapItems()
	{
		markLoadoutIDSwap(item1, item2);
		temp = inventory[item1];
		inventory[item1] = inventory[item2];
		inventory[item2] = temp;
	}

	public void swapHead()
	{
		markLoadoutIDSwap(-1, item2);
		temp = head;
		head = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostHead()
	{
		return head.boostEquip(inventory[item2]);
	}

	public void swapChest()
	{
		markLoadoutIDSwap(-2, item2);
		temp = chest;
		chest = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostChest()
	{
		return chest.boostEquip(inventory[item2]);
	}

	public void swapLegs()
	{
		markLoadoutIDSwap(-3, item2);
		temp = legs;
		legs = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostLegs()
	{
		return legs.boostEquip(inventory[item2]);
	}

	public void swapBoots()
	{
		markLoadoutIDSwap(-4, item2);
		temp = boots;
		boots = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostBoots()
	{
		return boots.boostEquip(inventory[item2]);
	}

	public void swapWeapon()
	{
		markLoadoutIDSwap(-5, item2);
		temp = weapon;
		weapon = inventory[item2];
		inventory[item2] = temp;
	}

	public void swapWeapon2()
	{
		markLoadoutIDSwap(-6, item2);
		temp = weapon2;
		weapon2 = inventory[item2];
		inventory[item2] = temp;
	}

	public void swapWeapons()
	{
		markLoadoutIDSwap(-5, -6);
		temp = weapon2;
		weapon2 = weapon;
		weapon = temp;
	}

	public bool boostWeapon()
	{
		return weapon.boostEquip(inventory[item2]);
	}

	public void swapAccs(int a, int b)
	{
		if (a < accs.Count && b < accs.Count)
		{
			markLoadoutIDSwap(a + 10000, b + 10000);
			temp = accs[a];
			accs[a] = accs[b];
			accs[b] = temp;
		}
	}

	public void swapAccWithItem(int accessoryIndex, int itemIndex)
	{
		if (accessoryIndex < accs.Count && itemIndex < inventory.Count)
		{
			markLoadoutIDSwap(accessoryIndex + 10000, itemIndex);
			temp = accs[accessoryIndex];
			accs[accessoryIndex] = inventory[itemIndex];
			inventory[itemIndex] = temp;
		}
	}

	public void swapDaycareWithItem(int daycareIndex, int itemIndex, int levelsToAdd)
	{
		if (daycareIndex < daycare.Count && itemIndex < inventory.Count)
		{
			daycare[daycareIndex].level += levelsToAdd;
			if (daycare[daycareIndex].level > 100 && daycare[daycareIndex].type != part.MacGuffin)
			{
				daycare[daycareIndex].level = 100;
			}
			markLoadoutIDSwap(daycareIndex + 100000, itemIndex);
			temp = daycare[daycareIndex];
			daycare[daycareIndex] = inventory[itemIndex];
			inventory[itemIndex] = temp;
		}
	}

	public void swapMacguffinWithItem(int macguffinIndex, int itemIndex)
	{
		if (macguffinIndex < macguffins.Count && itemIndex < inventory.Count)
		{
			temp = macguffins[macguffinIndex];
			macguffins[macguffinIndex] = inventory[itemIndex];
			inventory[itemIndex] = temp;
		}
	}

	public void swapMacguffins(int index1, int index2)
	{
		if (index1 < macguffins.Count && index2 < macguffins.Count)
		{
			temp = macguffins[index1];
			macguffins[index1] = macguffins[index2];
			macguffins[index2] = temp;
		}
	}

	public void swapAcc1()
	{
		temp = acc1;
		acc1 = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostAcc1()
	{
		return acc1.boostEquip(inventory[item2]);
	}

	public void swapAcc2()
	{
		temp = acc2;
		acc2 = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostAcc2()
	{
		return acc2.boostEquip(inventory[item2]);
	}

	public void swapAcc3()
	{
		temp = acc3;
		acc3 = inventory[item2];
		inventory[item2] = temp;
	}

	public bool boostAcc3()
	{
		return acc3.boostEquip(inventory[item2]);
	}

	public void swapAccs12()
	{
		temp = acc1;
		acc1 = acc2;
		acc2 = temp;
	}

	public void swapAccs13()
	{
		temp = acc1;
		acc1 = acc3;
		acc3 = temp;
	}

	public void swapAccs23()
	{
		temp = acc2;
		acc2 = acc3;
		acc3 = temp;
	}

	public void deleteItem(int id)
	{
		inventory[id] = null;
		inventory[id] = new Equipment();
		markLoadoutIDAsDeleted(id);
	}

	public void deleteHead()
	{
		head = null;
		head = new Equipment();
		markLoadoutIDAsDeleted(-1);
	}

	public void deleteChest()
	{
		chest = null;
		chest = new Equipment();
		markLoadoutIDAsDeleted(-2);
	}

	public void deleteLegs()
	{
		legs = null;
		legs = new Equipment();
		markLoadoutIDAsDeleted(-3);
	}

	public void deleteBoots()
	{
		boots = null;
		boots = new Equipment();
		markLoadoutIDAsDeleted(-4);
	}

	public void deleteWeapon()
	{
		weapon = null;
		weapon = new Equipment();
		markLoadoutIDAsDeleted(-5);
	}

	public void deleteWeapon2()
	{
		weapon2 = null;
		weapon2 = new Equipment();
		markLoadoutIDAsDeleted(-6);
	}

	public void deleteAcc1()
	{
		acc1 = null;
		acc1 = new Equipment();
	}

	public void deleteAcc2()
	{
		acc2 = null;
		acc2 = new Equipment();
	}

	public void deleteAcc3()
	{
		acc3 = null;
		acc3 = new Equipment();
	}

	public bool mergeable()
	{
		if (inventory[item1].id == inventory[item2].id && (inventory[item1].type == part.Accessory || inventory[item1].type == part.Head || inventory[item1].type == part.Chest || inventory[item1].type == part.Legs || inventory[item1].type == part.Boots || inventory[item1].type == part.Weapon))
		{
			return true;
		}
		return false;
	}

	public void validateInventory()
	{
		if (spaces < 24)
		{
			spaces = 24;
		}
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].id > 200)
			{
				inventory[i] = new Equipment();
			}
		}
		for (int j = 0; j < inventory.Count; j++)
		{
			if (inventory[j].id > 200)
			{
				inventory[j] = new Equipment();
			}
		}
		if (itemList == null)
		{
			itemList = new ItemList();
		}
		if (head.id > 200)
		{
			head = new Equipment();
		}
		if (chest.id > 200)
		{
			chest = new Equipment();
		}
		if (legs.id > 200)
		{
			legs = new Equipment();
		}
		if (boots.id > 200)
		{
			boots = new Equipment();
		}
		if (weapon.id > 200)
		{
			weapon = new Equipment();
		}
		if (acc1.id > 200)
		{
			acc1 = new Equipment();
		}
		if (acc2.id > 200)
		{
			acc2 = new Equipment();
		}
		if (acc3.id > 200)
		{
			acc3 = new Equipment();
		}
		if (trash.id > 200)
		{
			trash = new Equipment();
		}
		for (int k = 0; k < accs.Count; k++)
		{
			if (accs[k].id > 200)
			{
				accs[k] = new Equipment();
			}
		}
	}

	public void markLoadoutIDAsDeleted(int id)
	{
		for (int i = 0; i < loadouts.Count; i++)
		{
			if (loadouts[i].head == id)
			{
				loadouts[i].head = -1000;
			}
			if (loadouts[i].chest == id)
			{
				loadouts[i].chest = -1000;
			}
			if (loadouts[i].legs == id)
			{
				loadouts[i].legs = -1000;
			}
			if (loadouts[i].boots == id)
			{
				loadouts[i].boots = -1000;
			}
			if (loadouts[i].weapon == id)
			{
				loadouts[i].weapon = -1000;
			}
			if (loadouts[i].weapon2 == id)
			{
				loadouts[i].weapon2 = -1000;
			}
			for (int j = 0; j < loadouts[i].accessories.Count; j++)
			{
				if (loadouts[i].accessories[j] == id)
				{
					loadouts[i].accessories[j] = -1000;
				}
			}
		}
	}

	public void markLoadoutIDSwap(int id1, int id2)
	{
		for (int i = 0; i < loadouts.Count; i++)
		{
			if (loadouts[i].head == id1)
			{
				loadouts[i].head = id2;
			}
			else if (loadouts[i].head == id2)
			{
				loadouts[i].head = id1;
			}
			if (loadouts[i].chest == id1)
			{
				loadouts[i].chest = id2;
			}
			else if (loadouts[i].chest == id2)
			{
				loadouts[i].chest = id1;
			}
			if (loadouts[i].legs == id1)
			{
				loadouts[i].legs = id2;
			}
			else if (loadouts[i].legs == id2)
			{
				loadouts[i].legs = id1;
			}
			if (loadouts[i].boots == id1)
			{
				loadouts[i].boots = id2;
			}
			else if (loadouts[i].boots == id2)
			{
				loadouts[i].boots = id1;
			}
			if (loadouts[i].weapon == id1)
			{
				loadouts[i].weapon = id2;
			}
			else if (loadouts[i].weapon == id2)
			{
				loadouts[i].weapon = id1;
			}
			if (loadouts[i].weapon2 == id1)
			{
				loadouts[i].weapon2 = id2;
			}
			else if (loadouts[i].weapon2 == id2)
			{
				loadouts[i].weapon2 = id1;
			}
			for (int j = 0; j < loadouts[i].accessories.Count; j++)
			{
				if (loadouts[i].accessories[j] == id1)
				{
					loadouts[i].accessories[j] = id2;
				}
				else if (loadouts[i].accessories[j] == id2)
				{
					loadouts[i].accessories[j] = id1;
				}
			}
		}
	}

	public void updateInvSpaces(int spaces)
	{
		while (inventory.Count < spaces)
		{
			inventory.Add(new Equipment());
		}
	}

	public void updateAccSpaces(int spaces)
	{
		while (accs.Count < spaces)
		{
			accs.Add(new Equipment());
		}
	}

	public void updateMacGuffinSpaces(int spaces)
	{
		while (macguffins.Count < spaces)
		{
			macguffins.Add(new Equipment());
		}
	}

	public void updateMacguffinSpaces(int spaces)
	{
		while (macguffins.Count < spaces)
		{
			macguffins.Add(new Equipment());
		}
		while (macguffinBonuses.Count < 24)
		{
			macguffinBonuses.Add(1f);
		}
	}

	public void updateLoadoutAccs(int size)
	{
		for (int i = 0; i < loadouts.Count; i++)
		{
			while (loadouts[i].accessories.Count < size)
			{
				loadouts[i].accessories.Add(-1000);
			}
		}
	}

	public void updateDaycareSpaces(int spaces)
	{
		while (daycare.Count < spaces)
		{
			daycare.Add(new Equipment());
		}
		while (daycareTimers.Count < spaces)
		{
			daycareTimers.Add(new PlayerTime());
		}
	}
}
