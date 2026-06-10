using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval;
using NSMedieval.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettlementView : MonoBehaviour
{
	[SerializeField]
	private GameObject saveEntryPrefab;

	[SerializeField]
	private GameObject saveEntriesParent;

	[SerializeField]
	private TMP_Text folderNameText;

	[SerializeField]
	private SoundButton deleteWholeFolder;

	[SerializeField]
	private SoundButton expandButton;

	[SerializeField]
	private GameObject folderArrow;

	private bool isExpanded = true;

	private string folderName;

	private readonly List<SaveFileView> saveViews = new List<SaveFileView>();

	public List<SaveFileView> SaveViews => saveViews;

	public string FolderName => folderName;

	private void Awake()
	{
		saveEntryPrefab.SetActive(value: false);
	}

	public void Hide()
	{
	}

	public void Setup(string folder, List<VillageSaveInfo> villageSaveInfos, Action<VillageSaveInfo> overwriteProfileAction, Action<VillageSaveInfo> deleteProfileAction, Action<VillageSaveInfo> selectProfileAction, Action<string> deleteFolderAction, Action<VillageSaveInfo> loadProfileAction, bool isExpanded = false)
	{
		this.isExpanded = isExpanded;
		foreach (SaveFileView saveView in saveViews)
		{
			saveView.Hide();
			saveView.gameObject.SetActive(value: false);
		}
		folderName = folder;
		folderNameText.SetText(folder);
		if (deleteWholeFolder != null)
		{
			deleteWholeFolder.onClick.RemoveAllListeners();
			if (deleteFolderAction != null)
			{
				deleteWholeFolder.onClick.AddListener(delegate
				{
					deleteFolderAction(folderName);
				});
			}
		}
		if (expandButton != null)
		{
			RotateToggleSprite();
			saveEntriesParent.SetActive(this.isExpanded);
			expandButton.onClick.RemoveAllListeners();
			expandButton.onClick.AddListener(delegate
			{
				string soundID = (this.isExpanded ? "UI_Collapse" : "UI_Expand");
				MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
				this.isExpanded = !this.isExpanded;
				RotateToggleSprite();
				ExpandCollapseFiles();
			});
		}
		int num = 0;
		foreach (VillageSaveInfo villageSaveInfo in villageSaveInfos)
		{
			SaveFileView firstFreeSaveView = GetFirstFreeSaveView();
			firstFreeSaveView.Setup(villageSaveInfo, overwriteProfileAction, deleteProfileAction, selectProfileAction, loadProfileAction);
			firstFreeSaveView.transform.SetSiblingIndex(num++);
			firstFreeSaveView.gameObject.SetActive(value: true);
		}
	}

	public void SetSelectedProfile(VillageSaveInfo profile)
	{
		foreach (SaveFileView saveView in saveViews)
		{
			if (saveView.Profile != null)
			{
				if (saveView.Profile.Equals(profile))
				{
					saveView.SetSelected(selected: true);
				}
				else
				{
					saveView.SetSelected(selected: false);
				}
			}
		}
	}

	public void OnProfileDeleted(VillageSaveInfo profile, bool rebuildLayout = true)
	{
		foreach (SaveFileView saveView in saveViews)
		{
			if (saveView.Profile != null && saveView.Profile.Equals(profile))
			{
				saveView.Hide();
				saveView.gameObject.SetActive(value: false);
			}
		}
		if (rebuildLayout)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.transform.parent.GetComponent<RectTransform>());
		}
	}

	public void OnProfilesDeleted(List<VillageSaveInfo> profiles)
	{
		foreach (VillageSaveInfo profile in profiles)
		{
			foreach (SaveFileView saveView in saveViews)
			{
				if (saveView.Profile != null && saveView.Profile.Equals(profile))
				{
					saveView.Hide();
					saveView.gameObject.SetActive(value: false);
				}
			}
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.GetComponent<RectTransform>());
		LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.transform.parent.GetComponent<RectTransform>());
	}

	public void OnSaveReplaced(VillageSaveInfo newSave, VillageSaveInfo oldSave)
	{
		foreach (SaveFileView saveView in saveViews)
		{
			if (saveView.Profile != null && saveView.Profile.Equals(oldSave))
			{
				saveView.SetProfile(newSave);
			}
		}
	}

	public void ForceLayoutRebuild()
	{
		StartCoroutine(OnExpansionChange());
	}

	private SaveFileView GetFirstFreeSaveView()
	{
		foreach (SaveFileView saveView in saveViews)
		{
			if (!saveView.gameObject.activeSelf)
			{
				return saveView;
			}
		}
		GameObject obj = UnityEngine.Object.Instantiate(saveEntryPrefab, saveEntriesParent.transform, worldPositionStays: false);
		obj.SetActive(value: true);
		SaveFileView component = obj.GetComponent<SaveFileView>();
		saveViews.Add(component);
		return component;
	}

	private void ExpandCollapseFiles()
	{
		saveEntriesParent.SetActive(isExpanded);
		StartCoroutine(OnExpansionChange());
	}

	private void RotateToggleSprite()
	{
		folderArrow.transform.eulerAngles = new Vector3(0f, 0f, isExpanded ? (-90f) : 0f);
	}

	private IEnumerator OnExpansionChange()
	{
		yield return new WaitForEndOfFrame();
		LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.GetComponent<RectTransform>());
		LayoutRebuilder.ForceRebuildLayoutImmediate(saveEntriesParent.transform.parent.GetComponent<RectTransform>());
	}
}
