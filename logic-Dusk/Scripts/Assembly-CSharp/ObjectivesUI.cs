using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ObjectivesUI : MonoBehaviour
{
	public class CategoryItem
	{
		public string Key { get; set; }

		public string Name { get; set; }

		public UITextItem CatUIItem { get; set; }

		public EntryTypeEnum EntryType { get; set; }

		public List<EntryItem> EntryItemList { get; set; }

		public CategoryItem(EntryTypeEnum entryType, string key, UITextItem item)
		{
			EntryType = entryType;
			Key = key;
			CatUIItem = item;
			EntryItemList = new List<EntryItem>();
		}
	}

	public class EntryItem
	{
		public CategoryItem Parent { get; private set; }

		public string Key { get; set; }

		public string Name { get; set; }

		public UITextItem EntryUIItem { get; set; }

		public EntryItem(CategoryItem parentCat, string key, UITextItem item)
		{
			Parent = parentCat;
			Key = key;
			EntryUIItem = item;
		}
	}

	public static ObjectivesUI Instance;

	public UIObjectiveList categoryList;

	public UIObjectiveList objectiveList;

	public ReaderUI reader;

	private Dictionary<string, CategoryItem> categoryDict;

	private static int catIndex = -1;

	private static int itemIndex = -1;

	private static int listIndex;

	public bool IsShowing { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		base.gameObject.SetActive(false);
	}

	public void Reset(EntryTypeEnum entryType, bool onlyItems)
	{
		if (categoryDict == null || categoryDict.Count <= 0)
		{
			return;
		}
		Dictionary<string, CategoryItem>.Enumerator enumerator = categoryDict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value.EntryType != entryType)
			{
				continue;
			}
			int count = enumerator.Current.Value.EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				UITextItem entryUIItem = enumerator.Current.Value.EntryItemList[i].EntryUIItem;
				if (entryUIItem != null && entryUIItem.UnderlyingGameObject != null)
				{
					Object.Destroy(entryUIItem.UnderlyingGameObject);
				}
			}
			enumerator.Current.Value.EntryItemList.Clear();
		}
		if (!onlyItems)
		{
			categoryDict.Clear();
		}
	}

	public void SetVisibility()
	{
		base.gameObject.SetActive(true);
		int num = catIndex;
		int newItemIndex = itemIndex;
		Refresh();
		HideAll();
		MoveToTop();
		if (num > -1)
		{
			MoveToCatAndItem(num, newItemIndex);
		}
		if (listIndex == 1)
		{
			categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearHighlight();
			categoryDict.ElementAt(catIndex).Value.CatUIItem.Select();
			itemIndex = -1;
			int count = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				if (categoryDict.ElementAt(catIndex).Value.EntryItemList[i].EntryUIItem.IsSelected)
				{
					itemIndex = i;
					break;
				}
			}
			categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.ClearSelection();
			categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Highlight();
		}
		IsShowing = true;
	}

	private void HideAll()
	{
		if (categoryDict == null || categoryDict.Count <= 0)
		{
			return;
		}
		Dictionary<string, CategoryItem>.Enumerator enumerator = categoryDict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int count = enumerator.Current.Value.EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				enumerator.Current.Value.EntryItemList[i].EntryUIItem.Hide();
			}
		}
	}

	public void Hide()
	{
		GameAudio.Play2DSFX(GameAudio.SoundEnum.UIExitMenu);
		if (categoryDict != null && categoryDict.Count > 0)
		{
			Dictionary<string, CategoryItem>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				int count = enumerator.Current.Value.EntryItemList.Count;
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					EntryItem entryItem = enumerator.Current.Value.EntryItemList[i];
					if (entryItem.EntryUIItem.CanBeShown && entryItem.EntryUIItem.IsChanged)
					{
						if (entryItem.EntryUIItem.HasChangeBeenSeen)
						{
							entryItem.EntryUIItem.ClearIsChanged();
							ObjectiveManual.MarkChangedItemViewed(entryItem.Parent.Key, entryItem.Key);
						}
						else
						{
							flag = true;
						}
					}
				}
				if (enumerator.Current.Value.CatUIItem.IsChanged && !flag)
				{
					enumerator.Current.Value.CatUIItem.ClearIsChanged();
				}
			}
		}
		base.gameObject.SetActive(false);
		IsShowing = false;
	}

	public bool SetVisibility(string catKey, string itemKey, bool isVisible)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			int count = categoryDict[catKey].EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				EntryItem entryItem = categoryDict[catKey].EntryItemList[i];
				if (entryItem.Key == itemKey)
				{
					entryItem.EntryUIItem.CanBeShown = isVisible;
					if (isVisible)
					{
						entryItem.EntryUIItem.Show();
					}
					else
					{
						entryItem.EntryUIItem.Hide();
					}
					return true;
				}
			}
		}
		return false;
	}

	public bool SetCategoryDim(string catKey, bool isDim)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			if (isDim)
			{
				categoryDict[catKey].CatUIItem.Dim();
			}
			else
			{
				categoryDict[catKey].CatUIItem.UnDim();
			}
			return true;
		}
		return false;
	}

	public bool SetEntryDim(string catKey, string itemKey, bool isDim)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			int count = categoryDict[catKey].EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				EntryItem entryItem = categoryDict[catKey].EntryItemList[i];
				if (entryItem.Key == itemKey)
				{
					if (isDim)
					{
						entryItem.EntryUIItem.Dim();
					}
					else
					{
						entryItem.EntryUIItem.UnDim();
					}
					return true;
				}
			}
		}
		return false;
	}

	public bool SetCategoryChanged(string catKey, bool hasChanged)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			if (hasChanged)
			{
				categoryDict[catKey].CatUIItem.SetIsChanged();
			}
			else
			{
				categoryDict[catKey].CatUIItem.ClearIsChanged();
			}
			return true;
		}
		return false;
	}

	public bool SetEntryChanged(string catKey, string itemKey, bool hasChanged)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			int count = categoryDict[catKey].EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				EntryItem entryItem = categoryDict[catKey].EntryItemList[i];
				if (entryItem.Key == itemKey)
				{
					if (hasChanged)
					{
						entryItem.EntryUIItem.SetIsChanged();
					}
					else
					{
						entryItem.EntryUIItem.ClearIsChanged();
					}
					return true;
				}
			}
		}
		return false;
	}

	public CategoryItem GetCategoryObject(string catKey)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			return categoryDict[catKey];
		}
		return null;
	}

	public EntryItem GetEntryObject(string catKey, string itemKey)
	{
		if (categoryDict != null && categoryDict.ContainsKey(catKey))
		{
			int count = categoryDict[catKey].EntryItemList.Count;
			for (int i = 0; i < count; i++)
			{
				EntryItem entryItem = categoryDict[catKey].EntryItemList[i];
				if (entryItem.Key == itemKey)
				{
					return entryItem;
				}
			}
		}
		return null;
	}

	public bool AnyChangedEntries()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			Dictionary<string, CategoryItem>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				int count = enumerator.Current.Value.EntryItemList.Count;
				for (int i = 0; i < count; i++)
				{
					EntryItem entryItem = enumerator.Current.Value.EntryItemList[i];
					if (entryItem.EntryUIItem.CanBeShown && entryItem.EntryUIItem.IsChanged)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void Update()
	{
		if (!IsShowing)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
			return;
		}
		switch (listIndex)
		{
		case 0:
		{
			List<EntryItem> list = null;
			UITextItem uITextItem2 = null;
			UITextItem uITextItem3 = null;
			EntryItem entryItem2 = null;
			if (Input.GetButtonDown("Up"))
			{
				list = categoryDict.ElementAt(catIndex).Value.EntryItemList;
				uITextItem2 = categoryDict.ElementAt(catIndex).Value.CatUIItem;
				catIndex--;
				if (catIndex < 0)
				{
					catIndex = categoryDict.Count - 1;
				}
				uITextItem3 = categoryDict.ElementAt(catIndex).Value.CatUIItem;
				if (uITextItem3.EntryType == EntryTypeEnum.Objective)
				{
					int count = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count;
					bool flag = false;
					for (int num3 = count - 1; num3 >= 0; num3--)
					{
						if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num3].EntryUIItem.CanBeShown && !categoryDict.ElementAt(catIndex).Value.EntryItemList[num3].EntryUIItem.IsDimmed)
						{
							flag = true;
							itemIndex = num3;
						}
					}
					if (!flag)
					{
						for (int num4 = count - 1; num4 >= 0; num4--)
						{
							if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num4].EntryUIItem.CanBeShown)
							{
								flag = true;
								itemIndex = num4;
								break;
							}
						}
					}
					if (!flag)
					{
						itemIndex = 0;
					}
				}
				else
				{
					itemIndex = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count - 1;
				}
				if (categoryDict.ElementAt(catIndex).Value.EntryItemList.Count > itemIndex)
				{
					entryItem2 = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex];
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				}
				else
				{
					entryItem2 = null;
				}
			}
			else if (Input.GetButtonDown("Down"))
			{
				list = categoryDict.ElementAt(catIndex).Value.EntryItemList;
				uITextItem2 = categoryDict.ElementAt(catIndex).Value.CatUIItem;
				catIndex++;
				if (catIndex >= categoryDict.Count)
				{
					catIndex = 0;
				}
				uITextItem3 = categoryDict.ElementAt(catIndex).Value.CatUIItem;
				if (uITextItem3.EntryType == EntryTypeEnum.Objective)
				{
					int count2 = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count;
					bool flag2 = false;
					for (int num5 = count2 - 1; num5 >= 0; num5--)
					{
						if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num5].EntryUIItem.CanBeShown && !categoryDict.ElementAt(catIndex).Value.EntryItemList[num5].EntryUIItem.IsDimmed)
						{
							flag2 = true;
							itemIndex = num5;
							break;
						}
					}
					if (!flag2)
					{
						for (int num6 = count2 - 1; num6 >= 0; num6--)
						{
							if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num6].EntryUIItem.CanBeShown)
							{
								flag2 = true;
								itemIndex = num6;
							}
						}
					}
					if (!flag2)
					{
						itemIndex = 0;
					}
				}
				else
				{
					itemIndex = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count - 1;
				}
				if (categoryDict.ElementAt(catIndex).Value.EntryItemList.Count > itemIndex)
				{
					entryItem2 = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex];
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				}
				else
				{
					entryItem2 = null;
				}
			}
			else if (Input.GetButtonDown("Right"))
			{
				listIndex = 1;
				categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearHighlight();
				categoryDict.ElementAt(catIndex).Value.CatUIItem.Select();
				itemIndex = -1;
				int count3 = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count;
				for (int i = 0; i < count3; i++)
				{
					if (categoryDict.ElementAt(catIndex).Value.EntryItemList[i].EntryUIItem.IsSelected)
					{
						itemIndex = i;
						if (categoryDict.ElementAt(catIndex).Value.EntryItemList[i].EntryUIItem.EntryKey == "SEP")
						{
							itemIndex--;
						}
						break;
					}
				}
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.ClearSelection();
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Highlight();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			if (list != null)
			{
				categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearSelection();
				List<EntryItem> list2 = list;
				int count4 = list2.Count;
				for (int j = 0; j < count4; j++)
				{
					list2[j].EntryUIItem.Hide();
				}
			}
			if (uITextItem2 != null)
			{
				uITextItem2.ClearHighlight();
			}
			if (uITextItem3 != null)
			{
				uITextItem3.Highlight();
				List<EntryItem> entryItemList = categoryDict.ElementAt(catIndex).Value.EntryItemList;
				int count5 = entryItemList.Count;
				for (int k = 0; k < count5; k++)
				{
					entryItemList[k].EntryUIItem.ClearSelection();
					if (entryItemList[k].EntryUIItem.CanBeShown)
					{
						entryItemList[k].EntryUIItem.Show();
					}
				}
			}
			if (entryItem2 != null)
			{
				entryItem2.EntryUIItem.Select();
				ShowEntryData(entryItem2);
			}
			break;
		}
		case 1:
		{
			UITextItem uITextItem = null;
			EntryItem entryItem = null;
			if (Input.GetButtonDown("Up"))
			{
				int num = itemIndex;
				uITextItem = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem;
				do
				{
					itemIndex--;
					if (itemIndex < 0)
					{
						itemIndex = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count - 1;
					}
				}
				while ((!categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.CanBeShown && itemIndex != num) || categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.EntryKey == "SEP");
				entryItem = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex];
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			else if (Input.GetButtonDown("Down"))
			{
				int num2 = itemIndex;
				uITextItem = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem;
				do
				{
					itemIndex++;
					if (itemIndex >= categoryDict.ElementAt(catIndex).Value.EntryItemList.Count)
					{
						itemIndex = 0;
					}
				}
				while ((!categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.CanBeShown && itemIndex != num2) || categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.EntryKey == "SEP");
				entryItem = categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex];
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			else if (Input.GetButtonDown("Left"))
			{
				listIndex = 0;
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Select();
				categoryDict.ElementAt(catIndex).Value.CatUIItem.SetInactive();
				categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearSelection();
				categoryDict.ElementAt(catIndex).Value.CatUIItem.Highlight();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			}
			if (uITextItem != null)
			{
				uITextItem.ClearHighlight();
			}
			if (entryItem != null)
			{
				entryItem.EntryUIItem.Highlight();
				ShowEntryData(entryItem);
			}
			break;
		}
		}
	}

	private void Refresh()
	{
		objectiveList.Refresh();
	}

	private void MoveToTop()
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			if (catIndex < categoryDict.Count)
			{
				if (catIndex > -1)
				{
					List<EntryItem> entryItemList = categoryDict.ElementAt(catIndex).Value.EntryItemList;
					int count = entryItemList.Count;
					for (int i = 0; i < count; i++)
					{
						entryItemList[i].EntryUIItem.Hide();
						entryItemList[i].EntryUIItem.ClearHighlight();
						entryItemList[i].EntryUIItem.ClearSelection();
					}
				}
				if (catIndex != -1)
				{
					categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearSelection();
				}
				catIndex = 0;
				itemIndex = 0;
				List<EntryItem> entryItemList2 = categoryDict.ElementAt(catIndex).Value.EntryItemList;
				categoryDict.ElementAt(catIndex).Value.CatUIItem.Highlight();
				if (categoryDict.ElementAt(catIndex).Value.EntryType == EntryTypeEnum.Objective)
				{
					int count2 = categoryDict.ElementAt(catIndex).Value.EntryItemList.Count;
					bool flag = false;
					for (int num = count2 - 1; num >= 0; num--)
					{
						if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num].EntryUIItem.CanBeShown && !categoryDict.ElementAt(catIndex).Value.EntryItemList[num].EntryUIItem.IsDimmed)
						{
							flag = true;
							itemIndex = num;
						}
					}
					if (!flag)
					{
						for (int num2 = count2 - 1; num2 >= 0; num2--)
						{
							if (categoryDict.ElementAt(catIndex).Value.EntryItemList[num2].EntryUIItem.CanBeShown)
							{
								flag = true;
								itemIndex = num2;
							}
						}
					}
					if (!flag)
					{
						itemIndex = 0;
					}
				}
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Select();
				ShowEntryData(categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex]);
				int count3 = entryItemList2.Count;
				for (int j = 0; j < count3; j++)
				{
					if (entryItemList2[j].EntryUIItem.CanBeShown)
					{
						entryItemList2[j].EntryUIItem.Show();
					}
				}
			}
			else
			{
				catIndex = 0;
				itemIndex = 0;
			}
		}
		else
		{
			catIndex = -1;
		}
	}

	private void MoveToCatAndItem(int newCatIndex, int newItemIndex)
	{
		if (categoryDict != null && categoryDict.Count > 0)
		{
			if (catIndex > -1)
			{
				List<EntryItem> entryItemList = categoryDict.ElementAt(catIndex).Value.EntryItemList;
				int count = entryItemList.Count;
				for (int i = 0; i < count; i++)
				{
					entryItemList[i].EntryUIItem.Hide();
					entryItemList[i].EntryUIItem.ClearHighlight();
					entryItemList[i].EntryUIItem.ClearSelection();
				}
			}
			if (catIndex != -1)
			{
				categoryDict.ElementAt(catIndex).Value.CatUIItem.ClearSelection();
			}
			catIndex = newCatIndex;
			itemIndex = newItemIndex;
			List<EntryItem> entryItemList2 = categoryDict.ElementAt(catIndex).Value.EntryItemList;
			categoryDict.ElementAt(catIndex).Value.CatUIItem.Highlight();
			if (categoryDict.ElementAt(catIndex).Value.EntryType == EntryTypeEnum.Objective)
			{
			}
			if (categoryDict.ElementAt(catIndex).Value.EntryItemList.Count > itemIndex)
			{
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Select();
			}
			else
			{
				itemIndex = 0;
				categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex].EntryUIItem.Select();
			}
			ShowEntryData(categoryDict.ElementAt(catIndex).Value.EntryItemList[itemIndex]);
			int count2 = entryItemList2.Count;
			for (int j = 0; j < count2; j++)
			{
				if (entryItemList2[j].EntryUIItem.CanBeShown)
				{
					entryItemList2[j].EntryUIItem.Show();
				}
			}
		}
		else
		{
			catIndex = -1;
		}
	}

	public bool CategoryExists(string key)
	{
		if (categoryDict != null && categoryDict.ContainsKey(key))
		{
			return true;
		}
		return false;
	}

	public bool AddCategory(string key, string text, EntryTypeEnum entryType)
	{
		if (categoryDict == null)
		{
			categoryDict = new Dictionary<string, CategoryItem>();
		}
		UITextItem uITextItem = categoryList.AddItem(text, true, entryType);
		if (uITextItem != null && !categoryDict.ContainsKey(key))
		{
			CategoryItem categoryItem = null;
			if (entryType == EntryTypeEnum.Objective && categoryDict.ContainsKey("log"))
			{
				categoryItem = categoryDict["log"];
				categoryDict.Remove("log");
			}
			categoryDict.Add(key, new CategoryItem(entryType, key, uITextItem));
			if (categoryItem != null)
			{
				categoryDict.Add("log", categoryItem);
			}
			uITextItem.SetInactive();
			return true;
		}
		return false;
	}

	public bool AddSeparator(string catKey, bool isHidden)
	{
		if (categoryDict.ContainsKey(catKey))
		{
			UITextItem uITextItem = objectiveList.AddSeparator(isHidden);
			if (uITextItem != null)
			{
				uITextItem.EntryKey = "SEP";
				uITextItem.SetInactive();
				uITextItem.CanBeShown = !isHidden;
				uITextItem.Hide();
				uITextItem.Dim();
				categoryDict[catKey].EntryItemList.Add(new EntryItem(categoryDict[catKey], "SEP", uITextItem));
				return true;
			}
		}
		return false;
	}

	public bool AddEntryListing(string catKey, string itemKey, string text, string entryKey, bool isHidden)
	{
		if (categoryDict.ContainsKey(catKey))
		{
			UITextItem uITextItem = objectiveList.AddItem(text);
			if (uITextItem != null)
			{
				uITextItem.EntryKey = entryKey;
				uITextItem.SetInactive();
				uITextItem.CanBeShown = !isHidden;
				uITextItem.Hide();
				categoryDict[catKey].EntryItemList.Add(new EntryItem(categoryDict[catKey], itemKey, uITextItem));
				return true;
			}
		}
		return false;
	}

	public void DeleteItems(string catKey)
	{
		if (categoryDict.ContainsKey(catKey))
		{
			Dictionary<string, CategoryItem>.Enumerator enumerator = categoryDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				objectiveList.DeleteAllItems();
			}
		}
	}

	private void ShowEntryData(EntryItem item)
	{
		string text = string.Empty;
		switch (item.Parent.EntryType)
		{
		case EntryTypeEnum.Objective:
			if (item.EntryUIItem.EntryKey.ToLower().EndsWith("_log"))
			{
				string fileName = Path.GetFileName(item.EntryUIItem.EntryKey);
				if (LogManager.DoesBakedVersionExist(fileName))
				{
					string fullPath = Path.Combine(GameFileHelper.GetDataUniverseLogLocation(), fileName + ".bkd");
					item.EntryUIItem.EntryKey = LogManager.GetLogFromFile(fullPath);
				}
				else
				{
					item.EntryUIItem.EntryKey = LogManager.GetLogFromResource(item.EntryUIItem.EntryKey, true, true);
				}
			}
			text = item.EntryUIItem.EntryKey;
			break;
		case EntryTypeEnum.Log:
		{
			string text2 = Path.Combine(GameFileHelper.GetDataUniverseLogLocation(), LogManager.LogDataFile.GetSetting(item.EntryUIItem.EntryKey, "FILE", string.Empty));
			text2 = text2.Replace("Color/", string.Empty);
			if (LogManager.DoesBakedVersionExist(text2))
			{
				text2 += ".bkd";
				text = LogManager.GetLogFromFile(text2);
			}
			else
			{
				text = LogManager.GetStoryLogText(item.EntryUIItem.EntryKey, true);
			}
			break;
		}
		}
		reader.entryTextLabel.text = text;
	}
}
