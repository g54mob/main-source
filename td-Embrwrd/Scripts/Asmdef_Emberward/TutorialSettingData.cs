using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialSettingData", menuName = "設定檔/TutorialSettingData")]
public class TutorialSettingData : ScriptableObject
{
	[Serializable]
	public class TutorialSetting
	{
		public eTutorialType tutorialType;

		public Sprite sprite;

		public bool isShowInJournal;

		private Color GetEditorSpriteColor()
		{
			return default(Color);
		}

		public bool DoShowInJournal()
		{
			return false;
		}
	}

	[SerializeField]
	private Sprite sprite_Fallback;

	[SerializeField]
	private List<TutorialSetting> list_TutorialSettings;

	public List<TutorialSetting> List_TutorialSettings => null;

	public Sprite GetSprite(eTutorialType tutorialType)
	{
		return null;
	}
}
