public class ItemAbilityPatch
{
	private const string SWORD_LIFESTEAL_v070 = "PATCH_SWORD_LIFESTEAL_v070";

	private const string ARMOR_v093 = "PATCH_ARMOR_v093";

	public const string ELEMENT_DAMAGE_v2100 = "PATCH_ELEMENT_DAMAGE_v2100";

	public const string HAMMERS_v2110 = "PATCH_HAMMERS_v2110";

	public const string LONG_SWORDS_v2140 = "PATCH_LONG_SWORDS_v2140";

	public static void AfterProgressLoaded()
	{
		ProgressFlags.SetFlag("PATCH_ELEMENT_DAMAGE_v2100");
		ProgressFlags.SetFlag("PATCH_HAMMERS_v2110");
		ProgressFlags.SetFlag("PATCH_LONG_SWORDS_v2140");
	}

	public static void ApplyPatches(Item item)
	{
		if (item.element != ItemData.Element.Stone && NeedsPatch("PATCH_ELEMENT_DAMAGE_v2100"))
		{
			if (item.id == "socketed_crossbow")
			{
				int num = 0;
				while (item.extraAbilityIds != null && num < item.extraAbilityIds.Count)
				{
					if (item.extraAbilityIds[num] == "element_damage_wand")
					{
						item.extraAbilityIds[num] = "element_damage_crossbow";
					}
					else if (item.extraAbilityIds[num] == "element_damage_wand_2")
					{
						item.extraAbilityIds[num] = "element_damage_crossbow_2";
					}
					num++;
				}
			}
			else if (item.id == "runestone")
			{
				int num2 = 0;
				while (item.extraAbilityIds != null && num2 < item.extraAbilityIds.Count)
				{
					if (item.extraAbilityIds[num2] == "element_damage_wand_2")
					{
						item.extraAbilityIds[num2] = "element_damage_runestone";
					}
					num2++;
				}
			}
			else if (item.id == "socketed_staff")
			{
				int num3 = 0;
				while (item.extraAbilityIds != null && num3 < item.extraAbilityIds.Count)
				{
					if (item.extraAbilityIds[num3] == "element_damage_sword")
					{
						item.extraAbilityIds[num3] = "element_damage_staff";
					}
					else if (item.extraAbilityIds[num3] == "element_damage_sword_2")
					{
						item.extraAbilityIds[num3] = "element_damage_staff_2";
					}
					num3++;
				}
			}
		}
		if (item.element != ItemData.Element.Stone && NeedsPatch("PATCH_HAMMERS_v2110") && item.id == "socketed_hammer")
		{
			int num4 = 0;
			while (item.extraAbilityIds != null && num4 < item.extraAbilityIds.Count)
			{
				if (item.extraAbilityIds[num4] == "element_damage_sword")
				{
					item.extraAbilityIds[num4] = "element_damage_hammer";
				}
				else if (item.extraAbilityIds[num4] == "element_damage_sword_2")
				{
					item.extraAbilityIds[num4] = "element_damage_hammer_2";
				}
				num4++;
			}
		}
		if (item.element != ItemData.Element.Stone && NeedsPatch("PATCH_LONG_SWORDS_v2140") && item.id == "socketed_long_sword")
		{
			int num5 = 0;
			while (item.extraAbilityIds != null && num5 < item.extraAbilityIds.Count)
			{
				if (item.extraAbilityIds[num5] == "element_damage_sword")
				{
					item.extraAbilityIds[num5] = "element_damage_long_sword";
				}
				else if (item.extraAbilityIds[num5] == "element_damage_sword_2")
				{
					item.extraAbilityIds[num5] = "element_damage_long_sword_2";
				}
				num5++;
			}
		}
		if (item.element == ItemData.Element.Poison && Features.PREV_VERSION < new Version(3, 15, 0))
		{
			int num6 = 0;
			while (item.extraAbilityIds != null && num6 < item.extraAbilityIds.Count)
			{
				if (item.extraAbilityIds[num6] == "damage_debuff_whenhit")
				{
					item.extraAbilityIds[num6] = "damage_buff_whenhit";
				}
				num6++;
			}
		}
		if (item.element != ItemData.Element.Stone && Features.PREV_VERSION < new Version(3, 16, 0) && item.id.EndsWith("hammer"))
		{
			for (int i = 0; item.extraAbilityIds != null && i < item.extraAbilityIds.Count; i++)
			{
				switch (item.extraAbilityIds[i])
				{
				case "element_armor_onenemy_2":
					break;
				case "damage_buff_whenhit":
					item.extraAbilityIds[i] = "damage_debuff_onhit";
					continue;
				case "insta_kill_whenhit":
					item.extraAbilityIds[i] = "insta_kill_melee_onhit";
					continue;
				case "dot_whenhit":
					item.extraAbilityIds[i] = "dot_onhit";
					continue;
				case "chill_onenemy":
					item.extraAbilityIds[i] = "chill_onhit";
					continue;
				default:
					continue;
				}
				item.extraAbilityIds[i] = "element_armor_onenemy";
				if (item.element == ItemData.Element.Poison)
				{
					item.extraAbilityIds.Add("damage_debuff_onhit");
				}
				else if (item.element == ItemData.Element.Vigor)
				{
					item.extraAbilityIds.Add("chance_to_lifesteal_2");
				}
				else if (item.element == ItemData.Element.AEther)
				{
					item.extraAbilityIds.Add("insta_kill_melee_onhit");
				}
				else if (item.element == ItemData.Element.Fire)
				{
					item.extraAbilityIds.Add("dot_onhit");
				}
				else if (item.element == ItemData.Element.Ice)
				{
					item.extraAbilityIds.Add("chill_onhit");
				}
				break;
			}
		}
		if (item.level > 1 && item.id == "ki_crystal")
		{
			item.level = 1;
		}
		if (item.level > 3 && item.id == "star_stone")
		{
			item.level = 3;
		}
		if (item.element != ItemData.Element.Stone && !item.isLost && Features.PREV_VERSION < new Version(3, 37, 4) && item.extraAbilityIds == null && item.id != "runestone")
		{
			item.element = ItemData.Element.Stone;
		}
		if (item.element == ItemData.Element.Stone && item.id == "runestone")
		{
			item.element = ItemData.Element.Vigor;
		}
		if (item.isNamed && Features.PREV_VERSION < new Version(3, 46, 3))
		{
			item.nameTag = item.nameTag.Replace('"', '\'').Replace('“', '\'').Replace('”', '\'');
		}
		if (item.isLost && item.level < 6)
		{
			item.level = ItemFactory.CalculateItemLevelFromDisplayLevel(6f);
			while (ItemFactory.GetLevelDisplayIntegerForItem(item) < 6)
			{
				item.level *= 2;
			}
		}
		if (item.signature == null)
		{
			return;
		}
		if (item.level < 1)
		{
			string groupId = item.GetGroupId();
			ItemFactory.SetItemLevelByDisplayLevel(item, 1f);
			Weapon weapon = item as Weapon;
			if (weapon != null)
			{
				UtilityBeltKeyShortcuts.singleton.ReportCraft(item.id, groupId, weapon.handType, weapon);
			}
		}
		else if (!IsPowerOfTwo(item.level))
		{
			string groupId2 = item.GetGroupId();
			ItemFactory.SetItemLevelByDisplayLevel(item, 11f);
			Weapon weapon2 = item as Weapon;
			if (weapon2 != null)
			{
				UtilityBeltKeyShortcuts.singleton.ReportCraft(item.id, groupId2, weapon2.handType, weapon2);
			}
		}
	}

	private static bool IsPowerOfTwo(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		return (n & (n - 1)) == 0;
	}

	public static bool NeedsPatch(string patchId)
	{
		return !ProgressFlags.GetFlag(patchId);
	}
}
