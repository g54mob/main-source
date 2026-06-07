using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI
{
	public class UISettingsExclusiveChoiceToggle<T>
	{
		private TableReference tableLocalizationReference;

		private TableEntryReference titleEntryRef;

		private TableEntryReference messageEntryRef;

		private Dictionary<T, TableEntryReference> modeDict;

		private LocalizedString currentLocalizedStringEditMode;

		private UIButton chooseFormatButton;

		public Action<T> OnModeChosen;

		private T currentPreset;

		public void Init(Dictionary<T, TableEntryReference> modeDict, Action<T> OnModeChosen, UIButton chooseFormatButton, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef)
		{
		}

		public void SetCurrentFormat(T currentFormat)
		{
		}

		public void ChooseSettingsMode(List<TableEntryReference> toggles)
		{
		}

		public void OnCodeModeChoosen(List<UIToggle> toggles)
		{
		}

		private string GetButtonNameCurrentMode()
		{
			return null;
		}

		private string GetButtonName(T editMode)
		{
			return null;
		}

		private T GetCurrentButtonEnumValue(string enumInString)
		{
			return default(T);
		}
	}
}
