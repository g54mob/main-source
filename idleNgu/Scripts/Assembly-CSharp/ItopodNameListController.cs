using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItopodNameListController : MonoBehaviour
{
	public Character character;

	public List<string> ItopodNameList;

	public bool listLoaded = true;

	public int pageID;

	public int maxPage;

	public Text list1;

	public Text list2;

	public InputField pageInput;

	public Button pageUpButton;

	public Button pageDownButton;

	private void Start()
	{
		StartCoroutine(loadItopodNames());
	}

	private void Update()
	{
	}

	private IEnumerator loadItopodNames()
	{
		string url = "https://www.nguindustries.net/itopodNamesList.php";
		WWW www = new WWW(url);
		yield return new WaitForSeconds(5f);
		if (www.isDone && string.IsNullOrEmpty(www.error))
		{
			listLoaded = true;
			loadNamesIntoList(www.text);
		}
		else
		{
			listLoaded = false;
		}
	}

	public void loadNamesIntoList(string names)
	{
		try
		{
			string[] array = names.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				ItopodNameList.Add(array[i]);
			}
			maxPage = Mathf.CeilToInt(ItopodNameList.Count / 50);
		}
		catch (Exception ex)
		{
			listLoaded = false;
			character.tooltip.showOverrideTooltip("The Itopod Name List didn't load right. The server might be down or your internet is a potato. Error was: " + ex, 5f);
		}
	}

	public string genRandomName()
	{
		if (!listLoaded)
		{
			return "4G Goofed";
		}
		if (ItopodNameList.Count == 0)
		{
			return "4G Goofed";
		}
		int index = UnityEngine.Random.Range(0, ItopodNameList.Count);
		return ItopodNameList[index];
	}

	public void updateMenu()
	{
		if (character.menuID == 47)
		{
			updateText();
			updateInput();
		}
	}

	public void updateText()
	{
		if (!listLoaded || pageID * 50 >= ItopodNameList.Count || pageID < 0)
		{
			list1.text = "Error Loading List:(";
			list2.text = "Error Loading List :(";
			return;
		}
		list1.text = "";
		list2.text = "";
		for (int i = pageID * 50; i < pageID * 50 + 25; i++)
		{
			if (i < ItopodNameList.Count)
			{
				Text text = list1;
				text.text = text.text + ItopodNameList[i] + "\n";
			}
		}
		for (int j = pageID * 50 + 25; j < pageID * 50 + 50; j++)
		{
			if (j < ItopodNameList.Count)
			{
				Text text2 = list2;
				text2.text = text2.text + ItopodNameList[j] + "\n";
			}
		}
	}

	public void tryPageUp()
	{
		if ((pageID + 1) * 50 < ItopodNameList.Count)
		{
			pageID++;
			updateMenu();
		}
	}

	public void tryPageDown()
	{
		if (pageID > 0)
		{
			pageID--;
			updateMenu();
		}
	}

	public void setPage()
	{
		int num = int.Parse(pageInput.text);
		if (num * 50 > ItopodNameList.Count)
		{
			num = maxPage;
		}
		if (num < 0)
		{
			num = 0;
		}
		pageID = num;
		updateMenu();
	}

	public void updateInput()
	{
		pageInput.text = pageID.ToString();
	}
}
