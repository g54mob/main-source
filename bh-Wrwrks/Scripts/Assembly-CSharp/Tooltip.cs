using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
	public bool locked;

	public new TMP_Text name;

	public TMP_Text desc;

	public TMP_Text stats;

	public Module currMod;

	public Coroutine textUpdater;

	public Coroutine hider;

	public SpriteRenderer bg;

	public SpriteRenderer divider_top;

	public SpriteRenderer divider_bottom;

	public SpriteRenderer divider_tribe;

	public SpriteRenderer typeIcon;

	public Sprite[] iconList;

	public Module secretModule;

	private bool hop;

	public string statsOrigin = "";

	private static string[] jpTribes = new string[4] { "", "[<size=6.25>ペット</size>]", "[<size=6.25>メック</size>]", "[<size=6.25>ワンド</size>]" };

	public Dungeon dungeon => Dungeon.Instance;

	public Board board => Dungeon.Instance.board;

	public AnimationManager animationManager => Dungeon.Instance.animationManager;

	public static void ColorKeywords(TMP_Text txt)
	{
		foreach (var item in new List<(string, List<string>)>
		{
			("#EA323C", new List<string> { "Weapons", "Weapon", "+{0} DMG", "{0} DMG", "DMG: {DMG}", " DMG ", " DMG" }),
			("#99E65F", new List<string> { "Modules", "Module", "heals", "heal", "Heals", "Heal", "+{0} HP", "{0} HP", "HP" }),
			("#99E65F", new List<string> { "Pets", "Pet", "[PET]" }),
			("#C7CFDD", new List<string> { "Mechatron", "Mechs", "Mech", "[MECH]" }),
			("#DBDBDB", new List<string> { "AMP: {AMP}", "+{0}% AMP", "SPD: {SPD}", "+{0}% SPD", "-{0}% SPD", "+{0}% size", "-{0}% size", "+{0}% Size", "-{0}% Size" }),
			("#DBDBDB", new List<string> { "ANG: {ANG}", "KILLS: {COUNT}", "HITS: {COUNT}", "CD: {CD}", "COUNT: {COUNT}", "On Hit:", "On Kill:", "{0}s" }),
			("#00CDF9", new List<string> { "+{0} MP/s", "MP: {MP}", "{0} MP:", "Wands", "Wand", "[WAND]" }),
			("#0CF1FF", new List<string> { "Slowed", "slowed", "Slowing", "slowing", "Slows", "slows", "Slow", "slow" }),
			("#FFA214", new List<string> { "+${0}", "${0}" }),
			("#F389F5", new List<string>()),
			("#92A1B9", new List<string> { "Oil", "oil" })
		})
		{
			foreach (string item2 in item.Item2)
			{
				if (item2.Contains("{0}"))
				{
					for (int num = 100; num >= 0; num--)
					{
						txt.text = txt.text.Replace(item2.Replace("{0}", num.ToString()), "<color=" + item.Item1 + ">" + item2.Replace("{0}", num.ToString()) + "</color>");
					}
				}
				else
				{
					txt.text = txt.text.Replace(item2, "<color=" + item.Item1 + ">" + item2 + "</color>");
				}
			}
		}
		txt.text = txt.text.Replace("[g]", "<color=#FFA214>");
		txt.text = txt.text.Replace("[/g]", "</color>");
		txt.text = txt.text.Replace("[/w]", "</color>");
		txt.text = txt.text.Replace("[green]", "<color=#99E65F>");
		txt.text = txt.text.Replace("[blue]", "<color=#00CDF9>");
		txt.text = txt.text.Replace("[white]", "<color=#DBDBDB>");
		txt.text = txt.text.Replace("[red]", "<color=#EA323C>");
		txt.text = txt.text.Replace("[mech]", "<color=#C7CFDD>");
		txt.text = txt.text.Replace("[/green]", "</color>");
		SaveManager.Language language = Dungeon.Instance.saveData.language;
		if (language != SaveManager.Language.English && language == SaveManager.Language.Japanese)
		{
			ColorKeywordsJP(txt);
		}
	}

	public void Set(Module m, bool showUpgrade = false, bool noUpgrade = false, PerkDisplay perk = null, string customTitle = "", string customDesc = "", Vector3 customPos = default(Vector3), bool force = false, string customStats = "", Module specialPosMod = null)
	{
		if (dungeon.testMode)
		{
			return;
		}
		if (locked)
		{
			if (!Input.GetKeyDown(KeyCode.Mouse0))
			{
				return;
			}
			locked = false;
		}
		typeIcon.enabled = m != null;
		if (m == null)
		{
			m = secretModule;
		}
		if ((dungeon.board.previews[0].enabled && !showUpgrade) || dungeon.targeting || (m.isElevated && specialPosMod == null) || m.swapAnim)
		{
			return;
		}
		if (m.shopItem && m.upgradeHighlight.enabled)
		{
			showUpgrade = true;
		}
		if (Input.GetKey(KeyCode.Mouse0) && m != currMod && !showUpgrade && !force)
		{
			return;
		}
		if (Input.GetKey(KeyCode.Mouse0) && m == currMod && !showUpgrade && !force)
		{
			hop = false;
			return;
		}
		Database.ModuleInfo moduleInfo;
		if (customDesc != "" || customTitle != "")
		{
			moduleInfo = new Database.ModuleInfo();
			moduleInfo.name = customTitle;
			moduleInfo.desc = customDesc;
			moduleInfo.stats = customStats;
		}
		else
		{
			moduleInfo = ((perk == null) ? Database.GetModData_Localized(m) : Database.GetPerkData(perk.type));
		}
		name.text = moduleInfo.name.ToUpper();
		desc.text = moduleInfo.desc;
		string text = ((!m.UPGRADED && showUpgrade && moduleInfo.statsUpgrade != "") ? moduleInfo.statsUpgrade : moduleInfo.stats);
		desc.text = desc.text.Replace("{SPELL}", $"{m.manaCost} MP");
		List<Module.Tribe> list = moduleInfo.tribe;
		if (m != null && m.init)
		{
			list = m.tribes;
		}
		if (list.Count > 0)
		{
			if (text != "")
			{
				text += "\n";
			}
			foreach (Module.Tribe item in list)
			{
				string text2 = "";
				text2 = ((dungeon.saveData.language != SaveManager.Language.Japanese) ? ("[" + item.ToString().ToUpper() + "]") : jpTribes[(int)item]);
				text += text2;
			}
		}
		if (statsOrigin != text || m != currMod)
		{
			statsOrigin = text;
			stats.text = text;
		}
		typeIcon.sprite = iconList[(int)m.type];
		ColorKeywords(desc);
		ColorKeywords(stats);
		int num = name.text.Length + (m.UPGRADED ? 1 : 0);
		if (moduleInfo.upgrade != "" && (m.UPGRADED || showUpgrade) && !noUpgrade)
		{
			TMP_Text tMP_Text = desc;
			tMP_Text.text = tMP_Text.text + "\n<color=#FFA214>" + moduleInfo.upgrade + "</color>";
		}
		if ((m.UPGRADED || showUpgrade) && !noUpgrade)
		{
			name.text = "<color=#FFA214>" + name.text + "+</color>";
		}
		if (noUpgrade)
		{
			desc.text += "\n<color=#EA323C>NO UPGRADE</color>";
		}
		int num2 = ((dungeon.saveData.language == SaveManager.Language.Japanese) ? 7 : 11);
		if (num > num2 && desc.text != "")
		{
			bg.size = new Vector2(7.5f, 2f + desc.preferredHeight + stats.preferredHeight + 0.7f);
			typeIcon.transform.localPosition = new Vector3(-2.92f, 2.3f, 0f);
			Transform obj = divider_bottom.transform;
			Vector3 localScale = (divider_top.transform.localScale = new Vector3(103f, 1f));
			obj.localScale = localScale;
		}
		else
		{
			bg.size = new Vector2(7f, 2f + desc.preferredHeight + stats.preferredHeight + 0.7f);
			typeIcon.transform.localPosition = new Vector3(-2.67f, 2.3f, 0f);
			Transform obj2 = divider_bottom.transform;
			Vector3 localScale = (divider_top.transform.localScale = new Vector3(95f, 1f));
			obj2.localScale = localScale;
		}
		divider_bottom.transform.localPosition = divider_top.transform.localPosition;
		divider_bottom.transform.localPosition += new Vector3(0f, -0.375f);
		divider_bottom.transform.localPosition += new Vector3(0f, 0f - desc.preferredHeight);
		divider_bottom.transform.localPosition += new Vector3(0f, -0.1875f);
		stats.transform.localPosition = divider_bottom.transform.localPosition + new Vector3(0f, -0.3125f);
		if (desc.text == "")
		{
			divider_top.enabled = false;
			divider_bottom.enabled = false;
			divider_tribe.enabled = false;
			bg.size += new Vector2(-1.875f, -0.625f);
			bg.transform.localPosition = new Vector3(0f, 1.5f);
			name.transform.localPosition = new Vector3(0.0625f, 0.79999995f);
		}
		else
		{
			divider_top.enabled = true;
			divider_tribe.enabled = true;
			bg.transform.localPosition = new Vector3(0f, 3f);
			name.transform.localPosition = new Vector3(0f, 2.3f);
		}
		if (stats.text == "")
		{
			divider_bottom.enabled = false;
			bg.size += new Vector2(0f, -0.625f);
			statsOrigin = "";
		}
		else
		{
			divider_bottom.enabled = true;
		}
		if (currMod == m && perk == null && customTitle == "")
		{
			if (hider != null)
			{
				StopCoroutine(hider);
			}
		}
		else
		{
			if (textUpdater != null)
			{
				StopCoroutine(textUpdater);
			}
			if (hider != null)
			{
				StopCoroutine(hider);
			}
			if (base.transform.localScale != Vector3.zero)
			{
				animationManager.BounceZoom(base.gameObject, 0.05f, 2, modWire: false, UI: true);
			}
			textUpdater = StartCoroutine(TextUpdater(m));
			currMod = m;
			hop = false;
		}
		float num3 = 5f;
		float num4 = 0f;
		if (m.size == Module.Size.Medium)
		{
			num3 += 1.125f;
		}
		if (m.size == Module.Size.Large)
		{
			num3 += 2.25f;
		}
		if (m.shopItem)
		{
			if (m.index % 3 == 2)
			{
				num3 *= -1f;
			}
			if (m.index % 3 == 1 && m.size != Module.Size.Small)
			{
				num3 *= -1f;
			}
		}
		else if (m.bankItem)
		{
			num3 += -1f / 32f;
			if (((specialPosMod == null) ? m.index : specialPosMod.index) > 1)
			{
				num3 *= -1f;
			}
		}
		else if (m.preview)
		{
			num3 *= -1f;
		}
		else if (perk != null || customTitle != "")
		{
			num3 = 4.25f;
			num4 = -3.25f;
			if (perk != null)
			{
				if (perk.preview)
				{
					num3 *= -1f;
				}
			}
			else if (customTitle != "")
			{
				num3 *= -1f;
			}
		}
		else
		{
			int num5 = ((specialPosMod == null) ? m.index : specialPosMod.index);
			if (num5 % 5 > 2)
			{
				num3 *= -1f;
			}
			switch (num5 / 5)
			{
			case 0:
				num4 = (0f - bg.size.y) / 2f;
				break;
			case 1:
				num4 = bg.size.y / 2f;
				break;
			case 2:
				num4 = bg.size.y / 2f;
				break;
			}
			num4 = (float)(int)(num4 * 16f) / 16f;
		}
		base.transform.position = ((specialPosMod == null) ? m.transform.position : specialPosMod.transform.position) + new Vector3(num3, num4);
		if (perk != null)
		{
			base.transform.position = perk.transform.position + new Vector3(num3, num4 + 1f / 32f);
		}
		if (customTitle != "")
		{
			base.transform.position = customPos;
		}
		animationManager.LerpZoom(base.gameObject, Vector3.one, 5f, 0.1f, destroy: false, UI: true);
	}

	public void Hide(bool force = false)
	{
		if (locked)
		{
			return;
		}
		if (Input.GetKey(KeyCode.Mouse0) && !force)
		{
			hop = true;
			return;
		}
		if (hider != null)
		{
			StopCoroutine(hider);
		}
		hider = StartCoroutine(HideAnim());
	}

	private IEnumerator HideAnim()
	{
		yield return null;
		yield return null;
		animationManager.LerpZoom(base.gameObject, Vector3.zero, 5f, 0f, destroy: false, UI: true);
		currMod = null;
		if (textUpdater != null)
		{
			StopCoroutine(textUpdater);
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0) && hop)
		{
			Hide(force: true);
		}
	}

	public void ResetStats()
	{
		if (currMod == null)
		{
			return;
		}
		stats.text = Database.GetModData_Localized(currMod).stats;
		List<Module.Tribe> tribe = Database.GetModData(currMod).tribe;
		if (tribe.Count > 0)
		{
			if (stats.text != "")
			{
				stats.text += "\n";
			}
			foreach (Module.Tribe item in tribe)
			{
				TMP_Text tMP_Text = stats;
				tMP_Text.text = tMP_Text.text + "[" + item.ToString().ToUpper() + "]";
			}
		}
		StopCoroutine(textUpdater);
		textUpdater = StartCoroutine(TextUpdater(currMod));
	}

	private IEnumerator TextUpdater(Module m)
	{
		stats.text = statsOrigin;
		ColorKeywords(stats);
		string s = stats.text;
		while (!(m == null))
		{
			stats.text = s.Replace("{AMP}", Mathf.Ceil(m.amp / 4f * 100f).ToString("00") + "%");
			if ((double)(m.accel / 0.3f - (float)(int)(m.accel / 0.3f)) > 0.85)
			{
				stats.text = stats.text.Replace("{SPD}", Mathf.Ceil(m.accel / 0.3f * 100f).ToString("00") + "%");
			}
			else
			{
				stats.text = stats.text.Replace("{SPD}", Mathf.Floor(m.accel / 0.3f * 100f).ToString("00") + "%");
			}
			stats.text = stats.text.Replace("{DMG}", m.damage.ToString());
			stats.text = stats.text.Replace("{CD}", m.cooldown.ToString("0.0") + "s");
			stats.text = stats.text.Replace("{COUNT}", m.counter.ToString("0"));
			bool flag = m.upgradeHighlight.enabled && Mathf.CeilToInt(m.manaRegen) != (int)m.manaRegen;
			stats.text = stats.text.Replace("{MP}", m.mana.ToString(flag ? "0" : "0.0") + " [" + ((m.manaRegen >= 0f) ? "+" : "") + (((float)(int)m.manaRegen == m.manaRegen) ? ((int)m.manaRegen).ToString("0") : m.manaRegen.ToString("0.0")) + "/s]");
			switch (m.name)
			{
			case Module.Name.Diagonal:
			{
				float num3 = m.GetComponent<Diagonal>().angle + 180f;
				if (num3 >= 360f)
				{
					num3 -= 360f;
				}
				stats.text = stats.text.Replace("{ANG}", num3.ToString("0"));
				break;
			}
			case Module.Name.Quarter:
			{
				float num2 = m.GetComponent<Quarter>().angle + 180f;
				if (num2 >= 360f)
				{
					num2 -= 360f;
				}
				stats.text = stats.text.Replace("{ANG}", num2.ToString("0"));
				break;
			}
			case Module.Name.Point:
			{
				float num6 = m.GetComponent<Point>().angle + 180f;
				if (num6 >= 360f)
				{
					num6 -= 360f;
				}
				stats.text = stats.text.Replace("{ANG}", num6.ToString("0"));
				break;
			}
			case Module.Name.Star:
			{
				float num = m.GetComponent<Star>().angle + 180f;
				if (num >= 360f)
				{
					num -= 360f;
				}
				stats.text = stats.text.Replace("{ANG}", num.ToString("0"));
				break;
			}
			case Module.Name.Triangle:
			{
				float num5 = m.GetComponent<Triangle>().angle + 180f;
				if (num5 >= 360f)
				{
					num5 -= 360f;
				}
				stats.text = stats.text.Replace("{ANG}", num5.ToString("0"));
				break;
			}
			case Module.Name.Shuriken:
			{
				float t = m.amp / m.GetComponent<Horizontal>().maxAmp;
				float num4 = Mathf.Lerp(5f, 25f, t);
				stats.text = stats.text.Replace("{ANG}", num4.ToString("0"));
				break;
			}
			case Module.Name.Blade:
				stats.text = stats.text.Replace("{CRIT}", m.counter * 10 + (m.UPGRADED ? 15 : 0) + "%");
				break;
			}
			yield return null;
		}
	}

	public static void ColorKeywordsJP(TMP_Text txt)
	{
		foreach (var item in new List<(string, List<string>)>
		{
			("#EA323C", new List<string> { "武器" }),
			("#99E65F", new List<string> { "+{0} ヒール", "+{0}ヒール", "ヒール", "モジュール" }),
			("#99E65F", new List<string> { "[<size=6.25>ペット</size>]", "ペット" }),
			("#C7CFDD", new List<string> { "[<size=6.25>メック</size>]", "メック" }),
			("#DBDBDB", new List<string> { "ヒットに", "キルに", "ヒットに:", "キルに:" }),
			("#DBDBDB", new List<string> { "ザップ", "{0}秒", "大小" }),
			("#00CDF9", new List<string> { "[<size=6.25>ワンド</size>]", "ワンド" }),
			("#0CF1FF", new List<string> { "スロー" }),
			("#FFA214", new List<string>()),
			("#F389F5", new List<string>()),
			("#92A1B9", new List<string>())
		})
		{
			foreach (string item2 in item.Item2)
			{
				if (item2.Contains("{0}"))
				{
					for (int num = 100; num >= 0; num--)
					{
						txt.text = txt.text.Replace(item2.Replace("{0}", num.ToString()), "<color=" + item.Item1 + ">" + item2.Replace("{0}", num.ToString()) + "</color>");
					}
				}
				else
				{
					txt.text = txt.text.Replace(item2, "<color=" + item.Item1 + ">" + item2 + "</color>");
				}
			}
		}
	}
}
