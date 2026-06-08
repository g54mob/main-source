using System;
using UnityEngine;

public class ItemData
{
	public enum Element
	{
		Stone = 0,
		Ice = 1,
		Fire = 2,
		Poison = 3,
		Vigor = 4,
		AEther = 5,
		Air = 6
	}

	public class Rarity
	{
		public enum Type
		{
			Common = 0,
			Uncommon = 1,
			Rare = 2,
			Heroic = 3,
			Epic = 4,
			Legendary = 5,
			Transcendent = 6
		}

		private static int[] qualityThresholdPerBonus = new int[21]
		{
			1, 4, 7, 19, 31, 43, 100, 157, 214, 271,
			571, 871, 1171, 1471, 1771, 3484, 5197, 6910, 8623, 10336,
			12049
		};

		public Type type;

		public int levelBonus;

		public bool isPerfect;

		public int quality;

		public int selectedStatSeed;

		public int selectedAbilityIndex { get; set; }

		public Rarity()
		{
		}

		public Rarity(Type type)
		{
			this.type = type;
			Roll();
		}

		public Rarity Clone()
		{
			return new Rarity
			{
				type = type,
				levelBonus = levelBonus,
				isPerfect = isPerfect,
				quality = quality,
				selectedStatSeed = selectedStatSeed
			};
		}

		public static Rarity FromString(string sjson)
		{
			Rarity rarity = new Rarity();
			if (SlimJson.HasKey(sjson, "levelBonus"))
			{
				rarity.levelBonus = SlimJson.ParseInt(sjson, "levelBonus");
				rarity.type = GetTypeForBonus(rarity.levelBonus);
				rarity.isPerfect = IsBonusPerfect(rarity.levelBonus);
				rarity.quality = SlimJson.ParseInt(sjson, "quality");
				if (rarity.quality == 0)
				{
					rarity.quality = GetQualityThreshold(rarity.levelBonus);
				}
				rarity.selectedStatSeed = SlimJson.ParseInt(sjson, "selectedStatSeed");
			}
			else
			{
				rarity.levelBonus = SlimJson.ParseInt(sjson, "lv");
				rarity.type = GetTypeForBonus(rarity.levelBonus);
				rarity.isPerfect = IsBonusPerfect(rarity.levelBonus);
				rarity.quality = SlimJson.ParseInt(sjson, "ql");
				if (rarity.quality == 0)
				{
					rarity.quality = GetQualityThreshold(rarity.levelBonus);
				}
				rarity.selectedStatSeed = SlimJson.ParseInt(sjson, "sSS");
			}
			return rarity;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("lv", levelBonus);
			SlimJson.AddProperty("ql", quality);
			SlimJson.AddProperty("sSS", selectedStatSeed);
			return SlimJson.EndSerialization();
		}

		public void Roll(int rngSeed = -1)
		{
			if (type == Type.Common)
			{
				levelBonus = 0;
				isPerfect = false;
				quality = 0;
				selectedStatSeed = 0;
				return;
			}
			System.Random random = ((rngSeed >= 0) ? new System.Random(rngSeed) : new System.Random());
			selectedStatSeed = random.Next(0, 999999);
			if (type == Type.Uncommon)
			{
				levelBonus = 1;
				isPerfect = true;
			}
			else
			{
				int num = 0;
				int num2 = 1;
				if (type == Type.Rare)
				{
					num = 2;
					num2 = 3;
				}
				else if (type == Type.Heroic)
				{
					num = 4;
					num2 = 6;
				}
				else if (type == Type.Epic)
				{
					num = 7;
					num2 = 10;
				}
				else if (type == Type.Legendary)
				{
					num = 11;
					num2 = 15;
				}
				else if (type == Type.Transcendent)
				{
					num = 16;
					num2 = 21;
				}
				float num3 = 0.1f / (float)(num2 - num);
				if (random.NextDouble() <= (double)num3)
				{
					levelBonus = num2;
					isPerfect = true;
				}
				else
				{
					levelBonus = random.Next(num, num2);
					isPerfect = false;
				}
			}
			quality = GetQualityThreshold(levelBonus);
		}

		public static Color GetColorForRarity(Type type)
		{
			return type switch
			{
				Type.Common => ColorConstants.rarityCommon, 
				Type.Uncommon => ColorConstants.rarityUncommon, 
				Type.Rare => ColorConstants.rarityRare, 
				Type.Heroic => ColorConstants.rarityHeroic, 
				Type.Epic => ColorConstants.rarityEpic, 
				Type.Legendary => ColorConstants.rarityLegendary, 
				_ => ColorConstants.white, 
			};
		}

		public static Color GetColorForBonus(int bonus)
		{
			return GetColorForRarity(GetTypeForBonus(bonus));
		}

		public static Type GetNextRarity(Type type)
		{
			if (type == Type.Transcendent)
			{
				return Type.Transcendent;
			}
			return type + 1;
		}

		public static void TintString(AsciiString field, Color color, Item item)
		{
			Type rarityType = item.GetRarityType();
			if (rarityType == Type.Common)
			{
				field.color = color;
				field.isRainbow = false;
			}
			else if (item.GetLabelColor() != ColorConstants.white)
			{
				field.color = color * item.GetLabelColor();
				field.isRainbow = false;
			}
			else
			{
				field.isRainbow = rarityType == Type.Transcendent;
				Color colorForRarity = GetColorForRarity(rarityType);
				field.color = color * colorForRarity;
			}
		}

		public static int GetQualityThreshold(int forBonus)
		{
			if (forBonus <= 0)
			{
				return 0;
			}
			int num = Mathf.Clamp(forBonus - 1, 0, qualityThresholdPerBonus.Length - 1);
			return qualityThresholdPerBonus[num];
		}

		public static int GetBonusForQuality(int quality)
		{
			for (int i = 0; i < qualityThresholdPerBonus.Length; i++)
			{
				if (qualityThresholdPerBonus[i] > quality)
				{
					return i;
				}
			}
			return qualityThresholdPerBonus.Length;
		}

		public static Type GetTypeForBonus(int bonus)
		{
			if (bonus >= 16)
			{
				return Type.Transcendent;
			}
			if (bonus >= 11)
			{
				return Type.Legendary;
			}
			if (bonus >= 7)
			{
				return Type.Epic;
			}
			if (bonus >= 4)
			{
				return Type.Heroic;
			}
			if (bonus >= 2)
			{
				return Type.Rare;
			}
			return Type.Uncommon;
		}

		public static bool IsBonusPerfect(int bonus)
		{
			if (bonus != 1 && bonus != 3 && bonus != 6 && bonus != 10 && bonus != 15)
			{
				return bonus == 21;
			}
			return true;
		}
	}

	public class RunestoneInfo
	{
		public Element element;

		public Rarity rarity;

		public int selectedAbilitiesSeed;

		public RunestoneInfo Clone()
		{
			return new RunestoneInfo
			{
				element = element,
				rarity = rarity.Clone(),
				selectedAbilitiesSeed = selectedAbilitiesSeed
			};
		}

		public static RunestoneInfo FromString(string sjson)
		{
			return new RunestoneInfo
			{
				element = SlimJson.ParseEnum<Element>(sjson, "element"),
				rarity = SlimJson.Parse(sjson, "rarity", Rarity.FromString),
				selectedAbilitiesSeed = SlimJson.ParseInt(sjson, "selectedAbilitiesSeed")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("element", element.ToString());
			if (rarity != null)
			{
				SlimJson.AddProperty("rarity", rarity.ToString());
			}
			SlimJson.AddProperty("selectedAbilitiesSeed", selectedAbilitiesSeed);
			return SlimJson.EndSerialization();
		}

		public void Roll(int rngSeed = -1)
		{
			if (rarity != null)
			{
				rarity.Roll(rngSeed);
			}
			System.Random random = ((rngSeed >= 0) ? new System.Random(rngSeed) : new System.Random());
			selectedAbilitiesSeed = random.Next(0, 999999);
		}
	}

	[Serializable]
	public class Ability
	{
		public enum ApplyWhen
		{
			Start = 0,
			Equip = 1,
			AttackEnd = 2,
			AttackedByEnemy = 3
		}

		public enum ApplyTo
		{
			Item = 0,
			Character = 1,
			Bullet = 2
		}

		public string id;

		public string abbreviation;

		public string sibling;

		public ApplyWhen applyWhen;

		public ApplyTo applyTo;

		public bool applySubAbility;

		[HideInInspector]
		public string[] items;

		[HideInInspector]
		public string[] elements;

		public string[] combinatorySubAbilities;

		public string description;

		public Stat stat;

		public float subAbilityStatMult;

		[HideInInspector]
		public Ability subAbility;

		public bool canBeEnchanted = true;

		public bool applyRarity { get; set; }

		public Ability Clone()
		{
			Ability ability = new Ability();
			ability.id = id;
			ability.abbreviation = abbreviation;
			ability.sibling = sibling;
			ability.applyWhen = applyWhen;
			ability.applyTo = applyTo;
			ability.applySubAbility = applySubAbility;
			ability.items = items;
			ability.elements = elements;
			ability.combinatorySubAbilities = combinatorySubAbilities;
			ability.description = description;
			if (stat != null)
			{
				ability.stat = stat.Clone();
			}
			ability.subAbilityStatMult = subAbilityStatMult;
			if (subAbility != null)
			{
				ability.subAbility = subAbility.Clone();
			}
			ability.canBeEnchanted = canBeEnchanted;
			return ability;
		}

		public static Ability FromString(string sjson)
		{
			return new Ability
			{
				id = SlimJson.Parse(sjson, "id"),
				abbreviation = SlimJson.Parse(sjson, "abbreviation"),
				sibling = SlimJson.Parse(sjson, "sibling"),
				applyWhen = SlimJson.ParseEnum<ApplyWhen>(sjson, "applyWhen"),
				applyTo = SlimJson.ParseEnum<ApplyTo>(sjson, "applyTo"),
				applySubAbility = SlimJson.ParseBool(sjson, "applySubAbility"),
				items = SlimJson.ParseArray(sjson, "items"),
				elements = SlimJson.ParseArray(sjson, "elements"),
				combinatorySubAbilities = SlimJson.ParseArray(sjson, "combinatorySubAbilities"),
				description = SlimJson.Parse(sjson, "description"),
				stat = SlimJson.Parse(sjson, "stat", Stat.FromString),
				subAbilityStatMult = SlimJson.ParseFloat(sjson, "subAbilityStatMult", 1f),
				canBeEnchanted = SlimJson.ParseBool(sjson, "canBeEnchanted", defaultValue: true)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("abbreviation", abbreviation);
			SlimJson.AddProperty("sibling", sibling);
			SlimJson.AddProperty("applyWhen", applyWhen.ToString());
			SlimJson.AddProperty("applyTo", applyTo.ToString());
			SlimJson.AddProperty("applySubAbility", applySubAbility);
			SlimJson.AddProperty("items", items);
			SlimJson.AddProperty("elements", elements);
			SlimJson.AddProperty("combinatorySubAbilities", combinatorySubAbilities);
			SlimJson.AddProperty("description", description);
			if (stat != null)
			{
				SlimJson.AddProperty("stat", stat.ToString());
			}
			SlimJson.AddProperty("subAbilityStatMult", subAbilityStatMult);
			if (!canBeEnchanted)
			{
				SlimJson.AddProperty("canBeEnchanted", canBeEnchanted);
			}
			return SlimJson.EndSerialization();
		}

		public string GetDescription(Item parentItem, float statMultiplier = 1f)
		{
			if (description == null)
			{
				return id;
			}
			string text = Te.xt(description);
			string newValue = "?";
			if (stat != null)
			{
				float num = ItemFactory.GetLevelDisplayValueForItem(parentItem);
				if (applyRarity && parentItem.rarity != null)
				{
					num = ((!stat.rareStatOnly) ? (num + (float)parentItem.rarity.levelBonus) : ((float)parentItem.rarity.levelBonus));
				}
				else if (!applyRarity && stat.rareStatOnly)
				{
					num = 0f;
				}
				newValue = stat.Compute(num, statMultiplier).ToString("0.##");
			}
			text = text.Replace("<stat>", newValue);
			string newValue2 = "?";
			string newValue3 = "?";
			if (parentItem.element != Element.Stone)
			{
				newValue2 = Te.xt(ReplacementTidForElement(Counters(parentItem.element)));
				newValue3 = Te.xt(ReplacementTidForElement(CounteredBy(parentItem.element)));
			}
			string newValue4 = "";
			if (subAbility != null)
			{
				newValue4 = subAbility.GetDescription(parentItem, subAbilityStatMult);
			}
			text = text.Replace("<element+1>", newValue2);
			text = text.Replace("<element-1>", newValue3);
			text = text.Replace("<sub_ability>", newValue4);
			if (abbreviation != null && abbreviation.Length > 0)
			{
				text = text + "(" + abbreviation + ")";
			}
			return text;
		}
	}

	[Serializable]
	public class Stat
	{
		public enum Type
		{
			None = 0,
			Damage = 1,
			Health = 2,
			Armor = 3,
			ElementDamage = 4,
			ElementArmor = 5,
			AttackSpeed = 6,
			EvadeChance = 7,
			AoeChance = 8,
			LifestealChance = 9,
			CritChance = 10,
			CritMult = 11,
			SubAbilityDuration = 12,
			ChanceToApply = 13,
			Stun = 14,
			TicsPerMove = 15,
			Custom = 16,
			ArmorPerSecond = 17,
			MaxArmor = 18,
			Range = 19
		}

		public Type type;

		public string prefab = "stat_basic";

		public bool rareStatOnly;

		public bool computeEvenIfRareOnly = true;

		public bool canBeEnchanted;

		public float baseValue;

		public float levelMult;

		public float minValue;

		public bool floorResult;

		public string[] customParams;

		private DataHeavyStat dataHeavyStat;

		public void TryInitDataHeavyStat(string itemId)
		{
			if (customParams == null)
			{
				return;
			}
			for (int i = 0; i < customParams.Length; i++)
			{
				if (customParams[i].StartsWith("@"))
				{
					string statId = customParams[i].Substring(1);
					dataHeavyStat = DataHeavyStatController.singleton.GetStat(itemId, statId);
					break;
				}
			}
		}

		public Stat Clone()
		{
			Stat stat = new Stat();
			stat.type = type;
			stat.prefab = prefab;
			stat.rareStatOnly = rareStatOnly;
			stat.canBeEnchanted = canBeEnchanted;
			stat.baseValue = baseValue;
			stat.levelMult = levelMult;
			stat.minValue = minValue;
			stat.floorResult = floorResult;
			if (customParams != null)
			{
				stat.customParams = (string[])customParams.Clone();
			}
			return stat;
		}

		public static Stat FromString(string sjson)
		{
			return new Stat
			{
				type = SlimJson.ParseEnum<Type>(sjson, "type"),
				prefab = SlimJson.Parse(sjson, "prefab"),
				rareStatOnly = SlimJson.ParseBool(sjson, "rareStatOnly"),
				canBeEnchanted = SlimJson.ParseBool(sjson, "canBeEnchanted", defaultValue: true),
				baseValue = SlimJson.ParseFloat(sjson, "baseValue"),
				levelMult = SlimJson.ParseFloat(sjson, "levelMult"),
				minValue = SlimJson.ParseFloat(sjson, "minValue"),
				floorResult = SlimJson.ParseBool(sjson, "floorResult"),
				customParams = SlimJson.ParseArray(sjson, "customParams")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("type", type.ToString());
			SlimJson.AddProperty("prefab", prefab);
			SlimJson.AddProperty("rareStatOnly", rareStatOnly);
			if (!canBeEnchanted)
			{
				SlimJson.AddProperty("canBeEnchanted", property: false);
			}
			SlimJson.AddProperty("baseValue", baseValue);
			SlimJson.AddProperty("levelMult", levelMult);
			SlimJson.AddProperty("minValue", minValue);
			SlimJson.AddProperty("floorResult", floorResult);
			if (customParams != null)
			{
				SlimJson.AddProperty("customParams", customParams);
			}
			return SlimJson.EndSerialization();
		}

		public float Compute(float itemDisplayLevel, float resultMultiplier = 1f)
		{
			float num;
			if (dataHeavyStat != null)
			{
				num = dataHeavyStat.Compute(Mathf.RoundToInt(itemDisplayLevel));
				return num * resultMultiplier;
			}
			num = baseValue + levelMult * itemDisplayLevel;
			num *= resultMultiplier;
			if (floorResult)
			{
				num = ((!(num < 0f)) ? Mathf.Floor(num) : Mathf.Ceil(num));
			}
			if (num < 0f && levelMult <= 0f)
			{
				return Mathf.Min(num, minValue);
			}
			return Mathf.Max(num, minValue);
		}
	}

	public enum HandType
	{
		LeftOrRight = 0,
		LeftOnly = 1,
		RightOnly = 2,
		DoubleHanded = 3
	}

	public static Element Counters(Element e)
	{
		return e switch
		{
			Element.Poison => Element.Vigor, 
			Element.Vigor => Element.AEther, 
			Element.AEther => Element.Fire, 
			Element.Fire => Element.Ice, 
			Element.Air => Element.Ice, 
			Element.Ice => Element.Poison, 
			_ => e, 
		};
	}

	public static Element CounteredBy(Element e)
	{
		return e switch
		{
			Element.Poison => Element.Ice, 
			Element.Vigor => Element.Poison, 
			Element.AEther => Element.Vigor, 
			Element.Fire => Element.AEther, 
			Element.Air => Element.Fire, 
			Element.Ice => Element.Fire, 
			_ => e, 
		};
	}

	public static char CharForElement(Element e)
	{
		return e switch
		{
			Element.Ice => '❄', 
			Element.Fire => 'φ', 
			Element.Poison => '∞', 
			Element.Vigor => '♥', 
			Element.AEther => '*', 
			Element.Air => 'α', 
			_ => 'o', 
		};
	}

	public static string NameForElement(Element e)
	{
		return e switch
		{
			Element.Ice => "Ice", 
			Element.Fire => "Fire", 
			Element.Poison => "Poison", 
			Element.Vigor => "Vigor", 
			Element.AEther => "Æther", 
			Element.Air => "Air", 
			_ => "Stone", 
		};
	}

	public static string ReplacementTidForElement(Element e)
	{
		return e switch
		{
			Element.Ice => "tid_replacement_ice", 
			Element.Fire => "tid_replacement_fire", 
			Element.Poison => "tid_replacement_poison", 
			Element.Vigor => "tid_replacement_vigor", 
			Element.AEther => "tid_replacement_aether", 
			Element.Air => "Air", 
			_ => "tid_replacement_stone", 
		};
	}

	public static Element ParseElement(string elementName, bool ignoreCase)
	{
		if (ignoreCase)
		{
			elementName = elementName.ToLower();
		}
		return ParseElement(elementName);
	}

	public static Element ParseElement(string elementName)
	{
		switch (elementName)
		{
		case "ice":
		case "Ice":
			return Element.Ice;
		case "fire":
		case "Fire":
			return Element.Fire;
		case "poison":
		case "Poison":
			return Element.Poison;
		case "vigor":
		case "Vigor":
			return Element.Vigor;
		case "aether":
		case "AEther":
			return Element.AEther;
		case "air":
		case "Air":
			return Element.Air;
		default:
			return Element.Stone;
		}
	}

	public static Element RandomElement()
	{
		return (Element)UnityEngine.Random.Range(1, 7);
	}
}
