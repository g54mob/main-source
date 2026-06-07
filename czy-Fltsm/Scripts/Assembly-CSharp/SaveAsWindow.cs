using System.Collections.Generic;
using M4.Session;
using UnityEngine;

public class SaveAsWindow : PauseMenuWindow
{
	[SerializeField]
	private SaveAsSlot _slotPrefab;

	[SerializeField]
	private Transform _slotParent;

	private List<SaveAsSlot> _slots = new List<SaveAsSlot>();

	private SaveInfo _saveToOverwrite;

	public void Open()
	{
		UpdateSaveFiles(Session.Profile.ActiveRun.Saves);
		base.gameObject.SetActive(value: true);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		GameEventDispatcher.AddListener(GameEventType.SaveAdded, OnSaveFilesUpdate);
		GameEventDispatcher.AddListener(GameEventType.SaveRemoved, OnSaveFilesUpdate);
		GameEventDispatcher.AddListener(GameEventType.SaveOverwritten, OnSaveFilesUpdate);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameEventDispatcher.RemoveListener(GameEventType.SaveAdded, OnSaveFilesUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.SaveRemoved, OnSaveFilesUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.SaveOverwritten, OnSaveFilesUpdate);
	}

	private void OnSaveFilesUpdate(GameEvent gameEvent)
	{
		base.gameObject.SetActive(value: false);
	}

	public void CreateNewSave()
	{
		if (PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputSaveName, Community.PlayerCommunity.Name))
		{
			PopUpDialog.Instance.InputEvent += HandleNewSaveDialog;
		}
	}

	private void HandleNewSaveDialog(string newSaveName, bool dialogFeedback)
	{
		PopUpDialog.Instance.InputEvent -= HandleNewSaveDialog;
		if (!dialogFeedback)
		{
			return;
		}
		if (Session.Profile.ActiveRun.TryGetSave(out _saveToOverwrite, newSaveName))
		{
			SaveDialogProperties saveDialogProperties = Object.Instantiate(GameManager.Settings.UISettings.OverwriteSaveProperties);
			saveDialogProperties.Initialize(_saveToOverwrite);
			if (PopUpDialog.Instance.TryOpenPopUpDialog(saveDialogProperties))
			{
				PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleOverwriteDialog);
			}
		}
		else
		{
			Session.Profile.ActiveRun.Save(newSaveName);
		}
	}

	private void HandleOverwriteDialog(bool overwrite)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleOverwriteDialog);
		if (overwrite && _saveToOverwrite != null)
		{
			Session.Profile.ActiveRun.Save(_saveToOverwrite);
		}
	}

	private void UpdateSaveFiles(List<SaveInfo> saves)
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			_slots[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < saves.Count; j++)
		{
			SaveInfo saveInfo = saves[j];
			if (saveInfo.Type == SaveType.Manual)
			{
				SaveAsSlot saveAsSlot;
				if (j < _slots.Count)
				{
					saveAsSlot = _slots[j];
				}
				else
				{
					saveAsSlot = Object.Instantiate(_slotPrefab, _slotParent);
					_slots.Add(saveAsSlot);
				}
				saveAsSlot.Initialize(saveInfo);
			}
		}
	}
}
