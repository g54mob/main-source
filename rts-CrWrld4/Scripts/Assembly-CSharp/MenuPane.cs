using System.Collections.Generic;
using UnityEngine;

public class MenuPane : MonoBehaviour
{
	public GameObject saveLoadContainer;

	public GameObject saveLoadEditorContainer;

	public GameObject fileBrowserPanelPrefab;

	public SaveListBox saveListBox;

	public GameObject demoText;

	public List<LoadSaveEditSlot> loadSaveEditSlots;

	public GameObject exitButton;

	public GameObject exitConfirm;

	public GameObject restartButton;

	public GameObject restartConfirm;

	public GameObject saveLoadButton;

	public GameObject mverseButton;

	public void OnEnable()
	{
	}

	public void OnSaveLoadClicked()
	{
	}

	public void OnDisable()
	{
	}

	public void OnLoadMissionClicked(string filename)
	{
	}

	public void OnSaveMissionClicked(string filename)
	{
	}

	public void OnEditMissionClicked(string filename)
	{
	}

	public void OnLeaveClicked()
	{
	}

	public void FinalSequenceLeave()
	{
	}

	public void OnRestartClicked()
	{
	}

	public void RefreshSlots()
	{
	}

	public void OnLoadFromFileClicked()
	{
	}

	public void OnSaveToFileClicked()
	{
	}

	public void LoadMissionFromFile()
	{
	}

	public void SaveMissionToFile()
	{
	}

	private void LoadFileBrowserOutput(string[] paths)
	{
	}

	private void SaveFileBrowserOutput(string[] paths)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
