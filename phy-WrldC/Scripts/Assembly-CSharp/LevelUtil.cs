using UnityEngine;

public static class LevelUtil
{
	public static (string groupName, string levelName) GetLevelNames(LevelModel levelModel)
	{
		string text = LanguagesManager.Instance.GetText("level.name." + levelModel.Id, levelModel.Name);
		string item = "";
		switch (levelModel.Place)
		{
		case LevelModel.LevelPlace.Campaign:
		{
			(string, int) levelGroupInfos = GameManager.Instance.GroupCampaignModel.GetLevelGroupInfos(levelModel);
			if (!string.IsNullOrEmpty(levelGroupInfos.Item1))
			{
				text = levelGroupInfos.Item2 + " - " + text;
				(item, _) = levelGroupInfos;
			}
			break;
		}
		case LevelModel.LevelPlace.Sandbox:
			item = LanguagesManager.Instance.GetText("label.text.level.groupname.sandbox", "Sandbox");
			break;
		case LevelModel.LevelPlace.Tutorial:
			item = LanguagesManager.Instance.GetText("label.text.level.groupname.tutorial", "Tutorial");
			break;
		case LevelModel.LevelPlace.User:
			item = LanguagesManager.Instance.GetText("label.text.level.groupname.user", "My Level");
			break;
		case LevelModel.LevelPlace.Workshop:
			item = LanguagesManager.Instance.GetText("label.text.level.groupname.workshop", "Community Level");
			break;
		case LevelModel.LevelPlace.Test:
			item = LanguagesManager.Instance.GetText("label.text.level.groupname.test", "Level Editor - Test");
			break;
		}
		return (groupName: item, levelName: text);
	}

	public static void SetLevelMusic(LevelModel levelModel)
	{
		AudioClip audioClip = null;
		switch (levelModel.Place)
		{
		case LevelModel.LevelPlace.Campaign:
		case LevelModel.LevelPlace.Tutorial:
		case LevelModel.LevelPlace.Template:
		case LevelModel.LevelPlace.User:
		case LevelModel.LevelPlace.Workshop:
			audioClip = GameManager.Instance.GameStylesData.musicStylesData.campaignLevelClip;
			break;
		case LevelModel.LevelPlace.Sandbox:
		case LevelModel.LevelPlace.Test:
			audioClip = GameManager.Instance.GameStylesData.musicStylesData.sandboxLevelClip;
			break;
		default:
			audioClip = GameManager.Instance.GameStylesData.musicStylesData.campaignLevelClip;
			break;
		}
		GameManager.Instance.MusicManager.PlayMusic(audioClip, GameManager.Instance.GameStylesData.volumeStylesData.musicVolume);
	}
}
