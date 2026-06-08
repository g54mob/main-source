using System;
using UnityEngine;

public class UIObjectiveList : UIItemList
{
	public static UIObjectiveList Instance;

	public GameObject entrySepatator;

	protected override void Awake()
	{
		Instance = this;
		Initialize();
		base.Awake();
	}

	public void Initialize()
	{
		DeleteAllItems();
		itemList = new UITextItem[0];
	}

	public override void Refresh()
	{
		base.CurrentHighlightedIndex = -1;
	}

	public UITextItem AddItem(string text)
	{
		return AddItem(text, false, EntryTypeEnum.UnknownOrOther);
	}

	public UITextItem AddItem(string text, bool isVisible, EntryTypeEnum entryType)
	{
		GameObject gameObject = null;
		if (entryType == EntryTypeEnum.Objective)
		{
			int num = itemList.Length;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (((UITextItem)itemList[num2]).EntryType == EntryTypeEnum.Log)
				{
					gameObject = ((UITextItem)itemList[num2]).UnderlyingGameObject;
					gameObject.transform.parent = null;
					break;
				}
			}
		}
		Array.Resize(ref itemList, itemList.Length + 1);
		UITextItem uITextItem = (UITextItem)itemList[itemList.Length - 1];
		GameObject gameObject2 = UnityEngine.Object.Instantiate(itemPrefab);
		uITextItem = gameObject2.GetComponent<UITextItem>();
		uITextItem.SetText(text, "*");
		uITextItem.EntryType = entryType;
		uITextItem.SetActive();
		itemList[itemList.Length - 1] = uITextItem;
		gameObject2.transform.SetParent(base.gameObject.transform);
		gameObject2.transform.localScale = Vector3.one;
		gameObject2.SetActive(isVisible);
		if (gameObject != null)
		{
			gameObject.transform.SetParent(base.gameObject.transform);
			gameObject.transform.localScale = Vector3.one;
		}
		return uITextItem;
	}

	public UITextItem AddSeparator(bool isVisible)
	{
		if (entrySepatator != null)
		{
			Array.Resize(ref itemList, itemList.Length + 1);
			UITextItem uITextItem = (UITextItem)itemList[itemList.Length - 1];
			GameObject gameObject = UnityEngine.Object.Instantiate(entrySepatator);
			gameObject.transform.SetParent(base.gameObject.transform);
			gameObject.transform.localScale = Vector3.one;
			gameObject.SetActive(isVisible);
			uITextItem = gameObject.GetComponent<UITextItem>();
			uITextItem.SetActive();
			itemList[itemList.Length - 1] = uITextItem;
			return uITextItem;
		}
		return null;
	}
}
