using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public List<Module> modules = new List<Module>();

	public TMP_Text[] texts;

	public GameObject sellScreen;

	public List<Module.Name> commonWep;

	public List<Module.Name> commonMod;

	public List<Module.Name> uncommonWep;

	public List<Module.Name> uncommonMod;

	public List<Module.Name> rareWep;

	public List<Module.Name> rareMod;

	public List<Module.Name> epicWep;

	public List<Module.Name> epicMod;

	public List<Module.Name> GenericItems;

	public List<Module.Name> Mechs;

	public List<Module.Name> Pets;

	public List<Module.Name> Wands;

	public List<Module.Name> cMech;

	public List<Module.Name> cWand;

	public List<Module.Name> cPet;

	public List<Module.Name> rMech;

	public List<Module.Name> rWand;

	public List<Module.Name> rPet;

	public List<Module.Name> Tokens;

	private int _rsP = 1;

	public UIButton restockButton;

	public UIButton lockButton;

	public bool locked;

	public Sprite lockSprite;

	public Sprite unlockSprite;

	public SpriteRenderer lockIndicator;

	private List<Module.Name> prevStock = new List<Module.Name>();

	public Dungeon dungeon => Dungeon.Instance;

	public int restockPrice
	{
		get
		{
			return _rsP;
		}
		set
		{
			_rsP = value;
			restockButton.text.text = $"[${restockPrice}]";
			restockButton.text.color = ((dungeon.gold < restockPrice) ? Utils.GetColor("2A2F4E") : Utils.GetColor("C7CFDD"));
			restockButton.bg.sprite = ((dungeon.gold < restockPrice) ? dungeon.currentLocale.rerollButtonPoor : dungeon.currentLocale.rerollButton);
		}
	}

	public int baseRestockPrice
	{
		get
		{
			int num = dungeon.board.CountAuras(Aura.Type.RerollDiscount);
			return Mathf.Max(3 - num, 0);
		}
		set
		{
		}
	}

	private void Start()
	{
		InitRarities();
	}

	public void InitRarities()
	{
		for (int i = 0; i < 141; i++)
		{
			if (dungeon.moduleObjects[i] == null)
			{
				continue;
			}
			Module component = dungeon.moduleObjects[i].GetComponent<Module>();
			Database.ModuleInfo modData = Database.GetModData(component);
			if (modData.tribe.Count == 0)
			{
				GenericItems.Add(component.name);
			}
			else if (modData.tribe.Contains(Module.Tribe.Wand))
			{
				Wands.Add(component.name);
			}
			else if (modData.tribe.Contains(Module.Tribe.Mech))
			{
				Mechs.Add(component.name);
			}
			else if (modData.tribe.Contains(Module.Tribe.Pet))
			{
				Pets.Add(component.name);
			}
			if (component.TOKEN)
			{
				Tokens.Add(component.name);
			}
			else
			{
				if (Module.movementMods.Contains(component.name) || Module.wireMods.Contains(component.name))
				{
					continue;
				}
				if (modData.price <= 10)
				{
					if (component.type == Module.Type.Weapon)
					{
						if (modData.tribe.Contains(Module.Tribe.Wand))
						{
							cWand.Add(component.name);
						}
						if (modData.tribe.Contains(Module.Tribe.Pet))
						{
							cPet.Add(component.name);
						}
						if (modData.tribe.Contains(Module.Tribe.Mech))
						{
							cMech.Add(component.name);
						}
						commonWep.Add((Module.Name)i);
					}
					else
					{
						commonMod.Add((Module.Name)i);
					}
				}
				else if (component.type == Module.Type.Weapon)
				{
					if (modData.tribe.Contains(Module.Tribe.Wand))
					{
						rWand.Add(component.name);
					}
					if (modData.tribe.Contains(Module.Tribe.Pet))
					{
						rPet.Add(component.name);
					}
					if (modData.tribe.Contains(Module.Tribe.Mech))
					{
						rMech.Add(component.name);
					}
					rareWep.Add((Module.Name)i);
				}
				else
				{
					rareMod.Add((Module.Name)i);
				}
			}
		}
	}

	public void Sell(Module m)
	{
		dungeon.gold += m.sellPrice;
		dungeon.audioManager.PlaySound(AudioManager.Sound.Gold);
		dungeon.board.UnhighlightShopUpgrades();
		CheckPrices();
		StartCoroutine(seller(m));
	}

	private IEnumerator seller(Module m)
	{
		m.GetComponent<BoxCollider2D>().enabled = false;
		dungeon.animationManager.LerpZoom(m.gameObject, Vector3.zero, 5f);
		dungeon.board.TriggerModules(Trigger.Type.Sell, m);
		yield return Dungeon.Wait(6);
		Object.Destroy(m.gameObject);
	}

	public void ShowSell(Module m)
	{
		sellScreen.SetActive(value: true);
		sellScreen.GetComponentInChildren<TMP_Text>().text = $"${m.sellPrice}";
		if (dungeon.toggleStateButton.bg.sprite == dungeon.shopIcon)
		{
			dungeon.board.StateSell.SetActive(value: true);
			dungeon.board.StateSell.GetComponentInChildren<TMP_Text>().text = $"${m.sellPrice}";
		}
	}

	public void HideSell()
	{
		sellScreen.SetActive(value: false);
		if (dungeon.toggleStateButton.bg.sprite == dungeon.shopIcon)
		{
			dungeon.board.StateSell.SetActive(value: false);
		}
	}

	public bool Purchase(Module m)
	{
		if (dungeon.gold < m.shopPrice)
		{
			return false;
		}
		dungeon.audioManager.PlaySound(AudioManager.Sound.Buy);
		m.shopItem = false;
		texts[m.index].color = Utils.GetColor("2A2F4E");
		texts[m.index].text = "SOLD";
		modules.Remove(m);
		dungeon.gold -= m.shopPrice;
		CheckPrices();
		return true;
	}

	public void ShowTip(Vector3 pos)
	{
		Vector3 customPos = pos + new Vector3(-5.625f + (locked ? (-0.75f) : 0f), -1.21875f);
		(string, string, string) buttonTip = dungeon.localizationManager.GetButtonTip(UIButton.func.ShopLock);
		dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, null, buttonTip.Item1, buttonTip.Item2, customPos);
	}

	public void ToggleLock(bool noSound = false)
	{
		if (!noSound)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.75f);
		}
		locked = !locked;
		dungeon.tooltip.Hide();
		lockIndicator.enabled = locked;
		if (locked)
		{
			StartCoroutine(bounce(lockIndicator.gameObject, 2));
			lockButton.GetComponent<BoxCollider2D>().size = new Vector2(3.9569316f, 1.212769f);
			lockButton.GetComponent<BoxCollider2D>().offset = new Vector2(-0.43717653f, -0.026230931f);
		}
		else
		{
			lockButton.GetComponent<BoxCollider2D>().size = new Vector2(3.1874886f, 1.212769f);
			lockButton.GetComponent<BoxCollider2D>().offset = new Vector2(-0.05245489f, -0.026230931f);
		}
		lockButton.bg.sprite = (locked ? dungeon.currentLocale.unlockShop : dungeon.currentLocale.lockShop);
	}

	private IEnumerator TempDisable(Module m)
	{
		if (!(m == null))
		{
			m.GetComponent<Collider2D>().enabled = false;
			yield return Dungeon.Wait(15);
			if (!(m == null))
			{
				m.GetComponent<Collider2D>().enabled = true;
			}
		}
	}

	public static IEnumerator bounce(GameObject m, int f = 3)
	{
		m.transform.localPosition += new Vector3(0f, (float)f / 16f);
		for (int i = 0; i < f; i++)
		{
			yield return Dungeon.Wait(1);
			m.transform.localPosition -= new Vector3(0f, 0.0625f);
		}
	}

	private List<Module.Name> GetWeaponPool(float commonChance, float epicChance = 0f)
	{
		if (!Utils.RNG(commonChance))
		{
			if (!Utils.RNG(epicChance))
			{
				return new List<Module.Name>(rareWep);
			}
			return new List<Module.Name>(epicWep);
		}
		return new List<Module.Name>(commonWep);
	}

	private List<Module.Name> GetModPool(float commonChance, float epicChance = 0f)
	{
		if (!Utils.RNG(commonChance))
		{
			if (!Utils.RNG(epicChance))
			{
				return new List<Module.Name>(rareMod);
			}
			return new List<Module.Name>(epicMod);
		}
		return new List<Module.Name>(commonMod);
	}

	public List<Module.Name> GetNewStock()
	{
		float num = Mathf.Ceil(100f * (float)commonWep.Count / (float)(commonWep.Count + rareWep.Count));
		float num2 = Mathf.Ceil(100f * (float)commonMod.Count / (float)(commonMod.Count + rareMod.Count));
		float num3 = (100f - num) / 10f;
		if (dungeon.demo)
		{
			num3 = (100f - num) / 5f;
			num2 -= num3 * 2f;
			num -= num3 * 2f;
		}
		else
		{
			num2 -= num3 * 2f;
			num -= num3 * 2f;
		}
		float a = 100f - (float)(dungeon.currLevel - 1) * num3;
		float commonChance = Mathf.Max(a, num);
		float commonChance2 = Mathf.Max(a, num2);
		List<Module.Name> list = GetWeaponPool(commonChance);
		List<Module.Name> list2 = GetWeaponPool(commonChance);
		List<Module.Name> list3 = GetModPool(commonChance2);
		List<Module.Name> list4 = GetModPool(commonChance2);
		List<Module.Name> list5 = new List<Module.Name>(Module.movementMods);
		List<Module.Name> list6 = new List<Module.Name>(Module.wireMods);
		if (dungeon.demo)
		{
			list5 = new List<Module.Name>(Module.demoMovs);
			list6 = new List<Module.Name>(Module.demoWire);
		}
		if (dungeon.currLevel == 1)
		{
			list5.Remove(Module.Name.Horizontal);
			list5.Remove(Module.Name.Vertical);
			list5.Remove(Module.Name.Point);
			list5.Remove(Module.Name.Quarter);
		}
		if (dungeon.currLevel <= 10 && !dungeon.demo && Utils.RNG(80f - (float)dungeon.currLevel * 5f))
		{
			list6.Remove(Module.Name.MergeTriple);
			list6.Remove(Module.Name.SplitTriple);
			list6.Remove(Module.Name.MixerTriple);
		}
		if (dungeon.currLevel > 20 && !dungeon.demo)
		{
			list6.Remove(Module.Name.Merger);
			list6.Remove(Module.Name.Splitter);
			list6.Remove(Module.Name.Mixer);
		}
		List<Module.Name> list7 = new List<Module.Name>();
		List<Module> board = dungeon.board.GetBoard();
		board.AddRange(dungeon.bank.GetBank());
		foreach (Module item3 in board)
		{
			if (item3.name != Module.Name.Rat && item3.UPGRADED)
			{
				list7.Add(item3.name);
			}
		}
		int num4 = 0;
		bool flag;
		List<Module.Name> list8;
		do
		{
			flag = false;
			list5 = Utils.Shuffle(list5);
			list = Utils.Shuffle(list);
			list2 = Utils.Shuffle(list2);
			if (!dungeon.saveData.tutorials[1] && dungeon.currLevel == 1)
			{
				bool flag2 = false;
				foreach (Module item4 in dungeon.board.GetBoard())
				{
					if (item4.name == Module.Name.Sword && !item4.UPGRADED)
					{
						flag2 = true;
					}
				}
				if (list[0] != Module.Name.Sword && flag2)
				{
					if (list2[0] == Module.Name.Sword)
					{
						list2[0] = list2[1];
					}
					list[0] = Module.Name.Sword;
					if (num4 == 0)
					{
						dungeon.saveManager.PopupTutorial(1);
					}
				}
			}
			list3 = Utils.Shuffle(list3);
			list4 = Utils.Shuffle(list4);
			list6 = Utils.Shuffle(list6);
			if (list3.Count == 0)
			{
				list3 = (Utils.RNG(50f) ? new List<Module.Name>(commonMod) : new List<Module.Name>(rareMod));
			}
			if (list4.Count == 0)
			{
				list4 = (Utils.RNG(50f) ? new List<Module.Name>(commonMod) : new List<Module.Name>(rareMod));
			}
			if (list.Count == 0)
			{
				list = (Utils.RNG(50f) ? new List<Module.Name>(commonWep) : new List<Module.Name>(rareWep));
			}
			if (list2.Count == 0)
			{
				list2 = (Utils.RNG(50f) ? new List<Module.Name>(commonWep) : new List<Module.Name>(rareWep));
			}
			Module.Name item = ((Utils.RNG(Mathf.Max(25, 77 - 2 * dungeon.currLevel)) || dungeon.currLevel <= 2) ? list5[1] : list4[0]);
			Module.Name item2 = list6[0];
			list8 = new List<Module.Name>
			{
				list[0],
				list2[0],
				list3[0],
				item,
				list5[0],
				item2
			};
			List<Module.Name> list9 = new List<Module.Name>();
			foreach (Module.Name item5 in list8)
			{
				if (list7.Contains(item5))
				{
					flag = true;
				}
				if (list9.Contains(item5))
				{
					flag = true;
				}
				list9.Add(item5);
				if (prevStock.Contains(item5))
				{
					flag = true;
				}
			}
		}
		while (flag && num4++ < 1000);
		prevStock = new List<Module.Name>(list8);
		return list8;
	}

	public void Restock(bool first = true)
	{
		if (!first)
		{
			restockPrice = baseRestockPrice;
			if (dungeon.gold < restockPrice)
			{
				return;
			}
			dungeon.audioManager.PlaySound(AudioManager.Sound.Buy);
			dungeon.gold -= restockPrice;
			dungeon.board.TriggerModules(Trigger.Type.Reroll);
			dungeon.board.CheckAuras();
			if (locked)
			{
				ToggleLock(noSound: true);
			}
		}
		else
		{
			restockPrice = baseRestockPrice;
			if (locked)
			{
				ToggleLock(noSound: true);
				return;
			}
		}
		restockButton.text.text = $"[${restockPrice}]";
		restockButton.text.color = ((dungeon.gold < restockPrice) ? Utils.GetColor("2A2F4E") : Utils.GetColor("C7CFDD"));
		restockButton.bg.sprite = ((dungeon.gold < restockPrice) ? dungeon.currentLocale.rerollButtonPoor : dungeon.currentLocale.rerollButton);
		StopAllCoroutines();
		foreach (Module module in modules)
		{
			Object.Destroy(module.gameObject);
		}
		modules.Clear();
		List<Module.Name> newStock = GetNewStock();
		int num = dungeon.board.CountAuras(Aura.Type.PerkDiscount);
		float num2 = ((dungeon.currLevel >= 15) ? Mathf.Min(50, 5 + 3 * (dungeon.currLevel - 15)) : 0);
		for (int i = 0; i < 6; i++)
		{
			if (newStock[i] != Module.Name._COUNT)
			{
				Module component = Object.Instantiate(dungeon.moduleObjects[(int)newStock[i]]).GetComponent<Module>();
				if (!dungeon.saveData.collection.Contains(component.name))
				{
					dungeon.saveData.collection.Add(component.name);
				}
				component.transform.parent = base.transform;
				component.transform.localPosition = new Vector3(-4.53125f + 4.5f * (float)(i % 3), 2.28125f + -4.5f * (float)(i / 3), -1f);
				component.transform.localScale = Vector3.one;
				component.shopItem = true;
				Database.ModuleInfo modData = Database.GetModData(component);
				component.shopPrice = (int)((float)modData.price * Mathf.Pow(0.75f, num));
				component.tribes = new List<Module.Tribe>(modData.tribe);
				if (num2 > 0f && Utils.RNG(num2))
				{
					component.ShopUp();
				}
				texts[i].text = $"${component.shopPrice}";
				component.index = i;
				modules.Add(component);
				if (first)
				{
					StartCoroutine(TempDisable(component));
				}
			}
		}
		if (!first)
		{
			foreach (Module module2 in modules)
			{
				StartCoroutine(bounce(module2.gameObject));
			}
			dungeon.saveManager.SaveRunData();
		}
		dungeon.board.UnhighlightAllUpgrades();
		CheckPrices();
	}

	public void LoadStock(List<Module.Name> mods, List<bool> shopUpg)
	{
		restockPrice = baseRestockPrice;
		foreach (Module module in modules)
		{
			Object.Destroy(module.gameObject);
		}
		modules.Clear();
		restockButton.text.text = $"[${restockPrice}]";
		restockButton.text.color = ((dungeon.gold < restockPrice) ? Utils.GetColor("2A2F4E") : Utils.GetColor("C7CFDD"));
		restockButton.bg.sprite = ((dungeon.gold < restockPrice) ? dungeon.currentLocale.rerollButtonPoor : dungeon.currentLocale.rerollButton);
		int num = dungeon.board.CountAuras(Aura.Type.PerkDiscount);
		for (int i = 0; i < 6; i++)
		{
			if (mods[i] == Module.Name._COUNT)
			{
				texts[i].text = "SOLD";
				texts[i].color = Utils.GetColor("2A2F4E");
				continue;
			}
			Module component = Object.Instantiate(dungeon.moduleObjects[(int)mods[i]]).GetComponent<Module>();
			if (!dungeon.saveData.collection.Contains(component.name))
			{
				dungeon.saveData.collection.Add(component.name);
			}
			component.transform.parent = base.transform;
			component.transform.localPosition = new Vector3(-4.53125f + 4.5f * (float)(i % 3), 2.28125f + -4.5f * (float)(i / 3), -1f);
			component.transform.localScale = Vector3.one;
			component.shopItem = true;
			Database.ModuleInfo modData = Database.GetModData(component);
			component.shopPrice = (int)((float)modData.price * Mathf.Pow(0.75f, num));
			component.tribes = new List<Module.Tribe>(modData.tribe);
			if (shopUpg[i])
			{
				component.ShopUp();
			}
			texts[i].text = $"${component.shopPrice}";
			component.index = i;
			modules.Add(component);
			StartCoroutine(TempDisable(component));
		}
		prevStock = new List<Module.Name>(mods);
		dungeon.board.UnhighlightAllUpgrades();
		CheckPrices();
	}

	public void HighlightUpgrades()
	{
		bool flag = false;
		foreach (Module module2 in dungeon.shop.modules)
		{
			if (module2.shopUpped)
			{
				continue;
			}
			foreach (Module module3 in dungeon.board.modules)
			{
				if (!(module3 == null) && module3.name == module2.name && !module3.UPGRADED)
				{
					module3.HighlightUpgrade();
					module2.HighlightUpgrade();
				}
			}
			Module[] array = dungeon.bank.modules;
			foreach (Module module in array)
			{
				if (!(module == null) && !(module == module2) && module.name == module2.name && !module.UPGRADED && !module2.UPGRADED)
				{
					if (!module2.WIREMOD)
					{
						flag = true;
					}
					module.HighlightUpgrade();
					module2.HighlightUpgrade();
				}
			}
		}
		if (flag)
		{
			dungeon.board.ShowStateUpgrade();
		}
	}

	public void CheckPrices()
	{
		foreach (Module module in modules)
		{
			HighlightUpgrades();
			if (module.shopPrice > dungeon.gold)
			{
				texts[module.index].color = Utils.GetColor("2A2F4E");
			}
			else
			{
				texts[module.index].color = Utils.GetColor("C7CFDD");
			}
		}
		restockButton.text.color = ((dungeon.gold < restockPrice) ? Utils.GetColor("2A2F4E") : Utils.GetColor("C7CFDD"));
		restockButton.bg.sprite = ((dungeon.gold < restockPrice) ? dungeon.currentLocale.rerollButtonPoor : dungeon.currentLocale.rerollButton);
	}
}
