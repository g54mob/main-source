using CTS.Core;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class QuestTrackerQuestEntry : CTSBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _textDescription;

		[SerializeField]
		private Image _progressFill;

		[SerializeField]
		private Color _progressBarSuccessColor;

		[SerializeField]
		private GameObject _successOverlay;

		[SerializeField]
		private EntryHelpTooltip _toolTipsShower;

		[SerializeField]
		private Image _backgroundImage;

		private LocalizedString _localizedQuestEntryName = new LocalizedString();

		private Color _progressBarBaseColor;

		private Quest _assignedQuest;

		private int _assignedEntry = -1;

		protected override void OnAwake()
		{
			_progressBarBaseColor = _progressFill.color;
		}

		protected override void OnDisabled()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocalizationSettings_SelectedLocaleChanged;
			if ((bool)_assignedQuest)
			{
				_assignedQuest.EntryUpdated -= OnQuestEntryUpdated;
			}
		}

		protected override void OnEnabled()
		{
			LocalizationSettings.SelectedLocaleChanged += OnLocalizationSettings_SelectedLocaleChanged;
		}

		public void SetBackgroundColor(Color color)
		{
			_backgroundImage.color = color;
		}

		private void OnLocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			UpdateEntryProgress();
		}

		public void ResetEntry()
		{
			_localizedQuestEntryName.SetReference("", "");
			base.gameObject.name = "Entry";
			if ((bool)_assignedQuest)
			{
				_assignedQuest.EntryUpdated -= OnQuestEntryUpdated;
			}
			_assignedQuest = null;
			_assignedEntry = -1;
			_progressFill.color = _progressBarBaseColor;
			SetProgressFill(0f, 0f);
			_toolTipsShower.ResetReferences();
		}

		public void AssignEntry(Quest quest, int entryNumber)
		{
			_assignedQuest = quest;
			_assignedQuest.EntryUpdated += OnQuestEntryUpdated;
			_assignedEntry = entryNumber;
			string questGUID = _assignedQuest.QuestGUID;
			string text = GUIDHelper.FindTableID(questGUID);
			_localizedQuestEntryName.SetReference(text, questGUID + "_Entry_" + _assignedEntry);
			_textDescription.text = FormattedText.Parse(_localizedQuestEntryName.GetLocalizedString(), DialogueManager.masterDatabase.emphasisSettings).text;
			base.transform.name = _textDescription.text;
			_progressBarBaseColor = _progressFill.color;
			_toolTipsShower.SetQuestEntry(_assignedQuest.QuestName, _assignedQuest.QuestGUID, _assignedEntry);
			UpdateEntryProgress(smoothUpdate: false);
		}

		private void OnQuestEntryUpdated(int entry)
		{
			if (entry == _assignedEntry)
			{
				UpdateEntryProgress();
			}
		}

		public void UpdateEntryProgress(bool smoothUpdate = true)
		{
			if (!_assignedQuest)
			{
				return;
			}
			bool flag = QuestLog.GetQuestEntryState(_assignedQuest.QuestName, _assignedEntry) == QuestState.Success;
			_successOverlay.SetActive(flag);
			if (flag)
			{
				SetupSuccessVisuals(smoothUpdate);
				return;
			}
			_progressFill.color = _progressBarBaseColor;
			_textDescription.color = Color.white;
			Lua.Result questField = DialogueLua.GetQuestField(_assignedQuest.QuestName, "Entry " + _assignedEntry + " Progress");
			bool num = questField.luaValue == null || !questField.HasReturnValue || !DialogueLua.DoesVariableExist(questField.AsString);
			Lua.Result questField2 = DialogueLua.GetQuestField(_assignedQuest.QuestName, "Entry " + _assignedEntry + " Max");
			bool flag2 = questField2.luaValue == null || !questField2.HasReturnValue || !DialogueLua.DoesVariableExist(questField2.AsString);
			bool num2 = num || flag2;
			float endValue = (flag ? 1f : 0f);
			if (!num2 && !flag)
			{
				float asFloat = DialogueLua.GetVariable(questField.AsString).AsFloat;
				float asFloat2 = DialogueLua.GetVariable(questField2.AsString).AsFloat;
				endValue = ((!(asFloat > asFloat2)) ? (asFloat / asFloat2) : Mathf.InverseLerp(asFloat2 + 10f, asFloat2, asFloat));
			}
			SetProgressFill(endValue, smoothUpdate ? 0.2f : 0f);
		}

		private void SetupSuccessVisuals(bool smoothUpdate)
		{
			_progressFill.color = _progressBarSuccessColor;
			SetProgressFill(1f, smoothUpdate ? 0.2f : 0f);
			_textDescription.color = Color.grey;
		}

		private void SetProgressFill(float endValue, float duration)
		{
			_progressFill.DOKill();
			_progressFill.DOFillAmount(endValue, duration).SetUpdate(isIndependentUpdate: true);
		}
	}
}
