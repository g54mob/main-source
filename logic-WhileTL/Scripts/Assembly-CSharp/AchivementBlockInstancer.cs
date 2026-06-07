using Localization;
using UnityEngine;
using UnityEngine.UI;

public class AchivementBlockInstancer : ActiveComponent
{
	public void Init(string achivementName, bool hidden, bool big = true)
	{
		base.Init();
		Image image = base.gameObject.GetComponentsInChildren<Image>()[1];
		Text[] componentsInChildren = base.gameObject.GetComponentsInChildren<Text>();
		if (hidden && !ActiveComponent.Model.globalSaves.gainedAchivements.Contains(achivementName))
		{
			image.sprite = Logic.LoadSprite("Achievements/ACHIEVEMENT_HIDDEN");
			componentsInChildren[0].text = Logic.ColorTransform("GREEN", TextResources.GetString("ACHIEVEMENT_HIDDENT"));
			if (big)
			{
				componentsInChildren[1].text = TextResources.GetString("ACHIEVEMENT_HIDDEN");
			}
			return;
		}
		Sprite sprite = Logic.LoadSprite("Achievements/" + achivementName + (ActiveComponent.Model.globalSaves.gainedAchivements.Contains(achivementName) ? "_unlocked" : "_locked"));
		image.sprite = sprite;
		componentsInChildren[0].text = Logic.ColorTransform("GREEN", TextResources.GetString(achivementName + "T"));
		if (big)
		{
			componentsInChildren[1].text = TextResources.GetString(achivementName);
		}
	}

	public void Init(AchivementData achivementData, bool big = true)
	{
		Init(achivementData.KeyName, achivementData.Hidden, big);
	}
}
