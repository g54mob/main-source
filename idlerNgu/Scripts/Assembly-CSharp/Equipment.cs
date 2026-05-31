using System;
using UnityEngine;

[Serializable]
public class Equipment
{
	[NonSerialized]
	public string path;

	public int id;

	public part type;

	public int bossRequired;

	public float capAttack;

	public float curAttack;

	public float capDefense;

	public float curDefense;

	public specType spec1Type;

	public float spec1Cur;

	public float spec1Cap;

	public specType spec2Type;

	public float spec2Cur;

	public float spec2Cap;

	public specType spec3Type;

	public float spec3Cur;

	public float spec3Cap;

	public bool removable;

	[NonSerialized]
	public int numSpec;

	public int level;

	[NonSerialized]
	public bool unique;

	public void Start()
	{
	}

	public Equipment()
	{
		path = "NoItem";
		id = 0;
		type = part.None;
		bossRequired = -1;
		capAttack = 0f;
		curAttack = 0f;
		capDefense = 0f;
		curDefense = 0f;
		spec1Type = specType.None;
		spec1Cur = 0f;
		spec1Cap = 0f;
		spec2Type = specType.None;
		spec2Cur = 0f;
		spec2Cap = 0f;
		spec3Type = specType.None;
		spec3Cur = 0f;
		spec3Cap = 0f;
		removable = true;
		numSpec = 0;
	}

	public Equipment(string source)
	{
		path = source;
		id = 0;
		type = part.None;
		bossRequired = -1;
		capAttack = 0f;
		curAttack = 0f;
		capDefense = 0f;
		curDefense = 0f;
		spec1Type = specType.None;
		spec1Cur = 0f;
		spec1Cap = 0f;
		spec2Type = specType.None;
		spec2Cur = 0f;
		spec2Cap = 0f;
		spec3Type = specType.None;
		spec3Cur = 0f;
		spec3Cap = 0f;
		removable = true;
		numSpec = 0;
	}

	public Equipment(part partType, int boss, float curAtk, float capAtk, float curDef, float capDef, specType type1, float cur1, float cap1, specType type2, float cur2, float cap2, specType type3, float cur3, float cap3, string source, int pid)
	{
		id = pid;
		path = source;
		type = partType;
		curAttack = curAtk;
		capAttack = capAtk;
		curDefense = curDef;
		capDefense = capDef;
		spec1Type = type1;
		spec1Cur = cur1;
		spec1Cap = cap1;
		spec2Type = type2;
		spec2Cur = cur2;
		spec2Cap = cap2;
		spec3Type = type3;
		spec3Cur = cur3;
		spec3Cap = cap3;
		removable = true;
		bossRequired = boss;
		level = 0;
	}

	public Equipment(part partType, float boost, string source, int pid)
	{
		id = pid;
		bossRequired = -1;
		path = source;
		type = partType;
		bossRequired = 0;
		removable = true;
		numSpec = 0;
		level = 0;
		switch (partType)
		{
		case part.atkBoost:
			curAttack = boost;
			capAttack = 0f;
			curDefense = 0f;
			capDefense = 0f;
			spec1Type = specType.None;
			spec1Cur = 0f;
			spec1Cap = 0f;
			spec2Type = specType.None;
			spec2Cur = 0f;
			spec2Cap = 0f;
			spec3Type = specType.None;
			spec3Cur = 0f;
			spec3Cap = 0f;
			break;
		case part.defBoost:
			curAttack = 0f;
			capAttack = 0f;
			curDefense = boost;
			capDefense = 0f;
			spec1Type = specType.None;
			spec1Cur = 0f;
			spec1Cap = 0f;
			spec2Type = specType.None;
			spec2Cur = 0f;
			spec2Cap = 0f;
			spec3Type = specType.None;
			spec3Cur = 0f;
			spec3Cap = 0f;
			bossRequired = 0;
			break;
		case part.specBoost:
			curAttack = 0f;
			capAttack = 0f;
			curDefense = 0f;
			capDefense = 0f;
			spec1Type = specType.None;
			spec1Cur = boost;
			spec1Cap = 0f;
			spec2Type = specType.None;
			spec2Cur = boost;
			spec2Cap = 0f;
			spec3Type = specType.None;
			spec3Cur = boost;
			spec3Cap = 0f;
			bossRequired = 0;
			break;
		}
	}

	public string tooltipText(int bossID)
	{
		string text = "";
		string text2 = "\n\n";
		text += "<b>Stats</b>";
		if (bossID < bossRequired)
		{
			text = text + "(" + (Mathf.Min((float)bossID / (float)bossRequired, 1f) * 100f).ToString("##.#") + "%)";
		}
		text += "\n";
		if (capAttack != 0f)
		{
			float num = Mathf.Floor(curAttack * Mathf.Min((float)bossID / (float)bossRequired, 1f));
			text2 = "Power: " + num + " / " + Mathf.Floor(capAttack * (1f + (float)level / 100f)) + "\nMax Health: " + num * 3f + " / " + Mathf.Floor(capAttack * (1f + (float)level / 100f)) * 3f + "\n";
			if (curAttack >= Mathf.Floor(capAttack * (1f + (float)level / 100f)))
			{
				text2 = "<color=green>" + text2 + "</color>";
			}
			text += text2;
		}
		if (capDefense != 0f)
		{
			float num2 = Mathf.Floor(curDefense * Mathf.Min((float)bossID / (float)bossRequired, 1f));
			text2 = "Toughness: " + num2 + " / " + Mathf.Floor(capDefense * (1f + (float)level / 100f)) + "\nHealth Regen: " + num2 * 0.03f + " / " + Mathf.Floor(capDefense * (1f + (float)level / 100f)) * 0.03f + "\n";
			if (curDefense >= Mathf.Floor(capDefense * (1f + (float)level / 100f)))
			{
				text2 = "<color=green>" + text2 + "</color>";
			}
			text += text2;
		}
		if (text != "\n<b>Stats</b>\n")
		{
			text += "\n";
		}
		if (spec1Type != specType.None)
		{
			float num3 = Mathf.Floor(spec1Cur * Mathf.Min((float)bossID / (float)bossRequired, 1f));
			float num4 = Mathf.Floor(spec1Cap * (1f + (float)level / 100f));
			string text3 = "Special Effect 1: " + effectName(spec1Type) + "\nCurrent bonus: " + num3 + " / " + num4 + " (" + effectBonus(num3, spec1Type) + "% Bonus)";
			if (spec1Cur >= Mathf.Floor(spec1Cap * (1f + (float)level / 100f)))
			{
				text3 = "<color=green>" + text3 + "</color>";
			}
			text += text3;
		}
		if (spec2Type != specType.None)
		{
			float num5 = Mathf.Floor(spec2Cur * Mathf.Min((float)bossID / (float)bossRequired, 1f));
			float num6 = Mathf.Floor(spec2Cap * (1f + (float)level / 100f));
			string text4 = "\n\nSpecial Effect 2: " + effectName(spec2Type) + "\nCurrent bonus: " + num5 + " / " + num6 + " (" + effectBonus(num5, spec2Type) + "% Bonus)";
			if (spec2Cur >= Mathf.Floor(spec2Cap * (1f + (float)level / 100f)))
			{
				text4 = "<color=green>" + text4 + "</color>";
			}
			text += text4;
		}
		if (spec3Type != specType.None)
		{
			float num7 = Mathf.Floor(spec3Cur * Mathf.Min((float)bossID / (float)bossRequired, 1f));
			float num8 = Mathf.Floor(spec3Cap * (1f + (float)level / 100f));
			string text5 = "\n\nSpecial Effect 3: " + effectName(spec3Type) + "\nCurrent bonus: " + num7 + " / " + num8 + " (" + effectBonus(num7, spec3Type) + "% Bonus)";
			if (spec3Cur >= Mathf.Floor(spec3Cap * (1f + (float)level / 100f)))
			{
				text5 = "<color=green>" + text5 + "</color>";
			}
			text += text5;
		}
		if (unique)
		{
			text += "\n\nUNIQUE: Cannot equip more than one at the same time!";
		}
		return text;
	}

	public float specBonus(specType type)
	{
		float num = 0f;
		if (spec1Type == specType.None)
		{
			return num;
		}
		if (spec1Type == type)
		{
			num += spec1Cur;
		}
		if (spec2Type == type)
		{
			num += spec2Cur;
		}
		if (spec3Type == type)
		{
			num += spec3Cur;
		}
		return num;
	}

	public bool hasSpec(specType type)
	{
		if (spec1Type == type)
		{
			return true;
		}
		if (spec2Type == type)
		{
			return true;
		}
		if (spec3Type == type)
		{
			return true;
		}
		return false;
	}

	public float reqBossFactor(int bossReq)
	{
		return Mathf.Min(1f, level / bossReq);
	}

	public bool boostEquip(Equipment boost)
	{
		return boostEquip(boost, 1f);
	}

	public bool boostEquip(Equipment boost, float bonus)
	{
		if (id == 0)
		{
			return false;
		}
		if (boost.type == part.atkBoost)
		{
			float num = boost.capAttack * bonus;
			if (curAttack >= Mathf.Floor(capAttack * (1f + (float)level / 100f)))
			{
				return false;
			}
			curAttack += num;
			if (curAttack >= Mathf.Floor(capAttack * (1f + (float)level / 100f)))
			{
				curAttack = Mathf.Floor(capAttack * (1f + (float)level / 100f));
			}
			return true;
		}
		if (boost.type == part.defBoost)
		{
			float num2 = boost.capDefense * bonus;
			if (curDefense >= Mathf.Floor(capDefense * (1f + (float)level / 100f)))
			{
				return false;
			}
			curDefense += num2;
			if (curDefense >= Mathf.Floor(capDefense * (1f + (float)level / 100f)))
			{
				curDefense = Mathf.Floor(capDefense * (1f + (float)level / 100f));
			}
			return true;
		}
		if (boost.type == part.specBoost)
		{
			float num3 = boost.spec1Cap * bonus;
			bool result = false;
			float num4 = Mathf.Floor(spec1Cap * (1f + (float)level / 100f)) - spec1Cur;
			if (num4 >= num3)
			{
				spec1Cur += num3;
				return true;
			}
			if (num4 > 0f)
			{
				spec1Cur += num4;
				num3 -= num4;
				result = true;
			}
			float num5 = Mathf.Floor(spec2Cap * (1f + (float)level / 100f)) - spec2Cur;
			if (num5 >= num3)
			{
				spec2Cur += num3;
				return true;
			}
			if (num5 > 0f)
			{
				spec2Cur += num5;
				num3 -= num5;
				result = true;
			}
			float num6 = Mathf.Floor(spec3Cap * (1f + (float)level / 100f)) - spec3Cur;
			if (num6 >= num3)
			{
				spec3Cur += num3;
				return true;
			}
			if (num6 > 0f)
			{
				spec3Cur += num6;
				num3 -= num6;
				result = true;
			}
			return result;
		}
		return false;
	}

	public bool maxEquipBoost(Equipment boost)
	{
		if (id == 0)
		{
			return false;
		}
		if (boost.id == 170)
		{
			if (curAttack >= Mathf.Floor(capAttack * (1f + (float)level / 100f)))
			{
				return false;
			}
			curAttack = Mathf.Floor(capAttack * (1f + (float)level / 100f));
			return true;
		}
		if (boost.id == 171)
		{
			if (curDefense >= Mathf.Floor(capDefense * (1f + (float)level / 100f)))
			{
				return false;
			}
			curDefense = Mathf.Floor(capDefense * (1f + (float)level / 100f));
			return true;
		}
		if (boost.id == 172)
		{
			if (spec1Cur >= Mathf.Floor(spec1Cap * (1f + (float)level / 100f)) && spec2Cur >= Mathf.Floor(spec2Cap * (1f + (float)level / 100f)) && spec2Cur >= Mathf.Floor(spec2Cap * (1f + (float)level / 100f)))
			{
				return false;
			}
			spec1Cur = Mathf.Floor(spec1Cap * (1f + (float)level / 100f));
			spec2Cur = Mathf.Floor(spec2Cap * (1f + (float)level / 100f));
			spec2Cur = Mathf.Floor(spec2Cap * (1f + (float)level / 100f));
			return true;
		}
		return false;
	}

	public float getAttack()
	{
		return curAttack;
	}

	public void updateItem(int rboss, part ptype, float capatk, float curatk, float capdef, float curdef, specType type1, float capspec1, float curspec1, specType type2, float capspec2, float curspec2, specType type3, float capspec3, float curspec3, string npath, bool punique)
	{
		bossRequired = rboss;
		capAttack = capatk;
		type = ptype;
		if (curAttack > Mathf.Floor(capAttack * (1f + (float)level / 100f)))
		{
			curAttack = Mathf.Floor(capAttack * (1f + (float)level / 100f));
		}
		if (curAttack < curatk)
		{
			curAttack = curatk;
		}
		capDefense = capdef;
		if (curDefense > Mathf.Floor(capDefense * (1f + (float)level / 100f)))
		{
			curDefense = Mathf.Floor(capDefense * (1f + (float)level / 100f));
		}
		if (curDefense < curdef)
		{
			curDefense = curdef;
		}
		spec1Type = type1;
		spec1Cap = capspec1;
		float num = Mathf.Floor(spec1Cap * (1f + (float)level / 100f));
		if (spec1Cur > num)
		{
			spec1Cur = num;
		}
		if (spec1Cur < curspec1)
		{
			spec1Cur = curspec1;
		}
		spec2Type = type2;
		spec2Cap = capspec2;
		float num2 = Mathf.Floor(spec2Cap * (1f + (float)level / 100f));
		if (spec2Cur > num2)
		{
			spec2Cur = num2;
		}
		if (spec2Cur < curspec2)
		{
			spec2Cur = curspec2;
		}
		spec3Type = type3;
		spec3Cap = capspec3;
		float num3 = Mathf.Floor(spec3Cap * (1f + (float)level / 100f));
		if (spec3Cur > num3)
		{
			spec3Cur = num3;
		}
		if (spec3Cur < curspec3)
		{
			spec3Cur = curspec3;
		}
		path = npath;
		unique = punique;
	}

	public void mergeItem(Equipment equip)
	{
		if ((long)level + (long)equip.level + 1 > int.MaxValue)
		{
			level = int.MaxValue;
		}
		else
		{
			level = level + equip.level + 1;
		}
		if (level > 100 && type != part.MacGuffin)
		{
			level = 100;
		}
		curAttack = Mathf.Max(curAttack, equip.curAttack);
		if (curAttack > Mathf.Floor(capAttack * (1f + (float)level / 100f)))
		{
			curAttack = Mathf.Floor(capAttack * (1f + (float)level / 100f));
		}
		curDefense = Mathf.Max(curDefense, equip.curDefense);
		if (curDefense > Mathf.Floor(capDefense * (1f + (float)level / 100f)))
		{
			curDefense = Mathf.Floor(capDefense * (1f + (float)level / 100f));
		}
		spec1Cur = Mathf.Max(spec1Cur, equip.spec1Cur);
		spec2Cur = Mathf.Max(spec2Cur, equip.spec2Cur);
		spec3Cur = Mathf.Max(spec3Cur, equip.spec3Cur);
		if (spec1Cur > Mathf.Floor(spec1Cap * (1f + (float)level / 100f)))
		{
			spec1Cur = Mathf.Floor(spec1Cap * (1f + (float)level / 100f));
		}
		if (spec2Cur > Mathf.Floor(spec2Cap * (1f + (float)level / 100f)))
		{
			spec2Cur = Mathf.Floor(spec2Cap * (1f + (float)level / 100f));
		}
		if (spec3Cur > Mathf.Floor(spec3Cap * (1f + (float)level / 100f)))
		{
			spec3Cur = Mathf.Floor(spec3Cap * (1f + (float)level / 100f));
		}
		if (!removable || !equip.removable)
		{
			removable = false;
		}
		else
		{
			removable = true;
		}
	}

	public void levelUp()
	{
		if (id != 0 && level < 100)
		{
			level++;
			if (level > 100)
			{
				level = 100;
			}
		}
	}

	public float statFactor(int bossID)
	{
		if (bossRequired == 0)
		{
			return 1f;
		}
		return Mathf.Min((float)bossID / (float)bossRequired, 1f);
	}

	public bool isBoost()
	{
		if (type == part.atkBoost || type == part.defBoost || type == part.specBoost)
		{
			return true;
		}
		return false;
	}

	public bool isEquipment()
	{
		if (type == part.Head || type == part.Chest || type == part.Legs || type == part.Boots || type == part.Weapon || type == part.Accessory)
		{
			return true;
		}
		return false;
	}

	public bool isMacGuffin()
	{
		if (type == part.MacGuffin)
		{
			return true;
		}
		return false;
	}

	private string effectName(specType type)
	{
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
		default:
			return amount;
		}
	}

	public bool needsAtkBoost()
	{
		if (curAttack < capAttack)
		{
			return true;
		}
		return false;
	}

	public bool needsDefBoost()
	{
		if (curDefense < capDefense)
		{
			return true;
		}
		return false;
	}

	public bool needsSpecBoost()
	{
		if (spec1Cur < spec1Cap)
		{
			return true;
		}
		if (spec2Cur < spec1Cap)
		{
			return true;
		}
		if (spec3Cur < spec3Cap)
		{
			return true;
		}
		return false;
	}

	public void delete()
	{
	}
}
