using System.Collections.Generic;
using UI.Elements;
using UI.SmallCanvas;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI.Apps
{
	public class VideoRecorderSettingsApp : MultiToolApp
	{
		[SerializeField]
		private UIButton openVideoFolderButton;

		[SerializeField]
		private UIButton chooseVideoFormatButton;

		[SerializeField]
		private UIInputField deltaTimeStarting;

		[SerializeField]
		private VideoRecorderSmall smallPanelPrefab;

		private VideoRecorderSmall smallPanel;

		private TableReference tableLocalizationReference;

		private List<TableEntryReference> toggles;

		private Dictionary<VideoRecordPresetId, TableEntryReference> formatDict;

		private LocalizedString currentLocalizedStringFormat;

		private UISettingsExclusiveChoiceToggle<VideoRecordPresetId> settingsM;

		public override void Init()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public void OpenVideoFolder()
		{
		}

		private void OpenFolderConfirm(bool confirm)
		{
		}

		public void SetFormat(VideoRecordPresetId currentPreset)
		{
		}

		private void ModifyFormatPreset(VideoRecordPresetId currentPreset)
		{
		}

		private void ModifyDeltaTimeStarting(string sec)
		{
		}
	}
}
