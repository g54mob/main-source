using System.Collections.Generic;
using UnityEngine;

public class CraftBookScreen : BaseBookScreen
{
	private class PageData
	{
		public List<AsciiString> entryNames = new List<AsciiString>(4);

		public List<AsciiSprite> iconsA = new List<AsciiSprite>(4);

		public List<AsciiSprite> iconsB = new List<AsciiSprite>(4);

		public List<AsciiSprite> iconsResult = new List<AsciiSprite>(4);

		public List<bool> showStar = new List<bool>(4);

		public int entryCountToDisplay;

		public int pageAdjustY;
	}

	private static bool DEBUG_SHOW_ALL;

	public AsciiSprite itemFrame;

	public Color operatorColor = ColorConstants.thirdGrey;

	public AsciiString instructionsHeader;

	public AsciiTextBox ruleAString;

	public AsciiTextBox ruleBString;

	public AsciiTextBox ruleCString;

	public AsciiString always;

	public AsciiString be;

	public AsciiString crafting;

	private List<PageData> pageData = new List<PageData>();

	private List<string> discoveredCrafts = new List<string>();

	private List<string> allDataEntryIds;

	private int amountFoundNum;

	private Dictionary<string, bool> knownItems = new Dictionary<string, bool>();

	public static CraftBookScreen singleton { get; private set; }

	protected override int GetContentDiscovered()
	{
		return amountFoundNum;
	}

	protected override int GetTotalContentAmount()
	{
		int num = 0;
		for (int i = 0; i < ItemFactory.singleton.craftBookPages.Length; i++)
		{
			CraftPage craftPage = ItemFactory.singleton.craftBookPages[i];
			for (int j = 0; j < craftPage.entries.Count; j++)
			{
				if (craftPage.entries[j].IsEnabled())
				{
					num++;
				}
			}
		}
		return num;
	}

	protected override int GetPageCount()
	{
		return ItemFactory.singleton.craftBookPages.Length + 2;
	}

	public override void Show()
	{
		PreProcessKnownItems();
		InitEntryCount();
		base.Show();
	}

	protected override void UpdateContentForPage(int index)
	{
		if (index == 0)
		{
			return;
		}
		index--;
		if (index >= ItemFactory.singleton.craftBookPages.Length)
		{
			return;
		}
		CraftPage craftPage = ItemFactory.singleton.craftBookPages[index];
		PageData pageData;
		if (index < this.pageData.Count)
		{
			pageData = this.pageData[index];
		}
		else
		{
			pageData = new PageData();
			this.pageData.Add(pageData);
		}
		pageData.entryNames.Clear();
		pageData.iconsA.Clear();
		pageData.iconsB.Clear();
		pageData.iconsResult.Clear();
		pageData.showStar.Clear();
		pageData.entryCountToDisplay = 0;
		if (craftPage == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < craftPage.entries.Count; i++)
		{
			if (craftPage.entries[i].IsEnabled())
			{
				num++;
			}
		}
		pageData.pageAdjustY = 0;
		switch (num)
		{
		case 4:
			pageData.pageAdjustY = -7;
			break;
		case 3:
			pageData.pageAdjustY = -5;
			break;
		case 2:
			pageData.pageAdjustY = -2;
			break;
		}
		for (int j = 0; j < craftPage.entries.Count; j++)
		{
			CraftEntry craftEntry = craftPage.entries[j];
			bool flag = HasDiscovered(craftEntry) || DEBUG_SHOW_ALL;
			bool flag2 = true;
			if (!flag)
			{
				flag2 = IsKnown(craftEntry);
			}
			if ((!flag && !flag2) || !craftEntry.IsEnabled())
			{
				continue;
			}
			pageData.entryCountToDisplay++;
			Item item = null;
			if (!string.IsNullOrEmpty(craftEntry.result))
			{
				item = ItemFactory.singleton.GetPrefabForId(craftEntry.result);
			}
			string value;
			if (string.IsNullOrEmpty(craftEntry.name_override))
			{
				if (item != null)
				{
					string inStr = (craftEntry.element_result ? "Runestone" : "tid_replacement_stone");
					inStr = Te.xt(inStr);
					value = Te.xt(item.displayName).Replace("<element>", inStr);
				}
				else
				{
					value = "?";
				}
			}
			else
			{
				value = Te.xt(craftEntry.name_override);
			}
			AsciiString asciiString = new AsciiString();
			asciiString.alignment = AsciiString.Alignment.Center;
			asciiString.SetValue(value);
			pageData.entryNames.Add(asciiString);
			if (item != null)
			{
				pageData.iconsResult.Add(LoadIcon(item.iconPath, craftEntry.element_result));
			}
			else
			{
				pageData.iconsResult.Add(null);
			}
			if (flag)
			{
				Item item2 = null;
				if (!string.IsNullOrEmpty(craftEntry.itemA))
				{
					item2 = ItemFactory.singleton.GetPrefabForId(craftEntry.itemA);
				}
				if (item2 != null)
				{
					pageData.iconsA.Add(LoadIcon(item2.iconPath, craftEntry.elementA));
				}
				else
				{
					pageData.iconsA.Add(null);
				}
				Item item3 = null;
				if (!string.IsNullOrEmpty(craftEntry.itemB))
				{
					item3 = ItemFactory.singleton.GetPrefabForId(craftEntry.itemB);
				}
				if (item3 != null)
				{
					pageData.iconsB.Add(LoadIcon(item3.iconPath, craftEntry.elementB));
				}
				else
				{
					pageData.iconsB.Add(null);
				}
			}
			else
			{
				pageData.iconsA.Add(null);
				pageData.iconsB.Add(null);
			}
			pageData.showStar.Add(craftEntry.itemA == craftEntry.itemB);
		}
	}

	private AsciiSprite LoadIcon(string iconPath, bool element)
	{
		if (element)
		{
			return IconLoader.Singleton.GetSharedIcon(iconPath, 'o', ItemData.CharForElement(ItemData.Element.Vigor));
		}
		return IconLoader.Singleton.GetSharedIcon(iconPath);
	}

	protected override void DrawPageContents(AsciiRenderProcedural r, int offsetX, int offsetY, int index)
	{
		if (index == 0)
		{
			return;
		}
		if (index - 1 < this.pageData.Count)
		{
			PageData pageData = this.pageData[index - 1];
			for (int i = 0; i < pageData.entryCountToDisplay; i++)
			{
				int num = offsetY + i * 5 + pageData.pageAdjustY;
				pageData.entryNames[i].Draw(r, offsetX - 15, num);
				int num2 = offsetX + 10;
				r.SetCell(num2, num, 43, operatorColor);
				r.SetCell(num2 + 10, num, 61, operatorColor);
				DrawItemIcon(r, num2 - 5, num, pageData.iconsA[i]);
				DrawItemIcon(r, num2 + 5, num, pageData.iconsB[i]);
				DrawItemIcon(r, num2 + 15, num, pageData.iconsResult[i]);
				if (pageData.showStar[i])
				{
					r.SetCell(num2 + 15, num + 2, SpecialSymbols.Map('☆'), ColorConstants.white);
				}
			}
			return;
		}
		int num3 = ruleAString.lineCount + ruleBString.lineCount + ruleCString.lineCount;
		int num4 = offsetX - 15;
		int num5 = offsetY - 8;
		instructionsHeader.Draw(r, num4, num5);
		num4 -= 11;
		num5 += 2;
		if (num3 <= 13)
		{
			num5++;
		}
		ruleAString.Draw(r, num4, num5);
		num5 += 1 + ruleAString.lineCount;
		if (num3 <= 11)
		{
			num5++;
		}
		ruleBString.Draw(r, num4, num5);
		num5 += 1 + ruleBString.lineCount;
		if (num3 <= 11)
		{
			num5++;
		}
		ruleCString.Draw(r, num4, num5);
		always.Draw(r, offsetX, offsetY);
		be.Draw(r, offsetX, offsetY);
		crafting.Draw(r, offsetX, offsetY);
	}

	private void DrawItemIcon(AsciiRenderProcedural r, int offsetX, int offsetY, AsciiSprite icon)
	{
		if (icon != null)
		{
			itemFrame.Draw(r, offsetX, offsetY);
			icon.Draw(r, offsetX, offsetY);
		}
		else
		{
			r.SetCell(offsetX, offsetY, 63, ColorConstants.white);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
	}

	private void InitEntryCount()
	{
		if (allDataEntryIds == null)
		{
			allDataEntryIds = new List<string>();
			for (int i = 0; i < ItemFactory.singleton.craftBookPages.Length; i++)
			{
				CraftPage craftPage = ItemFactory.singleton.craftBookPages[i];
				for (int j = 0; j < craftPage.entries.Count; j++)
				{
					CraftEntry entry = craftPage.entries[j];
					string uniqueIdForEntry = GetUniqueIdForEntry(entry);
					allDataEntryIds.Add(uniqueIdForEntry);
				}
			}
		}
		amountFoundNum = 0;
		for (int k = 0; k < allDataEntryIds.Count; k++)
		{
			if (DEBUG_SHOW_ALL || discoveredCrafts.Contains(allDataEntryIds[k]))
			{
				amountFoundNum++;
			}
		}
		if (amountFoundNum >= GetTotalContentAmount())
		{
			AchievementController.singleton.ReportAllCraftRecipiesDiscovered();
		}
	}

	public void ReportCraft(ItemFactory.Result result)
	{
		string uniqueIdForCraftResult = GetUniqueIdForCraftResult(result);
		if (!discoveredCrafts.Contains(uniqueIdForCraftResult))
		{
			discoveredCrafts.Add(uniqueIdForCraftResult);
		}
	}

	public bool HasDiscovered(CraftEntry entry)
	{
		return discoveredCrafts.Contains(GetUniqueIdForEntry(entry));
	}

	private void PreProcessKnownItems()
	{
		knownItems.Clear();
		List<Item> allItems = Inventory.Singleton.GetAllItems();
		for (int i = 0; i < allItems.Count; i++)
		{
			Item item = allItems[i];
			if (!(item == null))
			{
				string key = AttachE(item.id, item.element != ItemData.Element.Stone);
				if (!knownItems.ContainsKey(key))
				{
					knownItems.Add(key, value: true);
				}
			}
		}
	}

	public bool IsKnown(CraftEntry entry)
	{
		return knownItems.ContainsKey(AttachE(entry.result, entry.element_result));
	}

	private string GetUniqueIdForCraftResult(ItemFactory.Result result)
	{
		if (result.itemA == result.itemB)
		{
			return "sword_sword_sword";
		}
		string text = AttachE(result.itemA.id, result.itemA.element != ItemData.Element.Stone);
		text = ((string.CompareOrdinal(result.itemA.id, result.itemB.id) >= 0) ? (AttachE(result.itemB.id, result.itemB.element != ItemData.Element.Stone) + "_" + text) : (text + "_" + AttachE(result.itemB.id, result.itemB.element != ItemData.Element.Stone)));
		return text = text + "_" + AttachE(result.resultingItem.id, result.resultingItem.element != ItemData.Element.Stone);
	}

	private string GetUniqueIdForEntry(CraftEntry entry)
	{
		string text = AttachE(entry.itemA, entry.elementA);
		text = ((string.CompareOrdinal(entry.itemA, entry.itemB) >= 0) ? (AttachE(entry.itemB, entry.elementB) + "_" + text) : (text + "_" + AttachE(entry.itemB, entry.elementB)));
		return text + "_" + AttachE(entry.result, entry.element_result);
	}

	private string GetResultIdForEntry(CraftEntry entry)
	{
		return AttachE(entry.result, entry.element_result);
	}

	private string AttachE(string itemId, bool hasElement)
	{
		if (hasElement)
		{
			return itemId + "_e";
		}
		return itemId;
	}

	public void ClearProgress()
	{
		discoveredCrafts.Clear();
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("discovered_crafts", discoveredCrafts.ToArray());
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			string[] collection = SlimJson.ParseArray(sjson, "discovered_crafts");
			discoveredCrafts = new List<string>(collection);
		}
	}
}
