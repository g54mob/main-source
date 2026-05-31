using System;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class EntryHelpTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private LocalizedString _helpText = new LocalizedString();

		private string _questName = "";

		private string _questGuid = "";

		private int _entryNumber = -1;

		private bool _onPointer;

		[field: SerializeField]
		public GameObject Target { get; private set; }

		[field: SerializeField]
		public TooltipsShowingInfo TooltipsShowing { get; private set; }

		public static event Action EntryTooltipShowned;

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocalizationSettings_SelectedLocaleChanged;
			OnPointerExit(null);
		}

		private void OnEnable()
		{
			LocalizationSettings.SelectedLocaleChanged += OnLocalizationSettings_SelectedLocaleChanged;
		}

		private void OnLocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if (_onPointer)
			{
				SetInfos();
			}
		}

		public void ResetReferences()
		{
			_questName = "";
			_questGuid = "";
			_entryNumber = -1;
			_helpText.SetReference("", "");
		}

		public void SetQuestEntry(string questName, string guid, int entryNumber)
		{
			_questName = questName;
			_questGuid = guid;
			_entryNumber = entryNumber;
			string text = GUIDHelper.FindTableID(questName);
			_helpText.SetReference(text, _questGuid + "_Entry_" + _entryNumber + "_Help");
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (MonoSingleton<TooltipsManager>.InstanceExists())
			{
				if (Target != null)
				{
					MonoSingleton<TooltipsManager>.Instance.HideIfIsTarget(Target);
				}
				else
				{
					MonoSingleton<TooltipsManager>.Instance.Hide();
				}
				_onPointer = false;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_onPointer = true;
			SetInfos();
		}

		private void SetInfos()
		{
			MonoSingleton<TooltipsManager>.Instance.Show(FormattedText.Parse(QuestLog.GetQuestEntry(_questName, _entryNumber), DialogueManager.masterDatabase.emphasisSettings).text, _helpText.IsEmpty ? "" : _helpText.GetLocalizedString(), Target, TooltipsShowing);
			EntryHelpTooltip.EntryTooltipShowned?.Invoke();
		}
	}
}
