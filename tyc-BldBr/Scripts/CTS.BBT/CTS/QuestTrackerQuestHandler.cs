using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class QuestTrackerQuestHandler : CTSBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _questNameLabel;

		[SerializeField]
		private GameObject _activePanel;

		[SerializeField]
		private RectTransform _entriesContainer;

		[SerializeField]
		private GameObject _rewardPanel;

		[BoxGroup("Entry Data")]
		[SerializeField]
		private QuestTrackerQuestEntry _questEntryTemplate;

		[BoxGroup("Entry Data")]
		[SerializeField]
		private Color _firstEntryColor;

		[BoxGroup("Entry Data")]
		[SerializeField]
		private Color _secondEntryColor;

		[BoxGroup("Entry Data")]
		[SerializeField]
		private float _entrySizes = 100f;

		private List<QuestTrackerQuestEntry> _entries = new List<QuestTrackerQuestEntry>();

		private Quest _currentlyShownQuest;

		private bool _colorsInverted;

		protected override void OnAwake()
		{
			_entries.Add(_questEntryTemplate);
			_questEntryTemplate.SetBackgroundColor(_firstEntryColor);
		}

		protected override void OnDisabled()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocalizationSettings_SelectedLocaleChanged;
			QuestTrackerManager.CurrentQuestChanged -= ShowQuest;
		}

		protected override void OnEnabled()
		{
			LocalizationSettings.SelectedLocaleChanged += OnLocalizationSettings_SelectedLocaleChanged;
			QuestTrackerManager.CurrentQuestChanged += ShowQuest;
		}

		private void OnLocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if ((bool)_currentlyShownQuest)
			{
				UpdateLabels();
			}
		}

		private void UpdateLabels()
		{
			_questNameLabel.text = _currentlyShownQuest.QuestLocalizedName;
			base.transform.name = _currentlyShownQuest.QuestName;
			AddEntries();
		}

		private void ResetEntries()
		{
			foreach (QuestTrackerQuestEntry entry in _entries)
			{
				entry.ResetEntry();
				entry.gameObject.SetActive(value: false);
			}
		}

		private void AddEntries()
		{
			ResetEntries();
			int questEntriesAmount = _currentlyShownQuest.QuestEntriesAmount;
			_entriesContainer.gameObject.SetActive(questEntriesAmount > 0);
			for (int i = 0; i < questEntriesAmount; i++)
			{
				if (_entries.Count <= i)
				{
					InstantiateEntry(_entriesContainer);
				}
				_entries[i].gameObject.SetActive(value: true);
				_entries[i].AssignEntry(_currentlyShownQuest, i + 1);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(_entriesContainer);
		}

		public void ResetInformations()
		{
			_currentlyShownQuest = null;
			ResetEntries();
			UpdateLabels();
		}

		public void ShowQuest(Quest quest)
		{
			SetupPanels(quest.QuestState == QuestState.ReturnToNPC);
			if (!(_currentlyShownQuest == quest))
			{
				_currentlyShownQuest = quest;
				UpdateLabels();
			}
		}

		private void InstantiateEntry(Transform container)
		{
			QuestTrackerQuestEntry questTrackerQuestEntry = Object.Instantiate(_questEntryTemplate);
			questTrackerQuestEntry.transform.SetParent(container.transform, worldPositionStays: false);
			_entries.Add(questTrackerQuestEntry);
			RectTransform obj = (RectTransform)questTrackerQuestEntry.transform;
			Vector2 sizeDelta = obj.sizeDelta;
			sizeDelta.y = _entrySizes;
			obj.sizeDelta = sizeDelta;
			if (_colorsInverted)
			{
				questTrackerQuestEntry.SetBackgroundColor(((_entries.Count - 1) % 2 <= 0) ? _secondEntryColor : _firstEntryColor);
			}
			else
			{
				questTrackerQuestEntry.SetBackgroundColor(((_entries.Count - 1) % 2 <= 0) ? _firstEntryColor : _secondEntryColor);
			}
		}

		public void InvertColors(bool invert)
		{
			if (_colorsInverted == invert)
			{
				return;
			}
			_colorsInverted = invert;
			if (_colorsInverted)
			{
				for (int i = 0; i < _entries.Count; i++)
				{
					_entries[i].SetBackgroundColor((i % 2 <= 0) ? _secondEntryColor : _firstEntryColor);
				}
			}
			else
			{
				for (int j = 0; j < _entries.Count; j++)
				{
					_entries[j].SetBackgroundColor((j % 2 <= 0) ? _firstEntryColor : _secondEntryColor);
				}
			}
		}

		private void SetupPanels(bool success)
		{
			_activePanel.SetActive(!success);
			_rewardPanel.SetActive(success);
		}

		public void ValidateQuest()
		{
			_currentlyShownQuest.ValidateQuest();
		}
	}
}
