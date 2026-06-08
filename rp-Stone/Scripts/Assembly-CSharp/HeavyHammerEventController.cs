using System.Collections.Generic;
using UnityEngine;

public class HeavyHammerEventController : BaseEventController
{
	private float realtime;

	private int abilityKillsRemaining;

	private Character bossTracked;

	private float fatiguePercent;

	private float f_armorReduced;

	private static HeavyHammerEventController instance;

	public static HeavyHammerEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new HeavyHammerEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "heavy_hammer";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[10] { 3, 0, 10, 0, 0, 10, 0, 1, 0, 100000 };
	}

	protected override void IncreaseRarityBonus()
	{
		switch (base.part)
		{
		case 0:
			base.rarityBonus = 3;
			GiveStartingReward();
			break;
		case 1:
			base.rarityBonus = 6;
			break;
		case 2:
			base.rarityBonus = 8;
			break;
		case 3:
			base.rarityBonus = 10;
			break;
		case 4:
			base.rarityBonus = 12;
			break;
		}
		base.part++;
	}

	private void GiveStartingReward()
	{
		if (!EventController.singleton.HasReceivedReward(GetEventId()))
		{
			Item item = Inventory.Singleton.FindBestWeapon("heavy hammer", Weapon.HandType.DoubleHanded);
			if (item == null)
			{
				item = Inventory.Singleton.MakeReward("heavy_hammer", 32);
			}
			else
			{
				Inventory.Singleton.RemoveItem(item);
			}
			item.cosmeticId = "golden";
			item.cosmetic = CosmeticController.singleton.GetCosmeticPrefab("golden");
			item.signature = "HAMMERTIME";
			Inventory.Singleton.AddItem(item);
			Cosmetic cosmetic = CosmeticController.singleton.FindInventoryCosmetic("golden", "heavy_hammer", ItemData.Element.Stone);
			if (cosmetic != null)
			{
				TreasureItem item2 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_gold", null);
				Inventory.Singleton.AddItem(item2);
				SequentialPopupManager.singleton.ScheduleItemFound(item2);
			}
			else
			{
				CosmeticController.Collection collection = CosmeticController.singleton.GetCollection("golden");
				CosmeticController.ItemEntry chosenItemEntry = new CosmeticController.ItemEntry("heavy_hammer", ItemData.Element.Stone);
				cosmetic = CosmeticController.singleton.MakeCosmeticAndAddToInventory(chosenItemEntry, collection);
				cosmetic.targetItem.appliedGroupId = item.GetGroupId();
				SequentialPopupManager.singleton.ScheduleItemFound(cosmetic);
			}
		}
	}

	protected override string GetRewardItemId()
	{
		return "treasure_3";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_hammer_title";
	}

	protected override Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != base.rarityBonus)
		{
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardItemId()) as TreasureItem;
			treasureItem.isShiny = true;
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.id = "sword";
			itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(base.rarityBonus);
			itemInTreasure.rarityBonus = base.rarityBonus;
			itemInTreasure.showTreasureColor = true;
			treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { itemInTreasure };
			rewardItem = treasureItem;
		}
		return rewardItem;
	}

	public override void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem("treasure_3") as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.signature = "HAMMERTIME";
		Data.ItemInTreasure[] collection = TreasureFactory.singleton.MakeShinyItemsInTreasure(base.rarityBonus, 32);
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>(collection);
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("ki_crystal", 1, base.rarityBonus, null);
		list.Add(item);
		collection = list.ToArray();
		treasureItem.itemsInTreasure = collection;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}

	protected override void HandlePartEnded(int partEnded)
	{
		switch (partEnded)
		{
		case 0:
			AnvilScreen.singleton.OnFuse -= ReportItemCrafted;
			break;
		case 1:
			Character.OnCharacterGoingToTakeDamage -= ReportEnemyGoingToTakeDamage_Part1;
			break;
		case 2:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated_Part2;
			Character.OnCharacterDied -= ReportEnemyKilled_Part2;
			break;
		case 3:
			StatModController.OnDebuffAdded -= ReportDebuffAdded_Part3;
			break;
		case 4:
			GameStates.Singleton.abilityActivationHUD.OnActivated -= ReportAbilityActivated_Part4;
			StatModController.OnDebuffAdded -= ReportDebuffAdded_Part4;
			Character.OnArmorGained -= ReportArmorGained_Part4;
			Character.OnCharacterDied -= ReportEnemyKilled_Part4;
			bossTracked = null;
			break;
		}
	}

	protected override void HandlePartStarted(int partStarted)
	{
		switch (partStarted)
		{
		case 0:
			AnvilScreen.singleton.OnFuse += ReportItemCrafted;
			break;
		case 1:
			Character.OnCharacterGoingToTakeDamage += ReportEnemyGoingToTakeDamage_Part1;
			break;
		case 2:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated_Part2;
			Character.OnCharacterDied += ReportEnemyKilled_Part2;
			break;
		case 3:
			StatModController.OnDebuffAdded += ReportDebuffAdded_Part3;
			break;
		case 4:
			GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated_Part4;
			StatModController.OnDebuffAdded += ReportDebuffAdded_Part4;
			Character.OnArmorGained += ReportArmorGained_Part4;
			Character.OnCharacterDied += ReportEnemyKilled_Part4;
			break;
		}
	}

	private void ReportItemCrafted(ItemFactory.Result result)
	{
		if (result.resultingItem.id == "heavy_hammer")
		{
			int num = ItemFactory.GetLevelDisplayIntegerForItem(result.resultingItem) - 1;
			if (num > base.progress)
			{
				ImproveReward(num - base.progress);
			}
		}
	}

	private void ReportEnemyGoingToTakeDamage_Part1(Character c, Damage dmg)
	{
		if (!(c == null) && c.id != null && !(dmg.bullet == null) && !(dmg.bullet.weapon == null) && !(c.Armor <= 0f) && !(dmg.bullet.weapon.id != "heavy_hammer"))
		{
			if (Time.realtimeSinceStartup - realtime < 0.1f)
			{
				ImproveReward();
			}
			else
			{
				realtime = Time.realtimeSinceStartup;
			}
		}
	}

	private void ReportAbilityActivated_Part2(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (provider.GetId() == "hammer")
		{
			abilityKillsRemaining = 3;
		}
	}

	private void ReportEnemyKilled_Part2(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (dmg != null && !(dmg.bullet == null) && !(dmg.bullet.weapon == null) && abilityKillsRemaining > 0 && dmg.bullet.weapon.id == "heavy_hammer" && dmg.bullet.tags.Contains("super"))
		{
			abilityKillsRemaining--;
			if (abilityKillsRemaining == 0)
			{
				ImproveReward();
			}
		}
	}

	private void ReportDebuffAdded_Part3(Character c, DebuffStatMod debuff)
	{
		if (debuff != null && debuff.id == "debuff_armor_fatigue" && c != null && c.HasTag("boss") && (c.armorPerSecond > 0f || c.id == "dysangelos_perfected"))
		{
			ImproveReward();
		}
	}

	private void ReportAbilityActivated_Part4(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (withStonescript && provider.GetId() == "hammer")
		{
			realtime = Time.realtimeSinceStartup;
		}
	}

	private void ReportDebuffAdded_Part4(Character c, DebuffStatMod debuff)
	{
		if (!(Time.realtimeSinceStartup - realtime > 3f) && debuff != null && debuff.id == "debuff_armor_fatigue" && c != null && c.HasTag("boss"))
		{
			bossTracked = c;
			fatiguePercent = 0f;
			f_armorReduced = 0f;
			Weapon weapon = debuff.sourceItem as Weapon;
			if (weapon != null)
			{
				HeavyHammerActivatedAbility component = weapon.GetComponent<HeavyHammerActivatedAbility>();
				fatiguePercent = component.ComputeStatWithId("armor_fatigue_power") / 100f;
			}
			debuff.OnEnded += delegate
			{
				bossTracked = null;
			};
		}
	}

	private void ReportArmorGained_Part4(Character c, float armorAmount)
	{
		if (armorAmount > 0f && c == bossTracked)
		{
			float num = armorAmount / (1f - fatiguePercent) - armorAmount;
			f_armorReduced += num;
			if (f_armorReduced >= 1f)
			{
				int num2 = Mathf.FloorToInt(f_armorReduced);
				f_armorReduced -= num2;
				ImproveReward(num2);
			}
		}
	}

	private void ReportEnemyKilled_Part4(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (bossTracked == c)
		{
			bossTracked = null;
		}
	}
}
