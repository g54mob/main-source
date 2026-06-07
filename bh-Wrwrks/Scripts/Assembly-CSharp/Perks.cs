using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Perks : MonoBehaviour
{
	public enum Type
	{
		Fortified = 0,
		Armored = 1,
		Midas = 2,
		Vampire = 3,
		Regen = 4,
		Focused = 5,
		Mana = 6,
		Hail = 7,
		Leader = 8,
		Conductor = 9,
		Bomber = 10,
		Inspire = 11,
		Mechatron = 12,
		Discount = 13,
		Heavy = 14,
		Blizzard = 15,
		Feedback = 16,
		Gigantism = 17,
		Static = 18,
		Chemicals = 19,
		Dividends = 20,
		Bash = 21,
		Splinter = 22,
		Topped_Up = 23,
		Resurrect = 24,
		Frostbite = 25,
		Souldrain = 26,
		Upsides = 27,
		Windwalk = 28,
		Compuwiz = 29,
		Techtrash = 30,
		Restore = 31,
		Stutter = 32,
		Sniper = 33,
		Magetech = 34,
		Horsepower = 35,
		Goblinized = 36,
		Intellect = 37,
		Boosters = 38,
		Modulator = 39,
		Herd = 40,
		Research = 41,
		Unstable = 42,
		Mainframe = 43,
		_COUNT = 44
	}

	public struct PerkInfo
	{
		public string name;

		public string desc;
	}

	public List<GameObject> perkObjects;

	public static List<Type> demoPerks = new List<Type>
	{
		Type.Fortified,
		Type.Armored,
		Type.Midas,
		Type.Vampire,
		Type.Resurrect,
		Type.Focused,
		Type.Mana,
		Type.Hail,
		Type.Leader,
		Type.Inspire,
		Type.Heavy,
		Type.Blizzard,
		Type.Feedback,
		Type.Gigantism,
		Type.Splinter,
		Type.Topped_Up,
		Type.Souldrain,
		Type.Windwalk,
		Type.Compuwiz,
		Type.Techtrash,
		Type.Stutter,
		Type.Magetech,
		Type.Horsepower,
		Type.Boosters,
		Type.Modulator
	};

	public List<TMP_Text> titles;

	public List<UIButton> buttons;

	public UIButton skipButton;

	public Sprite[] spriteList;

	public List<PerkDisplay> perks = new List<PerkDisplay>();

	public GameObject perkDisplayObject;

	public List<Type> perkList = new List<Type> { Type.Goblinized };

	public Dungeon dungeon => Dungeon.Instance;

	private Player player => dungeon.player;

	public void Reroll()
	{
		List<Type> list = new List<Type>();
		if (dungeon.demo)
		{
			list = new List<Type>(demoPerks);
		}
		else
		{
			for (int i = 0; i < 44; i++)
			{
				list.Add((Type)i);
			}
		}
		foreach (Type perk in perkList)
		{
			if (list.Count == 3)
			{
				break;
			}
			list.Remove(perk);
		}
		if (list.Count <= 3)
		{
			list.Clear();
			if (dungeon.demo)
			{
				list = new List<Type>(demoPerks);
			}
			else
			{
				for (int j = 0; j < 44; j++)
				{
					list.Add((Type)j);
				}
			}
		}
		list = Utils.Shuffle(list);
		for (int k = 0; k < 3; k++)
		{
			buttons[k].data = (int)list[k];
			PerkInfo perkText = GetPerkText(list[k]);
			if (perkText.name == "")
			{
				titles[k].text = list[k].ToString().ToUpper();
				titles[k].text = titles[k].text.Replace('_', ' ');
			}
			else
			{
				titles[k].text = perkText.name.ToUpper();
			}
			buttons[k].text.text = perkText.desc;
			buttons[k].icon.sprite = spriteList[buttons[k].data];
		}
	}

	public void LoadPerkStock(List<Type> perks)
	{
		for (int i = 0; i < 3; i++)
		{
			buttons[i].data = (int)perks[i];
			PerkInfo perkText = GetPerkText(perks[i]);
			if (perkText.name == "")
			{
				titles[i].text = perks[i].ToString().ToUpper();
				titles[i].text = titles[i].text.Replace('_', ' ');
			}
			else
			{
				titles[i].text = perkText.name.ToUpper();
			}
			buttons[i].text.text = perkText.desc;
			buttons[i].icon.sprite = spriteList[buttons[i].data];
		}
	}

	public void RefreshPerkText()
	{
		for (int i = 0; i < 3; i++)
		{
			Type data = (Type)buttons[i].data;
			PerkInfo perkText = GetPerkText((Type)buttons[i].data);
			if (perkText.name == "")
			{
				titles[i].text = data.ToString().ToUpper();
				titles[i].text = titles[i].text.Replace('_', ' ');
			}
			else
			{
				titles[i].text = perkText.name.ToUpper();
			}
			buttons[i].text.text = perkText.desc;
			buttons[i].icon.sprite = spriteList[buttons[i].data];
		}
	}

	public void Select(Type t, int index, bool test = false, bool loaded = false)
	{
		if (Dungeon.Instance.state == Dungeon.State.Perk || test)
		{
			perkList.Add(t);
			GainPerk(t, loaded);
			AddPerkDisplay(t, index);
			dungeon.board.CheckAuras();
			if (!test)
			{
				Dungeon.Instance.SetState(Dungeon.State.Shop);
			}
		}
	}

	public void Skip()
	{
		dungeon.gold += 10;
		dungeon.audioManager.PlaySound(AudioManager.Sound.Gold);
		dungeon.board.CheckAuras();
		Dungeon.Instance.SetState(Dungeon.State.Shop);
	}

	public static PerkInfo GetPerkText(Type t)
	{
		SaveManager.Language language = Dungeon.Instance.saveData.language;
		if (language != SaveManager.Language.English && language == SaveManager.Language.Japanese)
		{
			return GetPerkTextJP(t);
		}
		return GetPerkTextEN(t);
	}

	public static PerkInfo GetPerkTextEN(Type t)
	{
		PerkInfo result = new PerkInfo
		{
			name = ""
		};
		switch (t)
		{
		case Type.Fortified:
			result.desc = "+25 Max HP";
			break;
		case Type.Armored:
			result.desc = "Reduce DMG\ntaken by 1";
			break;
		case Type.Midas:
			result.desc = "On Kill:\n5% chance\nto get $1";
			break;
		case Type.Vampire:
			result.desc = "On Kill:\n10% chance\nto heal 1";
			break;
		case Type.Regen:
			result.desc = "Heal 5 HP\nevery 10s";
			break;
		case Type.Hail:
			result.desc = "Base fires\nSlowing ice\nevery 2s\n[DMG: 2 x8]";
			break;
		case Type.Focused:
			result.desc = "+15% AMP\n+15% SPD\nto Modules";
			break;
		case Type.Mana:
			result.desc = "+1 MP/s to\nall Wands";
			break;
		case Type.Leader:
			result.desc = "Top Weapon has +1 DMG";
			break;
		case Type.Conductor:
			result.desc = "+1 Bounce\nto all your\nZap effects";
			break;
		case Type.Bomber:
			result.desc = "+20% Area\nto all your\nexplosions";
			break;
		case Type.Inspire:
			result.desc = "Pets get +10% SPD per Pet owned";
			break;
		case Type.Mechatron:
			result.desc = "If you have\n5+ mechs,\nSummon Mechatron";
			break;
		case Type.Discount:
			result.desc = "Shop items cost 25% less";
			break;
		case Type.Heavy:
			result.desc = "All items have +2 DMG and -50% SPD";
			break;
		case Type.Blizzard:
			result.desc = "Slowing frost blast\non enemies near base\n[DMG: 2]";
			break;
		case Type.Feedback:
			result.desc = "+0.5 MP to a random Wand on another Wands cast";
			break;
		case Type.Gigantism:
			result.desc = "Top Pet has +2 DMG and +100% size";
			break;
		case Type.Static:
			result.desc = "Mechs make random sparks\n[DMG: 3]";
			break;
		case Type.Chemicals:
			result.desc = "On 10 kills\nCreate a\ntoxic area\n[DMG: 2]";
			break;
		case Type.Dividends:
			result.desc = "+$3 Wave Reward";
			break;
		case Type.Bash:
			result.desc = "On Hit:\n10% chance to stun for\n1.5 sec";
			break;
		case Type.Splinter:
			result.desc = "On Hit:\n30% chance to shoot bone shards\n[DMG: 2]";
			break;
		case Type.Topped_Up:
			result.desc = "+1 DMG to all top row items if at full HP";
			break;
		case Type.Resurrect:
			result.desc = "Revive once at 50% HP when dying";
			break;
		case Type.Frostbite:
			result.desc = "Deals 2 DMG\nper second\nto slowed enemies";
			break;
		case Type.Souldrain:
			result.desc = "Wands get +0.25 MP\non kill";
			break;
		case Type.Upsides:
			result.desc = "+2 DMG to all upgraded\nitems";
			break;
		case Type.Windwalk:
			result.desc = "Wands give all Pets +25% SPD for 1s on Cast";
			break;
		case Type.Compuwiz:
			result.desc = "Mechs give +1 MP/s to all Wands in Network";
			break;
		case Type.Techtrash:
			result.desc = "Give +2 DMG to random weapon on selling Mech";
			break;
		case Type.Restore:
			result.desc = "Wands get a 25% chance to heal 1 on cast";
			break;
		case Type.Stutter:
			result.desc = "Every 3s:\nStun all enemies for 0.25s";
			break;
		case Type.Sniper:
			result.desc = "Far enemies take +2 DMG from Weapons";
			break;
		case Type.Magetech:
			result.desc = "Wands give adjacent Mechs +DMG equal to their MP/s";
			break;
		case Type.Horsepower:
			result.desc = "Pets give all Mechs\n+1 DMG for 2s on kill";
			break;
		case Type.Goblinized:
			result.desc = "Shop rerolls cost $1 less";
			break;
		case Type.Intellect:
			result.desc = "+1 DMG to Wands";
			break;
		case Type.Boosters:
			result.desc = "Mechs give\n+40% SPD to adjacent Pets";
			break;
		case Type.Modulator:
			result.desc = "+2 DMG to Modules";
			break;
		case Type.Herd:
			result.desc = "+3 DMG to rows with\n3+ Pets";
			break;
		case Type.Mainframe:
			result.desc = "+1 Mech to all Networks";
			break;
		case Type.Research:
			result.desc = "Upgrade a random Mech";
			break;
		case Type.Unstable:
			result.desc = "Wands make explosions on cast";
			break;
		default:
			result.desc = "PLACEHOLDER\nNO EFFECT";
			break;
		}
		result.desc += "\n";
		return result;
	}

	public void AddPerkDisplay(Type t, int x)
	{
		PerkDisplay component = Object.Instantiate(perkDisplayObject).GetComponent<PerkDisplay>();
		component.type = t;
		component.spriteRenderer.sprite = spriteList[(int)t];
		component.spriteRenderer.sortingOrder = perks.Count;
		perks.Add(component);
		component.transform.position = buttons[x].icon.transform.position;
		SortPerks();
	}

	private void SortPerks()
	{
		float num = 0.9375f;
		if (perks.Count > 13)
		{
			num = 11.25f / (float)(perks.Count - 1);
		}
		Vector3 vector = new Vector3(-13.875f, 7.8125f, 0f);
		int num2 = 0;
		foreach (PerkDisplay perk in perks)
		{
			dungeon.animationManager.LerpTo(perk.gameObject, vector + new Vector3(num * (float)num2, 0f, 0.05f * (float)num2), 15);
			num2++;
		}
	}

	public void Highlight(Type type)
	{
		Aura aura = new Aura(Aura.Type.Damage);
		aura.owner = player.sentinel;
		switch (type)
		{
		case Type.Leader:
			aura.HighlightTopLeftWeapon(anim: false);
			break;
		case Type.Focused:
		case Type.Modulator:
			aura.HighlightModules(anim: false);
			break;
		case Type.Inspire:
		case Type.Gigantism:
		case Type.Horsepower:
		case Type.Herd:
			aura.HighlightAllTribe(anim: false, Module.Tribe.Pet);
			break;
		case Type.Mechatron:
		case Type.Static:
		case Type.Techtrash:
		case Type.Boosters:
		case Type.Research:
			aura.HighlightAllTribe(anim: false, Module.Tribe.Mech);
			break;
		case Type.Mana:
		case Type.Feedback:
		case Type.Souldrain:
		case Type.Restore:
		case Type.Magetech:
		case Type.Intellect:
		case Type.Unstable:
			aura.HighlightAllTribe(anim: false, Module.Tribe.Wand);
			break;
		case Type.Heavy:
		{
			aura.HighlightNonMove(anim: false);
			Aura aura2 = new Aura(Aura.Type.Decel);
			aura2.owner = player.sentinel;
			aura2.HighlightMove(anim: false);
			break;
		}
		case Type.Windwalk:
			aura.HighlightAllTribe(anim: false, Module.Tribe.Wand);
			break;
		case Type.Compuwiz:
			aura.HighlightAllTribe(anim: false, Module.Tribe.Mech);
			break;
		case Type.Topped_Up:
			aura.HighlightRow(0, anim: false);
			break;
		case Type.Upsides:
			aura.HighlightAllUpgraded(anim: false);
			break;
		case Type.Hail:
		case Type.Conductor:
		case Type.Bomber:
		case Type.Discount:
		case Type.Blizzard:
		case Type.Chemicals:
		case Type.Dividends:
		case Type.Bash:
		case Type.Splinter:
		case Type.Resurrect:
		case Type.Frostbite:
		case Type.Stutter:
		case Type.Sniper:
		case Type.Goblinized:
			break;
		}
	}

	public void GainPerk(Type t, bool loaded = false)
	{
		switch (t)
		{
		case Type.Fortified:
			dungeon.player.AddAura(new Aura(Aura.Type.PlayerHP, foreign: false, temp: false, null, 25f));
			break;
		case Type.Bash:
			dungeon.player.AddTrigger(Trigger.Ability.Stun, null, 10f);
			break;
		case Type.Armored:
			player.armor++;
			break;
		case Type.Midas:
			dungeon.player.AddTrigger(Trigger.Ability.PerkMidas, null, 5f);
			break;
		case Type.Vampire:
			dungeon.player.AddTrigger(Trigger.Ability.PerkVampire, null, 10f);
			break;
		case Type.Regen:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkRegen, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 600);
			break;
		case Type.Focused:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkFocused));
			break;
		case Type.Mana:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkMana));
			break;
		case Type.Hail:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkHail, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 120);
			break;
		case Type.Leader:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkLeader));
			break;
		case Type.Conductor:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkConductor));
			dungeon.player.AddAura(new Aura(Aura.Type.PerkConductor));
			break;
		case Type.Bomber:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkBomber));
			break;
		case Type.Inspire:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkInspire));
			break;
		case Type.Mechatron:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkMechatron));
			break;
		case Type.Discount:
		{
			dungeon.player.AddAura(new Aura(Aura.Type.PerkDiscount));
			int num = dungeon.board.CountAuras(Aura.Type.PerkDiscount);
			foreach (Module module2 in dungeon.shop.modules)
			{
				Database.ModuleInfo modData = Database.GetModData(module2);
				module2.shopPrice = (int)((float)modData.price * Mathf.Pow(0.75f, num));
				dungeon.shop.texts[module2.index].text = $"${module2.shopPrice}";
				dungeon.shop.CheckPrices();
			}
			break;
		}
		case Type.Heavy:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkHeavy));
			break;
		case Type.Blizzard:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkBlizzard, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 90);
			break;
		case Type.Feedback:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkFeedback, player.sentinel, null, 100f, 0, 1, Trigger.Type.Cast));
			break;
		case Type.Gigantism:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkGigantism));
			break;
		case Type.Static:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkStatic, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 15);
			break;
		case Type.Chemicals:
			dungeon.player.AddTrigger(Trigger.Ability.PerkChemicals);
			break;
		case Type.Dividends:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkDividends));
			break;
		case Type.Splinter:
			dungeon.player.AddTrigger(Trigger.Ability.PerkSplinter, null, 30f);
			break;
		case Type.Topped_Up:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkTopped));
			break;
		case Type.Resurrect:
			if (!loaded)
			{
				player.ressurects++;
			}
			break;
		case Type.Frostbite:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkFrostbite, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 60);
			break;
		case Type.Souldrain:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkSouldrain));
			break;
		case Type.Upsides:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkUpsides));
			break;
		case Type.Windwalk:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkWindwalk, player.sentinel, null, 100f, 0, 1, Trigger.Type.Cast));
			break;
		case Type.Compuwiz:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkCompuwiz));
			break;
		case Type.Techtrash:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkTechtrash, player.sentinel, null, 100f, 0, 1, Trigger.Type.Sell));
			break;
		case Type.Restore:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkRestore, player.sentinel, null, 25f, 0, 1, Trigger.Type.Cast));
			break;
		case Type.Stutter:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkStutter, player.sentinel, null, 100f, 0, 1, Trigger.Type.Timer), 180);
			break;
		case Type.Sniper:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkSniper, player.sentinel));
			break;
		case Type.Magetech:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkMagetech));
			break;
		case Type.Horsepower:
			Object.Instantiate(perkObjects[4]).transform.parent = dungeon.player.sentinel.transform;
			dungeon.player.AddAura(new Aura(Aura.Type.PerkHorsepower));
			break;
		case Type.Goblinized:
			dungeon.player.AddAura(new Aura(Aura.Type.RerollDiscount));
			dungeon.shop.restockPrice = dungeon.shop.baseRestockPrice;
			break;
		case Type.Intellect:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkIntellect));
			break;
		case Type.Boosters:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkBoosters));
			break;
		case Type.Modulator:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkModulator));
			break;
		case Type.Herd:
			dungeon.player.AddAura(new Aura(Aura.Type.PerkHerd));
			break;
		case Type.Research:
		{
			if (loaded)
			{
				break;
			}
			List<Module> tribe = dungeon.board.GetTribe(Module.Tribe.Mech, bankInlucded: true);
			List<Module> list = new List<Module>();
			foreach (Module item in tribe)
			{
				if (!(item == null) && !item.UPGRADED)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				Module module = Utils.RandElem(list);
				if (module != null && !loaded)
				{
					dungeon.board.UpgradeModule(module);
				}
			}
			break;
		}
		case Type.Unstable:
			dungeon.player.AddTrigger(new Trigger(Trigger.Ability.PerkUnstable, player.sentinel, null, 100f, 0, 1, Trigger.Type.Cast));
			break;
		case Type.Mainframe:
			player.mainframe++;
			break;
		}
		dungeon.board.CheckAuras();
	}

	public static PerkInfo GetPerkTextJP(Type t)
	{
		PerkInfo result = new PerkInfo
		{
			name = ""
		};
		switch (t)
		{
		case Type.Fortified:
			result.name = "強化";
			result.desc = "+25 マックス HP";
			break;
		case Type.Armored:
			result.name = "装甲";
			result.desc = "被 DMG 1 減少";
			break;
		case Type.Midas:
			result.name = "ミダース";
			result.desc = "キルに: 5% チャンスに $1\u3000増加";
			break;
		case Type.Vampire:
			result.name = "吸血鬼";
			result.desc = "キルに: 10% チャンスに1ヒールする";
			break;
		case Type.Regen:
			result.name = "再生";
			result.desc = "毎10秒に 5 HP\u3000ヒールする";
			break;
		case Type.Hail:
			result.name = "氷雨";
			result.desc = "毎2秒に基地がスローする氷を撃つ\n[DMG: 2 x8]";
			break;
		case Type.Focused:
			result.name = "集中的";
			result.desc = "モジュール +15% AMP +15% SPD";
			break;
		case Type.Mana:
			result.name = "マナ";
			result.desc = "全ワンド\n+1 MP/s";
			break;
		case Type.Leader:
			result.name = "首脳";
			result.desc = "一番武器\n+1 DMG";
			break;
		case Type.Conductor:
			result.name = "導体";
			result.desc = "ザップ効果\n+1バウンド";
			break;
		case Type.Bomber:
			result.name = "ボンバー";
			result.desc = "全爆発\n+20% エリア";
			break;
		case Type.Inspire:
			result.name = "インスパイア";
			result.desc = "ペット当たりペット +10% SPD";
			break;
		case Type.Mechatron:
			result.name = "マカトロン";
			result.desc = "メック五つ以上を持ったら、メカトロン呼ぶ";
			break;
		case Type.Discount:
			result.name = "割引";
			result.desc = "ショップアイテムの価格25%減少";
			break;
		case Type.Heavy:
			result.name = "重い";
			result.desc = "全アイテム +2 DMG と -50% SPD";
			break;
		case Type.Blizzard:
			result.name = "吹雪";
			result.desc = "基地近い敵にスローする爆風を撃つ\n[DMG: 2]";
			break;
		case Type.Feedback:
			result.name = "帰還";
			result.desc = "ほかのワンドの撃つにランダムなワンド +0.5 MP";
			break;
		case Type.Gigantism:
			result.name = "巨大症";
			result.desc = "一番ペット +2 DMG と +100% 大小";
			break;
		case Type.Static:
			result.name = "空電";
			result.desc = "メックがランダムな火の粉を作る\n[DMG: 3]";
			break;
		case Type.Chemicals:
			result.name = "化学品";
			result.desc = "10キルに有毒エリアを作る\n[DMG: 2]";
			break;
		case Type.Dividends:
			result.name = "配当金";
			result.desc = "+$3 ウエーブの褒美";
			break;
		case Type.Bash:
			result.name = "叩く";
			result.desc = "ヒットに:\n10%チャンスに1.5秒にスタンする";
			break;
		case Type.Splinter:
			result.name = "破片";
			result.desc = "ヒットに:\n30%チャンスに骨破片を撃つ\n[DMG: 2]";
			break;
		case Type.Topped_Up:
			result.name = "トップアップ";
			result.desc = "フル HP\u3000とき上並びのアイテム\u3000+1 DMG";
			break;
		case Type.Resurrect:
			result.name = "復活";
			result.desc = "死んだら 1回に 50% HP 持ち復活する";
			break;
		case Type.Frostbite:
			result.name = "凍傷";
			result.desc = "スローした敵に毎秒に 2 DMG 与える";
			break;
		case Type.Souldrain:
			result.name = "ソールドレン";
			result.desc = "キルにワンド +0.25 MP";
			break;
		case Type.Upsides:
			result.name = "アップサイド";
			result.desc = "全アップグレードしたアイテム +2 DMG";
			break;
		case Type.Windwalk:
			result.name = "風歩き";
			result.desc = "ワンドが撃つに1秒に全ペット +25% SPD";
			break;
		case Type.Compuwiz:
			result.name = "コンピュウィッズ";
			result.desc = "メックがネットワーク中のワンドを\u3000+1 MP/s";
			break;
		case Type.Techtrash:
			result.name = "テックゴミ";
			result.desc = "メック売ったらランダムな武器 +2 DMG";
			break;
		case Type.Restore:
			result.name = "直す";
			result.desc = "撃つにワンドは 25%チャンスに 1 ヒールする";
			break;
		case Type.Stutter:
			result.name = "吃る";
			result.desc = "毎 3秒:\n0.25秒に全敵スタンする";
			break;
		case Type.Sniper:
			result.name = "スナイパー";
			result.desc = "武器は遠い敵 +2 DMG 与える";
			break;
		case Type.Magetech:
			result.name = "メイジテック";
			result.desc = "ワンドは隣メックの与 +DMG を MP/s 等量で増加";
			break;
		case Type.Horsepower:
			result.name = "馬力";
			result.desc = "キルにペットは2秒に全メックを +1 DMG";
			break;
		case Type.Goblinized:
			result.name = "ゴブリナイズド";
			result.desc = "ショップリロールの価格 $1 減少";
			break;
		case Type.Intellect:
			result.name = "知能";
			result.desc = "ワンド +1 DMG";
			break;
		case Type.Boosters:
			result.name = "ブースター";
			result.desc = "メックは隣ペットを +40% SPD";
			break;
		case Type.Modulator:
			result.name = "変調器";
			result.desc = "モジュール +2 DMG";
			break;
		case Type.Herd:
			result.name = "群れ";
			result.desc = " ペット3匹以上いる並び +2 DMG";
			break;
		case Type.Mainframe:
			result.name = "メインフレーム";
			result.desc = "全ネットワークにメック\u3000+1";
			break;
		case Type.Research:
			result.name = "研究";
			result.desc = "ランダムなメックをアップグレードする";
			break;
		case Type.Unstable:
			result.name = "不安定";
			result.desc = "撃つにワンドが爆発を起こす";
			break;
		default:
			result.desc = "PLACEHOLDER\nNO EFFECT";
			break;
		}
		result.desc += "\n";
		return result;
	}
}
