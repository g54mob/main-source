using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI.Apps
{
	public class CodeEditorSettingsApp : MultiToolApp
	{
		[SerializeField]
		private UIToggle wordWrapToggle;

		[SerializeField]
		private UIToggle autoIndentToggle;

		[SerializeField]
		private UIButton chooseCodeEditModeButton;

		private List<TableEntryReference> toggles;

		private Dictionary<DebugApp.EditMode, TableEntryReference> editModeDict;

		private LocalizedString currentLocalizedStringEditMode;

		private UISettingsExclusiveChoiceToggle<DebugApp.EditMode> settingsM;

		public override void Init()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public void ApplyWordWrapPerfect(bool value)
		{
		}

		public void ApplyAutoIndent(bool value)
		{
		}

		public void SetEditMode(DebugApp.EditMode currentPreset)
		{
		}

		private void ModifyEditModePreset(DebugApp.EditMode currentPreset)
		{
		}
	}
}
