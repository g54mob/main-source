using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameSavesPanel : MonoBehaviour
{
	[Header("UI Elements")]
	public GameObject saveContentPrefab;

	public Transform contentParent;

	public Button deleteAllButton;

	private void Start()
	{
		ListSaveGames();
		if (deleteAllButton != null)
		{
			deleteAllButton.onClick.AddListener(DeleteAllSaves);
		}
	}

	public void ListSaveGames()
	{
		foreach (Transform item in contentParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		string[] allSaves = Singleton<ES3SaveManager>.Instance.GetAllSaves();
		List<SaveFileInfo> list = new List<SaveFileInfo>();
		string[] array = allSaves;
		foreach (string text in array)
		{
			string saveLastAccessTime = Singleton<ES3SaveManager>.Instance.GetSaveLastAccessTime(text);
			DateTime result = DateTime.MinValue;
			if (saveLastAccessTime != "Hiç açılmamış")
			{
				DateTime.TryParse(saveLastAccessTime, out result);
			}
			list.Add(new SaveFileInfo
			{
				fileName = text,
				lastAccessTime = result,
				lastAccessTimeString = saveLastAccessTime
			});
		}
		list = list.OrderByDescending((SaveFileInfo x) => x.lastAccessTime).ToList();
		foreach (SaveFileInfo item2 in list)
		{
			UnityEngine.Object.Instantiate(saveContentPrefab, contentParent).GetComponent<GameSaveContent>().SetupSaveContent(item2.fileName, item2.fileName + ".es3", this);
		}
	}

	public void DeleteAllSaves()
	{
		string[] allSaves = Singleton<ES3SaveManager>.Instance.GetAllSaves();
		foreach (string saveName in allSaves)
		{
			Singleton<ES3SaveManager>.Instance.SetSaveName(saveName);
			Singleton<ES3SaveManager>.Instance.DeleteCurrentSave();
		}
		ListSaveGames();
	}

	public void RefreshContent()
	{
		ListSaveGames();
	}
}
