using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class SavefileListUI : MonoBehaviour
	{
		public SavefileListEntry SavePrefab;

		public UIGrid ResultGrid;

		public UIScrollView ResultScrollView;

		public SavefileDetailPanel DetailPanel;

		private List<SaveData> _saves;

		private List<SavefileListEntry> _listEntries;

		private string _originalLanguage;

		private SavefileListEntry _selectedSaveFile;

		[HideInInspector]
		public SavefileListEntry SelectedSaveFile
		{
			get
			{
				return _selectedSaveFile;
			}
			set
			{
				if (DetailPanel.gameObject.activeSelf && _selectedSaveFile != null)
				{
					DetailPanel.OnClose();
				}
				_selectedSaveFile = value;
				DetailPanel.gameObject.SetActive(SelectedSaveFile != null);
				if (_selectedSaveFile != null)
				{
					DetailPanel.Init(_selectedSaveFile);
				}
			}
		}

		public void Start()
		{
			_originalLanguage = RuntimeGlobals.Settings.SelectedLanguage;
			FillupSaves();
		}

		public void Update()
		{
			if (!(_selectedSaveFile != null) || !(RuntimeGlobals.Settings.SelectedLanguage != _originalLanguage))
			{
				return;
			}
			List<SavefileListEntry> listEntries = _listEntries;
			if (listEntries != null)
			{
				listEntries.ForEach(delegate(SavefileListEntry e)
				{
					e.UpdateDescription(_selectedSaveFile.Save);
				});
			}
			DetailPanel.UpdateTranslation(_selectedSaveFile);
			_originalLanguage = RuntimeGlobals.Settings.SelectedLanguage;
		}

		public void FillupSaves()
		{
			ResultScrollView.ResetPosition();
			ResultGrid.transform.DestroyAllChildren();
			_saves = SaveManager.GetAllSaves();
			if (_listEntries == null)
			{
				_listEntries = new List<SavefileListEntry>();
			}
			else
			{
				_listEntries.Clear();
			}
			foreach (SaveData safe in _saves)
			{
				SavefileListEntry savefileListEntry = Object.Instantiate(SavePrefab);
				savefileListEntry.Init(this, safe);
				savefileListEntry.gameObject.transform.position = ResultGrid.transform.position;
				savefileListEntry.gameObject.transform.parent = ResultGrid.transform;
				savefileListEntry.gameObject.transform.localScale = ResultGrid.transform.localScale;
				if (SelectedSaveFile == null)
				{
					SelectedSaveFile = savefileListEntry;
				}
				_listEntries.Add(savefileListEntry);
			}
			ResultGrid.enabled = true;
			ResultGrid.Reposition();
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
			DetailPanel.gameObject.SetActive(SelectedSaveFile != null);
			if (SelectedSaveFile != null)
			{
				DetailPanel.Init(SelectedSaveFile);
			}
		}
	}
}
