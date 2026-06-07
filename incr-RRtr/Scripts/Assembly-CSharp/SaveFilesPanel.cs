using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SaveFilesPanel : MonoBehaviour
{
	[Serializable]
	public class SaveFileInfo
	{
		public string filePath;

		public DateTime fileTimeStamp;
	}

	[SerializeField]
	private RectTransform panelObject;

	[SerializeField]
	private Transform saveFileSlotsParent;

	[SerializeField]
	private SaveFileButton saveFileButton;

	[SerializeField]
	private GameObject loadingScreen;

	public List<SaveFileButton> saveFileButtons = new List<SaveFileButton>();

	public List<SaveFileInfo> saveFileList = new List<SaveFileInfo>();

	private void OnEnable()
	{
		panelObject.DOComplete();
		panelObject.transform.localScale = new Vector3(1f, 0f, 1f);
		panelObject.DOScaleY(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(SpawnAllSaveFiles);
		for (int i = 0; i < saveFileButtons.Count; i++)
		{
			UnityEngine.Object.Destroy(saveFileButtons[i].gameObject);
		}
		saveFileButtons.Clear();
		loadingScreen.SetActive(value: true);
	}

	private void SpawnAllSaveFiles()
	{
		saveFileList.Clear();
		string[] files = ES3.GetFiles();
		foreach (string text in files)
		{
			if (text.Contains(".txt") && !text.Contains("tmp") && !text.Contains(".bac") && !text.Contains("Player-glob.txt") && (text.StartsWith("V") || text.StartsWith("H")))
			{
				SaveFileInfo saveFileInfo = new SaveFileInfo();
				saveFileInfo.filePath = text;
				saveFileInfo.fileTimeStamp = ES3.GetTimestamp(text);
				saveFileList.Add(saveFileInfo);
			}
		}
		saveFileList.Sort((SaveFileInfo x, SaveFileInfo y) => DateTime.Compare(x.fileTimeStamp, y.fileTimeStamp));
		for (int num = saveFileList.Count - 1; num >= 0; num--)
		{
			if (saveFileList[num].filePath == PersistentFilePath.ins.currentFilePath)
			{
				SpawnCurrentSaveFile(saveFileList[num].filePath);
			}
			else
			{
				SpawnSaveFile(saveFileList[num].filePath);
			}
		}
		loadingScreen.SetActive(value: false);
	}

	private void SpawnSaveFile(string filepath)
	{
		SaveFileButton saveFileButton = UnityEngine.Object.Instantiate(this.saveFileButton, saveFileSlotsParent);
		saveFileButton.SetVisuals(filepath);
		saveFileButtons.Add(saveFileButton);
	}

	private void SpawnCurrentSaveFile(string filepath)
	{
		SaveFileButton saveFileButton = UnityEngine.Object.Instantiate(this.saveFileButton, saveFileSlotsParent);
		saveFileButton.SetVisuals(filepath);
		saveFileButton.SetCurrentlySelected();
		saveFileButtons.Add(saveFileButton);
	}
}
