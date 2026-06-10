using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "helpcontent_data", menuName = "Database/Help Content Page")]
public class HelpContentPage : SoCustomComparison
{
	[Serializable]
	public class HelpContentDisplay
	{
		public DisplaySetting helpDisplaySetting;

		public VideoClip clip;

		public Texture2D image;
	}

	public enum DisplaySetting
	{
		dontDisplay = 0,
		displayBeforeText = 1,
		displayAfterText = 2
	}

	public bool disabled;

	public string messageID;

	public List<HelpContentDisplay> contentDisplay;
}
