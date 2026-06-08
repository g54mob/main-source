using System;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArmActivationState : SuperAbilityActivationState
{
	[Serializable]
	public class RewardSet
	{
		public int resource;

		public int basicItem;

		public int complexItem;

		public int runestone;

		public int runestoneItem;

		public int runestone2;

		public int runestone3;

		public int enchant;

		public int enchant2;
	}

	public DebuffStatMod pickPocketPrefab;

	public RewardSet[] allRewardSets;

	public AsciiString resourceIcon;

	private AsciiSprite itemIcon;

	public int iconOffsetX = 3;

	public int iconOffsetY = -7;

	public int drawBeginTime = 27;

	public int drawEndTime = 37;

	private Item itemToReportStolen;

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (dmg.bullet != null && dmg.Owner != null && dmg.Owner == base.sourceItem.Owner && dmg.bullet.weapon == base.sourceItem && base.currentState == State.Starting)
		{
			dmg.amount /= 2;
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (!(dmg.bullet != null) || !(dmg.Owner != null) || !(dmg.Owner == base.sourceItem.Owner) || !(dmg.bullet.weapon == base.sourceItem) || dmg.bullet.tags.Contains("pick_pocket"))
		{
			return;
		}
		dmg.bullet.tags.Add("pick_pocket");
		dmg.tags.Add("pick_pocket");
		if (base.currentState == State.Starting)
		{
			dmg.bullet.tags.Add("activated_ability");
			dmg.tags.Add("activated_ability");
			return;
		}
		Hero hero = GameStates.Singleton.hero;
		if (hero.Alive)
		{
			DebuffStatMod debuffStatMod = UnityEngine.Object.Instantiate(pickPocketPrefab);
			debuffStatMod.sourceItem = base.sourceItem;
			debuffStatMod.character = hero;
			ItemData.Ability ability = FindAbilityWithId("pick_pocket_buff");
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.statData.type = ability.stat.type;
			debuffStatMod.statData.prefab = ability.stat.prefab;
			debuffStatMod.statData.baseValue = ComputePickPocketStatBonus();
			debuffStatMod.ticDuration = ComputePickPocketDuration();
			debuffStatMod.maxStack = ComputePickPocketStackSize();
			debuffStatMod.Init();
			int num = 0;
			List<StatModifier> pickPocketBuffStack = GetPickPocketBuffStack();
			if (pickPocketBuffStack != null)
			{
				num = pickPocketBuffStack.Count;
			}
			hero.AddStatModifier(debuffStatMod);
			if (pickPocketBuffStack == null || pickPocketBuffStack.Count > num)
			{
				SkeletonArmGoals.singleton.ReportPickPocketGained();
			}
		}
	}

	private int GetPickPocketCount()
	{
		List<StatModifier> pickPocketBuffStack = GetPickPocketBuffStack();
		if (pickPocketBuffStack != null && pickPocketBuffStack.Count > 0)
		{
			if (pickPocketBuffStack[0].sourceItem != base.sourceItem)
			{
				return 0;
			}
			return pickPocketBuffStack.Count;
		}
		return 0;
	}

	private List<StatModifier> GetPickPocketBuffStack()
	{
		StatModController statModController = GameStates.Singleton.hero.statModController;
		if (statModController == null)
		{
			return null;
		}
		if (statModController.debuffs == null)
		{
			return null;
		}
		List<List<StatModifier>> debuffs = statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == "pick_pocket")
			{
				return list;
			}
		}
		return null;
	}

	private int ComputePickPocketStatBonus()
	{
		return Mathf.FloorToInt(ComputeStatWithId("pick_pocket_buff"));
	}

	private int ComputePickPocketDuration()
	{
		return Mathf.FloorToInt(ComputeStatWithId("pick_pocket_duration")) * 30;
	}

	private int ComputePickPocketStackSize()
	{
		return Mathf.FloorToInt(ComputeStatWithId("pick_pocket_max_stack"));
	}

	protected override void SetState(State newState)
	{
		itemToReportStolen = null;
		if (newState == State.Starting)
		{
			SelectReward();
		}
		else if (newState == State.Done)
		{
			RemovePickPocketBuffs();
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != State.Starting)
		{
			return;
		}
		Weapon weapon = base.sourceItem as Weapon;
		if (weapon != null)
		{
			weapon.UpdateTic();
		}
		if (stateElapsedTics == 1)
		{
			SfxController.singleton.Play("skeleton_arm_pickpocket");
		}
		else if (stateElapsedTics == 25)
		{
			if (itemToReportStolen != null)
			{
				SkeletonArmGoals.singleton.ReportItemStolen(itemToReportStolen);
				itemToReportStolen = null;
			}
		}
		else if (stateElapsedTics == 45)
		{
			SetState(State.Done);
		}
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
		if (!(base.sourceItem.Owner == null) && base.currentState == State.Starting && stateElapsedTics >= drawBeginTime && stateElapsedTics <= drawEndTime)
		{
			int offsetX = base.sourceItem.Owner.lastDrawX + iconOffsetX;
			int offsetY = base.sourceItem.Owner.lastDrawY + iconOffsetY;
			if (itemIcon != null)
			{
				itemIcon.Draw(r, offsetX, offsetY);
			}
			else
			{
				resourceIcon.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void RemovePickPocketBuffs()
	{
		StatModController statModController = GameStates.Singleton.hero.statModController;
		if (statModController == null || statModController.debuffs == null)
		{
			return;
		}
		List<List<StatModifier>> debuffs = statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == "pick_pocket" && !(list[0].sourceItem != base.sourceItem))
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					list[num].End();
				}
			}
		}
	}

	private void SelectReward()
	{
		Weapon weapon = base.sourceItem as Weapon;
		if (weapon == null || weapon.Owner == null)
		{
			return;
		}
		resourceIcon.Clear();
		itemIcon = null;
		HeroAI component = weapon.Owner.GetComponent<HeroAI>();
		if (component == null || component.targetEnemy == null)
		{
			RewardResource(Data.Resource.Stone);
			return;
		}
		ItemData.Element element = component.targetEnemy.GetElement();
		if (element != ItemData.Element.Stone && !ProgressFlags.GetFlag("skeleton_arm_ftue"))
		{
			ProgressFlags.SetFlag("skeleton_arm_ftue");
			RewardRunestone(element, 1);
			return;
		}
		int pickPocketCount = GetPickPocketCount();
		RewardSet rewardSet = allRewardSets[pickPocketCount - 1];
		int num = UnityEngine.Random.Range(0, 100);
		if (num >= rewardSet.resource)
		{
			num -= rewardSet.resource;
			if (num >= rewardSet.basicItem)
			{
				num -= rewardSet.basicItem;
				if (num >= rewardSet.complexItem)
				{
					num -= rewardSet.complexItem;
					if (num >= rewardSet.runestoneItem)
					{
						num -= rewardSet.runestoneItem;
						if (num >= rewardSet.runestone)
						{
							num -= rewardSet.runestone;
						}
						else
						{
							if (element != ItemData.Element.Stone)
							{
								RewardRunestone(element, 1);
								return;
							}
							RewardWand(2);
						}
						if (num >= rewardSet.runestone2)
						{
							num -= rewardSet.runestone2;
						}
						else
						{
							if (element != ItemData.Element.Stone)
							{
								RewardRunestone(element, 2);
								return;
							}
							RewardWand(3);
						}
						if (num >= rewardSet.runestone3)
						{
							num -= rewardSet.runestone3;
						}
						else
						{
							if (element != ItemData.Element.Stone)
							{
								RewardRunestone(element, 3);
								return;
							}
							RewardWand(5);
						}
						if (num >= rewardSet.enchant)
						{
							num -= rewardSet.enchant;
							if (num >= rewardSet.enchant2)
							{
								num -= rewardSet.enchant2;
							}
							else
							{
								RewardEnchantment(2);
							}
						}
						else
						{
							RewardEnchantment(1);
						}
					}
					else
					{
						RewardRunestoneItem(element);
					}
				}
				else
				{
					RewardComplexItem();
				}
			}
			else
			{
				RewardBasicItem();
			}
		}
		else
		{
			switch (element)
			{
			case ItemData.Element.Poison:
			case ItemData.Element.AEther:
				RewardResource(Data.Resource.Tar);
				break;
			case ItemData.Element.Stone:
			case ItemData.Element.Vigor:
				RewardResource(Data.Resource.Wood);
				break;
			case ItemData.Element.Fire:
				RewardResource(Data.Resource.Bronze);
				break;
			default:
				RewardResource(Data.Resource.Stone);
				break;
			}
		}
	}

	private void RewardResource(Data.Resource type)
	{
		InventoryResources.singleton.AddResourceOfType(type, 1L);
		switch (type)
		{
		case Data.Resource.Stone:
			resourceIcon.SetValue("o");
			break;
		case Data.Resource.Wood:
			resourceIcon.SetValue("_/`");
			break;
		case Data.Resource.Tar:
			resourceIcon.SetValue("≈");
			break;
		case Data.Resource.Bronze:
			resourceIcon.SetValue(":.");
			break;
		}
		string resourceCostFormatted = MoneyUI.GetResourceCostFormatted(type, 1);
		ShowFlyupText(resourceCostFormatted);
	}

	private void RewardBasicItem()
	{
		string itemId = RandomID(new string[5] { "sword", "shield", "crossbow", "quarterstaff", "wand" });
		RewardItem(itemId);
	}

	private void RewardComplexItem()
	{
		string itemId = RandomID(new string[8] { "socketed_sword", "socketed_shield", "socketed_staff", "hammer", "bardiche", "long_sword", "dashing_shield", "heavy_crossbow" });
		RewardItem(itemId);
	}

	private void RewardWand(int count)
	{
		string itemId = "wand";
		RewardItem(itemId, count);
	}

	private void RewardRunestoneItem(ItemData.Element element)
	{
		string itemId = RandomID(new string[7] { "wand", "socketed_sword", "socketed_shield", "socketed_staff", "socketed_hammer", "socketed_long_sword", "socketed_crossbow" });
		RewardItem(itemId, element);
	}

	private void RewardRunestone(ItemData.Element element, int count)
	{
		string itemId = "runestone";
		RewardItem(itemId, element, count);
	}

	private void RewardEnchantment(int rarityBonus)
	{
		string itemId = "enchantment";
		ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(rarityBonus));
		rarity.selectedStatSeed = UnityEngine.Random.Range(0, 999999);
		rarity.levelBonus = rarityBonus;
		rarity.quality = ItemData.Rarity.GetQualityThreshold(rarityBonus);
		rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(rarityBonus);
		Item item = ItemFactory.singleton.MakeItemWithLevel(itemId, 1, rarity);
		Inventory.Singleton.AddItem(item);
		itemIcon = item.GetIcon();
		ShowFlyupText(item.GetName());
	}

	private void RewardItem(string itemId, int count = 1)
	{
		Item item = Inventory.Singleton.MakeReward(itemId, 1);
		Inventory.Singleton.AddItem(item, count);
		itemIcon = item.GetIcon();
		string text = item.GetName();
		if (count > 1)
		{
			text = text + " x" + count;
		}
		ShowFlyupText(text);
	}

	private void RewardItem(string itemId, ItemData.Element element, int count = 1)
	{
		Item item = Inventory.Singleton.MakeReward(itemId, 1, element, UnityEngine.Random.Range(0, 999999));
		item = Inventory.Singleton.AddItem(item, count);
		itemIcon = item.GetIcon();
		string text = item.GetName();
		if (count > 1)
		{
			text = text + " x" + count;
		}
		ShowFlyupText(text);
		itemToReportStolen = item;
	}

	private string RandomID(string[] possibleIDs)
	{
		int num = UnityEngine.Random.Range(0, possibleIDs.Length);
		return possibleIDs[num];
	}

	private void ShowFlyupText(string rewardStr)
	{
		FloatingText floatingText = GameStates.Singleton.hero.ShowFloatingText(rewardStr, 30);
		floatingText.PositionX += iconOffsetX;
		floatingText.PositionY += iconOffsetY + 2;
		floatingText.Message.color = ColorConstants.white;
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}
}
