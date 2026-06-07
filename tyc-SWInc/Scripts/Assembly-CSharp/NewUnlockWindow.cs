using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUnlockWindow : MonoBehaviour
{
	public GUIWindow Window;

	public RectTransform ContentPanel;

	public List<Button> ButtonPool = new List<Button>();

	public Sprite SoftwareUnlock;

	public Sprite CategoryUnlock;

	public Sprite AddonUnlock;

	public Sprite FeatureUnlock;

	private int _buttonCount;

	public Button GetButton()
	{
		Button button;
		if (_buttonCount < ButtonPool.Count)
		{
			button = ButtonPool[_buttonCount];
		}
		else
		{
			button = UnityEngine.Object.Instantiate(ButtonPool[0]);
			ButtonPool.Add(button);
		}
		button.transform.SetParent(ContentPanel, false);
		button.gameObject.SetActive(true);
		button.onClick.RemoveAllListeners();
		_buttonCount++;
		return button;
	}

	public void Show(List<UnlockChecker.UnlockItem> unlocks)
	{
		ButtonPool.ForEach(delegate(Button x)
		{
			x.gameObject.SetActive(false);
		});
		_buttonCount = 0;
		bool flag = false;
		foreach (UnlockChecker.UnlockItem item in unlocks)
		{
			Furniture furniture = null;
			if (item.Type == UnlockChecker.UnlockType.Furniture)
			{
				furniture = ObjectDatabase.Instance.GetFurnitureComponent(item.Name);
				if (furniture == null)
				{
					continue;
				}
			}
			flag = true;
			Button button = GetButton();
			button.GetComponentInChildren<Text>().text = item.GetName();
			button.onClick.AddListener(delegate
			{
				item.OnClick();
			});
			Image image = button.GetComponentsInChildren<Image>()[1];
			switch (item.Type)
			{
			case UnlockChecker.UnlockType.Software:
				image.sprite = SoftwareUnlock;
				break;
			case UnlockChecker.UnlockType.Category:
				image.sprite = CategoryUnlock;
				break;
			case UnlockChecker.UnlockType.Feature:
				image.sprite = FeatureUnlock;
				break;
			case UnlockChecker.UnlockType.Addon:
				image.sprite = AddonUnlock;
				break;
			case UnlockChecker.UnlockType.Furniture:
				image.sprite = furniture.Thumbnail;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		if (flag)
		{
			Window.Show();
		}
	}
}
