using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class TitleImageLoc : EntityBehaviourBase
{
	public Image titleImage;

	public Sprite[] titleSprites;

	private static readonly int SETTINGLANGUAGE_ID = AggroSettings.IdToHash("game-language");

	protected override void OnUpdatePresentation()
	{
		LanguageSetting setting = AggroSettings.GetSetting<LanguageSetting>(SETTINGLANGUAGE_ID);
		Sprite sprite = titleSprites[(int)setting.currentLanguage];
		if (sprite != null)
		{
			titleImage.sprite = sprite;
		}
		else
		{
			titleImage.sprite = titleSprites[0];
		}
	}
}
