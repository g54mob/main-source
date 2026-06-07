using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace UI.Apps
{
	public class SettingsApp : MultiToolApp
	{
		[SerializeField]
		private UIButton chooseLanguageButton;

		[SerializeField]
		private UISlider musicVolume;

		[SerializeField]
		private UISlider sfxVolume;

		[SerializeField]
		private UIToggle pixelPerfect;

		[SerializeField]
		private UIToggle bloom;

		[SerializeField]
		private UIButton videoRecorderSettingsButton;

		[SerializeField]
		private UIButton codeEditorSettingsButton;

		private List<TableEntryReference> languageToggles;

		private Dictionary<ExistingLanguages, TableEntryReference> formatDict;

		private UISettingsExclusiveChoiceToggle<ExistingLanguages> settingsM;

		public override void Init()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public void ApplyMusicVolume(float value)
		{
		}

		public void ApplySfxVolume(float value)
		{
		}

		public void ApplyPixelPerfect(bool value)
		{
		}

		public void ApplyBloom(bool value)
		{
		}

		public void SetLanguage(ExistingLanguages language)
		{
		}

		private void ModifyLanguagePreset(ExistingLanguages language)
		{
		}
	}
}
