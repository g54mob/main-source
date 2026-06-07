using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class DPS_Meter
{
	public Dictionary<string, int> prevDamage = new Dictionary<string, int>();

	public Dictionary<string, int> damage = new Dictionary<string, int>();

	public Dictionary<string, Module.Tribe> tribes = new Dictionary<string, Module.Tribe>();

	public string currTitle;

	public string currDesc;

	public void AddDamage(Module m, int dmg)
	{
		AddDamage(m.name, dmg, m.UPGRADED, m == Dungeon.Instance.player.sentinel);
	}

	public void AddDamage(Module.Name m, int dmg, bool upg, bool sentinel = false)
	{
		Database.ModuleInfo modData_Localized = Database.GetModData_Localized(m);
		string key = modData_Localized.name + (upg ? "+" : "");
		if (sentinel)
		{
			key = ((Dungeon.Instance.saveData.language == SaveManager.Language.Japanese) ? "スキル" : "SKILLS");
		}
		Module.Tribe value = ((modData_Localized.tribe.Count > 0) ? modData_Localized.tribe[0] : Module.Tribe.None);
		if (damage.ContainsKey(key))
		{
			damage[key] += dmg;
			return;
		}
		damage.Add(key, dmg);
		if (!tribes.ContainsKey(key))
		{
			tribes.Add(key, value);
		}
	}

	public void ResetDamage()
	{
		prevDamage.Clear();
		prevDamage = new Dictionary<string, int>(damage);
		damage.Clear();
		CreateLog();
	}

	public void CreateLog()
	{
		bool flag = Dungeon.Instance.saveData.language == SaveManager.Language.Japanese;
		string text = ((Dungeon.Instance.saveData.language == SaveManager.Language.Japanese) ? "<size=6.25>前のウェーブ</size> DMG" : "LAST WAVE DMG");
		string text2 = "";
		IOrderedEnumerable<KeyValuePair<string, int>> orderedEnumerable = prevDamage.OrderByDescending(delegate(KeyValuePair<string, int> entry)
		{
			KeyValuePair<string, int> keyValuePair = entry;
			return keyValuePair.Value;
		});
		int num = 1;
		int num2 = 18;
		if (flag)
		{
			num2 = 11;
		}
		if (prevDamage.Count == 0)
		{
			text2 = "---";
		}
		foreach (KeyValuePair<string, int> item in orderedEnumerable)
		{
			string text3 = item.Value.ToString();
			string text4 = item.Key.ToUpper();
			bool flag2 = text4 == "USB";
			string text5 = "";
			string text6 = "";
			if (tribes.ContainsKey(text4))
			{
				text5 = tribes[text4] switch
				{
					Module.Tribe.Mech => "[mech]", 
					Module.Tribe.Wand => "[blue]", 
					Module.Tribe.Pet => "[green]", 
					Module.Tribe.None => (!text4.Contains("+")) ? "[white]" : "[g]", 
					_ => "", 
				};
			}
			if (text5 != "")
			{
				text6 = "[/g]";
			}
			text4 = $"{num++}.{text4}";
			bool flag3 = false;
			if (text4.Contains("+"))
			{
				flag3 = true;
				text4 = text4.Replace("+", "");
			}
			if (text4.Length > num2 - 2 - text3.Length)
			{
				text4 = text4.Truncate(num2 - 3 - text3.Length, ".");
				if (text4.Last() == '.' && text4.Length > 2 && text4[text4.Length - 2] == ' ')
				{
					text4 = text4.Remove(text4.Length - 1);
					text4 = text4.Remove(text4.Length - 1);
				}
			}
			int num3 = num2 - text4.Length - 2 - text3.Length;
			if (num3 > 0 && flag3)
			{
				num3--;
				text4 += "+";
			}
			for (int num4 = 0; num4 < text4.Length; num4++)
			{
				if (text4[num4] == '.')
				{
					if (flag && !flag2)
					{
						text4 = text4.Insert(num4 + 1, "<size=6.25>");
					}
					text4 = text4.Insert(num4 + 1, text5);
					break;
				}
			}
			text4 += text6;
			if (flag && !flag2)
			{
				text4 += "</size>";
				text4 = text4.Replace("+", "<size=10>+</size>");
			}
			text2 += text4;
			for (int num5 = 0; num5 < num3; num5++)
			{
				text2 += " ";
			}
			text2 = text2 + "[white][[/g][red]" + text3 + "[/g][white]][/g]\n";
		}
		currTitle = text;
		currDesc = text2;
	}

	public void ShowDamage(Vector3 pos)
	{
		Dungeon.Instance.localizationManager.tooltipEN.Set(null, showUpgrade: false, noUpgrade: false, null, currTitle, currDesc, pos + new Vector3(0f, (float)(prevDamage.Count * 12) / 16f));
	}
}
