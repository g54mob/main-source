using System;
using UI.Apps;
using UI.Common;
using UnityEngine;

public class ConfigurationController : Controller, ILogOrigin
{
	public class ConfigurationData
	{
		public bool video_pixelPerfect;

		public bool video_bloom;

		public float audio_musicVolume;

		public float audio_sfxVolume;

		public Color spriteEditor_zoomGridColor;

		public Color spriteEditor_imageGridColor;

		[IniFile.NoAlpha]
		public Color spriteEditor_backgroundColor1;

		[IniFile.NoAlpha]
		public Color spriteEditor_backgroundColor2;

		public VideoRecordPresetId videoRecorder_videoRecorderPreset;

		public int videoRecorder_deltaTimeStarting;

		public bool codeEditor_wordWrap;

		public bool codeEditor_autoIndent;

		public DebugApp.EditMode codeEditor_editMode;

		public string workbench_cuttingMat;

		public ExistingLanguages language_currentLanguage;
	}

	private string path;

	private IniFile iniFile;

	[NonSerialized]
	[HideInInspector]
	public ConfigurationData data;

	public override void Init()
	{
	}

	private void Load()
	{
	}

	public void Save()
	{
	}
}
