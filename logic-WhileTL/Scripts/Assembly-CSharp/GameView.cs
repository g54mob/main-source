using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameView : ActiveComponent
{
	[SceneBind("Scroll View/Viewport/Content")]
	public Transform Content;

	[SceneBind("Close")]
	public Button CloseButton;

	[SceneBind("Buggle")]
	public Button scoreButton;

	[SceneBind("Name")]
	public Button nameButton;

	[SceneBind("Info")]
	public Button infoButton;

	[SceneBind("DateTime")]
	public Button dateTimeButton;

	[SceneBind("MoneyText")]
	public Button moneyButton;

	private GameObject savePref;

	protected List<SaveObjController> saveObjs = new List<SaveObjController>();

	private SaveObjController.SaveObjComparer.KeyEnum currentKey = SaveObjController.SaveObjComparer.KeyEnum.Time;

	private bool isCurrentKeyReversed = true;

	private const string upArrowSymbol = "↑";

	private const string downArrowSymbol = "↓";

	private static Color selectedColor;

	private Text oldText;

	private SaveObjController.SaveObjComparer.KeyEnum oldKey = SaveObjController.SaveObjComparer.KeyEnum.Time;

	protected void CloseClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		base.gameObject.SetActive(value: false);
	}

	private void ColorSelected(Text selectedText, SaveObjController.SaveObjComparer.KeyEnum key, Color color)
	{
		selectedText.color = color;
		foreach (SaveObjController saveObj in saveObjs)
		{
			saveObj.GetTextFieldByKey(key).color = color;
		}
	}

	private Text GetTextByKey(SaveObjController.SaveObjComparer.KeyEnum key)
	{
		return key switch
		{
			SaveObjController.SaveObjComparer.KeyEnum.Money => moneyButton.GetComponent<Text>(), 
			SaveObjController.SaveObjComparer.KeyEnum.Nickname => nameButton.GetComponent<Text>(), 
			SaveObjController.SaveObjComparer.KeyEnum.Info => infoButton.GetComponent<Text>(), 
			SaveObjController.SaveObjComparer.KeyEnum.Score => scoreButton.GetComponent<Text>(), 
			_ => dateTimeButton.GetComponent<Text>(), 
		};
	}

	private void UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum newKey)
	{
		if (newKey == currentKey)
		{
			isCurrentKeyReversed = !isCurrentKeyReversed;
		}
		else
		{
			currentKey = newKey;
			SaveObjController.SaveObjComparer.KeyEnum keyEnum = currentKey;
			if ((uint)(keyEnum - 2) <= 2u)
			{
				isCurrentKeyReversed = true;
			}
			else
			{
				isCurrentKeyReversed = false;
			}
		}
		SortSaveSlots(currentKey, isCurrentKeyReversed);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Button[] componentsInChildren = base.gameObject.GetComponentsInChildren<Button>();
		foreach (Button button in componentsInChildren)
		{
			switch (button.name)
			{
			case "Close":
				if (CloseButton == null)
				{
					CloseButton = button;
				}
				break;
			case "Buggle":
				if (scoreButton == null)
				{
					scoreButton = button;
				}
				break;
			case "Name":
				if (nameButton == null)
				{
					nameButton = button;
				}
				break;
			case "Info":
				if (infoButton == null)
				{
					infoButton = button;
				}
				break;
			case "DateTime":
				if (dateTimeButton == null)
				{
					dateTimeButton = button;
				}
				break;
			case "MoneyText":
				if (moneyButton == null)
				{
					moneyButton = button;
				}
				break;
			}
		}
		CloseButton.onClick.AddListener(CloseClick);
		savePref = Resources.Load("Prefabs/SaveObj") as GameObject;
		selectedColor = Logic.GetColor("WARNING");
		scoreButton.onClick.AddListener(delegate
		{
			UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum.Score);
		});
		nameButton.onClick.AddListener(delegate
		{
			UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum.Nickname);
		});
		infoButton.onClick.AddListener(delegate
		{
			UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum.Info);
		});
		dateTimeButton.onClick.AddListener(delegate
		{
			UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum.Time);
		});
		moneyButton.onClick.AddListener(delegate
		{
			UpdateSortKey(SaveObjController.SaveObjComparer.KeyEnum.Money);
		});
	}

	protected virtual void SaveClick(int saveId)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	protected virtual void InstantiateSave(int saveId, Action saveClickAction)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(savePref);
		gameObject.transform.SetParent(Content);
		gameObject.transform.localScale = Vector3.one;
		saveObjs.Add(gameObject.GetComponent<SaveObjController>());
		gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			saveClickAction();
		});
		if (saveId < ActiveComponent.Model.globalSaves.Preview.Count)
		{
			gameObject.GetComponent<SaveObjController>().Init(ActiveComponent.Model.globalSaves.Preview[saveId]);
			return;
		}
		gameObject.GetComponent<SaveObjController>().Init(null);
		gameObject.transform.SetAsFirstSibling();
	}

	public virtual void Redraw()
	{
		saveObjs.ForEach(delegate(SaveObjController i)
		{
			UnityEngine.Object.Destroy(i.gameObject);
		});
		saveObjs.Clear();
		for (int num = 0; num < ActiveComponent.Model.globalSaves.Preview.Count; num++)
		{
			int id = num;
			InstantiateSave(id, delegate
			{
				SaveClick(id);
			});
		}
		SortSaveSlots(currentKey, isCurrentKeyReversed);
		Content.gameObject.SetActive(value: true);
	}

	private void SortSaveSlots(SaveObjController.SaveObjComparer.KeyEnum key, bool reverse)
	{
		if (oldText != null && oldText.text.Length > 0 && (oldText.text[0] == "↑"[0] || oldText.text[0] == "↓"[0]))
		{
			ColorSelected(oldText, oldKey, Color.white);
			oldText.text = oldText.text.Substring(2, oldText.text.Length - 4);
		}
		Text textByKey = GetTextByKey(key);
		ColorSelected(textByKey, key, selectedColor);
		string text = (isCurrentKeyReversed ? "↑" : "↓");
		textByKey.text = text + " " + textByKey.text + " " + text;
		oldText = textByKey;
		oldKey = key;
		SaveObjController.SaveObjComparer comparer = new SaveObjController.SaveObjComparer(key, reverse);
		saveObjs.Sort(comparer);
		for (int i = 0; i < saveObjs.Count; i++)
		{
			saveObjs[i].transform.SetSiblingIndex(i);
		}
	}
}
